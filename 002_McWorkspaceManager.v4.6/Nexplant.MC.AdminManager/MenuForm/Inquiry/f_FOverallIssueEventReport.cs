/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOverallIssueEventReport.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.01
--  Description     : FAmate Admin Manager Overall Issue Event Report Form Class 
--  History         : Created by spike.lee at 2017.08.01
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
    public partial class FOverallIssueEventReport : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_cleared = false;
        // --

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOverallIssueEventReport(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOverallIssueEventReport(
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                if (m_cleared)
                {
                    mnuMenu.Tools[FMenuKey.MenuOerExport].SharedProps.Enabled = false;
                }
                else
                {
                    mnuMenu.Tools[FMenuKey.MenuOerExport].SharedProps.Enabled = true;
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

        private void designChartOfTotal(
            )
        {
            try
            {
                // ***
                // Design Chart Aggregate
                // *** 
                chartTotal.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartTotal.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartTotal.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartTotal.ChartAreas[0].AxisY.Title = "Count (n)";
                chartTotal.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartTotal.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartTotal.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartTotal.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartTotal.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartTotal.addSeries("Total", SeriesChartType.Column);
                chartTotal.Series["Total"].Color = Color.IndianRed;
                chartTotal.Series["Total"].Label = "#VAL";
                chartTotal.Series["Total"].XValueType = ChartValueType.String;
                chartTotal.Series["Total"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfTotal(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdTotal.dataSource;
                // --
                uds.Band.Columns.Add("No.");
                uds.Band.Columns.Add("Category");
                uds.Band.Columns.Add("Description");                
                uds.Band.Columns.Add("Total");                

                // --

                grdTotal.DisplayLayout.Bands[0].Columns["No."].Width = 60;
                grdTotal.DisplayLayout.Bands[0].Columns["Category"].Width = 120;
                grdTotal.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdTotal.DisplayLayout.Bands[0].Columns["Total"].Width = 60;
                
                // --

                grdTotal.DisplayLayout.Bands[0].Columns["No."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdTotal.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdTotal.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfServerTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue Server Top 5
                // *** 
                chartServerTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartServerTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartServerTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartServerTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartServerTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartServerTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartServerTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartServerTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartServerTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;                

                // --

                // ***
                // Design Series
                // ***
                chartServerTop5.addSeries("Server", SeriesChartType.Column);
                chartServerTop5.Series["Server"].Color = Color.IndianRed;
                chartServerTop5.Series["Server"].Label = "#VAL";
                chartServerTop5.Series["Server"].XValueType = ChartValueType.String;
                chartServerTop5.Series["Server"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfServerRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdServerRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdServerRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdServerRanking.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdServerRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 220;
                grdServerRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdServerRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdServerRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdServerRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfServerEventTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue Event of Server Top 5
                // *** 
                chartServerEventTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartServerEventTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartServerEventTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartServerEventTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartServerEventTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartServerEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartServerEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartServerEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartServerEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartServerEventTop5.addSeries("Server Event", SeriesChartType.Column);
                chartServerEventTop5.Series["Server Event"].Color = Color.IndianRed;
                chartServerEventTop5.Series["Server Event"].Label = "#VAL";
                chartServerEventTop5.Series["Server Event"].XValueType = ChartValueType.String;
                chartServerEventTop5.Series["Server Event"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfServerEventRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdServerEventRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Event"].Width = 120;
                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdServerEventRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdServerEventRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfEapTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue EAP Top 5
                // *** 
                chartEapTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEapTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEapTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEapTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEapTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEapTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEapTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEapTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEapTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEapTop5.addSeries("EAP", SeriesChartType.Column);
                chartEapTop5.Series["EAP"].Color = Color.IndianRed;
                chartEapTop5.Series["EAP"].Label = "#VAL";
                chartEapTop5.Series["EAP"].XValueType = ChartValueType.String;
                chartEapTop5.Series["EAP"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfEapRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEapRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdEapRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdEapRanking.DisplayLayout.Bands[0].Columns["EAP"].Width = 120;
                grdEapRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdEapRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdEapRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEapRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdEapRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfEapEventTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue Event of EAP Top 5
                // *** 
                chartEapEventTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEapEventTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEapEventTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEapEventTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEapEventTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEapEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEapEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEapEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEapEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEapEventTop5.addSeries("EAP Event", SeriesChartType.Column);
                chartEapEventTop5.Series["EAP Event"].Color = Color.IndianRed;
                chartEapEventTop5.Series["EAP Event"].Label = "#VAL";
                chartEapEventTop5.Series["EAP Event"].XValueType = ChartValueType.String;
                chartEapEventTop5.Series["EAP Event"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfEapEventRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEapEventRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Event"].Width = 120;
                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEapEventRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdEapEventRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfEquipmentTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue Equipment Top 5
                // *** 
                chartEqpTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEqpTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEqpTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                //// --
                chartEqpTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEqpTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEqpTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEqpTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEqpTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEqpTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEqpTop5.addSeries("Equipment", SeriesChartType.Column);
                chartEqpTop5.Series["Equipment"].Color = Color.IndianRed;
                chartEqpTop5.Series["Equipment"].Label = "#VAL";
                chartEqpTop5.Series["Equipment"].XValueType = ChartValueType.String;
                chartEqpTop5.Series["Equipment"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfEquipmentRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEqpRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdEqpRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdEqpRanking.DisplayLayout.Bands[0].Columns["Equipment"].Width = 120;
                grdEqpRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdEqpRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdEqpRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqpRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdEqpRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void designChartOfEquipmentEventTop5(
            )
        {
            try
            {
                // ***
                // Design Chart Issue Event of Equipment Top 5
                // *** 
                chartEqpEventTop5.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
                chartEqpEventTop5.ChartAreas[0].AxisX.IsMarginVisible = true;
                chartEqpEventTop5.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                // --
                chartEqpEventTop5.ChartAreas[0].AxisY.Title = "Count (n)";
                chartEqpEventTop5.ChartAreas[0].AxisY.IsMarginVisible = true;
                // --
                chartEqpEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                chartEqpEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.LineColor = Color.Gray;
                chartEqpEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.MaxNumberOfBreaks = 2;
                chartEqpEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.CollapsibleSpaceThreshold = 60;

                // --

                // ***
                // Design Series
                // ***
                chartEqpEventTop5.addSeries("Equipment Event", SeriesChartType.Column);
                chartEqpEventTop5.Series["Equipment Event"].Color = Color.IndianRed;
                chartEqpEventTop5.Series["Equipment Event"].Label = "#VAL";
                chartEqpEventTop5.Series["Equipment Event"].XValueType = ChartValueType.String;
                chartEqpEventTop5.Series["Equipment Event"].YValueType = ChartValueType.UInt32;
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

        private void designGridOfEquipmentEventRanking(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEqpEventRanking.dataSource;
                // --
                uds.Band.Columns.Add("Ranking");
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Total");

                // --

                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].Width = 60;
                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Event"].Width = 120;
                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Total"].Width = 60;

                // --

                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Ranking"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdEqpEventRanking.DisplayLayout.Bands[0].Columns["Total"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

                // --

                grdEqpEventRanking.DisplayLayout.Override.TipStyleCell = TipStyle.Show;
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

        private void refreshIssueTotal(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            Dictionary<string, UInt32> aggregateList = null;    
            Dictionary<string, string> descList = null;
            int pointIndex = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;

            try
            {
                chartTotal.Series[0].Points.Clear();

                // --

                aggregateList = new Dictionary<string, UInt32>();
                descList = new Dictionary<string,string>();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                
                // --
                
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountServerIssueEventTotal", fSqlParams, true);
                aggregateList.Add("Server", UInt32.Parse(dt.Rows[0][0].ToString()));
                descList.Add("Server", "Server Issue Event Total");
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountEapIssueEventTotal", fSqlParams, true);
                aggregateList.Add("EAP", UInt32.Parse(dt.Rows[0][0].ToString()));
                descList.Add("EAP", "EAP Issue Event Total");
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountEquipmentIssueEventTotal", fSqlParams, true);
                aggregateList.Add("Equipment", UInt32.Parse(dt.Rows[0][0].ToString()));
                descList.Add("Equipment", "Equipment Issue Event Total");
                
                // --

                foreach (string s in aggregateList.Keys)
                {
                    pointIndex = chartTotal.Series[0].Points.AddXY(s, aggregateList[s]);
                    chartTotal.Series[0].Points[pointIndex].Tag = s;
                    chartTotal.Series[0].Points[pointIndex].ToolTip = string.Format("{0} : {1}", s, aggregateList[s]);
                }

                // --

                grdTotal.beginUpdate();
                
                // --
                
                foreach (string s in aggregateList.Keys)
                {
                    index++;
                    // --
                    cellValues = new object[] {
                        index.ToString(),                    
                        s,    
                        descList[s],
                        aggregateList[s].ToString("#,##0")
                        };
                    // --
                    grdTotal.appendDataRow(s, cellValues);

                    // --

                    total += aggregateList[s];
                }
                // --
                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                // --
                index = grdTotal.appendDataRow("*", cellValues).Index;                

                // --

                if (grdTotal.Rows.Count > 0)
                {
                    grdTotal.ActiveRow = grdTotal.Rows[0];
                }
                
                // -- 
                
                grdTotal.endUpdate();

                // --

                grdTotal.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                chartTotal.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
            }
            catch (Exception ex)
            {
                grdTotal.endUpdate(); 
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueServer(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string server = string.Empty;
            string desc = string.Empty;            
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;            
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartServerTop5.Series[0].Points.Clear();

                // --

                grdServerRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountIssueServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        server = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --

                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartServerTop5.Series[0].Points.AddXY(server, count);
                            chartServerTop5.Series[0].Points[pointIndex].Tag = server;
                            chartServerTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", server, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            server,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdServerRanking.appendDataRow(server, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdServerRanking.appendDataRow("*", cellValues).Index;                

                // --

                grdServerRanking.endUpdate();

                // --

                grdServerRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartServerTop5.Series[0].Points.Count == 0)
                {
                    chartServerTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartServerTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdServerRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueServerEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string evt = string.Empty;
            string desc = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartServerEventTop5.Series[0].Points.Clear();

                // --

                grdServerEventRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountServerIssueEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --

                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartServerEventTop5.Series[0].Points.AddXY(evt, count);
                            chartServerEventTop5.Series[0].Points[pointIndex].Tag = evt;
                            chartServerEventTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            evt,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdServerEventRanking.appendDataRow(evt, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdServerEventRanking.appendDataRow("*", cellValues).Index;

                // --

                grdServerEventRanking.endUpdate();

                // --

                grdServerEventRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartServerEventTop5.Series[0].Points.Count == 0)
                {
                    chartServerEventTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartServerEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdServerEventRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueEap(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string eap = string.Empty;
            string desc = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartEapTop5.Series[0].Points.Clear();

                // -- 

                grdEapRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountIssueEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eap = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --

                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartEapTop5.Series[0].Points.AddXY(eap, count);
                            chartEapTop5.Series[0].Points[pointIndex].Tag = eap;
                            chartEapTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", eap, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            eap,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdEapRanking.appendDataRow(eap, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdEapRanking.appendDataRow("*", cellValues).Index;

                // --

                grdEapRanking.endUpdate();

                // --

                grdEapRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartEapTop5.Series[0].Points.Count == 0)
                {
                    chartEapTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartEapTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdEapRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueEapEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string evt = string.Empty;
            string desc = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartEapEventTop5.Series[0].Points.Clear();

                // --

                grdEapEventRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountEapIssueEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --
                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartEapEventTop5.Series[0].Points.AddXY(evt, count);
                            chartEapEventTop5.Series[0].Points[pointIndex].Tag = evt;
                            chartEapEventTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            evt,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdEapEventRanking.appendDataRow(evt, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdEapEventRanking.appendDataRow("*", cellValues).Index;

                // --

                grdEapEventRanking.endUpdate();

                // --

                grdEapEventRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartEapEventTop5.Series[0].Points.Count == 0)
                {
                    chartEapEventTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartEapEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdEapEventRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueEquipment(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string eqp = string.Empty;
            string desc = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartEqpTop5.Series[0].Points.Clear();

                // --

                grdEqpRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountIssueEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        eqp = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --

                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartEqpTop5.Series[0].Points.AddXY(eqp, count);
                            chartEqpTop5.Series[0].Points[pointIndex].Tag = eqp;
                            chartEqpTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", eqp, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            eqp,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdEqpRanking.appendDataRow(eqp, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdEqpRanking.appendDataRow("*", cellValues).Index;

                // --

                grdEqpRanking.endUpdate();

                // --

                grdEqpRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartEqpTop5.Series[0].Points.Count == 0)
                {
                    chartEqpTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartEqpTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdEqpRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void refreshIssueEquipmentEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string evt = string.Empty;
            string desc = string.Empty;
            UInt32 count = 0;
            int nextRowNumber = 0;
            int pointIndex = 0;
            int ranking = 0;
            object[] cellValues = null;
            int index = 0;
            UInt32 total = 0;
            UInt32 lastCount = 0;

            try
            {
                chartEqpEventTop5.Series[0].Points.Clear();

                // --

                grdEqpEventRanking.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("tran_date", udtDate.DateTime.ToString("yyyyMMdd"));
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Inquiry", "OverallIssueEventReport", "CountEquipmentIssueEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        evt = r[0].ToString();
                        desc = r[1].ToString();
                        count = UInt32.Parse(r[2].ToString());

                        // --

                        if (count != lastCount)
                        {
                            ranking++;
                            lastCount = count;
                        }

                        // --

                        if (ranking <= 5)
                        {
                            pointIndex = chartEqpEventTop5.Series[0].Points.AddXY(evt, count);
                            chartEqpEventTop5.Series[0].Points[pointIndex].Tag = evt;
                            chartEqpEventTop5.Series[0].Points[pointIndex].ToolTip = string.Format("{0} [{1}] : {2}", evt, desc, count.ToString());
                        }

                        // --

                        cellValues = new object[] {
                            ranking.ToString(),                    
                            evt,    
                            desc,
                            count.ToString("#,##0")
                            };
                        // --
                        grdEqpEventRanking.appendDataRow(evt, cellValues);

                        // --

                        total += count;
                    }
                } while (nextRowNumber >= 0);

                // --

                cellValues = new object[] {
                    "*",                    
                    "Total",    
                    string.Empty,
                    total.ToString("#,##0")
                    };
                index = grdEqpEventRanking.appendDataRow("*", cellValues).Index;

                // --

                grdEqpEventRanking.endUpdate();

                // --

                grdEqpEventRanking.Rows[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

                // --

                if (chartEqpEventTop5.Series[0].Points.Count == 0)
                {
                    chartEqpEventTop5.Series[0].Points.AddXY(" ", double.NaN);
                }
                else
                {
                    chartEqpEventTop5.ChartAreas[0].AxisY.ScaleBreakStyle.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                grdEqpEventRanking.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void clear(
            )
        {
            try
            {
                #region Init Chart

                foreach (FChart fChart in new FChart[] { chartTotal, chartServerTop5, chartServerEventTop5, chartEapTop5, chartEapEventTop5, chartEqpTop5, chartEqpEventTop5 })
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

                    // -- 
                    
                    foreach (Series s in fChart.Series)
                    {
                        s.Points.AddXY(" ", double.NaN);
                    }
                }

                #endregion

                // --

                #region Init Grid

                foreach (FGrid fGrid in new FGrid[] { grdTotal, grdServerRanking, grdServerEventRanking, grdEapRanking, grdEapEventRanking, grdEqpRanking, grdEqpEventRanking })
                {
                    fGrid.beginUpdate();
                    fGrid.removeAllDataRow();
                    fGrid.DisplayLayout.Bands[0].SortedColumns.Clear();
                    fGrid.endUpdate();
                }

                #endregion

                // --

                m_cleared = true;

                // --

                controlMenu();
            }
            catch (Exception ex)
            {
                grdTotal.endUpdate();
                grdServerRanking.endUpdate();
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

                refreshIssueTotal();
                // -- 
                refreshIssueServer();
                refreshIssueServerEvent();
                // --
                refreshIssueEap();
                refreshIssueEapEvent();
                // --
                refreshIssueEquipment();
                refreshIssueEquipmentEvent();
                
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

                refreshIssueTotal();
                refreshIssueServer();
                refreshIssueServerEvent();
                refreshIssueEap();
                refreshIssueEapEvent();
                refreshIssueEquipment();
                refreshIssueEquipmentEvent();
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

                refreshIssueTotal();
                refreshIssueServer();
                refreshIssueServerEvent();
                refreshIssueEap();
                refreshIssueEapEvent();
                refreshIssueEquipment();
                refreshIssueEquipmentEvent();
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
                fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_OverallIssueEventReport" + ".xlsx";

                // --

                sfd = new SaveFileDialog();
                // --                
                sfd.Title = "Export Overall Issue Event Report to Excel";
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
                fExcelSht = fExcelExp.addExcelSheet("Overall Issue Event Report");

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
                // Issue Event Total Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblTotal.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartTotal, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Event Category Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblCategory.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdTotal, rowIndex, 0);

                // --

                // ***
                // Issue Server Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblServerTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartServerTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Server Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblServerRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdServerRanking, rowIndex, 0);

                // --

                // ***
                // Issue Event of Server Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblServerEventTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartServerEventTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Event of Server Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblServerEventRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdServerEventRanking, rowIndex, 0);

                // --

                // ***
                // Issue EAP Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblEapTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEapTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue EAP Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblEapRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEapRanking, rowIndex, 0);

                // --

                // ***
                // Issue Event of EAP Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblEapEventTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEapEventTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Event of EAP Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblEapEventRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEapEventRanking, rowIndex, 0);

                // --

                // ***
                // Issue Equipment Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblEqpTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEqpTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Equipment Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblEqpRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEqpRanking, rowIndex, 0);

                // --

                // ***
                // Issue Event of Equipment Top 5 Write
                // ***
                rowIndex += 2;
                fExcelSht.writeText("[" + lblEqpEventTop5.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                fExcelSht.writeChart(chartEqpEventTop5, rowIndex, 0, rowIndex + 11, 4);

                // --

                // ***
                // Issue Event of Equipment Ranking Write
                // ***
                rowIndex += 12;
                fExcelSht.writeText("[" + lblEqpEventRanking.Text + "]", rowIndex, 0, m_fAdmCore.fUIWizard.fontName, 9, true);
                // --
                rowIndex += 1;
                rowIndex = fExcelSht.writeGrid(grdEqpEventRanking, rowIndex, 0);

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

        private void attachServerIssueEventSummary(
            string server
            )
        {
            FServerIssueEventSummary fServerIssueEventSummary = null;

            try
            {
                fServerIssueEventSummary = (FServerIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FServerIssueEventSummary));
                if (fServerIssueEventSummary == null)
                {
                    fServerIssueEventSummary = new FServerIssueEventSummary(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerIssueEventSummary);
                }
                fServerIssueEventSummary.activate();
                fServerIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), server);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void attachServerIssueEventHistory(
            string evt
            )
        {
            FServerIssueEventHistory fServerIssueEventHistory = null;

            try
            {
                fServerIssueEventHistory = (FServerIssueEventHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FServerIssueEventHistory));
                if (fServerIssueEventHistory == null)
                {
                    fServerIssueEventHistory = new FServerIssueEventHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerIssueEventHistory);
                }
                fServerIssueEventHistory.activate();
                fServerIssueEventHistory.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), evt);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerIssueEventHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void attachEapIssueEventSummary(
            string eap
            )
        {
            FEapIssueEventSummary fEapIssueEventSummary = null;

            try
            {
                fEapIssueEventSummary = (FEapIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FEapIssueEventSummary));
                if (fEapIssueEventSummary == null)
                {
                    fEapIssueEventSummary = new FEapIssueEventSummary(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapIssueEventSummary);
                }
                fEapIssueEventSummary.activate();
                fEapIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), eap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void attachEapIssueEventHistory(
            string evt
            )
        {
            FEapIssueEventHistory fEapIssueEventHistory = null;

            try
            {
                fEapIssueEventHistory = (FEapIssueEventHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEapIssueEventHistory));
                if (fEapIssueEventHistory == null)
                {
                    fEapIssueEventHistory = new FEapIssueEventHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapIssueEventHistory);
                }
                fEapIssueEventHistory.activate();
                fEapIssueEventHistory.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), evt);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapIssueEventHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void attachEquipmentIssueEventSummary(
            string eqp
            )
        {
            FEquipmentIssueEventSummary fEquipmentIssueEventSummary = null;

            try
            {
                fEquipmentIssueEventSummary = (FEquipmentIssueEventSummary)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentIssueEventSummary));
                if (fEquipmentIssueEventSummary == null)
                {
                    fEquipmentIssueEventSummary = new FEquipmentIssueEventSummary(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentIssueEventSummary);
                }
                fEquipmentIssueEventSummary.activate();
                fEquipmentIssueEventSummary.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), eqp);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentIssueEventSummary = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void attachEquipmentIssueEventHistory(
            string evt
            )
        {
            FEquipmentIssueEventHistory fEquipmentIssueEventHistory = null;

            try
            {
                fEquipmentIssueEventHistory = (FEquipmentIssueEventHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentIssueEventHistory));
                if (fEquipmentIssueEventHistory == null)
                {
                    fEquipmentIssueEventHistory = new FEquipmentIssueEventHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEquipmentIssueEventHistory);
                }
                fEquipmentIssueEventHistory.activate();
                fEquipmentIssueEventHistory.attach(udtDate.DateTime.ToString("yyyy-MM-dd"), evt);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEquipmentIssueEventHistory = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FOverallIssueEventReport Form Event Handler

        private void FOverallIssueEventReport_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tlpMain.Width = pnlMain.Width - 18;

                // --

                designChartOfTotal();
                designGridOfTotal();
                // --
                designChartOfServerTop5();
                designGridOfServerRanking();
                // --
                designChartOfServerEventTop5();
                designGridOfServerEventRanking();
                // --
                designChartOfEapTop5();
                designGridOfEapRanking();
                // --
                designChartOfEapEventTop5();
                designGridOfEapEventRanking();
                // --
                designChartOfEquipmentTop5();
                designGridOfEquipmentRanking();
                // --
                designChartOfEquipmentEventTop5();
                designGridOfEquipmentEventRanking();

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

        private void FOverallIssueEventReport_Shown(
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

                refreshIssueTotal();
                // --
                refreshIssueServer();
                refreshIssueServerEvent();
                // --
                refreshIssueEap();
                refreshIssueEapEvent();
                // --
                refreshIssueEquipment();
                refreshIssueEquipmentEvent();

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

        private void FOverallIssueEventReport_FormClosing(
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

        private void FOverallIssueEventReport_KeyDown(
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

                if (e.Tool.Key == FMenuKey.MenuOerRefresh)
                {
                    procMenuRefresh();
                }
                else if (e.Tool.Key == FMenuKey.MenuOerPrevious)
                {
                    procMenuPrevious();
                }
                else if (e.Tool.Key == FMenuKey.MenuOerNext)
                {
                    procMenuNext();
                }
                else if (e.Tool.Key == FMenuKey.MenuOerExport)
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
                    // procMenuRefresh();
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

        #region tlpMain Control Event Handler

        private void tlpMain_Resize(
            object sender, 
            EventArgs e
            )
        {
            int width = 0;

            try
            {
                width = tlpMain.ClientSize.Width - 100;
                if (width > 0)
                {
                    tlpMain.ColumnStyles[0].Width = width;
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

        #region chartServerTop5 Control Event Handler

        private void chartServerTop5_MouseDoubleClick(
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

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventSummary))
                {
                    return;
                }

                // --

                ret = chartServerTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    server = (string)chartServerTop5.Series["Server"].Points[ret.PointIndex].Tag;
                    // --
                    attachServerIssueEventSummary(server);
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

        #region grdServerRanking Control Event Handler

        private void grdServerRanking_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            string server = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdServerRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventSummary))
                {
                    return;
                }

                // --

                server = grdServerRanking.activeDataRowKey;
                if (server != "*")
                {
                    attachServerIssueEventSummary(server);
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

        #region chartServerEventTop5 Control Event Handler

        private void chartServerEventTop5_MouseDoubleClick(
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

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventHistory))
                {
                    return;
                }

                // --

                ret = chartServerEventTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    evt = (string)chartServerEventTop5.Series["Server Event"].Points[ret.PointIndex].Tag;
                    // --
                    attachServerIssueEventHistory(evt);
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

        #region grdServerEventRanking Control Event Handler

        private void grdServerEventRanking_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            string evt = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdServerRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerIssueEventHistory))
                {
                    return;
                }

                // --

                evt = grdServerEventRanking.activeDataRowKey;
                if (evt != "*")
                {
                    attachServerIssueEventHistory(evt);
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

        #region chartEapTop5 Control Event Handler

        private void chartEapTop5_MouseDoubleClick(
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

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventSummary))
                {
                    return;
                }

                // --

                ret = chartEapTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    eap = (string)chartEapTop5.Series["EAP"].Points[ret.PointIndex].Tag;
                    // --
                    attachEapIssueEventSummary(eap);
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

        #region grdEapRanking Control Event Handler

        private void grdEapRanking_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            string eap = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdEapRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventSummary))
                {
                    return;
                }

                // --

                eap = grdEapRanking.activeDataRowKey;
                if (eap != "*")
                {
                    attachEapIssueEventSummary(eap);
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

        #region chartEapEventTop5 Control Event Handler

        private void chartEapEventTop5_MouseDoubleClick(
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

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventHistory))
                {
                    return;
                }

                // --

                ret = chartEapEventTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    evt = (string)chartEapEventTop5.Series["EAP Event"].Points[ret.PointIndex].Tag;
                    // --
                    attachEapIssueEventHistory(evt);
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

        #region grdEapEventRanking Control Event Handler

        private void grdEapEventRanking_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            string evt = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdEapEventRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapIssueEventHistory))
                {
                    return;
                }

                // --

                evt = grdEapEventRanking.activeDataRowKey;
                if (evt != "*")
                {
                    attachEapIssueEventHistory(evt);
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

        #region chartEqpTop5 Control Event Handler

        private void chartEqpTop5_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            HitTestResult ret = null;
            string eqp = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventSummary))
                {
                    return;
                }

                // --

                ret = chartEqpTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    eqp = (string)chartEqpTop5.Series["Equipment"].Points[ret.PointIndex].Tag;
                    // --
                    attachEquipmentIssueEventSummary(eqp);
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

        #region grdEqpRanking Control Event Handle

        private void grdEqpRanking_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            string eqp = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdEqpRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventSummary))
                {
                    return;
                }

                // --

                eqp = grdEqpRanking.activeDataRowKey;
                if (eqp != "*")
                {
                    attachEquipmentIssueEventSummary(eqp);
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

        #region chartEqpEventTop5 Control Event Handler

        private void chartEqpEventTop5_MouseDoubleClick(
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

                if (!FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventHistory))
                {
                    return;
                }

                // --

                ret = chartEqpEventTop5.HitTest(e.X, e.Y);
                if (ret.ChartElementType == ChartElementType.DataPoint)
                {
                    evt = (string)chartEqpEventTop5.Series["Equipment Event"].Points[ret.PointIndex].Tag;
                    // --
                    attachEquipmentIssueEventHistory(evt);
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

        #region grdEqpEventRanking Control Event Handler

        private void grdEqpEventRanking_MouseDoubleClick(
            object sender,
            MouseEventArgs e
            )
        {
            string evt = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdEqpEventRanking.ActiveRow == null || !FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentIssueEventHistory))
                {
                    return;
                }

                // --

                evt = grdEqpEventRanking.activeDataRowKey;
                if (evt != "*")
                {
                    attachEquipmentIssueEventHistory(evt);
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
