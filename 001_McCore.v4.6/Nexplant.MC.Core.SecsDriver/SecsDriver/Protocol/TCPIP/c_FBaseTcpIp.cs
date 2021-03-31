/*---------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseTcpIp.cs
--  Creator         : byjeon
--  Create Date     : 2011.12.28
--  Description     : FAMate Core FaSecsDriver TCP/IP Base Class 
--  History         : Created by byjeon at 2011.12.28
                    : Modified by byjeon at 2013.04.25
                        - Tuning Code of the class
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal abstract class FBaseTcpIp : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        protected const string KeyFormat1 = "{0}-{1}-{2}";        // SessionID + Stream + Function (Ignore System Bytes 용)
        protected const string KeyFormat2 = "{0}-{1}-{2}-{3}";    // SessionID + Stream + Function + SystemBytes
        
        // -- 

        private bool m_disposed = false;
        // --
        private FTcpIpProtocol m_fTcpIpProtocol = null;
        private FIDPointer32 m_fSystemBytesPointer = null;
        private FDeviceState m_fDeviceState = FDeviceState.Closed;
        // -- 
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;
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

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseTcpIp(
            FTcpIpProtocol fTcpIpProtocol
            )
        {
            m_fTcpIpProtocol = fTcpIpProtocol;
            // -- 
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseTcpIp(
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
                    m_fTcpIpProtocol = null;
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

        public FTcpIpProtocol fTcpIpProtocol
        {
            get
            {
                try
                {
                    return m_fTcpIpProtocol;
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
                    return m_fTcpIpProtocol.fProtocolAgent;
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
                    return m_fTcpIpProtocol.fScdCore;
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
                    return m_fTcpIpProtocol.fScdCore.fEventPusher;
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
                    return m_fTcpIpProtocol.fScdCore.fSecsDriver;
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
                    return m_fTcpIpProtocol.fSecsDevice;
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

                if (m_fTcpIpProtocol.fSecsDevice.maxSystemBytes > 0)
                {
                    maxSystemBytes = m_fTcpIpProtocol.fSecsDevice.maxSystemBytes;
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
                m_localIp = m_fTcpIpProtocol.fSecsDevice.localIp;
                m_localPort = m_fTcpIpProtocol.fSecsDevice.localPort;
                m_remoteIp = m_fTcpIpProtocol.fSecsDevice.remoteIp;
                m_remotePort = m_fTcpIpProtocol.fSecsDevice.remotePort;
                // -- 
                m_rbit = m_fTcpIpProtocol.fSecsDevice.rbit;
                m_duplicateError = m_fTcpIpProtocol.fSecsDevice.duplicateError;
                m_interleave = m_fTcpIpProtocol.fSecsDevice.interleave;
                m_retryLimit = m_fTcpIpProtocol.fSecsDevice.retryLimit;
                m_ignoreSystemBytes = m_fTcpIpProtocol.fSecsDevice.ignoreSystemBytes;
                // --
                m_t1Timeout = (int)(m_fTcpIpProtocol.fSecsDevice.t1Timeout * 1000);
                m_t2Timeout = (int)(m_fTcpIpProtocol.fSecsDevice.t2Timeout * 1000);
                m_t3Timeout = m_fTcpIpProtocol.fSecsDevice.t3Timeout * 1000;
                m_t4Timeout = m_fTcpIpProtocol.fSecsDevice.t4Timeout * 1000;
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

        protected void changeDeviceState(
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
                        this.localIp,
                        this.localPort,
                        this.remoteIp,
                        this.remotePort
                        );
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

        protected string getTimeoutMessage(
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

        protected string getTimeoutDescription(
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

        protected void procDeviceErrorRaised(
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

        protected void procDeviceErrorRaised(
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

        #endregion
                
        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end