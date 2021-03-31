/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLfeContainer.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.30
--  Description     : FAMate Language File Editor Container Form Class 
--  History         : Created by spike.lee at 2010.12.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.LanguageFileEditor
{
    public partial class FLfeContainer : FBaseTabMdiChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLfeCore m_fLfeCore = null;
        private FCaptionEditor m_fCaptionEditor = null;
        private FMessageEditor m_fMessageEditor = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLfeContainer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLfeContainer(
            FIWsmCore fWsmCore
            )
            : this()
        {
            base.fUIWizard = fWsmCore.fUIWizard;
            m_fLfeCore = new FLfeCore(fWsmCore, this);
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
                    if (m_fLfeCore != null)
                    {
                        m_fLfeCore.Dispose();
                        m_fLfeCore = null;
                    }
                    if (m_fCaptionEditor != null)
                    {
                        m_fCaptionEditor.Dispose();
                        m_fCaptionEditor = null;
                    }
                    if (m_fMessageEditor != null)
                    {
                        m_fMessageEditor.Dispose();
                        m_fCaptionEditor = null;
                    }
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        private bool canExport
        {
            get
            {
                try
                {
                    if (
                        m_fCaptionEditor != null &&
                        m_fMessageEditor != null &&
                        !m_fLfeCore.fLfeFileInfo.isClosedFile
                        )
                    {
                        return true;
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
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string appName = string.Empty;

            try
            {
                appName = m_fLfeCore.fWsmCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                // --
                if (m_fLfeCore.fLfeFileInfo.isClosedFile)
                {
                    this.Text = appName;
                }
                else
                {
                    this.Text = appName + " - [" + m_fLfeCore.fLfeFileInfo.fileName + (m_fLfeCore.fLfeFileInfo.isModifiedFile ? "*" : "") + "]";
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
            string caption = string.Empty;
            string version = string.Empty;
            System.Reflection.Assembly assembly = null;

            try
            {
                caption = m_fLfeCore.fUIWizard.searchCaption(FConstants.ApplicationName);
                if (!m_fLfeCore.fLfeFileInfo.isClosedFile)
                {
                    caption += " - [" + m_fLfeCore.fLfeFileInfo.fileFullName + (m_fLfeCore.fLfeFileInfo.isModifiedFile ? "*" : "") + "]";
                }

                // --

                assembly = System.Reflection.Assembly.GetCallingAssembly();
                if (assembly != null)
                {
                    version = assembly.GetName().Version.ToString();
                }

                // --

                m_fLfeCore.fWsmCore.onMainStatusBarChanged(
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

        private void controlMainMenu(
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
                mnuMenu.Tools[FMenuKey.MenuClose].SharedProps.Enabled = !m_fLfeCore.fLfeFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuSave].SharedProps.Enabled = m_fLfeCore.fLfeFileInfo.isNewFile | m_fLfeCore.fLfeFileInfo.isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuSaveAs].SharedProps.Enabled = !m_fLfeCore.fLfeFileInfo.isClosedFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuExit].SharedProps.Enabled = true;

                // --

                // ***
                // Edit Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuEditCaption].SharedProps.Enabled = !m_fLfeCore.fLfeFileInfo.isClosedFile;
                mnuMenu.Tools[FMenuKey.MenuEditMessage].SharedProps.Enabled = !m_fLfeCore.fLfeFileInfo.isClosedFile;

                // --

                // ***
                // Tool Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuExport].SharedProps.Enabled = this.canExport;
                mnuMenu.Tools[FMenuKey.MenuImport].SharedProps.Enabled = this.canExport;

                // --

                // ***
                // Help Menu
                // ***
                mnuMenu.Tools[FMenuKey.MenuAbout].SharedProps.Enabled = true;

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

        private void showDefaultEditor(
            )
        {   
            try
            {   
                m_fCaptionEditor = new FCaptionEditor(m_fLfeCore);                
                m_fMessageEditor = new FMessageEditor(m_fLfeCore);
                // --
                m_fCaptionEditor.FormClosed += new FormClosedEventHandler(m_fCaptionEditor_FormClosed);
                m_fMessageEditor.FormClosed += new FormClosedEventHandler(m_fMessageEditor_FormClosed);
                // --
                this.showChild(m_fCaptionEditor);
                this.showChild(m_fMessageEditor);
                // --                
                m_fCaptionEditor.activate();
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
                if (m_fLfeCore.fLfeFileInfo.isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fLfeCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { m_fLfeCore.fLfeFileInfo.fileName }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fLfeCore.fWsmCore.fWsmContainer
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

        private void loadLanguageFile(
            string fileName
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(this);

                // --

                this.closeAllChilds();

                // --

                m_fLfeCore.fLfeFileInfo.openFile(fileName);
                showDefaultEditor();

                // --

                m_fLfeCore.fOption.recentOpenPath = Path.GetDirectoryName(fileName);

                // --

                setTitle();
                controlMainMenu();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                FDebug.throwException(ex);
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

        private void saveLanguageFile(
            string fileName
            )
        {
            try
            {
                m_fLfeCore.fLfeFileInfo.saveFile(fileName);

                // --

                m_fLfeCore.fOption.recentSavePath = Path.GetDirectoryName(fileName);
                m_fLfeCore.fOption.save();

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
            FProgress fProgress = null;

            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                fProgress = new FProgress();
                fProgress.show(this);

                // --
                
                this.closeAllChilds();               

                // --

                m_fLfeCore.fLfeFileInfo.newFile();
                showDefaultEditor();

                // --

                setTitle();
                controlMainMenu();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                // --
                FDebug.throwException(ex);
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
                dialog.Title = fUIWizard.searchCaption("Open Language File");
                dialog.Filter = "Language Files | *.xml";
                dialog.DefaultExt = "xml";
                dialog.InitialDirectory = m_fLfeCore.fOption.recentOpenPath;
                // --
                if (dialog.ShowDialog(m_fLfeCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                loadLanguageFile(dialog.FileName);
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

                this.closeAllChilds();
                m_fLfeCore.fLfeFileInfo.closeFile();

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

        private bool procMenuSave(
            )
        {
            try
            {
                if (m_fLfeCore.fLfeFileInfo.isNewFile)
                {
                    return procMenuSaveAs();
                }

                // --

                saveLanguageFile(m_fLfeCore.fLfeFileInfo.fileFullName);

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
                dialog.Title = fUIWizard.searchCaption("Save As Language File");
                dialog.Filter = "Language Files | *.xml";
                dialog.DefaultExt = "xml";
                // --
                if (m_fLfeCore.fLfeFileInfo.isNewFile)
                {
                    dialog.InitialDirectory = m_fLfeCore.fOption.recentSavePath;
                }
                else
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(m_fLfeCore.fLfeFileInfo.fileFullName);
                }
                dialog.FileName = m_fLfeCore.fLfeFileInfo.fileName;
                // --
                if (dialog.ShowDialog(m_fLfeCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return false;
                }
                
                // --

                saveLanguageFile(dialog.FileName);

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

        private void procMenuExit(
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

        private void procMenuEditCaption(
            )
        {
            try
            {   
                m_fCaptionEditor = (FCaptionEditor)this.getChild(typeof(FCaptionEditor));
                if (m_fCaptionEditor == null)
                {
                    m_fCaptionEditor = new FCaptionEditor(m_fLfeCore);
                    m_fCaptionEditor.FormClosed += new FormClosedEventHandler(m_fCaptionEditor_FormClosed);
                    this.showChild(m_fCaptionEditor);
                }                
                m_fCaptionEditor.activate();

                // --

                controlMainMenu();
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

        private void procMenuEditMessage(
            )
        {
            try
            {         
                m_fMessageEditor = (FMessageEditor)this.getChild(typeof(FMessageEditor));
                if (m_fMessageEditor == null)
                {
                    m_fMessageEditor = new FMessageEditor(m_fLfeCore);
                    m_fMessageEditor.FormClosed += new FormClosedEventHandler(m_fMessageEditor_FormClosed);
                    this.showChild(m_fMessageEditor);
                }
                m_fMessageEditor.activate();

                // --

                controlMainMenu();
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

        public void procMenuExport(
            )
        {
            SaveFileDialog dialog = null;
            DialogResult dialogResult;
            FExcelExporter fExcelExp = null;
            string fileName = string.Empty;

            try
            {
                //*** 
                // 2013.01.08 by mjkim
                // 에러 처리는 throwFException()으로 합니다.  로직 중간에 showError()를 사용하면 다시 아래 로직을 탑니다.
                // 아래 로직대로라면, 결국 개체 참조 에러 메시지가 뜨겠습니다.
                // MessageEditor와 CaptionEditor의 유무를 여기서 따질게 아니라, 애초 창이 없을 경우 이 로직을 안타게 하는게 낫지 싶습니다.
                // ***
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Language.xlsx";

                // --

                dialog = new SaveFileDialog();
                // --
                dialog.Title = fUIWizard.searchCaption("Export Language to Excel");
                dialog.Filter = "Excel Files | *.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.InitialDirectory = m_fLfeCore.fOption.recentExportPath;
                dialog.FileName = fileName;
                // --
                if (dialog.ShowDialog(m_fLfeCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }
                fileName = dialog.FileName;

                // --

                fExcelExp = new FExcelExporter(fileName);
                // --
                fExcelExp.excelExport(m_fCaptionEditor.fGrid, m_fCaptionEditor.Text);
                fExcelExp.excelExport(m_fMessageEditor.fGrid, m_fMessageEditor.Text);
                
                // --

                fExcelExp.save();

                // --

                m_fLfeCore.fOption.recentExportPath = Path.GetDirectoryName(fileName);

                // ***
                // Excel open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fLfeCore.fUIWizard.generateMessage("Q0012"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fExcelExp = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuImport(
            )
        {
            OpenFileDialog dialog = null;
            string message = string.Empty;
            string fileName = string.Empty;

            try
            {
                dialog = new OpenFileDialog();
                dialog.Title = fUIWizard.searchCaption("Import Language Excel File");
                dialog.Filter = "Excel Files | *.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.InitialDirectory = m_fLfeCore.fOption.recentImportPath;
                // --
                if (dialog.ShowDialog(m_fLfeCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                //--

                m_fCaptionEditor.excelImport(dialog.FileName);
                m_fMessageEditor.excelImport(dialog.FileName);

                // --

                m_fLfeCore.fOption.recentImportPath = Path.GetDirectoryName(dialog.FileName);
                
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

        private void procMenuAbout(
            )
        {
            FAbout fAbout = null;

            try
            {
                fAbout = new FAbout(m_fLfeCore);
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
                fChildForm = (FBaseTabChildForm)m_fLfeCore.fOption.fChildFormList.getFormOfKey(key);                
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
                dialog = new FFormSelector(m_fLfeCore);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fLfeCore Object Event Handler

        private void m_fLfeCore_LangugeFileModified(
            object sender, 
            FLanguageFileModifiedEventArgs e
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }   

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fCaptionEditor Object Event Handler

        void m_fCaptionEditor_FormClosed(
            object sender, 
            FormClosedEventArgs e
            )
        {
            try
            {
                m_fCaptionEditor.FormClosed -= new FormClosedEventHandler(m_fCaptionEditor_FormClosed);
                m_fCaptionEditor = null;

                // --

                controlMainMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fMessageEditor Object Event Handler

        void m_fMessageEditor_FormClosed(
            object sender,
            FormClosedEventArgs e
            )
        {
            try
            {
                m_fMessageEditor.FormClosed -= new FormClosedEventHandler(m_fMessageEditor_FormClosed);
                m_fMessageEditor = null;

                // --

                controlMainMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FLfeContainer Form Event Handler

        private void FLfeContainer_Activated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fLfeCore == null)
                {
                    return;
                }

                // --

                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLfeContainer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fLfeCore.LangugeFileModified += new FLanguageFileModifiedEventHandler(m_fLfeCore_LangugeFileModified);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLfeContainer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setTitle();
                controlMainMenu();
                setMainStatusBar();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLfeContainer_FormCloseConfirm(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLfeContainer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fLfeCore.fWsmCore.onMainStatusBarChanged(true);

                // --

                if (m_fLfeCore != null)
                {
                    m_fLfeCore.LangugeFileModified -= new FLanguageFileModifiedEventHandler(m_fLfeCore_LangugeFileModified);
                    // --
                    m_fLfeCore.Dispose();
                    m_fLfeCore = null;
                }
                if (m_fCaptionEditor != null)
                {
                    m_fCaptionEditor.Dispose();
                    m_fCaptionEditor = null;
                }
                if (m_fMessageEditor != null)
                {
                    m_fMessageEditor.Dispose();
                    m_fMessageEditor = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuMenu Control Event Handler

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
                else if (e.Tool.Key == FMenuKey.MenuSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuExit)
                {
                    procMenuExit();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuEditCaption)
                {
                    procMenuEditCaption();
                }
                else if (e.Tool.Key == FMenuKey.MenuEditMessage)
                {
                    procMenuEditMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuExport)
                {
                    procMenuExport();
                }
                else if (e.Tool.Key == FMenuKey.MenuImport)
                {
                    procMenuImport();
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
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

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
                // Control Window List
                // ***
                for (int i = 0; i < 10; i++)
                {
                    if (i >= m_fLfeCore.fOption.fChildFormList.count)
                    {
                        break;
                    }

                    // --

                    mnuTool = mnuMenu.Tools[MenuWinWindow + i.ToString()];
                    mnuTool.SharedProps.Tag = m_fLfeCore.fOption.fChildFormList.getKeyOfIndex(i);
                    mnuTool.SharedProps.Caption = "&" + (i + 1).ToString() + " " +fUIWizard .searchCaption( m_fLfeCore.fOption.fChildFormList.getTextOfIndex(i));
                    mnuTool.SharedProps.Visible = true;
                }                

                // --

                if (m_fLfeCore.fOption.fChildFormList.count > 10)
                {
                    mnuMenu.Tools[FMenuKey.MenuWinMoreWindows].SharedProps.Visible = true;
                }

                // --

                mnuMenu.endUpdate();
            }
            catch (Exception ex)
            {
                mnuMenu.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLfeCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                mnuTool = null;
            }
        }

        #endregion   

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
