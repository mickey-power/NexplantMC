/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverterList.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.24
--  Description     : FAMate Admin Manager SECS1 To HSMS Converter List Form Class 
--  History         : Created by baehyun seo at 2017.04.24
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverterList : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverterList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterList(
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
        
        private void designGridOfSecs1ToHsmsConverterList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdS2HCvtList.dataSource;
                // --
                uds.Band.Columns.Add("Converter");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Converter IP");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("SECS1 State");
                uds.Band.Columns.Add("HSMS State");
                // --
                uds.Band.Columns.Add("SECS1 Session ID");
                uds.Band.Columns.Add("SECS1 Serial Port");
                uds.Band.Columns.Add("SECS1 Baud");
                uds.Band.Columns.Add("SECS1 R-Bit");                
                uds.Band.Columns.Add("SECS1 Interleave");
                uds.Band.Columns.Add("SECS1 Duplicate Error");
                uds.Band.Columns.Add("SECS1 Ignore System Bytes");
                uds.Band.Columns.Add("SECS1 Retry Limit");
                uds.Band.Columns.Add("SECS1 T1");
                uds.Band.Columns.Add("SECS1 T2");
                uds.Band.Columns.Add("SECS1 T3");
                uds.Band.Columns.Add("SECS1 T4");
                // --
                uds.Band.Columns.Add("HSMS Session ID");
                uds.Band.Columns.Add("HSMS Connect Mode");
                uds.Band.Columns.Add("HSMS Local IP");
                uds.Band.Columns.Add("HSMS Local Port");
                uds.Band.Columns.Add("HSMS Remote IP");
                uds.Band.Columns.Add("HSMS Remote Port");
                uds.Band.Columns.Add("HSMS Link Test Period");
                uds.Band.Columns.Add("HSMS T3");
                uds.Band.Columns.Add("HSMS T5");
                uds.Band.Columns.Add("HSMS T6");
                uds.Band.Columns.Add("HSMS T7");
                uds.Band.Columns.Add("HSMS T8");
                // --
                uds.Band.Columns.Add("Last Event Time");
                uds.Band.Columns.Add("Last Event ID");
                uds.Band.Columns.Add("Create User ID");
                uds.Band.Columns.Add("Create Time");
                uds.Band.Columns.Add("Update User ID");
                uds.Band.Columns.Add("Update Time");

                // --

                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter"].CellAppearance.Image = Properties.Resources.S2HCvt;
                
                // --

                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Session ID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Baud"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Retry Limit"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T1"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T2"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T3"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T4"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Session ID"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Local Port"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Remote Port"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Link Test Period"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T3"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T5"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T6"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T7"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T8"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;                
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Last Event Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Create Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Update Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // --

                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter"].Header.Fixed = true;

                // --

                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter"].Width = 120;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Type"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter IP"].Width = 100;                
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 State"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS State"].Width = 70;
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Session ID"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Serial Port"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Baud"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 R-Bit"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Interleave"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Duplicate Error"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Ignore System Bytes"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 Retry Limit"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T1"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T2"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T3"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["SECS1 T4"].Width = 70;
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Session ID"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Connect Mode"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Local IP"].Width = 100;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Local Port"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Remote IP"].Width = 100;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Remote Port"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS Link Test Period"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T3"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T5"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T6"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T7"].Width = 70;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["HSMS T8"].Width = 70;
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Last Event Time"].Width = 165;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Last Event ID"].Width = 100;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Create User ID"].Width = 100;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Create Time"].Width = 165;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Update User ID"].Width = 100;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Update Time"].Width = 165;

                // --

                grdS2HCvtList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdS2HCvtList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
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

        private void clearGridOfSEcs1ToHsmsConverterDetail(
            )
        {
            try
            {
                grdS2HCvtDetail.beginUpdate();
                grdS2HCvtDetail.clearColumnValue();
                grdS2HCvtDetail.endUpdate();

                // --

                grdSecs1.beginUpdate();
                grdSecs1.clearColumnValue();
                grdSecs1.endUpdate();

                // --

                grdHsms.beginUpdate();
                grdHsms.clearColumnValue();
                grdHsms.endUpdate();
            }
            catch (Exception ex)
            {
                grdS2HCvtDetail.endUpdate();
                grdHsms.endUpdate();
                grdSecs1.endUpdate();
                // --
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
                clearGridOfSEcs1ToHsmsConverterDetail();
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

        private void refreshGridOfSecs1ToHsmsConverter(
             )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            object[] cellValues = null;
            string key = string.Empty;
            string beforeKey = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string lastEventTime = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;

            try
            {
                clear();

                // --

                beforeKey = grdS2HCvtList.activeDataRowKey;
                // --
                grdS2HCvtList.beginUpdate(false);
                grdS2HCvtList.removeAllDataRow();
                grdS2HCvtList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverterList", "ListSecs1ToHsmsConverterList", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        lastEventTime = FDataConvert.defaultDataTimeFormating(r[31].ToString());
                        createTime = FDataConvert.defaultDataTimeFormating(r[34].ToString());
                        updateTime = FDataConvert.defaultDataTimeFormating(r[36].ToString());

                        // --                        

                        cellValues = new object[] {
                            r[0].ToString(),    // Converter
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // Type
                            r[3].ToString(),    // Converter IP
                            r[4].ToString(),    // Up/Down                            
                            r[5].ToString(),    // SECS1 State
                            r[6].ToString(),    // HSMS State
                            // --
                            r[7].ToString(),    // SECS1 Session ID
                            r[8].ToString(),    // SECS1 Serial Port
                            r[9].ToString(),   // SECS1 Baud
                            r[10].ToString(),   // SECS1 R-Bit
                            r[11].ToString(),   // SECS1 Interleave
                            r[12].ToString(),   // SECS1 Duplidate Error                             
                            r[13].ToString(),   // SECS1 Ignore System Bytes
                            r[14].ToString(),   // SECS1 Retry Limit                     
                            r[15].ToString(),   // SECS1 T1
                            r[16].ToString(),   // SECS1 T2
                            r[17].ToString(),   // SECS1 T3
                            r[18].ToString(),   // SECS1 T4
                            // --
                            r[19].ToString(),   // HSMS Session ID
                            r[20].ToString(),   // HSMS Connect Mode
                            r[21].ToString(),   // HSMS Local IP
                            r[22].ToString(),   // HSMS Local Port
                            r[23].ToString(),   // HSMS Remote IP
                            r[24].ToString(),   // HSMS Remote Port
                            r[25].ToString(),   // HSMS Link Test Period
                            r[26].ToString(),   // HSMS T3
                            r[27].ToString(),   // HSMS T5
                            r[28].ToString(),   // HSMS T6
                            r[29].ToString(),   // HSMS T7
                            r[30].ToString(),   // HSMS T8
                            // --
                            lastEventTime,      // Last Event Time
                            r[32].ToString(),   // Last Event ID
                            r[33].ToString(),   // Create User ID
                            createTime,         // Create Time
                            r[35].ToString(),   // Update User ID
                            updateTime          // Update Time
                            };
                        key = (string)cellValues[0];
                        index = grdS2HCvtList.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdS2HCvtList.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        cell = row.Cells["SECS1 State"];
                        if (cell.Text != FCommunicationState.Selected.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }

                        cell = row.Cells["HSMS State"];
                        if (cell.Text != FCommunicationState.Selected.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdS2HCvtList.endUpdate(false);

                // --

                if (grdS2HCvtList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdS2HCvtList.activateDataRow(beforeKey);
                    }
                    if (grdS2HCvtList.activeDataRow == null)
                    {
                        grdS2HCvtList.ActiveRow = grdS2HCvtList.Rows[0];
                    }
                }

                // --

                lblTotal.Text = grdS2HCvtList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdS2HCvtList.Rows.Count.ToString("#,##0");

                // --

                if (tabMain.ActiveTab.Key == "S2HCvtList")
                {
                    grdS2HCvtList.Focus();
                }
            }
            catch (Exception ex)
            {
                grdS2HCvtList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
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
            string creator = string.Empty;
            string updater = string.Empty;
            string lastEventTime = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;

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
                if (grdS2HCvtList.activeDataRow == null)
                {
                    grdS2HCvtDetail.endUpdate();
                    grdSecs1.endUpdate();
                    grdHsms.endUpdate();
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("cvt_name", this.grdS2HCvtList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverterList", "SearchSecs1ToHsmsConverter", fSqlParams, true);
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
                    string.Empty,            // Empty2
                    // --
                    lastEventTime ,          // Last Event Time
                    row[10].ToString(),      // Last Event
                    string.Empty             // Empty3                    
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

                if (tabMain.ActiveTab.Key == "S2HCvtDetail")
                {
                    grdS2HCvtDetail.Focus();
                }
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
                if (tabMain.ActiveTab.Key == "S2HCvtList")
                {
                    refreshGridOfSecs1ToHsmsConverter();
                }                
                else
                {
                    refreshGridOfSecs1ToHsmsConverterDetail();                    
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

        private void exportGridOfSecs1ToHsmsConverter(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Secs1ToHsmsConverterList.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export SECS1 To HSMS Converter List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("SECS1 To HSMS Converter List");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // SECS1 To HSMS Converter List Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("SECS1 To HSMS Converter List") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdS2HCvtList, rowIndex, 0);
                // --
                rowIndex += 1;
                // --
                fExcelSht.writeText("Total Count: " + grdS2HCvtList.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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
                if(fExcelExp != null)
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

        private void exportGridOfSecs1ToHsmsConverterDetail(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_Secs1ToHsmsConverterList_" + tabMain.ActiveTab.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export SECS1 To HSMS Converter List to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("SECS1 To HSMS Converter List");

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
                
        private void export(
            )
        {
            try
            {
                if (tabMain.ActiveTab.Key == "S2HCvtList")
                {
                    exportGridOfSecs1ToHsmsConverter();
                }
                else
                {
                    exportGridOfSecs1ToHsmsConverterDetail();
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

        #region SECS1 To HSMS Convereter Popup Menu

        private void procMenuSecs1ToHsmsConverterStatus(
            )
        {
            FSecs1ToHsmsConverterStatus fSecs1ToHsmsConverterStatus = null;

            try
            {
                fSecs1ToHsmsConverterStatus = (FSecs1ToHsmsConverterStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterStatus));
                if (fSecs1ToHsmsConverterStatus == null)
                {
                    fSecs1ToHsmsConverterStatus = new FSecs1ToHsmsConverterStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterStatus);
                }
                fSecs1ToHsmsConverterStatus.activate();
                fSecs1ToHsmsConverterStatus.attach(grdS2HCvtList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterHistory(
            )
        {
            FSecs1ToHsmsConverterHistory fSecs1ToHsmsConverterHistory = null;

            try
            {
                fSecs1ToHsmsConverterHistory = (FSecs1ToHsmsConverterHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterHistory));
                if (fSecs1ToHsmsConverterHistory == null)
                {
                    fSecs1ToHsmsConverterHistory = new FSecs1ToHsmsConverterHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterHistory);
                }
                fSecs1ToHsmsConverterHistory.activate();
                fSecs1ToHsmsConverterHistory.attach(grdS2HCvtList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterLogList(
            )
        {
            FSecs1ToHsmsConverterLogList fSecs1ToHsmsConverterLogList = null;

            try
            {
                fSecs1ToHsmsConverterLogList = (FSecs1ToHsmsConverterLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterLogList));
                if (fSecs1ToHsmsConverterLogList == null)
                {
                    fSecs1ToHsmsConverterLogList = new FSecs1ToHsmsConverterLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterLogList);
                }
                fSecs1ToHsmsConverterLogList.activate();
                fSecs1ToHsmsConverterLogList.attach(grdS2HCvtList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterBackupLogList(
            )
        {
            FSecs1ToHsmsConverterBackupLogList fSecs1ToHsmsConverterBackupLogList = null;

            try
            {
                fSecs1ToHsmsConverterBackupLogList = (FSecs1ToHsmsConverterBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterBackupLogList));
                if (fSecs1ToHsmsConverterBackupLogList == null)
                {
                    fSecs1ToHsmsConverterBackupLogList = new FSecs1ToHsmsConverterBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterBackupLogList);
                }
                fSecs1ToHsmsConverterBackupLogList.activate();
                fSecs1ToHsmsConverterBackupLogList.attach(grdS2HCvtList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterBackupLogList = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FSecs1ToHsmsConverterList Form Event Handler

        private void FSecs1ToHsmsConverterList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfSecs1ToHsmsConverterList();
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

        private void FSecs1ToHsmsConverterList_Shown(
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

                grdS2HCvtList.Focus();
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

        private void FSecs1ToHsmsConverterList_FormClosing(
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

        private void FSecs1ToHsmsConverterList_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "S2HCvtList")
                    {
                        refreshGridOfSecs1ToHsmsConverter();
                    }
                    else
                    {
                        refreshGridOfSecs1ToHsmsConverterDetail();
                    }
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

                if (e.Tool.Key == FMenuKey.MenuS2HCvtListRefresh)
                {
                    refresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuS2HCvtListExport)
                {
                    export();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterStatus)
                {
                    procMenuSecs1ToHsmsConverterStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterHistory)
                {
                    procMenuSecs1ToHsmsConverterHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterLogList)
                {
                    procMenuSecs1ToHsmsConverterLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterBackupLogList)
                {
                    procMenuSecs1ToHsmsConverterBackupLogList();
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

        #region grdS2HCvtList Control Event Handler

        private void grdS2HCvtList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSecs1ToHsmsConverterDetail();
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

        private void grdS2HCvtList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.SelectedTab = tabMain.Tabs["S2HCvtDetail"];

                // --

                grdS2HCvtDetail.Focus();
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

        private void grdS2HCvtList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string serverType = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdS2HCvtList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdS2HCvtList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdS2HCvtList.ActiveRow = grdS2HCvtList.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterStatus].SharedProps.Enabled = grdS2HCvtList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterHistory].SharedProps.Enabled = grdS2HCvtList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterHistory) ? true : false;
                // --                
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterLogList].SharedProps.Enabled = grdS2HCvtList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterBackupLogList].SharedProps.Enabled = grdS2HCvtList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterBackupLogList) ? true : false;

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuS2HCvtListPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------     

        private void grdS2HCvtList_AfterRowFilterChanged(
            object sender,
            AfterRowFilterChangedEventArgs e
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

                grdS2HCvtList.beginUpdate();

                // --

                grdS2HCvtList.Selected.Rows.Clear();
                foreach (UltraGridRow r in e.Rows.GetFilteredInNonGroupByRows())
                {
                    if (r == grdS2HCvtList.ActiveRow)
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
                grdS2HCvtList.ActiveRow = e.Rows.GetRowAtVisibleIndex(activateIndex);
                grdS2HCvtList.DisplayLayout.RowScrollRegions[0].ScrollRowIntoView(grdS2HCvtList.ActiveRow);

                // --

                grdS2HCvtList.endUpdate();

                // --

                lblTotal.Text = grdS2HCvtList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdS2HCvtList.Rows.Count.ToString("#,##0");
            }
            catch (Exception ex)
            {
                grdS2HCvtList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstS2HCvtToolbar Control Event Handler

        private void rstS2HCvtToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdS2HCvtList.searchGridRow(e.searchWord))
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
