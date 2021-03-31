/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSsmContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler Container Form Class 
--  History         : Created by spike.lee at 2011.01.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinToolbars;

using System.Net.Sockets;
using System.Net;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSsmContainer : Nexplant.MC.Core.FaUIs.FBaseTabMdiChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_fileName = string.Empty;
        // --
        private FSsmCore m_fSsmCore = null;
        private FRelationViewer m_fRelationViewer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSsmContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSsmContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fSsmCore = new FSsmCore(fWsmCore, this);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSsmContainer(
            FIWsmCore fWsmCore,
            FSecsDriver fSecsDriver
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fSsmCore = new FSsmCore(fWsmCore, this, fSecsDriver);            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSsmContainer(
            FIWsmCore fWsmCore,
            string fileName
            )           
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fSsmCore = new FSsmCore(fWsmCore, this);            
            // --
            m_fileName = fileName;
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
                    if (m_fSsmCore != null)
                    {
                        m_fSsmCore.Dispose();
                        m_fSsmCore = null;
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
                appName = m_fSsmCore.fWsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                // --
                if (m_fSsmCore.fSsmFileInfo.isClosedFile)
                {
                    this.Text = appName;
                }
                else
                {
                    this.Text = appName + " - [" + m_fSsmCore.fSsmFileInfo.fileName + (m_fSsmCore.fSsmFileInfo.isModifiedFile ? "*" : "") + "]";
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

        private void setMainStatusBar(
            )
        {
            System.Reflection.Assembly assembly = null;
            string caption = string.Empty;
            string version = string.Empty;

            try
            {
                caption = m_fSsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                if (!m_fSsmCore.fSsmFileInfo.isClosedFile)
                {
                    caption += " - [" + m_fSsmCore.fSsmFileInfo.fileFullName + (m_fSsmCore.fSsmFileInfo.isModifiedFile ? "*" : "") + "]";
                }

                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }

                // --

                m_fSsmCore.fWsmCore.onMainStatusBarChanged(
                    true,
                    caption,
                    string.Empty,
                    string.Empty,
                    string.Empty,
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

        public void controlMainMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                // ***
                // File Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuNew].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuOpen].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuClose].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuClone].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuSave].SharedProps.Enabled = m_fSsmCore.fSsmFileInfo.isNewFile | m_fSsmCore.fSsmFileInfo.isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuSaveAs].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuRecentLog].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuExport].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuExit].SharedProps.Enabled = true;

                // --

                // ***
                // Setup Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuObjectNameDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuFunctionNameDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuUserTagNameDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuDataConversionSetDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEquipmentStateSetDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuRepositoryDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuDataSetDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEnvironmentDefinition].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;

                // --

                // ***
                // Modeling Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuSecsLibraryModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuSecsDeviceModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuHostLibraryModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuHostDeviceModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEquipmentModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuAllInOneModeler].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;

                // --                

                // ***
                // Tool Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuOpenAllDevice].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuCloseAllDevice].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuSecsBinaryLogCut].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile && m_fSsmCore.fOption.enabledLogOfBinary;
                mnuMenu.Tools[FMenuKey.MenuSmlLogCut].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile && m_fSsmCore.fOption.enabledLogOfSml;
                mnuMenu.Tools[FMenuKey.MenuVfeiLogCut].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile && m_fSsmCore.fOption.enabledLogOfVfei;
                mnuMenu.Tools[FMenuKey.MenuSecsLogCut].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile && m_fSsmCore.fOption.enabledLogOfSecs;

                // --

                // ***
                // Tracer Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuSecsBinaryTracer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuSmlTracer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuVfeiTracer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuLogTracer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                //mnuMenu.Tools[FMenuKey.MenuInterfaceTracer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuInterfaceTracer].SharedProps.Visible = false;

                // --

                // ***
                // View Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuSmlViewer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuVfeiViewer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuRelationViewer].SharedProps.Enabled = !m_fSsmCore.fSsmFileInfo.isClosedFile;

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

        private void changeRecentLibFile(
            string fileName
            )
        {
            try
            {
                if (m_fSsmCore.fOption.libRecentFileList.Contains(fileName))
                {
                    m_fSsmCore.fOption.libRecentFileList.Remove(fileName);
                }
                else if (m_fSsmCore.fOption.libRecentFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fSsmCore.fOption.libRecentFileList.RemoveAt(m_fSsmCore.fOption.libRecentFileList.Count - 1);
                }
                m_fSsmCore.fOption.libRecentFileList.Insert(0, fileName);

                // --

                m_fSsmCore.fWsmOption.recentFile = fileName;
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

        private bool confirmSave(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // Modeling File Save Confirm
                // ***
                if (m_fSsmCore.fSsmFileInfo.isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { m_fSsmCore.fSsmFileInfo.fileName }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fSsmCore.fWsmCore.fWsmContainer
                        );
                    if (dialogResult == DialogResult.Yes)
                    {
                        return procMenuSave();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }

                // --
               
                return true;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void loadLibFile(
            string fileName
            )
        {
            try
            {
                if (m_fRelationViewer != null)
                {
                    m_fRelationViewer.Close();
                }
                // --
                if (!this.closeAllChilds())
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.openFile(fileName);
                // showDefaultModeler();

                // --

                m_fSsmCore.fOption.libRecentOpenPath = Path.GetDirectoryName(fileName);
                changeRecentLibFile(fileName);

                // --

                setTitle();
                controlMainMenu();
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

        private void loadLogFile(
        string fileName
        )
        {
            FTotalLogTracer fLogTracer = null;

            try
            {
                fLogTracer = (FTotalLogTracer)this.getChild(typeof(FTotalLogTracer));
                if (fLogTracer == null)
                {
                    fLogTracer = new FTotalLogTracer(m_fSsmCore);
                    this.showChild(fLogTracer);
                }

                // --

                fLogTracer.Invoke(new MethodInvoker(delegate ()
                {
                    fLogTracer.openLogFile(fileName);
                }));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void saveLibFile(
            string fileName
            )
        {
            try
            {
                m_fSsmCore.fSsmFileInfo.saveFile(fileName);

                // --

                m_fSsmCore.fOption.libRecentSavePath = Path.GetDirectoryName(fileName);
                changeRecentLibFile(fileName);

                // --

                setTitle();
                controlMainMenu();
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

        private void procMenuNew(
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                if (!this.closeAllChilds())
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.newFile();
                // showDefaultModeler();

                // --

                setTitle();
                controlMainMenu();
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

        private void procMenuOpen(
            )
        {
            OpenFileDialog dialog = null;

            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                dialog = new OpenFileDialog();
                dialog.Title = fUIWizard.searchCaption("Open SECS Modeling File");
                dialog.Filter = "SECS Modeling Files | *.ssm";
                dialog.DefaultExt = "ssm";
                dialog.InitialDirectory = m_fSsmCore.fOption.libRecentOpenPath;
                
                // --

                // ***
                // TEST
                // ***
                #region TEST
                //string searchPattern = "????????????.ssm";
                //List<string> sptList = new List<string>();
                //List<string> extList = new List<string>();
                //List<string> fileList = new List<string>();

                //foreach (string s in searchPattern.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                //{
                //    sptList.Add(s.Trim());
                //    extList.Add(Path.GetExtension(s.Trim().ToLower()));
                //}

                //for (int i = 0; i < sptList.Count; i++)
                //{
                //    if (extList[i] == ".*")
                //    {
                //        foreach (string s in Directory.EnumerateFiles(m_fSsmCore.fOption.libRecentOpenPath, sptList[i], SearchOption.AllDirectories))
                //        {
                //            fileList.Add(s);
                //        }
                //    }
                //    else
                //    {
                //        foreach (string s in Directory.EnumerateFiles(m_fSsmCore.fOption.libRecentOpenPath, sptList[i], SearchOption.AllDirectories).Where(s => s.ToLower().EndsWith(extList[i])))
                //        {
                //            fileList.Add(s);
                //        }
                //    }
                //}

                //foreach (string s in fileList)
                //{
                //    System.Diagnostics.Debug.WriteLine(s);
                //}

                // --
                // --
                // --

                //FLic2License fLic = new FLic2License();
                //FLic2Info fLicInfo = fLic.validate(Path.Combine(m_fSsmCore.fOption.libRecentOpenPath, "license_test.lic"));
                //// --
                //System.Diagnostics.Debug.WriteLine("[License Information]");
                //System.Diagnostics.Debug.WriteLine("* LicenseId=" +fLicInfo.licenseId);
                //System.Diagnostics.Debug.WriteLine("* CustomerCompany=" + fLicInfo.customerCompany);
                //System.Diagnostics.Debug.WriteLine("* CustomerSite=" + fLicInfo.customerSite);
                //// --
                //System.Diagnostics.Debug.WriteLine("[Product Information]");
                //System.Diagnostics.Debug.WriteLine("* ProductTitle=" + fLicInfo.productTitle);
                //System.Diagnostics.Debug.WriteLine("* ProductVersion=" + fLicInfo.productVersion);
                //// --
                //System.Diagnostics.Debug.WriteLine("[FAmate SECS]");
                //System.Diagnostics.Debug.WriteLine("* ProductEnabled=" + fLicInfo.fLicSecs.productEnabled.ToString());
                //System.Diagnostics.Debug.WriteLine("* NetworkDeployed=" + fLicInfo.fLicSecs.networkDeployed.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedCheck=" + fLicInfo.fLicSecs.expireIssuedCheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedDate=" + fLicInfo.fLicSecs.expireIssuedDate);
                //System.Diagnostics.Debug.WriteLine("* MacAddressCheck=" + fLicInfo.fLicSecs.macAddresscheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* MacAddress=" + fLicInfo.fLicSecs.macAddress);
                //// --
                //System.Diagnostics.Debug.WriteLine("[FAmate OPC]");
                //System.Diagnostics.Debug.WriteLine("* ProductEnabled=" + fLicInfo.fLicOpc.productEnabled.ToString());
                //System.Diagnostics.Debug.WriteLine("* NetworkDeployed=" + fLicInfo.fLicOpc.networkDeployed.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedCheck=" + fLicInfo.fLicOpc.expireIssuedCheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedDate=" + fLicInfo.fLicOpc.expireIssuedDate);
                //System.Diagnostics.Debug.WriteLine("* MacAddressCheck=" + fLicInfo.fLicOpc.macAddresscheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* MacAddress=" + fLicInfo.fLicOpc.macAddress);
                //// --
                //System.Diagnostics.Debug.WriteLine("[FAmate TCP]");
                //System.Diagnostics.Debug.WriteLine("* ProductEnabled=" + fLicInfo.fLicTcp.productEnabled.ToString());
                //System.Diagnostics.Debug.WriteLine("* NetworkDeployed=" + fLicInfo.fLicTcp.networkDeployed.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedCheck=" + fLicInfo.fLicTcp.expireIssuedCheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedDate=" + fLicInfo.fLicTcp.expireIssuedDate);
                //System.Diagnostics.Debug.WriteLine("* MacAddressCheck=" + fLicInfo.fLicTcp.macAddresscheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* MacAddress=" + fLicInfo.fLicTcp.macAddress);
                //// --
                //System.Diagnostics.Debug.WriteLine("[FAmate Admin Manager]");
                //System.Diagnostics.Debug.WriteLine("* ProductEnabled=" + fLicInfo.fLicAdm.productEnabled.ToString());
                //System.Diagnostics.Debug.WriteLine("* NetworkDeployed=" + fLicInfo.fLicAdm.networkDeployed.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedCheck=" + fLicInfo.fLicAdm.expireIssuedCheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedDate=" + fLicInfo.fLicAdm.expireIssuedDate);
                //System.Diagnostics.Debug.WriteLine("* MacAddressCheck=" + fLicInfo.fLicAdm.macAddresscheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* MacAddress=" + fLicInfo.fLicTcp.macAddress);
                //// --
                //System.Diagnostics.Debug.WriteLine("[FAmate Admin Service]");
                //System.Diagnostics.Debug.WriteLine("* ProductEnabled=" + fLicInfo.fLicAds.productEnabled.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedCheck=" + fLicInfo.fLicAds.expireIssuedCheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* ExpireIssuedDate=" + fLicInfo.fLicAds.expireIssuedDate);
                //System.Diagnostics.Debug.WriteLine("* MacAddressCheck=" + fLicInfo.fLicAds.macAddresscheck.ToString());
                //System.Diagnostics.Debug.WriteLine("* MacAddress=" + fLicInfo.fLicAds.macAddress);
                //System.Diagnostics.Debug.WriteLine("* EapRuntime=" + fLicInfo.fLicAds.eapRuntime.ToString());
                //System.Diagnostics.Debug.WriteLine("* EquipmentRuntime=" + fLicInfo.fLicAds.equipmentRuntime.ToString());
                //System.Diagnostics.Debug.WriteLine("* Secs1HsmsConverterRuntime=" + fLicInfo.fLicAds.secs1HsmsConverterRuntime);

                // ***
                // TEST END
                // ***
                #endregion

                // --
                
                if (dialog.ShowDialog(m_fSsmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                loadLibFile(dialog.FileName);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }
       
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClose(
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --
                
                if (!this.closeAllChilds())
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.closeFile();

                // --

                setTitle();
                controlMainMenu();
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

        private void procMenuClone(
            )
        {
            try
            {
                m_fSsmCore.fWsmCore.fWsmContainer.showTabMdiChild(
                    new FSsmContainer(m_fSsmCore.fWsmCore, this.m_fSsmCore.fSsmFileInfo.fSecsDriver.cloneSecsDriver())
                    );               
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

        private bool procMenuSave(
            )
        {
            try
            {
                if (m_fSsmCore.fSsmFileInfo.isNewFile)
                {
                    return procMenuSaveAs();
                }

                // --

                saveLibFile(m_fSsmCore.fSsmFileInfo.fileFullName);

                // --

                return true;
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

        //------------------------------------------------------------------------------------------------------------------------

        private bool procMenuSaveAs(
            )
        {
            SaveFileDialog dialog = null;

            try
            {
                dialog = new SaveFileDialog();
                dialog.Title = fUIWizard.searchCaption("Save As SECS Modeling File");
                dialog.Filter = "SECS Modeling Files | *.ssm";
                dialog.DefaultExt = "ssm";
                // --
                // ***
                // 2012.11.16 by spike.lee
                // Option의 Recent Library Save Path는 어디에서 사용하는 겁니까?
                // 여기서 사용하기 위해 Option으로 저장하는거 아닙니까?
                // ***
                if (m_fSsmCore.fSsmFileInfo.isNewFile)
                {
                    dialog.InitialDirectory = m_fSsmCore.fOption.libRecentSavePath;
                }
                else
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(m_fSsmCore.fSsmFileInfo.fileFullName);
                }                
                dialog.FileName = m_fSsmCore.fSsmFileInfo.fileName;
                // --
                if (dialog.ShowDialog(m_fSsmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return false;
                }

                // --

                saveLibFile(dialog.FileName);                

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRecentLibFile(
            string fileName
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --                

                // ***
                // 2012.11.15 by spike.lee
                // Progress 띠우고, 기존 창 모두 닫고 오류나면 어떻하란 말입니까?
                // File이 존재하는지를 먼저 검사하고 이후 수행했어야지요.
                // ***
                if (!File.Exists(fileName))
                {
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0010", new object[] { fileName }),
                        m_fSsmCore.fWsmCore.fWsmContainer
                        );
                    // --
                    if (m_fSsmCore.fOption.libRecentFileList.Contains(fileName))
                    {
                        m_fSsmCore.fOption.libRecentFileList.Remove(fileName);
                    }                    
                    // --
                    return;
                }

                // --

                loadLibFile(fileName);                
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

        // ***
        // 2012.11.15 by spike.lee
        // 이 Method는 왜 대문자로 시작됩니까?        
        // ***
        private void procMenuRecentLogFile(
            string fileName
            )
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0010", new object[] { fileName }),
                        m_fSsmCore.fWsmCore.fWsmContainer
                        );
                    // --
                    if (m_fSsmCore.fOption.logRecentFileList.Contains(fileName))
                    {
                        m_fSsmCore.fOption.logRecentFileList.Remove(fileName);
                    }
                    // --
                    return;                    
                }

                // --                

                loadLogFile(fileName);           
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

        private void procMenuOption(
            )
        {
            FOptionDialog dialog = null;

            try
            {
                dialog = new FOptionDialog(this.m_fSsmCore);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    controlMainMenu();
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

        private void procMenuExport(
            )
        {
            FExportDialog dialog = null;

            try
            {
                dialog = new FExportDialog(this.m_fSsmCore);
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    controlMainMenu();
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

        private void procMenuObjectNameDefinition(
            )
        {
            FObjectNameDefinition fObjectNameDefinition = null;

            try
            {
                fObjectNameDefinition = (FObjectNameDefinition)this.getChild(typeof(FObjectNameDefinition));
                if (fObjectNameDefinition == null)
                {
                    fObjectNameDefinition = new FObjectNameDefinition(m_fSsmCore);
                    this.showChild(fObjectNameDefinition);
                }
                fObjectNameDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObjectNameDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuFunctionNameDefinition(
            )
        {
            FFunctionNameDefinition fFunctionNameDefinition = null;

            try
            {   
                fFunctionNameDefinition = (FFunctionNameDefinition)this.getChild(typeof(FFunctionNameDefinition));
                if (fFunctionNameDefinition == null)
                {
                    fFunctionNameDefinition = new FFunctionNameDefinition(m_fSsmCore);
                    this.showChild(fFunctionNameDefinition);
                }
                fFunctionNameDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fFunctionNameDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void procMenuUserTagNameDefinition(
            )
        {
            FUserTagNameDefinition fUserTagNameDefinition = null;

            try
            {   
                fUserTagNameDefinition = (FUserTagNameDefinition)this.getChild(typeof(FUserTagNameDefinition));
                if (fUserTagNameDefinition == null)
                {
                    fUserTagNameDefinition = new FUserTagNameDefinition(m_fSsmCore);
                    this.showChild(fUserTagNameDefinition);
                }
                fUserTagNameDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fUserTagNameDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDataConversionSetDefinition(
            )
        {
            FDataConversionSetDefinition fDataConversionSetDefinition = null;

            try
            {
                fDataConversionSetDefinition = (FDataConversionSetDefinition)this.getChild(typeof(FDataConversionSetDefinition));
                if (fDataConversionSetDefinition == null)
                {
                    fDataConversionSetDefinition = new FDataConversionSetDefinition(m_fSsmCore);
                    this.showChild(fDataConversionSetDefinition);
                }
                fDataConversionSetDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataConversionSetDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentStateSetDefinition(
            )
        {
            FEquipmentStateSetDefinition fEquipmentStateSetDefinition = null;

            try
            {
                fEquipmentStateSetDefinition = (FEquipmentStateSetDefinition)this.getChild(typeof(FEquipmentStateSetDefinition));
                if (fEquipmentStateSetDefinition == null)
                {
                    fEquipmentStateSetDefinition = new FEquipmentStateSetDefinition(m_fSsmCore);
                    this.showChild(fEquipmentStateSetDefinition);
                }
                fEquipmentStateSetDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentStateSetDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRepositoryDefinition(
            )
        {
            FRepositoryDefinition fRepositoryDefinition = null;

            try
            {
                fRepositoryDefinition = (FRepositoryDefinition)this.getChild(typeof(FRepositoryDefinition));
                if (fRepositoryDefinition == null)
                {
                    fRepositoryDefinition = new FRepositoryDefinition(m_fSsmCore);
                    this.showChild(fRepositoryDefinition);
                }
                fRepositoryDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fRepositoryDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuMenuEnvironmentDefinition(
            )
        {
            FEnvironmentDefinition fEnvironmentDefinition = null;

            try
            {
                fEnvironmentDefinition = (FEnvironmentDefinition)this.getChild(typeof(FEnvironmentDefinition));
                if (fEnvironmentDefinition == null)
                {
                    fEnvironmentDefinition = new FEnvironmentDefinition(m_fSsmCore);
                    this.showChild(fEnvironmentDefinition);
                }
                fEnvironmentDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEnvironmentDefinition = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDataSetDefinition(
            )
        {
            FDataSetDefinition fDataSetDefinition = null;

            try
            {   
                fDataSetDefinition = (FDataSetDefinition)this.getChild(typeof(FDataSetDefinition));
                if (fDataSetDefinition == null)
                {
                    fDataSetDefinition = new FDataSetDefinition(m_fSsmCore);
                    this.showChild(fDataSetDefinition);
                }
                fDataSetDefinition.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDataSetDefinition = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsLibraryModeler(
            )
        {
            FSecsLibraryModeler fSecsLibraryModeler = null;

            try
            {
                fSecsLibraryModeler = (FSecsLibraryModeler)this.getChild(typeof(FSecsLibraryModeler));
                if (fSecsLibraryModeler == null)
                {
                    fSecsLibraryModeler = new FSecsLibraryModeler(m_fSsmCore);
                    this.showChild(fSecsLibraryModeler);
                }
                fSecsLibraryModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsLibraryModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecsDeviceModeler(
            )
        {
            FSecsDeviceModeler fSecsDeviceModeler = null;

            try
            {
                fSecsDeviceModeler = (FSecsDeviceModeler)this.getChild(typeof(FSecsDeviceModeler));
                if (fSecsDeviceModeler == null)
                {
                    fSecsDeviceModeler = new FSecsDeviceModeler(m_fSsmCore);
                    this.showChild(fSecsDeviceModeler);
                }
                fSecsDeviceModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsDeviceModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuHostLibraryModeler(
            )
        {
            FHostLibraryModeler fHostLibraryModeler = null;

            try
            {   
                fHostLibraryModeler = (FHostLibraryModeler)this.getChild(typeof(FHostLibraryModeler));
                if (fHostLibraryModeler == null)
                {
                    fHostLibraryModeler = new FHostLibraryModeler(m_fSsmCore);
                    this.showChild(fHostLibraryModeler);
                }
                fHostLibraryModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostLibraryModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuHostDeviceModeler(
            )
        {
            FHostDeviceModeler fHostDeviceModeler = null;

            try
            {
                fHostDeviceModeler = (FHostDeviceModeler)this.getChild(typeof(FHostDeviceModeler));
                if (fHostDeviceModeler == null)
                {
                    fHostDeviceModeler = new FHostDeviceModeler(m_fSsmCore);
                    this.showChild(fHostDeviceModeler);
                }
                fHostDeviceModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fHostDeviceModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentModeler(
            )
        {
            FEquipmentModeler fEquipmentModeler = null;

            try
            {
                fEquipmentModeler = (FEquipmentModeler)this.getChild(typeof(FEquipmentModeler));
                if (fEquipmentModeler == null)
                {
                    fEquipmentModeler = new FEquipmentModeler(m_fSsmCore);
                    this.showChild(fEquipmentModeler);
                }
                fEquipmentModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAllInOneModeler(
            )
        {
            FAllInOneModeler fAllInOneModeler = null;

            try
            {
                fAllInOneModeler = (FAllInOneModeler)this.getChild(typeof(FAllInOneModeler));
                if (fAllInOneModeler == null)
                {
                    fAllInOneModeler = new FAllInOneModeler(m_fSsmCore);
                    this.showChild(fAllInOneModeler);
                }
                fAllInOneModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAllInOneModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuOpenAllDevice(
            )
        {
            try
            {
                m_fSsmCore.fSsmFileInfo.fSecsDriver.openAllDevice();
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

        private void procMenuCloseAllDevice(
            )
        {
            try
            {
                m_fSsmCore.fSsmFileInfo.fSecsDriver.closeAllDevice();
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

        private void procMenuSecsBinaryLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // SECS Binary Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSsmCore.fUIWizard.generateMessage("Q0013", new object[] { "SECS Binary Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.fSecsDriver.cutBinaryLogFile();
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

        private void procMenuSmlLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // SML Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSsmCore.fUIWizard.generateMessage("Q0013", new object[] { "SML Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.fSecsDriver.cutSmlLogFile();
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

        private void procMenuVfeiLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // VFEI Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSsmCore.fUIWizard.generateMessage("Q0013", new object[] { "VFEI Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.fSecsDriver.cutVfeiLogFile();
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

        private void procMenuSecsLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // SECS Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSsmCore.fUIWizard.generateMessage("Q0013", new object[] { "SECS Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fSsmCore.fSsmFileInfo.fSecsDriver.cutSecsLogFile();
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

        private void procMenuSecsBinaryTracer(
            )
        {
            FSecsBinaryTracer fSecsBinaryTracer = null;

            try
            {   
                fSecsBinaryTracer = (FSecsBinaryTracer)this.getChild(typeof(FSecsBinaryTracer));
                if (fSecsBinaryTracer == null)
                {
                    fSecsBinaryTracer = new FSecsBinaryTracer(m_fSsmCore);
                    this.showChild(fSecsBinaryTracer);
                }
                fSecsBinaryTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecsBinaryTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSmlTracer(
            )
        {
            FSmlTracer fSmlTracer = null;

            try
            {
                fSmlTracer = (FSmlTracer)this.getChild(typeof(FSmlTracer));
                if (fSmlTracer == null)
                {
                    fSmlTracer = new FSmlTracer(m_fSsmCore);
                    this.showChild(fSmlTracer);
                }
                fSmlTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSmlTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuVfeiTracer(
            )
        {
            FVfeiTracer fVfeiTracer = null;

            try
            {
                fVfeiTracer = (FVfeiTracer)this.getChild(typeof(FVfeiTracer));
                if (fVfeiTracer == null)
                {
                    fVfeiTracer = new FVfeiTracer(m_fSsmCore);
                    this.showChild(fVfeiTracer);
                }
                fVfeiTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fVfeiTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuLogTracer(
            )
        {
            FTotalLogTracer fLogTracer = null;

            try
            {   
                fLogTracer = (FTotalLogTracer)this.getChild(typeof(FTotalLogTracer));
                if (fLogTracer == null)
                {
                    fLogTracer = new FTotalLogTracer(m_fSsmCore);
                    this.showChild(fLogTracer);
                }
                fLogTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuInterfaceTracer(
        //    )
        //{
        //    FInterfaceTracer fInterfaceTracer = null;

        //    try
        //    {
        //        fInterfaceTracer = (FInterfaceTracer)this.getChild(typeof(FInterfaceTracer));
        //        if (fInterfaceTracer == null)
        //        {
        //            fInterfaceTracer = new FInterfaceTracer(m_fSsmCore);
        //            this.showChild(fInterfaceTracer);
        //        }
        //        fInterfaceTracer.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fInterfaceTracer = null;
        //    }
        //}
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuVfeiViewer(
            )
        {
            FVfeiViewer fVfeiViewer= null;

            try
            {
                fVfeiViewer = (FVfeiViewer)this.getChild(typeof(FVfeiViewer));
                if (fVfeiViewer == null)
                {
                    fVfeiViewer = new FVfeiViewer(m_fSsmCore);
                    this.showChild(fVfeiViewer);
                }
                fVfeiViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fVfeiViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSmlViewer(
            )
        {
            FSmlViewer fSmlViewer = null;

            try
            {   
                fSmlViewer = (FSmlViewer)this.getChild(typeof(FSmlViewer));
                if (fSmlViewer == null)
                {
                    fSmlViewer = new FSmlViewer(m_fSsmCore);
                    this.showChild(fSmlViewer);
                }
                fSmlViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSmlViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRelationViewer(
            )
        {
            try
            {
                showRelationViewer(null);
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

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fSsmCore);
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
                this.closeAllChilds();
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
                fChildForm = (FBaseTabChildForm)m_fSsmCore.fOption.fChildFormList.getFormOfKey(key);
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
                dialog = new FFormSelector(m_fSsmCore);
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

        public void showRelationViewer(
            FIObject fObject
            )
        {
            try
            {
                if (m_fRelationViewer == null)
                {
                    m_fRelationViewer = new FRelationViewer(m_fSsmCore);
                    m_fRelationViewer.FormClosed += new FormClosedEventHandler(m_fRelationViewer_FormClosed);
                    // --
                    m_fRelationViewer.Show(this);
                }

                // --

                if (fObject != null)
                {
                    m_fRelationViewer.refresh(fObject);
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

        public void showGemInspector(
            FSecsLibrary fSecsLibrary
            )
        {
            FSecsLibraryGemInspector fGemInspector = null;

            try
            {
                fGemInspector = (FSecsLibraryGemInspector)this.getChild(typeof(FSecsLibraryGemInspector));
                if (fGemInspector == null)
                {
                    fGemInspector = new FSecsLibraryGemInspector(m_fSsmCore);
                    this.showChild(fGemInspector);
                }

                // --

                if (fSecsLibrary != null)
                {
                    fGemInspector.refresh(fSecsLibrary);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fGemInspector = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void gotoRelation(
            FIObject fObject
            )
        {   
            FFunctionNameDefinition fFunctionNameDefinition = null;
            FDataConversionSetDefinition fDataConversionSetDefinition = null;
            FEquipmentStateSetDefinition fEquipmentStateSetDefinition = null;
            FRepositoryDefinition fRepositoryDefinition = null;
            FEnvironmentDefinition fEnvironmentDefinition = null;
            FDataSetDefinition fDataSetDefinition = null;
            FSecsDeviceModeler fSecsDeviceModeler = null;
            FSecsLibraryModeler fSecsLibraryModeler = null;
            FHostDeviceModeler fHostDeviceModeler = null;
            FHostLibraryModeler fHostLibraryModeler = null;
            FEquipmentModeler fEquipmentModeler = null;

            try
            {
                if (!this.m_fSsmCore.fSsmFileInfo.fSecsDriver.containsObject(fObject))
                {
                    return;
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.SecsDevice ||
                    fObject.fObjectType == FObjectType.SecsSession
                    )
                {
                    fSecsDeviceModeler = (FSecsDeviceModeler)this.getChild(typeof(FSecsDeviceModeler));
                    if (fSecsDeviceModeler == null)
                    {
                        fSecsDeviceModeler = new FSecsDeviceModeler(m_fSsmCore);
                        this.showChild(fSecsDeviceModeler);
                    }
                    fSecsDeviceModeler.activate();

                    // --

                    fSecsDeviceModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fSecsDeviceModeler.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.SecsLibrary ||
                    fObject.fObjectType == FObjectType.SecsMessage ||
                    fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    fSecsLibraryModeler = (FSecsLibraryModeler)this.getChild(typeof(FSecsLibraryModeler));
                    if (fSecsLibraryModeler == null)
                    {
                        fSecsLibraryModeler = new FSecsLibraryModeler(m_fSsmCore);
                        this.showChild(fSecsLibraryModeler);
                    }
                    fSecsLibraryModeler.activate();

                    // --

                    fSecsLibraryModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fSecsLibraryModeler.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.HostDevice ||
                    fObject.fObjectType == FObjectType.HostSession
                    )
                {
                    fHostDeviceModeler = (FHostDeviceModeler)this.getChild(typeof(FHostDeviceModeler));
                    if (fHostDeviceModeler == null)
                    {
                        fHostDeviceModeler = new FHostDeviceModeler(m_fSsmCore);
                        this.showChild(fHostDeviceModeler);
                    }
                    fHostDeviceModeler.activate();

                    // --

                    fHostDeviceModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fHostDeviceModeler.searchObject(fObject);
                    }));

                }
                else if (
                    fObject.fObjectType == FObjectType.HostLibrary ||
                    fObject.fObjectType == FObjectType.HostMessage ||
                    fObject.fObjectType == FObjectType.HostItem
                    )
                {
                    fHostLibraryModeler = (FHostLibraryModeler)this.getChild(typeof(FHostLibraryModeler));
                    if (fHostLibraryModeler == null)
                    {
                        fHostLibraryModeler = new FHostLibraryModeler(m_fSsmCore);
                        this.showChild(fHostLibraryModeler);
                    }
                    fHostLibraryModeler.activate();

                    // --

                    fHostLibraryModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fHostLibraryModeler.searchObject(fObject);
                    }));
                }
                else if (fObject.fObjectType == FObjectType.Environment)
                {
                    fEnvironmentDefinition = (FEnvironmentDefinition)this.getChild(typeof(FEnvironmentDefinition));
                    if (fEnvironmentDefinition == null)
                    {
                        fEnvironmentDefinition = new FEnvironmentDefinition(m_fSsmCore);
                        this.showChild(fEnvironmentDefinition);
                    }
                    fEnvironmentDefinition.activate();

                    // --

                    fEnvironmentDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fEnvironmentDefinition.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.Repository ||
                    fObject.fObjectType == FObjectType.Column
                    )
                {
                    fRepositoryDefinition = (FRepositoryDefinition)this.getChild(typeof(FRepositoryDefinition));
                    if (fRepositoryDefinition == null)
                    {
                        fRepositoryDefinition = new FRepositoryDefinition(m_fSsmCore);
                        this.showChild(fRepositoryDefinition);
                    }
                    fRepositoryDefinition.activate();

                    // --

                    fRepositoryDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fRepositoryDefinition.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    fObject.fObjectType == FObjectType.EquipmentState ||
                    fObject.fObjectType == FObjectType.StateValue
                    )
                {
                    fEquipmentStateSetDefinition = (FEquipmentStateSetDefinition)this.getChild(typeof(FEquipmentStateSetDefinition));
                    if (fEquipmentStateSetDefinition == null)
                    {
                        fEquipmentStateSetDefinition = new FEquipmentStateSetDefinition(m_fSsmCore);
                        this.showChild(fEquipmentStateSetDefinition);
                    }
                    fEquipmentStateSetDefinition.activate();

                    // --

                    fEquipmentStateSetDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fEquipmentStateSetDefinition.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.DataSet ||
                    fObject.fObjectType == FObjectType.Data
                    )
                {
                    fDataSetDefinition = (FDataSetDefinition)this.getChild(typeof(FDataSetDefinition));
                    if (fDataSetDefinition == null)
                    {
                        fDataSetDefinition = new FDataSetDefinition(m_fSsmCore);
                        this.showChild(fDataSetDefinition);
                    }
                    fDataSetDefinition.activate();

                    // --

                    fDataSetDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fDataSetDefinition.searchObject(fObject);
                    }));
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    fDataConversionSetDefinition = (FDataConversionSetDefinition)this.getChild(typeof(FDataConversionSetDefinition));
                    if (fDataConversionSetDefinition == null)
                    {
                        fDataConversionSetDefinition = new FDataConversionSetDefinition(m_fSsmCore);
                        this.showChild(fDataConversionSetDefinition);
                    }
                    fDataConversionSetDefinition.activate();

                    // --

                    fDataConversionSetDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fDataConversionSetDefinition.searchObject(fObject);
                    }));
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    fFunctionNameDefinition = (FFunctionNameDefinition)this.getChild(typeof(FFunctionNameDefinition));
                    if (fFunctionNameDefinition == null)
                    {
                        fFunctionNameDefinition = new FFunctionNameDefinition(m_fSsmCore);
                        this.showChild(fFunctionNameDefinition);
                    }
                    fFunctionNameDefinition.activate();

                    // --

                    fFunctionNameDefinition.Invoke(new MethodInvoker(delegate()
                    {
                        fFunctionNameDefinition.searchObject(fObject);
                    }));
                }
                else if (fObject.fObjectType == FObjectType.Scenario)
                {
                    fEquipmentModeler = (FEquipmentModeler)this.getChild(typeof(FEquipmentModeler));
                    if (fEquipmentModeler == null)
                    {
                        fEquipmentModeler = new FEquipmentModeler(m_fSsmCore);
                        this.showChild(fEquipmentModeler);
                    }
                    fEquipmentModeler.activate();

                    // --

                    fEquipmentModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fEquipmentModeler.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.SecsTrigger ||
                    fObject.fObjectType == FObjectType.SecsCondition ||
                    fObject.fObjectType == FObjectType.SecsExpression ||
                    fObject.fObjectType == FObjectType.SecsTransmitter ||
                    fObject.fObjectType == FObjectType.SecsTransfer ||
                    fObject.fObjectType == FObjectType.HostTrigger ||
                    fObject.fObjectType == FObjectType.HostCondition ||
                    fObject.fObjectType == FObjectType.HostExpression ||
                    fObject.fObjectType == FObjectType.HostTransmitter ||
                    fObject.fObjectType == FObjectType.HostTransfer ||
                    fObject.fObjectType == FObjectType.Judgement ||
                    fObject.fObjectType == FObjectType.JudgementCondition ||
                    fObject.fObjectType == FObjectType.JudgementExpression ||
                    fObject.fObjectType == FObjectType.EquipmentStateSetAlterer ||
                    fObject.fObjectType == FObjectType.EquipmentStateAlterer ||
                    fObject.fObjectType == FObjectType.Mapper ||
                    fObject.fObjectType == FObjectType.Storage ||
                    fObject.fObjectType == FObjectType.Branch ||
                    fObject.fObjectType == FObjectType.Function
                    )
                {
                    fEquipmentModeler = (FEquipmentModeler)this.getChild(typeof(FEquipmentModeler));
                    if (fEquipmentModeler == null)
                    {
                        fEquipmentModeler = new FEquipmentModeler(m_fSsmCore);
                        this.showChild(fEquipmentModeler);
                    }
                    fEquipmentModeler.activate();

                    // --

                    fEquipmentModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fEquipmentModeler.searchFlow(fObject);
                    }));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {   
                fFunctionNameDefinition = null;
                fDataConversionSetDefinition = null;
                fEquipmentStateSetDefinition = null;
                fRepositoryDefinition = null;
                fEnvironmentDefinition = null;
                fDataSetDefinition = null;
                fSecsDeviceModeler = null;
                fSecsLibraryModeler = null;
                fHostDeviceModeler = null;
                fHostLibraryModeler = null;
                fEquipmentModeler = null;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FIObject searchParentObject(
            FIObject fBaseObject,
            FObjectType objectName
            )
        {
            try
            {
                if (fBaseObject.fObjectType == objectName)
                {
                    return fBaseObject;
                }
                else
                {
                    return searchParentObject(m_fSsmCore.fSsmFileInfo.fSecsDriver.getParentOfObject(fBaseObject), objectName);
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

        private string reduceFileName(
            string fileName
            )
        {
            string filePath = string.Empty;
            string dfileName = string.Empty;
            List<string> arrfilePath = null;

            try
            {
                if (fileName.Length > 40)
                {
                    arrfilePath = new List<string>((Path.GetDirectoryName(fileName)).Split('\\'));
                    arrfilePath.Reverse();
                    // --
                    dfileName = Path.GetFileName(fileName);
                    
                    // --

                    foreach (string tfilePath in arrfilePath)
                    {
                        if (dfileName.Length < 40)
                        {
                            dfileName = tfilePath + @"\" + dfileName;
                        }
                    }    
                    
                    // --
                    
                    return @"..\" + dfileName;
                }
                else
                {
                    return fileName;
                }                
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

                if (fileExtension == ".ssl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Ssl"];
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

        private bool containsMenu(
            string name
            )
        {
            const string MenuWinGroup = "WinGroup";

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!mnuMenu.Tools[MenuWinGroup + i.ToString()].SharedProps.Visible)
                    {
                        return false;
                    }
                    if (mnuMenu.Tools[MenuWinGroup + i.ToString()].SharedProps.CustomizerCaption == name)
                    {
                        return true;
                    }
                }
                return false;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSsmContainer Form Event Handler

        private void FSsmContainer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                mnuMenu.ImageListSmall = new ImageList();
                // --
                mnuMenu.ImageListSmall.Images.Add("File_Ssm", Properties.Resources.File_Ssm);
                mnuMenu.ImageListSmall.Images.Add("File_Ssl", Properties.Resources.File_Ssl);
                mnuMenu.ImageListSmall.Images.Add("File_Sml", Properties.Resources.File_Sml);
                mnuMenu.ImageListSmall.Images.Add("File_Vfe", Properties.Resources.File_Vfe);
                mnuMenu.ImageListSmall.Images.Add("File_Bng", Properties.Resources.File_Bng);
                
                // --

                m_fSsmCore.ModelingFileModified += new FModelingFileModifiedEventHandler(m_fSsmCore_ModelingFileModified);
            }
            catch (Exception ex)
            {               
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_Shown(
           object sender,
           EventArgs e
           )
        {
            FProgress fProgress = null;
            string ext = string.Empty;

            try
            {

                fProgress = new FProgress();
                fProgress.show(this);

                // --

                if (m_fileName != string.Empty)
                {
                    ext = Path.GetExtension(m_fileName).ToLower();
                    if (ext == ".ssm")
                    {
                        // ***
                        // 외부 .ssm File 열기 처리
                        // ***
                        loadLibFile(m_fileName);
                    }
                    else if (ext == ".ssl")
                    {
                        // ***
                        // 외부 .ssl File 열기 처리
                        // ***
                        loadLogFile(m_fileName);
                    }
                    
                }
                else
                {
                    // ***
                    // SECS Modeler 기본 실행과 Modeling File Clone 처리
                    // ***
                    if (!m_fSsmCore.fSsmFileInfo.isClosedFile)
                    {
                        // showDefaultModeler();
                    }

                    // --

                    setTitle();
                    controlMainMenu();
                    setMainStatusBar();
                }                
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_fRelationViewer != null && !m_fRelationViewer.Visible)
                {
                    m_fRelationViewer.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fSsmCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_Leave(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                if (m_fRelationViewer != null && m_fRelationViewer.Visible)
                {
                    m_fRelationViewer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_FormCloseConfirm(
            object sender, 
            FFormCloseConfirmEventArgs e
            )
        {
            try
            {
                if (!confirmSave())
                {
                    e.cancel = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSsmContainer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                // ***
                // Device All Close
                // ***
                if (m_fSsmCore.fSsmFileInfo.fSecsDriver != null)
                {
                    m_fSsmCore.fSsmFileInfo.fSecsDriver.closeAllDevice();
                }

                // --

                if (m_fRelationViewer != null)
                {
                    m_fRelationViewer.Close();
                    m_fRelationViewer = null;
                }

                // --

                m_fSsmCore.fWsmCore.onMainStatusBarChanged(true);                
                // --
                if (m_fSsmCore != null)
                {
                    m_fSsmCore.ModelingFileModified -= new FModelingFileModifiedEventHandler(m_fSsmCore_ModelingFileModified);
                    // --
                    m_fSsmCore.Dispose();
                    m_fSsmCore = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
            PopupMenuTool popMenuTool = null;

            try
            {
                FCursor.waitCursor();

                // --

                mnuMenu.beginUpdate();

                // --

                if (e.Tool.Key == FMenuKey.MenuFile)
                {
                    popMenuTool = (PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuRecentLibrary];
                    popMenuTool.Tools.Clear();
                    // --
                    foreach (string s in m_fSsmCore.fOption.libRecentFileList)
                    {
                        if (!mnuMenu.Tools.Exists(s))
                        {
                            mnuMenu.Tools.Add(new ButtonTool(s));
                        }
                        mnuTool = mnuMenu.Tools[s];
                        mnuTool.SharedProps.Caption = reduceFileName(s);
                        mnuTool.SharedProps.AppearancesSmall.Appearance.Image = mnuMenu.ImageListSmall.Images["File_Ssm"];
                        popMenuTool.Tools.AddTool(s);
                    }
                    // --
                    popMenuTool.SharedProps.Enabled = popMenuTool.Tools.Count > 0 ? true : false;

                    // --

                    popMenuTool = (PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuRecentLog];
                    popMenuTool.Tools.Clear();
                    // --
                    foreach (string s in m_fSsmCore.fOption.logRecentFileList)
                    {
                        if (!mnuMenu.Tools.Exists(s))
                        {
                            mnuMenu.Tools.Add(new ButtonTool(s));
                        }
                        mnuTool = mnuMenu.Tools[s];
                        mnuTool.SharedProps.Caption = reduceFileName(s);
                        mnuTool.SharedProps.AppearancesSmall.Appearance.Image = getImageOfLog(s);
                        popMenuTool.Tools.AddTool(s);
                    }
                    // --
                    popMenuTool.SharedProps.Enabled = popMenuTool.Tools.Count > 0 ? true : false;
                }
                else if (e.Tool.Key == FMenuKey.MenuWindow)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        mnuMenu.Tools[MenuWinWindow + i.ToString()].SharedProps.Visible = false;
                    }
                    mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = false;

                    // --

                    // ***
                    // Control Window List
                    // ***
                    for (int i = 0; i < 10; i++)
                    {
                        if (i >= m_fSsmCore.fOption.fChildFormList.count)
                        {
                            break;
                        }

                        // --

                        mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                        mnuTool.SharedProps.Tag = m_fSsmCore.fOption.fChildFormList.getKeyOfIndex(i);
                        mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard.searchCaption(m_fSsmCore.fOption.fChildFormList.getTextOfIndex(i));
                        mnuTool.SharedProps.Visible = true;
                    }                    

                    // --

                    if (m_fSsmCore.fOption.fChildFormList.count > 10)
                    {
                        mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                    }
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                mnuTool = null;
                popMenuTool = null;
                // --
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

                if (e.Tool.Key == FMenuKey.MenuNew)
                {
                    procMenuNew();
                }
                else if (e.Tool.Key == FMenuKey.MenuOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuClose)
                {
                    procMenuClose();
                }
                else if (e.Tool.Key == FMenuKey.MenuClone)
                {
                    procMenuClone();
                }
                else if (e.Tool.Key == FMenuKey.MenuSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuOption)
                {
                    procMenuOption();
                }
                else if (e.Tool.Key == FMenuKey.MenuExport)
                {
                    procMenuExport();
                }
                else if (e.Tool.Key == FMenuKey.MenuExit)
                {
                    this.Close();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuObjectNameDefinition)
                {
                    procMenuObjectNameDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuFunctionNameDefinition)
                {
                    procMenuFunctionNameDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuUserTagNameDefinition)
                {
                    procMenuUserTagNameDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuDataConversionSetDefinition)
                {
                    procMenuDataConversionSetDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentStateSetDefinition)
                {
                    procMenuEquipmentStateSetDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuRepositoryDefinition)
                {
                    procMenuRepositoryDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuEnvironmentDefinition)
                {
                    procMenuMenuEnvironmentDefinition();
                }
                else if (e.Tool.Key == FMenuKey.MenuDataSetDefinition)
                {
                    procMenuDataSetDefinition();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSecsLibraryModeler)
                {
                    procMenuSecsLibraryModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsDeviceModeler)
                {
                    procMenuSecsDeviceModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuHostLibraryModeler)
                {
                    procMenuHostLibraryModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuHostDeviceModeler)
                {
                    procMenuHostDeviceModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuEquipmentModeler)
                {
                    procMenuEquipmentModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuAllInOneModeler)
                {
                    procMenuAllInOneModeler();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuOpenAllDevice)
                {
                    procMenuOpenAllDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuCloseAllDevice)
                {
                    procMenuCloseAllDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsBinaryLogCut)
                {
                    procMenuSecsBinaryLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSmlLogCut)
                {
                    procMenuSmlLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeiLogCut)
                {
                    procMenuVfeiLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecsLogCut)
                {
                    procMenuSecsLogCut();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSecsBinaryTracer)
                {
                    procMenuSecsBinaryTracer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSmlTracer)
                {
                    procMenuSmlTracer();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeiTracer)
                {
                    procMenuVfeiTracer();
                }
                else if (e.Tool.Key == FMenuKey.MenuLogTracer)
                {
                    procMenuLogTracer();
                }
                else if (e.Tool.Key == FMenuKey.MenuInterfaceTracer)
                {
                    //procMenuInterfaceTracer();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuVfeiViewer)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSmlViewer)
                {
                    procMenuSmlViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuRelationViewer)
                {
                    procMenuRelationViewer();
                }

                // --

                // ***
                // Window
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
                // Recent File
                // ***
                else if (Path.GetExtension(e.Tool.Key) == ".ssm")
                {
                    procMenuRecentLibFile(e.Tool.Key);
                }
                else
                {
                    procMenuRecentLogFile(e.Tool.Key);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }       

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fSsmCore Object Event Handler

        private void m_fSsmCore_ModelingFileModified(
            object sender, 
            FModelingFileModifiedEventArgs e
            )
        {
            try
            {
                setTitle();
                controlMainMenu();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion       

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fRelationViewer Form Event Handler

        private void m_fRelationViewer_FormClosed(
            object sender, 
            FormClosedEventArgs e
            )
        {
            try
            {
                m_fRelationViewer.FormClosed -= new FormClosedEventHandler(m_fRelationViewer_FormClosed);
                m_fRelationViewer = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
