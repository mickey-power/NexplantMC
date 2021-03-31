/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAdmContainer.cs
--  Creator         : mjkim
--  Create Date     : 2011.09.22
--  Description     : FAmate Admin Manager Form Class
--  History         : Created by mjkim at 2011.09.22
----------------------------------------------------------------------------------------------------------*/
using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.Misc;

namespace Nexplant.MC.AdminManager
{
    public partial class FAdmContainer : FBaseTabMdiChildForm
    {
        // --
        private BackgroundWorker m_bgWorker = null;
 
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        // --
        private string m_newNotice = string.Empty;
        private string m_noticeUpdateTime = string.Empty;
        private string m_noticeContents = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAdmContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAdmContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fAdmCore = new FAdmCore(fWsmCore, this);
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
                    if (m_fAdmCore != null)
                    {
                        m_fAdmCore.Dispose();
                        m_fAdmCore = null;
                    }
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
            string appName = string.Empty;

            try
            {
                appName = m_fAdmCore.fWsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                // --
                this.Text = appName + " - [" + m_fAdmCore.fOption.factory + "]";
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

        private void setMainStatusBar(
            )
        {
            System.Reflection.Assembly assembly = null;
            string caption = string.Empty;
            string factory = string.Empty;
            string version = string.Empty;

            try
            {
                caption = m_fAdmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                caption += " - [" + m_fAdmCore.fWsmOption.site + "]";
                // --
                factory = m_fAdmCore.fOption.factory;
                //if (m_fAdmCore.fOption.description != string.Empty)
                //{
                //    factory += " - [" + m_fAdmCore.fOption.description + "]";
                //}
                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }


                // --

                m_fAdmCore.fWsmCore.onMainStatusBarChanged(
                    true,
                    caption,
                    factory,
                    m_fAdmCore.fOption.userGroup,
                    m_fAdmCore.fOption.user,
                    version
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                assembly = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                // --
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

        private void controlMainMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                // ***
                // Setup Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuFactory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Factory);
                mnuMenu.Tools[FMenuKey.MenuNotice].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Notice);
                mnuMenu.Tools[FMenuKey.MenuGeneralCode].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.GeneralCode);
                mnuMenu.Tools[FMenuKey.MenuEvent].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Event);
                mnuMenu.Tools[FMenuKey.MenuUserGroupApplication].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.UserGroupApplication);
                mnuMenu.Tools[FMenuKey.MenuUserGroup].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.UserGroup);
                mnuMenu.Tools[FMenuKey.MenuUser].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.User);
                mnuMenu.Tools[FMenuKey.MenuServer].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Server);
                mnuMenu.Tools[FMenuKey.MenuPackage].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Package);
                mnuMenu.Tools[FMenuKey.MenuModel].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Model);
                mnuMenu.Tools[FMenuKey.MenuComponent].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Component);
                // --
                mnuMenu.Tools[FMenuKey.MenuSecsModelObjectName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.SecsModelObjectName);
                mnuMenu.Tools[FMenuKey.MenuSecsModelFunctionName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.SecsModelFunctionName);
                mnuMenu.Tools[FMenuKey.MenuSecsModelUserTagName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.SecsModelUserTagName);
                // --
                //mnuMenu.Tools[FMenuKey.MenuPlcModelObjectName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PlcModelObjectName);
                //mnuMenu.Tools[FMenuKey.MenuPlcModelFunctionName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PlcModelFunctionName);
                //mnuMenu.Tools[FMenuKey.MenuPlcModelUserTagName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PlcModelUserTagName);
                // --
                mnuMenu.Tools[FMenuKey.MenuOpcModelObjectName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.OpcModelObjectName);
                mnuMenu.Tools[FMenuKey.MenuOpcModelFunctionName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.OpcModelFunctionName);
                mnuMenu.Tools[FMenuKey.MenuOpcModelUserTagName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.OpcModelUserTagName);
                // --
                mnuMenu.Tools[FMenuKey.MenuTcpModelObjectName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.TcpModelObjectName);
                mnuMenu.Tools[FMenuKey.MenuTcpModelFunctionName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.TcpModelFunctionName);
                mnuMenu.Tools[FMenuKey.MenuTcpModelUserTagName].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.TcpModelUserTagName);
                // --
                mnuMenu.Tools[FMenuKey.MenuModelSheet].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelSheet);
                // --
                mnuMenu.Tools[FMenuKey.MenuHostDriver].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.HostDriver);
                mnuMenu.Tools[FMenuKey.MenuMaker].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Maker);
                mnuMenu.Tools[FMenuKey.MenuEquipmentType].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentType);
                mnuMenu.Tools[FMenuKey.MenuEquipmentArea].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentArea);
                mnuMenu.Tools[FMenuKey.MenuEquipmentLine].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentLine);
                mnuMenu.Tools[FMenuKey.MenuEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Equipment);
                // ***
                // 2016.05.09 Jungyoul 
                // Inline Equipment 미지원
                // ***
                mnuMenu.Tools[FMenuKey.MenuInlineEquipment].SharedProps.Visible = false;
                // mnuMenu.Tools[FMenuKey.MenuInlineEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.InlineEquipment);
                mnuMenu.Tools[FMenuKey.MenuCustomRemoteCommand].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommand);
                mnuMenu.Tools[FMenuKey.MenuEap].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Eap);

                // --

                // ***
                // Transaction Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuEapBatchModification].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBatchModification);
                mnuMenu.Tools[FMenuKey.MenuEapRelease].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease);
                mnuMenu.Tools[FMenuKey.MenuEapStart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart);
                mnuMenu.Tools[FMenuKey.MenuEapStop].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop);
                mnuMenu.Tools[FMenuKey.MenuEapRestart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart);
                mnuMenu.Tools[FMenuKey.MenuEapReload].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload);
                mnuMenu.Tools[FMenuKey.MenuEapAbort].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapAbort);
                mnuMenu.Tools[FMenuKey.MenuEapMove].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMove);
                mnuMenu.Tools[FMenuKey.MenuEapLogLevelSetup].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogLevelSetup);                
                mnuMenu.Tools[FMenuKey.MenuServerMainSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch);
                mnuMenu.Tools[FMenuKey.MenuServerBackupSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch);

                // --

                // ***
                // Remote Commnad Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuEquipmentEventDefineRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentEventDefineRequest);
                mnuMenu.Tools[FMenuKey.MenuEquipmentVersionRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentVersionRequest);
                mnuMenu.Tools[FMenuKey.MenuEquipmentControlModeRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentControlModeRequest);
                mnuMenu.Tools[FMenuKey.MenuCustomRemoteCommandRequest].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommandRequest);
                // --
                mnuMenu.Tools[FMenuKey.MenuRemotePingTestByServer].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByServer);
                mnuMenu.Tools[FMenuKey.MenuRemotePingTestByEquipment].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RemotePingTestByEquipment);
                // --

                // ***
                // Monitoring Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuEapMonitor].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMonitor);
                mnuMenu.Tools[FMenuKey.MenuEquipmentMonitor].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentMonitor);
                mnuMenu.Tools[FMenuKey.MenuIssueEventMonitor].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.IssueEventMonitor);

                // --

                // ***
                // Tool Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuAdminAgentOption].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentOption);
                
                // --

                // ***
                // View Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuEapLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList);
                mnuMenu.Tools[FMenuKey.MenuEapBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList);
                // --
                // ***
                // 2017.06.02 by spike.lee
                // MC Interface Log 관련 권한 추가
                // ***
                //mnuMenu.Tools[FMenuKey.MenuEapInterfaceLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                //mnuMenu.Tools[FMenuKey.MenuEapInterfaceBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuEapInterfaceLogList].SharedProps.Visible = false;
                mnuMenu.Tools[FMenuKey.MenuEapInterfaceBackupLogList].SharedProps.Visible = false;
                // ***
                mnuMenu.Tools[FMenuKey.MenuAdminServiceLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminServiceLogList);
                mnuMenu.Tools[FMenuKey.MenuAdminServiceBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminServiceBackupLogList);
                mnuMenu.Tools[FMenuKey.MenuAdminAgentLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList);
                mnuMenu.Tools[FMenuKey.MenuAdminAgentBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList);
                mnuMenu.Tools[FMenuKey.MenuAlertServiceLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AlertServiceLogList);
                mnuMenu.Tools[FMenuKey.MenuAlertServiceBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AlertServiceBackupLogList);

                // --

                // ***
                // Inquiry Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuRecentNotice].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.RecentNotice);
                mnuMenu.Tools[FMenuKey.MenuNoticeHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.NoticeHistory);
                mnuMenu.Tools[FMenuKey.MenuSystemCheckList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.SystemCheckList);
                mnuMenu.Tools[FMenuKey.MenuServerList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerList);
                mnuMenu.Tools[FMenuKey.MenuServerStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus);
                mnuMenu.Tools[FMenuKey.MenuServerHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory);
                mnuMenu.Tools[FMenuKey.MenuServerResourceList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceList);
                mnuMenu.Tools[FMenuKey.MenuServerResourceStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus);
                mnuMenu.Tools[FMenuKey.MenuServerResourceComparison].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceComparison);
                mnuMenu.Tools[FMenuKey.MenuServerResourceAnalysis].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceAnalysis);
                mnuMenu.Tools[FMenuKey.MenuServerResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory);
                mnuMenu.Tools[FMenuKey.MenuPackageList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PackageList);
                mnuMenu.Tools[FMenuKey.MenuPackageStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PackageStatus);
                mnuMenu.Tools[FMenuKey.MenuModelList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelList);
                mnuMenu.Tools[FMenuKey.MenuModelStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelStatus);
                mnuMenu.Tools[FMenuKey.MenuModelVersionSchema].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelVersionSchema);
                mnuMenu.Tools[FMenuKey.MenuComponentList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ComponentList);
                mnuMenu.Tools[FMenuKey.MenuComponentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ComponentStatus);
                mnuMenu.Tools[FMenuKey.MenuEapList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapList);
                mnuMenu.Tools[FMenuKey.MenuEapStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus);
                mnuMenu.Tools[FMenuKey.MenuEapHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory);
                // ***
                // 2017.06.02 by spike.lee
                // MC Repository Status 권한 부여 추가
                // ***
                mnuMenu.Tools[FMenuKey.MenuEapRepositoryStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus);
                // ***
                mnuMenu.Tools[FMenuKey.MenuEapNeedActionList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapNeedActionList);
                mnuMenu.Tools[FMenuKey.MenuEapResourceList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceList);
                mnuMenu.Tools[FMenuKey.MenuEapResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceHistory);
                mnuMenu.Tools[FMenuKey.MenuEapResourceComparison].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapResourceSummary);
                mnuMenu.Tools[FMenuKey.MenuEquipmentList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentList);
                mnuMenu.Tools[FMenuKey.MenuEquipmentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuEquipmentHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);
                mnuMenu.Tools[FMenuKey.MenuEquipmentGemStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentGemStatus);
                mnuMenu.Tools[FMenuKey.MenuUserHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.UserHistory);
                // ***
                // 2017.07.18 by spike.lee
                // Issue Event Report 관련 권한 부여 추가
                // ***
                mnuMenu.Tools[FMenuKey.MenuIssueEventSummary].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.IssueEventSummary);
                mnuMenu.Tools[FMenuKey.MenuServerIssueEventSummary].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventSummary);
                mnuMenu.Tools[FMenuKey.MenuEapIssueEventSummary].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventSummary);
                mnuMenu.Tools[FMenuKey.MenuEquipmentIssueEventSummary].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventSummary);
                // --
                mnuMenu.Tools[FMenuKey.MenuServerIssueEventHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventHistory);
                mnuMenu.Tools[FMenuKey.MenuEapIssueEventHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventHistory);
                mnuMenu.Tools[FMenuKey.MenuEquipmentIssueEventHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuServerIssueEventTotal].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventTotal);
                mnuMenu.Tools[FMenuKey.MenuEapIssueEventTotal].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventTotal);
                mnuMenu.Tools[FMenuKey.MenuEquipmentIssueEventTotal].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventTotal);

                // --

                // ***
                // 2017.04.28 by spike.lee
                // SECS1 To HSMS Menu 권한 부여
                // ***
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsEvent].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsEvent);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverter].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverter);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterList);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterStatus);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterHistory);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterMonitor].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterMonitor);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterLogList);
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterBackupLogList);

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initWorker(
            )
        {
            try
            {
                m_bgWorker = new BackgroundWorker();
                m_bgWorker.DoWork += bgWorker_DoWork;
                m_bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
                // --
                m_bgWorker.RunWorkerAsync();
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

        private void logInUser(
            )
        {
            FNotification fNotification = null;

            try
            {
                if (!validateUserGroupAuthority())
                {
                    this.Close();
                    return;
                }

                // --

                // ***
                // 2014.10.14 by spike.lee
                // ***
                //downloadHostDriver();
                initWorker();

                // --

                if (m_fAdmCore.fOption.noticePopupEnabled)
                {
                    if (m_newNotice == FYesNo.Yes.ToString())
                    {
                        if (FMessageBox.showQuestion(
                            FConstants.ApplicationName,
                            m_fAdmCore.fWsmCore.fUIWizard.generateMessage("Q0019"),
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button2,
                            this
                            ) == DialogResult.Yes)
                        {
                            fNotification = new FNotification(m_fAdmCore, m_noticeUpdateTime, m_noticeContents);
                            fNotification.ShowDialog(this);
                        }
                    }
                }

                // --

                setTitle();
                controlMainMenu();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
                // --
                this.Close();
            }
            finally
            {
                if (fNotification != null)
                {
                    fNotification.Dispose();
                    fNotification = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void downloadHostDriver(
           )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutHdr = null;
            FFtp fFtp = null;
            string zipFileName = string.Empty;
            string tempFilePath = string.Empty;
            // --
            System.Diagnostics.Stopwatch sw = null;

            try
            {
                sw = new System.Diagnostics.Stopwatch();
                sw.Start();

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SysHostDriverDownload_In.E_ADMADS_SysHostDriverDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SysHostDriverDownload_In.A_hLanguage, FADMADS_SysHostDriverDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SysHostDriverDownload_In.A_hFactory, FADMADS_SysHostDriverDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SysHostDriverDownload_In.A_hUserId, FADMADS_SysHostDriverDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SysHostDriverDownload_In.A_hStep, FADMADS_SysHostDriverDownload_In.D_hStep, "1");

                // --

                FADMADSCaster.ADMADS_SysHostDriverDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SysHostDriverDownload_Out.A_hStatus, FADMADS_SysHostDriverDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SysHostDriverDownload_Out.A_hStatusMessage, FADMADS_SysHostDriverDownload_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutHdr = fXmlNodeOut.get_elem(FADMADS_SysHostDriverDownload_Out.FHostDriver.E_HostDriver);
                // --
                zipFileName = fXmlNodeOutHdr.get_elemVal(
                    FADMADS_SysHostDriverDownload_Out.FHostDriver.A_Path,
                    FADMADS_SysHostDriverDownload_Out.FHostDriver.D_Path
                    );
                if (zipFileName.Trim() == string.Empty)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fFtp.downloadFiles(tempFilePath, zipFileName);
                fFtp.deleteFiles(zipFileName);

                // --

                zipFileName = Path.Combine(tempFilePath, zipFileName);
                F7Zip.unpack(zipFileName, m_fAdmCore.fWsmCore.hostDriverPath);

                // --

                sw.Stop();
                System.Diagnostics.Debug.WriteLine("HostDriverDownloadTime=" + sw.ElapsedMilliseconds.ToString());
            }
            catch (Exception ex)
            {
                // Modify by Jeff.Kim 2018.04.13
                // SDI 경우 Ftp 를 개개인이 방화벽 예외 신청을 해야 해서, Error가 발생해도 무시하는것으로 수정
                //FMessageBox.showError(FConstants.ApplicationName, ex, this);
                FDebug.writeLog(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeOut = null;
                fXmlNodeOutHdr = null;

                // --

                FCommon.deleteDirectory(tempFilePath);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuLogOut(
            )
        {
            try
            {
                // ***
                // Log Out Confirm
                // ***                
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fWsmCore.fUIWizard.generateMessage("Q0007", new object[] { FConstants.ApplicationName }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                closeAllDesktopAlert();
                // --
                this.closeAllChilds();
                
                // --

                setTitle();
                controlMainMenu();
                setMainStatusBar();

                // --

                logInUser();
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

        private void procMenuClose(
            )
        {
            try
            {
                this.Close();
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

        private void procMenuFactory(
            )
        {
            FFactory fFactory = null;

            try
            {   
                fFactory = (FFactory)this.getChild(typeof(FFactory));
                if (fFactory == null)
                {
                    fFactory = new FFactory(m_fAdmCore);
                    this.showChild(fFactory);
                }
                fFactory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFactory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuNotice(
            )
        {
            FNotice fNotice = null;

            try
            {   
                fNotice = (FNotice)this.getChild(typeof(FNotice));
                if (fNotice == null)
                {
                    fNotice = new FNotice(m_fAdmCore);
                    this.showChild(fNotice);
                }
                fNotice.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNotice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuGeneralCode(
            )
        {
            FGeneralCode fGeneralCode = null;

            try
            {                
                fGeneralCode = (FGeneralCode)this.getChild(typeof(FGeneralCode));
                if (fGeneralCode == null)
                {
                    fGeneralCode = new FGeneralCode(m_fAdmCore);
                    this.showChild(fGeneralCode);
                }
                fGeneralCode.activate();
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

        private void procMenuEvent(
            )
        {
            FEvent fEvent = null;

            try
            {
                fEvent = (FEvent)this.getChild(typeof(FEvent));
                if (fEvent == null)
                {
                    fEvent = new FEvent(m_fAdmCore);
                    this.showChild(fEvent);
                }
                fEvent.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEvent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuUserGroupApplication(
            )
        {
            FUserGroupApplication fUserGroupApplication = null;

            try
            {   
                fUserGroupApplication = (FUserGroupApplication)this.getChild(typeof(FUserGroupApplication));
                if (fUserGroupApplication == null)
                {
                    fUserGroupApplication = new FUserGroupApplication(m_fAdmCore);
                    this.showChild(fUserGroupApplication);
                }
                fUserGroupApplication.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fUserGroupApplication = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuUserGroup(
            )
        {
            FUserGroup fUserGroup = null;

            try
            {   
                fUserGroup = (FUserGroup)this.getChild(typeof(FUserGroup));
                if (fUserGroup == null)
                {
                    fUserGroup = new FUserGroup(m_fAdmCore);
                    this.showChild(fUserGroup);
                }
                fUserGroup.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fUserGroup = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuUser(
            )
        {
            FUser fUser = null;

            try
            {   
                fUser = (FUser)this.getChild(typeof(FUser));
                if (fUser == null)
                {
                    fUser = new FUser(m_fAdmCore);
                    this.showChild(fUser);
                }
                fUser.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fUser = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuUserHistory(
            )
        {
            FUserHistory fUserHistory = null;

            try
            {
                fUserHistory = (FUserHistory)this.getChild(typeof(FUserHistory).Name);
                if (fUserHistory == null)
                {
                    fUserHistory = new FUserHistory(m_fAdmCore);
                    this.showChild(fUserHistory);
                }
                fUserHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fUserHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuServer(
            )
        {
            FServer fServer = null;

            try
            {   
                fServer = (FServer)this.getChild(typeof(FServer));
                if (fServer == null)
                {
                    fServer = new FServer(m_fAdmCore);
                    this.showChild(fServer);
                }
                fServer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuPackage(
            )
        {
            FPackage fPackage = null;

            try
            {
                fPackage = (FPackage)this.getChild(typeof(FPackage));
                if (fPackage == null)
                {
                    fPackage = new FPackage(m_fAdmCore);
                    this.showChild(fPackage);
                }
                fPackage.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPackage = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuComponent(
            )
        {
            FComponent fComponent = null;

            try
            {   
                fComponent = (FComponent)this.getChild(typeof(FComponent));
                if (fComponent == null)
                {
                    fComponent = new FComponent(m_fAdmCore);
                    this.showChild(fComponent);
                }
                fComponent.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fComponent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModelSheet(
            )
        {
            FModelSheet fModelSheet = null;

            try
            {   
                fModelSheet = (FModelSheet)this.getChild(typeof(FModelSheet));
                if (fModelSheet == null)
                {
                    fModelSheet = new FModelSheet(m_fAdmCore);
                    this.showChild(fModelSheet);
                }
                fModelSheet.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelSheet = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMaker(
            )
        {
            FMaker fMaker = null;

            try
            {   
                fMaker = (FMaker)this.getChild(typeof(FMaker));
                if (fMaker == null)
                {
                    fMaker = new FMaker(m_fAdmCore);
                    this.showChild(fMaker);
                }
                fMaker.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMaker = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuHostDriver(
            )
        {
            FHostDriver fHostDriver = null;

            try
            {   
                fHostDriver = (FHostDriver)this.getChild(typeof(FHostDriver));
                if (fHostDriver == null)
                {
                    fHostDriver = new FHostDriver(m_fAdmCore);
                    this.showChild(fHostDriver);
                }
                fHostDriver.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDriver = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModel(
            )
        {
            FModel fModel = null;

            try
            {
                fModel = (FModel)this.getChild(typeof(FModel));
                if (fModel == null)
                {
                    fModel = new FModel(m_fAdmCore);
                    this.showChild(fModel);
                }
                fModel.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModel = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsModelObjectName(
            )
        {
            FSecsModelObjectName fSecsModelObjectName = null;

            try
            {
                fSecsModelObjectName = (FSecsModelObjectName)this.getChild(typeof(FSecsModelObjectName));
                if (fSecsModelObjectName == null)
                {
                    fSecsModelObjectName = new FSecsModelObjectName(m_fAdmCore);
                    this.showChild(fSecsModelObjectName);
                }
                fSecsModelObjectName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsModelObjectName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsModelFunctionName(
            )
        {
            FSecsModelFunctionName fSecsModelFunctionName = null;

            try
            {   
                fSecsModelFunctionName = (FSecsModelFunctionName)this.getChild(typeof(FSecsModelFunctionName));
                if (fSecsModelFunctionName == null)
                {
                    fSecsModelFunctionName = new FSecsModelFunctionName(m_fAdmCore);
                    this.showChild(fSecsModelFunctionName);
                }
                fSecsModelFunctionName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsModelFunctionName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsModelUserTagName(
            )
        {
            FSecsModelUserTagName fSecsModelUserTagName = null;

            try
            {   
                fSecsModelUserTagName = (FSecsModelUserTagName)this.getChild(typeof(FSecsModelUserTagName));
                if (fSecsModelUserTagName == null)
                {
                    fSecsModelUserTagName = new FSecsModelUserTagName(m_fAdmCore);
                    this.showChild(fSecsModelUserTagName);
                }
                fSecsModelUserTagName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsModelUserTagName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuPlcModelObjectName(
        //    )
        //{
        //    FPlcModelObjectName fPlcModelObjectName = null;

        //    try
        //    {
        //        fPlcModelObjectName = (FPlcModelObjectName)this.getChild(typeof(FPlcModelObjectName));
        //        if (fPlcModelObjectName == null)
        //        {
        //            fPlcModelObjectName = new FPlcModelObjectName(m_fAdmCore);
        //            this.showChild(fPlcModelObjectName);
        //        }
        //        fPlcModelObjectName.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fPlcModelObjectName = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuPlcModelFunctionName(
        //    )
        //{
        //    FPlcModelFunctionName fPlcModelFunctionName = null;

        //    try
        //    {   
        //        fPlcModelFunctionName = (FPlcModelFunctionName)this.getChild(typeof(FPlcModelFunctionName));
        //        if (fPlcModelFunctionName == null)
        //        {
        //            fPlcModelFunctionName = new FPlcModelFunctionName(m_fAdmCore);
        //            this.showChild(fPlcModelFunctionName);
        //        }
        //        fPlcModelFunctionName.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fPlcModelFunctionName = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuPlcModelUserTagName(
        //    )
        //{
        //    FPlcModelUserTagName fPlcModelUserTagName = null;

        //    try
        //    {   
        //        fPlcModelUserTagName = (FPlcModelUserTagName)this.getChild(typeof(FPlcModelUserTagName));
        //        if (fPlcModelUserTagName == null)
        //        {
        //            fPlcModelUserTagName = new FPlcModelUserTagName(m_fAdmCore);
        //            this.showChild(fPlcModelUserTagName);
        //        }
        //        fPlcModelUserTagName.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fPlcModelUserTagName = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpcModelObjectName(
            )
        {
            FOpcModelObjectName fOpcModelObjectName = null;

            try
            {
                fOpcModelObjectName = (FOpcModelObjectName)this.getChild(typeof(FOpcModelObjectName));
                if (fOpcModelObjectName == null)
                {
                    fOpcModelObjectName = new FOpcModelObjectName(m_fAdmCore);
                    this.showChild(fOpcModelObjectName);
                }
                fOpcModelObjectName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcModelObjectName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpcModelFunctionName(
            )
        {
            FOpcModelFunctionName fOpcModelFunctionName = null;

            try
            {
                fOpcModelFunctionName = (FOpcModelFunctionName)this.getChild(typeof(FOpcModelFunctionName));
                if (fOpcModelFunctionName == null)
                {
                    fOpcModelFunctionName = new FOpcModelFunctionName(m_fAdmCore);
                    this.showChild(fOpcModelFunctionName);
                }
                fOpcModelFunctionName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcModelFunctionName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpcModelUserTagName(
            )
        {
            FOpcModelUserTagName fOpcModelUserTagName = null;

            try
            {   
                fOpcModelUserTagName = (FOpcModelUserTagName)this.getChild(typeof(FOpcModelUserTagName));
                if (fOpcModelUserTagName == null)
                {
                    fOpcModelUserTagName = new FOpcModelUserTagName(m_fAdmCore);
                    this.showChild(fOpcModelUserTagName);
                }
                fOpcModelUserTagName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcModelUserTagName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuTcpModelObjectName(
            )
        {
            FTcpModelObjectName fTcpModelObjectName = null;

            try
            {
                fTcpModelObjectName = (FTcpModelObjectName)this.getChild(typeof(FTcpModelObjectName));
                if (fTcpModelObjectName == null)
                {
                    fTcpModelObjectName = new FTcpModelObjectName(m_fAdmCore);
                    this.showChild(fTcpModelObjectName);
                }
                fTcpModelObjectName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpModelObjectName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuTcpModelFunctionName(
            )
        {
            FTcpModelFunctionName fTcpModelFunctionName = null;

            try
            {   
                fTcpModelFunctionName = (FTcpModelFunctionName)this.getChild(typeof(FTcpModelFunctionName));
                if (fTcpModelFunctionName == null)
                {
                    fTcpModelFunctionName = new FTcpModelFunctionName(m_fAdmCore);
                    this.showChild(fTcpModelFunctionName);
                }
                fTcpModelFunctionName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpModelFunctionName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuTcpModelUserTagName(
            )
        {
            FTcpModelUserTagName fTcpModelUserTagName = null;

            try
            {
                fTcpModelUserTagName = (FTcpModelUserTagName)this.getChild(typeof(FTcpModelUserTagName));
                if (fTcpModelUserTagName == null)
                {
                    fTcpModelUserTagName = new FTcpModelUserTagName(m_fAdmCore);
                    this.showChild(fTcpModelUserTagName);
                }
                fTcpModelUserTagName.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpModelUserTagName = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCustomRemoteCommand(
            )
        {
            FCustomRemoteCommand fCommand = null;

            try
            {   
                fCommand = (FCustomRemoteCommand)this.getChild(typeof(FCustomRemoteCommand));
                if (fCommand == null)
                {
                    fCommand = new FCustomRemoteCommand(m_fAdmCore);
                    this.showChild(fCommand);
                }
                fCommand.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fCommand = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentType(
            )
        {
            FEquipmentType fEquipmentType = null;

            try
            {   
                fEquipmentType = (FEquipmentType)this.getChild(typeof(FEquipmentType));
                if (fEquipmentType == null)
                {
                    fEquipmentType = new FEquipmentType(m_fAdmCore);
                    this.showChild(fEquipmentType);
                }
                fEquipmentType.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentType = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentArea(
            )
        {
            FEquipmentArea fEquipmentArea = null;

            try
            {
                fEquipmentArea = (FEquipmentArea)this.getChild(typeof(FEquipmentArea));
                if (fEquipmentArea == null)
                {
                    fEquipmentArea = new FEquipmentArea(m_fAdmCore);
                    this.showChild(fEquipmentArea);
                }
                fEquipmentArea.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentArea = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentLine(
            )
        {
            FEquipmentLine fEquipmentLine = null;

            try
            {   
                fEquipmentLine = (FEquipmentLine)this.getChild(typeof(FEquipmentLine));
                if (fEquipmentLine == null)
                {
                    fEquipmentLine = new FEquipmentLine(m_fAdmCore);
                    this.showChild(fEquipmentLine);
                }
                fEquipmentLine.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentLine = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipment(
            )
        {
            FEquipment fEquipment = null;

            try
            {
                fEquipment = (FEquipment)this.getChild(typeof(FEquipment));
                if (fEquipment == null)
                {
                    fEquipment = new FEquipment(m_fAdmCore);
                    this.showChild(fEquipment);
                }
                fEquipment.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipment = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuInlineEquipment(
            )
        {
            FInlineEquipment fInlineEquipment = null;

            try
            {
                fInlineEquipment = (FInlineEquipment)this.getChild(typeof(FInlineEquipment));
                if (fInlineEquipment == null)
                {
                    fInlineEquipment = new FInlineEquipment(m_fAdmCore);
                    this.showChild(fInlineEquipment);
                }
                fInlineEquipment.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fInlineEquipment = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEap(
            )
        {
            FEap fEap = null;

            try
            {
                fEap = (FEap)this.getChild(typeof(FEap));
                if (fEap == null)
                {
                    fEap = new FEap(m_fAdmCore);
                    this.showChild(fEap);
                }
                fEap.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEap = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapBatchModification(
            )
        {
            FEapBatchModification fEap = null;

            try
            {
                fEap = (FEapBatchModification)this.getChild(typeof(FEapBatchModification));
                if (fEap == null)
                {
                    fEap = new FEapBatchModification(m_fAdmCore);
                    this.showChild(fEap);
                }
                fEap.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEap = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRelease(
            )
        {
            FEapRelease fEapRelease = null;

            try
            {   
                fEapRelease = (FEapRelease)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRelease));
                if (fEapRelease == null)
                {
                    fEapRelease = new FEapRelease(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRelease);
                }
                fEapRelease.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRelease = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapReload(
            )
        {
            FEapReload fEapReload = null;

            try
            {   
                fEapReload = (FEapReload)this.getChild(typeof(FEapReload));
                if (fEapReload == null)
                {
                    fEapReload = new FEapReload(m_fAdmCore);
                    this.showChild(fEapReload);
                }
                fEapReload.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapReload = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRestart(
            )
        {
            FEapRestart fEapRestart = null;

            try
            {
                fEapRestart = (FEapRestart)this.getChild(typeof(FEapRestart));
                if (fEapRestart == null)
                {
                    fEapRestart = new FEapRestart(m_fAdmCore);
                    this.showChild(fEapRestart);
                }
                fEapRestart.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRestart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStart(
            )
        {
            FEapStart fEapStart = null;

            try
            {
                fEapStart = (FEapStart)this.getChild(typeof(FEapStart));
                if (fEapStart == null)
                {
                    fEapStart = new FEapStart(m_fAdmCore);
                    this.showChild(fEapStart);
                }
                fEapStart.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStop(
            )
        {
            FEapStop fEapStop = null;

            try
            {   
                fEapStop = (FEapStop)this.getChild(typeof(FEapStop));
                if (fEapStop == null)
                {
                    fEapStop = new FEapStop(m_fAdmCore);
                    this.showChild(fEapStop);
                }
                fEapStop.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStop = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapAbort(
            )
        {
            FEapAbort fEapAbort = null;

            try
            {
                fEapAbort = (FEapAbort)this.getChild(typeof(FEapAbort));
                if (fEapAbort == null)
                {
                    fEapAbort = new FEapAbort(m_fAdmCore);
                    this.showChild(fEapAbort);
                }
                fEapAbort.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapAbort = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapMove(
            )
        {
            FEapMove fEapMove = null;

            try
            {
                fEapMove = (FEapMove)this.getChild(typeof(FEapMove));
                if (fEapMove == null)
                {
                    fEapMove = new FEapMove(m_fAdmCore);
                    this.showChild(fEapMove);
                }
                fEapMove.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapMove = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapLogLevelSetup(
            )
        {
            FEapLogLevelSetup fEapLogLevelSetup = null;

            try
            {
                fEapLogLevelSetup = (FEapLogLevelSetup)this.getChild(typeof(FEapLogLevelSetup));
                if (fEapLogLevelSetup == null)
                {
                    fEapLogLevelSetup = new FEapLogLevelSetup(m_fAdmCore);
                    this.showChild(fEapLogLevelSetup);
                }
                fEapLogLevelSetup.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogLevelSetup = null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerMainSwitch(
            )
        {
            FServerMainSwitch fServerMainSwitch = null;

            try
            {
                fServerMainSwitch = (FServerMainSwitch)this.getChild(typeof(FServerMainSwitch));
                if (fServerMainSwitch == null)
                {
                    fServerMainSwitch = new FServerMainSwitch(m_fAdmCore);
                    this.showChild(fServerMainSwitch);
                }
                fServerMainSwitch.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerMainSwitch = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerBackupSwitch(
            )
        {
            FServerBackupSwitch fServerBackupSwitch = null;

            try
            {
                fServerBackupSwitch = (FServerBackupSwitch)this.getChild(typeof(FServerBackupSwitch));
                if (fServerBackupSwitch == null)
                {
                    fServerBackupSwitch = new FServerBackupSwitch(m_fAdmCore);
                    this.showChild(fServerBackupSwitch);
                }
                fServerBackupSwitch.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerBackupSwitch = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapHistory(
            )
        {
            FEapHistory fEapHistory = null;

            try
            {
                fEapHistory = (FEapHistory)this.getChild(typeof(FEapHistory).Name);
                if (fEapHistory == null)
                {
                    fEapHistory = new FEapHistory(m_fAdmCore);
                    this.showChild(fEapHistory);
                }
                fEapHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapNeedActionList(
            )
        {
            FEapNeedActionList fEapList = null;

            try
            {
                fEapList = (FEapNeedActionList)this.getChild(typeof(FEapNeedActionList).Name);
                if (fEapList == null)
                {
                    fEapList = new FEapNeedActionList(m_fAdmCore);
                    this.showChild(fEapList);
                }
                fEapList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapResourceList(
            )
        {
            FEapResourceList fEapResourceList = null;

            try
            {
                fEapResourceList = (FEapResourceList)this.getChild(typeof(FEapResourceList).Name);
                if (fEapResourceList == null)
                {
                    fEapResourceList = new FEapResourceList(m_fAdmCore);
                    this.showChild(fEapResourceList);
                }
                fEapResourceList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapResourceList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapResourceSummary(
            )
        {
            FEapResourceComparison fEapResourceSummary = null;

            try
            {
                fEapResourceSummary = (FEapResourceComparison)this.getChild(typeof(FEapResourceComparison).Name);
                if (fEapResourceSummary == null)
                {
                    fEapResourceSummary = new FEapResourceComparison(m_fAdmCore);
                    this.showChild(fEapResourceSummary);
                }
                fEapResourceSummary.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapResourceSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapResourceHistory(
            )
        {
            FEapResourceHistory fEapResourceHistory = null;

            try
            {
                fEapResourceHistory = (FEapResourceHistory)this.getChild(typeof(FEapResourceHistory).Name);
                if (fEapResourceHistory == null)
                {
                    fEapResourceHistory = new FEapResourceHistory(m_fAdmCore);
                    this.showChild(fEapResourceHistory);
                }
                fEapResourceHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapResourceHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapMonitor(
           )
        {
            FEapMonitor fMonitor = null;

            try
            {   
                fMonitor = (FEapMonitor)this.getChild(typeof(FEapMonitor).Name);
                if (fMonitor == null)
                {
                    fMonitor = new FEapMonitor(m_fAdmCore);
                    this.showChild(fMonitor);
                }
                fMonitor.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMonitor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentMonitor(
           )
        {
            FEquipmentMonitor fMonitor = null;

            try
            {
                fMonitor = (FEquipmentMonitor)this.getChild(typeof(FEquipmentMonitor).Name);
                if (fMonitor == null)
                {
                    fMonitor = new FEquipmentMonitor(m_fAdmCore);
                    this.showChild(fMonitor);
                }
                fMonitor.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMonitor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuIssueEventMonitor(
           )
        {
            FIssueEventMonitor fMonitor = null;

            try
            {
                fMonitor = (FIssueEventMonitor)this.getChild(typeof(FIssueEventMonitor).Name);
                if (fMonitor == null)
                {
                    fMonitor = new FIssueEventMonitor(m_fAdmCore);
                    this.showChild(fMonitor);
                }
                fMonitor.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fMonitor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentEventDefineRequest(
           )
        {
            FEquipmentEventDefineRequest fEquipmentEventDefineRequest = null;

            try
            {
                fEquipmentEventDefineRequest = (FEquipmentEventDefineRequest)this.getChild(typeof(FEquipmentEventDefineRequest).Name);
                if (fEquipmentEventDefineRequest == null)
                {
                    fEquipmentEventDefineRequest = new FEquipmentEventDefineRequest(m_fAdmCore);
                    this.showChild(fEquipmentEventDefineRequest);
                }
                fEquipmentEventDefineRequest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentEventDefineRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentVersionRequest(
           )
        {
            FEquipmentVersionRequest fEquipmentVersionRequest = null;

            try
            {
                fEquipmentVersionRequest = (FEquipmentVersionRequest)this.getChild(typeof(FEquipmentVersionRequest).Name);
                if (fEquipmentVersionRequest == null)
                {
                    fEquipmentVersionRequest = new FEquipmentVersionRequest(m_fAdmCore);
                    this.showChild(fEquipmentVersionRequest);
                }
                fEquipmentVersionRequest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentVersionRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        private void procMenuEquipmentControlModeRequest(
          )
        {
            FEquipmentControlModeRequest fEquipmentControlModeRequest = null;

            try
            {
                fEquipmentControlModeRequest = (FEquipmentControlModeRequest)this.getChild(typeof(FEquipmentControlModeRequest).Name);
                if (fEquipmentControlModeRequest == null)
                {
                    fEquipmentControlModeRequest = new FEquipmentControlModeRequest(m_fAdmCore);
                    this.showChild(fEquipmentControlModeRequest);
                }
                fEquipmentControlModeRequest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentControlModeRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCustomRemoteCommandRequest(
          )
        {
            FCustomRemoteCommandRequest fCustoRemoteCommandRequest = null;

            try
            {
                fCustoRemoteCommandRequest = (FCustomRemoteCommandRequest)this.getChild(typeof(FCustomRemoteCommandRequest).Name);
                if (fCustoRemoteCommandRequest == null)
                {
                    fCustoRemoteCommandRequest = new FCustomRemoteCommandRequest(m_fAdmCore);
                    this.showChild(fCustoRemoteCommandRequest);
                }
                fCustoRemoteCommandRequest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fCustoRemoteCommandRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemotePingTestByServer(
            )
        {
            FRemotePingTestByServer fRemotePingTest = null;

            try
            {
                fRemotePingTest = (FRemotePingTestByServer)this.getChild(typeof(FRemotePingTestByServer).Name);
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByServer(m_fAdmCore);
                    this.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemotePingTest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemotePingTestByEquipment(
            )
        {
            FRemotePingTestByEquipment fRemotePingTest = null;

            try
            {
                fRemotePingTest = (FRemotePingTestByEquipment)this.getChild(typeof(FRemotePingTestByEquipment).Name);
                if (fRemotePingTest == null)
                {
                    fRemotePingTest = new FRemotePingTestByEquipment(m_fAdmCore);
                    this.showChild(fRemotePingTest);
                }
                fRemotePingTest.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRemotePingTest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminAgentOption(
           )
        {
            FAdminAgentOption fAdminAgentOption = null;

            try
            {
                fAdminAgentOption = (FAdminAgentOption)this.getChild(typeof(FAdminAgentOption).Name);
                if (fAdminAgentOption == null)
                {
                    fAdminAgentOption = new FAdminAgentOption(m_fAdmCore);
                    this.showChild(fAdminAgentOption);
                }
                fAdminAgentOption.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentOption = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminServiceLogList(
           )
        {
            FAdminServiceLogList fAdminServiceLogList = null;

            try
            {
                fAdminServiceLogList = (FAdminServiceLogList)this.getChild(typeof(FAdminServiceLogList));
                if (fAdminServiceLogList == null)
                {
                    fAdminServiceLogList = new FAdminServiceLogList(m_fAdmCore);
                    this.showChild(fAdminServiceLogList);
                }
                fAdminServiceLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminServiceLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminServiceBackupLogList(
           )
        {
            FAdminServiceBackupLogList fAdminServiceBackupLogList = null;

            try
            {
                fAdminServiceBackupLogList = (FAdminServiceBackupLogList)this.getChild(typeof(FAdminServiceBackupLogList).Name);
                if (fAdminServiceBackupLogList == null)
                {
                    fAdminServiceBackupLogList = new FAdminServiceBackupLogList(m_fAdmCore);
                    this.showChild(fAdminServiceBackupLogList);
                }
                fAdminServiceBackupLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminServiceBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminAgentLogList(
           )
        {
            FAdminAgentLogList fAdminAgentLogList = null;

            try
            {
                fAdminAgentLogList = (FAdminAgentLogList)this.getChild(typeof(FAdminAgentLogList).Name);
                if (fAdminAgentLogList == null)
                {
                    fAdminAgentLogList = new FAdminAgentLogList(m_fAdmCore);
                    this.showChild(fAdminAgentLogList);
                }
                fAdminAgentLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAdminAgentBackupLogList(
           )
        {
            FAdminAgentBackupLogList fAdminAgentBackupLogList = null;

            try
            {
                fAdminAgentBackupLogList = (FAdminAgentBackupLogList)this.getChild(typeof(FAdminAgentBackupLogList).Name);
                if (fAdminAgentBackupLogList == null)
                {
                    fAdminAgentBackupLogList = new FAdminAgentBackupLogList(m_fAdmCore);
                    this.showChild(fAdminAgentBackupLogList);
                }
                fAdminAgentBackupLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapLogList(
           )
        {
            FEapLogList fEapLogList = null;

            try
            {   
                fEapLogList = (FEapLogList)this.getChild(typeof(FEapLogList).Name);
                if (fEapLogList == null)
                {
                    fEapLogList = new FEapLogList(m_fAdmCore);
                    this.showChild(fEapLogList);
                }
                fEapLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapBackupLogList(
           )
        {
            FEapBackupLogList fEapBackupLogList = null;

            try
            {
                fEapBackupLogList = (FEapBackupLogList)this.getChild(typeof(FEapBackupLogList).Name);
                if (fEapBackupLogList == null)
                {
                    fEapBackupLogList = new FEapBackupLogList(m_fAdmCore);
                    this.showChild(fEapBackupLogList);
                }
                fEapBackupLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceLogList(
        //   )
        //{
        //    FEapInterfaceLogList fEapLogList = null;

        //    try
        //    {
        //        fEapLogList = (FEapInterfaceLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceLogList).Name);
        //        if (fEapLogList == null)
        //        {
        //            fEapLogList = new FEapInterfaceLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapLogList);
        //        }
        //        fEapLogList.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapLogList = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceBackupLogList(
        //   )
        //{
        //    FEapInterfaceBackupLogList fEapBackupLogList = null;

        //    try
        //    {
        //        fEapBackupLogList = (FEapInterfaceBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceBackupLogList).Name);
        //        if (fEapBackupLogList == null)
        //        {
        //            fEapBackupLogList = new FEapInterfaceBackupLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapBackupLogList);
        //        }
        //        fEapBackupLogList.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapBackupLogList = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAlertServiceLogList(
           )
        {
            FAlertServiceLogList fAlertServiceLogList = null;

            try
            {
                fAlertServiceLogList = (FAlertServiceLogList)this.getChild(typeof(FAlertServiceLogList).Name);
                if (fAlertServiceLogList == null)
                {
                    fAlertServiceLogList = new FAlertServiceLogList(m_fAdmCore);
                    this.showChild(fAlertServiceLogList);
                }
                fAlertServiceLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAlertServiceLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAlertServiceBackupLogList(
           )
        {
            FAlertServiceBackupLogList fAlertServiceBackupLogList = null;

            try
            {
                fAlertServiceBackupLogList = (FAlertServiceBackupLogList)this.getChild(typeof(FAlertServiceBackupLogList).Name);
                if (fAlertServiceBackupLogList == null)
                {
                    fAlertServiceBackupLogList = new FAlertServiceBackupLogList(m_fAdmCore);
                    this.showChild(fAlertServiceBackupLogList);
                }
                fAlertServiceBackupLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAlertServiceBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRecentNotice(
            )
        {
            FRecentNotice fRecentNotice = null;

            try
            {
                fRecentNotice = (FRecentNotice)this.getChild(typeof(FRecentNotice).Name);
                if (fRecentNotice == null)
                {
                    fRecentNotice = new FRecentNotice(m_fAdmCore);
                    this.showChild(fRecentNotice);
                }
                fRecentNotice.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRecentNotice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuNoticeHistory(
            )
        {
            FNoticeHistory fNoticeHistory = null;

            try
            {
                fNoticeHistory = (FNoticeHistory)this.getChild(typeof(FNoticeHistory).Name);
                if (fNoticeHistory == null)
                {
                    fNoticeHistory = new FNoticeHistory(m_fAdmCore);
                    this.showChild(fNoticeHistory);
                }
                fNoticeHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fNoticeHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSystemCheckList(
            )
        {
            FSystemCheckList fSystemCheckList = null;

            try
            {
                fSystemCheckList = (FSystemCheckList)this.getChild(typeof(FSystemCheckList).Name);
                if (fSystemCheckList == null)
                {
                    fSystemCheckList = new FSystemCheckList(m_fAdmCore);
                    this.showChild(fSystemCheckList);
                }
                fSystemCheckList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSystemCheckList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerList(
            )
        {
            FServerList fServerList = null;

            try
            {
                fServerList = (FServerList)this.getChild(typeof(FServerList).Name);
                if (fServerList == null)
                {
                    fServerList = new FServerList(m_fAdmCore);
                    this.showChild(fServerList);
                }
                fServerList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerStatus(
            )
        {
            FServerStatus fServerStatus = null;

            try
            {
                fServerStatus = (FServerStatus)this.getChild(typeof(FServerStatus).Name);
                if (fServerStatus == null)
                {
                    fServerStatus = new FServerStatus(m_fAdmCore);
                    this.showChild(fServerStatus);
                }
                fServerStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerHistory(
            )
        {
            FServerHistory fServerHistory = null;

            try
            {
                fServerHistory = (FServerHistory)this.getChild(typeof(FServerHistory).Name);
                if (fServerHistory == null)
                {
                    fServerHistory = new FServerHistory(m_fAdmCore);
                    this.showChild(fServerHistory);
                }
                fServerHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceList(
            )
        {
            FServerResourceList fServerResourceList = null;

            try
            {
                fServerResourceList = (FServerResourceList)this.getChild(typeof(FServerResourceList).Name);
                if (fServerResourceList == null)
                {
                    fServerResourceList = new FServerResourceList(m_fAdmCore);
                    this.showChild(fServerResourceList);
                }
                fServerResourceList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceStatus(
            )
        {
            FServerResourceStatus fServerResourceStatus = null;

            try
            {
                fServerResourceStatus = (FServerResourceStatus)this.getChild(typeof(FServerResourceStatus).Name);
                if (fServerResourceStatus == null)
                {
                    fServerResourceStatus = new FServerResourceStatus(m_fAdmCore);
                    this.showChild(fServerResourceStatus);
                }
                fServerResourceStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceComparison(
            )
        {
            FServerResourceComparison fServerResourceComparison = null;

            try
            {
                fServerResourceComparison = (FServerResourceComparison)this.getChild(typeof(FServerResourceComparison).Name);
                if (fServerResourceComparison == null)
                {
                    fServerResourceComparison = new FServerResourceComparison(m_fAdmCore);
                    this.showChild(fServerResourceComparison);
                }
                fServerResourceComparison.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceComparison = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceAnalysis(
            )
        {
            FServerResourceAnalysis fServerResourceAnalysis = null;

            try
            {
                fServerResourceAnalysis = (FServerResourceAnalysis)this.getChild(typeof(FServerResourceAnalysis).Name);
                if (fServerResourceAnalysis == null)
                {
                    fServerResourceAnalysis = new FServerResourceAnalysis(m_fAdmCore);
                    this.showChild(fServerResourceAnalysis);
                }
                fServerResourceAnalysis.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceAnalysis = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerResourceHistory(
            )
        {
            FServerResourceHistory fServerResourceHistory = null;

            try
            {
                fServerResourceHistory = (FServerResourceHistory)this.getChild(typeof(FServerResourceHistory).Name);
                if (fServerResourceHistory == null)
                {
                    fServerResourceHistory = new FServerResourceHistory(m_fAdmCore);
                    this.showChild(fServerResourceHistory);
                }
                fServerResourceHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPackageList(
            )
        {
            FPackageList fPackageList = null;

            try
            {
                fPackageList = (FPackageList)this.getChild(typeof(FPackageList).Name);
                if (fPackageList == null)
                {
                    fPackageList = new FPackageList(m_fAdmCore);
                    this.showChild(fPackageList);
                }
                fPackageList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPackageList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPackageStatus(
            )
        {
            FPackageStatus fPackageStatus = null;

            try
            {
                fPackageStatus = (FPackageStatus)this.getChild(typeof(FPackageStatus).Name);
                if (fPackageStatus == null)
                {
                    fPackageStatus = new FPackageStatus(m_fAdmCore);
                    this.showChild(fPackageStatus);
                }
                fPackageStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPackageStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModelList(
            )
        {
            FModelList fModelList = null;

            try
            {
                fModelList = (FModelList)this.getChild(typeof(FModelList).Name);
                if (fModelList == null)
                {
                    fModelList = new FModelList(m_fAdmCore);
                    this.showChild(fModelList);
                }
                fModelList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModelStatus(
            )
        {
            FModelStatus fModelStatus = null;

            try
            {
                fModelStatus = (FModelStatus)this.getChild(typeof(FModelStatus).Name);
                if (fModelStatus == null)
                {
                    fModelStatus = new FModelStatus(m_fAdmCore);
                    this.showChild(fModelStatus);
                }
                fModelStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuModelVersionSchema(
           )
        {
            FModelVersionSchema fModelVersionSchema = null;

            try
            {
                fModelVersionSchema = (FModelVersionSchema)this.getChild(typeof(FModelVersionSchema).Name);
                if (fModelVersionSchema == null)
                {
                    fModelVersionSchema = new FModelVersionSchema(m_fAdmCore);
                    this.showChild(fModelVersionSchema);
                }
                fModelVersionSchema.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelVersionSchema = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuComponentList(
            )
        {
            FComponentList fComponentList = null;

            try
            {
                fComponentList = (FComponentList)this.getChild(typeof(FComponentList).Name);
                if (fComponentList == null)
                {
                    fComponentList = new FComponentList(m_fAdmCore);
                    this.showChild(fComponentList);
                }
                fComponentList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fComponentList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuComponentStatus(
            )
        {
            FComponentStatus fComponentStatus = null;

            try
            {
                fComponentStatus = (FComponentStatus)this.getChild(typeof(FComponentStatus).Name);
                if (fComponentStatus == null)
                {
                    fComponentStatus = new FComponentStatus(m_fAdmCore);
                    this.showChild(fComponentStatus);
                }
                fComponentStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fComponentStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapList(
            )
        {
            FEapList fEapList = null;

            try
            {
                fEapList = (FEapList)this.getChild(typeof(FEapList).Name);
                if (fEapList == null)
                {
                    fEapList = new FEapList(m_fAdmCore);
                    this.showChild(fEapList);
                }
                fEapList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStatus(
            )
        {
            FEapStatus fEapStatus = null;

            try
            {
                fEapStatus = (FEapStatus)this.getChild(typeof(FEapStatus).Name);
                if (fEapStatus == null)
                {
                    fEapStatus = new FEapStatus(m_fAdmCore);
                    this.showChild(fEapStatus);
                }
                fEapStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRepositoryStatus(
            )
        {
            FEapRepositoryStatus fEapRepositoryStatus = null;

            try
            {
                fEapRepositoryStatus = (FEapRepositoryStatus)this.getChild(typeof(FEapRepositoryStatus).Name);
                if (fEapRepositoryStatus == null)
                {
                    fEapRepositoryStatus = new FEapRepositoryStatus(m_fAdmCore);
                    this.showChild(fEapRepositoryStatus);
                }
                fEapRepositoryStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRepositoryStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentList(
            )
        {
            FEquipmentList fEquipmentList = null;

            try
            {
                fEquipmentList = (FEquipmentList)this.getChild(typeof(FEquipmentList).Name);
                if (fEquipmentList == null)
                {
                    fEquipmentList = new FEquipmentList(m_fAdmCore);
                    this.showChild(fEquipmentList);
                }
                fEquipmentList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentStatus(
            )
        {
            FEquipmentStatus fEquipmentStatus = null;

            try
            {
                fEquipmentStatus = (FEquipmentStatus)this.getChild(typeof(FEquipmentStatus).Name);
                if (fEquipmentStatus == null)
                {
                    fEquipmentStatus = new FEquipmentStatus(m_fAdmCore);
                    this.showChild(fEquipmentStatus);
                }
                fEquipmentStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentHistory(
            )
        {
            FEquipmentHistory fEquipmentHistory = null;

            try
            {
                fEquipmentHistory = (FEquipmentHistory)this.getChild(typeof(FEquipmentHistory).Name);
                if (fEquipmentHistory == null)
                {
                    fEquipmentHistory = new FEquipmentHistory(m_fAdmCore);
                    this.showChild(fEquipmentHistory);
                }
                fEquipmentHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentGemStatus(
            )
        {
            FEquipmentGemStatus fEquipmentGemStatus = null;

            try
            {
                fEquipmentGemStatus = (FEquipmentGemStatus)this.getChild(typeof(FEquipmentGemStatus).Name);
                if (fEquipmentGemStatus == null)
                {
                    fEquipmentGemStatus = new FEquipmentGemStatus(m_fAdmCore);
                    this.showChild(fEquipmentGemStatus);
                }
                fEquipmentGemStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentGemStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuIssueEventSummary(
            )
        {
            FIssueEventSummary fIssueEventSummary = null;

            try
            {
                fIssueEventSummary = (FIssueEventSummary)this.getChild(typeof(FIssueEventSummary).Name);
                if (fIssueEventSummary == null)
                {
                    fIssueEventSummary = new FIssueEventSummary(m_fAdmCore);
                    this.showChild(fIssueEventSummary);
                }
                fIssueEventSummary.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerIssueEventSummary(
            )
        {
            FServerIssueEventSummary fServerIssueEventSummary = null;

            try
            {
                fServerIssueEventSummary = (FServerIssueEventSummary)this.getChild(typeof(FServerIssueEventSummary).Name);
                if (fServerIssueEventSummary == null)
                {
                    fServerIssueEventSummary = new FServerIssueEventSummary(m_fAdmCore);
                    this.showChild(fServerIssueEventSummary);
                }
                fServerIssueEventSummary.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapIssueEventSummary(
            )
        {
            FEapIssueEventSummary fEapIssueEventSummary = null;

            try
            {
                fEapIssueEventSummary = (FEapIssueEventSummary)this.getChild(typeof(FEapIssueEventSummary).Name);
                if (fEapIssueEventSummary == null)
                {
                    fEapIssueEventSummary = new FEapIssueEventSummary(m_fAdmCore);
                    this.showChild(fEapIssueEventSummary);
                }
                fEapIssueEventSummary.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentIssueEventSummary(
            )
        {
            FEquipmentIssueEventSummary fEquipmentIssueEventSummary = null;

            try
            {
                fEquipmentIssueEventSummary = (FEquipmentIssueEventSummary)this.getChild(typeof(FEquipmentIssueEventSummary).Name);
                if (fEquipmentIssueEventSummary == null)
                {
                    fEquipmentIssueEventSummary = new FEquipmentIssueEventSummary(m_fAdmCore);
                    this.showChild(fEquipmentIssueEventSummary);
                }
                fEquipmentIssueEventSummary.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerIssueEventHistory(
            )
        {
            FServerIssueEventHistory fServerIssueEventHistory = null;

            try
            {
                fServerIssueEventHistory = (FServerIssueEventHistory)this.getChild(typeof(FServerIssueEventHistory).Name);
                if (fServerIssueEventHistory == null)
                {
                    fServerIssueEventHistory = new FServerIssueEventHistory(m_fAdmCore);
                    this.showChild(fServerIssueEventHistory);
                }
                fServerIssueEventHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerIssueEventHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapIssueEventHistory(
            )
        {
            FEapIssueEventHistory fEapIssueEventHistory = null;

            try
            {
                fEapIssueEventHistory = (FEapIssueEventHistory)this.getChild(typeof(FEapIssueEventHistory).Name);
                if (fEapIssueEventHistory == null)
                {
                    fEapIssueEventHistory = new FEapIssueEventHistory(m_fAdmCore);
                    this.showChild(fEapIssueEventHistory);
                }
                fEapIssueEventHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapIssueEventHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentIssueEventHistory(
            )
        {
            FEquipmentIssueEventHistory fEquipmentIssueEventHistory = null;

            try
            {
                fEquipmentIssueEventHistory = (FEquipmentIssueEventHistory)this.getChild(typeof(FEquipmentIssueEventHistory).Name);
                if (fEquipmentIssueEventHistory == null)
                {
                    fEquipmentIssueEventHistory = new FEquipmentIssueEventHistory(m_fAdmCore);
                    this.showChild(fEquipmentIssueEventHistory);
                }
                fEquipmentIssueEventHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentIssueEventHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerIssueEventTotal(
            )
        {
            FServerIssueEventTotal fServerIssueEventTotal = null;

            try
            {
                fServerIssueEventTotal = (FServerIssueEventTotal)this.getChild(typeof(FServerIssueEventTotal).Name);
                if (fServerIssueEventTotal == null)
                {
                    fServerIssueEventTotal = new FServerIssueEventTotal(m_fAdmCore);
                    this.showChild(fServerIssueEventTotal);
                }
                fServerIssueEventTotal.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerIssueEventTotal = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapIssueEventTotal(
            )
        {
            FEapIssueEventTotal fEapIssueEventTotal = null;

            try
            {
                fEapIssueEventTotal = (FEapIssueEventTotal)this.getChild(typeof(FEapIssueEventTotal).Name);
                if (fEapIssueEventTotal == null)
                {
                    fEapIssueEventTotal = new FEapIssueEventTotal(m_fAdmCore);
                    this.showChild(fEapIssueEventTotal);
                }
                fEapIssueEventTotal.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapIssueEventTotal = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentIssueEventTotal(
            )
        {
            FEquipmentIssueEventTotal fEquipmentIssueEventTotal = null;

            try
            {
                fEquipmentIssueEventTotal = (FEquipmentIssueEventTotal)this.getChild(typeof(FEquipmentIssueEventTotal).Name);
                if (fEquipmentIssueEventTotal == null)
                {
                    fEquipmentIssueEventTotal = new FEquipmentIssueEventTotal(m_fAdmCore);
                    this.showChild(fEquipmentIssueEventTotal);
                }
                fEquipmentIssueEventTotal.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentIssueEventTotal = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOverallIssueEventReport(
            )
        {
            FOverallIssueEventReport fOverallIssueEventReport = null;

            try
            {
                fOverallIssueEventReport = (FOverallIssueEventReport)this.getChild(typeof(FOverallIssueEventReport).Name);
                if (fOverallIssueEventReport == null)
                {
                    fOverallIssueEventReport = new FOverallIssueEventReport(m_fAdmCore);
                    this.showChild(fOverallIssueEventReport);
                }
                fOverallIssueEventReport.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOverallIssueEventReport = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fAdmCore);
                fAbout.ShowDialog(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAbout = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuWinCloseAllWindows(
            )
        {

            try
            {
                for (int i = this.fChilds.Length - 1; i >= 0; i--)
                {
                    this.fChilds[i].Close();
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

        private void procMenuWinWindow(
            string key
            )
        {
            FBaseTabChildForm fChildForm = null;

            try
            {
                fChildForm = (FBaseTabChildForm)m_fAdmCore.fOption.fChildFormList.getFormOfKey(key);
                fChildForm.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fChildForm = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuWinMoreWindows(
            )
        {
            FFormSelector dialog = null;

            try
            {
                dialog = new FFormSelector(m_fAdmCore);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringServerData(
            FMonitoringServerDataReceivedEventArgs args
            )
        {
            UltraDesktopAlertShowWindowInfo dai = new UltraDesktopAlertShowWindowInfo();
            string lastEventId = string.Empty;
            string server = string.Empty;
            string svrDesc = string.Empty;
            // --
            const string Line = "<hr NoShade='true' size='1px' width='100%'/>";
            const string PreStr = "&nbsp; &#150;";
            
            try
            {
                server = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Name, FADMADS_TolServerDataPush_In.FServer.D_Name);
                svrDesc = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Description, FADMADS_TolServerDataPush_In.FServer.D_Description);
                lastEventId = args.fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_LastEventId, FADMADS_TolServerDataPush_In.FServer.D_LastEventId);

                // --

                if (lastEventId != "DOWN" && lastEventId != "ADMIN_AGENT_DOWN" && lastEventId != "OPC_SERVER_DOWN")
                {
                    return;
                }

                // --

                server = FCommon.convertDesktopAlertString(server);
                svrDesc = FCommon.convertDesktopAlertString(svrDesc);

                // --

                dai = new UltraDesktopAlertShowWindowInfo();
                dai.FooterText = m_fAdmCore.fUIWizard.generateMessage("M0017");
                dai.Data = args.fXmlNode;
                // --
                if (lastEventId == "DOWN")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("Server Down!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "Server : " + server + " [" + svrDesc + "]";
                }
                else if (lastEventId == "ADMIN_AGENT_DOWN")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("Server Agent Down!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "Server :" + server + " [" + svrDesc + "]";
                }
                else
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("OPC Server Down!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "Server :" + server + " [" + svrDesc + "]";
                }
                // --                
                if (m_fAdmCore.fOption.desktopAlertSoundEnabled)
                {
                    dai.Sound = m_fAdmCore.fWsmCore.appPath + "\\DefaultAlert.wav";
                }      
                // --
                dsaAlert.Show(dai);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dai = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringEapData(
            FMonitoringEapDataReceivedEventArgs args
            )
        {
            UltraDesktopAlertShowWindowInfo dai = new UltraDesktopAlertShowWindowInfo();
            string lastEventId = string.Empty;
            string eap = string.Empty;
            string eapDesc = string.Empty;
            // --
            const string Line = "<hr NoShade='true' size='1px' width='100%'/>";
            const string PreStr = "&nbsp; &#150;";

            try
            {
                eap = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name);
                eapDesc = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Description, FADMADS_TolEapDataPush_In.FEap.D_Description);
                lastEventId = args.fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_LastEventId, FADMADS_TolEapDataPush_In.FEap.D_LastEventId);

                // --

                // ***
                // 2017.05.12 by spike.lee
                // MC DOWN_DETECT 시에도 Desktop Alert를 발생하도록 수정
                // ***
                if (lastEventId != "DOWN" && lastEventId != "DOWN_DETECT" && lastEventId != "ABORT")
                {
                    return;
                }

                // --

                eap = FCommon.convertDesktopAlertString(eap);
                eapDesc = FCommon.convertDesktopAlertString(eapDesc);

                // --

                dai = new UltraDesktopAlertShowWindowInfo();
                dai.FooterText = m_fAdmCore.fUIWizard.generateMessage("M0017");
                dai.Data = args.fXmlNode;
                // --
                if (lastEventId == "DOWN" || lastEventId == "DOWN_DETECT")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("EAP Down!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "EAP : " + eap + " [" + eapDesc + "]";
                }
                else if (lastEventId == "ABORT")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("EAP Abort!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "EAP : " + eap + " [" + eapDesc + "]";
                }
                // --
                if (m_fAdmCore.fOption.desktopAlertSoundEnabled)
                {
                    dai.Sound = m_fAdmCore.fWsmCore.appPath + "\\DefaultAlert.wav";
                }                                
                // --
                dsaAlert.Show(dai);                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dai = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringDeviceData(
            FMonitoringDeviceDataReceivedEventArgs args
            )
        {
            UltraDesktopAlertShowWindowInfo dai = new UltraDesktopAlertShowWindowInfo();
            string eap = string.Empty;
            string eapDesc = string.Empty;
            string device = string.Empty;
            string deviceType = string.Empty;
            // --
            const string Line = "<hr NoShade='true' size='1px' width='100%'/>";
            const string PreStr = "&nbsp; &#150;";
            const string NewLine = "<br/>";

            try
            {
                eap = args.fXmlNode.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_Eap, FADMADS_TolDeviceDataPush_In.FDevice.D_Eap);
                eapDesc = args.fXmlNode.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_Description, FADMADS_TolDeviceDataPush_In.FDevice.D_Description);
                device = args.fXmlNode.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_Device, FADMADS_TolDeviceDataPush_In.FDevice.D_Device);
                deviceType = args.fXmlNode.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_DeviceType, FADMADS_TolDeviceDataPush_In.FDevice.D_DeviceType);
                
                // --

                eap = FCommon.convertDesktopAlertString(eap);
                eapDesc = FCommon.convertDesktopAlertString(eapDesc);
                device = FCommon.convertDesktopAlertString(device);

                // --

                dai = new UltraDesktopAlertShowWindowInfo();
                dai.FooterText = m_fAdmCore.fUIWizard.generateMessage("M0017");
                dai.Data = args.fXmlNode;
                // --
                if (deviceType == "Equipment")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("Equipment Device Disconnect!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "EAP : " + eap + " [" + eapDesc + "]" + NewLine;
                    dai.Text += PreStr + "Device : " + device;
                }
                else
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("Host Device Disconnect!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "EAP : " + eap + " [" + eapDesc + "]" + NewLine;
                    dai.Text += PreStr + "Device : " + device;
                }
                // --
                if (m_fAdmCore.fOption.desktopAlertSoundEnabled)
                {
                    dai.Sound = m_fAdmCore.fWsmCore.appPath + "\\DefaultAlert.wav";
                }
                // --
                dsaAlert.Show(dai);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dai = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringSecs1ToHsmsConverterData(
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs args
            )
        {
            UltraDesktopAlertShowWindowInfo dai = new UltraDesktopAlertShowWindowInfo();
            string lastEventId = string.Empty;
            string converter = string.Empty;
            string cvtDesc = string.Empty;
            // --
            const string Line = "<hr NoShade='true' size='1px' width='100%'/>";
            const string PreStr = "&nbsp; &#150;";

            try
            {
                converter = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Converter, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Converter);
                cvtDesc = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Description, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_Description);
                lastEventId = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_LastEventId, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.D_LastEventId);

                // --

                if (lastEventId != "DOWN" && lastEventId != "DOWN_DETECT")
                {
                     return;
                }

                // --

                converter = FCommon.convertDesktopAlertString(converter);
                cvtDesc = FCommon.convertDesktopAlertString(cvtDesc);

                // --

                dai = new UltraDesktopAlertShowWindowInfo();
                dai.FooterText = m_fAdmCore.fUIWizard.generateMessage("M0017");
                dai.Data = args.fXmlNode;
                // --
                if (lastEventId == "DOWN" || lastEventId == "DOWN_DETECT")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("SECS1 To HSMS Converter Down!");
                    // --
                    dai.Text = Line;
                    dai.Text += PreStr + "SECS1 To HSMS Converter : " + converter + " [" + cvtDesc + "]";
                }               
                // --
                if (m_fAdmCore.fOption.desktopAlertSoundEnabled)
                {
                    dai.Sound = m_fAdmCore.fWsmCore.appPath + "\\DefaultAlert.wav";
                }
                // --
                dsaAlert.Show(dai);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dai = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMonitoringSecs1ToHsmsConverterDisconnectData(
            FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs args
            )
        {
            UltraDesktopAlertShowWindowInfo dai = new UltraDesktopAlertShowWindowInfo();
            string converter = string.Empty;
            string cvtDesc = string.Empty;
            string device = string.Empty;
            // --
            const string Line = "<hr NoShade='true' size='1px' width='100%'/>";
            const string PreStr = "&nbsp; &#150;";
            const string NewLine = "<br/>";

            try
            {
                converter = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Converter, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.D_Converter);
                cvtDesc = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Description, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.D_Description);
                device = args.fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Device, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.D_Device);
                                
                // --

                converter = FCommon.convertDesktopAlertString(converter);
                cvtDesc = FCommon.convertDesktopAlertString(cvtDesc);
                device = FCommon.convertDesktopAlertString(device);

                // --

                dai = new UltraDesktopAlertShowWindowInfo();
                dai.FooterText = m_fAdmCore.fUIWizard.generateMessage("M0017");
                dai.Data = args.fXmlNode;
                
                // --

                if (device == "SECS1")
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("SECS1 To HSMS Converter SECS1 Disconnect!");
                }
                else
                {
                    dai.Caption = "[Nexplant MC Admin] " + m_fAdmCore.fUIWizard.searchCaption("SECS1 To HSMS Converter HSMS Disconnect!");
                }
                
                // --
                dai.Text = Line;
                dai.Text += PreStr + "SECS1 To HSMS Converter : " + converter + " [" + cvtDesc + "]" + NewLine;
                dai.Text += PreStr + "Device : " + device;

                // --

                if (m_fAdmCore.fOption.desktopAlertSoundEnabled)
                {
                    dai.Sound = m_fAdmCore.fWsmCore.appPath + "\\DefaultAlert.wav";
                }
                // --
                dsaAlert.Show(dai);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dai = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsEvent(
            )
        {
            FSecs1ToHsmsEvent fSecs1ToHsmsEvent = null;

            try
            {
                fSecs1ToHsmsEvent = (FSecs1ToHsmsEvent)this.getChild(typeof(FSecs1ToHsmsEvent).Name);
                if (fSecs1ToHsmsEvent == null)
                {
                    fSecs1ToHsmsEvent = new FSecs1ToHsmsEvent(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsEvent);
                }
                fSecs1ToHsmsEvent.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsEvent = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverter(
            )
        {
            FSecs1ToHsmsConverter fSecs1ToHsmsConverter = null;

            try
            {
                fSecs1ToHsmsConverter = (FSecs1ToHsmsConverter)this.getChild(typeof(FSecs1ToHsmsConverter).Name);
                if (fSecs1ToHsmsConverter == null)
                {
                    fSecs1ToHsmsConverter = new FSecs1ToHsmsConverter(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverter);
                }
                fSecs1ToHsmsConverter.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverter = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterList(
            )
        {
            FSecs1ToHsmsConverterList fSecs1ToHsmsConverterList = null;

            try
            {
                fSecs1ToHsmsConverterList = (FSecs1ToHsmsConverterList)this.getChild(typeof(FSecs1ToHsmsConverterList).Name);
                if (fSecs1ToHsmsConverterList == null)
                {
                    fSecs1ToHsmsConverterList = new FSecs1ToHsmsConverterList(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterList);
                }
                fSecs1ToHsmsConverterList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterStatus(
            )
        {
            FSecs1ToHsmsConverterStatus fSecs1ToHsmsConverterStatus = null;

            try
            {
                fSecs1ToHsmsConverterStatus = (FSecs1ToHsmsConverterStatus)this.getChild(typeof(FSecs1ToHsmsConverterStatus).Name);
                if (fSecs1ToHsmsConverterStatus == null)
                {
                    fSecs1ToHsmsConverterStatus = new FSecs1ToHsmsConverterStatus(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterStatus);
                }
                fSecs1ToHsmsConverterStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterHistory(
            )
        {
            FSecs1ToHsmsConverterHistory fSecs1ToHsmsConverterHistory = null;

            try
            {
                fSecs1ToHsmsConverterHistory = (FSecs1ToHsmsConverterHistory)this.getChild(typeof(FSecs1ToHsmsConverterHistory).Name);
                if (fSecs1ToHsmsConverterHistory == null)
                {
                    fSecs1ToHsmsConverterHistory = new FSecs1ToHsmsConverterHistory(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterHistory);
                }
                fSecs1ToHsmsConverterHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterMonitor(
            )
        {
            FSecs1ToHsmsConverterMonitor fSecs1ToHsmsConverterMonitor = null;

            try
            {
                fSecs1ToHsmsConverterMonitor = (FSecs1ToHsmsConverterMonitor)this.getChild(typeof(FSecs1ToHsmsConverterMonitor).Name);
                if (fSecs1ToHsmsConverterMonitor == null)
                {
                    fSecs1ToHsmsConverterMonitor = new FSecs1ToHsmsConverterMonitor(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterMonitor);
                }
                fSecs1ToHsmsConverterMonitor.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterMonitor = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterLogList(
            )
        {
            FSecs1ToHsmsConverterLogList fSecs1ToHsmsConverterLogList = null;

            try
            {
                fSecs1ToHsmsConverterLogList = (FSecs1ToHsmsConverterLogList)this.getChild(typeof(FSecs1ToHsmsConverterLogList).Name);
                if (fSecs1ToHsmsConverterLogList == null)
                {
                    fSecs1ToHsmsConverterLogList = new FSecs1ToHsmsConverterLogList(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterLogList);
                }
                fSecs1ToHsmsConverterLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterBackupLogList(
            )
        {
            FSecs1ToHsmsConverterBackupLogList fSecs1ToHsmsConverterBackupLogList = null;

            try
            {
                fSecs1ToHsmsConverterBackupLogList = (FSecs1ToHsmsConverterBackupLogList)this.getChild(typeof(FSecs1ToHsmsConverterBackupLogList).Name);
                if (fSecs1ToHsmsConverterBackupLogList == null)
                {
                    fSecs1ToHsmsConverterBackupLogList = new FSecs1ToHsmsConverterBackupLogList(m_fAdmCore);
                    this.showChild(fSecs1ToHsmsConverterBackupLogList);
                }
                fSecs1ToHsmsConverterBackupLogList.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void closeAllDesktopAlert(
            )
        {
            try
            {
                dsaAlert.CloseAll();
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

        private bool validateUserGroupAuthority(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInUsr = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutUsr = null;
            FXmlNode fXmlNodeOutNtc = null;
            string hostName = string.Empty;
            string ipAddress = string.Empty;

            try
            {
                hostName = FUserPCInfo.ComputerName;
                ipAddress = FUserPCInfo.getIPAddress();

                // --

                m_fAdmCore.initH101();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SysUserLogIn_In.E_ADMADS_SysUserLogIn_In);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hLanguage, FADMADS_SysUserLogIn_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hFactory, FADMADS_SysUserLogIn_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hUserId, FADMADS_SysUserLogIn_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hHostName, FADMADS_SysUserLogIn_In.D_hHostName, hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hHostIp, FADMADS_SysUserLogIn_In.D_hHostIp, ipAddress);
                fXmlNodeIn.set_elemVal(FADMADS_SysUserLogIn_In.A_hStep, FADMADS_SysUserLogIn_In.D_hStep, "1");
                // --
                fXmlNodeInUsr = fXmlNodeIn.set_elem(FADMADS_SysUserLogIn_In.FLogIn.E_LogIn);
                fXmlNodeInUsr.set_elemVal(FADMADS_SysUserLogIn_In.FLogIn.A_UserId, FADMADS_SysUserLogIn_In.FLogIn.D_UserId, m_fAdmCore.fOption.user);
                fXmlNodeInUsr.set_elemVal(FADMADS_SysUserLogIn_In.FLogIn.A_UserGroup, FADMADS_SysUserLogIn_In.FLogIn.D_UserGroup, m_fAdmCore.fOption.userGroup);

                // --

                FADMADSCaster.ADMADS_SysLogIn_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SysUserLogIn_Out.A_hStatus, FADMADS_SysUserLogIn_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SysUserLogIn_Out.A_hStatusMessage, FADMADS_SysUserLogIn_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutUsr = fXmlNodeOut.get_elem(FADMADS_SysUserLogIn_Out.FUser.E_User);
                m_fAdmCore.fOption.authority.allAuthority = (FYesNo)Enum.Parse(typeof(FYesNo), fXmlNodeOutUsr.get_elemVal(FADMADS_SysUserLogIn_Out.FUser.A_AllAuthority, FADMADS_SysUserLogIn_Out.FUser.D_AllAuthority));
                // --
                m_fAdmCore.fOption.authority.clear();
                foreach (FXmlNode n in fXmlNodeOutUsr.get_elemList(FADMADS_SysUserLogIn_Out.FUser.FAuthority.E_Authority))
                {
                    m_fAdmCore.fOption.authority.add(
                        new FUserFunctionData(
                            n.get_elemVal(FADMADS_SysUserLogIn_Out.FUser.FAuthority.A_Function, FADMADS_SysUserLogIn_Out.FUser.FAuthority.D_Function),
                            Convert.ToBoolean(n.get_elemVal(FADMADS_SysUserLogIn_Out.FUser.FAuthority.A_EnabledTransaction, FADMADS_SysUserLogIn_Out.FUser.FAuthority.D_EnabledTransaction))
                            ));
                }

                // --

                fXmlNodeOutNtc = fXmlNodeOut.get_elem(FADMADS_SysUserLogIn_Out.FNotice.E_Notice);
                // --
                m_newNotice = fXmlNodeOutNtc.get_elemVal(FADMADS_SysUserLogIn_Out.FNotice.A_NewNotice, FADMADS_SysUserLogIn_Out.FNotice.D_NewNotice);
                m_noticeUpdateTime = fXmlNodeOutNtc.get_elemVal(FADMADS_SysUserLogIn_Out.FNotice.A_UpdateTime, FADMADS_SysUserLogIn_Out.FNotice.A_UpdateTime);
                m_noticeContents = fXmlNodeOutNtc.get_elemVal(FADMADS_SysUserLogIn_Out.FNotice.A_Contents, FADMADS_SysUserLogIn_Out.FNotice.A_Contents);

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInUsr = null;
                fXmlNodeOut = null;
                fXmlNodeOutUsr = null;
                fXmlNodeOutNtc = null;
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FAdmContainer Form Event Handler

        private void FAdmContainer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                this.BeginInvoke(new MethodInvoker(
                    delegate()
                    {
                        logInUser();
                    }
                ));

                // --

                // ***
                // Monitoring Data Push Event Set
                // *** 
                m_fAdmCore.MonitoringServerDataReceived += new FMonitoringServerDataReceivedEventHandler(m_fAdmCore_MonitoringServerDataReceived);
                m_fAdmCore.MonitoringEapDataReceived += new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                m_fAdmCore.MonitoringDeviceDataReceived += new FMonitoringDeviceDataReceivedEventHandler(m_fAdmCore_MonitoringDeviceDataReceived);
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDataReceived += new FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived);
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDisconnectDataReceived += new FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDisconnectDataReceived);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAdmContainer_Activated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fAdmCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FAdmContainer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                // ***
                // Monitoring Data Push Event Reset
                // *** 
                m_fAdmCore.MonitoringServerDataReceived -= new FMonitoringServerDataReceivedEventHandler(m_fAdmCore_MonitoringServerDataReceived);
                m_fAdmCore.MonitoringEapDataReceived -= new FMonitoringEapDataReceivedEventHandler(m_fAdmCore_MonitoringEapDataReceived);
                m_fAdmCore.MonitoringDeviceDataReceived -= new FMonitoringDeviceDataReceivedEventHandler(m_fAdmCore_MonitoringDeviceDataReceived);
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDataReceived -= new FMonitoringSecs1ToHsmsConverterDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived);
                m_fAdmCore.MonitoringSecs1ToHsmsConverterDisconnectDataReceived -= new FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventHandler(m_fAdmCore_MonitoringSecs1ToHsmsConverterDisconnectDataReceived);

                // --

                closeAllDesktopAlert();

                // --

                m_fAdmCore.fWsmCore.onMainStatusBarChanged(true);
                // --
                if (m_fAdmCore != null)
                {
                    m_fAdmCore.Dispose();
                    m_fAdmCore = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_BeforeToolDropdown(
            object sender,
            Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e
            )
        {
            const string MenuWinWindow = "WinWindow";

            // --

            ToolBase mnuTool = null;

            try
            {
                if (e.Tool.Key != FMenuKey.MenuWindow)
                {
                    return;
                }

                // --

                mnuMenu.beginUpdate();

                // --

                for (int i = 0; i < 10; i++)
                {
                    mnuMenu.Tools[MenuWinWindow + i.ToString()].SharedProps.Visible = false;
                }
                mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = false;

                // --

                // ***
                // Child Window List
                // ***
                for (int i = 0; i < 10; i++)
                {
                    if (i >= m_fAdmCore.fOption.fChildFormList.count)
                    {
                        break;
                    }

                    // --

                    mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                    mnuTool.SharedProps.Tag = m_fAdmCore.fOption.fChildFormList.getKeyOfIndex(i);
                    mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard.searchCaption(m_fAdmCore.fOption.fChildFormList.getTextOfIndex(i));
                    mnuTool.SharedProps.Visible = true;
                }                

                // --

                if (m_fAdmCore.fOption.fChildFormList.count > 10)
                {
                    mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                mnuTool = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolClick(
            object sender,
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // System Menu
                // ***
                if (e.Tool.Key == FMenuKey.MenuClose)
                {
                    procMenuClose();
                }

                // --

                // ***
                // Setup Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuFactory)
                {
                    procMenuFactory();
                }
                else if (e.Tool.Key == FMenuKey.MenuNotice)
                {
                    procMenuNotice();
                }
                else if (e.Tool.Key == FMenuKey.MenuGeneralCode)
                {
                    procMenuGeneralCode();
                }
                else if (e.Tool.Key == FMenuKey.MenuEvent)
                {
                    procMenuEvent();
                }
                else if (e.Tool.Key == FMenuKey.MenuUserGroupApplication)
                {
                    procMenuUserGroupApplication();
                }
                else if (e.Tool.Key == FMenuKey.MenuUserGroup)
                {
                    procMenuUserGroup();
                }
                else if (e.Tool.Key == FMenuKey.MenuUser)
                {
                    procMenuUser();
                }
                else if (e.Tool.Key == FMenuKey.MenuServer)
                {
                    procMenuServer();
                }
                else if (e.Tool.Key == FMenuKey.MenuMaker)
                {
                    procMenuMaker();
                }
                else if (e.Tool.Key == FMenuKey.MenuHostDriver)
                {
                    procMenuHostDriver();
                }
                else if (e.Tool.Key == FMenuKey.MenuPackage)
                {
                    procMenuPackage();
                }
                else if (e.Tool.Key == FMenuKey.MenuComponent)
                {
                    procMenuComponent();
                }
                else if (e.Tool.Key == FMenuKey.MenuModel)
                {
                    procMenuModel();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsModelObjectName)
                {
                    procMenuSecsModelObjectName();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsModelFunctionName)
                {
                    procMenuSecsModelFunctionName();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsModelUserTagName)
                {
                    procMenuSecsModelUserTagName();
                }
                //else if (e.Tool.Key == FMenuKey.MenuPlcModelObjectName)
                //{
                //    procMenuPlcModelObjectName();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuPlcModelFunctionName)
                //{
                //    procMenuPlcModelFunctionName();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuPlcModelUserTagName)
                //{
                //    procMenuPlcModelUserTagName();
                //}
                else if (e.Tool.Key == FMenuKey.MenuOpcModelObjectName)
                {
                    procMenuOpcModelObjectName();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpcModelFunctionName)
                {
                    procMenuOpcModelFunctionName();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpcModelUserTagName)
                {
                    procMenuOpcModelUserTagName();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpModelObjectName)
                {
                    procMenuTcpModelObjectName();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpModelFunctionName)
                {
                    procMenuTcpModelFunctionName();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpModelUserTagName)
                {
                    procMenuTcpModelUserTagName();
                }
                else if (e.Tool.Key == FMenuKey.MenuModelSheet)
                {
                    procMenuModelSheet();
                }
                else if (e.Tool.Key == FMenuKey.MenuCustomRemoteCommand)
                {
                    procMenuCustomRemoteCommand();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentType)
                {
                    procMenuEquipmentType();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentArea)
                {
                    procMenuEquipmentArea();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentLine)
                {
                    procMenuEquipmentLine();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipment)
                {
                    procMenuEquipment();
                }
                else if (e.Tool.Key == FMenuKey.MenuInlineEquipment)
                {
                    procMenuInlineEquipment();
                }
                else if (e.Tool.Key == FMenuKey.MenuEap)
                {
                    procMenuEap();
                }

                // --

                // ***
                // Transaction Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuEapBatchModification)
                {
                    procMenuEapBatchModification();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapRelease)
                {
                    procMenuEapRelease();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapStart)
                {
                    procMenuEapStart();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapStop)
                {
                    procMenuEapStop();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapReload)
                {
                    procMenuEapReload();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapRestart)
                {
                    procMenuEapRestart();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapAbort)
                {
                    procMenuEapAbort();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapMove)
                {
                    procMenuEapMove();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapLogLevelSetup)
                {
                    procMenuEapLogLevelSetup();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerMainSwitch)
                {
                    procMenuServerMainSwitch();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerBackupSwitch)
                {
                    procMenuServerBackupSwitch();
                }

                // --

                // ***
                // Monitoring Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuEapMonitor)
                {
                    procMenuEapMonitor();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentMonitor)
                {
                    procMenuEquipmentMonitor();
                }
                else if (e.Tool.Key == FMenuKey.MenuIssueEventMonitor)
                {
                    procMenuIssueEventMonitor();
                }

                // --

                // ***
                // Remote Command Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuEquipmentEventDefineRequest)
                {
                    procMenuEquipmentEventDefineRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentVersionRequest)
                {
                    procMenuEquipmentVersionRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentControlModeRequest)
                {
                    procMenuEquipmentControlModeRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuCustomRemoteCommandRequest)
                {
                    procMenuCustomRemoteCommandRequest();
                }
                else if (e.Tool.Key == FMenuKey.MenuRemotePingTestByServer)
                {
                    procMenuRemotePingTestByServer();
                }
                else if (e.Tool.Key == FMenuKey.MenuRemotePingTestByEquipment)
                {
                    procMenuRemotePingTestByEquipment();
                }

                // --

                // ***
                // Tool Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuAdminAgentOption)
                {
                    procMenuAdminAgentOption();
                }

                // --

                // ***
                // View Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuAdminServiceLogList)
                {
                    procMenuAdminServiceLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuAdminServiceBackupLogList)
                {
                    procMenuAdminServiceBackupLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuAdminAgentLogList)
                {
                    procMenuAdminAgentLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuAdminAgentBackupLogList)
                {
                    procMenuAdminAgentBackupLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapLogList)
                {
                    procMenuEapLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapBackupLogList)
                {
                    procMenuEapBackupLogList();
                }
                //else if (e.Tool.Key == FMenuKey.MenuEapInterfaceLogList)
                //{
                //    procMenuEapInterfaceLogList();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuEapInterfaceBackupLogList)
                //{
                //    procMenuEapInterfaceBackupLogList();
                //}
                else if (e.Tool.Key == FMenuKey.MenuAlertServiceLogList)
                {
                    procMenuAlertServiceLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuAlertServiceBackupLogList)
                {
                    procMenuAlertServiceBackupLogList();
                }

                // --

                // ***
                // Inquiry Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuRecentNotice)
                {
                    procMenuRecentNotice();
                }
                else if (e.Tool.Key == FMenuKey.MenuNoticeHistory)
                {
                    procMenuNoticeHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSystemCheckList)
                {
                    procMenuSystemCheckList();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerList)
                {
                    procMenuServerList();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerStatus)
                {
                    procMenuServerStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerHistory)
                {
                    procMenuServerHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerResourceList)
                {
                    procMenuServerResourceList();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerResourceStatus)
                {
                    procMenuServerResourceStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerResourceComparison)
                {
                    procMenuServerResourceComparison();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerResourceAnalysis)
                {
                    procMenuServerResourceAnalysis();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerResourceHistory)
                {
                    procMenuServerResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuPackageList)
                {
                    procMenuPackageList();
                }
                else if (e.Tool.Key == FMenuKey.MenuPackageStatus)
                {
                    procMenuPackageStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuModelList)
                {
                    procMenuModelList();
                }
                else if (e.Tool.Key == FMenuKey.MenuModelStatus)
                {
                    procMenuModelStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuModelVersionSchema)
                {
                    procMenuModelVersionSchema();
                }
                else if (e.Tool.Key == FMenuKey.MenuComponentList)
                {
                    procMenuComponentList();
                }
                else if (e.Tool.Key == FMenuKey.MenuComponentStatus)
                {
                    procMenuComponentStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapList)
                {
                    procMenuEapList();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapStatus)
                {
                    procMenuEapStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapHistory)
                {
                    procMenuEapHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapRepositoryStatus)
                {
                    // ***
                    // 2017.06.05 by spike.lee
                    // MC Repository Status 추가
                    // *** 
                    procMenuEapRepositoryStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapNeedActionList)
                {
                    procMenuEapNeedActionList();
                }
                else if (e.Tool.Key == FMenuKey.MenuUserHistory)
                {
                    procMenuUserHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapResourceList)
                {
                    procMenuEapResourceList();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapResourceComparison)
                {
                    procMenuEapResourceSummary();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapResourceHistory)
                {
                    procMenuEapResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentList)
                {
                    procMenuEquipmentList();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentStatus)
                {
                    procMenuEquipmentStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentHistory)
                {
                    procMenuEquipmentHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentGemStatus)
                {
                    procMenuEquipmentGemStatus();
                }
                // ***
                // 2017.07.18 by spike.lee
                // Issue Event Report 관련 메뉴
                // ***
                else if (e.Tool.Key == FMenuKey.MenuIssueEventSummary)
                {
                    procMenuIssueEventSummary();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerIssueEventSummary)
                {
                    procMenuServerIssueEventSummary();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapIssueEventSummary)
                {
                    procMenuEapIssueEventSummary();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentIssueEventSummary)
                {
                    procMenuEquipmentIssueEventSummary();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerIssueEventHistory)
                {
                    procMenuServerIssueEventHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapIssueEventHistory)
                {
                    procMenuEapIssueEventHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentIssueEventHistory)
                {
                    procMenuEquipmentIssueEventHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuServerIssueEventTotal)
                {
                    procMenuServerIssueEventTotal();
                }
                else if (e.Tool.Key == FMenuKey.MenuEapIssueEventTotal)
                {
                    procMenuEapIssueEventTotal();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentIssueEventTotal)
                {
                    procMenuEquipmentIssueEventTotal();
                }
                else if (e.Tool.Key == FMenuKey.MenuOverallIssueEventReport)
                {
                    procMenuOverallIssueEventReport();
                }

                // --

                // ***
                // Window Menu
                // ***
                else if (e.Tool.Key == FMenuKey.MenuWinCloseAllWindows)
                {
                    procMenuWinCloseAllWindows();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuWinWindow0 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow1 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow2 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow3 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow4 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow5 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow6 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow7 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow8 ||
                    e.Tool.Key == FMenuKey.MenuWinWindow9
                    )
                {
                    procMenuWinWindow((string)e.Tool.SharedProps.Tag);
                }
                else if (e.Tool.Key == FMenuKey.MenuWinMoreWindows)
                {
                    procMenuWinMoreWindows();
                }

                // --

                // ***
                // Help
                // ***
                else if (e.Tool.Key == FMenuKey.MenuAbout)
                {
                    procMenuAbout();
                }

                // --

                // ***
                // 2017.04.21 by spike.lee
                // SECS1 To HSMS
                // ***
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsEvent)
                {
                    procMenuSecs1ToHsmsEvent();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverter)
                {
                    procMenuSecs1ToHsmsConverter();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterList)
                {
                    procMenuSecs1ToHsmsConverterList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterStatus)
                {
                    procMenuSecs1ToHsmsConverterStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterHistory)
                {
                    procMenuSecs1ToHsmsConverterHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterMonitor)
                {
                    procMenuSecs1ToHsmsConverterMonitor();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterLogList)
                {
                    procMenuSecs1ToHsmsConverterLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterBackupLogList)
                {
                    procMenuSecs1ToHsmsConverterBackupLogList();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion   

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fAdmCore Monitoring Push Event Handler

        private void m_fAdmCore_MonitoringServerDataReceived(
            object sender,
            FMonitoringServerDataReceivedEventArgs e
            )
        {
            try
            {
                if (!m_fAdmCore.fOption.desktopAlertEnabled || !m_fAdmCore.fOption.desktopAlertServerEnabled)
                {
                    return;
                }

                // --

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringServerData(e);
                    }));
                }
                else
                {
                    procMonitoringServerData(e);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void m_fAdmCore_MonitoringEapDataReceived(
            object sender, 
            FMonitoringEapDataReceivedEventArgs e
            )
        {
            try
            {
                if (!m_fAdmCore.fOption.desktopAlertEnabled || !m_fAdmCore.fOption.desktopAlertEapEnabled)
                {
                    return;
                }

                // --

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringEapData(e);
                    }));
                }
                else
                {
                    procMonitoringEapData(e);
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

        private void m_fAdmCore_MonitoringDeviceDataReceived(
            object sender, 
            FMonitoringDeviceDataReceivedEventArgs e
            )
        {
            try
            {
                if (!m_fAdmCore.fOption.desktopAlertEnabled || !m_fAdmCore.fOption.desktopAlertDeviceEnabled)
                {
                    return;
                }

                // --

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringDeviceData(e);
                    }));
                }
                else
                {
                    procMonitoringDeviceData(e);
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

        private void m_fAdmCore_MonitoringSecs1ToHsmsConverterDataReceived(
            object sender, 
            FMonitoringSecs1ToHsmsConverterDataReceivedEventArgs e
            )
        {
            try
            {
                if (!m_fAdmCore.fOption.desktopAlertEnabled || !m_fAdmCore.fOption.desktopAlertEapEnabled)
                {
                    return;
                }

                // --

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringSecs1ToHsmsConverterData(e);
                    }));
                }
                else
                {
                    procMonitoringSecs1ToHsmsConverterData(e);
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

        private void m_fAdmCore_MonitoringSecs1ToHsmsConverterDisconnectDataReceived(
            object sender, 
            FMonitoringSecs1ToHsmsConverterDisconnectDataReceivedEventArgs e
            )
        {
            try
            {
                if (!m_fAdmCore.fOption.desktopAlertEnabled || !m_fAdmCore.fOption.desktopAlertEapEnabled)
                {
                    return;
                }

                // --

                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        procMonitoringSecs1ToHsmsConverterDisconnectData(e);
                    }));
                }
                else
                {
                    procMonitoringSecs1ToHsmsConverterDisconnectData(e);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region dsaAlert Control Even Handler
        
        private void dsaAlert_DesktopAlertLinkClicked(
            object sender, 
            DesktopAlertLinkClickedEventArgs e
            )
        {
            FSystemCheckList fSystemCheckList = null;
            FSecs1ToHsmsConverterMonitor fSecs1ToHsmsConverterMonitor = null;
            FXmlNode fXmlNode = null;

            try
            {
                fXmlNode = ((FXmlNode)e.WindowInfo.Data);

                // --

                // ***
                // 2017.05.11 by spike.lee
                // SECS1 To HSMS Converter 관련 Desktop Alert 추가
                // ***
                if (
                    fXmlNode.name == FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.E_Secs1ToHsmsConverter ||
                    fXmlNode.name == FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.E_Secs1ToHsmsConverterDisconnect
                    )
                {
                    // ***
                    // 2017.05.12 by spike.lee
                    // 사용자 권한 체크 기능 추가
                    // ***
                    if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterMonitor))
                    {
                        return;
                    }

                    // -

                    procMenuSecs1ToHsmsConverterMonitor();
                    fSecs1ToHsmsConverterMonitor = (FSecs1ToHsmsConverterMonitor)this.getChild(typeof(FSecs1ToHsmsConverterMonitor).Name);

                    // --

                    if (fXmlNode.name == FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.E_Secs1ToHsmsConverter)
                    {
                        fSecs1ToHsmsConverterMonitor.attachConverter(
                            fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Converter, FADMADS_TolSecs1ToHsmsConverterDataPush_In.FSecs1ToHsmsConverter.A_Converter)
                            );
                    }
                    else if (fXmlNode.name == FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.E_Secs1ToHsmsConverterDisconnect)
                    {
                        fSecs1ToHsmsConverterMonitor.attachConverter(
                            fXmlNode.get_elemVal(FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Converter, FADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_In.FSecs1ToHsmsConverterDisconnect.A_Converter)
                            );
                    }
                }
                else
                {
                    // ***
                    // 2017.05.12 by spike.lee
                    // 사용자 권한 체크 기능 추가
                    // ***
                    if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.SystemCheckList))
                    {
                        return;
                    }

                    // --

                    procMenuSystemCheckList();
                    fSystemCheckList = (FSystemCheckList)this.getChild(typeof(FSystemCheckList).Name);

                    // --

                    if (fXmlNode.name == FADMADS_TolServerDataPush_In.FServer.E_Server)
                    {
                        fSystemCheckList.attachServer(
                            fXmlNode.get_elemVal(FADMADS_TolServerDataPush_In.FServer.A_Name, FADMADS_TolServerDataPush_In.FServer.D_Name)
                            );
                    }
                    else if (fXmlNode.name == FADMADS_TolEapDataPush_In.FEap.E_Eap)
                    {
                        fSystemCheckList.attachEap(
                            fXmlNode.get_elemVal(FADMADS_TolEapDataPush_In.FEap.A_Name, FADMADS_TolEapDataPush_In.FEap.D_Name)
                            );
                    }
                    else if (fXmlNode.name == FADMADS_TolDeviceDataPush_In.FDevice.E_Device)
                    {
                        fSystemCheckList.attachEap(
                            fXmlNode.get_elemVal(FADMADS_TolDeviceDataPush_In.FDevice.A_Eap, FADMADS_TolDeviceDataPush_In.FDevice.D_Eap)
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNode = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------       

        #region Worker Event Handler

        private void bgWorker_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e
            )
        {
            try
            {
                
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

        private void bgWorker_DoWork(
            object sender,
            DoWorkEventArgs e
            )
        {
            try
            {
                downloadHostDriver();
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
