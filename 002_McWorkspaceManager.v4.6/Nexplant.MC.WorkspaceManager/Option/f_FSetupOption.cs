/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSetupOption.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Workspace Manager Option Setup Form Class 
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.WorkspaceManager
{
    public partial class FSetupOption : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FWsmCore m_fWsmCore = null;
        private FPropSetupOption m_fPropSetupOption = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSetupOption(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSetupOption(
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
            }

            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FPropSetupOption fPropSetupOption
        {
            get
            {
                try
                {
                    return m_fPropSetupOption;
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

        private void setPropOfSetupOption(
            )
        {
            FWsmSiteOption target = null;

            try
            {
                if (exbExplorer.ActiveItem.Text == FOptionTab.General.ToString())
                {
                    m_fPropSetupOption = new FPropSetupOption(m_fWsmCore, pgdProp);
                    pgdProp.selectedObject = m_fPropSetupOption;
                }
                else
                {
                    if (m_fWsmCore.fOption.isLogIn)
                    {
                        target = new FWsmSiteOption();

                        // --

                        target.site = m_fWsmCore.fOption.site;
                        target.factory = m_fWsmCore.fOption.factory;
                        target.description = m_fWsmCore.fOption.description;
                        target.stationConnectString = m_fWsmCore.fOption.stationConnectString;
                        target.stationTimeout = m_fWsmCore.fOption.stationTimeout;
                        target.tuneChannelId = m_fWsmCore.fOption.tuneChannelId;
                        target.castChannelId = m_fWsmCore.fOption.castChannelId;

                        // --

                        target.fAdmOption = new FAdmSiteOption();
                        // --
                        target.fAdmOption.adsStationConnectString = m_fWsmCore.fOption.adsStationConnectString;
                        target.fAdmOption.adsStationTimeout = m_fWsmCore.fOption.adsStationTimeout;
                        target.fAdmOption.adsTuneChannelId = m_fWsmCore.fOption.adsTuneChannelId;
                        target.fAdmOption.adsCastChannelId = m_fWsmCore.fOption.adsCastChannelId;
                        target.fAdmOption.adsFtpIp = m_fWsmCore.fOption.adsFtpIp;
                        target.fAdmOption.adsFtpUsedAnonymous = m_fWsmCore.fOption.adsFtpUsedAnonymous;
                        target.fAdmOption.adsFtpUser = m_fWsmCore.fOption.adsFtpUser;
                        target.fAdmOption.adsFtpPassword = m_fWsmCore.fOption.adsFtpPassword;
                        target.fAdmOption.adsHistorySearchPeriod = m_fWsmCore.fOption.adsHistorySearchPeriod;
                        target.fAdmOption.adsNoticePopupEnabled = m_fWsmCore.fOption.adsNoticePopupEnabled;
                        target.fAdmOption.adsNoticeLastTime = m_fWsmCore.fOption.adsNoticeLastTime;
                        target.fAdmOption.adsDesktopAlertEnabled = m_fWsmCore.fOption.adsDesktopAlertEnabled;
                        target.fAdmOption.adsDesktopAlertSoundEnabled = m_fWsmCore.fOption.adsDesktopAlertSoundEnabled;
                        target.fAdmOption.adsDesktopAlertServerEnabled = m_fWsmCore.fOption.adsDesktopAlertServerEnabled;
                        target.fAdmOption.adsDesktopAlertEapEnabled = m_fWsmCore.fOption.adsDesktopAlertEapEnabled;
                        target.fAdmOption.adsDesktopAlertDeviceEnabled = m_fWsmCore.fOption.adsDesktopAlertDeviceEnabled;
                        target.fAdmOption.adsServerIssueMonitoringCount = m_fWsmCore.fOption.adsServerIssueMonitoringCount;
                        target.fAdmOption.adsEapIssueMonitoringCount = m_fWsmCore.fOption.adsEapIssueMonitoringCount;
                        target.fAdmOption.adsEquipmentIssueMonitoringCount = m_fWsmCore.fOption.adsEquipmentIssueMonitoringCount;
                        target.fAdmOption.adsSecsInterfaceLogFilterCaption1 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterCaption1;
                        target.fAdmOption.adsSecsInterfaceLogFilterSecsItem1 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterSecsItem1;
                        target.fAdmOption.adsSecsInterfaceLogFilterHostItem1 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterHostItem1;
                        target.fAdmOption.adsSecsInterfaceLogFilterCaption2 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterCaption2;
                        target.fAdmOption.adsSecsInterfaceLogFilterSecsItem2 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterSecsItem2;
                        target.fAdmOption.adsSecsInterfaceLogFilterHostItem2 = m_fWsmCore.fOption.adsSecsInterfaceLogFilterHostItem2;
                    }

                    // --

                    if (exbExplorer.ActiveItem.Text == FOptionTab.Site.ToString())
                    {
                        pgdProp.selectedObject = new FPropWsmOption(m_fWsmCore, pgdProp, target, false);
                    }
                    else if (exbExplorer.ActiveItem.Text == FOptionTab.ADS.ToString())
                    {
                        pgdProp.selectedObject = new FPropAdmOption(m_fWsmCore, pgdProp, target.fAdmOption, false);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                target = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSetupOption Form Event Handler

        private void FSetupOption_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                foreach (string s in Enum.GetNames(typeof(FOptionTab)))
                {
                    if (m_fWsmCore.fOption.isLogIn ||
                        (s != FOptionTab.Site.ToString() && s != FOptionTab.ADS.ToString()))
                    {
                        exbExplorer.Groups[0].Items.Add(s, s);
                    }
                }

                // --

                exbExplorer.Groups[0].Items[0].Active = true;
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
            try
            {
                if (m_fPropSetupOption.DebugLogFileKeepingPeriod < 1)
                {
                    FDebug.throwFException(m_fWsmCore.fUIWizard.generateMessage("E0001", new object[] { "Debug File Keeping Period" }));
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region exbExlorer Control Event Handler

        private void exbExplorer_ActiveItemChanged(
            object sender, 
            Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e
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
                setPropOfSetupOption();
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
