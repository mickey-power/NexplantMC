/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapIssueEventHistory.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.26
--  Description     : FAmate Admin Manager EAP Issue Event History Form Class 
--  History         : Created by spike.lee at 2017.07.26
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
    public partial class FEapIssueEventHistory : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --
        private Dictionary<string, string> m_eapList = null;
        private DataTable m_dtFraseapieh = null;
        private bool m_isAtteched = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapIssueEventHistory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapIssueEventHistory(
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
                    m_dtFraseapieh = null;
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

        private void designGridOfHistory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Time");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Event");
                // --
                for (int i = 1; i <= 20; i++)
                {
                    uds.Band.Columns.Add("Header " + i.ToString());
                    uds.Band.Columns.Add("Data " + i.ToString());
                }
                // --
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Operation Status");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("User ID");
                uds.Band.Columns.Add("(Set) Package");
                uds.Band.Columns.Add("(Rel) Package");
                uds.Band.Columns.Add("(Apl) Package");
                uds.Band.Columns.Add("(Set) Model");
                uds.Band.Columns.Add("(Rel) Model");
                uds.Band.Columns.Add("(Apl) Model");
                uds.Band.Columns.Add("(Set) Component");
                uds.Band.Columns.Add("(Rel) Component");
                uds.Band.Columns.Add("(Apl) Component");
                uds.Band.Columns.Add("Comment");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].CellAppearance.Image = Properties.Resources.History;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Time"].Width = 174;
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Event"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Operation Status"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Need Action"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["(Set) Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Rel) Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Apl) Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Set) Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Rel) Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Apl) Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Set) Component"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Rel) Component"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["(Apl) Component"].Width = 180;
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
                    mnuMenu.Tools[FMenuKey.MenuEihExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuEihExport].SharedProps.Enabled = true;
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

                foreach (FChart fChart in new FChart[] { chartEap })
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

                if (m_dtFraseapieh == null)
                {
                    m_dtFraseapieh = new DataTable();
                    foreach (string clmName in new string[] { "TRAN_TIME", "HIST_SEQ", "EAP", "EVENT_ID", "SERVER", "STEP", "UP_DOWN", "STATUS", "OPERATION_STATUS", "NEED_ACTION", "NEXT_NEED_ACTION", "TRAN_USER_ID" })
                    {
                        // ***
                        // 2017.04.04 by spike.lee
                        // HIST_SEQ Sort를 숫자형으로 적용하도록 수정
                        // ***
                        if (clmName == "HIST_SEQ")
                        {
                            m_dtFraseapieh.Columns.Add(clmName, typeof(UInt64));
                        }
                        else
                        {
                            m_dtFraseapieh.Columns.Add(clmName, typeof(string));
                        }
                    }
                    // --
                    foreach (string prev in new string[] { "SET", "REL", "APL" })
                    {
                        foreach (string clmName in new string[] { "PACKAGE", "PKG_VER" })
                        {
                            m_dtFraseapieh.Columns.Add(string.Format("{0}_{1}", prev, clmName), typeof(string));
                        }
                    }
                    // --
                    foreach (string prev in new string[] { "SET", "REL", "APL" })
                    {
                        foreach (string clmName in new string[] { "MODEL", "MDL_VER" })
                        {
                            m_dtFraseapieh.Columns.Add(string.Format("{0}_{1}", prev, clmName), typeof(string));
                        }
                    }
                    // --
                    foreach (string prev in new string[] { "SET", "REL", "APL" })
                    {
                        foreach (string clmName in new string[] { "USED_COM", "COMPONENT", "COM_VER" })
                        {
                            m_dtFraseapieh.Columns.Add(string.Format("{0}_{1}", prev, clmName), typeof(string));
                        }
                    }
                    // --
                    for (int i = 1; i <= 20; i++)
                    {
                        foreach (string clmName in new string[] { "EVT_H", "EVT_D" })
                        {
                            m_dtFraseapieh.Columns.Add(string.Format("{0}_{1}", clmName, i.ToString()), typeof(string));
                        }
                    }
                    // --
                    m_dtFraseapieh.Columns.Add("TRAN_COMMENT", typeof(string));
                }
                m_dtFraseapieh.Rows.Clear();

                #endregion

                // --

                refreshChartOfEap();

                // --

                initPropOfEapHistory();

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
                m_eapList = new Dictionary<string, string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapIssueEventHistory", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r[0].ToString();
                        desc = r[1].ToString();
                        m_eapList.Add(eap, desc);
                        // --
                        foreach (Series s in chartEap.Series)
                        {
                            pointIndex = s.Points.AddXY(string.Format("{0} [{1}]", eap, desc) , double.NaN);
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

                if (txtEvent.Text == string.Empty)
                {
                    txtEvent.Focus();
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "Event" }));
                }

                #endregion

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("from_date", udtFromDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("to_date", udtToDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("event_id", txtEvent.Text);
                fSqlParams.add("package", txtPackage.Text, txtPackage.Text == string.Empty ? true : false);
                fSqlParams.add("model", txtModel.Text, txtModel.Text == string.Empty ? true : false);
                fSqlParams.add("component", txtComponent.Text, txtComponent.Text == string.Empty ? true : false);
                fSqlParams.add("server", txtSvrName.Text, txtSvrName.Text == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapIssueEventHistory", "SearchEapIssueEventSummary", fSqlParams, false, ref nextRowNumber);
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
                            // --
                            pointIndex = chartEap.Series[0].Points.AddXY(string.Format("{0} [{1}]", eap, m_eapList[eap]) , count);
                            chartEap.Series[0].Points[pointIndex].Tag = eap;
                            chartEap.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", eap, m_eapList[eap], count.ToString());

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

        private void refreshGridOfEapHistory(
            string eap
            )
        {
            FSqlParams fSqlParams = null;
            int nextRowNumber = 0;
            object[] cellValues = null;
            string set_Package = string.Empty;
            string rel_Package = string.Empty;
            string apl_Package = string.Empty;
            string set_Model = string.Empty;
            string rel_Model = string.Empty;
            string apl_Model = string.Empty;
            string set_Component = string.Empty;
            string rel_Component = string.Empty;
            string apl_Component = string.Empty;
            int rowIndex = 0;

            try
            {
                initPropOfEapHistory();

                // --
                
                grdList.beginUpdate(false);
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdList.endUpdate(false);

                // --

                m_dtFraseapieh.Rows.Clear();

                // --


                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", eap);
                fSqlParams.add("from_date", udtFromDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("to_date", udtToDate.DateTime.ToString("yyyyMMdd"));
                fSqlParams.add("event_id", txtEvent.Text);
                // --
                do
                {
                    using (DataTable dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "EapIssueEventHistory", "SearchEapIeh", fSqlParams, false, ref nextRowNumber))
                    {
                        dt.AsEnumerable().Take(dt.Rows.Count).CopyToDataTable(m_dtFraseapieh, LoadOption.OverwriteChanges);
                    }
                }
                while (nextRowNumber >= 0);

                // --

                grdList.beginUpdate(false);

                // --

                m_dtFraseapieh.DefaultView.Sort = "HIST_SEQ ASC";
                foreach (DataRow r in m_dtFraseapieh.DefaultView.ToTable().Rows)
                {
                    set_Package = r["SET_PACKAGE"].ToString();
                    if (set_Package.ToString() == string.Empty)
                    {
                        set_Package = "N/A";
                    }
                    if (set_Package != "N/A")
                    {
                        set_Package += "[ver. " + r["SET_PKG_VER"].ToString() + "]";
                    }
                    // --
                    rel_Package = r["REL_PACKAGE"].ToString();
                    if (rel_Package.ToString() == string.Empty)
                    {
                        rel_Package = "N/A";
                    }
                    if (rel_Package != "N/A")
                    {
                        rel_Package += "[ver. " + r["REL_PKG_VER"].ToString() + "]";
                    }
                    // --
                    apl_Package = r["APL_PACKAGE"].ToString();
                    if (apl_Package.ToString() == string.Empty)
                    {
                        apl_Package = "N/A";
                    }
                    if (apl_Package != "N/A")
                    {
                        apl_Package += "[ver. " + r["APL_PKG_VER"].ToString() + "]";
                    }

                    // --

                    set_Model = r["SET_MODEL"].ToString();
                    if (set_Model.ToString() == string.Empty)
                    {
                        set_Model = "N/A";
                    }
                    else
                    {
                        set_Model += "[ver. " + r["SET_MDL_VER"].ToString() + "]";
                    }
                    // --
                    rel_Model = r["REL_MODEL"].ToString();
                    if (rel_Model.ToString() == string.Empty)
                    {
                        rel_Model = "N/A";
                    }
                    if (rel_Model != "N/A")
                    {
                        rel_Model += "[ver. " + r["REL_MDL_VER"].ToString() + "]";
                    }
                    // --
                    apl_Model = r["APL_MODEL"].ToString();
                    if (apl_Model.ToString() == string.Empty)
                    {
                        apl_Model = "N/A";
                    }
                    if (apl_Model != "N/A")
                    {
                        apl_Model += "[ver. " + r["APL_MDL_VER"].ToString() + "]";
                    }

                    // --

                    set_Component = r["SET_USED_COM"].ToString();
                    if (set_Component.ToString() == string.Empty)
                    {
                        set_Component = "N/A";
                    }
                    else
                    {
                        if (set_Component == FYesNo.Yes.ToString())
                        {
                            set_Component = "(" + set_Component + ") " + r["SET_COMPONENT"].ToString() + " [Ver. " + r["SET_COM_VER"].ToString() + "]";
                        }
                        else
                        {
                            set_Component = "(" + set_Component + ")";
                        }
                    }
                    // --
                    rel_Component = r["REL_USED_COM"].ToString();
                    if (rel_Component.ToString() == string.Empty)
                    {
                        rel_Component = "N/A";
                    }
                    if (rel_Component != "N/A")
                    {
                        if (rel_Component == FYesNo.Yes.ToString())
                        {
                            rel_Component = "(" + rel_Component + ") " + r["REL_COMPONENT"].ToString() + " [Ver. " + r["REL_COM_VER"].ToString() + "]";
                        }
                        else
                        {
                            rel_Component = "(" + rel_Component + ")";
                        }
                    }
                    // --
                    apl_Component = r["APL_USED_COM"].ToString();
                    if (apl_Component.ToString() == string.Empty)
                    {
                        apl_Component = "N/A";
                    }
                    if (apl_Component != "N/A")
                    {
                        if (apl_Component == FYesNo.Yes.ToString())
                        {
                            apl_Component = "(" + apl_Component + ") " + r["APL_COMPONENT"].ToString() + " [Ver. " + r["APL_COM_VER"].ToString() + "]";
                        }
                        else
                        {
                            apl_Component = "(" + apl_Component + ")";
                        }
                    }

                    cellValues = new object[] {
                        FDataConvert.defaultDataTimeFormating(r["TRAN_TIME"].ToString()),	
		                r["EAP"].ToString(),
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
                        r["SERVER"].ToString(),
                        r["STEP"].ToString(),
                        r["UP_DOWN"].ToString(),
                        r["STATUS"].ToString(),
                        r["OPERATION_STATUS"].ToString(),
                        r["NEED_ACTION"].ToString(),
                        r["NEXT_NEED_ACTION"].ToString(),
                        r["TRAN_USER_ID"].ToString(),
                        set_Package,
                        rel_Package,
                        apl_Package,
                        set_Model,
                        rel_Model,
                        apl_Model,
                        set_Component,
                        rel_Component,
                        apl_Component,                        
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

        private void initPropOfEapHistory(
           )
        {
            try
            {
                pgdProp.selectedObject = new FPropEapHistory(m_fAdmCore, pgdProp);
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

                refreahChartOfEapIssueEventSummary();
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_McIssueEventHistory" + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export MC Issue Event History to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("EAP Issue Event History");

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
                rowIndex += 1;
                fExcelSht.writeCondition(lblEvent.Text, txtEvent.Text, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblPackage.Text, txtPackage.Text, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblModel.Text, txtModel.Text, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblComponent.Text, txtComponent.Text, rowIndex, 0);
                // --
                rowIndex += 1;
                fExcelSht.writeCondition(lblServer.Text, txtSvrName.Text, rowIndex, 0);

                // --

                // ***
                // MC Issue Event Summary Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Issue Event Summary") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEap, rowIndex, 0, rowIndex + 21, 8);

                // --

                // ***
                // EAP History Grid Write
                // ***
                rowIndex += 22;
                fExcelSht.writeText("[" + m_fAdmCore.fUIWizard.searchCaption("EAP Issue Event History") + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
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
            string evt
            )
        {
            try
            {
                udtFromDate.Value = tranDate;
                udtToDate.Value = tranDate;
                txtEvent.Text = evt;

                // --

                tabMain.SelectedTab = tabMain.Tabs["EAP"];

                // --

                procMenuRefresh();

                // --

                txtEvent.Focus();

                // --

                m_isAtteched = true;
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

        #region FEapIssueEventHistory Form Event Handler

        private void FEapIssueEventHistory_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
           
                designChartOfEap();
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

        private void FEapIssueEventHistory_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --              

                if (m_isAtteched)
                {
                    return;
                }

                // -- 

                udtFromDate.Value = DateTime.Now.AddDays(-1 * m_fAdmCore.fOption.historySearchPeriod).ToString("yyyy-MM-dd");
                udtToDate.Value = DateTime.Now.ToString("yyyy-MM-dd");

                // -- 

                txtEvent.Focus();

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

        private void FEapIssueEventHistory_FormClosing(
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

        private void FEapIssueEventHistory_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuEihRefresh)
                {
                    procMenuRefresh();                    
                }                
                else if (e.Tool.Key == FMenuKey.MenuEihExport)
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

        #region chartEap Control Event Handler

        private void chartEap_MouseClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string eap = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEap.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    eap = (string)chartEap.Series["EAP"].Points[ret.PointIndex].Tag;
                    refreshGridOfEapHistory(eap);
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

        private void chartEap_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;

            try
            {
                FCursor.waitCursor();

                // --

                ret = chartEap.HitTest(e.X, e.Y);
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

        #region txtEvent Control Event Handler

        private void txtEvent_EditorButtonClick(
            object sender, 
            EditorButtonEventArgs e
            )
        {
            FEventSelector fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FEventSelector(m_fAdmCore, FEventType.MC.ToString(), txtEvent.Text, false);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                txtEvent.Text = fDialog.selectedEvent;
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

        private void txtEvent_ValueChanged(
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

                pgdProp.selectedObject = new FPropEapHistory(m_fAdmCore, pgdProp, (DataRow)grdList.ActiveRow.Tag);
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

                initPropOfEapHistory();
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

                fDialog = new FServerSelector(m_fAdmCore, "", txtSvrName.Text, "N");
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region TextBox Common Control Event Handler

        private void txtCommon_ValueChanged(
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

    }   // Class end
}   // Namespace end
