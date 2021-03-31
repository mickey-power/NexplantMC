namespace Nexplant.MC.AdminManager
{
    partial class FComponentVersionSelector
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
            this.pnlStep1 = new Infragistics.Win.Misc.UltraPanel();
            this.grdComponent = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstCom = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pnlStep2 = new Infragistics.Win.Misc.UltraPanel();
            this.rstComVer = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.grdComponentVer = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnNext = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnPrevious = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnReset = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlStep1.ClientArea.SuspendLayout();
            this.pnlStep1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComponent)).BeginInit();
            this.pnlStep2.ClientArea.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComponentVer)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.pnlStep1);
            this.pnlDialogClient.Controls.Add(this.pnlStep2);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(519, 262);
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
            // pnlStep1
            // 
            // 
            // pnlStep1.ClientArea
            // 
            this.pnlStep1.ClientArea.Controls.Add(this.grdComponent);
            this.pnlStep1.ClientArea.Controls.Add(this.rstCom);
            this.pnlStep1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep1.Location = new System.Drawing.Point(0, 0);
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(519, 262);
            this.pnlStep1.TabIndex = 0;
            // 
            // grdComponent
            // 
            this.grdComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdComponent.DisplayLayout.Appearance = appearance1;
            this.grdComponent.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdComponent.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponent.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdComponent.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdComponent.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdComponent.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdComponent.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdComponent.DisplayLayout.MaxColScrollRegions = 1;
            this.grdComponent.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdComponent.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdComponent.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdComponent.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdComponent.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdComponent.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdComponent.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdComponent.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdComponent.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponent.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponent.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdComponent.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdComponent.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdComponent.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdComponent.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.DisplayLayout.Override.CellPadding = 0;
            this.grdComponent.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdComponent.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdComponent.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdComponent.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdComponent.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdComponent.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdComponent.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdComponent.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdComponent.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdComponent.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponent.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponent.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponent.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdComponent.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdComponent.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdComponent.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdComponent.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdComponent.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdComponent.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdComponent.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdComponent.DisplayLayout.UseFixedHeaders = true;
            this.grdComponent.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdComponent.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdComponent.Location = new System.Drawing.Point(2, 25);
            this.grdComponent.multiSelected = false;
            this.grdComponent.Name = "grdComponent";
            this.grdComponent.Size = new System.Drawing.Size(515, 235);
            this.grdComponent.TabIndex = 0;
            this.grdComponent.Text = "Library Group";
            this.grdComponent.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdComponent.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponent.valueCopyOfClickedCell = false;
            this.grdComponent.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdCommon_DoubleClickRow);
            // 
            // rstCom
            // 
            this.rstCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstCom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstCom.Location = new System.Drawing.Point(2, 2);
            this.rstCom.Name = "rstCom";
            this.rstCom.refreshEnabled = true;
            this.rstCom.Size = new System.Drawing.Size(515, 23);
            this.rstCom.TabIndex = 8;
            this.rstCom.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstCommon_RefreshRequested);
            this.rstCom.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstCommon_SearchRequested);
            // 
            // pnlStep2
            // 
            // 
            // pnlStep2.ClientArea
            // 
            this.pnlStep2.ClientArea.Controls.Add(this.rstComVer);
            this.pnlStep2.ClientArea.Controls.Add(this.grdComponentVer);
            this.pnlStep2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStep2.Location = new System.Drawing.Point(0, 0);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(519, 262);
            this.pnlStep2.TabIndex = 1;
            this.pnlStep2.Visible = false;
            // 
            // rstComVer
            // 
            this.rstComVer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstComVer.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstComVer.Location = new System.Drawing.Point(2, 2);
            this.rstComVer.Name = "rstComVer";
            this.rstComVer.refreshEnabled = true;
            this.rstComVer.Size = new System.Drawing.Size(515, 23);
            this.rstComVer.TabIndex = 9;
            this.rstComVer.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstCommon_RefreshRequested);
            this.rstComVer.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstCommon_SearchRequested);
            // 
            // grdComponentVer
            // 
            this.grdComponentVer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.grdComponentVer.DisplayLayout.Appearance = appearance13;
            this.grdComponentVer.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdComponentVer.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponentVer.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.grdComponentVer.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdComponentVer.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.grdComponentVer.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdComponentVer.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.grdComponentVer.DisplayLayout.MaxColScrollRegions = 1;
            this.grdComponentVer.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdComponentVer.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance18.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.grdComponentVer.DisplayLayout.Override.ActiveRowAppearance = appearance18;
            this.grdComponentVer.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdComponentVer.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdComponentVer.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdComponentVer.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdComponentVer.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdComponentVer.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponentVer.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdComponentVer.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            this.grdComponentVer.DisplayLayout.Override.CardAreaAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.grdComponentVer.DisplayLayout.Override.CellAppearance = appearance20;
            this.grdComponentVer.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdComponentVer.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.DisplayLayout.Override.CellPadding = 0;
            this.grdComponentVer.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance21.BackColor = System.Drawing.SystemColors.Control;
            appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.BorderColor = System.Drawing.SystemColors.Window;
            this.grdComponentVer.DisplayLayout.Override.GroupByRowAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance22.BackColor2 = System.Drawing.Color.Lavender;
            appearance22.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            appearance22.TextHAlignAsString = "Center";
            appearance22.TextVAlignAsString = "Middle";
            this.grdComponentVer.DisplayLayout.Override.HeaderAppearance = appearance22;
            this.grdComponentVer.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdComponentVer.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdComponentVer.DisplayLayout.Override.RowAppearance = appearance20;
            this.grdComponentVer.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdComponentVer.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance23.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance23.BackColor2 = System.Drawing.Color.LightGray;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.grdComponentVer.DisplayLayout.Override.SelectedRowAppearance = appearance23;
            this.grdComponentVer.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponentVer.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponentVer.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdComponentVer.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance24.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdComponentVer.DisplayLayout.Override.TemplateAddRowAppearance = appearance24;
            this.grdComponentVer.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdComponentVer.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdComponentVer.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdComponentVer.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdComponentVer.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdComponentVer.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdComponentVer.DisplayLayout.UseFixedHeaders = true;
            this.grdComponentVer.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdComponentVer.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdComponentVer.Location = new System.Drawing.Point(2, 25);
            this.grdComponentVer.multiSelected = false;
            this.grdComponentVer.Name = "grdComponentVer";
            this.grdComponentVer.Size = new System.Drawing.Size(515, 235);
            this.grdComponentVer.TabIndex = 1;
            this.grdComponentVer.Text = "Library Group";
            this.grdComponentVer.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdComponentVer.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdComponentVer.valueCopyOfClickedCell = false;
            this.grdComponentVer.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdCommon_DoubleClickRow);
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
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
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
            this.btnNext.TabIndex = 4;
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
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "Previous(&P)";
            this.btnPrevious.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
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
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset(&R)";
            this.btnReset.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FComponentVersionSelector
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FComponentVersionSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Component Version Selector";
            this.Load += new System.EventHandler(this.FComponentVersionSelector_Load);
            this.Shown += new System.EventHandler(this.FComponentVersionSelector_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FComponentVersionSelector_KeyDown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.pnlStep1.ClientArea.ResumeLayout(false);
            this.pnlStep1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComponent)).EndInit();
            this.pnlStep2.ClientArea.ResumeLayout(false);
            this.pnlStep2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComponentVer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraPanel pnlStep1;
        private Core.FaUIs.FRefreshAndSearchToolbar rstCom;
        private Core.FaUIs.FGrid grdComponent;
        private Infragistics.Win.Misc.UltraPanel pnlStep2;
        private Core.FaUIs.FGrid grdComponentVer;
        private Core.FaUIs.FRefreshAndSearchToolbar rstComVer;
        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnNext;
        private Core.FaUIs.FButton btnPrevious;
        private Core.FaUIs.FButton btnReset;
        private Core.FaUIs.FButton btnOk;



    }
}
