/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerResourceHistoryViewer.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.11.27
--  Description     : FAMate Admin Manager Server Resource History Viewer Form Class 
--  History         : Created by jungyoul.moon at 2013.11.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerResourceHistoryViewer : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_server = string.Empty;
        private string m_fromDateTime = string.Empty;
        private string m_toDateTime = string.Empty;
        private FServerResourceType m_fSvrResType = FServerResourceType.Cpu;
       
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerResourceHistoryViewer()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerResourceHistoryViewer(
            FAdmCore fAdmCore,
            string server,
            string fromDateTime,
            string toDateTime,
            FServerResourceType fSvrResType
            )
            :this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            // --
            m_fAdmCore = fAdmCore;
            m_server = server;
            m_fromDateTime = fromDateTime;
            m_toDateTime = toDateTime;
            m_fSvrResType = fSvrResType;
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

        private void designChartOfServerResourceHistory(
            )
        {
            string seriesName = string.Empty;

            try
            {
                if (m_fSvrResType != FServerResourceType.Disk)
                {
                    chartResource.ChartAreas[0].AxisY.Minimum = 0;
                    chartResource.ChartAreas[0].AxisY.Maximum = 100;
                    chartResource.ChartAreas[0].AxisY.Interval = 10;
                    chartResource.ChartAreas[0].AxisY.Title = string.Format("{0} Usage(%)", m_fSvrResType.ToString());

                    // --

                    chartResource.Series.Clear();
                    // --
                    chartResource.addSeries(m_fSvrResType.ToString());
                    chartResource.Series[m_fSvrResType.ToString()].EmptyPointStyle.Color = Color.DodgerBlue;
                }
                else
                {
                    chartResource.ChartAreas[0].AxisY.Maximum = 100;
                    chartResource.ChartAreas[0].AxisY.Interval = 10;
                    chartResource.ChartAreas[0].AxisY.Title = "Disk Usage (%)";

                    // --

                    chartResource.Series.Clear();

                    // --

                    for (int i = 0; i < 10; i++)
                    {
                        seriesName = string.Format("Disk {0}", i + 1);
                        // --
                        chartResource.addSeries(seriesName);
                        chartResource.Series[seriesName].IsVisibleInLegend = false;
                    }
                    // --
                    chartResource.Series[0].Color = Color.FromArgb(65, 140, 240); chartResource.Series[0].EmptyPointStyle.Color = chartResource.Series[0].Color;
                    chartResource.Series[1].Color = Color.FromArgb(5, 100, 146); chartResource.Series[1].EmptyPointStyle.Color = chartResource.Series[1].Color;
                    chartResource.Series[2].Color = Color.FromArgb(191, 191, 191); chartResource.Series[2].EmptyPointStyle.Color = chartResource.Series[2].Color;
                    chartResource.Series[3].Color = Color.FromArgb(26, 59, 105); chartResource.Series[3].EmptyPointStyle.Color = chartResource.Series[3].Color;
                    chartResource.Series[4].Color = Color.FromArgb(255, 227, 130); chartResource.Series[4].EmptyPointStyle.Color = chartResource.Series[4].Color;
                    chartResource.Series[5].Color = Color.FromArgb(18, 156, 221); chartResource.Series[5].EmptyPointStyle.Color = chartResource.Series[5].Color;
                    chartResource.Series[6].Color = Color.FromArgb(202, 107, 75); chartResource.Series[6].EmptyPointStyle.Color = chartResource.Series[6].Color;
                    chartResource.Series[7].Color = Color.FromArgb(0, 92, 219); chartResource.Series[7].EmptyPointStyle.Color = chartResource.Series[7].Color;
                    chartResource.Series[8].Color = Color.FromArgb(243, 210, 136); chartResource.Series[8].EmptyPointStyle.Color = chartResource.Series[8].Color;
                    chartResource.Series[9].Color = Color.FromArgb(80, 99, 129); chartResource.Series[9].EmptyPointStyle.Color = chartResource.Series[9].Color;
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

        private void clear(
            )
        {
            try
            {
                chartResource.Annotations.Clear();
                // --
                chartResource.ChartAreas[0].AxisX.Minimum = FDataConvert.stringToDateTime(m_fromDateTime).ToOADate();
                chartResource.ChartAreas[0].AxisX.Maximum = FDataConvert.stringToDateTime(m_toDateTime).ToOADate();
                chartResource.ChartAreas[0].AxisX.ScaleView.ZoomReset(0);
                chartResource.ChartAreas[0].CursorX.Position = double.NaN;
                chartResource.ChartAreas[0].CursorY.Position = double.NaN;
                
                // --

                clearChartPoint(new Chart[] { chartResource});

                // --

                chartResource.Series[0].Points.AddXY(FDataConvert.stringToDateTime(m_toDateTime).ToOADate(), -1);
                
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

        private void clearChartPoint(
            Chart[] charts
            )
        {
            try
            {
                foreach (Chart chart in charts)
                {
                    foreach (Series s in chart.Series)
                    {
                        s.Points.SuspendUpdates();
                        // --
                        while (s.Points.Count > 0)
                        {
                            s.Points.RemoveAt(s.Points.Count - 1);
                        }
                        // --
                        s.Points.ResumeUpdates();
                        s.Points.Clear();
                    }
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

        private void refreshChartOfServerResourceHistory(
            )
        {
            try
            {
                clear();

                // --

                if (m_fSvrResType == FServerResourceType.Cpu)
                {
                    refreshChartOfServerCpuHistory();
                }
                else if (m_fSvrResType == FServerResourceType.Memory)
                {
                    refreshChartOfServerMemoryHistory();
                }
                else if (m_fSvrResType == FServerResourceType.Disk)
                {
                    refreshChartOfServerDiskHistory();
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

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ServerResourceHistoryViewer", "SearchManagementRate", fSqlParams, false);
                // --
                if (dt.Rows.Count > 0)
                {
                    if (m_fSvrResType == FServerResourceType.Cpu)
                    {
                        FChartCommon.addLine(chartResource, Color.DarkOrange, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][0].ToString()), "Caution");
                        FChartCommon.addLine(chartResource, Color.Crimson, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][1].ToString()), "Danger");
                    }
                    else if (m_fSvrResType == FServerResourceType.Memory)
                    {
                        FChartCommon.addLine(chartResource, Color.DarkOrange, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][2].ToString()), "Caution");
                        FChartCommon.addLine(chartResource, Color.Crimson, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][3].ToString()), "Danger");
                    }
                    else
                    {
                        FChartCommon.addLine(chartResource, Color.DarkOrange, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][4].ToString()), "Caution");
                        FChartCommon.addLine(chartResource, Color.Crimson, ChartDashStyle.Dot, 2, double.Parse(dt.Rows[0][5].ToString()), "Danger");
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

        private void refreshChartOfServerCpuHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DateTime emptyX = new DateTime();
            DateTime dateTimeX = new DateTime();
            double yValue = double.NaN;
            int dataIndex = 0;
            int nextRowNumber = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", m_fromDateTime);
                fSqlParams.add("tran_to_time", m_toDateTime, false);
                fSqlParams.add("server", m_server);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ServerResourceHistoryViewer", "SearchCpuHistory", fSqlParams, false, ref nextRowNumber);

                    // --

                    if (dataIndex == 0 && dt.Rows.Count > 0)
                    {
                        clearChartPoint(new Chart[] { chartResource });
                    }

                    // --

                    foreach (Series s in chartResource.Series)
                    {
                        s.Points.SuspendUpdates();

                        // --

                        foreach (DataRow r in dt.Rows)
                        {
                            dateTimeX = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r[0].ToString()));
                            if (s.Points.Count > 0 && dateTimeX.AddHours(-1) > emptyX)
                            {
                                s.Points.AddXY(dateTimeX.AddHours(-1).ToOADate(), double.NaN);
                            }
                            // --
                            if (double.TryParse(r[1].ToString(), out yValue) == false)
                            {
                                yValue = double.NaN;
                            }
                            // --
                            s.Points.Add(new DataPoint
                            {
                                XValue = dateTimeX.ToOADate(),
                                YValues = new double[] { yValue }
                            });
                            // --
                            emptyX = dateTimeX;
                        }

                        // --

                        s.Points.ResumeUpdates();
                    }
                    dataIndex++;
                }
                while (nextRowNumber >= 0);
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

        private void refreshChartOfServerMemoryHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DateTime emptyX = new DateTime();
            DateTime dateTimeX = new DateTime();
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int dataIndex = 0;
            int nextRowNumber = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", m_fromDateTime);
                fSqlParams.add("tran_to_time", m_toDateTime, false);
                fSqlParams.add("server", m_server);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ServerResourceHistoryViewer", "SearchMemoryHistory", fSqlParams, false, ref nextRowNumber);

                    // --

                    if (dataIndex == 0 && dt.Rows.Count > 0)
                    {
                        clearChartPoint(new Chart[] { chartResource });
                    }

                    // --

                    foreach (Series s in chartResource.Series)
                    {
                        s.Points.SuspendUpdates();

                        // --

                        foreach (DataRow r in dt.Rows)
                        {
                            dateTimeX = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(r[0].ToString()));
                            if (s.Points.Count > 0 && dateTimeX.AddHours(-1) > emptyX)
                            {
                                s.Points.AddXY(dateTimeX.AddHours(-1).ToOADate(), double.NaN);
                            }
                            // --
                            if (double.TryParse(r[1].ToString(), out size) && double.TryParse(r[2].ToString(), out usage))
                            {
                                yValue = Math.Round((usage * 100 / size), 2);
                            }
                            else
                            {
                                yValue = double.NaN;
                            }
                            // --
                            s.Points.Add(new DataPoint
                            {
                                XValue = dateTimeX.ToOADate(),
                                YValues = new double[] { yValue }
                            });
                            // --
                            emptyX = dateTimeX;
                        }

                        // --

                        s.Points.ResumeUpdates();
                    }
                    dataIndex++;
                }
                while (nextRowNumber >= 0);
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

        private void refreshChartOfServerDiskHistory(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DateTime emptyX = new DateTime();
            DateTime dateTimeX = new DateTime();
            double yValue = double.NaN;
            double size = double.NaN;
            double usage = double.NaN;
            int dataIndex = 0;
            int nextRowNumber = 0;
            // --
            string volume = string.Empty;
            int diskIndex = 0;
            Dictionary<string, int> diskDict = new Dictionary<string, int>();            

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_from_time", m_fromDateTime);
                fSqlParams.add("tran_to_time", m_toDateTime, false);
                fSqlParams.add("server", m_server);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ServerResourceHistoryViewer", "SearchDiskHistory", fSqlParams, false, ref nextRowNumber);

                    // --

                    if (dataIndex == 0 && dt.Rows.Count > 0)
                    {
                        clearChartPoint(new Chart[] { chartResource });
                    }

                    // --

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        diskIndex = 2;
                        dateTimeX = Convert.ToDateTime(FDataConvert.defaultDataTimeFormating(dt.Rows[i][0].ToString()));
                        foreach (Series s in chartResource.Series)
                        {
                            volume = dt.Rows[i][diskIndex].ToString();
                            if (volume != string.Empty)
                            {
                                if (s.Points.Count > 0 && dateTimeX.AddHours(-1) > emptyX)
                                {
                                    s.Points.AddXY(dateTimeX.AddHours(-1).ToOADate(), double.NaN);
                                }
                                // --
                                if (double.TryParse(dt.Rows[i][diskIndex + 1].ToString(), out size) && double.TryParse(dt.Rows[i][diskIndex + 2].ToString(), out usage))
                                {
                                    yValue = Math.Round((usage * 100 / size), 2);
                                }
                                else
                                {
                                    yValue = double.NaN;
                                }
                                // --
                                s.Points.Add(new DataPoint
                                {
                                    XValue = dateTimeX.ToOADate(),
                                    YValues = new double[] { yValue }
                                });
                                // --
                                s.LegendText = volume;
                                s.IsVisibleInLegend = true;
                            }
                            diskIndex += 3;
                        }
                        emptyX = dateTimeX;
                    }
                    dataIndex++;
                }
                while (nextRowNumber >= 0);                
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FServerResourceHistoryViewer Form Event Handler

        private void FServerResourceHistoryViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designChartOfServerResourceHistory();
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

        private void FServerResourceHistoryViewer_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshChartOfServerResourceHistory();
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

        private void FServerResourceHistoryViewer_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end

}   // Namespcae end
