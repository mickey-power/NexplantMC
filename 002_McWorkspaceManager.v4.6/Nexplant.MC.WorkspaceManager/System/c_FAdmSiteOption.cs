/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAdmSiteOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate Admin Manager Site Option Information Class 
--  History         : Created by jungyoul.moon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.WorkspaceManager
{
    public class FAdmSiteOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_adsStationConnectString = string.Empty;
        private int m_adsStationTimeout = 0;
        private string m_adsTuneChannelId = string.Empty;
        private string m_adsCastChannelId = string.Empty;
        private string m_adsFtpIp = string.Empty;
        private bool m_adsFtpUsedAnonymous = true;
        private string m_adsFtpUser = FXmlTagWSMOption.D_AdsFtpUser;
        private string m_adsFtpPassword = string.Empty;
        private int m_adsHistorySearchPeriod = 0;
        private bool m_adsNoticePopupEnabled = true;
        private string m_adsNoticeLastTime = string.Empty;
        private bool m_adsDesktopAlertEnabled = true;
        private bool m_adsDesktopAlertSoundEnabled = true;
        private bool m_adsDesktopAlertServerEnabled = true;
        private bool m_adsDesktopAlertEapEnabled = true;
        private bool m_adsDesktopAlertDeviceEnabled = true;
        private int m_adsServerIssueMonitoringCount = 0;
        private int m_adsEapIssueMonitoringCount = 0;
        private int m_adsEquipmentIssueMonitoringCount = 0;
        private string m_adsSecsInterfaceLogFilterCaption1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterSecsItem1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterHostItem1 = string.Empty;
        private string m_adsSecsInterfaceLogFilterCaption2 = string.Empty;
        private string m_adsSecsInterfaceLogFilterSecsItem2 = string.Empty;
        private string m_adsSecsInterfaceLogFilterHostItem2 = string.Empty;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAdmSiteOption(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAdmSiteOption(
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

        public string adsStationConnectString
        {
            get
            {
                try
                {
                    return m_adsStationConnectString;
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
                    m_adsStationConnectString = value;
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

        public int adsStationTimeout
        {
            get
            {
                try
                {
                    return m_adsStationTimeout;
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
                    m_adsStationTimeout = value;
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

        public string adsTuneChannelId
        {
            get
            {
                try
                {
                    return m_adsTuneChannelId;
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
                    m_adsTuneChannelId = value;
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

        public string adsCastChannelId
        {
            get
            {
                try
                {
                    return m_adsCastChannelId;
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
                    m_adsCastChannelId = value;
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
                return true;
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

        public int adsHistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_adsHistorySearchPeriod;
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
                    m_adsHistorySearchPeriod = value;
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

        public bool adsNoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_adsNoticePopupEnabled;
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
                    m_adsNoticePopupEnabled = value;
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

        public string adsNoticeLastTime
        {
            get
            {
                try
                {
                    return m_adsNoticeLastTime;
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
                    m_adsNoticeLastTime = value;
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

        public bool adsDesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertEnabled;
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
                    m_adsDesktopAlertEnabled = value;
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

        public bool adsDesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertSoundEnabled;
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
                    m_adsDesktopAlertSoundEnabled = value;
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

        public bool adsDesktopAlertServerEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertServerEnabled;
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
                    m_adsDesktopAlertServerEnabled = value;
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

        public bool adsDesktopAlertEapEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertEapEnabled;
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
                    m_adsDesktopAlertEapEnabled = value;
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

        public bool adsDesktopAlertDeviceEnabled
        {
            get
            {
                try
                {
                    return m_adsDesktopAlertDeviceEnabled;
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
                    m_adsDesktopAlertDeviceEnabled = value;
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

        public int adsServerIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsServerIssueMonitoringCount;
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
                    m_adsServerIssueMonitoringCount = value;
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

        public int adsEapIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsEapIssueMonitoringCount;
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
                    m_adsEapIssueMonitoringCount = value;
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

        public int adsEquipmentIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_adsEquipmentIssueMonitoringCount;
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
                    m_adsEquipmentIssueMonitoringCount = value;
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

        public string adsSecsInterfaceLogFilterCaption1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterCaption1;
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
                    m_adsSecsInterfaceLogFilterCaption1 = value;
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

        public string adsSecsInterfaceLogFilterSecsItem1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterSecsItem1;
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
                    m_adsSecsInterfaceLogFilterSecsItem1 = value;
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

        public string adsSecsInterfaceLogFilterHostItem1
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterHostItem1;
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
                    m_adsSecsInterfaceLogFilterHostItem1 = value;
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

        public string adsSecsInterfaceLogFilterCaption2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterCaption2;
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
                    m_adsSecsInterfaceLogFilterCaption2 = value;
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

        public string adsSecsInterfaceLogFilterSecsItem2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterSecsItem2;
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
                    m_adsSecsInterfaceLogFilterSecsItem2 = value;
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

        public string adsSecsInterfaceLogFilterHostItem2
        {
            get
            {
                try
                {
                    return m_adsSecsInterfaceLogFilterHostItem2;
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
                    m_adsSecsInterfaceLogFilterHostItem2 = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
