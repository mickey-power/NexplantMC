namespace Nexplant.MC.Core.FaUIs
{
    partial class FTextSearcher
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
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnClose = new Nexplant.MC.Core.FaUIs.FButton();
            this.lblTotalCount = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblTotalCountValue = new Nexplant.MC.Core.FaUIs.FValueLabel();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.grdList);
            this.pnlDialogClient.Controls.Add(this.rstToolbar);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(517, 225);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lblTotalCountValue);
            this.pnlClient.Controls.Add(this.lblTotalCount);
            this.pnlClient.Controls.Add(this.btnClose);
            this.pnlClient.Size = new System.Drawing.Size(521, 278);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnClose, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblTotalCount, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblTotalCountValue, 0);
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(2, 2);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = true;
            this.rstToolbar.Size = new System.Drawing.Size(513, 21);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstToolbar_SearchRequested);
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance1;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance6;
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
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
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
            this.grdList.Location = new System.Drawing.Point(2, 25);
            this.grdList.multiSelected = false;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(513, 198);
            this.grdList.TabIndex = 2;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = true;
            this.grdList.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdList_DoubleClickRow);
            this.grdList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdList_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnClose.Location = new System.Drawing.Point(423, 243);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close(&C)";
            this.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance14.ForeColor = System.Drawing.Color.DimGray;
            appearance14.TextVAlignAsString = "Middle";
            this.lblTotalCount.Appearance = appearance14;
            this.lblTotalCount.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTotalCount.Location = new System.Drawing.Point(7, 246);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(94, 21);
            this.lblTotalCount.TabIndex = 4;
            this.lblTotalCount.Text = "Total Count :";
            this.lblTotalCount.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblTotalCountValue
            // 
            this.lblTotalCountValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            appearance13.ForeColor = System.Drawing.Color.DimGray;
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.lblTotalCountValue.Appearance = appearance13;
            this.lblTotalCountValue.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTotalCountValue.Location = new System.Drawing.Point(98, 246);
            this.lblTotalCountValue.Name = "lblTotalCountValue";
            this.lblTotalCountValue.Size = new System.Drawing.Size(96, 21);
            this.lblTotalCountValue.TabIndex = 5;
            this.lblTotalCountValue.Text = "0";
            this.lblTotalCountValue.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FTextSearcher
            // 
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(521, 305);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTextSearcher";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.FTextSearcher_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTextSearcher_KeyDown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FRefreshAndSearchToolbar rstToolbar;
        private FGrid grdList;
        private FButton btnClose;
        private FLabel lblTotalCount;
        private FValueLabel lblTotalCountValue;

    }
}
