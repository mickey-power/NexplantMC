/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCntCore.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Core Class
--  History         : Created by mjkim at 2019.09.10                        
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public class FCntCore : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_appPath = string.Empty;
        private string m_userPath = string.Empty;
        private string m_optionPath = string.Empty;
        private string m_logPath = string.Empty;
        private string m_tempPath = string.Empty;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private FLogBackupScheduler m_fLogBackupScheduler = null;
        private FMainContainer m_fMainContainer = null;
        private FOption m_fOption = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction 

        public FCntCore(            
            )
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCntCore(
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecs1ToHsms fSecs1ToHsms
        {
            get
            {
                try
                {
                    return m_fSecs1ToHsms;
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

        public FMainContainer fMainContainer
        {
            get
            {
                try
                {
                    return m_fMainContainer;
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

        public FOption fOption
        {
            get
            {
                try
                {
                    return m_fOption;
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

        public string appPath
        {
            get
            {
                try
                {
                    return m_appPath;
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

        public string userPath
        {
            get
            {
                try
                {
                    return m_userPath;
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

        public string optionPath
        {
            get
            {
                try
                {
                    return m_optionPath;
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

        public string logPath
        {
            get
            {
                try
                {
                    return m_logPath;
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

        public string tempPath
        {
            get
            {
                try
                {
                    return m_tempPath;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            string licFileName = string.Empty;

            try
            {
                m_appPath = Application.StartupPath;
                m_userPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Miracom FAmate\\FAmate Bcr v4.5";
                m_optionPath = Path.Combine(m_userPath, "config");
                m_logPath = Path.Combine(m_userPath, "log");
                m_tempPath = Path.Combine(m_userPath, "temp");
                // --
                licFileName = m_appPath + "\\License\\license.lic";

                // --

                // ***
                // Option 생성
                // ***
                m_fOption = new FOption(this);

                // --

                // ***
                // Debug Log 정보 설정
                // ***
                FDebug.logFilePath = m_logPath;
                FDebug.logFileSuffix = m_fOption.adsBcrName;
                FDebug.logFileKeepingPeriod = 30;   // 로그 보관 30일
                FDebug.logFileAutoDeleteEnabled = true;
                                
                // --

                // ***
                // SECS1 to HSMS Converter 생성
                // ***
                m_fSecs1ToHsms = new FSecs1ToHsms(licFileName);
                m_fSecs1ToHsms.logDirectory = m_logPath;
                m_fSecs1ToHsms.logFileMaxSize = m_fOption.adsLogSize;   // MB 단위
                m_fSecs1ToHsms.logFileNameSuffix = m_fOption.adsBcrName;
                m_fSecs1ToHsms.logEnabled = true;
                // -
                setSecs1Option();
                setHsmsOption();

                // --

                // ***
                // Intercepting Message Setup
                // ***
                m_fSecs1ToHsms.addHsmsInterceptingDataMessage(new FInterceptingDataMessage(2, 101));
                m_fSecs1ToHsms.addHsmsInterceptingDataMessage(new FInterceptingDataMessage(2, 103));
                m_fSecs1ToHsms.addHsmsInterceptingDataMessage(new FInterceptingDataMessage(10, 101));

                // --

                // ***
                // Main UI 생성
                // ***
                m_fMainContainer = new FMainContainer(this);

                // --

                // ***
                // Log Backup Scheduler 생성
                // *** 
                m_fLogBackupScheduler = new FLogBackupScheduler(this);
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
                if (m_fLogBackupScheduler != null)
                {
                    m_fLogBackupScheduler.Dispose();
                    m_fLogBackupScheduler = null;
                }

                // --

                if (m_fMainContainer != null)
                {
                    m_fMainContainer.Dispose();
                    m_fMainContainer = null;
                }

                // --

                if (m_fSecs1ToHsms != null)
                {
                    m_fSecs1ToHsms.Dispose();
                    m_fSecs1ToHsms = null;
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

        public void setSecs1Option(
            )
        {
            try
            {
                // ***
                // SECS1 Config 설정
                // ***
                m_fSecs1ToHsms.fSecs1Config.sessionId = m_fOption.secs1SessionId;
                m_fSecs1ToHsms.fSecs1Config.serialPort = m_fOption.secs1SerialPort;
                m_fSecs1ToHsms.fSecs1Config.baud = m_fOption.secs1Baud;
                m_fSecs1ToHsms.fSecs1Config.rbit = m_fOption.secs1Rbit;
                m_fSecs1ToHsms.fSecs1Config.interleave = m_fOption.secs1Interleave;
                m_fSecs1ToHsms.fSecs1Config.duplicateError = m_fOption.secs1DuplicateError;
                m_fSecs1ToHsms.fSecs1Config.ignoreSystemBytes = m_fOption.secs1IgnoreSystemBytes;
                m_fSecs1ToHsms.fSecs1Config.retryLimit = m_fOption.secs1RetryLimit;
                m_fSecs1ToHsms.fSecs1Config.t1Timeout = m_fOption.secs1T1Timeout;
                m_fSecs1ToHsms.fSecs1Config.t2Timeout = m_fOption.secs1T2Timeout;
                m_fSecs1ToHsms.fSecs1Config.t3Timeout = m_fOption.secs1T3Timeout;
                m_fSecs1ToHsms.fSecs1Config.t4Timeout = m_fOption.secs1T4Timeout;
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

        public void setHsmsOption(
            )
        {
            try
            {
                // ***
                // HSMS Config 설정
                // ***
                m_fSecs1ToHsms.fHsmsConfig.sessionId = m_fOption.hsmsSessionId;
                m_fSecs1ToHsms.fHsmsConfig.fConnectMode = m_fOption.hsmsConnectMode;
                m_fSecs1ToHsms.fHsmsConfig.localIp = m_fOption.hsmsLocalIp;
                m_fSecs1ToHsms.fHsmsConfig.localPort = m_fOption.hsmsLocalPort;
                m_fSecs1ToHsms.fHsmsConfig.remoteIp = m_fOption.hsmsRemoteIp;
                m_fSecs1ToHsms.fHsmsConfig.remotePort = m_fOption.hsmsRemotePort;
                m_fSecs1ToHsms.fHsmsConfig.linkTestPeriod = m_fOption.hsmsLinkTestPeriod;
                m_fSecs1ToHsms.fHsmsConfig.t3Timeout = m_fOption.hsmsT3Timeout;
                m_fSecs1ToHsms.fHsmsConfig.t5Timeout = m_fOption.hsmsT5Timeout;
                m_fSecs1ToHsms.fHsmsConfig.t6Timeout = m_fOption.hsmsT6Timeout;
                m_fSecs1ToHsms.fHsmsConfig.t7Timeout = m_fOption.hsmsT7Timeout;
                m_fSecs1ToHsms.fHsmsConfig.t8Timeout = m_fOption.hsmsT8Timeout;
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

    }   // class end
}   // namespace end
