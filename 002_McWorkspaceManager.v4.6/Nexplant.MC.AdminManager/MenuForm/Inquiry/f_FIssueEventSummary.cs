/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FIssueEventSummary.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.18
--  Description     : FAmate Admin Manager Issue Event Summary Form Class 
--  History         : Created by spike.lee at 2017.07.18
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
    public partial class FIssueEventSummary : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private Dictionary<string, UInt32> m_serverList = null;
        private Dictionary<string, string> m_serverDescList = null;
        private Dictionary<string, UInt32> m_eapList = null;
        private Dictionary<string, string> m_eapDescList = null;
        private Dictionary<string, UInt32> m_equipmentList = null;
        private Dictionary<string, string> m_equipmentDescList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FIssueEventSummary(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIssueEventSummary(
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

        private void designChartOfEap(
            )
        {
            try
            {
                // ***
                // Design Chart EAP
                // *** 
                chartEap.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEap.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEap.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEap.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEap.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEap.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEap.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEap.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEap.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEap.addSeries("EAP", SeriesChartType.Column);
                chartEap.Series["EAP"].Color = Color.IndianRed;
                chartEap.Series["EAP"].Label = "#VAL";
                chartEap.Series["EAP"].XValueType = ChartValueType.String;
                chartEap.Series["EAP"].YValueType = ChartValueType.UInt32;
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

        private void designChartOfEquipment(
            )
        {
            try
            {
                // ***
                // Design Chart Equipment
                // *** 
                chartEqp.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEqp.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEqp.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEqp.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEqp.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEqp.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEqp.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEqp.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEqp.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEqp.addSeries("Equipment", SeriesChartType.Column);
                chartEqp.Series["Equipment"].Color = Color.IndianRed;
                chartEqp.Series["Equipment"].Label = "#VAL";
                chartEqp.Series["Equipment"].XValueType = ChartValueType.String;
                chartEqp.Series["Equipment"].YValueType = ChartValueType.UInt32;
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuIesExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuIesExport].SharedProps.Enabled = true;
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

                foreach (FChart fChart in new FChart[] { chartServer, chartEap, chartEqp })
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

                refreshChartOfServer();
                refreshChartOfEap();
                refreshChartOfEquipment();

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
                m_serverList = new Dictionary<string, UInt32>();
                m_serverDescList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "ListServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        server = r[0].ToString();
                        desc = r[1].ToString();
                        m_serverList.Add(server, 0);
                        m_serverDescList.Add(server, desc);
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

        private void refreshChartOfEap(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string eap = string.Empty;
            string desc = string.Empty;
            int pointIndex = 0;
            int nextRowNumber = 0;

            try
            {
                m_eapList = new Dictionary<string, UInt32>();
                m_eapDescList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r[0].ToString();
                        desc = r[1].ToString();
                        m_eapList.Add(eap, 0);
                        m_eapDescList.Add(eap, desc);
                        // --
                        foreach (Series s in chartEap.Series)
                        {
                            pointIndex = s.Points.AddXY(string.Format("{0} [{1}]", eap, desc), double.NaN);
                            s.Points[pointIndex].Tag = eap;
                            s.Points[pointIndex].IsEmpty = true;
                            s.Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", eap, desc, 0);
                            s.Points[pointIndex].LabelToolTip = eap;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (m_eapList.Count == 0)
                {
                    foreach (Series s in chartEap.Series)
                    {
                        s.Points.Add(
                            new DataPoint(chartEap.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
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

        private void refreshChartOfEquipment(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string eqpName = string.Empty;
            string desc = string.Empty;
            int pointIndex = 0;
            int nextRowNumber = 0;

            try
            {
                m_equipmentList = new Dictionary<string, UInt32>();
                m_equipmentDescList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqpName = r[0].ToString();
                        desc = r[1].ToString();
                        m_equipmentList.Add(eqpName, 0);
                        m_equipmentDescList.Add(eqpName, desc);
                        // --
                        foreach (Series s in chartEqp.Series)
                        {
                            pointIndex = s.Points.AddXY(string.Format("{0} [{1}]", eqpName, desc), double.NaN);
                            s.Points[pointIndex].Tag = eqpName;
                            s.Points[pointIndex].IsEmpty = true;
                            s.Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", eqpName, desc, 0);
                            s.Points[pointIndex].LabelToolTip = eqpName;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                if (m_equipmentList.Count == 0)
                {
                    foreach (Series s in chartEqp.Series)
                    {
                        s.Points.Add(
                            new DataPoint(chartEqp.ChartAreas[0].AxisX.Minimum, double.NaN) { IsEmpty = true }
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
            string server = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int pointCount = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "SearchServerIssueEventSummary", fSqlParams, false, ref nextRowNumber);
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
                            m_serverList[server] = count;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                foreach (string s in m_serverList.Keys)
                {
                    pointIndex = chartServer.Series[0].Points.AddXY(string.Format("{0} [{1}]", s, m_serverDescList[s]), m_serverList[s]);
                    chartServer.Series[0].Points[pointIndex].Tag = s;
                    chartServer.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", s, m_serverDescList[s], m_serverList[s].ToString());

                    // --

                    pointCount++;
                }

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

        private void refreahChartOfEapIssueEventSummary(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string eap = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int pointCount = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "SearchEapIssueEventSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r[0].ToString();
                        if (m_eapList.ContainsKey(eap))
                        {
                            if (!UInt32.TryParse(r[1].ToString(), out count))
                            {
                                count = 0;
                            }
                            m_eapList[eap] = count;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                foreach (string s in m_eapList.Keys)
                {
                    pointIndex = chartEap.Series[0].Points.AddXY(string.Format("{0} [{1}]", s, m_eapDescList[s]), m_eapList[s]);
                    chartEap.Series[0].Points[pointIndex].Tag = s;
                    chartEap.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", s, m_eapDescList[s], m_eapList[s].ToString());

                    // --

                    pointCount++;
                }

                // --

                if (pointCount > 0)
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in chartEap.Series)
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
                    chartEap.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
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

        private void refreahChartOfEquipmentIssueEventSummary(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            List<DataPoint> emptyPoints = null;
            string eqpName = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int pointCount = 0;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "IssueEventSummary", "SearchEquipmentIssueEventSummary", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqpName = r[0].ToString();
                        if (m_equipmentList.ContainsKey(eqpName))
                        {
                            if (!UInt32.TryParse(r[1].ToString(), out count))
                            {
                                count = 0;
                            }
                            m_equipmentList[eqpName] = count;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                foreach (string s in m_equipmentList.Keys)
                {
                    pointIndex = chartEqp.Series[0].Points.AddXY(string.Format("{0} [{1}]", s, m_equipmentDescList[s]), m_equipmentList[s]);
                    chartEqp.Series[0].Points[pointIndex].Tag = s;
                    chartEqp.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", s, m_equipmentDescList[s], m_equipmentList[s].ToString());

                    // --

                    pointCount++;
                }

                // --

                if (pointCount > 0)
                {
                    // ***
                    // Empty Point 제거
                    // ***
                    foreach (Series s in chartEqp.Series)
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
                    chartEqp.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
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

        private void procMenuRefresh(
            )
        {
            try
            {
                clear();

                // --

                refreahChartOfServerIssueEventSummary();
                refreahChartOfEapIssueEventSummary();
                refreahChartOfEquipmentIssueEventSummary();
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
                refreahChartOfEapIssueEventSummary();
                refreahChartOfEquipmentIssueEventSummary();
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
                refreahChartOfEapIssueEventSummary();
                refreahChartOfEquipmentIssueEventSummary();
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_IssueEventSummary" + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Issue Event Summary to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Issue Event Summary");

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

                // --

                // ***
                // Server Issue Event Summary Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Server Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartServer, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // EAP Issue Event Summary Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEap, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // Equipment Issue Event Summary Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("Equipment Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEqp, rowIndex, 0, rowIndex + 21, 8);

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

        #region FIssueEventSummary Form Event Handler

        private void FIssueEventSummary_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
           
                designChartOfServer();
                designChartOfEap();
                designChartOfEquipment();

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

        private void FIssueEventSummary_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --              

                udtDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                // -- 

                refreahChartOfServerIssueEventSummary();
                refreahChartOfEapIssueEventSummary();
                refreahChartOfEquipmentIssueEventSummary();
                // --
                m_cleared = false;

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

        private void FIssueEventSummary_FormClosing(
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

        private void FIssueEventSummary_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuIesRefresh)
                {
                    procMenuRefresh();                    
                }
                else if (e.Tool.Key == FMenuKey.MenuIesPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuIesNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuIesExport)
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

        #region chartServer Control Event Handler

        private void chartServer_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string server = string.Empty;
            FServerIssueEventSummary fServerIssueEventSummary = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartServer.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    server = (string)chartServer.Series["Server"].Points[ret.PointIndex].Tag;              
                    // --
                    fServerIssueEventSummary = (FServerIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FServerIssueEventSummary));
                    if (fServerIssueEventSummary == null)
                    {
                        fServerIssueEventSummary = new FServerIssueEventSummary(m_fAdmCore);
                        m_fAdmCore.fAdmContainer.showChild(fServerIssueEventSummary);
                    }
                    fServerIssueEventSummary.activate();
                    fServerIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), server);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fServerIssueEventSummary = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region chartEap Control Event Handler

        private void chartEap_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string eap = string.Empty;
            FEapIssueEventSummary fEapIssueEventSummary = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEap.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    eap = (string)chartEap.Series["EAP"].Points[ret.PointIndex].Tag;
                    // --
                    fEapIssueEventSummary = (FEapIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FEapIssueEventSummary));
                    if (fEapIssueEventSummary == null)
                    {
                        fEapIssueEventSummary = new FEapIssueEventSummary(m_fAdmCore);
                        m_fAdmCore.fAdmContainer.showChild(fEapIssueEventSummary);
                    }
                    fEapIssueEventSummary.activate();
                    fEapIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), eap);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fEapIssueEventSummary = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region chartEqp Control Event Handler

        private void chartEqp_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string eqp = string.Empty;
            FEquipmentIssueEventSummary fEquipmentIssueEventSummary = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEqp.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    eqp = (string)chartEqp.Series["Equipment"].Points[ret.PointIndex].Tag;
                    // --
                    fEquipmentIssueEventSummary = (FEquipmentIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentIssueEventSummary));
                    if (fEquipmentIssueEventSummary == null)
                    {
                        fEquipmentIssueEventSummary = new FEquipmentIssueEventSummary(m_fAdmCore);
                        m_fAdmCore.fAdmContainer.showChild(fEquipmentIssueEventSummary);
                    }
                    fEquipmentIssueEventSummary.activate();
                    fEquipmentIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), eqp);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fEquipmentIssueEventSummary = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
