/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTCP.cs
--  Creator         : Sunghoon.Park
--  Create Date     : 2021.03.08
--  Description     : NexplantMC Core FaTcpDriver TCP Class 
--  History         : Created by Sunghoon.Park at 2021.03.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FTcp : IDisposable
    {

        private const int AutoCycleRunTime = 50;

        //--
        private bool m_disposed = false;

        private int m_transactionTimeout = 0;
        
        //--
        private FConnectMode m_fConnectMode = FConnectMode.Passive;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        private FTcpProtocol m_fTcpProtocol = null;
        private FITcpDeviceDriver m_fTcpDeviceDriver = null;

        //--
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;

        private FTcpOpenTransaction m_fTranDataMessage = null;
        private FIDPointer32 m_fTidPointer = null;

        //--
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrAutoCycle = null;
        private FStaticTimer m_fTmrT8 = null;

        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcp(
            FTcpProtocol fTcpProtocol
            )
        {
            m_fTcpProtocol = fTcpProtocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcp(
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
                    m_fTcpProtocol = null;
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
                    return m_fTcpProtocol.fTcdCore;
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
                    return m_fTcpProtocol.fProtocolAgent;
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
                    return m_fTcpProtocol.fTcdCore.fEventPusher;
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
                    return m_fTcpProtocol.fTcdCore.fTcpDriver;
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
                    return m_fTcpProtocol.fTcpDevice;
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

        #region Method 


        private void init(
            )
        {
            try
            {

                //--
                m_fTcpDeviceDriver = this.fTcpDevice.createTcpDeviceDriver();

                if (m_fTcpDeviceDriver == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0041, "Tcp Device Driver"));
                }

                //--
                //Tcp Device Driver Initialize
                m_fTcpDeviceDriver.TcpDeviceDriverStateChanged += new FTcpDeviceDriverStateChangedEventHandler(m_fTcpDeviceDriver_TcpDeviceDriverStateChanged);
                m_fTcpDeviceDriver.TcpDeviceDriverErrorRaised += new FTcpDeviceDriverErrorRaisedEventHandler(m_fTcpDeviceDriver_TcpDeviceDriverErrorRaised);



                //-- 
                m_fTidPointer = new FIDPointer32();
                m_transactionTimeout = this.fTcpDevice.t3Timeout * 1000;
                m_fTranDataMessage = new FTcpOpenTransaction(this.fTcpDriver, m_transactionTimeout);

                //--
                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FTcpMainThread");                
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

                //--
                if (m_fTcpDeviceDriver != null)
                {

                    m_fTcpDeviceDriver.TcpDeviceDriverStateChanged -= new FTcpDeviceDriverStateChangedEventHandler(m_fTcpDeviceDriver_TcpDeviceDriverStateChanged);
                    m_fTcpDeviceDriver.TcpDeviceDriverErrorRaised -= new FTcpDeviceDriverErrorRaisedEventHandler(m_fTcpDeviceDriver_TcpDeviceDriverErrorRaised);


                    m_fTcpDeviceDriver.Dispose();
                    m_fTcpDeviceDriver = null;
                }

                // --               
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

        public void open(
            )
        {
            try
            {
                //--
                m_fTcpDeviceDriver.open();

                //--
                procStateOpened();
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
                m_fTcpDeviceDriver.close();
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

        public void closeTcpClient(
            )
        {
            try
            {
                m_fTcpDeviceDriver.closeTcpClient();
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
            FTcpSession fSession, 
            FTcpMessageTransfer fMessageTransfer
            )
        {
            try
            {
                m_fTcpDeviceDriver.send(fSession, fMessageTransfer);
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
                    fXmlNodeTtrList = FTcp2.parseConnectionTrigger(this.fTcpDriver, this.fTcpDevice.fXmlNode, fState);

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

        public void clearRetryDataMessage(
            FXmlNode fXmlNodeTmgl
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

        public string getTimeoutDescription(
            FTcpDeviceTimeout fTimeout
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string getTimeoutMessage(
            FTcpDeviceTimeout fTimeout
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

            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procAccpted(
            FTcpClient fTcpClient
            )
        {
            try
            {

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

        public void procDataReceived(
            byte[] data
            )
        {
            try
            {

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

        public void procDataSendFailed(
            String message,
            object state
            )
        {
            try
            {

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

        public void procDataSent(
            byte[] data,
            object state
            )
        {
            try
            {

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

        public void procDeviceErrorRaised(
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

        public void procOpenTransaction(
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
                        fXmlNodeTtrList = FTcp2.parseTimeoutTrigger(this.fTcpDriver, fLog.fXmlNode, ref fXmlNodeRetryTcn);
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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procRetryDataMessage(
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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procStateClosed(
            )
        {
            try
            {
                //--
                this.changeDeviceState(FDeviceState.Opened);

                //--
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

        public void procStateConnected(
            )
        {
            try
            {
                //--
                this.changeDeviceState(FDeviceState.Connected);

                //--
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

        public void procStateOpened(
            )
        {
            try
            {

                //--
                this.changeDeviceState(FDeviceState.Opened);

                //--
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


                //--
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

        public void procStateSelected(
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

        public void recvDataMessage(
            )
        {
            try
            {

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

        public void resetResource(
            )
        {
            try
            {
                // ***
                // Timer, Transaction, Buffer 초기화
                // ***                
                m_fTmrT8.stop();
                m_fTranDataMessage.clearTransaction();

                //--
                //PSH Comment 
                //Recieve Buffer는 Driver에서 관리
                //m_fRecvBuf.clear();
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

        public void sendDataMessage(
            FTcpSession fTcpSession,
            FTcpMessageTransfer fTmt
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {

            }
        }
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region fTcpDeviceDriver Event Handler

        private void m_fTcpDeviceDriver_TcpDeviceDriverStateChanged(
            object sender,
            FTcpDeviceDriverStateChangedEventArgs e
            )
        {
            try
            {
                //--
                m_localIp = e.localIp;
                m_localPort = e.localPort;
                m_remoteIp = e.remoteIp;
                m_remotePort = e.remotePort;

                //--
                if(e.fState == FDeviceState.Closed)
                {
                    procStateClosed();
                }
                else if(e.fState == FDeviceState.Connected)
                {
                    procStateConnected();
                }
                else if (e.fState == FDeviceState.Opened)
                {
                    procStateOpened();
                }
                else if (e.fState == FDeviceState.Selected)
                {
                    procStateSelected();
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

        private void m_fTcpDeviceDriver_TcpDeviceDriverErrorRaised(
            object sender, 
            FTcpDeviceDriverErrorRaisedEventArgs e
            )
        {
            try
            {
                procDeviceErrorRaised(e.errorMessage);
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
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(object sender, FThreadEventArgs e)
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

                if (m_fTcpDeviceDriver.fTcpclient == null || m_fTcpDeviceDriver.fTcpclient.fState != FTcpClientState.Connected)
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
                        m_fTcpDeviceDriver.fTcpclient.reconnect();
                    }
                    else
                    {
                        m_fTcpDeviceDriver.fTcpclient.close();
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
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

    }
}
