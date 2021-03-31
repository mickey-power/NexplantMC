namespace Nexplant.MC.AdminManager
{
    partial class FServerResourceHistoryViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartResource = new Nexplant.MC.Core.FaUIs.FLineChart();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartResource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.chartResource);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(809, 317);
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(813, 370);
            // 
            // chartResource
            // 
            this.chartResource.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartResource.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartResource.BorderlineColor = System.Drawing.Color.Silver;
            this.chartResource.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisX.LabelStyle.Format = "yyyy-MM-dd HH:mm:ss";
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.ScaleView.SmallScrollMinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea1.AxisY2.ScaleBreakStyle.Spacing = 0D;
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Gray;
            chartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Gray;
            chartArea1.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 82F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.X = 1F;
            chartArea1.Position.Y = 1F;
            this.chartResource.ChartAreas.Add(chartArea1);
            this.chartResource.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chartResource.Legends.Add(legend1);
            this.chartResource.Location = new System.Drawing.Point(0, 0);
            this.chartResource.Name = "chartResource";
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.DiagonalLeft;
            series1.BackSecondaryColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.EmptyPointStyle.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series1.EmptyPointStyle.BorderWidth = 2;
            series1.EmptyPointStyle.Color = System.Drawing.Color.DodgerBlue;
            series1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            series1.Legend = "Legend1";
            series1.MarkerSize = 7;
            series1.Name = "Series1";
            series1.ToolTip = "[#VALX{yyyy-MM-dd HH:mm:ss.fff}] #VALY %";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartResource.Series.Add(series1);
            this.chartResource.Size = new System.Drawing.Size(809, 317);
            this.chartResource.TabIndex = 3;
            this.chartResource.Text = "fLineChart1";
            // 
            // FServerResourceHistoryViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(813, 397);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FServerResourceHistoryViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Resource History Viewer";
            this.Load += new System.EventHandler(this.FServerResourceHistoryViewer_Load);
            this.Shown += new System.EventHandler(this.FServerResourceHistoryViewer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FServerResourceHistoryViewer_KeyDown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartResource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FLineChart chartResource;




    }
}