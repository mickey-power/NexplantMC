namespace Nexplant.MC.Core.FaUIs
{
    partial class FBaseRibbonMdiForm
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FRibbonToolbarsManager(this.components);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tmmTab = new Nexplant.MC.Core.FaUIs.FTabbedMdiManager(this.components);
            this.stbStatus = new Nexplant.MC.Core.FaUIs.FStatusBar();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmmTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stbStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // _FRibbonMdiFormBase_Toolbars_Dock_Area_Left
            // 
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.InitialResizeAreaExtent = 8;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 53);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.Name = "_FRibbonMdiFormBase_Toolbars_Dock_Area_Left";
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(8, 392);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this;
            this.mnuMenu.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.Office2007UICompatibility = false;
            this.mnuMenu.Ribbon.QuickAccessToolbar.Visible = false;
            this.mnuMenu.Ribbon.Visible = true;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _FRibbonMdiFormBase_Toolbars_Dock_Area_Right
            // 
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.InitialResizeAreaExtent = 8;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(647, 53);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.Name = "_FRibbonMdiFormBase_Toolbars_Dock_Area_Right";
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(8, 392);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _FRibbonMdiFormBase_Toolbars_Dock_Area_Top
            // 
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.Name = "_FRibbonMdiFormBase_Toolbars_Dock_Area_Top";
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(655, 53);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom
            // 
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.InitialResizeAreaExtent = 8;
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 445);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.Name = "_FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom";
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(655, 8);
            this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // tmmTab
            // 
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.tmmTab.Appearance = appearance3;
            this.tmmTab.MdiParent = this;
            this.tmmTab.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tmmTab.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tmmTab.ViewStyle = Infragistics.Win.UltraWinTabbedMdi.ViewStyle.Office2007;
            // 
            // stbStatus
            // 
            appearance1.FontData.Name = "Verdana";
            appearance1.FontData.SizeInPoints = 8.25F;
            this.stbStatus.Appearance = appearance1;
            this.stbStatus.BorderStylePanel = Infragistics.Win.UIElementBorderStyle.Solid;
            this.stbStatus.Location = new System.Drawing.Point(8, 422);
            this.stbStatus.Name = "stbStatus";
            appearance2.BorderColor = System.Drawing.Color.White;
            this.stbStatus.PanelAppearance = appearance2;
            this.stbStatus.Size = new System.Drawing.Size(639, 23);
            this.stbStatus.TabIndex = 6;
            this.stbStatus.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.stbStatus.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2007;
            // 
            // FBaseRibbonMdiForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(655, 453);
            this.Controls.Add(this.stbStatus);
            this.Controls.Add(this._FRibbonMdiFormBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._FRibbonMdiFormBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._FRibbonMdiFormBase_Toolbars_Dock_Area_Top);
            this.IsMdiContainer = true;
            this.Name = "FBaseRibbonMdiForm";
            this.Text = "Nexplant MC Ribbon MDI Form Base";
            this.Load += new System.EventHandler(this.FBaseRibbonMdiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmmTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stbStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FRibbonMdiFormBase_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FRibbonMdiFormBase_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FRibbonMdiFormBase_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FRibbonMdiFormBase_Toolbars_Dock_Area_Bottom;
        protected FRibbonToolbarsManager mnuMenu;
        protected FTabbedMdiManager tmmTab;
        protected FStatusBar stbStatus;
    }
}