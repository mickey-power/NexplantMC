namespace Nexplant.MC.OpcModeler
{
    partial class FExportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1);
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
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTabControl.UltraTab ultraTab4 = new Infragistics.Win.UltraWinTabControl.UltraTab();
            this.ultraTabPageControl2 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.grdExportItems = new Nexplant.MC.Core.FaUIs.FDetailViewGrid();
            this.btnExport = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.fTab1 = new Nexplant.MC.Core.FaUIs.FTab();
            this.ultraTabSharedControlsPage1 = new Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage();
            this.btnToggleAll = new Nexplant.MC.Core.FaUIs.FButton();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.ultraTabPageControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExportItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).BeginInit();
            this.fTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.fTab1);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(452, 285);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnToggleAll);
            this.pnlClient.Controls.Add(this.btnExport);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Size = new System.Drawing.Size(456, 338);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnExport, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnToggleAll, 0);
            // 
            // ultraTabPageControl2
            // 
            this.ultraTabPageControl2.Controls.Add(this.grdExportItems);
            this.ultraTabPageControl2.Location = new System.Drawing.Point(1, 23);
            this.ultraTabPageControl2.Name = "ultraTabPageControl2";
            this.ultraTabPageControl2.Size = new System.Drawing.Size(450, 261);
            // 
            // grdExportItems
            // 
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BorderColor = System.Drawing.Color.Silver;
            appearance4.FontData.SizeInPoints = 9F;
            appearance4.ForeColor = System.Drawing.Color.Black;
            appearance4.TextVAlignAsString = "Middle";
            this.grdExportItems.DisplayLayout.Appearance = appearance4;
            this.grdExportItems.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridBand1.ColHeadersVisible = false;
            this.grdExportItems.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdExportItems.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdExportItems.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance5.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.BorderColor = System.Drawing.SystemColors.Window;
            this.grdExportItems.DisplayLayout.GroupByBox.Appearance = appearance5;
            appearance6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdExportItems.DisplayLayout.GroupByBox.BandLabelAppearance = appearance6;
            this.grdExportItems.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.Control;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdExportItems.DisplayLayout.GroupByBox.PromptAppearance = appearance7;
            this.grdExportItems.DisplayLayout.MaxColScrollRegions = 1;
            this.grdExportItems.DisplayLayout.MaxRowScrollRegions = 1;
            this.grdExportItems.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.grdExportItems.DisplayLayout.Override.ActiveCellAppearance = appearance8;
            appearance9.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance9.BorderColor = System.Drawing.Color.Silver;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.TextVAlignAsString = "Middle";
            this.grdExportItems.DisplayLayout.Override.ActiveRowAppearance = appearance9;
            this.grdExportItems.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdExportItems.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdExportItems.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.grdExportItems.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdExportItems.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdExportItems.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdExportItems.DisplayLayout.Override.BorderStyleHeader = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdExportItems.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            this.grdExportItems.DisplayLayout.Override.CardAreaAppearance = appearance10;
            this.grdExportItems.DisplayLayout.Override.CellAppearance = appearance9;
            this.grdExportItems.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect;
            this.grdExportItems.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.DisplayLayout.Override.CellPadding = 0;
            this.grdExportItems.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            appearance11.BackColor = System.Drawing.SystemColors.Control;
            appearance11.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance11.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.BorderColor = System.Drawing.SystemColors.Window;
            this.grdExportItems.DisplayLayout.Override.GroupByRowAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance12.BackColor2 = System.Drawing.Color.Lavender;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance12.BorderColor = System.Drawing.Color.Silver;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.grdExportItems.DisplayLayout.Override.HeaderAppearance = appearance12;
            this.grdExportItems.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.Standard;
            this.grdExportItems.DisplayLayout.Override.RowAppearance = appearance9;
            this.grdExportItems.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.DisplayLayout.Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.grdExportItems.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            appearance13.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance13.BackColor2 = System.Drawing.Color.LightGray;
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.ForeColor = System.Drawing.Color.Black;
            appearance13.TextVAlignAsString = "Middle";
            this.grdExportItems.DisplayLayout.Override.SelectedCellAppearance = appearance13;
            this.grdExportItems.DisplayLayout.Override.SelectedRowAppearance = appearance9;
            this.grdExportItems.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdExportItems.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdExportItems.DisplayLayout.Override.SelectTypeGroupByRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.grdExportItems.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            appearance14.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdExportItems.DisplayLayout.Override.TemplateAddRowAppearance = appearance14;
            this.grdExportItems.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Hide;
            this.grdExportItems.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.grdExportItems.DisplayLayout.ScrollBarLook = scrollBarLook1;
            this.grdExportItems.DisplayLayout.Scrollbars = Infragistics.Win.UltraWinGrid.Scrollbars.None;
            this.grdExportItems.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdExportItems.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdExportItems.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.grdExportItems.DisplayLayout.UseFixedHeaders = true;
            this.grdExportItems.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.grdExportItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExportItems.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.grdExportItems.Location = new System.Drawing.Point(0, 0);
            this.grdExportItems.Name = "grdExportItems";
            this.grdExportItems.Size = new System.Drawing.Size(450, 261);
            this.grdExportItems.TabIndex = 2;
            this.grdExportItems.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.grdExportItems.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.grdExportItems.valueCopyOfClickedCell = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnExport.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnExport.Location = new System.Drawing.Point(266, 303);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(86, 28);
            this.btnExport.TabIndex = 31;
            this.btnExport.Text = "Export(&O)";
            this.btnExport.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(358, 303);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(409, 339);
            // 
            // fTab1
            // 
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.fTab1.ActiveTabAppearance = appearance1;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Silver;
            this.fTab1.Appearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.fTab1.ClientAreaAppearance = appearance3;
            this.fTab1.Controls.Add(this.ultraTabSharedControlsPage1);
            this.fTab1.Controls.Add(this.ultraTabPageControl2);
            this.fTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fTab1.Location = new System.Drawing.Point(0, 0);
            this.fTab1.Name = "fTab1";
            this.fTab1.ScrollButtonStyle = Infragistics.Win.UIElementButtonStyle.Office2010Button;
            appearance15.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance15.BackColor2 = System.Drawing.Color.Lavender;
            appearance15.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.fTab1.SelectedTabAppearance = appearance15;
            this.fTab1.SharedControlsPage = this.ultraTabSharedControlsPage1;
            this.fTab1.Size = new System.Drawing.Size(452, 285);
            this.fTab1.Style = Infragistics.Win.UltraWinTabControl.UltraTabControlStyle.Office2007Ribbon;
            this.fTab1.TabIndex = 0;
            ultraTab4.TabPage = this.ultraTabPageControl2;
            ultraTab4.Text = "Export";
            this.fTab1.Tabs.AddRange(new Infragistics.Win.UltraWinTabControl.UltraTab[] {
            ultraTab4});
            this.fTab1.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.fTab1.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // ultraTabSharedControlsPage1
            // 
            this.ultraTabSharedControlsPage1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabSharedControlsPage1.Name = "ultraTabSharedControlsPage1";
            this.ultraTabSharedControlsPage1.Size = new System.Drawing.Size(450, 261);
            // 
            // btnToggleAll
            // 
            this.btnToggleAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleAll.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnToggleAll.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnToggleAll.Location = new System.Drawing.Point(7, 303);
            this.btnToggleAll.Name = "btnToggleAll";
            this.btnToggleAll.Size = new System.Drawing.Size(104, 28);
            this.btnToggleAll.TabIndex = 33;
            this.btnToggleAll.Text = "Toggle All(&T)";
            this.btnToggleAll.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnToggleAll.Click += new System.EventHandler(this.btnToggleAll_Click);
            // 
            // FExportDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(456, 365);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FExportDialog";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FExportDialog_FormClosing);
            this.Load += new System.EventHandler(this.FExportDialog_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ultraTabPageControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExportItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fTab1)).EndInit();
            this.fTab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnExport;
        private Core.FaUIs.FButton btnCancel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Core.FaUIs.FTab fTab1;
        private Infragistics.Win.UltraWinTabControl.UltraTabSharedControlsPage ultraTabSharedControlsPage1;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl2;
        private Core.FaUIs.FDetailViewGrid grdExportItems;
        private Core.FaUIs.FButton btnToggleAll;
    }
}