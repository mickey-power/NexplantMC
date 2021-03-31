namespace Nexplant.MC.OpcModeler
{
    partial class FOpcDeviceModeler
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
            Infragistics.Win.UltraWinTree.Override _override1 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool67 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool71 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Read OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Write OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool74 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool76 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool77 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool78 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Primary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Secondary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool70 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool69 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool94 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Primary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Secondary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool61 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool84 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool86 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Device");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Device");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Device");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Session");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Session");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Session");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Message List");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Message List");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Message List");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Messages");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Messages");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Messages");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Primary OPC Message");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Secondary OPC Message");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool82 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool83 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Read OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Write OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool112 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Virtual Read OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool88 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool89 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool129 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool90 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool91 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool115 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy Values");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool119 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Values");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool92 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool93 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool60 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Primary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool63 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Secondary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool131 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import Tag By CSV");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool132 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import Tag By Text");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool95 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool100 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool101 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool96 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool104 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Multi Item Editor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool126 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Plc Address Editor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool108 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Validation OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool110 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset Item List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool124 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset Item Value");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Device");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Session");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Message List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Messages");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Primary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Secondary OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool98 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool68 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool120 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Event Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool122 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool123 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool113 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool58 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool64 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool65 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool72 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Open OPC Device");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool73 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Close OPC Device");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool75 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool79 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool80 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool81 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Primary OPC Message");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool59 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Secondary OPC Message");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool85 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Write OPC Message");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool87 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool106 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Event Item");
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool107 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append OPC Item");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool116 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Item");
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool117 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Item");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool97 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Read OPC Message");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool62 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before OPC Event Item");
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool66 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After OPC Event Item");
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool99 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import Tag By Text");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool103 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Multi Item Editor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool105 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Validation OPC Item");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool109 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset Item List");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool111 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Virtual Read OPC Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool114 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy Values");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool118 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Values");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool121 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Reset Item Value");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool125 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Plc Address Editor");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool128 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool127 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Import Tag By CSV");
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FOpcDeviceModeler));
            this.tvwTree = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.rstToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.FControlFormBase_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.FControlFormBase_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.spcMain);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // tvwTree
            // 
            this.tvwTree.AllowDrop = true;
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
            this.tvwTree.Location = new System.Drawing.Point(0, 25);
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
            this.tvwTree.Size = new System.Drawing.Size(722, 478);
            this.tvwTree.TabIndex = 1;
            this.tvwTree.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwTree.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tvwTree.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwTree_AfterActivate);
            this.tvwTree.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwTree_AfterExpand);
            this.tvwTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwTree_DragDrop);
            this.tvwTree.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwTree_DragOver);
            this.tvwTree.Enter += new System.EventHandler(this.tvwTree_Enter);
            this.tvwTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwTree_KeyDown);
            this.tvwTree.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvwTree_MouseMove);
            // 
            // mnuMenu
            // 
            this.mnuMenu.DesignerFlags = 1;
            this.mnuMenu.DockWithinContainer = this.pnlMenu;
            this.mnuMenu.LockToolbars = true;
            this.mnuMenu.MdiMergeable = false;
            this.mnuMenu.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.mnuMenu.ShowFullMenusDelay = 500;
            this.mnuMenu.ShowQuickCustomizeButton = false;
            this.mnuMenu.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.ScenicRibbon;
            this.mnuMenu.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            buttonTool32.InstanceProps.IsFirstInGroup = true;
            buttonTool39.InstanceProps.IsFirstInGroup = true;
            buttonTool74.InstanceProps.IsFirstInGroup = true;
            buttonTool35.InstanceProps.IsFirstInGroup = true;
            buttonTool70.InstanceProps.IsFirstInGroup = true;
            buttonTool94.InstanceProps.IsFirstInGroup = true;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            buttonTool7.InstanceProps.IsFirstInGroup = true;
            buttonTool11.InstanceProps.IsFirstInGroup = true;
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool48.InstanceProps.IsFirstInGroup = true;
            buttonTool34.InstanceProps.IsFirstInGroup = true;
            buttonTool49.InstanceProps.IsFirstInGroup = true;
            buttonTool84.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool67,
            buttonTool71,
            buttonTool32,
            buttonTool47,
            buttonTool39,
            buttonTool54,
            buttonTool74,
            buttonTool76,
            buttonTool77,
            buttonTool78,
            buttonTool29,
            buttonTool30,
            buttonTool35,
            buttonTool70,
            buttonTool69,
            buttonTool94,
            buttonTool2,
            buttonTool3,
            buttonTool1,
            buttonTool5,
            buttonTool6,
            buttonTool4,
            buttonTool8,
            buttonTool9,
            buttonTool7,
            buttonTool11,
            buttonTool12,
            buttonTool10,
            buttonTool13,
            buttonTool14,
            buttonTool48,
            buttonTool34,
            buttonTool61,
            buttonTool49,
            buttonTool84,
            buttonTool86});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance5.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcDevice;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool15.SharedPropsInternal.Caption = "Append OPC Device(&P)";
            appearance6.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcDevice;
            buttonTool16.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool16.SharedPropsInternal.Caption = "Insert Before OPC Device(&B)";
            appearance7.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcDevice;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            buttonTool17.SharedPropsInternal.Caption = "Insert After OPC Device(&A)";
            appearance8.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcSession;
            buttonTool18.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            buttonTool18.SharedPropsInternal.Caption = "Append OPC Session(&P)";
            appearance9.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcSession;
            buttonTool19.SharedPropsInternal.AppearancesSmall.Appearance = appearance9;
            buttonTool19.SharedPropsInternal.Caption = "Insert Before OPC Session(&B)";
            appearance10.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcSession;
            buttonTool20.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            buttonTool20.SharedPropsInternal.Caption = "Insert After OPC Session(&A)";
            appearance11.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcMessageList;
            buttonTool21.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
            buttonTool21.SharedPropsInternal.Caption = "Append OPC Message List(&P)";
            appearance12.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcMessageList;
            buttonTool22.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            buttonTool22.SharedPropsInternal.Caption = "Insert Before OPC Message List(&B)";
            appearance13.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcMessageList;
            buttonTool23.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool23.SharedPropsInternal.Caption = "Insert After OPC Message List(&A)";
            appearance14.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcMessages;
            buttonTool24.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool24.SharedPropsInternal.Caption = "Append OPC Messages(&P)";
            appearance15.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcMessages;
            buttonTool25.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool25.SharedPropsInternal.Caption = "Insert Before OPC Messages(&B)";
            appearance16.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcMessages;
            buttonTool26.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool26.SharedPropsInternal.Caption = "Insert After OPC Messages(&A)";
            appearance17.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendPrimaryOpcMessage;
            buttonTool27.SharedPropsInternal.AppearancesSmall.Appearance = appearance17;
            buttonTool27.SharedPropsInternal.Caption = "Append Primary OPC Message(&P)";
            appearance18.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendSecondaryOpcMessage;
            buttonTool28.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            buttonTool28.SharedPropsInternal.Caption = "Append Secondary OPC Message(&P)";
            appearance19.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolRemove;
            buttonTool36.SharedPropsInternal.AppearancesSmall.Appearance = appearance19;
            buttonTool36.SharedPropsInternal.Caption = "Remove(&R)";
            popupMenuTool1.SharedPropsInternal.Caption = "PopupMenu";
            buttonTool33.InstanceProps.IsFirstInGroup = true;
            buttonTool112.InstanceProps.IsFirstInGroup = true;
            buttonTool88.InstanceProps.IsFirstInGroup = true;
            buttonTool129.InstanceProps.IsFirstInGroup = true;
            buttonTool90.InstanceProps.IsFirstInGroup = true;
            buttonTool131.InstanceProps.IsFirstInGroup = true;
            buttonTool95.InstanceProps.IsFirstInGroup = true;
            buttonTool100.InstanceProps.IsFirstInGroup = true;
            buttonTool96.InstanceProps.IsFirstInGroup = true;
            buttonTool104.InstanceProps.IsFirstInGroup = true;
            buttonTool126.InstanceProps.IsFirstInGroup = true;
            buttonTool108.InstanceProps.IsFirstInGroup = true;
            buttonTool110.InstanceProps.IsFirstInGroup = true;
            buttonTool37.InstanceProps.IsFirstInGroup = true;
            buttonTool41.InstanceProps.IsFirstInGroup = true;
            buttonTool40.InstanceProps.IsFirstInGroup = true;
            buttonTool43.InstanceProps.IsFirstInGroup = true;
            buttonTool44.InstanceProps.IsFirstInGroup = true;
            buttonTool46.InstanceProps.IsFirstInGroup = true;
            buttonTool52.InstanceProps.IsFirstInGroup = true;
            buttonTool55.InstanceProps.IsFirstInGroup = true;
            buttonTool50.InstanceProps.IsFirstInGroup = true;
            buttonTool98.InstanceProps.IsFirstInGroup = true;
            buttonTool120.InstanceProps.IsFirstInGroup = true;
            buttonTool122.InstanceProps.IsFirstInGroup = true;
            buttonTool113.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool82,
            buttonTool83,
            buttonTool33,
            buttonTool31,
            buttonTool112,
            buttonTool88,
            buttonTool89,
            buttonTool129,
            buttonTool90,
            buttonTool91,
            buttonTool115,
            buttonTool119,
            buttonTool92,
            buttonTool93,
            buttonTool60,
            buttonTool63,
            buttonTool131,
            buttonTool132,
            buttonTool95,
            buttonTool100,
            buttonTool101,
            buttonTool96,
            buttonTool104,
            buttonTool126,
            buttonTool108,
            buttonTool110,
            buttonTool124,
            buttonTool37,
            buttonTool38,
            buttonTool41,
            buttonTool40,
            buttonTool42,
            buttonTool43,
            buttonTool44,
            buttonTool45,
            buttonTool46,
            buttonTool52,
            buttonTool53,
            buttonTool55,
            buttonTool50,
            buttonTool51,
            buttonTool98,
            buttonTool68,
            buttonTool120,
            buttonTool122,
            buttonTool123,
            buttonTool113});
            appearance20.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolExpand;
            buttonTool57.SharedPropsInternal.AppearancesSmall.Appearance = appearance20;
            buttonTool57.SharedPropsInternal.Caption = "Expand(&E)";
            appearance21.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCollapse;
            buttonTool58.SharedPropsInternal.AppearancesLarge.Appearance = appearance21;
            appearance22.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCollapse;
            buttonTool58.SharedPropsInternal.AppearancesSmall.Appearance = appearance22;
            buttonTool58.SharedPropsInternal.Caption = "Collapse(&L)";
            appearance23.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolMoveUp;
            buttonTool64.SharedPropsInternal.AppearancesLarge.Appearance = appearance23;
            appearance24.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolMoveUp;
            buttonTool64.SharedPropsInternal.AppearancesSmall.Appearance = appearance24;
            buttonTool64.SharedPropsInternal.Caption = "Move Up(&U)";
            appearance25.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolMoveDown;
            buttonTool65.SharedPropsInternal.AppearancesLarge.Appearance = appearance25;
            appearance26.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolMoveDown;
            buttonTool65.SharedPropsInternal.AppearancesSmall.Appearance = appearance26;
            buttonTool65.SharedPropsInternal.Caption = "Move Down(&D)";
            appearance27.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.OpenOpcDevice;
            buttonTool72.SharedPropsInternal.AppearancesSmall.Appearance = appearance27;
            buttonTool72.SharedPropsInternal.Caption = "Open OPC Device(&O)";
            appearance28.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.CloseOpcDevice;
            buttonTool73.SharedPropsInternal.AppearancesSmall.Appearance = appearance28;
            buttonTool73.SharedPropsInternal.Caption = "Close OPC Device(&C)";
            appearance29.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCut;
            buttonTool75.SharedPropsInternal.AppearancesLarge.Appearance = appearance29;
            appearance30.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCut;
            buttonTool75.SharedPropsInternal.AppearancesSmall.Appearance = appearance30;
            buttonTool75.SharedPropsInternal.Caption = "Cut(&T)";
            appearance31.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCopy;
            buttonTool79.SharedPropsInternal.AppearancesLarge.Appearance = appearance31;
            appearance32.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolCopy;
            buttonTool79.SharedPropsInternal.AppearancesSmall.Appearance = appearance32;
            buttonTool79.SharedPropsInternal.Caption = "Copy(&C)";
            appearance33.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolPasteSibling;
            buttonTool80.SharedPropsInternal.AppearancesSmall.Appearance = appearance33;
            buttonTool80.SharedPropsInternal.Caption = "Paste Sibling(&S)";
            appearance34.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ToolPasteChild;
            buttonTool81.SharedPropsInternal.AppearancesSmall.Appearance = appearance34;
            buttonTool81.SharedPropsInternal.Caption = "Paste Child(&C)";
            appearance35.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.PastePrimaryOpcMessage;
            buttonTool56.SharedPropsInternal.AppearancesSmall.Appearance = appearance35;
            buttonTool56.SharedPropsInternal.Caption = "Paste Primary OPC Message(&P)";
            buttonTool56.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            appearance36.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.PasteSecondaryOpcMessage;
            buttonTool59.SharedPropsInternal.AppearancesSmall.Appearance = appearance36;
            buttonTool59.SharedPropsInternal.Caption = "Paste Secondary OPC Message(&P)";
            appearance37.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.WriteOpcMessage;
            buttonTool85.SharedPropsInternal.AppearancesSmall.Appearance = appearance37;
            buttonTool85.SharedPropsInternal.Caption = "Write OPC Message(&W)";
            appearance38.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.Relation_Reference;
            buttonTool87.SharedPropsInternal.AppearancesSmall.Appearance = appearance38;
            buttonTool87.SharedPropsInternal.Caption = "Relation(&R)";
            appearance39.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcEventItem;
            buttonTool106.SharedPropsInternal.AppearancesSmall.Appearance = appearance39;
            buttonTool106.SharedPropsInternal.Caption = "Append OPC Event Item(&E)";
            appearance40.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.AppendOpcItem;
            buttonTool107.SharedPropsInternal.AppearancesSmall.Appearance = appearance40;
            buttonTool107.SharedPropsInternal.Caption = "Append OPC Item(&I)";
            appearance41.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcItem;
            buttonTool116.SharedPropsInternal.AppearancesSmall.Appearance = appearance41;
            buttonTool116.SharedPropsInternal.Caption = "Insert Before OPC Item(&B)";
            appearance42.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcItem;
            buttonTool117.SharedPropsInternal.AppearancesSmall.Appearance = appearance42;
            buttonTool117.SharedPropsInternal.Caption = "Insert After OPC Item(&A)";
            appearance43.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.ReadOpcMessage;
            buttonTool97.SharedPropsInternal.AppearancesSmall.Appearance = appearance43;
            buttonTool97.SharedPropsInternal.Caption = "Read OPC Message(&R)";
            appearance44.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertBeforeOpcEventItem;
            buttonTool62.SharedPropsInternal.AppearancesSmall.Appearance = appearance44;
            buttonTool62.SharedPropsInternal.Caption = "Insert Before OPC Event Item(&B)";
            appearance45.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.InsertAfterOpcEventItem;
            buttonTool66.SharedPropsInternal.AppearancesSmall.Appearance = appearance45;
            buttonTool66.SharedPropsInternal.Caption = "Insert After OPC Event Item(&B)";
            buttonTool103.SharedPropsInternal.Caption = "Multi Item Editor";
            buttonTool105.SharedPropsInternal.Caption = "Validation OPC Item";
            buttonTool109.SharedPropsInternal.Caption = "Reset Item List";
            buttonTool111.SharedPropsInternal.Caption = "Virtual Read OPC Message";
            buttonTool114.SharedPropsInternal.Caption = "Copy Values";
            buttonTool118.SharedPropsInternal.Caption = "Paste Values";
            buttonTool121.SharedPropsInternal.Caption = "Reset Item Value";
            buttonTool125.SharedPropsInternal.Caption = "Plc Address Editor";
            buttonTool128.SharedPropsInternal.Caption = "Replace(&H)";
            appearance46.Image = global::Nexplant.MC.OpcModeler.Properties.Resources.TolImport;
            buttonTool127.SharedPropsInternal.AppearancesSmall.Appearance = appearance46;
            buttonTool127.SharedPropsInternal.Caption = "Import Tag By CSV";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool24,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28,
            buttonTool36,
            popupMenuTool1,
            buttonTool57,
            buttonTool58,
            buttonTool64,
            buttonTool65,
            buttonTool72,
            buttonTool73,
            buttonTool75,
            buttonTool79,
            buttonTool80,
            buttonTool81,
            buttonTool56,
            buttonTool59,
            buttonTool85,
            buttonTool87,
            buttonTool106,
            buttonTool107,
            buttonTool116,
            buttonTool117,
            buttonTool97,
            buttonTool62,
            buttonTool66,
            buttonTool99,
            buttonTool103,
            buttonTool105,
            buttonTool109,
            buttonTool111,
            buttonTool114,
            buttonTool118,
            buttonTool121,
            buttonTool125,
            buttonTool128,
            buttonTool127});
            this.mnuMenu.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.mnuMenu.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.mnuMenu_ToolClick);
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Left);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Right);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Bottom);
            this.pnlMenu.Controls.Add(this._pnlMenu_Toolbars_Dock_Area_Top);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenu.Location = new System.Drawing.Point(4, 4);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(976, 24);
            this.pnlMenu.TabIndex = 0;
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
            this._pnlMenu_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(976, 24);
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
            this._pnlMenu_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(976, 0);
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
            this._pnlMenu_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(976, 24);
            this._pnlMenu_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcMain.Location = new System.Drawing.Point(4, 28);
            this.spcMain.Name = "spcMain";
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.rstToolbar);
            this.spcMain.Panel1.Controls.Add(this.tvwTree);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.spcMain.Panel2MinSize = 250;
            this.spcMain.Size = new System.Drawing.Size(976, 503);
            this.spcMain.SplitterDistance = 722;
            this.spcMain.TabIndex = 2;
            this.spcMain.TabStop = false;
            // 
            // rstToolbar
            // 
            this.rstToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstToolbar.Location = new System.Drawing.Point(0, 2);
            this.rstToolbar.Margin = new System.Windows.Forms.Padding(5);
            this.rstToolbar.Name = "rstToolbar";
            this.rstToolbar.refreshEnabled = false;
            this.rstToolbar.Size = new System.Drawing.Size(722, 22);
            this.rstToolbar.TabIndex = 0;
            this.rstToolbar.TabStop = false;
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
            this.pgdProp.Location = new System.Drawing.Point(0, 2);
            this.pgdProp.Name = "pgdProp";
            this.pgdProp.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdProp.selectedObject = null;
            this.pgdProp.Size = new System.Drawing.Size(250, 501);
            this.pgdProp.TabIndex = 0;
            this.pgdProp.ToolbarVisible = false;
            this.pgdProp.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdProp.ViewForeColor = System.Drawing.Color.Black;
            // 
            // FControlFormBase_Fill_Panel
            // 
            this.FControlFormBase_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FControlFormBase_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FControlFormBase_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.FControlFormBase_Fill_Panel.Name = "FControlFormBase_Fill_Panel";
            this.FControlFormBase_Fill_Panel.Size = new System.Drawing.Size(984, 535);
            this.FControlFormBase_Fill_Panel.TabIndex = 4;
            // 
            // FOpcDeviceModeler
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.FControlFormBase_Fill_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FOpcDeviceModeler";
            this.Text = "OPC Device Modeler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FOpcDeviceModeler_FormClosing);
            this.Load += new System.EventHandler(this.FOpcDeviceModeler_Load);
            this.Shown += new System.EventHandler(this.FOpcDeviceModeler_Shown);
            this.Controls.SetChildIndex(this.FControlFormBase_Fill_Panel, 0);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.FControlFormBase_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FTreeView tvwTree;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.Misc.UltraPanel FControlFormBase_Fill_Panel;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Core.FaUIs.FRefreshAndSearchToolbar rstToolbar;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
    }
}
