/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FChartCommon.cs
--  Creator         : mjkim
--  Create Date     : 2013.02.18
--  Description     : FAMate Core FaUIs Chart Common Function Class
--  History         : Created by mjkim at 2013.02.18
                    : Modified by byjeon at 2013.11.13
                        - Added three "addLine" methods
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public static class FChartCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FChartCommon(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void designChartArea(
            ChartArea chartArea
            )
        {
            try
            {
                chartArea.BackColor = Color.Gainsboro;
                chartArea.BackGradientStyle = GradientStyle.TopBottom;
                chartArea.IsSameFontSizeForAllAxes = true;
                // --
                chartArea.AxisX.LabelStyle.Font = new Font("Tahoma", 8.25F);
                chartArea.AxisX.MajorGrid.Enabled = true;
                chartArea.AxisX.MajorGrid.LineColor = Color.Silver;
                chartArea.AxisX.ScrollBar.IsPositionedInside = false;
                // --
                chartArea.AxisY.LabelStyle.Font = new Font("Tahoma", 8.25F);
                chartArea.AxisY.MajorGrid.Enabled = true;
                chartArea.AxisY.MajorGrid.LineColor = Color.Silver;
                chartArea.AxisY.Minimum = 0; 
                chartArea.AxisY.TitleFont = new Font("Tahoma", 8.25F);
                chartArea.AxisY.TitleForeColor = Color.DimGray;
                // --
                chartArea.AxisY2.LabelStyle.Font = new Font("Tahoma", 8.25F);
                chartArea.AxisY2.MajorGrid.Enabled = false;
                chartArea.AxisY2.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.None;
                chartArea.AxisY2.ScaleBreakStyle.Spacing = 0;
                chartArea.AxisY2.TitleFont = new Font("Tahoma", 8.25F);
                chartArea.AxisY2.TitleForeColor = Color.DimGray;
                // --
                chartArea.CursorX.Interval = 1;
                chartArea.CursorX.IsUserEnabled = true;
                chartArea.CursorX.IsUserSelectionEnabled = true;
                chartArea.CursorX.LineColor = Color.Gray;
                chartArea.CursorX.LineDashStyle = ChartDashStyle.Dash;
                // --
                chartArea.CursorY.IsUserEnabled = true;
                chartArea.CursorY.LineColor = Color.Gray;
                chartArea.CursorY.LineDashStyle = ChartDashStyle.Dash;
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

        public static void designLegend(
            Legend legend
            )
        {
            try
            {
                legend.BackColor = Color.Transparent;
                legend.Font = new Font("Tahoma", 8.25F);
                legend.IsTextAutoFit = false;
                legend.Alignment = StringAlignment.Center;
                legend.Docking = Docking.Bottom;
                legend.TitleFont = new Font("Taoma", 8.25F);
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

        public static void designSeries(
            Series series
            )
        {
            try
            {
                //series.BackGradientStyle = GradientStyle.DiagonalLeft;
                series.BackSecondaryColor = Color.Transparent;
                series.BorderWidth = 2;
                series.MarkerSize = 7;
                series.Font = new Font("Tahoma", 8.25F);
                series.SmartLabelStyle.Enabled = true;
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

        public static void designChart(
            Chart chart
            )
        {
            try
            {
                chart.BackColor = Color.WhiteSmoke;
                chart.BackGradientStyle = GradientStyle.TopBottom;
                chart.BorderlineColor = Color.Silver;
                chart.BorderlineDashStyle = ChartDashStyle.Solid;
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

        public static void addLine(
            Chart chart,
            Color color,
            ChartDashStyle style,
            double yValue,
            string text
            )
        {
            try
            {
                addLine(chart, chart.ChartAreas[0], color, style, 2, yValue, text);
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

        public static void addLine(
            Chart chart,
            ChartArea chartArea,
            Color color,
            ChartDashStyle style,
            double yValue,
            string text
            )
        {
            try
            {
                addLine(chart, chartArea, color, style, 2, yValue, text);
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

        public static void addLine(
            Chart chart,
            Color color,
            ChartDashStyle style,
            int width,
            double yValue,
            string text
            )
        {
            try
            {
                addLine(chart, chart.ChartAreas[0], color, style, width, yValue, text);
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

        public static void addLine(
            Chart chart,
            ChartArea chartArea,
            Color color,
            ChartDashStyle style,
            int width,
            double yValue,
            string text
            )
        {
            HorizontalLineAnnotation hLineAnn = null;
            TextAnnotation textAnn = null;

            try
            {
                hLineAnn = new HorizontalLineAnnotation();
                // --
                hLineAnn.AxisY = chartArea.AxisY;
                hLineAnn.ClipToChartArea = chartArea.Name;
                hLineAnn.IsInfinitive = true;
                hLineAnn.LineColor = color;
                hLineAnn.ShadowOffset = 1;
                hLineAnn.ShadowColor = Color.DarkGray;
                hLineAnn.LineDashStyle = style;
                hLineAnn.LineWidth = width;
                hLineAnn.Y = yValue;
                // --
                chart.Annotations.Add(hLineAnn);

                // --

                textAnn = new TextAnnotation();
                // --
                textAnn.SmartLabelStyle.Enabled = true;
                textAnn.SmartLabelStyle.IsOverlappedHidden = true;
                textAnn.AxisY = chartArea.AxisY;
                textAnn.ClipToChartArea = chartArea.Name;
                textAnn.Font = new Font("Tahoma", 8.25F);
                textAnn.ForeColor = Color.DimGray;
                textAnn.Text = text;
                textAnn.X = chartArea.Position.Width - 7;
                textAnn.Y = yValue;
                // --
                chart.Annotations.Add(textAnn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                hLineAnn = null;
                textAnn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void addLine(
            Chart chart,
            ChartArea chartArea,
            Color color,
            ChartDashStyle style,
            double yValue,
            string text,
            Color shadowColor
            )
        {
            try
            {
                addLine(chart, chartArea, color, style, 2, yValue, text, 1, shadowColor);
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

        public static void addLine(
            Chart chart,
            ChartArea chartArea,
            Color color,
            ChartDashStyle style,
            int width,
            double yValue,
            string text,
            int shadowOffset,
            Color shadowColor
            )
        {
            HorizontalLineAnnotation hLineAnn = null;
            TextAnnotation textAnn = null;

            try
            {
                hLineAnn = new HorizontalLineAnnotation();
                // --
                hLineAnn.AxisY = chartArea.AxisY;
                hLineAnn.ClipToChartArea = chartArea.Name;
                hLineAnn.IsInfinitive = true;
                hLineAnn.LineColor = color;
                hLineAnn.ShadowOffset = shadowOffset;
                hLineAnn.ShadowColor = shadowColor;
                hLineAnn.LineDashStyle = style;
                hLineAnn.LineWidth = width;
                hLineAnn.Y = yValue;
                // --
                chart.Annotations.Add(hLineAnn);

                // --

                textAnn = new TextAnnotation();
                // --
                textAnn.SmartLabelStyle.Enabled = true;
                textAnn.SmartLabelStyle.IsOverlappedHidden = true;
                textAnn.AxisY = chartArea.AxisY;
                textAnn.ClipToChartArea = chartArea.Name;
                textAnn.Font = new Font("Tahoma", 8.25F);
                textAnn.ForeColor = Color.DimGray;
                textAnn.Text = text;
                textAnn.X = 91;
                textAnn.Y = yValue;
                // --
                chart.Annotations.Add(textAnn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                hLineAnn = null;
                textAnn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void addBreakLine(
            Axis axis,
            Color color
            )
        {
            try
            {
                axis.ScaleBreakStyle.Enabled = true;
                axis.ScaleBreakStyle.CollapsibleSpaceThreshold = 30;
                axis.ScaleBreakStyle.BreakLineStyle = BreakLineStyle.Wave;
                axis.ScaleBreakStyle.LineWidth = 1;
                axis.ScaleBreakStyle.Spacing = 3;
                axis.ScaleBreakStyle.LineColor = color;
                axis.ScaleBreakStyle.LineDashStyle = ChartDashStyle.Solid;              
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
