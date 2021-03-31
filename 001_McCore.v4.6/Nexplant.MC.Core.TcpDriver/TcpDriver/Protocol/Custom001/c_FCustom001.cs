/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCustom001.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.22
--  Description     : FAMate Core FaTcpDriver CUSTOM_001 Class 
--  History         : Created by spike.lee at 2015.06.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FCustom001 : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단

        // --

        private bool m_disposed = false;
        // --
        private FCustom001Protocol m_fCustom001Protocol = null;
        private FIDPointer32 m_fTidPointer = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        private FCustom001OpenTransaction m_fTranDataMessage = null;
        // --
        private FConnectMode m_fConnectMode = FConnectMode.Passive;
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;        
        private int m_t3Timeout = 0;
        private int m_t5Timeout = 0;
        private int m_t8Timeout = 0;
        // --
        private FTcpListener m_fTcpListener = null;
        private FTcpClient m_fTcpClient = null;
        private FStaticTimer m_fTmrT8 = null;          
        // --
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrAutoCycle = null;   
        // --
        private FCustom001RecvBuffer m_fRecvBuf = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustom001(            
            FCustom001Protocol fCustom001Protocol
            )  
        {
            m_fCustom001Protocol = fCustom001Protocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCustom001(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
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

        public FTcdCore fTcdCore
        {
            get
            {
                try
                {
                    return m_fCustom001Protocol.fTcdCore;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProtocolAgent fProtocolAgent
        {
            get
            {
                try
                {
                    return m_fCustom001Protocol.fProtocolAgent;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEventPusher fEventPusher
        {
            get
            {
                try
                {
                    return m_fCustom001Protocol.fTcdCore.fEventPusher;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fCustom001Protocol.fTcdCore.fTcpDriver;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDevice fTcpDevice
        {
            get
            {
                try
                {
                    return m_fCustom001Protocol.fTcpDevice;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDeviceState fDeviceState
        {
            get
            {
                try
                {
                    return m_fDeviceState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIDPointer32 fTidPointer
        {
            get
            {
                try
                {
                    return m_fTidPointer;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
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
                m_fTidPointer = new FIDPointer32();
                // --
                m_fConnectMode = m_fCustom001Protocol.fTcpDevice.fConnectMode;
                m_localIp = m_fCustom001Protocol.fTcpDevice.localIp;
                m_localPort = m_fCustom001Protocol.fTcpDevice.localPort;
                m_remoteIp = m_fCustom001Protocol.fTcpDevice.remoteIp;
                m_remotePort = m_fCustom001Protocol.fTcpDevice.remotePort;
                // --
                m_t3Timeout = m_fCustom001Protocol.fTcpDevice.t3Timeout * 1000;
                m_t5Timeout = m_fCustom001Protocol.fTcpDevice.t5Timeout * 1000;
                m_t8Timeout = m_fCustom001Protocol.fTcpDevice.t8Timeout * 1000;

                // --

                m_fTmrT8 = new FStaticTimer();
                m_fRecvBuf = new FCustom001RecvBuffer();
                m_fTmrAutoCycle = new FStaticTimer();
                m_fTranDataMessage = new FCustom001OpenTransaction(this.fTcpDriver, m_t3Timeout);

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FCustom001MainThread");
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


                // --

                if (m_fTmrT8 != null)
                {
                    m_fTmrT8.Dispose();
                    m_fTmrT8 = null;
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

                if (m_fTranDataMessage != null)
                {
                    m_fTranDataMessage.Dispose();
                    m_fTranDataMessage = null;
                }

                if (m_fTidPointer != null)
                {
                    m_fTidPointer.Dispose();
                    m_fTidPointer = null;
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

                if (m_fTcpClient.fState == FTcpClientState.Connected)
                {
                    if (this.fDeviceState == FDeviceState.Selected)
                    {
                        if (this.fTcdCore.fConfig.enabledEventsOfScenario)
                        {
                            // ***
                            // Auto Action First Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runTcpAutoActionFirstCloseTransmitter(this.fTcpDevice);

                            // ***
                            // Auto Action Always Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runTcpAutoActionAlwaysCloseTransmitter(this.fTcpDevice);
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

        public void open(
            )
        {
            try
            {
                if (m_fConnectMode == FConnectMode.Active)
                {
                    m_fTcpClient = new FTcpClient(
                        this.fTcpDevice.localIp,
                        this.fTcpDevice.remoteIp,
                        this.fTcpDevice.remotePort
                        );
                    m_fTcpClient.retryConnectPeriod = m_t5Timeout; // T5 Timeout 설정
                    // --
                    m_fTcpClient.TcpClientStateChanged += new FTcpClientStateChangedEventHandler(m_fTcpClient_TcpClientStateChanged);
                    m_fTcpClient.TcpClientDataReceived += new FTcpClientDataReceivedEventHandler(m_fTcpClient_TcpClientDataReceived);
                    m_fTcpClient.TcpClientDataSent += new FTcpClientDataSentEventHandler(m_fTcpClient_TcpClientDataSent);
                    m_fTcpClient.TcpClientDataSendFailed += new FTcpClientDataSendFailedEventHandler(m_fTcpClient_TcpClientDataSendFailed);
                    m_fTcpClient.TcpClientErrorRaised += new FTcpClientErrorRaisedEventHandler(m_fTcpClient_TcpClientErrorRaised);
                    // --
                    m_fTcpClient.connect();
                }
                else
                {
                    m_fTcpListener = new FTcpListener(
                        this.fTcpDevice.localIp,
                        this.fTcpDevice.localPort,
                        1
                        );
                    // --
                    m_fTcpListener.TcpListenerAcceptCompleted += new FTcpListenerAcceptCompletedEventHandler(m_fTcpListener_TcpListenerAcceptCompleted);
                    m_fTcpListener.TcpListenerErrorRaised += new FTcpListenerErrorRaisedEventHandler(m_fTcpListener_TcpListenerErrorRaised);
                    // --
                    m_fTcpListener.start();

                    // --

                    procStateOpened();
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

        public void close(
            )
        {
            try
            {                
                if (m_fConnectMode == FConnectMode.Active)
                {
                    closeTcpClient();
                    resetResource();
                }
                else
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
                    resetResource();

                    // --

                    procStateClosed();
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

        public void send(
            FTcpSession fTcpSession,
            FTcpMessageTransfer fTcpMessageTransfer
            )
        {
            try
            {
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));
                }

                // --

                sendDataMessage(fTcpSession, fTcpMessageTransfer);
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

        private void sendDataMessage(
            FTcpSession fTsn,
            FTcpMessageTransfer fTmt
            )
        {
            FXmlNode fXmlNodeTmgl = null;
            FXmlNode fXmlNodeMsg = null;
            FTcpDeviceDataMessageSentLog fLog = null;
            UInt32 tid = 0;
            int sessionId = 0;
            FCustom001SendBuffer fBuf = null;

            try
            {
                if (fTmt.hasTid)
                {
                    tid = fTmt.tid;
                }
                else
                {
                    tid = this.fTidPointer.uniqueId;
                }

                // --

                fXmlNodeTmgl = FCustom001_2.parseTmtToMsg(
                    this.fTcpDevice, 
                    fTsn.fXmlNode, 
                    fTmt.fXmlNode, 
                    tid, 
                    ref sessionId,
                    ref fXmlNodeMsg
                    );

                // --

                fBuf = new FCustom001SendBuffer();
                fBuf.genDataMessage(fXmlNodeMsg);
                fLog = this.fEventPusher.createTcpDeviceDataMessageSentLog(fTsn.fXmlNode, fXmlNodeTmgl); 

                // --

                // ***
                // TcpMessageTransfer에 RepositoryMaterial이 존재할 경우 Reply Message 전송 시, 
                // RepositoryMaterial를 검색하기 위한 Key를 저장한다.
                // ***
                if (fTmt.fRepositoryMaterial != null)
                {
                    fTmt.fRepositoryMaterial.setTcpReplyKey(
                        this.fTcpDevice.uniqueId,
                        fTsn.uniqueId,
                        tid
                        );
                }

                // --

                m_fTcpClient.send(new FSocketSendData(fBuf.getBinaryData(), new object[] { fTsn, fLog, fBuf }));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeMsg = null;
                fXmlNodeTmgl = null;
                fBuf = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pauseProtocol(
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

        public void continueProtocol(
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

        public void changeDeviceState(
            FDeviceState fState
            )
        {
            FTcpDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeTtrList = null;

            try
            {
                m_fDeviceState = fState;

                // --
                 
                // ***
                // Device State 변경
                // ***
                this.fTcpDevice.changeState(m_fDeviceState);

                // --

                // ***
                // Trigger Parse
                // ***
                if (this.fTcpDriver.enabledEventsOfScenario)
                {
                    fXmlNodeTtrList = FCustom001_2.parseConnectionTrigger(this.fTcpDriver, this.fTcpDevice.fXmlNode, fState);

                    // --

                    fLog = new FTcpDeviceStateChangedLog(
                        FTcpDriverLogCommon.createXmlNodeTDVL(this.fTcpDevice.fXmlNode, FXmlTagTDVL.L_StateChanged)
                        );

                    // --
                    foreach (FXmlNode fXmlNodeTtr in fXmlNodeTtrList)
                    {
                        this.fEventPusher.pushTcpTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeTtr, fLog);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
                fXmlNodeTtrList = null;
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
                m_fTmrT8.stop();
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
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState)
                {
                    this.fEventPusher.pushTcpDeviceStateChangedEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.m_localIp,
                        this.m_localPort,
                        this.m_remoteIp,
                        this.m_remotePort
                        );
                }

                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearTcpAutoCycleTransmitter(this.fTcpDevice);
                m_fTmrAutoCycle.stop();

                // -- 

                // ***
                // TCP Retry Condtion 초기화
                // ***
                this.fProtocolAgent.clearTcpRetryCondition(this.fTcpDevice);

                // --

                resetResource();

                // --

                if (m_fConnectMode == FConnectMode.Passive)
                {
                    if (!m_fTcpListener.started)
                    {
                        m_fTcpListener.start();
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

        private void procAccepted(
            FTcpClient fTcpClient
            )
        {
            try
            {
                // ***
                // TCP Listener 중지
                // *** 
                m_fTcpListener.stop();

                // -- 

                if (this.fDeviceState != FDeviceState.Opened)
                {
                    fTcpClient.close();
                    return;
                }                

                // --

                closeTcpClient();

                // --

                // ***
                // TCP/IP 정보 설정
                // ***
                m_localIp = fTcpClient.localIp;
                m_localPort = fTcpClient.localPort;
                m_remoteIp = fTcpClient.remoteIp;
                m_remotePort = fTcpClient.remotePort;

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

                // --

                procStateConnected();
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
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState)
                {
                    this.fEventPusher.pushTcpDeviceStateChangedEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort
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

        private void procStateSelected(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Selected);
                // --
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState)
                {
                    this.fEventPusher.pushTcpDeviceStateChangedEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort
                        );
                }

                // --

                if (this.fTcdCore.fConfig.enabledEventsOfScenario)
                {
                    // ***
                    // Auto Action First Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runTcpAutoActionFirstSelectTransmitter(this.fTcpDevice);

                    // ***
                    // Auto Action Always Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runTcpAutoActionAlwaysSelectTransmitter(this.fTcpDevice);
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
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceState)
                {
                    this.fEventPusher.pushTcpDeviceStateChangedEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.m_localIp,
                        this.m_localPort,
                        this.m_remoteIp,
                        this.m_remotePort
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

        public void procDeviceErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceError)
                {
                    this.fEventPusher.pushTcpDeviceErrorRaisedEvent(this.fTcpDevice, FResultCode.Error, inEx.Message);
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

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataSendFailed(
            string message,
            object state
            )
        {
            object[] stateArr = null;
            FTcpDeviceDataMessageSentLog fLog = null;

            try
            {
                stateArr = (object[])state;

                // --

                fLog = (FTcpDeviceDataMessageSentLog)stateArr[1];
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage)
                {
                    this.fEventPusher.pushTcpDeviceDataMessageSentEvent(
                        this.fTcpDevice,
                        FResultCode.Error,
                        message,
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
                stateArr = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataSent(
            byte[] data,
            object state
            )
        {
            object[] stateArr = null;
            FTcpSession fTsn = null;
            FTcpDeviceDataMessageSentLog fLog = null;
            FCustom001SendBuffer fBuf = null;            
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            FXmlNode fXmlNodeRepTmg = null;
            UInt64 repUniqueId = 0;

            try
            {
                // ***
                // Binary Log Write
                // ***
                if (this.fTcdCore.fConfig.enabledLogOfBinary)
                {
                    this.fTcdCore.fLogWriter.pushBinaryLog(
                        FEventId.TcpDeviceDataSent,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fTcpDevice.name,
                        this.fTcpDevice.fProtocol,
                        this.fTcpDevice.fConnectMode,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort,
                        data
                        );
                }

                // --

                // ***
                // Device Data Event
                // ***
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceData)
                {
                    this.fEventPusher.pushTcpDeviceDataSentEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort,
                        data
                        );
                }

                // --

                stateArr = (object[])state;
                // --
                fTsn = (FTcpSession)stateArr[0];
                fLog = (FTcpDeviceDataMessageSentLog)stateArr[1];
                fBuf = (FCustom001SendBuffer)stateArr[2];

                // --

                // ***
                // Data Length 설정
                // ***
                fLog.fXmlNode.set_attrVal(FXmlTagTMGL.A_Length, FXmlTagTMGL.D_Length, data.Length.ToString());

                // --

                // ***
                // XML Log Write
                // ***
                if (this.fTcdCore.fConfig.enabledLogOfXml)
                {                    
                    this.fTcdCore.fLogWriter.pushXmlLog(
                        FEventId.TcpDeviceXmlSent,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fTcpDevice.name,
                        fLog.sessionId,
                        fLog.tid,
                        (UInt32)data.Length,
                        fResultCode,
                        resultMessage,
                        fBuf.xml
                        );
                }                

                // --

                // ***
                // Device Xml Event
                // ***
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceXml)
                {
                    this.fEventPusher.pushTcpDeviceXmlSentEvent(
                        this.fTcpDevice,
                        fResultCode,
                        resultMessage,
                        fLog.sessionId,
                        fLog.command,
                        fLog.tid,
                        (UInt32)data.Length,
                        fBuf.xml
                        );
                } 

                // --

                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage)
                {
                    this.fEventPusher.pushTcpDeviceDataMessageSentEvent(
                        this.fTcpDevice, 
                        FResultCode.Success, 
                        string.Empty, 
                        fLog
                        );
                }

                // --

                // ***
                // Data Message Open Transaction 설정
                // ***
                if (fLog.fTcpMessageType == FTcpMessageType.Command)
                {
                    fXmlNodeRepTmg = FCustom001_2.getReplyMessage(this.fTcpDriver, fTsn.fXmlNode, fLog.uniqueIdToString);
                    if (fXmlNodeRepTmg != null)
                    {
                        repUniqueId = UInt64.Parse(fXmlNodeRepTmg.get_attrVal(FXmlTagTMG.A_UniqueId, FXmlTagTMG.D_UniqueId));
                        m_fTranDataMessage.openTransaction(
                            this.fEventPusher.createTcpDeviceDataMessageSentLog(fLog.fXmlNodeTsn, fLog.fXmlNode.clone(false)),
                            repUniqueId
                            );
                    }
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                stateArr = null;
                fTsn = null;
                fLog = null;
                fBuf = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataReceived(
            byte[] data
            )
        {
            try
            {               
                if (this.fTcdCore.fConfig.enabledLogOfBinary)
                {
                    this.fTcdCore.fLogWriter.pushBinaryLog(
                        FEventId.TcpDeviceDataReceived,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fTcpDevice.name,
                        this.fTcpDevice.fProtocol,
                        this.fTcpDevice.fConnectMode,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort,
                        data
                        );
                }

                // --

                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceData)
                {
                    this.fEventPusher.pushTcpDeviceDataReceivedEvent(
                        this.fTcpDevice,
                        FResultCode.Success,
                        string.Empty,
                        m_localIp,
                        m_localPort,
                        m_remoteIp,
                        m_remotePort,
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
                    recvDataMessage();

                    // --

                    m_fRecvBuf.init();
                }

                // --

                // ***
                // Parsing이 완료되지 않을 경우 T8 Timer 설정
                // ***
                if (!m_fRecvBuf.isCompleted)
                {
                    m_fTmrT8.start(m_t8Timeout);
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

        private void recvDataMessage(
            )
        {
            const string TcpSessionQuery = FXmlTagTSN.E_TcpSession + "[@" + FXmlTagTSN.A_Name + "='{0}']";

            // --

            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            FXmlNode fXmlNodeTsn = null;
            FXmlNode fXmlNodeTmg = null;
            FXmlNode fXmlNodeTmgl = null;
            FXmlNode[] fXmlNodeTtrList = null;
            FTcpDeviceDataMessageSentLog fTranLog = null;
            FTcpDeviceDataMessageReceivedLog fLog = null;
            FXmlNode fXmlNodeRepTmg = null;
            FTcpMessage fRepTmg = null;
            FTcpMessageTransfer fRepTmt = null;
            string sessionName = string.Empty;
            int sessionId = 0;
            UInt32 tid = 0;     // 해당 프로토콜은 사용하지 못 함.

            try
            {
                // ***
                // 기본 메시지 Parsing 결과 설정
                // ***
                if (m_fRecvBuf.equipId != string.Empty)
                {
                    // ***
                    // 설비에서 전송된 Equip ID를 Session Name으로 사용한다.
                    // ***
                    sessionName = m_fRecvBuf.equipId;
                    // --
                    fXmlNodeTsn = this.fTcpDevice.fXmlNode.selectSingleNode(
                        string.Format(TcpSessionQuery, sessionName)
                        );
                    // --
                    if (fXmlNodeTsn != null)
                    {
                        sessionId = int.Parse(fXmlNodeTsn.get_attrVal(FXmlTagTSN.A_SessionId, FXmlTagTSN.D_SessionId));
                    }              
                }

                if (!m_fRecvBuf.isParseSuccess)                
                {
                    fResultCode = FResultCode.Error;
                    resultMessage = m_fRecvBuf.errorMessage;
                }

                // --

                // ***
                // XML 로그 기록
                // ***
                if (this.fTcdCore.fConfig.enabledLogOfXml)
                {
                    this.fTcdCore.fLogWriter.pushXmlLog(
                        FEventId.TcpDeviceXmlReceived,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fTcpDevice.name,
                        (UInt16)sessionId,
                        tid,
                        m_fRecvBuf.length,
                        fResultCode,
                        resultMessage,
                        m_fRecvBuf.xml
                        );
                }

                // --

                // ***
                // XML 이벤트 Push
                // ***
                if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceXml)
                {
                    this.fEventPusher.pushTcpDeviceXmlReceivedEvent(
                        this.fTcpDevice,
                        fResultCode,
                        resultMessage,
                        (UInt16)sessionId,
                        m_fRecvBuf.msgId,                        
                        0,
                        m_fRecvBuf.length,
                        m_fRecvBuf.xml
                        );
                }                

                // --

                // ***
                // 메시지 파싱
                // ***
                fXmlNodeTmgl = FCustom001_2.parseMsgToTmg(
                    this.fTcpDriver, 
                    this.fTcpDevice,   
                    fXmlNodeTsn,
                    sessionName,
                    sessionId,
                    m_fRecvBuf.msgId, 
                    0, 
                    m_fRecvBuf.fXmlMsg, 
                    m_fRecvBuf.length,
                    ref fResultCode, 
                    ref resultMessage,                     
                    ref fXmlNodeTmg                    
                    );
                fLog = this.fEventPusher.createTcpDeviceDataMessageReceivedLog(fXmlNodeTsn, fXmlNodeTmgl);

                // --

                if (fResultCode == FResultCode.Success)
                {
                    if (fLog.fTcpMessageType == FTcpMessageType.Command || fLog.fTcpMessageType == FTcpMessageType.Unsolicited)
                    {
                        // ***
                        // Primary Message 처리
                        // ***
                        if (fLog.fTcpMessageType == FTcpMessageType.Command)
                        {
                            fXmlNodeRepTmg = FCustom001_2.getReplyMessage(this.fTcpDriver, fXmlNodeTsn, fLog.uniqueIdToString);
                            if (fXmlNodeRepTmg != null)
                            {
                                fRepTmg = new FTcpMessage(this.fTcdCore, fXmlNodeRepTmg);
                            }
                        }

                        // --

                        if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage)
                        {
                            this.fEventPusher.pushTcpDeviceDataMessageReceivedEvent(
                                this.fTcpDevice,
                                fResultCode,
                                resultMessage,
                                fLog,
                                fRepTmg
                                );
                        }

                        // --

                        if (fRepTmg != null)
                        {
                            if (fRepTmg.autoReply)
                            {
                                fRepTmt = fRepTmg.createTransfer(tid);
                                FTcpDriverCommon.setTcpItemRandomValue(fRepTmt.fXmlNode);
                                // --
                                this.sendDataMessage(new FTcpSession(this.fTcdCore, fXmlNodeTsn), fRepTmt);
                            }
                            else
                            {
                                // ***
                                // Reply Message가 Auto Reply가 아닐 경우, TID를 Keeping한다.
                                // *** 
                                this.fProtocolAgent.fTcpTidStorage.add(
                                    fLog.deviceUniqueId,
                                    fLog.sessionUniqueId,
                                    fRepTmg.uniqueId,
                                    fLog.tid
                                    );                                
                            }
                        }                        
                    }
                    else
                    {
                        // ***
                        // Secondary Message 처리
                        // ***
                        fTranLog = m_fTranDataMessage.getTransaction((int)fLog.sessionId, fLog.uniqueId);
                        // --
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

                        if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage)
                        {
                            this.fEventPusher.pushTcpDeviceDataMessageReceivedEvent(
                                this.fTcpDevice, 
                                fResultCode, 
                                resultMessage, 
                                fLog, 
                                null
                                );
                        }
                    }

                    // --

                    // ***
                    // Trigger Parser
                    // ***
                    if (fTcdCore.fConfig.enabledEventsOfScenario)
                    {
                        if (fResultCode == FResultCode.Success)
                        {
                            fXmlNodeTtrList = FCustom001_2.parseExpressionTrigger(this.fTcpDriver, fXmlNodeTmgl);
                            foreach (FXmlNode fXmlNodeTtr in fXmlNodeTtrList)
                            {
                                this.fEventPusher.pushTcpTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeTtr, fLog);
                            }
                        }
                    }
                }
                else
                {
                    if (fLog.fTcpMessageType == FTcpMessageType.Reply)
                    {
                        this.fProtocolAgent.fTcpTidStorage.clear();
                        this.fProtocolAgent.fHostTidStorage.clear();
                    }

                    // --

                    if (this.fTcdCore.fConfig.enabledEventsOfTcpDeviceDataMessage)
                    {
                        this.fEventPusher.pushTcpDeviceDataMessageReceivedEvent(
                            this.fTcpDevice, 
                            fResultCode, 
                            resultMessage, 
                            fLog, 
                            null
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeTsn = null;
                fXmlNodeTmg = null;
                fXmlNodeTmgl = null;
                fXmlNodeTtrList = null;
                fTranLog = null;
                fLog = null;
                fRepTmg = null;
                fRepTmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void clearRetryDataMessage(
            FXmlNode fXmlNodeTmgl
            )
        {
            FXmlNodeList fXmlNodeListTcn = null;

            try
            {
                fXmlNodeListTcn = FHost2.getRetryCondition(this.fTcpDriver, fXmlNodeTmgl);
                foreach (FXmlNode fXmlNodeTcn in fXmlNodeListTcn)
                {
                    fXmlNodeTcn.set_attrVal(FXmlTagTCN.A_RetryCount, FXmlTagTCN.D_RetryCount, "0");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListTcn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procOpenTransaction(
            )
        {
            FTcpDeviceDataMessageSentLog fLog = null;
            FXmlNode[] fXmlNodeTtrList = null;
            FXmlNode fXmlNodeRetryTcn = null;

            try
            {
                while ((fLog = m_fTranDataMessage.getTimeoutTransaction()) != null)
                {
                    if (fTcdCore.fConfig.enabledEventsOfHostDeviceDataMessage)
                    {
                        this.fEventPusher.pushTcpDeviceDataMessageSentEvent(
                            this.fTcpDevice,
                            FResultCode.Error,
                            FConstants.err_m_0032,
                            fLog
                            );
                    }

                    // --

                    if (fTcdCore.fConfig.enabledEventsOfScenario)
                    {
                        fXmlNodeTtrList = FCustom001_2.parseTimeoutTrigger(this.fTcpDriver, fLog.fXmlNode, ref fXmlNodeRetryTcn);
                        foreach (FXmlNode fXmlNodeTtr in fXmlNodeTtrList)
                        {
                            this.fEventPusher.pushTcpTriggerRaisedEvent(
                                FResultCode.Success,
                                string.Empty,
                                fXmlNodeTtr,
                                fLog
                                );
                        }
                    }

                    // --

                    if (fXmlNodeRetryTcn != null)
                    {
                        procRetryDataMessage(fXmlNodeRetryTcn);
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
                fXmlNodeTtrList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procRetryDataMessage(
            FXmlNode fXmlNodeTcn
            )
        {
            int retryLimit = 0;
            int retryCount = 0;
            FTcpCondition fTcn = null;

            try
            {
                retryLimit = int.Parse(fXmlNodeTcn.get_attrVal(FXmlTagTCN.A_RetryLimit, FXmlTagTCN.D_RetryLimit));
                retryCount = int.Parse(fXmlNodeTcn.get_attrVal(FXmlTagTCN.A_RetryCount, FXmlTagTCN.D_RetryCount));

                // --

                // ***
                // Retry Limit 횟수만큼 시도되었을 경우, Retry 횟수 초기화
                // ***
                if (retryLimit == retryCount)
                {
                    fXmlNodeTcn.set_attrVal(FXmlTagTCN.A_RetryCount, FXmlTagTCN.D_RetryCount, "0");
                    return;
                }

                // --

                fTcn = new FTcpCondition(this.fTcdCore, fXmlNodeTcn);
                fTcn.fMessage.createTransfer().send(fTcn.fSession);

                // --

                // ***
                // Retry 회수 증가
                // ***
                fXmlNodeTcn.set_attrVal(FXmlTagTCN.A_RetryCount, FXmlTagTCN.D_RetryCount, (retryCount + 1).ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcn = null;
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
            bool isConnected = false;

            try
            {
                m_fMainSync.wait();

                // --

                if (m_fConnectMode == FConnectMode.Active)
                {                    
                    m_localIp = e.localIp;
                    m_localPort = e.localPort;
                    m_remoteIp = e.remoteIp;
                    m_remotePort = e.remotePort;

                    // --

                    if (e.fState == FTcpClientState.Opened)
                    {
                        procStateOpened();
                    }
                    else if (e.fState == FTcpClientState.Connected)
                    {
                        procStateConnected();
                        isConnected = true;
                    }
                    else if (e.fState == FTcpClientState.Closed)
                    {
                        procStateClosed();
                    }
                }
                else
                {
                    if (m_fTcpListener != null && e.fState == FTcpClientState.Closed)
                    {
                        procStateOpened();                        
                    }
                }

                // --

                if (isConnected)
                {
                    m_fMainSync.set();
                    procStateSelected();
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (!isConnected)
                {
                    m_fMainSync.set();
                }                
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

        #region m_fTcpListener Object Event Handler

        private void m_fTcpListener_TcpListenerAcceptCompleted(
            object sender,
            FTcpListenerAcceptCompletedEventArgs e
            )
        {
            bool isConnected = false;

            try
            {
                m_fMainSync.wait();

                // --

                procAccepted(e.fTcpClient);
                isConnected = true;

                // --

                if (isConnected)
                {
                    m_fMainSync.set();
                    procStateSelected(); 
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (!isConnected)
                {
                    m_fMainSync.set();
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getTimeoutMessage(
            FTcpDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FTcpDeviceTimeout.T3)
                {
                    return FConstants.err_m_20003;
                }
                else if (fTimeout == FTcpDeviceTimeout.T5)
                {
                    return FConstants.err_m_20005;
                }
                else if (fTimeout == FTcpDeviceTimeout.T8)
                {
                    return FConstants.err_m_20008;
                }
                return string.Empty;
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

        //------------------------------------------------------------------------------------------------------------------------

        public string getTimeoutDescription(
            FTcpDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FTcpDeviceTimeout.T3)
                {
                    return FConstants.err_m_21003;
                }
                else if (fTimeout == FTcpDeviceTimeout.T5)
                {
                    return FConstants.err_m_21005;
                }
                else if (fTimeout == FTcpDeviceTimeout.T8)
                {
                    return FConstants.err_m_21008;
                }
                return string.Empty;
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
                // T8 Timer check
                // ***
                if (m_fTmrT8.elasped(false))
                {
                    if (fTcdCore.fConfig.enabledEventsOfTcpDeviceTimeout)
                    {
                        this.fEventPusher.pushTcpDeviceTimeoutRaisedEvent(
                            this.fTcpDevice,
                            FResultCode.Error,
                            this.getTimeoutMessage(FTcpDeviceTimeout.T8),
                            FTcpDeviceTimeout.T8,
                            this.getTimeoutDescription(FTcpDeviceTimeout.T8)
                            );
                    }
                    // --
                    if (m_fConnectMode == FConnectMode.Active)
                    {
                        m_fTcpClient.reconnect();
                    }
                    else
                    {
                        m_fTcpClient.close();
                    }                    
                    return;
                }

                // --

                // ***
                // Auto Cycle Transmitter 처리
                // ***
                if (fTcdCore.fConfig.enabledEventsOfScenario)
                {
                    if (m_fTmrAutoCycle.elasped(true))
                    {
                        this.fProtocolAgent.runTcpAutoCycleTransmitter(this.fTcpDevice);
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
