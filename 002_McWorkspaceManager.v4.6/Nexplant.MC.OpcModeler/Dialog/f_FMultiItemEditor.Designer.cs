namespace Nexplant.MC.OpcModeler
{
    partial class FMultiItemEditor
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
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.lblApply = new Infragistics.Win.Misc.UltraLabel();
            this.lblTo = new Infragistics.Win.Misc.UltraLabel();
            this.txtFrom = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtTo = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.chkAll = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialogClient.Controls.Add(this.pgdProp);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(452, 262);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.chkAll);
            this.pnlClient.Controls.Add(this.txtTo);
            this.pnlClient.Controls.Add(this.txtFrom);
            this.pnlClient.Controls.Add(this.lblTo);
            this.pnlClient.Controls.Add(this.lblApply);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(456, 315);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblApply, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblTo, 0);
            this.pnlClient.Controls.SetChildIndex(this.txtFrom, 0);
            this.pnlClient.Controls.SetChildIndex(this.txtTo, 0);
            this.pnlClient.Controls.SetChildIndex(this.chkAll, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(356, 280);
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
            this.btnOk.Location = new System.Drawing.Point(264, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pgdProp
            // 
            this.pgdProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdProp.HelpVisible = false;
            this.pgdProp.LineColor = System.Drawing.Color.Silver;
            this.pgdProp.Location = new System.Drawing.Point(0, 0);
            this.pgdProp.Name = "pgdProp";
            this.pgdProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdProp.selectedObject = null;
            this.pgdProp.Size = new System.Drawing.Size(450, 260);
            this.pgdProp.TabIndex = 1;
            this.pgdProp.ToolbarVisible = false;
            this.pgdProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // lblApply
            // 
            this.lblApply.Location = new System.Drawing.Point(9, 283);
            this.lblApply.Name = "lblApply";
            this.lblApply.Size = new System.Drawing.Size(45, 23);
            this.lblApply.TabIndex = 5;
            this.lblApply.Text = "Apply";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(170, 283);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 23);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To";
            // 
            // txtFrom
            // 
            this.txtFrom.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.txtFrom.Enabled = false;
            this.txtFrom.Location = new System.Drawing.Point(109, 281);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(54, 24);
            this.txtFrom.TabIndex = 7;
            // 
            // txtTo
            // 
            this.txtTo.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(202, 281);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(54, 24);
            this.txtTo.TabIndex = 8;
            // 
            // chkAll
            // 
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(53, 283);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(51, 20);
            this.chkAll.TabIndex = 9;
            this.chkAll.Text = "All";
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // FMultiItemEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 342);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FMultiItemEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Multi Item Editor";
            this.Load += new System.EventHandler(this.FMultiItemEditor_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkAll;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtTo;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtFrom;
        private Infragistics.Win.Misc.UltraLabel lblTo;
        private Infragistics.Win.Misc.UltraLabel lblApply;
    }
}