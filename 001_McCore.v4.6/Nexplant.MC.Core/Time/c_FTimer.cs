/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTimer.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.22
--  Description     : FAMate Core FaCommon Timer Class
--  History         : Created by spike.lee at 2010.12.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FTimer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FTimerElapsedEventHandler TimerElapsed = null;

        private bool m_disposed = false;
        // --
        private string m_name = string.Empty;
        private bool m_atOnce = false;
        private int m_period = 0;
        private bool m_asyncEvent = false;
        private bool m_enabled = false;
        // --        
        private FThread m_fThread = null;
        private IAsyncResult m_ar = null;
        private FTimerElapsedEventArgs m_fTimeElapsedEventArgs = null;
        private long m_ticks = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTimer(
            string name, 
            bool atOnce,
            int period,
            bool asyncEvent
            )
        {
            m_name = name;
            m_atOnce = atOnce;
            m_period = period;
            m_asyncEvent = asyncEvent;
        }

        //------------------------------------------------------------------------------------------------------------------------       

        ~FTimer(
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

        public bool atOnce
        {
            get
            {
                try
                {
                    return m_atOnce;
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

        public int period
        {
            get
            {
                try
                {
                    return m_period;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool enabled
        {
            get
            {
                try
                {
                    return m_enabled;
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

        public void start(
            )
        {
            try
            {
                if (m_enabled)
                {
                    return;
                }

                // --

                m_enabled = true;                
                if (m_fTimeElapsedEventArgs == null)
                {
                    m_fTimeElapsedEventArgs = new FTimerElapsedEventArgs(this);
                }

                // --

                if (m_atOnce)
                {
                    m_ticks = FTickCount.addTicks(FTickCount.ticks, m_period * -1);
                }
                else
                {
                    m_ticks = FTickCount.ticks;
                }

                // --

                m_fThread = new FThread("FTimer_" + m_name);
                m_fThread.ThreadJobCalled += new FThreadJobCalledEventHandler(m_thread_ThreadJobCalled);
                m_fThread.start();
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
                if (!m_enabled)
                {
                    return;
                }

                if (m_fThread != null)
                {
                    m_fThread.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_thread_ThreadJobCalled);   
                    m_fThread.stop();
                    m_fThread.Dispose();
                    m_fThread = null;
                }
                m_enabled = false;
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

        public void restart(
            )
        {
            try
            {
                if (m_enabled)
                {
                    stop();
                }
                start();
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

        private IAsyncResult onTimerElapsed(            
            )
        {
            IAsyncResult ar = null;

            try
            {
                if (TimerElapsed != null)
                {
                    if (m_asyncEvent)
                    {
                        ar = TimerElapsed.BeginInvoke(this, m_fTimeElapsedEventArgs, new AsyncCallback(eventAsyncCallback), TimerElapsed);
                    }
                    else
                    {
                        TimerElapsed(this, m_fTimeElapsedEventArgs);
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

        private void eventAsyncCallback(
            IAsyncResult ar
            )
        {
            try
            {
                if (ar.AsyncState is FTimerElapsedEventHandler)
                {
                    ((FTimerElapsedEventHandler)ar.AsyncState).EndInvoke(ar);
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

        #region m_thread Object Event Handler

        private void m_thread_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (m_ar != null)
                {
                    if (!m_ar.AsyncWaitHandle.WaitOne(1))
                    {
                        return;
                    }
                    m_ar.AsyncWaitHandle.Dispose();
                    m_ar = null;                    
                }                

                // --                
                
                if (FTickCount.timeout(m_ticks, m_period))
                {
                    m_ticks = FTickCount.addTicks(m_ticks, m_period);
                    m_ar = onTimerElapsed();                    
                }
                else
                {
                    e.sleepThread(1);
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
