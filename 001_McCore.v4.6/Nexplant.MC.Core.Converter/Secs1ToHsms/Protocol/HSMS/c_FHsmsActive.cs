/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsActive.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.13
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Active Protocol Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FHsmsActive: FBaseHsms
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FHsmsRecvBuffer m_fRecvBuf = null;
        private FTcpClient m_fTcpClient = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrLinktest = null;
        private FStaticTimer m_fTmrT8 = null;
        private FHsmsControlMessageTransaction m_fTranSelectReq = null;
        private FHsmsControlMessageTransaction m_fTranLinktestReq = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsActive( 
            FSecs1ToHsms fSecs1ToHsms
            )
            : base(fSecs1ToHsms)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHsmsActive(
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
                m_fTmrLinktest = new FStaticTimer();
                m_fTmrT8 = new FStaticTimer();
                m_fTranSelectReq = new FHsmsControlMessageTransaction(this.fSecs1ToHsms);
                m_fTranLinktestReq = new FHsmsControlMessageTransaction(this.fSecs1ToHsms);
                m_fRecvBuf = new FHsmsRecvBuffer();

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FHsmsActiveMainThread");
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
                    m_fTcpClient.TcpClientDataReceived -= new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                    m_fTcpClient.TcpClientDataSent -= new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                    m_fTcpClient.TcpClientDataSendFailed -= new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                    m_fTcpClient.TcpClientErrorRaised -= new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                    // --                
                    m_fTcpClient = null;
                }

                // --

                if (m_fTmrLinktest != null)
                {
                    m_fTmrLinktest.Dispose();
                    m_fTmrLinktest = null;
                }

                if (m_fTmrT8 != null)
                {
                    m_fTmrT8.Dispose();
                    m_fTmrT8 = null;
                }

                if (m_fTranSelectReq != null)
                {
                    m_fTranSelectReq.Dispose();
                    m_fTranSelectReq = null;
                }

                if (m_fTranLinktestReq != null)
                {
                    m_fTranLinktestReq.Dispose();
                    m_fTranLinktestReq = null;
                }

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

        public override void open(
            )
        {
            try
            {
                m_fTcpClient = new FTcpClient(
                   this.fSecs1ToHsms.fHsmsConfig.localIp,
                   this.fSecs1ToHsms.fHsmsConfig.remoteIp,
                   this.fSecs1ToHsms.fHsmsConfig.remotePort
                   );
                m_fTcpClient.retryConnectPeriod = this.fSecs1ToHsms.fHsmsConfig.t5Timeout * 1000; // T5 Timeout 설정
                // --
                m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived += new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
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

                if (m_fTcpClient.fState == FTcpClientState.Connected)
                {
                    if (this.fSecs1ToHsms.fHsmsState == FCommunicationState.Selected)
                    {
                        while (this.fSecs1ToHsms.fEventPusher.hsmsEventCount > 0 || !m_fTcpClient.sendCompleted)
                        {
                            if (System.Windows.Forms.Application.MessageLoop)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                            System.Threading.Thread.Sleep(1);
                        }
                    }
                    // --
                    sendSeparateReq();
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

        public override void send(
            FSecsDataMessage fSecsDataMessage
            )
        {
            try
            {
                sendDataMessage(fSecsDataMessage);
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

        private void resetResource(
            )
        {
            try
            {
                // ***
                // Timer, Transaction, Buffer 초기화
                // ***
                m_fTmrLinktest.stop();
                m_fTmrT8.stop();
                m_fTranSelectReq.reset();
                m_fTranLinktestReq.reset();
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

        private void sendSelectReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSelectReq(this.fSystemBytesPointer.uniqueId);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));

                // --

                // ***
                // Select Transaction Open
                // ***
                m_fTranSelectReq.set(fBuf.sessionId, fBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendDeselectRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genDeselectRsp(sessionId, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendLinktestReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestReq(this.fSystemBytesPointer.uniqueId);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));

                // --

                // ***
                // Linktest Transaction Open
                // ***
                m_fTranLinktestReq.set(fBuf.sessionId, fBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendLinktestRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestRsp(sessionId, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestRsp,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendRejectReq(
            UInt16 sessionId,
            byte stype,
            byte reasonCode,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genRejectReq(sessionId, stype, reasonCode, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.RejectReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendSeparateReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSeparateReq(this.fSystemBytesPointer.uniqueId);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SeparateReq,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    string.Empty
                    );
                // --
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fSecsControlMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fBuf = null;
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void sendDataMessage(
            FSecsDataMessage fSecsDataMessage
            )
        {
            try
            {
                m_fTcpClient.send(new FSocketSendData(fSecsDataMessage.getHsmsBinaryData(true), fSecsDataMessage));
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void recvSelectReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(1);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 1, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSelectRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;

            try
            {
                if (!m_fTranSelectReq.enabled)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = getRejectReasonMessage(3);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
                }
                else if (m_fTranSelectReq.sessionId != m_fRecvBuf.sessionId)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "Session ID of the Select.Rsp");
                }
                else if (m_fTranSelectReq.systemBytes != m_fRecvBuf.systemBytes)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "System Bytes of the Select.Rsp");
                }
                else if (m_fRecvBuf.byte3 != 0)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = this.getSelectStatusMessage(m_fRecvBuf.byte3);
                }
                else
                {
                    // ***
                    // Select Transaction Close
                    // ***
                    m_fTranSelectReq.reset();
                }

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, fResult, errorMessage, fSecsControlMessage)
                    );

                // --

                if (fResult == FResultCode.Success)
                {
                    this.fSecs1ToHsms.changeHsmsState(FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Selected);

                    // --

                    if (this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod > 0)
                    {
                        m_fTmrLinktest.start(this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod * 1000);
                    }
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                sendDeselectRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);

                // --

                // ***
                // 통신 포트 재 연결
                // ***
                m_fTcpClient.reconnect();
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(3);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvLinktestReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                sendLinktestRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void recvLinktestRsp(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;

            try
            {
                if (!m_fTranLinktestReq.enabled)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = getRejectReasonMessage(3);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
                }
                else if (m_fTranLinktestReq.sessionId != m_fRecvBuf.sessionId)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "Session ID of the Linktst.Rsp");
                }
                else if (m_fTranLinktestReq.systemBytes != m_fRecvBuf.systemBytes)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = string.Format(FConstants.err_m_0015, "System Bytes of the Linktest.Rsp");
                }
                else if (m_fRecvBuf.byte3 != 0)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = this.getSelectStatusMessage(m_fRecvBuf.byte3);
                }
                else
                {
                    // ***
                    // Linktest Transaction Close
                    // ***
                    m_fTranLinktestReq.reset();
                }

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.LinktestRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, fResult, errorMessage, fSecsControlMessage)
                    );
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void recvRejectReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            string errorMessage = string.Empty;

            try
            {
                errorMessage = getRejectReasonMessage(m_fRecvBuf.byte3);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.DeselectRsp,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    errorMessage
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Warninig, errorMessage, fSecsControlMessage)
                    );
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSeparateReq(
            )
        {
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SeparateReq,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.byte2,
                    m_fRecvBuf.byte3,
                    m_fRecvBuf.ptype,
                    m_fRecvBuf.stype,
                    m_fRecvBuf.systemBytes,
                    string.Empty
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsControlMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageReceived, FResultCode.Success, string.Empty, fSecsControlMessage)
                    );

                // --

                // ***
                // 통신 포트 재 연결
                // ***
                m_fTcpClient.reconnect();
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDataMessage(
            )
        {
            FResultCode fResult = FResultCode.Success;
            string errorMessage = string.Empty;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                if (this.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                {
                    fResult = FResultCode.Warninig;
                    errorMessage = getRejectReasonMessage(4);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 4, m_fRecvBuf.systemBytes);
                }

                // --

                fSecsDataMessage = new FSecsDataMessage(
                    this.fSecs1ToHsms,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.wbit,
                    m_fRecvBuf.stream,
                    m_fRecvBuf.function,
                    m_fRecvBuf.systemBytes,
                    m_fRecvBuf.body.ToArray()
                    );
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsDataMessageReceivedEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageReceived, fResult, errorMessage, fSecsDataMessage)
                    );

                // --

                if (fResult == FResultCode.Success)
                {
                    if (this.fSecs1ToHsms.isHsmsInterceptingDataMessage(fSecsDataMessage.stream, fSecsDataMessage.function))
                    {
                        this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                            new FHsmsInterceptingDataMessageReceivedEventArgs(
                                this.fSecs1ToHsms, 
                                FEventId.HsmsInterceptingDataMessageReceived, 
                                fResult, 
                                errorMessage, 
                                fSecsDataMessage
                                )
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsDataMessage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procHsmsErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsErrorRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsErrorRaised, inEx.Message)
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procSelectTimeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T6, getTimeoutMessage(FSecsTimeout.T6))
                        );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 재 연결
                // ***
                m_fTcpClient.reconnect();
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

        private void procLinktestTimeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T6, getTimeoutMessage(FSecsTimeout.T6))
                        );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 재 연결
                // ***
                m_fTcpClient.reconnect();
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

        private void procT8Timeout(
            )
        {
            try
            {
                this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                    new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T8, getTimeoutMessage(FSecsTimeout.T8))
                    );
                // --
                sendSeparateReq();

                // --

                // ***
                // 통신 포트 재 연결
                // ***
                m_fTcpClient.reconnect();
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

                if (m_fTcpClient == null || m_fTcpClient.fState != FTcpClientState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                if (this.fSecs1ToHsms.fHsmsState != FCommunicationState.Connected && this.fSecs1ToHsms.fHsmsState != FCommunicationState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // Select Transaction Timeout 체크
                // ***
                if (m_fTranSelectReq.timeout())
                {
                    procSelectTimeout();
                    return;
                }

                // --

                // ***
                // Linktest Transaction Timeout 체크
                // ***
                if (m_fTranLinktestReq.timeout())
                {
                    procLinktestTimeout();
                    return;
                }

                // --

                // ***
                // T8 Timeout 체크
                // ***
                if (m_fTmrT8.elasped(false))
                {
                    procT8Timeout();
                    return;
                }

                // --

                // ***
                // Linktest 요청 
                // ***
                if (m_fTmrLinktest.elasped(true))
                {
                    if (!m_fTranLinktestReq.enabled)
                    {
                        sendLinktestReq();
                    }
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
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
                    this.fSecs1ToHsms.changeHsmsState(FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Opened);
                    // --
                    resetResource();
                }
                else if (e.fState == FTcpClientState.Connected)
                {
                    this.fSecs1ToHsms.changeHsmsState(FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Connected);
                    // --
                    sendSelectReq();
                }
                else if (e.fState == FTcpClientState.Closed)
                {
                    this.fSecs1ToHsms.changeHsmsState(FConnectMode.Active, this.localIp, this.localPort, this.remoteIp, this.remotePort, FCommunicationState.Closed);
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
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

                // ***
                // Data Receive 시 T8 Timer 해제
                // ***
                m_fTmrT8.stop();

                // --

                // ***
                // Linktest Timer 재 설정
                // ***
                if (m_fTmrLinktest.enabled)
                {
                    m_fTmrLinktest.restart(this.fSecs1ToHsms.fHsmsConfig.linkTestPeriod * 1000);
                }

                // --

                m_fRecvBuf.input(e.data);
                // --
                while (m_fRecvBuf.parse())
                {
                    if (m_fRecvBuf.stype == 0)
                    {
                        recvDataMessage();
                    }
                    else if (m_fRecvBuf.stype == 1)
                    {
                        recvSelectReq();
                    }
                    else if (m_fRecvBuf.stype == 2)
                    {
                        recvSelectRsp();
                    }
                    else if (m_fRecvBuf.stype == 3)
                    {
                        recvDeselectReq();
                    }
                    else if (m_fRecvBuf.stype == 4)
                    {
                        recvDeselectRsp();
                    }
                    else if (m_fRecvBuf.stype == 5)
                    {
                        recvLinktestReq();
                    }
                    else if (m_fRecvBuf.stype == 6)
                    {
                        recvLinktestRsp();
                    }
                    else if (m_fRecvBuf.stype == 7)
                    {
                        recvRejectReq();
                    }
                    else if (m_fRecvBuf.stype == 9)
                    {
                        recvSeparateReq();
                    }
                    else
                    {
                        // ***
                        // SType 지원 불가 오류 처리
                        // ***
                        // --
                        sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 1, m_fRecvBuf.systemBytes);
                    }

                    // --

                    m_fRecvBuf.init();
                }

                // --

                // ***
                // Parsing이 완료되지 않을 경우 T8 Timer 설정
                // ***
                if (!m_fRecvBuf.isCompleted)
                {
                    m_fTmrT8.start(this.fSecs1ToHsms.fHsmsConfig.t8Timeout * 1000);
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
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
            FSecsControlMessage fSecsControlMessage = null;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecsControlMessage)
                {
                    fSecsControlMessage = (FSecsControlMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsControlMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageSent, FResultCode.Success, string.Empty, fSecsControlMessage)
                        );                    
                }
                else if (e.fData.state is FSecsDataMessage)
                {
                    fSecsDataMessage = (FSecsDataMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsDataMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageSent, FResultCode.Success, string.Empty, fSecsDataMessage)
                        );
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
                fSecsDataMessage = null;
                // --
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fTcpClient_TcpClientDataSendFailed(
            object sender,
            FTcpClientDataSendFailedEventArgs e
            )
        {
            FSecsControlMessage fSecsControlMessage = null;
            FSecsDataMessage fSecsDataMessage = null;

            try
            {
                m_fMainSync.wait();

                // --

                if (e.fData.state is FSecsControlMessage)
                {
                    fSecsControlMessage = (FSecsControlMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsControlMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsControlMessageSent, FResultCode.Error, e.message, fSecsControlMessage)
                        );
                }
                else if (e.fData.state is FSecsDataMessage)
                {
                    fSecsDataMessage = (FSecsDataMessage)e.fData.state;
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsDataMessageSentEventArgs(this.fSecs1ToHsms, FEventId.HsmsDataMessageSent, FResultCode.Error, e.message, fSecsDataMessage)
                        );
                }
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {
                fSecsControlMessage = null;
                fSecsDataMessage = null;
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
                procHsmsErrorRaised(e.exception);
            }
            catch (Exception ex)
            {
                procHsmsErrorRaised(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
