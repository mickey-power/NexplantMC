/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropAdmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate Admin Manager User Log In Option Property Source Object Class 
--  History         : Created by jungyoul.moon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.WorkspaceManager
{
    public class FPropAdmOption : FDynPropCusBase<FWsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryStation = "[01] Station";
        private const string CategoryChannelId = "[02] Channel ID";
        private const string CategoryFtp = "[03] FTP";
        private const string CategoryHistory = "[04] History";
        private const string CategoryNotice = "[05] Notice";
        private const string CategoryDesktopAlertEnabled = "[06] Desktop Alert Enabled";
        private const string CategoryDesktopAlertOption = "[07] Desktop Alert Option";
        private const string CategoryIssueMonitoringCount = "[08] Issue Monitoring Count";
        private const string CategoryInterfaceLogFilter = "[09] Interface Log Filter";

        // --

        private bool m_disposed = false;      
        // --
        private bool m_tranEnabled = false;
        // --
        private FAdmSiteOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropAdmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FAdmSiteOption source,
            bool tranEnabled
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            m_tranEnabled = tranEnabled;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropAdmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FAdmSiteOption source
            )
            : this(fWsmCore, fPropGrid, source, true)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropAdmOption(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }                
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Station

        [Category(CategoryStation)]
        public string StationConnectString
        {
            get
            {
                try
                {
                    return m_source.adsStationConnectString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsStationConnectString = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryStation)]
        public int StationTimeout
        {
            get
            {
                try
                {
                    return m_source.adsStationTimeout;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsStationTimeout = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Channel ID

        [Category(CategoryChannelId)]
        public string TuneChannelId
        {
            get
            {
                try
                {
                    return m_source.adsTuneChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsTuneChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryChannelId)]
        public string CastChannelId
        {
            get
            {
                try
                {
                    return m_source.adsCastChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsCastChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTP

        [Category(CategoryFtp)]
        public string FtpIp
        {
            get
            {
                try
                {
                    return m_source.adsFtpIp;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsFtpIp = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        public bool FtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_source.adsFtpUsedAnonymous;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    if (!value)
                    {
                        m_source.adsFtpUser = string.Empty;
                        m_source.adsFtpPassword = string.Empty;
                    }
                    // --
                    m_source.adsFtpUsedAnonymous = value;

                    // --

                    setChangedFtpUsedAnonymous();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        public string FtpUser
        {
            get
            {
                try
                {
                    return m_source.adsFtpUser;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsFtpUser = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        [PasswordPropertyText(true)]
        public string FtpPassword
        {
            get
            {
                try
                {
                    return m_source.adsFtpPassword;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsFtpPassword = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region History

        [Category(CategoryHistory)]
        public int HistorySearchPeriod
        {
            get
            {
                try
                {
                    return m_source.adsHistorySearchPeriod;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsHistorySearchPeriod = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Notice

        [Category(CategoryNotice)]
        public bool NoticePopupEnabled
        {
            get
            {
                try
                {
                    return m_source.adsNoticePopupEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsNoticePopupEnabled = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Desktop Alert Enabled

        [Category(CategoryDesktopAlertEnabled)]
        public bool DesktopAlertEnabled
        {
            get
            {
                try
                {
                    return m_source.adsDesktopAlertEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsDesktopAlertEnabled = value;

                    // --

                    setChangedDesktopAlertEnabled();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryDesktopAlertEnabled)]
        public bool DesktopAlertSoundEnabled
        {
            get
            {
                try
                {
                    return m_source.adsDesktopAlertSoundEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsDesktopAlertSoundEnabled = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Desktop Alert Option

        [Category(CategoryDesktopAlertOption)]
        public bool DesktopAlertServerEnabled
        {
            get
            {
                try
                {
                    return m_source.adsDesktopAlertServerEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsDesktopAlertServerEnabled = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryDesktopAlertOption)]
        public bool DesktopAlertEapEnabled
        {
            get
            {
                try
                {
                    return m_source.adsDesktopAlertEapEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsDesktopAlertEapEnabled = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryDesktopAlertOption)]
        public bool DesktopAlertDeviceEnabled
        {
            get
            {
                try
                {
                    return m_source.adsDesktopAlertDeviceEnabled;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsDesktopAlertDeviceEnabled = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Issue Monitoring Count

        [Category(CategoryIssueMonitoringCount)]
        public int ServerIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_source.adsServerIssueMonitoringCount;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsServerIssueMonitoringCount = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryIssueMonitoringCount)]
        public int EapIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_source.adsEapIssueMonitoringCount;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsEapIssueMonitoringCount = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryIssueMonitoringCount)]
        public int EquipmentIssueMonitoringCount
        {
            get
            {
                try
                {
                    return m_source.adsEquipmentIssueMonitoringCount;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsEquipmentIssueMonitoringCount = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Interface Log Filter

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterCaption1
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterCaption1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterCaption1 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterSecsItem1
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterSecsItem1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterSecsItem1 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterHostItem1
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterHostItem1;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterHostItem1 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterCaption2
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterCaption2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterCaption2 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterSecsItem2
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterSecsItem2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterSecsItem2 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryInterfaceLogFilter)]
        public string SecsInterfaceLogFilterHostItem2
        {
            get
            {
                try
                {
                    return m_source.adsSecsInterfaceLogFilterHostItem2;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
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
                    m_source.adsSecsInterfaceLogFilterHostItem2 = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FAdmSiteOption source
        {
            get
            {
                try
                {
                    return m_source;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Connect String"));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DisplayNameAttribute("Timeout (ms)"));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DisplayNameAttribute("Tune"));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DisplayNameAttribute("Cast"));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DisplayNameAttribute("IP"));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DisplayNameAttribute("Used Anonymous"));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DisplayNameAttribute("User"));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DisplayNameAttribute("Password"));
                // --
                base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new DisplayNameAttribute("Search Period (Day)"));
                // --
                base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new DisplayNameAttribute("Enabled"));
                // --
                base.fTypeDescriptor.properties["DesktopAlertEnabled"].attributes.replace(new DisplayNameAttribute("Enabled"));
                base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new DisplayNameAttribute("Sound"));
                base.fTypeDescriptor.properties["DesktopAlertServerEnabled"].attributes.replace(new DisplayNameAttribute("Server"));
                base.fTypeDescriptor.properties["DesktopAlertEapEnabled"].attributes.replace(new DisplayNameAttribute("Mc"));
                base.fTypeDescriptor.properties["DesktopAlertDeviceEnabled"].attributes.replace(new DisplayNameAttribute("Device"));
                // --
                base.fTypeDescriptor.properties["ServerIssueMonitoringCount"].attributes.replace(new DisplayNameAttribute("Server "));
                base.fTypeDescriptor.properties["EapIssueMonitoringCount"].attributes.replace(new DisplayNameAttribute("EAP "));
                base.fTypeDescriptor.properties["EquipmentIssueMonitoringCount"].attributes.replace(new DisplayNameAttribute("Equipment "));
                // --
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption1"].attributes.replace(new DisplayNameAttribute("SECS Log - Caption 1"));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem1"].attributes.replace(new DisplayNameAttribute("SECS Log - SECS Item 1"));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem1"].attributes.replace(new DisplayNameAttribute("SECS Log - Host Item 1"));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption2"].attributes.replace(new DisplayNameAttribute("SECS Log - Caption 2"));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem2"].attributes.replace(new DisplayNameAttribute("SECS Log - SECS Item 2"));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem2"].attributes.replace(new DisplayNameAttribute("SECS Log - Host Item 2"));

                // --

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.adsStationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.adsStationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.adsTuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.adsCastChannelId));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DefaultValueAttribute(m_source.adsFtpIp));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DefaultValueAttribute(m_source.adsFtpUsedAnonymous));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DefaultValueAttribute(m_source.adsFtpUser));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DefaultValueAttribute(m_source.adsFtpPassword));
                // --
                base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new DefaultValueAttribute(m_source.adsHistorySearchPeriod));
                // --
                base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsNoticePopupEnabled));
                // --
                base.fTypeDescriptor.properties["DesktopAlertEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsDesktopAlertEnabled));
                base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsDesktopAlertSoundEnabled));
                base.fTypeDescriptor.properties["DesktopAlertServerEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsDesktopAlertServerEnabled));
                base.fTypeDescriptor.properties["DesktopAlertEapEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsDesktopAlertEapEnabled));
                base.fTypeDescriptor.properties["DesktopAlertDeviceEnabled"].attributes.replace(new DefaultValueAttribute(m_source.adsDesktopAlertDeviceEnabled));
                // --
                base.fTypeDescriptor.properties["ServerIssueMonitoringCount"].attributes.replace(new DefaultValueAttribute(m_source.adsServerIssueMonitoringCount));
                base.fTypeDescriptor.properties["EapIssueMonitoringCount"].attributes.replace(new DefaultValueAttribute(m_source.adsEapIssueMonitoringCount));
                base.fTypeDescriptor.properties["EquipmentIssueMonitoringCount"].attributes.replace(new DefaultValueAttribute(m_source.adsEquipmentIssueMonitoringCount));
                // --
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption1"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterCaption1));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem1"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterSecsItem1));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem1"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterHostItem1));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption2"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterCaption2));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem2"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterSecsItem2));
                base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem2"].attributes.replace(new DefaultValueAttribute(m_source.adsSecsInterfaceLogFilterHostItem2));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["DesktopAlertEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertServerEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertEapEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertDeviceEnabled"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["ServerIssueMonitoringCount"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EapIssueMonitoringCount"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["EquipmentIssueMonitoringCount"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem1"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterCaption2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterSecsItem2"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["SecsInterfaceLogFilterHostItem2"].attributes.replace(new ReadOnlyAttribute(true));
                }

                // --

                setChangedFtpUsedAnonymous();
                setChangedDesktopAlertEnabled();
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

        private void setChangedFtpUsedAnonymous(
            )
        {
            try
            {
                if (m_source.adsFtpUsedAnonymous)
                {
                    base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new BrowsableAttribute(true));
                }

                // --

                this.fPropGrid.Refresh();
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

        private void setChangedDesktopAlertEnabled(
            )
        {
            try
            {
                if (m_source.adsDesktopAlertEnabled)
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertServerEnabled"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertEapEnabled"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertDeviceEnabled"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DesktopAlertServerEnabled"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DesktopAlertEapEnabled"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DesktopAlertDeviceEnabled"].attributes.replace(new BrowsableAttribute(false));
                }

                // --

                this.fPropGrid.Refresh();
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
