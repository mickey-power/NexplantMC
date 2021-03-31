/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSocketEventPusher.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.22
--  Description     : FAMate Core FaCommon Socket Event Pusher Class
--  History         : Created by spike.lee at 2011.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FSocketEventPusher : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        FISocket m_fSocket = null;
        private FQueue<FSocketEventArgsBase> m_fEvents = null;
        // --
        private FThread m_fEventPusher = null;
        private bool m_isCompletedEventHandling = false;
        private bool m_suspended = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSocketEventPusher(
            FISocket fSocket,
            bool suspended
            )
        {
            m_fSocket = fSocket;
            m_fEvents = new FQueue<FSocketEventArgsBase>();
            m_suspended = suspended;

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSocketEventPusher(
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
                    term();

                    // --

                    if (m_fEvents != null)
                    {
                        m_fEvents.Dispose();
                        m_fEvents = null;
                    }
                    // --
                    m_fSocket = null;
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

        public int eventCount
        {
            get
            {
                try
                {
                    return m_fEvents.count;
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

        public bool isCompletedEventHandling
        {
            get
            {
                try
                {
                    if (this.eventCount == 0 && m_isCompletedEventHandling)
                    {
                        return true;
                    }
                    return false;
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

        public bool suspended
        {
            get
            {
                try
                {
                    return m_suspended;
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

        private void init(
            )
        {
            try
            {
                m_isCompletedEventHandling = true;
                m_fEventPusher = new FThread("SocketEventPusherThread", false, System.Threading.ThreadPriority.Normal, false);
                m_fEventPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);
                m_fEventPusher.start();
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

        private void term(
            )
        {
            try
            {
                if (m_fEventPusher != null)
                {
                    while (!this.isCompletedEventHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fEventPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);
                    // --
                    m_fEventPusher.stop();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
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

        public void pushEvent(
            FSocketEventArgsBase fSocketEvent
            )
        {
            try
            {
                m_fEvents.enqueue(fSocketEvent);
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

        public void pushEvent(
            FSocketEventArgsBase[] fSocketEvents
            )
        {
            try
            {
                m_fEvents.enqueue(fSocketEvents);
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

        public void suspend(
            )
        {
            try
            {
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                while (!this.isCompletedEventHandling)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fEventPusher Object Event Handler

        private void m_fEventPusher_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            FSocketEventArgsBase args = null;

            try
            {
                if (m_fEvents.count == 0)
                {
                    m_isCompletedEventHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompletedEventHandling = false;

                // --

                if (m_suspended)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                while (!m_suspended && (args = m_fEvents.dequeue()) != null)
                {
                    if (m_fSocket.fSocketType == FSocketType.Listener)
                    {
                        // ***
                        // FTcpListener
                        // ***
                        if (args.fSocketEventId == FSocketEventId.TcpListenerAcceptCompleted)
                        {
                            ((FTcpListener)m_fSocket).onTcpListenerAcceptCompleted(args);
                        }
                        else if (args.fSocketEventId == FSocketEventId.TcpListenerErrorRaised)
                        {
                            ((FTcpListener)m_fSocket).onTcpListenerErrorRaised(args);
                        }
                    }
                    else
                    {
                        // ***
                        // FTcpClient
                        // ***
                        if (args.fSocketEventId == FSocketEventId.TcpClientStateChanged)
                        {
                            ((FTcpClient)m_fSocket).onTcpClientStateChanged(args);
                        }
                        else if (args.fSocketEventId == FSocketEventId.TcpClientDataReceived)
                        {
                            ((FTcpClient)m_fSocket).onTcpClientDataReceived(args);
                        }
                        else if (args.fSocketEventId == FSocketEventId.TcpClientDataSent)
                        {
                            ((FTcpClient)m_fSocket).onTcpClientDataSent(args);
                        }
                        else if (args.fSocketEventId == FSocketEventId.TcpClientDataSendFailed)
                        {
                            ((FTcpClient)m_fSocket).onTcpClientDataSendFailed(args);
                        }
                        else if (args.fSocketEventId == FSocketEventId.TcpClientErrorRaised)
                        {
                            ((FTcpClient)m_fSocket).onTcpClientErrorRaised(args);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                args = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
