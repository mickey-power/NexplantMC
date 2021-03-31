/*---------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSECS1.cs
--  Creator         : byjeon
--  Create Date     : 2011.11.03
--  Description     : FAMate Core FaSecsDriver SECS-1 Class 
--  History         : Created by byjeon at 2011.11.03
                    : Modified by byjeon at 2013.03.06
                        - Tuning Code of the SendCompleted event handler 
                    : Modified by byjeon at 2013.04.25
                        - Tuning Code of the class
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSECS1 : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string KeyFormat1 = "{0}-{1}-{2}";        // SessionID + Stream + Function (Ignore System Bytes 용)
        private const string KeyFormat2 = "{0}-{1}-{2}-{3}";    // SessionID + Stream + Function + SystemBytes
        // --
        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단
        
        // --
        
        private bool m_disposed = false;
        // --        
        private FSecs1Protocol m_fSecs1Protocol = null;
        private FIDPointer32 m_fSystemBytesPointer = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        // --
        private bool m_rbit = false;
        private bool m_duplicateError = false;
        private bool m_interleave = false;
        private bool m_ignoreSystemBytes = false;
        private int m_retryLimit = 0;
        // --
        private int m_t1Timeout = 0;
        private int m_t2Timeout = 0;
        private int m_t3Timeout = 0;
        private int m_t4Timeout = 0;
        // --        
        private FSerial m_fSerial = null;
        private FSecs1RecvBuffer m_fRecvBuf = null;
        private FSecs1StatusType m_fStatusType = FSecs1StatusType.Idle;
        private FStaticTimer m_fTmrT1 = null;
        private FStaticTimer m_fTmrT2 = null;
        private FSecsOpenTransaction m_fTranDataMessage = null;
        // --
        private bool m_isMessagingBlock = false;
        private List<string> m_recvMessageList = null;
        private List<string> m_sendMessageList = null;
        private Dictionary<string, FRecvBlockManager> m_recvMessageDictionary = null;
        private Dictionary<string, FSendBlockManager> m_sendMessageDictionary = null;
        private int m_retryCounter = 0;
        // --
        private FCodeLock m_fMainRecvSync = null;
        private FCodeLock m_fMainSendSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrAutoCycle = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSECS1(
            FSecs1Protocol fSecs1Protocol
            )
        {
            m_fSecs1Protocol = fSecs1Protocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSECS1(
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
                    m_fSecs1Protocol = null;
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

        public FSecs1Protocol fSecs1Protocol
        {
            get
            {
                try
                {
                    return m_fSecs1Protocol;
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
                    return m_fSecs1Protocol.fProtocolAgent;
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

        public FIDPointer32 fSystemBytesPointer
        {
            get
            {
                try
                {
                    return m_fSystemBytesPointer;
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

        public FScdCore fScdCore
        {
            get
            {
                try
                {
                    return m_fSecs1Protocol.fScdCore;
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
                    return m_fSecs1Protocol.fScdCore.fEventPusher;
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

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecs1Protocol.fScdCore.fSecsDriver;
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

        public FSecsDevice fSecsDevice
        {
            get
            {
                try
                {
                    return m_fSecs1Protocol.fSecsDevice;
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

        public string serialPort
        {
            get
            {
                try
                {
                    return m_fSerial.portName;
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
                    m_fSerial.portName = value;
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

        public int baud
        {
            get
            {
                try
                {
                    return m_fSerial.baudRate;
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
                    if (
                        value == 150 ||
                        value == 300 ||
                        value == 1200 ||
                        value == 2400 ||
                        value == 4800 ||
                        value == 9600 ||
                        value == 14400 ||
                        value == 19200 ||
                        value == 28800 ||
                        value == 33600 ||
                        value == 57600 
                        )
                    {
                        m_fSerial.baudRate = value;
                    }
                    else
                    {
                        FDebug.throwFException(FConstants.err_m_16007);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool rbit
        {
            get
            {
                try
                {
                    return m_rbit;
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

        public bool duplicateError
        {
            get
            {
                try
                {
                    return m_duplicateError;
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

        public bool interleave
        {
            get
            {
                try
                {
                    return m_interleave;
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

        public bool ignoreSystemBytes
        {
            get
            {
                try
                {
                    return m_ignoreSystemBytes;
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

        public int retryLimit
        {
            get
            {
                try
                {
                    return m_retryLimit;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 3;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public int t1Timeout
        {
            get
            {
                try
                {
                    return m_t1Timeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return (int)(0.5 * 1000);
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
                return 10 * 1000;
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
                return 45 * 1000;
            }
        }
        //------------------------------------------------------------------------------------------------------------------------

        public int t4Timeout
        {
            get
            {
                try
                {
                    return m_t4Timeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 45 * 1000;
            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            UInt32 maxSystemBytes = UInt32.MaxValue;
            try
            {
                // -

                if (m_fSecs1Protocol.fSecsDevice.maxSystemBytes > 0)
                {
                    maxSystemBytes = m_fSecs1Protocol.fSecsDevice.maxSystemBytes;
                }

                // --
                // 2018.12.13 by Jeff.Kim
                // Device에 Max System byte 를 설정 할수 있도록 변경.
                // 특정 설비의 경우 System Byte 값이 6자기 (999999)를 넘어 갈경우 문제 발생
                m_fSystemBytesPointer = new FIDPointer32(
                    UInt32.MinValue,
                    maxSystemBytes,
                    UInt32.MinValue
                    );

                // --
                m_rbit = m_fSecs1Protocol.fSecsDevice.rbit;                
                m_duplicateError = m_fSecs1Protocol.fSecsDevice.duplicateError;
                m_interleave = m_fSecs1Protocol.fSecsDevice.interleave;
                m_retryLimit = m_fSecs1Protocol.fSecsDevice.retryLimit;
                m_ignoreSystemBytes = m_fSecs1Protocol.fSecsDevice.ignoreSystemBytes;
                // -- 
                m_t1Timeout = (int)(m_fSecs1Protocol.fSecsDevice.t1Timeout * 1000);
                m_t2Timeout = (int)(m_fSecs1Protocol.fSecsDevice.t2Timeout * 1000);
                m_t3Timeout = m_fSecs1Protocol.fSecsDevice.t3Timeout * 1000;
                m_t4Timeout = m_fSecs1Protocol.fSecsDevice.t4Timeout * 1000;

                // -- 

                m_fTmrT1 = new FStaticTimer();
                m_fTmrT2 = new FStaticTimer();
                m_fTranDataMessage = new FSecsOpenTransaction(this.fSecsDriver, this.t3Timeout, false);
                m_fRecvBuf = new FSecs1RecvBuffer();
                //--
                m_recvMessageList = new List<string>();
                m_sendMessageList = new List<string>();
                m_recvMessageDictionary = new Dictionary<string, FRecvBlockManager>();
                m_sendMessageDictionary = new Dictionary<string, FSendBlockManager>();
                
                // --

                m_fTmrAutoCycle = new FStaticTimer();
                m_fMainRecvSync = new FCodeLock();
                m_fMainSendSync = new FCodeLock();
                m_fThdMain = new FThread("FSecs1MainThread");
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
                if (m_fSystemBytesPointer != null)
                {
                    m_fSystemBytesPointer.Dispose();
                    m_fSystemBytesPointer = null;
                }

                // --

                if (m_fThdMain != null)
                {
                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                // --

                if (m_fSerial != null)
                {
                    m_fSerial.close();
                    m_fSerial.Dispose();
                    // --
                    m_fSerial.SerialStateChanged -= new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                    m_fSerial.SerialDataReceived -= new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                    m_fSerial.SerialDataSent -= new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                    m_fSerial.SerialDataSendFailed -= new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                    m_fSerial.SerialErrorRaised -= new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                    // -- 
                    m_fSerial = null;
                }

                // --

                if (m_fTmrT1 != null)
                {
                    m_fTmrT1.Dispose();
                    m_fTmrT1 = null;
                }

                if (m_fTmrT2 != null)
                {
                    m_fTmrT2.Dispose();
                    m_fTmrT2 = null;
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

                // -- 

                this.clearSendMessage();
                m_sendMessageList = null;
                m_sendMessageDictionary = null;

                this.clearRecvMessage();
                m_recvMessageList = null;
                m_recvMessageDictionary = null;
                
                // -- 

                if (m_fTmrAutoCycle != null)
                {
                    m_fTmrAutoCycle.Dispose();
                    m_fTmrAutoCycle = null;
                }

                if (m_fMainSendSync != null)
                {
                    m_fMainSendSync.Dispose();
                    m_fMainSendSync = null;
                }

                if (m_fMainRecvSync != null)
                {
                    m_fMainRecvSync.Dispose();
                    m_fMainRecvSync = null;
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
                
        public void open(
            )
        {
            try
            {
                m_fSerial = new FSerial(
                    this.fSecs1Protocol.fSecsDevice.serialPort,
                    this.fSecs1Protocol.fSecsDevice.baud
                    );
                // --
                m_fSerial.SerialStateChanged += new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                m_fSerial.SerialDataReceived += new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                m_fSerial.SerialDataSent += new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                m_fSerial.SerialDataSendFailed += new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                m_fSerial.SerialErrorRaised += new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                // -- 
                m_fSerial.open();
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
                if (m_fSerial.fState == FSerialState.Opened)
                {
                    if(this.fDeviceState == FDeviceState.Selected)
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
                        while (this.fEventPusher.eventCount > 0 || !m_fSerial.sendCompleted)
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

                m_fSerial.close();
                m_fSerial.Dispose();
                // --
                m_fSerial.SerialStateChanged -= new FSerialStateChangedEventHandler(m_fSerial_SerialStateChanged);
                m_fSerial.SerialDataReceived -= new FSerialDataReceivedEventHandler(m_fSerial_SerialDataReceived);
                m_fSerial.SerialDataSent -= new FSerialDataSentEventHandler(m_fSerial_SerialDataSent);
                m_fSerial.SerialDataSendFailed -= new FSerialDataSendFailedEventHandler(m_fSerial_SerialDataSendFailed);
                m_fSerial.SerialErrorRaised -= new FSerialErrorRaisedEventHandler(m_fSerial_SerialErrorRaised);
                // -- 
                m_fSerial = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fSerial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void send(
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

        public void pauseProtocol(
            )
        {
            try
            {
                m_fMainRecvSync.wait();
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
                m_fMainRecvSync.set();
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
                m_fRecvBuf.clear();
                
                // -- 
                
                clearSendMessage();
                clearRecvMessage();
                m_fTranDataMessage.clearTransaction();
                
                // --
                
                returnToIdle();
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

        private void changeDeviceState(
            FDeviceState fState
            )
        {
            FSecsDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeStrList = null;
            try
            {
                m_fDeviceState = fState;

                // --

                this.fSecsDevice.changeState(m_fDeviceState);

                // -- 

                if (fSecsDriver.fScdCore.fConfig.enabledEventsOfSecsDeviceState)
                {
                    this.fEventPusher.pushSecsDeviceStateChangedEvent(
                        this.fSecsDevice,
                        FResultCode.Success,
                        string.Empty,
                        this.serialPort,
                        this.baud
                        );
                }

                // --

                // ***
                // Trigger Parse
                // ***
                if (this.fScdCore.fSecsDriver.enabledEventsOfScenario)
                {
                    fXmlNodeStrList = FSECS2.parseConnectionTrigger(this.fSecsDriver, this.fSecsDevice.fXmlNode,fState);
                    // --

                    fLog = new FSecsDeviceStateChangedLog(
                        FSecsDriverLogCommon.createXmlNodeSDVL(this.fSecsDevice.fXmlNode, FXmlTagSDVL.L_StateChanged)
                        );

                    // --
                    foreach (FXmlNode fXmlNodeStr in fXmlNodeStrList)
                    {
                        this.fEventPusher.pushSecsTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeStr, fLog);
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
                fXmlNodeStrList = null;
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
                
                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearSecsAutoCycleTransmitter(this.fSecsDevice);
                m_fTmrAutoCycle.stop();
                
                // -- 

                // ***
                // SECS Retry Condition 초기화
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
            int remainBlocks = 0;
            byte byteValue = 0;
            string messageKey = string.Empty;            
            // --
            FBlockInfo fBlockInfo = null;
            FSendBlockManager fSendBlocks = null;
            FRecvBlockManager fRecvBlocks = null;
            
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
                        this.serialPort,
                        this.baud,
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
                        this.serialPort,
                        this.baud,
                        data
                        );
                }

                // --

                m_fRecvBuf.input(data);
                if (m_fStatusType == FSecs1StatusType.Idle)
                {
                    #region Idle Status

                    while (m_fRecvBuf.length > 0)
                    {
                        byteValue = m_fRecvBuf.output();
                        if (byteValue == (byte)FSecs1HandshakeCode.ENQ)
                        {
                            m_isMessagingBlock = true;
                            // --
                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                            {
                                this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    FSecs1HandshakeCode.ENQ
                                    );
                            }

                            // --
                            
                            sendEOT();
                            
                            // --

                            // ***
                            // 2016.09.07 Jungyoul
                            // Error 처리 및 Buffer Clear
                            // ***
                            while (m_fRecvBuf.length > 0)
                            {
                                procDeviceErrorRaised(string.Format(FConstants.err_m_16001, m_fRecvBuf.output()));
                            }
                            break;
                        }
                        else
                        {
                            procDeviceErrorRaised(string.Format(FConstants.err_m_16001, byteValue));
                        }
                    }

                    #endregion
                }
                else if(m_fStatusType == FSecs1StatusType.LineControl)
                {
                    #region LineControl Status

                    while (m_fRecvBuf.length > 0)                    
                    {                        
                        byteValue = m_fRecvBuf.output();
                        if (byteValue == (byte)FSecs1HandshakeCode.ENQ && !rbit)
                        {
                            m_fTmrT2.stop();
                            
                            // --
                            
                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                            {
                                this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    FSecs1HandshakeCode.ENQ
                                    );
                            }

                            // -- 
                            
                            // procDeviceErrorRaised(FConstants.err_m_16009);
                            
                            // --
                            
                            sendEOT();
                            
                            // --

                            // ***
                            // 2016.09.07 Jungyoul
                            // Error 처리 및 Buffer Clear
                            // ***
                            while (m_fRecvBuf.length > 0)
                            {
                                procDeviceErrorRaised(string.Format(FConstants.err_m_16001, m_fRecvBuf.output()));
                            }
                        }
                        else if (byteValue == (byte)FSecs1HandshakeCode.EOT)
                        {
                            m_fTmrT2.stop();

                            // --
                            
                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                            {
                                this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    FSecs1HandshakeCode.EOT
                                    );
                            }
                            
                            // -- 
                            
                            m_fStatusType = FSecs1StatusType.Send;
                            sendBlock();

                            // --

                            // ***
                            // 2016.09.07 Jungyoul
                            // Error 처리 및 Buffer Clear
                            // ***
                            while (m_fRecvBuf.length > 0)
                            {
                                procDeviceErrorRaised(string.Format(FConstants.err_m_16001, m_fRecvBuf.output()));
                            }
                            break;
                        }
                        else
                        {
                            if (byteValue != (byte)FSecs1HandshakeCode.ENQ)
                            {
                                procDeviceErrorRaised(string.Format(FConstants.err_m_16001, byteValue));
                            }
                        }                        
                    }

                    #endregion
                }
                else if (m_fStatusType == FSecs1StatusType.Receive)
                {
                    #region Receive Status

                    m_fTmrT2.stop();

                    // -- 

                    byteValue = m_fRecvBuf.watch();
                    if (byteValue >= 10 && byteValue <= 254)
                    {
                        m_fTmrT1.restart(t1Timeout);
                        // -- 
                        if (m_fRecvBuf.length >= 1 + byteValue + 2)
                        {
                            m_fTmrT1.stop();

                            // -- 

                            fBlockInfo = new FBlockInfo(m_fRecvBuf.output(1 + byteValue + 2));
                            
                            // --
                            
                            // ***
                            // Checksum
                            // ***
                            if (!fBlockInfo.isCheckSum)
                            {
                                m_fStatusType = FSecs1StatusType.ReceiveCompletion;
                                m_fTmrT1.restart(t1Timeout);
                                FDebug.throwFException(FConstants.err_m_16010);
                            }

                            // --

                            if (fScdCore.fConfig.enabledEventsOfSecsDeviceBlock)
                            {
                                this.fEventPusher.pushSecsDeviceBlockReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    fBlockInfo.rbit,
                                    fBlockInfo.sessionId,
                                    fBlockInfo.wbit,
                                    fBlockInfo.stream,
                                    fBlockInfo.function,
                                    fBlockInfo.ebit,
                                    fBlockInfo.blockNo,
                                    fBlockInfo.systemBytes,
                                    fBlockInfo.length
                                    );
                            }

                            // --

                            // ***
                            // Interleave
                            // ***
                            if (!interleave)
                            {
                                if (isInterleave(messageKey))
                                {                                    
                                    sendNAK();
                                    FDebug.throwFException(FConstants.err_m_16008);
                                }
                            }
                            
                            // --
                            
                            sendACK();
                        
                            // --

                            procBlockReceived(fBlockInfo);
                            
                            // --
                            
                            messageKey = makeKey(fBlockInfo.sessionId, fBlockInfo.stream, fBlockInfo.function, fBlockInfo.systemBytes);
                            fRecvBlocks = getRecvBlockManager(messageKey, true);
                            
                            if (fRecvBlocks.isCompleted)
                            {
                                if (rbit == fRecvBlocks.rbit)
                                {
                                    procDeviceErrorRaised(FConstants.err_m_16003);
                                }

                                // -- 

                                recvDataMessage(messageKey, fRecvBlocks);
                                closeRecvMessage(messageKey);
                            }                            
                        }
                        else
                        {
                            m_fTmrT1.restart(t1Timeout);
                        }
                    }
                    else
                    {
                        m_fStatusType = FSecs1StatusType.ReceiveCompletion;
                        m_fRecvBuf.clear();
                        m_fTmrT1.restart(t1Timeout);
                    }

                    #endregion
                }
                else if (m_fStatusType == FSecs1StatusType.ReceiveCompletion)
                {
                    #region ReceiveCompletion Status

                    if (m_fRecvBuf.length > 0)
                    {
                        m_fRecvBuf.clear();                        
                        m_fTmrT1.restart(t1Timeout);
                    }

                    #endregion
                }
                else if (m_fStatusType == FSecs1StatusType.SendCompletion)
                {
                    #region SendCompletion Status

                    m_fTmrT2.stop();

                    // -- 

                    byteValue = m_fRecvBuf.output();
                    if (byteValue == (byte)FSecs1HandshakeCode.ACK)
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                        {
                            this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                this.fSecsDevice,
                                FResultCode.Success,
                                string.Empty,
                                FSecs1HandshakeCode.ACK
                                );
                        }

                        // --

                        fSendBlocks = getSendBlockManager(m_sendMessageList[0]);
                        remainBlocks = fSendBlocks.removeBlock();
                        if (remainBlocks == 0)
                        {
                            procDataMessageSent(fSendBlocks);
                                
                            // -- 
                                
                            if (fSendBlocks.wbit)
                            {
                                messageKey = makeKey(fSendBlocks.sessionId, fSendBlocks.stream, fSendBlocks.function + 1, fSendBlocks.systemBytes);
                                openRecvMessage(
                                    messageKey,
                                    !fSendBlocks.rbit,
                                    fSendBlocks.sessionId,
                                    fSendBlocks.wbit,
                                    fSendBlocks.stream,
                                    fSendBlocks.function + 1,
                                    fSendBlocks.systemBytes
                                    );
                            }
                                
                            // -- 
                                
                            closeSendMessage(m_sendMessageList[0]);
                        }

                        // -- 

                        returnToIdle();
                    }
                    else 
                    {
                        if (byteValue == (byte)FSecs1HandshakeCode.NAK)
                        {
                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                            {
                                this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    FSecs1HandshakeCode.NAK
                                    );
                            }
                        }
                        else
                        {
                            procDeviceErrorRaised(string.Format(FConstants.err_m_16001, byteValue));
                        }
                        
                        // -- 

                        m_fStatusType = FSecs1StatusType.LineControl;
                        m_retryCounter++;
                        if (m_retryCounter > retryLimit)
                        {
                            closeSendMessage(m_sendMessageList[0]);
                            returnToIdle();
                            FDebug.throwFException(FConstants.err_m_16002);
                        }
                        else
                        {
                            sendENQ();
                        }
                    }

                    // --

                    // ***
                    // 2016.09.07 Jungyoul
                    // ENQ 처리 추가
                    // ***
                    while (m_fRecvBuf.length > 0)
                    {
                        byteValue = m_fRecvBuf.output();
                        if (byteValue == (byte)FSecs1HandshakeCode.ENQ)
                        {
                            m_isMessagingBlock = true;
                            // --
                            if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                            {
                                this.fEventPusher.pushSecsDeviceHandshakeReceivedEvent(
                                    this.fSecsDevice,
                                    FResultCode.Success,
                                    string.Empty,
                                    FSecs1HandshakeCode.ENQ
                                    );
                            }

                            // -- 

                            sendEOT();

                            // --

                            // ***
                            // 2016.09.07 Jungyoul
                            // Error 처리 및 Buffer Clear
                            // ***
                            while (m_fRecvBuf.length > 0)
                            {
                                procDeviceErrorRaised(string.Format(FConstants.err_m_16001, m_fRecvBuf.output()));
                            }
                            break;
                        }
                        else
                        {
                            procDeviceErrorRaised(string.Format(FConstants.err_m_16001, byteValue));
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (fBlockInfo != null)
                {
                    fBlockInfo.Dispose();
                    fBlockInfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void procDataSent(
            byte[] data,
            object state
            )
        {
            FSecsDeviceHandshakeSentLog fHandshakeSentLog = null;

            try
            {
                // ***
                // 2012.11.23 by spike.lee
                // Binary Log File은 Enabled Event와 상관 없이 기록하도록 수정
                // ***
                if (this.fScdCore.fConfig.enabledLogOfBinary)
                {
                    this.fScdCore.fLogWriter.pushBinaryLog(
                        FEventId.SecsDeviceDataSent,
                        FDataConvert.defaultNowDateTimeToString(),
                        this.fSecsDevice.name,
                        this.fSecsDevice.fProtocol,
                        this.serialPort,
                        this.baud,
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
                        this.serialPort,
                        this.baud,
                        data
                        );
                }
                
                // --
                                
                if (state is FSecsDeviceBlockSentLog)
                {
                    m_fStatusType = FSecs1StatusType.SendCompletion;
                    m_fTmrT2.restart(t2Timeout);

                    // -- 

                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceBlock)
                    {
                        this.fEventPusher.pushSecsDeviceBlockSentEvent(
                            this.fSecsDevice,
                            FResultCode.Success,
                            string.Empty,
                            (FSecsDeviceBlockSentLog)state
                            );
                    }
                }
                else if (state is FSecsDeviceHandshakeSentLog)
                {
                    fHandshakeSentLog = (FSecsDeviceHandshakeSentLog)state;
                    // --
                    if (fHandshakeSentLog.fHandshakeCode == FSecs1HandshakeCode.ENQ)
                    {
                        m_fTmrT2.restart(t2Timeout);
                    }
                    else if (fHandshakeSentLog.fHandshakeCode == FSecs1HandshakeCode.EOT)
                    {
                        m_fStatusType = FSecs1StatusType.Receive;
                        m_fTmrT2.restart(t2Timeout);
                    }
                    else if (
                        fHandshakeSentLog.fHandshakeCode == FSecs1HandshakeCode.ACK ||
                        fHandshakeSentLog.fHandshakeCode == FSecs1HandshakeCode.NAK
                        )
                    {
                        returnToIdle();
                    }

                    // --

                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                    {
                        this.fEventPusher.pushSecsDeviceHandshakeSentEvent(
                            this.fSecsDevice,
                            FResultCode.Success,
                            string.Empty,
                            (FSecsDeviceHandshakeSentLog)state
                            );
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
            try
            {
                if (state is FSecsDeviceBlockSentLog)
                {
                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceBlock)
                    {
                        this.fEventPusher.pushSecsDeviceBlockSentEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            message,
                            (FSecsDeviceBlockSentLog)state
                            );
                    }
                }
                else if (state is FSecsDeviceHandshakeSentLog)
                {
                    if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceHandshake)
                    {
                        this.fEventPusher.pushSecsDeviceHandshakeSentEvent(
                            this.fSecsDevice,
                            FResultCode.Error,
                            message,
                            (FSecsDeviceHandshakeSentLog)state
                            );
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
        
        private void procDataMessageSent(
            FSendBlockManager fSendBlockManager
            )
        {
            string sml = string.Empty;
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;

            try
            {
                if (
                    this.fScdCore.fConfig.enabledLogOfSml ||
                    this.fScdCore.fConfig.enabledEventsOfSecsDeviceSml
                    )
                {
                    // ***
                    // SML Parsing
                    // ***
                    sml = FMessageConverter.convertBinToSml(
                        fSendBlockManager.stream,
                        fSendBlockManager.function,
                        fSendBlockManager.wbit,
                        fSendBlockManager.body,
                        fSendBlockManager.length,
                        ref fResultCode,
                        ref resultMessage
                        );
                    
                    // -- 

                    // ***
                    // 2012.11.23 by spike.lee
                    // SML Log File은 Enabled Event와 상관 없이 기록하도록 수정
                    // ***
                    if (this.fScdCore.fConfig.enabledLogOfSml)
                    {
                        this.fScdCore.fLogWriter.pushSmlLog(
                            FEventId.SecsDeviceSmlSent,
                            FDataConvert.defaultNowDateTimeToString(),
                            this.fSecsDevice.name,
                            fSendBlockManager.sessionId,
                            fSendBlockManager.systemBytes,
                            fSendBlockManager.length,
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
                            fSendBlockManager.sessionId,
                            fSendBlockManager.stream,
                            fSendBlockManager.function,
                            fSendBlockManager.wbit,
                            fSendBlockManager.systemBytes,
                            fSendBlockManager.length,
                            sml
                            );
                    }                    
                }

                // --
                                
                // ***
                // SECS Data Message Sent Event
                // ***
                if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                {
                    this.fEventPusher.pushSecsDeviceDataMessageSentEvent(
                        this.fSecsDevice, 
                        FResultCode.Success, 
                        string.Empty,
                        fSendBlockManager.fLog
                        );
                }

                // --

                // ***
                // Data Message Open Transaction 설정
                // ***
                if (fSendBlockManager.fLog.isPrimary && fSendBlockManager.fLog.wBit)
                {
                    m_fTranDataMessage.openTransaction(
                        this.fEventPusher.createSecsDeviceDataMessageSentLog(fSendBlockManager.fLog.fXmlNodeSsn, fSendBlockManager.fLog.fXmlNode.clone(false))
                        );
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

        private void procBlockReceived(
            FBlockInfo fBlockInfo
            )
        {
            FRecvBlockManager fRecvBlockManager = null;
            string messageKey = string.Empty;

            try
            {
                messageKey = makeKey(fBlockInfo.sessionId, fBlockInfo.stream, fBlockInfo.function, fBlockInfo.systemBytes);
                
                // ***
                // Known Device
                // ***
                if (!isKnownDevice(fBlockInfo.sessionId))
                {
                    FDebug.throwFException(FConstants.err_m_16004);
                }
                
                // -- 

                // ***
                // Duplicate Block
                // ***
                if (isDuplicate(fBlockInfo))
                {
                    if (duplicateError)
                    {
                        FDebug.throwFException(FConstants.err_m_16005);
                    }
                    return;
                }

                // -- 

                // ***
                // Expected Block
                // ***
                if (isExpectedBlock(fBlockInfo))
                {
                    if (!fBlockInfo.isSecondary)
                    {
                        fRecvBlockManager = getRecvBlockManager(messageKey, true);                        
                        fRecvBlockManager.fTmrT4.stop();
                        fRecvBlockManager.addBlock(fBlockInfo.block);
                    }
                }
                else
                {
                    if (!fBlockInfo.isPrimary)
                    {
                        FDebug.throwFException(FConstants.err_m_16006);
                    }

                    if (!fBlockInfo.isFirst)
                    {
                        FDebug.throwFException(FConstants.err_m_16006);
                    }

                    // -- 

                    openRecvMessage(messageKey, fBlockInfo.block);
                    m_recvMessageDictionary[messageKey].addBlock(fBlockInfo.block);
                }
                
                // -- 
                
                fRecvBlockManager = getRecvBlockManager(messageKey, true);
                if (fBlockInfo.isSecondary)
                {
                    if (!fBlockInfo.isFirst)
                    {
                        fRecvBlockManager.fTmrT4.stop();
                    }

                    // -- 

                    fRecvBlockManager.addBlock(fBlockInfo.block);

                    // -- 

                    if (!fBlockInfo.isLast)
                    {
                        fRecvBlockManager.fTmrT4.start(t4Timeout);
                    }
                }
                else
                {
                    if (!fBlockInfo.isLast)
                    {
                        fRecvBlockManager.fTmrT4.restart(t4Timeout);
                    }
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {                              
                if (fBlockInfo != null)
                {
                    fBlockInfo.Dispose();
                    fBlockInfo = null;
                }
            }

        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private string getTimeoutMessage(
            FSecsDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsDeviceTimeout.T1)
                {
                    return FConstants.err_m_20001;
                }
                else if (fTimeout == FSecsDeviceTimeout.T2)
                {
                    return FConstants.err_m_20002;
                }
                else if (fTimeout == FSecsDeviceTimeout.T3)
                {
                    return FConstants.err_m_20003;
                }
                else if (fTimeout == FSecsDeviceTimeout.T4)
                {
                    return FConstants.err_m_20004;
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
                
        private string getTimeoutDescription(
            FSecsDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsDeviceTimeout.T1)
                {
                    return FConstants.err_m_21001;
                }
                else if (fTimeout == FSecsDeviceTimeout.T2)
                {
                    return FConstants.err_m_21002;
                }
                else if (fTimeout == FSecsDeviceTimeout.T3)
                {
                    return FConstants.err_m_21003;
                }
                else if (fTimeout == FSecsDeviceTimeout.T4)
                {
                    return FConstants.err_m_21004;
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

        private void procDeviceErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                if (this.fScdCore.fConfig.enabledEventsOfSecsDeviceError)
                {
                    this.fEventPusher.pushSecsDeviceErrorRaisedEvent(this.fSecsDevice, FResultCode.Error, inEx.Message);
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

        private void procDeviceErrorRaised(
            string errorMessage
            )
        {
            Exception inEx = null;

            try
            {
                inEx = new Exception(errorMessage);
                // --
                procDeviceErrorRaised(inEx);
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
        
        private void sendDataMessage(
            FSecsSession fSsn,
            FSecsMessageTransfer fSmt
            )
        {
            FXmlNode fXmlNodeSmgl = null;
            // --
            int sessionId = 0;
            bool wbit = false;
            int stream = 0;
            int function = 0;
            UInt32 systemBytes = 0;
            // -- 
            string messageKey = string.Empty;
            ArrayList body = null;
            List<byte[]> blockList = null;
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

                blockList = (new FSecs1SendBuffer()).genBlocks(
                    rbit,
                    (UInt16)sessionId,
                    stream,
                    function,
                    wbit,
                    systemBytes,
                    body
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

                //--

                messageKey = makeKey(sessionId, stream, function, systemBytes);
                openSendMessage(messageKey, blockList, body, fLog);                               
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fXmlNodeSmgl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendENQ(
            )
        {
            FSecsDeviceHandshakeSentLog fLog = null;

            try
            {
                fLog = this.fEventPusher.createSecsDeviceHandshakeSentLog(
                    this.fSecsDevice,
                    FSecs1HandshakeCode.ENQ
                    );
                
                // --
                
                m_fSerial.send(new FSerialSendData((new FSecs1SendBuffer()).genENQ(), fLog));
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

        private void sendEOT(
            )
        {
            FSecsDeviceHandshakeSentLog fLog = null;

            try
            {
                fLog = this.fEventPusher.createSecsDeviceHandshakeSentLog(
                    this.fSecsDevice,
                    FSecs1HandshakeCode.EOT
                    );
                
                // --
                
                m_fSerial.send(new FSerialSendData((new FSecs1SendBuffer()).genEOT(), fLog));
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

        private void sendACK(
            )
        {
            FSecsDeviceHandshakeSentLog fLog = null;

            try
            {
                fLog = this.fEventPusher.createSecsDeviceHandshakeSentLog(
                    this.fSecsDevice,
                    FSecs1HandshakeCode.ACK
                    );
                
                // --
                
                m_fSerial.send(new FSerialSendData((new FSecs1SendBuffer()).genACK(), fLog));
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

        private void sendNAK(
            )
        {
            FSecsDeviceHandshakeSentLog fLog = null;

            try
            {
                fLog = this.fEventPusher.createSecsDeviceHandshakeSentLog(
                    this.fSecsDevice,
                    FSecs1HandshakeCode.NAK
                    );
                
                // --
                
                m_fSerial.send(new FSerialSendData((new FSecs1SendBuffer()).genNAK(), fLog));
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
        
        private void sendBlock(
            )
        {
            FBlockInfo fBlockInfo = null;
            FSendBlockManager fSendBlockManager = null;
            // -- 
            FSecsDeviceBlockSentLog fLog = null;
            
            try
            {
                fSendBlockManager = getSendBlockManager(m_sendMessageList[0]);
                fBlockInfo = new FBlockInfo(fSendBlockManager.getBlock());
                    
                // --
                    
                fLog = this.fEventPusher.createSecsDeviceBlockSentLog(
                    this.fSecsDevice,
                    fBlockInfo.rbit,
                    fBlockInfo.sessionId,
                    fBlockInfo.wbit,
                    fBlockInfo.stream,
                    fBlockInfo.function,
                    fBlockInfo.ebit,
                    fBlockInfo.blockNo,
                    fBlockInfo.systemBytes,
                    fBlockInfo.length
                    );
                  
                // --
                    
                m_fSerial.send(new FSerialSendData(fBlockInfo.block, fLog));
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                fBlockInfo = null;
            }
        }
       
        //------------------------------------------------------------------------------------------------------------------------

        private void recvDataMessage(
            string messageKey,
            FRecvBlockManager fRecvBlocks
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
            FSecsDeviceDataMessageReceivedLog fRecvLog = null;
            FSecsMessage fSmg = null;
            FSecsMessageTransfer fSmt = null;            

            try
            {
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
                        fRecvBlocks.stream,
                        fRecvBlocks.function,
                        fRecvBlocks.wbit,
                        fRecvBlocks.body,
                        fRecvBlocks.length,
                        ref fResultCode,
                        ref resultMessage
                        );

                    // --                

                    // ***
                    // 2012.11.23 by spike.lee
                    // SML Log File은 Enabled Event와 상관 없이 기록하도록 수정
                    // ***
                    if (this.fScdCore.fConfig.enabledLogOfSml)
                    {
                        this.fScdCore.fLogWriter.pushSmlLog(
                            FEventId.SecsDeviceSmlReceived,
                            FDataConvert.defaultNowDateTimeToString(),
                            this.fSecsDevice.name,
                            fRecvBlocks.sessionId,
                            fRecvBlocks.systemBytes,
                            fRecvBlocks.length,
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
                            fRecvBlocks.sessionId,
                            fRecvBlocks.stream,
                            fRecvBlocks.function,
                            fRecvBlocks.wbit,
                            fRecvBlocks.systemBytes,
                            fRecvBlocks.length,
                            sml
                            );
                    }
                }

                // --

                // ***
                // SECS Open Transaction 검색 (Only Secondary Message)
                // ***
                if (fRecvBlocks.function != 0 && fRecvBlocks.function % 2 == 0)
                {
                    fTranLog = m_fTranDataMessage.getTransaction(
                        fRecvBlocks.sessionId,
                        fRecvBlocks.stream,
                        fRecvBlocks.function,
                        fRecvBlocks.systemBytes
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
                    fRecvBlocks.sessionId,
                    fRecvBlocks.stream,
                    fRecvBlocks.function,
                    fRecvBlocks.wbit,
                    fRecvBlocks.systemBytes,
                    fRecvBlocks.body,
                    fRecvBlocks.length,
                    ref fResultCode,
                    ref resultMessage,
                    ref fXmlNodeSsn,
                    ref fXmlNodeSmg
                    );
                
                // --
                
                fRecvLog = this.fEventPusher.createSecsDeviceDataMessageReceivedLog(fXmlNodeSsn, fXmlNodeSmgl);

                // --

                if (fResultCode == FResultCode.Success)
                {
                    if (fRecvLog.isPrimary)
                    {
                        if (fRecvLog.wBit)
                        {
                            fXmlNodeSmg = FSECS2.getReplyMessage(this.fSecsDriver, fXmlNodeSsn, fRecvLog.uniqueIdToString);
                            if (fXmlNodeSmg != null)
                            {
                                fSmg = new FSecsMessage(this.fScdCore, fXmlNodeSmg);
                            }
                        }

                        // --

                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                        {
                            this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(
                                this.fSecsDevice,
                                fResultCode,
                                resultMessage,
                                fRecvLog,
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
                                fSmt = fSmg.createTransfer(fRecvLog.systemBytes);
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
                                    fRecvLog.deviceUniqueId,
                                    fRecvLog.sessionUniqueId,
                                    fSmg.uniqueId,
                                    fRecvLog.systemBytes
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
                        }
                        
                        // --
                        
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                        {
                            this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(
                                this.fSecsDevice,
                                fResultCode,
                                resultMessage,
                                fRecvLog,
                                null
                                );
                        }
                    }

                    // --
                    
                    // ***
                    // Trigger Parse
                    // ***
                    if (fScdCore.fSecsDriver.enabledEventsOfScenario)
                    {
                        if (fResultCode == FResultCode.Success)
                        {
                            fXmlNodeStrList = FSECS2.parseExpressionTrigger(this.fSecsDriver, fXmlNodeSmgl);
                            foreach (FXmlNode fXmlNodeStr in fXmlNodeStrList)
                            {
                                this.fEventPusher.pushSecsTriggerRaisedEvent(
                                    FResultCode.Success,
                                    string.Empty,
                                    fXmlNodeStr,
                                    fRecvLog
                                    );
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
                    if (!fRecvLog.isPrimary)
                    {
                        this.fProtocolAgent.fSecsSystemBytesStorage.clear();
                        this.fProtocolAgent.fHostTidStorage.clear();
                    }

                    // --

                    if (fScdCore.fConfig.enabledEventsOfSecsDeviceDataMessage)
                    {
                        this.fEventPusher.pushSecsDeviceDataMessageReceivedEvent(
                            this.fSecsDevice,
                            fResultCode,
                            resultMessage,
                            fRecvLog,
                            null
                            );
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
                fRecvLog = null;
                fSmg = null;
                fSmt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void openRecvMessage(
            string messageKey,
            byte[] block
            )
        {
            try
            {
                m_fMainRecvSync.wait();

                // -- 

                if (m_recvMessageList.Contains(messageKey))
                {
                    m_recvMessageList.Remove(messageKey);
                }

                if (m_recvMessageDictionary.ContainsKey(messageKey))
                {
                    m_recvMessageDictionary.Remove(messageKey);
                }

                // --

                m_recvMessageList.Add(messageKey);
                m_recvMessageDictionary.Add(messageKey, new FRecvBlockManager(block));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void openRecvMessage(
            string messageKey,
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            int stream,
            int function,
            UInt32 systemBytes
            )
        {
            try
            {
                m_fMainRecvSync.wait();

                // -- 

                if (m_recvMessageList.Contains(messageKey))
                {
                    m_recvMessageList.Remove(messageKey);
                }

                if (m_recvMessageDictionary.ContainsKey(messageKey))
                {
                    m_recvMessageDictionary.Remove(messageKey);
                }

                // --

                m_recvMessageList.Add(messageKey);
                m_recvMessageDictionary.Add(messageKey, new FRecvBlockManager(rbit, sessionId, wbit, stream, function, systemBytes));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void openSendMessage(
            string messageKey,
            List<byte[]> blockList,
            ArrayList body,
            FSecsDeviceDataMessageSentLog fLog
            )
        {
            try
            {
                m_fMainSendSync.wait();

                // -- 

                if (m_sendMessageList.Contains(messageKey))
                {
                    m_sendMessageList.Remove(messageKey);
                }

                if (m_sendMessageDictionary.ContainsKey(messageKey))
                {
                    m_sendMessageDictionary.Remove(messageKey);
                }
                
                // --
                
                m_sendMessageList.Add(messageKey);
                m_sendMessageDictionary.Add(messageKey, new FSendBlockManager(blockList, body, fLog));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSendSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeSendMessage(
            string messageKey
            )
        {
            FSendBlockManager fSendBlockManager = null;

            try
            {
                m_fMainSendSync.wait();

                // -- 

                fSendBlockManager = getSendBlockManager(messageKey);
                fSendBlockManager.Dispose();
                fSendBlockManager = null;
                
                // --
                
                m_sendMessageList.Remove(messageKey);
                m_sendMessageDictionary.Remove(messageKey);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSendSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeRecvMessage(
            string messageKey
            )
        {
            FRecvBlockManager fRecvBlockManager = null;

            try
            {
                m_fMainRecvSync.wait();
                
                // -- 

                fRecvBlockManager = getRecvBlockManager(messageKey, true);
                // ***
                // 2016.09.07 by Jungyoul
                // Null 처리
                // ***
                if (fRecvBlockManager != null)
                {
                    fRecvBlockManager.Dispose();
                    fRecvBlockManager = null;

                    // --

                    m_recvMessageList.Remove(messageKey);
                    m_recvMessageDictionary.Remove(messageKey);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void clearSendMessage(
            )
        {
            try
            {
                m_fMainSendSync.wait();

                // -- 

                m_sendMessageList.Clear();                
                m_sendMessageDictionary.Clear();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainSendSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clearRecvMessage(
            )
        {
            try
            {
                m_fMainRecvSync.wait();

                // -- 

                m_recvMessageList.Clear();
                m_recvMessageDictionary.Clear();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string makeKey(
            int sessionId,
            int stream,
            int function,
            UInt32 systemBytes
            )
        {
            try
            {
                if (ignoreSystemBytes)
                {
                    return string.Format(KeyFormat1, sessionId, stream, function);
                }
                return string.Format(KeyFormat2, sessionId, stream, function, systemBytes);
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

        private bool isKnownDevice(
            UInt16 sessionId
            )
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isExpectedBlock(
            FBlockInfo fBlockInfo
            )
        {
            try
            {
                return (fBlockInfo.isPrimary) ? isPrimaryExpectedBlock(fBlockInfo) : isSecondaryExpectedBlock(fBlockInfo);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
            
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isPrimaryExpectedBlock(
            FBlockInfo fBlockInfo
            )
        {
            string messageKey = string.Empty;
            FRecvBlockManager fRecvBlocks = null;

            try
            {
                messageKey = makeKey(fBlockInfo.sessionId, fBlockInfo.stream, fBlockInfo.function, fBlockInfo.systemBytes);
                fRecvBlocks = m_recvMessageDictionary[messageKey];
                
                // --

                // ***
                // 2016.09.07 by Jungyoul
                // Null 처리
                // ***
                if (fRecvBlocks != null)
                {
                    if (
                        fRecvBlocks.rbit == fBlockInfo.rbit &&
                        fRecvBlocks.sessionId == fBlockInfo.sessionId &&
                        !(ignoreSystemBytes == false && fRecvBlocks.systemBytes != fBlockInfo.systemBytes) &&
                        fRecvBlocks.wbit == fBlockInfo.wbit &&
                        fRecvBlocks.stream == fBlockInfo.stream &&
                        fRecvBlocks.function == fBlockInfo.function
                        )
                    {
                        if (fRecvBlocks.justRecvBlockNo == 0)
                        {
                            if (fBlockInfo.blockNo == 0 || fBlockInfo.blockNo == 1)
                            {
                                return true;
                            }
                        }
                        else if (fRecvBlocks.justRecvBlockNo + 1 == fBlockInfo.blockNo)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fRecvBlocks = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isSecondaryExpectedBlock(
            FBlockInfo fBlockInfo
            )
        {
            string messageKey = string.Empty;
            FRecvBlockManager fRecvBlocks = null;

            try
            {
                messageKey = makeKey(fBlockInfo.sessionId, fBlockInfo.stream, fBlockInfo.function, fBlockInfo.systemBytes);
                fRecvBlocks = getRecvBlockManager(messageKey, false);

                // --

                // ***
                // 2016.09.07 by Jungyoul
                // Null 처리
                // ***
                if (fRecvBlocks != null)
                {
                    if (
                        fRecvBlocks.sessionId == fBlockInfo.sessionId &&
                        !(ignoreSystemBytes == false && fRecvBlocks.systemBytes != fBlockInfo.systemBytes) &&
                        fRecvBlocks.stream == fBlockInfo.stream &&
                        fRecvBlocks.function == fBlockInfo.function
                        )
                    {
                        fRecvBlocks.rbit = fBlockInfo.rbit;

                        // --

                        if (fRecvBlocks.justRecvBlockNo == 0)
                        {
                            if (fBlockInfo.blockNo == 0 || fBlockInfo.blockNo == 1)
                            {
                                return true;
                            }
                        }
                        else if (fRecvBlocks.justRecvBlockNo + 1 == fBlockInfo.blockNo)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fRecvBlocks = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isDuplicate(
            FBlockInfo fBlockInfo
            )
        {
            string messageKey = string.Empty;
            FRecvBlockManager fRecvBlocks = null;

            try
            {
                messageKey = makeKey(fBlockInfo.sessionId, fBlockInfo.stream, fBlockInfo.function, fBlockInfo.systemBytes);
                fRecvBlocks = getRecvBlockManager(messageKey, false);

                // --

                // ***
                // 2016.09.07 by Jungyoul
                // Null 처리
                // ***
                if (fRecvBlocks != null)
                {
                    if (
                        fRecvBlocks.rbit == fBlockInfo.rbit &&
                        fRecvBlocks.sessionId == fBlockInfo.sessionId &&
                        fRecvBlocks.wbit == fBlockInfo.wbit &&
                        fRecvBlocks.stream == fBlockInfo.stream &&
                        fRecvBlocks.function == fBlockInfo.function &&
                        fRecvBlocks.systemBytes == fBlockInfo.systemBytes &&
                        fRecvBlocks.justRecvBlockNo == fBlockInfo.blockNo
                        )
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool isInterleave(
            string blockMessageKey
            )
        {
            bool isOccupied = false;
            string occupyMessageKey = string.Empty;

            try
            {
                isOccupied = false;
                foreach(KeyValuePair <string, FRecvBlockManager> occupyMessage in m_recvMessageDictionary)
                {
                    if (occupyMessage.Value.blockCount > 0)
                    {
                        occupyMessageKey = occupyMessage.Key;
                        isOccupied = true;
                        break;
                    }
                }

                // -- 

                if (isOccupied && occupyMessageKey != blockMessageKey)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FSendBlockManager getSendBlockManager(
            string messageKey
            )
        {
            try
            {
                if (!m_sendMessageDictionary.ContainsKey(messageKey))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_16900, messageKey));
                }
                return m_sendMessageDictionary[messageKey];
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

        //------------------------------------------------------------------------------------------------------------------------

        private FRecvBlockManager getRecvBlockManager(
            string messageKey,
            bool isKeyNotFoundError
            )
        {
            try
            {
                // ***
                // 2016.09.07 by Jungyoul
                // recvMessage가 없을 경우 처리 방식 변경
                // ***
                if (m_recvMessageDictionary.ContainsKey(messageKey))
                {
                    return m_recvMessageDictionary[messageKey];
                }
                else if (isKeyNotFoundError)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_16900, messageKey));
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        private void returnToIdle(
            )
        {
            try
            {
                m_fTmrT1.stop();
                m_fTmrT2.stop();
                // --
                m_fStatusType = FSecs1StatusType.Idle;
                m_isMessagingBlock = false;
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

        #region m_fSerial Object Event Handler

        private void m_fSerial_SerialStateChanged(
            object sender,
            FSerialStateChangedEventArgs e
            )
        {
            bool isConnected = false;

            try
            {
                m_fMainRecvSync.wait();

                // --

                this.serialPort = e.portName;
                this.baud = e.baudRate;

                // -- 

                if (e.fState == FSerialState.Opened)
                {
                    procStateOpened();
                    procStateConnected();
                    // --
                    isConnected = true;
                }
                else if (e.fState == FSerialState.Closed)
                {
                    procStateClosed();
                }

                // --

                // ***
                // 2016.05.02 by spike.lee
                // Auto Transmitter 처리 시 m_fMainSync가 Cross Lock되는 분제로 Selected 이벤트를 별도로 처리 함.                
                // ***
                if (isConnected)
                {
                    m_fMainRecvSync.set();
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
                    m_fMainRecvSync.set();
                }                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataReceived(
            object sender,
            FSerialDataReceivedEventArgs e
            )
        {
            try
            {
                m_fMainRecvSync.wait();
                
                // --
                
                procDataReceived(e.data);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSent(
            object sender,
            FSerialDataSentEventArgs e
            )
        {
            try
            {
                m_fMainRecvSync.wait();

                // --

                procDataSent(e.fData.data, e.fData.state);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialDataSendFailed(
            object sender,
            FSerialDataSendFailedEventArgs e
            )
        {
            try
            {
                m_fMainRecvSync.wait();

                // --

                procDataSendFailed(e.message, e.fData.state);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                m_fMainRecvSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fSerial_SerialErrorRaised(
            object sender,
            FSerialErrorRaisedEventArgs e
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
            string key = string.Empty;
            FRecvBlockManager fRecvBlocks = null;

            try
            {
                waited = m_fMainRecvSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --
                                
                if (m_fSerial == null || m_fSerial.fState != FSerialState.Opened)
                {
                    e.sleepThread(1);
                    return;
                }

                if (m_fDeviceState != FDeviceState.Selected)
                {
                    e.sleepThread(1);
                    return;
                }

                // --

                // ***
                // T4 Timer check
                // ***
                foreach (string messageKey in m_recvMessageList)
                {
                    fRecvBlocks = getRecvBlockManager(messageKey, false);

                    // ***
                    // 2016.09.07 by Jungyoul
                    // Null 처리
                    // ***
                    if (fRecvBlocks == null)
                    {
                        continue;
                    }

                    if (fRecvBlocks.fTmrT4.elasped(false))
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                        {
                            this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                this.getTimeoutMessage(FSecsDeviceTimeout.T4),
                                FSecsDeviceTimeout.T4,
                                this.getTimeoutDescription(FSecsDeviceTimeout.T4)
                                );
                        }
                        // --
                        closeRecvMessage(messageKey);
                        returnToIdle();
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
                               
                if (m_fStatusType == FSecs1StatusType.Idle)
                {
                    if (m_isMessagingBlock)
                    {
                        e.sleepThread(1);
                        return;
                    }

                    if (m_sendMessageList == null || m_sendMessageList.Count == 0)
                    {
                        e.sleepThread(1);
                        return;
                    }

                    // -- 
                    
                    m_isMessagingBlock = true;
                    // --
                    m_fStatusType = FSecs1StatusType.LineControl;
                    m_retryCounter = 0;
                    // --
                    sendENQ();
                    return;
                }
                else if (
                    m_fStatusType == FSecs1StatusType.LineControl ||
                    m_fStatusType == FSecs1StatusType.SendCompletion                    
                    )
                {
                    if (m_fTmrT2.elasped(false))
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                        {
                            this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                this.getTimeoutMessage(FSecsDeviceTimeout.T2),
                                FSecsDeviceTimeout.T2,
                                this.getTimeoutDescription(FSecsDeviceTimeout.T2)
                                );
                        }

                        // -- 

                        m_fStatusType = FSecs1StatusType.LineControl;
                        m_retryCounter++;
                        if (m_retryCounter > retryLimit)
                        {
                            closeSendMessage(m_sendMessageList[0]);
                            returnToIdle();
                            FDebug.throwFException(FConstants.err_m_16002);
                        }
                        else
                        {
                            sendENQ();
                        }
                        return;
                    }                    
                }
                else if (m_fStatusType == FSecs1StatusType.Receive)
                {
                    // ***
                    // T1 Timer check
                    // ***
                    if (m_fTmrT1.elasped(false))
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                        {
                            this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                this.getTimeoutMessage(FSecsDeviceTimeout.T1),
                                FSecsDeviceTimeout.T1,
                                this.getTimeoutDescription(FSecsDeviceTimeout.T1)
                                );
                        }
                        
                        // -- 
                        
                        sendNAK();
                        return;
                    }

                    // -- 

                    // ***
                    // T2 Timer check
                    // ***
                    if (m_fTmrT2.elasped(false))
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                        {
                            this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                this.getTimeoutMessage(FSecsDeviceTimeout.T2),
                                FSecsDeviceTimeout.T2,
                                this.getTimeoutDescription(FSecsDeviceTimeout.T2)
                                );
                        }
                        
                        // -- 
                        
                        sendNAK();
                        return;
                    }
                }
                else if (m_fStatusType == FSecs1StatusType.ReceiveCompletion)
                {
                    // ***
                    // T1 Timer check
                    // ***
                    if (m_fTmrT1.elasped(false))
                    {
                        if (fScdCore.fConfig.enabledEventsOfSecsDeviceTimeout)
                        {
                            this.fEventPusher.pushSecsDeviceTimeoutRaisedEvent(
                                this.fSecsDevice,
                                FResultCode.Error,
                                this.getTimeoutMessage(FSecsDeviceTimeout.T1),
                                FSecsDeviceTimeout.T1,
                                this.getTimeoutDescription(FSecsDeviceTimeout.T1)
                                );
                        }
                        
                        // -- 
                        
                        sendNAK();
                        return;
                    }                    
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
                    m_fMainRecvSync.set();
                }
            }
        }
                
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end