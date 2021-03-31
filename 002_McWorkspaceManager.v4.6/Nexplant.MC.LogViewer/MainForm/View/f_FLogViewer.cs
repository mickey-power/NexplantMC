/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FApplicationLogViewer.cs
--  Creator         : baehyun seo
--  Create Date     : 2012.07.03
--  Description     : FAMate Manager Application Log Viewer Form Class 
--  History         : Created by baehyun seo at 2012.07.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.LogViewer
{
    public partial class FLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLvwCore m_fLvwCore = null;
        private string m_fileName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogViewer(
            FLvwCore fAlvCore
            )
            : this()
        {
            base.fUIWizard = fAlvCore.fUIWizard;
            m_fLvwCore = fAlvCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogViewer(
            FLvwCore fAlvCore,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fAlvCore.fUIWizard;
            m_fLvwCore = fAlvCore;
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
                    m_fLvwCore = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string fileName
        {
            get
            {
                try
                {
                    return m_fileName;
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
        }

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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                // -- 
                txtLog.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fLvwCore.fOption.fontName = preFontName;
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
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());
                m_fLvwCore.fOption.fontSize = float.Parse(numFontSize.Value.ToString());
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

        private void designGridOfIndex(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Category");
                uds.Band.Columns.Add("Function");
                uds.Band.Columns.Add("Action");
                uds.Band.Columns.Add("Type Name");
                uds.Band.Columns.Add("Namespace");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Category"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Function"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Action"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Namespace"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Bands[0].Columns["Type Name"].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.Image = Properties.Resources.History;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Category"].Width = 85;
                grdList.DisplayLayout.Bands[0].Columns["Function"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Action"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Type Name"].Width = 113;
                grdList.DisplayLayout.Bands[0].Columns["Namespace"].Width = 188;

                // --

                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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
            )
        {
            int beforeCursor = 0;
            int wordSelect = 0;

            try
            {
                beforeCursor = txtLog.SelectionStart;
                wordSelect = txtLog.SelectionLength;
                
                // --

                txtLog.openLogFile(fileName);
                
                // --

                if (beforeCursor == 0)
                {
                    beforeCursor = txtLog.TextLength;
                    wordSelect = 0;
                }

                // --

                txtLog.Select(beforeCursor, wordSelect);
                txtLog.ScrollToCaret();
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

        public void refreshLog(
            )
        {
            FProgress fProgress = null;
            string key = string.Empty;
            string startTime = string.Empty;
            string category = string.Empty;
            string action = string.Empty;
            string namespace_ = string.Empty;
            string typeName = string.Empty;
            string function = string.Empty;
            int blockIndex = 0;
            int preIndex = 0;
            int startIndex = 0;
            int endIndex = 0;
            object[] cellValues = null;
            int index = 0;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fLvwCore.fWsmCore.fWsmContainer);

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                loadLogFile();

                do
                {
                    blockIndex = txtLog.Text.IndexOf("\r\n-\r\n", startIndex);
                    // --
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("[", startIndex);
                    // --
                    if (
                        startIndex == -1 ||
                        startIndex > blockIndex
                       )
                    {
                        continue;
                    }
                    key = startIndex.ToString();

                    // --

                    startTime = string.Empty;
                    category = string.Empty;
                    action = string.Empty;
                    namespace_ = string.Empty;
                    typeName = string.Empty;
                    function = string.Empty;

                    // --

                    // ***
                    // Start Time
                    // ***
                    if (startIndex < blockIndex)
                    {
                        startIndex += 1;
                        endIndex = txtLog.Text.IndexOf("]", startIndex);
                        startTime = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Category
                    // ***
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("Category=<", startIndex);
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockIndex)
                    {
                        startIndex += 10;
                        endIndex = txtLog.Text.IndexOf(">", startIndex);
                        category = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                        // --
                        if (category == "E")
                        {
                            category = "System Error";
                        }
                        else if (category == "F")
                        {
                            category = "Nexplant MC Error";
                        }
                        else if (category == "I")
                        {
                            category = "Information";
                        }
                    }

                    // --

                    // ***
                    // Action
                    // ***
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("Action=<", startIndex);
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockIndex)
                    {
                        startIndex += 8;
                        endIndex = txtLog.Text.IndexOf(">", startIndex);
                        action = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Namespace
                    // ***
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("Namespace=<", startIndex);
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockIndex)
                    {
                        startIndex += 11;
                        endIndex = txtLog.Text.IndexOf(">", startIndex);
                        namespace_ = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Type Name
                    // ***
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("TypeName=<", startIndex);
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockIndex)
                    {
                        startIndex += 10;
                        endIndex = txtLog.Text.IndexOf(">", startIndex);
                        typeName = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    // ***
                    // Function
                    // ***
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("Function=<", startIndex);
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
                    {
                        startIndex = preIndex;
                    }
                    else if (startIndex < blockIndex)
                    {
                        startIndex += 10;
                        endIndex = txtLog.Text.IndexOf(">", startIndex);
                        function = txtLog.Text.Substring(startIndex, endIndex - startIndex);
                    }

                    // --

                    cellValues = new object[] {
                        startTime,
                        category, 
                        function,
                        action,
                        typeName,
                        namespace_
                        };
                    index = grdList.appendDataRow(key, cellValues).Index;

                    // --

                    startIndex = blockIndex + 1;
                } while (startIndex > -1);

                // --

                grdList.endUpdate(false);

                // --

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("Start Time", false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
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

                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfIndex(
            )
        {
            try
            {
                if (m_fileName == string.Empty)
                {
                    return;
                }

                // --

                txtFileName.Text = Path.GetFileName(m_fileName);
                
                // --

                refreshLog();
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

        #region FApplicationLogViewer Form Event Handler

        private void FLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text = m_fLvwCore.fOption.fontName;
                numFontSize.Value = m_fLvwCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --                

                designGridOfIndex();

                // --

                m_fLvwCore.fOption.fChildFormList.add(this, this.Text + " - [" + Path.GetFileName(m_fileName) + "]");
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfIndex();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FLogViewer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fLvwCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFind)
                {
                    txtLog.showSearcher();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fLvwCore.fOption.fontName;
                        txtLog.Appearance.FontData.Name = m_fLvwCore.fOption.fontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            int startIndex = 0;
            int position = 0;

            try
            {
                FCursor.waitCursor();

                // --

                startIndex = int.Parse(grdList.activeDataRowKey);
                position = txtLog.Text.IndexOf("]", startIndex);
                // --
                txtLog.Select(startIndex, position - startIndex + 1);
                txtLog.ScrollToCaret();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_AfterRowFilterChanged(
            object sender,
            Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Rows.VisibleRowCount == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdList.ActiveRow)
                    {
                        activateIndex = r.VisibleIndex;
                        break;
                    }
                }
                // --
                if (activateIndex == -1)
                {
                    activateIndex = e.Rows.VisibleRowCount - 1;
                }
                grdList.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdList.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdList.ActiveRow);

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtLog.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_KeyDown(
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
                    txtLog.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtLog Control Event Handler

        private void txtLog_KeyDown(
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
                    txtLog.showSearcher();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion 
        
        //------------------------------------------------------------------------------------------------------------------------

        #region numFontSize Control Event Handler

        private void numFontSize_BeforeExitEditMode(
            object sender, 
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(numFontSize.Value.ToString());
                // --
                if (fontSize < FConstants.FontMinSize)
                {
                    numFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    numFontSize.Value = FConstants.FontMaxSize;
                }

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void numFontSize_EditorSpinButtonClick(
            object sender, 
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(numFontSize.Value.ToString());
                // --
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    numFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    numFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                }

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void numFontSize_KeyDown(
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
                    procMenuChangeFontSize();
                    txtLog.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fLvwCore.fWsmCore.fWsmContainer);
                
                // --

                refreshLog();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fLvwCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
