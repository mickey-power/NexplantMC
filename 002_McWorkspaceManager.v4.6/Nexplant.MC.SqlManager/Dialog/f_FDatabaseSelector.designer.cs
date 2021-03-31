namespace Nexplant.MC.SqlManager
{
    partial class FDatabaseSelector
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.fPanel3 = new Nexplant.MC.Core.FaUIs.FPanel();
            this.chkPostgreSql = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkMsSql = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkMySql = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkOracle = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.chkMariaDb = new Nexplant.MC.Core.FaUIs.FCheckedBox();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.fTab1 = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.fPanel3.ClientArea.SuspendLayout();
            this.fPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPostgreSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMsSql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMySql)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOracle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMariaDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).BeginInit();
            this.fTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.fTab1);
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
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.fPanel3);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(518, 238);
            // 
            // fPanel3
            // 
            appearance4.BorderColor = System.Drawing.Color.DarkGray;
            this.fPanel3.Appearance = appearance4;
            this.fPanel3.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // fPanel3.ClientArea
            // 
            this.fPanel3.ClientArea.Controls.Add(this.chkPostgreSql);
            this.fPanel3.ClientArea.Controls.Add(this.chkMsSql);
            this.fPanel3.ClientArea.Controls.Add(this.chkMySql);
            this.fPanel3.ClientArea.Controls.Add(this.chkOracle);
            this.fPanel3.ClientArea.Controls.Add(this.chkMariaDb);
            this.fPanel3.Location = new System.Drawing.Point(2, 2);
            this.fPanel3.Name = "fPanel3";
            this.fPanel3.Size = new System.Drawing.Size(514, 234);
            this.fPanel3.TabIndex = 25;
            // 
            // chkPostgreSql
            // 
            appearance5.BackColor = System.Drawing.Color.Transparent;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.chkPostgreSql.Appearance = appearance5;
            this.chkPostgreSql.BackColor = System.Drawing.Color.Transparent;
            this.chkPostgreSql.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkPostgreSql.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkPostgreSql.Location = new System.Drawing.Point(5, 104);
            this.chkPostgreSql.Name = "chkPostgreSql";
            this.chkPostgreSql.Size = new System.Drawing.Size(128, 19);
            this.chkPostgreSql.TabIndex = 16;
            this.chkPostgreSql.Text = "PostgreSQL";
            this.chkPostgreSql.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkMsSql
            // 
            appearance6.BackColor = System.Drawing.Color.Transparent;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.chkMsSql.Appearance = appearance6;
            this.chkMsSql.BackColor = System.Drawing.Color.Transparent;
            this.chkMsSql.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkMsSql.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkMsSql.Location = new System.Drawing.Point(5, 4);
            this.chkMsSql.Name = "chkMsSql";
            this.chkMsSql.Size = new System.Drawing.Size(234, 19);
            this.chkMsSql.TabIndex = 11;
            this.chkMsSql.Text = "Microsoft SQL Server";
            this.chkMsSql.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkMySql
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.chkMySql.Appearance = appearance7;
            this.chkMySql.BackColor = System.Drawing.Color.Transparent;
            this.chkMySql.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkMySql.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkMySql.Location = new System.Drawing.Point(5, 54);
            this.chkMySql.Name = "chkMySql";
            this.chkMySql.Size = new System.Drawing.Size(128, 19);
            this.chkMySql.TabIndex = 13;
            this.chkMySql.Text = "MySQL";
            this.chkMySql.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkOracle
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.chkOracle.Appearance = appearance8;
            this.chkOracle.BackColor = System.Drawing.Color.Transparent;
            this.chkOracle.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkOracle.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkOracle.Location = new System.Drawing.Point(5, 29);
            this.chkOracle.Name = "chkOracle";
            this.chkOracle.Size = new System.Drawing.Size(128, 19);
            this.chkOracle.TabIndex = 12;
            this.chkOracle.Text = "Oracle Database";
            this.chkOracle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chkMariaDb
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.chkMariaDb.Appearance = appearance9;
            this.chkMariaDb.BackColor = System.Drawing.Color.Transparent;
            this.chkMariaDb.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkMariaDb.GlyphInfo = Infragistics.Win.UIElementDrawParams.Office2010CheckBoxGlyphInfo;
            this.chkMariaDb.Location = new System.Drawing.Point(5, 79);
            this.chkMariaDb.Name = "chkMariaDb";
            this.chkMariaDb.Size = new System.Drawing.Size(128, 19);
            this.chkMariaDb.TabIndex = 14;
            this.chkMariaDb.Text = "MariaDB";
            this.chkMariaDb.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(334, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 1;
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
            this.btnCancel.Location = new System.Drawing.Point(426, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // fTab1
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.fTab1.ActiveTabAppearance = appearance1;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Silver;
            this.fTab1.Appearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.fTab1.ClientAreaAppearance = appearance3;
            this.fTab1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.fTab1.Controls.Add(this.ultraTabPageControl2);
            this.fTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fTab1.Location = new System.Drawing.Point(0, 0);
            this.fTab1.Name = "fTab1";
            this.fTab1.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.fTab1.SelectedTabAppearance = appearance10;
            this.fTab1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.fTab1.Size = new System.Drawing.Size(520, 262);
            this.fTab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.fTab1.TabIndex = 17;
            ultraTab4.TabPage = this.ultraTabPageControl2;
            ultraTab4.Text = "Database";
            this.fTab1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab4});
            this.fTab1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.fTab1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(518, 238);
            // 
            // FDatabaseSelector
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FDatabaseSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Selector";
            this.Load += new System.EventHandler(this.FDownloadDbSelector_Load);
            this.Shown += new System.EventHandler(this.FDownloadDbSelector_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.fPanel3.ClientArea.ResumeLayout(false);
            this.fPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkPostgreSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMsSql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMySql)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOracle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMariaDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).EndInit();
            this.fTab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FCheckedBox chkPostgreSql;
        private Core.FaUIs.FCheckedBox chkMariaDb;
        private Core.FaUIs.FCheckedBox chkMySql;
        private Core.FaUIs.FCheckedBox chkOracle;
        private Core.FaUIs.FCheckedBox chkMsSql;
        private Core.FaUIs.FTab fTab1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Core.FaUIs.FPanel fPanel3;


    }
}
