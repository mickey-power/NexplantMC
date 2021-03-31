namespace Nexplant.MC.AdminManager
{
    partial class FSecsInterfaceObjectLogViewer
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab1 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab2 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinEditors.SpinEditorButton spinEditorButton1 = new Infragistics.Win.UltraWinEditors.SpinEditorButton();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FSecsInterfaceObjectLogViewer));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.tvwTree = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.ultraTabPageControl3 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.txtLog = new Nexplant.MC.Core.FaUIs.FLogTextBox();
            this.pnlLog = new Nexplant.MC.Core.FaUIs.FPanel();
            this.ClientArea_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.fTab1 = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.numFontSize = new Nexplant.MC.Core.FaUIs.FNumericBox();
            this.grdFilter = new Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider(this.components);
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).BeginInit();
            this.ultraTabPageControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).BeginInit();
            this.pnlLog.ClientArea.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.ClientArea_Fill_Panel.ClientArea.SuspendLayout();
            this.ClientArea_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).BeginInit();
            this.fTab1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlLog);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.tvwTree);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(974, 503);
            // 
            // tvwTree
            // 
            this.tvwTree.AllowDrop = true;
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            this.tvwTree.Appearance = appearance5;
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
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance6;
            _override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            _override1.ItemHeight = 18;
            _override1.Multiline = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.ForeColor = System.Drawing.Color.Black;
            _override1.NodeAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BackColor2 = System.Drawing.Color.LightGray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance8.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance8;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended;
            _override1.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            _override1.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwTree.ScrollBarLook = scrollBarLook1;
            this.tvwTree.Size = new System.Drawing.Size(974, 503);
            this.tvwTree.TabIndex = 2;
            this.tvwTree.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwTree.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabPageControl3
            // 
            this.ultraTabPageControl3.Controls.Add(this.txtLog);
            this.ultraTabPageControl3.Controls.Add(this.numFontSize);
            this.ultraTabPageControl3.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl3.Name = "ultraTabPageControl3";
            this.ultraTabPageControl3.Size = new System.Drawing.Size(974, 503);
            // 
            // txtLog
            // 
            this.txtLog.AlwaysInEditMode = true;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Appearance = appearance9;
            this.txtLog.AutoSize = false;
            this.txtLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtLog.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtLog.HideSelection = false;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.MaxLength = 2147483647;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(974, 503);
            this.txtLog.TabIndex = 19;
            this.txtLog.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtLog.WordWrap = false;
            // 
            // pnlLog
            // 
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlLog.Appearance = appearance1;
            // 
            // pnlLog.ClientArea
            // 
            this.pnlLog.ClientArea.Controls.Add(this.ClientArea_Fill_Panel);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Location = new System.Drawing.Point(4, 4);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(976, 527);
            this.pnlLog.TabIndex = 19;
            // 
            // ClientArea_Fill_Panel
            // 
            // 
            // ClientArea_Fill_Panel.ClientArea
            // 
            this.ClientArea_Fill_Panel.ClientArea.Controls.Add(this.fTab1);
            this.ClientArea_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClientArea_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientArea_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.ClientArea_Fill_Panel.Name = "ClientArea_Fill_Panel";
            this.ClientArea_Fill_Panel.Size = new System.Drawing.Size(976, 527);
            this.ClientArea_Fill_Panel.TabIndex = 0;
            // 
            // fTab1
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.fTab1.ActiveTabAppearance = appearance2;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Silver;
            this.fTab1.Appearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            this.fTab1.ClientAreaAppearance = appearance4;
            this.fTab1.Controls.Add(this.ultraTabSharedControlsPage2);
            this.fTab1.Controls.Add(this.ultraTabPageControl1);
            this.fTab1.Controls.Add(this.ultraTabPageControl3);
            this.fTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fTab1.Location = new System.Drawing.Point(0, 0);
            this.fTab1.Name = "fTab1";
            this.fTab1.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance12.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance12.BackColor2 = System.Drawing.Color.Lavender;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.fTab1.SelectedTabAppearance = appearance12;
            this.fTab1.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.fTab1.Size = new System.Drawing.Size(976, 527);
            this.fTab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.fTab1.TabIndex = 15;
            ultraTab1.TabPage = this.ultraTabPageControl1;
            ultraTab1.Text = "Object Log";
            ultraTab2.TabPage = this.ultraTabPageControl3;
            ultraTab2.Text = "Text Log";
            this.fTab1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab1,
            ultraTab2});
            this.fTab1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.fTab1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(974, 503);
            // 
            // numFontSize
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            this.numFontSize.Appearance = appearance10;
            this.numFontSize.AutoSize = false;
            this.numFontSize.BackColor = System.Drawing.Color.White;
            appearance11.BackColor = System.Drawing.Color.White;
            appearance11.ForeColor = System.Drawing.Color.DimGray;
            spinEditorButton1.Appearance = appearance11;
            this.numFontSize.ButtonsRight.Add(spinEditorButton1);
            this.numFontSize.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.numFontSize.Font = new System.Drawing.Font("Verdana", 9F);
            this.numFontSize.Location = new System.Drawing.Point(180, 202);
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.PromptChar = ' ';
            this.numFontSize.Size = new System.Drawing.Size(63, 20);
            this.numFontSize.TabIndex = 10;
            this.numFontSize.TabStop = false;
            this.numFontSize.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.numFontSize.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FSecsInterfaceObjectLogViewer
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FSecsInterfaceObjectLogViewer";
            this.Text = "SECS Interface Object Log Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FSecsInterfaceLogViewer_FormClosing);
            this.Load += new System.EventHandler(this.FSecsInterfaceLogViewer_Load);
            this.Shown += new System.EventHandler(this.FSecsInterfaceLogViewer_Shown);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).EndInit();
            this.ultraTabPageControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLog)).EndInit();
            this.pnlLog.ClientArea.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.ClientArea_Fill_Panel.ClientArea.ResumeLayout(false);
            this.ClientArea_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).EndInit();
            this.fTab1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.SupportDialogs.FilterUIProvider.UltraGridFilterUIProvider grdFilter;
        private Core.FaUIs.FPanel pnlLog;
        private Infragistics.Win.Misc.UltraPanel ClientArea_Fill_Panel;
        private Core.FaUIs.FTreeView tvwTree;
        private Core.FaUIs.FTab fTab1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl3;
        private Core.FaUIs.FNumericBox numFontSize;
        private Core.FaUIs.FLogTextBox txtLog;
    }
}
