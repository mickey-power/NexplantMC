/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceHistory.cs
--  Creator         : jungyoul moon
--  Create Date     : 2013.02.18
--  Description     : FAMate Admin Manager Server Resource History Form Class 
--  History         : Created by jungyoul moon at 2013.02.18
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
    public partial class FServerResourceHistory : Nexplant.MC.Core.FaUIs.FBaseTabChildForm, FIInquiry
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const int MinimumTimePeriod = 1; // Min

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private FInquiryProgress m_fInqProgress = null;
        private DataTable m_dtFsyssvrrhi = null;
        private DataTable m_dtFraseaprhi = null;
        private DataTable m_dtFsyssvrdef = null;
        private List<string[]> m_lstReqTimes = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceHistory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceHistory(
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
                    m_dtFsyssvrrhi = null;
                    m_dtFraseaprhi = null;
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        private DateTime toDateTime
        {
            get
            {
                try
                {
                    return udtToTime.ReadOnly ? DateTime.Now : udtToTime.DateTime;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return DateTime.Now;
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

        private void designChartOfServerCpuHistory(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area 
                // ***
                chartCpu.ChartAreas[0].AxisX.Title = string.Empty;
                chartCpu.ChartAreas[0].AxisY.Title = "Usage(%)";
                // --
                chartCpu.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-24).ToOADate();
                chartCpu.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
                // --
                chartCpu.ChartAreas[0].AxisY.Minimum = 0;
                chartCpu.ChartAreas[0].AxisY.Maximum = 100;
                // --
                chartCpu.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                chartCpu.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartCpu.ChartAreas[0].AxisX.IsMarginVisible = false;
                // --
                chartCpu.ChartAreas[0].AxisX.ScaleView.MinSize = 10;
                chartCpu.ChartAreas[0].AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Minutes;
                chartCpu.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                chartCpu.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Seconds;
                chartCpu.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartCpu.ChartAreas[0].CursorX.Interval = 1;
                chartCpu.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
                chartCpu.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartCpu.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

                // ***
                // Design Legend Custom Item
                // ***
                legendItem = new LegendItem("Caution", Color.DarkOrange, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.DarkOrange;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartCpu.Legends[0].CustomItems.Add(legendItem);
                // --
                legendItem = new LegendItem("Danger", Color.Crimson, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.Crimson;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartCpu.Legends[0].CustomItems.Add(legendItem);

                // ***
                // Design Series
                // ***
                chartCpu.addSeries("Eap", SeriesChartType.Area);
                chartCpu.Series["Eap"].Color = Color.FromArgb(241, 185, 168);  
                chartCpu.Series["Eap"].Enabled = false;
                chartCpu.Series["Eap"].MarkerSize = 0;
                chartCpu.Series["Eap"].XValueType = ChartValueType.DateTime;
                // --
                chartCpu.addSeries("Server", SeriesChartType.Line);
                chartCpu.Series["Server"].Color = Color.DarkGray; 
                chartCpu.Series["Server"].BorderWidth = 1;
                chartCpu.Series["Server"].MarkerColor = Color.FromArgb(65, 140, 240);
                chartCpu.Series["Server"].MarkerSize = 6;
                chartCpu.Series["Server"].MarkerStyle = MarkerStyle.Circle;
                chartCpu.Series["Server"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                chartCpu.Series["Server"].XValueType = ChartValueType.DateTime;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                legendItem = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void designChartOfServerMemoryHistory(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area 
                // ***
                chartMem.ChartAreas[0].AxisX.Title = string.Empty;
                chartMem.ChartAreas[0].AxisY.Title = "Usage(%)";
                // --
                chartMem.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-24).ToOADate();
                chartMem.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
                // --
                chartMem.ChartAreas[0].AxisY.Minimum = 0;
                chartMem.ChartAreas[0].AxisY.Maximum = 100;
                // --
                chartMem.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                chartMem.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartMem.ChartAreas[0].AxisX.IsMarginVisible = false;
                // --
                chartMem.ChartAreas[0].AxisX.ScaleView.MinSize = 10;
                chartMem.ChartAreas[0].AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Minutes;
                chartMem.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                chartMem.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Seconds;
                chartMem.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartMem.ChartAreas[0].CursorX.Interval = 1;
                chartMem.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
                chartMem.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartMem.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

                // ***
                // Design Legend Custom Item
                // ***
                legendItem = new LegendItem("Caution", Color.DarkOrange, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.DarkOrange;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartMem.Legends[0].CustomItems.Add(legendItem);
                // --
                legendItem = new LegendItem("Danger", Color.Crimson, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.Crimson;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartMem.Legends[0].CustomItems.Add(legendItem);

                // ***
                // Design Series
                // ***
                chartMem.addSeries("Eap", SeriesChartType.Area);
                chartMem.Series["Eap"].Color = Color.FromArgb(241, 185, 168);
                chartMem.Series["Eap"].Enabled = false;
                chartMem.Series["Eap"].MarkerSize = 0;
                chartMem.Series["Eap"].XValueType = ChartValueType.DateTime;
                // --
                chartMem.addSeries("Server", SeriesChartType.Line);
                chartMem.Series["Server"].Color = Color.DarkGray;
                chartMem.Series["Server"].BorderWidth = 1;
                chartMem.Series["Server"].MarkerColor = Color.FromArgb(65, 140, 240);
                chartMem.Series["Server"].MarkerSize = 6;
                chartMem.Series["Server"].MarkerStyle = MarkerStyle.Circle;
                chartMem.Series["Server"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                chartMem.Series["Server"].XValueType = ChartValueType.DateTime;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                legendItem = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void designChartOfServerDiskHistory(
            )
        {
            LegendItem legendItem = null;
            string seriesName = string.Empty;

            try
            {
                // ***
                // Design Chart Area 
                // ***
                chartDsk.ChartAreas[0].AxisX.Title = string.Empty;
                chartDsk.ChartAreas[0].AxisY.Title = "Usage(%)";
                // --
                chartDsk.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-24).ToOADate();
                chartDsk.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
                // --
                chartDsk.ChartAreas[0].AxisY.Minimum = 0;
                chartDsk.ChartAreas[0].AxisY.Maximum = 100;
                // --
                chartDsk.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                chartDsk.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartDsk.ChartAreas[0].AxisX.IsMarginVisible = false;
                // --
                chartDsk.ChartAreas[0].AxisX.ScaleView.MinSize = 10;
                chartDsk.ChartAreas[0].AxisX.ScaleView.MinSizeType = DateTimeIntervalType.Minutes;
                chartDsk.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;
                chartDsk.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Seconds;
                chartDsk.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartDsk.ChartAreas[0].CursorX.Interval = 1;
                chartDsk.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Seconds;
                chartDsk.ChartAreas[0].CursorX.IsUserEnabled = true;
                chartDsk.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

                // ***
                // Design Legend Custom Item
                // ***
                legendItem = new LegendItem("Caution", Color.DarkOrange, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.DarkOrange;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartDsk.Legends[0].CustomItems.Add(legendItem);
                // --
                legendItem = new LegendItem("Danger", Color.Crimson, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.Crimson;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartDsk.Legends[0].CustomItems.Add(legendItem);

                // ***
                // Design Series
                // ***
                chartDsk.addSeries("Eap", SeriesChartType.Area);
                chartDsk.Series["Eap"].Color = Color.FromArgb(241, 185, 168);
                chartDsk.Series["Eap"].Enabled = false;
                chartDsk.Series["Eap"].LegendText = "MC's SUM";
                chartDsk.Series["Eap"].MarkerSize = 0;
                chartDsk.Series["Eap"].XValueType = ChartValueType.DateTime;
                // --
                for (int i = 1; i <= 10; i++)
                {
                    seriesName = string.Format("Server {0}", i);
                    // --
                    chartDsk.addSeries(seriesName, SeriesChartType.Line);
                    chartDsk.Series[seriesName].Color = Color.DarkGray;
                    chartDsk.Series[seriesName].BorderWidth = 1;
                    chartDsk.Series[seriesName].MarkerSize = 6;
                    chartDsk.Series[seriesName].MarkerStyle = MarkerStyle.Circle;
                    chartDsk.Series[seriesName].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                    chartDsk.Series[seriesName].XValueType = ChartValueType.DateTime;
                }
                // --
                chartDsk.Series["Server 1"].MarkerColor = Color.FromArgb(65, 140, 240);
                chartDsk.Series["Server 2"].MarkerColor = Color.FromArgb(5, 100, 146);
                chartDsk.Series["Server 3"].MarkerColor = Color.FromArgb(191, 191, 191);
                chartDsk.Series["Server 4"].MarkerColor = Color.FromArgb(26, 59, 105);
                chartDsk.Series["Server 5"].MarkerColor = Color.FromArgb(255, 227, 130);
                chartDsk.Series["Server 6"].MarkerColor = Color.FromArgb(18, 156, 221);
                chartDsk.Series["Server 7"].MarkerColor = Color.FromArgb(202, 107, 75);
                chartDsk.Series["Server 8"].MarkerColor = Color.FromArgb(0, 92, 219);
                chartDsk.Series["Server 9"].MarkerColor = Color.FromArgb(243, 210, 136);
                chartDsk.Series["Server 10"].MarkerColor = Color.FromArgb(80, 99, 129);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                legendItem = null;
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
                    mnuMenu.Tools[FMenuKey.MenuSrhExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSrhExport].SharedProps.Enabled = true;
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
                #region Init Data Table

                if (m_dtFsyssvrrhi == null)
                {
                    m_dtFsyssvrrhi = new DataTable();
                    // --
                    foreach (string clmName in new string[] { "TRAN_TIME", "CPU_USAGE", "MEMORY_USAGE" })
                    {
                        m_dtFsyssvrrhi.Columns.Add(clmName, typeof(string));
                    }
                    for (int i = 1; i <= 10; i++)
                    {
                        m_dtFsyssvrrhi.Columns.Add(string.Format("DISK_{0}_USAGE", i.ToString()), typeof(string));
                    }
                }
                m_dtFsyssvrrhi.Rows.Clear();
                // --
                if (m_dtFraseaprhi == null)
                {
                    m_dtFraseaprhi = new DataTable();
                    // --
                    foreach (string clmName in new string[] { "TRAN_TIME", "CPU_USAGE", "MEMORY_USAGE" })
                    {
                        m_dtFraseaprhi.Columns.Add(clmName, typeof(string));
                    }
                    for (int i = 1; i <= 10; i++)
                    {
                        m_dtFraseaprhi.Columns.Add(string.Format("DISK_{0}_USAGE", i.ToString()), typeof(string));
                    }
                }
                m_dtFraseaprhi.Rows.Clear();

                #endregion

                // --

                #region Init Chart

                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
                    fChart.ChartAreas[0].AxisX.Minimum = udtFromTime.DateTime.ToOADate();
                    fChart.ChartAreas[0].AxisX.Maximum = toDateTime.Subtract(udtFromTime.DateTime).TotalSeconds < MinimumTimePeriod ? udtFromTime.DateTime.AddMinutes(MinimumTimePeriod).ToOADate() : toDateTime.ToOADate();
                    // --
                    fChart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    fChart.ChartAreas[0].AxisY.Minimum = 0;
                    fChart.ChartAreas[0].AxisY.Maximum = 100;
                    fChart.ChartAreas[0].CursorX.Position = double.NaN;
                    fChart.ChartAreas[0].CursorY.Position = double.NaN;

                    // --

                    foreach (Series s in fChart.Series)
                    {
                        s.Points.Clear();
                        // --
                        s.Points.Add(
                            new DataPoint(fChart.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
                            );
                        // --
                        s.IsVisibleInLegend = false;
                    }

                    // --

                    fChart.Annotations.Clear();
                }

                #endregion

                // --

                refreshChartOfManagementRate();
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

        private void validationInputCondition(
            )
        {
            FSqlParams fSqlParams = null;
            string fromDateTime = string.Empty;
            string toDateTime = string.Empty;

            try
            {
                // ***
                // Date Time Validation
                // ***
                udtToTime.DateTime = udtToTime.ReadOnly ? DateTime.Now : udtToTime.DateTime;
                // --
                fromDateTime = udtFromTime.DateTime.ToString("yyyyMMddHHmmss000");
                toDateTime = udtToTime.DateTime.ToString("yyyyMMddHHmmss999");

                // --

                if (FCommon.convertStringToDateTime(toDateTime).Subtract(FCommon.convertStringToDateTime(fromDateTime)).TotalMilliseconds < 0)
                {
                    if (udtToTime.ReadOnly)
                    {
                        udtFromTime.Focus();
                    }
                    else
                    {
                        udtToTime.Focus();
                    }
                    // --
                    FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Start and End Time" }));
                }

                // --

                // ***
                // Server Validation
                // ***
                if (txtSvrName.Text.Trim() == string.Empty)
                {
                    txtSvrName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Server" }));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);
                // --
                m_dtFsyssvrdef = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceHistory", "HasServer", fSqlParams, false);
                if (m_dtFsyssvrdef.Rows.Count == 0)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Server" }));
                }
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

        public void request(
            )
        {
            try
            {
                if (bwRequest.IsBusy)
                {
                    return;
                }

                // --

                bwRequest.RunWorkerAsync();
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

        private void doCollect(
            BackgroundWorker worker
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            int procCount = 0;

            try
            {
                // ***
                // 시작 보고
                // ***
                worker.ReportProgress(0);

                // --

                // ***
                // Search Server Resource History
                // ***
                foreach (string[] reqTimes in m_lstReqTimes)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    // --

                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("server", txtSvrName.Text);
                    fSqlParams.add("tran_from_time", reqTimes[0]);
                    fSqlParams.add("tran_to_time", reqTimes[1]);

                    // --

                    procCount++;
                    nextRowNumber = 0;
                    // --
                    do
                    {
                        using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceHistory", "SearchResourceHistory", fSqlParams, false, ref nextRowNumber))
                        {
                            dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrrhi, LoadOption.OverwriteChanges);
                        }
                        // --
                        worker.ReportProgress(procCount);
                    }
                    while (nextRowNumber >= 0);

                    // --

                    procCount++;
                    nextRowNumber = 0;
                    // --
                    do
                    {
                        using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceHistory", "SearchEapResourceHistory", fSqlParams, false, ref nextRowNumber))
                        {
                            dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFraseaprhi, LoadOption.OverwriteChanges);
                        }
                        // --
                        worker.ReportProgress(procCount);
                    }
                    while (nextRowNumber >= 0);
                }
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

        private void refreshChartOfManagementRate(
            )
        {
            FSqlParams fSqlParams = null;
            
            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceHistory", "SearchManagementRate", fSqlParams, false))
                {
                    if (dt.Rows.Count > 0)
                    {
                        addManagementRate(chartCpu, "CPU Caution Rate", Convert.ToDouble(dt.Rows[0][0].ToString()), Color.DarkOrange, "%");
                        addManagementRate(chartCpu, "CPU Danger Rate", Convert.ToDouble(dt.Rows[0][1].ToString()), Color.Crimson, "%");
                        addManagementRate(chartMem, "Memory Caution Rate", Convert.ToDouble(dt.Rows[0][2].ToString()), Color.DarkOrange, "%");
                        addManagementRate(chartMem, "Memory Danger Rate", Convert.ToDouble(dt.Rows[0][3].ToString()), Color.Crimson, "%");
                        addManagementRate(chartDsk, "Disk Caution Rate", Convert.ToDouble(dt.Rows[0][4].ToString()), Color.DarkOrange, "%");
                        addManagementRate(chartDsk, "Disk Danger Rate", Convert.ToDouble(dt.Rows[0][5].ToString()), Color.Crimson, "%");
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
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshChartOfHistory(
            )
        {
            List<DataPoint> emptyPoints = null;
            string volume = string.Empty;
            double tranTime = double.NaN;
            double cpuUsage = double.NaN;
            double memUsage = double.NaN;
            double dskUsage = double.NaN;
            double tmp = double.NaN;

            try
            {
                m_dtFsyssvrrhi.DefaultView.Sort = "TRAN_TIME";
                foreach (DataRow r in m_dtFsyssvrrhi.DefaultView.ToTable().Rows)
                {
                    tranTime = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString())).ToOADate();

                    // --

                    // ***
                    // CPU USAGE
                    // ***
                    cpuUsage = double.TryParse(r["CPU_USAGE"].ToString(), out cpuUsage) ? cpuUsage : double.NaN;
                    chartCpu.Series["Server"].Points.AddXY(tranTime, cpuUsage);

                    // --

                    // ***
                    // MEMORY USAGE
                    // ***
                    if (double.TryParse(r["MEMORY_USAGE"].ToString(), out tmp))
                    {
                        memUsage = Math.Round((tmp * 100 / double.Parse(m_dtFsyssvrdef.Rows[0]["MEMORY"].ToString())), 2);
                    }
                    else
                    {
                        memUsage = double.NaN;
                    }
                    chartMem.Series["Server"].Points.AddXY(tranTime, memUsage);

                    // --

                    // ***
                    // DISK USAGE
                    // ***
                    for (int i = 1; i <= 10; i++)
                    {
                        volume = m_dtFsyssvrdef.Rows[0][string.Format("DISK_{0}", i.ToString())].ToString();
                        if (string.IsNullOrWhiteSpace(volume))
                        {
                            continue;
                        }

                        // --

                        chartDsk.Series[string.Format("Server {0}", i.ToString())].LegendText = volume;

                        // --

                        if (double.TryParse(r[string.Format("DISK_{0}_USAGE", i.ToString())].ToString(), out tmp))
                        {
                            dskUsage = Math.Round((tmp * 100 / double.Parse(m_dtFsyssvrdef.Rows[0][string.Format("DISK_{0}_SIZE", i.ToString())].ToString())), 2);
                        }
                        else
                        {
                            dskUsage = double.NaN;
                        }
                        chartDsk.Series[string.Format("Server {0}", i.ToString())].Points.AddXY(tranTime, dskUsage);
                    }
                }

                m_dtFraseaprhi.DefaultView.Sort = "TRAN_TIME";
                foreach (DataRow r in m_dtFraseaprhi.DefaultView.ToTable().Rows)
                {
                    tranTime = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString())).ToOADate();

                    // --

                    // ***
                    // CPU USAGE
                    // ***
                    cpuUsage = double.TryParse(r["CPU_USAGE"].ToString(), out cpuUsage) ? cpuUsage : double.NaN;
                    chartCpu.Series["Eap"].Points.AddXY(tranTime, cpuUsage);

                    // --

                    // ***
                    // MEMORY USAGE
                    // ***
                    if (double.TryParse(r["MEMORY_USAGE"].ToString(), out tmp))
                    {
                        memUsage = Math.Round((tmp * 100 / double.Parse(m_dtFsyssvrdef.Rows[0]["MEMORY"].ToString())), 2);
                    }
                    else
                    {
                        memUsage = double.NaN;
                    }
                    chartMem.Series["Eap"].Points.AddXY(tranTime, memUsage);
                }

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
                    foreach (Series s in fChart.Series)
                    {
                        if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                        {
                            emptyPoints = s.Points.Where(p => p.IsEmpty).ToList();
                            foreach (DataPoint p in emptyPoints)
                            {
                                s.Points.Remove(p);
                            }
                            // --
                            s.IsVisibleInLegend = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                emptyPoints = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        

        private void addManagementRate(
            FChart fChart,
            string name,
            double value,
            Color color,
            string unit
            )
        {
            HorizontalLineAnnotation hLineAnn = null;

            try
            {
                // ***
                // Horizontal Line Annotation
                // ***
                hLineAnn = new HorizontalLineAnnotation();
                // --
                hLineAnn.AxisY = fChart.ChartAreas[0].AxisY;
                hLineAnn.Name = name;
                hLineAnn.ClipToChartArea = fChart.ChartAreas[0].Name;
                hLineAnn.IsInfinitive = true;
                hLineAnn.LineColor = color;
                hLineAnn.LineDashStyle = ChartDashStyle.Dot;
                hLineAnn.LineWidth = 2;
                hLineAnn.Y = value;
                hLineAnn.Visible = true;
                hLineAnn.ToolTip = string.Format("{0} : {1} {2}", name, value, unit);
                // --
                fChart.Annotations.Add(hLineAnn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                hLineAnn = null;
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

                validationInputCondition();

                // --

                m_lstReqTimes = FCommon.generateRequestTimes(
                   FCommon.convertStringToDateTime(udtFromTime.DateTime.ToString("yyyyMMddHHmmss000")),
                   FCommon.convertStringToDateTime(udtToTime.DateTime.ToString("yyyyMMddHHmmss999"))
                   );

                // --

                m_fInqProgress.ReqCount = m_lstReqTimes.Count * 2;
                m_fInqProgress.StartPosition = FormStartPosition.CenterParent;
                m_fInqProgress.ShowDialog(this);
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerResourceHistory_" + txtSvrName.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Server Resource History to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Resource History");

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
                fExcelSht.writeCondition(lblFromTime.Text, udtFromTime.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblToTime.Text, udtToTime.Text, rowIndex, 2); 
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 4);
                
                // --

                // ***
                // Server Resource Cpu History Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("CPU History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartCpu, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Server Resource Memory History Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Memory History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartMem, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Server Resource Disk History Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Disk History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartDsk, rowIndex, 0, rowIndex + 21, 8);
                
                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 22;
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
            string serverName
            )
        {
            try
            {
                txtSvrName.Text = serverName;

                // --

                procMenuRefresh();

                // --

                udtFromTime.Focus();
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

        #region FServerResourceHistory Form Event Handler

        private void FServerResourceHistory_Load(
            object sender,
            EventArgs e
            )
        {
            DateTime dateTime;

            try
            {
                FCursor.waitCursor();

                // --
           
                designChartOfServerCpuHistory();
                designChartOfServerMemoryHistory();
                designChartOfServerDiskHistory();

                // --

                dateTime = DateTime.Now;
                // --
                udtFromTime.DateTime = DateTime.Parse(dateTime.AddDays(-m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd") + " 00:00:00.000");
                udtToTime.DateTime = dateTime;
                ((StateEditorButton)udtToTime.ButtonsLeft[0]).Checked = false;

                // --

                m_fInqProgress = new FInquiryProgress(m_fAdmCore, this);
                m_fInqProgress.Canceled += new EventHandler<EventArgs>(fInqProgress_Canceled);

                // --

                clear();

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

        private void FServerResourceHistory_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --              
                
                txtSvrName.Focus();
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

        private void FServerResourceHistory_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fInqProgress != null)
                {
                    m_fInqProgress.Canceled -= new EventHandler<EventArgs>(fInqProgress_Canceled);
                    // --
                    m_fInqProgress.Dispose();
                    m_fInqProgress = null;
                }

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

        private void FServerResourceHistory_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuSrhRefresh)
                {
                    procMenuRefresh();                    
                }
                else if (e.Tool.Key == FMenuKey.MenuSrhExport)
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

        #region udtFromTime Control Event Handler

        private void udtFromTime_KeyDown(
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

        private void udtFromTime_ValueChanged(
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

        #region udtToTime Control Event Handler

        private void udtToTime_AfterEditorButtonCheckStateChanged(
            object sender,
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (((StateEditorButton)e.Button).Checked)
                {
                    udtToTime.ReadOnly = false;
                    // --
                    udtToTime.Appearance.BackColor = Color.White;
                    udtToTime.Appearance.ForeColor = Color.Black;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.White;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.White;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.White;
                    udtToTime.ButtonAppearance.BackColor = Color.White;
                    // --
                    udtToTime.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59.999");
                }
                else
                {
                    udtToTime.ReadOnly = true;
                    // --
                    udtToTime.Appearance.BackColor = Color.WhiteSmoke;
                    udtToTime.Appearance.ForeColor = SystemColors.ControlDarkDark;
                    // --
                    udtToTime.ButtonsLeft[0].Appearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonsLeft[0].Appearance.BackColor = Color.WhiteSmoke;
                    // --
                    udtToTime.ButtonAppearance.BorderColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColor = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.BackColorDisabled = Color.WhiteSmoke;
                    udtToTime.ButtonAppearance.ForeColorDisabled = Color.DimGray;
                    // --
                    udtToTime.Value = DateTime.Now;
                }

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

        //------------------------------------------------------------------------------------------------------------------------

        private void udtToTime_KeyDown(
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

        private void udtToTime_ValueChanged(
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
        
        #region fInqProgress Control Event Handler

        private void fInqProgress_Canceled(
            object sender,
            EventArgs e
            )
        {
            try
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
                }
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

        #region bwRequest Control Event Handler

        private void bwRequest_DoWork(
            object sender,
            DoWorkEventArgs e
            )
        {
            try
            {
                doCollect((BackgroundWorker)sender);
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_ProgressChanged(
            object sender,
            ProgressChangedEventArgs e
            )
        {
            try
            {
                if (!bwRequest.CancellationPending)
                {
                    m_fInqProgress.changedProgress(e.ProgressPercentage, m_dtFsyssvrrhi.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                if (bwRequest.WorkerSupportsCancellation)
                {
                    bwRequest.CancelAsync();
                }
                // -
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void bwRequest_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e
            )
        {
            try
            {
                m_fInqProgress.Close();

                // --

                if (e.Error != null)
                {
                    throw e.Error;
                }

                // --

                refreshChartOfHistory();
            }
            catch (Exception ex)
            {
                this.Invoke(
                    new Action(() => { FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer); })
                    );
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region chkEap Control Event Handler

        private void chkEap_CheckedChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                chartCpu.Series["Eap"].Enabled = chkEap.Checked;
                chartMem.Series["Eap"].Enabled = chkEap.Checked;
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
