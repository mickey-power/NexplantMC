/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FChart.cs
--  Creator         : mjkim
--  Create Date     : 2013.05.23
--  Description     : FAMate Core FaUIs MS Chart
--  History         : Created by mjkim at 2013.05.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FChart : Chart
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FChart(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
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

        private void init(
            )
        {
            try
            {
                this.HandleCreated += new EventHandler(FChart_HandleCreated);
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(FChart_MouseDown);
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

        private void term(
            )
        {
            try
            {
                this.HandleCreated -= new EventHandler(FChart_HandleCreated);
                this.MouseDown -= new System.Windows.Forms.MouseEventHandler(FChart_MouseDown);
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

        public void addSeries(
            string name,
            SeriesChartType chartType
            )
        {
            Series s = null;

            try
            {
                s = this.Series.Add(name);
                // --
                FChartCommon.designSeries(s);
                // --
                s.ChartType = chartType;
                s.MarkerStyle = chartType == SeriesChartType.Column ? MarkerStyle.None : MarkerStyle.Square;
                s.XValueType = ChartValueType.Date;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                s = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void addSeries2(
            string name,
            SeriesChartType chartType
            )
        {
            try
            {
                addSeries(name, chartType);
                // --
                this.Series[name].YAxisType = AxisType.Secondary;
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

        #region FColumnChart Control Event Handler

        void FChart_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                foreach (ChartArea a in this.ChartAreas)
                {
                    FChartCommon.designChartArea(a);
                }

                // --

                foreach (Legend l in this.Legends)
                {
                    FChartCommon.designLegend(l);
                }

                // --

                foreach (Series s in this.Series)
                {
                    FChartCommon.designSeries(s);
                    // --
                    s.XValueType = ChartValueType.Date;
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

        void FChart_MouseDown(
            object sender, 
            System.Windows.Forms.MouseEventArgs e
            )
        {
            try
            {
                this.Focus();
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
}   // Namespace end
