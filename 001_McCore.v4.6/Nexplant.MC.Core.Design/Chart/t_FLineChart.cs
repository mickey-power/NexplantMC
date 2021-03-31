/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FLineChart.cs
--  Creator         : mjkim
--  Create Date     : 2013.02.18
--  Description     : FAMate Core FaUIs MS Chart - Line Type Control
--  History         : Created by mjkim at 2013.02.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FLineChart : Chart
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLineChart(
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
                this.HandleCreated += new EventHandler(FLineChart_HandleCreated);
                this.MouseDown += new System.Windows.Forms.MouseEventHandler(FLineChart_MouseDown);
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
                this.HandleCreated -= new EventHandler(FLineChart_HandleCreated);
                this.MouseDown -= new System.Windows.Forms.MouseEventHandler(FLineChart_MouseDown);
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
            string name
            )
        {
            Series s = null;

            try
            {
                s = this.Series.Add(name);

                // --

                FChartCommon.designSeries(s);
                // --
                s.ChartType = SeriesChartType.Line;
                s.EmptyPointStyle.Color = s.Color;
                s.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dot;
                s.EmptyPointStyle.BorderWidth = 2;
                s.MarkerStyle = MarkerStyle.None;
                s.ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY %";
                s.XValueType = ChartValueType.DateTime;
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
            string name
            )
        {
            try
            {
                addSeries(name);
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

        #region FLineChart Control Event Handler

        void FLineChart_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                foreach (ChartArea a in this.ChartAreas)
                {
                    FChartCommon.designChartArea(a);
                    // --
                    a.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
                    a.AxisX.ScaleView.SmallScrollMinSizeType = DateTimeIntervalType.Minutes;
                    // --
                    a.CursorX.IntervalType = DateTimeIntervalType.Minutes;
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
                    s.ChartType = SeriesChartType.Line;
                    s.EmptyPointStyle.Color = s.Color;
                    s.EmptyPointStyle.BorderDashStyle = ChartDashStyle.Dash;
                    s.EmptyPointStyle.BorderWidth = 2;
                    s.MarkerStyle = MarkerStyle.None;
                    s.ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY %";
                    s.XValueType = ChartValueType.DateTime;
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

        void FLineChart_MouseDown(
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
