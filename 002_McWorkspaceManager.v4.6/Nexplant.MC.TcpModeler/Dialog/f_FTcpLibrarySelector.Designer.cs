namespace Nexplant.MC.TcpModeler
{
    partial class FTcpLibrarySelector
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
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
            this.grdTcpLibrary = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnReset = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnNext = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnPrevious = new Nexplant.MC.Core.FaUIs.FButton();
            this.grdTcpLibraryGroup = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTcpLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTcpLibraryGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.grdTcpLibraryGroup);
            this.pnlDialogClient.Controls.Add(this.grdTcpLibrary);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(520, 262);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnNext);
            this.pnlClient.Controls.Add(this.btnPrevious);
            this.pnlClient.Controls.Add(this.btnReset);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnReset, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnPrevious, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnNext, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // grdTcpLibrary
            // 
            this.grdTcpLibrary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.grdTcpLibrary.DisplayLayout.Appearance = appearance13;
            this.grdTcpLibrary.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdTcpLibrary.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibrary.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibrary.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdTcpLibrary.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.grdTcpLibrary.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdTcpLibrary.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdTcpLibrary.DisplayLayout.MaxColScrollRegions = 1;
            this.grdTcpLibrary.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTcpLibrary.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance18.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.grdTcpLibrary.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.grdTcpLibrary.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdTcpLibrary.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdTcpLibrary.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdTcpLibrary.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdTcpLibrary.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdTcpLibrary.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibrary.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibrary.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibrary.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.grdTcpLibrary.DisplayLayout.Override.CellAppearance = appearance20;
            this.grdTcpLibrary.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdTcpLibrary.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.DisplayLayout.Override.CellPadding = 0;
            this.grdTcpLibrary.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibrary.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance22.BackColor2 = System.Drawing.Color.Lavender;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            this.grdTcpLibrary.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grdTcpLibrary.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdTcpLibrary.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdTcpLibrary.DisplayLayout.Override.RowAppearance = appearance20;
            this.grdTcpLibrary.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdTcpLibrary.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance23.BackColor2 = System.Drawing.Color.LightGray;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.grdTcpLibrary.DisplayLayout.Override.SelectedRowAppearance = appearance23;
            this.grdTcpLibrary.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibrary.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibrary.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibrary.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdTcpLibrary.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grdTcpLibrary.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdTcpLibrary.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdTcpLibrary.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdTcpLibrary.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdTcpLibrary.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdTcpLibrary.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdTcpLibrary.DisplayLayout.UseFixedHeaders = true;
            this.grdTcpLibrary.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdTcpLibrary.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdTcpLibrary.Location = new System.Drawing.Point(2, 2);
            this.grdTcpLibrary.multiSelected = false;
            this.grdTcpLibrary.Name = "grdTcpLibrary";
            this.grdTcpLibrary.Size = new System.Drawing.Size(516, 258);
            this.grdTcpLibrary.TabIndex = 1;
            this.grdTcpLibrary.Text = "fGrid1";
            this.grdTcpLibrary.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdTcpLibrary.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibrary.valueCopyOfClickedCell = false;
            this.grdTcpLibrary.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdCommon_DoubleClickRow);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(334, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnReset.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReset.Enabled = false;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnReset.Location = new System.Drawing.Point(12, 280);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(86, 28);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset(&R)";
            this.btnReset.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnNext.Location = new System.Drawing.Point(242, 280);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(86, 28);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next(&N)";
            this.btnNext.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnPrevious.Location = new System.Drawing.Point(150, 280);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(86, 28);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous(&P)";
            this.btnPrevious.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // grdTcpLibraryGroup
            // 
            this.grdTcpLibraryGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdTcpLibraryGroup.DisplayLayout.Appearance = appearance1;
            this.grdTcpLibraryGroup.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdTcpLibraryGroup.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibraryGroup.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibraryGroup.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdTcpLibraryGroup.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdTcpLibraryGroup.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdTcpLibraryGroup.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdTcpLibraryGroup.DisplayLayout.MaxColScrollRegions = 1;
            this.grdTcpLibraryGroup.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdTcpLibraryGroup.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdTcpLibraryGroup.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibraryGroup.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdTcpLibraryGroup.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibraryGroup.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdTcpLibraryGroup.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdTcpLibraryGroup.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdTcpLibraryGroup.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.DisplayLayout.Override.CellPadding = 0;
            this.grdTcpLibraryGroup.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdTcpLibraryGroup.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdTcpLibraryGroup.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdTcpLibraryGroup.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdTcpLibraryGroup.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdTcpLibraryGroup.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdTcpLibraryGroup.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdTcpLibraryGroup.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdTcpLibraryGroup.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdTcpLibraryGroup.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdTcpLibraryGroup.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdTcpLibraryGroup.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdTcpLibraryGroup.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdTcpLibraryGroup.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdTcpLibraryGroup.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdTcpLibraryGroup.DisplayLayout.UseFixedHeaders = true;
            this.grdTcpLibraryGroup.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdTcpLibraryGroup.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdTcpLibraryGroup.Location = new System.Drawing.Point(2, 2);
            this.grdTcpLibraryGroup.multiSelected = false;
            this.grdTcpLibraryGroup.Name = "grdTcpLibraryGroup";
            this.grdTcpLibraryGroup.Size = new System.Drawing.Size(516, 258);
            this.grdTcpLibraryGroup.TabIndex = 0;
            this.grdTcpLibraryGroup.Text = "Library Group";
            this.grdTcpLibraryGroup.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdTcpLibraryGroup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdTcpLibraryGroup.valueCopyOfClickedCell = false;
            this.grdTcpLibraryGroup.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdCommon_DoubleClickRow);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(426, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // FTcpLibrarySelector
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTcpLibrarySelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TCP Library Selector";
            this.Load += new System.EventHandler(this.FTcpLibrarySelector_Load);
            this.Shown += new System.EventHandler(this.FTcpLibrarySelector_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTcpLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTcpLibraryGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FGrid grdTcpLibrary;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnReset;
        private Core.FaUIs.FButton btnNext;
        private Core.FaUIs.FButton btnPrevious;
        private Core.FaUIs.FGrid grdTcpLibraryGroup;
        private Core.FaUIs.FButton btnCancel;


    }
}
