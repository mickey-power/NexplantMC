namespace Nexplant.MC.AdminManager
{
    partial class FTrsLogViewer
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
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool1 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Find");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool1 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("Font Size");
            Infragistics.Win.UltraWinToolbars.FontListTool fontListTool2 = new Infragistics.Win.UltraWinToolbars.FontListTool("Font Name");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.SpinEditorButton spinEditorButton1 = new Infragistics.Win.UltraWinEditors.SpinEditorButton();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTrsLogViewer));
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlLog = new Nexplant.MC.Core.FaUIs.FPanel();
            this.numFontSize = new Nexplant.MC.Core.FaUIs.FNumericBox();
            this.txtLog = new Nexplant.MC.Core.FaUIs.FLogTextBox();
            this._ClientArea_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlLog.ClientArea.SuspendLayout();
            this.pnlLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlLog);
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
            fontListTool1.InstanceProps.IsFirstInGroup = true;
            controlContainerTool2.ControlName = "numFontSize";
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            fontListTool1,
            controlContainerTool2});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance5.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolFind;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool2.SharedPropsInternal.Caption = "Find(&F)...";
            controlContainerTool1.ControlName = "numFontSize";
            controlContainerTool1.SharedPropsInternal.Caption = "Font Size(&Z) :";
            controlContainerTool1.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            appearance6.BackColor = System.Drawing.Color.White;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            fontListTool2.EditAppearance = appearance6;
            fontListTool2.SharedPropsInternal.Caption = "Font Name(&F) :";
            fontListTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            controlContainerTool1,
            fontListTool2});
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
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Left);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Right);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Bottom);
            this.pnlLog.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Top);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(4, 4);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(976, 527);
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
            this.numFontSize.Location = new System.Drawing.Point(804, 207);
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
            this.txtLog.Location = new System.Drawing.Point(0, 26);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(976, 501);
            this.txtLog.TabIndex = 4;
            this.txtLog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLog.WordWrap = false;
            this.txtLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLog_KeyDown);
            // 
            // _ClientArea_Toolbars_Dock_Area_Left
            // 
            this._ClientArea_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ClientArea_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 24);
            this._ClientArea_Toolbars_Dock_Area_Left.Name = "_ClientArea_Toolbars_Dock_Area_Left";
            this._ClientArea_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 503);
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
            this._ClientArea_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 503);
            this._ClientArea_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Bottom
            // 
            this._ClientArea_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ClientArea_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 527);
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
            // FTrsLogViewer
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FTrsLogViewer";
            this.Text = "TRS Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTrsLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FTrsLogViewer_Load);
            this.Shown += new System.EventHandler(this.FTrsLogViewer_Shown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlLog.ClientArea.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FPanel pnlLog;
        private Core.FaUIs.FLogTextBox txtLog;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FNumericBox numFontSize;
    }
}
