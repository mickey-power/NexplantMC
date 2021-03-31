/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialToEthernet.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.23
--  Description     : FAmate Converter FaSerialToEthernet Serial to Ethernet Main Class
--  History         : Created by mjkim at 2019.09.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using System.Text;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FSerialToEthernet: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FEventRaisedEventHandler EventRaised = null;

        // --

        private bool m_disposed = false;
        // --
        private bool m_logEnabled = false;
        private string m_logDirectory = string.Empty;
        private string m_logFileNameSuffix = string.Empty;
        private int m_logFileMaxSize = 0;
        private bool m_logMonitoringEnabled = false;
        // --
        private FCommunicationState m_fSerialState = FCommunicationState.Closed;
        private FCommunicationState m_fSocketState = FCommunicationState.Closed;
        private FSerialPluginConfig m_fSerialConfig = null;
        private FSocketConfig m_fSocketConfig = null;
        private FEventPusher m_fEventPusher = null;
        private FSerialPlugin m_fSerial = null;
        private FBaseTcp m_fTcp = null;
        private FLogWriter m_fLogWriter = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialToEthernet(
            string licFileName
            )
        {
            validateLicense(licFileName);     

            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialToEthernet(
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

        public FSerialPluginConfig fSerialConfig
        {
            get
            {
                try
                {
                    return m_fSerialConfig;
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

        public FSocketConfig fSocketConfig
        {
            get
            {
                try
                {
                    return m_fSocketConfig;
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

        public FCommunicationState fSerialState
        {
            get
            {
                try
                {
                    return m_fSerialState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FCommunicationState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCommunicationState fSocketState
        {
            get
            {
                try
                {
                    return m_fSocketState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FCommunicationState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FEventPusher fEventPusher
        {
            get
            {
                try
                {
                    return m_fEventPusher;
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

        public bool logEnabled
        {
            get
            {
                try
                {
                    return m_logEnabled;
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

            set
            {
                try
                {
                    m_logEnabled = value;
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

        public string logDirectory
        {
            get
            {
                try
                {
                    return m_logDirectory;
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
                    m_logDirectory = value;
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

        public string logFileNameSuffix
        {
            get
            {
                try
                {
                    return m_logFileNameSuffix;
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
                    m_logFileNameSuffix = value;
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

        public int logFileMaxSize
        {
            get
            {
                try
                {
                    return m_logFileMaxSize;
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
                    m_logFileMaxSize = value;
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

        public bool logMonitoringEnabled
        {
            get
            {
                try
                {
                    return m_logMonitoringEnabled;
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

            set
            {
                try
                {
                    m_logMonitoringEnabled = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void validateLicense(
            string fileName
            )
        {
            // ***
            // New License File 적용
            // *** 
            FLic2License fLic = null;
            FLic2Info fLicInfo = null;

            try
            {
                fLic = new FLic2License();
                fLicInfo = fLic.validate(fileName);

                // --

                // ***
                // Product 허가 여부 체크
                // ***
                if (fLicInfo.fLicS2hCvt.productEnabled == FYesNo.No)
                {
                    fLic.rasieValidationError("product.enabled");
                }

                // --

                // ***
                // 사용기간 체크
                // ***
                if (fLicInfo.fLicS2hCvt.expireIssuedCheck == FYesNo.Yes && !fLic.validateExpireIssueDate(fLicInfo.fLicS2hCvt.expireIssuedDate))
                {
                    fLic.rasieValidationError("expire.issued.date");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fLic != null)
                {
                    fLic.Dispose();
                    fLic = null;
                }

                if (fLicInfo != null)
                {
                    fLicInfo.Dispose();
                    fLicInfo = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void init(
            )
        {
            try
            {
                m_logDirectory = Application.StartupPath + "\\Log";
                m_logFileNameSuffix = "SerialToEthernet";
                m_logFileMaxSize = 5; // 5MB

                // --

                m_fLogWriter = new FLogWriter(this);

                // -- 

                // ***
                // Serial / TCP/IP Config 생성
                // ***
                m_fSerialConfig = new FSerialPluginConfig(this);
                m_fSocketConfig = new FSocketConfig(this);

                // -

                m_fEventPusher = new FEventPusher(this);
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
                closeAll();

                // --

                if (m_fEventPusher != null)
                {
                    m_fEventPusher.Dispose();
                    m_fEventPusher = null;
                }

                // --

                if (m_fSerialConfig != null)
                {
                    m_fSerialConfig.Dispose();
                    m_fSerialConfig = null;
                }
                if (m_fSocketConfig != null)
                {
                    m_fSocketConfig.Dispose();
                    m_fSocketConfig = null;
                }

                // --

                if (m_fLogWriter != null)
                {
                    m_fLogWriter.Dispose();
                    m_fLogWriter = null;
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

        public void openSerial(
            )
        {
            try
            {
                if (m_fSerialState != FCommunicationState.Closed)
                {
                    return;
                }

                // --

                m_fSerial = new FSerialPlugin(this);
                m_fSerial.open();
            }
            catch (Exception ex)
            {
                if (m_fSerial != null)
                {
                    m_fSerial.Dispose();
                    m_fSerial = null;
                }
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void openSocket(
            )
        {
            try
            {
                if (m_fSocketState != FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fSocketConfig.fConnectMode == FConnectMode.Passive)
                {
                    m_fTcp = new FTcpPassive(this);
                }
                else
                {
                    m_fTcp = new FTcpActive(this);
                }
                // --                
                m_fTcp.open();
            }
            catch (Exception ex)
            {
                if (m_fTcp != null)
                {
                    m_fTcp.Dispose();
                    m_fTcp = null;
                }
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void closeSerial(
            )
        {
            try
            {
                if (m_fSerialState == FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fSerial != null)
                {
                    m_fSerial.close();
                    m_fSerial.Dispose();
                    m_fSerial = null;
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

        public void closeTcp(
            )
        {
            try
            {
                if (m_fSocketState == FCommunicationState.Closed)
                {
                    return;
                }

                // --

                if (m_fTcp != null)
                {
                    m_fTcp.close();
                    m_fTcp.Dispose();
                    m_fTcp = null;
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

        public void openAll(
            )
        {
            try
            {
                openSerial();
                openSocket();
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

        public void closeAll(
            )
        {
            try
            {
                closeTcp();
                closeSerial();
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

        internal void changeSerialState(
            FCommunicationState fState,
            string serialPort,
            int baud
            )
        {
            try
            {
                if (m_fSerialState == fState)
                {
                    return;
                }
                m_fSerialState = fState;
                
                // --
                
                m_fEventPusher.pushSerialEvent(
                    new FSerialPluginStateChangedEventArgs(
                        this, 
                        FEventId.SerialStateChanged, 
                        FResultCode.Success, 
                        string.Empty, 
                        fState, 
                        serialPort, 
                        baud
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

        internal void changeTcpState(
            FCommunicationState fState,
            FConnectMode fConnectMode,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort
            )
        {
            try
            {
                if (m_fSocketState == fState)
                {
                    return;
                }
                m_fSocketState = fState;

                // --

                m_fEventPusher.pushTcpEvent(
                    new FSocketStateChangedEventArgs(
                        this, 
                        FEventId.SocketStateChanged, 
                        FResultCode.Success, 
                        string.Empty,
                        fState,
                        fConnectMode,
                        localIp, 
                        localPort,
                        remoteIp,
                        remotePort
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

        private void sendSerialData(
            FSerialSendData fSerialSendData
            )
        {
            try
            {
                if (this.fSerialState == FCommunicationState.Connected)
                { 
                    m_fSerial.send(fSerialSendData);
                }
                else
                {
                    m_fEventPusher.pushSerialEvent(
                        new FSerialPluginDataSentEventArgs(
                            this, 
                            FEventId.SerialDataSent, 
                            FResultCode.Error, 
                            string.Format(FConstants.err_m_0030, "Serial"), 
                            fSerialSendData
                            )
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

        public void sendSerialData(
            byte[] data
            )
        {
            try
            {
                sendSerialData(
                    new FSerialSendData(data)
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

        private void sendTcpData(
            FSocketSendData fSocketSendData
            )
        {
            try
            {
                if (this.fSocketState == FCommunicationState.Connected)
                {
                    m_fTcp.send(fSocketSendData);
                }
                else
                {
                    m_fEventPusher.pushTcpEvent(
                        new FSocketDataSentEventArgs(
                            this, 
                            FEventId.SocketDataSent, 
                            FResultCode.Error, 
                            string.Format(FConstants.err_m_0030, "TCP/IP"), 
                            fSocketSendData
                            )
                        );
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

        public void sendTcpData(
            FSerialPluginDataTransfer fSerialDataTransfer
            )
        {
            try
            {
                sendTcpData(fSerialDataTransfer.getSerialData());
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

        internal void onEventRaised(
            FEventArgsBase fArgs
            )
        {
            try
            {
                if (m_logEnabled)
                {
                    m_fLogWriter.write(fArgs);
                }

                // --

                if (EventRaised != null)
                {
                    EventRaised(this, fArgs);
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

        public void waitEventHandlingCompleted(
            )
        {
            try
            {
                m_fEventPusher.waitEventHandlingCompleted();
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

        public void writeAppLog(
            string log
            )
        {
            try
            {
                m_fLogWriter.write(log);
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

    }   // Class end
}   // Namespace end
