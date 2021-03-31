/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepware.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.22
--  Description     : FAMate Core FaOpcDriver Kepware Class 
--  History         : Created by spike.lee at 2015.06.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using Nexplant.MC.Core.FaCommon;
using Kepware.ClientAce.OpcDaClient;
using Kepware.ClientAce.OpcCmn;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FKepware : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int AutoCycleRunTime = 50;    // 추후 설정 여부 판단
        private const int AutoTraceRunTime = 50;

        // --

        private bool m_disposed = false;
        // --        
        private FKepwareProtocol m_fKepwareProtocol = null;
        private FProtocol m_fProtocol = FProtocol.KEPWARE;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;        
        // --
        private string m_url = string.Empty;
        private string m_progId = string.Empty;
        private int m_clientHandle = 0;
        private string m_localId = string.Empty;
        private string m_itemNameFormat = string.Empty;
        private string m_browerItemNameFormat = string.Empty;
        private string m_defaultNamespace = string.Empty;
        private int m_keepAliveTime = 0;
        private int m_eventReloadTime = 0;
        //--
        private FSecurityPolicy m_fSecurityPolicy = FSecurityPolicy.None;
        private FSecurityMode m_fSecurityMode = FSecurityMode.Sign;
        private string m_certificateUrl = string.Empty;
        private string m_storeName = string.Empty;
        //--
        private int m_t2Timeout = 0;    // OPC Command Reply Timeout
        private int m_t3Timeout = 0;    // OPC Item Reset Timeout
        private int m_t5Timeout = 0;    // OPC Recconnect Timeout        
        // --
        private FIDPointer32 m_fTagRdTid = null;
        private FIDPointer32 m_fTagWtTid = null;
        // --
        private FKepwareBufferList m_fTagRdBufList = null;      // Timeout 처리 필요
        private FKepwareBufferList m_fTagWtBufList = null;      // Timeout 처리 필요
        // --        
        private FKepwareSubscriber m_fSysSubscriber = null;
        private FKepwareSubscriber m_fItmSubscriber = null;
        // --
        private FDelayMessageList m_fDelayMessageList = null;        
        private FStaticTimer m_fTmrErrorTagReload = null;
        // --
        private DaServerMgt m_opcServer = null;        
        // --        
        private FCodeLock m_fMainSync = null;
        private FThread m_fThdMain = null;
        private FStaticTimer m_fTmrReconnect = null;
        private FStaticTimer m_fTmrReselect = null;
        // --
        private bool m_isCompleteDataHandling = true;
        private FThread m_fThdSubscribeData = null;
        private FQueue<FKepwareSubscriberData> m_fQueueSubscribeData = null;

        // --

        private Dictionary<UInt64, FStaticTimer> m_fTmrTagReloadList = null;
        private Dictionary<UInt64, FStaticTimer> m_fTmrAutoCycleList = null;
        private Dictionary<UInt64, FStaticTimer> m_fTmrAutoTraceList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepware(            
            FKepwareProtocol fKepwareProtocol
            )  
        {
            m_fKepwareProtocol = fKepwareProtocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepware(
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
                    m_fKepwareProtocol = null;
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

        public FKepwareProtocol fKepwareProtocol
        {
            get
            {
                try
                {
                    return m_fKepwareProtocol;
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
                    return m_fKepwareProtocol.fProtocolAgent;
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

        public FOcdCore fOcdCore
        {
            get
            {
                try
                {
                    return m_fKepwareProtocol.fOcdCore;
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
                    return m_fKepwareProtocol.fOcdCore.fEventPusher;
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

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fKepwareProtocol.fOcdCore.fOpcDriver;
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

        public FOpcDevice fOpcDevice
        {
            get
            {
                try
                {
                    return m_fKepwareProtocol.fOpcDevice;
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

        public string url
        {
            get
            {
                try
                {
                    return m_url;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int clientHandle
        {
            get
            {
                try
                {
                    return m_clientHandle;
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

        public string localId
        {
            get
            {
                try
                {
                    return m_localId;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string defaultNamespace
        {
            get
            {
                try
                {
                    return m_defaultNamespace;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int keepAliveTime
        {
            get
            {
                try
                {
                    return m_keepAliveTime;
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

        public int eventReloadTime
        {
            get
            {
                try
                {
                    return m_eventReloadTime;
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

        //------------------------------------------------------------------------------------------------------------------------

        public int dataCount
        {
            get
            {
                try
                {                    
                    return m_fQueueSubscribeData.count;
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

        public bool isCompleteDataHandling
        {
            get
            {
                try
                {
                    if (this.dataCount == 0 && m_isCompleteDataHandling)
                    {
                        return true;
                    }
                    return false;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fProtocol = m_fKepwareProtocol.fOpcDevice.fProtocol;

                // --

                m_url = m_fKepwareProtocol.fOpcDevice.url;
                m_progId = m_fKepwareProtocol.fOpcDevice.progId;
                m_clientHandle = m_fKepwareProtocol.fOpcDevice.clientHandle;
                m_localId = m_fKepwareProtocol.fOpcDevice.localId;
                m_itemNameFormat = m_fKepwareProtocol.fOpcDevice.itemNameFormat;
                m_browerItemNameFormat = m_fKepwareProtocol.fOpcDevice.browerItemNameFormat;
                m_defaultNamespace = m_fKepwareProtocol.fOpcDevice.defaultNamespace;
                m_keepAliveTime = m_fKepwareProtocol.fOpcDevice.keepAliveTime * 1000;
                m_eventReloadTime = m_fKepwareProtocol.fOpcDevice.eventReloadTime * 1000;
                //--
                m_fSecurityPolicy = m_fKepwareProtocol.fOpcDevice.fSecurityPolicy;
                m_fSecurityMode = m_fKepwareProtocol.fOpcDevice.fSecurityMode;
                m_certificateUrl = m_fKepwareProtocol.fOpcDevice.certificateUrl;
                m_storeName = m_fKepwareProtocol.fOpcDevice.storeName;
                // --
                m_t2Timeout = (int)(m_fKepwareProtocol.fOpcDevice.t2Timeout * 1000);
                m_t3Timeout = m_fKepwareProtocol.fOpcDevice.t3Timeout * 1000;
                m_t5Timeout = m_fKepwareProtocol.fOpcDevice.t5Timeout * 1000;

                // --

                m_fQueueSubscribeData = new FQueue<FKepwareSubscriberData>();
                // --
                m_fTmrTagReloadList = new Dictionary<UInt64, FStaticTimer>();
                m_fTmrAutoCycleList = new Dictionary<UInt64, FStaticTimer>();
                m_fTmrAutoTraceList = new Dictionary<UInt64, FStaticTimer>();

                // --

                foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    m_fTmrAutoCycleList.Add(fOsn.uniqueId, new FStaticTimer());
                    m_fTmrAutoTraceList.Add(fOsn.uniqueId, new FStaticTimer());
                    m_fTmrTagReloadList.Add(fOsn.uniqueId, new FStaticTimer());
                }

                // --
                                
                m_fTmrReconnect = new FStaticTimer();
                m_fTmrReselect = new FStaticTimer();

                // --

                m_fMainSync = new FCodeLock();
                m_fThdMain = new FThread("FKepwareMainThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();

                // --

                m_fThdSubscribeData = new FThread("FKepwareSubscribeDataThread");                
                m_fThdSubscribeData.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdSubscribeData_ThreadJobCalled);
                m_fThdSubscribeData.start();
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
            FStaticTimer[] fStaticTimerArray = null;

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

                if (m_fThdSubscribeData != null)
                {
                    while (!this.isCompleteDataHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fThdSubscribeData.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdSubscribeData_ThreadJobCalled);
                    // --
                    m_fThdSubscribeData.stop();
                    m_fThdSubscribeData.Dispose();
                    m_fThdSubscribeData = null;
                }
                                       
                // --

                if (m_opcServer != null)
                {
                    m_opcServer.ServerStateChanged -= new DaServerMgt.ServerStateChangedEventHandler(m_opcServer_ServerStateChanged);
                    m_opcServer.DataChanged -= new DaServerMgt.DataChangedEventHandler(m_opcServer_DataChanged);
                    m_opcServer.ReadCompleted -= new DaServerMgt.ReadCompletedEventHandler(m_opcServer_ReadCompleted);
                    m_opcServer.WriteCompleted -= new DaServerMgt.WriteCompletedEventHandler(m_opcServer_WriteCompleted);
                    // --
                    if (m_opcServer.IsConnected)
                    {
                        m_opcServer.Disconnect();
                    }
                    // --
                    m_opcServer.Dispose();
                    m_opcServer = null;
                }

                // --

                if (m_fTmrAutoCycleList != null)
                {
                    fStaticTimerArray = new FStaticTimer[m_fTmrAutoCycleList.Count];
                    m_fTmrAutoCycleList.Values.CopyTo(fStaticTimerArray, 0);
                    m_fTmrAutoCycleList.Clear();
                    m_fTmrAutoCycleList = null;

                    for (int i = 0; i < fStaticTimerArray.Length; i++)
                    {
                        fStaticTimerArray[i].Dispose();
                        fStaticTimerArray[i] = null;
                    }
                }

                // --

                if (m_fTmrAutoTraceList != null)
                {
                    fStaticTimerArray = new FStaticTimer[m_fTmrAutoTraceList.Count];
                    m_fTmrAutoTraceList.Values.CopyTo(fStaticTimerArray, 0);
                    m_fTmrAutoTraceList.Clear();
                    m_fTmrAutoTraceList = null;

                    for (int i = 0; i < fStaticTimerArray.Length; i++)
                    {
                        fStaticTimerArray[i].Dispose();
                        fStaticTimerArray[i] = null;
                    }
                    
                }

                // --

                if (m_fTmrReconnect != null)
                {
                    m_fTmrReconnect.Dispose();
                    m_fTmrReconnect = null;
                }            
    
                // --

                if (m_fTmrReselect != null)
                {
                    m_fTmrReselect.Dispose();
                    m_fTmrReselect = null;
                }

                // --

                if (m_fMainSync != null)
                {
                    m_fMainSync.Dispose();
                    m_fMainSync = null;
                }

                // --

                if (m_fQueueSubscribeData != null)
                {
                    m_fQueueSubscribeData.Dispose();
                    m_fQueueSubscribeData = null;
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

        private void initOpcServer(
            )
        {
            try
            {
                if (m_opcServer != null)
                {   
                    if (m_opcServer.IsConnected)
                    {
                        m_opcServer.Disconnect();
                    }                     
                    return;
                }

                // --

                m_opcServer = new DaServerMgt();
                // --
                m_opcServer.ServerStateChanged += new DaServerMgt.ServerStateChangedEventHandler(m_opcServer_ServerStateChanged);
                m_opcServer.DataChanged += new DaServerMgt.DataChangedEventHandler(m_opcServer_DataChanged);
                m_opcServer.ReadCompleted += new DaServerMgt.ReadCompletedEventHandler(m_opcServer_ReadCompleted);
                m_opcServer.WriteCompleted += new DaServerMgt.WriteCompletedEventHandler(m_opcServer_WriteCompleted);
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

        private void termOpcServer(
            )
        {
            try
            {
                if (m_opcServer == null)
                {
                    return;
                }

                // --

                m_opcServer.ServerStateChanged -= new DaServerMgt.ServerStateChangedEventHandler(m_opcServer_ServerStateChanged);
                m_opcServer.DataChanged -= new DaServerMgt.DataChangedEventHandler(m_opcServer_DataChanged);
                m_opcServer.ReadCompleted -= new DaServerMgt.ReadCompletedEventHandler(m_opcServer_ReadCompleted);
                m_opcServer.WriteCompleted -= new DaServerMgt.WriteCompletedEventHandler(m_opcServer_WriteCompleted);
                // --
                if (m_opcServer.IsConnected)
                {
                    m_opcServer.Disconnect();
                }
                // --
                m_opcServer.Dispose();
                m_opcServer = null;
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
            try
            {
                m_fDeviceState = fState;

                // --

                this.fOpcDevice.changeState(fState);
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

        private void changeSessionState(
            FSessionState fState
            )
        {
            try
            {   
                foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    fOsn.changeState(fState);
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

        private void changeSessionState(
            FOpcSession fOpcSession,
            FSessionState fState
            )
        {
            try
            {
                fOpcSession.changeState(fState);
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

        private void raiseConnectionTrigger(
            FDeviceState fState
            )
        {
            FOpcDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeOtrList = null;

            try
            {
                // ***
                // Trigger Parse
                // ***
                if (this.fOcdCore.fOpcDriver.enabledEventsOfScenario)
                {
                    fXmlNodeOtrList = FKepware2.parseConnectionTrigger(this.fOpcDriver, this.fOpcDevice.fXmlNode, fState);
                    // --

                    fLog = new FOpcDeviceStateChangedLog(
                        FOpcDriverLogCommon.createXmlNodeODVL(this.fOpcDevice.fXmlNode, FXmlTagODVL.L_StateChanged)
                        );

                    // --

                    foreach (FXmlNode fXmlNodeOtr in fXmlNodeOtrList)
                    {
                        this.fEventPusher.pushOpcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeOtr, fLog);
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

        // Add by Jeff.Kim 2015.10.08
        // Session 별 Connection State 처리를 위해 추가
        private void raiseSessionConnectionTrigger(
            FOpcSession fOsn,
            FDeviceState fState
            )
        {
            FOpcDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeOtrList = null;

            try
            {
                // ***
                // Trigger Parse
                // ***
                if (this.fOcdCore.fOpcDriver.enabledEventsOfScenario)
                {
                    fXmlNodeOtrList = FKepware2.parseConnectionTrigger2(this.fOpcDriver, fOsn, this.fOpcDevice.fXmlNode, fState);
                    fLog = new FOpcDeviceStateChangedLog(
                        FOpcDriverLogCommon.createXmlNodeODVL(this.fOpcDevice.fXmlNode, FXmlTagODVL.L_StateChanged)
                        );

                    // --

                    foreach (FXmlNode fXmlNodeOtr in fXmlNodeOtrList)
                    {
                        this.fEventPusher.pushOpcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeOtr, fLog);
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

        public void open(
            )
        {
            try
            {
                m_fTagRdTid = new FIDPointer32();
                m_fTagRdTid.reset(1, 65535, 1);
                // --
                m_fTagWtTid = new FIDPointer32();
                m_fTagWtTid.reset(1, 65535, 1);

                // -- 

                m_fTagRdBufList = new FKepwareBufferList();
                m_fTagWtBufList = new FKepwareBufferList();

                // --

                // Add by Jeff.Kim 2015.10.06
                // System.ErrorTag 분리
                m_fItmSubscriber = new FKepwareSubscriber();
                m_fSysSubscriber = new FKepwareSubscriber();

                // --

                m_fTmrErrorTagReload = new FStaticTimer();
                m_fDelayMessageList = new FDelayMessageList();

                // --

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
            FStaticTimer[] fStaticTimerList = null;
            int cnt = 0;

            try
            {
                m_fMainSync.wait();

                // --

                if (m_opcServer.IsConnected)
                {
                    if (this.fDeviceState == FDeviceState.Connected)
                    {
                        if (fOcdCore.fConfig.enabledEventsOfScenario)
                        {
                            // ***
                            // Auto Action First Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runOpcAutoActionFirstCloseTransmitter(this.fOpcDevice);

                            // ***
                            // Auto Action Always Close Transmitter 처리
                            // ***
                            this.fProtocolAgent.runOpcAutoActionAlwaysCloseTransmitter(this.fOpcDevice);
                        }

                        // --

                        while (m_fTagRdBufList.count > 0 || m_fTagWtBufList.count > 0)
                        {
                            System.Threading.Thread.Sleep(100);
                            cnt++;
                            if (cnt > 10)
                            {
                                break;
                            }
                        }

                        // --

                        // ***
                        // 2016.12.21 by spike.lee
                        // 모든 Event를 처리하고 Close 하도록 수정
                        // ***
                        while (this.fEventPusher.eventCount > 0)
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

                termOpcServer();

                // --

                procStateClosed();

                // --

                if (m_fTagRdTid != null)
                {
                    m_fTagRdTid.Dispose();
                    m_fTagRdTid = null;
                }
                // --
                if (m_fTagWtTid != null)
                {
                    m_fTagWtTid.Dispose();
                    m_fTagWtTid = null;
                }

                // --

                if (m_fTagRdBufList != null)
                {
                    m_fTagRdBufList.Dispose();
                    m_fTagRdBufList = null;
                }
                // --
                if (m_fTagWtBufList != null)
                {
                    m_fTagWtBufList.Dispose();
                    m_fTagWtBufList = null;
                }

                // --

                // Add by Jeff.Kim 2015.10.06
                // System.ErrorTag 분리
                if (m_fItmSubscriber != null)
                {
                    m_fItmSubscriber.Dispose();
                    m_fItmSubscriber = null;
                }
                // --
                if (m_fSysSubscriber != null)
                {
                    m_fSysSubscriber.Dispose();
                    m_fSysSubscriber = null;
                }

                // --

                if (m_fTmrTagReloadList != null)
                {
                    fStaticTimerList = new FStaticTimer[m_fTmrTagReloadList.Count];
                    m_fTmrTagReloadList.Values.CopyTo(fStaticTimerList, 0);
                    m_fTmrTagReloadList.Clear();
                    m_fTmrTagReloadList = null;

                    for (int i = 0; i < fStaticTimerList.Length; i++)
                    {
                        fStaticTimerList[i].Dispose();
                        fStaticTimerList[i] = null;
                    }
                }
                // --
                if (m_fTmrErrorTagReload != null)
                {
                    m_fTmrErrorTagReload.Dispose();
                    m_fTmrErrorTagReload = null;
                }
                // --
                if (m_fDelayMessageList != null)
                {
                    m_fDelayMessageList.Dispose();
                    m_fDelayMessageList = null;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fMainSync.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void write(
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOpcMessageTransfer
            )
        {
            try
            {
                if (fOpcSession.fState != FSessionState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Session"));
                }

                // --

                if (fOpcMessageTransfer.fOpcMessageTransferAreaType == FOpcMessageTransferAreaType.Unknown)
                {
                    fOpcMessageTransfer.fOpcMessageTransferAreaType = FOpcMessageTransferAreaType.Write;
                }
                // --
                requestMessageWrite(fOpcSession, fOpcMessageTransfer);
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
            FOpcSession fOpcSession,
            FOpcMessageTransfer fOpcMessageTransfer
            )
        {
            FOpcMessageTransfer fOmt = null;
            FXmlNode fXmlNodeOmt = null;
            int oeiCount = 0;
            int index = 0;

            try
            {
                if (fOpcSession.fState != FSessionState.Selected)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0030, "Session"));
                }

                // --

                if (fOpcMessageTransfer.fOpcMessageTransferAreaType == FOpcMessageTransferAreaType.Unknown)
                {
                    fOpcMessageTransfer.fOpcMessageTransferAreaType = FOpcMessageTransferAreaType.Read;
                }

                // --

                oeiCount = fOpcMessageTransfer.fChildEventItemListCollection[0].fChildOpcEventItemCollection.count;
                // --
                if (oeiCount > 1)
                {
                    fXmlNodeOmt = fOpcMessageTransfer.fXmlNode.clone(true);
                    // --
                    for (int i = 0; i < oeiCount; i++)
                    {
                        fOmt = new FOpcMessageTransfer(FOpcMessageTransferAreaType.Read, this.fOcdCore, fXmlNodeOmt.clone(true));
                        index = 0;
                        // --
                        foreach (FOpcEventItem fOei in fOmt.fChildEventItemListCollection[0].fChildOpcEventItemCollection)
                        {
                            if (i != index)
                            {
                                fOei.remove();
                            }
                            index++;
                        }
                        // --
                        requestMessageRead(fOpcSession, fOmt);
                    }
                }
                else
                {
                    requestMessageRead(fOpcSession, fOpcMessageTransfer);
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

        public void refreshOpcSessionItemName(
            FOpcSession fOpcSession
            )
        {
            string cp = string.Empty;
            int[] propid = null;
            bool more = false;
            BrowseElement[] beList = null;
            string itemName = string.Empty;
            FTagFormat fItemFormat = FTagFormat.String;
            bool isArray = false;
            FXmlNode fXmlNodeItn = null;

            try
            {
                // ***
                // Modified by spike.lee at 2016.01.19
                // OPC UA와 OPC DA의 Browse 방식 이원화
                // *** 
                itemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.BrowerDaItemNameFormat, fOpcSession.channel) :
                    string.Format(m_browerItemNameFormat, m_defaultNamespace, fOpcSession.channel);
                // --
                m_opcServer.Browse(itemName, "", ref cp, 0, BrowseFilter.ITEM, propid, true, true, out beList, out more);

                // -- 

                if (beList == null)
                {
                    return;
                }

                // --

                foreach (FXmlNode x in fOpcSession.fXmlNode.selectNodes(FXmlTagITN.E_ItemName))
                {
                    fOpcSession.fXmlNode.removeChild(x);
                }

                // --

                foreach (BrowseElement be in beList)
                {
                    FKepware2.parseItemName(be, ref itemName, ref fItemFormat, ref isArray);

                    // --

                    fXmlNodeItn = FOpcDriverCommon.createXmlNodeITN(
                        this.fOcdCore.fXmlDoc,
                        this.fOcdCore.fIdPointer.uniqueId.ToString(),
                        itemName,
                        FEnumConverter.fromTagFormat(fItemFormat),
                        FBoolean.fromBool(isArray)
                        );
                    fOpcSession.fXmlNode.appendChild(fXmlNodeItn);
                }

                // --

                this.fOcdCore.fEventPusher.pushOpcSessionItemNameRefreshedEvent(fOpcSession);
                this.fOcdCore.fEventPusher.pushEvent(
                    new FObjectEventArgs(
                        FEventId.ObjectModifyCompleted,
                        this.fOcdCore.fOpcDriver,
                        this.fOpcDevice,
                        fOpcSession
                        )
                    );
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

        private void procStateOpened(
            )
        {
            try
            {
                m_fItmSubscriber.init();
                m_fSysSubscriber.init();
                m_fDelayMessageList.clear();
                m_fTagRdBufList.clear();
                m_fTagWtBufList.clear();

                // --

                this.changeDeviceState(FDeviceState.Opened);
                this.changeSessionState(FSessionState.Opened);
                // --
                if (fOpcDriver.fOcdCore.fConfig.enabledEventsOfOpcDeviceState)
                {
                    this.fEventPusher.pushOpcDeviceStateChangedEvent(
                        this.fOpcDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }

                // --             

                raiseConnectionTrigger(FDeviceState.Opened);

                // --

                // ***
                // Auto Cycle Run Time 중지
                // ***
                this.fProtocolAgent.clearOpcAutoCycleTransmitter(this.fOpcDevice);
                foreach (FOpcSession fosn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    if (m_fTmrAutoCycleList.ContainsKey(fosn.uniqueId))
                    {
                        m_fTmrAutoCycleList[fosn.uniqueId].stop();
                    }
                }

                // --

                // ***
                // Auto Trace Run Time 중지
                // ***
                this.fProtocolAgent.clearAutoTraceMessage(this.fOpcDevice);
                foreach (FOpcSession fosn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    if (m_fTmrAutoTraceList.ContainsKey(fosn.uniqueId))
                    {
                        m_fTmrAutoTraceList[fosn.uniqueId].stop();
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

        private void procStateConnected(
            )
        {

            // ***
            // OPC DA 관련 객체
            // ***
            OpcServerEnum opcServerEnum = null;
            ServerIdentifier[] availableOPCServers;
            string daUrl = string.Empty;
            // --
            ConnectInfo connectInfo = new ConnectInfo();
            bool connectFailed = false;

            //--
            PkiCertificate clientCert = null;
            string security_Url = "http://opcfoundation.org/UA/SecurityPolicy#";
            byte securityMode;
            byte[] serverCertificate;

            try
            {
                try
                {
                    initOpcServer();

                    // --

                    connectInfo = new ConnectInfo(m_localId, false, true, m_keepAliveTime);

                    // --

                    // ***
                    // Modified by spike.ee at 2016.01.19
                    // OPC DA Connect 기능 추가
                    // ***
                    if (m_fProtocol == FProtocol.OPCDA)
                    {
                        // ***
                        // OPD DA 서버 목록 검색 
                        // *** 
                        opcServerEnum = new OpcServerEnum();
                        opcServerEnum.EnumComServer(
                            m_url,
                            false,
                            new ServerCategory[] { ServerCategory.OPCDA },
                            out availableOPCServers
                            );

                        // --

                        connectFailed = true;
                        if (availableOPCServers.Length > 0)
                        {
                            // ***
                            // ProgID를 포함하고 있으면 OPC DA Server의 Url를 검색한다.
                            // ***
                            foreach (ServerIdentifier opcServer in availableOPCServers)
                            {
                                if (opcServer.ProgID.Contains(m_progId))
                                {
                                    daUrl = opcServer.Url;
                                    connectFailed = false;
                                    break;
                                }
                            }

                            // --

                            if (!connectFailed)
                            {
                                m_opcServer.Connect(daUrl, m_clientHandle, ref connectInfo, out connectFailed);
                            }
                        }
                    }
                    else
                    {
                        // ***
                        // KEPWARE와 OPCUA
                        // ***


                        // ***
                        // 2019.06.27 at Sunghoon.Park Kepware Security Policy 지원
                        // ***
                        security_Url = security_Url + m_fSecurityPolicy.ToString();

                        if (m_fSecurityPolicy == FSecurityPolicy.Basic128Rsa15 || m_fSecurityPolicy == FSecurityPolicy.Basic256)
                        {

                            securityMode = (byte)m_fSecurityMode;

                            //--
                            //get Server Certificate
                            opcServerEnum = new OpcServerEnum();
                            opcServerEnum.getCertificateForEndpoint(m_url, security_Url, securityMode, out serverCertificate);
                            connectInfo.ServerCertificate = serverCertificate;

                            //get Client Certificate
                            clientCert = PkiCertificate.fromWindowsStoreWithPrivateKey(WinStoreLocation.CurrentUser
                                                                             , m_storeName
                                                                             , m_certificateUrl);
                            connectInfo.ClientCertificate = clientCert.toDER();
                            connectInfo.ClientPrivateKey = clientCert.PrivateKey;
                            //--
                            connectInfo.SecurityPolicyUri = security_Url;
                            connectInfo.MessageSecurityMode = securityMode;
                            connectInfo.CertificateStoreName = m_storeName;
                            connectInfo.CertificateStoreLocation = WinStoreLocation.CurrentUser;
                        }
                        else
                        {
                            securityMode = 1; // 1: None
                            connectInfo.SecurityPolicyUri = security_Url;
                            connectInfo.MessageSecurityMode = securityMode;
                        }

                        //--

                        m_opcServer.Connect(m_url, m_clientHandle, ref connectInfo, out connectFailed);
                    }

                    // --

                    if (connectFailed)
                    {
                        m_fTmrReconnect.start(1000);
                        return;
                    }
                    m_fTmrReconnect.stop();
                }
                catch (Exception opcEX)
                {
                    System.Diagnostics.Debug.WriteLine(opcEX.ToString());

                    m_fTmrReconnect.start(1000);
                    return;
                }

                // --                

                this.changeDeviceState(FDeviceState.Connected);
                this.changeSessionState(FSessionState.Connected);
                // --
                if (this.fOpcDriver.fOcdCore.fConfig.enabledEventsOfOpcDeviceState)
                {
                    this.fEventPusher.pushOpcDeviceStateChangedEvent(
                        this.fOpcDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }

                // --

                raiseConnectionTrigger(FDeviceState.Connected);
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
            }
            finally
            {
                if (opcServerEnum != null)
                {
                    opcServerEnum.Dispose();
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procStateSelected(
            FOpcSession fOpcSession
            )
        {
            bool sessionConnected = true;

            try
            {
                // --
                // Add by Jeff.Kim 2015.10.10
                // PLC 연결시에 기존 Auto trace 가 존재 한다면, Tick을 현재 Tick으로 Reset 한다.                 
                if (fOpcSession.fState != FSessionState.Selected)
                {
                    this.fProtocolAgent.resetOpcAutoTraceMessage(fOpcSession);
                }

                // --

                this.changeSessionState(fOpcSession, FSessionState.Selected);

                // --

                // Modify by Jeff.Kim 2015.10.07
                // Device의 상태의 Kepware Server와의 연결까지만 확인하면 되므로,
                // Selected 는 Session 기준으로 관리한다. 
                foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    if (fOsn.fState != FSessionState.Selected)
                    {
                        sessionConnected = false;
                        break;
                    }
                }

                // --
                // Modify by Jeff.Kim 2015.10.07
                // Session 중에 하나라도 PLC가 연결 되지 않았다면 Device상태는 Selected 상태로 
                // 만들지 않는다. 
                if (sessionConnected && fOpcDevice.fState == FDeviceState.Connected)
                {
                    this.changeDeviceState(FDeviceState.Selected);

                    //--

                    if (fOpcDriver.fOcdCore.fConfig.enabledEventsOfOpcDeviceState)
                    {
                        this.fEventPusher.pushOpcDeviceStateChangedEvent(
                            this.fOpcDevice,
                            FResultCode.Success,
                            string.Empty
                            );
                    }
                }

                // --                

                raiseSessionConnectionTrigger(fOpcSession, FDeviceState.Selected);

                // --

                if (this.fOcdCore.fConfig.enabledEventsOfScenario)
                {
                    // ***
                    // Auto Action First Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runOpcAutoActionFirstSelectTransmitter(this.fOpcDevice, fOpcSession);

                    // ***
                    // Auto Action Always Select Transmitter 처리
                    // ***
                    this.fProtocolAgent.runOpcAutoActionAlwaysSelectTransmitter(this.fOpcDevice, fOpcSession);
                }

                // --

                // ***
                // Auto Cycle Run Time 실행
                // ***                
                if (!m_fTmrAutoCycleList[fOpcSession.uniqueId].enabled)
                {
                    m_fTmrAutoCycleList[fOpcSession.uniqueId].start(AutoCycleRunTime);
                }
                else
                {
                    m_fTmrAutoCycleList[fOpcSession.uniqueId].restart();
                }

                // --

                // ***
                // Auto Trace Run Time 실행
                // ***
                if (!m_fTmrAutoTraceList[fOpcSession.uniqueId].enabled)
                {
                    m_fTmrAutoTraceList[fOpcSession.uniqueId].start(AutoTraceRunTime);
                }
                else
                {
                    m_fTmrAutoTraceList[fOpcSession.uniqueId].restart();
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
                this.changeSessionState(FSessionState.Closed);
                // --
                if (this.fOpcDriver.fOcdCore.fConfig.enabledEventsOfOpcDeviceState)
                {
                    this.fEventPusher.pushOpcDeviceStateChangedEvent(
                        this.fOpcDevice,
                        FResultCode.Success,
                        string.Empty
                        );
                }

                // --

                raiseConnectionTrigger(FDeviceState.Closed);
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

        private void requestSessionClose(
            FOpcSession fOpcSession,
            FKepwareSession fKepwareSession
            )
        {
            try
            {
                if (this.fOpcDevice.fState != FDeviceState.Connected)
                {
                    this.changeDeviceState(FDeviceState.Connected);
                    if (this.fOpcDriver.fOcdCore.fConfig.enabledEventsOfOpcDeviceState)
                    {
                        this.fEventPusher.pushOpcDeviceStateChangedEvent(
                            this.fOpcDevice,
                            FResultCode.Success,
                            string.Empty
                            );
                    }
                }

                // --

                if (fOpcSession != null)
                {
                    this.changeSessionState(fOpcSession, FSessionState.Connected);
                    raiseSessionConnectionTrigger(fOpcSession, FDeviceState.Connected);
                }

                // --

                // Add by Jeff.Kim 2015.10.06
                // Connected로 갈경우 OpcEventItem에 대한 Subscribe를 초기화
                if (fKepwareSession != null)
                {
                    requestItemTagSubscriptionCancel(fKepwareSession);
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

        private void procItemTagDataChanged(
            int clientSubscription,
            bool allQualitiesGood,
            bool noErrors,
            ItemValueCallback[] itemValues
            )
        {
            FKepwareSession fKepSession = null;
            FOpcSession fOpcSession = null;
            string info = string.Empty;

            try
            {
                if (!m_fItmSubscriber.fSessionList.TryGetValue((UInt64)clientSubscription, out fKepSession))
                {
                    return;
                }

                // --

                // Add by Jeff.Kim 2015.10.08
                foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    if (fKepSession.osnOriginalUniqueId == fOsn.uniqueId)
                    {
                        fOpcSession = fOsn;
                        break;
                    }
                }

                // --

                if (fOpcSession != null) { 
                    if (!allQualitiesGood)
                    {
                        info = "OpcSession=" + fOpcSession.name + ", allQualitiesGood=" + allQualitiesGood.ToString();
                        FDebug.throwFException(string.Format(FConstants.err_m_0039, "Subscribe error", info));
                    }
                    // --             
                    if (fOpcSession.fState == FSessionState.Selected)
                    {
                        requestItemTagParsing(fKepSession, itemValues);
                    }
                }

                // --

                fKepSession.completed = true;
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
                // 21.02.19 by MjKIM
                // Session을 끊을 필요가 있을까 고민 중,..  동일한 에러가 계속 발생한다라고 하면, sessionClose() 해야 함
                //if (m_fDeviceState == FDeviceState.Selected)
                //{
                //    requestSessionClose(fOpcSession, fKepSession);
                //}

                // --

                fKepSession.completed = false;
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSystemTagDataChanged(
            int clientSubscription,
            bool allQualitiesGood,
            bool noErrors,
            ItemValueCallback[] itemValues
            )
        {
            FKepwareSession fKepSession = null;
            string info = string.Empty;

            try
            {
                if (!m_fSysSubscriber.enabled ||
                    !m_fSysSubscriber.fSessionList.TryGetValue((UInt64)clientSubscription, out fKepSession))
                {
                    return;
                }

                // --

                if (!allQualitiesGood)
                {
                    info = "System Subscribe" + ", allQualitiesGood=" + allQualitiesGood.ToString();
                    FDebug.throwFException(string.Format(FConstants.err_m_0039, "Subscribe error", info));
                }

                // --

                foreach (ItemValueCallback v in itemValues)
                {
                    FKepwareItem fItem = fKepSession.fItemList[(UInt64)v.ClientHandle];
                    foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                    {
                        if (fItem.itemName.Contains(fOsn.channel))
                        {
                            if (v.Value == null || (bool)v.Value)
                            {
                                if (fOsn.fState == FSessionState.Selected &&
                                    fItem.itemName.Contains(FConstants.SystemErrorTagName))
                                {
                                    requestSessionClose(
                                        fOsn,
                                        m_fItmSubscriber.fSessionList.ContainsKey((UInt64)v.ClientHandle) ? m_fItmSubscriber.fSessionList[(UInt64)v.ClientHandle] : null
                                        );
                                }
                            }
                            else
                            {
                                if (fOsn.fState == FSessionState.Connected)
                                {
                                    procStateSelected(fOsn);
                                }
                            }
                        }
                    }
                }

                // --  

                fKepSession.completed = true;
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);

                // --  

                fKepSession.completed = false;
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDataRead(
            FKepwareBuffer fRdBuf
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            bool isEvent = false;
            FXmlNode fXmlNodeOmgl = null;
            FXmlNode fXmlNodeOmgRep = null;
            FOpcMessage fOmgRep = null;
            FOpcMessageTransfer fOmtRep = null;
            FOpcDeviceDataMessageReadLog fLog = null;
            // --
            FXmlNode[] fXmlNodeOtrList = null;

            try
            {
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;

                // --

                // ***
                // Read Message Parsing
                // ***
                fXmlNodeOmgl = FKepware2.parseOpcRead(
                    fRdBuf,
                    ref fResultCode,
                    ref resultMessage,
                    ref isEvent
                    );
                fLog = this.fEventPusher.createOpcDeviceDataMessageReadLog(fRdBuf.fOpcSession.fXmlNode, fXmlNodeOmgl);

                // --                

                if (this.fOcdCore.fConfig.enabledEventsOfOpcDeviceDataMessage)
                {
                    this.fEventPusher.pushOpcDeviceDataMessageReadEvent(this.fOpcDevice, fResultCode, resultMessage, fLog);
                }

                // --            

                if (
                    fResultCode != FResultCode.Success &&
                    !FBoolean.toBool(fXmlNodeOmgl.get_attrVal(FXmlTagOMGL.A_IgnoreReadResult, FXmlTagOMGL.D_IgnoreReadResult))
                    )
                {
                    return;
                }

                // --

                if (isEvent && fLog.isPrimary)
                {
                    fXmlNodeOmgRep = FKepware2.getReplyMessage(fRdBuf.fOpcSession, fLog.uniqueIdToString);
                    if (fXmlNodeOmgRep != null)
                    {
                        fOmgRep = new FOpcMessage(this.fOcdCore, fXmlNodeOmgRep);
                        if (fOmgRep.autoReply)
                        {
                            fOmtRep = fOmgRep.createTransfer();
                            FOpcDriverCommon.setOpcItemRandomValue(fOmtRep.fXmlNode);

                            // ***
                            // 시나리오를 진행하기 위해 Try Catch 처리 필요한지 점검
                            // ***
                            requestMessageWrite(fRdBuf.fOpcSession, fOmtRep);
                        }
                    }
                }

                // --

                // ***
                // OPC Trigger Parsing
                // ***
                if (this.fOcdCore.fOpcDriver.enabledEventsOfScenario)
                {
                    fXmlNodeOtrList = FKepware2.parseExpressionTrigger(this.fOpcDriver, fXmlNodeOmgl);
                    foreach (FXmlNode fXmlNodeOtr in fXmlNodeOtrList)
                    {
                        this.fEventPusher.pushOpcTriggerRaisedEvent(FResultCode.Success, string.Empty, fXmlNodeOtr, fLog);
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

        private void procDataWritten(
            FKepwareBuffer fWtBuf
            )
        {
            FResultCode fResultCode = FResultCode.Success;
            string resultMessage = string.Empty;
            FXmlNode fXmlNodeOmgl = null;
            FOpcDeviceDataMessageWrittenLog fLog = null;

            try
            {
                fResultCode = FResultCode.Success;
                resultMessage = string.Empty;

                // --

                // ***
                // Write Message Result Paring
                // ***
                fXmlNodeOmgl = FKepware2.parseOpcWritten(
                    fWtBuf,
                    ref fResultCode,
                    ref resultMessage
                    );
                fLog = this.fEventPusher.createOpcDeviceDataMessageWrittenLog(fWtBuf.fOpcSession.fXmlNode, fXmlNodeOmgl);

                // --                

                if (this.fOcdCore.fConfig.enabledEventsOfOpcDeviceDataMessage)
                {
                    this.fEventPusher.pushOpcDeviceDataMessageWrittenEvent(this.fOpcDevice, fResultCode, resultMessage, fLog);
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

        private void procDeviceErrorRaised(
            Exception inEx
            )
        {
            try
            {
                FDebug.writeLog(inEx);
                // --
                if (this.fOcdCore.fConfig.enabledEventsOfOpcDeviceError)
                {
                    this.fEventPusher.pushOpcDeviceErrorRaisedEvent(this.fOpcDevice, FResultCode.Error, inEx.Message);
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

        private void requestMessageRead(
            FOpcSession fOsn,
            FOpcMessageTransfer fOmt
            )
        {
            UInt32 tid = 0;
            FKepwareBuffer fTagRdBuf = null;            
            ItemIdentifier tagId = null;
            ItemIdentifier[] tagIdList = null;    

            try
            {
                tid = m_fTagRdTid.uniqueId;
                fTagRdBuf = new FKepwareBuffer(fOsn, fOmt);

                // --

                // ***
                // OPC Event Item Read
                // ***
                foreach (FOpcEventItem fOei in fOmt.fChildEventItemListCollection[0].fChildOpcEventItemCollection)
                {
                    tagId = new ItemIdentifier();
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    tagId.ItemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, fOei.itemName) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, fOei.itemName);
                    tagId.ClientHandle = fOei.uniqueId; 
                    // --
                    fTagRdBuf.opcIdList.Add(tagId);
                }
                
                // --

                // ***
                // OPC Item Read
                // ***
                foreach (FOpcItem fOit in fOmt.fChildOpcItemListCollection[0].fChildOpcItemCollection)
                {
                    tagId = new ItemIdentifier();
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    tagId.ItemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, fOit.itemName) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, fOit.itemName);
                    tagId.ClientHandle = fOit.uniqueId;                    
                    // --
                    fTagRdBuf.opcIdList.Add(tagId);
                }                
                
                // --

                m_fTagRdBufList.add(tid, fTagRdBuf);
                tagIdList = fTagRdBuf.opcIdList.ToArray();
                if (m_opcServer.ReadAsync((int)tid, 0, ref tagIdList) != ReturnCode.SUCCEEDED)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0038, "OPC Server", "Read"));
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

        private void requestMessageReadByEvent(
            FOpcSession fOsn,
            FOpcMessageTransfer fOmt
            )
        {
            UInt32 tid = 0;
            FKepwareBuffer fTagRdBuf = null;
            ItemIdentifier tagId = null;
            ItemIdentifier[] tagIdList = null;

            try
            {
                tid = m_fTagRdTid.uniqueId;
                fTagRdBuf = new FKepwareBuffer(fOsn, fOmt);
                fTagRdBuf.readByEvent = true;

                // --
                
                // ***
                // OPC Item Read
                // ***
                foreach (FOpcItem fOit in fOmt.fChildOpcItemListCollection[0].fChildOpcItemCollection)
                {
                    tagId = new ItemIdentifier();
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    tagId.ItemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, fOit.itemName) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, fOit.itemName);
                    tagId.ClientHandle = fOit.uniqueId;
                    // --
                    fTagRdBuf.opcIdList.Add(tagId);
                }

                // --

                if (fTagRdBuf.opcIdList.Count > 0)
                {
                    m_fTagRdBufList.add(tid, fTagRdBuf);
                    tagIdList = fTagRdBuf.opcIdList.ToArray();
                    if (!fOmt.IgnoreReadResult && m_opcServer.ReadAsync((int)tid, 0, ref tagIdList) != ReturnCode.SUCCEEDED)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0038, "OPC Server", "Read"));
                    }
                }
                else
                {
                    // --
                    // Modify by Jeff.Kim 2015.10.12
                    // OpcItem이 없을 경우에는 바로 Event 발생시킨다. 
                    fTagRdBuf.isError = false;

                    // --

                    procDataRead(fTagRdBuf);
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

        private void requestMessageWrite(
            FOpcSession fOsn,
            FOpcMessageTransfer fOmt
            )
        {
            UInt32 tid = 0;
            FKepwareBuffer fTagWtBuf = null;
            ItemIdentifier tagId = null;
            ItemIdentifier[] tagIdList = null;
            ItemValue tagValue = null;
            ItemValue[] tagValueList = null;

            try
            {
                tid = m_fTagWtTid.uniqueId;
                fTagWtBuf = new FKepwareBuffer(fOsn, fOmt);

                // --

                // ***
                // OPC Item Write
                // ***
                foreach (FOpcItem fOit in fOmt.fChildOpcItemListCollection[0].fChildOpcItemCollection)
                {
                    tagId = new ItemIdentifier();
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    tagId.ItemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, fOit.itemName) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, fOit.itemName);
                    tagId.ClientHandle = fOit.uniqueId;                                        
                    // --
                    fTagWtBuf.opcIdList.Add(tagId);

                    // --

                    tagValue = new ItemValue();                    
                    tagValue.Value = FKepware2.parseOpcValue(fOit.fItemFormat, fOit.itemArray, fOit.value, fOit.length);
                    // --
                    fTagWtBuf.opcValueList.Add(tagValue);
                }

                // --

                // ***
                // OPC Event Item Write
                // ***
                foreach (FOpcEventItem fOei in fOmt.fChildEventItemListCollection[0].fChildOpcEventItemCollection)
                {
                    tagId = new ItemIdentifier();
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    tagId.ItemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, fOei.itemName) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, fOei.itemName);
                    tagId.ClientHandle = fOei.uniqueId;
                    // --
                    fTagWtBuf.opcIdList.Add(tagId);

                    // --

                    tagValue = new ItemValue();
                    tagValue.Value = FKepware2.parseOpcValue(fOei.fItemFormat, fOei.itemArray, fOei.value, fOei.length);                    
                    // --                    
                    fTagWtBuf.opcValueList.Add(tagValue); 
                }                

                // --

                m_fTagWtBufList.add(tid, fTagWtBuf);
                tagIdList = fTagWtBuf.opcIdList.ToArray();
                tagValueList = fTagWtBuf.opcValueList.ToArray();
                if (m_opcServer.WriteAsync((int)tid, ref tagIdList, tagValueList) != ReturnCode.SUCCEEDED)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0038, "OPC Server", "Write"));
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

        public void clearSubscription(
            )
        {
            try
            {
                m_fItmSubscriber.init();
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

        private void procItemTagSubscriptionRegister(
            FOpcSession fOpcSession
            )
        {
            const string xPath =
                FXmlTagOML.E_OpcMessageList + "/" +
                FXmlTagOMS.E_OpcMessages + "[@" + FXmlTagOMS.A_Direction + "='R']/" +
                FXmlTagOMG.E_OpcMessage + "[@" + FXmlTagOMG.A_IsPrimary + "='T']/" +
                FXmlTagOEL.E_OpcEventItemList + "/" +
                FXmlTagOEI.E_OpcEventItem;
            // --
            FXmlNodeList fNodeItemList = null;
            FKepwareSession fNewSession = null;
            FKepwareSession fOldSession = null;
            UInt64 oeiUniqueId = 0;
            FTagFormat fItemFormat;
            string itemName = string.Empty;
            FOpcFormat fFormat = FOpcFormat.Boolean;
            bool ignoreFirst = false;
            ItemIdentifier[] opcIdList = null;
            ItemIdentifier opcId = null;
            int index;
            int updateRate = 0;
            int serverHandle = 0;
            ReturnCode retCode;

            try
            {
                if (!fOpcSession.hasLibrary)
                {
                    return;
                }
                // --                
                fNodeItemList = fOpcSession.fLibrary.fXmlNode.selectNodes(xPath);
                if (fNodeItemList.count == 0)
                {
                    return;
                }

                // --

                // --
                // Modify by Jeff.Kim 2015.10.09
                // 이미 등록된 Session에 대해서 Subscribe에 Event가 발생하지 않았을 경우 수행하지 않는다. 
                // 기존 등록이 완료 되었는데, Reload 시점에 DataChanged Event 를 받지 못했다면, 서버로 
                // 취소 보낸후 다시 등록 한다. 
                if (m_fItmSubscriber.fSessionList.ContainsKey(fOpcSession.uniqueId))
                {
                    fOldSession = m_fItmSubscriber.fSessionList[fOpcSession.uniqueId];
                    if (!fOldSession.completed)
                    {
                        requestItemTagSubscriptionCancel(fOldSession);
                    }
                }

                // --

                // ***
                // Subscribe Item 검색
                // ***                
                fNewSession = new FKepwareSession(
                    fOpcSession.uniqueId,
                    fOpcSession.uniqueId,
                    fOpcSession.channel,
                    fOpcSession.updateRate,
                    fOpcSession.deadBand
                    );
                fNewSession.name = fOpcSession.name;

                // ***
                // 신규 Subscribe 등록
                // ***     
                index = 0;
                opcIdList = new ItemIdentifier[fNodeItemList.count];
                foreach (FXmlNode x in fNodeItemList)
                {
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // OPC UA와 OPC DA의 Tag Name Format 이원화
                    // ***
                    oeiUniqueId = UInt64.Parse(x.get_attrVal(FXmlTagOEI.A_UniqueId, FXmlTagOEI.D_UniqueId));
                    fItemFormat = FEnumConverter.toTagFormat(x.get_attrVal(FXmlTagOEI.A_ItemFormat, FXmlTagOEI.D_ItemFormat));
                    itemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOpcSession.channel, x.get_attrVal(FXmlTagOEI.A_ItemName, FXmlTagOEI.D_ItemName)) :
                        string.Format(m_itemNameFormat, m_defaultNamespace, fOpcSession.channel, x.get_attrVal(FXmlTagOEI.A_ItemName, FXmlTagOEI.D_ItemName));
                    fFormat = FEnumConverter.toOpcFormat(x.get_attrVal(FXmlTagOEI.A_Format, FXmlTagOEI.D_Format));
                    ignoreFirst = FBoolean.toBool(x.get_attrVal(FXmlTagOEI.A_IgnoreFirst, FXmlTagOEI.D_IgnoreFirst));
                    // --
                    fNewSession.fItemList.Add(
                        oeiUniqueId,
                        new FKepwareItem(fNewSession.osnUniqueId, oeiUniqueId, fItemFormat, itemName, fFormat, ignoreFirst)
                        );

                    // --
                    opcId = new ItemIdentifier();
                    opcId.ClientHandle = oeiUniqueId;
                    opcId.ItemName = itemName;
                    opcId.ItemPath = fOpcSession.channel + x.get_attrVal(FXmlTagOEI.A_ItemName, FXmlTagOEI.D_ItemName);
                    // --
                    opcIdList[index++] = opcId;
                }

                // -- 

                retCode = m_opcServer.Subscribe(
                    (int)fNewSession.osnUniqueId,
                    true,
                    fNewSession.updateRate,
                    out updateRate,
                    fNewSession.deadBand,
                    ref opcIdList,
                    out serverHandle
                    );

                // --

                if (retCode == ReturnCode.SUCCEEDED ||
                    retCode == ReturnCode.UNSUPPORTEDUPDATERATE)
                {
                    fNewSession.serverHandle = serverHandle;
                    fNewSession.registerSucceed = true;
                    fNewSession.completed = false;
                    // --
                    m_fItmSubscriber.fSessionList.Add(fNewSession.osnUniqueId, fNewSession);
                }
                else if (fOpcSession.fState == FSessionState.Selected)
                {
                    // 2020.10.19 Sunghoon.Park
                    // Workspace Manager에서 Test 시 Subscribe Error Tag Logging 추가
                    if (this.fOpcDriver.fOpcRunMode == FOpcRunMode.WorkspaceManager)
                    {
                        foreach (ItemIdentifier opcItem in opcIdList)
                        {
                            if (!opcItem.ResultID.Succeeded)
                            {
                                procDeviceErrorRaised(
                                    new Exception(string.Format(FConstants.err_m_0044, fNewSession.name, opcItem.ItemName.Substring(7).ToString()))
                                    );
                            }
                        }
                    }
                    // --
                    FDebug.throwFException(
                        string.Format(FConstants.err_m_0043, fNewSession.name, "Data", "ReturnCode=" + retCode.ToString())
                        );
                }
            }
            catch (Exception ex)
            {
                procDeviceErrorRaised(ex);
                // 21.02.19 by MjKIM
                // Session을 끊을 필요가 있을까 고민 중,..  동일한 에러가 계속 발생한다라고 하면, sessionClose() 해야 함
                //if (m_fDeviceState == FDeviceState.Selected)
                //{
                //    requestSessionClose(fOpcSession, fNewSession);
                //}
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procSystemTagSubscriptionRegister(
            )
        {
            Dictionary<UInt64, FKepwareSession> fNewSessionList = new Dictionary<UInt64, FKepwareSession>();
            FKepwareSession fNewSession = null;
            UInt64 oeiUniqueId = 0;
            FTagFormat fItemFormat;
            string itemName = string.Empty;
            FOpcFormat fFormat = FOpcFormat.Boolean;
            bool ignoreFirst = false;
            ItemIdentifier[] opcIdList = null;
            ItemIdentifier opcId = null;
            int index;
            UInt64 heartbeatIndex = 1;
            int updateRate = 0;
            int serverHandle = 0;
            ReturnCode retCode;
            List <string> duplicatedChannels = new List<string>();

            try
            {
                if (m_fSysSubscriber.succeed)
                {
                    return;
                }

                // --

                // ***
                // Subscribe Item 검색
                // ***
                fNewSession = new FKepwareSession(1, 1, string.Empty, 500, 0);
                foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                {
                    // Modify By Jeff.Kim 2015.10.20
                    // Multi Session 에서 Session의 Channel 값이 동일 할경우 Unique한 Channel만을 등록 한후,
                    // Data Changed 에서 동일한 Channel 값을 사용 하는 Session에 대해서 Selected 상태로 만든다. 
                    if (!duplicatedChannels.Contains(fOsn.channel))
                    {
                        oeiUniqueId = fOsn.uniqueId;
                        fItemFormat = FTagFormat.Boolean;
                        itemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, FConstants.SystemErrorTagName) :
                            string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, FConstants.SystemErrorTagName);
                        fFormat = FOpcFormat.Boolean;
                        ignoreFirst = true;
                        // --
                        fNewSession.fItemList.Add(
                            oeiUniqueId,
                            new FKepwareItem(fNewSession.osnUniqueId, oeiUniqueId, fItemFormat, itemName, fFormat, ignoreFirst)
                            );
                        // --
                        oeiUniqueId = heartbeatIndex++;
                        fItemFormat = FTagFormat.Byte;
                        itemName = m_fProtocol == FProtocol.OPCDA ? string.Format(FConstants.DaItemNameFormat, fOsn.channel, FConstants.HeartbeatTagName) :
                            string.Format(m_itemNameFormat, m_defaultNamespace, fOsn.channel, FConstants.HeartbeatTagName);
                        fFormat = FOpcFormat.U1;
                        ignoreFirst = true;
                        // --
                        fNewSession.fItemList.Add(
                            oeiUniqueId,
                            new FKepwareItem(fNewSession.osnUniqueId, oeiUniqueId, fItemFormat, itemName, fFormat, ignoreFirst)
                            );

                        // --

                        duplicatedChannels.Add(fOsn.channel);
                    }
                }

                // --

                fNewSessionList.Add(fNewSession.osnUniqueId, fNewSession);

                // --                

                // ***
                // 이전 Subscribe 중지
                // ***
                requestSystemTagSubscriptionCancel();
                // --
                m_fSysSubscriber.fSessionList = fNewSessionList;
                if (m_fSysSubscriber.fSessionList.Count == 0)
                {
                    return;
                }

                // --                

                // ***
                // 신규 Subscribe 등록
                // ***                
                foreach (ulong key in m_fSysSubscriber.fSessionList.Keys)
                {
                    fNewSession = m_fSysSubscriber.fSessionList[key];
                    opcIdList = new ItemIdentifier[fNewSession.fItemList.Count];
                    index = 0;
                    // --
                    foreach (FKepwareItem i in fNewSession.fItemList.Values)
                    {
                        opcId = new ItemIdentifier();
                        opcId.ClientHandle = i.oeiUniqueId;
                        opcId.ItemName = i.itemName;
                        // --
                        opcIdList[index++] = opcId;
                    }
                    // -- 
                    retCode = m_opcServer.Subscribe(
                        (int)fNewSession.osnUniqueId,
                        true,
                        fNewSession.updateRate,
                        out updateRate,
                        fNewSession.deadBand,
                        ref opcIdList,
                        out serverHandle
                        );
                    if (retCode == ReturnCode.SUCCEEDED ||
                        retCode == ReturnCode.UNSUPPORTEDUPDATERATE)
                    {
                        fNewSession.serverHandle = serverHandle;
                        fNewSession.registerSucceed = true;
                        fNewSession.completed = false;
                    }
                    else
                    {
                        FDebug.throwFException("SYSTEM tag subscribe is not registered.");
                    }
                }

                // --

                m_fSysSubscriber.enabled = true;
            }
            catch (Exception ex)
            {
                if (m_fDeviceState == FDeviceState.Selected)
                {
                    procDeviceErrorRaised(ex);

                    // --

                    m_fSysSubscriber.enabled = false;
                }
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void requestSystemTagSubscriptionCancel(
            )
        {   
            try
            {               
                // ***
                // 이전 Subscribe 중지
                // ***
                if (m_fSysSubscriber.enabled)
                {
                    foreach (FKepwareSession s in m_fSysSubscriber.fSessionList.Values)
                    {
                        m_opcServer.SubscriptionCancel(s.serverHandle);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fSysSubscriber.fSessionList.Clear();
                m_fSysSubscriber.enabled = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void requestItemTagSubscriptionCancel(
            FKepwareSession fKepwareSession
            )
        {            
            try
            {   
                // ***
                // 이전 Subscribe 중지
                // ***
                if (m_fItmSubscriber.fSessionList.ContainsKey(fKepwareSession.osnUniqueId))
                {
                    if (fKepwareSession.registerSucceed)
                    {
                        m_opcServer.SubscriptionCancel(fKepwareSession.serverHandle);
                    }
                    m_fItmSubscriber.fSessionList.Remove(fKepwareSession.osnUniqueId);
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

        private void requestItemTagParsing(
            FKepwareSession fKepSession,
            ItemValueCallback[] itemValues
            )
        {
            const string xPathOsn =
                FXmlTagOSN.E_OpcSession + "[@" + FXmlTagOSN.A_UniqueId + "='{0}']";            

            const string xPathOei =
                FXmlTagOML.E_OpcMessageList + "/" +
                FXmlTagOMS.E_OpcMessages + "[@" + FXmlTagOMS.A_Direction + "='R']/" +
                FXmlTagOMG.E_OpcMessage + "/" +
                FXmlTagOEL.E_OpcEventItemList + "/" +
                FXmlTagOEI.E_OpcEventItem + "[@" + FXmlTagOEI.A_UniqueId + "='{0}']";
            // --
            UInt64 osnUniqueId = 0;
            UInt64 oeiUniqueId = 0;
            UInt64 oldUniqueId = 0;
            FKepwareItem fItem = null;
            FXmlNode fXmlNodeOsn = null;            
            FXmlNode fXmlNodeOei = null;
            FOpcSession fOsn = null;            
            FOpcEventItem fOei = null;
            FOpcMessageTransfer fOmt = null;
            // --
            string opcValue = string.Empty;            

            try
            {
                foreach (ItemValueCallback c in itemValues)
                {
                    oeiUniqueId = (UInt64)c.ClientHandle;
                    
                    // --
                    
                    // ***
                    // _system._error Tag인 경우 미처리
                    // ***
                    if (fKepSession.osnUniqueId == oeiUniqueId || !fKepSession.fItemList.ContainsKey(oeiUniqueId))
                    {
                        continue;     
                    }

                    // --
                    
                    fItem = fKepSession.fItemList[oeiUniqueId];
                    fItem.oldValue = c.Value;
                    osnUniqueId = fItem.osnUniqueId;
                    
                    // --

                    if (fOsn == null || osnUniqueId != oldUniqueId)
                    {
                        fXmlNodeOsn = this.fOpcDevice.fXmlNode.selectSingleNode(string.Format(xPathOsn, osnUniqueId));
                        if (fXmlNodeOsn == null)
                        {
                            continue;
                        }
                        fOsn = ((FOpcSession)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeOsn));
                    }                    

                    // --

                    fXmlNodeOei = fOsn.fLibrary.fXmlNode.selectSingleNode(string.Format(xPathOei, oeiUniqueId));
                    if (fXmlNodeOei == null)
                    {
                        continue;
                    }
                    fOei = ((FOpcEventItem)FOpcDriverCommon.createObject(this.fOcdCore, fXmlNodeOei));
                    opcValue = FKepware2.parseTagValue(fOei.fItemFormat, fOei.fFormat, c.Value);
                    if (!fOei.alwaysEvent && fOei.encodingValue != opcValue)
                    {
                        continue;
                    }                    
                    
                    // --
                    // Modify By Jeff.Kim 2015.11.12
                    // Item의 값이 처음 Set 될경우 Ignore First 를 확인한다. 
                    if (!fItem.firstValueSet)
                    {
#if DEBUG
                        System.Diagnostics.Debug.WriteLine(
                            "[" + FDataConvert.defaultNowDateTimeToString() + "]" +
                            "ItemName=" + fOei.itemName + ", " +
                            "Session=" + fOsn.name + ", " +
                            "State=" + fOsn.fState.ToString()
                            );
#endif
                        fItem.firstValueSet = true;
                        if (fItem.ignoreFirst)
                        {   
                            continue;
                        }                        
                    }

                    // --

                    // ***
                    // 2015.07.15 by spike.lee
                    // OPC Message에서 이벤트 처리되는 OPC Event Item외에 다른 OPC Event Item은 제거               
                    // ***
                    fOmt = fOei.fParent.fParent.createTransfer();
                    foreach (FOpcEventItem i in fOmt.fChildEventItemListCollection[0].fChildOpcEventItemCollection)
                    {
                        if (i.uniqueId != oeiUniqueId)
                        {
                            i.remove();
                        }
                        else
                        { 
                            // Modify by Jeff.Kim 2015.10.12
                            // Subscribe 에서 발생한 값을 Event Item의 값으로 사용.
                            // 다시 해당 Item을 Read하지 않기 위해 설정
                            i.originalValue = opcValue;
                        }
                    }
                    
                    // --

                    if (fOmt.delayTime == 0)
                    {
                        requestMessageReadByEvent(fOsn, fOmt);
                    }
                    else
                    {
                        m_fDelayMessageList.add(
                            new FDelayMessage(fOsn, fOmt, fOmt.delayTime)
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

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procDelayMessage(
            FDelayMessage[] fDelayMessageList
            )
        {
            try
            {
                foreach (FDelayMessage m in fDelayMessageList)
                {
                    try
                    {
                        requestMessageReadByEvent(m.fOpcSession, m.fOpcMessageTransfer);    
                    }
                    catch (Exception inEx)
                    {
                        procDeviceErrorRaised(inEx);
                    }
                    finally
                    {

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

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region m_opcServer Object Event Handler

        private void m_opcServer_WriteCompleted(
            int transactionHandle, 
            bool noErrors, 
            ItemResultCallback[] itemResults
            )
        {
            UInt32 tid = 0;
            FKepwareBuffer fTagWtBuf = null;

            try
            {
                tid = (UInt32)transactionHandle;
                fTagWtBuf = m_fTagWtBufList.remove(tid);
                if (fTagWtBuf == null)
                {
                    return;
                }

                // --

                fTagWtBuf.isError = !noErrors;
                fTagWtBuf.opcResultCallbackList.AddRange(itemResults);

                // --

                procDataWritten(fTagWtBuf);
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

        private void m_opcServer_ReadCompleted(
            int transactionHandle, 
            bool allQualitiesGood, 
            bool noErrors, 
            ItemValueCallback[] itemValues
            )
        {
            UInt32 tid = 0;
            FKepwareBuffer fTagRdBuf = null;            

            try
            {
                tid = (UInt32)transactionHandle;
                fTagRdBuf = m_fTagRdBufList.remove(tid);
                if (fTagRdBuf == null)
                {
                    return;
                }
                
                // --

                fTagRdBuf.isError = !noErrors;
                fTagRdBuf.opcValueCallbackList.AddRange(itemValues);                  

                // --

                procDataRead(fTagRdBuf);
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

        private void m_opcServer_DataChanged(
            int clientSubscription, 
            bool allQualitiesGood, 
            bool noErrors, 
            ItemValueCallback[] itemValues
            )
        {            
            try
            {
                m_fQueueSubscribeData.enqueue(
                    new FKepwareSubscriberData(clientSubscription, allQualitiesGood, noErrors, itemValues)
                    );
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

        private void m_opcServer_ServerStateChanged(
            int clientHandle, 
            ServerState state
            )
        {
            FDeviceState opcErrorState = FDeviceState.ErrorShutdown;

            try
            {
                // ***
                // Modified by spike.lee at 2016.01.26
                // ClientAce의 OPC Server 상태를 OpcDevice 상태에 반영
                // OPC DA 지원을 위해 ErrorShutdown이나 ErrorWatchDog이 발생하면 Admin에서
                // EAP를 Abort 시키기 위해 기능을 추가 함
                // ***
                if (
                    state == ServerState.UNDEFINED ||
                    state == ServerState.ERRORWATCHDOG ||
                    state == ServerState.ERRORSHUTDOWN
                    )
                {
                    if (state == ServerState.UNDEFINED)
                    {
                        opcErrorState = FDeviceState.Undefined; 
                    }
                    else if (state == ServerState.ERRORWATCHDOG)
                    {
                        opcErrorState = FDeviceState.ErrorWatchDog;
                    }
                    else if (state == ServerState.ERRORSHUTDOWN)
                    {
                        opcErrorState = FDeviceState.ErrorShutdown;
                    }

                    // --

                    this.fEventPusher.pushOpcDeviceStateChangedEvent(
                        this.fOpcDevice,
                        FResultCode.Error,
                        string.Empty,
                        opcErrorState
                        );
                    // --
                    raiseConnectionTrigger(opcErrorState);

                    // --

                    m_fTmrReconnect.start(m_t5Timeout);

                    // --                      

                    procStateOpened(); 
                }
                else if (state == ServerState.DISCONNECTED)
                {
                    // ***
                    // DISCONNECT 상태는 Client Ace 라이브러리에서 OPC Server와 연결을
                    // 끊을 경우에 발생하는 상태이므로 처리하지 않는다.
                    // ***
                }

                // --

                // Add by Jeff.Kim 2015.10.06 
                // Connected시에 기존 Plc state tag 초기화
                if (state == ServerState.CONNECTED)
                {
                    requestSystemTagSubscriptionCancel();
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
            FDelayMessage[] fDelayMessageList = null;
            FOpcSession fOpcSession = null;

            try
            {
                waited = m_fMainSync.tryWait(1);
                if (!waited)
                {
                    return;
                }

                // --

                if (m_fDeviceState == FDeviceState.Opened)
                {
                    if (!m_fTmrReconnect.enabled || m_fTmrReconnect.elasped(false))
                    {
                        procStateConnected();
                    }                    
                }

                // ***
                // Modify by Jeff.Kim 2015.10.06
                // Connected 시에 Plc state tag 등록
                // ***
                if (m_fDeviceState == FDeviceState.Connected)                
                {
                    // ***
                    // Modify by Kt.Kim at 2019.07.29
                    // KEPWARE에서 Session  별로 독립적 수행은 되나, 개별 Session 이상시 Device 상태가 변화 되게 수정
                    // ***                    
                    // Modify by Jeff.Kim at 2019.02.11
                    // Session 별로 독립적으로 수행 하기 위해서 Kepware 도 Opc UA, DA Protocol 과 동일하게
                    // 처리한다.
                    // ***
                    // Modified by spike.lee at 2016.01.19
                    // PLC 연결 상태 체크는 KEPWARE 프로토콜일 경우에만 처리하고
                    // OPC UA와 OPC DA는 OPC Server와의 연결 상태만 관리하도록 처리                                        
                    // ***

                    if (m_fProtocol == FProtocol.KEPWARE)
                    {
                        // --
                        // Modify by Jeff.Kim 2015.11.19
                        // Connected에서 Selected가 동초에 발생될경우 Admin Manager에서 상태가 뒤집히는 현상을 막기위함
                        // --
                        e.sleepThread(100);

                        // --

                        procSystemTagSubscriptionRegister();
                        m_fTmrErrorTagReload.start(m_eventReloadTime);
                        
                        // --

                        foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                        {  
                            // ***
                            // Add by Jeff.Kim 2018.10.17
                            // 일정 시간 지연후에 Subscription 등록을 위해서 설정
                            // ***
                            m_fTmrTagReloadList[fOsn.uniqueId].start(m_eventReloadTime);
                        }
                    }
                    else
                    {
                        e.sleepThread(500);

                        // --

                        // ***
                        // Modified by spike.lee at 2016.01.19
                        // OPC DA와 OPC UA는 OPC 서버와 Connect되면 Selected 상태로 변경하도록 처리
                        // ***                        
                        foreach (FOpcSession fOsn in this.fOpcDevice.fChildOpcSessionCollection)
                        {
                            // ***
                            // Add by Jeff.Kim 2018.10.17
                            // 일정 시간 지연후에 Subscription 등록을 위해서 설정
                            // ***
                            m_fTmrTagReloadList[fOsn.uniqueId].start(10000); // 10초
                        }
                    }                                        
                }

                // --

                isSleep = true;

                // --

                for (int i = 0; i < this.fOpcDevice.fChildOpcSessionCollection.count; i++)
                {
                    fOpcSession = this.fOpcDevice.fChildOpcSessionCollection[i];

                    // --

                    if (fOpcSession.fState != FSessionState.Connected &&
                        fOpcSession.fState != FSessionState.Selected)
                    {
                        continue;
                    }

                    // --
                    // Modify by Jeff.Kim 2018.10.16
                    // Subscribe Item 등록
                    // Subscrition 등록이 정상적으로 이루어 지지 않은 경우나, 등록은 했지만, 서버에서 Event Reload 시간이후
                    // 에도 DataChanged Event 가 발생 하지 않을 경우 재 등록 한다. 
                    if (!m_fItmSubscriber.fSessionList.ContainsKey(fOpcSession.uniqueId) ||
                        (m_fItmSubscriber.fSessionList[fOpcSession.uniqueId].registerSucceed && !m_fItmSubscriber.fSessionList[fOpcSession.uniqueId].completed))
                    {
                        if (m_fTmrTagReloadList[fOpcSession.uniqueId].elasped(false))
                        {
                            procItemTagSubscriptionRegister(fOpcSession);

                            // --

                            m_fTmrTagReloadList[fOpcSession.uniqueId].start(m_eventReloadTime);
                        }
                    }

                    // --

                    // ***
                    // Delay Message 처리
                    // ***
                    fDelayMessageList = m_fDelayMessageList.getMessage(fOpcSession);
                    if (fDelayMessageList != null)
                    {
                        isSleep = false;
                        procDelayMessage(fDelayMessageList);
                    }

                    // -- 

                    // ***
                    // Auto Cycle Transmitter 처리
                    // ***
                    if (fOcdCore.fConfig.enabledEventsOfScenario &&
                        m_fTmrAutoCycleList.ContainsKey(fOpcSession.uniqueId) &&
                        m_fTmrAutoCycleList[fOpcSession.uniqueId].elasped(true))
                    {
                        isSleep = false;
                        this.fProtocolAgent.runOpcAutoCycleTransmitter(fOpcSession);
                    }

                    // --

                    // ***
                    // Auto Trace Message 처리
                    // ***
                    if (m_fTmrAutoTraceList.ContainsKey(fOpcSession.uniqueId) &&
                        m_fTmrAutoTraceList[fOpcSession.uniqueId].elasped(true))
                    {
                        isSleep = false;
                        this.fProtocolAgent.runOpcAutoTraceMessage(fOpcSession);
                    }
                }

                // --

                if (isSleep)
                {
                    e.sleepThread(1);
                }
            }
            catch (Exception ex)
            {
                e.sleepThread(1);
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

        #region m_fThdSubscribeData Object Event Handler

        private void m_fThdSubscribeData_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            FKepwareSubscriberData args = null;

            try
            {
                if (this.dataCount == 0)
                {
                    m_isCompleteDataHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompleteDataHandling = false;

                // --

                while (m_fQueueSubscribeData.count > 0)
                {
                    try
                    {
                        args = m_fQueueSubscribeData.dequeue();
                        if (args == null)
                        {
                            break;
                        }

                        // --

                        if (args.clientSubscription == 1)
                        {
                            procSystemTagDataChanged(
                                args.clientSubscription,
                                args.allQualitiesGood,
                                args.noErrors,
                                args.itemValues
                                );
                        }
                        else
                        {
                            procItemTagDataChanged(
                                args.clientSubscription,
                                args.allQualitiesGood,
                                args.noErrors,
                                args.itemValues
                                );
                        }
                    }
                    catch { }
                    finally
                    {
                        args.Dispose();
                        args = null;
                    }
                }
            }
            catch (Exception ex)
            {
                e.sleepThread(1);
                FDebug.writeLog(ex);
            }
            finally
            {
                if (args != null)
                {
                    args.Dispose();
                }
            }
        }

        #endregion
       
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
