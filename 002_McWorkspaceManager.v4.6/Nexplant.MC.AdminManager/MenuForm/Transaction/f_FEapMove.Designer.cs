namespace Nexplant.MC.AdminManager
{
    partial class FEapMove
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
            this.components = new System.ComponentModel.Container();
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
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Attach");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Detach");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Attach");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Detach");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clear");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEapMove));
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this._pnlDialogClient_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlDialogClient_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlDialogClient_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.lblSuccessTitle = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblSuccess = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblFail = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblFailTitle = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblCancel = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblCancelTitle = new Nexplant.MC.Core.FaUIs.FLabel();
            this.btnMove = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtSvrName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblServer = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSvrName)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.grdList);
            this.pnlDialogClient.Controls.Add(this._pnlDialogClient_Toolbars_Dock_Area_Left);
            this.pnlDialogClient.Controls.Add(this._pnlDialogClient_Toolbars_Dock_Area_Right);
            this.pnlDialogClient.Controls.Add(this._pnlDialogClient_Toolbars_Dock_Area_Bottom);
            this.pnlDialogClient.Controls.Add(this._pnlDialogClient_Toolbars_Dock_Area_Top);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Padding = new System.Windows.Forms.Padding(2);
            this.pnlDialogClient.Size = new System.Drawing.Size(979, 482);
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance1;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdList.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdList.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdList.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdList.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdList.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdList.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdList.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdList.DisplayLayout.UseFixedHeaders = true;
            this.grdList.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdList.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdList.Location = new System.Drawing.Point(2, 58);
            this.grdList.multiSelected = true;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(975, 424);
            this.grdList.TabIndex = 0;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = true;
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlDialogClient;
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
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool5});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance13.Image = global::Nexplant.MC.AdminManager.Properties.Resources.AppendEap;
            buttonTool3.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool3.SharedPropsInternal.Caption = "Attach";
            appearance14.Image = global::Nexplant.MC.AdminManager.Properties.Resources.RemoveEap;
            buttonTool4.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool4.SharedPropsInternal.Caption = "Detach";
            appearance15.Image = global::Nexplant.MC.AdminManager.Properties.Resources.RemoveAllEap;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool6.SharedPropsInternal.Caption = "Clear";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4,
            buttonTool6});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // _pnlDialogClient_Toolbars_Dock_Area_Left
            // 
            this._pnlDialogClient_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlDialogClient_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlDialogClient_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlDialogClient_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlDialogClient_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(2, 25);
            this._pnlDialogClient_Toolbars_Dock_Area_Left.Name = "_pnlDialogClient_Toolbars_Dock_Area_Left";
            this._pnlDialogClient_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 455);
            this._pnlDialogClient_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlDialogClient_Toolbars_Dock_Area_Right
            // 
            this._pnlDialogClient_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlDialogClient_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlDialogClient_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlDialogClient_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlDialogClient_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(977, 25);
            this._pnlDialogClient_Toolbars_Dock_Area_Right.Name = "_pnlDialogClient_Toolbars_Dock_Area_Right";
            this._pnlDialogClient_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 455);
            this._pnlDialogClient_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlDialogClient_Toolbars_Dock_Area_Top
            // 
            this._pnlDialogClient_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlDialogClient_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlDialogClient_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlDialogClient_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlDialogClient_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(2, 2);
            this._pnlDialogClient_Toolbars_Dock_Area_Top.Name = "_pnlDialogClient_Toolbars_Dock_Area_Top";
            this._pnlDialogClient_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(975, 23);
            this._pnlDialogClient_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlDialogClient_Toolbars_Dock_Area_Bottom
            // 
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(2, 480);
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.Name = "_pnlDialogClient_Toolbars_Dock_Area_Bottom";
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(975, 0);
            this._pnlDialogClient_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // lblSuccessTitle
            // 
            this.lblSuccessTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.ForeColor = System.Drawing.Color.DimGray;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.lblSuccessTitle.Appearance = appearance16;
            this.lblSuccessTitle.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblSuccessTitle.Location = new System.Drawing.Point(527, 531);
            this.lblSuccessTitle.Name = "lblSuccessTitle";
            this.lblSuccessTitle.Size = new System.Drawing.Size(66, 22);
            this.lblSuccessTitle.TabIndex = 4;
            this.lblSuccessTitle.Text = "Success:";
            this.lblSuccessTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblSuccess
            // 
            this.lblSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance17.ForeColor = System.Drawing.Color.DimGray;
            appearance17.TextVAlignAsString = "Middle";
            this.lblSuccess.Appearance = appearance17;
            this.lblSuccess.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblSuccess.Location = new System.Drawing.Point(594, 531);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(42, 22);
            this.lblSuccess.TabIndex = 5;
            this.lblSuccess.Text = "0";
            this.lblSuccess.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFail
            // 
            this.lblFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance18.ForeColor = System.Drawing.Color.DimGray;
            appearance18.TextVAlignAsString = "Middle";
            this.lblFail.Appearance = appearance18;
            this.lblFail.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFail.Location = new System.Drawing.Point(710, 531);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(42, 22);
            this.lblFail.TabIndex = 7;
            this.lblFail.Text = "0";
            this.lblFail.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFailTitle
            // 
            this.lblFailTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance19.ForeColor = System.Drawing.Color.DimGray;
            appearance19.TextHAlignAsString = "Right";
            appearance19.TextVAlignAsString = "Middle";
            this.lblFailTitle.Appearance = appearance19;
            this.lblFailTitle.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFailTitle.Location = new System.Drawing.Point(643, 531);
            this.lblFailTitle.Name = "lblFailTitle";
            this.lblFailTitle.Size = new System.Drawing.Size(66, 22);
            this.lblFailTitle.TabIndex = 6;
            this.lblFailTitle.Text = "Fail:";
            this.lblFailTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance20.ForeColor = System.Drawing.Color.DimGray;
            appearance20.TextVAlignAsString = "Middle";
            this.lblCancel.Appearance = appearance20;
            this.lblCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblCancel.Location = new System.Drawing.Point(827, 531);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(42, 22);
            this.lblCancel.TabIndex = 9;
            this.lblCancel.Text = "0";
            this.lblCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblCancelTitle
            // 
            this.lblCancelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance21.ForeColor = System.Drawing.Color.DimGray;
            appearance21.TextHAlignAsString = "Right";
            appearance21.TextVAlignAsString = "Middle";
            this.lblCancelTitle.Appearance = appearance21;
            this.lblCancelTitle.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblCancelTitle.Location = new System.Drawing.Point(760, 531);
            this.lblCancelTitle.Name = "lblCancelTitle";
            this.lblCancelTitle.Size = new System.Drawing.Size(66, 22);
            this.lblCancelTitle.TabIndex = 8;
            this.lblCancelTitle.Text = "Cancel:";
            this.lblCancelTitle.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnMove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMove.Enabled = false;
            this.btnMove.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnMove.Location = new System.Drawing.Point(881, 528);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(97, 28);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Move(&M)";
            this.btnMove.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance22.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance22;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtSvrName);
            this.pnlCondition.ClientArea.Controls.Add(this.lblServer);
            this.pnlCondition.Location = new System.Drawing.Point(5, 56);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(975, 29);
            this.pnlCondition.TabIndex = 0;
            // 
            // txtSvrName
            // 
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.Image = global::Nexplant.MC.AdminManager.Properties.Resources.Server;
            this.txtSvrName.Appearance = appearance23;
            this.txtSvrName.AutoSize = false;
            this.txtSvrName.BackColor = System.Drawing.Color.White;
            this.txtSvrName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance24.BackColor = System.Drawing.Color.Transparent;
            appearance24.Image = ((object)(resources.GetObject("appearance24.Image")));
            appearance24.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.Appearance = appearance24;
            appearance25.Image = ((object)(resources.GetObject("appearance25.Image")));
            appearance25.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.PressedAppearance = appearance25;
            this.txtSvrName.ButtonsRight.Add(editorButton1);
            this.txtSvrName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtSvrName.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtSvrName.Location = new System.Drawing.Point(123, 2);
            this.txtSvrName.Name = "txtSvrName";
            this.txtSvrName.ReadOnly = true;
            this.txtSvrName.Size = new System.Drawing.Size(173, 23);
            this.txtSvrName.TabIndex = 1;
            this.txtSvrName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtSvrName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtSvrName.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtSvrName_EditorButtonClick);
            // 
            // lblServer
            // 
            appearance26.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance26.BackColor2 = System.Drawing.Color.Lavender;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.lblServer.Appearance = appearance26;
            this.lblServer.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblServer.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblServer.Location = new System.Drawing.Point(2, 2);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(120, 23);
            this.lblServer.TabIndex = 5;
            this.lblServer.Text = "To Server*";
            this.lblServer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FEapMove
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblCancelTitle);
            this.Controls.Add(this.lblFail);
            this.Controls.Add(this.lblFailTitle);
            this.Controls.Add(this.lblSuccess);
            this.Controls.Add(this.lblSuccessTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FEapMove";
            this.Text = "EAP Move";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEapMove_FormClosing);
            this.Load += new System.EventHandler(this.FEapMove_Load);
            this.Shown += new System.EventHandler(this.FEapMove_Shown);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.Controls.SetChildIndex(this.lblSuccessTitle, 0);
            this.Controls.SetChildIndex(this.lblSuccess, 0);
            this.Controls.SetChildIndex(this.lblFailTitle, 0);
            this.Controls.SetChildIndex(this.lblFail, 0);
            this.Controls.SetChildIndex(this.lblCancelTitle, 0);
            this.Controls.SetChildIndex(this.lblCancel, 0);
            this.Controls.SetChildIndex(this.btnMove, 0);
            this.Controls.SetChildIndex(this.pnlCondition, 0);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSvrName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FGrid grdList;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlDialogClient_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlDialogClient_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlDialogClient_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlDialogClient_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FLabel lblSuccessTitle;
        private Core.FaUIs.FLabel lblSuccess;
        private Core.FaUIs.FLabel lblFail;
        private Core.FaUIs.FLabel lblFailTitle;
        private Core.FaUIs.FLabel lblCancel;
        private Core.FaUIs.FLabel lblCancelTitle;
        private Core.FaUIs.FButton btnMove;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTitleLabel lblServer;
        private Core.FaUIs.FTextBox txtSvrName;
    }
}
