namespace Nexplant.MC.AdminManager
{
    partial class FUserGroupAlertSelector
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
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.rstUrgToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.grdUserGroup = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstEvtToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.txtEventType = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblEventType = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.grdEvent = new Nexplant.MC.Core.FaUIs.FGrid();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).BeginInit();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEventType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.spcMain);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(740, 344);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(744, 397);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.Location = new System.Drawing.Point(2, 2);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.rstUrgToolbar);
            this.spcMain.Panel1.Controls.Add(this.grdUserGroup);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.rstEvtToolbar);
            this.spcMain.Panel2.Controls.Add(this.pnlCondition);
            this.spcMain.Panel2.Controls.Add(this.grdEvent);
            this.spcMain.Size = new System.Drawing.Size(736, 340);
            this.spcMain.SplitterDistance = 245;
            this.spcMain.TabIndex = 0;
            // 
            // rstUrgToolbar
            // 
            this.rstUrgToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstUrgToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstUrgToolbar.Location = new System.Drawing.Point(0, 0);
            this.rstUrgToolbar.Name = "rstUrgToolbar";
            this.rstUrgToolbar.refreshEnabled = true;
            this.rstUrgToolbar.Size = new System.Drawing.Size(245, 21);
            this.rstUrgToolbar.TabIndex = 5;
            this.rstUrgToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstUrgToolbar_RefreshRequested);
            this.rstUrgToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstUrgToolbar_SearchRequested);
            // 
            // grdUserGroup
            // 
            this.grdUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.grdUserGroup.DisplayLayout.Appearance = appearance1;
            this.grdUserGroup.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdUserGroup.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserGroup.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.grdUserGroup.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdUserGroup.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.grdUserGroup.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdUserGroup.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.grdUserGroup.DisplayLayout.MaxColScrollRegions = 1;
            this.grdUserGroup.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdUserGroup.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextVAlignAsString = "Middle";
            this.grdUserGroup.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.grdUserGroup.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdUserGroup.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdUserGroup.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdUserGroup.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdUserGroup.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdUserGroup.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserGroup.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserGroup.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.grdUserGroup.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdUserGroup.DisplayLayout.Override.CellAppearance = appearance8;
            this.grdUserGroup.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdUserGroup.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.DisplayLayout.Override.CellPadding = 0;
            this.grdUserGroup.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.grdUserGroup.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance10.BackColor2 = System.Drawing.Color.Lavender;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            appearance10.TextHAlignAsString = "Center";
            appearance10.TextVAlignAsString = "Middle";
            this.grdUserGroup.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.grdUserGroup.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdUserGroup.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdUserGroup.DisplayLayout.Override.RowAppearance = appearance8;
            this.grdUserGroup.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdUserGroup.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance11.BackColor2 = System.Drawing.Color.LightGray;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.TextVAlignAsString = "Middle";
            this.grdUserGroup.DisplayLayout.Override.SelectedRowAppearance = appearance11;
            this.grdUserGroup.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserGroup.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserGroup.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserGroup.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdUserGroup.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.grdUserGroup.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdUserGroup.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdUserGroup.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdUserGroup.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdUserGroup.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdUserGroup.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdUserGroup.DisplayLayout.UseFixedHeaders = true;
            this.grdUserGroup.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdUserGroup.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdUserGroup.Location = new System.Drawing.Point(0, 23);
            this.grdUserGroup.multiSelected = false;
            this.grdUserGroup.Name = "grdUserGroup";
            this.grdUserGroup.Size = new System.Drawing.Size(245, 319);
            this.grdUserGroup.TabIndex = 6;
            this.grdUserGroup.Text = "fGrid1";
            this.grdUserGroup.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdUserGroup.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserGroup.valueCopyOfClickedCell = false;
            this.grdUserGroup.AfterRowActivate += new System.EventHandler(this.grdUserGroup_AfterRowActivate);
            // 
            // rstEvtToolbar
            // 
            this.rstEvtToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstEvtToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstEvtToolbar.Location = new System.Drawing.Point(0, 31);
            this.rstEvtToolbar.Name = "rstEvtToolbar";
            this.rstEvtToolbar.refreshEnabled = true;
            this.rstEvtToolbar.Size = new System.Drawing.Size(487, 21);
            this.rstEvtToolbar.TabIndex = 3;
            this.rstEvtToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstEvtToolbar_RefreshRequested);
            this.rstEvtToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstEvtToolbar_SearchRequested);
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance13.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance13;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.txtEventType);
            this.pnlCondition.ClientArea.Controls.Add(this.lblEventType);
            this.pnlCondition.Location = new System.Drawing.Point(0, 0);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(487, 29);
            this.pnlCondition.TabIndex = 26;
            // 
            // txtEventType
            // 
            this.txtEventType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.BackColor = System.Drawing.Color.White;
            appearance14.BackColorDisabled = System.Drawing.Color.WhiteSmoke;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.txtEventType.Appearance = appearance14;
            this.txtEventType.AutoSize = false;
            this.txtEventType.BackColor = System.Drawing.Color.White;
            this.txtEventType.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtEventType.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtEventType.Enabled = false;
            this.txtEventType.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtEventType.Location = new System.Drawing.Point(124, 2);
            this.txtEventType.Name = "txtEventType";
            this.txtEventType.ReadOnly = true;
            this.txtEventType.Size = new System.Drawing.Size(359, 23);
            this.txtEventType.TabIndex = 14;
            this.txtEventType.TabStop = false;
            this.txtEventType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtEventType.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblEventType
            // 
            appearance15.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance15.BackColor2 = System.Drawing.Color.Lavender;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.lblEventType.Appearance = appearance15;
            this.lblEventType.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblEventType.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblEventType.Location = new System.Drawing.Point(2, 2);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(120, 23);
            this.lblEventType.TabIndex = 13;
            this.lblEventType.Text = "Event Type";
            this.lblEventType.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdEvent
            // 
            this.grdEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.grdEvent.DisplayLayout.Appearance = appearance16;
            this.grdEvent.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdEvent.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEvent.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEvent.DisplayLayout.GroupByBox.Appearance = appearance17;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEvent.DisplayLayout.GroupByBox.BandLabelAppearance = appearance18;
            this.grdEvent.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance19.BackColor2 = System.Drawing.SystemColors.Control;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance19.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdEvent.DisplayLayout.GroupByBox.PromptAppearance = appearance19;
            this.grdEvent.DisplayLayout.MaxColScrollRegions = 1;
            this.grdEvent.DisplayLayout.MaxRowScrollRegions = 1;
            appearance20.BackColor = System.Drawing.SystemColors.Window;
            appearance20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdEvent.DisplayLayout.Override.ActiveCellAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance21.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance21.BorderColor = System.Drawing.Color.Silver;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.grdEvent.DisplayLayout.Override.ActiveRowAppearance = appearance21;
            this.grdEvent.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdEvent.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdEvent.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdEvent.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdEvent.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdEvent.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEvent.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdEvent.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            this.grdEvent.DisplayLayout.Override.CardAreaAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.grdEvent.DisplayLayout.Override.CellAppearance = appearance23;
            this.grdEvent.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdEvent.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.DisplayLayout.Override.CellPadding = 0;
            this.grdEvent.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance24.BackColor = System.Drawing.SystemColors.Control;
            appearance24.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance24.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance24.BorderColor = System.Drawing.SystemColors.Window;
            this.grdEvent.DisplayLayout.Override.GroupByRowAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance25.BackColor2 = System.Drawing.Color.Lavender;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextHAlignAsString = "Center";
            appearance25.TextVAlignAsString = "Middle";
            this.grdEvent.DisplayLayout.Override.HeaderAppearance = appearance25;
            this.grdEvent.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdEvent.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdEvent.DisplayLayout.Override.RowAppearance = appearance23;
            this.grdEvent.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdEvent.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance26.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance26.BackColor2 = System.Drawing.Color.LightGray;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance26.BorderColor = System.Drawing.Color.Silver;
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.TextVAlignAsString = "Middle";
            this.grdEvent.DisplayLayout.Override.SelectedRowAppearance = appearance26;
            this.grdEvent.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEvent.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEvent.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdEvent.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance27.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdEvent.DisplayLayout.Override.TemplateAddRowAppearance = appearance27;
            this.grdEvent.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdEvent.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdEvent.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdEvent.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdEvent.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdEvent.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdEvent.DisplayLayout.UseFixedHeaders = true;
            this.grdEvent.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdEvent.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdEvent.Location = new System.Drawing.Point(0, 54);
            this.grdEvent.multiSelected = true;
            this.grdEvent.Name = "grdEvent";
            this.grdEvent.Size = new System.Drawing.Size(487, 286);
            this.grdEvent.TabIndex = 4;
            this.grdEvent.Text = "fGrid1";
            this.grdEvent.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdEvent.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdEvent.valueCopyOfClickedCell = false;
            this.grdEvent.AfterRowActivate += new System.EventHandler(this.grdEvent_AfterRowActivate);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(646, 362);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Enabled = false;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(554, 362);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FUserGroupAlertSelector
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(744, 424);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FUserGroupAlertSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Group Alert Selector";
            this.Load += new System.EventHandler(this.FUserGroupAlertSelector_Load);
            this.Shown += new System.EventHandler(this.FUserGroupAlertSelector_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FUserGroupAlertSelector_KeyDown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).EndInit();
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEventType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FGrid grdEvent;
        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTitleLabel lblEventType;
        private Core.FaUIs.FRefreshAndSearchToolbar rstEvtToolbar;
        private Core.FaUIs.FRefreshAndSearchToolbar rstUrgToolbar;
        private Core.FaUIs.FGrid grdUserGroup;
        private Core.FaUIs.FTextBox txtEventType;



    }
}
