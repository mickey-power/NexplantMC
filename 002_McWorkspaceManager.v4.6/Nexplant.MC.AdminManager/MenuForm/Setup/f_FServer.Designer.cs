namespace Nexplant.MC.AdminManager
{
    partial class FServer
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
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("ServerPopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Status");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server History");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource Status");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource History");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Main Switch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Backup Switch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Admin Agent Log List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Admin Agent Backup Log List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Status");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server History");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource Status");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource Comparison");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource History");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Main Switch");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Backup Switch");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Admin Agent Log List");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Admin Agent Backup Log List");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Server Resource Analysis");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServer));
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.lblTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.grdList = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.btnDelete = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnClear = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnUpdate = new Nexplant.MC.Core.FaUIs.FButton();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this._FControlDialogFormBase_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.spcMain);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Padding = new System.Windows.Forms.Padding(2);
            this.pnlDialogClient.Size = new System.Drawing.Size(980, 482);
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.Location = new System.Drawing.Point(2, 2);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.lblTotal);
            this.spcMain.Panel1.Controls.Add(this.grdList);
            this.spcMain.Panel1.Controls.Add(this.rstToolbar);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2MinSize = 250;
            this.spcMain.Size = new System.Drawing.Size(976, 478);
            this.spcMain.SplitterDistance = 722;
            this.spcMain.TabIndex = 1;
            this.spcMain.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTotal.Appearance = appearance1;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTotal.Location = new System.Drawing.Point(609, 3);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(110, 20);
            this.lblTotal.TabIndex = 91;
            this.lblTotal.Text = "0";
            this.lblTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdList
            // 
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Appearance = appearance2;
            this.grdList.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdList.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdList.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdList.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdList.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdList.DisplayLayout.MaxColScrollRegions = 1;
            this.grdList.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdList.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.ActiveRowAppearance = appearance7;
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
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdList.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdList.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.CellPadding = 0;
            this.grdList.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdList.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdList.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdList.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdList.DisplayLayout.Override.RowAppearance = appearance9;
            this.grdList.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdList.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.BackColor2 = System.Drawing.Color.LightGray;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.grdList.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.grdList.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdList.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdList.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
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
            this.grdList.Location = new System.Drawing.Point(0, 23);
            this.grdList.multiSelected = true;
            this.grdList.Name = "grdList";
            this.grdList.Size = new System.Drawing.Size(722, 455);
            this.grdList.TabIndex = 1;
            this.grdList.Text = "fGrid1";
            this.grdList.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdList.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdList.valueCopyOfClickedCell = false;
            this.grdList.AfterRowActivate += new System.EventHandler(this.grdList_AfterRowActivate);
            this.grdList.Enter += new System.EventHandler(this.grdList_Enter);
            this.grdList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdList_MouseDown);
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(0, 0);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = true;
            this.rstToolbar.Size = new System.Drawing.Size(603, 21);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.TabStop = false;
            this.rstToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstToolbar_RefreshRequested);
            this.rstToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstToolbar_SearchRequested);
            // 
            // pgdProp
            // 
            this.pgdProp.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdProp.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdProp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgdProp.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdProp.HelpVisible = false;
            this.pgdProp.LineColor = System.Drawing.Color.Silver;
            this.pgdProp.Location = new System.Drawing.Point(0, 0);
            this.pgdProp.Name = "pgdProp";
            this.pgdProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdProp.selectedObject = null;
            this.pgdProp.Size = new System.Drawing.Size(250, 478);
            this.pgdProp.TabIndex = 0;
            this.pgdProp.ToolbarVisible = false;
            this.pgdProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnDelete.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnDelete.Location = new System.Drawing.Point(6, 528);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 28);
            this.btnDelete.TabIndex = 2;
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
            this.btnClear.TabIndex = 1;
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
            this.btnUpdate.TabIndex = 0;
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
            popupMenuTool1.SharedPropsInternal.Caption = "ServerPopupMenu";
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool17.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool8,
            buttonTool9,
            buttonTool10,
            buttonTool12,
            buttonTool13,
            buttonTool14,
            buttonTool17,
            buttonTool18});
            appearance14.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerStatus;
            buttonTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool1.SharedPropsInternal.Caption = "Server Status...";
            appearance15.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerHistory;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool2.SharedPropsInternal.Caption = "Server History...";
            appearance16.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerResourceStatus;
            buttonTool3.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool3.SharedPropsInternal.Caption = "Server Resource Status...";
            appearance17.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerResourceComparison;
            buttonTool4.SharedPropsInternal.AppearancesSmall.Appearance = appearance17;
            buttonTool4.SharedPropsInternal.Caption = "Server Resource Comparison...";
            appearance18.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerResourceHistory;
            buttonTool5.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            buttonTool5.SharedPropsInternal.Caption = "Server Resource History...";
            appearance19.Image = global::Nexplant.MC.AdminManager.Properties.Resources.TrnServerMainSwitch;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance19;
            buttonTool6.SharedPropsInternal.Caption = "Server Main Switch...";
            appearance20.Image = global::Nexplant.MC.AdminManager.Properties.Resources.TrnServerBackupSwitch;
            buttonTool7.SharedPropsInternal.AppearancesSmall.Appearance = appearance20;
            buttonTool7.SharedPropsInternal.Caption = "Server Backup Switch...";
            appearance21.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ViewAdminAgentLogList;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance21;
            buttonTool15.SharedPropsInternal.Caption = "Admin Agent Log List...";
            appearance22.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ViewAdminAgentBackupLogList;
            buttonTool16.SharedPropsInternal.AppearancesSmall.Appearance = appearance22;
            buttonTool16.SharedPropsInternal.Caption = "Admin Agent Backup Log List...";
            appearance23.Image = global::Nexplant.MC.AdminManager.Properties.Resources.InqServerResourceAnalysis;
            buttonTool19.SharedPropsInternal.AppearancesSmall.Appearance = appearance23;
            buttonTool19.SharedPropsInternal.Caption = "Server Resource Analysis...";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            buttonTool6,
            buttonTool7,
            buttonTool15,
            buttonTool16,
            buttonTool19});
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
            // FServer
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._FControlDialogFormBase_Toolbars_Dock_Area_Top);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FServer";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FServer_FormClosing);
            this.Load += new System.EventHandler(this.FServer_Load);
            this.Shown += new System.EventHandler(this.FServer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FServer_KeyDown);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Top, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Bottom, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Right, 0);
            this.Controls.SetChildIndex(this._FControlDialogFormBase_Toolbars_Dock_Area_Left, 0);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FGrid grdList;
        private Core.FaUIs.FRefreshAndSearchToolbar rstToolbar;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Core.FaUIs.FButton btnDelete;
        private Core.FaUIs.FButton btnClear;
        private Core.FaUIs.FButton btnUpdate;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _FControlDialogFormBase_Toolbars_Dock_Area_Top;
        private Core.FaUIs.FLabel lblTotal;
    }
}
