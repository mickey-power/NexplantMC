/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserLogInOptionDialog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.11
--  Description     : FAMate Workspace Manager User Log In Option Dialog Form Class 
--  History         : Created by jungyoul.moon at 2014.08.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.WorkspaceManager
{
    public partial class FUserLogInOptionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FWsmCore m_fWsmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserLogInOptionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserLogInOptionDialog(
            FWsmCore fWsmCore
            ) 
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fWsmCore = fWsmCore;
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
                    m_fWsmCore = null;
                }
                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fWsmCore.fUIWizard.searchCaption(this.Text);
                this.Text = caption;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                setTitle();
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

        private void designExplorerBarOfFactory(
            )
        {
            try
            {
                exbExplorer.beginUpdate();

                // --

                exbExplorer.Groups.Add("Site", "Site");

                // --

                exbExplorer.endUpdate();
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshExplorerBarOfFactory(
            )
        {
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;            

            try
            {
                exbExplorer.BeginUpdate();

                // --

                group = exbExplorer.Groups["Site"];
                foreach (FWsmSiteOption source in m_fWsmCore.fOption.fSiteOptionList)
                {
                    item = group.Items.Add(source.site, source.site);
                    item.Tag = source;
                }

                // --

                exbExplorer.EndUpdate();

                // --

                if (group.Items.Count == 0)
                {
                    initPropOfUserLogInOption();
                    btnOk.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (group.Items.Exists(m_fWsmCore.fOption.site))
                    {
                        group.Items[m_fWsmCore.fOption.site].Active = true;
                    }
                    // --
                    if (exbExplorer.ActiveItem == null)
                    {
                        group.Items[0].Active = true;
                    }
                }

                // --

                exbExplorer.Select();                
            }
            catch (Exception ex)
            {
                exbExplorer.EndUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                group = null;
                item = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfUserLogInOption(
            )
        {
            FWsmSiteOption source = null;

            try
            {
                source = new FWsmSiteOption();

                // --

                source.site = string.Empty;
                source.factory = string.Empty;
                source.description = string.Empty;
                source.stationConnectString = string.Empty;
                source.stationTimeout = 0;
                source.tuneChannelId = string.Empty;
                source.castChannelId = string.Empty;

                // --

                source.fAdmOption = new FAdmSiteOption();
                // --
                source.fAdmOption.adsStationConnectString = string.Empty;
                source.fAdmOption.adsStationTimeout = 0;
                source.fAdmOption.adsTuneChannelId = string.Empty;
                source.fAdmOption.adsCastChannelId = string.Empty;
                source.fAdmOption.adsFtpIp = string.Empty;
                source.fAdmOption.adsFtpUsedAnonymous = true;
                source.fAdmOption.adsFtpUser = string.Empty;
                source.fAdmOption.adsFtpPassword = string.Empty;
                source.fAdmOption.adsHistorySearchPeriod = 0;
                source.fAdmOption.adsNoticePopupEnabled = true;
                source.fAdmOption.adsNoticeLastTime = string.Empty;
                source.fAdmOption.adsDesktopAlertEnabled = true;
                source.fAdmOption.adsDesktopAlertSoundEnabled = true;
                source.fAdmOption.adsDesktopAlertServerEnabled = true;
                source.fAdmOption.adsDesktopAlertEapEnabled = true;
                source.fAdmOption.adsDesktopAlertDeviceEnabled = true;
                source.fAdmOption.adsServerIssueMonitoringCount = 0;
                source.fAdmOption.adsEapIssueMonitoringCount = 0;
                source.fAdmOption.adsEquipmentIssueMonitoringCount = 0;
                source.fAdmOption.adsSecsInterfaceLogFilterCaption1 = string.Empty;
                source.fAdmOption.adsSecsInterfaceLogFilterSecsItem1 = string.Empty;
                source.fAdmOption.adsSecsInterfaceLogFilterHostItem1 = string.Empty;
                source.fAdmOption.adsSecsInterfaceLogFilterCaption2 = string.Empty;
                source.fAdmOption.adsSecsInterfaceLogFilterSecsItem2 = string.Empty;
                source.fAdmOption.adsSecsInterfaceLogFilterHostItem2 = string.Empty;

                // --

                source.fDcmOption = new FDcmSiteOption();
                // --
                source.fDcmOption.dcsStationConnectString = string.Empty;
                source.fDcmOption.dcsStationTimeout = 0;
                source.fDcmOption.dcsTuneChannelId = string.Empty;
                source.fDcmOption.dcsCastChannelId = string.Empty;
                source.fDcmOption.dcsFtpIp = string.Empty;
                source.fDcmOption.dcsFtpUsedAnonymous = true;
                source.fDcmOption.dcsFtpUser = string.Empty;
                source.fDcmOption.dcsFtpPassword = string.Empty;
                source.fDcmOption.dcsHistorySearchPeriod = 0;
                source.fDcmOption.dcsNoticePopupEnabled = true;
                source.fDcmOption.dcsNoticeLastTime = string.Empty;

                // --

                source.fRmmOption = new FRmmSiteOption();
                // --
                source.fRmmOption.rmsStationConnectString = string.Empty;
                source.fRmmOption.rmsStationTimeout = 0;
                source.fRmmOption.rmsTuneChannelId = string.Empty;
                source.fRmmOption.rmsCastChannelId = string.Empty;
                source.fRmmOption.rmsFtpIp = string.Empty;
                source.fRmmOption.rmsFtpUsedAnonymous = true;
                source.fRmmOption.rmsFtpUser = string.Empty;
                source.fRmmOption.rmsFtpPassword = string.Empty;
                source.fRmmOption.rmsHistorySearchPeriod = 0;
                source.fRmmOption.rmsNoticePopupEnabled = true;
                source.fRmmOption.rmsNoticeLastTime = string.Empty;
                source.fRmmOption.rmsDesktopAlertEnabled = true;
                source.fRmmOption.rmsDesktopAlertSoundEnabled = true;
                source.fRmmOption.rmsDesktopAlertRecipeEnabled = true;

                // --

                source.fPmmOption = new FPmmSiteOption();
                // --
                source.fPmmOption.pmsStationConnectString = string.Empty;
                source.fPmmOption.pmsStationTimeout = 0;
                source.fPmmOption.pmsTuneChannelId = string.Empty;
                source.fPmmOption.pmsCastChannelId = string.Empty;
                source.fPmmOption.pmsFtpIp = string.Empty;
                source.fPmmOption.pmsFtpUsedAnonymous = true;
                source.fPmmOption.pmsFtpUser = string.Empty;
                source.fPmmOption.pmsFtpPassword = string.Empty;
                source.fPmmOption.pmsHistorySearchPeriod = 0;
                source.fPmmOption.pmsNoticePopupEnabled = true;
                source.fPmmOption.pmsNoticeLastTime = string.Empty;
                source.fPmmOption.pmsDesktopAlertEnabled = true;
                source.fPmmOption.pmsDesktopAlertSoundEnabled = true;
                source.fPmmOption.pmsDesktopAlertParameterEnabled = true;
                // --

                source.fFhmOption = new FFhmSiteOption();
                // --
                source.fFhmOption.fhsStationConnectString = string.Empty;
                source.fFhmOption.fhsStationTimeout = 0;
                source.fFhmOption.fhsTuneChannelId = string.Empty;
                source.fFhmOption.fhsCastChannelId = string.Empty;
                source.fFhmOption.fhsFtpIp = string.Empty;
                source.fFhmOption.fhsFtpUsedAnonymous = true;
                source.fFhmOption.fhsFtpUser = string.Empty;
                source.fFhmOption.fhsFtpPassword = string.Empty;
                source.fFhmOption.fhsHistorySearchPeriod = 0;
                source.fFhmOption.fhsNoticePopupEnabled = true;
                source.fFhmOption.fhsNoticeLastTime = string.Empty;
                source.fFhmOption.fhsDesktopAlertEnabled = true;
                source.fFhmOption.fhsDesktopAlertSoundEnabled = true;
                source.fFhmOption.fhsDesktopAlertFileEnabled = true;
                // --

                pgdWsmProp.selectedObject = new FPropWsmOption(m_fWsmCore, pgdWsmProp, source);
                pgdAdmProp.selectedObject = new FPropAdmOption(m_fWsmCore, pgdAdmProp, source.fAdmOption);
                pgdDcmProp.selectedObject = new FPropDcmOption(m_fWsmCore, pgdAdmProp, source.fDcmOption);
                pgdRmmProp.selectedObject = new FPropRmmOption(m_fWsmCore, pgdAdmProp, source.fRmmOption);
                pgdPmmProp.selectedObject = new FPropPmmOption(m_fWsmCore, pgdAdmProp, source.fPmmOption);
                pgdFhmProp.selectedObject = new FPropFhmOption(m_fWsmCore, pgdAdmProp, source.fFhmOption);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                    source = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfUserLogInOption(
            )
        {
            FWsmSiteOption source = null;
            FWsmSiteOption target = null;

            try
            {
                source = (FWsmSiteOption)exbExplorer.ActiveItem.Tag;

                // --

                target = new FWsmSiteOption();

                // --

                target.site = source.site;
                target.factory = source.factory;
                target.description = source.description;
                target.stationConnectString = source.stationConnectString;
                target.stationTimeout = source.stationTimeout;
                target.tuneChannelId = source.tuneChannelId;
                target.castChannelId = source.castChannelId;

                // --

                target.fAdmOption = new FAdmSiteOption();
                // --
                target.fAdmOption.adsStationConnectString = source.fAdmOption.adsStationConnectString;
                target.fAdmOption.adsStationTimeout = source.fAdmOption.adsStationTimeout;
                target.fAdmOption.adsTuneChannelId = source.fAdmOption.adsTuneChannelId;
                target.fAdmOption.adsCastChannelId = source.fAdmOption.adsCastChannelId;
                target.fAdmOption.adsFtpIp = source.fAdmOption.adsFtpIp;
                target.fAdmOption.adsFtpUsedAnonymous = source.fAdmOption.adsFtpUsedAnonymous;
                target.fAdmOption.adsFtpUser = source.fAdmOption.adsFtpUser;
                target.fAdmOption.adsFtpPassword = source.fAdmOption.adsFtpPassword;
                target.fAdmOption.adsHistorySearchPeriod = source.fAdmOption.adsHistorySearchPeriod;
                target.fAdmOption.adsNoticePopupEnabled = source.fAdmOption.adsNoticePopupEnabled;
                target.fAdmOption.adsNoticeLastTime = source.fAdmOption.adsNoticeLastTime;
                target.fAdmOption.adsDesktopAlertEnabled = source.fAdmOption.adsDesktopAlertEnabled;
                target.fAdmOption.adsDesktopAlertSoundEnabled = source.fAdmOption.adsDesktopAlertSoundEnabled;
                target.fAdmOption.adsDesktopAlertServerEnabled = source.fAdmOption.adsDesktopAlertServerEnabled;
                target.fAdmOption.adsDesktopAlertEapEnabled = source.fAdmOption.adsDesktopAlertEapEnabled;
                target.fAdmOption.adsDesktopAlertDeviceEnabled = source.fAdmOption.adsDesktopAlertDeviceEnabled;
                target.fAdmOption.adsServerIssueMonitoringCount = source.fAdmOption.adsServerIssueMonitoringCount;
                target.fAdmOption.adsEapIssueMonitoringCount = source.fAdmOption.adsEapIssueMonitoringCount;
                target.fAdmOption.adsEquipmentIssueMonitoringCount = source.fAdmOption.adsEquipmentIssueMonitoringCount;
                target.fAdmOption.adsSecsInterfaceLogFilterCaption1 = source.fAdmOption.adsSecsInterfaceLogFilterCaption1;
                target.fAdmOption.adsSecsInterfaceLogFilterSecsItem1 = source.fAdmOption.adsSecsInterfaceLogFilterSecsItem1;
                target.fAdmOption.adsSecsInterfaceLogFilterHostItem1 = source.fAdmOption.adsSecsInterfaceLogFilterHostItem1;
                target.fAdmOption.adsSecsInterfaceLogFilterCaption2 = source.fAdmOption.adsSecsInterfaceLogFilterCaption2;
                target.fAdmOption.adsSecsInterfaceLogFilterSecsItem2 = source.fAdmOption.adsSecsInterfaceLogFilterSecsItem2;
                target.fAdmOption.adsSecsInterfaceLogFilterHostItem2 = source.fAdmOption.adsSecsInterfaceLogFilterHostItem2;

                // --

                target.fDcmOption = new FDcmSiteOption();
                // --
                target.fDcmOption.dcsStationConnectString = source.fDcmOption.dcsStationConnectString;
                target.fDcmOption.dcsStationTimeout = source.fDcmOption.dcsStationTimeout;
                target.fDcmOption.dcsTuneChannelId = source.fDcmOption.dcsTuneChannelId;
                target.fDcmOption.dcsCastChannelId = source.fDcmOption.dcsCastChannelId;
                target.fDcmOption.dcsFtpIp = source.fDcmOption.dcsFtpIp;
                target.fDcmOption.dcsFtpUsedAnonymous = source.fDcmOption.dcsFtpUsedAnonymous;
                target.fDcmOption.dcsFtpUser = source.fDcmOption.dcsFtpUser;
                target.fDcmOption.dcsFtpPassword = source.fDcmOption.dcsFtpPassword;
                target.fDcmOption.dcsHistorySearchPeriod = source.fDcmOption.dcsHistorySearchPeriod;
                target.fDcmOption.dcsNoticePopupEnabled = source.fDcmOption.dcsNoticePopupEnabled;
                target.fDcmOption.dcsNoticeLastTime = source.fDcmOption.dcsNoticeLastTime;
                
                // --

                target.fRmmOption = new FRmmSiteOption();
                // --
                target.fRmmOption.rmsStationConnectString = source.fRmmOption.rmsStationConnectString;
                target.fRmmOption.rmsStationTimeout = source.fRmmOption.rmsStationTimeout;
                target.fRmmOption.rmsTuneChannelId = source.fRmmOption.rmsTuneChannelId;
                target.fRmmOption.rmsCastChannelId = source.fRmmOption.rmsCastChannelId;
                target.fRmmOption.rmsFtpIp = source.fRmmOption.rmsFtpIp;
                target.fRmmOption.rmsFtpUsedAnonymous = source.fRmmOption.rmsFtpUsedAnonymous;
                target.fRmmOption.rmsFtpUser = source.fRmmOption.rmsFtpUser;
                target.fRmmOption.rmsFtpPassword = source.fRmmOption.rmsFtpPassword;
                target.fRmmOption.rmsHistorySearchPeriod = source.fRmmOption.rmsHistorySearchPeriod;
                target.fRmmOption.rmsNoticePopupEnabled = source.fRmmOption.rmsNoticePopupEnabled;
                target.fRmmOption.rmsNoticeLastTime = source.fRmmOption.rmsNoticeLastTime;
                target.fRmmOption.rmsDesktopAlertEnabled = source.fRmmOption.rmsDesktopAlertEnabled;
                target.fRmmOption.rmsDesktopAlertSoundEnabled = source.fRmmOption.rmsDesktopAlertSoundEnabled;
                target.fRmmOption.rmsDesktopAlertRecipeEnabled = source.fRmmOption.rmsDesktopAlertRecipeEnabled;
                
                // --

                target.fPmmOption = new FPmmSiteOption();
                // --
                target.fPmmOption.pmsStationConnectString = source.fPmmOption.pmsStationConnectString;
                target.fPmmOption.pmsStationTimeout = source.fPmmOption.pmsStationTimeout;
                target.fPmmOption.pmsTuneChannelId = source.fPmmOption.pmsTuneChannelId;
                target.fPmmOption.pmsCastChannelId = source.fPmmOption.pmsCastChannelId;
                target.fPmmOption.pmsFtpIp = source.fPmmOption.pmsFtpIp;
                target.fPmmOption.pmsFtpUsedAnonymous = source.fPmmOption.pmsFtpUsedAnonymous;
                target.fPmmOption.pmsFtpUser = source.fPmmOption.pmsFtpUser;
                target.fPmmOption.pmsFtpPassword = source.fPmmOption.pmsFtpPassword;
                target.fPmmOption.pmsHistorySearchPeriod = source.fPmmOption.pmsHistorySearchPeriod;
                target.fPmmOption.pmsNoticePopupEnabled = source.fPmmOption.pmsNoticePopupEnabled;
                target.fPmmOption.pmsNoticeLastTime = source.fPmmOption.pmsNoticeLastTime;
                target.fPmmOption.pmsDesktopAlertEnabled = source.fPmmOption.pmsDesktopAlertEnabled;
                target.fPmmOption.pmsDesktopAlertSoundEnabled = source.fPmmOption.pmsDesktopAlertSoundEnabled;
                target.fPmmOption.pmsDesktopAlertParameterEnabled = source.fPmmOption.pmsDesktopAlertParameterEnabled;

                // --

                target.fFhmOption = new FFhmSiteOption();
                // --
                target.fFhmOption.fhsStationConnectString = source.fFhmOption.fhsStationConnectString;
                target.fFhmOption.fhsStationTimeout = source.fFhmOption.fhsStationTimeout;
                target.fFhmOption.fhsTuneChannelId = source.fFhmOption.fhsTuneChannelId;
                target.fFhmOption.fhsCastChannelId = source.fFhmOption.fhsCastChannelId;
                target.fFhmOption.fhsFtpIp = source.fFhmOption.fhsFtpIp;
                target.fFhmOption.fhsFtpUsedAnonymous = source.fFhmOption.fhsFtpUsedAnonymous;
                target.fFhmOption.fhsFtpUser = source.fFhmOption.fhsFtpUser;
                target.fFhmOption.fhsFtpPassword = source.fFhmOption.fhsFtpPassword;
                target.fFhmOption.fhsHistorySearchPeriod = source.fFhmOption.fhsHistorySearchPeriod;
                target.fFhmOption.fhsNoticePopupEnabled = source.fFhmOption.fhsNoticePopupEnabled;
                target.fFhmOption.fhsNoticeLastTime = source.fFhmOption.fhsNoticeLastTime;
                target.fFhmOption.fhsDesktopAlertEnabled = source.fFhmOption.fhsDesktopAlertEnabled;
                target.fFhmOption.fhsDesktopAlertSoundEnabled = source.fFhmOption.fhsDesktopAlertSoundEnabled;
                target.fFhmOption.fhsDesktopAlertFileEnabled = source.fFhmOption.fhsDesktopAlertFileEnabled;
                // --

                pgdWsmProp.selectedObject = new FPropWsmOption(m_fWsmCore, pgdWsmProp, target);
                pgdAdmProp.selectedObject = new FPropAdmOption(m_fWsmCore, pgdAdmProp, target.fAdmOption);
                pgdDcmProp.selectedObject = new FPropDcmOption(m_fWsmCore, pgdDcmProp, target.fDcmOption);
                pgdRmmProp.selectedObject = new FPropRmmOption(m_fWsmCore, pgdRmmProp, target.fRmmOption);
                pgdPmmProp.selectedObject = new FPropPmmOption(m_fWsmCore, pgdPmmProp, target.fPmmOption);
                pgdFhmProp.selectedObject = new FPropFhmOption(m_fWsmCore, pgdFhmProp, target.fFhmOption);

                // --

                btnOk.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                source = null;
                target = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FUserLogInOptionDialog Form Event Handler

        private void FUserLogInOptionDialog_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designExplorerBarOfFactory();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FUserLogInOptionDialog_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshExplorerBarOfFactory();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender,
            EventArgs e
            )
        {
            FWsmSiteOption source = null;

            try
            {
                FCursor.waitCursor();

                // --

                source = (FWsmSiteOption)exbExplorer.ActiveItem.Tag;

                // --

                m_fWsmCore.fOption.site = source.site;
                m_fWsmCore.fOption.factory = source.factory;
                m_fWsmCore.fOption.description = source.description;
                m_fWsmCore.fOption.stationConnectString = source.stationConnectString;
                m_fWsmCore.fOption.stationTimeout = source.stationTimeout;
                m_fWsmCore.fOption.tuneChannelId = source.tuneChannelId;
                m_fWsmCore.fOption.castChannelId = source.castChannelId;
                // --
                m_fWsmCore.fOption.adsStationConnectString = source.fAdmOption.adsStationConnectString;
                m_fWsmCore.fOption.adsStationTimeout = source.fAdmOption.adsStationTimeout;
                m_fWsmCore.fOption.adsTuneChannelId = source.fAdmOption.adsTuneChannelId;
                m_fWsmCore.fOption.adsCastChannelId = source.fAdmOption.adsCastChannelId;
                m_fWsmCore.fOption.adsFtpIp = source.fAdmOption.adsFtpIp;
                m_fWsmCore.fOption.adsFtpUsedAnonymous = source.fAdmOption.adsFtpUsedAnonymous;
                m_fWsmCore.fOption.adsFtpUser = source.fAdmOption.adsFtpUser;
                m_fWsmCore.fOption.adsFtpPassword = source.fAdmOption.adsFtpPassword;
                m_fWsmCore.fOption.adsHistorySearchPeriod = source.fAdmOption.adsHistorySearchPeriod;
                m_fWsmCore.fOption.adsNoticePopupEnabled = source.fAdmOption.adsNoticePopupEnabled;
                m_fWsmCore.fOption.adsNoticeLastTime = source.fAdmOption.adsNoticeLastTime;
                m_fWsmCore.fOption.adsDesktopAlertEnabled = source.fAdmOption.adsDesktopAlertEnabled;
                m_fWsmCore.fOption.adsDesktopAlertSoundEnabled = source.fAdmOption.adsDesktopAlertSoundEnabled;
                m_fWsmCore.fOption.adsDesktopAlertServerEnabled = source.fAdmOption.adsDesktopAlertServerEnabled;
                m_fWsmCore.fOption.adsDesktopAlertEapEnabled = source.fAdmOption.adsDesktopAlertEapEnabled;
                m_fWsmCore.fOption.adsDesktopAlertDeviceEnabled = source.fAdmOption.adsDesktopAlertDeviceEnabled;
                m_fWsmCore.fOption.adsServerIssueMonitoringCount = source.fAdmOption.adsServerIssueMonitoringCount;
                m_fWsmCore.fOption.adsEapIssueMonitoringCount = source.fAdmOption.adsEapIssueMonitoringCount;
                m_fWsmCore.fOption.adsEquipmentIssueMonitoringCount = source.fAdmOption.adsEquipmentIssueMonitoringCount;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterCaption1 = source.fAdmOption.adsSecsInterfaceLogFilterCaption1;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterSecsItem1 = source.fAdmOption.adsSecsInterfaceLogFilterSecsItem1;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterHostItem1 = source.fAdmOption.adsSecsInterfaceLogFilterHostItem1;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterCaption2 = source.fAdmOption.adsSecsInterfaceLogFilterCaption2;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterSecsItem2 = source.fAdmOption.adsSecsInterfaceLogFilterSecsItem2;
                m_fWsmCore.fOption.adsSecsInterfaceLogFilterHostItem2 = source.fAdmOption.adsSecsInterfaceLogFilterHostItem2;
                // --
                m_fWsmCore.fOption.dcsStationConnectString = source.fDcmOption.dcsStationConnectString;
                m_fWsmCore.fOption.dcsStationTimeout = source.fDcmOption.dcsStationTimeout;
                m_fWsmCore.fOption.dcsTuneChannelId = source.fDcmOption.dcsTuneChannelId;
                m_fWsmCore.fOption.dcsCastChannelId = source.fDcmOption.dcsCastChannelId;
                m_fWsmCore.fOption.dcsFtpIp = source.fDcmOption.dcsFtpIp;
                m_fWsmCore.fOption.dcsFtpUsedAnonymous = source.fDcmOption.dcsFtpUsedAnonymous;
                m_fWsmCore.fOption.dcsFtpUser = source.fDcmOption.dcsFtpUser;
                m_fWsmCore.fOption.dcsFtpPassword = source.fDcmOption.dcsFtpPassword;
                m_fWsmCore.fOption.dcsHistorySearchPeriod = source.fDcmOption.dcsHistorySearchPeriod;
                m_fWsmCore.fOption.dcsNoticePopupEnabled = source.fDcmOption.dcsNoticePopupEnabled;
                m_fWsmCore.fOption.dcsNoticeLastTime = source.fDcmOption.dcsNoticeLastTime;
                // --
                m_fWsmCore.fOption.rmsStationConnectString = source.fRmmOption.rmsStationConnectString;
                m_fWsmCore.fOption.rmsStationTimeout = source.fRmmOption.rmsStationTimeout;
                m_fWsmCore.fOption.rmsTuneChannelId = source.fRmmOption.rmsTuneChannelId;
                m_fWsmCore.fOption.rmsCastChannelId = source.fRmmOption.rmsCastChannelId;
                m_fWsmCore.fOption.rmsFtpIp = source.fRmmOption.rmsFtpIp;
                m_fWsmCore.fOption.rmsFtpUsedAnonymous = source.fRmmOption.rmsFtpUsedAnonymous;
                m_fWsmCore.fOption.rmsFtpUser = source.fRmmOption.rmsFtpUser;
                m_fWsmCore.fOption.rmsFtpPassword = source.fRmmOption.rmsFtpPassword;
                m_fWsmCore.fOption.rmsHistorySearchPeriod = source.fRmmOption.rmsHistorySearchPeriod;
                m_fWsmCore.fOption.rmsNoticePopupEnabled = source.fRmmOption.rmsNoticePopupEnabled;
                m_fWsmCore.fOption.rmsNoticeLastTime = source.fRmmOption.rmsNoticeLastTime;
                m_fWsmCore.fOption.rmsDesktopAlertEnabled = source.fRmmOption.rmsDesktopAlertEnabled;
                m_fWsmCore.fOption.rmsDesktopAlertSoundEnabled = source.fRmmOption.rmsDesktopAlertSoundEnabled;
                m_fWsmCore.fOption.rmsDesktopAlertRecipeEnabled = source.fRmmOption.rmsDesktopAlertRecipeEnabled;
                // --
                m_fWsmCore.fOption.pmsStationConnectString = source.fPmmOption.pmsStationConnectString;
                m_fWsmCore.fOption.pmsStationTimeout = source.fPmmOption.pmsStationTimeout;
                m_fWsmCore.fOption.pmsTuneChannelId = source.fPmmOption.pmsTuneChannelId;
                m_fWsmCore.fOption.pmsCastChannelId = source.fPmmOption.pmsCastChannelId;
                m_fWsmCore.fOption.pmsFtpIp = source.fPmmOption.pmsFtpIp;
                m_fWsmCore.fOption.pmsFtpUsedAnonymous = source.fPmmOption.pmsFtpUsedAnonymous;
                m_fWsmCore.fOption.pmsFtpUser = source.fPmmOption.pmsFtpUser;
                m_fWsmCore.fOption.pmsFtpPassword = source.fPmmOption.pmsFtpPassword;
                m_fWsmCore.fOption.pmsHistorySearchPeriod = source.fPmmOption.pmsHistorySearchPeriod;
                m_fWsmCore.fOption.pmsNoticePopupEnabled = source.fPmmOption.pmsNoticePopupEnabled;
                m_fWsmCore.fOption.pmsNoticeLastTime = source.fPmmOption.pmsNoticeLastTime;
                m_fWsmCore.fOption.pmsDesktopAlertEnabled = source.fPmmOption.pmsDesktopAlertEnabled;
                m_fWsmCore.fOption.pmsDesktopAlertSoundEnabled = source.fPmmOption.pmsDesktopAlertSoundEnabled;
                m_fWsmCore.fOption.pmsDesktopAlertParameterEnabled = source.fPmmOption.pmsDesktopAlertParameterEnabled;
                // --
                m_fWsmCore.fOption.fhsStationConnectString = source.fFhmOption.fhsStationConnectString;
                m_fWsmCore.fOption.fhsStationTimeout = source.fFhmOption.fhsStationTimeout;
                m_fWsmCore.fOption.fhsTuneChannelId = source.fFhmOption.fhsTuneChannelId;
                m_fWsmCore.fOption.fhsCastChannelId = source.fFhmOption.fhsCastChannelId;
                m_fWsmCore.fOption.fhsFtpIp = source.fFhmOption.fhsFtpIp;
                m_fWsmCore.fOption.fhsFtpUsedAnonymous = source.fFhmOption.fhsFtpUsedAnonymous;
                m_fWsmCore.fOption.fhsFtpUser = source.fFhmOption.fhsFtpUser;
                m_fWsmCore.fOption.fhsFtpPassword = source.fFhmOption.fhsFtpPassword;
                m_fWsmCore.fOption.fhsHistorySearchPeriod = source.fFhmOption.fhsHistorySearchPeriod;
                m_fWsmCore.fOption.fhsNoticePopupEnabled = source.fFhmOption.fhsNoticePopupEnabled;
                m_fWsmCore.fOption.fhsNoticeLastTime = source.fFhmOption.fhsNoticeLastTime;
                m_fWsmCore.fOption.fhsDesktopAlertEnabled = source.fFhmOption.fhsDesktopAlertEnabled;
                m_fWsmCore.fOption.fhsDesktopAlertSoundEnabled = source.fFhmOption.fhsDesktopAlertSoundEnabled;
                m_fWsmCore.fOption.fhsDesktopAlertFileEnabled = source.fFhmOption.fhsDesktopAlertFileEnabled;
                // --
                    
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                source = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FWsmSiteOption source = null;
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;

            try
            {
                FCursor.waitCursor();

                // --

                exbExplorer.beginUpdate();

                // --

                source = ((FPropWsmOption)pgdWsmProp.selectedObject).source;
                source.fAdmOption = ((FPropAdmOption)pgdAdmProp.selectedObject).source;
                source.fDcmOption = ((FPropDcmOption)pgdDcmProp.selectedObject).source;
                source.fRmmOption = ((FPropRmmOption)pgdRmmProp.selectedObject).source;
                source.fPmmOption = ((FPropPmmOption)pgdPmmProp.selectedObject).source;
                source.fFhmOption = ((FPropFhmOption)pgdFhmProp.selectedObject).source;

                // --

                #region Validation

                FCommon.validateName(source.site, true, this.fUIWizard, "User Log In Option Dialog");
                FCommon.validateName(source.factory, true, this.fUIWizard, "User Log In Option Dialog");

                // --

                if (source.stationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Station Connect String" }));
                }

                if (source.stationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Station Timeout" }));
                }

                if (source.tuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Tune Channel ID" }));
                }

                if (source.castChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Cast Channel ID" }));
                }

                // --

                if (source.fAdmOption.adsStationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Station Connect String of Admin Manager" }));
                }

                if (source.fAdmOption.adsStationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Station Timeout of Admin Manager" }));
                }

                if (source.fAdmOption.adsTuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Tune Channel ID of Admin Manager" }));
                }

                if (source.fAdmOption.adsCastChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Cast Channel ID of Admin Manager" }));
                }

                if (source.fAdmOption.adsHistorySearchPeriod < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Search Period of Admin Manager" }));
                }

                if (source.fAdmOption.adsServerIssueMonitoringCount < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Server Issue Monitoring Count of Admin Manager " }));
                }

                if (source.fAdmOption.adsEapIssueMonitoringCount < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "EAP Issue Monitoring Count of Admin Manager " }));
                }

                if (source.fAdmOption.adsEquipmentIssueMonitoringCount < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Equipment Issue Monitoring Count of Admin Manager " }));
                }

                if (source.fAdmOption.adsSecsInterfaceLogFilterCaption1 != string.Empty && source.fAdmOption.adsSecsInterfaceLogFilterSecsItem1 == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "SECS Item 1" }));
                }

                if (source.fAdmOption.adsSecsInterfaceLogFilterCaption1 != string.Empty && source.fAdmOption.adsSecsInterfaceLogFilterHostItem1 == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Host Item 1" }));
                }

                if (source.fAdmOption.adsSecsInterfaceLogFilterCaption2 != string.Empty && source.fAdmOption.adsSecsInterfaceLogFilterSecsItem2 == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "SECS Item 2" }));
                }

                if (source.fAdmOption.adsSecsInterfaceLogFilterCaption2 != string.Empty && source.fAdmOption.adsSecsInterfaceLogFilterHostItem2 == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Host Item 2" }));
                }

                // --

                if (source.fDcmOption.dcsStationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "DCS Manager Station Connect String" }));
                }

                if (source.fDcmOption.dcsStationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "DCS Manager Station Timeout" }));
                }

                if (source.fDcmOption.dcsTuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "DCS Manager Tune Channel ID" }));
                }

                if (source.fDcmOption.dcsCastChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "DCS Manager Cast Channel ID" }));
                }

                if (source.fDcmOption.dcsHistorySearchPeriod < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "DCS Manager Search Period" }));
                }

                // --

                if (source.fRmmOption.rmsStationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "RMS Manager Station Connect String" }));
                }

                if (source.fRmmOption.rmsStationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "RMS Manager Station Timeout" }));
                }

                if (source.fRmmOption.rmsTuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "RMS Manager Tune Channel ID" }));
                }

                if (source.fRmmOption.rmsCastChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "RMS Manager Cast Channel ID" }));
                }
                
                if (source.fRmmOption.rmsHistorySearchPeriod < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "RMS Manager Search Period" }));
                }

                // --

                if (source.fPmmOption.pmsStationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "PMS Manager Station Connect String" }));
                }

                if (source.fPmmOption.pmsStationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "PMS Manager Station Timeout" }));
                }

                if (source.fPmmOption.pmsTuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "PMS Manager Tune Channel ID" }));
                }

                if (source.fPmmOption.pmsCastChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "PMS Manager Cast Channel ID" }));
                }

                if (source.fPmmOption.pmsHistorySearchPeriod < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "PMS Manager Search Period" }));
                }

                // --

                if (source.fFhmOption.fhsStationConnectString.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "FHS Manager Station Connect String" }));
                }

                if (source.fFhmOption.fhsStationTimeout < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "FHS Manager Station Timeout" }));
                }

                if (source.fFhmOption.fhsTuneChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "FHS Manager Tune Channel ID" }));
                }

                if (source.fFhmOption.fhsCastChannelId.Trim() == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "FHS Manager Cast Channel ID" }));
                }

                if (source.fFhmOption.fhsHistorySearchPeriod < 1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "FHS Manager Search Period" }));
                }
                #endregion

                // --

                m_fWsmCore.fOption.updateWsmOption(source);

                // --

                group = exbExplorer.Groups["Site"];
                if (group.Items.Exists(source.site))
                {
                    item = group.Items[source.site];
                }
                else
                {
                    item = group.Items.Add(source.site, source.site);
                }
                // --
                item.Tag = source;
                item.Active = true;

                // --

                exbExplorer.endUpdate();
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate(); 
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                source = null;
                group = null;
                item = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                initPropOfUserLogInOption();                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;
            int index = -1;

            try
            {
                FCursor.waitCursor();

                // --


                exbExplorer.beginUpdate();

                // --

                item = exbExplorer.ActiveItem;
                if (item == null)
                {
                    return;
                }

                // --

                group = item.Group;
                index = item.Index;
                // --
                m_fWsmCore.fOption.deleteSiteOption((FWsmSiteOption)item.Tag);
                group.Items.RemoveAt(index);

                // --

                exbExplorer.endUpdate();

                // --

                while (true)
                {
                    if (index < group.Items.Count)
                    {
                        break;
                    }

                    index--;
                }

                // --

                if (index >= 0)
                {
                    group.Items[index].Active = true;
                }

                // --

                if (group.Items.Count == 0)
                {
                    initPropOfUserLogInOption();
                    btnOk.Enabled = false;
                    btnDelete.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate(); 
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                group = null;
                item = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region exbExlorer Control Event Handler

        private void exbExplorer_ActiveItemChanged(
            object sender, 
            ItemEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Item == null)
                {
                    return;
                }

                // --

                e.Item.Checked = true;
                setPropOfUserLogInOption();
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exbExplorer_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (exbExplorer.ActiveItem == null)
                {
                    return;
                }

                // --

                exbExplorer.ActiveItem.Checked = true;
                setPropOfUserLogInOption();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
