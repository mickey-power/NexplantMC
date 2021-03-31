/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpPassive.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet TCP Passive Protocol Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FTcpPassive : FBaseTcp
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpRecvBuffer m_fRecvBuf = null;
        private FTcpListener m_fTcpListener = null;
        private FTcpClient m_fTcpClient = null;
        private FCodeLock m_fMainSync = null;
        //private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpPassive(    
            FSerialToEthernet fSerialToTcp
            )
            : base(fSerialToTcp)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpPassive(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fRecvBuf = new FTcpRecvBuffer();

                // --

                m_fMainSync = new FCodeLock();
                //m_fThdMain = new FThread("FTcpPassiveMainThread");
                //m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                //m_fThdMain.start();
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
                //if (m_fThdMain != null)
                //{
                //    m_fThdMain.stop();
                //    m_fThdMain.Dispose();
                //    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                //    m_fThdMain = null;
                //}

                if (m_fTcpListener != null)
                {
                    m_fTcpListener.stop();
                    m_fTcpListener.Dispose();
                    // --
                    m_fTcpListener.TcpListenerAcceptCompleted -= new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                    m_fTcpListener.TcpListenerErrorRaised -= new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                    // --
                    m_fTcpListener = null;
                }

                if (m_fTcpClient != null)
                {
                    m_fTcpClient.close();
                    m_fTcpClient.Dispose();
                    // --
                    m_fTcpClient.TcpClientStateChanged -= new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                    m_fTcpClient.TcpClientDataReceived -= new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                    m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                    m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                    m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                    // --
                    m_fTcpClient = null;
                }

                // --

                if (m_fRecvBuf != null)
                {
                    m_fRecvBuf.Dispose();
                    m_fRecvBuf = null;
                }

                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
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

        private void sendData(
            FSocketSendData fSocketSendData
            )
        {
            try
            {
                m_fTcpClient.send(fSocketSendData);
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

        private void recvData(
            )
        {
            try
            {
                this.fSerialToEthernet.fEventPusher.pushTcpEvent(
                    new FSocketDataReceivedEventArgs(this.fSerialToEthernet, FEventId.SocketDataReceived, FResultCode.Success, string.Empty, m_fRecvBuf.bin)
                    );
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void resetResource(
            )
        {
            try
            {
                m_fRecvBuf.clear();
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

        private void closeTcpClient(
            )
        {
            try
            {
                if (m_fTcpClient == null)
                {
                    return;
                }

                // --                

                if (
                    m_fTcpClient.fState == FTcpClientState.Connected &&
                    this.fSerialToEthernet.fSocketState == FCommunicationState.Connected
                    )
                {
                    while (this.fSerialToEthernet.fEventPusher.tcpEventCount > 0 || !m_fTcpClient.sendCompleted)
                    {
                        if (System.Windows.Forms.Application.MessageLoop)
                        {
                            System.Windows.Forms.Application.DoEvents();
                        }
                        System.Threading.Thread.Sleep(1);
                    }
                }

                // --

                m_fTcpClient.close();
                m_fTcpClient.Dispose();
                // --
                m_fTcpClient.TcpClientStateChanged -= new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived -= new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient = null;
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

        public override void open(
            )
        {
            try
            {
                m_fTcpListener = new FTcpListener(this.fSerialToEthernet.fSocketConfig.localIp, this.fSerialToEthernet.fSocketConfig.localPort, 1);
                // --
                m_fTcpListener.TcpListenerAcceptCompleted += new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                m_fTcpListener.TcpListenerErrorRaised += new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                // --
                m_fTcpListener.start();

                // --

                this.fSerialToEthernet.changeTcpState(FCommunicationState.Opened, FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort);
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

        public override void close(
            )
        {
            try
            {
                m_fTcpListener.stop();
                m_fTcpListener.Dispose();
                // --
                m_fTcpListener.TcpListenerAcceptCompleted -= new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                m_fTcpListener.TcpListenerErrorRaised -= new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                // --
                m_fTcpListener = null;

                // --

                closeTcpClient();

                // --

                this.fSerialToEthernet.changeTcpState(FCommunicationState.Closed, FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort);
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

        public override void send(
            FSocketSendData fSocketSendData
            )
        {
            try
            {
                sendData(fSocketSendData);
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

        private void procSocketErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                this.fSerialToEthernet.fEventPusher.pushTcpEvent(
                    new FSocketErrorRaisedEventArgs(this.fSerialToEthernet, FEventId.SocketErrorRaised, inEx.Message)
                    );
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

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            bool waited = false;

            try
            {
                waited = m_fMainSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if(m_fTcpListener.started)
                {
                    if (this.fSerialToEthernet.fSerialState != FCommunicationState.Connected)
                    {
                        m_fTcpListener.stop();
                        this.fSerialToEthernet.changeTcpState(FCommunicationState.Opened, FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort);
                    }
                }
                else
                {
                    if (this.fSerialToEthernet.fSerialState == FCommunicationState.Connected)
                    {
                        m_fTcpListener.start();
                    }
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {
                if (waited)
                {
                    m_fMainSync.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fTcpListener Object Event Handler

        private void m_fTcpListener_TcpListenerAcceptCompleted(
            object sender,
            FTcpListenerAcceptCompletedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                closeTcpClient();

                // --

                this.localIp = e.fTcpClient.localIp;
                this.localPort = e.fTcpClient.localPort;
                this.remoteIp = e.fTcpClient.remoteIp;
                this.remotePort = e.fTcpClient.remotePort;

                // --

                m_fTcpClient = e.fTcpClient;
                // --
                m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived += new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                m_fTcpClient.TcpClientDataSent += new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed += new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised += new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient.resumeEvent();

                // -- 

                this.fSerialToEthernet.changeTcpState(FCommunicationState.Connected, FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpListener_TcpListenerErrorRaised(
            object sender,
            FTcpListenerErrorRaisedEventArgs e
            )
        {
            try
            {
                procSocketErrorRaised(e.exception);
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

        #region m_fTcpClient Object Event Handler

        private void m_fTcpClient_TcpClientStateChanged(
            object sender, 
            FTcpClientStateChangedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (m_fTcpListener != null && e.fState == FTcpClientState.Closed)
                {
                    this.fSerialToEthernet.changeTcpState(FCommunicationState.Opened, FConnectMode.Passive, this.localIp, this.localPort, this.remoteIp, this.remotePort);
                    // --
                    resetResource();
                }
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataReceived(
            object sender,
            FTcpClientDataReceivedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                if (e.dataLength > 0)
                {
                    m_fRecvBuf.input(e.data);

                    // --

                    while (m_fRecvBuf.parse())
                    {
                        recvData();

                        // --

                        m_fRecvBuf.init();
                    }
                }
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataSent(
            object sender, 
            FTcpClientDataSentEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                this.fSerialToEthernet.fEventPusher.pushTcpEvent(
                    new FSocketDataSentEventArgs(
                        this.fSerialToEthernet, 
                        FEventId.SocketDataSent, 
                        FResultCode.Success, 
                        string.Empty, 
                        e.fData
                        )
                    );
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataSendFailed(
            object sender, 
            FTcpClientDataSendFailedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                this.fSerialToEthernet.fEventPusher.pushTcpEvent(
                    new FSocketDataSentEventArgs(
                        this.fSerialToEthernet, 
                        FEventId.SocketDataSent, 
                        FResultCode.Error, 
                        e.message, 
                        e.fData
                        )
                    );  
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientErrorRaised(
            object sender, 
            FTcpClientErrorRaisedEventArgs e
            )
        {
            try
            {
                procSocketErrorRaised(e.exception);
            }
            catch (Exception ex)
            {
                procSocketErrorRaised(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
