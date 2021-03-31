/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpActive.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet TCP Active Protocol Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    internal class FTcpActive: FBaseTcp
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpClient m_fTcpClient = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpActive( 
            FSerialToEthernet fSerialToTcp
            )
            : base(fSerialToTcp)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpActive(
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
                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FTcpActiveMainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();
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
                if (m_fThdMain != null)
                {
                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                // --

                if (m_fTcpClient != null)
                {
                    m_fTcpClient.close();
                    m_fTcpClient.Dispose();
                    // --
                    m_fTcpClient.TcpClientStateChanged -= new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                    m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                    m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                    m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                    // --                
                    m_fTcpClient = null;
                }

                // --

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

        public override void open(
            )
        {
            try
            {
                m_fTcpClient = new FTcpClient(
                   this.fSerialToEthernet.fSocketConfig.localIp,
                   this.fSerialToEthernet.fSocketConfig.remoteIp,
                   this.fSerialToEthernet.fSocketConfig.remotePort
                   );
                m_fTcpClient.retryConnectPeriod = this.fSerialToEthernet.fSocketConfig.retryConnectPeriod * 1000; // T5 Timeout 설정
                // --
                m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataSent += new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed += new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised += new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient.connect();
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
                procTcpErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procTcpErrorRaised(
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

                if (
                    m_fTcpClient == null || 
                    m_fTcpClient.fState != FTcpClientState.Connected ||
                    this.fSerialToEthernet.fSocketState != FCommunicationState.Connected
                    )
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procTcpErrorRaised(ex);
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

                this.localIp = e.localIp;
                this.localPort = e.localPort;
                this.remoteIp = e.remoteIp;
                this.remotePort = e.remotePort;

                // --

                if (e.fState == FTcpClientState.Opened)
                {
                    this.fSerialToEthernet.changeTcpState(FCommunicationState.Opened, FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort);
                }
                else if (e.fState == FTcpClientState.Connected)
                {
                    this.fSerialToEthernet.changeTcpState(FCommunicationState.Connected, FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort);
                }
                else if (e.fState == FTcpClientState.Closed)
                {
                    this.fSerialToEthernet.changeTcpState(FCommunicationState.Closed, FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort);
                }
            }
            catch (Exception ex)
            {
                procTcpErrorRaised(ex);
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
                    new FSocketDataSentEventArgs(this.fSerialToEthernet, FEventId.SocketDataSent, FResultCode.Success, string.Empty, e.fData)
                    );
            }
            catch (Exception ex)
            {
                procTcpErrorRaised(ex);
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
                    new FSocketDataSentEventArgs(this.fSerialToEthernet, FEventId.SocketDataSendFailed, FResultCode.Error, e.message, e.fData)
                    );
            }
            catch (Exception ex)
            {
                procTcpErrorRaised(ex);
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
                procTcpErrorRaised(e.exception);
            }
            catch (Exception ex)
            {
                procTcpErrorRaised(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
