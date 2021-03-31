namespace Miracom.FAMate.SecsLogViewer
{
    partial class FSecsBinaryLogView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSecsBinaryLogView));
            ((System.ComponentModel.ISupportInitialize)(this.tpnClient)).BeginInit();
            this.tpnClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpnClient
            // 
            this.tpnClient.Size = new System.Drawing.Size(1118, 627);
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.tpnClient.TileSettings.Appearance = appearance1;
            this.tpnClient.TileSettings.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BackColor2 = System.Drawing.Color.Lavender;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tpnClient.TileSettings.HeaderAppearance = appearance2;
            this.tpnClient.TileSettings.ShowCloseButton = Infragistics.Win.DefaultableBoolean.True;
            this.tpnClient.TileSettings.ShowStateChangeButton = Infragistics.Win.DefaultableBoolean.True;
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(1126, 635);
            // 
            // FSecsBinaryLogView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1126, 662);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FSecsBinaryLogView";
            this.Text = "SECS Binary Log View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSecsBinaryView_FormClosing);
            this.Enter += new System.EventHandler(this.FSecsBinaryView_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.tpnClient)).EndInit();
            this.tpnClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}