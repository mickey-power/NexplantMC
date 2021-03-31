/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.10
--  Description     : FAMate Admin Manager Option Class 
--  History         : Created by mj.kim at 2012.01.10
                    : Modified by spike.lee at 2012.04.03
                        - Source Tuning
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private FFormList m_fChildFormList = null;
        // --
        private string m_fontName = string.Empty;
        private float m_fontSize = 0;
        // --
        private string m_recentDownloadPath = string.Empty;
        private string m_recentLogDownloadPath = string.Empty;
        private string m_recentExportPath = string.Empty;
        // --
        private string m_factory = string.Empty;
        private string m_description = string.Empty;
        // --
        private string m_user = string.Empty;
        private string m_userName = string.Empty;
        private string m_userGroup = string.Empty;
        private FUserAuthorityData m_authority = null;
        // --
        private string m_stationConnectString = string.Empty;
        private int m_stationTimeout = 0;
        private string m_tuneChannelId = string.Empty;
        private string m_castChannelId = string.Empty;
        private string m_ftpIp = string.Empty;
        private bool m_ftpUsedAnonymous = false;
        private string m_ftpUser = string.Empty;
        private string m_ftpPassword = string.Empty;
        // --
        private int m_historySearchPeriod = 0;
        // --
        private bool m_noticePopupEnabled = true;
        private string m_noticeLastTime = string.Empty;
        // --
        private bool m_desktopAlertEnabled = true;
        private bool m_desktopAlertSoundEnabled = true;
        private bool m_desktopAlertServerEnabled = true;
        private bool m_desktopAlertEapEnabled = true;
        private bool m_desktopAlertDeviceEnabled = true;
        // --
        // ***
        // 2017.07.11 by spike.lee
        // Issue Monitoring Count 
        // ***
        private int m_serverIssueMonitoringCount = 0;
        private int m_eapIssueMonitoringCount = 0;
        private int m_equipmentIssueMonitoringCount = 0;
        // --
        private string m_secsInterfaceLogFilterCaption1 = string.Empty;
        private string m_secInterfaceLogFilterSecsItem1 = string.Empty;
        private string m_secsInterfaceLogFilterHostItem1 = string.Empty;
        private string m_secsInterfaceLogFilterCaption2 = string.Empty;
        private string m_secsInterfaceLogFilterSecsItem2 = string.Empty;
        private string m_secsInterfaceLogFilterHostItem2 = string.Empty;
        // --
        private string m_hostIP = string.Empty;
        private string m_hostName = string.Empty;
        private string m_macAddrress = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FAdmCore fAdmCore 
            )
        {
            m_fAdmCore = fAdmCore;
            // --
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
                    // --
                    m_fAdmCore = null;
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

        public FFormList fChildFormList
        {
            get
            {
                try
                {
                    return m_fChildFormList;
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

        public string fontName
        {
            get
            {
                try
                {
                    return m_fontName;
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
                    m_fontName = value;
                }
                catch (Exception ex)
                {
                    FDebug.writeLog(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float fontSize
        {
            get
            {
                try
                {
                    return m_fontSize;
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
                    m_fontSize = value;
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

        public string factory
        {
            get
            {
                try
                {
                    return m_factory;
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

            set
            {
                try
                {
                    m_factory = value;
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

        public string description
        {
            get
            {
                try
                {
                    return m_description;
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

            set
            {
                try
                {
                    m_description = value;
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

        public string user
        {
            get
            {
                try
                {
                    return m_user;
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

            set
            {
                try
                {
                    m_user = value;
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

        public string userName
        {
            get
            {
                try
                {
                    return m_userName;
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

            set
            {
                try
                {
                    m_userName = value;
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

        public string userGroup
        {
            get
            {
                try
                {
                    return m_userGroup;
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

            set
            {
                try
                {
                    m_userGroup = value;
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

        public FUserAuthorityData authority
        {
            get
            {
                try
                {
                    return m_authority;
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

            set
            {
                try
                {
                    m_authority = value;
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

        public string stationConnectString
        {
            get
            {
                try
                {
                    return m_stationConnectString;
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

            set
            {
                try
                {
                    m_stationConnectString = value;
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

        public int stationTimeout
        {
            get
            {
                try
                {
                    return m_stationTimeout;
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
                    m_stationTimeout = value;
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

        public string tuneChannelId
        {
            get
            {
                try
                {
                    return m_tuneChannelId;
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

            set
            {
                try
                {
                    m_tuneChannelId = value;
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

        public string castChannelId
        {
            get
            {
                try
                {
                    return m_castChannelId;
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

            set
            {
                try
                {
                    m_castChannelId = value;
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

        public string ftpIp
        {
            get
            {
                try
                {
                    return m_ftpIp;
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

            set
            {
                try
                {
                    m_ftpIp = value;
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

        public bool ftpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_ftpUsedAnonymous;
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
                    m_ftpUsedAnonymous = value;
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

        public string ftpUser
        {
            get
            {
                try
                {
                    return m_ftpUser;
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

            set
            {
                try
                {
                    m_ftpUser = value;
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

        public string ftpPassword
        {
            get
            {
                try
                {
                    return m_ftpPassword;
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

            set
            {
                try
                {
                    m_ftpPassword = value;
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

        public int historySearchPeriod
        {
            get
            {
                try
                {
                    return m_historySearchPeriod;
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
                    m_historySearchPeriod = value;
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

        public bool noticePopupEnabled
        {
            get
            {
                try
                {
                    return m_noticePopupEnabled;
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
                    m_noticePopupEnabled = value;
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

        public string noticeLastTime
        {
            get
            {
                try
                {
                    return m_noticeLastTime;
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

            set
            {
                try
                {
                    m_noticeLastTime = value;
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

        public bool desktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_desktopAlertEnabled;
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
                    m_desktopAlertEnabled = value;
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

        public bool desktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_desktopAlertSoundEnabled;
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
                    m_desktopAlertSoundEnabled = value;
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

        public bool desktopAlertServerEnabled
        {
            get
            {
                try
                {
                    return m_desktopAlertServerEnabled;
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
                    m_desktopAlertServerEnabled = value;
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

        public bool desktopAlertEapEnabled
        {
            get
            {
                try
                {
                    return m_desktopAlertEapEnabled;
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
                    m_desktopAlertEapEnabled = value;
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

        public bool desktopAlertDeviceEnabled
        {
            get
            {
                try
                {
                    return m_desktopAlertDeviceEnabled;
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
                    m_desktopAlertDeviceEnabled = value;
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

        public int serverIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_serverIssueMonitoringCount;
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
                    m_serverIssueMonitoringCount = value;
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

        public int eapIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_eapIssueMonitoringCount;
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
                    m_eapIssueMonitoringCount = value;
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

        public int equipmentIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_equipmentIssueMonitoringCount;
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
                    m_equipmentIssueMonitoringCount = value;
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

        public string secsInterfaceLogFilterCaption1
        {
            get
            {
                try
                {
                    return m_secsInterfaceLogFilterCaption1;
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
                    m_secsInterfaceLogFilterCaption1 = value;
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

        public string secsInterfaceLogFilterSecsItem1
        {
            get
            {
                try
                {
                    return m_secInterfaceLogFilterSecsItem1;
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
                    m_secInterfaceLogFilterSecsItem1 = value;
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

        public string secsInterfaceLogFilterHostItem1
        {
            get
            {
                try
                {
                    return m_secsInterfaceLogFilterHostItem1;
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
                    m_secsInterfaceLogFilterHostItem1 = value;
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

        public string secsInterfaceLogFilterCaption2
        {
            get
            {
                try
                {
                    return m_secsInterfaceLogFilterCaption2;
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
                    m_secsInterfaceLogFilterCaption2 = value;
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

        public string secsInterfaceLogFilterSecsItem2
        {
            get
            {
                try
                {
                    return m_secsInterfaceLogFilterSecsItem2;
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
                    m_secsInterfaceLogFilterSecsItem2 = value;
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

        public string secsInterfaceLogFilterHostItem2
        {
            get
            {
                try
                {
                    return m_secsInterfaceLogFilterHostItem2;
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
                    m_secsInterfaceLogFilterHostItem2 = value;
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

        public string recentDownloadPath
        {
            get
            {
                try
                {
                    return m_recentDownloadPath;
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
                    m_recentDownloadPath = Directory.Exists(value) ? value : m_fAdmCore.fWsmCore.usrPath;
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

        public string recentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_recentLogDownloadPath;
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
                    m_recentLogDownloadPath = Directory.Exists(value) ? value : m_fAdmCore.fWsmCore.usrPath;
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

        public string recentExportPath
        {
            get
            {
                try
                {
                    return m_recentExportPath;
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
                    m_recentExportPath = Directory.Exists(value) ? value : m_fAdmCore.fWsmCore.usrPath;
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

        public string hostIPAddrress
        {
            get
            {
                try
                {
                    return m_hostIP;
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
                    m_hostIP = value;
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

        public string hostName
        {
            get
            {
                try
                {
                    return m_hostName;
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
                    m_hostName = value;
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

        public string hostMacAddrress
        {
            get
            {
                try
                {
                    return m_macAddrress;
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
                    m_macAddrress = value;
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
                // ***
                // General Information load
                // ***
                m_recentDownloadPath = m_fAdmCore.fWsmOption.adsRecentDownloadPath;
                m_recentLogDownloadPath = m_fAdmCore.fWsmOption.adsRecentLogDownloadPath;
                m_recentExportPath = m_fAdmCore.fWsmOption.adsRecentExportPath;
                // --
                m_fontName = m_fAdmCore.fWsmOption.adsFontName;
                m_fontSize = m_fAdmCore.fWsmOption.adsFontSize;
                // --

                // ***
                // Factory Option load
                // ***
                m_factory = m_fAdmCore.fWsmOption.factory;
                m_description = m_fAdmCore.fWsmOption.description;
                // --
                m_stationConnectString = m_fAdmCore.fWsmOption.adsStationConnectString;
                m_stationTimeout = m_fAdmCore.fWsmOption.adsStationTimeout;
                // --
                m_tuneChannelId = m_fAdmCore.fWsmOption.adsTuneChannelId;
                m_castChannelId = m_fAdmCore.fWsmOption.adsCastChannelId;
                // --
                m_ftpIp = m_fAdmCore.fWsmOption.adsFtpIp;
                m_ftpUsedAnonymous = m_fAdmCore.fWsmOption.adsFtpUsedAnonymous;
                m_ftpUser = m_fAdmCore.fWsmOption.adsFtpUser;
                m_ftpPassword = m_fAdmCore.fWsmOption.adsFtpPassword;
                // --
                m_historySearchPeriod = m_fAdmCore.fWsmOption.adsHistorySearchPeriod;
                // --
                m_noticePopupEnabled = m_fAdmCore.fWsmOption.adsNoticePopupEnabled;
                m_noticeLastTime = m_fAdmCore.fWsmOption.adsNoticeLastTime;
                // --
                m_desktopAlertEnabled = m_fAdmCore.fWsmOption.adsDesktopAlertEnabled;
                m_desktopAlertSoundEnabled = m_fAdmCore.fWsmOption.adsDesktopAlertSoundEnabled;
                m_desktopAlertServerEnabled = m_fAdmCore.fWsmOption.adsDesktopAlertServerEnabled;
                m_desktopAlertEapEnabled = m_fAdmCore.fWsmOption.adsDesktopAlertEapEnabled;
                m_desktopAlertDeviceEnabled = m_fAdmCore.fWsmOption.adsDesktopAlertDeviceEnabled;
                // --
                m_serverIssueMonitoringCount = m_fAdmCore.fWsmOption.adsServerIssueMonitoringCount;
                m_eapIssueMonitoringCount = m_fAdmCore.fWsmOption.adsEapIssueMonitoringCount;
                m_equipmentIssueMonitoringCount = m_fAdmCore.fWsmOption.adsEquipmentIssueMonitoringCount;
                // --
                m_secsInterfaceLogFilterCaption1 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterCaption1;
                m_secInterfaceLogFilterSecsItem1 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterSecsItem1;
                m_secsInterfaceLogFilterHostItem1 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterHostItem1;
                m_secsInterfaceLogFilterCaption2 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterCaption2;
                m_secsInterfaceLogFilterSecsItem2 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterSecsItem2;
                m_secsInterfaceLogFilterHostItem2 = m_fAdmCore.fWsmOption.adsSecsInterfaceLogFilterHostItem2;
                // --

                // ***
                // Login Information
                // ***
                m_user = m_fAdmCore.fWsmOption.user;
                m_userName = m_fAdmCore.fWsmOption.userName;
                m_userGroup = m_fAdmCore.fWsmOption.userGroup;
                // --
                m_hostIP = m_fAdmCore.fWsmOption.hostIP;
                m_hostName = m_fAdmCore.fWsmOption.hostName;

                // --

                m_fChildFormList = new FFormList(m_fAdmCore);
                m_authority = new FUserAuthorityData(m_fAdmCore);
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
                if (m_fChildFormList != null)
                {
                    m_fChildFormList.Dispose();
                    m_fChildFormList = null;
                }

                if (m_authority != null)
                {
                    m_authority.Dispose();
                    m_authority = null;
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

        public void save(
            )
        {
            try
            {
                m_fAdmCore.fWsmOption.adsRecentDownloadPath = m_recentDownloadPath;
                m_fAdmCore.fWsmOption.adsRecentLogDownloadPath = m_recentLogDownloadPath;
                m_fAdmCore.fWsmOption.adsRecentExportPath = m_recentExportPath;
                // --
                m_fAdmCore.fWsmOption.adsFontName = m_fontName;
                m_fAdmCore.fWsmOption.adsFontSize = m_fontSize;
                // --
                m_fAdmCore.fWsmOption.adsNoticeLastTime = m_noticeLastTime;
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
