namespace Nexplant.MC.AdminManager
{
    partial class FRecentNotice
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
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRecentNotice));
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ftxNotice = new Nexplant.MC.Core.FaUIs.FFormattedBox();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.ftxNotice);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlMenu;
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance2.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolRefresh;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedPropsInternal.Caption = "Refresh(&R)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Left);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Right);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Bottom);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Top);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(4, 4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(976, 24);
            this.pnlMenu.TabIndex = 0;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Left
            // 
            this._pnlMenu_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlMenu_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 23);
            this._pnlMenu_Toolbars_Dock_Area_Left.Name = "_pnlMenu_Toolbars_Dock_Area_Left";
            this._pnlMenu_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 1);
            this._pnlMenu_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Right
            // 
            this._pnlMenu_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlMenu_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(976, 23);
            this._pnlMenu_Toolbars_Dock_Area_Right.Name = "_pnlMenu_Toolbars_Dock_Area_Right";
            this._pnlMenu_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 1);
            this._pnlMenu_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Bottom
            // 
            this._pnlMenu_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 24);
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Name = "_pnlMenu_Toolbars_Dock_Area_Bottom";
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(976, 0);
            this._pnlMenu_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Top
            // 
            this._pnlMenu_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlMenu_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._pnlMenu_Toolbars_Dock_Area_Top.Name = "_pnlMenu_Toolbars_Dock_Area_Top";
            this._pnlMenu_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(976, 23);
            this._pnlMenu_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // ftxNotice
            // 
            this.ftxNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.ftxNotice.Appearance = appearance1;
            this.ftxNotice.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftxNotice.Location = new System.Drawing.Point(4, 30);
            this.ftxNotice.Name = "ftxNotice";
            this.ftxNotice.ReadOnly = true;
            this.ftxNotice.Size = new System.Drawing.Size(976, 501);
            this.ftxNotice.TabIndex = 40;
            this.ftxNotice.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ftxNotice.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ftxNotice.Value = "";
            // 
            // FRecentNotice
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FRecentNotice";
            this.Text = "Recent Notice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRecentNotice_FormClosing);
            this.Load += new System.EventHandler(this.FRecentNotice_Load);
            this.Shown += new System.EventHandler(this.FRecentNotice_Shown);
            this.Enter += new System.EventHandler(this.FRecentNotice_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRecentNotice_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FFormattedBox ftxNotice;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
    }
}
