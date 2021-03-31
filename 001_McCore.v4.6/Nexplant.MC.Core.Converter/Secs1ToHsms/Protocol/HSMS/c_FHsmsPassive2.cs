/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsPassive2.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.12
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Passive 2 Protocol Class
--  History         : Created by spike.lee at 2017.04.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FHsmsPassive2: FBaseHsms
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpClient m_fTcpClient = null;
        private FHsmsRecvBuffer m_fRecvBuf = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrT7 = null;
        private FStaticTimer m_fTmrT8 = null;
        private FCommunicationState m_fState = FCommunicationState.Closed;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsPassive2(            
            FSecs1ToHsms fSecsToHsms,
            FTcpClient fTcpClient
            )
            : base(fSecsToHsms)
        {
            m_fTcpClient = fTcpClient;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHsmsPassive2(
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

        public FCommunicationState fState
        {
            get
            {
                try
                {
                    return m_fState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FCommunicationState.Closed;
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
                m_fTmrT7 = new FStaticTimer();
                m_fTmrT8 = new FStaticTimer();
                m_fRecvBuf = new FHsmsRecvBuffer();

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FHsmsPassive2MainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();

                // --

                this.localIp = m_fTcpClient.localIp;
                this.localPort = m_fTcpClient.localPort;
                this.remoteIp = m_fTcpClient.remoteIp;
                this.remotePort = m_fTcpClient.remotePort;

                // --

                m_fState = FCommunicationState.Connected;

                // --

                // ***
                // T7 Timer Start
                // ***
                m_fTmrT7.start(this.fSecs1ToHsms.fHsmsConfig.t7Timeout * 1000);

                // --

                m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                m_fTcpClient.TcpClientDataReceived += new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                m_fTcpClient.TcpClientDataSent += new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                m_fTcpClient.TcpClientDataSendFailed += new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                m_fTcpClient.TcpClientErrorRaised += new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                // --
                m_fTcpClient.resumeEvent();
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

                // ***
                // 통신 포트 Close
                // ***
                close();

                // --

                if (m_fTmrT7 != null)
                {
                    m_fTmrT7.Dispose();
                    m_fTmrT7 = null;
                }

                if (m_fTmrT8 != null)
                {
                    m_fTmrT8.Dispose();
                    m_fTmrT8 = null;
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

        public override void open(
            )
        {
            try
            {

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

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void resetResource(
            )
        {
            try
            {
                // ***
                // Timer Buffer 초기화
                // ***
                m_fTmrT7.stop();
                m_fTmrT8.stop();
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

        private void recvSelectReq(
            )
        {
            string errorMessage = string.Empty;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                errorMessage = getSelectStatusMessage(3);

                // --

                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectReq,
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

                sendSelectRsp(m_fRecvBuf.sessionId, 3, m_fRecvBuf.systemBytes);
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
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
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
            string errorMessage = string.Empty;

            try
            {
                errorMessage = this.getRejectReasonMessage(3);

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
                // 통신 포트 Close
                // ***
                m_fTcpClient.close();
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

        private void sendSelectRsp(
            UInt16 sessionId,
            byte status,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsControlMessage fSecsControlMessage = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSelectRsp(sessionId, status, systemBytes);
                // --
                fSecsControlMessage = new FSecsControlMessage(
                    this.fSecs1ToHsms,
                    FHsmsControlMessageType.SelectRsp,
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
                    getRejectReasonMessage(reasonCode)
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

                if (m_fState != FCommunicationState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // T7 Timeout 체크
                // ***
                if (m_fTmrT7.elasped(false))
                {
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T7, getTimeoutMessage(FSecsTimeout.T7))
                            );
                    // --
                    sendSeparateReq();

                    // --

                    // ***
                    // 통신 포트 Close
                    // ***
                    m_fTcpClient.close();
                    return;
                }

                // --

                // ***
                // T8 Timeout 체크
                // ***
                if (m_fTmrT8.elasped(false))
                {
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsTimeoutRaisedEventArgs(this.fSecs1ToHsms, FEventId.HsmsTimeoutRaised, FSecsTimeout.T8, getTimeoutMessage(FSecsTimeout.T8))
                            );
                    // --
                    sendSeparateReq();

                    // --

                    // ***
                    // 통신 포트 Close
                    // ***
                    m_fTcpClient.close();
                    return;
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

                if (e.fState == FTcpClientState.Closed)
                {
                    m_fState = FCommunicationState.Closed;
                    // --
                    this.fSecs1ToHsms.fEventPusher.pushHsmsEvent(
                        new FHsmsStateChangedEventArgs(
                            this.fSecs1ToHsms, 
                            FEventId.HsmsStateChanged, 
                            FResultCode.Warninig, 
                            string.Format(FConstants.err_m_0024, "Secondary TCP/IP Connection"), 
                            FConnectMode.Passive,
                            this.localIp,
                            this.localPort,
                            this.remoteIp,
                            this.remotePort,
                            m_fState
                            )
                        );

                    // --

                    resetResource();
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

                m_fRecvBuf.input(e.data);
                // --
                while (m_fRecvBuf.parse())
                {                
                    if (m_fRecvBuf.stype == 0)
                    {
                        // ***
                        // Not Selected 오류 처리
                        // ***
                        sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 4, m_fRecvBuf.systemBytes);
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
                    // --

                    if (fSecsControlMessage.fType == FHsmsControlMessageType.SelectRsp)
                    {
                        sendSeparateReq();

                        // --

                        // ***
                        // 통신 포트 Close
                        // ***
                        m_fTcpClient.close();
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
