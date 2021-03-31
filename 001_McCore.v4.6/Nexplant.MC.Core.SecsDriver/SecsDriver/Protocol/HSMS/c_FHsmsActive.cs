/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsActive.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.02
--  Description     : FAMate Core FaSecsDriver HSMS Active Class 
--  History         : Created by spike.lee at 2011.09.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FHsmsActive : FBaseHsms
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단

        // --

        private bool m_disposed = false;
        // --
        private FTcpClient m_fTcpClient = null;
        private FHsmsRecvBuffer m_fRecvBuf = null;
        private FStaticTimer m_fTmrLinktest = null;
        private FStaticTimer m_fTmrT8 = null;
        private FHsmsControlMessageTransaction m_fTranSelectReq = null;
        private FHsmsControlMessageTransaction m_fTranLinktestReq = null;
        private FSecsOpenTransaction m_fTranDataMessage = null;     // 여기서 부터
        // --
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrAutoCycle = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsActive(            
            FHsmsProtocol fHsmsProtocol
            )           
            : base(fHsmsProtocol)
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
            )
        {
            try
            {
                m_fTmrLinktest = new FStaticTimer();
                m_fTmrT8 = new FStaticTimer();
                m_fTranSelectReq = new FHsmsControlMessageTransaction(this.t6Timeout);
                m_fTranLinktestReq = new FHsmsControlMessageTransaction(this.t6Timeout);
                m_fTranDataMessage = new FSecsOpenTransaction(this.fSecsDriver, this.t3Timeout, false);
                m_fRecvBuf = new FHsmsRecvBuffer();
                m_fTmrAutoCycle = new FStaticTimer();                

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

                if (m_fTranDataMessage != null)
                {
                    m_fTranDataMessage.Dispose();
                    m_fTranDataMessage = null;
                }

                if (m_fRecvBuf != null)
                {
                    m_fRecvBuf.Dispose();
                    m_fRecvBuf = null;
                }

                if (m_fTmrAutoCycle != null)
                {
                    m_fTmrAutoCycle.Dispose();
                    m_fTmrAutoCycle = null;
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
                    this.fHsmsProtocol.fSecsDevice.localIp,                    
                    this.fHsmsProtocol.fSecsDevice.remoteIp,
                    this.fHsmsProtocol.fSecsDevice.remotePort
                    );
                m_fTcpClient.retryConnectPeriod = this.t5Timeout; // T5 Timeout 설정
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
                // ***
                // Separate.Req 전송
                // ***
                if (m_fTcpClient.fState == FTcpClientState.Connected)
                {
                    if (this.fDeviceState == FDeviceState.Selected)
                    {
                        if (fScdCore.fConfig.enabledEventsOfScenario)
                        {
                            // ***
                            // Auto Action First Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runSecsAutoActionFirstCloseTransmitter(this.fSecsDevice);

                            // ***
                            // Auto Action Always Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runSecsAutoActionAlwaysCloseTransmitter(this.fSecsDevice);
                        }

                        // --

                        // ***
                        // 2016.12.21 by spike.lee
                        // 모든 Event를 처리하고 Close 하도록 수정
                        // ***
                        while (this.fEventPusher.eventCount > 0 || !m_fTcpClient.sendCompleted)
                        {
                            if (System.Windows.Forms.Application.MessageLoop)
                            {
                                System.Windows.Forms.Application.DoEvents();
                            }
                            System.Threading.Thread.Sleep(1);
                        }
                    }
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

                // --

                resetResource();
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
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));
                }

                // --

                sendDataMessage(fSecsSession, fSecsMessageTransfer);
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
                // Timer, Transaction, Buffer 초기화
                // ***
                m_fTmrLinktest.stop();
                m_fTmrT8.stop();
                m_fTranSelectReq.reset();
                m_fTranLinktestReq.reset();
                m_fTranDataMessage.clearTransaction();
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

        private void procStateOpened(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Opened);
                // --
                if (fSecsDriver.fScdCore.fConfig.enabledEventsOfSecsDeviceState)
                {
                    this.fEventPusher.pushSecsDeviceStateChangedEvent(
                        this.fSecsDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }
                
                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearSecsAutoCycleTransmitter(this.fSecsDevice);
                m_fTmrAutoCycle.stop();

                // --

                // ***
                // SECS Retry Condtion 초기화
                // ***
                this.fProtocolAgent.clearSecsRetryCondition(this.fSecsDevice);

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
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }

                // --

                sendSelectReq();
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

        private void procStateSelected(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Selected);
                // --
                if (fSecsDriver.fScdCore.fConfig.enabledEventsOfSecsDeviceState)
                {
                    this.fEventPusher.pushSecsDeviceStateChangedEvent(
                        this.fSecsDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }

                // --

                // ***
                // Linktest Timer Start (Selected 상태 부터 Linktest 시작)
                // ***
                if (this.linkTestPeriod > 0)
                {
                    m_fTmrLinktest.start(this.linkTestPeriod);
                }               
 
                // --

                if (fScdCore.fConfig.enabledEventsOfScenario)
                {
                    // ***
                    // Auto Action First Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runSecsAutoActionFirstSelectTransmitter(this.fSecsDevice);

                    // ***
                    // Auto Action Always Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runSecsAutoActionAlwaysSelectTransmitter(this.fSecsDevice);
                }

                // --

                // ***
                // Auto Cycle Run Time 실행
                // ***
                m_fTmrAutoCycle.start(AutoCycleRunTime);
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
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
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

        private void procDataReceived(
            byte[] data
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

                // ***
                // Linktest Restart
                // (Linktest Period가 0일 경우 Linktest Timer가 Disabled되어 있기 때문에 Restart 할 필요 없음)
                // ***
                if (m_fTmrLinktest.enabled)
                {
                    m_fTmrLinktest.restart();
                }

                // --

                m_fRecvBuf.input(data);
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
            object[] stateArr = null;
            // --
            FXmlNode[] fXmlNodeStrList = null;
            // --           
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceDataMessageSentLog fLog = null;
            string sml = string.Empty;
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;

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

                if (state.GetType().IsArray)
                {
                    stateArr = (object[])state;
                    // --
                    if (stateArr[0] is FSecsDeviceDataMessageSentLog)
                    {
                        if (
                            this.fScdCore.fConfig.enabledLogOfSml ||
                            this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml
                            )
                        {
                            // ***
                            // SML Parsing
                            // ***
                            fBuf = (FHsmsSendBuffer)stateArr[1];
                            // --
                            sml = FMessageConverter.convertBinToSml(
                                fBuf.stream,
                                fBuf.function,
                                fBuf.wbit,
                                fBuf.body,
                                fBuf.length,
                                ref fResultCode,
                                ref resultMessage
                                );
                            
                            // --

                            // ***
                            // 2012.11.23 by spike.lee
                            // SML Log File은 Eanbled Event와 상관 없이 기록하도록 수정
                            // ***
                            if (this.fScdCore.fConfig.enabledLogOfSml)
                            {
                                this.fScdCore.fLogWriter.pushSmlLog(
                                    FEventId.SecsDeviceSmlSent,
                                    FDataConvert.defaultNowDateTimeToString(),
                                    this.fSecsDevice.name,
                                    fBuf.sessionId,
                                    fBuf.systemBytes,
                                    fBuf.length,
                                    fResultCode,
                                    resultMessage,
                                    sml
                                    );                                
                            }

                            // --

                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml)
                            {
                                this.fEventPusher.pushSecsDeviceSmlSentEvent(
                                    this.fSecsDevice,
                                    fResultCode,
                                    resultMessage,
                                    fBuf.sessionId,
                                    fBuf.stream,
                                    fBuf.function,
                                    fBuf.wbit,
                                    fBuf.systemBytes,
                                    fBuf.length,
                                    sml
                                    );
                            }                            
                        }

                        // --
                        
                        // ***
                        // SECS Data Message Sent Event
                        // ***
                        fLog = (FSecsDeviceDataMessageSentLog)stateArr[0];
                        if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                        {
                            this.fEventPusher.pushSecsDeviceDataMessageSentEvent(this.fSecsDevice, FResultCode.Success, string.Empty, fLog);
                        }

                        // --

                        // ***
                        // Data Message Open Transaction 설정
                        // ***
                        if (fLog.isPrimary && fLog.wBit)
                        {
                            m_fTranDataMessage.openTransaction(
                                this.fEventPusher.createSecsDeviceDataMessageSentLog(fLog.fXmlNodeSsn, fLog.fXmlNode.clone(false))
                                );
                        }

                        // --

                        // ***
                        // Add by Jeff.Kim 2017.12.21
                        // 보낸 메시지도 Trigger를 타도록 수정.
                        // ***
                        if (fScdCore.fSecsDriver.enabledEventsOfScenario)
                        {
                            if (fResultCode == FResultCode.Success)
                            {
                                fXmlNodeStrList = FSECS2.parseExpressionTrigger(this.fSecsDriver, fLog.fXmlNode);
                                foreach (FXmlNode fXmlNodeStr in fXmlNodeStrList)
                                {
                                    this.fEventPusher.pushSecsTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeStr, fLog);
                                }
                            }
                        }
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
                                FResultCode.Success,
                                string.Empty,
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
                fBuf = null;
                fLog = null;
                fXmlNodeStrList = null;
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

        private void procOpenTransaction(
            )
        {
            FSecsDeviceDataMessageSentLog fLog = null;
            FXmlNode[] fXmlNodeStrList = null;
            FXmlNode fXmlNodeRetryScn = null;
            bool isClear = false;

            try
            {
                while ((fLog = m_fTranDataMessage.getTimeoutTransaction()) != null)
                {
                    // ***
                    // 2014.10.23 by spike.lee
                    // Request/Reply 시, 상대 Device 메시지 문제로 SystemBytes나 TID가 밀리는 문제로
                    // T3 Timeout이 발생하면 SystemBytes와 TID Storage Clear
                    // 해결책이 보이지 않아 임시 처리 함.
                    // ***
                    if (!isClear)
                    {
                        this.fProtocolAgent.fSecsSystemBytesStorage.clear();
                        this.fProtocolAgent.fHostTidStorage.clear();
                        isClear = true;
                    }

                    if (fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                    {
                        this.fEventPusher.pushSecsDeviceDataMessageSentEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            this.getTimeoutMessage(FSecsDeviceTimeout.T3),
                            fLog
                            );
                    }

                    // --

                    if (fScdCore.fSecsDriver.enabledEventsOfScenario)
                    {
                        fXmlNodeStrList = FSECS2.parseTimeoutTrigger(this.fSecsDriver, fLog.fXmlNode, ref fXmlNodeRetryScn);
                        foreach (FXmlNode fXmlNodeStr in fXmlNodeStrList)
                        {
                            this.fEventPusher.pushSecsTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeStr, fLog);
                        }
                    }
                    // --

                    if (fXmlNodeRetryScn != null)
                    {
                        procRetryDataMessage(fXmlNodeRetryScn);
                    }
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fLog = null;
                fXmlNodeStrList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procRetryDataMessage(
           FXmlNode fXmlNodeScn
           )
        {
            int retryLimit = 0;
            int retryCount = 0;
            FSecsCondition fScn = null;

            try
            {
                retryLimit = int.Parse(fXmlNodeScn.get_attrVal(FXmlTagSCN.A_RetryLimit, FXmlTagSCN.D_RetryLimit));
                retryCount = int.Parse(fXmlNodeScn.get_attrVal(FXmlTagSCN.A_RetryCount, FXmlTagSCN.D_RetryCount));

                // --

                // ***
                // Retry Limit 횟수만큼 시도되었을 경우, Retry 횟수 초기화
                // ***
                if (retryLimit == retryCount)
                {
                    fXmlNodeScn.set_attrVal(FXmlTagSCN.A_RetryCount, FXmlTagSCN.D_RetryCount, "0");
                    return;
                }

                // --

                fScn = new FSecsCondition(this.fScdCore, fXmlNodeScn);
                fScn.fMessage.createTransfer().send(fScn.fSession);

                // --

                // ***
                // Retry 회수 증가
                // ***
                fXmlNodeScn.set_attrVal(FXmlTagSCN.A_RetryCount, FXmlTagSCN.D_RetryCount, (retryCount + 1).ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void clearRetryDataMessage(
            FXmlNode fXmlNodeSmgl
            )
        {
            FXmlNodeList fXmlNodeListScn = null;

            try
            {
                fXmlNodeListScn = FSECS2.getRetryCondition(this.fSecsDriver, fXmlNodeSmgl);
                foreach (FXmlNode fXmlNodeScn in fXmlNodeListScn)
                {
                    fXmlNodeScn.set_attrVal(FXmlTagSCN.A_RetryCount, FXmlTagSCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListScn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendDataMessage(
            FSecsSession fSsn,
            FSecsMessageTransfer fSmt
            )
        {
            FXmlNode fXmlNodeSmgl = null;
            UInt32 systemBytes = 0;
            int sessionId = 0;
            int stream = 0;
            int function = 0;
            bool wbit = false;
            ArrayList body = null;
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceDataMessageSentLog fLog = null;

            try
            {
                if (fSmt.hasSystemBytes)
                {
                    systemBytes = fSmt.systemBytes;
                }
                else
                {
                    systemBytes = this.fSystemBytesPointer.uniqueId;
                }                

                // --                

                fXmlNodeSmgl = FSECS2.parseSmgToBin(
                    this.fSecsDevice, 
                    fSsn.fXmlNode, 
                    fSmt.fXmlNode, 
                    systemBytes,                     
                    ref sessionId, 
                    ref stream, 
                    ref function, 
                    ref wbit, 
                    ref body
                    );

                // --

                fBuf = new FHsmsSendBuffer();
                fBuf.genDataMessage(
                    (UInt16)sessionId, 
                    stream, 
                    function, 
                    wbit, 
                    systemBytes, 
                    body == null ? null : (byte[])body.ToArray(typeof(byte))
                    );
                // --
                fLog = this.fEventPusher.createSecsDeviceDataMessageSentLog(fSsn.fXmlNode, fXmlNodeSmgl);

                // --

                // ***
                // SecsMessageTransfer에 RepositoryMaterial이 존재할 경우 Reply Message 전송 시, RepositoryMaterial를 검색하기 위한 Key를 저장한다.
                // ***
                if (fSmt.fRepositoryMaterial != null)
                {
                    fSmt.fRepositoryMaterial.setSecsReplyKey(
                        this.fSecsDevice.uniqueId,
                        fSsn.uniqueId,
                        systemBytes
                        );
                }

                // --

                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), new object[]{ fLog, fBuf }));                
            }
            catch (FException ex)
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
                fXmlNodeSmgl = null;
                body = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendSelectReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genSelectReq(this.fSystemBytesPointer.uniqueId);
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
                    FControlMessageType.SelectReq
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
                m_fTranSelectReq.set(fBuf.sessionId, fBuf.systemBytes);                
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

        private void sendLinktestReq(
            )
        {
            FHsmsSendBuffer fBuf = null;
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fBuf = new FHsmsSendBuffer();
                fBuf.genLinktestReq(this.fSystemBytesPointer.uniqueId);
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
                    FControlMessageType.LinktestReq
                    );
                // --                
                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), fLog));
                m_fTranLinktestReq.set(fBuf.sessionId, fBuf.systemBytes);
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

        private void recvDataMessage(
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            string sml = string.Empty;
            FXmlNode fXmlNodeSsn = null;
            FXmlNode fXmlNodeSmg = null;
            FXmlNode fXmlNodeSmgl = null;
            FXmlNode[] fXmlNodeStrList = null;
            FSecsDeviceDataMessageSentLog fTranLog = null;
            FSecsDeviceDataMessageReceivedLog fLog = null;
            FSecsMessage fSmg = null;
            FSecsMessageTransfer fSmt = null;

            try
            {
                // ***
                // Selected 상태가 아닌 상태에서 Data Message가 전송될 경우 Reject 처리
                // ***
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 4, m_fRecvBuf.systemBytes);
                    return;
                }                

                // --

                if (
                    this.fScdCore.fConfig.enabledLogOfSml ||
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml
                    )
                {
                    // ***
                    // SML Parsing
                    // ***
                    fResultCode = FResultCode.Success;
                    resultMessage = string.Empty;
                    // --
                    sml = FMessageConverter.convertBinToSml(
                        m_fRecvBuf.stream,
                        m_fRecvBuf.function,
                        m_fRecvBuf.wbit,
                        m_fRecvBuf.body,
                        m_fRecvBuf.length,
                        ref fResultCode,
                        ref resultMessage
                        );

                    // --

                    // ***
                    // 2012.11.23 by spike.lee
                    // SML Log File은 Eanbled Event와 상관 없이 기록하도록 수정
                    // ***
                    if (this.fScdCore.fConfig.enabledLogOfSml)
                    {
                        this.fScdCore.fLogWriter.pushSmlLog(
                            FEventId.SecsDeviceSmlReceived,
                            FDataConvert.defaultNowDateTimeToString(),
                            this.fSecsDevice.name,
                            m_fRecvBuf.sessionId,
                            m_fRecvBuf.systemBytes,
                            m_fRecvBuf.length,
                            fResultCode,
                            resultMessage,
                            sml
                            );
                    }

                    // --

                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml)
                    {
                        this.fEventPusher.pushSecsDeviceSmlReceivedEvent(
                            this.fSecsDevice,
                            fResultCode,
                            resultMessage,
                            m_fRecvBuf.sessionId,
                            m_fRecvBuf.stream,
                            m_fRecvBuf.function,
                            m_fRecvBuf.wbit,
                            m_fRecvBuf.systemBytes,
                            m_fRecvBuf.length,
                            sml
                            );
                    }                    
                }

                // --

                // ***
                // SECS Open Transaction 검색 (Only Secondary Message)
                // ***
                if (m_fRecvBuf.function != 0 && m_fRecvBuf.function % 2 == 0)
                {
                    fTranLog = m_fTranDataMessage.getTransaction(
                        m_fRecvBuf.sessionId, 
                        m_fRecvBuf.stream, 
                        m_fRecvBuf.function, 
                        m_fRecvBuf.systemBytes
                        );
                    // --
                    if (fTranLog != null)
                    {
                        fXmlNodeSsn = fTranLog.fXmlNodeSsn;
                        fXmlNodeSmg = FSECS2.getReplyMessage(this.fSecsDriver, fXmlNodeSsn, fTranLog.uniqueIdToString);
                    }                    
                }

                // --

                // ***
                // SECS2 Parsing
                // ***
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;
                // --
                fXmlNodeSmgl = FSECS2.parseBinToSmg(
                    this.fSecsDriver,
                    this.fSecsDevice,
                    m_fRecvBuf.sessionId,
                    m_fRecvBuf.stream,
                    m_fRecvBuf.function,
                    m_fRecvBuf.wbit,
                    m_fRecvBuf.systemBytes,
                    m_fRecvBuf.body,
                    m_fRecvBuf.length,
                    ref fResultCode,
                    ref resultMessage,
                    ref fXmlNodeSsn,
                    ref fXmlNodeSmg
                    );
                fLog = this.fEventPusher.createSecsDeviceDataMessageReceivedLog(fXmlNodeSsn, fXmlNodeSmgl);

                // --

                if (fResultCode == FResultCode.Success)
                {
                    if (fLog.isPrimary)
                    {
                        if (fLog.wBit)
                        {
                            fXmlNodeSmg = FSECS2.getReplyMessage(this.fSecsDriver, fXmlNodeSsn, fLog.uniqueIdToString);
                            if (fXmlNodeSmg != null)
                            {
                                fSmg = new FSecsMessage(this.fScdCore, fXmlNodeSmg);
                            }
                        }                            

                        // --

                        if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                        {
                            this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(
                                this.fSecsDevice,
                                fResultCode,
                                resultMessage,
                                fLog,
                                fSmg
                                );
                        }

                        // --

                        if (fSmg != null)
                        {
                            if (fSmg.autoReply)
                            {
                                // ***
                                // Auto Reply Message Random Value 설정
                                // ***
                                fSmt = fSmg.createTransfer(fLog.systemBytes);
                                FSecsDriverCommon.setSecsItemRandomValue(fSmt.fXmlNode);

                                // --

                                this.sendDataMessage(new FSecsSession(this.fScdCore, fXmlNodeSsn), fSmt);
                            }
                            else
                            {
                                // ***
                                // Reply Message가 Auto Reply가 아닐 경우, System Bytes를 Keeping한다.
                                // ***
                                this.fProtocolAgent.fSecsSystemBytesStorage.add(
                                    fLog.deviceUniqueId, 
                                    fLog.sessionUniqueId, 
                                    fSmg.uniqueId, 
                                    fLog.systemBytes
                                    );                                
                            }
                        }                        
                    }
                    else
                    {
                        if (fTranLog == null)
                        {
                            fResultCode = FResultCode.Warninig;
                            resultMessage = FConstants.err_m_0031;
                        }
                        else
                        {
                            m_fTranDataMessage.closeTransaction(fTranLog);
                            clearRetryDataMessage(fTranLog.fXmlNode);   
                        }

                        // --

                        if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                        {
                            this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(this.fSecsDevice, fResultCode, resultMessage, fLog, null);
                        }
                    }

                    // --
                                        
                    // ***
                    // Trigger Parse
                    // ***
                    if (this.fScdCore.fSecsDriver.enabledEventsOfScenario)
                    {
                        if (fResultCode == FResultCode.Success)
                        {
                            fXmlNodeStrList = FSECS2.parseExpressionTrigger(this.fSecsDriver, fXmlNodeSmgl);
                            foreach (FXmlNode fXmlNodeStr in fXmlNodeStrList)
                            {
                                this.fEventPusher.pushSecsTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeStr, fLog);
                            }
                        }
                    }
                }
                else
                {
                    // ***
                    // 2014.10.23 by spike.lee
                    // Request/Reply 시, 상대 Device 메시지 문제로 SystemBytes나 TID가 밀리는 문제로
                    // Seondary 메시지가 성공하지 못하면 SystemBytes와 TID Storage Clear
                    // 해결책이 보이지 않아 임시 처리 함.
                    // ***
                    if (!fLog.isPrimary)
                    {
                        this.fProtocolAgent.fSecsSystemBytesStorage.clear(); 
                        this.fProtocolAgent.fHostTidStorage.clear();
                    }
                    
                    // --

                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                    {
                        this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(this.fSecsDevice, fResultCode, resultMessage, fLog, null);
                    }
                }                                  
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fXmlNodeSsn = null;
                fXmlNodeSmg = null;
                fXmlNodeSmgl = null;
                fXmlNodeStrList = null;
                fTranLog = null;
                fLog = null;
                fSmg = null;
                fSmt = null;
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

        private void recvSelectRsp(
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;

            try
            {
                if (!m_fTranSelectReq.enabled)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = this.getRejectReasonMessage(3);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
                }
                else if (m_fTranSelectReq.sessionId != m_fRecvBuf.sessionId)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0015, "Session ID of the Select.Rsp");
                }
                else if (m_fTranSelectReq.systemBytes != m_fRecvBuf.systemBytes)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0015, "System Bytes of the Select.Rsp");
                }
                else if (m_fRecvBuf.byte3 != 0)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = this.getSelectStatusMessage(m_fRecvBuf.byte3);                    
                }
                else
                {
                    fResultCode = FResultCode.Success;
                    m_fTranSelectReq.reset();                    
                }

                // --

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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, fResultCode, resultMessage, fLog);
                }

                // --

                if (fResultCode == FResultCode.Success)
                {
                    procStateSelected();
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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, FResultCode.Success, string.Empty, fLog);
                }

                // --
                
                sendDeselectRsp(m_fRecvBuf.sessionId, m_fRecvBuf.systemBytes);
                
                // --
                
                m_fTcpClient.reconnect();
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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, FResultCode.Warninig, this.getRejectReasonMessage(3), fLog);
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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, FResultCode.Success, string.Empty, fLog);
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
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;

            try
            {                
                if (!m_fTranLinktestReq.enabled)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = this.getRejectReasonMessage(3);
                    // --
                    sendRejectReq(m_fRecvBuf.sessionId, m_fRecvBuf.stype, 3, m_fRecvBuf.systemBytes);
                }
                else if (m_fTranLinktestReq.sessionId != m_fRecvBuf.sessionId)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0015, "Session ID of the Select.Rsp");
                }
                else if (m_fTranLinktestReq.systemBytes != m_fRecvBuf.systemBytes)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = string.Format(FConstants.err_m_0015, "System Bytes of the Select.Rsp");
                }
                else if (m_fRecvBuf.byte3 != 0)
                {
                    fResultCode = FResultCode.Warninig;
                    resultMessage = this.getSelectStatusMessage(m_fRecvBuf.byte3);
                }
                else
                {
                    fResultCode = FResultCode.Success;
                    m_fTranLinktestReq.reset();
                }

                // --

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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, fResultCode, resultMessage, fLog);
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
                    // --
                    fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Reason, FXmlTagCMGL.D_Reason, this.getRejectReasonMessage(m_fRecvBuf.byte3));
                    // --
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, FResultCode.Success, string.Empty, fLog);
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
                    this.fEventPusher.pushSecsDeviceControlMessageReceivedEvent(this.fSecsDevice, FResultCode.Success, string.Empty, fLog);
                }

                // --

                m_fTcpClient.reconnect();
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

                // ***
                // TCP/IP 정보 설정
                // ***
                this.localIp = e.localIp;
                this.localPort = e.localPort;
                this.remoteIp = e.remoteIp;
                this.remotePort = e.remotePort;

                // --

                if (e.fState == FTcpClientState.Opened)
                {
                    procStateOpened();
                }
                else if (e.fState == FTcpClientState.Connected)
                {
                    procStateConnected();
                }
                else if (e.fState == FTcpClientState.Closed)
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

                if (this.fDeviceState != FDeviceState.Connected && this.fDeviceState != FDeviceState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // Select or Linktest Transaction Timeout Check
                // ***
                if (m_fTranSelectReq.timeout() || m_fTranLinktestReq.timeout())
                {
                    if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                    {
                        this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            this.getTimeoutMessage(FSecsDeviceTimeout.T6),
                            FSecsDeviceTimeout.T6,
                            this.getTimeoutDescription(FSecsDeviceTimeout.T6)
                            );
                    }
                    // --
                    sendSeparateReq();
                    m_fTcpClient.reconnect();
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
                    m_fTcpClient.reconnect();
                    return;
                }

                // --

                // ***
                // Linktest Timer Check (Timeout 시, 재시작)
                // ***
                if (m_fTmrLinktest.elasped(true))
                {
                    // ***
                    // Linktest Transaction이 Open되어 있지 않을 경우 Open
                    // ***
                    if (!m_fTranLinktestReq.enabled)
                    {
                        sendLinktestReq();
                        return;
                    }
                }

                // --               
                
                // ***
                // Auto Cycle Transmitter 처리
                // ***
                if (fScdCore.fConfig.enabledEventsOfScenario)
                {
                    if (m_fTmrAutoCycle.elasped(true))
                    {
                        this.fProtocolAgent.runSecsAutoCycleTransmitter(this.fSecsDevice);
                    }
                }

                // --
                
                // ***
                // T3 Timer Check (Open Transaction Timeout Check)
                // ***
                procOpenTransaction();

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
