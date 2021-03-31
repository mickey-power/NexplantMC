/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Option Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FCntCore m_fCntCore = null;
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDoc = null;
        // --
        private string m_adsBcrName = string.Empty;
        private string m_adsFtpIp = string.Empty;
        private bool m_adsFtpUsedAnonymous = false;
        private string m_adsFtpUser = string.Empty;
        private string m_adsFtpPassword = string.Empty;
        private int m_adsLogSize = 0;
        private int m_adsLogBackupTime = 0;
        private int m_adsLogCompressCount = 0;
        private int m_adsLogKeepingPeriod = 0;
        // --
        private UInt16 m_secs1SessionId = 0;
        private string m_secs1SerialPort = string.Empty;
        private int m_secs1Baud = 0;
        private bool m_secs1Rbit = false;
        private bool m_secs1Interleave = false;
        private bool m_secs1DuplicateError = false;
        private bool m_secs1IgnoreSystemBytes = false;
        private int m_secs1RetryLimit = 0;
        private float m_secs1T1Timeout = 0;
        private float m_secs1T2Timeout = 0;
        private int m_secs1T3Timeout = 0;
        private int m_secs1T4Timeout = 0;
        // --
        private UInt16 m_hsmsSessionId = 0;
        private FConnectMode m_hsmsConnectMode = FConnectMode.Passive;
        private string m_hsmsLocalIp = string.Empty;
        private int m_hsmsLocalPort = 0;
        private string m_hsmsRemoteIp = string.Empty;
        private int m_hsmsRemotePort = 0;
        private int m_hsmsLinkTestPeriod = 0;
        private int m_hsmsT3Timeout = 0;
        private int m_hsmsT5Timeout = 0;
        private int m_hsmsT6Timeout = 0;
        private int m_hsmsT7Timeout = 0;
        private int m_hsmsT8Timeout = 0;

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Class Contruction and Destruction 

        public FOption(            
            FCntCore fCntCore
            )
        {
            m_fCntCore = fCntCore;
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOption(
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
                    m_fCntCore = null;
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

        public string adsBcrName
        {
            get
            {
                try
                {
                    return m_adsBcrName;
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
                    m_adsBcrName = value;
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

        public string adsFtpIp
        {
            get
            {
                try
                {
                    return m_adsFtpIp;
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
                    m_adsFtpIp = value;
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

        public bool adsFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_adsFtpUsedAnonymous;
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
                    m_adsFtpUsedAnonymous = value;
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

        public string adsFtpUser
        {
            get
            {
                try
                {
                    return m_adsFtpUser;
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
                    m_adsFtpUser = value;
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

        public string adsFtpPassword
        {
            get
            {
                try
                {
                    return m_adsFtpPassword;
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
                    m_adsFtpPassword = value;
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

        public int adsLogSize
        {
            get
            {
                try
                {
                    return m_adsLogSize;
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
                    m_adsLogSize = value;
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

        public int adsLogBackupTime
        {
            get
            {
                try
                {
                    return m_adsLogBackupTime;
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
                    m_adsLogBackupTime = value;
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

        public int adsLogCompressCount
        {
            get
            {
                try
                {
                    return m_adsLogCompressCount;
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
                    m_adsLogCompressCount = value;
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

        public int adsLogKeepingPeriod
        {
            get
            {
                try
                {
                    return m_adsLogKeepingPeriod;
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
                    m_adsLogKeepingPeriod = value;
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

        public UInt16 secs1SessionId
        {
            get
            {
                try
                {
                    return m_secs1SessionId;
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
                    m_secs1SessionId = value;
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

        public string secs1SerialPort
        {
            get
            {
                try
                {
                    return m_secs1SerialPort;
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
                    m_secs1SerialPort = value;
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

        public int secs1Baud
        {
            get
            {
                try
                {
                    return m_secs1Baud;
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
                    m_secs1Baud = value;
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

        public bool secs1Rbit
        {
            get
            {
                try
                {
                    return m_secs1Rbit;
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
                    m_secs1Rbit = value;
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

        public bool secs1Interleave
        {
            get
            {
                try
                {
                    return m_secs1Interleave;
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
                    m_secs1Interleave = value;
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

        public bool secs1DuplicateError
        {
            get
            {
                try
                {
                    return m_secs1DuplicateError;
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
                    m_secs1DuplicateError = value;
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

        public bool secs1IgnoreSystemBytes
        {
            get
            {
                try
                {
                    return m_secs1IgnoreSystemBytes;
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
                    m_secs1IgnoreSystemBytes = value;
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

        public int secs1RetryLimit
        {
            get
            {
                try
                {
                    return m_secs1RetryLimit;
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
                    m_secs1RetryLimit = value;
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

        public float secs1T1Timeout
        {
            get
            {
                try
                {
                    return m_secs1T1Timeout;
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
                    m_secs1T1Timeout = value;
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

        public float secs1T2Timeout
        {
            get
            {
                try
                {
                    return m_secs1T2Timeout;
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
                    m_secs1T2Timeout = value;
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

        public int secs1T3Timeout
        {
            get
            {
                try
                {
                    return m_secs1T3Timeout;
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
                    m_secs1T3Timeout = value;
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

        public int secs1T4Timeout
        {
            get
            {
                try
                {
                    return m_secs1T4Timeout;
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
                    m_secs1T4Timeout = value;
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

        public UInt16 hsmsSessionId
        {
            get
            {
                try
                {
                    return m_hsmsSessionId;
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
                    m_hsmsSessionId = value;
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

        public FConnectMode hsmsConnectMode
        {
            get
            {
                try
                {
                    return m_hsmsConnectMode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConnectMode.Passive;
            }

            set
            {
                try
                {
                    m_hsmsConnectMode = value;
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

        public string hsmsLocalIp
        {
            get
            {
                try
                {
                    return m_hsmsLocalIp;
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
                    m_hsmsLocalIp = value;
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

        public int hsmsLocalPort
        {
            get
            {
                try
                {
                    return m_hsmsLocalPort;
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
                    m_hsmsLocalPort = value;
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

        public string hsmsRemoteIp
        {
            get
            {
                try
                {
                    return m_hsmsRemoteIp;
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
                    m_hsmsRemoteIp = value;
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

        public int hsmsRemotePort
        {
            get
            {
                try
                {
                    return m_hsmsRemotePort;
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
                    m_hsmsRemotePort = value;
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

        public int hsmsLinkTestPeriod
        {
            get
            {
                try
                {
                    return m_hsmsLinkTestPeriod;
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
                    m_hsmsLinkTestPeriod = value;
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

        public int hsmsT3Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT3Timeout;
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
                    m_hsmsT3Timeout = value;
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

        public int hsmsT5Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT5Timeout;
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
                    m_hsmsT5Timeout = value;
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

        public int hsmsT6Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT6Timeout;
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
                    m_hsmsT6Timeout = value;
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

        public int hsmsT7Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT7Timeout;
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
                    m_hsmsT7Timeout = value;
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

        public int hsmsT8Timeout
        {
            get
            {
                try
                {
                    return m_hsmsT8Timeout;
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
                    m_hsmsT8Timeout = value;
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

        private void init(
            )
        {
            try
            {
                m_optionFileName = m_fCntCore.optionPath + "\\NexplantMCCounter.cfg";

                // --

                if (File.Exists(m_optionFileName))
                {
                    loadOption();
                }
                else
                {
                    createOption();
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

        private void term(
            )
        {
            try
            {
                if (m_fXmlDoc != null)
                {
                    m_fXmlDoc.Dispose();
                    m_fXmlDoc = null;
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

        private void loadOption(
            )
        {
            FXmlNode fXmlNodeFAM = null;
            FXmlNode fXmlNodeBRO = null;
            FXmlNode fXmlNodeADO = null;
            FXmlNode fXmlNodeS1O = null;
            FXmlNode fXmlNodeHMO = null;

            try
            {
                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.load(m_optionFileName);

                // --

                fXmlNodeFAM = m_fXmlDoc.selectSingleNode(FXmlTagOption.E_FAmate);
                fXmlNodeBRO = fXmlNodeFAM.selectSingleNode(FXmlTagOption.E_BcrOption);

                // --

                fXmlNodeADO = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_AdsOption);
                // --
                m_adsBcrName = fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsBcrName, FXmlTagOption.D_AdsBcrName);
                m_adsFtpIp = fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsFtpIp, FXmlTagOption.D_AdsFtpIp);
                m_adsFtpUsedAnonymous = bool.Parse(fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsFtpUsedAnonymous, FXmlTagOption.D_AdsFtpUsedAnonymous));
                m_adsFtpUser = fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsFtpUser, FXmlTagOption.D_AdsFtpUser);
                m_adsFtpPassword = fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsFtpPassword, FXmlTagOption.D_AdsFtpPassword);
                m_adsLogSize = int.Parse(fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsLogSize, FXmlTagOption.D_AdsLogSize));
                m_adsLogBackupTime = int.Parse(fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsLogBackupTime, FXmlTagOption.D_AdsLogBackupTime));
                m_adsLogCompressCount = int.Parse(fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsLogCompressCount, FXmlTagOption.D_AdsLogCompressCount));
                m_adsLogKeepingPeriod = int.Parse(fXmlNodeADO.get_attrVal(FXmlTagOption.A_AdsLogKeepingPeriod, FXmlTagOption.D_AdsLogKeepingPeriod));

                // --

                fXmlNodeS1O = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_Secs1Option);
                // --
                m_secs1SessionId = UInt16.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1SessionId, FXmlTagOption.D_Secs1SessionId));
                m_secs1SerialPort = fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1SerialPort, FXmlTagOption.D_Secs1SerialPort);
                m_secs1Baud = int.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1Baud, FXmlTagOption.D_Secs1Baud));
                m_secs1Rbit = bool.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1Rbit, FXmlTagOption.D_Secs1Rbit));
                m_secs1Interleave = bool.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1Interleave, FXmlTagOption.D_Secs1Interleave));
                m_secs1DuplicateError = bool.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1DuplidateError, FXmlTagOption.D_Secs1DuplidateError));
                m_secs1IgnoreSystemBytes = bool.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1IgnoreSystemBytes, FXmlTagOption.D_Secs1IgnoreSystemBytes));
                m_secs1RetryLimit = int.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1RetryLimit, FXmlTagOption.D_Secs1RetryLimit));
                m_secs1T1Timeout = float.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1T1Timeout, FXmlTagOption.D_Secs1T1Timeout));
                m_secs1T2Timeout = float.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1T2Timeout, FXmlTagOption.D_Secs1T2Timeout));
                m_secs1T3Timeout = int.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1T3Timeout, FXmlTagOption.D_Secs1T3Timeout));
                m_secs1T4Timeout = int.Parse(fXmlNodeS1O.get_attrVal(FXmlTagOption.A_Secs1T4Timeout, FXmlTagOption.D_Secs1T4Timeout));

                // --
                
                fXmlNodeHMO = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_HsmsOption);
                // --
                m_hsmsSessionId = UInt16.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsSessionId, FXmlTagOption.D_HsmsSessionId));
                m_hsmsConnectMode = (FConnectMode)Enum.Parse(typeof(FConnectMode), fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsConnectMode, FXmlTagOption.D_HsmsConnectMode));
                m_hsmsLocalIp = fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsLocalIp, FXmlTagOption.D_HsmsLocalIp);
                m_hsmsLocalPort = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsLocalPort, FXmlTagOption.D_HsmsLocalPort));
                m_hsmsRemoteIp = fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsRemoteIp, FXmlTagOption.D_HsmsRemoteIp);
                m_hsmsRemotePort = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsRemotePort, FXmlTagOption.D_HsmsRemotePort));
                m_hsmsLinkTestPeriod = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsLinkTestPeriod, FXmlTagOption.D_HsmsLinkTestPeriod));
                m_hsmsT3Timeout = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsT3Timeout, FXmlTagOption.D_HsmsT3Timeout));
                m_hsmsT5Timeout = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsT5Timeout, FXmlTagOption.D_HsmsT5Timeout));
                m_hsmsT6Timeout = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsT6Timeout, FXmlTagOption.D_HsmsT6Timeout));
                m_hsmsT7Timeout = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsT7Timeout, FXmlTagOption.D_HsmsT7Timeout));
                m_hsmsT8Timeout = int.Parse(fXmlNodeHMO.get_attrVal(FXmlTagOption.A_HsmsT8Timeout, FXmlTagOption.D_HsmsT8Timeout));
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

        private void createOption(
            )
        {
            FXmlNode fXmlNodeFAM = null;
            FXmlNode fXmlNodeBRO = null;
            FXmlNode fXmlNodeADO = null;
            FXmlNode fXmlNodeS1O = null;
            FXmlNode fXmlNodeHMO = null;
            string creationTime = string.Empty;

            try
            {
                creationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                // --

                // ***
                // Admin Service I/F Option Default Value set
                // ***
                m_adsBcrName = FXmlTagOption.D_AdsBcrName;
                m_adsFtpIp = FXmlTagOption.D_AdsFtpIp;
                m_adsFtpUsedAnonymous = bool.Parse(FXmlTagOption.D_AdsFtpUsedAnonymous);
                m_adsFtpUser = FXmlTagOption.D_AdsFtpUser;
                m_adsFtpPassword = FXmlTagOption.D_AdsFtpPassword;
                m_adsLogSize = int.Parse(FXmlTagOption.D_AdsLogSize);
                m_adsLogBackupTime = int.Parse(FXmlTagOption.D_AdsLogBackupTime);
                m_adsLogCompressCount = int.Parse(FXmlTagOption.D_AdsLogCompressCount);
                m_adsLogKeepingPeriod = int.Parse(FXmlTagOption.D_AdsLogKeepingPeriod);

                // --

                // ***
                // SECS1 Option Default Value set
                // ***
                m_secs1SessionId = UInt16.Parse(FXmlTagOption.D_Secs1SessionId);
                m_secs1SerialPort = FXmlTagOption.D_Secs1SerialPort;
                m_secs1Baud = int.Parse(FXmlTagOption.D_Secs1Baud);
                m_secs1Rbit = bool.Parse(FXmlTagOption.D_Secs1Rbit);
                m_secs1Interleave = bool.Parse(FXmlTagOption.D_Secs1Interleave);
                m_secs1DuplicateError = bool.Parse(FXmlTagOption.D_Secs1DuplidateError);
                m_secs1IgnoreSystemBytes = bool.Parse(FXmlTagOption.D_Secs1IgnoreSystemBytes);
                m_secs1RetryLimit = int.Parse(FXmlTagOption.D_Secs1RetryLimit);
                m_secs1T1Timeout = float.Parse(FXmlTagOption.D_Secs1T1Timeout);
                m_secs1T2Timeout = float.Parse(FXmlTagOption.D_Secs1T2Timeout);
                m_secs1T3Timeout = int.Parse(FXmlTagOption.D_Secs1T3Timeout);
                m_secs1T4Timeout = int.Parse(FXmlTagOption.D_Secs1T4Timeout);

                // --

                // ***
                // HSMS Option Default Value set
                // ***
                m_hsmsSessionId = UInt16.Parse(FXmlTagOption.D_HsmsSessionId);
                m_hsmsConnectMode = (FConnectMode)Enum.Parse(typeof(FConnectMode), FXmlTagOption.D_HsmsConnectMode);
                m_hsmsLocalIp = FXmlTagOption.D_HsmsLocalIp;
                m_hsmsLocalPort = int.Parse(FXmlTagOption.D_HsmsLocalPort);
                m_hsmsRemoteIp = FXmlTagOption.D_HsmsRemoteIp;
                m_hsmsRemotePort = int.Parse(FXmlTagOption.D_HsmsRemotePort);
                m_hsmsLinkTestPeriod = int.Parse(FXmlTagOption.D_HsmsLinkTestPeriod);
                m_hsmsT3Timeout = int.Parse(FXmlTagOption.D_HsmsT3Timeout);
                m_hsmsT5Timeout = int.Parse(FXmlTagOption.D_HsmsT5Timeout);
                m_hsmsT6Timeout = int.Parse(FXmlTagOption.D_HsmsT6Timeout);
                m_hsmsT7Timeout = int.Parse(FXmlTagOption.D_HsmsT7Timeout);
                m_hsmsT8Timeout = int.Parse(FXmlTagOption.D_HsmsT8Timeout);

                // --

                m_fXmlDoc = new FXmlDocument();
                m_fXmlDoc.preserveWhiteSpace = false;
                m_fXmlDoc.appendChild(m_fXmlDoc.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                fXmlNodeFAM = m_fXmlDoc.appendChild(m_fXmlDoc.createNode(FXmlTagOption.E_FAmate));
                // --
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileFormat, FXmlTagOption.D_FileFormat, "CFG");
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileVersion, FXmlTagOption.D_FileVersion, "4.5.2.10");
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileCreationTime, FXmlTagOption.D_FileCreationTime, creationTime);
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileUpdateTime, FXmlTagOption.D_FileUpdateTime, creationTime);
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileDescription, FXmlTagOption.D_FileDescription, "FAmate BCR Option File");
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_UniqueIdPointer, FXmlTagOption.D_UniqueIdPointer, "0");

                // --

                fXmlNodeBRO = fXmlNodeFAM.appendChild(m_fXmlDoc.createNode(FXmlTagOption.E_BcrOption));

                // --

                fXmlNodeADO = fXmlNodeBRO.appendChild(m_fXmlDoc.createNode(FXmlTagOption.E_AdsOption));
                // --
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsBcrName, FXmlTagOption.D_AdsBcrName, m_adsBcrName);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpIp, FXmlTagOption.D_AdsFtpIp, m_adsFtpIp);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpUsedAnonymous, FXmlTagOption.D_AdsFtpUsedAnonymous, m_adsFtpUsedAnonymous.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpUser, FXmlTagOption.D_AdsFtpUser, m_adsFtpUser);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpPassword, FXmlTagOption.D_AdsFtpPassword, m_adsFtpPassword);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogSize, FXmlTagOption.D_AdsLogSize, m_adsLogSize.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogBackupTime, FXmlTagOption.D_AdsLogBackupTime, m_adsLogBackupTime.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogCompressCount, FXmlTagOption.D_AdsLogCompressCount, m_adsLogCompressCount.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogKeepingPeriod, FXmlTagOption.D_AdsLogKeepingPeriod, m_adsLogKeepingPeriod.ToString());

                // --

                fXmlNodeS1O = fXmlNodeBRO.appendChild(m_fXmlDoc.createNode(FXmlTagOption.E_Secs1Option));
                // --
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1SessionId, FXmlTagOption.D_Secs1SessionId, m_secs1SessionId.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1SerialPort, FXmlTagOption.D_Secs1SerialPort, m_secs1SerialPort);
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Baud, FXmlTagOption.D_Secs1Baud, m_secs1Baud.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Rbit, FXmlTagOption.D_Secs1Rbit, m_secs1Rbit.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Interleave, FXmlTagOption.D_Secs1Interleave, m_secs1Interleave.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1DuplidateError, FXmlTagOption.D_Secs1DuplidateError, m_secs1DuplicateError.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1IgnoreSystemBytes, FXmlTagOption.D_Secs1IgnoreSystemBytes, m_secs1IgnoreSystemBytes.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1RetryLimit, FXmlTagOption.D_Secs1RetryLimit, m_secs1RetryLimit.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T1Timeout, FXmlTagOption.D_Secs1T1Timeout, m_secs1T1Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T2Timeout, FXmlTagOption.D_Secs1T2Timeout, m_secs1T2Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T3Timeout, FXmlTagOption.D_Secs1T3Timeout, m_secs1T3Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T4Timeout, FXmlTagOption.D_Secs1T4Timeout, m_secs1T4Timeout.ToString());

                // --

                fXmlNodeHMO = fXmlNodeBRO.appendChild(m_fXmlDoc.createNode(FXmlTagOption.E_HsmsOption));
                // --
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsSessionId, FXmlTagOption.D_HsmsSessionId, m_hsmsSessionId.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsConnectMode, FXmlTagOption.D_HsmsConnectMode, m_hsmsConnectMode.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLocalIp, FXmlTagOption.D_HsmsLocalIp, m_hsmsLocalIp);
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLocalPort, FXmlTagOption.D_HsmsLocalPort, m_hsmsLocalPort.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsRemoteIp, FXmlTagOption.D_HsmsRemoteIp, m_hsmsRemoteIp);
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsRemotePort, FXmlTagOption.D_HsmsRemotePort, m_hsmsRemotePort.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLinkTestPeriod, FXmlTagOption.D_HsmsLinkTestPeriod, m_hsmsLinkTestPeriod.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT3Timeout, FXmlTagOption.D_HsmsT3Timeout, m_hsmsT3Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT5Timeout, FXmlTagOption.D_HsmsT5Timeout, m_hsmsT5Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT6Timeout, FXmlTagOption.D_HsmsT6Timeout, m_hsmsT6Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT7Timeout, FXmlTagOption.D_HsmsT7Timeout, m_hsmsT7Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT8Timeout, FXmlTagOption.D_HsmsT8Timeout, m_hsmsT8Timeout.ToString());

                // --

                if (!Directory.Exists(m_fCntCore.optionPath))
                {
                    Directory.CreateDirectory(m_fCntCore.optionPath);
                }
                m_fXmlDoc.save(m_optionFileName);
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

        public void save(
            )
        {
            FXmlNode fXmlNodeFAM = null;
            FXmlNode fXmlNodeBRO = null;
            FXmlNode fXmlNodeADO = null;
            FXmlNode fXmlNodeS1O = null;
            FXmlNode fXmlNodeHMO = null;
            string updateTime = string.Empty;

            try
            {
                if (m_fXmlDoc == null)
                {
                    return;
                }

                // --

                updateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

                // --

                fXmlNodeFAM = m_fXmlDoc.selectSingleNode(FXmlTagOption.E_FAmate);
                // --
                fXmlNodeFAM.set_attrVal(FXmlTagOption.A_FileUpdateTime, FXmlTagOption.D_FileUpdateTime, updateTime);

                // --

                fXmlNodeBRO = fXmlNodeFAM.selectSingleNode(FXmlTagOption.E_BcrOption);

                // --

                fXmlNodeADO = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_AdsOption);
                // --
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsBcrName, FXmlTagOption.D_AdsBcrName, m_adsBcrName);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpIp, FXmlTagOption.D_AdsFtpIp, m_adsFtpIp);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpUsedAnonymous, FXmlTagOption.D_AdsFtpUsedAnonymous, m_adsFtpUsedAnonymous.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpUser, FXmlTagOption.D_AdsFtpUser, m_adsFtpUser);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsFtpPassword, FXmlTagOption.D_AdsFtpPassword, m_adsFtpPassword);
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogSize, FXmlTagOption.D_AdsLogSize, m_adsLogSize.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogBackupTime, FXmlTagOption.D_AdsLogBackupTime, m_adsLogBackupTime.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogCompressCount, FXmlTagOption.D_AdsLogCompressCount, m_adsLogCompressCount.ToString());
                fXmlNodeADO.set_attrVal(FXmlTagOption.A_AdsLogKeepingPeriod, FXmlTagOption.D_AdsLogKeepingPeriod, m_adsLogKeepingPeriod.ToString());

                // --

                fXmlNodeS1O = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_Secs1Option);
                // --
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1SessionId, FXmlTagOption.D_Secs1SessionId, m_secs1SessionId.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1SerialPort, FXmlTagOption.D_Secs1SerialPort, m_secs1SerialPort);
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Baud, FXmlTagOption.D_Secs1Baud, m_secs1Baud.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Rbit, FXmlTagOption.D_Secs1Rbit, m_secs1Rbit.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1Interleave, FXmlTagOption.D_Secs1Interleave, m_secs1Interleave.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1DuplidateError, FXmlTagOption.D_Secs1DuplidateError, m_secs1DuplicateError.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1IgnoreSystemBytes, FXmlTagOption.D_Secs1IgnoreSystemBytes, m_secs1IgnoreSystemBytes.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1RetryLimit, FXmlTagOption.D_Secs1RetryLimit, m_secs1RetryLimit.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T1Timeout, FXmlTagOption.D_Secs1T1Timeout, m_secs1T1Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T2Timeout, FXmlTagOption.D_Secs1T2Timeout, m_secs1T2Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T3Timeout, FXmlTagOption.D_Secs1T3Timeout, m_secs1T3Timeout.ToString());
                fXmlNodeS1O.set_attrVal(FXmlTagOption.A_Secs1T4Timeout, FXmlTagOption.D_Secs1T4Timeout, m_secs1T4Timeout.ToString());

                // --

                fXmlNodeHMO = fXmlNodeBRO.selectSingleNode(FXmlTagOption.E_HsmsOption);
                // --
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsSessionId, FXmlTagOption.D_HsmsSessionId, m_hsmsSessionId.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsConnectMode, FXmlTagOption.D_HsmsConnectMode, m_hsmsConnectMode.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLocalIp, FXmlTagOption.D_HsmsLocalIp, m_hsmsLocalIp);
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLocalPort, FXmlTagOption.D_HsmsLocalPort, m_hsmsLocalPort.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsRemoteIp, FXmlTagOption.D_HsmsRemoteIp, m_hsmsRemoteIp);
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsRemotePort, FXmlTagOption.D_HsmsRemotePort, m_hsmsRemotePort.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsLinkTestPeriod, FXmlTagOption.D_HsmsLinkTestPeriod, m_hsmsLinkTestPeriod.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT3Timeout, FXmlTagOption.D_HsmsT3Timeout, m_hsmsT3Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT5Timeout, FXmlTagOption.D_HsmsT5Timeout, m_hsmsT5Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT6Timeout, FXmlTagOption.D_HsmsT6Timeout, m_hsmsT6Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT7Timeout, FXmlTagOption.D_HsmsT7Timeout, m_hsmsT7Timeout.ToString());
                fXmlNodeHMO.set_attrVal(FXmlTagOption.A_HsmsT8Timeout, FXmlTagOption.D_HsmsT8Timeout, m_hsmsT8Timeout.ToString());

                // --

                if (!Directory.Exists(m_fCntCore.optionPath))
                {
                    Directory.CreateDirectory(m_fCntCore.optionPath);
                }
                m_fXmlDoc.save(m_optionFileName);
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
