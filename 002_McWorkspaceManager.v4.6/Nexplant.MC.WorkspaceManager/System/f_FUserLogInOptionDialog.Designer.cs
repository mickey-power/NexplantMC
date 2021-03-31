namespace Nexplant.MC.WorkspaceManager
{
    partial class FUserLogInOptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUserLogInOptionDialog));
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab7 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab6 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl5 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdWsmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdAdmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdDcmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdRmmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl4 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdPmmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl6 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.pgdFhmProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnClear = new Nexplant.MC.Core.FaUIs.FButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.exbExplorer = new Nexplant.MC.Core.FaUIs.FExplorerBar();
            this.tabMain = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnDelete = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnUpdate = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl5.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            this.ultraTabPageControl3.SuspendLayout();
            this.ultraTabPageControl4.SuspendLayout();
            this.ultraTabPageControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exbExplorer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.splitContainer1);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(630, 370);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnUpdate);
            this.pnlClient.Controls.Add(this.btnDelete);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Controls.Add(this.btnClear);
            this.pnlClient.Size = new System.Drawing.Size(634, 423);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnClear, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnUpdate, 0);
            // 
            // ultraTabPageControl5
            // 
            this.ultraTabPageControl5.Controls.Add(this.pgdWsmProp);
            this.ultraTabPageControl5.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl5.Name = "ultraTabPageControl5";
            this.ultraTabPageControl5.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdWsmProp
            // 
            this.pgdWsmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdWsmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdWsmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdWsmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdWsmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdWsmProp.HelpVisible = false;
            this.pgdWsmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdWsmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdWsmProp.Name = "pgdWsmProp";
            this.pgdWsmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdWsmProp.selectedObject = null;
            this.pgdWsmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdWsmProp.TabIndex = 4;
            this.pgdWsmProp.ToolbarVisible = false;
            this.pgdWsmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdWsmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.pgdAdmProp);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdAdmProp
            // 
            this.pgdAdmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdAdmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdAdmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdAdmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdAdmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdAdmProp.HelpVisible = false;
            this.pgdAdmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdAdmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdAdmProp.Name = "pgdAdmProp";
            this.pgdAdmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdAdmProp.selectedObject = null;
            this.pgdAdmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdAdmProp.TabIndex = 3;
            this.pgdAdmProp.ToolbarVisible = false;
            this.pgdAdmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdAdmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.pgdDcmProp);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdDcmProp
            // 
            this.pgdDcmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdDcmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdDcmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdDcmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdDcmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdDcmProp.HelpVisible = false;
            this.pgdDcmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdDcmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdDcmProp.Name = "pgdDcmProp";
            this.pgdDcmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdDcmProp.selectedObject = null;
            this.pgdDcmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdDcmProp.TabIndex = 4;
            this.pgdDcmProp.ToolbarVisible = false;
            this.pgdDcmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdDcmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.pgdRmmProp);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdRmmProp
            // 
            this.pgdRmmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdRmmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdRmmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdRmmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdRmmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdRmmProp.HelpVisible = false;
            this.pgdRmmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdRmmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdRmmProp.Name = "pgdRmmProp";
            this.pgdRmmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdRmmProp.selectedObject = null;
            this.pgdRmmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdRmmProp.TabIndex = 4;
            this.pgdRmmProp.ToolbarVisible = false;
            this.pgdRmmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdRmmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl4
            // 
            this.ultraTabPageControl4.Controls.Add(this.pgdPmmProp);
            this.ultraTabPageControl4.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl4.Name = "ultraTabPageControl4";
            this.ultraTabPageControl4.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdPmmProp
            // 
            this.pgdPmmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdPmmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdPmmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdPmmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdPmmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdPmmProp.HelpVisible = false;
            this.pgdPmmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdPmmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdPmmProp.Name = "pgdPmmProp";
            this.pgdPmmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdPmmProp.selectedObject = null;
            this.pgdPmmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdPmmProp.TabIndex = 4;
            this.pgdPmmProp.ToolbarVisible = false;
            this.pgdPmmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdPmmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl6
            // 
            this.ultraTabPageControl6.Controls.Add(this.pgdFhmProp);
            this.ultraTabPageControl6.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl6.Name = "ultraTabPageControl6";
            this.ultraTabPageControl6.Size = new System.Drawing.Size(440, 343);
            // 
            // pgdFhmProp
            // 
            this.pgdFhmProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdFhmProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdFhmProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdFhmProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdFhmProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdFhmProp.HelpVisible = false;
            this.pgdFhmProp.LineColor = System.Drawing.Color.Silver;
            this.pgdFhmProp.Location = new System.Drawing.Point(0, 0);
            this.pgdFhmProp.Name = "pgdFhmProp";
            this.pgdFhmProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdFhmProp.selectedObject = null;
            this.pgdFhmProp.Size = new System.Drawing.Size(440, 343);
            this.pgdFhmProp.TabIndex = 5;
            this.pgdFhmProp.ToolbarVisible = false;
            this.pgdFhmProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdFhmProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(540, 388);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnClear.Location = new System.Drawing.Point(448, 388);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(86, 28);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear(&R)";
            this.btnClear.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.exbExplorer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Size = new System.Drawing.Size(624, 367);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 3;
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
            this.exbExplorer.Location = new System.Drawing.Point(0, 0);
            this.exbExplorer.Name = "exbExplorer";
            this.exbExplorer.ShowDefaultContextMenu = false;
            this.exbExplorer.Size = new System.Drawing.Size(180, 366);
            this.exbExplorer.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox;
            this.exbExplorer.TabIndex = 0;
            this.exbExplorer.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.exbExplorer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.exbExplorer.ActiveItemChanged += new Infragistics.Win.UltraWinExplorerBar.ActiveItemChangedEventHandler(this.exbExplorer_ActiveItemChanged);
            this.exbExplorer.Enter += new System.EventHandler(this.exbExplorer_Enter);
            // 
            // tabMain
            // 
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.tabMain.ActiveTabAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Silver;
            this.tabMain.Appearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Transparent;
            this.tabMain.ClientAreaAppearance = appearance9;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Controls.Add(this.ultraTabPageControl2);
            this.tabMain.Controls.Add(this.ultraTabPageControl3);
            this.tabMain.Controls.Add(this.ultraTabPageControl4);
            this.tabMain.Controls.Add(this.ultraTabPageControl5);
            this.tabMain.Controls.Add(this.ultraTabPageControl6);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tabMain.SelectedTabAppearance = appearance10;
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabMain.Size = new System.Drawing.Size(442, 367);
            this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.tabMain.TabIndex = 16;
            ultraTab7.Key = "General";
            ultraTab7.TabPage = this.ultraTabPageControl5;
            ultraTab7.Text = "General";
            ultraTab2.Key = "ADS";
            ultraTab2.TabPage = this.ultraTabPageControl1;
            ultraTab2.Text = "ADS";
            ultraTab4.Key = "DCS";
            ultraTab4.TabPage = this.ultraTabPageControl2;
            ultraTab4.Text = "DCS";
            ultraTab4.Visible = false;
            ultraTab5.Key = "RMS";
            ultraTab5.TabPage = this.ultraTabPageControl3;
            ultraTab5.Text = "RMS";
            ultraTab5.Visible = false;
            ultraTab6.Key = "PMS";
            ultraTab6.TabPage = this.ultraTabPageControl4;
            ultraTab6.Text = "PMS";
            ultraTab6.Visible = false;
            ultraTab1.Key = "FHS";
            ultraTab1.TabPage = this.ultraTabPageControl6;
            ultraTab1.Text = "FHS";
            ultraTab1.Visible = false;
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab7,
            ultraTab2,
            ultraTab4,
            ultraTab5,
            ultraTab6,
            ultraTab1});
            this.tabMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tabMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(440, 343);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnDelete.Location = new System.Drawing.Point(6, 388);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete(&D)";
            this.btnDelete.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(352, 388);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 28);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update(&U)";
            this.btnUpdate.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // FUserLogInOptionDialog
            // 
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUserLogInOptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.FUserLogInOptionDialog_Load);
            this.Shown += new System.EventHandler(this.FUserLogInOptionDialog_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl5.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            this.ultraTabPageControl3.ResumeLayout(false);
            this.ultraTabPageControl4.ResumeLayout(false);
            this.ultraTabPageControl6.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exbExplorer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnClear;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Core.FaUIs.FExplorerBar exbExplorer;
        private Core.FaUIs.FButton btnDelete;
        private Core.FaUIs.FButton btnUpdate;
        private Core.FaUIs.FTab tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Core.FaUIs.FDynPropGrid pgdAdmProp;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Core.FaUIs.FDynPropGrid pgdDcmProp;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Core.FaUIs.FDynPropGrid pgdRmmProp;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl4;
        private Core.FaUIs.FDynPropGrid pgdPmmProp;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl5;
        private Core.FaUIs.FDynPropGrid pgdWsmProp;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl6;
        private Core.FaUIs.FDynPropGrid pgdFhmProp;
    }
}
