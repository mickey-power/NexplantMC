namespace Nexplant.MC.WorkspaceManager
{
    partial class FUserLogIn
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnAdd = new Nexplant.MC.Core.FaUIs.FButton();
            this.txtFactory = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtDescription = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtUserId = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtPassword = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.chkIdSave = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.txtSite = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIdSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.BackgroundImage = global::Nexplant.MC.WorkspaceManager.Properties.Resources.FUserLogIn;
            this.pnlDialogClient.Controls.Add(this.txtSite);
            this.pnlDialogClient.Controls.Add(this.chkIdSave);
            this.pnlDialogClient.Controls.Add(this.txtPassword);
            this.pnlDialogClient.Controls.Add(this.txtUserId);
            this.pnlDialogClient.Controls.Add(this.txtDescription);
            this.pnlDialogClient.Controls.Add(this.txtFactory);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(463, 220);
            this.pnlDialogClient.TabIndex = 0;
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnAdd);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(467, 273);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnAdd, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(362, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(259, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnAdd.Location = new System.Drawing.Point(6, 238);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Option(&O)";
            this.btnAdd.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnAdd.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // txtFactory
            // 
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtFactory.Appearance = appearance6;
            this.txtFactory.AutoSize = false;
            this.txtFactory.BackColor = System.Drawing.Color.White;
            this.txtFactory.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFactory.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtFactory.Enabled = false;
            this.txtFactory.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtFactory.Location = new System.Drawing.Point(292, 66);
            this.txtFactory.Name = "txtFactory";
            this.txtFactory.ReadOnly = true;
            this.txtFactory.Size = new System.Drawing.Size(147, 21);
            this.txtFactory.TabIndex = 0;
            this.txtFactory.TabStop = false;
            this.txtFactory.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFactory.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtDescription
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtDescription.Appearance = appearance5;
            this.txtDescription.AutoSize = false;
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDescription.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtDescription.Location = new System.Drawing.Point(292, 94);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(147, 21);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TabStop = false;
            this.txtDescription.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtDescription.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtUserId
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtUserId.Appearance = appearance4;
            this.txtUserId.AutoSize = false;
            this.txtUserId.BackColor = System.Drawing.Color.White;
            this.txtUserId.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtUserId.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtUserId.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtUserId.Location = new System.Drawing.Point(292, 122);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(147, 21);
            this.txtUserId.TabIndex = 2;
            this.txtUserId.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtUserId.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtPassword
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Appearance = appearance3;
            this.txtPassword.AutoSize = false;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtPassword.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtPassword.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtPassword.Location = new System.Drawing.Point(292, 150);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(147, 21);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.txtPassword.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtPassword.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkIdSave
            // 
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.TextVAlignAsString = "Middle";
            this.chkIdSave.Appearance = appearance2;
            this.chkIdSave.BackColor = System.Drawing.Color.Transparent;
            this.chkIdSave.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkIdSave.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkIdSave.Location = new System.Drawing.Point(295, 172);
            this.chkIdSave.Name = "chkIdSave";
            this.chkIdSave.Size = new System.Drawing.Size(144, 21);
            this.chkIdSave.TabIndex = 4;
            this.chkIdSave.Text = "ID Save";
            this.chkIdSave.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtSite
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtSite.Appearance = appearance1;
            this.txtSite.AutoSize = false;
            this.txtSite.BackColor = System.Drawing.Color.White;
            this.txtSite.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSite.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtSite.Enabled = false;
            this.txtSite.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtSite.Location = new System.Drawing.Point(292, 38);
            this.txtSite.Name = "txtSite";
            this.txtSite.ReadOnly = true;
            this.txtSite.Size = new System.Drawing.Size(147, 21);
            this.txtSite.TabIndex = 5;
            this.txtSite.TabStop = false;
            this.txtSite.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtSite.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FUserLogIn
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUserLogIn";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Log In";
            this.Load += new System.EventHandler(this.FUserLogIn_Load);
            this.Shown += new System.EventHandler(this.FUserLogIn_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFactory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIdSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnAdd;
        private Core.FaUIs.FTextBox txtPassword;
        private Core.FaUIs.FTextBox txtUserId;
        private Core.FaUIs.FTextBox txtDescription;
        private Core.FaUIs.FTextBox txtFactory;
        private Core.FaUIs.FCheckedBox chkIdSave;
        private Core.FaUIs.FTextBox txtSite;
    }
}
