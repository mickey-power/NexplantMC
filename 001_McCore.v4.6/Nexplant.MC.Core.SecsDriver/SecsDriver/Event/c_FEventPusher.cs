/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventPusher.cs
--  Creator         : spike.lee
--  Create Date     : 2011.02.01
--  Description     : FAMate Core FaSecsDriver Event Pusher Class 
--  History         : Created by spike.lee at 2011.02.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FEventPusher : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private FQueue<FEventArgsBase> m_fPreEvents = null; // 2012.11.01 by spike.lee 선행 Event Queue (Scenario Control Event 용)
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
            FScdCore fScdCore 
            )
        {
            m_fScdCore = fScdCore;
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
                    
                    m_fScdCore = null;                    
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
                m_fEventPusher = new FThread("SecsEventPushThread", false, System.Threading.ThreadPriority.Normal, true);
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

        public FSecsDeviceControlMessageReceivedLog createSecsDeviceControlMessageReceivedLog(
            FSecsDevice fSecsDevice,
            UInt16 sessionId,
            byte byte2,
            byte byte3,
            byte ptype,
            byte stype,
            UInt32 systemBytes,
            UInt32 length,
            FControlMessageType fType
            )
        {
            FSecsDeviceControlMessageReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceControlMessageReceivedLog(FSecsDriverLogCommon.createXmlNodeCMGL(m_fScdCore.fXmlDoc, FXmlTagCMGL.L_Received));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_UniqueId, FXmlTagCMGL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Name, FXmlTagCMGL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Description, FXmlTagCMGL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_FontColor, FXmlTagCMGL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_FontBold, FXmlTagCMGL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Type, FXmlTagCMGL.D_Type, FEnumConverter.fromControlMessageType(fType));
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SessionId, FXmlTagCMGL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Byte2, FXmlTagCMGL.D_Byte2, byte2.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Byte3, FXmlTagCMGL.D_Byte2, byte3.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_PType, FXmlTagCMGL.D_PType, ptype.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SType, FXmlTagCMGL.D_SType, stype.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SystemBytes, FXmlTagCMGL.D_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Length, FXmlTagCMGL.D_Length, length.ToString());
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

        public FSecsDeviceControlMessageSentLog createSecsDeviceControlMessageSentLog(
            FSecsDevice fSecsDevice,
            UInt16 sessionId,
            byte byte2,
            byte byte3,
            byte ptype,
            byte stype,
            UInt32 systemBytes,
            UInt32 length,
            FControlMessageType fType
            )
        {
            FSecsDeviceControlMessageSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceControlMessageSentLog(FSecsDriverLogCommon.createXmlNodeCMGL(m_fScdCore.fXmlDoc, FXmlTagCMGL.L_Sent));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_UniqueId, FXmlTagCMGL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Name, FXmlTagCMGL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Description, FXmlTagCMGL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_FontColor, FXmlTagCMGL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_FontBold, FXmlTagCMGL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Type, FXmlTagCMGL.D_Type, FEnumConverter.fromControlMessageType(fType));
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SessionId, FXmlTagCMGL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Byte2, FXmlTagCMGL.D_Byte2, byte2.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Byte3, FXmlTagCMGL.D_Byte2, byte3.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_PType, FXmlTagCMGL.D_PType, ptype.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SType, FXmlTagCMGL.D_SType, stype.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_SystemBytes, FXmlTagCMGL.D_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Length, FXmlTagCMGL.D_Length, length.ToString());
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

        public FSecsDeviceDataMessageReceivedLog createSecsDeviceDataMessageReceivedLog(
            FXmlNode fXmlNodeSsn,
            FXmlNode fXmlNodeSmgl
            )
        {
            FSecsDeviceDataMessageReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataMessageReceivedLog(fXmlNodeSsn, fXmlNodeSmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.A_LogType, FXmlTagSMGL.L_Received);
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

        public FSecsDeviceDataMessageSentLog createSecsDeviceDataMessageSentLog(
            FXmlNode fXmlNodeSsn,
            FXmlNode fXmlNodeSmgl
            )
        {
            FSecsDeviceDataMessageSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataMessageSentLog(fXmlNodeSsn, fXmlNodeSmgl);
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_LogType, FXmlTagSMGL.A_LogType, FXmlTagSMGL.L_Sent);
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_MessageType, FXmlTagSMGL.D_MessageType, FXmlTagSMGL.M_Message);
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

        public FSecsDeviceHandshakeSentLog createSecsDeviceHandshakeSentLog(
            FSecsDevice fSecsDevice,
            FSecs1HandshakeCode fHandshakeCode
            )
        {
            FSecsDeviceHandshakeSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceHandshakeSentLog(FSecsDriverLogCommon.createXmlNodeSDHL(m_fScdCore.fXmlDoc, FXmlTagSDHL.L_Sent));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_UniqueId, FXmlTagSDHL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Name, FXmlTagSDHL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Description, FXmlTagSDHL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_FontColor, FXmlTagSDHL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_FontBold, FXmlTagSDHL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_HandshakeCode, FXmlTagSDHL.D_HandshakeCode, ((int)fHandshakeCode).ToString());
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

        public FSecsDeviceBlockSentLog createSecsDeviceBlockSentLog(
            FSecsDevice fSecsDevice,
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            int stream,
            int function,
            bool ebit,
            UInt16 blockNo,
            UInt32 systemBytes,
            int length
            )
        {
            FSecsDeviceBlockSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceBlockSentLog(FSecsDriverLogCommon.createXmlNodeSDBL(m_fScdCore.fXmlDoc, FXmlTagSDBL.L_Sent));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_UniqueId, FXmlTagSDBL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Name, FXmlTagSDBL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Description, FXmlTagSDBL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_FontColor, FXmlTagSDBL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_FontBold, FXmlTagSDBL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_RBit, FXmlTagSDBL.D_RBit, FBoolean.fromBool(rbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_SessionId, FXmlTagSDBL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_WBit, FXmlTagSDBL.D_WBit, FBoolean.fromBool(wbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Stream, FXmlTagSDBL.D_Stream, stream.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Function, FXmlTagSDBL.D_Function, function.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_BlockNo, FXmlTagSDBL.D_BlockNo, blockNo.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_SystemBytes, FXmlTagSDBL.D_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Length, FXmlTagSDBL.D_Length, length.ToString());
                //--
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

        public FSecsDeviceTelnetPacketSentLog createSecsDeviceTelnetPacketSentLog(
            FSecsDevice fSecsDevice,
            FTelnetPacketType fPacketType,
            FTelnetCommand fTelnetCommand,
            FTelnetOption fTelnetOption
            )
        {
            FSecsDeviceTelnetPacketSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceTelnetPacketSentLog(FSecsDriverLogCommon.createXmlNodeSDHL(m_fScdCore.fXmlDoc, FXmlTagSDHL.L_Sent));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_UniqueId, FXmlTagSTPL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Name, FXmlTagSTPL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Description, FXmlTagSTPL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontColor, FXmlTagSTPL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontBold, FXmlTagSTPL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType, FEnumConverter.fromTelnetPacketType(fPacketType));
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand, FEnumConverter.fromTelnetCommand(fTelnetCommand));
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetOption, FXmlTagSTPL.D_TelnetOption, FEnumConverter.fromTelnetOption(fTelnetOption));
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

        public void pushPreEvent(
            FEventArgsBase fSecsEvent
            )
        {
            try
            {
                m_fPreEvents.enqueue(fSecsEvent);
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
            FEventArgsBase[] fSecsEvents
            )
        {
            try
            {
                m_fPreEvents.enqueue(fSecsEvents);
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
            FEventArgsBase fSecsEvent
            )
        {
            try
            {
                m_fEvents.enqueue(fSecsEvent);                
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
            FEventArgsBase[] fSecsEvents
            )
        {
            try
            {
                m_fEvents.enqueue(fSecsEvents);
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

        public void pushSecsDeviceStateChangedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort
            )
        {
            FSecsDeviceStateChangedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceStateChangedLog(
                    FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_StateChanged)
                    );
                // --                
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalIp, FXmlTagSDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalPort, FXmlTagSDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemoteIp, FXmlTagSDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemotePort, FXmlTagSDVL.D_RemoteIp, remotePort.ToString());

                // -- 

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device State Changed Event를 Previous Event로 변경
                // ***
                if (fLog.fState == FDeviceState.Closed)
                {
                    pushEvent(new FSecsDeviceStateChangedEventArgs(FEventId.SecsDeviceStateChanged, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
                }
                else
                {
                    pushPreEvent(new FSecsDeviceStateChangedEventArgs(FEventId.SecsDeviceStateChanged, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceStateChangedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            string serialPort,
            int baud
            )
        {
            FSecsDeviceStateChangedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceStateChangedLog(
                    FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_StateChanged)
                    );
                // --                
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_SerialPort, FXmlTagSDVL.D_SerialPort, serialPort);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Baud, FXmlTagSDVL.D_Baud, baud.ToString());
                
                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device State Changed Event를 Previous Event로 변경
                // ***
                if (fLog.fState == FDeviceState.Closed)
                {
                    pushEvent(new FSecsDeviceStateChangedEventArgs(FEventId.SecsDeviceStateChanged, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
                }
                else
                {
                    pushPreEvent(new FSecsDeviceStateChangedEventArgs(FEventId.SecsDeviceStateChanged, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceErrorRaisedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage
            )
        {
            FSecsDeviceErrorRaisedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceErrorRaisedLog(FSecsDriverLogCommon.createXmlNodeSDEL(m_fScdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_ResultCode, FXmlTagSDEL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_ResultMessage, FXmlTagSDEL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_UniqueId, FXmlTagSDEL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_Index, FXmlTagSDEL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_Name, FXmlTagSDEL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_Description, FXmlTagSDEL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_FontColor, FXmlTagSDEL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDEL.A_FontBold, FXmlTagSDEL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Error Raised Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceErrorRaisedEventArgs(FEventId.SecsDeviceErrorRaised, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceTimeoutRaisedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceTimeout fTimeout,
            string reason
            )
        {
            FSecsDeviceTimeoutRaisedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceTimeoutRaisedLog(FSecsDriverLogCommon.createXmlNodeSDTL(m_fScdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_ResultCode, FXmlTagSDTL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_ResultMessage, FXmlTagSDTL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_UniqueId, FXmlTagSDTL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Index, FXmlTagSDTL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Name, FXmlTagSDTL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Description, FXmlTagSDTL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_FontColor, FXmlTagSDTL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_FontBold, FXmlTagSDTL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Reason, FXmlTagSDTL.A_Reason, reason);
                fLog.fXmlNode.set_attrVal(FXmlTagSDTL.A_Timeout, FXmlTagSDTL.D_Timeout, FEnumConverter.fromSecsDeviceTimeout(fTimeout));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Timeout Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceTimeoutRaisedEventArgs(FEventId.SecsDeviceTimeoutRaised, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceDataReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            byte[] data
            )
        {
            FSecsDeviceDataReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataReceivedLog(FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_DataReceived));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalIp, FXmlTagSDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalPort, FXmlTagSDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemoteIp, FXmlTagSDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemotePort, FXmlTagSDVL.D_RemoteIp, remotePort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Length, FXmlTagSDVL.D_Length, data.Length.ToString());

                // --

                pushEvent(new FSecsDeviceDataReceivedEventArgs(FEventId.SecsDeviceDataReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog, data));
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

        public void pushSecsDeviceDataReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            string serialPort,
            int baud,
            byte[] data
            )
        {
            FSecsDeviceDataReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataReceivedLog(FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_DataReceived));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_SerialPort, FXmlTagSDVL.D_SerialPort, serialPort);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Baud, FXmlTagSDVL.D_Baud, baud.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Length, FXmlTagSDVL.D_Length, data.Length.ToString());

                // --
                
                pushEvent(new FSecsDeviceDataReceivedEventArgs(FEventId.SecsDeviceDataReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog, data));
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

        public void pushSecsDeviceDataSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort,
            byte[] data
            )
        {
            FSecsDeviceDataSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataSentLog(FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_DataSent));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalIp, FXmlTagSDVL.D_LocalIp, localIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_LocalPort, FXmlTagSDVL.D_LocalIp, localPort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemoteIp, FXmlTagSDVL.D_RemoteIp, remoteIp);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_RemotePort, FXmlTagSDVL.D_RemoteIp, remotePort.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Length, FXmlTagSDVL.D_Length, data.Length.ToString());

                // --
                                
                pushEvent(new FSecsDeviceDataSentEventArgs(FEventId.SecsDeviceDataSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog, data));
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

        public void pushSecsDeviceDataSentEvent(
           FSecsDevice fSecsDevice,
           FResultCode fResultCode,
           string resultMessage,
           string serialPort,
           int baud,
           byte[] data
           )
        {
            FSecsDeviceDataSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceDataSentLog(FSecsDriverLogCommon.createXmlNodeSDVL(fSecsDevice.fXmlNode, FXmlTagSDVL.L_DataSent));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultCode, FXmlTagSDVL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_ResultMessage, FXmlTagSDVL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Index, FXmlTagSDVL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_SerialPort, FXmlTagSDVL.D_SerialPort, serialPort);
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Baud, FXmlTagSDVL.D_Baud, baud.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDVL.A_Length, FXmlTagSDVL.D_Length, data.Length.ToString());
                
                // --
                
                pushEvent(new FSecsDeviceDataSentEventArgs(FEventId.SecsDeviceDataSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog, data));
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

        public void pushSecsDeviceHandshakeReceivedEvent(
           FSecsDevice fSecsDevice,
           FResultCode fResultCode,
           string resultMessage,
           FSecs1HandshakeCode fHandshakeCode
          )
        {
            FSecsDeviceHandshakeReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceHandshakeReceivedLog(FSecsDriverLogCommon.createXmlNodeSDHL(m_fScdCore.fXmlDoc, FXmlTagSDHL.L_Received));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_ResultCode, FXmlTagSDHL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_ResultMessage, FXmlTagSDHL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_UniqueId, FXmlTagSDHL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Index, FXmlTagSDHL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Name, FXmlTagSDHL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Description, FXmlTagSDHL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_FontColor, FXmlTagSDHL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_FontBold, FXmlTagSDHL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_HandshakeCode, FXmlTagSDHL.D_HandshakeCode, ((int)fHandshakeCode).ToString());

                // --
                
                pushEvent(new FSecsDeviceHandshakeReceivedEventArgs(FEventId.SecsDeviceHandshakeReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceHandshakeSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceHandshakeSentLog fLog
            )
        {
            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_ResultCode, FXmlTagSDHL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_ResultMessage, FXmlTagSDHL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDHL.A_Index, FXmlTagSDHL.D_Index, fSecsDevice.index.ToString());

                // --
                
                pushEvent(new FSecsDeviceHandshakeSentEventArgs(FEventId.SecsDeviceHandshakeSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceTelnetPacketReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FITelnetPacket fTelnetPacket
           )
        {
            FSecsDeviceTelnetPacketReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceTelnetPacketReceivedLog(FSecsDriverLogCommon.createXmlNodeSTPL(m_fScdCore.fXmlDoc, FXmlTagSTPL.L_Received));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_ResultCode, FXmlTagSTPL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_ResultMessage, FXmlTagSTPL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_UniqueId, FXmlTagSTPL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Index, FXmlTagSTPL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Name, FXmlTagSTPL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Description, FXmlTagSTPL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontColor, FXmlTagSTPL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontBold, FXmlTagSTPL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                if (fTelnetPacket.fPacketType == FTelnetPacketType.Data)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType, FEnumConverter.fromTelnetPacketType(fTelnetPacket.fPacketType));
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetData, FXmlTagSTPL.D_TelnetData, FValueConverter.fromValue(FFormat.Binary, ((FTelnetDataPacket)fTelnetPacket).data));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Command)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType, FEnumConverter.fromTelnetPacketType(fTelnetPacket.fPacketType));
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand, FEnumConverter.fromTelnetCommand(((FTelnetCommandPacket)fTelnetPacket).fCommand));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Option)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType, FEnumConverter.fromTelnetPacketType(fTelnetPacket.fPacketType));
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand, FEnumConverter.fromTelnetCommand(((FTelnetOptionPacket)fTelnetPacket).fCommand));
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetOption, FXmlTagSTPL.D_TelnetOption, FEnumConverter.fromTelnetOption(((FTelnetOptionPacket)fTelnetPacket).fOption));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Subnegotiation)
                {

                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Telnet Packet Received Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceTelnetPacketReceivedEventArgs(FEventId.SecsDeviceTelnetPacketReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceTelnetPacketSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FITelnetPacket fTelnetPacket
            )
        {
            FSecsDeviceTelnetPacketSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceTelnetPacketSentLog(FSecsDriverLogCommon.createXmlNodeSTPL(m_fScdCore.fXmlDoc, FXmlTagSTPL.L_Sent));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_ResultCode, FXmlTagSTPL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_ResultMessage, FXmlTagSTPL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_UniqueId, FXmlTagSTPL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Index, FXmlTagSTPL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Name, FXmlTagSTPL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_Description, FXmlTagSTPL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontColor, FXmlTagSTPL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_FontBold, FXmlTagSTPL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_PacketType, FXmlTagSTPL.D_PacketType, FEnumConverter.fromTelnetPacketType(fTelnetPacket.fPacketType));
                if (fTelnetPacket.fPacketType == FTelnetPacketType.Data)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetData, FXmlTagSTPL.D_TelnetData, FValueConverter.fromValue(FFormat.Ascii, ((FTelnetDataPacket)fTelnetPacket).data));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Command)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand, FEnumConverter.fromTelnetCommand(((FTelnetCommandPacket)fTelnetPacket).fCommand));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Option)
                {
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetCommand, FXmlTagSTPL.D_TelnetCommand, FEnumConverter.fromTelnetCommand(((FTelnetOptionPacket)fTelnetPacket).fCommand));
                    fLog.fXmlNode.set_attrVal(FXmlTagSTPL.A_TelnetOption, FXmlTagSTPL.D_TelnetOption, FEnumConverter.fromTelnetOption(((FTelnetOptionPacket)fTelnetPacket).fOption));
                }
                else if (fTelnetPacket.fPacketType == FTelnetPacketType.Subnegotiation)
                {

                }

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Telnet Packet Sent Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceTelnetPacketSentEventArgs(FEventId.SecsDeviceTelnetPacketSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceTelnetStateChangedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FTelnetOption fTelnetOption,
            FTelnetPosition fTelnetPosition,
            FTelnetOptionState fTelnetOptionState
            )
        {
            FSecsDeviceTelnetStateChangedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceTelnetStateChangedLog(FSecsDriverLogCommon.createXmlNodeSTSL(m_fScdCore.fXmlDoc));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_ResultCode, FXmlTagSTSL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_ResultMessage, FXmlTagSTSL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_UniqueId, FXmlTagSTSL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_Index, FXmlTagSTSL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_Name, FXmlTagSTSL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_Description, FXmlTagSTSL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_FontColor, FXmlTagSTSL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_FontBold, FXmlTagSTSL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_TelnetOption, FXmlTagSTSL.D_TelnetOption, FEnumConverter.fromTelnetOption(fTelnetOption));
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_TelnetPosition, FXmlTagSTSL.D_TelnetPosition, FEnumConverter.fromTelnetPosition(fTelnetPosition));
                fLog.fXmlNode.set_attrVal(FXmlTagSTSL.A_TelnetOptionState, FXmlTagSTSL.D_TelnetOptionState, FEnumConverter.fromTelnetOptionState(fTelnetOptionState));

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Telnet State Changed Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceTelnetStateChangedEventArgs(FEventId.SecsDeviceTelnetStateChanged, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceControlMessageReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceControlMessageReceivedLog fLog
            )
        {
            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_ResultCode, FXmlTagCMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_ResultMessage, FXmlTagCMGL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Index, FXmlTagCMGL.D_Index, fSecsDevice.index.ToString());

                // --

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Control Message Received Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceControlMessageReceivedEventArgs(FEventId.SecsDeviceControlMessageReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceControlMessageSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceControlMessageSentLog fLog
            )
        {
            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_ResultCode, FXmlTagCMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_ResultMessage, FXmlTagCMGL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagCMGL.A_Index, FXmlTagCMGL.D_Index, fSecsDevice.index.ToString());

                // -- 

                // ***
                // 2016.12.21 by spike.lee
                // Secs Device Control Message Sent Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FSecsDeviceControlMessageSentEventArgs(FEventId.SecsDeviceControlMessageSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceBlockReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            int stream,
            int function,
            bool ebit,
            UInt16 blockNo,
            UInt32 systemBytes,
            int length
           )
        {
            FSecsDeviceBlockReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceBlockReceivedLog(FSecsDriverLogCommon.createXmlNodeSDBL(m_fScdCore.fXmlDoc, FXmlTagSDBL.L_Received));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_ResultCode, FXmlTagSDBL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_ResultMessage, FXmlTagSDBL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_UniqueId, FXmlTagSDBL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Index, FXmlTagSDBL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Name, FXmlTagSDBL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Description, FXmlTagSDBL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_FontColor, FXmlTagSDBL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_FontBold, FXmlTagSDBL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_RBit, FXmlTagSDBL.D_RBit, FBoolean.fromBool(rbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_SessionId, FXmlTagSDBL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_WBit, FXmlTagSDBL.D_WBit, FBoolean.fromBool(wbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Stream, FXmlTagSDBL.D_Stream, stream.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Function, FXmlTagSDBL.D_Function, function.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_BlockNo, FXmlTagSDBL.D_BlockNo, blockNo.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_SystemBytes, FXmlTagSDBL.D_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Length, FXmlTagSDBL.D_Length, length.ToString());
                
                // --
                
                pushEvent(new FSecsDeviceBlockReceivedEventArgs(FEventId.SecsDeviceBlockReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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
        
        public void pushSecsDeviceBlockSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceBlockSentLog fLog
            )
        {
            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_ResultCode, FXmlTagSDBL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_ResultMessage, FXmlTagSDBL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSDBL.A_Index, FXmlTagSDBL.D_Index, fSecsDevice.index.ToString());
                
                // -- 

                pushEvent(new FSecsDeviceBlockSentEventArgs(FEventId.SecsDeviceBlockSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog));
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

        public void pushSecsDeviceSmlReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            UInt16 sessionId,
            int stream,
            int function,
            bool wbit,
            UInt32 systemBytes,
            UInt32 length,
            string sml
            )
        {
            FSecsDeviceSmlReceivedLog fLog = null;

            try
            {
                fLog = new FSecsDeviceSmlReceivedLog(FSecsDriverLogCommon.createXmlNodeSMLL(m_fScdCore.fXmlDoc, FXmlTagSMLL.L_Received));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_ResultCode, FXmlTagSMLL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_ResultMessage, FXmlTagSMLL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_UniqueId, FXmlTagSMLL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Index, FXmlTagSMLL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Name, FXmlTagSMLL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Description, FXmlTagSMLL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_FontColor, FXmlTagSMLL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_FontBold, FXmlTagSMLL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_SessionId, FXmlTagSMLL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Stream, FXmlTagSMLL.D_Stream, stream.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Function, FXmlTagSMLL.D_Function, function.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_WBit, FXmlTagSMLL.D_WBit, FBoolean.fromBool(wbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_SystemBytes, FXmlTagSMLL.A_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Length, FXmlTagSMLL.D_Length, length.ToString());

                // --

                pushEvent(new FSecsDeviceSmlReceivedEventArgs(FEventId.SecsDeviceSmlReceived, m_fScdCore.fSecsDriver, fSecsDevice, fLog, sml));
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

        public void pushSecsDeviceSmlSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            UInt16 sessionId,
            int stream,
            int function,
            bool wbit,
            UInt32 systemBytes,
            UInt32 length,
            string sml
            )
        {
            FSecsDeviceSmlSentLog fLog = null;

            try
            {
                fLog = new FSecsDeviceSmlSentLog(FSecsDriverLogCommon.createXmlNodeSMLL(m_fScdCore.fXmlDoc, FXmlTagSMLL.L_Sent));
                // -- 
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_ResultCode, FXmlTagSMLL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_ResultMessage, FXmlTagSMLL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_UniqueId, FXmlTagSMLL.D_UniqueId, fSecsDevice.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Index, FXmlTagSMLL.D_Index, fSecsDevice.index.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Name, FXmlTagSMLL.D_Name, fSecsDevice.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Description, FXmlTagSMLL.D_Description, fSecsDevice.description);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_FontColor, FXmlTagSMLL.D_FontColor, fSecsDevice.fontColor.Name);
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_FontBold, FXmlTagSMLL.D_FontBold, FBoolean.fromBool(fSecsDevice.fontBold));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_SessionId, FXmlTagSMLL.D_SessionId, sessionId.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Stream, FXmlTagSMLL.D_Stream, stream.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Function, FXmlTagSMLL.D_Function, function.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_WBit, FXmlTagSMLL.D_WBit, FBoolean.fromBool(wbit));
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_SystemBytes, FXmlTagSMLL.A_SystemBytes, systemBytes.ToString());
                fLog.fXmlNode.set_attrVal(FXmlTagSMLL.A_Length, FXmlTagSMLL.D_Length, length.ToString());

                // --

                pushEvent(new FSecsDeviceSmlSentEventArgs(FEventId.SecsDeviceSmlSent, m_fScdCore.fSecsDriver, fSecsDevice, fLog, sml));
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

        public void pushSecsDeviceDataMessageReceivedEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceDataMessageReceivedLog fLog,
            FSecsMessage fReplySmg
            )
        {
            FSecsSession fSsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultCode, FXmlTagSMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultMessage, FXmlTagSMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodeSsn != null)
                {
                    fSsn = new FSecsSession(m_fScdCore, fLog.fXmlNodeSsn);
                }
                
                // -- 

                pushEvent(new FSecsDeviceDataMessageReceivedEventArgs(FEventId.SecsDeviceDataMessageReceived, m_fScdCore.fSecsDriver, fSecsDevice, fSsn, fLog, fReplySmg));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSsn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushSecsDeviceDataMessageSentEvent(
            FSecsDevice fSecsDevice,
            FResultCode fResultCode,
            string resultMessage,
            FSecsDeviceDataMessageSentLog fLog
            )
        {
            FSecsSession fSsn = null;

            try
            {
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultCode, FXmlTagSMGL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSMGL.A_ResultMessage, FXmlTagSMGL.D_ResultMessage, resultMessage);
                // --
                if (fLog.fXmlNodeSsn != null)
                {
                    fSsn = new FSecsSession(m_fScdCore, fLog.fXmlNodeSsn);
                }

                // -- 

                pushEvent(new FSecsDeviceDataMessageSentEventArgs(FEventId.SecsDeviceDataMessageSent, m_fScdCore.fSecsDriver, fSecsDevice, fSsn, fLog));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSsn = null;
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
                    FSecsDriverLogCommon.createXmlNodeSDVL(fHostDevice.fXmlNode, FXmlTagHDVL.L_StateChanged)
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
                    pushEvent(new FHostDeviceStateChangedEventArgs(FEventId.HostDeviceStateChanged, m_fScdCore.fSecsDriver, fHostDevice, fLog));
                }
                else
                {
                    pushPreEvent(new FHostDeviceStateChangedEventArgs(FEventId.HostDeviceStateChanged, m_fScdCore.fSecsDriver, fHostDevice, fLog));
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
                fLog = new FHostDeviceErrorRaisedLog(FSecsDriverLogCommon.createXmlNodeHDEL(m_fScdCore.fXmlDoc));
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
                // Host Device Error Raised Event를 Previous Event로 변경
                // ***
                pushPreEvent(new FHostDeviceErrorRaisedEventArgs(FEventId.HostDeviceErrorRaised, m_fScdCore.fSecsDriver, fHostDevice, fLog));
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
                fLog = new FHostDeviceVfeiReceivedLog(FSecsDriverLogCommon.createXmlNodeVEFL(m_fScdCore.fXmlDoc, FXmlTagVFEL.L_Received));
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

                pushEvent(new FHostDeviceVfeiReceivedEventArgs(FEventId.HostDeviceVfeiReceived, m_fScdCore.fSecsDriver, fHostDevice, fLog, vfei));
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
                fLog = new FHostDeviceVfeiSentLog(FSecsDriverLogCommon.createXmlNodeVEFL(m_fScdCore.fXmlDoc, FXmlTagVFEL.L_Sent));
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

                pushEvent(new FHostDeviceVfeiSentEventArgs(FEventId.HostDeviceVfeiSent, m_fScdCore.fSecsDriver, fHostDevice, fLog, vfei));
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
                    fHsn = new FHostSession(m_fScdCore, fLog.fXmlNodeHsn);
                }
                
                // --

                pushEvent(new FHostDeviceDataMessageReceivedEventArgs(FEventId.HostDeviceDataMessageReceived, m_fScdCore.fSecsDriver, fHostDevice, fHsn, fLog, fReplyHmg));
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
                    fHsn = new FHostSession(m_fScdCore, fLog.fXmlNodeHsn);
                }

                // --

                pushEvent(new FHostDeviceDataMessageSentEventArgs(FEventId.HostDeviceDataMessageSent, m_fScdCore.fSecsDriver, fHostDevice, fHsn, fLog));
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

        public void pushSecsTriggerRaisedEvent(
           FResultCode fResultCode,
           string resultMessage,
           FXmlNode fXmlNodeStr,
           FIObjectLog fIObjectLog
           )
        {
            FScenarioData fScenarioData = null;
            FSecsTriggerRaisedLog fLog = null;

            try
            {
                // ***
                // 최초 Scenario Data 생성
                // ***
                fScenarioData = new FScenarioData(m_fScdCore);
                fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeStr.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                if (
                    fIObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageReceivedLog ||
                    fIObjectLog.fObjectLogType == FObjectLogType.SecsDeviceDataMessageSentLog
                    )
                {
                    fScenarioData.setDataMessageReceivedLog((FIMessageLog)fIObjectLog);
                }
                else
                {
                    fScenarioData.setIObjectLog(fIObjectLog);
                }      
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeStr));
                fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeStr, true));

                // --

                fLog = new FSecsTriggerRaisedLog(fXmlNodeStr.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_ResultCode, FXmlTagSTRL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_ResultMessage, FXmlTagSTRL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_EquipmentId, FXmlTagSTRL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_EquipmentName, FXmlTagSTRL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_ScenarioId, FXmlTagSTRL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTRL.A_ScenarioName, FXmlTagSTRL.D_ScenarioName, fScenarioData.fScenario.name);

                // -- 

                pushEvent(new FSecsTriggerRaisedEventArgs(FEventId.SecsTriggerRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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

        public void pushSecsTransmitterRaisedEvent(
            FResultCode fResultCode,
            string resultMessage,
            FXmlNode fXmlNodeStn,
            FScenarioData fScenarioData,
            bool isPreEvent
            )
        {
            // --

            FDataSetLog fDtsl = null;
            FSecsMessageTransfer fSmt = null;
            FSecsTransmitterRaisedLog fLog = null;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeStn.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeStn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));                    
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeStn));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeStn, false));
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
                            fSmt = (FSecsMessageTransfer)fTrf.fMessageTransfer;
                            fSmt.fXmlNode = FDataMapper.generateSecsMessageTransfer(fScenarioData, fDtsl.fXmlNode, fSmt.fXmlNode);                            
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
                        fSmt = (FSecsMessageTransfer)fTrf.fMessageTransfer;
                        if (fSmt.wBit)
                        {
                            fSmt.fRepositoryMaterial = fScenarioData.fRepositoryMaterial;
                        }
                    }
                }

                // --

                fLog = new FSecsTransmitterRaisedLog(fXmlNodeStn.clone(false));
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_ResultCode, FXmlTagSTNL.D_ResultCode, FEnumConverter.fromResultCode(fResultCode));
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_ResultMessage, FXmlTagSTNL.D_ResultMessage, resultMessage);
                // --
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_EquipmentId, FXmlTagSTNL.D_EquipmentId, fScenarioData.fEquipment.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_EquipmentName, FXmlTagSTNL.D_EquipmentName, fScenarioData.fEquipment.name);
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_ScenarioId, FXmlTagSTNL.D_ScenarioId, fScenarioData.fScenario.uniqueIdToString);
                fLog.fXmlNode.set_attrVal(FXmlTagSTNL.A_ScenarioName, FXmlTagSTNL.D_ScenarioName, fScenarioData.fScenario.name);
                                
                // --                

                // ***
                // 2012.11.01 by spike.lee
                // 선행 Event (Pre. Event) 처리
                // ***
                if (isPreEvent)
                {
                    pushPreEvent(new FSecsTransmitterRaisedEventArgs(FEventId.SecsTransmitterRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
                }
                else
                {
                    pushEvent(new FSecsTransmitterRaisedEventArgs(FEventId.SecsTransmitterRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDtsl = null;
                fSmt = null;
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
                fScenarioData = new FScenarioData(m_fScdCore);
                fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeHtr.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                // --
                if (
                    fIObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageReceivedLog ||
                    fIObjectLog.fObjectLogType == FObjectLogType.HostDeviceDataMessageSentLog
                    )
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

                pushEvent(new FHostTriggerRaisedEventArgs(FEventId.HostTriggerRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeHtn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                    pushPreEvent(new FHostTransmitterRaisedEventArgs(FEventId.HostTransmitterRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
                }
                else
                {
                    pushEvent(new FHostTransmitterRaisedEventArgs(FEventId.HostTransmitterRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeJdm.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                pushPreEvent(new FJudgementPerformedEventArgs(FEventId.JudgementPerformed, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeMap.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                pushPreEvent(new FMapperPerformedEventArgs(FEventId.MapperPerformed, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeEsa.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                        fXmlNodeEst = fScenarioData.fScdCore.fSecsDriver.fXmlNode.selectSingleNode(xpath);
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
                            fScenarioData.fScdCore, 
                            fXmlNodeEat.get_attrVal(FXmlTagEAT.A_Value, FXmlTagEAT.D_Value));
                        fEquipmentStateMaterial.setEquipmentStateKey(fScenarioData.fEquipment.uniqueId, ulong.Parse(estId));

                        // --

                        fScenarioData.fScdCore.fEquipmentStateMaterialStorage.add(fEquipmentStateMaterial);
                        
                        // --
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
                pushPreEvent(new FEquipmentStateSetAltererPerformedEventArgs(FEventId.EquipmentStateSetAltererPerformed, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
            // --
            bool autoSelect = false;
            bool autoCreate = false;

            try
            {
                // ***
                // Scenario가 달라졌을 경우 Equipment와 Scenario 정보 변경
                // ***
                if (fScenarioData.fScenario.fXmlNode != fXmlNodeStg.fParentNode)
                {
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeStg.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                        fXmlNodeRps = fScenarioData.fScdCore.fSecsDriver.fXmlNode.selectSingleNode(xpath);
                        rpsName = fXmlNodeRps.get_attrVal(FXmlTagRPS.A_Name, FXmlTagRPS.D_Name);

                        // --                    

                        fXmlNodeRps = null;
                        // --
                        if (fAction == FStorageAction.Create)
                        {
                            fXmlNodeRpsl = FRepositoryHandler.createRepository(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                            if (fRepositoryMaterial != null)
                            {
                                fScenarioData.fScdCore.fRepositoryMaterialStorage.add(fRepositoryMaterial);
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
                            // --
                            // ***
                            // 2018.01.09 by jeff.kim
                            // Update시에 자동 Select, 자동 생성 여부 Flag 확인
                            autoSelect = FBoolean.toBool(fXmlNodeStg.get_attrVal(FXmlTagSTG.A_AutoSelect, FXmlTagSTG.D_AutoSelect));
                            autoCreate = FBoolean.toBool(fXmlNodeStg.get_attrVal(FXmlTagSTG.A_AutoCreate, FXmlTagSTG.D_AutoCreate));

                            // --
                            // ***
                            // 2018.01.09 by jeff.kim
                            // Update시에 Select를 자동 수행 한다.
                            // ***
                            if (autoSelect)
                            {
                                fXmlNodeRpsl = FRepositoryHandler.selectRepositoryByKey(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                                if (fRepositoryMaterial != null)
                                {
                                    fScenarioData.setRepositoryMaterial(fRepositoryMaterial);
                                }
                            }                                                       

                            // ***
                            // 2017.04.03 by spike.lee
                            // Update 구현
                            // ***
                            if (fScenarioData.hasRepositoryMaterial)
                            {
                                fXmlNodeRpsl = FRepositoryHandler.updateRepository(fScenarioData, fXmlNodeStg);
                                fScenarioData.setRepositoryMaterial(fRepositoryMaterial);

                                // --
                                // 2019.10.08 by kitae.kim
                                // Update 후, Select 시나리오를 태워 바로 메세지를 보낸다.
                                if (!autoSelect)
                                {
                                    fXmlNodeRpsl = FRepositoryHandler.selectRepository(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                                }
                            }
                            else if (autoCreate)
                            {
                                // --
                                // 2018.01.12 by jeff.kim
                                // 선택된 Repository가 없을 경우, 자동 생성 Flag가 True 일경우 Repository를 생성한다. 
                                fXmlNodeRpsl = FRepositoryHandler.createRepository(fScenarioData, fXmlNodeStg, ref fRepositoryMaterial);
                                if (fRepositoryMaterial != null)
                                {
                                    fScenarioData.fScdCore.fRepositoryMaterialStorage.add(fRepositoryMaterial);
                                    fScenarioData.setRepositoryMaterial(fRepositoryMaterial);
                                }
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
                    fScenarioData.fScdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection.count.ToString()
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
                pushPreEvent(new FStoragePerformedEventArgs(FEventId.StoragePerformed, m_fScdCore.fSecsDriver, fLog, fScenarioData));

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Repository Material Save 구현
                // ***
                if (fResultCode == FResultCode.Success)
                {
                    if (m_fScdCore.fConfig.enabledRepositorySave)
                    {
                        m_fScdCore.saveRepositoryMaterial(fAction);
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeCbk.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
                }
                fScenarioData.setNextFlow(getNextFlow(fXmlNodeCbk));
                // --
                if (fScenarioData.fTransferCollection == null)
                {
                    fScenarioData.setTransferCollection(getTransferCollection(fXmlNodeCbk, true));
                }

                // --

                fXmlNodeFun = fXmlNodeCbk.selectSingleNode(FXmlTagFUN.E_Function);
                fScenarioData.setNextFunction(fXmlNodeFun == null ? null : new FFunction(m_fScdCore, fXmlNodeFun));

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
                pushPreEvent(new FCallbackRaisedEventArgs(FEventId.CallbackRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                fScenarioData.setNextFunction(fXmlNodeNextFun == null ? null : new FFunction(m_fScdCore, fXmlNodeNextFun));

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
                pushPreEvent(new FFunctionCalledEventArgs(FEventId.FunctionCalled, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeBrn.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                pushPreEvent(new FBranchRaisedEventArgs(FEventId.BranchRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeCmt.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                pushPreEvent(new FCommentWrittenEventArgs(FEventId.CommentWritten, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                    fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodePau.fParentNode));
                    fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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
                pushPreEvent(new FPauserRaisedEventArgs(FEventId.PauserRaised, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                fScenarioData = new FScenarioData(m_fScdCore);
                fScenarioData.setScenario(new FScenario(m_fScdCore, fXmlNodeEtp.fParentNode));
                fScenarioData.setEquipment(new FEquipment(m_fScdCore, fScenarioData.fScenario.fXmlNode.fParentNode.fParentNode));
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

                pushEvent(new FEntryPointCalledEventArgs(FEventId.EntryPointCalled, m_fScdCore.fSecsDriver, fLog, fScenarioData));
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
                pushPreEvent(new FApplicationWrittenEventArgs(FEventId.ApplicationWritten, m_fScdCore.fSecsDriver, fLog));
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
            FObjectType fType = FObjectType.SecsTrigger;

            try
            {
                fXmlNodeNextFlow = fXmlNodeFlow.fNextSibling;
                if (fXmlNodeNextFlow == null)
                {
                    return null;
                }

                // --

                fType = FSecsDriverCommon.getObjectType(fXmlNodeNextFlow);
                if (
                    fType == FObjectType.SecsTransmitter ||
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
                    return (FIFlow)FSecsDriverCommon.createObject(m_fScdCore, fXmlNodeNextFlow);
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

                fXmlNodeScn = m_fScdCore.fSecsDriver.fXmlNode.selectSingleNode(string.Format(ScenarioQuery, locationId));
                locationName = fXmlNodeScn.get_attrVal(FXmlTagSCN.A_Name, FXmlTagSCN.D_Name);

                // --                

                // ***
                // Scenario First Flow Select (반드시 First인지 점검)
                // ***
                xpath =
                    FXmlTagSTN.E_SecsTransmitter + " | " +
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
                return (FIFlow)FSecsDriverCommon.createObject(m_fScdCore, fXmlNodeNextFlow);
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
            FObjectType fType = FObjectType.SecsTrigger;
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
                    fType = FSecsDriverCommon.getObjectType(fXmlNodeNextFlow);
                    if (fType == FObjectType.SecsTransmitter)
                    {
                        fTransferCollection = new FTransferCollection();
                        foreach (FSecsTransfer fStn in new FSecsTransferCollection(m_fScdCore, fXmlNodeNextFlow.selectNodes(FXmlTagSTF.E_SecsTransfer)))
                        {
                            if (fStn.hasMessage)
                            {
                                fTransferCollection.add(new FTransfer(fStn, fStn.fMessage.createTransfer()));
                            }                            
                        }
                        return fTransferCollection;
                    }
                    else if (fType == FObjectType.HostTransmitter)
                    {
                        fTransferCollection = new FTransferCollection();
                        foreach (FHostTransfer fHtn in new FHostTransferCollection(m_fScdCore, fXmlNodeNextFlow.selectNodes(FXmlTagHTF.E_HostTransfer)))
                        {
                            if (fHtn.hasMessage)
                            {
                                fTransferCollection.add(new FTransfer(fHtn, fHtn.fMessage.createTransfer()));
                            }                            
                        }
                        return fTransferCollection;
                    }
                    else if (fType == FObjectType.SecsTrigger || fType == FObjectType.HostTrigger || fType == FObjectType.Branch)
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
                return m_fScdCore.fSecsDriver.fXmlNode.selectSingleNode(string.Format(DataSetQuery, id)).clone(true);
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
                return m_fScdCore.fSecsDriver.fXmlNode.selectSingleNode(string.Format(EquipmentStateSetQuery, id)).clone(true);
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
                        m_fScdCore.fConfig.enabledRepositoryAutoRemove && 
                        m_fScdCore.fRepositoryMaterialStorage.fRepositoryMaterialCollection.count > 0 &&
                        m_fTmrRpmRemove.elasped(true)
                        )
                    {
                        m_fScdCore.removeAutoRepositoryMaterial();
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

                    if (args.fSecsEventId == FEventId.ModelingFileOpenCompleted)
                    {
                        m_fScdCore.fSecsDriver.onModelingFileOpenCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ModelingFileReopenCompleted)
                    {
                        m_fScdCore.fSecsDriver.onModelingFileReopenCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ModelingFileReopenFailed)
                    {
                        m_fScdCore.fSecsDriver.onModelingFileReopenFailed(args);
                    }
                    else if (args.fSecsEventId == FEventId.ModelingFileSaveCompleted)
                    {
                        m_fScdCore.fSecsDriver.onModelingFileSaveCompleted(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.ObjectModifyCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectModifyCompleted(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.ObjectInsertBeforeCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectInsertBeforeCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ObjectInsertAfterCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectInsertAfterCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ObjectAppendCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectAppendCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ObjectRemoveCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectRemoveCompleted(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.ObjectMoveUpCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectMoveUpCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ObjectMoveDownCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectMoveDownCompleted(args);
                    }
                    else if (args.fSecsEventId == FEventId.ObjectMoveToCompleted)
                    {
                        m_fScdCore.fSecsDriver.onObjectMoveToCompleted(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.SecsDeviceStateChanged)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceStateChanged(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceErrorRaised)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceErrorRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceTimeoutRaised)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceTimeoutRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceDataReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceDataReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceDataSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceDataSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceTelnetPacketReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceTelnetPacketReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceTelnetPacketSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceTelnetPacketSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceTelnetStateChanged)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceTelnetStateChanged(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceHandshakeReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceHandshakeReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceHandshakeSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceHandshakeSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceControlMessageReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceControlMessageReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceControlMessageSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceControlMessageSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceBlockReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceBlockReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceBlockSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceBlockSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceSmlReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceSmlReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceSmlSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceSmlSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceDataMessageReceived)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceDataMessageReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsDeviceDataMessageSent)
                    {
                        m_fScdCore.fSecsDriver.onSecsDeviceDataMessageSent(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.HostDeviceStateChanged)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceStateChanged(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostDeviceErrorRaised)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceErrorRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostDeviceVfeiReceived)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceVfeiReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostDeviceVfeiSent)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceVfeiSent(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostDeviceDataMessageReceived)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceDataMessageReceived(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostDeviceDataMessageSent)
                    {
                        m_fScdCore.fSecsDriver.onHostDeviceDataMessageSent(args);
                    }
                    // -- 
                    else if (args.fSecsEventId == FEventId.SecsTriggerRaised)
                    {
                        m_fScdCore.fSecsDriver.onSecsTriggerRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.SecsTransmitterRaised)
                    {
                        m_fScdCore.fSecsDriver.onSecsTransmitterRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostTriggerRaised)
                    {
                        m_fScdCore.fSecsDriver.onHostTriggerRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.HostTransmitterRaised)
                    {
                        m_fScdCore.fSecsDriver.onHostTransmitterRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.JudgementPerformed)
                    {
                        m_fScdCore.fSecsDriver.onJudgementPerformed(args);
                    }
                    else if (args.fSecsEventId == FEventId.MapperPerformed)
                    {
                        m_fScdCore.fSecsDriver.onMapperPerformed(args);
                    }
                    else if (args.fSecsEventId == FEventId.EquipmentStateSetAltererPerformed)
                    {
                        m_fScdCore.fSecsDriver.onEquipmentStateSetAltererPerformed(args);
                    }
                    else if (args.fSecsEventId == FEventId.StoragePerformed)
                    {
                        m_fScdCore.fSecsDriver.onStoragePerformed(args);
                    }
                    else if (args.fSecsEventId == FEventId.CallbackRaised)
                    {
                        m_fScdCore.fSecsDriver.onCallbackRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.FunctionCalled)
                    {
                        m_fScdCore.fSecsDriver.onFunctionCalled(args);
                    }
                    else if (args.fSecsEventId == FEventId.BranchRaised)
                    {
                        m_fScdCore.fSecsDriver.onBranchRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.CommentWritten)
                    {
                        m_fScdCore.fSecsDriver.onCommentWritten(args);
                    }
                    else if (args.fSecsEventId == FEventId.PauserRaised)
                    {
                        m_fScdCore.fSecsDriver.onPauserRaised(args);
                    }
                    else if (args.fSecsEventId == FEventId.EntryPointCalled)
                    {
                        m_fScdCore.fSecsDriver.onEntryPointCalled(args);
                    }
                    else if (args.fSecsEventId == FEventId.ApplicationWritten)
                    {
                        m_fScdCore.fSecsDriver.onApplicationWritten(args);
                    }
                    // --
                    else if (args.fSecsEventId == FEventId.RecpsitoryMaterialSaved)
                    {
                        // ***
                        // 2017.05.31 by spike.lee
                        // Repository Material Saved 이벤트 추가
                        // ***
                        m_fScdCore.fSecsDriver.onRepositoryMaterialSaved(args);
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
