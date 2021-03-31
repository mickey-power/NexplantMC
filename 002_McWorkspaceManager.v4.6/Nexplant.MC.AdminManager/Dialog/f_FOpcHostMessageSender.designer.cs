namespace Nexplant.MC.AdminManager
{
    partial class FOpcHostMessageSender
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
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.OptionSet optionSet1 = new Infragistics.Win.UltraWinToolbars.OptionSet("ScreenState");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnSend = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlItem = new Nexplant.MC.Core.FaUIs.FPanel();
            this.tvwTree = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.fSplitter = new Nexplant.MC.Core.FaUIs.FSplitter();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.lblTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenu_Fill_Panel = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.fLabel1 = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblSuccess = new Nexplant.MC.Core.FaUIs.FLabel();
            this.fLabel3 = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblFail = new Nexplant.MC.Core.FaUIs.FLabel();
            this.fLabel4 = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblSkip = new Nexplant.MC.Core.FaUIs.FLabel();
            this.fLabel2 = new Nexplant.MC.Core.FaUIs.FLabel();
            this.lblCancel = new Nexplant.MC.Core.FaUIs.FLabel();
            this.pnlCondition = new Nexplant.MC.Core.FaUIs.FPanel();
            this.lblCastChannel = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtCastChannel = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.txtStation = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.lblStation = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.lblModuleName = new Nexplant.MC.Core.FaUIs.FTitleLabel();
            this.txtModuleName = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlItem.ClientArea.SuspendLayout();
            this.pnlItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlCondition.ClientArea.SuspendLayout();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCastChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuleName)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.spcMain);
            this.pnlDialogClient.Controls.Add(this.pnlMenu);
            this.pnlDialogClient.Controls.Add(this.fSplitter);
            this.pnlDialogClient.Controls.Add(this.pnlItem);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(809, 434);
            this.pnlDialogClient.TabIndex = 2;
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lblCancel);
            this.pnlClient.Controls.Add(this.btnSend);
            this.pnlClient.Controls.Add(this.fLabel2);
            this.pnlClient.Controls.Add(this.lblSkip);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Controls.Add(this.fLabel4);
            this.pnlClient.Controls.Add(this.lblFail);
            this.pnlClient.Controls.Add(this.fLabel1);
            this.pnlClient.Controls.Add(this.fLabel3);
            this.pnlClient.Controls.Add(this.lblSuccess);
            this.pnlClient.Size = new System.Drawing.Size(814, 487);
            this.pnlClient.TabIndex = 0;
            this.pnlClient.Controls.SetChildIndex(this.lblSuccess, 0);
            this.pnlClient.Controls.SetChildIndex(this.fLabel3, 0);
            this.pnlClient.Controls.SetChildIndex(this.fLabel1, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblFail, 0);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.fLabel4, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblSkip, 0);
            this.pnlClient.Controls.SetChildIndex(this.fLabel2, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnSend, 0);
            this.pnlClient.Controls.SetChildIndex(this.lblCancel, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(720, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnSend.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnSend.Location = new System.Drawing.Point(628, 452);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(86, 28);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send(&S)";
            this.btnSend.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlItem
            // 
            appearance24.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlItem.Appearance = appearance24;
            // 
            // pnlItem.ClientArea
            // 
            this.pnlItem.ClientArea.Controls.Add(this.tvwTree);
            this.pnlItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlItem.Location = new System.Drawing.Point(0, 282);
            this.pnlItem.Name = "pnlItem";
            this.pnlItem.Size = new System.Drawing.Size(809, 152);
            this.pnlItem.TabIndex = 27;
            // 
            // tvwTree
            // 
            this.tvwTree.AllowDrop = true;
            this.tvwTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance25.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            this.tvwTree.Appearance = appearance25;
            this.tvwTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tvwTree.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.tvwTree.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Font = new System.Drawing.Font("Verdana", 9F);
            this.tvwTree.HideSelection = false;
            this.tvwTree.Location = new System.Drawing.Point(2, 0);
            this.tvwTree.multiSelected = false;
            this.tvwTree.Name = "tvwTree";
            this.tvwTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            appearance26.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance26.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance26.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance26;
            _override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            _override1.ItemHeight = 18;
            _override1.Multiline = Infragistics.Win.DefaultableBoolean.False;
            appearance27.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance27.ForeColor = System.Drawing.Color.Black;
            _override1.NodeAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance28.BackColor2 = System.Drawing.Color.LightGray;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance28.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance28;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.None;
            _override1.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            _override1.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Override = _override1;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwTree.ScrollBarLook = scrollBarLook2;
            this.tvwTree.Size = new System.Drawing.Size(805, 152);
            this.tvwTree.TabIndex = 3;
            this.tvwTree.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwTree.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fSplitter
            // 
            appearance22.BackColor = System.Drawing.Color.Transparent;
            this.fSplitter.Appearance = appearance22;
            this.fSplitter.BackColor = System.Drawing.Color.Transparent;
            this.fSplitter.BorderStyle = Infragistics.Win.UIElementBorderStyle.None;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.GlassBottom20;
            this.fSplitter.ButtonAppearance = appearance23;
            this.fSplitter.ButtonExtent = 100;
            this.fSplitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.fSplitter.Location = new System.Drawing.Point(0, 278);
            this.fSplitter.Name = "fSplitter";
            this.fSplitter.RestoreExtent = 152;
            this.fSplitter.Size = new System.Drawing.Size(809, 4);
            this.fSplitter.TabIndex = 21;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcMain.IsSplitterFixed = true;
            this.spcMain.Location = new System.Drawing.Point(0, 24);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.pnlCondition);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.lblTotal);
            this.spcMain.Panel2.Controls.Add(this.grdList);
            this.spcMain.Panel2.Controls.Add(this.rstToolbar);
            this.spcMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.spcMain.Panel2MinSize = 80;
            this.spcMain.Size = new System.Drawing.Size(809, 254);
            this.spcMain.SplitterDistance = 80;
            this.spcMain.SplitterWidth = 2;
            this.spcMain.TabIndex = 29;
            this.spcMain.TabStop = false;
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance9;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance10;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance11;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance12.BackColor2 = System.Drawing.SystemColors.Control;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance12.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance12;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance13.BackColor = System.Drawing.SystemColors.Window;
            appearance13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance14.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance14;
            this.grdList.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdList.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdList.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdList.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdList.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdList.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance15.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance16;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance17.BackColor = System.Drawing.SystemColors.Control;
            appearance17.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance17.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance17.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance17.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance17;
            appearance18.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance18.BackColor2 = System.Drawing.Color.Lavender;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            appearance18.TextHAlignAsString = "Center";
            appearance18.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance18;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance16;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance19.BackColor2 = System.Drawing.Color.LightGray;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance19;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance20.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance20;
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
            this.grdList.Location = new System.Drawing.Point(2, 24);
            this.grdList.multiSelected = false;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(805, 146);
            this.grdList.TabIndex = 2;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = false;
            this.grdList.AfterRowActivate += new System.EventHandler(this.grdList_AfterRowActivate);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.lblTotal.Appearance = appearance8;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTotal.Location = new System.Drawing.Point(729, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 21);
            this.lblTotal.TabIndex = 87;
            this.lblTotal.Text = "0";
            this.lblTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(2, 0);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = false;
            this.rstToolbar.Size = new System.Drawing.Size(722, 21);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.TabStop = false;
            this.rstToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstToolbar_SearchRequested);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlMenu;
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            optionSet1.AllowAllUp = false;
            this.mnuMenu.OptionSets.Add(optionSet1);
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFontNamesInFont = false;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool5});
            ultraToolbar1.ShowInToolbarList = false;
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance21.Image = global::Nexplant.MC.AdminManager.Properties.Resources.FileOpen;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance21;
            buttonTool17.SharedPropsInternal.Caption = "Open(&O)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool17});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.pnlMenu_Fill_Panel);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Left);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Right);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Bottom);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Top);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(809, 24);
            this.pnlMenu.TabIndex = 34;
            // 
            // pnlMenu_Fill_Panel
            // 
            this.pnlMenu_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.pnlMenu_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu_Fill_Panel.Location = new System.Drawing.Point(0, 24);
            this.pnlMenu_Fill_Panel.Name = "pnlMenu_Fill_Panel";
            this.pnlMenu_Fill_Panel.Size = new System.Drawing.Size(809, 0);
            this.pnlMenu_Fill_Panel.TabIndex = 0;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Left
            // 
            this._pnlMenu_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._pnlMenu_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 24);
            this._pnlMenu_Toolbars_Dock_Area_Left.Name = "_pnlMenu_Toolbars_Dock_Area_Left";
            this._pnlMenu_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 0);
            this._pnlMenu_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Right
            // 
            this._pnlMenu_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._pnlMenu_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(809, 24);
            this._pnlMenu_Toolbars_Dock_Area_Right.Name = "_pnlMenu_Toolbars_Dock_Area_Right";
            this._pnlMenu_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 0);
            this._pnlMenu_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Bottom
            // 
            this._pnlMenu_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 24);
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Name = "_pnlMenu_Toolbars_Dock_Area_Bottom";
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(809, 0);
            this._pnlMenu_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // _pnlMenu_Toolbars_Dock_Area_Top
            // 
            this._pnlMenu_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._pnlMenu_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._pnlMenu_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._pnlMenu_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._pnlMenu_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._pnlMenu_Toolbars_Dock_Area_Top.Name = "_pnlMenu_Toolbars_Dock_Area_Top";
            this._pnlMenu_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(809, 24);
            this._pnlMenu_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // fLabel1
            // 
            this.fLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance34.ForeColor = System.Drawing.Color.DimGray;
            appearance34.TextHAlignAsString = "Right";
            appearance34.TextVAlignAsString = "Middle";
            this.fLabel1.Appearance = appearance34;
            this.fLabel1.Font = new System.Drawing.Font("Verdana", 9F);
            this.fLabel1.Location = new System.Drawing.Point(163, 455);
            this.fLabel1.Name = "fLabel1";
            this.fLabel1.Size = new System.Drawing.Size(66, 22);
            this.fLabel1.TabIndex = 16;
            this.fLabel1.Text = "Success:";
            this.fLabel1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblSuccess
            // 
            this.lblSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance36.ForeColor = System.Drawing.Color.DimGray;
            appearance36.TextVAlignAsString = "Middle";
            this.lblSuccess.Appearance = appearance36;
            this.lblSuccess.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblSuccess.Location = new System.Drawing.Point(230, 455);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(42, 22);
            this.lblSuccess.TabIndex = 17;
            this.lblSuccess.Text = "0";
            this.lblSuccess.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fLabel3
            // 
            this.fLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance35.ForeColor = System.Drawing.Color.DimGray;
            appearance35.TextHAlignAsString = "Right";
            appearance35.TextVAlignAsString = "Middle";
            this.fLabel3.Appearance = appearance35;
            this.fLabel3.Font = new System.Drawing.Font("Verdana", 9F);
            this.fLabel3.Location = new System.Drawing.Point(279, 455);
            this.fLabel3.Name = "fLabel3";
            this.fLabel3.Size = new System.Drawing.Size(66, 22);
            this.fLabel3.TabIndex = 18;
            this.fLabel3.Text = "Fail:";
            this.fLabel3.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblFail
            // 
            this.lblFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance33.ForeColor = System.Drawing.Color.DimGray;
            appearance33.TextVAlignAsString = "Middle";
            this.lblFail.Appearance = appearance33;
            this.lblFail.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblFail.Location = new System.Drawing.Point(346, 455);
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(42, 22);
            this.lblFail.TabIndex = 19;
            this.lblFail.Text = "0";
            this.lblFail.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fLabel4
            // 
            this.fLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance32.ForeColor = System.Drawing.Color.DimGray;
            appearance32.TextHAlignAsString = "Right";
            appearance32.TextVAlignAsString = "Middle";
            this.fLabel4.Appearance = appearance32;
            this.fLabel4.Font = new System.Drawing.Font("Verdana", 9F);
            this.fLabel4.Location = new System.Drawing.Point(396, 455);
            this.fLabel4.Name = "fLabel4";
            this.fLabel4.Size = new System.Drawing.Size(66, 22);
            this.fLabel4.TabIndex = 20;
            this.fLabel4.Text = "Skip:";
            this.fLabel4.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblSkip
            // 
            this.lblSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance31.ForeColor = System.Drawing.Color.DimGray;
            appearance31.TextVAlignAsString = "Middle";
            this.lblSkip.Appearance = appearance31;
            this.lblSkip.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblSkip.Location = new System.Drawing.Point(463, 455);
            this.lblSkip.Name = "lblSkip";
            this.lblSkip.Size = new System.Drawing.Size(42, 22);
            this.lblSkip.TabIndex = 21;
            this.lblSkip.Text = "0";
            this.lblSkip.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // fLabel2
            // 
            this.fLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance30.ForeColor = System.Drawing.Color.DimGray;
            appearance30.TextHAlignAsString = "Right";
            appearance30.TextVAlignAsString = "Middle";
            this.fLabel2.Appearance = appearance30;
            this.fLabel2.Font = new System.Drawing.Font("Verdana", 9F);
            this.fLabel2.Location = new System.Drawing.Point(511, 455);
            this.fLabel2.Name = "fLabel2";
            this.fLabel2.Size = new System.Drawing.Size(66, 22);
            this.fLabel2.TabIndex = 20;
            this.fLabel2.Text = "Cancel:";
            this.fLabel2.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblCancel
            // 
            this.lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            appearance29.ForeColor = System.Drawing.Color.DimGray;
            appearance29.TextVAlignAsString = "Middle";
            this.lblCancel.Appearance = appearance29;
            this.lblCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblCancel.Location = new System.Drawing.Point(583, 455);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(42, 22);
            this.lblCancel.TabIndex = 21;
            this.lblCancel.Text = "0";
            this.lblCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.DarkGray;
            this.pnlCondition.Appearance = appearance1;
            this.pnlCondition.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // pnlCondition.ClientArea
            // 
            this.pnlCondition.ClientArea.Controls.Add(this.lblCastChannel);
            this.pnlCondition.ClientArea.Controls.Add(this.txtCastChannel);
            this.pnlCondition.ClientArea.Controls.Add(this.txtStation);
            this.pnlCondition.ClientArea.Controls.Add(this.lblStation);
            this.pnlCondition.ClientArea.Controls.Add(this.lblModuleName);
            this.pnlCondition.ClientArea.Controls.Add(this.txtModuleName);
            this.pnlCondition.Location = new System.Drawing.Point(2, 2);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(805, 77);
            this.pnlCondition.TabIndex = 35;
            // 
            // lblCastChannel
            // 
            appearance2.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance2.BackColor2 = System.Drawing.Color.Lavender;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.lblCastChannel.Appearance = appearance2;
            this.lblCastChannel.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblCastChannel.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblCastChannel.Location = new System.Drawing.Point(2, 50);
            this.lblCastChannel.Name = "lblCastChannel";
            this.lblCastChannel.Size = new System.Drawing.Size(120, 23);
            this.lblCastChannel.TabIndex = 4;
            this.lblCastChannel.Text = "Cast Channel";
            this.lblCastChannel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtCastChannel
            // 
            this.txtCastChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.BackColor = System.Drawing.Color.White;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.txtCastChannel.Appearance = appearance3;
            this.txtCastChannel.AutoSize = false;
            this.txtCastChannel.BackColor = System.Drawing.Color.White;
            this.txtCastChannel.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtCastChannel.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtCastChannel.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtCastChannel.Location = new System.Drawing.Point(123, 50);
            this.txtCastChannel.Name = "txtCastChannel";
            this.txtCastChannel.Size = new System.Drawing.Size(678, 23);
            this.txtCastChannel.TabIndex = 5;
            this.txtCastChannel.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtCastChannel.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtStation
            // 
            this.txtStation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.BackColor = System.Drawing.Color.White;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.txtStation.Appearance = appearance4;
            this.txtStation.AutoSize = false;
            this.txtStation.BackColor = System.Drawing.Color.White;
            this.txtStation.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtStation.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtStation.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtStation.Location = new System.Drawing.Point(123, 2);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(678, 23);
            this.txtStation.TabIndex = 1;
            this.txtStation.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtStation.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblStation
            // 
            appearance5.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance5.BackColor2 = System.Drawing.Color.Lavender;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextHAlignAsString = "Center";
            appearance5.TextVAlignAsString = "Middle";
            this.lblStation.Appearance = appearance5;
            this.lblStation.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblStation.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblStation.Location = new System.Drawing.Point(2, 2);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(120, 23);
            this.lblStation.TabIndex = 0;
            this.lblStation.Text = "Station";
            this.lblStation.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // lblModuleName
            // 
            appearance6.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance6.BackColor2 = System.Drawing.Color.Lavender;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.Color.Silver;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.lblModuleName.Appearance = appearance6;
            this.lblModuleName.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.Solid;
            this.lblModuleName.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblModuleName.Location = new System.Drawing.Point(2, 26);
            this.lblModuleName.Name = "lblModuleName";
            this.lblModuleName.Size = new System.Drawing.Size(120, 23);
            this.lblModuleName.TabIndex = 2;
            this.lblModuleName.Text = "Module Name";
            this.lblModuleName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // txtModuleName
            // 
            this.txtModuleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance7.BackColor = System.Drawing.Color.White;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            this.txtModuleName.Appearance = appearance7;
            this.txtModuleName.AutoSize = false;
            this.txtModuleName.BackColor = System.Drawing.Color.White;
            this.txtModuleName.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.txtModuleName.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtModuleName.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtModuleName.Location = new System.Drawing.Point(123, 26);
            this.txtModuleName.Name = "txtModuleName";
            this.txtModuleName.Size = new System.Drawing.Size(678, 23);
            this.txtModuleName.TabIndex = 3;
            this.txtModuleName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.txtModuleName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FOpcHostMessageSender
            // 
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(814, 514);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FOpcHostMessageSender";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Host Message Sender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FOpcHostMessageSender_FormClosing);
            this.Load += new System.EventHandler(this.FOpcHostMessageSender_Load);
            this.Shown += new System.EventHandler(this.FOpcHostMessageSender_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.pnlItem.ClientArea.ResumeLayout(false);
            this.pnlItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlCondition.ClientArea.ResumeLayout(false);
            this.pnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCastChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModuleName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnCancel;
        private Core.FaUIs.FButton btnSend;
        private Core.FaUIs.FPanel pnlItem;
        private Core.FaUIs.FSplitter fSplitter;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FLabel lblTotal;
        private Core.FaUIs.FRefreshAndSearchToolbar rstToolbar;
        private Core.FaUIs.FGrid grdList;
        private Core.FaUIs.FTreeView tvwTree;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Core.FaUIs.FLabel lblCancel;
        private Core.FaUIs.FLabel fLabel2;
        private Core.FaUIs.FLabel lblSkip;
        private Core.FaUIs.FLabel fLabel4;
        private Core.FaUIs.FLabel lblFail;
        private Core.FaUIs.FLabel fLabel1;
        private Core.FaUIs.FLabel fLabel3;
        private Core.FaUIs.FLabel lblSuccess;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenu_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FPanel pnlCondition;
        private Core.FaUIs.FTitleLabel lblCastChannel;
        private Core.FaUIs.FTextBox txtCastChannel;
        private Core.FaUIs.FTextBox txtStation;
        private Core.FaUIs.FTitleLabel lblStation;
        private Core.FaUIs.FTitleLabel lblModuleName;
        private Core.FaUIs.FTextBox txtModuleName;
    }
}
