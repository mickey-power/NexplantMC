/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropDcmOption.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate DCS Manager User Log In Option Property Source Object Class 
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
    public class FPropDcmOption : FDynPropCusBase<FWsmCore>
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
        private FDcmSiteOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropDcmOption(
            FWsmCore fWsmCore,
            FDynPropGrid fPropGrid,
            FDcmSiteOption source
            )
            : base(fWsmCore, fWsmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropDcmOption(
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
                    return m_source.dcsStationConnectString;
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
                    m_source.dcsStationConnectString = value;
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
                    return m_source.dcsStationTimeout;
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
                    m_source.dcsStationTimeout = value;
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
                    return m_source.dcsTuneChannelId;
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
                    m_source.dcsTuneChannelId = value;
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
                    return m_source.dcsCastChannelId;
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
                    m_source.dcsCastChannelId = value;
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
                    return m_source.dcsFtpIp;
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
                    m_source.dcsFtpIp = value;
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
                    return m_source.dcsFtpUsedAnonymous;
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
                        m_source.dcsFtpUser = string.Empty;
                        m_source.dcsFtpPassword = string.Empty;
                    }
                    // --
                    m_source.dcsFtpUsedAnonymous = value;

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
                    return m_source.dcsFtpUser;
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
                    m_source.dcsFtpUser = value;
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
                    return m_source.dcsFtpPassword;
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
                    m_source.dcsFtpPassword = value;
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
                    return m_source.dcsHistorySearchPeriod;
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
                    m_source.dcsHistorySearchPeriod = value;
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
                    return m_source.dcsNoticePopupEnabled;
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
                    m_source.dcsNoticePopupEnabled = value;
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
        public FDcmSiteOption source
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

                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.dcsStationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.dcsStationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.dcsTuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.dcsCastChannelId));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DefaultValueAttribute(m_source.dcsFtpIp));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DefaultValueAttribute(m_source.dcsFtpUsedAnonymous));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DefaultValueAttribute(m_source.dcsFtpUser));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DefaultValueAttribute(m_source.dcsFtpPassword));
                // --
                base.fTypeDescriptor.properties["HistorySearchPeriod"].attributes.replace(new DefaultValueAttribute(m_source.dcsHistorySearchPeriod));
                // --
                base.fTypeDescriptor.properties["NoticePopupEnabled"].attributes.replace(new DefaultValueAttribute(m_source.dcsNoticePopupEnabled));
                
                // --

                setChangedFtpUsedAnonymous();
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
                if (m_source.dcsFtpUsedAnonymous)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
