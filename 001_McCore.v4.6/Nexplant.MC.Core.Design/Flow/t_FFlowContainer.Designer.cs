namespace Nexplant.MC.Core.FaUIs
{
    partial class FFlowContainer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook3 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.pnlContainer = new Infragistics.Win.Misc.UltraPanel();
            this.pnlBody = new Infragistics.Win.Misc.UltraPanel();
            this.pnlHeader = new Infragistics.Win.Misc.UltraPanel();
            this.lblHost = new Infragistics.Win.Misc.UltraLabel();
            this.lblEap = new Infragistics.Win.Misc.UltraLabel();
            this.lblEq = new Infragistics.Win.Misc.UltraLabel();
            this.grdScenario = new Nexplant.MC.Core.FaUIs.FGrid();
            this.pnlContainer.ClientArea.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlHeader.ClientArea.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScenario)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.pnlContainer.Appearance = appearance1;
            this.pnlContainer.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlContainer.ClientArea
            // 
            this.pnlContainer.ClientArea.Controls.Add(this.pnlBody);
            this.pnlContainer.ClientArea.Controls.Add(this.pnlHeader);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            scrollBarLook3.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.pnlContainer.ScrollBarLook = scrollBarLook3;
            this.pnlContainer.Size = new System.Drawing.Size(527, 506);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlBody
            // 
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlBody.Appearance = appearance13;
            this.pnlBody.AutoScroll = true;
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 45);
            this.pnlBody.Name = "pnlBody";
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.pnlBody.ScrollBarLook = scrollBarLook1;
            this.pnlBody.Size = new System.Drawing.Size(525, 459);
            this.pnlBody.TabIndex = 1;
            this.pnlBody.UseAppStyling = false;
            this.pnlBody.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.pnlBody.PaintClient += new System.Windows.Forms.PaintEventHandler(this.pnlBody_PaintClient);
            this.pnlBody.Resize += new System.EventHandler(this.pnlBody_Resize);
            // 
            // pnlHeader
            // 
            // 
            // pnlHeader.ClientArea
            // 
            this.pnlHeader.ClientArea.Controls.Add(this.lblHost);
            this.pnlHeader.ClientArea.Controls.Add(this.lblEap);
            this.pnlHeader.ClientArea.Controls.Add(this.lblEq);
            this.pnlHeader.ClientArea.Controls.Add(this.grdScenario);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(525, 45);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.PaintClient += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_PaintClient);
            // 
            // lblHost
            // 
            appearance8.BackColor = System.Drawing.Color.White;
            appearance8.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Center";
            appearance8.TextVAlignAsString = "Middle";
            this.lblHost.Appearance = appearance8;
            this.lblHost.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.lblHost.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.Location = new System.Drawing.Point(264, 25);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(52, 18);
            this.lblHost.TabIndex = 6;
            this.lblHost.Text = "Host";
            // 
            // lblEap
            // 
            appearance10.BackColor = System.Drawing.Color.White;
            appearance10.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.lblEap.Appearance = appearance10;
            this.lblEap.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.lblEap.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEap.Location = new System.Drawing.Point(136, 25);
            this.lblEap.Name = "lblEap";
            this.lblEap.Size = new System.Drawing.Size(52, 18);
            this.lblEap.TabIndex = 5;
            this.lblEap.Text = "EAP";
            // 
            // lblEq
            // 
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.BackColor2 = System.Drawing.Color.Gainsboro;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.lblEq.Appearance = appearance12;
            this.lblEq.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Rounded1;
            this.lblEq.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEq.Location = new System.Drawing.Point(2, 25);
            this.lblEq.Name = "lblEq";
            this.lblEq.Size = new System.Drawing.Size(52, 18);
            this.lblEq.TabIndex = 4;
            this.lblEq.Text = "EQ";
            // 
            // grdScenario
            // 
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Appearance = appearance2;
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
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            appearance3.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.ActiveRowAppearance = appearance3;
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
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.CellAppearance = appearance4;
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
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BackColor2 = System.Drawing.Color.Lavender;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.ForeColorDisabled = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grdScenario.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdScenario.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdScenario.DisplayLayout.Override.RowAppearance = appearance4;
            this.grdScenario.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdScenario.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightGray;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdScenario.DisplayLayout.Override.SelectedRowAppearance = appearance6;
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
            this.grdScenario.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
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
            this.grdScenario.Size = new System.Drawing.Size(525, 20);
            this.grdScenario.TabIndex = 3;
            this.grdScenario.Text = "fGrid1";
            this.grdScenario.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdScenario.valueCopyOfClickedCell = true;
            this.grdScenario.Enter += new System.EventHandler(this.grdScenario_Enter);
            this.grdScenario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdScenario_MouseDown);
            // 
            // FFlowContainer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FFlowContainer";
            this.Size = new System.Drawing.Size(527, 506);
            this.Load += new System.EventHandler(this.FFlowContainer_Load);
            this.pnlContainer.ClientArea.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlHeader.ClientArea.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScenario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlContainer;
        private Infragistics.Win.Misc.UltraPanel pnlBody;
        private Infragistics.Win.Misc.UltraPanel pnlHeader;
        private FGrid grdScenario;
        private Infragistics.Win.Misc.UltraLabel lblHost;
        private Infragistics.Win.Misc.UltraLabel lblEap;
        private Infragistics.Win.Misc.UltraLabel lblEq;
    }
}
