/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FWsmContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Workspace Manager Container Form Class 
--  History         : Created by spike.lee at 2010.12.28
                    : Modified by spike.lee at 2011.09.20
                        - FAMate XML Tag Generator Add-On
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Net;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
// --
using Nexplant.MC.AdminManager;
using Nexplant.MC.ApplicationLogViewer;
//using Nexplant.MC.LogViewer;
using Nexplant.MC.LanguageFileEditor;
using Nexplant.MC.SecsModeler;
using Nexplant.MC.OpcModeler;
using Nexplant.MC.TcpModeler;
using Nexplant.MC.SourceGenerator;
using Nexplant.MC.SqlManager;

namespace Nexplant.MC.WorkspaceManager
{
    public partial class FWsmContainer : FBaseRibbonMdiForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string[] m_openFileNames = null;
        private bool m_updateAlarm = false;     // 2017.03.27 by spike.lee add
        private bool m_updateRequest = false;   // 2017.03.27 by spike.lee add
        // --
        private FWsmCore m_fWsmCore = null;
        private FThread m_fThdUpdater = null;
        private FStaticTimer m_fTmrUpdater = null;
        private Uri m_updateUri = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FWsmContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------       

        public FWsmContainer(
            FWsmCore fWsmCore,
            string[] openFileNames
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fWsmCore = fWsmCore;
            // --
            m_openFileNames = openFileNames;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setMainStatusBar(
            )
        {
            string caption = string.Empty;
            int indexOf = -1;
            
            try
            {
                caption = stbStatus.Panels["Contents"].Text;
                indexOf = caption.IndexOf("-");
                if (indexOf > -1)
                {
                    caption = m_fWsmCore.fUIWizard.searchCaption(caption.Substring(0, indexOf - 1)) + caption.Substring(indexOf - 1);
                }
                else
                {
                    caption = m_fWsmCore.fUIWizard.searchCaption(caption);
                }
                // --
                stbStatus.Panels["Contents"].Text = caption;
                stbStatus.Panels["Factory"].Text = m_fWsmCore.fUIWizard.searchCaption("Factory") + ": " + stbStatus.Panels["Factory"].Tag;
                stbStatus.Panels["UserGroup"].Text = m_fWsmCore.fUIWizard.searchCaption("User Group") + ": " + stbStatus.Panels["UserGroup"].Tag;
                stbStatus.Panels["User"].Text = m_fWsmCore.fUIWizard.searchCaption("User") + ": " + stbStatus.Panels["User"].Tag;
                stbStatus.Panels["Build"].Text = m_fWsmCore.fUIWizard.searchCaption("Build") + " " + stbStatus.Panels["Build"].Tag;
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

        protected override void WndProc(
            ref Message m
            )
        {
            if (m.Msg == (int)FNativeAPIs.FWinMsgs.WM_COPYDATA)
            {
                FNativeAPIs.COPYDATASTRUCT dataArgs;

                try
                {
                    dataArgs = (FNativeAPIs.COPYDATASTRUCT)Marshal.PtrToStructure(m.LParam, typeof(FNativeAPIs.COPYDATASTRUCT));

                    // --

                    this.BeginInvoke(new MethodInvoker(
                        delegate()
                        {
                            openFile(dataArgs.lpData);
                        }
                    ));                    
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(this.Name, ex, null);
                }
                finally
                {
                    
                }
            }
            base.WndProc(ref m);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                // --
                setMainStatusBar();
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
            // ***
            // New License File 적용
            // *** 

            try
            {
                mnuMenu.BeginUpdate();

                // --

                if (m_fWsmCore.fLicInfo.fLicAdm.productEnabled == FYesNo.Yes)
                {
                    mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuLogin].SharedProps.Enabled = !m_fWsmCore.fOption.isLogIn;
                    mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuLogout].SharedProps.Enabled = m_fWsmCore.fOption.isLogIn;
                    mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuPasswordChange].SharedProps.Enabled = m_fWsmCore.fOption.isLogIn;
                }
                else
                {
                    mnuMenu.Ribbon.Tabs["System"].Groups["System"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuLogin]);
                    mnuMenu.Ribbon.Tabs["System"].Groups["System"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuLogout]);
                    mnuMenu.Ribbon.Tabs["System"].Groups["System"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuPasswordChange]);
                }

                // --

                if (m_fWsmCore.fOption.developmentToolEnabled == FYesNo.Yes)
                {
                    mnuMenu.Ribbon.Tabs["Development Tool"].Visible = true;
                }
                else
                {
                    mnuMenu.Ribbon.Tabs["Development Tool"].Visible = false;
                }

                // --

                // ***
                // 2017.08.28 by spike.lee
                // License File 적용
                // ***
                if (m_fWsmCore.fLicInfo.fLicSecs.productEnabled == FYesNo.No)
                {
                    mnuMenu.Ribbon.Tabs["Automation"].Groups["Modeling"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuSecsModeler]);
                }
                // --
                if (m_fWsmCore.fLicInfo.fLicOpc.productEnabled == FYesNo.No)
                {
                    mnuMenu.Ribbon.Tabs["Automation"].Groups["Modeling"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuOpcModeler]);
                }
                // --
                if (m_fWsmCore.fLicInfo.fLicTcp.productEnabled == FYesNo.No)
                {
                    mnuMenu.Ribbon.Tabs["Automation"].Groups["Modeling"].Tools.Remove(mnuMenu.Ribbon.ToolbarsManager.Tools[FMenuKey.MenuTcpModeler]);
                }
                // --
                if (
                    m_fWsmCore.fLicInfo.fLicSecs.productEnabled == FYesNo.No &&
                    m_fWsmCore.fLicInfo.fLicOpc.productEnabled == FYesNo.No &&
                    m_fWsmCore.fLicInfo.fLicTcp.productEnabled == FYesNo.No
                    )
                {
                    mnuMenu.Ribbon.Tabs["Automation"].Groups["Modeling"].Visible = false;
                }
                // --
                if (m_fWsmCore.fLicInfo.fLicAdm.productEnabled == FYesNo.No)
                {
                    mnuMenu.Ribbon.Tabs["Automation"].Groups["Management"].Visible = false;
                }

                // ***
                // 2019.09.05 by hongmi.park
                // RecentFiles Load
                // ***
                //if (m_fWsmCore.fOption.recentLogFileList.Length > 0)
                //{
                //    ((ListTool)mnuMenu.Tools[FMenuKey.MenuListRecentFile]).ListToolItems.Clear();

                //    foreach (string file in m_fWsmCore.fOption.recentLogFileList)
                //    {
                //        ((ListTool)mnuMenu.Tools[FMenuKey.MenuListRecentFile]).ListToolItems.Add(file, file);
                //        ((ListTool)mnuMenu.Tools[FMenuKey.MenuListRecentFile]).ListToolItems[file].Appearance.Image = getImageOfLog(file);
                //        ((ListTool)mnuMenu.Tools[FMenuKey.MenuListRecentFile]).ListToolItems[file].Appearance.ImageHAlign = Infragistics.Win.HAlign.Left;
                //        ((ListTool)mnuMenu.Tools[FMenuKey.MenuListRecentFile]).ListToolItems[file].Appearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                        
                //    }
                //}


                // --

                mnuMenu.EndUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.EndUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------       

        private void procMenuLogIn(
            )
        {
            FUserLogIn fUserLogIn = null;

            try
            {
                fUserLogIn = new FUserLogIn(m_fWsmCore);
                if (fUserLogIn.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                controlMainMenu();

                // --

                m_fWsmCore.onMainStatusBarChanged(true);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fUserLogIn != null)
                {
                    fUserLogIn.Dispose();
                    fUserLogIn = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuLogOut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // Log Out Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fWsmCore.fUIWizard.generateMessage("Q0007", new object[] { "Nexplant MC Workspace Manager v4.6" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                foreach (Form form in this.tmmTab.MdiParent.MdiChildren)
                {
                    if (form is FAdmContainer)
                    {
                        form.Close();
                    }
                }

                // --

                m_fWsmCore.fOption.isLogIn = false;

                // --

                controlMainMenu();

                // --

                m_fWsmCore.onMainStatusBarChanged(false);
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

        private void procMenuPasswordChange(
            )
        {
            FPasswordChange fPasswordChange = null;

            try
            {
                fPasswordChange = new FPasswordChange(m_fWsmCore);
                if (fPasswordChange.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fPasswordChange != null)
                {
                    fPasswordChange.Dispose();
                    fPasswordChange = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOption(
            )
        {
            FSetupOption fSetupOption = null;

            try
            {
                fSetupOption = new FSetupOption(m_fWsmCore);
                if (fSetupOption.ShowDialog(this) == DialogResult.OK)
                {
                    m_fWsmCore.fOption.changeOption(fSetupOption.fPropSetupOption);
                }

                // --

                controlMainMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fSetupOption != null)
                {
                    fSetupOption.Dispose();
                    fSetupOption = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuLanguageFileEditor(
            )
        {
            try
            {
                this.showTabMdiChild(new FLfeContainer(m_fWsmCore));
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

        private void procMenuApplicationLogViewer(
            )
        {
            try
            {
                this.showTabMdiChild(new FAlvContainer(m_fWsmCore));
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

        private void procMenuLogViewer(
            )
        {
            try
            {
                //this.showTabMdiChild(new FLvwContainer(m_fWsmCore));
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

        private void procMenuSecsModeler(
            )
        {
            try
            {
                this.showTabMdiChild(new FSsmContainer(m_fWsmCore));
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

        private void procMenuSecsModeler(
            string fileName
            )
        {
            try
            {
                this.showTabMdiChild(new FSsmContainer(m_fWsmCore, fileName));
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

        private void procMenuOpcModeler(
            )
        {
            try
            {
                this.showTabMdiChild(new FOpmContainer(m_fWsmCore));
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

        private void procMenuOpcModeler(
            string fileName
            )
        {
            try
            {
                this.showTabMdiChild(new FOpmContainer(m_fWsmCore, fileName));
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

        private void procMenuTcpModeler(
            )
        {
            try
            {
                this.showTabMdiChild(new FTcmContainer(m_fWsmCore));
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

        private void procMenuTcpModeler(
            string fileName
            )
        {
            try
            {
                this.showTabMdiChild(new FTcmContainer(m_fWsmCore, fileName));
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

        private void procMenuListRecentFile(
            string fileName
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

        private void procMenuLogViewer(
            string fileName
            )
        {
            try
            {
                //this.showTabMdiChild(new FLvwContainer(m_fWsmCore, fileName));
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

        private void procMenuSourceGenerator(
            )
        {
            try
            {
                this.showTabMdiChild(new FScgContainer(m_fWsmCore));
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

        private void procMenuSourceGenerator(
            string fileName
            )
        {
            try
            {
                this.showTabMdiChild(new FScgContainer(m_fWsmCore, fileName));
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

        private void procMenuSqlManager(
            )
        {
            try
            {
                this.showTabMdiChild(new FSqmContainer(m_fWsmCore));
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

        private void procMenuAdminManager(
            )
        {
            FUserLogIn fUserLogIn = null;

            try
            {
                if (!m_fWsmCore.fOption.isLogIn)
                {
                    fUserLogIn = new FUserLogIn(m_fWsmCore);
                    if (fUserLogIn.ShowDialog(this) == DialogResult.Cancel)
                    {
                        return;
                    }

                    // --

                    controlMainMenu();
                }

                // --

                this.showTabMdiChild(new FAdmContainer(m_fWsmCore));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fUserLogIn != null)
                {
                    fUserLogIn.Dispose();
                    fUserLogIn = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designWsmContainer(
            )
        {
            try
            {
                this.BackgroundImage = Properties.Resources.FWsmContainer;
                this.BackgroundImageLayout = ImageLayout.Center;

                // --

                mnuMenu.ImageListSmall = new ImageList();
                // --
                mnuMenu.ImageListSmall.Images.Add("File_Gen", Properties.Resources.File_Gen);
                mnuMenu.ImageListSmall.Images.Add("File_Ssm", Properties.Resources.File_Ssm);
                mnuMenu.ImageListSmall.Images.Add("File_Log", Properties.Resources.File_Log); 
                mnuMenu.ImageListSmall.Images.Add("File_Dlg", Properties.Resources.File_Dlg);
                mnuMenu.ImageListSmall.Images.Add("File_Ssl", Properties.Resources.File_Ssl);
                mnuMenu.ImageListSmall.Images.Add("File_Sml", Properties.Resources.File_Sml);
                mnuMenu.ImageListSmall.Images.Add("File_Vfe", Properties.Resources.File_Vfe);
                mnuMenu.ImageListSmall.Images.Add("File_Bng", Properties.Resources.File_Bng);
                mnuMenu.ImageListSmall.Images.Add("File_Osm", Properties.Resources.File_Osm);
                mnuMenu.ImageListSmall.Images.Add("File_Osl", Properties.Resources.File_Osl);
                mnuMenu.ImageListSmall.Images.Add("File_Tsm", Properties.Resources.File_Tsm);
                mnuMenu.ImageListSmall.Images.Add("File_Tsl", Properties.Resources.File_Tsl);
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

        private Image getImageOfLog(
            string fileName
            )
        {
            string fileExtension = string.Empty;

            try
            {
                fileExtension = Path.GetExtension(fileName);

                // --

                if (fileExtension == ".gen")
                {
                    return mnuMenu.ImageListSmall.Images["File_Gen"];
                }
                else if (fileExtension == ".ssm")
                {
                    return mnuMenu.ImageListSmall.Images["File_Ssm"];
                }
                else if (fileExtension == ".psm")
                {
                    return mnuMenu.ImageListSmall.Images["File_Psm"];
                }
                else if (fileExtension == ".log")
                {
                    return mnuMenu.ImageListSmall.Images["File_Log"];
                }
                else if (fileExtension == ".dlg")
                {
                    return mnuMenu.ImageListSmall.Images["File_Dlg"];
                }
                else if (fileExtension == ".ssl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Ssl"];
                }
                else if (fileExtension == ".psl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Psl"];
                }
                else if (fileExtension == ".sml")
                {
                    return mnuMenu.ImageListSmall.Images["File_Sml"];
                }
                else if (fileExtension == ".vfe")
                {
                    return mnuMenu.ImageListSmall.Images["File_Vfe"];
                }
                else if (fileExtension == ".bng")
                {
                    return mnuMenu.ImageListSmall.Images["File_Bng"];
                }
                else if (fileExtension == ".osm")
                {
                    return mnuMenu.ImageListSmall.Images["File_Osm"];
                }
                else if (fileExtension == ".osl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Osl"];
                }
                else if (fileExtension == ".tsm")
                {
                    return mnuMenu.ImageListSmall.Images["File_Tsm"];
                }
                else if (fileExtension == ".tsl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Tsl"];
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        private void openFile(
            string fileName
            )
        {
            string ext = string.Empty;

            try
            {
                // ***
                // File이 존재하는지 검사
                // ***
                if (!File.Exists(fileName))
                {
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        fUIWizard.generateMessage("E0010", new object[] { "\"" + fileName + "\" File" }),
                        this
                        );
                    return;
                }

                // --

                ext = Path.GetExtension(fileName).ToLower();
                // --
                if (
                    ext == ".ssm" ||
                    ext == ".ssl"
                    )
                {
                    procMenuSecsModeler(fileName);
                }
                else if (
                         ext == ".osm" ||
                         ext == ".osl"
                         )
                {
                    procMenuOpcModeler(fileName);
                }
                else if (
                         ext == ".tsm" ||
                         ext == ".tsl"
                         )
                {
                    procMenuTcpModeler(fileName);
                }
                else if (ext == ".psm")
                {
                    // procMenuPlcModeler(fileName);
                }
                else if (ext == ".gen")
                {
                    // procMenuSourceGenerator(fileName);
                }
                else if (
                    ext == ".bng" ||
                    ext == ".vfe" ||
                    //ext == ".ssl" ||
                    //ext == ".osl" ||
                    //ext == ".tsl" ||
                    ext == ".log" ||
                    ext == ".dlg" ||
                    ext == ".sml" ||
                    ext == ".xlg"
                    )
                {
                    procMenuLogViewer(fileName);
                }
                else
                {
                    // ***
                    // 지원하지 않는 확장자 검사
                    // ***
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        fUIWizard.generateMessage("E0043", new object[] { "\"" + fileName + "\" File Extension" }),
                        this
                        );
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

        private DialogResult confirmUpdate(
            )
        {
            try
            {
                // ***
                // Update Confirm
                // ***                
                return FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fWsmCore.fUIWizard.generateMessage("Q0020"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return System.Windows.Forms.DialogResult.No;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FWsmContainer Form Event Handler

        private void FWsmContainer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                mnuMenu.Ribbon.IsMinimized = true;
                // --
                m_fWsmCore.MainStatusBarChanged += new FMainStatusBarChangedEventHandler(m_fWsmCore_MainStatusBarChanged);
                // --
                m_fWsmCore.onMainStatusBarChanged(false);

                // -- 

                designWsmContainer();

                // --

                controlMainMenu();

                // --

                // ***
                // 2017.03.27 by spike.lee
                // 자동 Update 확인 Thread 활성화
                // ***
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    m_updateUri = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.UpdateLocation;

                    // --

                    m_fTmrUpdater = new FStaticTimer();
                    m_fTmrUpdater.start(1000 * 60 * 5);  // 5분
                    // --
                    m_fThdUpdater = new FThread("WSM_Updater");
                    m_fThdUpdater.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdUpdater_ThreadJobCalled);
                    m_fThdUpdater.start();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FWsmContainer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fWsmCore.fLicInfo.fLicAdm.expireIssuedCheck == FYesNo.Yes)
                {
                    this.Text = FConstants.ApplicationName + " - " + m_fWsmCore.fLicInfo.customerCompany + " [Expiry Date : " + m_fWsmCore.fLicInfo.fLicAdm.expireIssuedDate + "]";
                }
                else
                {
                    this.Text = FConstants.ApplicationName + " - " + m_fWsmCore.fLicInfo.customerCompany;
                }

                // --

                if (m_openFileNames != null)
                {
                    foreach (string f in m_openFileNames)
                    {
                        openFile(f);
                    }
                }

                // --

                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FWsmContainer_FormCloseConfirm(
            object sender,
            FFormCloseConfirmEventArgs e
            )
        {
            DialogResult dialogResult;

            try
            {
                FCursor.waitCursor();

                // --

                if (m_fWsmCore.fOption.isLogIn)
                {
                    // ***
                    // Application Exit Confirm
                    // ***                
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fWsmCore.fUIWizard.generateMessage("Q0001", new object[] { FConstants.ApplicationName }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        this
                        );
                    if (dialogResult == DialogResult.No)
                    {
                        e.cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FWsmContainer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            string path = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                m_fWsmCore.MainStatusBarChanged -= new FMainStatusBarChangedEventHandler(m_fWsmCore_MainStatusBarChanged);

                // --

                // ***
                // 2017.04.04 by spike.lee
                // Updater Thread Terminate
                // ***
                if (m_fThdUpdater != null)
                {
                    m_fThdUpdater.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdUpdater_ThreadJobCalled);
                    m_fThdUpdater.stop();
                    m_fThdUpdater.Dispose();
                    m_fThdUpdater = null;
                }

                // --

                if (m_fTmrUpdater != null)
                {
                    m_fTmrUpdater.Dispose();
                    m_fTmrUpdater = null;
                }

                // --

                // ***
                // 2017.03.27 by spike.lee
                // Update 실행
                // *** 
                if (m_updateRequest)
                {
                    path =
                        Environment.GetFolderPath(Environment.SpecialFolder.Programs) +
                        @"\\Miracom\Nexplant MC Workspace Manager v4.6\Nexplant MC Workspace Manager v4.6.appref-ms";
                    // --
                    System.Diagnostics.Process.Start(path);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FWsmContainer_DragDrop(
            object sender,
            DragEventArgs e
            )
        {
            string[] files = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string file in files)
                    {
                        openFile(file);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FWsmContainer_DragEnter(
            object sender,
            DragEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fWsmCore Object Event Handler

        private void m_fWsmCore_MainStatusBarChanged(
            object sender,
            FMainStatusBarChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.enabled)
                {
                    stbStatus.Panels["Contents"].Text = e.contents;
                    // --
                    stbStatus.Panels["Factory"].Visible = (e.factory != string.Empty);
                    stbStatus.Panels["Factory"].Tag = e.factory;
                    // --
                    stbStatus.Panels["UserGroup"].Visible = (e.userGroup != string.Empty);
                    stbStatus.Panels["UserGroup"].Tag = e.userGroup;
                    // --
                    stbStatus.Panels["User"].Visible = (e.user != string.Empty);
                    stbStatus.Panels["User"].Tag = e.user;
                    // --
                    // stbStatus.Panels["Build"].Tag = e.version;
                }
                else
                {
                    stbStatus.Panels["Contents"].Text = FConstants.ApplicationName;
                    stbStatus.Panels["Factory"].Visible = false;
                    stbStatus.Panels["UserGroup"].Visible = false;
                    stbStatus.Panels["User"].Visible = false;
                    // --
                    //if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    //{
                    //    stbStatus.Panels["Build"].Tag = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                    //}
                    //else
                    //{
                    //    stbStatus.Panels["Build"].Tag = Application.ProductVersion;
                    //}
                }

                // --

                // ***
                // 2017.03.27 by spike.lee
                // WorkspaceManager 버전으로 표기하도록 수정
                // ***
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    stbStatus.Panels["Build"].Tag = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
                }
                else
                {
                    stbStatus.Panels["Build"].Tag = Application.ProductVersion;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdUpdater Object Event Handler

        private void m_fThdUpdater_ThreadJobCalled(
            object sender, 
            FThreadEventArgs e
            )
        {
            string manifestFile = string.Empty;
            XDocument xDoc = null;
            XNamespace nsSys = null;
            Version version = null;

            try
            {
                if (!m_updateAlarm && m_fTmrUpdater.elasped(true))
                {
                    manifestFile = new WebClient().DownloadString(m_updateUri);
                    xDoc = XDocument.Parse(manifestFile);
                    nsSys = "urn:schemas-microsoft-com:asm.v1";
                    version = new Version(xDoc.Descendants(nsSys + "assemblyIdentity").First().Attribute("version").Value);
                    // --
                    if (version > System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion)
                    {
                        this.BeginInvoke(new MethodInvoker(delegate()
                        {
                            m_updateAlarm = true;
                            // --
                            tmrUpdateCheck.Interval = 1200;
                            tmrUpdateCheck.Enabled = true;
                        }));
                    }
                }
                // --
                e.sleepThread(10);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                xDoc = null;
                nsSys = null;
                version = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

        private void mnuMenu_BeforeToolDropdown(
            object sender, 
            BeforeToolDropdownEventArgs e
            )
        {
            PopupMenuTool popupMenuTool = null;
            ToolBase toolBase = null;
            string[] recentFiles = null;

            try
            {
                FCursor.waitCursor();

                // --

                popupMenuTool = (PopupMenuTool)e.Tool;

                // --

                popupMenuTool.Tools.Clear();

                // --

                if (!mnuMenu.Tools.Exists(FMenuKey.MenuRecentlyDocuments))
                {
                    mnuMenu.Tools.Add(new LabelTool(FMenuKey.MenuRecentlyDocuments));
                }
                toolBase = mnuMenu.Tools[FMenuKey.MenuRecentlyDocuments];
                toolBase.SharedProps.Caption = "Recently Documents ──────────────────";
                popupMenuTool.Tools.AddTool(FMenuKey.MenuRecentlyDocuments);

                // --

                if (e.Tool.Key == FMenuKey.MenuPopupSourceGenerator)
                {
                    recentFiles = m_fWsmCore.fOption.recentGenFileList;
                }
                else if (e.Tool.Key == FMenuKey.MenuPopupSecsModeler)
                {
                    recentFiles = m_fWsmCore.fOption.recentSecsModelerFileList;
                }
                else if (e.Tool.Key == FMenuKey.MenuPopupPlcModeler)
                {
                    recentFiles = m_fWsmCore.fOption.recentPlcModelerFileList;
                }
                else if (e.Tool.Key == FMenuKey.MenuPopupLogViewer)
                {
                    recentFiles = m_fWsmCore.fOption.recentLogFileList;
                }

                // --
                

                if (m_fWsmCore.fOption.recentLogFileList.Length > 0)
                {
                    recentFiles = m_fWsmCore.fOption.recentLogFileList;
                    foreach (string s in recentFiles)
                    {
                        if (!mnuMenu.Tools.Exists(s))
                        {
                            mnuMenu.Tools.Add(new ButtonTool(s));
                        }
                        toolBase = mnuMenu.Tools[s];
                        toolBase.SharedProps.Caption = Path.GetFileName(s);
                        toolBase.SharedProps.ToolTipText = s;
                        toolBase.SharedProps.AppearancesSmall.Appearance.Image = getImageOfLog(s);
                        popupMenuTool.Tools.AddTool(s);
                    }
                }
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
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

                if (e.Tool.Key == FMenuKey.MenuLogin)
                {
                    procMenuLogIn();
                }
                else if (e.Tool.Key == FMenuKey.MenuLogout)
                {
                    procMenuLogOut();
                }
                else if (e.Tool.Key == FMenuKey.MenuPasswordChange)
                {
                    procMenuPasswordChange();
                }
                else if (e.Tool.Key == FMenuKey.MenuOption)
                {
                    procMenuOption();
                }
                else if (e.Tool.Key == FMenuKey.MenuListRecentFile)
                {
                    openFile(e.Tool.Key);
                    // procMenuListRecentFile();
                }
                else if (e.Tool.Key == FMenuKey.MenuExit)
                {
                    this.Close();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuLanguageFileEditor)
                {
                    procMenuLanguageFileEditor();
                }
                else if (e.Tool.Key == FMenuKey.MenuApplicationLogViewer)
                {
                    procMenuApplicationLogViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLogViewer)
                {
                    procMenuLogViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSourceGenerator)
                {
                    procMenuSourceGenerator();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlManager)
                {
                    procMenuSqlManager();
                }
                // --                
                else if (e.Tool.Key == FMenuKey.MenuSecsModeler)
                {
                    procMenuSecsModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpcModeler)
                {
                    procMenuOpcModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpModeler)
                {
                    procMenuTcpModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuAdminManager)
                {
                    procMenuAdminManager();
                }

                // -- 

                // ***
                // Recent File
                // ***
                else
                {
                    openFile(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tmrUpdateCheck Control Event Handler

        private void tmrUpdateCheck_Tick(
            object sender, 
            EventArgs e
            )
        {
            Color Color1 = Color.SteelBlue;
            Color Color2 = Color.FromArgb(0, 0, 0, 0);

            try
            {
                if (stbStatus.Panels["Build"].Appearance.BackColor == Color1)
                {
                    stbStatus.Panels["Build"].Appearance.BackColor = Color2;
                }
                else
                {
                    stbStatus.Panels["Build"].Appearance.BackColor = Color1;
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region stbStatus Control Event Handler

        private void stbStatus_PanelClick(
            object sender, 
            Infragistics.Win.UltraWinStatusBar.PanelClickEventArgs e
            )
        {
            DialogResult dialogResult;

            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Panel.Key == "Build" && m_updateAlarm)
                {
                    dialogResult = confirmUpdate();
                    if (dialogResult == System.Windows.Forms.DialogResult.Yes)
                    {
                        m_updateRequest = true;
                        this.Close();
                        m_updateRequest = false;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }    

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        // test


        //private int m_lastKey = 0;

        private void tmmTab_TabDropped(
            object sender, 
            Infragistics.Win.UltraWinTabbedMdi.MdiTabDroppedEventArgs e
            )
        {
            //Infragistics.Win.UltraWinDock.DockAreaPane dockArea = null;
            //Infragistics.Win.UltraWinDock.DockableControlPane form = null;

            try
            {
                //m_lastKey++;


                //if (udmMgr.DockAreas.Count == 0)
                //{
                //    dockArea = new Infragistics.Win.UltraWinDock.DockAreaPane(Infragistics.Win.UltraWinDock.DockedLocation.Floating);                    
                //    // --
                //    udmMgr.DockAreas.Add(dockArea);
                //    dockArea.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.True;
                //    dockArea.Maximized = true;

                    
                //}

                //form = new Infragistics.Win.UltraWinDock.DockableControlPane(e.Tab.Form);
                //form.Text = form.Control.Text;
                //form.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.True;
                
                //udmMgr.DockAreas[0].Panes.Add(form);
                
                //form.Settings.AllowMaximize = Infragistics.Win.DefaultableBoolean.True;
                //form.Maximized = true;

                

                //form.Float();
                
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("", ex, this);
            }
            finally
            {

            }
        }

        private void udmMgr_DoubleClickSplitterBar(object sender, Infragistics.Win.UltraWinDock.PanesEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("udmMgr_DoubleClickSplitterBar");
        }

        private void udmMgr_AfterPaneButtonClick(object sender, Infragistics.Win.UltraWinDock.PaneButtonEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("udmMgr_AfterPaneButtonClick");


            //if (e.Button == Infragistics.Win.UltraWinDock.PaneButton.Maximize)
            //{
            //    e.Pane.Maximized = true;
            //}
            //else if (e.Button == Infragistics.Win.UltraWinDock.PaneButton.Close)
            //{
            //    e.Pane.Closed = false;
            //}
            
        }

        private void udmMgr_BeforePaneButtonClick(object sender, Infragistics.Win.UltraWinDock.CancelablePaneButtonEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("udmMgr_AfterPaneButtonClick");


            if (e.Button == Infragistics.Win.UltraWinDock.PaneButton.Maximize)
            {
                e.Pane.Maximized = true;
            }
            else if (e.Button == Infragistics.Win.UltraWinDock.PaneButton.Close)
            {
                e.Cancel = true;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end