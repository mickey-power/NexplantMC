/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelsece.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.25
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Class 
--  History         : Created by Jeff.Kim at 2013.07.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelsece : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단
        private const int AutoTraceRunTime = 50;

        // --

        private bool m_disposed = false;
        // --
        private bool m_autoClearCompleted = false;
        private bool m_selectedActionCompleted = false;
        private bool m_closing = false;
        private FMelseceProtocol m_fMelseceProtocol = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;        
        // --        
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;
        private int m_t2Timeout = 0;    // PLC Command Reply Timeout
        private int m_t3Timeout = 0;    // PLC Bit Auto Reset Timeout
        private int m_t5Timeout = 0;    // PLC Recconnect Timeout
        private FQueue<FMelseceLinkMapData> m_fReqLinkMapQueue = null;
        private Dictionary<string, FMelseceSession> m_fSessionList = null;
        // --
        private FTcpClient m_fTcpClient = null;
        private FMelseceRecvBuffer m_fRecvBuffer = null;
        // --
        private FMelseceAutoResetList m_fAutoResetList = null;
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FCodeLock m_fMelseceReqSync = null;
        private FThread m_fThdMelseceReq = null;
        private FStaticTimer m_fTmrAutoCycle = null;
        private FStaticTimer m_fTmrAutoTrace = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelsece(            
            FMelseceProtocol fMelseceProtocol
            )  
        {
            m_fMelseceProtocol = fMelseceProtocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelsece(
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
                    // --
                    m_fMelseceProtocol = null;
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

        public FMelseceProtocol fMelseceProtocol
        {
            get
            {
                try
                {
                    return m_fMelseceProtocol;
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
                    return m_fMelseceProtocol.fProtocolAgent;
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

        public FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fMelseceProtocol.fPcdCore;
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
                    return m_fMelseceProtocol.fPcdCore.fEventPusher;
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

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fMelseceProtocol.fPcdCore.fPlcDriver;
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

        public FPlcDevice fPlcDevice
        {
            get
            {
                try
                {
                    return m_fMelseceProtocol.fPlcDevice;
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

        public string localIp
        {
            get
            {
                try
                {
                    return m_localIp;
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

            set
            {
                try
                {
                    m_localIp = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int localPort
        {
            get
            {
                try
                {
                    return m_localPort;
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

            set
            {
                try
                {
                    m_localPort = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string remoteIp
        {
            get
            {
                try
                {
                    return m_remoteIp;
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

            set
            {
                try
                {
                    m_remoteIp = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int remotePort
        {
            get
            {
                try
                {
                    return m_remotePort;
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

            set
            {
                try
                {
                    m_remotePort = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int t2Timeout
        {
            get
            {
                try
                {
                    return m_t2Timeout;
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

        public int t3Timeout
        {
            get
            {
                try
                {
                    return m_t3Timeout;
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

        public int t5Timeout
        {
            get
            {
                try
                {
                    return m_t5Timeout;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_localIp = m_fMelseceProtocol.fPlcDevice.localIp;
                m_localPort = m_fMelseceProtocol.fPlcDevice.localPort;
                m_remoteIp = m_fMelseceProtocol.fPlcDevice.remoteIp;
                m_remotePort = m_fMelseceProtocol.fPlcDevice.remotePort;
                // --
                m_t2Timeout = (int)(m_fMelseceProtocol.fPlcDevice.t2Timeout * 1000);
                m_t3Timeout = m_fMelseceProtocol.fPlcDevice.t3Timeout * 1000;
                m_t5Timeout = m_fMelseceProtocol.fPlcDevice.t5Timeout * 1000;

                // --

                m_fReqLinkMapQueue = new FQueue<FMelseceLinkMapData>();
                m_fSessionList = new Dictionary<string, FMelseceSession>();
                m_fRecvBuffer = new FMelseceRecvBuffer();
                m_fTmrAutoCycle = new FStaticTimer();
                m_fTmrAutoTrace = new FStaticTimer();

                // --

                m_fAutoResetList = new FMelseceAutoResetList(m_t3Timeout);

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FMelseceMainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();   

                // --

                m_fMelseceReqSync = new FCodeLock();
                m_fThdMelseceReq = new FThread("FMelseceReqThread");
                m_fThdMelseceReq.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMelseceReq_ThreadJobCalled);
                m_fThdMelseceReq.start(); 
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

                if (m_fThdMelseceReq != null)
                {
                    m_fThdMelseceReq.stop();
                    m_fThdMelseceReq.Dispose();
                    m_fThdMelseceReq.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMelseceReq_ThreadJobCalled);
                    m_fThdMelseceReq = null;
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

                if (m_fRecvBuffer != null)
                {
                    m_fRecvBuffer.Dispose();
                    m_fRecvBuffer = null;
                }

                // --

                if (m_fTmrAutoCycle != null)
                {
                    m_fTmrAutoCycle.Dispose();
                    m_fTmrAutoCycle = null;
                }

                // --

                if (m_fTmrAutoTrace != null)
                {
                    m_fTmrAutoTrace.Dispose();
                    m_fTmrAutoTrace = null;
                }

                // --

                if (m_fMelseceReqSync != null)
                {
                    m_fMelseceReqSync.Dispose();
                    m_fMelseceReqSync = null;
                }

                // --

                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
                }

                // --

                m_fAutoResetList = null;
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
            FPlcDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodePtrList = null;
            try
            {
                m_fDeviceState = fState;

                // --

                this.fPlcDevice.changeState(fState);

                // ***
                // Trigger Parse
                // ***
                if (this.fPcdCore.fPlcDriver.enabledEventsOfScenario)
                {
                    fXmlNodePtrList = FMelsece2.parseConnectionTrigger(this.fPlcDriver, this.fPlcDevice.fXmlNode, fState);
                    // --

                    fLog = new FPlcDeviceStateChangedLog(
                        FPlcDriverLogCommon.createXmlNodePDVL(this.fPlcDevice.fXmlNode, FXmlTagPDVL.L_StateChanged)
                        );

                    // --

                    foreach (FXmlNode fXmlNodeStr in fXmlNodePtrList)
                    {
                        this.fEventPusher.pushPlcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeStr, fLog);
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
                fXmlNodePtrList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void open(
            )
        {
            try
            {
                // ***
                // Session 정보 Create
                // ***
                foreach (FPlcSession fPsn in m_fMelseceProtocol.fPlcDevice.fChildPlcSessionCollection)
                {
                    m_fSessionList.Add(fPsn.uniqueIdToString, new FMelseceSession(fPsn));
                }

                // --

                m_fTcpClient = new FTcpClient(
                    this.fMelseceProtocol.fPlcDevice.localIp,
                    this.fMelseceProtocol.fPlcDevice.remoteIp,
                    this.fMelseceProtocol.fPlcDevice.remotePort
                    );
                m_fTcpClient.retryConnectPeriod = this.t5Timeout; // Reconnect Timeout 설정
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

        public void close(
            )
        {
            bool isWait = false;

            try
            {
                if (m_closing)
                {
                    return;
                }

                // --

                m_fMelseceReqSync.wait();
                isWait = true;
                // --
                m_closing = true;

                // --

                // ***
                // Separate.Req 전송
                // ***
                if (m_fTcpClient.fState == FTcpClientState.Connected)
                {
                    if (this.fDeviceState == FDeviceState.Selected)
                    {
                        if (fPcdCore.fConfig.enabledEventsOfScenario)
                        {
                            // ***
                            // Auto Action First Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runPlcAutoActionFirstCloseTransmitter(this.fPlcDevice);

                            // ***
                            // Auto Action Always Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runPlcAutoActionAlwaysCloseTransmitter(this.fPlcDevice);
                        }

                        // --

                        if (m_fReqLinkMapQueue.count > 0)
                        {
                            procLinkMapData();
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

                // --

                m_fSessionList.Clear();

                // --

                resetResource();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (isWait)
                {
                    m_fMelseceReqSync.set();
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void write(
            FPlcSession fPlcSession, 
            FPlcMessageTransfer fPlcMessageTransfer
            )
        {
            try
            {
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));
                }

                // --

                if (fPlcMessageTransfer.fPlcMessageTransferAreaType == FPlcMessageTransferAreaType.Unknown)
                {
                    fPlcMessageTransfer.fPlcMessageTransferAreaType = FPlcMessageTransferAreaType.Write;
                }
                // --
                requestMessageLinkMapWrite(fPlcSession, fPlcMessageTransfer);
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

        public void read(
            FPlcSession fPlcSession, 
            FPlcMessageTransfer fPlcMessageTransfer
            )
        {
            try
            {
                if (this.fDeviceState != FDeviceState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Device"));
                }

                // --

                if (fPlcMessageTransfer.fPlcMessageTransferAreaType == FPlcMessageTransferAreaType.Unknown)
                {
                    fPlcMessageTransfer.fPlcMessageTransferAreaType = FPlcMessageTransferAreaType.Read;
                }
                // --
                requestMessageLinkMapRead(fPlcSession, fPlcMessageTransfer);
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

        private void resetResource(
            )
        {
            try
            {
                m_fAutoResetList.clear();
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
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfPlcDeviceState)
                {
                    this.fEventPusher.pushPlcDeviceStateChangedEvent(
                        this.fPlcDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
                }

                // --

                m_autoClearCompleted = false;
                m_selectedActionCompleted = false;
                // --
                foreach (FMelseceSession fMsn in m_fSessionList.Values)
                {
                    fMsn.fReadTimer.stop();
                }

                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearPlcAutoCycleTransmitter(this.fPlcDevice);
                m_fTmrAutoCycle.stop();

                // --

                // ***
                // Auto Trace Run Time 중지
                // ***
                this.fProtocolAgent.clearAutoTraceMessage(this.fPlcDevice);
                m_fTmrAutoTrace.stop();
                
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
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfPlcDeviceState)
                {
                    this.fEventPusher.pushPlcDeviceStateChangedEvent(
                        this.fPlcDevice,
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
                // Plc는 Selected Transaction 이 따로 없으므로 Connected가 되면 바로 Selected 로 변경
                // ***
                procStateSelected();
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
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfPlcDeviceState)
                {
                    this.fEventPusher.pushPlcDeviceStateChangedEvent(
                        this.fPlcDevice,
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

        private void procStateClosed(
            )
        {
            try
            {
                this.changeDeviceState(FDeviceState.Closed);
                // --
                if (fPlcDriver.fPcdCore.fConfig.enabledEventsOfPlcDeviceState)
                {
                    this.fEventPusher.pushPlcDeviceStateChangedEvent(
                        this.fPlcDevice,
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
            int needLen = 0;
            int copyLen = 0;
            int cursor = 0;
            byte[] buf = null;
            FResultCode fResultCode = FResultCode.Success;
            string message = string.Empty;

            try
            {
                if (!m_fRecvBuffer.enabled)
                {
                    fResultCode = FResultCode.Warninig;
                    message = string.Format(FConstants.err_m_0036, "Unexpected Data");
                }
                
                // --
                
                if (this.fPcdCore.fConfig.enabledLogOfBinary)
                {
                    this.fPcdCore.fLogWriter.pushBinaryLog(
                        FEventId.PlcDeviceDataReceived,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fPlcDevice.name,
                        this.fPlcDevice.fProtocol,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceData)
                {
                    this.fEventPusher.pushPlcDeviceDataReceivedEvent(
                        this.fPlcDevice,
                        fResultCode,
                        message,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                // ***
                // PLC로 데이터를 요청하지 않았는데 데이터가 전송될 경우 Device Error로 처리한다.
                // ***
                if (!m_fRecvBuffer.enabled)
                {
                    procDeviceErrorRaised(new FException(message));
                    return;
                }

                // --

                if (m_fRecvBuffer.headerLength < 9)
                {
                    needLen = 9 - m_fRecvBuffer.headerLength;
                    // --
                    if (data.Length > needLen)
                    {
                        copyLen = needLen;
                    }
                    else
                    {
                        copyLen = data.Length;
                    }
                    // --
                    buf = new byte[copyLen];
                    Array.Copy(data, buf, copyLen);
                    m_fRecvBuffer.header.AddRange(buf);
                    // --
                    m_fRecvBuffer.headerLength += copyLen;
                    cursor += copyLen;

                    // --

                    if (m_fRecvBuffer.headerLength == 9)
                    {
                        m_fRecvBuffer.dataSpece = (int)BitConverter.ToUInt16(m_fRecvBuffer.header.GetRange(7, 2).ToArray(), 0);
                    }
                }

                // --

                if (cursor < data.Length)
                {
                    needLen = m_fRecvBuffer.dataSpece - m_fRecvBuffer.dataLength;
                    // --
                    if ((data.Length - cursor) > needLen)
                    {
                        copyLen = needLen;
                    }
                    else
                    {
                        copyLen = data.Length - cursor;
                    }
                    // --
                    buf = new byte[copyLen];
                    Array.Copy(data, cursor, buf, 0, copyLen);
                    m_fRecvBuffer.data.AddRange(buf);
                    // --
                    m_fRecvBuffer.dataLength += copyLen;
                    cursor += copyLen;

                    // --

                    if (m_fRecvBuffer.dataLength >= m_fRecvBuffer.dataSpece)
                    {
                        m_fRecvBuffer.result = true;
                        // --
                        m_fRecvBuffer.set();
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

        private void procDataSent(
            byte[] data
            )
        {
            try
            {
                if (this.fPcdCore.fConfig.enabledLogOfBinary)
                {
                    this.fPcdCore.fLogWriter.pushBinaryLog(
                        FEventId.PlcDeviceDataSent,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fPlcDevice.name,
                        this.fPlcDevice.fProtocol,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
                        );
                }

                // --

                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceData)
                {
                    this.fEventPusher.pushPlcDeviceDataSentEvent(
                        this.fPlcDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort,
                        data
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

        private void procDataSendFailed(
            string message
            )
        {
            try
            {
                m_fRecvBuffer.result = false;
                m_fRecvBuffer.message = message;
                // --
                m_fRecvBuffer.set();
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

        private void procDeviceErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceError)
                {
                    this.fEventPusher.pushPlcDeviceErrorRaisedEvent(this.fPlcDevice, FResultCode.Error, inEx.Message);
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

        private void procSessionLinkMapRead( 
            FMelseceLinkMapSessionReadData fLinkMapData
            )
        {
            FMelseceBitResult fBitResult = null;
            FMelseceWordResult fWordResult = null;
            UInt32[] chgBits = null;
            UInt32 address = 0;
            byte bit = 0;
            FXmlNodeList fXmlNodeListPmg = null;
            FXmlNodeList fXmlNodeListPbt = null;
            string uid = string.Empty;
            HashSet<string> uidKeys = null;
            List<FXmlNode> fPmgList = null;
            UInt32 bitAddr = 0;
            byte defBit = 0;
            byte plcBit = 0;
            bool isRead = false;
            string msg = string.Empty;
            FXmlNode fXmlNodePmgl = null;
            FPlcDeviceDataMessageReadLog fLog = null;
            FXmlNode fXmlNodeReplyPmg = null;
            FPlcMessage fReplyPmg = null;
            FPlcMessageTransfer fPmt = null;
            FXmlNode[] fXmlNodePtrList = null;            

            try
            {
                // ***
                // Session Bit 영역 Read
                // ***
                foreach (FMelseceData fData in fLinkMapData.fBitReadList)
                {
                    if (fData.fType == FPlcDataType.BitRead)
                    {
                        fBitResult = readBatchBit((FMelseceBitReadData)fData);
                        // --
                        if (!fBitResult.result)
                        {
                            if (fBitResult.isTimeout)
                            {
                                fLinkMapData.fSession.fReadTimer.stop();
                            }
                            // --
                            msg =
                                string.Format(FConstants.err_m_0038, "\"" + fLinkMapData.fSession.fPlcSession.name + "\" Session", "scan") +
                                " " +
                                fBitResult.message;
                            procDeviceErrorRaised(new FException(msg));
                            return;
                        }
                        // --
                        fLinkMapData.fBitResultList.Add(fBitResult); 
                    }
                    else if (fData.fType == FPlcDataType.WordRead)
                    {
                        fWordResult = readBatchWord((FMelseceWordReadData)fData);
                        // --
                        if (!fWordResult.result)
                        {
                            if (fWordResult.isTimeout)
                            {
                                fLinkMapData.fSession.fReadTimer.stop();
                            }
                            // --
                            msg =
                                string.Format(FConstants.err_m_0038, "\"" + fLinkMapData.fSession.fPlcSession.name + "\" Session", "scan") +
                                " " +
                                fWordResult.message;
                            procDeviceErrorRaised(new FException(msg));
                            return;
                        }
                        // --
                        fLinkMapData.fBitResultList.Add(fWordResult); 
                    }
                }
                
                // --

                // ***
                // Bit 영역이 변경되지 않았을 경우 Word 영역을 Read 하지 않는다.
                // ***
                chgBits = fLinkMapData.fSession.getChangedReadBits(fLinkMapData.getReadBits());
                if (chgBits.Length == 0)
                {
                    return;
                }
                
                // --

                // ***
                // Read Message 검색
                // ***
                uidKeys = new HashSet<string>();
                fPmgList = new List<FXmlNode>();
                // --
                foreach (UInt32 chgBit in chgBits)
                {
                    address = (UInt32)(chgBit & 0x7FFFFFFF);
                    bit = (byte)((chgBit & 0x80000000) >> 31);

                    // --

                    // ***
                    // Bit 조건에 해당하는 PLC Read Message 검색
                    // ***
                    fXmlNodeListPmg = 
                        FMelsece2.getReadMessage(
                            m_fMelseceProtocol.fPcdCore.fPlcDriver, 
                            fLinkMapData.fSession.fPlcSession, 
                            address, 
                            bit
                            );
                    
                    // --

                    // ***
                    // 미포함된 PLC Read Message 추출
                    // ***
                    foreach (FXmlNode fXmlNodePmg in fXmlNodeListPmg)
                    {
                        uid = fXmlNodePmg.get_attrVal(FXmlTagPMG.A_UniqueId, FXmlTagPMG.D_UniqueId);
                        if (uidKeys.Contains(uid))
                        {
                            continue;
                        }
                        uidKeys.Add(uid);
                        
                        // --

                        isRead = true;
                        fXmlNodeListPbt = FMelsece2.getBitOfReadMessage(fXmlNodePmg);
                        foreach (FXmlNode fXmlNodePbt in fXmlNodeListPbt)
                        {
                            bitAddr = UInt32.Parse(fXmlNodePbt.get_attrVal(FXmlTagPBT.A_Address, FXmlTagPBT.D_Address));
                            defBit = byte.Parse(fXmlNodePbt.get_attrVal(FXmlTagPBT.A_Value, FXmlTagPBT.D_Value));
                            plcBit = fLinkMapData.fSession.getReadBit(bitAddr);
                            // --
                            if (defBit != plcBit)
                            {
                                isRead = false;
                                break;
                            }
                        }

                        // --

                        if (isRead)
                        {
                            fPmgList.Add(fXmlNodePmg);
                        }
                    }
                }

                // --

                // ***
                // Read Message가 존재하지 않을 경우 Word 영역 Read Skip
                // ***
                if (fPmgList.Count == 0)
                {
                    return;
                }

                // --

                // ***
                // Session Word 영역 Read
                // *** 
                foreach (FMelseceWordReadData fData in fLinkMapData.fWordReadList)
                {
                    fWordResult = readBatchWord(fData);
                    // --
                    if (!fWordResult.result)
                    {
                        if (fWordResult.isTimeout)
                        {
                            fLinkMapData.fSession.fReadTimer.stop();
                        }
                        // --
                        msg =
                            string.Format(FConstants.err_m_0038, "\"" + fLinkMapData.fSession.fPlcSession.name + "\" Session", "scan") +
                            " " +
                            fWordResult.message;
                        procDeviceErrorRaised(new FException(msg));
                        return;
                    }
                    // --
                    fLinkMapData.fWordResultList.Add(fWordResult);
                }
                // --
                fLinkMapData.fSession.setReadWords(fLinkMapData.getReadWords());

                // --

                // ***
                // Read Message Parsing
                // ***
                foreach (FXmlNode fXmlNodePmg in fPmgList)
                {
                    fXmlNodePmgl = FMelsece2.parseSessionBinToPmg(
                        this.fPlcDevice,
                        fLinkMapData.fSession,
                        fXmlNodePmg,
                        fLinkMapData.bitDeviceCode,
                        fLinkMapData.bitStartAddress,
                        fLinkMapData.wordDeviceCode,
                        fLinkMapData.wordStartAddress
                        );
                    // --
                    fLog = this.fEventPusher.createPlcDeviceDataMessageReadLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fXmlNodePmgl);
                    
                    // --

                    if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageReadEvent(
                            this.fPlcDevice,
                            FResultCode.Success,
                            string.Empty,
                            fLog
                            );
                    }

                    // --

                    // ***
                    // Reply Message
                    // ***
                    if (fLog.isPrimary)
                    {
                        fXmlNodeReplyPmg = FMelsece2.getReplyMessage(
                            this.fPlcDriver, 
                            fLinkMapData.fSession.fPlcSession, 
                            fLog.uniqueIdToString
                            );
                        // --
                        if (fXmlNodeReplyPmg != null)
                        {
                            fReplyPmg = new FPlcMessage(this.fPcdCore, fXmlNodeReplyPmg);
                            // --
                            if (fReplyPmg.autoReply)
                            {
                                // ***
                                // Auto Reply Message Random Value 설정
                                // ***
                                fPmt = fReplyPmg.createTransfer();
                                FPlcDriverCommon.setPlcWordRandomValue(fPmt.fXmlNode);

                                // --

                                requestMessageLinkMapWrite(fLinkMapData.fSession.fPlcSession, fPmt);
                            }
                        }
                    }

                    // --

                    // ***
                    // PLC Trigger Parsing
                    // ***
                    if (this.fPcdCore.fPlcDriver.enabledEventsOfScenario)
                    {
                        fXmlNodePtrList = FMelsece2.parseExpressionTrigger(this.fPlcDriver, fXmlNodePmgl);
                        foreach (FXmlNode fXmlNodePtr in fXmlNodePtrList)
                        {
                            this.fEventPusher.pushPlcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodePtr, fLog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fBitResult = null;
                fWordResult = null;
                chgBits = null;
                address = 0;
                fXmlNodeListPmg = null;
                fXmlNodeListPbt = null;
                uidKeys = null;
                fPmgList = null;
                fXmlNodePmgl = null;
                fLog = null;
                fXmlNodeReplyPmg = null;
                fReplyPmg = null;
                fPmt = null;
                fXmlNodePtrList = null;

                // --

                fLinkMapData.fSession.isReadCompleted = true;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSessionLinkMapAutoClear(
            )
        {
            FMelseceBitWriteData fBitData = null;
            FMelseceWordWriteData fWordData = null;
            FMelseceBitResult fBResult = null;
            FMelseceWordResult fWResult = null;
            byte deviceCode = 0;
            UInt32 startAddress = 0;
            int length = 0;
            int writeCnt = 0;
            int remLen = 0;
            int remBitLen = 0;            

            try
            {
                foreach (FMelseceSession fMsn in m_fSessionList.Values)
                {
                    if (!fMsn.fPlcSession.autoClear)
                    {
                        continue;
                    }

                    // --

                    // ***
                    // Write Word 영역 Clear
                    // ***
                    deviceCode = FPlcValueConverter.toMelseceDeviceCode(fMsn.fPlcSession.writeWordDeviceCode);
                    startAddress = fMsn.fPlcSession.writeWordStartAddr;
                    length = fMsn.fPlcSession.writeWordLength;
                    // --
                    writeCnt = (length / 960) + (length % 960 > 0 ? 1 : 0);

                    // --

                    for (int i = 0; i < writeCnt; i++)
                    {
                        fWordData = new FMelseceWordWriteData();

                        // --

                        fWordData.deviceCode = deviceCode;
                        fWordData.address = startAddress;
                        startAddress += 960;
                        // --
                        if (i < writeCnt - 1)
                        {
                            fWordData.length = 960;
                            fWordData.bytes = new byte[960 * 2];
                        }
                        else
                        {
                            remLen = length % 960;
                            if (remLen == 0)
                            {
                                fWordData.length = 960;
                                fWordData.bytes = new byte[960 * 2];
                            }
                            else
                            {
                                fWordData.length = (UInt16)remLen;
                                fWordData.bytes = new byte[remLen * 2];
                            }
                        }
                        // --
                        fWordData.timeout = this.t2Timeout;

                        // --

                        fWResult = writeBatchWord(fWordData);
                        if (!fWResult.result)
                        {
                            procDeviceErrorRaised(new FException("Session Auto Clear Failed!"));
                            return;
                        }
                    }

                    // --

                    // ***
                    // Write Bit 영역 Clear
                    // ***
                    deviceCode = FPlcValueConverter.toMelseceDeviceCode(fMsn.fPlcSession.writeBitDeviceCode);
                    startAddress = fMsn.fPlcSession.writeBitStartAddr;
                    //--
                    remBitLen = fMsn.fPlcSession.writeBitLength % 16;
                    length = (fMsn.fPlcSession.writeBitLength - remBitLen) / 16;
                    writeCnt = (length / 960) + (length % 960 > 0 ? 1 : 0);

                    // --

                    for (int i = 0; i < writeCnt; i++)
                    {
                        fWordData = new FMelseceWordWriteData();

                        // --

                        fWordData.deviceCode = deviceCode;
                        fWordData.address = startAddress;
                        // --
                        if (i < writeCnt - 1)
                        {
                            fWordData.length = 960;
                            fWordData.bytes = new byte[960 * 2];
                            // --
                            startAddress += (960 * 16);
                        }
                        else
                        {
                            remLen = length % 960;
                            if (remLen == 0)
                            {
                                fWordData.length = 960;
                                fWordData.bytes = new byte[960 * 2];
                                // --
                                startAddress += (960 * 16);
                            }
                            else
                            {
                                fWordData.length = (UInt16)remLen;
                                fWordData.bytes = new byte[remLen * 2];
                                // --
                                startAddress += ((uint)remLen * 16);
                            }
                        }
                        // --
                        fWordData.timeout = this.t2Timeout;

                        // --

                        fWResult = writeBatchWord(fWordData);
                        if (!fWResult.result)
                        {
                            procDeviceErrorRaised(new FException("Session Auto Clear Failed!"));
                            return;
                        }
                    }

                    //

                    // ***
                    // Write Bit 영역 Clear (자투리 Bit)
                    // ***
                    if (remBitLen > 0)
                    {
                        fBitData = new FMelseceBitWriteData();
                        // --
                        fBitData.deviceCode = deviceCode;
                        fBitData.address = startAddress;
                        fBitData.length = (UInt16)remBitLen;
                        fBitData.bits = new byte[remBitLen];
                        // --
                        fBitData.timeout = this.t2Timeout;

                        // --

                        fBResult = writeBatchBit(fBitData);
                        if (!fBResult.result)
                        {
                            procDeviceErrorRaised(new FException("Session Auto Clear Failed!"));
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fBitData = null;
                fWordData = null;
                fBResult = null;
                fWResult = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMessageLinkMapWrite(
            FMelseceLinkMapMessageWriteData fLinkMapData
            )
        {
            FMelseceBitResult fBitResult = null;
            FMelseceWordResult fWordResult = null;
            FPlcDeviceDataMessageWrittenLog fLog = null;            

            try
            {
                fLog = this.fEventPusher.createPlcDeviceDataMessageWrittenLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fLinkMapData.fXmlNodePmgl);

                // --

                // ***
                // Message Word 영역 write
                // ***
                foreach (FMelseceWordWriteData[] fWordDatas in fLinkMapData.fWordWriteList)
                {
                    fWordResult = writeRandomWord(fWordDatas, fLinkMapData.timeout);
                    if (!fWordResult.result)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageWrittenEvent(this.fPlcDevice, FResultCode.Error, fWordResult.message, fLog);
                        return;
                    }
                }

                // --
                
                // ***
                // Message Bit 영역 Write
                // ***
                foreach (FMelseceBitWriteData[] fBitDatas in fLinkMapData.fBitWriteList)
                {
                    fBitResult = writeRandomBit(fBitDatas, fLinkMapData.timeout);
                    if (!fBitResult.result)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageWrittenEvent(this.fPlcDevice, FResultCode.Error, fBitResult.message, fLog);
                        return;
                    }
                }

                // --

                if (fLinkMapData.fMessageAreaType == FPlcMessageTransferAreaType.Write)
                {
                    // ***
                    // Auto Reset 해제
                    // ***
                    foreach (FPlcBitLog fPbtl in fLog.fChildPlcBitListLogCollection[0].fChildPlcBitLogCollection)
                    {
                        m_fAutoResetList.remove(fLog.bitDeviceCode, fLog.bitStartAddr, fPbtl.addr);
                    }

                    // --

                    // ***
                    // Auto Reset 처리
                    // ***
                    if (fLog.autoReset)
                    {
                        foreach (FPlcBitLog fPbtl in fLog.fChildPlcBitListLogCollection[0].fChildPlcBitLogCollection)
                        {
                            m_fAutoResetList.add(
                                new FMelseceAutoReset(fLinkMapData.fSession, fLog.fXmlNode.clone(false), fPbtl.fXmlNode.clone(false))
                                );
                        }
                    }
                }

                // --

                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage)
                {
                    this.fEventPusher.pushPlcDeviceDataMessageWrittenEvent(this.fPlcDevice, FResultCode.Success, string.Empty, fLog);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fBitResult = null;
                fWordResult = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMessageLinkMapAutoReset(
            FMelseceLinkMapAutoResetData fLinkMapData
            )
        {
            FMelseceBitResult fBitResult = null;
            FPlcDeviceDataMessageWrittenLog fLog = null;            

            try
            {
                fLog = this.fEventPusher.createPlcDeviceDataMessageWrittenLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fLinkMapData.fXmlNodePmgl);

                // --

                // ***
                // Message Bit 영역 Write
                // ***
                foreach (FMelseceBitWriteData[] fBitDatas in fLinkMapData.fBitWriteList)
                {
                    fBitResult = writeRandomBit(fBitDatas, fLinkMapData.timeout);
                    if (!fBitResult.result)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageWrittenEvent(this.fPlcDevice, FResultCode.Error, fBitResult.message, fLog);
                        return;
                    }
                }

                // --

                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage)
                {
                    this.fEventPusher.pushPlcDeviceDataMessageWrittenEvent(
                        this.fPlcDevice, 
                        FResultCode.Warninig, 
                        string.Format(FConstants.err_m_0039, "Bit Auto Reset"), 
                        fLog
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fBitResult = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMessageLinkMapRead(
            FMelseceLinkMapMessageReadData fLinkMapData
            )
        {
            FMelseceWordResult fResult = null;
            FPlcDeviceDataMessageReadLog fLog = null;
            FXmlNode fXmlNodePmgl = null;
            FXmlNodeList fXmlNodeListBit1 = null;
            FXmlNodeList fXmlNodeListBit2 = null;
            FXmlNode[] fXmlNodePtrList = null;
            bool isDefMessage = false;
            FXmlNode fXmlNodeReplyPmg = null;
            FPlcMessage fReplyPmg = null;
            FPlcMessageTransfer fPmt = null;            

            try
            {
                // ***
                // Message Bit 영역 Read
                // ***
                foreach (FMelseceWordReadData[] fBitDatas in fLinkMapData.fBitReadList)
                {
                    fResult = readRandomWord(fBitDatas, fLinkMapData.timeout);
                    if (!fResult.result)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageReadEvent(
                            this.fPlcDevice,
                            FResultCode.Error,
                            fResult.message,
                            this.fEventPusher.createPlcDeviceDataMessageReadLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fLinkMapData.fXmlNodePmgl)
                            );
                        return;
                    }
                    // --
                    fLinkMapData.fBitResultList.Add(fResult);
                }

                // --

                // ***
                // Message Word 영역 Read
                // ***
                foreach (FMelseceWordReadData[] fWordDatas in fLinkMapData.fWordReadList)
                {
                    fResult = readRandomWord(fWordDatas, fLinkMapData.timeout);
                    if (!fResult.result)
                    {
                        this.fEventPusher.pushPlcDeviceDataMessageReadEvent(
                            this.fPlcDevice,
                            FResultCode.Error,
                            fResult.message,
                            this.fEventPusher.createPlcDeviceDataMessageReadLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fLinkMapData.fXmlNodePmgl)
                            );
                        return;
                    }
                    // --
                    fLinkMapData.fWordResultList.Add(fResult);
                }

                // --

                // ***
                // Read Message Parse
                // ***
                fXmlNodePmgl = FMelsece2.parseMessageBinToPmg(
                    this.fPlcDevice,
                    fLinkMapData.fSession,
                    fLinkMapData.fXmlNodePmgl,
                    fLinkMapData.getReadBits(),
                    fLinkMapData.getReadWords()
                    );
                // --
                fLog = this.fEventPusher.createPlcDeviceDataMessageReadLog(fLinkMapData.fSession.fPlcSession.fXmlNode, fXmlNodePmgl);
                
                // --

                if (this.fPcdCore.fConfig.enabledEventsOfPlcDeviceDataMessage)
                {
                    this.fEventPusher.pushPlcDeviceDataMessageReadEvent(
                        this.fPlcDevice,
                        FResultCode.Success,
                        string.Empty,
                        fLog
                        );
                }

                // --

                // ***
                // Auto Reply와 Trigger를 발생시키기 위해 Read된 PLC Message의 Bit가 정의된 PLC Message의 Read Message와 동일한지 검색
                // ***
                isDefMessage = true;
                fXmlNodeListBit1 = fLinkMapData.fXmlNodePmgl.selectNodes(FXmlTagPBLL.E_PlcBitList + "/" + FXmlTagPBTL.E_PlcBit);
                fXmlNodeListBit2 = fXmlNodePmgl.selectNodes(FXmlTagPBLL.E_PlcBitList + "/" + FXmlTagPBTL.E_PlcBit);
                for (int i = 0; i < fXmlNodeListBit1.count; i++)
                {
                    if (fXmlNodeListBit1[i].get_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value) != fXmlNodeListBit2[i].get_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value))
                    {
                        isDefMessage = false;
                        break;
                    }
                }

                if (isDefMessage)
                {
                    if (fLog.isPrimary)
                    {
                        fXmlNodeReplyPmg = FMelsece2.getReplyMessage(
                            this.fPlcDriver,
                            fLinkMapData.fSession.fPlcSession,
                            fLog.uniqueIdToString
                            );
                        // --
                        if (fXmlNodeReplyPmg != null)
                        {
                            fReplyPmg = new FPlcMessage(this.fPcdCore, fXmlNodeReplyPmg);
                            // --
                            if (fReplyPmg.autoReply)
                            {
                                // ***
                                // Auto Reply Message Random Value 설정
                                // ***
                                fPmt = fReplyPmg.createTransfer();
                                FPlcDriverCommon.setPlcWordRandomValue(fPmt.fXmlNode);

                                // --

                                requestMessageLinkMapWrite(fLinkMapData.fSession.fPlcSession, fPmt);
                            }
                        }
                    }

                    // --

                    // ***
                    // PLC Trigger Parsing
                    // ***
                    if (this.fPcdCore.fPlcDriver.enabledEventsOfScenario)
                    {
                        fXmlNodePtrList = FMelsece2.parseExpressionTrigger(this.fPlcDriver, fXmlNodePmgl);
                        foreach (FXmlNode fXmlNodePtr in fXmlNodePtrList)
                        {
                            this.fEventPusher.pushPlcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodePtr, fLog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fResult = null;
                fXmlNodePmgl = null;
                fXmlNodeListBit1 = null;
                fXmlNodeListBit2 = null;
                fXmlNodeReplyPmg = null;
                fReplyPmg = null;
                fPmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procLinkMapData(
            )
        {
            try
            {
                foreach (FMelseceLinkMapData fLinkMapData in m_fReqLinkMapQueue.dequeueAll())
                {
                    if (fLinkMapData.fType == FMelseceLinkMapDataType.SessionRead)
                    {
                        procSessionLinkMapRead((FMelseceLinkMapSessionReadData)fLinkMapData);
                    }
                    else if (fLinkMapData.fType == FMelseceLinkMapDataType.MessageWrite)
                    {
                        procMessageLinkMapWrite((FMelseceLinkMapMessageWriteData)fLinkMapData);
                    }
                    else if (fLinkMapData.fType == FMelseceLinkMapDataType.MessageRead)
                    {
                        procMessageLinkMapRead((FMelseceLinkMapMessageReadData)fLinkMapData);
                    }
                    else if (fLinkMapData.fType == FMelseceLinkMapDataType.AutoReset)
                    {
                        procMessageLinkMapAutoReset((FMelseceLinkMapAutoResetData)fLinkMapData);
                    }
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

        private void requestSessionLinkMapRead(
            FMelseceSession fMsn
            )
        {
            FMelseceLinkMapSessionReadData fLinkMapData = null;
            FMelseceBitReadData fBitReadData = null;
            FMelseceWordReadData fWordReadData = null;
            int bitPerWord = 0;
            int calcLen = 0;
            int readCnt = 0;
            int remLen = 0;
            int remBitLen = 0;
            byte deviceCode = 0;
            UInt32 startAddress = 0;            

            try
            {
                fLinkMapData = new FMelseceLinkMapSessionReadData(
                    fMsn,
                    fMsn.fPlcSession.readBitDeviceCode,
                    fMsn.fPlcSession.readBitStartAddr,
                    fMsn.fPlcSession.readWordDeviceCode,
                    fMsn.fPlcSession.readWordStartAddr
                    );

                // --

                // ***
                // Read Bit 영역 전체 Scan Data 생성
                // ***
                remBitLen = fMsn.fPlcSession.readBitLength % 16;                
                calcLen = (fMsn.fPlcSession.readBitLength - remBitLen) / 16;    // Bit 길이를 Word 길이로 변경            
                readCnt = (calcLen / 960) + (calcLen % 960 > 0 ? 1 : 0);        // Request Count
                // --
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(fMsn.fPlcSession.readBitDeviceCode);
                startAddress = fMsn.fPlcSession.readBitStartAddr;                
                bitPerWord = 960 * 16;
                for (int i = 0; i < readCnt; i++)
                {
                    fWordReadData = new FMelseceWordReadData();
                    
                    // --

                    fWordReadData.deviceCode = deviceCode;
                    fWordReadData.address = startAddress;
                    // --
                    if (i < readCnt - 1)
                    {
                        fWordReadData.length = 960;                        
                        startAddress += (UInt32)bitPerWord;
                    }
                    else
                    {
                        remLen = calcLen % 960;
                        if (remLen == 0)
                        {
                            fWordReadData.length = 960;
                            startAddress += (UInt32)bitPerWord;
                        }
                        else
                        {
                            fWordReadData.length = (UInt16)remLen;
                            startAddress += (UInt32)(remLen * 16);
                        }                        
                    }
                    // --
                    fWordReadData.timeout = this.t2Timeout;

                    // --

                    fLinkMapData.fBitReadList.Add(fWordReadData);
                }

                // --

                if (remBitLen > 0)
                {
                    fBitReadData = new FMelseceBitReadData();
                    // --
                    fBitReadData.deviceCode = deviceCode;
                    fBitReadData.address = startAddress;
                    fBitReadData.length = (UInt16)remBitLen;
                    // --
                    fBitReadData.timeout = this.t2Timeout;
                    
                    // --

                    fLinkMapData.fBitReadList.Add(fBitReadData);
                }

                // --

                // ***
                // Read Word 영역 전체 Scan Data 생성
                // ***
                readCnt = (fMsn.fPlcSession.readWordLength / 960) + (fMsn.fPlcSession.readWordLength % 960 > 0 ? 1 : 0); // Request Count
                // --
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(fMsn.fPlcSession.readWordDeviceCode);
                startAddress = fMsn.fPlcSession.readWordStartAddr;
                // --
                for (int i = 0; i < readCnt; i++)
                {
                    fWordReadData = new FMelseceWordReadData();

                    // --

                    fWordReadData.deviceCode = deviceCode;
                    fWordReadData.address = startAddress;
                    startAddress += 960;
                    // --
                    if (i < readCnt - 1)
                    {
                        fWordReadData.length = 960;
                    }
                    else
                    {
                        remLen = fMsn.fPlcSession.readWordLength % 960;
                        if (remLen == 0)
                        {
                            fWordReadData.length = 960;
                        }
                        else
                        {
                            fWordReadData.length = (UInt16)remLen;
                        }
                    }
                    // --
                    fWordReadData.timeout = this.t2Timeout;

                    // --

                    fLinkMapData.fWordReadList.Add(fWordReadData);
                }

                // --

                fMsn.isReadCompleted = false;
                m_fReqLinkMapQueue.enqueue(fLinkMapData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLinkMapData = null;
                fBitReadData = null;
                fWordReadData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void requestMessageLinkMapWrite(
            FPlcSession fPsn,
            FPlcMessageTransfer fPmt
            )
        {
            FMelseceSession fMsn = null;
            FMelseceLinkMapMessageWriteData fLinkMapData = null;
            FMelseceRandomParam fParam = null;            
            List<FMelseceBitWriteData> fBitDatas = null;
            FMelseceBitWriteData fBitData = null;
            List<FMelseceWordWriteData> fWordDatas = null;
            FMelseceWordWriteData fWordData = null;
            FXmlNode fXmlNodePmgl = null;
            string bitDeviceCode = string.Empty;
            UInt32 bitStartAddress = 0;
            string wordDeviceCode = string.Empty;
            UInt32 wordStartAddress = 0;
            byte deviceCode = 0;
            UInt32 startAddress = 0;            

            try
            {
                if (
                    !m_fSessionList.ContainsKey(fPsn.uniqueIdToString) ||
                    !m_fSessionList[fPsn.uniqueIdToString].fPlcSession.Equals(fPsn)
                    )
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Session"));
                }
                
                // --

                fMsn = m_fSessionList[fPsn.uniqueIdToString];
                // --
                if (fPmt.fPlcMessageTransferAreaType == FPlcMessageTransferAreaType.Read)
                {
                    bitDeviceCode = fMsn.fPlcSession.readBitDeviceCode;
                    bitStartAddress = fMsn.fPlcSession.readBitStartAddr;
                    wordDeviceCode = fMsn.fPlcSession.readWordDeviceCode;
                    wordStartAddress = fMsn.fPlcSession.readWordStartAddr;
                }
                else
                {
                    bitDeviceCode = fMsn.fPlcSession.writeBitDeviceCode;
                    bitStartAddress = fMsn.fPlcSession.writeBitStartAddr;
                    wordDeviceCode = fMsn.fPlcSession.writeWordDeviceCode;
                    wordStartAddress = fMsn.fPlcSession.writeWordStartAddr;
                }
                
                // --
                
                fParam = new FMelseceRandomParam();
                fXmlNodePmgl = FMelsece2.parseWritePmgToBin(
                    this.fPlcDevice, 
                    fMsn,
                    fPmt.fXmlNode,
                    bitDeviceCode, 
                    bitStartAddress,
                    wordDeviceCode,
                    wordStartAddress,
                    fParam
                    );
                // --
                fLinkMapData = new FMelseceLinkMapMessageWriteData(fMsn, fPmt.fPlcMessageTransferAreaType, fXmlNodePmgl, this.t2Timeout);

                // --

                // ***
                // Bit Write 데이터 생성
                //  - 한 트랜잭션으로 처리할 수 있는 Bit 점수 188 (Random Bit Write)
                // ***  
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(bitDeviceCode);
                startAddress = bitStartAddress;
                fBitDatas = new List<FMelseceBitWriteData>();
                // --
                for (int i = 0; i < fParam.bitAddresses.Count; i++)
                {
                    if (i % 188 == 0)
                    {
                        if (fBitDatas.Count > 0)
                        {
                            fLinkMapData.fBitWriteList.Add(fBitDatas.ToArray());
                        }
                        fBitDatas.Clear();
                    }
                    
                    // --

                    fBitData = new FMelseceBitWriteData();
                    // --
                    fBitData.deviceCode = deviceCode;
                    fBitData.address = fParam.bitAddresses[i] + startAddress;
                    fBitData.bits = new byte[1] { fParam.bits[i] };
                    // --
                    fBitDatas.Add(fBitData);
                }
                // --
                if (fBitDatas.Count > 0)
                {
                    fLinkMapData.fBitWriteList.Add(fBitDatas.ToArray()); // 짜투리
                }

                // --

                // ***
                // Word Write 데이터 생성
                //  - 한 트랜잭션으로 처리할 수 있는 Word 점수는 165 (Random Word Write)
                // ***
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(wordDeviceCode);
                startAddress = wordStartAddress;
                fWordDatas = new List<FMelseceWordWriteData>();
                // --
                for (int i = 0; i < fParam.wordAddresses.Count; i++)
                {
                    if (i % 165 == 0)
                    {
                        if (fWordDatas.Count > 0)
                        {
                            fLinkMapData.fWordWriteList.Add(fWordDatas.ToArray());
                        }
                        fWordDatas.Clear();
                    }

                    // --

                    fWordData = new FMelseceWordWriteData();
                    // --
                    fWordData.deviceCode = deviceCode;
                    fWordData.address = fParam.wordAddresses[i] + startAddress;
                    fWordData.bytes = fParam.words[i];
                    // --
                    fWordDatas.Add(fWordData);
                }
                // --
                if (fWordDatas.Count > 0)
                {
                    fLinkMapData.fWordWriteList.Add(fWordDatas.ToArray()); // 짜투리
                }
                
                // --

                m_fReqLinkMapQueue.enqueue(fLinkMapData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMsn = null;
                fLinkMapData = null;
                fParam = null;
                fBitData = null;
                fWordData = null;
                fXmlNodePmgl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void requestMessageLinkMapAutoReset(
            FMelseceAutoReset fAutoReset
            )
        {
            FXmlNode fXmlNodePbl = null;
            FXmlNode fXmlNodePmgl = null;
            FMelseceLinkMapAutoResetData fLinkMapData = null;
            FMelseceRandomParam fParam = null;
            List<FMelseceBitWriteData> fBitDatas = null;
            FMelseceBitWriteData fBitData = null;
            byte deviceCode = 0;
            UInt32 startAddress = 0;            

            try
            {
                // ***
                // Auto Reset에 의한 Message 생성
                // ***
                fXmlNodePbl = fAutoReset.fXmlNodePmg.appendChild(FPlcDriverCommon.createXmlNodePBL(this.fPcdCore.fXmlDoc));
                fXmlNodePbl.appendChild(fAutoReset.fXmlNodePbt);
                
                // --

                fParam = new FMelseceRandomParam();
                fXmlNodePmgl = FMelsece2.parseWritePmgToBin(
                    this.fPlcDevice,
                    fAutoReset.fSession,
                    fAutoReset.fXmlNodePmg,
                    fAutoReset.bitDeviceCode,
                    fAutoReset.bitStartAddress,
                    fAutoReset.wordDeviceCode,
                    fAutoReset.wordStartAddress,
                    fParam
                    );
                // --
                fLinkMapData = new FMelseceLinkMapAutoResetData(fAutoReset.fSession, fXmlNodePmgl, this.t2Timeout);
                
                // --

                // ***
                // Bit Write 데이터 생성
                //  - 한 트랜잭션으로 처리할 수 있는 Bit 점수 188 (Random Bit Write)
                // ***  
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(fAutoReset.bitDeviceCode);
                startAddress = fAutoReset.bitStartAddress;
                fBitDatas = new List<FMelseceBitWriteData>();
                // --
                for (int i = 0; i < fParam.bitAddresses.Count; i++)
                {
                    if (i % 188 == 0)
                    {
                        if (fBitDatas.Count > 0)
                        {
                            fLinkMapData.fBitWriteList.Add(fBitDatas.ToArray());
                        }
                        fBitDatas.Clear();
                    }

                    // --

                    fBitData = new FMelseceBitWriteData();
                    // --
                    fBitData.deviceCode = deviceCode;
                    fBitData.address = fParam.bitAddresses[i] + startAddress;
                    fBitData.bits = new byte[1] { fParam.bits[i] };
                    // --
                    fBitDatas.Add(fBitData);
                }
                // --
                if (fBitDatas.Count > 0)
                {
                    fLinkMapData.fBitWriteList.Add(fBitDatas.ToArray()); // 짜투리
                }

                // --

                m_fReqLinkMapQueue.enqueue(fLinkMapData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodePbl = null;
                fXmlNodePmgl = null;
                fParam = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void requestMessageLinkMapRead(
            FPlcSession fPsn,
            FPlcMessageTransfer fPmt
            )
        {
            FMelseceSession fMsn = null;
            FMelseceLinkMapMessageReadData fLinkMapData = null;
            FMelseceRandomParam fParam = null;
            List<FMelseceWordReadData> fBitDatas = null;
            FMelseceWordReadData fBitData = null;
            List<FMelseceWordReadData> fWordDatas = null;
            FMelseceWordReadData fWordData = null;
            FXmlNode fXmlNodePmgl = null;
            string bitDeviceCode = string.Empty;
            UInt32 bitStartAddress = 0;
            string wordDeviceCode = string.Empty;
            UInt32 wordStartAddress = 0;
            byte deviceCode = 0;
            UInt32 startAddress = 0;            

            try
            {
                if (
                    !m_fSessionList.ContainsKey(fPsn.uniqueIdToString) ||
                    !m_fSessionList[fPsn.uniqueIdToString].fPlcSession.Equals(fPsn)
                    )
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "Session"));
                }

                // --

                fMsn = m_fSessionList[fPsn.uniqueIdToString];
                // --
                if (fPmt.fPlcMessageTransferAreaType == FPlcMessageTransferAreaType.Read)
                {
                    bitDeviceCode = fMsn.fPlcSession.readBitDeviceCode;
                    bitStartAddress = fMsn.fPlcSession.readBitStartAddr;
                    wordDeviceCode = fMsn.fPlcSession.readWordDeviceCode;
                    wordStartAddress = fMsn.fPlcSession.readWordStartAddr;
                }
                else
                {
                    bitDeviceCode = fMsn.fPlcSession.writeBitDeviceCode;
                    bitStartAddress = fMsn.fPlcSession.writeBitStartAddr;
                    wordDeviceCode = fMsn.fPlcSession.writeWordDeviceCode;
                    wordStartAddress = fMsn.fPlcSession.writeWordStartAddr;
                }

                // --

                fParam = new FMelseceRandomParam();
                fXmlNodePmgl = FMelsece2.parseReadPmgToBin(
                    this.fPlcDevice,
                    fMsn,
                    fPmt.fXmlNode,
                    bitDeviceCode,
                    bitStartAddress,
                    wordDeviceCode,
                    wordStartAddress,
                    fParam
                    );
                // --
                fLinkMapData = new FMelseceLinkMapMessageReadData(fMsn, fXmlNodePmgl, this.t2Timeout);

                // --

                // ***
                // Bit Read 데이터 생성
                //  - 한 트랜잭션으로 처리할 수 있는 Word 점수는 192 (Random Word Read)
                // ***
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(bitDeviceCode);
                startAddress = bitStartAddress;
                fBitDatas = new List<FMelseceWordReadData>();
                // --
                for (int i = 0; i < fParam.bitAddresses.Count; i++)
                {
                    if (i % 192 == 0)
                    {
                        if (fBitDatas.Count > 0)
                        {
                            fLinkMapData.fBitReadList.Add(fBitDatas.ToArray());
                        }
                        fBitDatas.Clear();
                    }

                    // --

                    fBitData = new FMelseceWordReadData();
                    // --
                    fBitData.deviceCode = deviceCode;
                    fBitData.address = fParam.bitAddresses[i] + startAddress;
                    // --
                    fBitDatas.Add(fBitData);
                }
                // --
                if (fBitDatas.Count > 0)
                {
                    fLinkMapData.fBitReadList.Add(fBitDatas.ToArray()); // 짜투리
                }

                // --

                // ***
                // Word Read 데이터 생성
                //  - 한 트랜잭션으로 처리할 수 있는 Word 점수는 192 (Random Word Read)
                // ***
                deviceCode = FPlcValueConverter.toMelseceDeviceCode(wordDeviceCode);
                startAddress = wordStartAddress;
                fWordDatas = new List<FMelseceWordReadData>();
                // --
                for (int i = 0; i < fParam.wordAddresses.Count; i++)
                {
                    if (i % 192 == 0)
                    {
                        if (fWordDatas.Count > 0)
                        {
                            fLinkMapData.fWordReadList.Add(fWordDatas.ToArray());
                        }
                        fWordDatas.Clear();
                    }

                    // --

                    fWordData = new FMelseceWordReadData();
                    // --
                    fWordData.deviceCode = deviceCode;
                    fWordData.address = fParam.wordAddresses[i] + startAddress;
                    // --
                    fWordDatas.Add(fWordData);
                }
                // --
                if (fWordDatas.Count > 0)
                {
                    fLinkMapData.fWordReadList.Add(fWordDatas.ToArray()); // 짜투리
                }

                // --

                m_fReqLinkMapQueue.enqueue(fLinkMapData);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMsn = null;
                fLinkMapData = null;
                fParam = null;
                fBitData = null;
                fWordData = null;
                fXmlNodePmgl = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Command Methods

        private FMelseceBitResult writeBatchBit(
            FMelseceBitWriteData fData
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            int bitSpace = 0;
            UInt16 plcTimeout = 0;
            FMelseceBitResult fResult = null;
            FStaticTimer fTimer = null;

            try
            {
                bitSpace = (fData.length / 2) + (fData.length % 2);
                plcTimeout = (UInt16)(fData.timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(01 14) + 서브커맨드(01 00) +
                // 선두디바이스(3Byte) + 디바이스코드(1Byte) + 디바이스점수(2Byte) + 디바이스점수분의데이터((n)Byte)
                // ***
                cursor = 0;
                cmdData = new Byte[21 + bitSpace];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)(12 + bitSpace)), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x01; // Command
                cmdData[cursor++] = 0x14;
                // --
                cmdData[cursor++] = 0x01; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.address), 0, cmdData, cursor, 3); // Address
                cursor += 3;
                // --
                cmdData[cursor++] = fData.deviceCode; // Device Code
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.length), 0, cmdData, cursor, 2); // Bit Access Length
                cursor += 2;

                // --

                for (int i = 0; i < fData.length; i++)
                {
                    if (i % 2 == 0)
                    {
                        cmdData[cursor] = (byte)(fData.bits[i] << 4);
                    }
                    else
                    {
                        cmdData[cursor] = (byte)(cmdData[cursor] + fData.bits[i]);
                        cursor++;
                    }
                }

                // --

                fResult = new FMelseceBitResult();
                fTimer = new FStaticTimer();
                fTimer.start(fData.timeout);
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(fData.timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Batch Bit Write");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);
                
                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Batch Bit", "write") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
                // --
                if (fTimer != null)
                {
                    fTimer.Dispose();
                    fTimer = null;
                }                
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceBitResult readBatchBit(
            FMelseceBitReadData fData
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceBitResult fResult = null;

            try
            {                
                plcTimeout = (UInt16)(fData.timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(01 04) + 서브커맨드(01 00) +
                // 선두디바이스(3Byte) + 디바이스코드(1Byte) + 디바이스점수(2Byte)
                // ***
                cursor = 0;
                cmdData = new byte[21];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)12), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x01; // Command
                cmdData[cursor++] = 0x04;
                // --
                cmdData[cursor++] = 0x01; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.address), 0, cmdData, cursor, 3); // Address
                cursor += 3;
                // --
                cmdData[cursor++] = fData.deviceCode; // Device Code
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.length), 0, cmdData, cursor, 2); // Length
                cursor += 2;

                // --

                fResult = new FMelseceBitResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                // --
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(fData.timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Batch Bit Read");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Batch Bit", "read") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                cursor = 11;
                fResult.bits = new byte[fData.length];
                // --
                for (int i = 0; i < fResult.bits.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        fResult.bits[i] = (byte)(repData[cursor] >> 4);
                    }
                    else
                    {
                        fResult.bits[i] = (byte)(repData[cursor] & 0x0F);
                        cursor++;
                    }
                }

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceBitResult writeRandomBit(
            FMelseceBitWriteData[] fDatas,
            int timeout
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceBitResult fResult = null;

            try
            {
                plcTimeout = (UInt16)(timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(02 14) + 서브커맨드(01 00) + 비트액세스점수(1Byte) +
                // (선두디바이스(3Byte) + 디바이스코드(1Byte) + 비트 셋/리셋(1Byte)) * n
                // ***
                cursor = 0;
                cmdData = new Byte[16 + (fDatas.Length * 5)];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)(7 + (fDatas.Length * 5))), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x02; // Command
                cmdData[cursor++] = 0x14;
                // --
                cmdData[cursor++] = 0x01; // Sub Command
                cmdData[cursor++] = 0x00;
                // --                
                cmdData[cursor++] = (byte)fDatas.Length; // Bit Access Length
                // --
                for (int i = 0; i < fDatas.Length; i++)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes(fDatas[i].address), 0, cmdData, cursor, 3); // Address
                    cursor += 3;
                    // --
                    cmdData[cursor++] = fDatas[i].deviceCode; // Device Code
                    // --
                    cmdData[cursor++] = fDatas[i].bits[0];    // Bit Set/Reset                    
                }

                // --

                fResult = new FMelseceBitResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                // --
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Random Bit Write");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Random Bit", "write") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceWordResult writeBatchWord(
            FMelseceWordWriteData fData
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceWordResult fResult = null;

            try
            {
                plcTimeout = (UInt16)(fData.timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(01 14) + 서브커맨드(00 00) +
                // 선두디바이스(3Byte) + 디바이스코드(1Byte) + 디바이스점수(2Byte) + 디바이스점수분의데이터((n)Byte)
                // ***
                cursor = 0;
                cmdData = new Byte[21 + (fData.length * 2)];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)(12 + (fData.length * 2))), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x01; // Command
                cmdData[cursor++] = 0x14;
                // --
                cmdData[cursor++] = 0x00; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.address), 0, cmdData, cursor, 3); // Address
                cursor += 3;
                // --
                cmdData[cursor++] = fData.deviceCode; // Device Code
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.length), 0, cmdData, cursor, 2); // Bit Access Length
                cursor += 2;
                // --
                Buffer.BlockCopy(fData.bytes, 0, cmdData, cursor, fData.bytes.Length);

                // --

                fResult = new FMelseceWordResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(fData.timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Batch Word Write");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --
                
                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Batch Word", "write") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceWordResult readBatchWord(
            FMelseceWordReadData fData
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceWordResult fResult = null;

            try
            {
                plcTimeout = (UInt16)(fData.timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(01 04) + 서브커맨드(00 00) +
                // 선두디바이스(3Byte) + 디바이스코드(1Byte) + 디바이스점수(2Byte)
                // ***
                cursor = 0;
                cmdData = new Byte[21];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)12), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x01; // Command
                cmdData[cursor++] = 0x04;
                // --
                cmdData[cursor++] = 0x00; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.address), 0, cmdData, cursor, 3); // Address
                cursor += 3;
                // --
                cmdData[cursor++] = fData.deviceCode; // Device Code
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(fData.length), 0, cmdData, cursor, 2); // Bit Access Length
                cursor += 2;

                // --

                fResult = new FMelseceWordResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                // --
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(fData.timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Batch Word Read");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // -

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Batch Word", "read") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.bytes = new byte[fData.length * 2];
                Buffer.BlockCopy(repData, 11, fResult.bytes, 0, fResult.bytes.Length);

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceWordResult writeRandomWord(
            FMelseceWordWriteData[] fDatas,
            int timeout
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceWordResult fResult = null;

            try
            {
                plcTimeout = (UInt16)(timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(02 14) + 서브커맨드(00 00) + 워드액세스점수(1Byte) + 더블워드액세스점수(1Byte) + 
                // (선두디바이스(3Byte) + 디바이스코드(1Byte) + 쓰기데이터(2Byte)) * n
                // ***
                cursor = 0;
                cmdData = new Byte[17 + (fDatas.Length * 6)];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)(8 + (fDatas.Length * 6))), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x02; // Command
                cmdData[cursor++] = 0x14;
                // --
                cmdData[cursor++] = 0x00; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = (byte)fDatas.Length; // Word Access Length
                // --
                cmdData[cursor++] = 0; // Double Word Access Length
                // --
                for (int i = 0; i < fDatas.Length; i++)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes(fDatas[i].address), 0, cmdData, cursor, 3); // Address
                    cursor += 3;
                    // --
                    cmdData[cursor++] = fDatas[i].deviceCode; // Device Code
                    // --
                    Buffer.BlockCopy(fDatas[i].bytes, 0, cmdData, cursor, 2);
                    cursor += 2;
                }

                // --

                fResult = new FMelseceWordResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                // --
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Random Word Write");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Random Word", "write") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FMelseceWordResult readRandomWord(
            FMelseceWordReadData[] fDatas,
            int timeout
            )
        {
            int cursor = 0;
            byte[] cmdData = null;
            byte[] repData = null;
            UInt16 plcTimeout = 0;
            FMelseceWordResult fResult = null;

            try
            {
                plcTimeout = (UInt16)(timeout / 250);

                // --

                // ***
                // Command Data Create
                // --
                // 서브헤더(50 00) + 네트워크번호(00) + PLC No.(FF) + 요구상대모듈 I/O 번호(FF 03) + 요구상대모듈국번호(00) + 요구데이터길이(2Byte) +
                // CPU감시타이머(2Byte) + 커맨드(03 04) + 서브커맨드(00 00) + 워드액세스점수(1Byte) + 더블워드액세스점수(1Byte) + 
                // (선두디바이스(3Byte) + 디바이스코드(1Byte)) * n
                // ***
                cursor = 0;
                cmdData = new Byte[17 + (fDatas.Length * 4)];
                // --
                cmdData[cursor++] = 0x50; // Sub Header
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = 0x00; // Nework No.
                // --
                cmdData[cursor++] = 0xFF; // PLC No.
                // --
                cmdData[cursor++] = 0xFF; // Module I/O No.
                cmdData[cursor++] = 0x03;
                // --
                cmdData[cursor++] = 0x00; // Module No.
                // --
                Buffer.BlockCopy(BitConverter.GetBytes((UInt16)(8 + (fDatas.Length * 4))), 0, cmdData, cursor, 2); // Length
                cursor += 2;
                // --
                Buffer.BlockCopy(BitConverter.GetBytes(plcTimeout), 0, cmdData, cursor, 2); // Timeout 
                cursor += 2;
                // --
                cmdData[cursor++] = 0x03; // Command
                cmdData[cursor++] = 0x04;
                // --
                cmdData[cursor++] = 0x00; // Sub Command
                cmdData[cursor++] = 0x00;
                // --
                cmdData[cursor++] = (byte)fDatas.Length; // Word Access Length
                // --
                cmdData[cursor++] = 0; // Double Word Access Length
                // --
                for (int i = 0; i < fDatas.Length; i++)
                {
                    Buffer.BlockCopy(BitConverter.GetBytes(fDatas[i].address), 0, cmdData, cursor, 3); // Address
                    cursor += 3;
                    // --
                    cmdData[cursor++] = fDatas[i].deviceCode; // Device Code                    
                }

                // --

                fResult = new FMelseceWordResult();
                // --
                m_fRecvBuffer.enabled = true;
                m_fRecvBuffer.reset();
                // --
                m_fTcpClient.send((new FSocketSendData(cmdData)));
                // --
                if (!m_fRecvBuffer.wait(timeout))
                {
                    m_fRecvBuffer.set();
                    // --
                    fResult.result = false;
                    fResult.isTimeout = true;
                    fResult.message = string.Format(FConstants.err_m_0037, "PLC Random Word Read");
                    // --
                    return fResult;
                }
                // --
                if (!m_fRecvBuffer.result)
                {
                    fResult.result = false;
                    fResult.message = m_fRecvBuffer.message;
                    // --
                    return fResult;
                }

                // --

                repData = m_fRecvBuffer.getBytes();
                fResult.exitCode = BitConverter.ToUInt16(repData, 9);

                // --

                if (fResult.exitCode != 0)
                {
                    fResult.result = false;
                    fResult.message =
                        string.Format(FConstants.err_m_0038, "PLC Random Word", "read") +
                        "[0x" + fResult.exitCode.ToString("X4") + "]";
                    // --
                    return fResult;
                }

                // --

                fResult.bytes = new byte[fDatas.Length * 2];
                Buffer.BlockCopy(repData, 11, fResult.bytes, 0, fResult.bytes.Length);

                // --

                fResult.result = true;
                return fResult;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fRecvBuffer.clear();
            }
            return null;
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

                procDataSent(e.data);
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

                procDataSendFailed(e.message);
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
            bool isSleep = false;
            FMelseceAutoReset[] fAutoResets = null;

            try
            {
                waited = m_fMainSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if (m_fTcpClient == null || this.fDeviceState != FDeviceState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                if (!m_autoClearCompleted || !m_selectedActionCompleted || m_closing)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                isSleep = true;
                                
                // --

                // ***
                // Session Read Area Request
                // ***
                foreach (FMelseceSession fMsn in m_fSessionList.Values)
                {
                    if (!fMsn.fPlcSession.hasLibrary || !fMsn.fPlcSession.scanEnabled || !fMsn.isReadCompleted)
                    {
                        continue;
                    }

                    // --

                    if (!fMsn.fReadTimer.enabled)
                    {
                        fMsn.fReadTimer.start(fMsn.fPlcSession.scanTime);
                    }
                    else if (!fMsn.fReadTimer.elasped(true))
                    {
                        continue;
                    }

                    isSleep = false;
                    requestSessionLinkMapRead(fMsn);                    
                }

                // --

                // ***
                // Auto Reset 처리 
                // ***
                fAutoResets = m_fAutoResetList.getTimeoutData();
                if (fAutoResets.Length > 0)
                {
                    isSleep = false;
                    // --
                    foreach (FMelseceAutoReset fAutoReset in fAutoResets)
                    {
                        requestMessageLinkMapAutoReset(fAutoReset);
                    }
                }

                // --

                // ***
                // Auto Cycle Transmitter 처리
                // ***
                if (fPcdCore.fConfig.enabledEventsOfScenario)
                {
                    if (m_fTmrAutoCycle.elasped(true))
                    {
                        isSleep = false;
                        // --
                        this.fProtocolAgent.runPlcAutoCycleTransmitter(this.fPlcDevice);
                    }
                }

                // --

                // ***
                // Auto Trace Message 처리
                // ***
                if (m_fTmrAutoTrace.elasped(true))
                {
                    isSleep = false;
                    // --
                    this.fProtocolAgent.runPlcAutoTraceMessage(this.fPlcDevice);
                }
                
                // --

                if (isSleep)
                {
                    e.sleepThread(1);
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fAutoResets = null;

                if (waited)
                {
                    m_fMainSync.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMelseceReq Object Event Handler

        private void m_fThdMelseceReq_ThreadJobCalled(
           object sender,
           FThreadEventArgs e
           )
        {
            bool waited = false;

            try
            {
                waited = m_fMelseceReqSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if (m_fTcpClient == null || this.fDeviceState != FDeviceState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // Link Map Auto Clear
                // ***
                if (!m_autoClearCompleted)
                {
                    procSessionLinkMapAutoClear();
                    m_autoClearCompleted = true;
                }
               
                // --

                // ***
                // Selected Auto Action 
                // ***
                if (!m_selectedActionCompleted)
                {
                    if (fPcdCore.fConfig.enabledEventsOfScenario)
                    {
                        // ***
                        // Auto Action First Select Transmitter 처리
                        // ***
                        this.fProtocolAgent.runPlcAutoActionFirstSelectTransmitter(this.fPlcDevice);

                        // ***
                        // Auto Action Always Select Transmitter 처리
                        // ***
                        this.fProtocolAgent.runPlcAutoActionAlwaysSelectTransmitter(this.fPlcDevice);
                    }
                    
                    // --

                    // ***
                    // Auto Cycle Run Time 실행
                    // ***
                    m_fTmrAutoCycle.start(AutoCycleRunTime);

                    // --

                    // ***
                    // Auto Trace Run Time 실행
                    // ***
                    m_fTmrAutoTrace.start(AutoTraceRunTime);

                    // --

                    m_selectedActionCompleted = true;
                }

                // --

                if (m_fReqLinkMapQueue.count == 0)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                procLinkMapData();
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (waited)
                {
                    m_fMelseceReqSync.set();
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
