/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerIssueEventSummary.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.20
--  Description     : FAmate Admin Manager Server Issue Event Summary Form Class 
--  History         : Created by spike.lee at 2017.07.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Collections.Generic;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerIssueEventSummary : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private List<string> m_eventList = null;
        private Dictionary<string, string> m_eventDescList = null;
        private DataTable m_dtFsyssvrieh = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerIssueEventSummary(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerIssueEventSummary(
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
                    m_dtFsyssvrieh = null;
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

        private void designChartOfSummary(
            )
        {
            try
            {
                // ***
                // Design Chart Summary
                // *** 
                chartSummary.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartSummary.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartSummary.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartSummary.ChartAreas[0].AxisY.Title = "Count (n)";
                chartSummary.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartSummary.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartSummary.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartSummary.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartSummary.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;
                
                // --

                // ***
                // Design Series
                // ***
                chartSummary.addSeries("Event", SeriesChartType.Column);
                chartSummary.Series["Event"].Color = Color.IndianRed;
                chartSummary.Series["Event"].Label = "#VAL";
                chartSummary.Series["Event"].XValueType = ChartValueType.String;
                chartSummary.Series["Event"].YValueType = ChartValueType.UInt32;  
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

        private void designGridOfHistory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");                
                uds.Band.Columns.Add("Event");
                // --
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }
                // --
                uds.Band.Columns.Add("Server Type");
                uds.Band.Columns.Add("Server IP");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Agent");
                uds.Band.Columns.Add("Used Backup");
                uds.Band.Columns.Add("Backup Mode");
                uds.Band.Columns.Add("Backup Server");
                uds.Band.Columns.Add("B.Server Up/Down");
                uds.Band.Columns.Add("B.Server Status");
                uds.Band.Columns.Add("B.Server Agent");
                uds.Band.Columns.Add("OPC Server Monitoring");
                uds.Band.Columns.Add("OPC Server");
                uds.Band.Columns.Add("User ID");
                uds.Band.Columns.Add("Comment");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;                
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Server Type"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Status"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Agent"].Width = 60;
                grdList.DisplayLayout.Bands[0].Columns["Server IP"].Width = 110;
                grdList.DisplayLayout.Bands[0].Columns["Used Backup"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Backup Mode"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Backup Server"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Up/Down"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Status"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["B.Server Agent"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["OPC Server Monitoring"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["OPC Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["User ID"].Width = 100;
                for (int i = 1; i <= 20; i++)
                {
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].Width = 100;
                    grdList.DisplayLayout.Bands[0].Columns["Header " + i.ToString()].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    // --
                    grdList.DisplayLayout.Bands[0].Columns["Data " + i.ToString()].Width = 100;
                }
                grdList.DisplayLayout.Bands[0].Columns["Comment"].Width = 200;

                // --

                grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
                grdList.DisplayLayout.Override.FilterUIProvider = this.grdFilter;
                grdList.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuSisPrevious].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSisNext].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSisExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSisPrevious].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSisNext].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSisExport].SharedProps.Enabled = true;
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

        private void clear(
            )
        {
            try
            {
                #region Init Chart

                foreach (FChart fChart in new FChart[] { chartSummary })
                {
                    fChart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    fChart.ChartAreas[0].CursorX.Position = double.NaN;
                    fChart.ChartAreas[0].CursorY.Position = double.NaN;
                    // --
                    foreach (Series s in fChart.Series)
                    {
                        s.Points.Clear();                        
                    }
                    // --
                    fChart.Annotations.Clear();    
                
                    // --

                    fChart.ChartAreas[0].AxisY.Minimum = double.NaN;
                    fChart.ChartAreas[0].AxisY.Maximum = double.NaN;
                    fChart.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = false;     
                }

                #endregion

                // --

                #region Init Data Table

                if (m_dtFsyssvrieh == null)
                {
                    m_dtFsyssvrieh = new DataTable();
                    foreach (string clmName in new string[] { "TRAN_TIME", "HIST_SEQ", "SERVER", "EVENT_ID", "SVR_TYPE", "SVR_IP", "UP_DOWN", "STATUS", "ADA_UP_DOWN", "B_USED", "B_MODE", "B_SERVER", "B_UP_DOWN", "B_STATUS", "B_ADA_UP_DOWN", "OPC_SVR_MON", "OPC_SVR_UP_DOWN", "TRAN_USER_ID" })
                    {
                        // ***
                        // 2017.04.04 by spike.lee
                        // HIST_SEQ Sort를 숫자형으로 적용하도록 수정
                        // ***
                        if (clmName == "HIST_SEQ")
                        {
                            m_dtFsyssvrieh.Columns.Add(clmName, typeof(UInt64));
                        }
                        else
                        {
                            m_dtFsyssvrieh.Columns.Add(clmName, typeof(string));
                        }
                    }
                    // --
                    for (int i = 1; i <= 20; i++)
                    {
                        foreach (string clmName in new string[] { "EVT_H", "EVT_D" })
                        {
                            m_dtFsyssvrieh.Columns.Add(string.Format("{0}_{1}", clmName, i.ToString()), typeof(string));
                        }
                    }
                    // --
                    m_dtFsyssvrieh.Columns.Add("TRAN_COMMENT", typeof(string));
                }
                m_dtFsyssvrieh.Rows.Clear();

                #endregion

                // --

                #region Init Grid

                initPropOfServerHistory();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                #endregion

                // --

                refreshChartOfSummary();

                // --

                refreshTotal();

                // --

                m_cleared = true;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshChartOfSummary(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string evt = string.Empty;
            string desc = string.Empty;
            int pointIndex = 0;
            int nextRowNumber = 0;

            try
            {
                m_eventList = new List<string>();
                m_eventDescList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventSummary", "ListServerEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        desc = r[1].ToString();
                        m_eventList.Add(evt);
                        m_eventDescList.Add(evt, desc);
                        // --
                        foreach (Series s in chartSummary.Series)
                        {
                            pointIndex = s.Points.AddXY(evt, double.NaN);
                            s.Points[pointIndex].Tag = evt;
                            s.Points[pointIndex].IsEmpty = true;
                            s.Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, desc, 0);
                            s.Points[pointIndex].LabelToolTip = evt;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (m_eventList.Count == 0)
                {
                    foreach (Series s in chartSummary.Series)
                    {
                        s.Points.Add(
                            new DataPoint(chartSummary.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
                            );
                    }
                }         
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

        private void refreahChartOfServerIssueEventSummary(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string evt = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int pointCount = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventSummary", "SearchServerIssueEventSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        if (m_eventList.Contains(evt))
                        {
                            if (!UInt32.TryParse(r[1].ToString(), out count))
                            {
                                count = 0;
                            }
                            // --
                            pointIndex = chartSummary.Series[0].Points.AddXY(evt, count);
                            chartSummary.Series[0].Points[pointIndex].Tag = evt;
                            chartSummary.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, m_eventDescList[evt], count);

                            // --

                            pointCount++;
                        }
                    }
                } while (nextRowNumber >= 0);

                // -

                if (pointCount > 0)
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in chartSummary.Series)
                    {
                        if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                        {
                            emptyPoints = s.Points.Where(p => p.IsEmpty).ToList();
                            foreach (DataPoint p in emptyPoints)
                            {
                                s.Points.Remove(p);
                            }
                        }
                    }
                    // --
                    chartSummary.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }  
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                emptyPoints = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshGridOfServerHistory(
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            object[] cellValues = null;
            int rowIndex = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));                
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventSummary", "SearchServerIeh", fSqlParams, false, ref nextRowNumber))
                    {
                        dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrieh, LoadOption.OverwriteChanges);
                    }
                }
                while (nextRowNumber >= 0);

                // --

                grdList.beginUpdate(false);

                // --

                m_dtFsyssvrieh.DefaultView.Sort = "HIST_SEQ ASC";
                foreach (DataRow r in m_dtFsyssvrieh.DefaultView.ToTable().Rows)
                {
                    cellValues = new object[] {
                        FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()),
                        r["EVENT_ID"].ToString(),
                        // --
                        r["EVT_H_1"].ToString(),
                        r["EVT_D_1"].ToString(),
                        r["EVT_H_2"].ToString(),
                        r["EVT_D_2"].ToString(),
                        r["EVT_H_3"].ToString(),
                        r["EVT_D_3"].ToString(),
                        r["EVT_H_4"].ToString(),
                        r["EVT_D_4"].ToString(),
                        r["EVT_H_5"].ToString(),
                        r["EVT_D_5"].ToString(),
                        r["EVT_H_6"].ToString(),
                        r["EVT_D_6"].ToString(),            
                        r["EVT_H_7"].ToString(),
                        r["EVT_D_7"].ToString(),   
                        r["EVT_H_8"].ToString(),
                        r["EVT_D_8"].ToString(),     
                        r["EVT_H_9"].ToString(),
                        r["EVT_D_9"].ToString(),
                        r["EVT_H_10"].ToString(),
                        r["EVT_D_10"].ToString(),
                        r["EVT_H_11"].ToString(),
                        r["EVT_D_11"].ToString(),
                        r["EVT_H_12"].ToString(),
                        r["EVT_D_12"].ToString(),
                        r["EVT_H_13"].ToString(),
                        r["EVT_D_13"].ToString(),
                        r["EVT_H_14"].ToString(),
                        r["EVT_D_14"].ToString(),
                        r["EVT_H_15"].ToString(),
                        r["EVT_D_15"].ToString(),
                        r["EVT_H_16"].ToString(),
                        r["EVT_D_16"].ToString(),
                        r["EVT_H_17"].ToString(),
                        r["EVT_D_17"].ToString(),
                        r["EVT_H_18"].ToString(),
                        r["EVT_D_18"].ToString(),
                        r["EVT_H_19"].ToString(),
                        r["EVT_D_19"].ToString(),
                        r["EVT_H_20"].ToString(),
                        r["EVT_D_20"].ToString(),
                        // --
                        r["SVR_TYPE"].ToString(),
                        r["SVR_IP"].ToString(),
                        r["UP_DOWN"].ToString(),
                        r["STATUS"].ToString(),
                        r["ADA_UP_DOWN"].ToString(),
                        r["B_USED"].ToString(),
                        r["B_MODE"].ToString(),
                        r["B_SERVER"].ToString(),
                        r["B_UP_DOWN"].ToString(),
                        r["B_STATUS"].ToString(),
                        r["B_ADA_UP_DOWN"].ToString(),
                        r["OPC_SVR_MON"].ToString(),
                        r["OPC_SVR_UP_DOWN"].ToString(),
                        r["TRAN_USER_ID"].ToString(),                        
                        r["TRAN_COMMENT"].ToString()
                        };
                    // --
                    rowIndex = grdList.appendDataRow(r["HIST_SEQ"].ToString(), cellValues).Index;
                    grdList.Rows[rowIndex].Tag = r;

                    //-- 

                    if (m_eventDescList.ContainsKey(r["EVENT_ID"].ToString()))
                    {
                        grdList.Rows[rowIndex].Cells["Event"].ToolTipText = m_eventDescList[r["EVENT_ID"].ToString()];
                    }
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdList.Rows.VisibleRowCount.ToString("#,##0") + " / " + grdList.Rows.Count.ToString("#,##0");                
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

        private void initPropOfServerHistory(
           )
        {
            try
            {
                pgdProp.selectedObject = new FPropServerHistory(m_fAdmCore, pgdProp);
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

        private void procMenuRefresh(
            )
        {
            try
            {
                clear();

                // --

                if (txtSvrName.Text.Trim() == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Server" }));
                }

                // --

                refreahChartOfServerIssueEventSummary();
                refreshGridOfServerHistory();
                // --
                m_cleared = false;

                // --

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

        private void procMenuPrevious(
            )
        {
            try
            {
                udtDate.Value = udtDate.DateTime.AddDays(-1).ToString("yyyy-MM-dd");

                // --

                refreahChartOfServerIssueEventSummary();
                refreshGridOfServerHistory();
                // --
                m_cleared = false;

                // --

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

        private void procMenuNext(
            )
        {
            try
            {
                udtDate.Value = udtDate.DateTime.AddDays(1).ToString("yyyy-MM-dd");

                // --

                refreahChartOfServerIssueEventSummary();
                refreshGridOfServerHistory();
                // --
                m_cleared = false;

                // --

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

        private void procMenuExport(
            )
        {
            SaveFileDialog sfd = null;
            string fileName = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerIssueEventSummary" + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Server Issue Event Summary to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Issue Event Summary");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Input Condition (입력 조건) Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblDate.Text, udtDate.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 0);

                // --

                // ***
                // Server Issue Event Summary Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartSummary, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Server History Grid Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Issue Event History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdList, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeText("Total Count: " + grdList.Rows.Count.ToString(), rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);

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
            string tranDate,
            string server
            )
        {
            try
            {
                udtDate.Value = tranDate;
                txtSvrName.Text = server;

                // --

                tabMain.SelectedTab = tabMain.Tabs["Summary"];

                // --

                procMenuRefresh();

                // --

                udtDate.Focus();
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

        #region FServerIssueEventSummary Form Event Handler

        private void FServerIssueEventSummary_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
           
                designChartOfSummary();
                designGridOfHistory();

                // --

                udtDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

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

        private void FServerIssueEventSummary_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --              
                                
                udtDate.Focus();

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

        private void FServerIssueEventSummary_FormClosing(
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

        private void FServerIssueEventSummary_KeyDown(
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
                    procMenuRefresh();
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

                if (e.Tool.Key == FMenuKey.MenuSisRefresh)
                {
                    procMenuRefresh();                    
                }
                else if (e.Tool.Key == FMenuKey.MenuSisPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuSisNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuSisExport)
                {
                    procMenuExport();
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

        #region udtDate Control Event Handler

        private void udtDate_KeyDown(
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
                    procMenuRefresh();
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

        //------------------------------------------------------------------------------------------------------------------------

        private void udtDate_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!m_cleared)
                {
                    clear();
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

        #region txtSvrName Control Event Handler

        private void txtSvrName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FServerSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FServerSelector(m_fAdmCore, FServerType.Real.ToString(), txtSvrName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtSvrName.Text = fDialog.selectedServer;
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

        private void txtSvrName_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!m_cleared)
                {
                    clear();
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

                pgdProp.selectedObject = new FPropServerHistory(m_fAdmCore, pgdProp, (DataRow)grdList.ActiveRow.Tag);
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

        private void grdList_AfterRowFilterChanged(
            object sender,
            AfterRowFilterChangedEventArgs e
            )
        {
            int activateIndex = -1;

            try
            {
                FCursor.waitCursor();

                // --

                initPropOfServerHistory();
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

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
