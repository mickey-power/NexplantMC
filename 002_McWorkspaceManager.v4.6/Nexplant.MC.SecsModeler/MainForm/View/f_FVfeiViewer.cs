/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FVfeiViewer.cs
--  Creator         : kitae
--  Create Date     : 2011.06.01
--  Description     : FAMate SECS Modeler VFEI Viewer Form Class
--  History         : Created by kitae at 2011.06.01
                      Modify by spike.lee at 2012.11.15
                        - Refresh Function 수정 (File Refresh 처리)
                        - Font Name 미 적용 Bug 수정 (Event 핸들러 재설정)
                        - Save Confirm 전면 수정
                        - Menu Control 관련 전면 수정
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.SecsModeler
{
    public partial class FVfeiViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FVfeiViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FVfeiViewer(
            FSsmCore fSsmCore
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
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
                    m_fSsmCore = null;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private void refreshFileName(
            )
        {
            try
            {
                txtFileName.Text = (m_isTempFile ? "[Temp] " : "") + m_fileName + (m_isModifiedFile ? "*" : "");
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                mnuMenu.Tools[FMenuKey.menuVfeRefresh].SharedProps.Enabled = !m_isNewFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuVfeFind].SharedProps.Enabled = true;
                // --
                mnuMenu.Tools[FMenuKey.MenuVfeOpen].SharedProps.Enabled = true;                
                // --
                mnuMenu.Tools[FMenuKey.MenuVfeSave].SharedProps.Enabled = m_isNewFile | m_isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuVfeSaveAs].SharedProps.Enabled = true;
                // --
                mnuMenu.Tools[FMenuKey.MenuVfeClear].SharedProps.Enabled = !m_isCleared;

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

        public void appendVfei(
            string vfeiText
            )
        {          
            try
            {
                txtVfei.AppendText(vfeiText);
                txtVfei.Select(txtVfei.TextLength, 0);
                txtVfei.ScrollToCaret();
                txtVfei.Focus();

                // --                 

                m_isModifiedFile = true;
                m_isCleared = false;

                // --

                refreshFileName();
                controlMenu();     
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

        public bool confirmSave(
            )
        {
            DialogResult dialogResult;

            try
            {
                if (m_isModifiedFile)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fSsmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
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

        private void loadVfeiFile(
            string fileName
            )
        {
            string openFileName = string.Empty; 
            
            try
            {
                FCursor.waitCursor();

                // -- 

                openFileName = FCommon.loadFile(m_fSsmCore, fileName);

                // -- 

                using (StreamReader sr = new StreamReader(openFileName, Encoding.Default))
                {
                    txtVfei.Text = sr.ReadToEnd();
                    txtVfei.Select(0, 0);
                    txtVfei.ScrollToCaret();
                    txtVfei.Focus();
                    // --
                    sr.Close();
                }

                // --

                m_isTempFile = (fileName != openFileName) ? true : false;
                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fileName = fileName;
                m_fSsmCore.fOption.vfeiViewerRecentOpenPath = Path.GetDirectoryName(m_fileName);

                // --

                refreshFileName();
                controlMenu();
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

        private void saveVfeiFile(
            string fileName
            )
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fileName, false, Encoding.Default);
                // --
                sw.Write(txtVfei.Text);
                // --
                sw.Close();
                sw.Dispose();
                sw = null;

                // --

                m_isNewFile = false;
                m_isModifiedFile = false;
                m_isCleared = false;
                // --
                m_fileName = fileName;
                m_fSsmCore.fOption.vfeiViewerRecentSavePath = Path.GetDirectoryName(m_fileName);

                // --

                refreshFileName();
                controlMenu();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRefresh(
            )
        {
            try
            {
                if (!confirmSave())
                {
                    return;
                }

                // --

                loadVfeiFile(m_fileName);
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
                dialog.InitialDirectory = m_fSsmCore.fOption.vfeiViewerRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open VFEI Log File");
                dialog.Filter = "VFEI Log Files (*.vfe)| *.vfe";
                dialog.DefaultExt = "vfe";

                // --

                if (dialog.ShowDialog(m_fSsmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (Path.GetFileName(m_fileName) == Path.GetFileName(dialog.FileName))
                {
                    return;
                }

                // --

                loadVfeiFile(dialog.FileName);                                
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
                if (m_isNewFile)
                {
                    return procMenuSaveAs();
                }
                saveVfeiFile(m_fileName);

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
                dialog.Title = fUIWizard.searchCaption("Save VFEI Log File");
                dialog.Filter = "VFEI Log File (*.vfe) |*.vfe";
                dialog.DefaultExt = "vfe";
                // --
                if (m_isNewFile)
                {
                    dialog.InitialDirectory = m_fSsmCore.fOption.vfeiViewerRecentSavePath;
                    dialog.FileName = m_fileName;
                }
                else
                {
                    dialog.InitialDirectory = Path.GetDirectoryName(m_fileName);
                    dialog.FileName = Path.GetFileName(m_fileName);
                }

                // --

                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return false;
                }

                // --

                saveVfeiFile(dialog.FileName);

                // --

                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dialog = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClear(
            )
        {
            try
            {
                txtVfei.Clear();

                // --

                m_isModifiedFile = true;
                m_isCleared = true;

                // --

                refreshFileName();
                controlMenu();
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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                // --
                txtVfei.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fSsmCore.fOption.commonFontName = preFontName;
            }
            catch (Exception)
            {
                isValidFontName = false;
            }
            finally
            {

            }
            return isValidFontName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChangeFontSize(
            )
        {
            try
            {
                txtVfei.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());
                m_fSsmCore.fOption.commonFontSize = float.Parse(mnbFontSize.Value.ToString());
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

        #region FVfeiViewer Form Event Handler

        private void FVfeiViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSsmCore.fOption.commonFontName;
                mnbFontSize.Value = m_fSsmCore.fOption.commonFontSize;
                
                // --
                
                txtVfei.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtVfei.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());

                // --
                
                m_fileName = "VFEI" + m_fFileIdPointer.uniqueId.ToString() + ".vfe";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                refreshFileName();
                controlMenu();

                // --

                m_fSsmCore.fOption.fChildFormList.add(this, this.Text + " - [" + m_fileName + "]");
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

        private void FVfeiViewer_FormCloseConfirm(
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

        private void FVfeiViewer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fSsmCore.fOption.fChildFormList.remove(this);
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

        #region txtVfei Control Event Handler

        private void txtVfei_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Control && e.KeyCode == Keys.F)
                {
                    txtVfei.showSearcher();
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

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.menuVfeRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeFind)
                {
                    txtVfei.showSearcher();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuVfeClear)
                {
                    procMenuClear();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_ToolValueChanged(
            object sender, 
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    procMenuChangeFontName();                    
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_AfterToolDeactivate(
            object sender,
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSsmCore.fOption.commonFontName;
                        txtVfei.Appearance.FontData.Name = m_fSsmCore.fOption.commonFontName;
                    }
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

        #region mnbFontSize Control Event Handler
        
        private void mnbFontSize_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mnbFontSize.Value.ToString());
                if (fontSize < FConstants.FontMinSize)
                {
                    mnbFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    mnbFontSize.Value = FConstants.FontMaxSize;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_EditorSpinButtonClick(
            object sender,
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mnbFontSize.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    mnbFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mnbFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    txtVfei.Focus();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_ValueChanged(
           object sender,
           EventArgs e
           )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuChangeFontSize();
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

    }   // Class end
}   // Namespace end