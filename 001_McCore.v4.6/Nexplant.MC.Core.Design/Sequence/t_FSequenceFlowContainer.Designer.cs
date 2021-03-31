namespace Nexplant.MC.Core.FaUIs
{
    partial class FSequenceFlowContainer
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.ufm = new Infragistics.Win.Misc.UltraFlowLayoutManager(this.components);
            this.pnlContainer = new Infragistics.Win.Misc.UltraPanel();
            this.grdScenario = new Nexplant.MC.Core.FaUIs.FGrid();
            ((System.ComponentModel.ISupportInitialize)(this.ufm)).BeginInit();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScenario)).BeginInit();
            this.SuspendLayout();
            // 
            // ufm
            // 
            this.ufm.ContainerControl = this.pnlContainer.ClientArea;
            this.ufm.HorizontalGap = 0;
            this.ufm.VerticalGap = 4;
            // 
            // pnlContainer
            // 
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            this.pnlContainer.Appearance = appearance6;
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContainer.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 24);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlContainer.Name = "pnlContainer";
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.pnlContainer.ScrollBarLook = scrollBarLook1;
            this.pnlContainer.Size = new System.Drawing.Size(374, 426);
            this.pnlContainer.TabIndex = 1;
            this.pnlContainer.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.pnlContainer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pnlContainer.PaintClient += new System.Windows.Forms.PaintEventHandler(this.pnlContainer_PaintClient);
            // 
            // grdScenario
            // 
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Appearance = appearance7;
            this.grdScenario.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdScenario.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdScenario.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance77.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance77.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance77.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance77.BorderColor = System.Drawing.SystemColors.Window;
            this.grdScenario.DisplayLayout.GroupByBox.Appearance = appearance77;
            appearance78.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdScenario.DisplayLayout.GroupByBox.BandLabelAppearance = appearance78;
            this.grdScenario.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance79.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance79.BackColor2 = System.Drawing.SystemColors.Control;
            appearance79.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance79.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdScenario.DisplayLayout.GroupByBox.PromptAppearance = appearance79;
            this.grdScenario.DisplayLayout.MaxColScrollRegions = 1;
            this.grdScenario.DisplayLayout.MaxRowScrollRegions = 1;
            appearance80.BackColor = System.Drawing.SystemColors.Window;
            appearance80.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdScenario.DisplayLayout.Override.ActiveCellAppearance = appearance80;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.ActiveRowAppearance = appearance8;
            this.grdScenario.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdScenario.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdScenario.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdScenario.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdScenario.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdScenario.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdScenario.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdScenario.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance82.BackColor = System.Drawing.SystemColors.Window;
            this.grdScenario.DisplayLayout.Override.CardAreaAppearance = appearance82;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdScenario.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdScenario.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.CellPadding = 0;
            this.grdScenario.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance84.BackColor = System.Drawing.SystemColors.Control;
            appearance84.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance84.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance84.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance84.BorderColor = System.Drawing.SystemColors.Window;
            this.grdScenario.DisplayLayout.Override.GroupByRowAppearance = appearance84;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdScenario.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdScenario.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdScenario.DisplayLayout.Override.RowAppearance = appearance9;
            this.grdScenario.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdScenario.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdScenario.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdScenario.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdScenario.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdScenario.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance87.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdScenario.DisplayLayout.Override.TemplateAddRowAppearance = appearance87;
            this.grdScenario.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdScenario.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdScenario.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdScenario.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdScenario.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdScenario.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdScenario.DisplayLayout.UseFixedHeaders = true;
            this.grdScenario.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdScenario.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdScenario.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdScenario.Location = new System.Drawing.Point(0, 0);
            this.grdScenario.multiSelected = false;
            this.grdScenario.Name = "grdScenario";
            this.grdScenario.Size = new System.Drawing.Size(374, 24);
            this.grdScenario.TabIndex = 2;
            this.grdScenario.Text = "fGrid1";
            this.grdScenario.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.valueCopyOfClickedCell = true;
            this.grdScenario.AfterRowActivate += new System.EventHandler(this.grdScenario_AfterRowActivate);
            this.grdScenario.Enter += new System.EventHandler(this.grdScenario_Enter);
            this.grdScenario.Leave += new System.EventHandler(this.grdScenario_Leave);
            this.grdScenario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdScenario_MouseDown);
            // 
            // FSequenceFlowContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.grdScenario);
            this.Name = "FSequenceFlowContainer";
            this.Size = new System.Drawing.Size(374, 450);
            this.Load += new System.EventHandler(this.FSequenceFlowContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ufm)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScenario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraFlowLayoutManager ufm;
        private Infragistics.Win.Misc.UltraPanel pnlContainer;
        private FGrid grdScenario;
    }
}
