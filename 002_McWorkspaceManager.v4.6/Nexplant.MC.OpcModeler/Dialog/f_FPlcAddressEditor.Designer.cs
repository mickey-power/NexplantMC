namespace Nexplant.MC.OpcModeler
{
    partial class FPlcAddressEditor
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.txtNew = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtOld = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDataBlock = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.txtDataBlock = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.lblDataType = new Infragistics.Win.Misc.UltraLabel();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBlock)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialogClient.Controls.Add(this.lblDataType);
            this.pnlDialogClient.Controls.Add(this.txtDataBlock);
            this.pnlDialogClient.Controls.Add(this.ultraLabel1);
            this.pnlDialogClient.Controls.Add(this.lblDataBlock);
            this.pnlDialogClient.Controls.Add(this.txtOld);
            this.pnlDialogClient.Controls.Add(this.txtNew);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(365, 34);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(369, 87);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(269, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(177, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNew
            // 
            this.txtNew.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.txtNew.Location = new System.Drawing.Point(280, 4);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(74, 24);
            this.txtNew.TabIndex = 9;
            // 
            // txtOld
            // 
            this.txtOld.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.txtOld.Enabled = false;
            this.txtOld.Location = new System.Drawing.Point(181, 4);
            this.txtOld.Name = "txtOld";
            this.txtOld.Size = new System.Drawing.Size(74, 24);
            this.txtOld.TabIndex = 10;
            // 
            // lblDataBlock
            // 
            this.lblDataBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblDataBlock.Appearance = appearance3;
            this.lblDataBlock.Location = new System.Drawing.Point(4, 4);
            this.lblDataBlock.Name = "lblDataBlock";
            this.lblDataBlock.Size = new System.Drawing.Size(36, 23);
            this.lblDataBlock.TabIndex = 11;
            this.lblDataBlock.Text = "DB";
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance2.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.Plc_Address_New;
            this.ultraLabel1.Appearance = appearance2;
            this.ultraLabel1.Location = new System.Drawing.Point(259, 4);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(17, 23);
            this.ultraLabel1.TabIndex = 12;
            // 
            // txtDataBlock
            // 
            this.txtDataBlock.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.txtDataBlock.Location = new System.Drawing.Point(46, 4);
            this.txtDataBlock.Name = "txtDataBlock";
            this.txtDataBlock.Size = new System.Drawing.Size(74, 24);
            this.txtDataBlock.TabIndex = 13;
            // 
            // lblDataType
            // 
            this.lblDataType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.lblDataType.Appearance = appearance1;
            this.lblDataType.Location = new System.Drawing.Point(119, 4);
            this.lblDataType.Name = "lblDataType";
            this.lblDataType.Size = new System.Drawing.Size(60, 23);
            this.lblDataType.TabIndex = 14;
            // 
            // FPlcAddressEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(369, 114);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPlcAddressEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Plc Address Editor";
            this.Load += new System.EventHandler(this.FPlcAddressEditor_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlDialogClient.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataBlock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Infragistics.Win.Misc.UltraLabel lblDataBlock;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtOld;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtNew;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.Misc.UltraLabel lblDataType;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtDataBlock;
    }
}