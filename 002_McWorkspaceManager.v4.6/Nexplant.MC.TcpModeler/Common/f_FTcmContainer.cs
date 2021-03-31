/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcmContainer.cs
--  Creator         : Jeff.kim
--  Create Date     : 2013.07.10
--  Description     : FAMate TCP Modeler Container Form Class 
--  History         : Created by Jeff.Kim at 2013.07.10
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcmContainer : Nexplant.MC.Core.FaUIs.FBaseTabMdiChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_fileName = string.Empty;

        // --

        private FTcmCore m_fTcmCore = null;
        private FRelationViewer m_fRelationViewer = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcmContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcmContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fTcmCore = new FTcmCore(fWsmCore, this);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcmContainer(
            FIWsmCore fWsmCore,
            FTcpDriver fTcpDriver
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fTcmCore = new FTcmCore(fWsmCore, this, fTcpDriver);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcmContainer(
            FIWsmCore fWsmCore,
            string fileName
            )           
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fTcmCore = new FTcmCore(fWsmCore, this);            
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
                    if (m_fTcmCore != null)
                    {
                        m_fTcmCore.Dispose();
                        m_fTcmCore = null;

                        // --
                        m_fRelationViewer = null;
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
                appName = m_fTcmCore.fWsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                // --
                if (m_fTcmCore.fTcmFileInfo.isClosedFile)
                {
                    this.Text = appName;
                }
                else
                {
                    this.Text = appName + " - [" + m_fTcmCore.fTcmFileInfo.fileName + (m_fTcmCore.fTcmFileInfo.isModifiedFile ? "*" : "") + "]";
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
                caption = m_fTcmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                if (!m_fTcmCore.fTcmFileInfo.isClosedFile)
                {
                    caption += " - [" + m_fTcmCore.fTcmFileInfo.fileFullName + (m_fTcmCore.fTcmFileInfo.isModifiedFile ? "*" : "") + "]";
                }
                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }


                // --

                m_fTcmCore.fWsmCore.onMainStatusBarChanged(
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
                mnuMenu.Tools[FMenuKey.MenuClose].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuClone].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuSave].SharedProps.Enabled = m_fTcmCore.fTcmFileInfo.isNewFile | m_fTcmCore.fTcmFileInfo.isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuSaveAs].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuRecentLibrary].SharedProps.Enabled = true;
                mnuMenu.Tools[FMenuKey.MenuRecentLog].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuExport].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuOption].SharedProps.Enabled = true;
                // --
                mnuMenu.Tools[FMenuKey.MenuExit].SharedProps.Enabled = true;

                // --     

                // ***
                // Setup Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuObjectNameDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuFunctionNameDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuUserTagNameDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuDataConversionSetDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEquipmentStateSetDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuRepositoryDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEnvironmentDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuDataSetDefinition].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;

                // --

                // ***
                // Modeling Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuTcpLibraryModeler].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuTcpDeviceModeler].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuHostLibraryModeler].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuHostDeviceModeler].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEquipmentModeler].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;

                // ***
                // Tool
                // ***
                mnuMenu.Tools[FMenuKey.MenuOpenAllDevice].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuCloseAllDevice].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuTcpBinaryLogCut].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile && m_fTcmCore.fOption.enabledLogOfBinary;
                mnuMenu.Tools[FMenuKey.MenuXlgLogCut].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile && m_fTcmCore.fOption.enabledLogOfXlg;
                mnuMenu.Tools[FMenuKey.MenuVfeiLogCut].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile && m_fTcmCore.fOption.enabledLogOfVfei;
                mnuMenu.Tools[FMenuKey.MenuTcpLogCut].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile && m_fTcmCore.fOption.enabledLogOfTcp;


                // ***
                // Tracer Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuTcpBinaryTracer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuXlgTracer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuVfeiTracer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuLogTracer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                //mnuMenu.Tools[FMenuKey.MenuInterfaceTracer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuInterfaceTracer].SharedProps.Visible = false;

                // ***
                // View Menu
                // ***                
                mnuMenu.Tools[FMenuKey.MenuXlgViewer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuVfeiViewer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuRelationViewer].SharedProps.Enabled = !m_fTcmCore.fTcmFileInfo.isClosedFile;

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
                if (m_fTcmCore.fOption.libRecentFileList.Contains(fileName))
                {
                    m_fTcmCore.fOption.libRecentFileList.Remove(fileName);
                }
                else if (m_fTcmCore.fOption.libRecentFileList.Count == FConstants.RecentMaxCount)
                {
                    m_fTcmCore.fOption.libRecentFileList.RemoveAt(m_fTcmCore.fOption.libRecentFileList.Count - 1);
                }
                m_fTcmCore.fOption.libRecentFileList.Insert(0, fileName);

                // --

                m_fTcmCore.fWsmOption.recentFile = fileName;
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

                if (fileExtension == ".tsl")
                {
                    return mnuMenu.ImageListSmall.Images["File_Tsl"];
                }
                else if (fileExtension == ".vfe")
                {
                    return mnuMenu.ImageListSmall.Images["File_Vfe"];
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

        private bool confirmSave(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // Modeling File Save Confirm
                // ***
                if (m_fTcmCore.fTcmFileInfo.isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { m_fTcmCore.fTcmFileInfo.fileName }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fTcmCore.fWsmCore.fWsmContainer
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
                if (!this.closeAllChilds())
                {
                    return;
                }

                // --

                m_fTcmCore.fTcmFileInfo.openFile(fileName);

                // --

                m_fTcmCore.fOption.libRecentOpenPath = Path.GetDirectoryName(fileName);
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
                    fLogTracer = new FTotalLogTracer(m_fTcmCore);
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
                m_fTcmCore.fTcmFileInfo.saveFile(fileName);

                // --

                m_fTcmCore.fOption.libRecentSavePath = Path.GetDirectoryName(fileName);
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

                m_fTcmCore.fTcmFileInfo.newFile();
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
                dialog.Title = fUIWizard.searchCaption("Open TCP Modeling File");
                dialog.Filter = "TCP Modeling Files | *.tsm";
                dialog.DefaultExt = "tsm";
                dialog.InitialDirectory = m_fTcmCore.fOption.libRecentOpenPath;
                // --
                if (dialog.ShowDialog(m_fTcmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
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

                m_fTcmCore.fTcmFileInfo.closeFile();

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
                m_fTcmCore.fWsmCore.fWsmContainer.showTabMdiChild(
                    new FTcmContainer(m_fTcmCore.fWsmCore, this.m_fTcmCore.fTcmFileInfo.fTcpDriver.cloneTcpDriver())
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
                if (m_fTcmCore.fTcmFileInfo.isNewFile)
                {
                    return procMenuSaveAs();
                }

                // --

                saveLibFile(m_fTcmCore.fTcmFileInfo.fileFullName);

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
                dialog.Title = fUIWizard.searchCaption("Save As TCP Modeling File");
                dialog.Filter = "TCP Modeling Files | *.tsm";
                dialog.DefaultExt = "tsm";
                
                // --
                
                if (m_fTcmCore.fTcmFileInfo.isNewFile)
                {
                    dialog.InitialDirectory = m_fTcmCore.fOption.libRecentSavePath;
                }
                else
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(m_fTcmCore.fTcmFileInfo.fileFullName);
                }
                dialog.FileName = m_fTcmCore.fTcmFileInfo.fileName;
                // --
                if (dialog.ShowDialog(m_fTcmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
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

                if (!File.Exists(fileName))
                {
                    FMessageBox.showError(
                        FConstants.ApplicationName,
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0010", new object[] { fileName }),
                        m_fTcmCore.fWsmCore.fWsmContainer
                        );
                    // --
                    if (m_fTcmCore.fOption.libRecentFileList.Contains(fileName))
                    {
                        m_fTcmCore.fOption.libRecentFileList.Remove(fileName);
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

        ////------------------------------------------------------------------------------------------------------------------------

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
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0010", new object[] { fileName }),
                        m_fTcmCore.fWsmCore.fWsmContainer
                        );
                    // --
                    if (m_fTcmCore.fOption.logRecentFileList.Contains(fileName))
                    {
                        m_fTcmCore.fOption.logRecentFileList.Remove(fileName);
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
                dialog = new FOptionDialog(this.m_fTcmCore);
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
                dialog = new FExportDialog(this.m_fTcmCore);
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
                    fObjectNameDefinition = new FObjectNameDefinition(m_fTcmCore);
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
                    fFunctionNameDefinition = new FFunctionNameDefinition(m_fTcmCore);
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
                    fUserTagNameDefinition = new FUserTagNameDefinition(m_fTcmCore);
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
                    fDataConversionSetDefinition = new FDataConversionSetDefinition(m_fTcmCore);
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
                    fEquipmentStateSetDefinition = new FEquipmentStateSetDefinition(m_fTcmCore);
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
                    fRepositoryDefinition = new FRepositoryDefinition(m_fTcmCore);
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
                    fEnvironmentDefinition = new FEnvironmentDefinition(m_fTcmCore);
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
                    fDataSetDefinition = new FDataSetDefinition(m_fTcmCore);
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

        private void procMenuTcpLibraryModeler(
            )
        {
            FTcpLibraryModeler fTcpLibraryModeler = null;

            try
            {
                fTcpLibraryModeler = (FTcpLibraryModeler)this.getChild(typeof(FTcpLibraryModeler));
                if (fTcpLibraryModeler == null)
                {
                    fTcpLibraryModeler = new FTcpLibraryModeler(m_fTcmCore);
                    this.showChild(fTcpLibraryModeler);
                }
                fTcpLibraryModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpLibraryModeler = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuTcpDeviceModeler(
            )
        {
            FTcpDeviceModeler fTcpDeviceModeler = null;

            try
            {
                fTcpDeviceModeler = (FTcpDeviceModeler)this.getChild(typeof(FTcpDeviceModeler));
                if (fTcpDeviceModeler == null)
                {
                    fTcpDeviceModeler = new FTcpDeviceModeler(m_fTcmCore);
                    this.showChild(fTcpDeviceModeler);
                }
                fTcpDeviceModeler.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpDeviceModeler = null;
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
                    fHostLibraryModeler = new FHostLibraryModeler(m_fTcmCore);
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
                    fHostDeviceModeler = new FHostDeviceModeler(m_fTcmCore);
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
                    fEquipmentModeler = new FEquipmentModeler(m_fTcmCore);
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

        private void procMenuOpenAllDevice(
            )
        {
            try
            {
                m_fTcmCore.fTcmFileInfo.fTcpDriver.openAllDevice();
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
                m_fTcmCore.fTcmFileInfo.fTcpDriver.closeAllDevice();
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

        private void procMenuTcpBinaryLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // TCP Binary Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fTcmCore.fUIWizard.generateMessage("Q0013", new object[] { "TCP Binary Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fTcmCore.fTcmFileInfo.fTcpDriver.cutTcpBinaryLogFile();
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

        private void procMenuXlgLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // XLG Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fTcmCore.fUIWizard.generateMessage("Q0013", new object[] { "XLG Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fTcmCore.fTcmFileInfo.fTcpDriver.cutXmlLogFile();
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
                    m_fTcmCore.fUIWizard.generateMessage("Q0013", new object[] { "VFEI Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fTcmCore.fTcmFileInfo.fTcpDriver.cutVfeiLogFile();
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

        private void procMenuTcpLogCut(
            )
        {
            DialogResult dialogResult;

            try
            {
                // ***
                // TCP Log Cut Confirm
                // ***                
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fTcmCore.fUIWizard.generateMessage("Q0013", new object[] { "TCP Log" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                m_fTcmCore.fTcmFileInfo.fTcpDriver.cutTcpLogFile();
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

        private void procMenuTcpBinaryTracer(
            )
        {
            FTcpBinaryTracer fTcpBinaryTracer = null;

            try
            {                
                fTcpBinaryTracer = (FTcpBinaryTracer)this.getChild(typeof(FTcpBinaryTracer));
                if (fTcpBinaryTracer == null)
                {
                    fTcpBinaryTracer = new FTcpBinaryTracer(m_fTcmCore);
                    this.showChild(fTcpBinaryTracer);
                }
                fTcpBinaryTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fTcpBinaryTracer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuXlgTracer(
            )
        {
            FXlgTracer fXlgTracer = null;

            try
            {
                fXlgTracer = (FXlgTracer)this.getChild(typeof(FXlgTracer));
                if (fXlgTracer == null)
                {
                    fXlgTracer = new FXlgTracer(m_fTcmCore);
                    this.showChild(fXlgTracer);
                }
                fXlgTracer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXlgTracer = null;
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
                    fVfeiTracer = new FVfeiTracer(m_fTcmCore);
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
                    fLogTracer = new FTotalLogTracer(m_fTcmCore);
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
        //    FInterfaceTracer fIfTracer = null;

        //    try
        //    {
        //        fIfTracer = (FInterfaceTracer)this.getChild(typeof(FInterfaceTracer));
        //        if (fIfTracer == null)
        //        {
        //            fIfTracer = new FInterfaceTracer(m_fTcmCore);
        //            this.showChild(fIfTracer);
        //        }
        //        fIfTracer.activate();
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fIfTracer = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuXlgViewer(
            )
        {
            FXlgViewer fXlgViewer = null;

            try
            {
                fXlgViewer = (FXlgViewer)this.getChild(typeof(FXlgViewer));
                if (fXlgViewer == null)
                {
                    fXlgViewer = new FXlgViewer(m_fTcmCore);
                    this.showChild(fXlgViewer);
                }
                fXlgViewer.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXlgViewer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuVfeiViewer(
            )
        {
            FVfeiViewer fVfeiViewer = null;

            try
            {
                fVfeiViewer = (FVfeiViewer)this.getChild(typeof(FVfeiViewer));
                if (fVfeiViewer == null)
                {
                    fVfeiViewer = new FVfeiViewer(m_fTcmCore);
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
                fAbout = new FAbout(m_fTcmCore);
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
                fChildForm = (FBaseTabChildForm)m_fTcmCore.fOption.fChildFormList.getFormOfKey(key);
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
                dialog = new FFormSelector(m_fTcmCore);
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
                    m_fRelationViewer = new FRelationViewer(m_fTcmCore);
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
            FTcpDeviceModeler fTcpDeviceModeler = null;
            FTcpLibraryModeler fTcpLibraryModeler = null;
            FHostDeviceModeler fHostDeviceModeler = null;
            FHostLibraryModeler fHostLibraryModeler = null;
            FEquipmentModeler fEquipmentModeler = null;

            try
            {
                if (!this.m_fTcmCore.fTcmFileInfo.fTcpDriver.containsObject(fObject))
                {
                    return;
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.TcpDevice ||
                    fObject.fObjectType == FObjectType.TcpSession
                    )
                {
                    fTcpDeviceModeler = (FTcpDeviceModeler)this.getChild(typeof(FTcpDeviceModeler));
                    if (fTcpDeviceModeler == null)
                    {
                        fTcpDeviceModeler = new FTcpDeviceModeler(m_fTcmCore);
                        this.showChild(fTcpDeviceModeler);
                    }
                    fTcpDeviceModeler.activate();

                    // --

                    fTcpDeviceModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fTcpDeviceModeler.searchObject(fObject);
                    }));
                }
                else if (
                    fObject.fObjectType == FObjectType.TcpLibrary ||
                    fObject.fObjectType == FObjectType.TcpMessage ||
                    fObject.fObjectType == FObjectType.TcpItem
                    )
                {
                    fTcpLibraryModeler = (FTcpLibraryModeler)this.getChild(typeof(FTcpLibraryModeler));
                    if (fTcpLibraryModeler == null)
                    {
                        fTcpLibraryModeler = new FTcpLibraryModeler(m_fTcmCore);
                        this.showChild(fTcpLibraryModeler);
                    }
                    fTcpLibraryModeler.activate();

                    // --

                    fTcpLibraryModeler.Invoke(new MethodInvoker(delegate()
                    {
                        fTcpLibraryModeler.searchObject(fObject);
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
                        fHostDeviceModeler = new FHostDeviceModeler(m_fTcmCore);
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
                        fHostLibraryModeler = new FHostLibraryModeler(m_fTcmCore);
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
                        fEnvironmentDefinition = new FEnvironmentDefinition(m_fTcmCore);
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
                        fRepositoryDefinition = new FRepositoryDefinition(m_fTcmCore);
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
                        fEquipmentStateSetDefinition = new FEquipmentStateSetDefinition(m_fTcmCore);
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
                        fDataSetDefinition = new FDataSetDefinition(m_fTcmCore);
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
                        fDataConversionSetDefinition = new FDataConversionSetDefinition(m_fTcmCore);
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
                        fFunctionNameDefinition = new FFunctionNameDefinition(m_fTcmCore);
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
                        fEquipmentModeler = new FEquipmentModeler(m_fTcmCore);
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
                    fObject.fObjectType == FObjectType.TcpTrigger ||
                    fObject.fObjectType == FObjectType.TcpCondition ||
                    fObject.fObjectType == FObjectType.TcpExpression ||
                    fObject.fObjectType == FObjectType.TcpTransmitter ||
                    fObject.fObjectType == FObjectType.TcpTransfer ||
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
                        fEquipmentModeler = new FEquipmentModeler(m_fTcmCore);
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
                fTcpDeviceModeler = null;
                fTcpLibraryModeler = null;
                fHostDeviceModeler = null;
                fHostLibraryModeler = null;
                fEquipmentModeler = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FTcmContainer Form Event Handler

        private void FTcmContainer_Load(
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
                mnuMenu.ImageListSmall.Images.Add("File_Tsm", Properties.Resources.File_Tsm);
                mnuMenu.ImageListSmall.Images.Add("File_Tsl", Properties.Resources.File_Tsl);
                mnuMenu.ImageListSmall.Images.Add("File_Vfe", Properties.Resources.File_Vfe);
                mnuMenu.ImageListSmall.Images.Add("File_Bng", Properties.Resources.File_Bng);

                // --

                m_fTcmCore.ModelingFileModified += new FModelingFileModifiedEventHandler(m_fTcmCore_ModelingFileModified);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcmContainer_Shown(
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
                    if (ext == ".tsm")
                    {
                        // ***
                        // 외부 .tsm File 열기 처리
                        // ***
                        loadLibFile(m_fileName);
                    }
                    else if (ext == ".tsl")
                    {
                        // ***
                        // 외부 .tsl File 열기 처리
                        // ***
                        loadLogFile(m_fileName);
                    }
                    
                }
                else
                {
                    // ***
                    // TCP Modeler 기본 실행과 Modeling File Clone 처리
                    // ***
                    if (!m_fTcmCore.fTcmFileInfo.isClosedFile)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

        private void FTcmContainer_Enter(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcmContainer_Activated(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fTcmCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcmContainer_Leave(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcmContainer_FormCloseConfirm(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTcmContainer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                // ***
                // Device All Close
                // ***
                if (m_fTcmCore.fTcmFileInfo.fTcpDriver != null)
                {
                    m_fTcmCore.fTcmFileInfo.fTcpDriver.closeAllDevice();
                }

                // --

                if (m_fRelationViewer != null)
                {
                    m_fRelationViewer.Close();
                    m_fRelationViewer = null;
                }

                // --

                m_fTcmCore.fWsmCore.onMainStatusBarChanged(true);
                // --
                if (m_fTcmCore != null)
                {
                    m_fTcmCore.ModelingFileModified -= new FModelingFileModifiedEventHandler(m_fTcmCore_ModelingFileModified);
                    // --
                    m_fTcmCore.Dispose();
                    m_fTcmCore = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    foreach (string s in m_fTcmCore.fOption.libRecentFileList)
                    {
                        if (!mnuMenu.Tools.Exists(s))
                        {
                            mnuMenu.Tools.Add(new ButtonTool(s));
                        }
                        mnuTool = mnuMenu.Tools[s];
                        mnuTool.SharedProps.Caption = reduceFileName(s);
                        mnuTool.SharedProps.AppearancesSmall.Appearance.Image = mnuMenu.ImageListSmall.Images["File_Tsm"];
                        popMenuTool.Tools.AddTool(s);
                    }
                    // --
                    popMenuTool.SharedProps.Enabled = popMenuTool.Tools.Count > 0 ? true : false;

                    // --

                    popMenuTool = (PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuRecentLog];
                    popMenuTool.Tools.Clear();
                    // --
                    foreach (string s in m_fTcmCore.fOption.logRecentFileList)
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
                        if (i >= m_fTcmCore.fOption.fChildFormList.count)
                        {
                            break;
                        }

                        // --

                        mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                        mnuTool.SharedProps.Tag = m_fTcmCore.fOption.fChildFormList.getKeyOfIndex(i);
                        mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " + fUIWizard.searchCaption(m_fTcmCore.fOption.fChildFormList.getTextOfIndex(i));
                        mnuTool.SharedProps.Visible = true;
                    }                    

                    // --

                    if (m_fTcmCore.fOption.fChildFormList.count > 10)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                else if (e.Tool.Key == FMenuKey.MenuTcpLibraryModeler)
                {
                    procMenuTcpLibraryModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpDeviceModeler)
                {
                    procMenuTcpDeviceModeler();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuHostLibraryModeler)
                {
                    procMenuHostLibraryModeler();
                }
                else if (e.Tool.Key == FMenuKey.MenuHostDeviceModeler)
                {
                    procMenuHostDeviceModeler();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuEquipmentModeler)
                {
                    procMenuEquipmentModeler();
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
                else if (e.Tool.Key == FMenuKey.MenuTcpBinaryLogCut)
                {
                    procMenuTcpBinaryLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlgLogCut)
                {
                    procMenuXlgLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeiLogCut)
                {
                    procMenuVfeiLogCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuTcpLogCut)
                {
                    procMenuTcpLogCut();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuTcpBinaryTracer)
                {
                    procMenuTcpBinaryTracer();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlgTracer)
                {
                    procMenuXlgTracer();
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
                else if (e.Tool.Key == FMenuKey.MenuXlgViewer)
                {
                    procMenuXlgViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeiViewer)
                {
                    procMenuVfeiViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuRelationViewer)
                {
                    procMenuRelationViewer();
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
                // Recent File
                // ***
                else if (Path.GetExtension(e.Tool.Key) == ".tsm")
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fTcmCore Object Event Handler

        private void m_fTcmCore_ModelingFileModified(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion   
        
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
