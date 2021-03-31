namespace Nexplant.MC.AdminManager
{
    partial class FEquipmentHistory
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
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEquipmentHistory));
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.StateEditorButton stateEditorButton1 = new Infragistics.Win.UltraWinEditors.StateEditorButton();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.lblToTime = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtEqpName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.udtToTime = new Nexplant.MC.Core.FaUIs.FDateTimeBox();
            this.udtFromTime = new Nexplant.MC.Core.FaUIs.FDateTimeBox();
            this.lblEqpName = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.lblFromTime = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.grdFilter = new Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(this.components);
            this.bwRequest = new System.ComponentModel.BackgroundWorker();
            this.pnlClient.SuspendLayout();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEqpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtToTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.spcMain);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Controls.Add(this.pnlCondition);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // lblToTime
            // 
            appearance26.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance26.BackColor2 = System.Drawing.Color.Lavender;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Center";
            appearance26.TextVAlignAsString = "Middle";
            this.lblToTime.Appearance = appearance26;
            this.lblToTime.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblToTime.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblToTime.Location = new System.Drawing.Point(298, 2);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.Size = new System.Drawing.Size(120, 23);
            this.lblToTime.TabIndex = 13;
            this.lblToTime.Text = "To Time";
            this.lblToTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance16;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtEqpName);
            this.pnlCondition.ClientArea.Controls.Add(this.udtToTime);
            this.pnlCondition.ClientArea.Controls.Add(this.udtFromTime);
            this.pnlCondition.ClientArea.Controls.Add(this.lblEqpName);
            this.pnlCondition.ClientArea.Controls.Add(this.lblToTime);
            this.pnlCondition.ClientArea.Controls.Add(this.lblFromTime);
            this.pnlCondition.Location = new System.Drawing.Point(4, 28);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(976, 29);
            this.pnlCondition.TabIndex = 24;
            // 
            // txtEqpName
            // 
            appearance17.BackColor = System.Drawing.Color.White;
            appearance17.BorderColor = System.Drawing.Color.Silver;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.Image = global::Nexplant.MC.AdminManager.Properties.Resources.Equipment;
            this.txtEqpName.Appearance = appearance17;
            this.txtEqpName.AutoSize = false;
            this.txtEqpName.BackColor = System.Drawing.Color.White;
            this.txtEqpName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.Appearance = appearance18;
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Center;
            editorButton1.PressedAppearance = appearance19;
            this.txtEqpName.ButtonsRight.Add(editorButton1);
            this.txtEqpName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtEqpName.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtEqpName.Location = new System.Drawing.Point(715, 2);
            this.txtEqpName.Name = "txtEqpName";
            this.txtEqpName.ReadOnly = true;
            this.txtEqpName.Size = new System.Drawing.Size(173, 23);
            this.txtEqpName.TabIndex = 2;
            this.txtEqpName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtEqpName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtEqpName.ValueChanged += new System.EventHandler(this.txtEqpName_ValueChanged);
            this.txtEqpName.EditorButtonClick += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.txtEqpName_EditorButtonClick);
            // 
            // udtToTime
            // 
            this.udtToTime.AlwaysInEditMode = true;
            appearance20.BackColor = System.Drawing.Color.White;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            this.udtToTime.Appearance = appearance20;
            this.udtToTime.AutoSize = false;
            this.udtToTime.BackColor = System.Drawing.Color.White;
            appearance21.BackColor = System.Drawing.Color.White;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance21.BorderColor = System.Drawing.Color.White;
            appearance21.ForeColor = System.Drawing.Color.DimGray;
            this.udtToTime.ButtonAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.White;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance22.BorderColor = System.Drawing.Color.White;
            stateEditorButton1.Appearance = appearance22;
            stateEditorButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.udtToTime.ButtonsLeft.Add(stateEditorButton1);
            this.udtToTime.DateTime = new System.DateTime(2015, 7, 23, 0, 0, 0, 0);
            this.udtToTime.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.udtToTime.Location = new System.Drawing.Point(419, 2);
            this.udtToTime.MaskInput = "{date} hh:mm:ss";
            this.udtToTime.Name = "udtToTime";
            this.udtToTime.Size = new System.Drawing.Size(173, 23);
            this.udtToTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtToTime.TabIndex = 1;
            this.udtToTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.udtToTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.udtToTime.Value = new System.DateTime(2015, 7, 23, 0, 0, 0, 0);
            this.udtToTime.ValueChanged += new System.EventHandler(this.udtToTime_ValueChanged);
            this.udtToTime.AfterEditorButtonCheckStateChanged += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.udtToTime_AfterEditorButtonCheckStateChanged);
            // 
            // udtFromTime
            // 
            this.udtFromTime.AlwaysInEditMode = true;
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.udtFromTime.Appearance = appearance23;
            this.udtFromTime.AutoSize = false;
            this.udtFromTime.BackColor = System.Drawing.Color.White;
            appearance24.BackColor = System.Drawing.Color.White;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance24.BorderColor = System.Drawing.Color.White;
            appearance24.ForeColor = System.Drawing.Color.DimGray;
            this.udtFromTime.ButtonAppearance = appearance24;
            this.udtFromTime.DateTime = new System.DateTime(2015, 7, 23, 0, 0, 0, 0);
            this.udtFromTime.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.udtFromTime.Location = new System.Drawing.Point(123, 2);
            this.udtFromTime.MaskInput = "{date} hh:mm:ss";
            this.udtFromTime.Name = "udtFromTime";
            this.udtFromTime.Size = new System.Drawing.Size(173, 23);
            this.udtFromTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtFromTime.TabIndex = 0;
            this.udtFromTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.udtFromTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.udtFromTime.Value = new System.DateTime(2015, 7, 23, 0, 0, 0, 0);
            this.udtFromTime.ValueChanged += new System.EventHandler(this.udtFromTime_ValueChanged);
            // 
            // lblEqpName
            // 
            appearance25.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance25.BackColor2 = System.Drawing.Color.Lavender;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.lblEqpName.Appearance = appearance25;
            this.lblEqpName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblEqpName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblEqpName.Location = new System.Drawing.Point(594, 2);
            this.lblEqpName.Name = "lblEqpName";
            this.lblEqpName.Size = new System.Drawing.Size(120, 23);
            this.lblEqpName.TabIndex = 15;
            this.lblEqpName.Text = "Equipment*";
            this.lblEqpName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFromTime
            // 
            appearance27.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance27.BackColor2 = System.Drawing.Color.Lavender;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance27.BorderColor = System.Drawing.Color.Silver;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Center";
            appearance27.TextVAlignAsString = "Middle";
            this.lblFromTime.Appearance = appearance27;
            this.lblFromTime.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblFromTime.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFromTime.Location = new System.Drawing.Point(2, 2);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.Size = new System.Drawing.Size(120, 23);
            this.lblFromTime.TabIndex = 5;
            this.lblFromTime.Text = "From Time";
            this.lblFromTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
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
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool1});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance14.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolExport;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool2.SharedPropsInternal.Caption = "Export(&E)";
            appearance15.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolRefresh;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool6.SharedPropsInternal.Caption = "Refresh(&R)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
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
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.Location = new System.Drawing.Point(4, 59);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.lblTotal);
            this.spcMain.Panel1.Controls.Add(this.rstToolbar);
            this.spcMain.Panel1.Controls.Add(this.grdList);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2MinSize = 250;
            this.spcMain.Size = new System.Drawing.Size(976, 472);
            this.spcMain.SplitterDistance = 722;
            this.spcMain.TabIndex = 35;
            this.spcMain.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTotal.Appearance = appearance1;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTotal.Location = new System.Drawing.Point(595, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 20);
            this.lblTotal.TabIndex = 95;
            this.lblTotal.Text = "0 / 0";
            this.lblTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(0, 1);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = false;
            this.rstToolbar.Size = new System.Drawing.Size(593, 21);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.TabStop = false;
            this.rstToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstToolbar_SearchRequested);
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance2;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance7;
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
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance9;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.BackColor2 = System.Drawing.Color.LightGray;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
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
            this.grdList.Location = new System.Drawing.Point(0, 24);
            this.grdList.multiSelected = true;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(722, 446);
            this.grdList.TabIndex = 1;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = true;
            this.grdList.AfterRowActivate += new System.EventHandler(this.grdList_AfterRowActivate);
            this.grdList.AfterRowFilterChanged += new Infragistics.Win.UltraWinGrid.AfterRowFilterChangedEventHandler(this.grdList_AfterRowFilterChanged);
            // 
            // pgdProp
            // 
            this.pgdProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdProp.HelpVisible = false;
            this.pgdProp.LineColor = System.Drawing.Color.Silver;
            this.pgdProp.Location = new System.Drawing.Point(0, 0);
            this.pgdProp.Name = "pgdProp";
            this.pgdProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdProp.selectedObject = null;
            this.pgdProp.Size = new System.Drawing.Size(250, 472);
            this.pgdProp.TabIndex = 0;
            this.pgdProp.ToolbarVisible = false;
            this.pgdProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // bwRequest
            // 
            this.bwRequest.WorkerReportsProgress = true;
            this.bwRequest.WorkerSupportsCancellation = true;
            this.bwRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRequest_DoWork);
            this.bwRequest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRequest_ProgressChanged);
            this.bwRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRequest_RunWorkerCompleted);
            // 
            // FEquipmentHistory
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FEquipmentHistory";
            this.Text = "Equipment History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEquipmentHistory_FormClosing);
            this.Load += new System.EventHandler(this.FEquipmentHistory_Load);
            this.Shown += new System.EventHandler(this.FEquipmentHistory_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEquipmentHistory_KeyDown);
            this.pnlClient.ResumeLayout(false);
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEqpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtToTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTitleLabel lblToTime;
        private Core.FaUIs.FTitleLabel lblFromTime;
        private Core.FaUIs.FTitleLabel lblEqpName;
        private Core.FaUIs.FDateTimeBox udtFromTime;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FGrid grdList;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Core.FaUIs.FDateTimeBox udtToTime;
        private Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider grdFilter;
        private Core.FaUIs.FTextBox txtEqpName;
        private System.ComponentModel.BackgroundWorker bwRequest;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FRefreshAndSearchToolbar rstToolbar;
        private Core.FaUIs.FLabel lblTotal;
    }
}
