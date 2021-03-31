namespace Nexplant.MC.TcpModeler
{
    partial class FValueEditor
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
            this.rtxValue = new Nexplant.MC.Core.FaUIs.FRichTextBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDialogClient.Controls.Add(this.rtxValue);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(520, 262);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
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
            this.btnCancel.Location = new System.Drawing.Point(424, 280);
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
            this.btnOk.Location = new System.Drawing.Point(332, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rtxValue
            // 
            this.rtxValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxValue.DetectUrls = false;
            this.rtxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxValue.Location = new System.Drawing.Point(0, 0);
            this.rtxValue.Name = "rtxValue";
            this.rtxValue.Size = new System.Drawing.Size(518, 260);
            this.rtxValue.TabIndex = 0;
            this.rtxValue.Text = "";
            // 
            // FValueEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FValueEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Value Editor";
            this.Shown += new System.EventHandler(this.FValueEditor_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FRichTextBox rtxValue;
    }
}