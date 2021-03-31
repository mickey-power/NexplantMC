/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapReferenceSheet.cs
--  Creator         : mjkim
--  Create Date     : 2014.03.21
--  Description     : FAMate Admin Manager EAP Reference Sheet Form Class 
--  History         : Created by mjkim at 2014.03.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapReferenceSheet : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string Title = "EAP Reference Sheet";

        // --

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_eapName = string.Empty;
        private string m_modelName = string.Empty;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapReferenceSheet(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapReferenceSheet(
            FAdmCore fAdmCore,
            string eapName
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_eapName = eapName;

            // --

            setTitle();
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
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string eapName
        {
            get
            {
                try
                {
                    return m_eapName;
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
                this.Text = this.fUIWizard.searchCaption(Title) + " - [" + m_eapName + "]";
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

        private void designGridOfManual(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdManual.dataSource;
                // --
                uds.Band.Columns.Add("Manual Name");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Manual Type");
                uds.Band.Columns.Add("File");

                // --

                grdManual.DisplayLayout.Bands[0].Columns["Manual Name"].CellAppearance.Image = Properties.Resources.ModelManual;
                // --
                grdManual.DisplayLayout.Bands[0].Columns["Manual Name"].Header.Fixed = true;
                // --
                grdManual.DisplayLayout.Bands[0].Columns["Manual Name"].Width = 120;
                grdManual.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdManual.DisplayLayout.Bands[0].Columns["Manual Type"].Width = 100;
                grdManual.DisplayLayout.Bands[0].Columns["File"].Width = 100;
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (tabMain.ActiveTab.Key == "Sheet")
                {
                    mnuMenu.Tools[FMenuKey.MenuErsExport].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuErsDownload].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuErsExport].SharedProps.Enabled = grdManual.Rows.Count > 0 ? true : true;
                    mnuMenu.Tools[FMenuKey.MenuErsDownload].SharedProps.Enabled = grdManual.activeDataRowKey != string.Empty ? true : false;
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

        private void refreshModelName(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", m_eapName);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ReferenceSheet", "SearchModel", fSqlParams, true);

                // --

                m_modelName = dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        private void refreshModelSheet(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string contents = string.Empty;

            try
            {
                ftxSheet.Value = string.Empty;
                if (m_modelName == string.Empty)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", m_modelName);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ReferenceSheet", "SearchModelSheet", fSqlParams, false);
                // --
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                // --

                contents = "";
                contents += dt.Rows[0]["SHT_CONTENTS_01"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_02"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_03"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_04"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_05"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_06"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_07"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_08"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_09"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_10"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_11"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_12"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_13"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_14"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_15"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_16"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_17"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_18"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_19"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_20"].ToString();
                // --

                ftxSheet.Value = contents;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfManual(
            )
        {
            try
            {
                pgdManual.selectedObject = new FPropModelManual(m_fAdmCore, pgdManual, m_modelName, false);
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

        private void setPropOfManual(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdManual.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", m_modelName);
                fSqlParams.add("mnu_type", grdManual.activeDataRow["Manual Type"].ToString());
                fSqlParams.add("mnu_name", grdManual.activeDataRow["Manual Name"].ToString());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ReferenceSheet", "SearchModelManual", fSqlParams, true);

                // --

                pgdManual.selectedObject = new FPropModelManual(m_fAdmCore, pgdManual, dt, false);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string generateGridUniqueKey(
            string[] dat
            )
        {
            const char UnitSeparator = (char)0x1F;
            // --
            StringBuilder key = null;

            try
            {
                key = new StringBuilder();

                foreach (string s in dat)
                {
                    key.Append(s);
                    key.Append(UnitSeparator);
                }

                // --

                return key.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                key = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfManual(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdManual.removeAllDataRow();
                grdManual.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfManual();
                // --
                lblTotal.Text = grdManual.Rows.Count.ToString();

                // --

                if (m_modelName == string.Empty)
                {
                    return;
                }

                // --

                grdManual.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", m_modelName);
                // --                
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ReferenceSheet", "ListModelManual", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(), // Manual
                            r[1].ToString(), // Description
                            r[2].ToString(), // Manual Type
                            r[3].ToString()  // Manual File
                            };
                        key = generateGridUniqueKey(new string[] { r[2].ToString(), r[0].ToString() });
                        grdManual.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdManual.endUpdate();

                // --

                if (grdManual.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdManual.activateDataRow(beforeKey);
                    }
                    if (grdManual.activeDataRow == null)
                    {
                        grdManual.ActiveRow = grdManual.Rows[0];
                    }
                }

                // --

                lblTotal.Text = grdManual.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                grdManual.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void export(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 FExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McReferenceSheet.xlsx";

                // --

                sfd = new SaveFileDialog();
                sfd.InitialDirectory = m_fAdmCore.fOption.recentExportPath;
                sfd.Title = "Export MC Reference Sheet to Excel";
                sfd.Filter = "Excel Files | *.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.FileName = fileName;
                // --
                if (sfd.ShowDialog(m_fAdmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                fileName = sfd.FileName;

                // --

                FExcelExp = new FExcelExporter2(fileName, m_fAdmCore.fUIWizard.fontName, 9);
                fExcelSht = FExcelExp.addExcelSheet("EAP Reference Sheet");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Model List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Manual") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdManual, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdManual.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
                // --
                fExcelSht.writeText("Create Time: " + FDataConvert.defaultNowDateTimeToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

                // --

                FExcelExp.save();

                // --

                // ***
                // Last Excel Export Path 저장
                // ***
                m_fAdmCore.fOption.recentExportPath = Path.GetDirectoryName(fileName);

                // --

                // ***
                // Excel Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0012"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start(fileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (FExcelExp != null)
                {
                    FExcelExp.Dispose();
                    FExcelExp = null;
                }

                if (FExcelExp != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }

                sfd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void downloadManual(
            )
        {
            FolderBrowserDialog fbd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMnu = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutMnu = null;
            FFtp fFtp = null;
            string mnuType = string.Empty;
            string mnuName = string.Empty;
            string fileName = string.Empty;
            string downloadFilePath = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fAdmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory Create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Create
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_InqModelManualDownload_In.E_ADMADS_InqModelManualDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelManualDownload_In.A_hLanguage, FADMADS_InqModelManualDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_InqModelManualDownload_In.A_hFactory, FADMADS_InqModelManualDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelManualDownload_In.A_hUserId, FADMADS_InqModelManualDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_InqModelManualDownload_In.A_hStep, FADMADS_InqModelManualDownload_In.D_hStep, "1");

                // --

                fXmlNodeInMnu = fXmlNodeIn.set_elem(FADMADS_InqModelManualDownload_In.FManual.E_Manual);
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_InqModelManualDownload_In.FManual.A_Model,
                    FADMADS_InqModelManualDownload_In.FManual.D_Model,
                    m_modelName
                    );

                // --

                mnuType = grdManual.activeDataRow["Manual Type"].ToString();
                mnuName = grdManual.activeDataRow["Manual Name"].ToString();

                // --

                fXmlNodeInMnu.set_elemVal(
                    FADMADS_InqModelManualDownload_In.FManual.A_ManualType,
                    FADMADS_InqModelManualDownload_In.FManual.D_ManualType,
                    mnuType
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_InqModelManualDownload_In.FManual.A_ManualName,
                    FADMADS_InqModelManualDownload_In.FManual.D_ManualName,
                    mnuName
                    );
                // --
                FADMADSCaster.ADMADS_SetModelManualDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_InqModelManualDownload_Out.A_hStatus, FADMADS_InqModelManualDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_InqModelManualDownload_Out.A_hStatusMessage, FADMADS_InqModelManualDownload_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutMnu = fXmlNodeOut.get_elem(FADMADS_InqModelManualDownload_Out.FManual.E_Manual);
                fileName = fXmlNodeOutMnu.get_elemVal(FADMADS_InqModelManualDownload_Out.FManual.A_Filename, FADMADS_InqModelManualDownload_Out.FManual.D_Filename);
                zipFileName = fXmlNodeOutMnu.get_elemVal(FADMADS_InqModelManualDownload_Out.FManual.A_Path, FADMADS_InqModelManualDownload_Out.FManual.D_Path);

                // --

                fFtp.downloadFiles(tempFilePath, zipFileName);
                fFtp.deleteFiles(zipFileName);

                // --

                zipFileName = Path.Combine(tempFilePath, zipFileName);
                downloadFilePath = Path.Combine(fbd.SelectedPath, string.Join("_", m_fAdmCore.fOption.factory, m_modelName, mnuType, mnuName));
                if (Directory.Exists(downloadFilePath))
                {
                    Directory.Delete(downloadFilePath, true);
                }
                Directory.CreateDirectory(downloadFilePath);
                // --
                F7Zip.unpack(zipFileName, downloadFilePath);

                // --

                m_fAdmCore.fOption.recentDownloadPath = fbd.SelectedPath;
                FCommon.deleteDirectory(tempFilePath);

                // --

                // ***
                // Download Manual Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0016"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start(Path.Combine(downloadFilePath, fileName));
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
                fXmlNodeInMnu = null;
                fXmlNodeOut = null;
                fXmlNodeOutMnu = null;
                fbd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public void refresh(
            )
        {
            try
            {
                refreshModelName();
                refreshModelSheet();
                refreshGridOfManual(grdManual.activeDataRowKey);

                // --

                if (tabMain.ActiveTab.Key == "Sheet")
                {
                    ftxSheet.Focus();
                }
                else
                {
                    grdManual.Focus();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FEapReferenceSheet Form Event Handler

        private void FEapReferenceSheet_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfManual();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapReferenceSheet_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refresh();

                // --

                ftxSheet.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapReferenceSheet_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FEapReferenceSheet_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    refresh();
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuErsRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuErsExport)
                {
                    export();
                }
                else if (e.Tool.Key == FMenuKey.MenuErsDownload)
                {
                    downloadManual();
                }
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabMain Control Event Handler

        private void tabMain_SelectedTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
            )
        {
            try
            {
                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
 
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdManual Control Event Handler

        private void grdManual_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfManual();

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdManual_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfManual();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstManual Control Event Handler

        private void rstManual_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdManual.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
