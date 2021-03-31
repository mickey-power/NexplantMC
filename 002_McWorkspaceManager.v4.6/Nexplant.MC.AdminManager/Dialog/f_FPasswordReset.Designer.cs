namespace Nexplant.MC.AdminManager
{
    partial class FPasswordReset
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.fPanel1 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.lblPass = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtPass = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.ftlFactory = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtFactory = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.ftlUserId = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.ftlUserGroup = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtUser = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtUserGroup = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.fPanel1.ClientArea.SuspendLayout();
            this.fPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.fPanel1);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(400, 118);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(404, 171);
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
            this.btnCancel.Location = new System.Drawing.Point(306, 136);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(214, 136);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 4;
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
            this.fPanel1.ClientArea.Controls.Add(this.lblPass);
            this.fPanel1.ClientArea.Controls.Add(this.txtPass);
            this.fPanel1.ClientArea.Controls.Add(this.ftlFactory);
            this.fPanel1.ClientArea.Controls.Add(this.txtFactory);
            this.fPanel1.ClientArea.Controls.Add(this.ftlUserId);
            this.fPanel1.ClientArea.Controls.Add(this.ftlUserGroup);
            this.fPanel1.ClientArea.Controls.Add(this.txtUser);
            this.fPanel1.ClientArea.Controls.Add(this.txtUserGroup);
            this.fPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fPanel1.Location = new System.Drawing.Point(0, 0);
            this.fPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.fPanel1.Name = "fPanel1";
            this.fPanel1.Size = new System.Drawing.Size(400, 118);
            this.fPanel1.TabIndex = 13;
            // 
            // lblPass
            // 
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BackColor2 = System.Drawing.Color.Lavender;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.lblPass.Appearance = appearance2;
            this.lblPass.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblPass.Location = new System.Drawing.Point(3, 85);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(167, 23);
            this.lblPass.TabIndex = 16;
            this.lblPass.Text = "Current User Password";
            this.lblPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtPass
            // 
            this.txtPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Appearance = appearance3;
            this.txtPass.AutoSize = false;
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtPass.Location = new System.Drawing.Point(173, 85);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(222, 23);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlFactory
            // 
            appearance4.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance4.BackColor2 = System.Drawing.Color.Lavender;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ftlFactory.Appearance = appearance4;
            this.ftlFactory.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlFactory.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlFactory.Location = new System.Drawing.Point(3, 2);
            this.ftlFactory.Name = "ftlFactory";
            this.ftlFactory.Size = new System.Drawing.Size(125, 23);
            this.ftlFactory.TabIndex = 10;
            this.ftlFactory.Text = "Factory";
            this.ftlFactory.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtFactory
            // 
            this.txtFactory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtFactory.Appearance = appearance5;
            this.txtFactory.AutoSize = false;
            this.txtFactory.BackColor = System.Drawing.Color.White;
            this.txtFactory.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFactory.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtFactory.Enabled = false;
            this.txtFactory.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtFactory.Location = new System.Drawing.Point(131, 2);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.ReadOnly = true;
            this.txtFactory.Size = new System.Drawing.Size(264, 23);
            this.txtFactory.TabIndex = 9;
            this.txtFactory.TabStop = false;
            this.txtFactory.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFactory.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlUserId
            // 
            appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance6.BackColor2 = System.Drawing.Color.Lavender;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Left";
            appearance6.TextVAlignAsString = "Middle";
            this.ftlUserId.Appearance = appearance6;
            this.ftlUserId.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlUserId.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlUserId.Location = new System.Drawing.Point(3, 52);
            this.ftlUserId.Name = "ftlUserId";
            this.ftlUserId.Size = new System.Drawing.Size(125, 23);
            this.ftlUserId.TabIndex = 6;
            this.ftlUserId.Text = "User";
            this.ftlUserId.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlUserGroup
            // 
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BackColor2 = System.Drawing.Color.Lavender;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Left";
            appearance7.TextVAlignAsString = "Middle";
            this.ftlUserGroup.Appearance = appearance7;
            this.ftlUserGroup.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlUserGroup.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlUserGroup.Location = new System.Drawing.Point(3, 27);
            this.ftlUserGroup.Name = "ftlUserGroup";
            this.ftlUserGroup.Size = new System.Drawing.Size(125, 23);
            this.ftlUserGroup.TabIndex = 8;
            this.ftlUserGroup.Text = "User Group";
            this.ftlUserGroup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtUser
            // 
            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUser.Appearance = appearance8;
            this.txtUser.AutoSize = false;
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUser.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtUser.Enabled = false;
            this.txtUser.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtUser.Location = new System.Drawing.Point(131, 52);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(264, 23);
            this.txtUser.TabIndex = 4;
            this.txtUser.TabStop = false;
            this.txtUser.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtUser.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtUserGroup
            // 
            this.txtUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUserGroup.Appearance = appearance9;
            this.txtUserGroup.AutoSize = false;
            this.txtUserGroup.BackColor = System.Drawing.Color.White;
            this.txtUserGroup.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUserGroup.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtUserGroup.Enabled = false;
            this.txtUserGroup.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtUserGroup.Location = new System.Drawing.Point(131, 27);
            this.txtUserGroup.Name = "txtUserGroup";
            this.txtUserGroup.ReadOnly = true;
            this.txtUserGroup.Size = new System.Drawing.Size(264, 23);
            this.txtUserGroup.TabIndex = 3;
            this.txtUserGroup.TabStop = false;
            this.txtUserGroup.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtUserGroup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FPasswordReset
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 198);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPasswordReset";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Reset";
            this.Load += new System.EventHandler(this.FPasswordReset_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.fPanel1.ClientArea.ResumeLayout(false);
            this.fPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FPanel fPanel1;
        private Core.FaUIs.FTitleLabel lblPass;
        private Core.FaUIs.FTextBox txtPass;
        private Core.FaUIs.FTitleLabel ftlFactory;
        private Core.FaUIs.FTextBox txtFactory;
        private Core.FaUIs.FTitleLabel ftlUserId;
        private Core.FaUIs.FTitleLabel ftlUserGroup;
        private Core.FaUIs.FTextBox txtUser;
        private Core.FaUIs.FTextBox txtUserGroup;
    }
}