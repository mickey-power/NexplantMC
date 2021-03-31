/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FXlgViewer.cs
--  Creator         : kitae
--  Create Date     : 2011.06.01
--  Description     : FAMate TCP Modeler XLG Viewer Form Class
--  History         : Created by kitae at 2011.06.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.TcpModeler
{
    public partial class FXlgViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private static FIDPointer32 m_fFileIdPointer = new FIDPointer32();
        // --
        private string m_fileName = string.Empty;
        private bool m_isTempFile = false;
        private bool m_isNewFile = false;
        private bool m_isModifiedFile = false;
        private bool m_isCleared = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FXlgViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXlgViewer(
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
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
                    m_fTcmCore = null;
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
            string caption = string.Empty;

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

                mnuMenu.Tools[FMenuKey.menuXlvRefresh].SharedProps.Enabled = !m_isNewFile;
                // --
                mnuMenu.Tools[FMenuKey.MenuXlvFind].SharedProps.Enabled = true;
                // --
                mnuMenu.Tools[FMenuKey.MenuXlvOpen].SharedProps.Enabled = true;                
                // --
                mnuMenu.Tools[FMenuKey.MenuXlvSave].SharedProps.Enabled = m_isNewFile | m_isModifiedFile;
                mnuMenu.Tools[FMenuKey.MenuXlvSaveAs].SharedProps.Enabled = true;
                // --
                mnuMenu.Tools[FMenuKey.MenuXlvClear].SharedProps.Enabled = !m_isCleared;                                

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

        public void appendXlg(
            string xlgText
            )
        {           
            try
            {
                txtXlg.AppendText(xlgText);
                txtXlg.Select(txtXlg.TextLength, 0);
                txtXlg.ScrollToCaret();
                txtXlg.Focus();

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
                        m_fTcmCore.fWsmCore.fUIWizard.generateMessage("Q0002", new object[] { Path.GetFileName(m_fileName) }),
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

        private void loadXlgFile(
            string fileName
            )
        {
            string openFileName = string.Empty; 

            try
            {
                FCursor.waitCursor();
                
                // -- 

                openFileName = FCommon.loadFile(m_fTcmCore, fileName);

                // -- 

                using (StreamReader sr = new StreamReader(openFileName, Encoding.Default))
                {
                    txtXlg.Text = sr.ReadToEnd();
                    txtXlg.Select(0, 0);
                    txtXlg.ScrollToCaret();
                    txtXlg.Focus();
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
                m_fTcmCore.fOption.xlgViewerRecentOpenPath = Path.GetDirectoryName(m_fileName);
        
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

        private void saveXlgFile(
            string fileName
            )
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(fileName, false, Encoding.Default);
                // --
                sw.Write(txtXlg.Text);
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
                m_fTcmCore.fOption.xlgViewerRecentSavePath = Path.GetDirectoryName(m_fileName);

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

                loadXlgFile(m_fileName);
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
                dialog.InitialDirectory = m_fTcmCore.fOption.xlgViewerRecentOpenPath;
                dialog.Title = fUIWizard.searchCaption("Open XLG Log File");
                dialog.Filter = "XLG Log Files (*.xlg) | *.xlg";
                dialog.DefaultExt = "xlg";

                // --
                
                if (dialog.ShowDialog(m_fTcmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --                

                loadXlgFile(dialog.FileName);                
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
                saveXlgFile(m_fileName);                

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
                dialog.Title = fUIWizard.searchCaption("Save XLG Log File");
                dialog.Filter = "XLG Log File (*.xlg) | *.xlg";
                dialog.DefaultExt = "xlg";
                // --
                if (m_isNewFile)
                {
                    dialog.InitialDirectory = m_fTcmCore.fOption.xlgViewerRecentSavePath;
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

                saveXlgFile(dialog.FileName);

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
                txtXlg.Clear();

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
                txtXlg.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fTcmCore.fOption.commonFontName = preFontName;
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
                txtXlg.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());
                m_fTcmCore.fOption.commonFontSize = float.Parse(mnbFontSize.Value.ToString());
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

        #region FXlgViewer Form Event Handler

        private void FXlgViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                mnbFontSize.Value = m_fTcmCore.fOption.commonFontSize;
                
                // --

                txtXlg.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtXlg.Appearance.FontData.SizeInPoints = float.Parse(mnbFontSize.Value.ToString());

                // --

                m_fileName = "XLG" + m_fFileIdPointer.uniqueId.ToString() + ".xlg";
                // --
                m_isNewFile = true;
                m_isModifiedFile = false;
                m_isCleared = true;

                // --

                refreshFileName();
                controlMenu();

                // --

                m_fTcmCore.fOption.fChildFormList.add(this, this.Text + " - [" + m_fileName + "]");
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

        private void FXlgViewer_FormCloseConfirm(
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

        private void FXlgViewer_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                m_fTcmCore.fOption.fChildFormList.remove(this);
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

        #region txtXlg Control Event Handler

        private void txtXlg_KeyDown(
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
                    txtXlg.showSearcher();
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

                if (e.Tool.Key == FMenuKey.menuXlvRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlvFind)
                {
                    txtXlg.showSearcher();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlvOpen)
                {
                    procMenuOpen();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlvSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlvSaveAs)
                {
                    procMenuSaveAs();
                }
                else if (e.Tool.Key == FMenuKey.MenuXlvClear)
                {
                    procMenuClear();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fTcmCore.fOption.commonFontName;
                        txtXlg.Appearance.FontData.Name = m_fTcmCore.fOption.commonFontName;
                    }
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                    txtXlg.Focus();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void mnbFontSize_ValueChanged(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
