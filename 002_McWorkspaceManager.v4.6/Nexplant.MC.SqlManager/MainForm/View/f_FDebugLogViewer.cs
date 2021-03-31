/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDebugLogViewer.cs
--  Creator         : baehyun seo
--  Create Date     : 2012.07.03
--  Description     : FAMate Sql Manager Debug Log Viewer Form Class 
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
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FDebugLogViewer : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        private string m_fileName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDebugLogViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDebugLogViewer(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDebugLogViewer(
            FSqmCore fSqmCore,
            string fileName
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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
                    m_fSqmCore = null;
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

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);

                // --

                txtFileName.Text = Path.GetFileName(m_fileName);
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
                m_fSqmCore.fOption.fontName = preFontName;
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
                m_fSqmCore.fOption.fontSize = float.Parse(numFontSize.Value.ToString());
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
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlnodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            // --
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
            int beforeCursor = 0;
            int wordSelect = 0;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_ViwSqlServiceLogDownload_In.E_FSQMSQS_ViwSqlServiceLogDownload_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogDownload_In.A_hLanguage, FSQMSQS_ViwSqlServiceLogDownload_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogDownload_In.A_hStep, FSQMSQS_ViwSqlServiceLogDownload_In.D_hStep, "1");
                // --
                fXmlnodeInLog = fXmlNodeIn.set_elem(FSQMSQS_ViwSqlServiceLogDownload_In.FLog.E_Log);
                fXmlnodeInLog.set_elemVal(FSQMSQS_ViwSqlServiceLogDownload_In.FLog.A_File, FSQMSQS_ViwSqlServiceLogDownload_In.FLog.D_File, m_fileName);

                // --

                FSQMSQSCaster.SQMSQS_ViwSqlServiceLogDownload_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogDownload_Out.A_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogDownload_Out.A_hStatusMessage, FSQMSQS_ViwSqlServiceLogDownload_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutLog = fXmlNodeOut.get_elem(FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.E_Log);
                zipFileName = fXmlNodeOutLog.get_elemVal(FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.A_Path, FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.D_Path);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fSqmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Download & DeleteFiles
                // ***
                fFtp = FCommon.createFtp(m_fSqmCore);
                // --
                fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                fFtp.deleteFiles(Path.GetFileName(zipFileName));

                // --

                // ***
                // Download File unpack
                // ***
                F7Zip.unpack(tempFilePath + "\\" + zipFileName, tempFilePath);

                // --

                beforeCursor = txtLog.SelectionStart;
                wordSelect = txtLog.SelectionLength;

                // --
                
                txtLog.openLogFile(tempFilePath + "\\" + Path.GetFileName(m_fileName));

                // --

                if (beforeCursor == 0)
                {
                    beforeCursor = txtLog.TextLength;
                }

                // --

                txtLog.Select(beforeCursor, wordSelect);
                txtLog.ScrollToCaret();

                // --

                Directory.Delete(tempFilePath, true);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
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
                fXmlnodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutLog = null;
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
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Category"].Width = 85;
                grdList.DisplayLayout.Bands[0].Columns["Function"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Action"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Type Name"].Width = 113;
                grdList.DisplayLayout.Bands[0].Columns["Namespace"].Width = 188;
                // --
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;

                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.Image = Properties.Resources.History;
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

        private void refreshGridOfIndex(
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

            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();                                
                
                // --

                fProgress = new FProgress();
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);

                // --

                loadLogFile(); 

                // --

                do
                {
                    blockIndex = txtLog.Text.IndexOf("\r\n-\r\n", startIndex);
                    // --
                    preIndex = startIndex;
                    startIndex = txtLog.Text.IndexOf("[", startIndex);
                    // --
                    if (startIndex == -1 ||
                        startIndex > blockIndex)
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
                    grdList.appendDataRow(key, cellValues);

                    // --

                    startIndex = blockIndex + 1;
                } while (startIndex > -1);

                // --

                grdList.endUpdate();

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

                grdList.endUpdate();
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
        
        public void refreshLog(
            )
        {
            try
            {
                refreshGridOfIndex();
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

        private void searchLog(
            )
        {
            int startIndex = 0;
            int position = 0;

            try
            {
                startIndex = int.Parse(grdList.activeDataRowKey);
                position = txtLog.Text.IndexOf("]", startIndex);
                // --
                txtLog.Select(startIndex, position - startIndex + 1);
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDebugLogViewer Form Event Handler

        private void FDebugLogViewer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text = m_fSqmCore.fOption.fontName;
                numFontSize.Value = m_fSqmCore.fOption.fontSize;

                // --

                txtLog.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtLog.Appearance.FontData.SizeInPoints = float.Parse(numFontSize.Value.ToString());

                // --                
                
                designGridOfIndex();

                // --

                m_fSqmCore.fOption.fChildList.add(this, this.Text + " - [" + m_fileName + "]");
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FDebugLogViewer_Shown(
            object sender, 
            EventArgs e
            )
        {
            FProgress fProgress = null;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);

                // --

                refreshGridOfIndex();

                // --

                setTitle();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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

        private void FDebugLogViewer_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.fOption.fChildList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuSqlFind)
                {
                    txtLog.showSearcher();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_FontNameChange(
            object sender, 
            Infragistics.Win.UltraWinToolbars.ToolEventArgs e
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSqmCore.fOption.fontName;
                        txtLog.Appearance.FontData.Name = m_fSqmCore.fOption.fontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
            try
            {
                FCursor.waitCursor();

                // --

                searchLog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion         

        //------------------------------------------------------------------------------------------------------------------------

        #region mskFontSize Control Event Handler

        private void mskFontSize_EditorSpinButtonClick(
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
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    numFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    numFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_BeforeExitEditMode(
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
                if (fontSize < FConstants.FontMinSize)
                {
                    numFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    numFontSize.Value = FConstants.FontMaxSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_KeyDown(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);
                
                // -
                
                refreshGridOfIndex();
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                    FMessageBox.showInformation("Search", m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion                            

        //------------------------------------------------------------------------------------------------------------------------

    }   //  Class end
}   // Namespace end
