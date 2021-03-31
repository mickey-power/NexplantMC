namespace Nexplant.MC.SqlManager
{
    partial class FApplicationLogViewer
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
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool2 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool1 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.SpinEditorButton spinEditorButton1 = new Infragistics.Win.UltraWinEditors.SpinEditorButton();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FApplicationLogViewer));
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlLog = new Nexplant.MC.Core.FaUIs.FPanel();
            this.mskFontSize = new Nexplant.MC.Core.FaUIs.FNumericBox();
            this._ClientArea_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtFileName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.fTitleLabel2 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.grdFilter = new Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(this.components);
            this.pnlIndex = new Nexplant.MC.Core.FaUIs.FPanel();
            this.fSplitter = new Nexplant.MC.Core.FaUIs.FSplitter();
            this.txtLog = new Nexplant.MC.Core.FaUIs.FLogTextBox();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlLog.ClientArea.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mskFontSize)).BeginInit();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.pnlIndex.ClientArea.SuspendLayout();
            this.pnlIndex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlLog);
            this.pnlClient.Controls.Add(this.fSplitter);
            this.pnlClient.Controls.Add(this.pnlIndex);
            this.pnlClient.Controls.Add(this.pnlCondition);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlLog.ClientArea;
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
            fontListTool2.InstanceProps.IsFirstInGroup = true;
            controlContainerTool2.ControlName = "mskFontSize";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            fontListTool2,
            controlContainerTool2});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance5.Image = global::Nexplant.MC.SqlManager.Properties.Resources.ToolFind;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool2.SharedPropsInternal.Caption = "Find(&F)...";
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            fontListTool1.EditAppearance = appearance6;
            fontListTool1.SharedPropsInternal.Caption = "Font Name(&F) :";
            fontListTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool1.ControlName = "mskFontSize";
            controlContainerTool1.SharedPropsInternal.Caption = "Font Size(&Z) :";
            controlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            fontListTool1,
            controlContainerTool1});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.AfterToolDeactivate += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.mnuMenu_AfterToolDeactivate);
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            this.mnuMenu.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.mnuMenu_FontNameChange);
            // 
            // pnlLog
            // 
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlLog.Appearance = appearance1;
            // 
            // pnlLog.ClientArea
            // 
            this.pnlLog.ClientArea.Controls.Add(this.txtLog);
            this.pnlLog.ClientArea.Controls.Add(this.mskFontSize);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Left);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Right);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Bottom);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Top);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(4, 227);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(976, 304);
            this.pnlLog.TabIndex = 0;
            // 
            // mskFontSize
            // 
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.mskFontSize.Appearance = appearance3;
            this.mskFontSize.AutoSize = false;
            this.mskFontSize.BackColor = System.Drawing.Color.White;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.ForeColor = System.Drawing.Color.DimGray;
            spinEditorButton1.Appearance = appearance4;
            this.mskFontSize.ButtonsRight.Add(spinEditorButton1);
            this.mskFontSize.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.mskFontSize.Font = new System.Drawing.Font("Verdana", 9F);
            this.mskFontSize.FormatString = "";
            this.mskFontSize.Location = new System.Drawing.Point(93, 30);
            this.mskFontSize.Name = "mskFontSize";
            this.mskFontSize.PromptChar = ' ';
            this.mskFontSize.Size = new System.Drawing.Size(68, 20);
            this.mskFontSize.TabIndex = 9;
            this.mskFontSize.TabStop = false;
            this.mskFontSize.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.mskFontSize.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mskFontSize.ValueChanged += new System.EventHandler(this.mskFontSize_ValueChanged);
            this.mskFontSize.BeforeExitEditMode += new Infragistics.Win.BeforeExitEditModeEventHandler(this.mskFontSize_BeforeExitEditMode);
            this.mskFontSize.EditorSpinButtonClick += new Infragistics.Win.UltraWinEditors.SpinButtonClickEventHandler(this.mskFontSize_EditorSpinButtonClick);
            this.mskFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mskFontSize_KeyDown);
            // 
            // _ClientArea_Toolbars_Dock_Area_Left
            // 
            this._ClientArea_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ClientArea_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 24);
            this._ClientArea_Toolbars_Dock_Area_Left.Name = "_ClientArea_Toolbars_Dock_Area_Left";
            this._ClientArea_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 280);
            this._ClientArea_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Right
            // 
            this._ClientArea_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ClientArea_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(976, 24);
            this._ClientArea_Toolbars_Dock_Area_Right.Name = "_ClientArea_Toolbars_Dock_Area_Right";
            this._ClientArea_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 280);
            this._ClientArea_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Bottom
            // 
            this._ClientArea_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ClientArea_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 304);
            this._ClientArea_Toolbars_Dock_Area_Bottom.Name = "_ClientArea_Toolbars_Dock_Area_Bottom";
            this._ClientArea_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(976, 0);
            this._ClientArea_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Top
            // 
            this._ClientArea_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ClientArea_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ClientArea_Toolbars_Dock_Area_Top.Name = "_ClientArea_Toolbars_Dock_Area_Top";
            this._ClientArea_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(976, 24);
            this._ClientArea_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // pnlCondition
            // 
            appearance22.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance22;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtFileName);
            this.pnlCondition.ClientArea.Controls.Add(this.fTitleLabel2);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(4, 4);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(976, 29);
            this.pnlCondition.TabIndex = 11;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance23.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Appearance = appearance23;
            this.txtFileName.AutoSize = false;
            this.txtFileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFileName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFileName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtFileName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtFileName.HideSelection = false;
            this.txtFileName.Location = new System.Drawing.Point(123, 2);
            this.txtFileName.MaxLength = 2147483647;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileName.Size = new System.Drawing.Size(849, 23);
            this.txtFileName.TabIndex = 15;
            this.txtFileName.TabStop = false;
            this.txtFileName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFileName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fTitleLabel2
            // 
            appearance24.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance24.BackColor2 = System.Drawing.Color.Lavender;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Center";
            appearance24.TextVAlignAsString = "Middle";
            this.fTitleLabel2.Appearance = appearance24;
            this.fTitleLabel2.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel2.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel2.Location = new System.Drawing.Point(2, 2);
            this.fTitleLabel2.Name = "fTitleLabel2";
            this.fTitleLabel2.Size = new System.Drawing.Size(120, 23);
            this.fTitleLabel2.TabIndex = 14;
            this.fTitleLabel2.Text = "File";
            this.fTitleLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance10;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance11;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance12;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance13.BackColor2 = System.Drawing.SystemColors.Control;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance13;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            appearance14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance15.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance15;
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
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance17.BorderColor = System.Drawing.Color.Silver;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance17;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance18.BackColor = System.Drawing.SystemColors.Control;
            appearance18.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance18.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance19.BackColor2 = System.Drawing.Color.Lavender;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextHAlignAsString = "Center";
            appearance19.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance19;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance17;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance20.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance20.BackColor2 = System.Drawing.Color.LightGray;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance20;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance21;
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
            this.grdList.Location = new System.Drawing.Point(0, 25);
            this.grdList.multiSelected = true;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(976, 165);
            this.grdList.TabIndex = 1;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = true;
            this.grdList.AfterRowActivate += new System.EventHandler(this.grdList_AfterRowActivate);
            this.grdList.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdList_DoubleClickRow);
            this.grdList.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.grdList_AfterRowFilterChanged);
            this.grdList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdList_KeyDown);
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(0, 2);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = true;
            this.rstToolbar.Size = new System.Drawing.Size(976, 22);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.TabStop = false;
            this.rstToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstToolbar_RefreshRequested);
            this.rstToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstToolbar_SearchRequested);
            // 
            // pnlIndex
            // 
            appearance9.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlIndex.Appearance = appearance9;
            // 
            // pnlIndex.ClientArea
            // 
            this.pnlIndex.ClientArea.Controls.Add(this.grdList);
            this.pnlIndex.ClientArea.Controls.Add(this.rstToolbar);
            this.pnlIndex.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlIndex.Location = new System.Drawing.Point(4, 33);
            this.pnlIndex.Name = "pnlIndex";
            this.pnlIndex.Size = new System.Drawing.Size(976, 190);
            this.pnlIndex.TabIndex = 13;
            // 
            // fSplitter
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.fSplitter.Appearance = appearance7;
            this.fSplitter.BackColor = System.Drawing.Color.Transparent;
            this.fSplitter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20;
            this.fSplitter.ButtonAppearance = appearance8;
            this.fSplitter.ButtonExtent = 100;
            this.fSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.fSplitter.Location = new System.Drawing.Point(4, 223);
            this.fSplitter.Name = "fSplitter";
            this.fSplitter.RestoreExtent = 144;
            this.fSplitter.Size = new System.Drawing.Size(976, 4);
            this.fSplitter.TabIndex = 16;
            // 
            // txtLog
            // 
            this.txtLog.AlwaysInEditMode = true;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Appearance = appearance2;
            this.txtLog.AutoSize = false;
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtLog.HideSelection = false;
            this.txtLog.Location = new System.Drawing.Point(0, 24);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(976, 280);
            this.txtLog.TabIndex = 14;
            this.txtLog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLog.WordWrap = false;
            // 
            // FApplicationLogViewer
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FApplicationLogViewer";
            this.Text = "Application Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FApplicationLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FApplicationLogViewer_Load);
            this.Shown += new System.EventHandler(this.FApplicationLogViewer_Shown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlLog.ClientArea.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mskFontSize)).EndInit();
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.pnlIndex.ClientArea.ResumeLayout(false);
            this.pnlIndex.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FRefreshAndSearchToolbar rstToolbar;
        private Core.FaUIs.FGrid grdList;
        private Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider grdFilter;
        private Core.FaUIs.FNumericBox mskFontSize;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTextBox txtFileName;
        private Core.FaUIs.FTitleLabel fTitleLabel2;
        private Core.FaUIs.FPanel pnlIndex;
        private Core.FaUIs.FPanel pnlLog;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FSplitter fSplitter;
        private Core.FaUIs.FLogTextBox txtLog;
    }
}
