namespace Nexplant.MC.LogViewer
{
    partial class FBinaryLogViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.SpinEditorButton spinEditorButton1 = new Infragistics.Win.UltraWinEditors.SpinEditorButton();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool1 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool2 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Refresh");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBinaryLogViewer));
            this.pnlLog = new System.Windows.Forms.Panel();
            this.numFontSize = new Nexplant.MC.Core.FaUIs.FNumericBox();
            this.txtLog = new Nexplant.MC.Core.FaUIs.FLogTextBox();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtFileName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblFileName = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this._pnlClient_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlClient_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlClient.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlCondition);
            this.pnlClient.Controls.Add(this.pnlLog);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Left);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Right);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Bottom);
            this.pnlClient.Controls.Add(this._pnlClient_Toolbars_Dock_Area_Top);
            this.pnlClient.Size = new System.Drawing.Size(896, 328);
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.Controls.Add(this.numFontSize);
            this.pnlLog.Controls.Add(this.txtLog);
            this.pnlLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlLog.Location = new System.Drawing.Point(4, 35);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(888, 290);
            this.pnlLog.TabIndex = 9;
            // 
            // numFontSize
            // 
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            this.numFontSize.Appearance = appearance4;
            this.numFontSize.AutoSize = false;
            this.numFontSize.BackColor = System.Drawing.Color.White;
            appearance5.BackColor = System.Drawing.Color.White;
            appearance5.ForeColor = System.Drawing.Color.DimGray;
            spinEditorButton1.Appearance = appearance5;
            this.numFontSize.ButtonsRight.Add(spinEditorButton1);
            this.numFontSize.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.numFontSize.Font = new System.Drawing.Font("Verdana", 9F);
            this.numFontSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numFontSize.Location = new System.Drawing.Point(794, 51);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.PromptChar = ' ';
            this.numFontSize.Size = new System.Drawing.Size(72, 20);
            this.numFontSize.TabIndex = 13;
            this.numFontSize.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.numFontSize.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.numFontSize.Value = 8;
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
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Appearance = appearance6;
            this.txtLog.AutoSize = false;
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtLog.HideSelection = false;
            this.txtLog.Location = new System.Drawing.Point(0, 26);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(888, 264);
            this.txtLog.TabIndex = 2;
            this.txtLog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLog.WordWrap = false;
            this.txtLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLog_KeyDown);
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
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            fontListTool1.InstanceProps.IsFirstInGroup = true;
            controlContainerTool1.ControlName = "numFontSize";
            controlContainerTool1.InstanceProps.Width = 156;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool4,
            buttonTool3,
            fontListTool1,
            controlContainerTool1});
            ultraToolbar1.Settings.ToolSpacing = 1;
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance7.Image = global::Nexplant.MC.LogViewer.Properties.Resources.ToolFind;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            buttonTool15.SharedPropsInternal.Caption = "Find(&F)...";
            appearance8.Image = global::Nexplant.MC.LogViewer.Properties.Resources.FileOpen;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            buttonTool17.SharedPropsInternal.Caption = "Open(&O)...";
            popupMenuTool1.SharedPropsInternal.Caption = "PopupMenu";
            buttonTool41.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool38,
            buttonTool41});
            appearance9.BackColor = System.Drawing.Color.White;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            fontListTool2.EditAppearance = appearance9;
            fontListTool2.SharedPropsInternal.Caption = "Font Name(&F) :";
            fontListTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool2.ControlName = "numFontSize";
            controlContainerTool2.SharedPropsInternal.Caption = "Font Size(&Z) :";
            controlContainerTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            controlContainerTool2.SharedPropsInternal.Width = 156;
            appearance10.Image = global::Nexplant.MC.LogViewer.Properties.Resources.ToolRefresh;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            buttonTool2.SharedPropsInternal.Caption = "Refresh(&R)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15,
            buttonTool17,
            popupMenuTool1,
            fontListTool2,
            controlContainerTool2,
            buttonTool2});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            this.mnuMenu.ToolValueChanged += new Infragistics.Win.UltraWinToolbars.ToolEventHandler(this.mnuMenu_ToolValueChanged);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance1;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtFileName);
            this.pnlCondition.ClientArea.Controls.Add(this.lblFileName);
            this.pnlCondition.Location = new System.Drawing.Point(4, 30);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(888, 29);
            this.pnlCondition.TabIndex = 15;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtFileName.Appearance = appearance2;
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
            this.txtFileName.Size = new System.Drawing.Size(761, 23);
            this.txtFileName.TabIndex = 13;
            this.txtFileName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtFileName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFileName
            // 
            appearance3.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance3.BackColor2 = System.Drawing.Color.Lavender;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.lblFileName.Appearance = appearance3;
            this.lblFileName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblFileName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFileName.Location = new System.Drawing.Point(2, 2);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(120, 23);
            this.lblFileName.TabIndex = 9;
            this.lblFileName.Text = "File";
            this.lblFileName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _pnlClient_Toolbars_Dock_Area_Left
            // 
            this._pnlClient_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlClient_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(4, 28);
            this._pnlClient_Toolbars_Dock_Area_Left.Name = "_pnlClient_Toolbars_Dock_Area_Left";
            this._pnlClient_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 296);
            this._pnlClient_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Right
            // 
            this._pnlClient_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlClient_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(892, 28);
            this._pnlClient_Toolbars_Dock_Area_Right.Name = "_pnlClient_Toolbars_Dock_Area_Right";
            this._pnlClient_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 296);
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
            this._pnlClient_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(888, 24);
            this._pnlClient_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlClient_Toolbars_Dock_Area_Bottom
            // 
            this._pnlClient_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlClient_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlClient_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlClient_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlClient_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(4, 324);
            this._pnlClient_Toolbars_Dock_Area_Bottom.Name = "_pnlClient_Toolbars_Dock_Area_Bottom";
            this._pnlClient_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(888, 0);
            this._pnlClient_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // FBinaryLogViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(896, 355);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBinaryLogViewer";
            this.Text = "Binary Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSecsBinaryLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FSecsBinaryLogViewer_Load);
            this.Shown += new System.EventHandler(this.FSecsBinaryLogViewer_Shown);
            this.Enter += new System.EventHandler(this.FSecsBinaryLogViewer_Enter);
            this.pnlClient.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FLogTextBox txtLog;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FNumericBox numFontSize;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTextBox txtFileName;
        private Core.FaUIs.FTitleLabel lblFileName;
        private System.Windows.Forms.Panel pnlLog;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlClient_Toolbars_Dock_Area_Top;
    }
}