namespace Nexplant.MC.AdminManager
{
    partial class FTcpModelUserTagName
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
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTcpModelUserTagName));
            this.btnDelete = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnClear = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnUpdate = new Nexplant.MC.Core.FaUIs.FButton();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcChild = new System.Windows.Forms.SplitContainer();
            this.lblTypeTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.grdObjectType = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstTypeToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.lblTagTotal = new Nexplant.MC.Core.FaUIs.FLabel();
            this.grdUserTagName = new Nexplant.MC.Core.FaUIs.FGrid();
            this.rstUserTagToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcChild)).BeginInit();
            this.spcChild.Panel1.SuspendLayout();
            this.spcChild.Panel2.SuspendLayout();
            this.spcChild.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjectType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserTagName)).BeginInit();
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
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.Location = new System.Drawing.Point(2, 2);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.spcChild);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2MinSize = 250;
            this.spcMain.Size = new System.Drawing.Size(976, 478);
            this.spcMain.SplitterDistance = 722;
            this.spcMain.TabIndex = 6;
            this.spcMain.TabStop = false;
            // 
            // spcChild
            // 
            this.spcChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcChild.Location = new System.Drawing.Point(0, 0);
            this.spcChild.Name = "spcChild";
            this.spcChild.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcChild.Panel1
            // 
            this.spcChild.Panel1.Controls.Add(this.lblTypeTotal);
            this.spcChild.Panel1.Controls.Add(this.grdObjectType);
            this.spcChild.Panel1.Controls.Add(this.rstTypeToolbar);
            // 
            // spcChild.Panel2
            // 
            this.spcChild.Panel2.Controls.Add(this.lblTagTotal);
            this.spcChild.Panel2.Controls.Add(this.grdUserTagName);
            this.spcChild.Panel2.Controls.Add(this.rstUserTagToolbar);
            this.spcChild.Size = new System.Drawing.Size(722, 478);
            this.spcChild.SplitterDistance = 235;
            this.spcChild.TabIndex = 0;
            this.spcChild.TabStop = false;
            // 
            // lblTypeTotal
            // 
            this.lblTypeTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.lblTypeTotal.Appearance = appearance1;
            this.lblTypeTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTypeTotal.Location = new System.Drawing.Point(603, 3);
            this.lblTypeTotal.Name = "lblTypeTotal";
            this.lblTypeTotal.Size = new System.Drawing.Size(108, 20);
            this.lblTypeTotal.TabIndex = 95;
            this.lblTypeTotal.Text = "0";
            this.lblTypeTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdObjectType
            // 
            this.grdObjectType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.grdObjectType.DisplayLayout.Appearance = appearance2;
            this.grdObjectType.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdObjectType.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdObjectType.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance3.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.SystemColors.Window;
            this.grdObjectType.DisplayLayout.GroupByBox.Appearance = appearance3;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdObjectType.DisplayLayout.GroupByBox.BandLabelAppearance = appearance4;
            this.grdObjectType.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance5.BackColor2 = System.Drawing.SystemColors.Control;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdObjectType.DisplayLayout.GroupByBox.PromptAppearance = appearance5;
            this.grdObjectType.DisplayLayout.MaxColScrollRegions = 1;
            this.grdObjectType.DisplayLayout.MaxRowScrollRegions = 1;
            appearance6.BackColor = System.Drawing.SystemColors.Window;
            appearance6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdObjectType.DisplayLayout.Override.ActiveCellAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance7.BorderColor = System.Drawing.Color.Silver;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.grdObjectType.DisplayLayout.Override.ActiveRowAppearance = appearance7;
            this.grdObjectType.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdObjectType.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdObjectType.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdObjectType.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdObjectType.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdObjectType.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdObjectType.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdObjectType.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance8.BackColor = System.Drawing.SystemColors.Window;
            this.grdObjectType.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdObjectType.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdObjectType.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdObjectType.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.DisplayLayout.Override.CellPadding = 0;
            this.grdObjectType.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance10.BorderColor = System.Drawing.SystemColors.Window;
            this.grdObjectType.DisplayLayout.Override.GroupByRowAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance11.BackColor2 = System.Drawing.Color.Lavender;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            appearance11.TextHAlignAsString = "Center";
            appearance11.TextVAlignAsString = "Middle";
            this.grdObjectType.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.grdObjectType.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdObjectType.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdObjectType.DisplayLayout.Override.RowAppearance = appearance9;
            this.grdObjectType.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdObjectType.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance12.BackColor2 = System.Drawing.Color.LightGray;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.TextVAlignAsString = "Middle";
            this.grdObjectType.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.grdObjectType.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdObjectType.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdObjectType.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdObjectType.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            appearance13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdObjectType.DisplayLayout.Override.TemplateAddRowAppearance = appearance13;
            this.grdObjectType.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdObjectType.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdObjectType.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdObjectType.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdObjectType.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdObjectType.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdObjectType.DisplayLayout.UseFixedHeaders = true;
            this.grdObjectType.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdObjectType.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdObjectType.Location = new System.Drawing.Point(0, 23);
            this.grdObjectType.multiSelected = false;
            this.grdObjectType.Name = "grdObjectType";
            this.grdObjectType.Size = new System.Drawing.Size(722, 212);
            this.grdObjectType.TabIndex = 1;
            this.grdObjectType.Text = "fGrid1";
            this.grdObjectType.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdObjectType.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdObjectType.valueCopyOfClickedCell = false;
            this.grdObjectType.AfterRowActivate += new System.EventHandler(this.grdObjectType_AfterRowActivate);
            // 
            // rstTypeToolbar
            // 
            this.rstTypeToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstTypeToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstTypeToolbar.Location = new System.Drawing.Point(0, 0);
            this.rstTypeToolbar.Name = "rstTypeToolbar";
            this.rstTypeToolbar.refreshEnabled = true;
            this.rstTypeToolbar.Size = new System.Drawing.Size(597, 21);
            this.rstTypeToolbar.TabIndex = 0;
            this.rstTypeToolbar.TabStop = false;
            this.rstTypeToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstTypeToolbar_RefreshRequested);
            this.rstTypeToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstTypeToolbar_SearchRequested);
            // 
            // lblTagTotal
            // 
            this.lblTagTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.lblTagTotal.Appearance = appearance14;
            this.lblTagTotal.Font = new System.Drawing.Font("Verdana", 9F);
            this.lblTagTotal.Location = new System.Drawing.Point(603, 3);
            this.lblTagTotal.Name = "lblTagTotal";
            this.lblTagTotal.Size = new System.Drawing.Size(108, 20);
            this.lblTagTotal.TabIndex = 95;
            this.lblTagTotal.Text = "0";
            this.lblTagTotal.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // grdUserTagName
            // 
            this.grdUserTagName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance15.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.TextVAlignAsString = "Middle";
            this.grdUserTagName.DisplayLayout.Appearance = appearance15;
            this.grdUserTagName.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn;
            this.grdUserTagName.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserTagName.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.grdUserTagName.DisplayLayout.GroupByBox.Appearance = appearance16;
            appearance17.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdUserTagName.DisplayLayout.GroupByBox.BandLabelAppearance = appearance17;
            this.grdUserTagName.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance18.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance18.BackColor2 = System.Drawing.SystemColors.Control;
            appearance18.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance18.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdUserTagName.DisplayLayout.GroupByBox.PromptAppearance = appearance18;
            this.grdUserTagName.DisplayLayout.MaxColScrollRegions = 1;
            this.grdUserTagName.DisplayLayout.MaxRowScrollRegions = 1;
            appearance19.BackColor = System.Drawing.SystemColors.Window;
            appearance19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdUserTagName.DisplayLayout.Override.ActiveCellAppearance = appearance19;
            appearance20.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance20.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance20.BorderColor = System.Drawing.Color.Silver;
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.grdUserTagName.DisplayLayout.Override.ActiveRowAppearance = appearance20;
            this.grdUserTagName.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdUserTagName.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdUserTagName.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;
            this.grdUserTagName.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdUserTagName.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdUserTagName.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserTagName.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdUserTagName.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance21.BackColor = System.Drawing.SystemColors.Window;
            this.grdUserTagName.DisplayLayout.Override.CardAreaAppearance = appearance21;
            appearance22.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance22.BorderColor = System.Drawing.Color.Silver;
            appearance22.ForeColor = System.Drawing.Color.Black;
            appearance22.TextVAlignAsString = "Middle";
            this.grdUserTagName.DisplayLayout.Override.CellAppearance = appearance22;
            this.grdUserTagName.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.grdUserTagName.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.DisplayLayout.Override.CellPadding = 0;
            this.grdUserTagName.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance23.BackColor = System.Drawing.SystemColors.Control;
            appearance23.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance23.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance23.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance23.BorderColor = System.Drawing.SystemColors.Window;
            this.grdUserTagName.DisplayLayout.Override.GroupByRowAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance24.BackColor2 = System.Drawing.Color.Lavender;
            appearance24.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance24.BorderColor = System.Drawing.Color.Silver;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            appearance24.TextHAlignAsString = "Center";
            appearance24.TextVAlignAsString = "Middle";
            this.grdUserTagName.DisplayLayout.Override.HeaderAppearance = appearance24;
            this.grdUserTagName.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdUserTagName.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdUserTagName.DisplayLayout.Override.RowAppearance = appearance22;
            this.grdUserTagName.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdUserTagName.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
            appearance25.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance25.BackColor2 = System.Drawing.Color.LightGray;
            appearance25.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance25.BorderColor = System.Drawing.Color.Silver;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.grdUserTagName.DisplayLayout.Override.SelectedRowAppearance = appearance25;
            this.grdUserTagName.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserTagName.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserTagName.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdUserTagName.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            appearance26.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdUserTagName.DisplayLayout.Override.TemplateAddRowAppearance = appearance26;
            this.grdUserTagName.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdUserTagName.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdUserTagName.DisplayLayout.ScrollBarLook = scrollBarLook2;
            this.grdUserTagName.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdUserTagName.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdUserTagName.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdUserTagName.DisplayLayout.UseFixedHeaders = true;
            this.grdUserTagName.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdUserTagName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdUserTagName.Location = new System.Drawing.Point(0, 23);
            this.grdUserTagName.multiSelected = true;
            this.grdUserTagName.Name = "grdUserTagName";
            this.grdUserTagName.Size = new System.Drawing.Size(722, 216);
            this.grdUserTagName.TabIndex = 1;
            this.grdUserTagName.Text = "fGrid1";
            this.grdUserTagName.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdUserTagName.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdUserTagName.valueCopyOfClickedCell = false;
            this.grdUserTagName.AfterRowActivate += new System.EventHandler(this.grdUserTagName_AfterRowActivate);
            this.grdUserTagName.Enter += new System.EventHandler(this.grdUserTagName_Enter);
            // 
            // rstUserTagToolbar
            // 
            this.rstUserTagToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstUserTagToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstUserTagToolbar.Location = new System.Drawing.Point(0, 0);
            this.rstUserTagToolbar.Name = "rstUserTagToolbar";
            this.rstUserTagToolbar.refreshEnabled = true;
            this.rstUserTagToolbar.Size = new System.Drawing.Size(597, 21);
            this.rstUserTagToolbar.TabIndex = 0;
            this.rstUserTagToolbar.TabStop = false;
            this.rstUserTagToolbar.RefreshRequested += new Nexplant.MC.Core.FaUIs.FRefreshRequestedEventHandler(this.rstUserTagToolbar_RefreshRequested);
            this.rstUserTagToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstUserTagToolbar_SearchRequested);
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
            // FTcpModelUserTagName
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FTcpModelUserTagName";
            this.Text = "TCP Model User Tag Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FModelUserTagName_FormClosing);
            this.Load += new System.EventHandler(this.FModelUserTagName_Load);
            this.Shown += new System.EventHandler(this.FModelUserTagName_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FTcpModelUserTagName_KeyDown);
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
            this.spcChild.Panel1.ResumeLayout(false);
            this.spcChild.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcChild)).EndInit();
            this.spcChild.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdObjectType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserTagName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnDelete;
        private Core.FaUIs.FButton btnClear;
        private Core.FaUIs.FButton btnUpdate;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FGrid grdUserTagName;
        private Core.FaUIs.FRefreshAndSearchToolbar rstUserTagToolbar;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private System.Windows.Forms.SplitContainer spcChild;
        private Core.FaUIs.FGrid grdObjectType;
        private Core.FaUIs.FRefreshAndSearchToolbar rstTypeToolbar;
        private Core.FaUIs.FLabel lblTypeTotal;
        private Core.FaUIs.FLabel lblTagTotal;
    }
}
