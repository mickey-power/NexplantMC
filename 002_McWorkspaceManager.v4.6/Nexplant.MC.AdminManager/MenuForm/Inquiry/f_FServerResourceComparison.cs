/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceComparison.cs
--  Creator         : mjkim
--  Create Date     : 2013.04.08
--  Description     : FAMate Admin Manager Server Resource Comparison Form Class 
--  History         : Created by mjkim at 2013.04.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerResourceComparison : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = true;      

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceComparison(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceComparison(
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

        private void designChartOfServerCpuComparison(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area
                // *** 
                chartCpu.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartCpu.ChartAreas[0].AxisX.IsStartedFromZero = false;
                chartCpu.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartCpu.ChartAreas[0].AxisY.Minimum = 0;
                chartCpu.ChartAreas[0].AxisY.Maximum = 100;
                chartCpu.ChartAreas[0].AxisY.Interval = 10;
                chartCpu.ChartAreas[0].AxisY.Title = "Usage (%)";
                
                // --

                // ***
                // Design Series
                // ***
                chartCpu.addSeries("CPU", SeriesChartType.Point);
                chartCpu.Series["CPU"].Label = "#VAL %";

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

        private void designChartOfServerMemoryComparison(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area
                // *** 
                chartMem.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartMem.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartMem.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartMem.ChartAreas[0].AxisY.Minimum = 0;
                chartMem.ChartAreas[0].AxisY.Maximum = 100;
                chartMem.ChartAreas[0].AxisY.Interval = 10;
                chartMem.ChartAreas[0].AxisY.Title = "Usage (%)";
                chartMem.ChartAreas[0].AxisY.IsMarginVisible = false;
                
                // --

                // ***
                // Design Series
                // ***
                chartMem.addSeries("Memory", SeriesChartType.Point);
                chartMem.Series["Memory"].Label = "#VAL %";
                
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

        private void designChartOfServerDiskComparison(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area
                // *** 
                chartDsk.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartDsk.ChartAreas[0].AxisX.IsStartedFromZero = false;
                chartDsk.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartDsk.ChartAreas[0].AxisY.Minimum = 0;
                chartDsk.ChartAreas[0].AxisY.Maximum = 100;
                chartDsk.ChartAreas[0].AxisY.Interval = 10;
                chartDsk.ChartAreas[0].AxisY.Title = "Usage (%)";
                
                // --

                // ***
                // Design Series
                // ***
                for (int i = 0; i < 10; i++)
                {
                    chartDsk.addSeries(string.Format("Disk {0}", i), SeriesChartType.Point);
                    chartDsk.Series[i].Label = "#VAL %";
                }
                // --
                chartDsk.Series[0].Color = Color.FromArgb(65, 140, 240);
                chartDsk.Series[1].Color = Color.FromArgb(5, 100, 146);
                chartDsk.Series[2].Color = Color.FromArgb(191, 191, 191);
                chartDsk.Series[3].Color = Color.FromArgb(26, 59, 105);
                chartDsk.Series[4].Color = Color.FromArgb(255, 227, 130); 
                chartDsk.Series[5].Color = Color.FromArgb(18, 156, 221); 
                chartDsk.Series[6].Color = Color.FromArgb(202, 107, 75);
                chartDsk.Series[7].Color = Color.FromArgb(0, 92, 219); 
                chartDsk.Series[8].Color = Color.FromArgb(243, 210, 136);
                chartDsk.Series[9].Color = Color.FromArgb(80, 99, 129);
                
                // --

                // ***
                // Design Legned Custom Item
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
                    mnuMenu.Tools[FMenuKey.MenuSrmExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuSrmExport].SharedProps.Enabled = true;
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
            int pointIndex = 0;
            
            try
            {
                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
                    fChart.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                    // --
                    fChart.ChartAreas[0].AxisY.Minimum = 0;
                    fChart.ChartAreas[0].AxisY.Maximum = 100;
                    fChart.ChartAreas[0].CursorX.Position = double.NaN;
                    fChart.ChartAreas[0].CursorY.Position = double.NaN;

                    // --

                    foreach (Series s in fChart.Series)
                    {
                        s.Points.Clear();
                        // --
                        pointIndex = s.Points.AddXY(0, double.NaN);
                        s.Points[pointIndex].AxisLabel = " ";
                        s.Points[pointIndex].IsEmpty = true;
                        // --
                        s.IsVisibleInLegend = false;
                    }

                    // --

                    fChart.Annotations.Clear();
                } 

                // --

                refreshChartOfServerList();
                refreshChartOfManagementRate();

                // --

                m_cleared = true;

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

        private void refreshChartOfServerList(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string serverName = string.Empty;
            int pointIndex = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceComparison", "ListServer", fSqlParams, false);
                // --
                foreach (DataRow r in dt.Rows)
                {
                    serverName = r[0].ToString();
                    // --
                    foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                    {
                        foreach (Series s in fChart.Series)
                        {
                            pointIndex = s.Points.AddXY(serverName, double.NaN);
                            s.Points[pointIndex].IsEmpty = true;
                            s.Points[pointIndex].ToolTip = serverName;
                            s.Points[pointIndex].LabelToolTip = serverName;
                        }
                    }
                }

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
                    foreach (Series s in fChart.Series)
                    {
                        if (s.Points.Where(p => string.IsNullOrWhiteSpace(p.AxisLabel) == false).Count() > 0)
                        {
                            emptyPoints = s.Points.Where(p => string.IsNullOrWhiteSpace(p.AxisLabel)).ToList();
                            foreach (DataPoint p in emptyPoints)
                            {
                                s.Points.Remove(p);
                            }
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
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceComparison", "SearchManagementRate", fSqlParams, false);
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

        private void refreshChartOfServerComparison(
            )
        {
            try
            {
                clear();

                // --

                refreshChartOfServerCpuComparison();
                refreshChartOfServerMemoryComparison();
                refreshChartOfServerDiskComparison();

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

        private void refreshChartOfServerCpuComparison(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string xValue = string.Empty;
            double yValue = double.NaN;
            int nextRowNumber = 0;
            int pointIndex = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);               
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceComparison", "SearchCpuSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = r[0].ToString();
                        yValue = double.TryParse(r[1].ToString(), out yValue) ? yValue : 0;
                        // --
                        pointIndex = chartCpu.Series[0].Points.AddXY(xValue, yValue);
                        chartCpu.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{2}] : {1} %", xValue, yValue, r[2].ToString());
                    }
                } while (nextRowNumber >= 0);

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
                        s.IsVisibleInLegend = true;
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

        private void refreshChartOfServerMemoryComparison(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string xValue = string.Empty;
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int nextRowNumber = 0;
            int pointIndex = 0;            

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);           
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceComparison", "SearchMemorySummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = r[0].ToString();
                        if (double.TryParse(r[1].ToString(), out size) && double.TryParse(r[2].ToString(), out usage))
                        {
                            yValue = size == 0 ? 0 : Math.Round((usage * 100 / size), 2);
                        }
                        else
                        {
                            yValue = 0;
                        }

                        // --

                        pointIndex = chartMem.Series[0].Points.AddXY(xValue, yValue);
                        chartMem.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{2}] : {1} %", xValue, yValue, r[3].ToString());
                    }
                } while (nextRowNumber >= 0);
             
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
                        s.IsVisibleInLegend = true;
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

        private void refreshChartOfServerDiskComparison(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string xValue = string.Empty;
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int diskIndex = 0;
                        
            string volume = string.Empty;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --               
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceComparison", "SearchDiskSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        diskIndex = 1;
                        // --
                        foreach (Series s in chartDsk.Series)
                        {
                            if (string.IsNullOrWhiteSpace(volume = r[diskIndex++].ToString()))
                            {
                                break;
                            }
                            // --
                            s.LegendText = volume;

                            // --

                            xValue = r[0].ToString();
                            if (double.TryParse(r[diskIndex++].ToString(), out size) && double.TryParse(r[diskIndex++].ToString(), out usage))
                            {
                                yValue = Math.Round((usage * 100 / size), 2);
                            }
                            else
                            {
                                yValue = double.NaN;
                            }
                            // --
                            pointIndex = s.Points.AddXY(xValue, yValue);
                            s.Points[pointIndex].ToolTip = string.Format("{0} [{3}] : [{1}] {2} %", xValue, volume, yValue, r[31].ToString());
                        }
                    }
                } while (nextRowNumber >= 0);
                    
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
                        s.IsVisibleInLegend = true;
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerResourceComparison.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server Resource Comparison to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Server Resource Comparison");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle(this.Text, rowIndex, 0);

                // --

                // ***
                // Cpu Comparison Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("CPU Comparison") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartCpu, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Memory Comparison Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Memory Comparison") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
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
                // Disk Comparison Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Disk Comparison)") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
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

        #region FServerResourceComparison Form Event Handler

        private void FServerResourceComparison_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                designChartOfServerCpuComparison();
                designChartOfServerMemoryComparison();
                designChartOfServerDiskComparison();

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

        private void FServerResourceComparison_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshChartOfServerComparison();

                // --

                tabMain.Focus();
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

        private void FServerResourceComparison_FormClosing(
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

        private void FServerResourceComparison_KeyDown(
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
                    refreshChartOfServerComparison();
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

                if (e.Tool.Key == FMenuKey.MenuSrmRefresh)
                {
                    refreshChartOfServerComparison();
                }
                else if (e.Tool.Key == FMenuKey.MenuSrmExport)
                {
                    export();
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
