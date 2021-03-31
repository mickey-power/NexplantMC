namespace Nexplant.MC.AdminManager
{
    partial class FEapTypeSelector
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.fButton2 = new Nexplant.MC.Core.FaUIs.FButton();
            this.fButton1 = new Nexplant.MC.Core.FaUIs.FButton();
            this.chkSecs = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkOpc = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkPrc = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkTcp = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkFile = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTcp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.chkFile);
            this.pnlDialogClient.Controls.Add(this.chkTcp);
            this.pnlDialogClient.Controls.Add(this.chkPrc);
            this.pnlDialogClient.Controls.Add(this.chkOpc);
            this.pnlDialogClient.Controls.Add(this.chkSecs);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(307, 161);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.fButton1);
            this.pnlClient.Controls.Add(this.fButton2);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(312, 214);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.fButton2, 0);
            this.pnlClient.Controls.SetChildIndex(this.fButton1, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(201, 252);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(98, 252);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // fButton2
            // 
            this.fButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fButton2.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.fButton2.Font = new System.Drawing.Font("Verdana", 9F);
            this.fButton2.Location = new System.Drawing.Point(122, 179);
            this.fButton2.Name = "fButton2";
            this.fButton2.Size = new System.Drawing.Size(86, 28);
            this.fButton2.TabIndex = 0;
            this.fButton2.Text = "OK(&O)";
            this.fButton2.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.fButton2.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // fButton1
            // 
            this.fButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fButton1.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.fButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.fButton1.Font = new System.Drawing.Font("Verdana", 9F);
            this.fButton1.Location = new System.Drawing.Point(214, 179);
            this.fButton1.Name = "fButton1";
            this.fButton1.Size = new System.Drawing.Size(86, 28);
            this.fButton1.TabIndex = 1;
            this.fButton1.Text = "Cancel(&C)";
            this.fButton1.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // chkSecs
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.chkSecs.Appearance = appearance5;
            this.chkSecs.BackColor = System.Drawing.Color.Transparent;
            this.chkSecs.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkSecs.Checked = true;
            this.chkSecs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSecs.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkSecs.Location = new System.Drawing.Point(18, 12);
            this.chkSecs.Name = "chkSecs";
            this.chkSecs.Size = new System.Drawing.Size(286, 20);
            this.chkSecs.TabIndex = 0;
            this.chkSecs.Text = "SECS (MC Wizard for SECS)";
            this.chkSecs.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.chkSecs.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkOpc
            // 
            appearance4.BackColor = System.Drawing.Color.Transparent;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.chkOpc.Appearance = appearance4;
            this.chkOpc.BackColor = System.Drawing.Color.Transparent;
            this.chkOpc.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkOpc.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkOpc.Location = new System.Drawing.Point(18, 40);
            this.chkOpc.Name = "chkOpc";
            this.chkOpc.Size = new System.Drawing.Size(286, 20);
            this.chkOpc.TabIndex = 2;
            this.chkOpc.Text = "OPC (MC Wizard for OPC)";
            this.chkOpc.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.chkOpc.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkPrc
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.chkPrc.Appearance = appearance3;
            this.chkPrc.BackColor = System.Drawing.Color.Transparent;
            this.chkPrc.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkPrc.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkPrc.Location = new System.Drawing.Point(18, 124);
            this.chkPrc.Name = "chkPrc";
            this.chkPrc.Size = new System.Drawing.Size(281, 20);
            this.chkPrc.TabIndex = 4;
            this.chkPrc.Text = "Process (MC Wizard for Process)";
            this.chkPrc.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.chkPrc.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkTcp
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.chkTcp.Appearance = appearance2;
            this.chkTcp.BackColor = System.Drawing.Color.Transparent;
            this.chkTcp.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkTcp.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkTcp.Location = new System.Drawing.Point(18, 68);
            this.chkTcp.Name = "chkTcp";
            this.chkTcp.Size = new System.Drawing.Size(287, 20);
            this.chkTcp.TabIndex = 3;
            this.chkTcp.Text = "TCP (MC Wizard for TCP)";
            this.chkTcp.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.chkTcp.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // chkFile
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.chkFile.Appearance = appearance1;
            this.chkFile.BackColor = System.Drawing.Color.Transparent;
            this.chkFile.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkFile.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkFile.Location = new System.Drawing.Point(18, 96);
            this.chkFile.Name = "chkFile";
            this.chkFile.Size = new System.Drawing.Size(287, 20);
            this.chkFile.TabIndex = 5;
            this.chkFile.Text = "FILE (MC Wizard for FILE)";
            this.chkFile.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.chkFile.CheckedChanged += new System.EventHandler(this.chkCommon_CheckedChanged);
            // 
            // FEapTypeSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(312, 241);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FEapTypeSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EAP Type Selector";
            this.Load += new System.EventHandler(this.FCommentEditor_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTcp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton fButton2;
        private Core.FaUIs.FButton fButton1;
        private Core.FaUIs.FCheckedBox chkSecs;
        private Core.FaUIs.FCheckedBox chkOpc;
        private Core.FaUIs.FCheckedBox chkPrc;
        private Core.FaUIs.FCheckedBox chkTcp;
        private Core.FaUIs.FCheckedBox chkFile;
    }
}