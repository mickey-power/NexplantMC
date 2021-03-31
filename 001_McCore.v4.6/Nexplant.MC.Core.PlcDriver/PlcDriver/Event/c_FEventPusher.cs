/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventPusher.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver Event Pusher Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FEventPusher : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
        private FQueue<FEventArgsBase> m_fPreEvents = null; // 2013.07.10 by spike.lee 선행 Event Queue (Scenario Control Event 용)
        private FQueue<FEventArgsBase> m_fEvents = null;
        // --
        private FThread m_fEventPusher = null;
        private bool m_isCompletedEventHandling = false;
        // --
        private FPauserAgent m_fPauserAgent = null;
        private FStaticTimer m_fTmrRpmRemove = null;        // 2017.04.05 by spike.lee Repository Material Auto Remove 구현

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEventPusher(
            FPcdCore fScdCore 
            )
        {
            m_fPcdCore = fScdCore;
            m_fPreEvents = new FQueue<FEventArgsBase>();
            m_fEvents = new FQueue<FEventArgsBase>();
            m_fPauserAgent = new FPauserAgent(fScdCore);
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEventPusher(
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

                    if (m_fPreEvents != null)
                    {
                        m_fPreEvents.Dispose();
                        m_fPreEvents = null;
                    }
                    // --
                    if (m_fEvents != null)
                    {
                        m_fEvents.Dispose();
                        m_fEvents = null;
                    }
                    // --
                    if (m_fPauserAgent != null)
                    {
                        m_fPauserAgent.Dispose();
                        m_fPauserAgent = null;
                    }
                    
                    // --
                    
                    m_fPcdCore = null;                    
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

        public int eventCount
        {
            get
            {
                try
                {
                    return (m_fPreEvents.count + m_fEvents.count);
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

        public bool isCompletedEventHandling
        {
            get
            {
                try
                {
                    if (this.eventCount == 0 && m_isCompletedEventHandling)
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
                // ***
                // 2017.04.05 by spike.lee
                // Repository Material Auto Remove 실행 Timer 생성
                // ***
                m_fTmrRpmRemove = new FStaticTimer();
                m_fTmrRpmRemove.start(1000);  // 1초

                // --

                // ***
                // 비동기 Thread 생성 (Event는 비동기적으로 호출되기 때문에 Client는 Invoke 계열 Method를 통해 처리
                // ***
                m_isCompletedEventHandling = true;
                m_fEventPusher = new FThread("PlcEventPushThread", false, System.Threading.ThreadPriority.Normal, true);
                m_fEventPusher.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);                
                m_fEventPusher.start();
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
                if (m_fEventPusher != null)
                {
                    while (!this.isCompletedEventHandling)
                    {
                        System.Threading.Thread.Sleep(10);
                    }

                    // --

                    m_fEventPusher.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fEventPusher_ThreadJobCalled);                
                    // --
                    m_fEventPusher.stop();
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                // --

                if (m_fTmrRpmRemove != null)
                {
                    m_fTmrRpmRemove.Dispose();
                    m_fTmrRpmRemove = null;
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

        public FHostDeviceDataMessageReceivedLog createHostDeviceDataMessageReceivedLog(
            FXmlNode fXmlNodeHsn,
            FXmlNode fXmlNodeHmgl
            )
        {
            FHostDeviceDataMessageReceivedLog fLog = null;

            try
            {
                fLog = new FHostDeviceDataMessageReceivedLog(fXmlNodeHsn, fXmlNodeHmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.A_LogType, FXmlTagHMGL.L_Received);
                // --
                return fLog;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDeviceDataMessageSentLog createHostDeviceDataMessageSentLog(
            FXmlNode fXmlNodeHsn,
            FXmlNode fXmlNodeHmgl
            )
        {
            FHostDeviceDataMessageSentLog fLog = null;

            try
            {
                fLog = new FHostDeviceDataMessageSentLog(fXmlNodeHsn, fXmlNodeHmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_LogType, FXmlTagHMGL.A_LogType, FXmlTagHMGL.L_Sent);
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_MessageType, FXmlTagHMGL.D_MessageType, FXmlTagHMGL.M_Message);
                // --
                return fLog;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPlcDeviceDataMessageReadLog createPlcDeviceDataMessageReadLog(
            FXmlNode fXmlNodePsn,
            FXmlNode fXmlNodePmgl
            )
        {
            FPlcDeviceDataMessageReadLog fLog = null;

            try
            {
                fLog = new FPlcDeviceDataMessageReadLog(fXmlNodePsn, fXmlNodePmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_LogType, FXmlTagPMGL.D_LogType, FXmlTagPMGL.L_Read);
                // --
                return fLog;
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

        public FPlcDeviceDataMessageWrittenLog createPlcDeviceDataMessageWrittenLog(
            FXmlNode fXmlNodePsn,
            FXmlNode fXmlNodePmgl
            )
        {
            FPlcDeviceDataMessageWrittenLog fLog = null;

            try
            {
                fLog = new FPlcDeviceDataMessageWrittenLog(fXmlNodePsn, fXmlNodePmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_LogType, FXmlTagPMGL.D_LogType, FXmlTagPMGL.L_Written);
                // --
                return fLog;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPreEvent(
            FEventArgsBase fPlcEvent
            )
        {
            try
            {
                m_fPreEvents.enqueue(fPlcEvent);
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

        public void pushPreEvent(
            FEventArgsBase[] fPlcEvents
            )
        {
            try
            {
                m_fPreEvents.enqueue(fPlcEvents);
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

        public void pushEvent(
            FEventArgsBase fPlcEvent
            )
        {
            try
            {
                m_fEvents.enqueue(fPlcEvent);                
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

        public void pushEvent(
            FEventArgsBase[] fPlcEvents
            )
        {
            try
            {
                m_fEvents.enqueue(fPlcEvents);
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

        public void pushPlcDeviceStateChangedEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort
            )
        {
            FPlcDeviceStateChangedLog fLog = null;

            try
            {
                fLog = new FPlcDeviceStateChangedLog(
                    FPlcDriverLogCommon.createXmlNodePDVL(fPlcDevice.fXmlNode, FXmlTagPDVL.L_StateChanged)
                    );
                // --                
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultCode, FXmlTagPDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultMessage, FXmlTagPDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Index, FXmlTagPDVL.D_Index, fPlcDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalIp, FXmlTagPDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalPort, FXmlTagPDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemoteIp, FXmlTagPDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemotePort, FXmlTagPDVL.D_RemoteIp, remotePort.ToString());

                // -- 

                // ***
                // 2016.12.21 by spike.lee
                // Plc Device State Changed Event를 Previous Event로 변경
                // ***
                if (fLog.fState == FDeviceState.Closed)
                {
                    pushEvent(new FPlcDeviceStateChangedEventArgs(FEventId.PlcDeviceStateChanged, m_fPcdCore.fPlcDriver, fPlcDevice, fLog));
                }
                else
                {
                    pushPreEvent(new FPlcDeviceStateChangedEventArgs(FEventId.PlcDeviceStateChanged, m_fPcdCore.fPlcDriver, fPlcDevice, fLog));
                }                
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceErrorRaisedEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage
            )
        {
            FPlcDeviceErrorRaisedLog fLog = null;

            try
            {
                fLog = new FPlcDeviceErrorRaisedLog(FPlcDriverLogCommon.createXmlNodePDEL(m_fPcdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_ResultCode, FXmlTagPDEL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_ResultMessage, FXmlTagPDEL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_UniqueId, FXmlTagPDEL.D_UniqueId, fPlcDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_Index, FXmlTagPDEL.D_Index, fPlcDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_Name, FXmlTagPDEL.D_Name, fPlcDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_Description, FXmlTagPDEL.D_Description, fPlcDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_FontColor, FXmlTagPDEL.D_FontColor, fPlcDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagPDEL.A_FontBold, FXmlTagPDEL.D_FontBold, FBoolean.fromBool(fPlcDevice.fontBold));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Plc Device Error Raised Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FPlcDeviceErrorRaisedEventArgs(FEventId.PlcDeviceErrorRaised, m_fPcdCore.fPlcDriver, fPlcDevice, fLog));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceTimeoutRaisedEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            FPlcDeviceTimeout fTimeout,
            string reason
            )
        {
            FPlcDeviceTimeoutRaisedLog fLog = null;

            try
            {
                fLog = new FPlcDeviceTimeoutRaisedLog(FPlcDriverLogCommon.createXmlNodePDTL(m_fPcdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_ResultCode, FXmlTagPDTL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_ResultMessage, FXmlTagPDTL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_UniqueId, FXmlTagPDTL.D_UniqueId, fPlcDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Index, FXmlTagPDTL.D_Index, fPlcDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Name, FXmlTagPDTL.D_Name, fPlcDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Description, FXmlTagPDTL.D_Description, fPlcDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_FontColor, FXmlTagPDTL.D_FontColor, fPlcDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_FontBold, FXmlTagPDTL.D_FontBold, FBoolean.fromBool(fPlcDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Reason, FXmlTagPDTL.A_Reason, reason);
                fLog.fXmlNode.set_attrVal(FXmlTagPDTL.A_Timeout, FXmlTagPDTL.D_Timeout, FEnumConverter.fromPlcDeviceTimeout(fTimeout));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Plc Device Timeout Raised Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FPlcDeviceTimeoutRaisedEventArgs(FEventId.PlcDeviceTimeoutRaised, m_fPcdCore.fPlcDriver, fPlcDevice, fLog));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceDataReceivedEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            byte[] data
            )
        {
            FPlcDeviceDataReceivedLog fLog = null;

            try
            {
                fLog = new FPlcDeviceDataReceivedLog(FPlcDriverLogCommon.createXmlNodePDVL(fPlcDevice.fXmlNode, FXmlTagPDVL.L_DataReceived));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultCode, FXmlTagPDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultMessage, FXmlTagPDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Index, FXmlTagPDVL.D_Index, fPlcDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalIp, FXmlTagPDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalPort, FXmlTagPDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemoteIp, FXmlTagPDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemotePort, FXmlTagPDVL.D_RemoteIp, remotePort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Length, FXmlTagPDVL.D_Length, data.Length.ToString());
                
                // --
                
                pushEvent(new FPlcDeviceDataReceivedEventArgs(FEventId.PlcDeviceDataReceived, m_fPcdCore.fPlcDriver, fPlcDevice, fLog, data));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceDataSentEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            byte[] data
            )
        {
            FPlcDeviceDataSentLog fLog = null;

            try
            {
                fLog = new FPlcDeviceDataSentLog(FPlcDriverLogCommon.createXmlNodePDVL(fPlcDevice.fXmlNode, FXmlTagPDVL.L_DataSent));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultCode, FXmlTagPDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_ResultMessage, FXmlTagPDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Index, FXmlTagPDVL.D_Index, fPlcDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalIp, FXmlTagPDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_LocalPort, FXmlTagPDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemoteIp, FXmlTagPDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_RemotePort, FXmlTagPDVL.D_RemoteIp, remotePort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagPDVL.A_Length, FXmlTagPDVL.D_Length, data.Length.ToString());
                
                // --
                
                pushEvent(new FPlcDeviceDataSentEventArgs(FEventId.PlcDeviceDataSent, m_fPcdCore.fPlcDriver, fPlcDevice, fLog, data));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceDataMessageReadEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            FPlcDeviceDataMessageReadLog fLog
            )
        {
            FPlcSession fPsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultCode, FXmlTagPMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultMessage, FXmlTagPMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodePsn != null)
                {
                    fPsn = new FPlcSession(m_fPcdCore, fLog.fXmlNodePsn);
                }

                // --

                pushEvent(new FPlcDeviceDataMessageReadEventArgs(FEventId.PlcDeviceDataMessageRead, m_fPcdCore.fPlcDriver, fPlcDevice, fPsn, fLog));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcDeviceDataMessageWrittenEvent(
            FPlcDevice fPlcDevice,
            FResultCode fResultCode,
            string resultMessage,
            FPlcDeviceDataMessageWrittenLog fLog
            )
        {
            FPlcSession fPsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultCode, FXmlTagPMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPMGL.A_ResultMessage, FXmlTagPMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodePsn != null)
                {
                    fPsn = new FPlcSession(m_fPcdCore, fLog.fXmlNodePsn);
                }

                // --

                pushEvent(new FPlcDeviceDataMessageWrittenEventArgs(FEventId.PlcDeviceDataMessageWritten, m_fPcdCore.fPlcDriver, fPlcDevice, fPsn, fLog));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceStateChangedEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage
            )
        {
            FHostDeviceStateChangedLog fLog = null;

            try
            {
                fLog = new FHostDeviceStateChangedLog(
                    FPlcDriverLogCommon.createXmlNodeHDVL(fHostDevice.fXmlNode, FXmlTagHDVL.L_StateChanged)
                    );
                // --                
                fLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_ResultCode, FXmlTagHDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_ResultMessage, FXmlTagHDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHDVL.A_Index, FXmlTagHDVL.D_Index, fHostDevice.index.ToString());

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Host Device State Changed Event를 Previous Event로 변경
                // ***
                if (fLog.fState == FDeviceState.Closed)
                {
                    pushEvent(new FHostDeviceStateChangedEventArgs(FEventId.HostDeviceStateChanged, m_fPcdCore.fPlcDriver, fHostDevice, fLog));
                }
                else
                {
                    pushPreEvent(new FHostDeviceStateChangedEventArgs(FEventId.HostDeviceStateChanged, m_fPcdCore.fPlcDriver, fHostDevice, fLog));
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceErrorRaisedEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage
            )
        {
            FHostDeviceErrorRaisedLog fLog = null;

            try
            {
                fLog = new FHostDeviceErrorRaisedLog(FPlcDriverLogCommon.createXmlNodeHDEL(m_fPcdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_ResultCode, FXmlTagHDEL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_ResultMessage, FXmlTagHDEL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_UniqueId, FXmlTagHDEL.D_UniqueId, fHostDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Index, FXmlTagHDEL.D_Index, fHostDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Name, FXmlTagHDEL.D_Name, fHostDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_Description, FXmlTagHDEL.D_Description, fHostDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_FontColor, FXmlTagHDEL.D_FontColor, fHostDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagHDEL.A_FontBold, FXmlTagHDEL.D_FontBold, FBoolean.fromBool(fHostDevice.fontBold));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Host Device State Changed Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FHostDeviceErrorRaisedEventArgs(FEventId.HostDeviceErrorRaised, m_fPcdCore.fPlcDriver, fHostDevice, fLog));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceVfeiReceivedEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage,
            string machineId,
            UInt16 sessionId,
            string command,
            FHostMessageType fHostMessageType,
            UInt32 tid,
            string vfei
            )
        {
            FHostDeviceVfeiReceivedLog fLog = null;

            try
            {
                fLog = new FHostDeviceVfeiReceivedLog(FPlcDriverLogCommon.createXmlNodeVEFL(m_fPcdCore.fXmlDoc, FXmlTagVFEL.L_Received));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_ResultCode, FXmlTagVFEL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_ResultMessage, FXmlTagVFEL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_UniqueId, FXmlTagVFEL.D_UniqueId, fHostDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Index, FXmlTagVFEL.D_Index, fHostDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Name, FXmlTagVFEL.D_Name, fHostDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Description, FXmlTagVFEL.D_Description, fHostDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_FontColor, FXmlTagVFEL.D_FontColor, fHostDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_FontBold, FXmlTagVFEL.D_FontBold, FBoolean.fromBool(fHostDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_MachineId, FXmlTagVFEL.D_MachineId, machineId);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_SessionId, FXmlTagVFEL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Command, FXmlTagVFEL.D_Command, command);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_HostMessageType, FXmlTagVFEL.D_HostMessageType, FEnumConverter.fromHostMessageType(fHostMessageType));
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_TID, FXmlTagVFEL.A_TID, tid.ToString());

                // --

                pushEvent(new FHostDeviceVfeiReceivedEventArgs(FEventId.HostDeviceVfeiReceived, m_fPcdCore.fPlcDriver, fHostDevice, fLog, vfei));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceVfeiSentEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage,
            string machineId,
            UInt16 sessionId,
            string command,
            FHostMessageType fHostMessageType,
            UInt32 tid,
            string vfei
            )
        {
            FHostDeviceVfeiSentLog fLog = null;

            try
            {
                fLog = new FHostDeviceVfeiSentLog(FPlcDriverLogCommon.createXmlNodeVEFL(m_fPcdCore.fXmlDoc, FXmlTagVFEL.L_Sent));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Time, FXmlTagVFEL.D_Time, FDataConvert.defaultNowDateTimeToString());
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_ResultCode, FXmlTagVFEL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_ResultMessage, FXmlTagVFEL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_UniqueId, FXmlTagVFEL.D_UniqueId, fHostDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Index, FXmlTagVFEL.D_Index, fHostDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Name, FXmlTagVFEL.D_Name, fHostDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Description, FXmlTagVFEL.D_Description, fHostDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_FontColor, FXmlTagVFEL.D_FontColor, fHostDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_FontBold, FXmlTagVFEL.D_FontBold, FBoolean.fromBool(fHostDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_MachineId, FXmlTagVFEL.D_MachineId, machineId);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_SessionId, FXmlTagVFEL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_Command, FXmlTagVFEL.D_Command, command);
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_HostMessageType, FXmlTagVFEL.D_HostMessageType, FEnumConverter.fromHostMessageType(fHostMessageType));
                fLog.fXmlNode.set_attrVal(FXmlTagVFEL.A_TID, FXmlTagVFEL.A_TID, tid.ToString());

                // --

                pushEvent(new FHostDeviceVfeiSentEventArgs(FEventId.HostDeviceVfeiSent, m_fPcdCore.fPlcDriver, fHostDevice, fLog, vfei));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceDataMessageReceivedEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage,
            FHostDeviceDataMessageReceivedLog fLog,
            FHostMessage fReplyHmg
            )
        {
            FHostSession fHsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultCode, FXmlTagHMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultMessage, FXmlTagHMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodeHsn != null)
                {
                    fHsn = new FHostSession(m_fPcdCore, fLog.fXmlNodeHsn);
                }

                // --

                pushEvent(new FHostDeviceDataMessageReceivedEventArgs(FEventId.HostDeviceDataMessageReceived, m_fPcdCore.fPlcDriver, fHostDevice, fHsn, fLog, fReplyHmg));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostDeviceDataMessageSentEvent(
            FHostDevice fHostDevice,
            FResultCode fResultCode,
            string resultMessage,
            FHostDeviceDataMessageSentLog fLog
            )
        {
            FHostSession fHsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultCode, FXmlTagHMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHMGL.A_ResultMessage, FXmlTagHMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodeHsn != null)
                {
                    fHsn = new FHostSession(m_fPcdCore, fLog.fXmlNodeHsn);
                }

                // --

                pushEvent(new FHostDeviceDataMessageSentEventArgs(FEventId.HostDeviceDataMessageSent, m_fPcdCore.fPlcDriver, fHostDevice, fHsn, fLog));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcTriggerRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodePtr,
            FIObjectLog fIObjectLog
            )
        {
            FScenarioData fScenarioData = null;
            FPlcTriggerRaisedLog fLog = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(m_fPcdCore);
                fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodePtr.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                if (fIObjectLog.fObjectLogType == FObjectLogType.PlcDeviceDataMessageReadLog)
                {
                    fScenarioData.setDataMessageReceivedLog((FIMessageLog)fIObjectLog);
                }
                else
                {
                    fScenarioData.setIObjectLog(fIObjectLog);
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodePtr));
                fScenarioData.setTransferCollection(getTransferCollection(fXmlNodePtr, true));

                // --

                fLog = new FPlcTriggerRaisedLog(fXmlNodePtr.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_ResultCode, FXmlTagPTRL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_ResultMessage, FXmlTagPTRL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_EquipmentId, FXmlTagPTRL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_EquipmentName, FXmlTagPTRL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_ScenarioId, FXmlTagPTRL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPTRL.A_ScenarioName, FXmlTagPTRL.D_ScenarioName, fScenarioData.fScenario.name);

                // -- 

                pushEvent(new FPlcTriggerRaisedEventArgs(FEventId.PlcTriggerRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScenarioData = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPlcTransmitterRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodePtn,
            FScenarioData fScenarioData,
            bool isPreEvent
            )
        {
            // --

            FDataSetLog fDtsl = null;
            FPlcMessageTransfer fPmt = null;
            FPlcTransmitterRaisedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodePtn.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodePtn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodePtn));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodePtn, false));
                }

                // --

                // ***
                // Mapper Data를 Message Transfer에 설정
                // ***
                if (fScenarioData.hasTransferCollection && fScenarioData.hasMapperPerformedLog)
                {
                    if (fScenarioData.fMapperPerformedLog.hasDataSetLog)
                    {
                        fDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog();
                        // --
                        foreach (FTransfer fTrf in fScenarioData.fTransferCollection)
                        {
                            fPmt = (FPlcMessageTransfer)fTrf.fMessageTransfer;
                            fPmt.fXmlNode = FDataMapper.generatePlcMessageTransfer(fScenarioData, fDtsl.fXmlNode, fPmt.fXmlNode);
                        }
                    }
                }

                // --

                // ***
                // Primary Message인 경우 Reply Message를 전송받을 경우 RepositoryMaterial를 검색하기 위해 RepositoryMaterial를 저장한다.
                // ***
                //if (fScenarioData.hasRepositoryMaterial)
                //{
                //    foreach (FTransfer fTrf in fScenarioData.fTransferCollection)
                //    {
                //        fSmt = (FSecsMessageTransfer)fTrf.fMessageTransfer;
                //        if (fSmt.wBit)
                //        {
                //            fSmt.fRepositoryMaterial = fScenarioData.fRepositoryMaterial;
                //        }
                //    }
                //}

                // --

                fLog = new FPlcTransmitterRaisedLog(fXmlNodePtn.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_ResultCode, FXmlTagPTNL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_ResultMessage, FXmlTagPTNL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_EquipmentId, FXmlTagPTNL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_EquipmentName, FXmlTagPTNL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_ScenarioId, FXmlTagPTNL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPTNL.A_ScenarioName, FXmlTagPTNL.D_ScenarioName, fScenarioData.fScenario.name);

                // --                

                if (isPreEvent)
                {
                    pushPreEvent(new FPlcTransmitterRaisedEventArgs(FEventId.PlcTransmitterRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
                }
                else
                {
                    pushEvent(new FPlcTransmitterRaisedEventArgs(FEventId.PlcTransmitterRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDtsl = null;
                fPmt = null;
                fLog = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostTriggerRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeHtr,
            FIObjectLog fIObjectLog
            )
        {
            FScenarioData fScenarioData = null;
            FHostTriggerRaisedLog fLog = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(m_fPcdCore);
                fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeHtr.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                if (fIObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fIObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog)
                {
                    fScenarioData.setDataMessageReceivedLog((FIMessageLog)fIObjectLog);
                }
                else
                {
                    fScenarioData.setIObjectLog(fIObjectLog);
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeHtr));
                fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeHtr, true));

                // --

                fLog = new FHostTriggerRaisedLog(fXmlNodeHtr.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_ResultCode, FXmlTagHTRL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_ResultMessage, FXmlTagHTRL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_EquipmentId, FXmlTagHTRL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_EquipmentName, FXmlTagHTRL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_ScenarioId, FXmlTagHTRL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagHTRL.A_ScenarioName, FXmlTagHTRL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                pushEvent(new FHostTriggerRaisedEventArgs(FEventId.HostTriggerRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fScenarioData = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushHostTransmitterRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeHtn,
            FScenarioData fScenarioData,
            bool isPreEvent
            )
        {
            FDataSetLog fDtsl = null;
            FHostMessageTransfer fHmt = null;
            FHostTransmitterRaisedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeHtn.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeHtn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeHtn));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeHtn, false));
                }

                // --

                if (fScenarioData.hasTransferCollection && fScenarioData.hasMapperPerformedLog)
                {
                    if (fScenarioData.fMapperPerformedLog.hasDataSetLog)
                    {
                        fDtsl = fScenarioData.fMapperPerformedLog.getDataSetLog();
                        // --
                        foreach (FTransfer fTrf in fScenarioData.fTransferCollection)
                        {
                            fHmt = (FHostMessageTransfer)fTrf.fMessageTransfer;
                            fHmt.fXmlNode = FDataMapper.generateHostMessageTransfer(fScenarioData, fDtsl.fXmlNode, fHmt.fXmlNode);
                        }
                    }
                }

                // --

                // ***
                // Primary Message인 경우 Reply Message를 전송받을 경우 RepositoryMaterial를 검색하기 위해 RepositoryMaterial를 저장한다.
                // ***
                if (fScenarioData.hasRepositoryMaterial)
                {
                    foreach (FTransfer fTrf in fScenarioData.fTransferCollection)
                    {
                        fHmt = (FHostMessageTransfer)fTrf.fMessageTransfer;
                        if (fHmt.fHostMessageType == FHostMessageType.Command)
                        {
                            fHmt.fRepositoryMaterial = fScenarioData.fRepositoryMaterial;
                        }
                    }
                }

                // --

                fLog = new FHostTransmitterRaisedLog(fXmlNodeHtn.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_ResultCode, FXmlTagHTNL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_ResultMessage, FXmlTagHTNL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_EquipmentId, FXmlTagHTNL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_EquipmentName, FXmlTagHTNL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_ScenarioId, FXmlTagHTNL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagHTNL.A_ScenarioName, FXmlTagHTNL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                if (isPreEvent)
                {
                    pushPreEvent(new FHostTransmitterRaisedEventArgs(FEventId.HostTransmitterRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
                }
                else
                {
                    pushEvent(new FHostTransmitterRaisedEventArgs(FEventId.HostTransmitterRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDtsl = null;
                fHmt = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushJudgementPerformedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeJdm,
            FScenarioData fScenarioData
            )
        {
            FJudgementPerformedLog fLog = null;
            FIFlow fBranchFlow = null;
            string locationName = string.Empty;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeJdm.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeJdm.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeJdm));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeJdm, true));
                }

                // --

                fBranchFlow = getBranchNextFlow(fXmlNodeJdm, ref locationName);

                // --

                if (!FJudgementParser.parseJudgement(fScenarioData, fXmlNodeJdm))
                {
                    fResultCode = FResultCode.Error;
                    resultMessage = string.Format(FConstants.err_m_0035, "Judgement Condition");

                    // ***
                    // Branch 설정
                    // ***
                    fScenarioData.setNextFlow(fBranchFlow);
                    fScenarioData.setTransferCollection(null);  // Transfer Collection 초기화
                }

                // --

                fLog = new FJudgementPerformedLog(fXmlNodeJdm.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_ResultCode, FXmlTagJDML.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_ResultMessage, FXmlTagJDML.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_EquipmentId, FXmlTagJDML.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_EquipmentName, FXmlTagJDML.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_ScenarioId, FXmlTagJDML.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_ScenarioName, FXmlTagJDML.D_ScenarioName, fScenarioData.fScenario.name);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagJDML.A_LocationName, FXmlTagJDML.D_LocationName, locationName);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FJudgementPerformedEventArgs(FEventId.JudgementPerformed, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
                fBranchFlow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushMapperPerformedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeMap,
            FScenarioData fScenarioData
            )
        {
            FXmlNode fXmlNodeDts = null;
            FXmlNode fXmlNodeDtsl = null;
            FMapperPerformedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeMap.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeMap.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeMap));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeMap, true));
                }

                // --

                fXmlNodeDts = getDataSet(fXmlNodeMap);
                // --
                if (fXmlNodeDts == null)
                {
                    fResultCode = FResultCode.Error;
                    resultMessage = string.Format(FConstants.err_m_0016, "Data Set");
                }
                else
                {
                    fXmlNodeDtsl = FDataMapper.generateDataSetLog(fScenarioData, fXmlNodeDts);
                }

                // --

                fLog = new FMapperPerformedLog(fXmlNodeMap.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_ResultCode, FXmlTagMAPL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_ResultMessage, FXmlTagMAPL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_EquipmentId, FXmlTagMAPL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_EquipmentName, FXmlTagMAPL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_ScenarioId, FXmlTagMAPL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagMAPL.A_ScenarioName, FXmlTagMAPL.D_ScenarioName, fScenarioData.fScenario.name);
                // --
                if (fXmlNodeDtsl != null)
                {
                    fLog.fXmlNode.set_attrVal(
                        FXmlTagMAPL.A_DataSetName,
                        FXmlTagMAPL.D_DataSetName,
                        fXmlNodeDtsl.get_attrVal(FXmlTagDTSL.A_Name, FXmlTagDTSL.D_Name)
                        );
                    // --
                    fLog.fXmlNode.appendChild(fXmlNodeDtsl);

                    // --

                    fScenarioData.setMapperPerformedLog(fLog);  // Mapper Performed Log 설정
                }

                // --

                // ***
                // Result가 Success가 아닐 경우, Next Flow 진행을 중지한다.
                // ***
                if (fResultCode != FResultCode.Success)
                {
                    fScenarioData.setNextFlow(null);
                }

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FMapperPerformedEventArgs(FEventId.MapperPerformed, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDts = null;
                fXmlNodeDtsl = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushEquipmentStateSetAltererPerformedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeEsa,
            FScenarioData fScenarioData
            )
        {
            const string EquipmentsStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='{0}']";

            // --

            FXmlNode fXmlNodeEssl = null;
            FXmlNode fXmlNodeEst = null;
            FEquipmentStateSetAltererPerformedLog fLog = null;
            FEquipmentStateMaterial fEquipmentStateMaterial = null;
            string xpath = string.Empty;
            string essId = string.Empty;
            string estId = string.Empty;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeEsa.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeEsa.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeEsa));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeEsa, true));
                }

                // --

                essId = fXmlNodeEsa.get_attrVal(FXmlTagESA.A_EquipmentStateSetId, FXmlTagESA.D_EquipmentStateSetId);
                if (essId == string.Empty)
                {
                    fResultCode = FResultCode.Error;
                    resultMessage = string.Format(FConstants.err_m_0016, "Equipment State Set");
                }
                else
                {
                    // Equipment State 저장.
                    foreach (FXmlNode fXmlNodeEat in fXmlNodeEsa.fChildNodes)
                    {
                        estId = fXmlNodeEat.get_attrVal(FXmlTagEAT.A_EquipmentStateId, FXmlTagEAT.D_EquipmentStateId);
                        if (essId == string.Empty)
                        {
                            continue;
                        }

                        // --

                        // 설정되어 있는 Equipment State 가 Modeling에 존재하지 않을 경우 Pass
                        xpath = string.Format(EquipmentsStateQuery, estId);
                        fXmlNodeEst = fScenarioData.fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(xpath);
                        if (fXmlNodeEst == null)
                        {
                            continue;
                        }

                        // --

                        // 임시- 추가 attribute로 기존 설정되지 않은 값이 있을경우를 위해...
                        fXmlNodeEat.set_attrVal(
                            FXmlTagEAT.A_EquipmentStateName,
                            FXmlTagEAT.D_EquipmentStateName,
                            fXmlNodeEst.get_attrVal(FXmlTagEST.A_Name, FXmlTagEST.D_Name)
                            );

                        // --

                        fEquipmentStateMaterial = new FEquipmentStateMaterial(
                            fScenarioData.fPcdCore,
                            fXmlNodeEat.get_attrVal(FXmlTagEAT.A_Value, FXmlTagEAT.D_Value)
                            );
                        fEquipmentStateMaterial.setEquipmentStateKey(fScenarioData.fEquipment.uniqueId, ulong.Parse(estId));

                        // --

                        fScenarioData.fPcdCore.fEquipmentStateMaterialStorage.add(fEquipmentStateMaterial);
                    }
                }

                // --

                fLog = new FEquipmentStateSetAltererPerformedLog(fXmlNodeEsa.clone(true));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_ResultCode, FXmlTagESAL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_ResultMessage, FXmlTagESAL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_EquipmentId, FXmlTagESAL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_EquipmentName, FXmlTagESAL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_ScenarioId, FXmlTagESAL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagESAL.A_ScenarioName, FXmlTagESAL.D_ScenarioName, fScenarioData.fScenario.name);
                // --

                if (fLog.hasEquipmentStateSetLog)
                {
                    fXmlNodeEssl = getEquipmentStateSetLog(fXmlNodeEsa);
                    if (fXmlNodeEssl != null)
                    {
                        fLog.fXmlNode.set_attrVal(
                            FXmlTagESAL.A_EquipmentStateSetName,
                            FXmlTagESAL.D_EquipmentStateSetName,
                            fXmlNodeEssl.get_attrVal(FXmlTagESS.A_Name, FXmlTagESS.D_Name)
                            );
                    }
                }

                // --

                fScenarioData.setEquipmentStateSetAltererPerformedLog(fLog);  // Equipment State Set Alterer Performed Log 설정

                // --

                // ***
                // Result가 Success가 아닐 경우, Next Flow 진행을 중지한다.
                // ***
                if (fResultCode != FResultCode.Success)
                {
                    fScenarioData.setNextFlow(null);
                }

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FEquipmentStateSetAltererPerformedEventArgs(FEventId.EquipmentStateSetAltererPerformed, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeEssl = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushStoragePerformedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeStg,
            FScenarioData fScenarioData
            )
        {
            const string RepositoryQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagRPD.E_RepositoryDefinition +
                "/" + FXmlTagRPL.E_RepositoryList +
                "/" + FXmlTagRPS.E_Repository + "[@" + FXmlTagRPS.A_UniqueId + "='{0}']";

            // --

            FStoragePerformedLog fLog = null;
            string rpsId = string.Empty;
            string rpsName = string.Empty;
            FStorageAction fAction;
            FXmlNode fXmlNodeRps = null;
            FXmlNode fXmlNodeRpsl = null;
            FXmlNode[] fXmlNodeRpslArr = null;
            FRepositoryMaterial fRepositoryMaterial = null;
            FIFlow fBranchFlow = null;
            string locationName = string.Empty;
            string xpath = string.Empty;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeStg.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeStg.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeStg));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeStg, true));
                }

                // --

                fAction = FEnumConverter.toStorageAction(fXmlNodeStg.get_attrVal(FXmlTagSTG.A_Action, FXmlTagSTG.D_Action));
                if (fAction == FStorageAction.RemoveAll)
                {
                    // ***
                    // 2017.03.30 by spike.lee
                    // Repository Material All Remove 구현
                    // ***
                    fXmlNodeRpslArr = FRepositoryHandler.removeAllRepository(fScenarioData);
                    fScenarioData.setRepositoryMaterial(null);
                }
                else
                {
                    rpsId = fXmlNodeStg.get_attrVal(FXmlTagSTG.A_RepositoryId, FXmlTagSTG.D_RepositoryId);
                    if (rpsId == string.Empty)
                    {
                        fResultCode = FResultCode.Error;
                        resultMessage = string.Format(FConstants.err_m_0016, "Repository");
                    }
                    else
                    {
                        xpath = string.Format(RepositoryQuery, rpsId);
                        fXmlNodeRps = fScenarioData.fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(xpath);
                        rpsName = fXmlNodeRps.get_attrVal(FXmlTagRPS.A_Name, FXmlTagRPS.D_Name);

                        // --                    

                        fXmlNodeRps = null;
                        // --
                        if (fAction == FStorageAction.Create)
                        {
                            fXmlNodeRpsl = FRepositoryHandler.createRepository(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                            if (fRepositoryMaterial != null)
                            {
                                fScenarioData.fPcdCore.fRepositoryMaterialStorage.add(fRepositoryMaterial);
                                fScenarioData.setRepositoryMaterial(fRepositoryMaterial);
                            }
                        }
                        else if (fAction == FStorageAction.Select)
                        {
                            fXmlNodeRpsl = FRepositoryHandler.selectRepository(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                            if (fRepositoryMaterial != null)
                            {
                                fScenarioData.setRepositoryMaterial(fRepositoryMaterial);
                            }
                        }
                        else if (fAction == FStorageAction.Update)
                        {
                            // ***
                            // 2017.04.03 by spike.lee
                            // Update 구현
                            // ***
                            if (fScenarioData.hasRepositoryMaterial)
                            {
                                fXmlNodeRpsl = FRepositoryHandler.updateRepository(fScenarioData, fXmlNodeStg);
                                fScenarioData.setRepositoryMaterial(fRepositoryMaterial);
                            }
                        }
                        else if (fAction == FStorageAction.Remove)
                        {
                            // ***
                            // 2017.03.30 by spike.lee
                            // Repository Material를 All과 Part로 구분하여 제거하도록 구현
                            // ***
                            if (fScenarioData.hasRepositoryMaterial)
                            {
                                fXmlNodeRpsl = FRepositoryHandler.removeRepository(fScenarioData, fXmlNodeStg);
                                fScenarioData.setRepositoryMaterial(null);
                            }
                        }

                        // --

                        // ***
                        // 2017.03.30 by spike.lee
                        // Repository Material All Remove 구현
                        // ***
                        if (fXmlNodeRpsl == null)
                        {
                            fResultCode = FResultCode.Error;
                            resultMessage = string.Format(FConstants.err_m_0016, "Repository");
                        }
                    }
                }

                // -- 

                fBranchFlow = getBranchNextFlow(fXmlNodeStg, ref locationName);

                // --                

                fLog = new FStoragePerformedLog(fXmlNodeStg.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_ResultCode, FXmlTagSTGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_ResultMessage, FXmlTagSTGL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_EquipmentId, FXmlTagSTGL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_EquipmentName, FXmlTagSTGL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_ScenarioId, FXmlTagSTGL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_ScenarioName, FXmlTagSTGL.D_ScenarioName, fScenarioData.fScenario.name);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_RepositoryName, FXmlTagSTGL.D_RepositoryName, rpsName);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTGL.A_LocationName, FXmlTagSTGL.D_LocationName, locationName);
                // --
                fLog.fXmlNode.set_attrVal(
                    FXmlTagSTGL.A_RepositoryMaterialCount,
                    FXmlTagSTGL.D_RepositoryMaterialCount,
                    fScenarioData.fPcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection.count.ToString()
                    );
                // --
                if (fXmlNodeRpsl != null)
                {
                    fLog.fXmlNode.appendChild(fXmlNodeRpsl);
                }
                else if (fXmlNodeRpslArr != null)
                {
                    // ***
                    // 2017.03.31 by spike.lee
                    // Repository Material All Remove 구현
                    // ***
                    foreach (FXmlNode x in fXmlNodeRpslArr)
                    {
                        fLog.fXmlNode.appendChild(x);
                    }
                }

                // --

                // ***
                // Result가 Success가 아닐 경우, Next Flow 진행을 중지한다.
                // ***
                if (fResultCode != FResultCode.Success)
                {
                    // ***
                    // Branch 설정
                    // ***
                    fScenarioData.setNextFlow(fBranchFlow);
                    fScenarioData.setTransferCollection(null);  // Transfer Collection 초기화
                }

                // --

                // ***
                // 2017.03.30 by spike.lee
                // fScenarioData에 StoragePerformedLog Set 추가
                // ***
                fScenarioData.setStoragePerformedLog(fLog);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, m_fPcdCore.fPlcDriver, fLog, fScenarioData));

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // ***
                if (fResultCode == FResultCode.Success)
                {
                    if (m_fPcdCore.fConfig.enabledRepositorySave)
                    {
                        m_fPcdCore.saveRepositoryMaterial(fAction);
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
                fXmlNodeRps = null;
                fXmlNodeRpsl = null;
                fXmlNodeRpslArr = null;
                fRepositoryMaterial = null;
                fBranchFlow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushCallbackRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeCbk,
            FScenarioData fScenarioData
            )
        {
            FXmlNode fXmlNodeFun = null;
            FCallbackRaisedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeCbk.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeCbk.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeCbk));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeCbk, true));
                }

                // --

                fXmlNodeFun = fXmlNodeCbk.selectSingleNode(FXmlTagFUN.E_Function);
                fScenarioData.setNextFunction(fXmlNodeFun == null ? null : new FFunction(m_fPcdCore, fXmlNodeFun));

                // --

                fLog = new FCallbackRaisedLog(fXmlNodeCbk.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_ResultCode, FXmlTagCBKL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_ResultMessage, FXmlTagCBKL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_EquipmentId, FXmlTagCBKL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_EquipmentName, FXmlTagCBKL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_ScenarioId, FXmlTagCBKL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCBKL.A_ScenarioName, FXmlTagCBKL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FCallbackRaisedEventArgs(FEventId.CallbackRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeFun = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushFunctionCalledEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeFun,
            FScenarioData fScenarioData
            )
        {
            FXmlNode fXmlNodeNextFun = null;
            FFunctionCalledLog fLog = null;

            try
            {
                fXmlNodeNextFun = fXmlNodeFun.fNextSibling;
                fScenarioData.setNextFunction(fXmlNodeNextFun == null ? null : new FFunction(m_fPcdCore, fXmlNodeNextFun));

                // --

                fLog = new FFunctionCalledLog(fXmlNodeFun.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_ResultCode, FXmlTagFUNL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_ResultMessage, FXmlTagFUNL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_EquipmentId, FXmlTagFUNL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_EquipmentName, FXmlTagFUNL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_ScenarioId, FXmlTagFUNL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagFUNL.A_ScenarioName, FXmlTagFUNL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FFunctionCalledEventArgs(FEventId.FunctionCalled, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeNextFun = null;
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushBranchRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeBrn,
            FScenarioData fScenarioData
            )
        {
            FBranchRaisedLog fLog = null;
            string locationName = string.Empty;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeBrn.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeBrn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getBranchNextFlow(fXmlNodeBrn, ref locationName));
                fScenarioData.setTransferCollection(null);  // Transfer Collection 초기화

                // --

                fLog = new FBranchRaisedLog(fXmlNodeBrn.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_ResultCode, FXmlTagBRNL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_ResultMessage, FXmlTagBRNL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_EquipmentId, FXmlTagBRNL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_EquipmentName, FXmlTagBRNL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_ScenarioId, FXmlTagBRNL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_ScenarioName, FXmlTagBRNL.D_ScenarioName, fScenarioData.fScenario.name);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagBRNL.A_LocationName, FXmlTagBRNL.D_LocationName, locationName);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FBranchRaisedEventArgs(FEventId.BranchRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushCommentWrittenEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeCmt,
            FScenarioData fScenarioData
            )
        {
            FCommentWrittenLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeCmt.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeCmt.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeCmt));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeCmt, true));
                }

                // --

                fLog = new FCommentWrittenLog(fXmlNodeCmt.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_ResultCode, FXmlTagCMTL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_ResultMessage, FXmlTagCMTL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_EquipmentId, FXmlTagCMTL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_EquipmentName, FXmlTagCMTL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_ScenarioId, FXmlTagCMTL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCMTL.A_ScenarioName, FXmlTagCMTL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FCommentWrittenEventArgs(FEventId.CommentWritten, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPauserRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodePau,
            FScenarioData fScenarioData
            )
        {
            FPauserRaisedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodePau.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodePau.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodePau));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodePau, true));
                }

                // --

                fLog = new FPauserRaisedLog(fXmlNodePau.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_ResultCode, FXmlTagPAUL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_ResultMessage, FXmlTagPAUL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_EquipmentId, FXmlTagPAUL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_EquipmentName, FXmlTagPAUL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_ScenarioId, FXmlTagPAUL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_ScenarioName, FXmlTagPAUL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                // Pauser Mode 가 Random 인 경우에는 random 값을 계산해서 한다. 
                if (fLog.fPauserMode == FPauserMode.Random)
                {
                    Random rnd = new Random();
                    int rndVal = rnd.Next(fLog.pauseMinTime, fLog.pauseMaxTime);
                    fLog.fXmlNode.set_attrVal(FXmlTagPAUL.A_PauseTime, FXmlTagPAUL.D_PauseTime, rndVal.ToString("d"));
                }

                // --

                m_fPauserAgent.pushPauserData(fLog, fScenarioData);

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FPauserRaisedEventArgs(FEventId.PauserRaised, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushEntryPointCalledEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeEtp,
            object entryPointData
            )
        {
            FScenarioData fScenarioData = null;
            FEntryPointCalledLog fLog = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(m_fPcdCore);
                fScenarioData.setScenario(new FScenario(m_fPcdCore, fXmlNodeEtp.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fPcdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                // --
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeEtp));
                fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeEtp, true));
                // --
                fScenarioData.setEntryPointData(entryPointData);

                // --

                fLog = new FEntryPointCalledLog(fXmlNodeEtp.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_ResultCode, FXmlTagETPL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_ResultMessage, FXmlTagETPL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_EquipmentId, FXmlTagETPL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_EquipmentName, FXmlTagETPL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_ScenarioId, FXmlTagETPL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagETPL.A_ScenarioName, FXmlTagETPL.D_ScenarioName, fScenarioData.fScenario.name);

                // --

                pushEvent(new FEntryPointCalledEventArgs(FEventId.EntryPointCalled, m_fPcdCore.fPlcDriver, fLog, fScenarioData));
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

        public void pushApplicationWrittenEvent(
            FXmlNode fXmlNodeAppl
            )
        {
            FApplicationWrittenLog fLog = null;

            try
            {
                fLog = new FApplicationWrittenLog(fXmlNodeAppl.clone(true));

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                pushPreEvent(new FApplicationWrittenEventArgs(FEventId.ApplicationWritten, m_fPcdCore.fPlcDriver, fLog));
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

        private FIFlow getNextFlow(
            FXmlNode fXmlNodeFlow
            )
        {
            FXmlNode fXmlNodeNextFlow = null;
            FObjectType fType = FObjectType.HostTrigger;

            try
            {
                fXmlNodeNextFlow = fXmlNodeFlow.fNextSibling;
                if (fXmlNodeNextFlow == null)
                {
                    return null;
                }

                // --

                fType = FPlcDriverCommon.getObjectType(fXmlNodeNextFlow);
                if (
                    fType == FObjectType.PlcTransmitter ||
                    fType == FObjectType.HostTransmitter ||
                    fType == FObjectType.Judgement ||
                    fType == FObjectType.EquipmentStateSetAlterer ||
                    fType == FObjectType.Mapper ||
                    fType == FObjectType.Storage ||
                    fType == FObjectType.Callback ||
                    fType == FObjectType.Branch ||
                    fType == FObjectType.Pauser ||
                    fType == FObjectType.Comment
                    )
                {
                    return (FIFlow)FPlcDriverCommon.createObject(m_fPcdCore, fXmlNodeNextFlow);
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeNextFlow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FIFlow getBranchNextFlow(
            FXmlNode fXmlNode,
            ref string locationName
            )
        {
            const string ScenarioQuery =
                FXmlTagEQM.E_EquipmentModeling +
                "/" + FXmlTagEQP.E_Equipment +
                "/" + FXmlTagSNG.E_ScenarioGroup +
                "/" + FXmlTagSNR.E_Scenario + "[@" + FXmlTagSNR.A_UniqueId + "='{0}']";

            // --

            FXmlNode fXmlNodeScn = null;
            FXmlNode fXmlNodeNextFlow = null;
            string locationId = string.Empty;
            string xpath = string.Empty;

            try
            {
                if (fXmlNode.name == FXmlTagBRN.E_Branch)
                {
                    locationId = fXmlNode.get_attrVal(FXmlTagBRN.A_LocationId, FXmlTagBRN.D_LocationId);
                }
                else if (fXmlNode.name == FXmlTagJDM.E_Judgement)
                {
                    locationId = fXmlNode.get_attrVal(FXmlTagJDM.A_LocationId, FXmlTagJDM.D_LocationId);
                }
                else if (fXmlNode.name == FXmlTagSTG.E_Storage)
                {
                    locationId = fXmlNode.get_attrVal(FXmlTagSTG.A_LocationId, FXmlTagSTG.D_LocationId);
                }
                // --
                locationName = string.Empty;
                if (locationId == string.Empty)
                {
                    return null;
                }

                // --

                fXmlNodeScn = m_fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(string.Format(ScenarioQuery, locationId));
                locationName = fXmlNodeScn.get_attrVal(FXmlTagSNR.A_Name, FXmlTagSNR.D_Name);

                // --                

                // ***
                // Scenario First Flow Select (반드시 First인지 점검)
                // ***
                xpath =
                    FXmlTagPTN.E_PlcTransmitter + " | " +
                    FXmlTagHTN.E_HostTransmitter + " | " +
                    FXmlTagESA.E_EquipmentStateSetAlterer + " | " +
                    FXmlTagJDM.E_Judgement + " | " +
                    FXmlTagMAP.E_Mapper + " | " +
                    FXmlTagSTG.E_Storage + " | " +
                    FXmlTagCBK.E_Callback + " | " +
                    FXmlTagBRN.E_Branch + " | " +
                    FXmlTagPAU.E_Pauser + " | " +
                    FXmlTagCMT.E_Comment;
                fXmlNodeNextFlow = fXmlNodeScn.selectSingleNode(xpath);
                // --
                if (fXmlNodeNextFlow == null)
                {
                    return null;
                }
                return (FIFlow)FPlcDriverCommon.createObject(m_fPcdCore, fXmlNodeNextFlow);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeScn = null;
                fXmlNodeNextFlow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FTransferCollection getTransferCollection(
            FXmlNode fXmlNodeFlow,
            bool isFromNext
            )
        {
            FXmlNode fXmlNodeNextFlow = null;
            FObjectType fType = FObjectType.HostTrigger;
            FTransferCollection fTransferCollection = null;

            try
            {
                if (isFromNext)
                {
                    fXmlNodeNextFlow = fXmlNodeFlow.fNextSibling;
                }
                else
                {
                    fXmlNodeNextFlow = fXmlNodeFlow;
                }

                // --

                while (fXmlNodeNextFlow != null)
                {
                    fType = FPlcDriverCommon.getObjectType(fXmlNodeNextFlow);
                    if (fType == FObjectType.PlcTransmitter)
                    {
                        fTransferCollection = new FTransferCollection();
                        foreach (FPlcTransfer fPtn in new FPlcTransferCollection(m_fPcdCore, fXmlNodeNextFlow.selectNodes(FXmlTagPTF.E_PlcTransfer)))
                        {
                            if (fPtn.hasMessage)
                            {
                                fTransferCollection.add(new FTransfer(fPtn, fPtn.fMessage.createTransfer()));
                            }
                        }
                        return fTransferCollection;
                    }
                    else if (fType == FObjectType.HostTransmitter)
                    {
                        fTransferCollection = new FTransferCollection();
                        foreach (FHostTransfer fHtn in new FHostTransferCollection(m_fPcdCore, fXmlNodeNextFlow.selectNodes(FXmlTagHTF.E_HostTransfer)))
                        {
                            if (fHtn.hasMessage)
                            {
                                fTransferCollection.add(new FTransfer(fHtn, fHtn.fMessage.createTransfer()));
                            }
                        }
                        return fTransferCollection;
                    }
                    else if (fType == FObjectType.PlcTrigger || fType == FObjectType.HostTrigger || fType == FObjectType.Branch)
                    {
                        return null;
                    }
                    fXmlNodeNextFlow = fXmlNodeNextFlow.fNextSibling;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeNextFlow = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode getDataSet(
            FXmlNode fXmlNodeMap
            )
        {
            const string DataSetQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagDSD.E_DataSetDefinition +
                "/" + FXmlTagDSL.E_DataSetList +
                "/" + FXmlTagDTS.E_DataSet + "[@" + FXmlTagDTS.A_UniqueId + "='{0}']";

            // --

            string id = string.Empty;
            string xpath = string.Empty;

            try
            {
                id = fXmlNodeMap.get_attrVal(FXmlTagMAP.A_DataSetId, FXmlTagMAP.D_DataSetId);
                if (id == string.Empty)
                {
                    return null;
                }
                // --
                return m_fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(string.Format(DataSetQuery, id)).clone(true);
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

        private FXmlNode getEquipmentStateSetLog(
            FXmlNode fXmlNode
            )
        {
            const string EquipmentStateSetQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet + "[@" + FXmlTagESS.A_UniqueId + "='{0}']";

            // --

            string id = string.Empty;
            string xpath = string.Empty;

            try
            {
                id = fXmlNode.get_attrVal(FXmlTagESAL.A_EquipmentStateSetId, FXmlTagESAL.D_EquipmentStateSetId);
                if (id == string.Empty)
                {
                    return null;
                }
                // --
                return m_fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(string.Format(EquipmentStateSetQuery, id)).clone(true);
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                while (!this.isCompletedEventHandling)
                {
                    if (System.Windows.Forms.Application.MessageLoop)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1);
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

        #region m_fEventPusher Object Event Handler

        private void m_fEventPusher_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            FEventArgsBase args = null;

            try
            {
                // ***
                // PAUSER 가 존재하면 CHECK.
                // ***
                if (m_fPauserAgent.count > 0)
                {
                    m_fPauserAgent.checkTimeoutPauser();
                }

                // --

                if (this.eventCount == 0)
                {
                    // ***
                    // 2017.04.05 by spike.lee
                    // Repository Material Auto Remove 구현
                    // ***
                    if (
                        m_fPcdCore.fConfig.enabledRepositoryAutoRemove &&
                        m_fPcdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection.count > 0 &&
                        m_fTmrRpmRemove.elasped(true)
                        )
                    {
                        m_fPcdCore.removeAutoRepositoryMaterial();
                    }

                    // --

                    m_isCompletedEventHandling = true;
                    e.sleepThread(1);
                    return;
                }
                m_isCompletedEventHandling = false;

                // --

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event 처리를 위해 이중화 Queue 처리
                // PreQueue에 Event를 먼저 처리하도록 수정
                // ***
                while (this.eventCount > 0)
                {
                    args = m_fPreEvents.dequeue();
                    if (args == null)
                    {
                        args = m_fEvents.dequeue();
                    }

                    // --

                    if (args.fPlcEventId == FEventId.ModelingFileOpenCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onModelingFileOpenCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ModelingFileReopenCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onModelingFileReopenCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ModelingFileReopenFailed)
                    {
                        m_fPcdCore.fPlcDriver.onModelingFileReopenFailed(args);
                    }
                    else if (args.fPlcEventId == FEventId.ModelingFileSaveCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onModelingFileSaveCompleted(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.ObjectModifyCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectModifyCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectInsertBeforeCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectInsertBeforeCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectInsertAfterCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectInsertAfterCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectAppendCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectAppendCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectRemoveCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectRemoveCompleted(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.ObjectMoveUpCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectMoveUpCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectMoveDownCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectMoveDownCompleted(args);
                    }
                    else if (args.fPlcEventId == FEventId.ObjectMoveToCompleted)
                    {
                        m_fPcdCore.fPlcDriver.onObjectMoveToCompleted(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.PlcDeviceStateChanged)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceStateChanged(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceErrorRaised)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceErrorRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceTimeoutRaised)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceTimeoutRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceDataReceived)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceDataReceived(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceDataSent)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceDataSent(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceDataMessageRead)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceDataMessageRead(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcDeviceDataMessageWritten)
                    {
                        m_fPcdCore.fPlcDriver.onPlcDeviceDataMessageWritten(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.HostDeviceStateChanged)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceStateChanged(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostDeviceErrorRaised)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceErrorRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostDeviceVfeiReceived)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceVfeiReceived(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostDeviceVfeiSent)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceVfeiSent(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostDeviceDataMessageReceived)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceDataMessageReceived(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostDeviceDataMessageSent)
                    {
                        m_fPcdCore.fPlcDriver.onHostDeviceDataMessageSent(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.PlcTriggerRaised)
                    {
                        m_fPcdCore.fPlcDriver.onPlcTriggerRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.PlcTransmitterRaised)
                    {
                        m_fPcdCore.fPlcDriver.onPlcTransmitterRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostTriggerRaised)
                    {
                        m_fPcdCore.fPlcDriver.onHostTriggerRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.HostTransmitterRaised)
                    {
                        m_fPcdCore.fPlcDriver.onHostTransmitterRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.JudgementPerformed)
                    {
                        m_fPcdCore.fPlcDriver.onJudgementPerformed(args);
                    }
                    else if (args.fPlcEventId == FEventId.MapperPerformed)
                    {
                        m_fPcdCore.fPlcDriver.onMapperPerformed(args);
                    }
                    else if (args.fPlcEventId == FEventId.EquipmentStateSetAltererPerformed)
                    {
                        m_fPcdCore.fPlcDriver.onEquipmentStateSetAltererPerformed(args);
                    }
                    else if (args.fPlcEventId == FEventId.StoragePerformed)
                    {
                        m_fPcdCore.fPlcDriver.onStoragePerformed(args);
                    }
                    else if (args.fPlcEventId == FEventId.CallbackRaised)
                    {
                        m_fPcdCore.fPlcDriver.onCallbackRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.FunctionCalled)
                    {
                        m_fPcdCore.fPlcDriver.onFunctionCalled(args);
                    }
                    else if (args.fPlcEventId == FEventId.BranchRaised)
                    {
                        m_fPcdCore.fPlcDriver.onBranchRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.CommentWritten)
                    {
                        m_fPcdCore.fPlcDriver.onCommentWritten(args);
                    }
                    else if (args.fPlcEventId == FEventId.PauserRaised)
                    {
                        m_fPcdCore.fPlcDriver.onPauserRaised(args);
                    }
                    else if (args.fPlcEventId == FEventId.EntryPointCalled)
                    {
                        m_fPcdCore.fPlcDriver.onEntryPointCalled(args);
                    }
                    else if (args.fPlcEventId == FEventId.ApplicationWritten)
                    {
                        m_fPcdCore.fPlcDriver.onApplicationWritten(args);
                    }
                    // --
                    else if (args.fPlcEventId == FEventId.RecpsitoryMaterialSaved)
                    {
                        // ***
                        // 2017.05.31 by spike.lee
                        // Repository Material Saved 이벤트 추가
                        // ***
                        m_fPcdCore.fPlcDriver.onRepositoryMaterialSaved(args);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                args = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
