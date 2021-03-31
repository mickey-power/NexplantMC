namespace Nexplant.MC.Core.FaUIs
{
    partial class FBaseTabMdiChildForm
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
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this._FFormBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FFormBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FFormBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FFormBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlClient = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this;
            this.mnuMenu.DockWithinContainerBaseType = typeof(Nexplant.MC.Core.FaUIs.FBaseForm);
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // _FFormBase_Toolbars_Dock_Area_Left
            // 
            this._FFormBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FFormBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FFormBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._FFormBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FFormBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._FFormBase_Toolbars_Dock_Area_Left.Name = "_FFormBase_Toolbars_Dock_Area_Left";
            this._FFormBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 440);
            this._FFormBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _FFormBase_Toolbars_Dock_Area_Right
            // 
            this._FFormBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FFormBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FFormBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._FFormBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FFormBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(524, 0);
            this._FFormBase_Toolbars_Dock_Area_Right.Name = "_FFormBase_Toolbars_Dock_Area_Right";
            this._FFormBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 440);
            this._FFormBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _FFormBase_Toolbars_Dock_Area_Top
            // 
            this._FFormBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FFormBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FFormBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._FFormBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FFormBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._FFormBase_Toolbars_Dock_Area_Top.Name = "_FFormBase_Toolbars_Dock_Area_Top";
            this._FFormBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(524, 0);
            this._FFormBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _FFormBase_Toolbars_Dock_Area_Bottom
            // 
            this._FFormBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FFormBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FFormBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._FFormBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FFormBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 440);
            this._FFormBase_Toolbars_Dock_Area_Bottom.Name = "_FFormBase_Toolbars_Dock_Area_Bottom";
            this._FFormBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(524, 0);
            this._FFormBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // pnlClient
            // 
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 0);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(524, 440);
            this.pnlClient.TabIndex = 4;
            // 
            // FBaseTabMdiChildForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(524, 440);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this._FFormBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._FFormBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._FFormBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._FFormBase_Toolbars_Dock_Area_Top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FBaseTabMdiChildForm";
            this.Text = "Nexplant MC TAB MDI Child Form Base";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBaseTabMdiChildForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FFormBase_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FFormBase_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FFormBase_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FFormBase_Toolbars_Dock_Area_Bottom;
        protected FToolbarsManager mnuMenu;
        protected System.Windows.Forms.Panel pnlClient;
    }
}
