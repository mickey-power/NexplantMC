namespace Nexplant.MC.WorkspaceManager
{
    partial class FPasswordChange
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.fPanel1 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.ftlOldPass = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtOldPass = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.ftlConPass = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.ftlNewPass = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtConPass = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtNewPass = new Nexplant.MC.Core.FaUIs.FTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.fPanel1);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(400, 164);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(404, 217);
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
            this.btnCancel.Location = new System.Drawing.Point(306, 182);
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
            this.btnOk.Location = new System.Drawing.Point(214, 182);
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
            this.fPanel1.ClientArea.Controls.Add(this.ftlOldPass);
            this.fPanel1.ClientArea.Controls.Add(this.txtOldPass);
            this.fPanel1.ClientArea.Controls.Add(this.ftlConPass);
            this.fPanel1.ClientArea.Controls.Add(this.ftlNewPass);
            this.fPanel1.ClientArea.Controls.Add(this.txtConPass);
            this.fPanel1.ClientArea.Controls.Add(this.txtNewPass);
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
            this.fPanel1.Size = new System.Drawing.Size(400, 164);
            this.fPanel1.TabIndex = 13;
            // 
            // ftlOldPass
            // 
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BackColor2 = System.Drawing.Color.Lavender;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.ftlOldPass.Appearance = appearance2;
            this.ftlOldPass.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlOldPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlOldPass.Location = new System.Drawing.Point(3, 85);
            this.ftlOldPass.Name = "ftlOldPass";
            this.ftlOldPass.Size = new System.Drawing.Size(125, 23);
            this.ftlOldPass.TabIndex = 16;
            this.ftlOldPass.Text = "Old Password";
            this.ftlOldPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtOldPass.Appearance = appearance3;
            this.txtOldPass.AutoSize = false;
            this.txtOldPass.BackColor = System.Drawing.Color.White;
            this.txtOldPass.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtOldPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtOldPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtOldPass.Location = new System.Drawing.Point(131, 85);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '*';
            this.txtOldPass.Size = new System.Drawing.Size(264, 23);
            this.txtOldPass.TabIndex = 1;
            this.txtOldPass.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtOldPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlConPass
            // 
            appearance4.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance4.BackColor2 = System.Drawing.Color.Lavender;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.ftlConPass.Appearance = appearance4;
            this.ftlConPass.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlConPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlConPass.Location = new System.Drawing.Point(3, 135);
            this.ftlConPass.Name = "ftlConPass";
            this.ftlConPass.Size = new System.Drawing.Size(125, 23);
            this.ftlConPass.TabIndex = 13;
            this.ftlConPass.Text = "Confirm Password";
            this.ftlConPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlNewPass
            // 
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BackColor2 = System.Drawing.Color.Lavender;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Left";
            appearance5.TextVAlignAsString = "Middle";
            this.ftlNewPass.Appearance = appearance5;
            this.ftlNewPass.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftlNewPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.ftlNewPass.Location = new System.Drawing.Point(3, 110);
            this.ftlNewPass.Name = "ftlNewPass";
            this.ftlNewPass.Size = new System.Drawing.Size(125, 23);
            this.ftlNewPass.TabIndex = 14;
            this.ftlNewPass.Text = "New Password";
            this.ftlNewPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtConPass
            // 
            this.txtConPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.txtConPass.Appearance = appearance6;
            this.txtConPass.AutoSize = false;
            this.txtConPass.BackColor = System.Drawing.Color.White;
            this.txtConPass.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtConPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtConPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtConPass.Location = new System.Drawing.Point(131, 135);
            this.txtConPass.Name = "txtConPass";
            this.txtConPass.PasswordChar = '*';
            this.txtConPass.Size = new System.Drawing.Size(264, 23);
            this.txtConPass.TabIndex = 3;
            this.txtConPass.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtConPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.txtNewPass.Appearance = appearance7;
            this.txtNewPass.AutoSize = false;
            this.txtNewPass.BackColor = System.Drawing.Color.White;
            this.txtNewPass.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtNewPass.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtNewPass.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtNewPass.Location = new System.Drawing.Point(131, 110);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(264, 23);
            this.txtNewPass.TabIndex = 2;
            this.txtNewPass.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtNewPass.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ftlFactory
            // 
            appearance8.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance8.BackColor2 = System.Drawing.Color.Lavender;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Left";
            appearance8.TextVAlignAsString = "Middle";
            this.ftlFactory.Appearance = appearance8;
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
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtFactory.Appearance = appearance9;
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
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Left";
            appearance10.TextVAlignAsString = "Middle";
            this.ftlUserId.Appearance = appearance10;
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
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.ftlUserGroup.Appearance = appearance11;
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
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUser.Appearance = appearance12;
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
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtUserGroup.Appearance = appearance13;
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
            // FPasswordChange
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(404, 244);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FPasswordChange";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Password Change";
            this.Load += new System.EventHandler(this.FPasswordChange_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.fPanel1.ClientArea.ResumeLayout(false);
            this.fPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FPanel fPanel1;
        private Core.FaUIs.FTitleLabel ftlOldPass;
        private Core.FaUIs.FTextBox txtOldPass;
        private Core.FaUIs.FTitleLabel ftlConPass;
        private Core.FaUIs.FTitleLabel ftlNewPass;
        private Core.FaUIs.FTextBox txtConPass;
        private Core.FaUIs.FTextBox txtNewPass;
        private Core.FaUIs.FTitleLabel ftlFactory;
        private Core.FaUIs.FTextBox txtFactory;
        private Core.FaUIs.FTitleLabel ftlUserId;
        private Core.FaUIs.FTitleLabel ftlUserGroup;
        private Core.FaUIs.FTextBox txtUser;
        private Core.FaUIs.FTextBox txtUserGroup;
    }
}