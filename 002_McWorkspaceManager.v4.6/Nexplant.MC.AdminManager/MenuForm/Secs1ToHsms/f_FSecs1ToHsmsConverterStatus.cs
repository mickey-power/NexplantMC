/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverterStatus.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.28
--  Description     : FAmate Admin Manager SECS1 To HSMS Convereter Status Form Class 
--  History         : Created by spike.lee at 2017.04.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverterStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverterStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterStatus(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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

        private void designGridOfSecs1ToHsmsConverterDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Converter",
                    "Description",
                    "Empty1",
                    // --
                    "Type",
                    "Converter IP",
                    "Up/Down",                    
                    // --
                    "Creator",
                    "Updater",
                    "Empty2",
                    // --
                    "Last Event Time",
                    "Last Event",
                    "Empty3"
                };

                // --

                grdS2HCvtDetail.addColumns(3, columns);
                grdS2HCvtDetail.setColumnHeaderWidth(120);
                // --
                grdS2HCvtDetail.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdS2HCvtDetail.Rows[0].Cells[4].Value = string.Empty;
                grdS2HCvtDetail.Rows[2].Cells[4].Value = string.Empty;
                grdS2HCvtDetail.Rows[3].Cells[4].Value = string.Empty;

                // --

                columns = new string[]
                {
                    "State",
                    "Session ID",
                    "Serial Port",
                    // --
                    "Baud",                    
                    "R-Bit",
                    "Interleave",
                    // --
                    "Duplidate Error",                    
                    "Ignore System Bytes",                    
                    "Retry Limit",
                    // --
                    "T1",                    
                    "T2",                    
                    "T3",
                    // --
                    "T4",
                    "Empty1",
                    "Empty2"
                };

                // --

                grdSecs1.addColumns(3, columns);
                grdSecs1.setColumnHeaderWidth(120);
                // --
                grdSecs1.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdSecs1.Rows[4].Cells[2].Value = string.Empty;
                grdSecs1.Rows[4].Cells[4].Value = string.Empty;

                // --

                columns = new string[]
                {
                    "State",
                    "Session ID",
                    "Connect Mode",
                    // --
                    "Local IP",                    
                    "Local Port",
                    "Remote IP",
                    // --
                    "Remote Port",                    
                    "Link Test Period",
                    "T3",
                    // --
                    "T5",                    
                    "T6",
                    "T7",
                    // --
                    "T8",
                    "Empty1",
                    "Empty2"
                };

                // --

                grdHsms.addColumns(3, columns);
                grdHsms.setColumnHeaderWidth(120);
                // --
                grdHsms.DisplayLayout.Override.TipStyleCell = TipStyle.Show;

                // --

                grdHsms.Rows[4].Cells[2].Value = string.Empty;
                grdHsms.Rows[4].Cells[4].Value = string.Empty;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clear(
            )
        {
            try
            {
                // ***
                // SECS1 To HSMS Converter Detail Information Clear
                // ***
                grdS2HCvtDetail.beginUpdate();
                grdS2HCvtDetail.clearColumnValue();
                grdS2HCvtDetail.endUpdate();
            }
            catch (Exception ex)
            {
                grdS2HCvtDetail.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSecs1ToHsmsConverterDetail(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string eqpName = string.Empty;
            string eqpDesc = string.Empty;
            string eqpRecipe = string.Empty;
            string type = string.Empty;
            string area = string.Empty;
            string line = string.Empty;
            string controlMode = string.Empty;
            string priState = string.Empty;
            string state = string.Empty;
            string eqMdln = string.Empty;
            string eqSoftRev = string.Empty;
            string eqEventDefine = string.Empty;
            string creator = string.Empty;
            string updater = string.Empty;
            string lastEventTime = string.Empty;
            string lastEventID = string.Empty;

            try
            {
                grdS2HCvtDetail.beginUpdate();
                grdS2HCvtDetail.clearColumnValue();
                // --
                grdSecs1.beginUpdate();
                grdSecs1.clearColumnValue();
                // --
                grdHsms.beginUpdate();
                grdHsms.clearColumnValue();

                // --

                #region Validation

                if (txtConverter.Text == string.Empty)
                {
                    grdS2HCvtDetail.endUpdate();
                    grdSecs1.endUpdate();
                    grdHsms.endUpdate();
                    txtConverter.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Converter" }));
                }

                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("cvt_name", txtConverter.Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverterStatus", "SearchSecs1ToHsmsConverter", fSqlParams, true);
                row = dt.Rows[0];

                // --

                creator = row[5].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[6].ToString()) + "]";
                updater = row[7].ToString() + " [" + FDataConvert.defaultDataTimeFormating(row[8].ToString()) + "]";
                lastEventTime = FDataConvert.defaultDataTimeFormating(row[9].ToString());

                // --

                cellValues = new object[] {
                    row[0].ToString(),       // Converter
                    row[1].ToString(),       // Description
                    string.Empty,            // Empty1
                    // --
                    row[2].ToString(),       // Type
                    row[3].ToString(),       // Converter IP
                    row[4].ToString(),       // Up/Down
                    // --
                    creator,                 // Creator
                    updater,                 // Updater                   
                    string.Empty,            // Empty1
                    // --
                    lastEventTime ,          // Last Event Time
                    row[10].ToString(),      // Last Event
                    string.Empty             // Empty2                    
                    };
                grdS2HCvtDetail.setColumnValues(cellValues);

                // --

                cell = grdS2HCvtDetail.getColumn("Up/Down");
                if (cell.Text == FUpDown.Down.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }

                // --

                cellValues = new object[] {
                    row[11].ToString(),       // SECS1 State
                    row[12].ToString(),       // SECS1 Session ID
                    row[13].ToString(),       // SECS1 Serial Port
                    // --
                    row[14].ToString(),       // SECS1 Baud
                    row[15].ToString(),       // SECS1 R-Bit
                    row[16].ToString(),       // SECS1 Interleave
                    // --
                    row[17].ToString(),       // SECS1 Duplidate Error
                    row[18].ToString(),       // SECS1 Ignore System Bytes     
                    row[19].ToString(),       // SECS1 Retry Limit
                    // --
                    row[20].ToString(),       // SECS1 T1
                    row[21].ToString(),       // SECS1 T2
                    row[22].ToString(),       // SECS1 T3                  
                    // --
                    row[23].ToString(),       // SECS1 T4
                    string.Empty,             // Empty 1
                    string.Empty              // Empty 2                  
                    };
                grdSecs1.setColumnValues(cellValues);

                // --

                cell = grdSecs1.getColumn("State");
                if (cell.Text != FCommunicationState.Selected.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }

                // --

                cellValues = new object[] {
                    row[24].ToString(),       // HSMS State
                    row[25].ToString(),       // HSMS Session ID
                    row[26].ToString(),       // HSMS Connect Mode
                    // --
                    row[27].ToString(),       // HSMS Local IP
                    row[28].ToString(),       // HSMS Local Port
                    row[29].ToString(),       // HSMS Remote IP
                    // --
                    row[30].ToString(),       // HSMS Remote Port
                    row[31].ToString(),       // HSMS Link Test Period
                    row[32].ToString(),       // HSMS T3
                    // --
                    row[33].ToString(),       // HSMS T5
                    row[34].ToString(),       // HSMS T6
                    row[35].ToString(),       // HSMS T7                  
                    // --
                    row[36].ToString(),       // HSMS T8
                    string.Empty,             // Empty 1
                    string.Empty              // Empty 2                  
                    };
                grdHsms.setColumnValues(cellValues);

                // --

                cell = grdHsms.getColumn("State");
                if (cell.Text != FCommunicationState.Selected.ToString())
                {
                    cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    cell.Appearance.ForeColor = Color.Red;
                }

                // --

                grdS2HCvtDetail.endUpdate();
                grdSecs1.endUpdate();
                grdHsms.endUpdate();

                // --

                grdS2HCvtDetail.Focus();
            }
            catch (Exception ex)
            {
                grdS2HCvtDetail.endUpdate();
                grdSecs1.endUpdate();
                grdHsms.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refresh(
            )
        {
            try
            {
                refreshGridOfSecs1ToHsmsConverterDetail();
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

        private void export(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Secs1ToHsmsConverterStatus.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export SECS1 To HSMS Converter Status to Excel";
                sfd.Filter = "Excel Files | *.xlsx";
                sfd.DefaultExt = "xlsx";
                sfd.InitialDirectory = m_fAdmCore.fOption.recentExportPath;
                sfd.FileName = fileName;
                // --
                if (sfd.ShowDialog(m_fAdmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                fileName = sfd.FileName;

                // --

                fExcelExp = new FExcelExporter2(fileName, m_fAdmCore.fUIWizard.fontName, 9);
                fExcelSht = fExcelExp.addExcelSheet("SECS1 To HSMS Converter Status");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // SECS1 To HSMS Converter Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("SECS1 To HSMS Converter Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdS2HCvtDetail, rowIndex, 0);
                // --
                rowIndex += 2;
                fExcelSht.writeText("* SECS1", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdSecs1, rowIndex, 0);
                // --
                rowIndex += 2;
                fExcelSht.writeText("* HSMS", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdHsms, rowIndex, 0);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 2;
                // --
                fExcelSht.writeText("Create Time: " + FDataConvert.defaultNowDateTimeToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

                // --

                fExcelExp.save();

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

                sfd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void attach(
            string converter
            )
        {
            try
            {
                txtConverter.Text = converter;

                // --

                refresh();

                // --

                txtConverter.Focus();
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

        #region FSecs1ToHsmsConverterStatus Form Event Handler

        private void FSecs1ToHsmsConverterStatus_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfSecs1ToHsmsConverterDetail();

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

        private void FSecs1ToHsmsConverterStatus_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                txtConverter.Focus();
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

        private void FSecs1ToHsmsConverterStatus_FormClosing(
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

        private void FSecs1ToHsmsConverterStatus_KeyDown(
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
                    refreshGridOfSecs1ToHsmsConverterDetail();
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

                if (e.Tool.Key == FMenuKey.MenuS2HCvtStatusRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuS2HCvtStatusExport)
                {
                    export();
                }

                // --

                //else if (e.Tool.Key == FMenuKey.MenuInqEqpEventDefineRequest)
                //{
                //    procMenuEquipmentEventDefineRequest();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEqpVersionRequest)
                //{
                //    procMenuEquipmentVersionRequest();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEqpControlModeRequest)
                //{
                //    procMenuEquipmentControlModeRequest();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEqpCustomRemoteCommandRequest)
                //{
                //    procMenuCustomRemoteCommandRequest();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEqpHistory)
                //{
                //    procMenuEquipmentHistory();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuInqEqpRemotePingTest)
                //{
                //    procMenuRemotePingTestByEquipment();
                //}
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

        #region txtConverter Control Event Handler

        private void txtConvertr_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FSecs1ToHsmsConverterSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FSecs1ToHsmsConverterSelector(m_fAdmCore, txtConverter.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtConverter.Text = fDialog.selectedConverter;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void txtConverter_ValueChanged(
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
