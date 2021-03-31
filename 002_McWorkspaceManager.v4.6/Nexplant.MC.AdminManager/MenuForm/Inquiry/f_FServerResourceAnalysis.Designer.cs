namespace Nexplant.MC.AdminManager
{
    partial class FServerResourceAnalysis
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool(" Dummy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Export");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool(" Dummy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.StateEditorButton stateEditorButton1 = new Infragistics.Win.UltraWinEditors.StateEditorButton();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServerResourceAnalysis));
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.udtToTime = new Nexplant.MC.Core.FaUIs.FDateTimeBox();
            this.udtFromTime = new Nexplant.MC.Core.FaUIs.FDateTimeBox();
            this.lblToTime = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.lblFromTime = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.chartVarRes = new Nexplant.MC.Core.FaUIs.FChart();
            this.bwRequest = new System.ComponentModel.BackgroundWorker();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udtToTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFromTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarRes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.chartVarRes);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Controls.Add(this.pnlCondition);
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
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5,
            buttonTool1,
            buttonTool3});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance1.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolExport;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance1;
            buttonTool2.SharedPropsInternal.Caption = "Export(&E)";
            buttonTool4.SharedPropsInternal.Caption = " ";
            buttonTool4.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            appearance2.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolRefresh;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance2;
            buttonTool6.SharedPropsInternal.Caption = "Refresh(&R)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool4,
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
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance3;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.udtToTime);
            this.pnlCondition.ClientArea.Controls.Add(this.udtFromTime);
            this.pnlCondition.ClientArea.Controls.Add(this.lblToTime);
            this.pnlCondition.ClientArea.Controls.Add(this.lblFromTime);
            this.pnlCondition.Location = new System.Drawing.Point(4, 28);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(976, 29);
            this.pnlCondition.TabIndex = 46;
            // 
            // udtToTime
            // 
            this.udtToTime.AlwaysInEditMode = true;
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            this.udtToTime.Appearance = appearance4;
            this.udtToTime.AutoSize = false;
            this.udtToTime.BackColor = System.Drawing.Color.White;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance5.BorderColor = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.DimGray;
            this.udtToTime.ButtonAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance6.BorderColor = System.Drawing.Color.White;
            stateEditorButton1.Appearance = appearance6;
            stateEditorButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.udtToTime.ButtonsLeft.Add(stateEditorButton1);
            this.udtToTime.DateTime = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.udtToTime.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.udtToTime.Location = new System.Drawing.Point(436, 2);
            this.udtToTime.MaskInput = "{date} hh:mm:ss";
            this.udtToTime.Name = "udtToTime";
            this.udtToTime.Size = new System.Drawing.Size(190, 23);
            this.udtToTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtToTime.TabIndex = 1;
            this.udtToTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.udtToTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.udtToTime.Value = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.udtToTime.ValueChanged += new System.EventHandler(this.udtToTime_ValueChanged);
            this.udtToTime.AfterEditorButtonCheckStateChanged += new Infragistics.Win.UltraWinEditors.EditorButtonEventHandler(this.udtToTime_AfterEditorButtonCheckStateChanged);
            this.udtToTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udtToTime_KeyDown);
            // 
            // udtFromTime
            // 
            this.udtFromTime.AlwaysInEditMode = true;
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            this.udtFromTime.Appearance = appearance7;
            this.udtFromTime.AutoSize = false;
            this.udtFromTime.BackColor = System.Drawing.Color.White;
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            appearance8.BorderColor = System.Drawing.Color.White;
            appearance8.ForeColor = System.Drawing.Color.DimGray;
            this.udtFromTime.ButtonAppearance = appearance8;
            this.udtFromTime.DateTime = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.udtFromTime.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.udtFromTime.Location = new System.Drawing.Point(123, 2);
            this.udtFromTime.MaskInput = "{date} hh:mm:ss";
            this.udtFromTime.Name = "udtFromTime";
            this.udtFromTime.Size = new System.Drawing.Size(190, 23);
            this.udtFromTime.SpinButtonDisplayStyle = Infragistics.Win.ButtonDisplayStyle.Always;
            this.udtFromTime.TabIndex = 0;
            this.udtFromTime.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.udtFromTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.udtFromTime.Value = new System.DateTime(2013, 4, 15, 0, 0, 0, 0);
            this.udtFromTime.ValueChanged += new System.EventHandler(this.udtFromTime_ValueChanged);
            this.udtFromTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.udtFromTime_KeyDown);
            // 
            // lblToTime
            // 
            appearance9.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance9.BackColor2 = System.Drawing.Color.Lavender;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.lblToTime.Appearance = appearance9;
            this.lblToTime.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblToTime.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblToTime.Location = new System.Drawing.Point(315, 2);
            this.lblToTime.Name = "lblToTime";
            this.lblToTime.Size = new System.Drawing.Size(120, 23);
            this.lblToTime.TabIndex = 25;
            this.lblToTime.Text = "To Time";
            this.lblToTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFromTime
            // 
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.lblFromTime.Appearance = appearance10;
            this.lblFromTime.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblFromTime.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFromTime.Location = new System.Drawing.Point(2, 2);
            this.lblFromTime.Name = "lblFromTime";
            this.lblFromTime.Size = new System.Drawing.Size(120, 23);
            this.lblFromTime.TabIndex = 24;
            this.lblFromTime.Text = "From Time";
            this.lblFromTime.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // chartVarRes
            // 
            this.chartVarRes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartVarRes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chartVarRes.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chartVarRes.BorderlineColor = System.Drawing.Color.Silver;
            this.chartVarRes.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea1.AxisY2.ScaleBreakStyle.Spacing = 0D;
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineColor = System.Drawing.Color.Gray;
            chartArea1.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.LineColor = System.Drawing.Color.Gray;
            chartArea1.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartCpuArea";
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY2.IsLabelAutoFit = false;
            chartArea2.AxisY2.LabelStyle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea2.AxisY2.ScaleBreakStyle.Spacing = 0D;
            chartArea2.AxisY2.TitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            chartArea2.AxisY2.TitleForeColor = System.Drawing.Color.DimGray;
            chartArea2.BackColor = System.Drawing.Color.Gainsboro;
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.LineColor = System.Drawing.Color.Gray;
            chartArea2.CursorX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.CursorY.IsUserEnabled = true;
            chartArea2.CursorY.LineColor = System.Drawing.Color.Gray;
            chartArea2.CursorY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartMemArea";
            this.chartVarRes.ChartAreas.Add(chartArea1);
            this.chartVarRes.ChartAreas.Add(chartArea2);
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Enabled = false;
            legend2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend2";
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chartVarRes.Legends.Add(legend1);
            this.chartVarRes.Legends.Add(legend2);
            this.chartVarRes.Location = new System.Drawing.Point(4, 59);
            this.chartVarRes.Name = "chartVarRes";
            this.chartVarRes.Size = new System.Drawing.Size(976, 473);
            this.chartVarRes.TabIndex = 0;
            // 
            // bwRequest
            // 
            this.bwRequest.WorkerReportsProgress = true;
            this.bwRequest.WorkerSupportsCancellation = true;
            this.bwRequest.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwRequest_DoWork);
            this.bwRequest.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwRequest_ProgressChanged);
            this.bwRequest.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwRequest_RunWorkerCompleted);
            // 
            // FServerResourceAnalysis
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FServerResourceAnalysis";
            this.Text = "Server Resource Analysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FServerResourceAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.FServerResourceAnalysis_Load);
            this.Shown += new System.EventHandler(this.FServerResourceAnalysis_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FServerResourceAnalysis_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udtToTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udtFromTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartVarRes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FDateTimeBox udtToTime;
        private Core.FaUIs.FDateTimeBox udtFromTime;
        private Core.FaUIs.FTitleLabel lblToTime;
        private Core.FaUIs.FTitleLabel lblFromTime;
        private Core.FaUIs.FChart chartVarRes;
        private System.ComponentModel.BackgroundWorker bwRequest;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
    }
}
