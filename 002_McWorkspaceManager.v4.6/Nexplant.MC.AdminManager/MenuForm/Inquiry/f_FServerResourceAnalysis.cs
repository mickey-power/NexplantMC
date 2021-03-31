/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceAnalysis.cs
--  Creator         : tjkim
--  Create Date     : 2013.08.01
--  Description     : FAMate Admin Manager Server Resource Analysis Form Class 
--  History         : Created by tjkim at 2013.08.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerResourceAnalysis : Nexplant.MC.Core.FaUIs.FBaseTabChildForm, FIInquiry
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private FInquiryProgress m_fInqProgress = null;
        private DataTable m_dtFsyssvrdef = null;
        private DataTable m_dtFsyssvrrhi = null;
        private List<string[]> m_lstReqTimes = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceAnalysis(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceAnalysis(
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
                    m_dtFsyssvrdef = null;
                    m_dtFsyssvrrhi = null;
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

        private void designChartOfServerAnalysis(
            )
        {
            LegendItem legendItem = null;

            try
            {
                #region Design of Variable Resource

                chartVarRes.SuppressExceptions = true;

                // ***
                // Design CPU ChartArea 
                // ***
                chartVarRes.ChartAreas[0].AxisX.Interval = 1;
                chartVarRes.ChartAreas[0].AxisY.Interval = 20;
                chartVarRes.ChartAreas[0].AxisY.Maximum = 100;
                chartVarRes.ChartAreas[0].AxisY.Title = "CPU Analysis (%)";
                // --
                chartVarRes.ChartAreas[0].AxisX.IsStartedFromZero = false;
                chartVarRes.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartVarRes.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
                
                // -- 

                // ***
                // Design Memory ChartArea 
                // ***
                chartVarRes.ChartAreas[1].AxisX.Interval = 1;
                chartVarRes.ChartAreas[1].AxisY.Interval = 20;
                chartVarRes.ChartAreas[1].AxisY.Maximum = 100;
                chartVarRes.ChartAreas[1].AxisY.Title = "Memory Analysis (%)";
                // --
                chartVarRes.ChartAreas[1].AxisX.IsStartedFromZero = false;
                chartVarRes.ChartAreas[1].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartVarRes.ChartAreas[1].AxisX.ScrollBar.IsPositionedInside = true;
                                
                // --

                // ***
                // Clear Series 
                // ***
                chartVarRes.Series.Clear();
                
                // -- 

                // ***
                // Design CPU Series
                // ***
                chartVarRes.addSeries("Cpu", SeriesChartType.Candlestick);
                chartVarRes.Series["Cpu"].ChartArea = "ChartCpuArea";
                chartVarRes.Series["Cpu"].Label = "#VAL %";
                chartVarRes.Series["Cpu"].Color = Color.RoyalBlue;
                chartVarRes.Series["Cpu"]["PointWidth"] = "0.3";
                // chartVarRes.Series["Cpu"].YValuesPerPoint = 1;
                chartVarRes.Series["Cpu"].MarkerSize = 0;
                chartVarRes.Series["Cpu"].YValueType = ChartValueType.Double;
                chartVarRes.Series["Cpu"].XValueType = ChartValueType.String;
                
                // -- 

                // ***
                // Design Memory Series
                // ***
                chartVarRes.addSeries("Memory", SeriesChartType.Candlestick);
                chartVarRes.Series["Memory"].ChartArea = "ChartMemArea";
                chartVarRes.Series["Memory"].Label = "#VAL %";
                chartVarRes.Series["Memory"].Color = Color.Teal;
                chartVarRes.Series["Memory"]["PointWidth"] = "0.3";
                // chartVarRes.Series["Memory"].YValuesPerPoint = 1;
                chartVarRes.Series["Memory"].MarkerSize = 0;
                chartVarRes.Series["Memory"].YValueType = ChartValueType.Double;
                chartVarRes.Series["Memory"].XValueType = ChartValueType.String;

                // --

                legendItem = new LegendItem("Caution", Color.DarkOrange, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.DarkOrange;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartVarRes.Legends[0].CustomItems.Add(legendItem);
                // --
                legendItem = new LegendItem("Danger", Color.Crimson, string.Empty);
                legendItem.ImageStyle = LegendImageStyle.Line;
                legendItem.BorderColor = Color.Crimson;
                legendItem.BorderWidth = 2;
                legendItem.MarkerStyle = MarkerStyle.None;
                legendItem.BorderDashStyle = ChartDashStyle.Dot;
                chartVarRes.Legends[0].CustomItems.Add(legendItem);
                
                #endregion
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
                #region Init Data Table

                if (m_dtFsyssvrrhi == null)
                {
                    m_dtFsyssvrrhi = new DataTable();
                    foreach (string clmName in new string[] { "SERVER", "CPU_USAGE", "MEMORY_USAGE" })
                    {
                        m_dtFsyssvrrhi.Columns.Add(clmName, typeof(string));
                    }
                }
                m_dtFsyssvrrhi.Rows.Clear();

                #endregion

                // --

                #region Init Chart

                foreach (ChartArea chartArea in chartVarRes.ChartAreas)
                {
                    chartArea.AxisX.ScaleView.ZoomReset(0);
                    // --
                    chartArea.AxisY.Minimum = 0;
                    chartArea.AxisY.Maximum = 100;
                    chartArea.CursorX.Position = double.NaN;
                    chartArea.CursorY.Position = double.NaN;
                }

                // --

                foreach (Series s in chartVarRes.Series)
                {
                    s.Points.Clear();
                    // --
                    // --
                    pointIndex = s.Points.AddXY(" ", new object[] { double.NaN, double.NaN, double.NaN, double.NaN });
                    s.Points[pointIndex].AxisLabel = " ";
                    s.Points[pointIndex].IsEmpty = true;
                }

                // --

                chartVarRes.Annotations.Clear();

                #endregion

                // --

                refreshChartOfServerList();
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
            int procCount = 0;
            int nextRowNumber = 0;

            try
            {
                // ***
                // 시작 보고
                // ***
                worker.ReportProgress(0);

                // --

                foreach (string[] reqTimes in m_lstReqTimes)
                {
                    if (worker.CancellationPending)
                    {
                        break;
                    }

                    // --

                    foreach (DataRow r in m_dtFsyssvrdef.Rows)
                    {
                        procCount++;
                        nextRowNumber = 0;
                        // --
                        fSqlParams = new FSqlParams();
                        fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                        fSqlParams.add("server", r["SERVER"].ToString());
                        fSqlParams.add("tran_from_time", reqTimes[0]);
                        fSqlParams.add("tran_to_time", reqTimes[1]);
                        // --
                        do
                        {
                            using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceAnalysis", "SearchCpuMemoryAnalysis", fSqlParams, false, ref nextRowNumber))
                            {
                                dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrrhi, LoadOption.OverwriteChanges);
                            }
                            // --
                            worker.ReportProgress(procCount);
                        }
                        while (nextRowNumber >= 0);
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

        private void refreshChartOfServerList(
            )
        {
            FSqlParams fSqlParams = null;
            List<DataPoint> dataPoints = null;
            string serverName = string.Empty;
            int pointIndex = 0;
            int nextRowNumber = 0;

            try
            {
                // ***
                // Init Server Data Table
                // ***
                if (m_dtFsyssvrdef == null)
                {
                    m_dtFsyssvrdef = new DataTable();
                    foreach (string clmName in new string[] { "SERVER", "SVR_DESC", "MEMORY" })
                    {
                        m_dtFsyssvrdef.Columns.Add(clmName, typeof(string));
                    }
                }
                m_dtFsyssvrdef.Rows.Clear();

                // --

                // ***
                // Refresh Server List
                // ***
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceAnalysis", "ListServer", fSqlParams, false, ref nextRowNumber))
                    {
                        dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFsyssvrdef, LoadOption.OverwriteChanges);
                    }
                }
                while (nextRowNumber >= 0);

                // --

                // ***
                // Refresh Chart
                // ***
                foreach (DataRow r in m_dtFsyssvrdef.Rows)
                {
                    serverName = r["SERVER"].ToString();
                    foreach (Series s in chartVarRes.Series)
                    {
                        pointIndex = s.Points.AddXY(serverName, new object[] { double.NaN, double.NaN, double.NaN, double.NaN });
                        // --
                        s.Points[pointIndex].IsEmpty = true;
                        s.Points[pointIndex].ToolTip = serverName;
                        s.Points[pointIndex].LabelToolTip = serverName;
                    }
                }

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (Series s in chartVarRes.Series)
                {
                    if (s.Points.Where(p => string.IsNullOrWhiteSpace(p.AxisLabel) == false).Count() > 0)
                    {
                        dataPoints = s.Points.Where(p => string.IsNullOrWhiteSpace(p.AxisLabel)).ToList();
                        foreach (DataPoint p in dataPoints)
                        {
                            s.Points.Remove(p);
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
                dataPoints = null;
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
                chartVarRes.Annotations.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "ServerResourceAnalysis", "SearchManagementRate", fSqlParams, false);
                // --
                if (dt.Rows.Count > 0)
                {
                    addManagementRate(chartVarRes.ChartAreas[0], "CPU Caution Rate", Convert.ToDouble(dt.Rows[0][0].ToString()), Color.DarkOrange, "%");
                    addManagementRate(chartVarRes.ChartAreas[0], "CPU Danger Rate", Convert.ToDouble(dt.Rows[0][1].ToString()), Color.Crimson, "%");
                    addManagementRate(chartVarRes.ChartAreas[1], "Memory Caution Rate", Convert.ToDouble(dt.Rows[0][2].ToString()), Color.DarkOrange, "%");
                    addManagementRate(chartVarRes.ChartAreas[1], "Memory Danger Rate", Convert.ToDouble(dt.Rows[0][3].ToString()), Color.Crimson, "%");
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

        private void refreshChartOfServerAnalysis(
            )
        {
            List<DataPoint> dataPoints = null;
            // --
            List<double> cpuSampleValues = null;
            List<double> memSampleValues = null;
            double[] statisticsValues = null;
            // --
            double cpuLowValue = double.NaN;
            double cpuHigthValue = double.NaN;
            double cpuOpenValue = double.NaN;
            double cpuCloseValue = double.NaN;
            double cpuAvgValue = double.NaN;
            double cpuStdevValue = double.NaN;
            // --
            double memDefValue = double.NaN;
            double memLowValue = double.NaN;
            double memHigthValue = double.NaN;
            double memOpenValue = double.NaN;
            double memCloseValue = double.NaN;
            double memAvgValue = double.NaN;
            double memStdevValue = double.NaN;
            // --
            double tmp = double.NaN;
            // --
            string server = string.Empty;
            string svrDesc = string.Empty;
            int pointIndex = 0;
          
            try
            {
                foreach (DataRow svrRow in m_dtFsyssvrdef.Rows)
                {
                    cpuSampleValues = new List<double>();
                    memSampleValues = new List<double>();

                    // --

                    server = svrRow["SERVER"].ToString();
                    svrDesc = svrRow["SVR_DESC"].ToString();
                    m_dtFsyssvrrhi.DefaultView.RowFilter = string.Format("SERVER = '{0}'", server);
                    // --
                    foreach (DataRow r in m_dtFsyssvrrhi.DefaultView.ToTable().Rows)
                    {
                        if (double.TryParse(r["CPU_USAGE"].ToString(), out tmp))
                        {
                            cpuSampleValues.Add(tmp);
                        }

                        // --

                        if (double.TryParse(r["MEMORY_USAGE"].ToString(), out tmp))
                        {
                            memSampleValues.Add(tmp);
                        }
                    }

                    // --

                    // ***
                    // CPU
                    // ***
                    statisticsValues = extractStatisticsValues(cpuSampleValues);
                    // --
                    cpuLowValue = statisticsValues[0];
                    cpuAvgValue = statisticsValues[1];
                    cpuHigthValue = statisticsValues[2];
                    cpuStdevValue = statisticsValues[3];
                    cpuOpenValue = (cpuAvgValue + cpuStdevValue) > cpuHigthValue ? cpuHigthValue : (cpuAvgValue + cpuStdevValue);
                    cpuCloseValue = (cpuAvgValue - cpuStdevValue) < cpuLowValue ? cpuLowValue : (cpuAvgValue - cpuStdevValue);
                    
                    // --

                    pointIndex = chartVarRes.Series["Cpu"].Points.AddXY(server,  new object[] { cpuHigthValue, cpuLowValue, cpuCloseValue, cpuOpenValue });
                    // --
                    chartVarRes.Series["Cpu"].Points[pointIndex].Label = cpuAvgValue.ToString() + " %";
                    chartVarRes.Series["Cpu"].Points[pointIndex].ToolTip =
                        string.Format("{0} [{5}] : CPU Rate - Min:{1}%, Max:{2}%, Avg:{3}%, Stdev:{4}%", server, cpuLowValue, cpuHigthValue, cpuAvgValue, cpuStdevValue, svrDesc);
                    
                    // --

                    // ***
                    // MEMORY
                    // ***
                    if (double.TryParse(svrRow["MEMORY"].ToString(), out memDefValue) && memDefValue > 0)
                    {
                        statisticsValues = extractStatisticsValues(memSampleValues);
                        // --
                        memLowValue = Math.Round((statisticsValues[0] * 100 / memDefValue), 2);
                        memAvgValue = Math.Round((statisticsValues[1] * 100 / memDefValue), 2);
                        memHigthValue = Math.Round((statisticsValues[2] * 100 / memDefValue), 2);
                        memStdevValue = Math.Round((statisticsValues[3] * 100 / memDefValue), 2);
                        memOpenValue = (memAvgValue + memStdevValue) > memHigthValue ? memHigthValue : (memAvgValue + memStdevValue);
                        memCloseValue = (memAvgValue - memStdevValue) < memLowValue ? memLowValue : (memAvgValue - memStdevValue);
                    }
                    else
                    {
                        memLowValue = 0;
                        memHigthValue = 0;
                        memAvgValue = 0;
                        memStdevValue = 0;
                        memOpenValue = 0;
                        memCloseValue = 0;
                    }
                    
                    // --

                    pointIndex = chartVarRes.Series["Memory"].Points.AddXY(server, new object[] { memHigthValue, memLowValue, memCloseValue, memOpenValue });
                    // --
                    chartVarRes.Series["Memory"].Points[pointIndex].Label = memAvgValue.ToString() + " %";
                    chartVarRes.Series["Memory"].Points[pointIndex].ToolTip =
                        string.Format("{0} [{5}] : Memory Rate - Min:{1}%, Max:{2}%, Avg:{3}%, Stdev:{4}%", server, memLowValue, memHigthValue, memAvgValue, memStdevValue, svrDesc);
                }

                // --

                // ***
                // Empty Point 제거
                // ***
                foreach (Series s in chartVarRes.Series)
                {
                    if (s.Points.Where(p => p.IsEmpty == false).Count() > 0)
                    {
                        dataPoints = s.Points.Where(p => p.IsEmpty).ToList();
                        foreach (DataPoint p in dataPoints)
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
                dataPoints = null;
                cpuSampleValues = null;
                memSampleValues = null;
                statisticsValues = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------        

        private void addManagementRate(
            ChartArea chartArea,
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
                hLineAnn.AxisY = chartArea.AxisY;
                hLineAnn.Name = name;
                hLineAnn.ClipToChartArea = chartArea.Name;
                hLineAnn.IsInfinitive = true;
                hLineAnn.LineColor = color;
                hLineAnn.LineDashStyle = ChartDashStyle.Dot;
                hLineAnn.LineWidth = 2;
                hLineAnn.Y = value;
                hLineAnn.Visible = true;
                hLineAnn.ToolTip = string.Format("{0} : {1} {2}", name, value, unit);
                // --
                chartVarRes.Annotations.Add(hLineAnn);
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

        private double[] extractStatisticsValues(
            List<double> values
            )
        {
            double min = 0;
            double max = 0;
            double avg = 0;
            double std = 0;
            // --
            double sum = 0;
            double variance = 0;
            
            try
            {
                if (values.Count == 0)
                {
                    return new double[] { 0, 0, 0, 0 };
                }

                // --

                min = values.Min();
                max = values.Max();
                avg = Math.Round(values.Average(), 2);

                // --

                foreach (double value in values)
                {
                    sum += Math.Pow((avg - value), 2);
                }

                // --

                // ***
                // 분산
                // ***
                variance = (sum / (values.Count - 1));

                // --

                // ***
                // 표준 편차
                // ***
                std = Math.Round(Math.Sqrt(variance), 2);

                // --

                return new double[] { min, avg, max, std };
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
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

                m_fInqProgress.ReqCount = (m_lstReqTimes.Count * m_dtFsyssvrdef.Rows.Count);
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
            string createTime = string.Empty;
            FExcelExporter2 fExcelExp = null;
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_ServerResourceAnalysis.xlsx";

                // --

                sfd = new SaveFileDialog();
                // --
                sfd.Title = "Export Server Resource Analysis to Excel";
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
                createTime = FDataConvert.defaultNowDateTimeToString();

                // -- 

                #region CPU And Memory Sheet

                fExcelSht = fExcelExp.addExcelSheet("CPU And Memory Analysis");

                // --

                // ***
                // Title write
                // ***
                rowIndex = 0;
                fExcelSht.writeTitle("CPU/Memory Analysis", rowIndex, 0);

                // --

                // ***
                // Input Condition (입력 조건) Write
                // ***
                rowIndex = 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Input Condition") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblFromTime.Text, udtFromTime.Text, rowIndex, 0);
                fExcelSht.writeCondition(lblToTime.Text, udtToTime.Text, rowIndex, 2);

                // --

                // ***
                // CPU/Memory Analysis Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("CPU/Memory Analysis") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartVarRes, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Create Time Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Create Time") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // -- 
                rowIndex += 1;
                fExcelSht.writeText(createTime, rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, false);

                #endregion
                
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

        private void procServerResourceHistory(
            string server,
            FServerResourceType fSrvResType
            )
        {
            FServerResourceHistoryViewer dialog = null;
            string fromDateTime = string.Empty;
            string toDateTime = string.Empty;
            

            try
            {
                fromDateTime = this.udtFromTime.DateTime.ToString("yyyyMMddHHmmss000");
                toDateTime = this.udtToTime.DateTime.ToString("yyyyMMddHHmmss999");

                // --

                dialog = new FServerResourceHistoryViewer(this.m_fAdmCore, server, fromDateTime, toDateTime, fSrvResType);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }
       
        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FServerResourceComparison Form Event Handler

        private void FServerResourceAnalysis_Load(
            object sender,
            EventArgs e
            )
        {
            DateTime dateTime;

            try
            {
                FCursor.waitCursor();

                // --

                designChartOfServerAnalysis();

                // --

                dateTime = DateTime.Now;
                // --
                udtFromTime.DateTime = DateTime.Parse(dateTime.AddDays(-m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd") + " 00:00:00.000");
                udtToTime.DateTime = dateTime;             
                ((StateEditorButton)udtToTime.ButtonsLeft[0]).Checked = false;

                // --

                chartVarRes.AxisViewChanged += new EventHandler<ViewEventArgs>(chartVarRes_AxisViewChanged);
          
                // --

                m_fInqProgress = new FInquiryProgress(m_fAdmCore, this);
                m_fInqProgress.Canceled += new EventHandler<EventArgs>(fInqProgress_Canceled);

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

        private void FServerResourceAnalysis_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                         

                clear();

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

        private void FServerResourceAnalysis_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                chartVarRes.AxisViewChanged -= new EventHandler<ViewEventArgs>(chartVarRes_AxisViewChanged);

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

        private void FServerResourceAnalysis_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuSrmRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuSrmExport)
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

        #region chartVarRes Control Event Handler

        private void chartVarRes_AxisViewChanged(
            object sender,
            ViewEventArgs e
            )
        {
            double scaleViewPos = 0;
            double scaleViewSize = 0;

            try
            {
                chartVarRes.BeginInit();

                foreach (ChartArea chartArea in chartVarRes.ChartAreas)
                {
                    if (chartArea == e.ChartArea)
                    {
                        scaleViewPos = chartArea.AxisX.ScaleView.Position;
                        scaleViewSize = chartArea.AxisX.ScaleView.Size;
                    }
                }

                foreach (ChartArea chartArea in chartVarRes.ChartAreas)
                {
                    chartArea.AxisX.ScaleView.Position = scaleViewPos;
                    chartArea.AxisX.ScaleView.Size = scaleViewPos;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                chartVarRes.EndInit();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void chartVarRes_MouseDoubleClick(
             object sender,
             MouseEventArgs e
             )
        {
            HitTestResult htResult = null;
            string server = string.Empty;
            FServerResourceType fSrvResType = FServerResourceType.Cpu;

            try
            {
                htResult = chartVarRes.HitTest(e.X, e.Y);
                if (htResult.ChartElementType != ChartElementType.DataPoint)
                {
                    return;
                }

                // --

                if (chartVarRes.Series[htResult.Series.Name].ChartArea == "ChartCpuArea")
                {
                    fSrvResType = FServerResourceType.Cpu;
                }
                else if (chartVarRes.Series[htResult.Series.Name].ChartArea == "ChartMemArea")
                {
                    fSrvResType = FServerResourceType.Memory;
                }
                else
                {
                    fSrvResType = FServerResourceType.Disk;
                }
                // --
                server = chartVarRes.Series[htResult.Series.Name].Points[htResult.PointIndex].AxisLabel;

                // --

                procServerResourceHistory(server, fSrvResType);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                htResult = null;
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

                refreshChartOfServerAnalysis();
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