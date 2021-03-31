/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsPassive2.cs
--  Creator         : spike.lee
--  Create Date     : 2011.10.04
--  Description     : FAMate Core FaSecsDriver HSMS Passive2 (Abnormal Connection) Class 
--  History         : Created by spike.lee at 2011.10.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FHsmsPassive2 : FBaseHsms
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpClient m_fTcpClient = null;
        private FHsmsRecvBuffer m_fRecvBuf = null;
        private FStaticTimer m_fTmrT7 = null;
        private FStaticTimer m_fTmrT8 = null;
        // --
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsPassive2(                        
            FHsmsProtocol fHsmsProtocol,
            FTcpClient fTcpClient
            )
            : base (fHsmsProtocol)
        {
            init(fTcpClient);
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
       
                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            FTcpClient fTcpClient
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

                // ***
                // TCP/IP 정보 설정
                // ***
                this.localIp = fTcpClient.localIp;
                this.localPort = fTcpClient.localPort;
                this.remoteIp = fTcpClient.remoteIp;
                this.remotePort = fTcpClient.remotePort;

                // --

                procStateConnected();

                // --

                m_fTcpClient = fTcpClient;
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
            FSecsSession fSecsSession,
            FSecsMessageTransfer fSecsMessageTransfer
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

        public override void pauseProtocol(
            )
        {
            try
            {
                m_fMainSync.wait();
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

        public override void continueProtocol(
            )
        {
            try
            {
                m_fMainSync.set();
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

        private void procStateConnected(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Connected);
                // --
                if (fSecsDriver.fScdCore.fConfig.enabledEventsOfSecsDeviceState)
                {
                    this.fEventPusher.pushSecsDeviceStateChangedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0023, "Secondary TCP/IP Connection"),
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }

                // --

                // ***
                // T7 Timer Start
                // ***
                m_fTmrT7.start(this.t7Timeout);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateClosed(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Closed);
                // --
                if (fSecsDriver.fScdCore.fConfig.enabledEventsOfSecsDeviceState)
                {
                    this.fEventPusher.pushSecsDeviceStateChangedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0024, "Secondary TCP/IP Connection"),
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }
                
                // --

                resetResource();
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataReceived(
            byte[] data
            )
        {
            string sml = string.Empty;

            try
            {
                // ***
                // 2012.11.23 by spike.lee
                // Binary Log File은 Eanbled Event와 상관 없이 기록하도록 수정
                // ***
                if (this.fScdCore.fConfig.enabledLogOfBinary)
                {
                    this.fScdCore.fLogWriter.pushBinaryLog(
                        FEventId.SecsDeviceDataReceived,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fSecsDevice.name,
                        this.fSecsDevice.fProtocol,
                        this.fSecsDevice.fConnectMode,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceData)
                {
                    this.fEventPusher.pushSecsDeviceDataReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                // ***
                // Data Receive 시 T8 Timer 해제
                // ***
                m_fTmrT8.stop();

                // --

                m_fRecvBuf.input(data);
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
                    m_fTmrT8.start(this.t8Timeout);
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataSent(
            byte[] data,
            object state
            )
        {
            try
            {
                // ***
                // 2012.11.23 by spike.lee
                // Binary Log File은 Eanbled Event와 상관 없이 기록하도록 수정
                // ***
                if (this.fScdCore.fConfig.enabledLogOfBinary)
                {
                    this.fScdCore.fLogWriter.pushBinaryLog(
                        FEventId.SecsDeviceDataSent,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fSecsDevice.name,
                        this.fSecsDevice.fProtocol,
                        this.fSecsDevice.fConnectMode,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceData)
                {
                    this.fEventPusher.pushSecsDeviceDataSentEvent(
                        this.fSecsDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                if (state is FSecsDeviceControlMessageSentLog)
                {
                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                    {
                        this.fEventPusher.pushSecsDeviceControlMessageSentEvent(
                            this.fSecsDevice,
                            FResultCode.Warninig,
                            string.Format(FConstants.err_m_0025, "Control Message", "the Secondary TCP/IP Connection"),
                            (FSecsDeviceControlMessageSentLog)state
                            );
                    }

                    // --

                    if (((FSecsDeviceControlMessageSentLog)state).fType == FControlMessageType.SelectRsp)
                    {
                        sendSeparateReq();
                        // --
                        m_fTcpClient.close();
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataSendFailed(
            string message,
            object state
            )
        {
            object[] stateArr = null;
            FSecsDeviceDataMessageSentLog fLog = null;

            try
            {
                if (state.GetType().IsArray)
                {
                    stateArr = (object[])state;

                    // --

                    fLog = (FSecsDeviceDataMessageSentLog)stateArr[0];
                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                    {
                        this.fEventPusher.pushSecsDeviceDataMessageSentEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            message,
                            fLog
                            );
                    }
                }
                else
                {
                    if (state is FSecsDeviceControlMessageSentLog)
                    {
                        if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                        {
                            this.fEventPusher.pushSecsDeviceControlMessageSentEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                message,
                                (FSecsDeviceControlMessageSentLog)state
                                );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                stateArr = null;
                fLog = null;
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
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSelectRsp(sessionId, status, systemBytes);
                // --
                fLog = this.fEventPusher.createSecsDeviceControlMessageSentLog(
                    this.fSecsDevice,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    fBuf.length,
                    FControlMessageType.SelectRsp
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBuf != null)
                {
                    fBuf.Dispose();
                    fBuf = null;
                }
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendDeselectRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genDeselectRsp(sessionId, systemBytes);
                // --
                fLog = this.fEventPusher.createSecsDeviceControlMessageSentLog(
                    this.fSecsDevice,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    fBuf.length,
                    FControlMessageType.DeselectRsp
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBuf != null)
                {
                    fBuf.Dispose();
                    fBuf = null;
                }
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendLinktestRsp(
            UInt16 sessionId,
            UInt32 systemBytes
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestRsp(sessionId, systemBytes);
                // --
                fLog = this.fEventPusher.createSecsDeviceControlMessageSentLog(
                    this.fSecsDevice,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    fBuf.length,
                    FControlMessageType.LinktestRsp
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBuf != null)
                {
                    fBuf.Dispose();
                    fBuf = null;
                }
                fLog = null;
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
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genRejectReq(sessionId, stype, reasonCode, systemBytes);
                // --
                fLog = this.fEventPusher.createSecsDeviceControlMessageSentLog(
                    this.fSecsDevice,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    fBuf.length,
                    FControlMessageType.RejectReq
                    );
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Reason, FXmlTagCMGL.D_Reason, this.getRejectReasonMessage(reasonCode));
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBuf != null)
                {
                    fBuf.Dispose();
                    fBuf = null;
                }
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendSeparateReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSeparateReq(this.fSystemBytesPointer.uniqueId);
                // --
                fLog = this.fEventPusher.createSecsDeviceControlMessageSentLog(
                    this.fSecsDevice,
                    fBuf.sessionId,
                    fBuf.byte2,
                    fBuf.byte3,
                    fBuf.ptype,
                    fBuf.stype,
                    fBuf.systemBytes,
                    fBuf.length,
                    FControlMessageType.SeparateReq
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBuf != null)
                {
                    fBuf.Dispose();
                    fBuf = null;
                }
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSelectReq(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;            

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.SelectReq
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        this.getSelectStatusMessage(3),
                        fLog
                        );
                }

                // --

                sendSelectRsp(m_fRecvBuf.sessionId, 3, m_fRecvBuf.systemBytes);                
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSelectRsp(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                       this.fSecsDevice,
                       m_fRecvBuf.sessionId,
                       m_fRecvBuf.byte2,
                       m_fRecvBuf.byte3,
                       m_fRecvBuf.ptype,
                       m_fRecvBuf.stype,
                       m_fRecvBuf.systemBytes,
                       m_fRecvBuf.length,
                       FControlMessageType.SelectRsp
                       );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        this.getRejectReasonMessage(1),
                        fLog
                        );
                }

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 1, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectReq(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.DeselectReq
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0026, "Control Message", "the Secondary TCP/IP Connection"),
                        fLog
                        );
                }

                // --

                sendDeselectRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);

                // --

                m_fTcpClient.close();
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvDeselectRsp(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.DeselectRsp
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        this.getRejectReasonMessage(3),
                        fLog
                        );
                }

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvLinktestReq(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.LinktestReq
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0026, "Control Message", "the Secondary TCP/IP Connection"),
                        fLog
                        );
                }

                // --

                sendLinktestRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvLinktestRsp(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;            

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.LinktestRsp
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        this.getRejectReasonMessage(3),
                        fLog
                        );
                }

                // --

                sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvRejectReq(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.RejectReq
                        );
                    fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Reason, FXmlTagCMGL.D_Reason, this.getRejectReasonMessage(m_fRecvBuf.byte3));
                    // --                
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0026, "Control Message", "the Secondary TCP/IP Connection"),
                        fLog
                        );
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void recvSeparateReq(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                if (fScdCore.fConfig.enabledEventsOfSecsDeviceControlMessage)
                {
                    fLog = this.fEventPusher.createSecsDeviceControlMessageReceivedLog(
                        this.fSecsDevice,
                        m_fRecvBuf.sessionId,
                        m_fRecvBuf.byte2,
                        m_fRecvBuf.byte3,
                        m_fRecvBuf.ptype,
                        m_fRecvBuf.stype,
                        m_fRecvBuf.systemBytes,
                        m_fRecvBuf.length,
                        FControlMessageType.SeparateReq
                        );
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(
                        this.fSecsDevice,
                        FResultCode.Warninig,
                        string.Format(FConstants.err_m_0026, "Control Message", "the Secondary TCP/IP Connection"),
                        fLog
                        );
                }

                // --

                m_fTcpClient.close();
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
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
                    procStateClosed();
                }
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

        private void m_fTcpClient_TcpClientDataReceived(
            object sender,
            FTcpClientDataReceivedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                procDataReceived(e.data);
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

        private void m_fTcpClient_TcpClientDataSent(
            object sender,
            FTcpClientDataSentEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                procDataSent(e.data, e.fData.state);
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

        private void m_fTcpClient_TcpClientDataSendFailed(
            object sender,
            FTcpClientDataSendFailedEventArgs e
            )
        {
            try
            {
                m_fMainSync.wait();

                // --

                procDataSendFailed(e.message, e.fData.state);
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

        private void m_fTcpClient_TcpClientErrorRaised(
            object sender,
            FTcpClientErrorRaisedEventArgs e
            )
        {
            try
            {
                procDeviceErrorRaised(e.exception);
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

                if (m_fTcpClient == null || m_fTcpClient.fState != FTcpClientState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                if (this.fDeviceState != FDeviceState.Connected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // T7 Timer check
                // ***
                if (m_fTmrT7.elasped(false))
                {
                    if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                    {
                        this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            this.getTimeoutMessage(FSecsDeviceTimeout.T7),
                            FSecsDeviceTimeout.T7,
                            this.getTimeoutDescription(FSecsDeviceTimeout.T7)
                            );
                    }
                    // --
                    sendSeparateReq();
                    m_fTcpClient.close();
                    return;
                }

                // --

                // ***
                // T8 Timer check
                // ***
                if (m_fTmrT8.elasped(false))
                {
                    if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                    {
                        this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            this.getTimeoutMessage(FSecsDeviceTimeout.T8),
                            FSecsDeviceTimeout.T8,
                            this.getTimeoutDescription(FSecsDeviceTimeout.T8)
                            );
                    }
                    // --
                    sendSeparateReq();
                    m_fTcpClient.close();
                    return;
                }

                // --

                e.sleepThread(1);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
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

    }   // Class end
}   // Namespace end
