namespace Nexplant.MC.AdminManager
{
    partial class FEapLogViewer
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Previous");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool1 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool2 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Previous");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Next");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.SpinEditorButton spinEditorButton1 = new Infragistics.Win.UltraWinEditors.SpinEditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEapLogViewer));
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlLog = new Nexplant.MC.Core.FaUIs.FPanel();
            this.numFontSize = new Nexplant.MC.Core.FaUIs.FNumericBox();
            this.txtLog = new Nexplant.MC.Core.FaUIs.FLogTextBox();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtSize = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.fTitleLabel3 = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtFileName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblFileName = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtLogType = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblLogType = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this._pnlClient_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlLog.ClientArea.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).BeginInit();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogType)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlLog);
            this.pnlClient.Controls.Add(this.pnlCondition);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Left);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Right);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Bottom);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Top);
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
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            fontListTool1.InstanceProps.IsFirstInGroup = true;
            controlContainerTool2.ControlName = "numFontSize";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool5,
            buttonTool6,
            buttonTool1,
            fontListTool1,
            controlContainerTool2});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance12.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolFind;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            buttonTool2.SharedPropsInternal.Caption = "Find(&F)...";
            controlContainerTool1.ControlName = "numFontSize";
            controlContainerTool1.SharedPropsInternal.Caption = "Font Size(&Z) :";
            controlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            fontListTool2.EditAppearance = appearance13;
            fontListTool2.SharedPropsInternal.Caption = "Font Name(&F) :";
            fontListTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance14.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolRefresh;
            buttonTool4.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool4.SharedPropsInternal.Caption = "Refresh(&R)";
            appearance15.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolPrevious;
            buttonTool7.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool7.SharedPropsInternal.Caption = "Previous(&P)";
            appearance16.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolNext;
            buttonTool8.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool8.SharedPropsInternal.Caption = "Next(&N)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            controlContainerTool1,
            fontListTool2,
            buttonTool4,
            buttonTool7,
            buttonTool8});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.AfterToolDeactivate += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.mnuMenu_AfterToolDeactivate);
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            this.mnuMenu.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.mnuMenu_ToolValueChanged);
            // 
            // pnlLog
            // 
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlLog.Appearance = appearance1;
            // 
            // pnlLog.ClientArea
            // 
            this.pnlLog.ClientArea.Controls.Add(this.numFontSize);
            this.pnlLog.ClientArea.Controls.Add(this.txtLog);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(4, 57);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(976, 474);
            this.pnlLog.TabIndex = 12;
            // 
            // numFontSize
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            this.numFontSize.Appearance = appearance2;
            this.numFontSize.AutoSize = false;
            this.numFontSize.BackColor = System.Drawing.Color.White;
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.ForeColor = System.Drawing.Color.DimGray;
            spinEditorButton1.Appearance = appearance3;
            this.numFontSize.ButtonsRight.Add(spinEditorButton1);
            this.numFontSize.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.numFontSize.Font = new System.Drawing.Font("Verdana", 9F);
            this.numFontSize.Location = new System.Drawing.Point(822, 26);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.PromptChar = ' ';
            this.numFontSize.Size = new System.Drawing.Size(68, 20);
            this.numFontSize.TabIndex = 10;
            this.numFontSize.TabStop = false;
            this.numFontSize.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.numFontSize.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.numFontSize.BeforeExitEditMode += new Infragistics.Win.BeforeExitEditModeEventHandler(this.numFontSize_BeforeExitEditMode);
            this.numFontSize.EditorSpinButtonClick += new Infragistics.Win.UltraWinEditors.SpinButtonClickEventHandler(this.numFontSize_EditorSpinButtonClick);
            this.numFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.numFontSize_KeyDown);
            // 
            // txtLog
            // 
            this.txtLog.AlwaysInEditMode = true;
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Appearance = appearance4;
            this.txtLog.AutoSize = false;
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtLog.HideSelection = false;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(976, 474);
            this.txtLog.TabIndex = 4;
            this.txtLog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLog.WordWrap = false;
            this.txtLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLog_KeyDown);
            // 
            // pnlCondition
            // 
            appearance5.BorderColor = System.Drawing.Color.Silver;
            this.pnlCondition.Appearance = appearance5;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtSize);
            this.pnlCondition.ClientArea.Controls.Add(this.fTitleLabel3);
            this.pnlCondition.ClientArea.Controls.Add(this.txtFileName);
            this.pnlCondition.ClientArea.Controls.Add(this.lblFileName);
            this.pnlCondition.ClientArea.Controls.Add(this.txtLogType);
            this.pnlCondition.ClientArea.Controls.Add(this.lblLogType);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(4, 28);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(976, 29);
            this.pnlCondition.TabIndex = 10;
            // 
            // txtSize
            // 
            this.txtSize.AlwaysInEditMode = true;
            this.txtSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.txtSize.Appearance = appearance6;
            this.txtSize.AutoSize = false;
            this.txtSize.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSize.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtSize.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtSize.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtSize.HideSelection = false;
            this.txtSize.Location = new System.Drawing.Point(800, 2);
            this.txtSize.MaxLength = 2147483647;
            this.txtSize.Name = "txtSize";
            this.txtSize.ReadOnly = true;
            this.txtSize.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtSize.Size = new System.Drawing.Size(172, 23);
            this.txtSize.TabIndex = 39;
            this.txtSize.TabStop = false;
            this.txtSize.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtSize.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fTitleLabel3
            // 
            this.fTitleLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance7.BackColor2 = System.Drawing.Color.Lavender;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Center";
            appearance7.TextVAlignAsString = "Middle";
            this.fTitleLabel3.Appearance = appearance7;
            this.fTitleLabel3.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.fTitleLabel3.Font = new System.Drawing.Font("Verdana", 9F);
            this.fTitleLabel3.Location = new System.Drawing.Point(679, 2);
            this.fTitleLabel3.Name = "fTitleLabel3";
            this.fTitleLabel3.Size = new System.Drawing.Size(120, 23);
            this.fTitleLabel3.TabIndex = 38;
            this.fTitleLabel3.Text = "Size";
            this.fTitleLabel3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtFileName
            // 
            this.txtFileName.AlwaysInEditMode = true;
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Appearance = appearance8;
            this.txtFileName.AutoSize = false;
            this.txtFileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtFileName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtFileName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtFileName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtFileName.HideSelection = false;
            this.txtFileName.Location = new System.Drawing.Point(418, 2);
            this.txtFileName.MaxLength = 2147483647;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileName.Size = new System.Drawing.Size(259, 23);
            this.txtFileName.TabIndex = 15;
            this.txtFileName.TabStop = false;
            this.txtFileName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFileName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFileName
            // 
            appearance9.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance9.BackColor2 = System.Drawing.Color.Lavender;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextHAlignAsString = "Center";
            appearance9.TextVAlignAsString = "Middle";
            this.lblFileName.Appearance = appearance9;
            this.lblFileName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFileName.Location = new System.Drawing.Point(297, 2);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(120, 23);
            this.lblFileName.TabIndex = 14;
            this.lblFileName.Text = "File";
            this.lblFileName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtLogType
            // 
            this.txtLogType.AlwaysInEditMode = true;
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            this.txtLogType.Appearance = appearance10;
            this.txtLogType.AutoSize = false;
            this.txtLogType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLogType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtLogType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtLogType.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtLogType.HideSelection = false;
            this.txtLogType.Location = new System.Drawing.Point(123, 2);
            this.txtLogType.MaxLength = 2147483647;
            this.txtLogType.Name = "txtLogType";
            this.txtLogType.ReadOnly = true;
            this.txtLogType.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogType.Size = new System.Drawing.Size(172, 23);
            this.txtLogType.TabIndex = 13;
            this.txtLogType.TabStop = false;
            this.txtLogType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtLogType.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblLogType
            // 
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.lblLogType.Appearance = appearance11;
            this.lblLogType.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblLogType.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblLogType.Location = new System.Drawing.Point(2, 2);
            this.lblLogType.Name = "lblLogType";
            this.lblLogType.Size = new System.Drawing.Size(120, 23);
            this.lblLogType.TabIndex = 9;
            this.lblLogType.Text = "Log";
            this.lblLogType.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _pnlClient_Toolbars_Dock_Area_Left
            // 
            this._pnlClient_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlClient_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(4, 28);
            this._pnlClient_Toolbars_Dock_Area_Left.Name = "_pnlClient_Toolbars_Dock_Area_Left";
            this._pnlClient_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 503);
            this._pnlClient_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Right
            // 
            this._pnlClient_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlClient_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(980, 28);
            this._pnlClient_Toolbars_Dock_Area_Right.Name = "_pnlClient_Toolbars_Dock_Area_Right";
            this._pnlClient_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 503);
            this._pnlClient_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Top
            // 
            this._pnlClient_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlClient_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(4, 4);
            this._pnlClient_Toolbars_Dock_Area_Top.Name = "_pnlClient_Toolbars_Dock_Area_Top";
            this._pnlClient_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(976, 24);
            this._pnlClient_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Bottom
            // 
            this._pnlClient_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlClient_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(4, 531);
            this._pnlClient_Toolbars_Dock_Area_Bottom.Name = "_pnlClient_Toolbars_Dock_Area_Bottom";
            this._pnlClient_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(976, 0);
            this._pnlClient_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // FEapLogViewer
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FEapLogViewer";
            this.Text = "EAP Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSmlLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FEapLogViewer_Load);
            this.Shown += new System.EventHandler(this.FEapLogViewer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FEapLogViewer_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlLog.ClientArea.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).EndInit();
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLogType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FPanel pnlLog;
        private Core.FaUIs.FLogTextBox txtLog;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTextBox txtFileName;
        private Core.FaUIs.FTitleLabel lblFileName;
        private Core.FaUIs.FTextBox txtLogType;
        private Core.FaUIs.FTitleLabel lblLogType;
        private Core.FaUIs.FNumericBox numFontSize;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FTextBox txtSize;
        private Core.FaUIs.FTitleLabel fTitleLabel3;
    }
}
