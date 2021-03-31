namespace Nexplant.MC.OpcModeler
{
    partial class FValidationViewer
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Goto");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Goto");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this._pnlClient_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlDialogClient = new Nexplant.MC.Core.FaUIs.FPanel();
            this.tvwTree = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlDialogClient.ClientArea.SuspendLayout();
            this.pnlDialogClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlDialogClient);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Left);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Right);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Bottom);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Top);
            this.pnlClient.Size = new System.Drawing.Size(410, 448);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlClient;
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool4,
            buttonTool1});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance6.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.Goto;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool2.SharedPropsInternal.Caption = "Goto";
            appearance7.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolRefresh;
            buttonTool5.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            buttonTool5.SharedPropsInternal.Caption = "Refresh";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool5});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // _pnlClient_Toolbars_Dock_Area_Top
            // 
            this._pnlClient_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlClient_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(4, 4);
            this._pnlClient_Toolbars_Dock_Area_Top.Name = "_pnlClient_Toolbars_Dock_Area_Top";
            this._pnlClient_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(402, 24);
            this._pnlClient_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Bottom
            // 
            this._pnlClient_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlClient_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(4, 444);
            this._pnlClient_Toolbars_Dock_Area_Bottom.Name = "_pnlClient_Toolbars_Dock_Area_Bottom";
            this._pnlClient_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(402, 0);
            this._pnlClient_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Left
            // 
            this._pnlClient_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlClient_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(4, 28);
            this._pnlClient_Toolbars_Dock_Area_Left.Name = "_pnlClient_Toolbars_Dock_Area_Left";
            this._pnlClient_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 416);
            this._pnlClient_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Right
            // 
            this._pnlClient_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlClient_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(406, 28);
            this._pnlClient_Toolbars_Dock_Area_Right.Name = "_pnlClient_Toolbars_Dock_Area_Right";
            this._pnlClient_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 416);
            this._pnlClient_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlDialogClient.Appearance = appearance1;
            // 
            // pnlDialogClient.ClientArea
            // 
            this.pnlDialogClient.ClientArea.Controls.Add(this.tvwTree);
            this.pnlDialogClient.Location = new System.Drawing.Point(4, 30);
            this.pnlDialogClient.Name = "pnlDialogClient";
            this.pnlDialogClient.Size = new System.Drawing.Size(402, 414);
            this.pnlDialogClient.TabIndex = 13;
            // 
            // tvwTree
            // 
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            this.tvwTree.Appearance = appearance2;
            this.tvwTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tvwTree.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.tvwTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTree.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Font = new System.Drawing.Font("Verdana", 9F);
            this.tvwTree.HideSelection = false;
            this.tvwTree.Location = new System.Drawing.Point(0, 0);
            this.tvwTree.multiSelected = true;
            this.tvwTree.Name = "tvwTree";
            this.tvwTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance3.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance3;
            _override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            _override1.ItemHeight = 18;
            _override1.Multiline = Infragistics.Win.DefaultableBoolean.False;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.ForeColor = System.Drawing.Color.Black;
            _override1.NodeAppearance = appearance4;
            _override1.NodeDoubleClickAction = Infragistics.Win.UltraWinTree.NodeDoubleClickAction.None;
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.BackColor2 = System.Drawing.Color.LightGray;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance5.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance5;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended;
            _override1.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            _override1.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwTree.ScrollBarLook = scrollBarLook1;
            this.tvwTree.Size = new System.Drawing.Size(402, 414);
            this.tvwTree.TabIndex = 9;
            this.tvwTree.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwTree.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.DoubleClick += new System.EventHandler(this.tvwTree_DoubleClick);
            // 
            // FValidationViewer
            // 
            this.ClientSize = new System.Drawing.Size(410, 475);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FValidationViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Validation Viewer";
            this.Load += new System.EventHandler(this.FRelationViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRelationViewer_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlDialogClient.ClientArea.ResumeLayout(false);
            this.pnlDialogClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Left;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FPanel pnlDialogClient;
        private Core.FaUIs.FTreeView tvwTree;
    }
}
