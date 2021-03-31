namespace Nexplant.MC.AdminManager
{
    partial class FOpcLogObjectViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FOpcLogObjectViewer));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("ToolBar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.tvwTree = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.FControlFormBase_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.mnuMenu = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this.ClientArea_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._ClientArea_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._ClientArea_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).BeginInit();
            this.FControlFormBase_Fill_Panel.ClientArea.SuspendLayout();
            this.FControlFormBase_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.ClientArea_Fill_Panel.ClientArea.SuspendLayout();
            this.ClientArea_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(1008, 328);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "SecsDriverLog");
            this.imageList.Images.SetKeyName(1, "SdvStateChangedLog");
            this.imageList.Images.SetKeyName(2, "SdvStateChangedLog_Opened.png");
            this.imageList.Images.SetKeyName(3, "SdvStateChangedLog_Connected.png");
            this.imageList.Images.SetKeyName(4, "SdvStateChangedLog_Selected.png");
            this.imageList.Images.SetKeyName(5, "SdvStateChangedLog_Closed.png");
            this.imageList.Images.SetKeyName(6, "ApplicationLog.png");
            this.imageList.Images.SetKeyName(7, "ApplicationWritedLog.png");
            this.imageList.Images.SetKeyName(8, "BranchRaisedLog.png");
            this.imageList.Images.SetKeyName(9, "CallbackRaisedLog.png");
            this.imageList.Images.SetKeyName(10, "CommentWritedLog.png");
            this.imageList.Images.SetKeyName(11, "ContentLog.png");
            this.imageList.Images.SetKeyName(12, "ContentLog_List.png");
            this.imageList.Images.SetKeyName(13, "ConvertToSml.png");
            this.imageList.Images.SetKeyName(14, "ConvertToVfei.png");
            this.imageList.Images.SetKeyName(15, "DataLog.png");
            this.imageList.Images.SetKeyName(16, "DataLog_List.png");
            this.imageList.Images.SetKeyName(17, "DataSetLog.png");
            this.imageList.Images.SetKeyName(18, "FunctionCalledLog.png");
            this.imageList.Images.SetKeyName(19, "FUserLogIn.png");
            this.imageList.Images.SetKeyName(20, "HdvDataMessageReceivedLog.png");
            this.imageList.Images.SetKeyName(21, "HdvDataMessageReceivedLog_Command.png");
            this.imageList.Images.SetKeyName(22, "HdvDataMessageReceivedLog_Reply.png");
            this.imageList.Images.SetKeyName(23, "HdvDataMessageReceivedLog_Unsolicited.png");
            this.imageList.Images.SetKeyName(24, "HdvDataMessageSentLog.png");
            this.imageList.Images.SetKeyName(25, "HdvDataMessageSentLog_Command.png");
            this.imageList.Images.SetKeyName(26, "HdvDataMessageSentLog_Reply.png");
            this.imageList.Images.SetKeyName(27, "HdvDataMessageSentLog_Unsolicited.png");
            this.imageList.Images.SetKeyName(28, "HdvErrorRaisedLog.png");
            this.imageList.Images.SetKeyName(29, "HdvStateChangedLog.png");
            this.imageList.Images.SetKeyName(30, "HdvStateChangedLog_Closed.png");
            this.imageList.Images.SetKeyName(31, "HdvStateChangedLog_Connected.png");
            this.imageList.Images.SetKeyName(32, "HdvStateChangedLog_Opened.png");
            this.imageList.Images.SetKeyName(33, "HdvStateChangedLog_Selected.png");
            this.imageList.Images.SetKeyName(34, "HdvVfeiReceivedLog.png");
            this.imageList.Images.SetKeyName(35, "HdvVfeiSentLog.png");
            this.imageList.Images.SetKeyName(36, "HostDeviceLog.png");
            this.imageList.Images.SetKeyName(37, "HostItemLog.png");
            this.imageList.Images.SetKeyName(38, "HostItemLog_List.png");
            this.imageList.Images.SetKeyName(39, "HostTransmitterRaisedLog.png");
            this.imageList.Images.SetKeyName(40, "HostTriggerRaisedLog.png");
            this.imageList.Images.SetKeyName(41, "JudgementPerformedLog.png");
            this.imageList.Images.SetKeyName(42, "MapperPerformedLog.png");
            this.imageList.Images.SetKeyName(43, "Result_Error.png");
            this.imageList.Images.SetKeyName(44, "Result_Warning.png");
            this.imageList.Images.SetKeyName(45, "ScenarioLog.png");
            this.imageList.Images.SetKeyName(46, "SdvBlockReceivedLog.png");
            this.imageList.Images.SetKeyName(47, "SdvBlockSentLog.png");
            this.imageList.Images.SetKeyName(48, "SdvControlMessageReceivedLog.png");
            this.imageList.Images.SetKeyName(49, "SdvControlMessageSentLog.png");
            this.imageList.Images.SetKeyName(50, "SdvDataMessageReceivedLog.png");
            this.imageList.Images.SetKeyName(51, "SdvDataMessageReceivedLog_Primary.png");
            this.imageList.Images.SetKeyName(52, "SdvDataMessageReceivedLog_Secondary.png");
            this.imageList.Images.SetKeyName(53, "SdvDataMessageSentLog.png");
            this.imageList.Images.SetKeyName(54, "SdvDataMessageSentLog_Primary.png");
            this.imageList.Images.SetKeyName(55, "SdvDataMessageSentLog_Secondary.png");
            this.imageList.Images.SetKeyName(56, "SdvDataReceivedLog.png");
            this.imageList.Images.SetKeyName(57, "SdvDataSentLog.png");
            this.imageList.Images.SetKeyName(58, "SdvErrorRaisedLog.png");
            this.imageList.Images.SetKeyName(59, "SdvHandshakeReceivedLog.png");
            this.imageList.Images.SetKeyName(60, "SdvHandshakeSentLog.png");
            this.imageList.Images.SetKeyName(61, "SdvSmlReceivedLog.png");
            this.imageList.Images.SetKeyName(62, "SdvSmlSentLog.png");
            this.imageList.Images.SetKeyName(63, "SdvTelnetPacketReceivedLog.png");
            this.imageList.Images.SetKeyName(64, "SdvTelnetPacketSentLog.png");
            this.imageList.Images.SetKeyName(65, "SdvTelnetStateChangedLog.png");
            this.imageList.Images.SetKeyName(66, "SdvTimeoutRaisedLog.png");
            this.imageList.Images.SetKeyName(67, "SecsDeviceLog.png");
            this.imageList.Images.SetKeyName(68, "SecsItemLog.png");
            this.imageList.Images.SetKeyName(69, "SecsItemLog_List.png");
            this.imageList.Images.SetKeyName(70, "SecsLogFilter.png");
            this.imageList.Images.SetKeyName(71, "SecsTransmitterRaisedLog.png");
            this.imageList.Images.SetKeyName(72, "SecsTriggerRaisedLog.png");
            this.imageList.Images.SetKeyName(73, "StoragePerformedLog.png");
            this.imageList.Images.SetKeyName(74, "ToolAttach.png");
            this.imageList.Images.SetKeyName(75, "ToolCheck.png");
            this.imageList.Images.SetKeyName(76, "ToolDetach.png");
            this.imageList.Images.SetKeyName(77, "ToolDownload.png");
            this.imageList.Images.SetKeyName(78, "ToolExport.png");
            this.imageList.Images.SetKeyName(79, "ToolFind.png");
            this.imageList.Images.SetKeyName(80, "ToolRefresh.png");
            this.imageList.Images.SetKeyName(81, "Value.png");
            this.imageList.Images.SetKeyName(82, "ValueFormula.png");
            // 
            // spcMain
            // 
            this.spcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.Location = new System.Drawing.Point(0, 3);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.tvwTree);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.spcMain.Panel2MinSize = 180;
            this.spcMain.Size = new System.Drawing.Size(1008, 302);
            this.spcMain.SplitterDistance = 756;
            this.spcMain.TabIndex = 2;
            // 
            // tvwTree
            // 
            this.tvwTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.tvwTree.Appearance = appearance1;
            this.tvwTree.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tvwTree.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.tvwTree.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Font = new System.Drawing.Font("Verdana", 9F);
            this.tvwTree.HideSelection = false;
            this.tvwTree.ImageList = this.imageList;
            this.tvwTree.Location = new System.Drawing.Point(0, 2);
            this.tvwTree.multiSelected = true;
            this.tvwTree.Name = "tvwTree";
            this.tvwTree.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance2.ForeColor = System.Drawing.Color.Black;
            _override1.ActiveNodeAppearance = appearance2;
            _override1.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            _override1.ItemHeight = 18;
            _override1.Multiline = Infragistics.Win.DefaultableBoolean.False;
            appearance3.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance3.ForeColor = System.Drawing.Color.Black;
            _override1.NodeAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance4.BackColor2 = System.Drawing.Color.LightGray;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance4.ForeColor = System.Drawing.Color.Black;
            _override1.SelectedNodeAppearance = appearance4;
            _override1.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended;
            _override1.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            _override1.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwTree.ScrollBarLook = scrollBarLook1;
            this.tvwTree.Size = new System.Drawing.Size(756, 300);
            this.tvwTree.TabIndex = 0;
            this.tvwTree.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwTree.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwTree_AfterActivate);
            this.tvwTree.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwTree_AfterExpand);
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
            this.pgdProp.Location = new System.Drawing.Point(0, 2);
            this.pgdProp.Name = "pgdProp";
            this.pgdProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdProp.selectedObject = null;
            this.pgdProp.Size = new System.Drawing.Size(248, 300);
            this.pgdProp.TabIndex = 0;
            this.pgdProp.ToolbarVisible = false;
            this.pgdProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // FControlFormBase_Fill_Panel
            // 
            // 
            // FControlFormBase_Fill_Panel.ClientArea
            // 
            this.FControlFormBase_Fill_Panel.ClientArea.Controls.Add(this.ClientArea_Fill_Panel);
            this.FControlFormBase_Fill_Panel.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Left);
            this.FControlFormBase_Fill_Panel.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Right);
            this.FControlFormBase_Fill_Panel.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Bottom);
            this.FControlFormBase_Fill_Panel.ClientArea.Controls.Add(this._ClientArea_Toolbars_Dock_Area_Top);
            this.FControlFormBase_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FControlFormBase_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FControlFormBase_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.FControlFormBase_Fill_Panel.Name = "FControlFormBase_Fill_Panel";
            this.FControlFormBase_Fill_Panel.Size = new System.Drawing.Size(1008, 328);
            this.FControlFormBase_Fill_Panel.TabIndex = 21;
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.FControlFormBase_Fill_Panel.ClientArea;
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(1, 1);
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool3,
            buttonTool4});
            ultraToolbar1.Text = "ToolBar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            appearance5.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolExpand;
            buttonTool1.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool1.SharedPropsInternal.Caption = "Expand(&E)";
            buttonTool1.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            appearance6.Image = global::Nexplant.MC.AdminManager.Properties.Resources.ToolCollapse;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool2.SharedPropsInternal.Caption = "Collapse(&L)";
            buttonTool2.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftC;
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // ClientArea_Fill_Panel
            // 
            // 
            // ClientArea_Fill_Panel.ClientArea
            // 
            this.ClientArea_Fill_Panel.ClientArea.Controls.Add(this.spcMain);
            this.ClientArea_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClientArea_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientArea_Fill_Panel.Location = new System.Drawing.Point(0, 23);
            this.ClientArea_Fill_Panel.Name = "ClientArea_Fill_Panel";
            this.ClientArea_Fill_Panel.Size = new System.Drawing.Size(1008, 305);
            this.ClientArea_Fill_Panel.TabIndex = 0;
            // 
            // _ClientArea_Toolbars_Dock_Area_Left
            // 
            this._ClientArea_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._ClientArea_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 23);
            this._ClientArea_Toolbars_Dock_Area_Left.Name = "_ClientArea_Toolbars_Dock_Area_Left";
            this._ClientArea_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 305);
            this._ClientArea_Toolbars_Dock_Area_Left.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Right
            // 
            this._ClientArea_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._ClientArea_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1008, 23);
            this._ClientArea_Toolbars_Dock_Area_Right.Name = "_ClientArea_Toolbars_Dock_Area_Right";
            this._ClientArea_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 305);
            this._ClientArea_Toolbars_Dock_Area_Right.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Top
            // 
            this._ClientArea_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._ClientArea_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._ClientArea_Toolbars_Dock_Area_Top.Name = "_ClientArea_Toolbars_Dock_Area_Top";
            this._ClientArea_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1008, 23);
            this._ClientArea_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // _ClientArea_Toolbars_Dock_Area_Bottom
            // 
            this._ClientArea_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._ClientArea_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(245)))));
            this._ClientArea_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._ClientArea_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ClientArea_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 328);
            this._ClientArea_Toolbars_Dock_Area_Bottom.Name = "_ClientArea_Toolbars_Dock_Area_Bottom";
            this._ClientArea_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1008, 0);
            this._ClientArea_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.mnuMenu;
            // 
            // FOpcLogObjectViewer
            // 
            this.ClientSize = new System.Drawing.Size(1008, 355);
            this.Controls.Add(this.FControlFormBase_Fill_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FOpcLogObjectViewer";
            this.Text = "OPC Log Object Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FOpcLogObjectViewer_FormClosing);
            this.Load += new System.EventHandler(this.FOpcLogObjectViewer_Load);
            this.Shown += new System.EventHandler(this.FOpcLogObjectViewer_Shown);
            this.Enter += new System.EventHandler(this.FOpcLogObjectViewer_Enter);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.Controls.SetChildIndex(this.FControlFormBase_Fill_Panel, 0);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).EndInit();
            this.FControlFormBase_Fill_Panel.ClientArea.ResumeLayout(false);
            this.FControlFormBase_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.ClientArea_Fill_Panel.ClientArea.ResumeLayout(false);
            this.ClientArea_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FTreeView tvwTree;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Infragistics.Win.Misc.UltraPanel FControlFormBase_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager mnuMenu;
        private Infragistics.Win.Misc.UltraPanel ClientArea_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _ClientArea_Toolbars_Dock_Area_Top;

    }
}
