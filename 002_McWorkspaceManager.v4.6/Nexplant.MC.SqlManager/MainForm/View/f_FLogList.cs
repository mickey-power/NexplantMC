/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLogList.cs
--  Creator         : baehyun seo
--  Create Date     : 2012.04.17
--  Description     : FAMate Sql Manager Log File List Form Class 
--  History         : Created by baehyun seo at 2012.04.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using System.Drawing;

namespace Nexplant.MC.SqlManager
{
    public partial class FLogList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        private bool m_cleared = true;
        private string m_lastSelectedLog = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogList(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            try
            {
                base.changeControlCaption();
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

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuSqlExport].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSqlDownload].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSqlView].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSqlExport].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSqlDownload].SharedProps.Enabled = m_lastSelectedLog == string.Empty ? false : true;
                    mnuMenu.Tools[FMenuKey.MenuSqlView].SharedProps.Enabled = m_lastSelectedLog == string.Empty ? false : true;
                }

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

        private Image getImageOfLog(
            string fileName
            )
        {
            string fileExtension = string.Empty;

            try
            {
                fileExtension = Path.GetExtension(fileName);

                if (fileExtension == ".log")
                {
                    return grdList.ImageList.Images["File_Log"];
                }
                else if (fileExtension == ".dlg")
                {
                    return grdList.ImageList.Images["File_Dlg"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return grdList.ImageList.Images["File_Log"];
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designComboOfLogType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbLogType.dataSource;

                // --

                uds.Band.Columns.Add("Log Type");

                // --

                ucbLogType.Appearance.Image = Properties.Resources.Log;

                // --

                ucbLogType.DisplayLayout.Bands[0].Columns["Log Type"].CellAppearance.Image = Properties.Resources.Log;
                // --
                ucbLogType.DisplayLayout.Bands[0].Columns["Log Type"].Width = ucbLogType.Width - 2;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfLog(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Creation Time");
                uds.Band.Columns.Add("Last Write Time");
                uds.Band.Columns.Add("Last Access Time");
                uds.Band.Columns.Add("Size");

                // --

                grdList.DisplayLayout.Bands[0].Columns["File Name"].Width = 280;
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].Width = 170;
                grdList.DisplayLayout.Bands[0].Columns["Creation Time"].Width = 170;
                grdList.DisplayLayout.Bands[0].Columns["Last Write Time"].Width = 170;
                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].Width = 170;
                grdList.DisplayLayout.Bands[0].Columns["Size"].Width = 60;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Creation Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Last Write Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Size"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["File Name"].Header.Fixed = true;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("File_Log", Properties.Resources.File_Log);
                grdList.ImageList.Images.Add("File_Dlg", Properties.Resources.File_Dlg);
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

        private void clear(
            )
        {
            try
            {
                if (m_cleared)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                // ***
                // Sql Service Log List Clear
                // ***
                grdList.removeAllDataRow();

                // --

                grdList.endUpdate();

                // --

                m_cleared = true;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
 
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshComboOfLogType(
            )
        {
            try
            {
                ucbLogType.beginUpdate(false);
                ucbLogType.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FLogType)))
                {
                    ucbLogType.appendDataRow(s, new object[] { s });
                }

                // --

                ucbLogType.endUpdate(false);

                // --

                ucbLogType.Text = FLogType.All.ToString();
            }
            catch (Exception ex)
            {
                ucbLogType.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshListOfLog(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_ViwSqlServiceLogList_In.E_FSQMSQS_ViwSqlServiceLogList_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogList_In.A_hLanguage, FSQMSQS_ViwSqlServiceLogList_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogList_In.A_hStep, FSQMSQS_ViwSqlServiceLogList_In.D_hStep, "1");
                // --
                fXmlNodeInLog = fXmlNodeIn.set_elem(FSQMSQS_ViwSqlServiceLogList_In.FLog.E_Log);
                fXmlNodeInLog.set_elemVal(FSQMSQS_ViwSqlServiceLogList_In.FLog.A_Type, FSQMSQS_ViwSqlServiceLogList_In.FLog.D_Type, ucbLogType.Text);

                // --

                do
                {
                    fXmlNodeInLog.set_elemVal(
                        FSQMSQS_ViwSqlServiceLogList_In.FLog.A_NextRowNumber,
                        FSQMSQS_ViwSqlServiceLogList_In.FLog.D_NextRowNumber,
                        nextRowNumber.ToString()
                        );

                    // --

                    FSQMSQSCaster.SQMSQS_ViwSqlServiceLogList_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogList_Out.A_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogList_Out.A_hStatusMessage, FSQMSQS_ViwSqlServiceLogList_Out.D_hStatusMessage));
                    }

                    // --

                    fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_ViwSqlServiceLogList_Out.FTable.E_Table);
                    // --
                    dt = FDbWizard.stringToDataTable(fXmlNodeOutTbl.get_elemVal(FSQMSQS_ViwSqlServiceLogList_Out.FTable.A_Rows, FSQMSQS_ViwSqlServiceLogList_Out.FTable.D_Rows));
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0],   // File Name
                            FDataConvert.defaultDataTimeFormating(r[0].ToString().Substring(0, 17)),
                            r[1],   // CreationTime
                            r[2],   // LastWriteTime
                            r[3],   // LastAccessTime
                            r[4]    // Size
                            };
                        key = r[0].ToString().Trim();
                        index = grdList.appendDataRow(key, cellValues).Index;
                        // --
                        grdList.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = getImageOfLog(r[0].ToString());
                    }

                    // --

                    nextRowNumber = int.Parse(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_ViwSqlServiceLogList_Out.FTable.A_NextRowNumber, FSQMSQS_ViwSqlServiceLogList_Out.FTable.D_NextRowNumber)
                        );
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate(false);

                // --

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("File Name", true);

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_lastSelectedLog != string.Empty)
                    {
                        grdList.activateDataRow(m_lastSelectedLog);
                    }
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                m_cleared = false;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInLog = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void export(
            )
        {
            SaveFileDialog dialog = null;
            DialogResult dialogResult;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_SqlServiceLogList.xlsx";

                // --

                dialog = new SaveFileDialog();
                // --
                dialog.Title = fUIWizard.searchCaption("Export Sql Service Log List to Excel");
                dialog.Filter = "Excel Files | *.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.InitialDirectory = m_fSqmCore.fOption.recentExportPath;
                dialog.FileName = fileName;
                // --
                if (dialog.ShowDialog(m_fSqmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }
                fileName = dialog.FileName;

                // --

                fExcelExp = new FExcelExporter2(fileName, m_fSqmCore.fUIWizard.fontName, 9);
                fExcelSht = fExcelExp.addExcelSheet("Sql Service Log List");

                // --

                // ***
                // Title Write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Input Condition Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fSqmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fSqmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblLogType.Text, ucbLogType.Text, rowIndex, 0);

                // --

                // ***
                // Sql Service Log List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fSqmCore.fUIWizard.searchCaption("Sql Service Log List") + "]", rowIndex, 0, m_fSqmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdList, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdList.Rows.Count.ToString(), rowIndex, 0, m_fSqmCore.fUIWizard.fontName, 9, true);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
                // --
                fExcelSht.writeText("Create Time: " + FDataConvert.defaultNowDateTimeToString(), rowIndex, 0, m_fSqmCore.fUIWizard.fontName, 9, true);

                // --

                fExcelExp.save();

                // --

                // ***
                // Last Excel Export Path Save
                // ***
                m_fSqmCore.fOption.recentExportPath = Path.GetDirectoryName(fileName);

                // --

                // ***
                // Excel Open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0012"),
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
                if (fExcelExp != null)
                {
                    fExcelExp.Dispose();
                    fExcelExp = null;
                }

                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }

                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void downlaod(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlnodeInLog = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutLog = null;
            FFtp fFtp = null;
            DialogResult dialogResult;
            FolderBrowserDialog fbd;
            string downloadFilePath = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // Download Directory
                // ***
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fSqmCore.fOption.recentLogDownloadPath;
                dialogResult = fbd.ShowDialog();
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                m_fSqmCore.fOption.recentLogDownloadPath = fbd.SelectedPath;

                // --

                fFtp = FCommon.createFtp(m_fSqmCore);

                // --

                tempFilePath = Path.Combine(m_fSqmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                downloadFilePath = Path.Combine(fbd.SelectedPath, "SQLService_Log");
                if (!Directory.Exists(downloadFilePath))
                {
                    Directory.CreateDirectory(downloadFilePath);
                }

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_ViwSqlServiceLogDownload_In.E_FSQMSQS_ViwSqlServiceLogDownload_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogDownload_In.A_hLanguage, FSQMSQS_ViwSqlServiceLogDownload_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_ViwSqlServiceLogDownload_In.A_hStep, FSQMSQS_ViwSqlServiceLogDownload_In.D_hStep, "1");
                // --
                fXmlnodeInLog = fXmlNodeIn.set_elem(FSQMSQS_ViwSqlServiceLogDownload_In.FLog.E_Log);

                // --

                foreach (string key in grdList.selectedDataRowKeys)
                {
                    fXmlnodeInLog.set_elemVal(
                        FSQMSQS_ViwSqlServiceLogDownload_In.FLog.A_File,
                        FSQMSQS_ViwSqlServiceLogDownload_In.FLog.D_File,
                        key
                        );

                    // --

                    FSQMSQSCaster.SQMSQS_ViwSqlServiceLogDownload_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogDownload_Out.A_hStatus, FSQMSQS_ViwSqlServiceLogDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_ViwSqlServiceLogDownload_Out.A_hStatusMessage, FSQMSQS_ViwSqlServiceLogDownload_Out.D_hStatusMessage));
                    }

                    // --

                    fXmlNodeOutLog = fXmlNodeOut.get_elem(FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.E_Log);
                    zipFileName = fXmlNodeOutLog.get_elemVal(
                        FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.A_Path,
                        FSQMSQS_ViwSqlServiceLogDownload_Out.FLog.D_Path
                        );

                    // --

                    fFtp.downloadFiles(tempFilePath, Path.GetFileName(zipFileName));
                    fFtp.deleteFiles(Path.GetFileName(zipFileName));

                    // --

                    zipFileName = tempFilePath + "\\" + zipFileName;
                    F7Zip.unpack(zipFileName, downloadFilePath);
                }

                // --

                // ***
                // Temp Directory Delete
                // ***
                Directory.Delete(tempFilePath, true);

                // --

                // ***
                /// folder open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0006"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", fbd.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void view(
            )
        {
            FApplicationLogViewer fAppLogViewer = null;
            FDebugLogViewer fDbgLogViewer = null;
            string extension = string.Empty;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }

                // --

                extension = grdList.activeDataRowKey.Substring(grdList.activeDataRowKey.Length - 3);

                // --

                if (extension == FExtensionType.log.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fSqmCore.fSqmContainer.fChilds)
                    {
                        if (fChildForm is FApplicationLogViewer)
                        {
                            if (((FApplicationLogViewer)fChildForm).fileName == m_lastSelectedLog)
                            {
                                fAppLogViewer = (FApplicationLogViewer)fChildForm;                                
                                fAppLogViewer.refreshLog();
                                fAppLogViewer.activate();                                
                                return;
                            }
                        }
                    }

                    // --

                    if (fAppLogViewer == null)
                    {
                        fAppLogViewer = new FApplicationLogViewer(m_fSqmCore, m_lastSelectedLog);
                        m_fSqmCore.fSqmContainer.showChild(fAppLogViewer);
                    }
                    fAppLogViewer.activate();
                }
                else if (extension == FExtensionType.dlg.ToString())
                {
                    foreach (FBaseTabChildForm fChildForm in m_fSqmCore.fSqmContainer.fChilds)
                    {
                        if (fChildForm is FDebugLogViewer)
                        {
                            if (((FDebugLogViewer)fChildForm).fileName == m_lastSelectedLog)
                            {
                                fDbgLogViewer = (FDebugLogViewer)fChildForm;
                                fDbgLogViewer.refreshLog();
                                fDbgLogViewer.activate();
                                return;
                            }
                        }
                    }

                    // --

                    if (fDbgLogViewer == null)
                    {
                        fDbgLogViewer = new FDebugLogViewer(m_fSqmCore, m_lastSelectedLog);
                        m_fSqmCore.fSqmContainer.showChild(fDbgLogViewer);
                    }
                    fDbgLogViewer.activate();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fAppLogViewer = null;
                fDbgLogViewer = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FLogList Form Event Handler

        private void FLogList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfLogType();
                designGridOfLog();

                // --

                m_fSqmCore.fOption.fChildList.add(this);
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

        private void FLogList_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfLogType();

                // --

                controlMenu();

                // --

                ucbLogType.Focus();
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

        private void FLogList_FormClosing(
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

                if (e.Tool.Key == FMenuKey.MenuSqlRefresh)
                {
                    refreshListOfLog();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlExport)
                {
                    export();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlDownload)
                {
                    downlaod();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqlView)
                {
                    view();
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

                m_lastSelectedLog = grdList.activeDataRowKey;
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

        private void grdList_DoubleClickRow(
            object sender,
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // ---

                view();
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
                    view();
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

        #region opsLogType Control Event Handler

        private void opsLogType_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshListOfLog();
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

        #region ucbLogType Control Event Handler

        private void ucbLogType_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                clear();
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

    }   // Class end
}   // Namespace end
