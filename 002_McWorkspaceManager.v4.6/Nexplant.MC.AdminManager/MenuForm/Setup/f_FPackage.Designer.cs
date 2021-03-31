namespace Nexplant.MC.AdminManager
{
    partial class FPackage
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
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
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
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Package Status");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Package Status");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab3 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab5 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FPackage));
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.spcPackage = new System.Windows.Forms.SplitContainer();
            this.lblPkgTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.grdPackage = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstPackage = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pgdPackage = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.spcPackageVer = new System.Windows.Forms.SplitContainer();
            this.lblVerTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.grdVersion = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstVersion = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pgdVersion = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.btnDelete = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnClear = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnUpdate = new Nexplant.MC.Core.FaUIs.FButton();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tabMain = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage2 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnDownload = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnNewVersion = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPackage)).BeginInit();
            this.spcPackage.Panel1.SuspendLayout();
            this.spcPackage.Panel2.SuspendLayout();
            this.spcPackage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPackage)).BeginInit();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPackageVer)).BeginInit();
            this.spcPackageVer.Panel1.SuspendLayout();
            this.spcPackageVer.Panel2.SuspendLayout();
            this.spcPackageVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.tabMain);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Padding = new System.Windows.Forms.Padding(2);
            this.pnlDialogClient.Size = new System.Drawing.Size(980, 482);
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Controls.Add(this.spcPackage);
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(974, 454);
            // 
            // spcPackage
            // 
            this.spcPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcPackage.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcPackage.Location = new System.Drawing.Point(2, 2);
            this.spcPackage.Name = "spcPackage";
            // 
            // spcPackage.Panel1
            // 
            this.spcPackage.Panel1.Controls.Add(this.lblPkgTotal);
            this.spcPackage.Panel1.Controls.Add(this.grdPackage);
            this.spcPackage.Panel1.Controls.Add(this.rstPackage);
            // 
            // spcPackage.Panel2
            // 
            this.spcPackage.Panel2.Controls.Add(this.pgdPackage);
            this.spcPackage.Panel2MinSize = 250;
            this.spcPackage.Size = new System.Drawing.Size(970, 450);
            this.spcPackage.SplitterDistance = 716;
            this.spcPackage.TabIndex = 2;
            this.spcPackage.TabStop = false;
            // 
            // lblPkgTotal
            // 
            this.lblPkgTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextHAlignAsString = "Right";
            appearance4.TextVAlignAsString = "Middle";
            this.lblPkgTotal.Appearance = appearance4;
            this.lblPkgTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblPkgTotal.Location = new System.Drawing.Point(603, 3);
            this.lblPkgTotal.Name = "lblPkgTotal";
            this.lblPkgTotal.Size = new System.Drawing.Size(108, 20);
            this.lblPkgTotal.TabIndex = 93;
            this.lblPkgTotal.Text = "0";
            this.lblPkgTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdPackage
            // 
            this.grdPackage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            appearance5.ForeColor = System.Drawing.Color.Black;
            appearance5.TextVAlignAsString = "Middle";
            this.grdPackage.DisplayLayout.Appearance = appearance5;
            this.grdPackage.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdPackage.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPackage.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance6.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance6.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPackage.DisplayLayout.GroupByBox.Appearance = appearance6;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPackage.DisplayLayout.GroupByBox.BandLabelAppearance = appearance7;
            this.grdPackage.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance8.BackColor2 = System.Drawing.SystemColors.Control;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdPackage.DisplayLayout.GroupByBox.PromptAppearance = appearance8;
            this.grdPackage.DisplayLayout.MaxColScrollRegions = 1;
            this.grdPackage.DisplayLayout.MaxRowScrollRegions = 1;
            appearance9.BackColor = System.Drawing.SystemColors.Window;
            appearance9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdPackage.DisplayLayout.Override.ActiveCellAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance10.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance10.BorderColor = System.Drawing.Color.Silver;
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.TextVAlignAsString = "Middle";
            this.grdPackage.DisplayLayout.Override.ActiveRowAppearance = appearance10;
            this.grdPackage.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdPackage.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdPackage.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdPackage.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdPackage.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdPackage.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPackage.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdPackage.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            this.grdPackage.DisplayLayout.Override.CardAreaAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.grdPackage.DisplayLayout.Override.CellAppearance = appearance12;
            this.grdPackage.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdPackage.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.DisplayLayout.Override.CellPadding = 0;
            this.grdPackage.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance13.BackColor = System.Drawing.SystemColors.Control;
            appearance13.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance13.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance13.BorderColor = System.Drawing.SystemColors.Window;
            this.grdPackage.DisplayLayout.Override.GroupByRowAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance14.BackColor2 = System.Drawing.Color.Lavender;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.Color.Silver;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.grdPackage.DisplayLayout.Override.HeaderAppearance = appearance14;
            this.grdPackage.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdPackage.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdPackage.DisplayLayout.Override.RowAppearance = appearance12;
            this.grdPackage.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdPackage.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance15.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance15.BackColor2 = System.Drawing.Color.LightGray;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.grdPackage.DisplayLayout.Override.SelectedRowAppearance = appearance15;
            this.grdPackage.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdPackage.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdPackage.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdPackage.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdPackage.DisplayLayout.Override.TemplateAddRowAppearance = appearance16;
            this.grdPackage.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdPackage.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdPackage.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdPackage.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdPackage.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdPackage.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdPackage.DisplayLayout.UseFixedHeaders = true;
            this.grdPackage.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdPackage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdPackage.Location = new System.Drawing.Point(0, 23);
            this.grdPackage.multiSelected = true;
            this.grdPackage.Name = "grdPackage";
            this.grdPackage.Size = new System.Drawing.Size(716, 427);
            this.grdPackage.TabIndex = 1;
            this.grdPackage.Text = "fGrid1";
            this.grdPackage.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdPackage.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdPackage.valueCopyOfClickedCell = false;
            this.grdPackage.AfterRowActivate += new System.EventHandler(this.grdPackage_AfterRowActivate);
            this.grdPackage.DoubleClickRow += new Infragistics.Win.UltraWinGrid.DoubleClickRowEventHandler(this.grdPackage_DoubleClickRow);
            this.grdPackage.Enter += new System.EventHandler(this.grdPackage_Enter);
            this.grdPackage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdPackage_MouseDown);
            // 
            // rstPackage
            // 
            this.rstPackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstPackage.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstPackage.Location = new System.Drawing.Point(0, 0);
            this.rstPackage.Name = "rstPackage";
            this.rstPackage.refreshEnabled = true;
            this.rstPackage.Size = new System.Drawing.Size(597, 21);
            this.rstPackage.TabIndex = 0;
            this.rstPackage.TabStop = false;
            this.rstPackage.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstPackage_RefreshRequested);
            this.rstPackage.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstPackage_SearchRequested);
            // 
            // pgdPackage
            // 
            this.pgdPackage.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdPackage.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdPackage.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdPackage.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdPackage.HelpVisible = false;
            this.pgdPackage.LineColor = System.Drawing.Color.Silver;
            this.pgdPackage.Location = new System.Drawing.Point(0, 0);
            this.pgdPackage.Name = "pgdPackage";
            this.pgdPackage.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdPackage.selectedObject = null;
            this.pgdPackage.Size = new System.Drawing.Size(250, 450);
            this.pgdPackage.TabIndex = 0;
            this.pgdPackage.ToolbarVisible = false;
            this.pgdPackage.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdPackage.ViewForeColor = System.Drawing.Color.Black;
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.spcPackageVer);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(974, 454);
            // 
            // spcPackageVer
            // 
            this.spcPackageVer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spcPackageVer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcPackageVer.Location = new System.Drawing.Point(2, 2);
            this.spcPackageVer.Name = "spcPackageVer";
            // 
            // spcPackageVer.Panel1
            // 
            this.spcPackageVer.Panel1.Controls.Add(this.lblVerTotal);
            this.spcPackageVer.Panel1.Controls.Add(this.grdVersion);
            this.spcPackageVer.Panel1.Controls.Add(this.rstVersion);
            // 
            // spcPackageVer.Panel2
            // 
            this.spcPackageVer.Panel2.Controls.Add(this.pgdVersion);
            this.spcPackageVer.Panel2MinSize = 250;
            this.spcPackageVer.Size = new System.Drawing.Size(970, 450);
            this.spcPackageVer.SplitterDistance = 716;
            this.spcPackageVer.TabIndex = 2;
            this.spcPackageVer.TabStop = false;
            // 
            // lblVerTotal
            // 
            this.lblVerTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.lblVerTotal.Appearance = appearance17;
            this.lblVerTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblVerTotal.Location = new System.Drawing.Point(603, 3);
            this.lblVerTotal.Name = "lblVerTotal";
            this.lblVerTotal.Size = new System.Drawing.Size(108, 20);
            this.lblVerTotal.TabIndex = 93;
            this.lblVerTotal.Text = "0";
            this.lblVerTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdVersion
            // 
            this.grdVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance18.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.grdVersion.DisplayLayout.Appearance = appearance18;
            this.grdVersion.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdVersion.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdVersion.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance19.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance19.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance19.BorderColor = System.Drawing.SystemColors.Window;
            this.grdVersion.DisplayLayout.GroupByBox.Appearance = appearance19;
            appearance20.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdVersion.DisplayLayout.GroupByBox.BandLabelAppearance = appearance20;
            this.grdVersion.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance21.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance21.BackColor2 = System.Drawing.SystemColors.Control;
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance21.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdVersion.DisplayLayout.GroupByBox.PromptAppearance = appearance21;
            this.grdVersion.DisplayLayout.MaxColScrollRegions = 1;
            this.grdVersion.DisplayLayout.MaxRowScrollRegions = 1;
            appearance22.BackColor = System.Drawing.SystemColors.Window;
            appearance22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdVersion.DisplayLayout.Override.ActiveCellAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance23.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.grdVersion.DisplayLayout.Override.ActiveRowAppearance = appearance23;
            this.grdVersion.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdVersion.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdVersion.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdVersion.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdVersion.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdVersion.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdVersion.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdVersion.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance24.BackColor = System.Drawing.SystemColors.Window;
            this.grdVersion.DisplayLayout.Override.CardAreaAppearance = appearance24;
            appearance25.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.grdVersion.DisplayLayout.Override.CellAppearance = appearance25;
            this.grdVersion.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdVersion.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.DisplayLayout.Override.CellPadding = 0;
            this.grdVersion.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance26.BackColor = System.Drawing.SystemColors.Control;
            appearance26.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance26.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance26.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance26.BorderColor = System.Drawing.SystemColors.Window;
            this.grdVersion.DisplayLayout.Override.GroupByRowAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance27.BackColor2 = System.Drawing.Color.Lavender;
            appearance27.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance27.BorderColor = System.Drawing.Color.Silver;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Center";
            appearance27.TextVAlignAsString = "Middle";
            this.grdVersion.DisplayLayout.Override.HeaderAppearance = appearance27;
            this.grdVersion.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdVersion.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdVersion.DisplayLayout.Override.RowAppearance = appearance25;
            this.grdVersion.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdVersion.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance28.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance28.BackColor2 = System.Drawing.Color.LightGray;
            appearance28.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance28.BorderColor = System.Drawing.Color.Silver;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.grdVersion.DisplayLayout.Override.SelectedRowAppearance = appearance28;
            this.grdVersion.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdVersion.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdVersion.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdVersion.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance29.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdVersion.DisplayLayout.Override.TemplateAddRowAppearance = appearance29;
            this.grdVersion.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdVersion.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdVersion.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdVersion.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdVersion.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdVersion.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdVersion.DisplayLayout.UseFixedHeaders = true;
            this.grdVersion.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdVersion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdVersion.Location = new System.Drawing.Point(0, 23);
            this.grdVersion.multiSelected = true;
            this.grdVersion.Name = "grdVersion";
            this.grdVersion.Size = new System.Drawing.Size(716, 427);
            this.grdVersion.TabIndex = 1;
            this.grdVersion.Text = "fGrid1";
            this.grdVersion.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdVersion.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdVersion.valueCopyOfClickedCell = false;
            this.grdVersion.AfterRowActivate += new System.EventHandler(this.grdVersion_AfterRowActivate);
            this.grdVersion.Enter += new System.EventHandler(this.grdVersion_Enter);
            this.grdVersion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdVersion_MouseDown);
            // 
            // rstVersion
            // 
            this.rstVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstVersion.Location = new System.Drawing.Point(0, 0);
            this.rstVersion.Name = "rstVersion";
            this.rstVersion.refreshEnabled = true;
            this.rstVersion.Size = new System.Drawing.Size(597, 21);
            this.rstVersion.TabIndex = 0;
            this.rstVersion.TabStop = false;
            this.rstVersion.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstVersion_RefreshRequested);
            this.rstVersion.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstVersion_SearchRequested);
            // 
            // pgdVersion
            // 
            this.pgdVersion.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdVersion.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdVersion.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdVersion.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdVersion.HelpVisible = false;
            this.pgdVersion.LineColor = System.Drawing.Color.Silver;
            this.pgdVersion.Location = new System.Drawing.Point(0, 0);
            this.pgdVersion.Name = "pgdVersion";
            this.pgdVersion.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdVersion.selectedObject = null;
            this.pgdVersion.Size = new System.Drawing.Size(250, 450);
            this.pgdVersion.TabIndex = 0;
            this.pgdVersion.ToolbarVisible = false;
            this.pgdVersion.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdVersion.ViewForeColor = System.Drawing.Color.Black;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnDelete.Location = new System.Drawing.Point(6, 528);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete(&D)";
            this.btnDelete.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnClear.Location = new System.Drawing.Point(881, 528);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear(&R)";
            this.btnClear.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(778, 528);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 28);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update(&U)";
            this.btnUpdate.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this;
            this.mnuMenu.DockWithinContainerBaseType = typeof(Nexplant.MC.Core.FaUIs.FBaseControlDialogForm);
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance31.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqPackageStatus;
            buttonTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance31;
            buttonTool1.SharedPropsInternal.Caption = "Package Status...";
            popupMenuTool1.SharedPropsInternal.Caption = "PopupMenu";
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2});
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            popupMenuTool1});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // _FControlDialogFormBase_Toolbars_Dock_Area_Left
            // 
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.Name = "_FControlDialogFormBase_Toolbars_Dock_Area_Left";
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 562);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _FControlDialogFormBase_Toolbars_Dock_Area_Right
            // 
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(984, 0);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.Name = "_FControlDialogFormBase_Toolbars_Dock_Area_Right";
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 562);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _FControlDialogFormBase_Toolbars_Dock_Area_Top
            // 
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.Name = "_FControlDialogFormBase_Toolbars_Dock_Area_Top";
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(984, 0);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _FControlDialogFormBase_Toolbars_Dock_Area_Bottom
            // 
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 562);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.Name = "_FControlDialogFormBase_Toolbars_Dock_Area_Bottom";
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(984, 0);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // tabMain
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.tabMain.ActiveTabAppearance = appearance1;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Silver;
            this.tabMain.Appearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.tabMain.ClientAreaAppearance = appearance3;
            this.tabMain.Controls.Add(this.ultraTabSharedControlsPage2);
            this.tabMain.Controls.Add(this.ultraTabPageControl1);
            this.tabMain.Controls.Add(this.ultraTabPageControl2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(2, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance30.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance30.BackColor2 = System.Drawing.Color.Lavender;
            appearance30.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.tabMain.SelectedTabAppearance = appearance30;
            this.tabMain.SharedControlsPage = this.ultraTabSharedControlsPage2;
            this.tabMain.Size = new System.Drawing.Size(976, 478);
            this.tabMain.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.tabMain.TabIndex = 16;
            ultraTab3.Key = "Package";
            ultraTab3.TabPage = this.ultraTabPageControl1;
            ultraTab3.Text = "Package";
            ultraTab5.Key = "Package Version";
            ultraTab5.TabPage = this.ultraTabPageControl2;
            ultraTab5.Text = "Package Version";
            this.tabMain.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab3,
            ultraTab5});
            this.tabMain.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tabMain.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tabMain.ActiveTabChanged += new Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventHandler(this.tabMain_ActiveTabChanged);
            // 
            // ultraTabSharedControlsPage2
            // 
            this.ultraTabSharedControlsPage2.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage2.Name = "ultraTabSharedControlsPage2";
            this.ultraTabSharedControlsPage2.Size = new System.Drawing.Size(974, 454);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownload.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnDownload.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnDownload.Location = new System.Drawing.Point(109, 528);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(97, 28);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download(&D)";
            this.btnDownload.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnNewVersion
            // 
            this.btnNewVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewVersion.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnNewVersion.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnNewVersion.Location = new System.Drawing.Point(675, 528);
            this.btnNewVersion.Name = "btnNewVersion";
            this.btnNewVersion.Size = new System.Drawing.Size(97, 28);
            this.btnNewVersion.TabIndex = 0;
            this.btnNewVersion.Text = "New Version(&N)";
            this.btnNewVersion.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnNewVersion.Click += new System.EventHandler(this.btnNewVersion_Click);
            // 
            // FPackage
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnNewVersion);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FPackage";
            this.Text = "Package";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FPackage_FormClosing);
            this.Load += new System.EventHandler(this.FPackage_Load);
            this.Shown += new System.EventHandler(this.FPackage_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FPackage_KeyDown);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Top, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Right, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Left, 0);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.btnNewVersion, 0);
            this.Controls.SetChildIndex(this.btnDownload, 0);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl1.ResumeLayout(false);
            this.spcPackage.Panel1.ResumeLayout(false);
            this.spcPackage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPackage)).EndInit();
            this.spcPackage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPackage)).EndInit();
            this.ultraTabPageControl2.ResumeLayout(false);
            this.spcPackageVer.Panel1.ResumeLayout(false);
            this.spcPackageVer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPackageVer)).EndInit();
            this.spcPackageVer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnDelete;
        private Core.FaUIs.FButton btnClear;
        private Core.FaUIs.FButton btnUpdate;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FTab tabMain;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage2;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private System.Windows.Forms.SplitContainer spcPackage;
        private Core.FaUIs.FGrid grdPackage;
        private Core.FaUIs.FRefreshAndSearchToolbar rstPackage;
        private Core.FaUIs.FDynPropGrid pgdPackage;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private System.Windows.Forms.SplitContainer spcPackageVer;
        private Core.FaUIs.FGrid grdVersion;
        private Core.FaUIs.FRefreshAndSearchToolbar rstVersion;
        private Core.FaUIs.FDynPropGrid pgdVersion;
        private Core.FaUIs.FButton btnDownload;
        private Core.FaUIs.FButton btnNewVersion;
        private Core.FaUIs.FLabel lblPkgTotal;
        private Core.FaUIs.FLabel lblVerTotal;
    }
}
