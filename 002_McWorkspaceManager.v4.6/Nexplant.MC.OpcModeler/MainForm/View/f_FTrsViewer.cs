/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FVfeiViewer.cs
--  Creator         : kitae
--  Create Date     : 2011.06.01
--  Description     : FAMate OPC Modeler VFEI Viewer Form Class
--  History         : Created by kitae at 2011.06.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.OpcModeler
{
    public partial class FTrsViewer : Nexplant.MC.Core.FaUIs.FBaseControlForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTrsViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTrsViewer(
            FOpmCore fOpmCore
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
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
                    m_fOpmCore = null;
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
                mnuMenu.Tools[FMenuKey.MenuVfeClear].SharedProps.Enabled = m_isCleared;

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

        public void appendTrs(
            string trsText
            )
        {          
            try
            {
                txtTrs.AppendText(trsText);
                txtTrs.Select(txtTrs.TextLength, 0);
                txtTrs.ScrollToCaret();
                txtTrs.Focus();

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
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxDefaultButton.Button3,
                        m_fOpmCore.fWsmCore.fWsmContainer
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

                openFileName = FCommon.loadFile(m_fOpmCore, fileName);

                // -- 

                using (StreamReader sr = new StreamReader(openFileName, Encoding.Default))
                {
                    txtTrs.Text = sr.ReadToEnd();
                    txtTrs.Select(0, 0);
                    txtTrs.ScrollToCaret();
                    txtTrs.Focus();
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
                m_fOpmCore.fOption.vfeiViewerRecentOpenPath = Path.GetDirectoryName(m_fileName);

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
                sw.Write(txtTrs.Text);
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
                m_fOpmCore.fOption.vfeiViewerRecentSavePath = Path.GetDirectoryName(m_fileName);

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
                dialog.InitialDirectory = m_fOpmCore.fOption.vfeiViewerRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("VFEI Log File");
                dialog.Filter = "VFEI Log Files (*.vfe)| *.vfe";
                dialog.DefaultExt = "vfe";

                // --

                if (dialog.ShowDialog(m_fOpmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
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
                    dialog.InitialDirectory = m_fOpmCore.fOption.vfeiViewerRecentSavePath;
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
                txtTrs.Clear();

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
                txtTrs.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fOpmCore.fOption.commonFontName = preFontName;
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
                txtTrs.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());
                m_fOpmCore.fOption.commonFontSize = float.Parse(mnbFontSize.Value.ToString());
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

        #region FTrsViewer Form Event Handler

        private void FTrsViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fOpmCore.fOption.commonFontName;
                mnbFontSize.Value = m_fOpmCore.fOption.commonFontSize;
                
                // --

                txtTrs.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtTrs.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());

                // --
                
                m_fileName = "VFEI" + m_fFileIdPointer.uniqueId.ToString() + ".vfe";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                refreshFileName();
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTrsViewer_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fOpmCore.fOption.fChildFormList.add(this, this.Text + " - [" + m_fileName + "]");
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTrsViewer_FormCloseConfirm(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FTrsViewer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fOpmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtTrs Control Event Handler

        private void txtTrs_KeyDown(
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
                    txtTrs.showSearcher();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    txtTrs.showSearcher();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fOpmCore.fOption.commonFontName;
                        txtTrs.Appearance.FontData.Name = m_fOpmCore.fOption.commonFontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                //if (fontSize < FConstants.FontMinSize)
                //{
                //    mnbFontSize.Value = FConstants.FontMinSize;
                //}
                //else if (fontSize > FConstants.FontMaxSize)
                //{
                //    mnbFontSize.Value = FConstants.FontMaxSize;
                //}
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                //if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                //{
                //    mnbFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                //}
                //else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                //{
                //    mnbFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                //}
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                    txtTrs.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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