namespace Nexplant.MC.SqlManager
{
    partial class FFormSelector
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
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnClose = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnActivate = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.grdList);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(520, 262);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnClose);
            this.pnlClient.Controls.Add(this.btnActivate);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnActivate, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnClose, 0);
            // 
            // grdList
            // 
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance10;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance30.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance30.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance30.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance30;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance31;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance32.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance32.BackColor2 = System.Drawing.SystemColors.Control;
            appearance32.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance32.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance32;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance33.BackColor = System.Drawing.SystemColors.Window;
            appearance33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance33;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance11;
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
            appearance39.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance39;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance12;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance43.BackColor = System.Drawing.SystemColors.Control;
            appearance43.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance43.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance43.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance43.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance43;
            appearance13.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance13.BackColor2 = System.Drawing.Color.Lavender;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.ForeColorDisabled = System.Drawing.Color.Black;
            appearance13.TextHAlignAsString = "Center";
            appearance13.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance13;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance12;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.BackColor2 = System.Drawing.Color.LightGray;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance14;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance46.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance46;
            this.grdList.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdList.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdList.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdList.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdList.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdList.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdList.DisplayLayout.UseFixedHeaders = true;
            this.grdList.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdList.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdList.Location = new System.Drawing.Point(0, 0);
            this.grdList.multiSelected = true;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(520, 262);
            this.grdList.TabIndex = 0;
            this.grdList.Text = "grdDataSet";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = false;
            this.grdList.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdList_DoubleClickRow);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnClose.Location = new System.Drawing.Point(334, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close(&C)";
            this.btnClose.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this.btnActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActivate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnActivate.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnActivate.Location = new System.Drawing.Point(242, 280);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(86, 28);
            this.btnActivate.TabIndex = 3;
            this.btnActivate.Text = "Activate(&A)";
            this.btnActivate.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(426, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // FFormSelector
            // 
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FFormSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Windows";
            this.Load += new System.EventHandler(this.FFormSelector_Load);
            this.Shown += new System.EventHandler(this.FFormSelector_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FGrid grdList;
        private Core.FaUIs.FButton btnClose;
        private Core.FaUIs.FButton btnActivate;
        private Core.FaUIs.FButton btnOk;
    }
}
