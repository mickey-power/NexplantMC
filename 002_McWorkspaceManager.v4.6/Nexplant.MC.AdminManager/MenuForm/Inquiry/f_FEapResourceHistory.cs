/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapResourceHistory.cs
--  Creator         : jungyoul moon
--  Create Date     : 2013.03.13
--  Description     : FAMate Admin Manager Eap Resource History Form Class 
--  History         : Created by jungyoul moon at 2013.02.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapResourceHistory : Nexplant.MC.Core.FaUIs.FBaseTabChildForm, FIInquiry
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
        private DataTable m_dtFraseaprhi = null;
        private List<string[]> m_lstReqTimes = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapResourceHistory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapResourceHistory(
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
                    m_dtFraseaprhi = null;
                    m_lstReqTimes = null;
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

        private void designChartOfEapCpuHistory(
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
                chartCpu.ChartAreas[0].AxisX.Minimum = udtFromTime.DateTime.ToOADate();
                chartCpu.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();
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

                // --

                // ***
                // Design Series
                // ***
                chartCpu.addSeries("Value", SeriesChartType.FastLine);
                chartCpu.Series["Value"].Color = Color.DarkGray;
                chartCpu.Series["Value"].BorderWidth = 1;
                chartCpu.Series["Value"].XValueType = ChartValueType.DateTime;
                chartCpu.Series["Value"].IsVisibleInLegend = false;
                // --
                chartCpu.addSeries("Cpu", SeriesChartType.FastPoint);
                chartCpu.Series["Cpu"].MarkerStyle = MarkerStyle.Circle;
                chartCpu.Series["Cpu"].MarkerSize = 6;
                chartCpu.Series["Cpu"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                chartCpu.Series["Cpu"].XValueType = ChartValueType.DateTime;
                chartCpu.Series["Cpu"].Legend = chartCpu.Legends[0].Name;

                // --

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

        private void designChartOfEapMemoryHistory(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area 
                // ***
                chartMem.ChartAreas[0].AxisX.Title = string.Empty;
                chartMem.ChartAreas[0].AxisY.Title = "Usage(MB)";
                chartMem.ChartAreas[0].AxisY.LabelStyle.Format = "F2";
                // --
                chartMem.ChartAreas[0].AxisX.Minimum = udtFromTime.DateTime.ToOADate();
                chartMem.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();
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

                // --

                // ***
                // Design Series
                // ***
                chartMem.addSeries("Value", SeriesChartType.FastLine);
                chartMem.Series["Value"].Color = Color.DarkGray;
                chartMem.Series["Value"].BorderWidth = 1;
                chartMem.Series["Value"].XValueType = ChartValueType.DateTime;
                chartMem.Series["Value"].IsVisibleInLegend = false;
                // --
                chartMem.addSeries("Memory", SeriesChartType.FastPoint);
                chartMem.Series["Memory"].MarkerStyle = MarkerStyle.Circle;
                chartMem.Series["Memory"].MarkerSize = 6;
                chartMem.Series["Memory"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(MB)";
                chartMem.Series["Memory"].XValueType = ChartValueType.DateTime;
                chartMem.Series["Memory"].Legend = chartMem.Legends[0].Name;

                // --

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

        private void designChartOfEapDiskHistory(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area 
                // ***
                chartDsk.ChartAreas[0].AxisX.Title = string.Empty;
                chartDsk.ChartAreas[0].AxisY.Title = "Usage(MB)";
                // --
                chartDsk.ChartAreas[0].AxisX.Minimum = udtFromTime.DateTime.ToOADate();
                chartDsk.ChartAreas[0].AxisX.Maximum = toDateTime.ToOADate();
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

                // --

                // ***
                // Design Series
                // ***
                chartDsk.addSeries("Value", SeriesChartType.FastLine);
                chartDsk.Series["Value"].Color = Color.DarkGray;
                chartDsk.Series["Value"].BorderWidth = 1;
                chartDsk.Series["Value"].XValueType = ChartValueType.DateTime;
                chartDsk.Series["Value"].IsVisibleInLegend = false;
                // --
                chartDsk.addSeries("Disk", SeriesChartType.FastPoint);
                chartDsk.Series["Disk"].MarkerStyle = MarkerStyle.Circle;
                chartDsk.Series["Disk"].MarkerSize = 6;
                chartDsk.Series["Disk"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(MB)";
                chartDsk.Series["Disk"].XValueType = ChartValueType.DateTime;
                chartDsk.Series["Disk"].Legend = chartDsk.Legends[0].Name;

                // --

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

        private void clear(
            )
        {
            try
            {
                #region Init Data Table

                if (m_dtFraseaprhi == null)
                {
                    m_dtFraseaprhi = new DataTable();
                    foreach (string clmName in new string[] { "TRAN_TIME", "CPU_USAGE", "MEMORY_USAGE", "DISK_USAGE" })
                    {
                        m_dtFraseaprhi.Columns.Add(clmName, typeof(string));
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
                // Eap Validation
                // ***
                if (txtEapName.Text.Trim() == string.Empty)
                {
                    txtEapName.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "EAP" }));
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", txtEapName.Text);
                // --
                using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceHistory", "HasEap", fSqlParams, false))
                {
                    if (dt.Rows.Count == 0)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Eap" }));
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuEalExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEalExport].SharedProps.Enabled = true;
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

        public void attach(
            string eapName
            )
        {
            try
            {
                txtEapName.Text = eapName;

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
                // Search User Events
                // ***
                foreach (string[] reqTimes in m_lstReqTimes)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    // --

                    procCount++;
                    nextRowNumber = 0;
                    // --
                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("eap", txtEapName.Text);
                    fSqlParams.add("tran_from_time", reqTimes[0]);
                    fSqlParams.add("tran_to_time", reqTimes[1]);
                    // --
                    do
                    {
                        using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceHistory", "SearchResourceHistory", fSqlParams, false, ref nextRowNumber))
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

        private void refreshChartOfHistory(
            )
        {
            List<DataPoint> emptyPoints = null;
            double tranTime = double.NaN;
            double cpuUsage = double.NaN;
            double memUsage = double.NaN;
            double dskUsage = double.NaN;

            try
            {
                m_dtFraseaprhi.DefaultView.Sort = "TRAN_TIME";
                foreach (DataRow r in m_dtFraseaprhi.DefaultView.ToTable().Rows)
                {
                    tranTime = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString())).ToOADate();
                    
                    // --
                    
                    // ***
                    // CPU USAGE
                    // ***
                    cpuUsage = double.TryParse(r["CPU_USAGE"].ToString(), out cpuUsage) ? cpuUsage : double.NaN;
                    chartCpu.Series["Value"].Points.AddXY(tranTime, cpuUsage);
                    // ***
                    // MEMORY USAGE
                    // ***
                    memUsage = double.TryParse(r["MEMORY_USAGE"].ToString(), out memUsage) ? memUsage : double.NaN;
                    chartMem.Series["Value"].Points.AddXY(tranTime, memUsage);
                    // ***
                    // DISK USAGE
                    // ***
                    dskUsage = double.TryParse(r["DISK_USAGE"].ToString(), out dskUsage) ? dskUsage : double.NaN;
                    chartDsk.Series["Value"].Points.AddXY(tranTime, dskUsage);
                }

                // --

                // ***
                // Filtering
                // ***
                chartCpu.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, "Value", "Cpu");
                chartMem.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, "Value", "Memory");
                chartDsk.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, "Value", "Disk");
                
                // --

                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in fChart.Series)
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

                    calculateAxisYMargin(fChart);
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

        private void refreshChartOfManagementRate(
            )
        {
            FSqlParams fSqlParams = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceHistory", "SearchManagementRate", fSqlParams, false))
                {
                    if (dt.Rows.Count > 0)
                    {
                        addManagementRate(chartCpu, "CPU Caution Rate", Convert.ToDouble(dt.Rows[0][0].ToString()), Color.DarkOrange, "%");
                        addManagementRate(chartCpu, "CPU Danger Rate", Convert.ToDouble(dt.Rows[0][1].ToString()), Color.Crimson, "%");
                        addManagementRate(chartMem, "Memory Caution Rate", Convert.ToDouble(dt.Rows[0][2].ToString()), Color.DarkOrange, "MB");
                        addManagementRate(chartMem, "Memory Danger Rate", Convert.ToDouble(dt.Rows[0][3].ToString()), Color.Crimson, "MB");
                        addManagementRate(chartDsk, "Disk Caution Rate", Convert.ToDouble(dt.Rows[0][4].ToString()), Color.DarkOrange, "MB");
                        addManagementRate(chartDsk, "Disk Danger Rate", Convert.ToDouble(dt.Rows[0][5].ToString()), Color.Crimson, "MB");
                        // --
                        foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                        {
                            calculateAxisYMargin(fChart);
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
                fSqlParams = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void calculateAxisYMargin(
            FChart fChart
            )
        {
            List<double> pointValues = null;

            try
            {
                pointValues = new List<double>();

                // --

                // ***
                // Data Point 수집
                // ***
                foreach (Series s in fChart.Series)
                {
                    if (s.Points.Where(p => p.IsEmpty == false).Count() == 0)
                    {
                        continue;
                    }

                    // --

                    if (s.Points.FindMaxByValue() != null)
                    {
                        pointValues.Add(s.Points.FindMaxByValue().YValues.Max());
                    }
                }

                // --

                // ***
                // Annotation Value 수집
                // ***
                foreach (Annotation ann in fChart.Annotations)
                {
                    pointValues.Add(ann.Y);
                }

                // --

                if (pointValues.Count == 0)
                {
                    fChart.ChartAreas[0].AxisY.Minimum = 0;
                    fChart.ChartAreas[0].AxisY.Maximum = 100;
                    return;
                }

                // --

                fChart.ChartAreas[0].AxisY.Minimum = 0;
                fChart.ChartAreas[0].AxisY.Maximum = pointValues.Max() + (pointValues.Max() * 0.1);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                pointValues = null;
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

                m_fInqProgress.ReqCount = m_lstReqTimes.Count;
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McResourceHistory_" + txtEapName.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export MC Resource History to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Eap Resource History");

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
                fExcelSht.writeCondition(lblToTime.Text, toDateTime.ToString("yyyy-MM-dd HH:mm:ss"), rowIndex, 2);
                fExcelSht.writeCondition(lblEap.Text, txtEapName.Text, rowIndex, 4);

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


        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FEapResourceHistory Form Event Handler

        private void FEapResourceHistory_Load(
            object sender,
            EventArgs e
            )
        {
            DateTime dateTime;

            try
            {
                FCursor.waitCursor();

                // --

                designChartOfEapCpuHistory();
                designChartOfEapMemoryHistory();
                designChartOfEapDiskHistory();

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

        private void FEapResourceHistory_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                udtFromTime.KeyDown += new KeyEventHandler(udtFromTime_KeyDown);
                udtFromTime.ValueChanged += new EventHandler(udtFromTime_ValueChanged);

                // --

                udtFromTime.Focus();
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

        private void FEapResourceHistory_FormClosing(
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

        private void FEapResourceHistory_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuErhRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuErhExport)
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

        #region txtEapName Control Event Handler

        private void txtEapName_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FEapSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEapSelector(m_fAdmCore, txtEapName.Text, "N");
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEapName.Text = fDialog.selectedEapName;
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

        private void txtEapName_ValueChanged(
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
                    m_fInqProgress.changedProgress(e.ProgressPercentage, m_dtFraseaprhi.Rows.Count);
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

    }   // Class end
}   // Namespace end
