namespace Nexplant.MC.AdminManager
{
    partial class FTransactionCertification
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
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlPassword = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtPassword = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.ftlPassword = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.chkOption = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.pnlContent = new Nexplant.MC.Core.FaUIs.FPanel();
            this.pnlComment = new Nexplant.MC.Core.FaUIs.FPanel();
            this.lblComment = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtComment = new Nexplant.MC.Core.FaUIs.FEditTextBox();
            this.pnlItemCode = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtRevision = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtItemCode = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.fTitleLabel1 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlPassword.ClientArea.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOption)).BeginInit();
            this.pnlContent.ClientArea.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlComment.ClientArea.SuspendLayout();
            this.pnlComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.pnlItemCode.ClientArea.SuspendLayout();
            this.pnlItemCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.pnlContent);
            this.pnlDialogClient.Controls.Add(this.pnlPassword);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(440, 261);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.chkOption);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(445, 314);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.chkOption, 0);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(255, 279);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(347, 279);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // pnlPassword
            // 
            this.pnlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlPassword.Appearance = appearance9;
            this.pnlPassword.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlPassword.ClientArea
            // 
            this.pnlPassword.ClientArea.Controls.Add(this.txtPassword);
            this.pnlPassword.ClientArea.Controls.Add(this.ftlPassword);
            this.pnlPassword.Location = new System.Drawing.Point(2, 2);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(435, 29);
            this.pnlPassword.TabIndex = 27;
            // 
            // txtPassword
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Appearance = appearance10;
            this.txtPassword.AutoSize = false;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPassword.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtPassword.Location = new System.Drawing.Point(124, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(308, 23);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.txtPassword.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtPassword.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlPassword
            // 
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.ftlPassword.Appearance = appearance11;
            this.ftlPassword.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlPassword.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlPassword.Location = new System.Drawing.Point(2, 2);
            this.ftlPassword.Name = "ftlPassword";
            this.ftlPassword.Size = new System.Drawing.Size(120, 23);
            this.ftlPassword.TabIndex = 14;
            this.ftlPassword.Text = "Password";
            this.ftlPassword.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkOption
            // 
            this.chkOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance12.BackColor = System.Drawing.Color.Transparent;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.DimGray;
            this.chkOption.Appearance = appearance12;
            this.chkOption.BackColor = System.Drawing.Color.Transparent;
            this.chkOption.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkOption.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkOption.Location = new System.Drawing.Point(4, 283);
            this.chkOption.Name = "chkOption";
            this.chkOption.Size = new System.Drawing.Size(123, 19);
            this.chkOption.TabIndex = 36;
            this.chkOption.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.Transparent;
            this.pnlContent.Appearance = appearance1;
            this.pnlContent.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlContent.ClientArea
            // 
            this.pnlContent.ClientArea.Controls.Add(this.pnlComment);
            this.pnlContent.ClientArea.Controls.Add(this.pnlItemCode);
            this.pnlContent.Location = new System.Drawing.Point(1, 32);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(437, 229);
            this.pnlContent.TabIndex = 30;
            // 
            // pnlComment
            // 
            this.pnlComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlComment.Appearance = appearance2;
            this.pnlComment.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlComment.ClientArea
            // 
            this.pnlComment.ClientArea.Controls.Add(this.lblComment);
            this.pnlComment.ClientArea.Controls.Add(this.txtComment);
            this.pnlComment.Location = new System.Drawing.Point(0, 31);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(435, 195);
            this.pnlComment.TabIndex = 32;
            // 
            // lblComment
            // 
            this.lblComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance3.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance3.BackColor2 = System.Drawing.Color.Lavender;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblComment.Appearance = appearance3;
            this.lblComment.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblComment.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblComment.Location = new System.Drawing.Point(2, 2);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(120, 189);
            this.lblComment.TabIndex = 30;
            this.lblComment.Text = "Comment";
            this.lblComment.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtComment
            // 
            this.txtComment.AlwaysInEditMode = true;
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtComment.Appearance = appearance4;
            this.txtComment.AutoSize = false;
            this.txtComment.BackColor = System.Drawing.Color.White;
            this.txtComment.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtComment.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtComment.HideSelection = false;
            this.txtComment.Location = new System.Drawing.Point(124, 2);
            this.txtComment.MaxLength = 2147483647;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(307, 189);
            this.txtComment.TabIndex = 29;
            this.txtComment.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtComment.WordWrap = false;
            // 
            // pnlItemCode
            // 
            appearance5.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlItemCode.Appearance = appearance5;
            this.pnlItemCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlItemCode.ClientArea
            // 
            this.pnlItemCode.ClientArea.Controls.Add(this.txtRevision);
            this.pnlItemCode.ClientArea.Controls.Add(this.txtItemCode);
            this.pnlItemCode.ClientArea.Controls.Add(this.fTitleLabel1);
            this.pnlItemCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlItemCode.Location = new System.Drawing.Point(0, 0);
            this.pnlItemCode.Name = "pnlItemCode";
            this.pnlItemCode.Size = new System.Drawing.Size(435, 29);
            this.pnlItemCode.TabIndex = 31;
            // 
            // txtRevision
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.txtRevision.Appearance = appearance6;
            this.txtRevision.AutoSize = false;
            this.txtRevision.BackColor = System.Drawing.Color.White;
            this.txtRevision.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtRevision.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtRevision.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtRevision.Location = new System.Drawing.Point(347, 2);
            this.txtRevision.Name = "txtRevision";
            this.txtRevision.Size = new System.Drawing.Size(85, 23);
            this.txtRevision.TabIndex = 32;
            this.txtRevision.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.txtRevision.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtRevision.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtItemCode
            // 
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.txtItemCode.Appearance = appearance7;
            this.txtItemCode.AutoSize = false;
            this.txtItemCode.BackColor = System.Drawing.Color.White;
            this.txtItemCode.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtItemCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtItemCode.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtItemCode.Location = new System.Drawing.Point(124, 2);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(221, 23);
            this.txtItemCode.TabIndex = 31;
            this.txtItemCode.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.txtItemCode.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtItemCode.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fTitleLabel1
            // 
            this.fTitleLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            appearance8.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance8.BackColor2 = System.Drawing.Color.Lavender;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.fTitleLabel1.Appearance = appearance8;
            this.fTitleLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel1.Location = new System.Drawing.Point(2, 2);
            this.fTitleLabel1.Name = "fTitleLabel1";
            this.fTitleLabel1.Size = new System.Drawing.Size(120, 23);
            this.fTitleLabel1.TabIndex = 30;
            this.fTitleLabel1.Text = "Item Code";
            this.fTitleLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FTransactionCertification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(445, 341);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTransactionCertification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transaction Certification";
            this.Load += new System.EventHandler(this.FTransactionCertification_Load);
            this.Shown += new System.EventHandler(this.FTransactionCertification_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.pnlPassword.ClientArea.ResumeLayout(false);
            this.pnlPassword.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOption)).EndInit();
            this.pnlContent.ClientArea.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlComment.ClientArea.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.pnlItemCode.ClientArea.ResumeLayout(false);
            this.pnlItemCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRevision)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FPanel pnlPassword;
        private Core.FaUIs.FTitleLabel ftlPassword;
        private Core.FaUIs.FTextBox txtPassword;
        private Core.FaUIs.FCheckedBox chkOption;
        private Core.FaUIs.FPanel pnlContent;
        private Core.FaUIs.FPanel pnlComment;
        private Core.FaUIs.FTitleLabel lblComment;
        private Core.FaUIs.FEditTextBox txtComment;
        private Core.FaUIs.FPanel pnlItemCode;
        private Core.FaUIs.FTitleLabel fTitleLabel1;
        private Core.FaUIs.FTextBox txtItemCode;
        private Core.FaUIs.FTextBox txtRevision;
    }
}