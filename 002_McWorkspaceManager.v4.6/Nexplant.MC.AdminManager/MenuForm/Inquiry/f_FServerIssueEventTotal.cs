/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerIssueEventTotal.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.31
--  Description     : FAmate Admin Manager Server Issue Event Total Form Class 
--  History         : Created by spike.lee at 2017.07.31
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
    public partial class FServerIssueEventTotal : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private Dictionary<string, string> m_eventList = null;
        private Dictionary<string, string> m_serverList = null;
        private DataTable m_dtFsyssvrieh = null;
        private string m_event = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerIssueEventTotal(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerIssueEventTotal(
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

        private void designChartOfEvent(
            )
        {
            try
            {
                // ***
                // Design Chart Event
                // *** 
                chartEvent.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEvent.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEvent.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEvent.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEvent.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEvent.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEvent.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEvent.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEvent.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEvent.addSeries("Event", SeriesChartType.Column);
                chartEvent.Series["Event"].Color = Color.IndianRed;
                chartEvent.Series["Event"].Label = "#VAL";
                chartEvent.Series["Event"].XValueType = ChartValueType.String;
                chartEvent.Series["Event"].YValueType = ChartValueType.UInt32;
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

        private void designChartOfServer(
            )
        {
            try
            {
                // ***
                // Design Chart Server
                // *** 
                chartServer.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartServer.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartServer.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartServer.ChartAreas[0].AxisY.Title = "Count (n)";
                chartServer.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartServer.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartServer.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartServer.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartServer.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartServer.addSeries("Server", SeriesChartType.Column);
                chartServer.Series["Server"].Color = Color.IndianRed;
                chartServer.Series["Server"].Label = "#VAL";
                chartServer.Series["Server"].XValueType = ChartValueType.String;
                chartServer.Series["Server"].YValueType = ChartValueType.UInt32;
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
                uds.Band.Columns.Add("Server");
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
                grdList.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
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
                    mnuMenu.Tools[FMenuKey.MenuSihExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSihExport].SharedProps.Enabled = true;
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

                foreach (FChart fChart in new FChart[] { chartEvent, chartServer })
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

                refreshChartOfEvent();
                refreshChartOfServer();

                // --

                initPropOfServerHistory();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                m_cleared = true;

                // --

                refreshTotal();

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

        private void clearServer(
            )
        {
            try
            {
                #region Init Chart

                foreach (FChart fChart in new FChart[] { chartServer })
                {
                    fChart.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = false;

                    // --

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
                }

                #endregion

                // --

                m_dtFsyssvrieh.Rows.Clear();

                // --

                refreshChartOfServer();

                // --

                initPropOfServerHistory();

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate();

                // --

                refreshTotal();
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

        private void refreshChartOfEvent(
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
                m_eventList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventTotal", "ListServerEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        desc = r[1].ToString();
                        m_eventList.Add(evt, desc);
                        // --
                        foreach (Series s in chartEvent.Series)
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
                    foreach (Series s in chartEvent.Series)
                    {
                        s.Points.Add(
                            new DataPoint(chartEvent.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
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

        private void refreshChartOfServer(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string server = string.Empty;
            string desc = string.Empty;
            int pointIndex = 0;
            int nextRowNumber = 0;

            try
            {
                m_serverList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventTotal", "ListServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        server = r[0].ToString();
                        desc = r[1].ToString();
                        m_serverList.Add(server, desc);
                        // --
                        foreach (Series s in chartServer.Series)
                        {
                            pointIndex = s.Points.AddXY(string.Format("{0} [{1}]", server, desc), double.NaN);
                            s.Points[pointIndex].Tag = server;
                            s.Points[pointIndex].IsEmpty = true;
                            s.Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", server, desc, 0);
                            s.Points[pointIndex].LabelToolTip = server;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (m_serverList.Count == 0)
                {
                    foreach (Series s in chartServer.Series)
                    {
                        s.Points.Add(
                            new DataPoint(chartServer.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
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

        private void refreahChartOfServerIssueEventTotal(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string evt = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            string fromDate = string.Empty;
            string toDate = string.Empty;
            int pointCount = 0;

            try
            {
                fromDate = udtFromDate.DateTime.ToString("yyyyMMdd");
                toDate = udtToDate.DateTime.ToString("yyyyMMdd");

                // --

                #region Validation

                if (string.Compare(fromDate, toDate) > 0)
                {
                    udtFromDate.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "From Date and To Date" }));
                }

                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("from_date", udtFromDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("to_date", udtToDate.DateTime.ToString("yyyyMMdd"));                
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventTotal", "SearchServerIssueEventTotal", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        if (m_eventList.ContainsKey(evt))
                        {
                            if (!UInt32.TryParse(r[1].ToString(), out count))
                            {
                                count = 0;
                            }
                            // --
                            pointIndex = chartEvent.Series[0].Points.AddXY(evt, count);
                            chartEvent.Series[0].Points[pointIndex].Tag = evt;
                            chartEvent.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, m_eventList[evt], count.ToString());

                            // --

                            pointCount++;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (pointCount > 0)
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in chartEvent.Series)
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
                    chartEvent.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
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

        private void refreahChartOfServerIssueEventSummary(
            string evt
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string server = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            string fromDate = string.Empty;
            string toDate = string.Empty;
            int pointCount = 0;

            try
            {
                fromDate = udtFromDate.DateTime.ToString("yyyyMMdd");
                toDate = udtToDate.DateTime.ToString("yyyyMMdd");

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("from_date", udtFromDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("to_date", udtToDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("event_id", evt);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventTotal", "SearchServerIssueEventSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        server = r[0].ToString();
                        if (m_serverList.ContainsKey(server))
                        {
                            if (!UInt32.TryParse(r[1].ToString(), out count))
                            {
                                count = 0;
                            }
                            // --
                            pointIndex = chartServer.Series[0].Points.AddXY(string.Format("{0} [{1}]", server, m_serverList[server]), count);
                            chartServer.Series[0].Points[pointIndex].Tag = server;
                            chartServer.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", server, m_serverList[server], count.ToString());

                            // --

                            pointCount++;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (pointCount > 0)
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in chartServer.Series)
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
                    chartServer.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
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

        private void refreshGridOfServrHistory(
            string server,
            string evt
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            object[] cellValues = null;
            int rowIndex = 0;

            try
            {
                initPropOfServerHistory();

                // --
                
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate(false);

                // --

                m_dtFsyssvrieh.Rows.Clear();

                // --


                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", server);
                fSqlParams.add("from_date", udtFromDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("to_date", udtToDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("event_id", evt);                
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerIssueEventTotal", "SearchServerIeh", fSqlParams, false, ref nextRowNumber))
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
                        r["SERVER"].ToString(),
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
                grdList.endUpdate(false);
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

                refreahChartOfServerIssueEventTotal();
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerIssueEventTotal" + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Server Issue Event Total to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Issue Event Total");

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
                fExcelSht.writeCondition(lblFromDate.Text, udtFromDate.Text, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblToDate.Text, udtToDate.Text, rowIndex, 0);
                
                // --

                // ***
                // Server Issue Event Total Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Issue Event Total") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEvent, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Server Issue Event Summary Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartServer, rowIndex, 0, rowIndex + 21, 8);

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FServerIssueEventTotal Form Event Handler

        private void FServerIssueEventTotal_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designChartOfEvent();
                designChartOfServer();
                designGridOfHistory();

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

        private void FServerIssueEventTotal_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --              

                udtFromDate.Value = DateTime.Now.AddDays(-1 * m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd");
                udtToDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                // -- 

                udtFromDate.Focus();

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

        private void FServerIssueEventTotal_FormClosing(
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

        private void FServerIssueEventTotal_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuSihRefresh)
                {
                    procMenuRefresh();                    
                }                
                else if (e.Tool.Key == FMenuKey.MenuSihExport)
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

        #region udtFromDate Control Event Handler

        private void udtFromDate_ValueChanged(
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

        #region chartEvent Control Event Handler

        private void chartEvent_MouseClick(
            object sender,
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string evt = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEvent.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    clearServer();

                    // --

                    evt = (string)chartEvent.Series["Event"].Points[ret.PointIndex].Tag;
                    refreahChartOfServerIssueEventSummary(evt);

                    // --

                    m_event = evt;
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

        private void chartEvent_MouseDoubleClick(
            object sender,
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEvent.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    tabMain.SelectedTab = tabMain.Tabs["Server"];
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

        #region chartServer Control Event Handler

        private void chartServer_MouseClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string server = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartServer.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    server = (string)chartServer.Series["Server"].Points[ret.PointIndex].Tag;
                    refreshGridOfServrHistory(server, m_event);
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

        private void chartServer_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartServer.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    tabMain.SelectedTab = tabMain.Tabs["History"];
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

        #region udtToDate Control Event Handler

        private void udtToDate_ValueChanged(
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

    }   // Class end
}   // Namespace end
