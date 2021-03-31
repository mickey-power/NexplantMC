namespace Nexplant.MC.AdminManager
{
    partial class FInquiryProgress
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

            // ***
            // myDispose
            // ***
            myDispose(disposing);

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.pnlMain = new Infragistics.Win.Misc.UltraPanel();
            this.lblCollectCount = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblPercentage = new Nexplant.MC.Core.FaUIs.FLabel();
            this.btnStop = new Nexplant.MC.Core.FaUIs.FButton();
            this.Pgb = new Infragistics.Win.UltraWinProgressBar.UltraProgressBar();
            this.lblRemaining = new Nexplant.MC.Core.FaUIs.FLabel();
            this.pnlMain.ClientArea.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.White;
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.BackwardDiagonal;
            appearance1.BorderColor = System.Drawing.Color.Gainsboro;
            appearance1.BorderColor2 = System.Drawing.Color.Gray;
            this.pnlMain.Appearance = appearance1;
            this.pnlMain.BorderStyle = Infragistics.Win.UIElementBorderStyle.TwoColor;
            // 
            // pnlMain.ClientArea
            // 
            this.pnlMain.ClientArea.Controls.Add(this.lblCollectCount);
            this.pnlMain.ClientArea.Controls.Add(this.lblPercentage);
            this.pnlMain.ClientArea.Controls.Add(this.btnStop);
            this.pnlMain.ClientArea.Controls.Add(this.Pgb);
            this.pnlMain.ClientArea.Controls.Add(this.lblRemaining);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(412, 94);
            this.pnlMain.TabIndex = 16;
            // 
            // lblCollectCount
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            appearance2.TextHAlignAsString = "Right";
            appearance2.TextVAlignAsString = "Bottom";
            this.lblCollectCount.Appearance = appearance2;
            this.lblCollectCount.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblCollectCount.Location = new System.Drawing.Point(192, 13);
            this.lblCollectCount.Name = "lblCollectCount";
            this.lblCollectCount.Size = new System.Drawing.Size(209, 19);
            this.lblCollectCount.TabIndex = 22;
            this.lblCollectCount.Text = "Collected Data : 0";
            this.lblCollectCount.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblPercentage
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.lblPercentage.Appearance = appearance3;
            this.lblPercentage.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblPercentage.Location = new System.Drawing.Point(4, 54);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(46, 19);
            this.lblPercentage.TabIndex = 21;
            this.lblPercentage.Text = "0 %";
            this.lblPercentage.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnStop.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnStop.Location = new System.Drawing.Point(315, 54);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(86, 28);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop(&S)";
            this.btnStop.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Pgb
            // 
            appearance4.BackColor = System.Drawing.Color.LightGray;
            this.Pgb.Appearance = appearance4;
            this.Pgb.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance5.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.Pgb.FillAppearance = appearance5;
            this.Pgb.Location = new System.Drawing.Point(4, 38);
            this.Pgb.Name = "Pgb";
            this.Pgb.Size = new System.Drawing.Size(397, 10);
            this.Pgb.TabIndex = 19;
            this.Pgb.Text = "[Formatted]";
            this.Pgb.TextVisible = false;
            // 
            // lblRemaining
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Bottom";
            this.lblRemaining.Appearance = appearance6;
            this.lblRemaining.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblRemaining.Location = new System.Drawing.Point(4, 13);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(209, 19);
            this.lblRemaining.TabIndex = 16;
            this.lblRemaining.Text = "Calculating...";
            this.lblRemaining.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FInquiryProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 94);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FInquiryProgress";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FTransactionProgress";
            this.Load += new System.EventHandler(this.FInquiryProgress_Load);
            this.Shown += new System.EventHandler(this.FInquiryProgress_Shown);
            this.pnlMain.ClientArea.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlMain;
        private Core.FaUIs.FLabel lblRemaining;
        private Infragistics.Win.UltraWinProgressBar.UltraProgressBar Pgb;
        private Core.FaUIs.FButton btnStop;
        private Core.FaUIs.FLabel lblPercentage;
        private Core.FaUIs.FLabel lblCollectCount;
    }
}