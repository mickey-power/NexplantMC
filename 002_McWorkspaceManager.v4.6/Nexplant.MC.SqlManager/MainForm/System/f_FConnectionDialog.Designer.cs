namespace Nexplant.MC.SqlManager
{
    partial class FConnectionDialog
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup ultraExplorerBarGroup1 = new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FConnectionDialog));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.exbExplorer = new Nexplant.MC.Core.FaUIs.FExplorerBar();
            this.btnAdd = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exbExplorer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.BackgroundImage = global::Nexplant.MC.SqlManager.Properties.Resources.FConnectionDialog;
            this.pnlDialogClient.Controls.Add(this.exbExplorer);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(463, 220);
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
            this.btnCancel.TabIndex = 4;
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
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // exbExplorer
            // 
            this.exbExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(222)))), ((int)(((byte)(234)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.exbExplorer.Appearance = appearance1;
            this.exbExplorer.Font = new System.Drawing.Font("Verdana", 9F);
            ultraExplorerBarGroup1.Key = "Default Group";
            ultraExplorerBarGroup1.Text = "New Group";
            this.exbExplorer.Groups.AddRange(new Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup[] {
            ultraExplorerBarGroup1});
            appearance2.BackColor = System.Drawing.Color.Transparent;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.exbExplorer.GroupSettings.AppearancesSmall.Appearance = appearance2;
            appearance3.FontData.BoldAsString = "False";
            this.exbExplorer.GroupSettings.AppearancesSmall.HeaderAppearance = appearance3;
            this.exbExplorer.GroupSettings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            this.exbExplorer.GroupSettings.ShowExpansionIndicator = Infragistics.Win.DefaultableBoolean.False;
            this.exbExplorer.ItemSettings.AllowDragCopy = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.exbExplorer.ItemSettings.AllowDragMove = Infragistics.Win.UltraWinExplorerBar.ItemDragStyle.None;
            this.exbExplorer.ItemSettings.AllowEdit = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.Image = ((object)(resources.GetObject("appearance4.Image")));
            appearance4.TextVAlignAsString = "Middle";
            this.exbExplorer.ItemSettings.AppearancesSmall.ActiveAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance5.BorderColor = System.Drawing.Color.Transparent;
            appearance5.Image = ((object)(resources.GetObject("appearance5.Image")));
            this.exbExplorer.ItemSettings.AppearancesSmall.Appearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.Image = ((object)(resources.GetObject("appearance6.Image")));
            appearance6.TextVAlignAsString = "Middle";
            this.exbExplorer.ItemSettings.AppearancesSmall.CheckedAppearance = appearance6;
            this.exbExplorer.ItemSettings.UseDefaultImage = Infragistics.Win.DefaultableBoolean.False;
            this.exbExplorer.Location = new System.Drawing.Point(213, 70);
            this.exbExplorer.Name = "exbExplorer";
            this.exbExplorer.ShowDefaultContextMenu = false;
            this.exbExplorer.Size = new System.Drawing.Size(211, 99);
            this.exbExplorer.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox;
            this.exbExplorer.TabIndex = 0;
            this.exbExplorer.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.exbExplorer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.exbExplorer.ItemDoubleClick += new Infragistics.Win.UltraWinExplorerBar.ItemDoubleClickEventHandler(this.exbExplorer_ItemDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnAdd.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnAdd.Location = new System.Drawing.Point(6, 238);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 28);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Option(&O)";
            this.btnAdd.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnAdd.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // FConnectionDialog
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 300);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FConnectionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connections";
            this.Load += new System.EventHandler(this.FConnectionDialog_Load);
            this.Shown += new System.EventHandler(this.FConnectionDialog_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exbExplorer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FExplorerBar exbExplorer;
        private Core.FaUIs.FButton btnAdd;
    }
}
