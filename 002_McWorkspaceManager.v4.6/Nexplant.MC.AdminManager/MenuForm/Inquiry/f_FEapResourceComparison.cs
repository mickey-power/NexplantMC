/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapResourceComparison.cs
--  Creator         : jungyoul moon
--  Create Date     : 2013.02.18
--  Description     : FAMate Admin Manager Eap Resource Comparison Form Class 
--  History         : Created by jungyoul moon at 2013.02.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Windows.Forms.DataVisualization.Charting;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapResourceComparison : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = true;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapResourceComparison(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapResourceComparison(
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

        private void designChartOfEapCpuComparison(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area
                // *** 
                chartCpu.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartCpu.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartCpu.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartCpu.ChartAreas[0].AxisY.Minimum = 0;
                chartCpu.ChartAreas[0].AxisY.Maximum = 100;
                chartCpu.ChartAreas[0].AxisY.Title = "Usage (%)";
                chartCpu.ChartAreas[0].AxisY.IsMarginVisible = false;
                
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

        private void designChartOfEapMemoryComparison(
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
                chartMem.ChartAreas[0].AxisY.Title = "Usage (MB)";
                chartMem.ChartAreas[0].AxisY.IsMarginVisible = false;
                chartMem.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

                // --

                // ***
                // Design Series
                // ***
                chartMem.addSeries("Memory", SeriesChartType.Point);
                chartMem.Series["Memory"].Label = "#VAL MB";
                
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

        private void designChartOfEapDiskComparison(
            )
        {
            LegendItem legendItem = null;

            try
            {
                // ***
                // Design Chart Area
                // *** 
                chartDsk.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartDsk.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartDsk.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartDsk.ChartAreas[0].AxisY.Minimum = 0;
                chartDsk.ChartAreas[0].AxisY.Maximum = 100;
                chartDsk.ChartAreas[0].AxisY.Title = "Usage (MB)";
                chartDsk.ChartAreas[0].AxisY.IsMarginVisible = false;

                // --

                // ***
                // Design Series
                // ***
                chartDsk.addSeries("Disk", SeriesChartType.Point);
                chartDsk.Series["Disk"].Label = "#VAL MB";

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
            int pointIndex = 0;

            try
            {
                foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                {
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
                        pointIndex = s.Points.AddXY(0, double.NaN);
                        s.Points[pointIndex].AxisLabel = " ";
                        s.Points[pointIndex].IsEmpty = true;
                    }

                    // --

                    fChart.Annotations.Clear();
                }

                // --

                refreshChartOfEap();
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

        private void refreshChartOfEap(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            int nextRowNumber = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("server", txtSvrName.Text, txtSvrName.Text == string.Empty ? true : false);
                fSqlParams.add("package", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceComparison", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        foreach (FChart fChart in new FChart[] { chartCpu, chartMem, chartDsk })
                        {
                            fChart.Series[0].Points.AddXY(r[0].ToString(), double.NaN);
                        }
                    }
                } while (nextRowNumber >= 0);

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

        private void refreshChartOfEapComparison(
            )
        {            
            try
            {
                clear();
                                                                
                // --

                refreshChartOfEapCpuComparison();
                refreshChartOfEapMemoryComparison();
                refreshChartOfEapDiskComparison();
                
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

        private void refreshChartOfEapCpuComparison(
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
                fSqlParams.add("server", txtSvrName.Text, txtSvrName.Text == string.Empty ? true : false);
                fSqlParams.add("package", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceComparison", "SearchCpuSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = r[0].ToString();
                        yValue = double.TryParse(r[1].ToString(), out yValue) ? yValue : 0;
                        // --
                        pointIndex = chartCpu.Series[0].Points.AddXY(xValue, yValue);
                        chartCpu.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{2}] : {1} %", xValue, yValue, r[2].ToString());
                    }
                }
                while (nextRowNumber >= 0);

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
                    }
                }

                // --

                calculateAxisYMargin(chartCpu);
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

        private void refreshChartOfEapMemoryComparison(
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
                fSqlParams.add("server", txtSvrName.Text, txtSvrName.Text == string.Empty ? true : false);
                fSqlParams.add("package", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceComparison", "SearchMemorySummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = r[0].ToString();
                        if (double.TryParse(r[1].ToString(), out size) && double.TryParse(r[2].ToString(), out usage))
                        {
                            // ***
                            // 2015.08.27 by spike.lee
                            // Virtual Server에서 운영되는 EAP는 서버 메모리가 없으므로 4G를 기본으로 처리합니다.
                            // ***
                            //if (size == 0)
                            //{
                            //    size = 4 * 1024;
                            //}
                            //// --
                            //yValue = Math.Round((usage * 100 / size), 2);
                            yValue = usage;
                        }
                        else
                        {
                            yValue = 0;
                        }

                        // --

                        pointIndex = chartMem.Series[0].Points.AddXY(xValue, yValue);
                        chartMem.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{2}] : {1} MB", xValue, yValue, r[3].ToString());
                    }
                }
                while (nextRowNumber >= 0);

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
                    }
                }

                // --

                calculateAxisYMargin(chartMem);
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

        private void refreshChartOfEapDiskComparison(
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
                fSqlParams.add("server", txtSvrName.Text, txtSvrName.Text == string.Empty ? true : false);
                fSqlParams.add("package", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceComparison", "SearchDiskSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        xValue = r[0].ToString();
                        yValue = double.TryParse(r[1].ToString(), out yValue) ? yValue : 0;
                        // --
                        pointIndex = chartDsk.Series[0].Points.AddXY(r[0].ToString(), yValue);
                        chartDsk.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{2}] : {1} MB", xValue, yValue, r[2].ToString());
                    }
                }
                while (nextRowNumber >= 0);

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
                    }
                }

                // --

                calculateAxisYMargin(chartDsk);                
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
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapResourceComparison", "SearchManagementRate", fSqlParams, false);
                // --
                if (dt.Rows.Count > 0)
                {
                    addManagementRate(chartCpu, "CPU Caution Rate", Convert.ToDouble(dt.Rows[0][0].ToString()), Color.DarkOrange, "%");
                    addManagementRate(chartCpu, "CPU Danger Rate", Convert.ToDouble(dt.Rows[0][1].ToString()), Color.Crimson, "%");
                    addManagementRate(chartMem, "Memory Caution Rate", Convert.ToDouble(dt.Rows[0][2].ToString()), Color.DarkOrange, "%");
                    addManagementRate(chartMem, "Memory Danger Rate", Convert.ToDouble(dt.Rows[0][3].ToString()), Color.Crimson, "%");
                    addManagementRate(chartDsk, "Disk Caution Rate", Convert.ToDouble(dt.Rows[0][4].ToString()), Color.DarkOrange, "MB");
                    addManagementRate(chartDsk, "Disk Danger Rate", Convert.ToDouble(dt.Rows[0][5].ToString()), Color.Crimson, "MB");
                    // --
                    calculateAxisYMargin(chartCpu);
                    calculateAxisYMargin(chartMem);
                    calculateAxisYMargin(chartDsk);
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

        private void calculateAxisYMargin(
            Chart fChart
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McResourceComparison.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export MC Resource Comparison to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Eap Resource Comparison");

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
                fExcelSht.writeCondition(lblPackage.Text, txtPackage.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblModel.Text, txtModel.Text, rowIndex, 2);
                fExcelSht.writeCondition(lblComponent.Text, txtComponent.Text, rowIndex, 4);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 0);
                
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

        #region FEapResourceComparison Form Event Handler

        private void FEapResourceComparison_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --           
                
                designChartOfEapCpuComparison();
                designChartOfEapMemoryComparison();
                designChartOfEapDiskComparison();

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

        private void FEapResourceComparison_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshChartOfEapComparison();

                // -- 

                txtPackage.Focus();
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

        private void FEapResourceComparison_FormClosing(
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

        private void FEapResourceComparison_KeyDown(
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
                    refreshChartOfEapComparison();
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

                if (e.Tool.Key == FMenuKey.MenuErcRefresh)
                {
                    refreshChartOfEapComparison();
                }
                else if (e.Tool.Key == FMenuKey.MenuErcExport)
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

        #region txtPackage Control Event Handler

        private void txtPackage_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FPackageSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FPackageSelector(m_fAdmCore, txtPackage.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtPackage.Text = fDialog.selectedPackage;
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

        private void txtPackage_ValueChanged(
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

        #region txtModel Control Event Handler

        private void txtModel_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FModelSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FModelSelector(m_fAdmCore, txtModel.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtModel.Text = fDialog.selectedModel;
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

        private void txtModel_ValueChanged(
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

        #region txtComponent Control Event Handler

        private void txtComponent_EditorButtonClick(
            object sender,
            EditorButtonEventArgs e
            )
        {
            FComponentSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FComponentSelector(m_fAdmCore, txtComponent.Text);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtComponent.Text = fDialog.selectedComponent;
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

        private void txtComponent_ValueChanged(
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

        #region chartCpu Control Event Handler

        private void chartCpu_AxisViewChanged(
            object sender,
            ViewEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Axis.AxisName == AxisName.X)
                {
                    calculateAxisYMargin(chartCpu);
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

        #region chartMemory Control Event Handler

        private void chartMemory_AxisViewChanged(
            object sender, 
            ViewEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Axis.AxisName == AxisName.X)
                {
                    calculateAxisYMargin(chartMem);
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

        #region chartDiks Control Event Handler

        private void chartDisk_AxisViewChanged(
            object sender, 
            ViewEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Axis.AxisName == AxisName.X)
                {
                    calculateAxisYMargin(chartDsk);
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
