namespace Nexplant.MC.OpcModeler
{
    partial class FReplaceNameDialog
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.fPanel1 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.ftlFindWhat = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtFindWhat = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.ftlReplaceWith = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtReplaceWith = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.fPanel1.ClientArea.SuspendLayout();
            this.fPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFindWhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplaceWith)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.fPanel1);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(400, 54);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(404, 107);
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
            this.btnCancel.Location = new System.Drawing.Point(306, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(214, 72);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // fPanel1
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.fPanel1.Appearance = appearance1;
            this.fPanel1.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // fPanel1.ClientArea
            // 
            this.fPanel1.ClientArea.Controls.Add(this.ftlFindWhat);
            this.fPanel1.ClientArea.Controls.Add(this.txtFindWhat);
            this.fPanel1.ClientArea.Controls.Add(this.ftlReplaceWith);
            this.fPanel1.ClientArea.Controls.Add(this.txtReplaceWith);
            this.fPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fPanel1.Location = new System.Drawing.Point(0, 0);
            this.fPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.fPanel1.Name = "fPanel1";
            this.fPanel1.Size = new System.Drawing.Size(400, 54);
            this.fPanel1.TabIndex = 13;
            // 
            // ftlFindWhat
            // 
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BackColor2 = System.Drawing.Color.Lavender;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ftlFindWhat.Appearance = appearance2;
            this.ftlFindWhat.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlFindWhat.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlFindWhat.Location = new System.Drawing.Point(3, 2);
            this.ftlFindWhat.Name = "ftlFindWhat";
            this.ftlFindWhat.Size = new System.Drawing.Size(125, 23);
            this.ftlFindWhat.TabIndex = 10;
            this.ftlFindWhat.Text = "Find What";
            this.ftlFindWhat.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtFindWhat
            // 
            this.txtFindWhat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtFindWhat.Appearance = appearance3;
            this.txtFindWhat.AutoSize = false;
            this.txtFindWhat.BackColor = System.Drawing.Color.White;
            this.txtFindWhat.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFindWhat.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtFindWhat.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtFindWhat.Location = new System.Drawing.Point(131, 2);
            this.txtFindWhat.Name = "txtFindWhat";
            this.txtFindWhat.Size = new System.Drawing.Size(264, 23);
            this.txtFindWhat.TabIndex = 0;
            this.txtFindWhat.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFindWhat.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlReplaceWith
            // 
            appearance4.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance4.BackColor2 = System.Drawing.Color.Lavender;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ftlReplaceWith.Appearance = appearance4;
            this.ftlReplaceWith.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlReplaceWith.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlReplaceWith.Location = new System.Drawing.Point(3, 27);
            this.ftlReplaceWith.Name = "ftlReplaceWith";
            this.ftlReplaceWith.Size = new System.Drawing.Size(125, 23);
            this.ftlReplaceWith.TabIndex = 8;
            this.ftlReplaceWith.Text = "Replace With";
            this.ftlReplaceWith.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtReplaceWith
            // 
            this.txtReplaceWith.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtReplaceWith.Appearance = appearance5;
            this.txtReplaceWith.AutoSize = false;
            this.txtReplaceWith.BackColor = System.Drawing.Color.White;
            this.txtReplaceWith.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtReplaceWith.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtReplaceWith.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtReplaceWith.Location = new System.Drawing.Point(131, 27);
            this.txtReplaceWith.Name = "txtReplaceWith";
            this.txtReplaceWith.Size = new System.Drawing.Size(264, 23);
            this.txtReplaceWith.TabIndex = 1;
            this.txtReplaceWith.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtReplaceWith.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FReplaceNameDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 134);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FReplaceNameDialog";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.Load += new System.EventHandler(this.FPasswordChange_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.fPanel1.ClientArea.ResumeLayout(false);
            this.fPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFindWhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplaceWith)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FPanel fPanel1;
        private Core.FaUIs.FTitleLabel ftlFindWhat;
        private Core.FaUIs.FTextBox txtFindWhat;
        private Core.FaUIs.FTitleLabel ftlReplaceWith;
        private Core.FaUIs.FTextBox txtReplaceWith;
    }
}