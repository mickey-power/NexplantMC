/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseHsms.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.02
--  Description     : FAMate Core FaSecsDriver HSMS Base (FHsmsActive, FHsmsPassive) Class 
--  History         : Created by spike.lee at 2011.09.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal abstract class FBaseHsms : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FHsmsProtocol m_fHsmsProtocol = null;
        private FIDPointer32 m_fSystemBytesPointer = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        // --
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;
        private int m_linkTestPeriod = 0;
        private int m_t3Timeout = 0;
        private int m_t5Timeout = 0;
        private int m_t6Timeout = 0;
        private int m_t7Timeout = 0;
        private int m_t8Timeout = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseHsms(            
            FHsmsProtocol fHsmsProtocol
            )
        {
            m_fHsmsProtocol = fHsmsProtocol;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseHsms(
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
                    m_fHsmsProtocol = null;   
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

        public FHsmsProtocol fHsmsProtocol
        {
            get
            {
                try
                {
                    return m_fHsmsProtocol;
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
                    return m_fHsmsProtocol.fProtocolAgent;
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
                    return m_fHsmsProtocol.fScdCore;
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
                    return m_fHsmsProtocol.fScdCore.fEventPusher;
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
                    return m_fHsmsProtocol.fScdCore.fSecsDriver;
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
                    return m_fHsmsProtocol.fSecsDevice;
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

        public int linkTestPeriod
        {
            get
            {
                try
                {
                    return m_linkTestPeriod;
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

        public int t6Timeout
        {
            get
            {
                try
                {
                    return m_t6Timeout;
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

        public int t7Timeout
        {
            get
            {
                try
                {
                    return m_t7Timeout;
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

        public int t8Timeout
        {
            get
            {
                try
                {
                    return m_t8Timeout;
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

        public abstract void open(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void close(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void send(
            FSecsSession fSecsSession, 
            FSecsMessageTransfer fSecsMessageTransfer
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void pauseProtocol(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void continueProtocol(
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void init(
            )
        {
            UInt32 maxSystemBytes = UInt32.MaxValue;
            try
            {
                // -

                if (m_fHsmsProtocol.fSecsDevice.maxSystemBytes > 0)
                {
                    maxSystemBytes = m_fHsmsProtocol.fSecsDevice.maxSystemBytes;
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
                m_localIp = m_fHsmsProtocol.fSecsDevice.localIp;
                m_localPort = m_fHsmsProtocol.fSecsDevice.localPort;
                m_remoteIp = m_fHsmsProtocol.fSecsDevice.remoteIp;
                m_remotePort = m_fHsmsProtocol.fSecsDevice.remotePort;
                m_linkTestPeriod = m_fHsmsProtocol.fSecsDevice.linkTestTimePeriod * 1000;
                m_t3Timeout = m_fHsmsProtocol.fSecsDevice.t3Timeout * 1000;
                m_t5Timeout = m_fHsmsProtocol.fSecsDevice.t5Timeout * 1000;
                m_t6Timeout = m_fHsmsProtocol.fSecsDevice.t6Timeout * 1000;
                m_t7Timeout = m_fHsmsProtocol.fSecsDevice.t7Timeout * 1000;
                m_t8Timeout = m_fHsmsProtocol.fSecsDevice.t8Timeout * 1000;
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
            FSecsDeviceStateChangedLog fLog = null;
            FXmlNode[] fXmlNodeStrList = null;

            try
            {
                m_fDeviceState = fState;
                
                // --
                
                // ***
                // HSMS Passive2는 Device 상태를 변경할 수 없다.
                // ***
                if (!(this is FHsmsPassive2))
                {
                    this.fSecsDevice.changeState(m_fDeviceState);                    
                }

                // --

                // ***
                // Trigger Parse
                // ***
                if (this.fScdCore.fSecsDriver.enabledEventsOfScenario)
                {
                    fXmlNodeStrList = FSECS2.parseConnectionTrigger(this.fSecsDriver, this.fSecsDevice.fXmlNode, fState);
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

        public string getSelectStatusMessage(
            byte status
            )
        {
            try
            {
                if (status == 0)
                {
                    return string.Empty;
                }
                else if (status == 1)
                {
                    return FConstants.err_m_12001;
                }
                else if (status == 2)
                {
                    return FConstants.err_m_12002;
                }
                else if (status == 3)
                {
                    return FConstants.err_m_12003;
                }
                else if (status < 128)
                {
                    return FConstants.err_m_12004;
                }
                return FConstants.err_m_12128;
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

        public string getDeselectStatusMessage(
            int status
            )
        {
            try
            {
                if (status == 0)
                {
                    return string.Empty;
                }
                else if (status == 1)
                {
                    return FConstants.err_m_14001;
                }
                else if (status == 2)
                {
                    return FConstants.err_m_14002;
                }
                else if (status < 128)
                {
                    return FConstants.err_m_14003;
                }
                return FConstants.err_m_14128;
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

        public string getRejectReasonMessage(
            int reasonCode
            )
        {
            try
            {
                if (reasonCode == 0)
                {
                    return string.Empty;
                }
                else if (reasonCode == 1)
                {
                    return FConstants.err_m_17001;
                }
                else if (reasonCode == 2)
                {
                    return FConstants.err_m_17002;
                }
                else if (reasonCode == 3)
                {
                    return FConstants.err_m_17003;
                }
                else if (reasonCode == 4)
                {
                    return FConstants.err_m_17004;
                }
                else if (reasonCode < 128)
                {
                    return FConstants.err_m_17128;
                }
                return FConstants.err_m_14128;
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

        public string getTimeoutMessage(
            FSecsDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsDeviceTimeout.T3)
                {
                    return FConstants.err_m_20003;
                }
                else if (fTimeout == FSecsDeviceTimeout.T5)
                {
                    return FConstants.err_m_20005;
                }
                else if (fTimeout == FSecsDeviceTimeout.T6)
                {
                    return FConstants.err_m_20006;
                }
                else if (fTimeout == FSecsDeviceTimeout.T7)
                {
                    return FConstants.err_m_20007;
                }
                else if (fTimeout == FSecsDeviceTimeout.T8)
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
            FSecsDeviceTimeout fTimeout
            )
        {
            try
            {
                if (fTimeout == FSecsDeviceTimeout.T3)
                {
                    return FConstants.err_m_21003;
                }
                else if (fTimeout == FSecsDeviceTimeout.T5)
                {
                    return FConstants.err_m_21005;
                }
                else if (fTimeout == FSecsDeviceTimeout.T6)
                {
                    return FConstants.err_m_21006;
                }
                else if (fTimeout == FSecsDeviceTimeout.T7)
                {
                    return FConstants.err_m_21007;
                }
                else if (fTimeout == FSecsDeviceTimeout.T8)
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

        //------------------------------------------------------------------------------------------------------------------------

        public void procDeviceErrorRaised(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end