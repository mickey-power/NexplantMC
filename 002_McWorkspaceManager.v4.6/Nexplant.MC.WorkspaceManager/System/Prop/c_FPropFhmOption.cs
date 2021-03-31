/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropFhmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate PMS Manager User Log In Option Property Source Object Class 
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
    public class FPropFhmOption : FDynPropCusBase<FWsmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryStation = "[01] Station";
        private const string CategoryChannelId = "[02] Channel ID";
        private const string CategoryFtp = "[03] FTP";
        private const string CategoryHistory = "[04] History";
        private const string CategoryNotice = "[05] Notice";
        private const string CategoryDesktopAlertEnabled = "[06] Desktop Alert Enabled";
        private const string CategoryDesktopAlertOption = "[07] Desktop Alert Option";

        // --

        private bool m_disposed = false;      
        // --
        private FFhmSiteOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropFhmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FFhmSiteOption source
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropFhmOption(
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
                    return m_source.fhsStationConnectString;
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
                    m_source.fhsStationConnectString = value;
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
                    return m_source.fhsStationTimeout;
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
                    m_source.fhsStationTimeout = value;
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
                    return m_source.fhsTuneChannelId;
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
                    m_source.fhsTuneChannelId = value;
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
                    return m_source.fhsCastChannelId;
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
                    m_source.fhsCastChannelId = value;
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
                    return m_source.fhsFtpIp;
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
                    m_source.fhsFtpIp = value;
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
                    return m_source.fhsFtpUsedAnonymous;
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
                        m_source.fhsFtpUser = string.Empty;
                        m_source.fhsFtpPassword = string.Empty;
                    }
                    // --
                    m_source.fhsFtpUsedAnonymous = value;

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
                    return m_source.fhsFtpUser;
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
                    m_source.fhsFtpUser = value;
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
                    return m_source.fhsFtpPassword;
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
                    m_source.fhsFtpPassword = value;
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
                    return m_source.fhsHistorySearchPeriod;
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
                    m_source.fhsHistorySearchPeriod = value;
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
                    return m_source.fhsNoticePopupEnabled;
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
                    m_source.fhsNoticePopupEnabled = value;
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
                    return m_source.fhsDesktopAlertEnabled;
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
                    m_source.fhsDesktopAlertEnabled = value;

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
                    return m_source.fhsDesktopAlertSoundEnabled;
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
                    m_source.fhsDesktopAlertSoundEnabled = value;
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
        public bool DesktopAlertFileEnabled
        {
            get
            {
                try
                {
                    return m_source.fhsDesktopAlertFileEnabled;
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
                    m_source.fhsDesktopAlertFileEnabled = value;
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
        public FFhmSiteOption source
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
                // --
                base.fTypeDescriptor.properties["DesktopAlertFileEnabled"].attributes.replace(new DisplayNameAttribute("File"));
                
                // --

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.fhsStationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.fhsStationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.fhsTuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.fhsCastChannelId));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DefaultValueAttribute(m_source.fhsFtpIp));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DefaultValueAttribute(m_source.fhsFtpUsedAnonymous));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DefaultValueAttribute(m_source.fhsFtpUser));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DefaultValueAttribute(m_source.fhsFtpPassword));
                // --
                base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new DefaultValueAttribute(m_source.fhsHistorySearchPeriod));
                // --
                base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new DefaultValueAttribute(m_source.fhsNoticePopupEnabled));
                // --
                base.fTypeDescriptor.properties["DesktopAlertEnabled"].attributes.replace(new DefaultValueAttribute(m_source.fhsDesktopAlertEnabled));
                base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new DefaultValueAttribute(m_source.fhsDesktopAlertSoundEnabled));
                // --
                base.fTypeDescriptor.properties["DesktopAlertFileEnabled"].attributes.replace(new DefaultValueAttribute(m_source.fhsDesktopAlertFileEnabled));
                

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
                if (m_source.fhsFtpUsedAnonymous)
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
                if (m_source.fhsDesktopAlertEnabled)
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertFileEnabled"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DesktopAlertFileEnabled"].attributes.replace(new BrowsableAttribute(false));
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
