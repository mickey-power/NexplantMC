namespace Nexplant.MC.AdminManager
{
    partial class FProcessEapWizard
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("List");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FProcessEapWizard));
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.fPanel2 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtSvrName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.fTitleLabel8 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.fPanel5 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.fTitleLabel1 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.fTitleLabel2 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtEap = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtDesc = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.tabMain = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.fPanel2.ClientArea.SuspendLayout();
            this.fPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSvrName)).BeginInit();
            this.fPanel5.ClientArea.SuspendLayout();
            this.fPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlDialogClient.Controls.Add(this.tabMain);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(617, 373);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(622, 426);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.fPanel2);
            this.ultraTabPageControl1.Controls.Add(this.fPanel5);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(616, 349);
            // 
            // fPanel2
            // 
            appearance4.BorderColor = System.Drawing.Color.DarkGray;
            this.fPanel2.Appearance = appearance4;
            this.fPanel2.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // fPanel2.ClientArea
            // 
            this.fPanel2.ClientArea.Controls.Add(this.txtSvrName);
            this.fPanel2.ClientArea.Controls.Add(this.fTitleLabel8);
            this.fPanel2.Location = new System.Drawing.Point(2, 60);
            this.fPanel2.Name = "fPanel2";
            this.fPanel2.Size = new System.Drawing.Size(612, 29);
            this.fPanel2.TabIndex = 36;
            // 
            // txtSvrName
            // 
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.Image = global::Nexplant.MC.AdminManager.Properties.Resources.Server;
            this.txtSvrName.Appearance = appearance5;
            this.txtSvrName.AutoSize = false;
            this.txtSvrName.BackColor = System.Drawing.Color.White;
            this.txtSvrName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.Appearance = appearance6;
            editorButton1.Key = "List";
            appearance7.Image = ((object)(resources.GetObject("appearance7.Image")));
            appearance7.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.PressedAppearance = appearance7;
            this.txtSvrName.ButtonsRight.Add(editorButton1);
            this.txtSvrName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtSvrName.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtSvrName.Location = new System.Drawing.Point(103, 2);
            this.txtSvrName.Name = "txtSvrName";
            this.txtSvrName.ReadOnly = true;
            this.txtSvrName.Size = new System.Drawing.Size(505, 23);
            this.txtSvrName.TabIndex = 29;
            this.txtSvrName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtSvrName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fTitleLabel8
            // 
            appearance8.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance8.BackColor2 = System.Drawing.Color.Lavender;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.fTitleLabel8.Appearance = appearance8;
            this.fTitleLabel8.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel8.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel8.Location = new System.Drawing.Point(2, 2);
            this.fTitleLabel8.Name = "fTitleLabel8";
            this.fTitleLabel8.Size = new System.Drawing.Size(99, 23);
            this.fTitleLabel8.TabIndex = 16;
            this.fTitleLabel8.Text = "Server";
            this.fTitleLabel8.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fPanel5
            // 
            appearance9.BorderColor = System.Drawing.Color.DarkGray;
            this.fPanel5.Appearance = appearance9;
            this.fPanel5.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // fPanel5.ClientArea
            // 
            this.fPanel5.ClientArea.Controls.Add(this.fTitleLabel1);
            this.fPanel5.ClientArea.Controls.Add(this.fTitleLabel2);
            this.fPanel5.ClientArea.Controls.Add(this.txtEap);
            this.fPanel5.ClientArea.Controls.Add(this.txtDesc);
            this.fPanel5.Location = new System.Drawing.Point(2, 2);
            this.fPanel5.Name = "fPanel5";
            this.fPanel5.Size = new System.Drawing.Size(612, 55);
            this.fPanel5.TabIndex = 35;
            // 
            // fTitleLabel1
            // 
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.fTitleLabel1.Appearance = appearance10;
            this.fTitleLabel1.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel1.Location = new System.Drawing.Point(2, 2);
            this.fTitleLabel1.Name = "fTitleLabel1";
            this.fTitleLabel1.Size = new System.Drawing.Size(99, 23);
            this.fTitleLabel1.TabIndex = 0;
            this.fTitleLabel1.Text = "EAP";
            this.fTitleLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fTitleLabel2
            // 
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.fTitleLabel2.Appearance = appearance11;
            this.fTitleLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel2.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel2.Location = new System.Drawing.Point(2, 28);
            this.fTitleLabel2.Name = "fTitleLabel2";
            this.fTitleLabel2.Size = new System.Drawing.Size(99, 23);
            this.fTitleLabel2.TabIndex = 1;
            this.fTitleLabel2.Text = "Description";
            this.fTitleLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtEap
            // 
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            this.txtEap.Appearance = appearance12;
            this.txtEap.AutoSize = false;
            this.txtEap.BackColor = System.Drawing.Color.White;
            this.txtEap.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtEap.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtEap.Location = new System.Drawing.Point(103, 2);
            this.txtEap.MaxLength = 20;
            this.txtEap.Name = "txtEap";
            this.txtEap.Size = new System.Drawing.Size(505, 23);
            this.txtEap.TabIndex = 0;
            this.txtEap.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtEap.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtDesc
            // 
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Appearance = appearance13;
            this.txtDesc.AutoSize = false;
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtDesc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtDesc.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtDesc.Location = new System.Drawing.Point(103, 28);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(505, 23);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtDesc.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(524, 391);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(432, 391);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabMain
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.tabMain.ActiveTabAppearance = appearance1;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Silver;
            this.tabMain.Appearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.tabMain.ClientAreaAppearance = appearance3;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance14.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance14.BackColor2 = System.Drawing.Color.Lavender;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tabMain.SelectedTabAppearance = appearance14;
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabMain.ShowTabListButton = Infragistics.Win.DefaultableBoolean.False;
            this.tabMain.Size = new System.Drawing.Size(618, 373);
            this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.tabMain.TabIndex = 108;
            ultraTab3.Key = "General";
            ultraTab3.TabPage = this.ultraTabPageControl1;
            ultraTab3.Text = "General";
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3});
            this.tabMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tabMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(616, 349);
            // 
            // FProcessEapWizard
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(622, 453);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FProcessEapWizard";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EAP Wizard for Process";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEapWizard_FormClosing);
            this.Load += new System.EventHandler(this.FEapWizard_Load);
            this.Shown += new System.EventHandler(this.FEapWizard_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.fPanel2.ClientArea.ResumeLayout(false);
            this.fPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSvrName)).EndInit();
            this.fPanel5.ClientArea.ResumeLayout(false);
            this.fPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FTab tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Core.FaUIs.FPanel fPanel2;
        private Core.FaUIs.FTitleLabel fTitleLabel8;
        private Core.FaUIs.FPanel fPanel5;
        private Core.FaUIs.FTitleLabel fTitleLabel1;
        private Core.FaUIs.FTitleLabel fTitleLabel2;
        private Core.FaUIs.FTextBox txtEap;
        private Core.FaUIs.FTextBox txtDesc;
        private Core.FaUIs.FTextBox txtSvrName;
    }
}
