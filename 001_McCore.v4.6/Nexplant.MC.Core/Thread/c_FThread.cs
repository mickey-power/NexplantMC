/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FThread.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Thread Class
--  History         : Created by spike.lee at 2010.11.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    public class FThread : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FThreadStartedEventHandler ThreadStarted = null;
        public event FThreadStoppedEventHandler ThreadStopped = null;        
        public event FThreadErrorRaisedEventHandler ThreadErrorRaised = null;
        public event FThreadJobCalledEventHandler ThreadJobCalled = null;

        private const int DefaultThreadSleep = 1;
        private const int DefaultTerminateTimeout = 60000;

        private bool m_disposed = false;
        // --
        private string m_name = string.Empty;
        private bool m_isBackground = false;
        private ThreadPriority m_priority = ThreadPriority.Normal;
        private bool m_asyncEvent = false;
        // --
        private bool m_alived = false;
        private Thread m_thdJob = null;        
        // --
        private FCodeLock m_fSpdLock = null;
        private bool m_suspended = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FThread(
            string name 
            )
        {
            m_fSpdLock = new FCodeLock();
            m_name = name;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FThread(
            string name,
            bool isBackground
            )
            : this(name)
        {
            m_isBackground = isBackground;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FThread(
            string name, 
            bool isBackground, 
            ThreadPriority priority,
            bool asyncEvent
            ) : this(name)
        {
            m_isBackground = isBackground;
            m_priority = priority;
            m_asyncEvent = asyncEvent;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FThread(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    stop();
                    // --
                    if (m_fSpdLock != null)
                    {
                        m_fSpdLock.Dispose();
                        m_fSpdLock = null;
                    }

                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string name
        {
            get
            {
                try
                {
                    return m_name;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool isBackground
        {
            get
            {
                try
                {
                    return m_isBackground;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public ThreadPriority priority
        {
            get
            {
                try
                {
                    return m_priority;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return ThreadPriority.Normal;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool asyncEvent
        {
            get
            {
                try
                {
                    return m_asyncEvent;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool alived
        {
            get
            {
                try
                {
                    return m_alived;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void suspend(
            )
        {
            try
            {
                if (m_suspended)
                {
                    return;
                }

                m_fSpdLock.wait();
                m_suspended = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void resume(
            )
        {
            try
            {
                if (!m_suspended)
                {
                    return;
                }

                m_fSpdLock.set();
                m_suspended = false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void start(
            )
        {
            try
            {
                if (m_alived)
                {
                    return;
                }

                // --

                m_alived = true;
                m_thdJob = new Thread(new ThreadStart(doJob));
                m_thdJob.Name = m_name;
                m_thdJob.IsBackground = m_isBackground;
                m_thdJob.Priority = m_priority;
                m_thdJob.Start();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void stop(
            )
        {
            try
            {
                stop(DefaultTerminateTimeout);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void stop(
            int millisecondTimeout
            )
        {
            try
            {
                if (!m_alived)
                {
                    return;
                }

                // --

                m_alived = false;
                if (m_thdJob != null)
                {
                    if (!m_thdJob.Join(millisecondTimeout))
                    {
                        m_thdJob.Abort();                       
                    }                    
                    m_thdJob = null;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void doJob(
            )
        {
            FDebugLogArgs logArgs = null;
            FThreadEventArgs args = null;
            IAsyncResult ar = null;

            try
            {
                logArgs = new FDebugLogArgs(FDebugLogCategory.Information, "ThreadStart", this.GetType(), "doJob");
                logArgs.additionInfo = "ThreadName=<" + m_name + ">, ThreadId=<" + m_thdJob.ManagedThreadId.ToString() + ">, IsBackground=<" + m_isBackground.ToString() + ">, Priority=<" + m_priority.ToString() + ">, AsyncEvent=<" + m_asyncEvent.ToString() + ">";
                FDebug.writeLog(logArgs);

                // --

                args = new FThreadEventArgs(this);
                ar = onThreadStarted(args);

                // --

                while (m_alived)
                {
                    try
                    {
                        if (ar != null)
                        {
                            if (!ar.AsyncWaitHandle.WaitOne(1))
                            {
                                continue;
                            }
                            ar.AsyncWaitHandle.Dispose();
                            ar = null;
                        }                        

                        // --

                        if (m_fSpdLock.tryWait(1))
                        {
                            ar = onThreadJobCalled(args);
                        }                        
                    }
                    catch (Exception ex)
                    {
                        FDebug.writeLog(ex);
                        ar = onThreadErrorRaised(ex);
                    }
                    finally
                    {

                    }
                }

                // --

                ar = onThreadStopped(args);
                if (ar != null)
                {
                    ar.AsyncWaitHandle.WaitOne();
                }

                // --

                logArgs = new FDebugLogArgs(FDebugLogCategory.Information, "ThreadStop", this.GetType(), "doJob");
                logArgs.additionInfo = "ThreadName=<" + m_name + ">, ThreadId=<" + m_thdJob.ManagedThreadId.ToString() + ">, IsBackground=<" + m_isBackground.ToString() + ">, Priority=<" + m_priority.ToString() + ">, AsyncEvent=<" + m_asyncEvent.ToString() + ">";
                FDebug.writeLog(logArgs);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                args = null;
                ar = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private IAsyncResult onThreadStarted(
            FThreadEventArgs args
            )
        {
            IAsyncResult ar = null;

            try
            {
                if (ThreadStarted != null)
                {
                    if (m_asyncEvent)
                    {
                        ar = ThreadStarted.BeginInvoke(this, args, new AsyncCallback(eventAsyncCallback), ThreadStarted);
                    }
                    else
                    {
                        ThreadStarted(this, args);
                    }    
                }                               
                return ar;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private IAsyncResult onThreadStopped(
            FThreadEventArgs args
            )
        {
            IAsyncResult ar = null;

            try
            {
                if (ThreadStopped != null)
                {
                    if (m_asyncEvent)
                    {
                        ar = ThreadStopped.BeginInvoke(this, args, new AsyncCallback(eventAsyncCallback), ThreadStopped);     
                    }
                    else
                    {
                        ThreadStopped(this, args);
                    }
                }                
                return ar;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private IAsyncResult onThreadErrorRaised(
            Exception exception
            )
        {
            IAsyncResult ar = null;

            try
            {
                if (ThreadErrorRaised != null)
                {
                    if (m_asyncEvent)
                    {
                        ar = ThreadErrorRaised.BeginInvoke(
                            this, 
                            new FThreadErrorRaisedEventArgs(this, exception.Message, exception), 
                            new AsyncCallback(eventAsyncCallback),         
                            ThreadErrorRaised
                            );
                    }
                    else
                    {
                        ThreadErrorRaised(this, new FThreadErrorRaisedEventArgs(this, exception.Message, exception));
                    }                    
                }
                else
                {
                    Thread.Sleep(DefaultThreadSleep);
                }
                return ar;
            }
            catch (FException ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private IAsyncResult onThreadJobCalled(
            FThreadEventArgs args
            )
        {
            IAsyncResult ar = null;

            try
            {
                if (ThreadJobCalled != null)
                {
                    if (m_asyncEvent)
                    {
                        ar = ThreadJobCalled.BeginInvoke(this, args, new AsyncCallback(eventAsyncCallback), ThreadJobCalled);    
                    }
                    else
                    {
                        ThreadJobCalled(this, args);
                    }                                       
                }
                else
                {
                    Thread.Sleep(DefaultThreadSleep);
                }
                return ar;
            }
            catch (FException ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void eventAsyncCallback(
            IAsyncResult ar
            )
        {
            try
            {
                if (ar.AsyncState is FThreadJobCalledEventHandler)
                {
                    ((FThreadJobCalledEventHandler)ar.AsyncState).EndInvoke(ar);
                }
                else if (ar.AsyncState is FThreadStartedEventHandler)
                {
                    ((FThreadStartedEventHandler)ar.AsyncState).EndInvoke(ar);
                }
                else if (ar.AsyncState is FThreadStoppedEventHandler)
                {
                    ((FThreadStoppedEventHandler)ar.AsyncState).EndInvoke(ar);
                }                
                else if (ar.AsyncState is FThreadErrorRaisedEventHandler)
                {
                    ((FThreadErrorRaisedEventHandler)ar.AsyncState).EndInvoke(ar);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
