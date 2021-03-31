/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropRmmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate RMS Manager User Log In Option Property Source Object Class 
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
    public class FPropRmmOption : FDynPropCusBase<FWsmCore>
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
        private FRmmSiteOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropRmmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FRmmSiteOption source
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropRmmOption(
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
                    return m_source.rmsStationConnectString;
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
                    m_source.rmsStationConnectString = value;
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
                    return m_source.rmsStationTimeout;
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
                    m_source.rmsStationTimeout = value;
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
                    return m_source.rmsTuneChannelId;
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
                    m_source.rmsTuneChannelId = value;
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
                    return m_source.rmsCastChannelId;
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
                    m_source.rmsCastChannelId = value;
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
                    return m_source.rmsFtpIp;
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
                    m_source.rmsFtpIp = value;
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
                    return m_source.rmsFtpUsedAnonymous;
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
                        m_source.rmsFtpUser = string.Empty;
                        m_source.rmsFtpPassword = string.Empty;
                    }
                    // --
                    m_source.rmsFtpUsedAnonymous = value;

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
                    return m_source.rmsFtpUser;
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
                    m_source.rmsFtpUser = value;
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
                    return m_source.rmsFtpPassword;
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
                    m_source.rmsFtpPassword = value;
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
                    return m_source.rmsHistorySearchPeriod;
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
                    m_source.rmsHistorySearchPeriod = value;
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
                    return m_source.rmsNoticePopupEnabled;
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
                    m_source.rmsNoticePopupEnabled = value;
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
                    return m_source.rmsDesktopAlertEnabled;
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
                    m_source.rmsDesktopAlertEnabled = value;

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
                    return m_source.rmsDesktopAlertSoundEnabled;
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
                    m_source.rmsDesktopAlertSoundEnabled = value;
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
        public bool DesktopAlertRecipeEnabled
        {
            get
            {
                try
                {
                    return m_source.rmsDesktopAlertRecipeEnabled;
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
                    m_source.rmsDesktopAlertRecipeEnabled = value;
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
        public FRmmSiteOption source
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
                base.fTypeDescriptor.properties["DesktopAlertRecipeEnabled"].attributes.replace(new DisplayNameAttribute("Recipe"));
                
                // --

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.rmsStationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.rmsStationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.rmsTuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.rmsCastChannelId));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DefaultValueAttribute(m_source.rmsFtpIp));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DefaultValueAttribute(m_source.rmsFtpUsedAnonymous));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DefaultValueAttribute(m_source.rmsFtpUser));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DefaultValueAttribute(m_source.rmsFtpPassword));
                // --
                base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new DefaultValueAttribute(m_source.rmsHistorySearchPeriod));
                // --
                base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new DefaultValueAttribute(m_source.rmsNoticePopupEnabled));
                // --
                base.fTypeDescriptor.properties["DesktopAlertEnabled"].attributes.replace(new DefaultValueAttribute(m_source.rmsDesktopAlertEnabled));
                base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new DefaultValueAttribute(m_source.rmsDesktopAlertSoundEnabled));
                // -=-
                base.fTypeDescriptor.properties["DesktopAlertRecipeEnabled"].attributes.replace(new DefaultValueAttribute(m_source.rmsDesktopAlertRecipeEnabled));
                

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
                if (m_source.rmsFtpUsedAnonymous)
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
                if (m_source.rmsDesktopAlertEnabled)
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["DesktopAlertRecipeEnabled"].attributes.replace(new BrowsableAttribute(true));
                }
                else
                {
                    base.fTypeDescriptor.properties["DesktopAlertSoundEnabled"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["DesktopAlertRecipeEnabled"].attributes.replace(new BrowsableAttribute(false));
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
