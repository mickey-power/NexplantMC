/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceStatus.cs
--  Creator         : jungyoul moon
--  Create Date     : 2013.02.18
--  Description     : FAMate Admin Manager Server Resource Status Form Class 
--  History         : Created by jungyoul moon at 2013.02.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerResourceStatus : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private DateTime m_fromDateTime = DateTime.MinValue;
        private DateTime m_toDateTime = DateTime.MinValue;
        private bool m_cleared = true;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceStatus(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceStatus(
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

        private void designGridOfServerResourceDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[] {
                    "Server",
                    "OS",
                    "CPU",
                    // --
                    "Computer Name",
                    "Work Group",
                    "User Name",
                    // --
                    "CPU Usage (%)",
                    "Memory Usage (MB)",
                    "Empty1",
                    // --
                    "Disk1 Usage (MB)",
                    "Disk2 Usage (MB)",
                    "Disk3 Usage (MB)",
                    // --
                    "Disk4 Usage (MB)",
                    "Disk5 Usage (MB)",
                    "Disk6 Usage (MB)",
                    // --
                    "Disk7 Usage (MB)",
                    "Disk8 Usage (MB)",
                    "Disk9 Usage (MB)",
                    // --
                    "Disk10 Usage (MB)",
                    "Creator",
                    "Updater"
                    };

                // --

                grdServerReourceDetail.addColumns(3, columns);
                grdServerReourceDetail.setColumnHeaderWidth(120);

                // --

                grdServerReourceDetail.Rows[2].Cells[1].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[2].Cells[3].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdServerReourceDetail.Rows[3].Cells[1].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[3].Cells[3].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[3].Cells[5].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdServerReourceDetail.Rows[4].Cells[1].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[4].Cells[3].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[4].Cells[5].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdServerReourceDetail.Rows[5].Cells[1].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[5].Cells[3].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdServerReourceDetail.Rows[5].Cells[5].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdServerReourceDetail.Rows[6].Cells[1].Appearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdServerReourceDetail.Rows[2].Cells[4].Value = string.Empty;
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

        private void designChartOfServerCpuStatus(
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
                chartCpu.addSeries("CPU", SeriesChartType.FastPoint);
                chartCpu.Series["CPU"].MarkerStyle = MarkerStyle.Circle;
                chartCpu.Series["CPU"].MarkerSize = 6;
                chartCpu.Series["CPU"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                chartCpu.Series["CPU"].XValueType = ChartValueType.DateTime;
                chartCpu.Series["CPU"].Legend = chartCpu.Legends[0].Name;

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

        private void designChartOfServerMemoryStatus(
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
                chartMem.Series["Memory"].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
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

        private void designChartOfServerDiskStatus(
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
                
                // --

                // ***
                // Design Series
                // ***
                for (int i = 0; i < 10; i++)
                {
                    seriesName = string.Format("Value {0}", i);
                    // --
                    chartDsk.addSeries(seriesName, SeriesChartType.FastLine);
                    chartDsk.Series[seriesName].Color = Color.DarkGray;
                    chartDsk.Series[seriesName].BorderWidth = 1;
                    chartDsk.Series[seriesName].XValueType = ChartValueType.DateTime;
                    chartDsk.Series[seriesName].IsVisibleInLegend = false;
                    chartDsk.Series[seriesName].Tag = i.ToString();

                    // --

                    seriesName = string.Format("Disk {0}", i);
                    // --
                    chartDsk.addSeries(seriesName, SeriesChartType.FastPoint);
                    chartDsk.Series[seriesName].MarkerStyle = MarkerStyle.Circle;
                    chartDsk.Series[seriesName].MarkerSize = 6;
                    chartDsk.Series[seriesName].ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY(%)";
                    chartDsk.Series[seriesName].XValueType = ChartValueType.DateTime;
                    chartDsk.Series[seriesName].Legend = chartDsk.Legends[0].Name;
                }
                // --
                chartDsk.Series["Disk 0"].Color = Color.FromArgb(65, 140, 240);
                chartDsk.Series["Disk 1"].Color = Color.FromArgb(5, 100, 146);
                chartDsk.Series["Disk 2"].Color = Color.FromArgb(191, 191, 191);
                chartDsk.Series["Disk 3"].Color = Color.FromArgb(26, 59, 105);
                chartDsk.Series["Disk 4"].Color = Color.FromArgb(255, 227, 130);
                chartDsk.Series["Disk 5"].Color = Color.FromArgb(18, 156, 221);
                chartDsk.Series["Disk 6"].Color = Color.FromArgb(202, 107, 75);
                chartDsk.Series["Disk 7"].Color = Color.FromArgb(0, 92, 219);
                chartDsk.Series["Disk 8"].Color = Color.FromArgb(243, 210, 136);
                chartDsk.Series["Disk 9"].Color = Color.FromArgb(80, 99, 129);
                
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuSvlExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSvlExport].SharedProps.Enabled = true;    
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
            DateTime dtNow = new DateTime();

            try
            {
                if (m_cleared)
                {
                    grdServerReourceDetail.beginUpdate();
                    // --
                    grdServerReourceDetail.clearColumnValue();
                    // --
                    grdServerReourceDetail.endUpdate();

                    // --

                    dtNow = DateTime.Now;

                    // --

                    foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                    {
                        fChart.ChartAreas[0].AxisX.Minimum = DateTime.Now.AddHours(-24).ToOADate();
                        fChart.ChartAreas[0].AxisX.Maximum = DateTime.Now.ToOADate();
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
                    
                    // --

                    refreshChartOfManagementRate();
                }

                // --

                m_cleared = true;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdServerReourceDetail.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clearChartPoint(
            FChart fChart
            )
        {
            try
            {
                foreach (Series s in fChart.Series)
                {
                    while (s.Points.Count > 0)
                    {
                        s.Points.RemoveAt(s.Points.Count - 1);
                    }
                    // --
                    s.Points.Clear();
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

        public void attach(
            string serverName
            )
        {
            try
            {
                txtSvrName.Text = serverName;

                // --

                refershGridOfServerResourceDetail();

                // --

                txtSvrName.Focus();
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

        private void refershGridOfServerResourceDetail(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow r = null;
            object[] cellValues = null;
            int diskIndex = 0;
            List<string> diskList = null;
            string cpu = string.Empty;
            string cpuUsage = string.Empty;
            string memory = string.Empty;
            string createTime = string.Empty;
            string updateTime = string.Empty;
            string creator = string.Empty;
            string updater = string.Empty;

            try
            {
                clear();

                // --

                grdServerReourceDetail.beginUpdate();
                
                // --

                #region Validation

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

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "HasServer", fSqlParams, false);
                // --
                if (dt.Rows.Count == 0)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0010", new object[] { "Server" }));
                }
                
                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "SearchServerResource", fSqlParams, true);
                r = dt.Rows[0];

                // --

                // Cpu
                if (r[5].ToString() == string.Empty)
                {
                    cpu = "N/A";
                    cpuUsage = "N/A";
                }
                else
                {
                    cpu = r[5].ToString();
                    cpuUsage = r[6].ToString();
                }
                // Memory
                if (double.Parse(r[7].ToString()) == 0)
                {
                    memory = "N/A";
                }
                else
                {
                    // Memory / Usage
                    memory = string.Format("{0} / {1}", r[8].ToString(), r[7].ToString());
                }
                // Disk
                diskList = new List<string>();
                diskIndex = 9;
                for (int i = 0; i < 10; i++)
                {
                    if (r[diskIndex].ToString() == string.Empty)
                    {
                        diskList.Add("N/A");
                    }
                    else
                    {
                        diskList.Add(string.Format("({0}) : {1} / {2}", r[diskIndex], r[diskIndex + 2], r[diskIndex + 1]));
                    }
                    diskIndex += 3;
                }
                // --
                
                creator = r[40] + " [" + FDataConvert.defaultDataTimeFormating(r[39].ToString()) + "]";
                updater = r[42] + " [" + FDataConvert.defaultDataTimeFormating(r[41].ToString()) + "]";

                // --

                cellValues = new object[] {
                    r[0].ToString() == string.Empty ? "N/A" : r[0].ToString(),    // Server
                    r[4].ToString() == string.Empty ? "N/A" : r[4].ToString(),    // OS
                    cpu,                                                          // Cpu
                    // --
                    r[1].ToString() == string.Empty ? "N/A" : r[1].ToString(),    // Computer Name
                    r[2].ToString() == string.Empty ? "N/A" : r[2].ToString(),    // Work Group
                    r[3].ToString() == string.Empty ? "N/A" : r[3].ToString(),    // User Name
                    // --                   
                    cpuUsage,                                                     // Cpu Usage
                    memory,                                                       // Memory
                    string.Empty,                                                 // Empty1
                    // --
                    diskList[0],                                                  // Disk1
                    diskList[1],                                                  // Disk2
                    diskList[2],                                                  // Disk3
                    // --
                    diskList[3],                                                  // Disk4
                    diskList[4],                                                  // Disk5
                    diskList[5],                                                  // Disk6
                    // --
                    diskList[6],                                                  // Disk7
                    diskList[7],                                                  // Disk8
                    diskList[8],                                                  // Disk9
                    // --
                    diskList[9],                                                  // Disk10
                    creator,                                                     // Creator 
                    updater                                                    // Updater
                    };
                grdServerReourceDetail.setColumnValues(cellValues);

                // --

                grdServerReourceDetail.endUpdate();

                // --

                refreshChartOfServerCpuHistory();
                refreshChartOfServerMemoryHistory();             
                refreshChartOfServerDiskHistory();                    

                // --

                m_cleared = false;

                // --

                controlMenu();

                // --

                grdServerReourceDetail.Focus();
            }
            catch (Exception ex)
            {
                grdServerReourceDetail.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                r = null;
                cellValues = null;
                diskList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshChartOfServerCpuHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            double xValue = double.NaN;
            double yValue = double.NaN;
            int nextRowNumber = 0;
            
            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", DateTime.Now.AddHours(-24).ToString("yyyyMMddHHmmss000"));
                fSqlParams.add("tran_to_time", DateTime.Now.ToString("yyyyMMddHHmmss999"));
                fSqlParams.add("server", txtSvrName.Text);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "SearchCpuHistory", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r[0].ToString())).ToOADate();
                        yValue = double.TryParse(r[1].ToString(), out yValue) ? yValue : double.NaN;
                        // --
                        chartCpu.Series["Value"].Points.AddXY(xValue, yValue);
                    }

                } while (nextRowNumber >= 0);
                
                // --

                // ***
                // Filtering
                // ***
                chartCpu.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, "Value", "CPU");

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (Series s in chartCpu.Series)
                {
                    if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                    {
                        emptyPoints = s.Points.Where(p => p.IsEmpty).ToList();
                        foreach (DataPoint p in emptyPoints)
                        {
                            s.Points.Remove(p);
                        }
                        // --
                        s.IsVisibleInLegend = s.ChartType == SeriesChartType.FastPoint;
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
                emptyPoints = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshChartOfServerMemoryHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            double xValue = double.NaN;
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int nextRowNumber = 0;
            
            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", DateTime.Now.AddHours(-24).ToString("yyyyMMddHHmmss000"));
                fSqlParams.add("tran_to_time", DateTime.Now.ToString("yyyyMMddHHmmss999"));
                fSqlParams.add("server", txtSvrName.Text);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "SearchMemoryHistory", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r[0].ToString())).ToOADate();
                        if (double.TryParse(r[1].ToString(), out size) && double.TryParse(r[2].ToString(), out usage))
                        {
                            yValue = Math.Round((usage * 100 / size), 2);
                        }
                        else
                        {
                            yValue = double.NaN;
                        }
                        // --
                        chartMem.Series["Value"].Points.AddXY(xValue, yValue);
                    }
                }
                while (nextRowNumber >= 0);

                // --

                // ***
                // Filtering
                // ***
                chartMem.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, "Value", "Memory");

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (Series s in chartMem.Series)
                {
                    if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                    {
                        emptyPoints = s.Points.Where(p => p.IsEmpty).ToList();
                        foreach (DataPoint p in emptyPoints)
                        {
                            s.Points.Remove(p);
                        }
                        // --
                        s.IsVisibleInLegend = s.ChartType == SeriesChartType.FastPoint;
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
                emptyPoints = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshChartOfServerDiskHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string volume = string.Empty;           
            double xValue = double.NaN;
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int nextRowNumber = 0;
            int diskIndex = 0;
            
            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", DateTime.Now.AddHours(-24).ToString("yyyyMMddHHmmss000"));
                fSqlParams.add("tran_to_time", DateTime.Now.ToString("yyyyMMddHHmmss999"));
                fSqlParams.add("server", txtSvrName.Text);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "SearchDiskHistory", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        diskIndex = 1;
                        // --
                        foreach (Series s in chartDsk.Series.Where(s => s.ChartType == SeriesChartType.FastLine))
                        {
                            if (string.IsNullOrWhiteSpace(volume = r[diskIndex++].ToString()))
                            {
                                break;
                            }
                            // --
                            chartDsk.Series[string.Format("Disk {0}", s.Tag.ToString())].LegendText = volume;

                            // --

                            xValue = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r[0].ToString())).ToOADate();
                            if (double.TryParse(r[diskIndex++].ToString(), out size) && double.TryParse(r[diskIndex++].ToString(), out usage))
                            {
                                yValue = Math.Round((usage * 100 / size), 2);
                            }
                            else
                            {
                                yValue = double.NaN;
                            }
                            // --
                            s.Points.AddXY(xValue, yValue);
                        }
                    }
                } while (nextRowNumber >= 0);
                
                // --

                // ***
                // Filtering
                // ***
                for (int i = 0; i < 10; i++)
                {
                    chartDsk.DataManipulator.Filter(CompareMethod.EqualTo, double.NaN, string.Format("Value {0}", i.ToString()), string.Format("Disk {0}", i.ToString()));
                }

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (Series s in chartDsk.Series)
                {
                    if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                    {
                        emptyPoints = s.Points.Where(p => p.IsEmpty).ToList();
                        foreach (DataPoint p in emptyPoints)
                        {
                            s.Points.Remove(p);
                        }
                        // --
                        s.IsVisibleInLegend = s.ChartType == SeriesChartType.FastPoint;
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
                emptyPoints = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshChartOfManagementRate(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceStatus", "SearchManagementRate", fSqlParams, false);

                // --

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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerResourceStatus_" + txtSvrName.Text + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server Resource Status to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Resource Status");

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
                rowIndex = 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 0);

                // --

                // ***
                // Server Resource Detail Grid Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Resource Detail") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeDetailViewGrid(grdServerReourceDetail, rowIndex, 0);

                // --

                // ***
                // Cpu History Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("CPU History (24Hours)") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartCpu, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Memory History Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Memory History  (24Hours)") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                // --
                if (chartMem.Size.Width != chartCpu.Size.Width || chartMem.Size.Height != chartCpu.Size.Height)
                {
                    chartMem.Size = new System.Drawing.Size(chartCpu.Size.Width, chartCpu.Size.Height);
                }
                // --
                fExcelSht.writeChart(chartMem, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Disk History Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Disk History  (24Hours)") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                // --
                if (chartDsk.Size.Width != chartCpu.Size.Width || chartDsk.Size.Height != chartCpu.Size.Height)
                {
                    chartDsk.Size = new System.Drawing.Size(chartCpu.Size.Width, chartCpu.Size.Height);
                }
                // --
                fExcelSht.writeChart(chartDsk, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 22;
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

        #region FServerResourceStatus Form Event Handler

        private void FServerResourceStatus_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfServerResourceDetail();
                // -- 
                designChartOfServerCpuStatus();
                designChartOfServerMemoryStatus();
                designChartOfServerDiskStatus();

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

        private void FServerResourceStatus_Shown(
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

        private void FServerResourceStatus_FormClosing(
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

        private void FServerResourceStatus_KeyDown(
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
                    refershGridOfServerResourceDetail();
                    m_cleared = true;
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

                if (e.Tool.Key == FMenuKey.MenuSrsRefresh)
                {
                    refershGridOfServerResourceDetail();
                    m_cleared = true;
                }
                else if (e.Tool.Key == FMenuKey.MenuSrsExport)
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

    }   // Class end
}   // Namespace end
