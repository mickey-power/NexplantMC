/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventPusher.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Event Pusher Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FEventPusher: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSerialToEthernet m_fSerialToTcp = null;
        // --
        private FQueue<FEventArgsBase> m_fSerialEvents = null;
        private FQueue<FEventArgsBase> m_fTcpEvents = null;
        private FThread m_fThdEventPusher = null;
        private bool m_isCompletedEventHandling = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEventPusher(
            FSerialToEthernet fSerialToTcp
            )
        {
            m_fSerialToTcp = fSerialToTcp;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventPusher(
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
                    m_fSerialToTcp = null;
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

        public int serialEventCount
        {
            get
            {
                try
                {
                    return m_fSerialEvents.count;
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

        public int tcpEventCount
        {
            get
            {
                try
                {
                    return m_fTcpEvents.count;
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
                    if (this.serialEventCount == 0 && this.tcpEventCount == 0 && m_isCompletedEventHandling)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fSerialEvents = new FQueue<FEventArgsBase>();
                m_fTcpEvents = new FQueue<FEventArgsBase>();

                // --

                m_isCompletedEventHandling = true;
                m_fThdEventPusher = new FThread("EventPushThread", false, System.Threading.ThreadPriority.Normal, true);
                m_fThdEventPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdEventPusher_ThreadJobCalled);
                m_fThdEventPusher.start();
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
                if (m_fThdEventPusher != null)
                {
                    while (!this.isCompletedEventHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fThdEventPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdEventPusher_ThreadJobCalled);
                    m_fThdEventPusher.stop();
                    m_fThdEventPusher.Dispose();
                    m_fThdEventPusher = null;
                }

                if (m_fSerialEvents != null)
                {
                    m_fSerialEvents.Dispose();
                    m_fSerialEvents = null;
                }

                if (m_fTcpEvents != null)
                {
                    m_fTcpEvents.Dispose();
                    m_fTcpEvents = null;
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

        public void pushSerialEvent(
            FEventArgsBase fArgs
            )
        {
            try
            {
                m_fSerialEvents.enqueue(fArgs);
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

        public void pushTcpEvent(
            FEventArgsBase fArgs
            )
        {
            try
            {
                m_fTcpEvents.enqueue(fArgs);
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

        #region m_fThdEventHandler Object Event Handler

        private void m_fThdEventPusher_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            try
            {
                if (this.serialEventCount == 0 && this.tcpEventCount == 0)
                {
                    m_isCompletedEventHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompletedEventHandling = false;

                // --

                while (this.serialEventCount > 0)
                {
                    m_fSerialToTcp.onEventRaised(m_fSerialEvents.dequeue());
                }

                // --

                while (this.tcpEventCount > 0)
                {
                    m_fSerialToTcp.onEventRaised(m_fTcpEvents.dequeue());
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
