namespace Nexplant.MC.TcpModeler
{
    partial class FEquipmentModeler
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool60 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Scenario Modeler");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool61 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool62 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool63 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool64 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool65 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool66 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool67 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool68 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool69 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool70 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool71 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool72 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool73 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool74 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool75 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool76 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool77 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool78 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool97 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool98 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool99 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool100 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool101 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool102 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool103 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool104 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool105 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool106 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool107 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool108 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool259 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool255 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool214 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool109 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool110 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool111 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool112 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool113 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool114 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool115 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool116 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool117 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool118 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool119 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool120 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool145 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool146 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool147 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool148 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool149 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool150 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool151 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool152 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool153 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool154 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool155 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool156 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool181 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool182 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool183 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool157 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool158 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool159 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool206 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool160 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool161 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool162 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool190 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Send TCP Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario Group");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario Group");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario Group");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool204 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Send Host Message");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool208 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool212 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clone");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool59 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Scenario Modeler");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario Group");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Scenario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Scenario");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Scenario");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool5 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert Before");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert After");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool187 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool193 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool197 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool200 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool203 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool207 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool210 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool215 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool218 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool221 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool258 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool224 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool201 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool227 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool230 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool233 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool236 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool239 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool242 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool245 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool248 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool251 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool254 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool58 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Scenario Modeler");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool79 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Trigger");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool80 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Trigger");
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool81 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Trigger");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool82 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transmitter");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool83 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Transmitter");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool84 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transmitter");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool85 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool86 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool87 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool88 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool89 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool90 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool91 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool92 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool93 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool94 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool95 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool96 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool121 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool122 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool123 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool124 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool125 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool126 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool127 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool128 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool129 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool130 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool131 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool132 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool133 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool134 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool135 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool136 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Condition");
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool137 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Condition");
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool138 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Condition");
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool139 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Expression");
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool140 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Expression");
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool141 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Expression");
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool142 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transfer");
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool143 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Transfer");
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool144 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append TCP Transfer");
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool163 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool164 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool165 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool166 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool167 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool168 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool169 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool170 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool171 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool172 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool173 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool174 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool175 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool176 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool177 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool178 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool179 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool180 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool184 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool185 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool186 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool191 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool196 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool205 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert Before");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool213 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool260 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool261 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool262 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool263 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool264 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool265 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool266 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool267 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool268 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool269 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool270 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool199 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool271 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool272 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool273 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before TCP Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool274 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool275 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool276 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool277 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool278 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool279 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool280 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert After");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool281 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool282 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool283 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool284 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool285 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool286 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool287 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool288 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool289 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool290 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool291 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool292 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool198 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool293 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool294 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After TCP Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool296 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool297 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool298 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool299 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool300 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool301 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool302 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool192 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Entry Point");
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool194 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Entry Point");
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool195 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Entry Point");
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool202 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Send Host Message");
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool211 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Send TCP Message");
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool189 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool209 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Clone");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinTree.Override _override2 = new Infragistics.Win.UltraWinTree.Override();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook2 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FEquipmentModeler));
            this.tvwScenario = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcScenario = new System.Windows.Forms.SplitContainer();
            this.rstSnrToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.spcFlow = new System.Windows.Forms.SplitContainer();
            this.flowContHost = new System.Windows.Forms.Integration.ElementHost();
            this.flcContainer = new Nexplant.MC.Core.FaUIs.WPF.FFlowContainer();
            this.rstFlowToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.tvwFlow = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.FControlFormBase_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwScenario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcScenario)).BeginInit();
            this.spcScenario.Panel1.SuspendLayout();
            this.spcScenario.Panel2.SuspendLayout();
            this.spcScenario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcFlow)).BeginInit();
            this.spcFlow.Panel1.SuspendLayout();
            this.spcFlow.Panel2.SuspendLayout();
            this.spcFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwFlow)).BeginInit();
            this.FControlFormBase_Fill_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.spcMain);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // tvwScenario
            // 
            this.tvwScenario.AllowDrop = true;
            this.tvwScenario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.tvwScenario.Appearance = appearance1;
            this.tvwScenario.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tvwScenario.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.tvwScenario.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.tvwScenario.Font = new System.Drawing.Font("Verdana", 9F);
            this.tvwScenario.HideSelection = false;
            this.tvwScenario.Location = new System.Drawing.Point(0, 25);
            this.tvwScenario.multiSelected = true;
            this.tvwScenario.Name = "tvwScenario";
            this.tvwScenario.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
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
            this.tvwScenario.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwScenario.ScrollBarLook = scrollBarLook1;
            this.tvwScenario.Size = new System.Drawing.Size(250, 478);
            this.tvwScenario.TabIndex = 1;
            this.tvwScenario.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwScenario.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tvwScenario.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwScenario_AfterActivate);
            this.tvwScenario.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwScenario_AfterExpand);
            this.tvwScenario.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwScenario_DragDrop);
            this.tvwScenario.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwScenario_DragOver);
            this.tvwScenario.Enter += new System.EventHandler(this.tvwScenario_Enter);
            this.tvwScenario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwScenario_KeyDown);
            this.tvwScenario.Leave += new System.EventHandler(this.tvwScenario_Leave);
            this.tvwScenario.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvwScenario_MouseMove);
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
            buttonTool31.InstanceProps.IsFirstInGroup = true;
            buttonTool35.InstanceProps.IsFirstInGroup = true;
            buttonTool55.InstanceProps.IsFirstInGroup = true;
            buttonTool60.InstanceProps.IsFirstInGroup = true;
            buttonTool10.InstanceProps.IsFirstInGroup = true;
            buttonTool8.InstanceProps.IsFirstInGroup = true;
            buttonTool7.InstanceProps.IsFirstInGroup = true;
            buttonTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool4.InstanceProps.IsFirstInGroup = true;
            buttonTool61.InstanceProps.IsFirstInGroup = true;
            buttonTool63.InstanceProps.IsFirstInGroup = true;
            buttonTool64.InstanceProps.IsFirstInGroup = true;
            buttonTool66.InstanceProps.IsFirstInGroup = true;
            buttonTool67.InstanceProps.IsFirstInGroup = true;
            buttonTool69.InstanceProps.IsFirstInGroup = true;
            buttonTool70.InstanceProps.IsFirstInGroup = true;
            buttonTool72.InstanceProps.IsFirstInGroup = true;
            buttonTool73.InstanceProps.IsFirstInGroup = true;
            buttonTool75.InstanceProps.IsFirstInGroup = true;
            buttonTool76.InstanceProps.IsFirstInGroup = true;
            buttonTool78.InstanceProps.IsFirstInGroup = true;
            buttonTool97.InstanceProps.IsFirstInGroup = true;
            buttonTool99.InstanceProps.IsFirstInGroup = true;
            buttonTool100.InstanceProps.IsFirstInGroup = true;
            buttonTool102.InstanceProps.IsFirstInGroup = true;
            buttonTool103.InstanceProps.IsFirstInGroup = true;
            buttonTool105.InstanceProps.IsFirstInGroup = true;
            buttonTool106.InstanceProps.IsFirstInGroup = true;
            buttonTool108.InstanceProps.IsFirstInGroup = true;
            buttonTool259.InstanceProps.IsFirstInGroup = true;
            buttonTool214.InstanceProps.IsFirstInGroup = true;
            buttonTool109.InstanceProps.IsFirstInGroup = true;
            buttonTool111.InstanceProps.IsFirstInGroup = true;
            buttonTool112.InstanceProps.IsFirstInGroup = true;
            buttonTool114.InstanceProps.IsFirstInGroup = true;
            buttonTool115.InstanceProps.IsFirstInGroup = true;
            buttonTool117.InstanceProps.IsFirstInGroup = true;
            buttonTool118.InstanceProps.IsFirstInGroup = true;
            buttonTool120.InstanceProps.IsFirstInGroup = true;
            buttonTool145.InstanceProps.IsFirstInGroup = true;
            buttonTool147.InstanceProps.IsFirstInGroup = true;
            buttonTool148.InstanceProps.IsFirstInGroup = true;
            buttonTool150.InstanceProps.IsFirstInGroup = true;
            buttonTool151.InstanceProps.IsFirstInGroup = true;
            buttonTool153.InstanceProps.IsFirstInGroup = true;
            buttonTool154.InstanceProps.IsFirstInGroup = true;
            buttonTool156.InstanceProps.IsFirstInGroup = true;
            buttonTool181.InstanceProps.IsFirstInGroup = true;
            buttonTool183.InstanceProps.IsFirstInGroup = true;
            buttonTool157.InstanceProps.IsFirstInGroup = true;
            buttonTool159.InstanceProps.IsFirstInGroup = true;
            buttonTool160.InstanceProps.IsFirstInGroup = true;
            buttonTool162.InstanceProps.IsFirstInGroup = true;
            buttonTool190.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool39,
            buttonTool54,
            buttonTool31,
            buttonTool32,
            buttonTool53,
            buttonTool50,
            buttonTool35,
            buttonTool55,
            buttonTool56,
            buttonTool60,
            buttonTool10,
            buttonTool8,
            buttonTool9,
            buttonTool7,
            buttonTool2,
            buttonTool3,
            buttonTool1,
            buttonTool5,
            buttonTool6,
            buttonTool4,
            buttonTool61,
            buttonTool62,
            buttonTool63,
            buttonTool64,
            buttonTool65,
            buttonTool66,
            buttonTool67,
            buttonTool68,
            buttonTool69,
            buttonTool70,
            buttonTool71,
            buttonTool72,
            buttonTool73,
            buttonTool74,
            buttonTool75,
            buttonTool76,
            buttonTool77,
            buttonTool78,
            buttonTool97,
            buttonTool98,
            buttonTool99,
            buttonTool100,
            buttonTool101,
            buttonTool102,
            buttonTool103,
            buttonTool104,
            buttonTool105,
            buttonTool106,
            buttonTool107,
            buttonTool108,
            buttonTool259,
            buttonTool255,
            buttonTool214,
            buttonTool109,
            buttonTool110,
            buttonTool111,
            buttonTool112,
            buttonTool113,
            buttonTool114,
            buttonTool115,
            buttonTool116,
            buttonTool117,
            buttonTool118,
            buttonTool119,
            buttonTool120,
            buttonTool145,
            buttonTool146,
            buttonTool147,
            buttonTool148,
            buttonTool149,
            buttonTool150,
            buttonTool151,
            buttonTool152,
            buttonTool153,
            buttonTool154,
            buttonTool155,
            buttonTool156,
            buttonTool181,
            buttonTool182,
            buttonTool183,
            buttonTool157,
            buttonTool158,
            buttonTool159,
            buttonTool206,
            buttonTool160,
            buttonTool161,
            buttonTool162,
            buttonTool190});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance9.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendScenarioGroup;
            buttonTool15.SharedPropsInternal.AppearancesSmall.Appearance = appearance9;
            buttonTool15.SharedPropsInternal.Caption = "Append Scenario Group(&P)";
            appearance10.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeScenarioGroup;
            buttonTool16.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            buttonTool16.SharedPropsInternal.Caption = "Insert Before Scenario Group(&B)";
            appearance11.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterScenarioGroup;
            buttonTool17.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
            buttonTool17.SharedPropsInternal.Caption = "Insert After Scenario Group(&A)";
            appearance12.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendScenario;
            buttonTool18.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            buttonTool18.SharedPropsInternal.Caption = "Append Scenario(&P)";
            appearance13.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeScenario;
            buttonTool19.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool19.SharedPropsInternal.Caption = "Insert Before Scenario(&B)";
            appearance14.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterScenario;
            buttonTool20.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool20.SharedPropsInternal.Caption = "Insert After Scenario(&A)";
            appearance15.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendEquipment;
            buttonTool21.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool21.SharedPropsInternal.Caption = "Append Equipment(&P)";
            appearance16.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeEquipment;
            buttonTool22.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool22.SharedPropsInternal.Caption = "Insert Before Equipment(&B)";
            appearance17.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterEquipment;
            buttonTool23.SharedPropsInternal.AppearancesSmall.Appearance = appearance17;
            buttonTool23.SharedPropsInternal.Caption = "Insert After Equipment(&A)";
            appearance18.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolRemove;
            buttonTool36.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            buttonTool36.SharedPropsInternal.Caption = "Remove(&R)";
            popupMenuTool1.SharedPropsInternal.Caption = "PopupMenu";
            buttonTool33.InstanceProps.IsFirstInGroup = true;
            buttonTool208.InstanceProps.IsFirstInGroup = true;
            buttonTool44.InstanceProps.IsFirstInGroup = true;
            buttonTool212.InstanceProps.IsFirstInGroup = true;
            buttonTool51.InstanceProps.IsFirstInGroup = true;
            buttonTool48.InstanceProps.IsFirstInGroup = true;
            buttonTool59.InstanceProps.IsFirstInGroup = true;
            buttonTool52.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool24.InstanceProps.IsFirstInGroup = true;
            buttonTool37.InstanceProps.IsFirstInGroup = true;
            buttonTool41.InstanceProps.IsFirstInGroup = true;
            buttonTool40.InstanceProps.IsFirstInGroup = true;
            buttonTool43.InstanceProps.IsFirstInGroup = true;
            popupMenuTool5.InstanceProps.IsFirstInGroup = true;
            buttonTool187.InstanceProps.IsFirstInGroup = true;
            buttonTool193.InstanceProps.IsFirstInGroup = true;
            buttonTool197.InstanceProps.IsFirstInGroup = true;
            buttonTool200.InstanceProps.IsFirstInGroup = true;
            buttonTool203.InstanceProps.IsFirstInGroup = true;
            buttonTool207.InstanceProps.IsFirstInGroup = true;
            buttonTool210.InstanceProps.IsFirstInGroup = true;
            buttonTool215.InstanceProps.IsFirstInGroup = true;
            buttonTool218.InstanceProps.IsFirstInGroup = true;
            buttonTool221.InstanceProps.IsFirstInGroup = true;
            buttonTool258.InstanceProps.IsFirstInGroup = true;
            buttonTool224.InstanceProps.IsFirstInGroup = true;
            buttonTool201.InstanceProps.IsFirstInGroup = true;
            buttonTool227.InstanceProps.IsFirstInGroup = true;
            buttonTool230.InstanceProps.IsFirstInGroup = true;
            buttonTool233.InstanceProps.IsFirstInGroup = true;
            buttonTool236.InstanceProps.IsFirstInGroup = true;
            buttonTool239.InstanceProps.IsFirstInGroup = true;
            buttonTool242.InstanceProps.IsFirstInGroup = true;
            buttonTool245.InstanceProps.IsFirstInGroup = true;
            buttonTool248.InstanceProps.IsFirstInGroup = true;
            buttonTool251.InstanceProps.IsFirstInGroup = true;
            buttonTool254.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool204,
            buttonTool33,
            buttonTool34,
            buttonTool208,
            buttonTool44,
            buttonTool45,
            buttonTool46,
            buttonTool47,
            buttonTool212,
            buttonTool51,
            buttonTool48,
            buttonTool49,
            buttonTool59,
            buttonTool52,
            buttonTool13,
            buttonTool14,
            buttonTool24,
            buttonTool37,
            buttonTool38,
            buttonTool41,
            buttonTool40,
            buttonTool42,
            buttonTool43,
            popupMenuTool5,
            popupMenuTool4,
            buttonTool187,
            buttonTool193,
            buttonTool197,
            buttonTool200,
            buttonTool203,
            buttonTool207,
            buttonTool210,
            buttonTool215,
            buttonTool218,
            buttonTool221,
            buttonTool258,
            buttonTool224,
            buttonTool201,
            buttonTool227,
            buttonTool230,
            buttonTool233,
            buttonTool236,
            buttonTool239,
            buttonTool242,
            buttonTool245,
            buttonTool248,
            buttonTool251,
            buttonTool254});
            appearance19.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolExpand;
            buttonTool57.SharedPropsInternal.AppearancesSmall.Appearance = appearance19;
            buttonTool57.SharedPropsInternal.Caption = "Expand(&E)";
            appearance20.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolCollapse;
            buttonTool58.SharedPropsInternal.AppearancesSmall.Appearance = appearance20;
            buttonTool58.SharedPropsInternal.Caption = "Collapse(&L)";
            appearance21.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ModelingScenarioModeler;
            buttonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance21;
            buttonTool11.SharedPropsInternal.Caption = "Scenario Modeler(&M)";
            appearance22.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolCopy;
            buttonTool25.SharedPropsInternal.AppearancesSmall.Appearance = appearance22;
            buttonTool25.SharedPropsInternal.Caption = "Copy(&C)";
            appearance23.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolCut;
            buttonTool26.SharedPropsInternal.AppearancesSmall.Appearance = appearance23;
            buttonTool26.SharedPropsInternal.Caption = "Cut(&T)";
            appearance24.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolPasteChild;
            buttonTool27.SharedPropsInternal.AppearancesSmall.Appearance = appearance24;
            buttonTool27.SharedPropsInternal.Caption = "Paste Child(&C)";
            buttonTool27.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            appearance25.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolPasteSibling;
            buttonTool28.SharedPropsInternal.AppearancesSmall.Appearance = appearance25;
            buttonTool28.SharedPropsInternal.Caption = "Paste Sibling(&S)";
            appearance26.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolMoveUp;
            buttonTool29.SharedPropsInternal.AppearancesSmall.Appearance = appearance26;
            buttonTool29.SharedPropsInternal.Caption = "Move Up(&U)";
            appearance27.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ToolMoveDown;
            buttonTool30.SharedPropsInternal.AppearancesSmall.Appearance = appearance27;
            buttonTool30.SharedPropsInternal.Caption = "Move Down(&D)";
            appearance28.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.ViewRelation;
            buttonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance28;
            buttonTool12.SharedPropsInternal.Caption = "Relation(&R)";
            appearance29.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeTcpTrigger;
            buttonTool79.SharedPropsInternal.AppearancesSmall.Appearance = appearance29;
            buttonTool79.SharedPropsInternal.Caption = "Insert Before TCP Trigger(&B)";
            appearance30.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterTcpTrigger;
            buttonTool80.SharedPropsInternal.AppearancesSmall.Appearance = appearance30;
            buttonTool80.SharedPropsInternal.Caption = "Insert After TCP Trigger(&A)";
            appearance31.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendTcpTrigger;
            buttonTool81.SharedPropsInternal.AppearancesSmall.Appearance = appearance31;
            buttonTool81.SharedPropsInternal.Caption = "Append TCP Trigger(&P)";
            appearance32.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeTcpTransmitter;
            buttonTool82.SharedPropsInternal.AppearancesSmall.Appearance = appearance32;
            buttonTool82.SharedPropsInternal.Caption = "Insert Before TCP Transmitter(&B)";
            appearance33.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterTcpTransmitter;
            buttonTool83.SharedPropsInternal.AppearancesSmall.Appearance = appearance33;
            buttonTool83.SharedPropsInternal.Caption = "Insert After TCP Transmitter(&A)";
            appearance34.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendTcpTransmitter;
            buttonTool84.SharedPropsInternal.AppearancesSmall.Appearance = appearance34;
            buttonTool84.SharedPropsInternal.Caption = "Append TCP Transmitter(&P)";
            appearance35.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeHostTrigger;
            buttonTool85.SharedPropsInternal.AppearancesSmall.Appearance = appearance35;
            buttonTool85.SharedPropsInternal.Caption = "Insert Before Host Trigger(&B)";
            appearance36.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterHostTrigger;
            buttonTool86.SharedPropsInternal.AppearancesSmall.Appearance = appearance36;
            buttonTool86.SharedPropsInternal.Caption = "Insert After Host Trigger(&A)";
            appearance37.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendHostTrigger;
            buttonTool87.SharedPropsInternal.AppearancesSmall.Appearance = appearance37;
            buttonTool87.SharedPropsInternal.Caption = "Append Host Trigger(&P)";
            appearance38.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeHostTransmitter;
            buttonTool88.SharedPropsInternal.AppearancesSmall.Appearance = appearance38;
            buttonTool88.SharedPropsInternal.Caption = "Insert Before Host Transmitter(&B)";
            appearance39.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterHostTransmitter;
            buttonTool89.SharedPropsInternal.AppearancesSmall.Appearance = appearance39;
            buttonTool89.SharedPropsInternal.Caption = "Insert After Host Transmitter(&A)";
            appearance40.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendHostTransmitter;
            buttonTool90.SharedPropsInternal.AppearancesSmall.Appearance = appearance40;
            buttonTool90.SharedPropsInternal.Caption = "Append Host Transmitter(&P)";
            appearance41.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeEquipmentStateSetAlterer;
            buttonTool91.SharedPropsInternal.AppearancesSmall.Appearance = appearance41;
            buttonTool91.SharedPropsInternal.Caption = "Insert Before Equipment State Set Alterer(&B)";
            appearance42.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterEquipmentStateSetAlterer;
            buttonTool92.SharedPropsInternal.AppearancesSmall.Appearance = appearance42;
            buttonTool92.SharedPropsInternal.Caption = "Insert After Equipment State Set Alterer(&A)";
            appearance43.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendEquipmentStateSetAlterer;
            buttonTool93.SharedPropsInternal.AppearancesSmall.Appearance = appearance43;
            buttonTool93.SharedPropsInternal.Caption = "Append Equipment State Set Alterer(&P)";
            appearance44.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeJudgement;
            buttonTool94.SharedPropsInternal.AppearancesSmall.Appearance = appearance44;
            buttonTool94.SharedPropsInternal.Caption = "Insert Before Judgement(&B)";
            appearance45.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterJudgement;
            buttonTool95.SharedPropsInternal.AppearancesSmall.Appearance = appearance45;
            buttonTool95.SharedPropsInternal.Caption = "Insert After Judgement(&A)";
            appearance46.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendJudgement;
            buttonTool96.SharedPropsInternal.AppearancesSmall.Appearance = appearance46;
            buttonTool96.SharedPropsInternal.Caption = "Append Judgement(&P)";
            appearance47.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeMapper;
            buttonTool121.SharedPropsInternal.AppearancesSmall.Appearance = appearance47;
            buttonTool121.SharedPropsInternal.Caption = "Insert Before Mapper(&B)";
            appearance48.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterMapper;
            buttonTool122.SharedPropsInternal.AppearancesSmall.Appearance = appearance48;
            buttonTool122.SharedPropsInternal.Caption = "Insert After Mapper(&A)";
            appearance49.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendMapper;
            buttonTool123.SharedPropsInternal.AppearancesSmall.Appearance = appearance49;
            buttonTool123.SharedPropsInternal.Caption = "Append Mapper(&P)";
            appearance50.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeStorage;
            buttonTool124.SharedPropsInternal.AppearancesSmall.Appearance = appearance50;
            buttonTool124.SharedPropsInternal.Caption = "Insert Before Storage(&B)";
            appearance51.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterStorage;
            buttonTool125.SharedPropsInternal.AppearancesSmall.Appearance = appearance51;
            buttonTool125.SharedPropsInternal.Caption = "Insert After Storage(&A)";
            appearance52.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendStorage;
            buttonTool126.SharedPropsInternal.AppearancesSmall.Appearance = appearance52;
            buttonTool126.SharedPropsInternal.Caption = "Append Storage(&P)";
            appearance53.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeCallback;
            buttonTool127.SharedPropsInternal.AppearancesSmall.Appearance = appearance53;
            buttonTool127.SharedPropsInternal.Caption = "Insert Before Callback(&B)";
            appearance54.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterCallback;
            buttonTool128.SharedPropsInternal.AppearancesSmall.Appearance = appearance54;
            buttonTool128.SharedPropsInternal.Caption = "Insert After Callback(&A)";
            appearance55.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendCallback;
            buttonTool129.SharedPropsInternal.AppearancesSmall.Appearance = appearance55;
            buttonTool129.SharedPropsInternal.Caption = "Append Callback(&P)";
            appearance56.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeBranch;
            buttonTool130.SharedPropsInternal.AppearancesSmall.Appearance = appearance56;
            buttonTool130.SharedPropsInternal.Caption = "Insert Before Branch(&B)";
            appearance57.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterBranch;
            buttonTool131.SharedPropsInternal.AppearancesSmall.Appearance = appearance57;
            buttonTool131.SharedPropsInternal.Caption = "Insert After Branch(&A)";
            appearance58.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendBranch;
            buttonTool132.SharedPropsInternal.AppearancesSmall.Appearance = appearance58;
            buttonTool132.SharedPropsInternal.Caption = "Append Branch(&P)";
            appearance59.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeComment;
            buttonTool133.SharedPropsInternal.AppearancesSmall.Appearance = appearance59;
            buttonTool133.SharedPropsInternal.Caption = "Insert Before Comment(&B)";
            appearance60.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterComment;
            buttonTool134.SharedPropsInternal.AppearancesSmall.Appearance = appearance60;
            buttonTool134.SharedPropsInternal.Caption = "Insert After Comment(&A)";
            appearance61.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendComment;
            buttonTool135.SharedPropsInternal.AppearancesSmall.Appearance = appearance61;
            buttonTool135.SharedPropsInternal.Caption = "Append Comment(&P)";
            appearance62.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeTcpCondition;
            buttonTool136.SharedPropsInternal.AppearancesSmall.Appearance = appearance62;
            buttonTool136.SharedPropsInternal.Caption = "Insert Before TCP Condition(&B)";
            appearance63.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterTcpCondition;
            buttonTool137.SharedPropsInternal.AppearancesSmall.Appearance = appearance63;
            buttonTool137.SharedPropsInternal.Caption = "Insert After TCP Condition(&A)";
            appearance64.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendTcpCondition;
            buttonTool138.SharedPropsInternal.AppearancesSmall.Appearance = appearance64;
            buttonTool138.SharedPropsInternal.Caption = "Append TCP Condition(&P)";
            appearance65.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeTcpExpression;
            buttonTool139.SharedPropsInternal.AppearancesSmall.Appearance = appearance65;
            buttonTool139.SharedPropsInternal.Caption = "Insert Before TCP Expression(&B)";
            appearance66.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterTcpExpression;
            buttonTool140.SharedPropsInternal.AppearancesSmall.Appearance = appearance66;
            buttonTool140.SharedPropsInternal.Caption = "Insert After TCP Expression(&A)";
            appearance67.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendTcpExpression;
            buttonTool141.SharedPropsInternal.AppearancesSmall.Appearance = appearance67;
            buttonTool141.SharedPropsInternal.Caption = "Append TCP Expression(&P)";
            appearance68.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeTcpTransfer;
            buttonTool142.SharedPropsInternal.AppearancesSmall.Appearance = appearance68;
            buttonTool142.SharedPropsInternal.Caption = "Insert Before TCP Transfer(&B)";
            appearance69.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterTcpTransfer;
            buttonTool143.SharedPropsInternal.AppearancesSmall.Appearance = appearance69;
            buttonTool143.SharedPropsInternal.Caption = "Insert After TCP Transfer(&A)";
            appearance70.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendTcpTransfer;
            buttonTool144.SharedPropsInternal.AppearancesSmall.Appearance = appearance70;
            buttonTool144.SharedPropsInternal.Caption = "Append TCP Transfer(&P)";
            appearance71.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeHostCondition;
            buttonTool163.SharedPropsInternal.AppearancesSmall.Appearance = appearance71;
            buttonTool163.SharedPropsInternal.Caption = "Insert Before Host Condition(&B)";
            appearance72.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterHostCondition;
            buttonTool164.SharedPropsInternal.AppearancesSmall.Appearance = appearance72;
            buttonTool164.SharedPropsInternal.Caption = "Insert After Host Condition(&A)";
            appearance73.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendHostCondition;
            buttonTool165.SharedPropsInternal.AppearancesSmall.Appearance = appearance73;
            buttonTool165.SharedPropsInternal.Caption = "Append Host Condition(&P)";
            appearance74.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeHostExpression;
            buttonTool166.SharedPropsInternal.AppearancesSmall.Appearance = appearance74;
            buttonTool166.SharedPropsInternal.Caption = "Insert Before Host Expression(&B)";
            appearance75.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterHostExpression;
            buttonTool167.SharedPropsInternal.AppearancesSmall.Appearance = appearance75;
            buttonTool167.SharedPropsInternal.Caption = "Insert After Host Expression(&A)";
            appearance76.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendHostExpression;
            buttonTool168.SharedPropsInternal.AppearancesSmall.Appearance = appearance76;
            buttonTool168.SharedPropsInternal.Caption = "Append Host Expression(&P)";
            appearance77.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeHostTransfer;
            buttonTool169.SharedPropsInternal.AppearancesSmall.Appearance = appearance77;
            buttonTool169.SharedPropsInternal.Caption = "Insert Before Host Transfer(&B)";
            appearance78.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterHostTransfer;
            buttonTool170.SharedPropsInternal.AppearancesSmall.Appearance = appearance78;
            buttonTool170.SharedPropsInternal.Caption = "Insert After Host Transfer(&A)";
            appearance79.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendHostTransfer;
            buttonTool171.SharedPropsInternal.AppearancesSmall.Appearance = appearance79;
            buttonTool171.SharedPropsInternal.Caption = "Append Host Transfer(&P)";
            appearance80.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeEquipmentStateAlterer;
            buttonTool172.SharedPropsInternal.AppearancesSmall.Appearance = appearance80;
            buttonTool172.SharedPropsInternal.Caption = "Insert Before Equipment State Alterer(&B)";
            appearance81.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterEquipmentStateAlterer;
            buttonTool173.SharedPropsInternal.AppearancesSmall.Appearance = appearance81;
            buttonTool173.SharedPropsInternal.Caption = "Insert After Equipment State Alterer(&A)";
            appearance82.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendEquipmentStateAlterer;
            buttonTool174.SharedPropsInternal.AppearancesSmall.Appearance = appearance82;
            buttonTool174.SharedPropsInternal.Caption = "Append Equipment State Alterer(&P)";
            appearance83.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeJudgementExpression;
            buttonTool175.SharedPropsInternal.AppearancesSmall.Appearance = appearance83;
            buttonTool175.SharedPropsInternal.Caption = "Insert Before Judgement Expression(&B)";
            appearance84.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterJudgementExpression;
            buttonTool176.SharedPropsInternal.AppearancesSmall.Appearance = appearance84;
            buttonTool176.SharedPropsInternal.Caption = "Insert After Judgement Expression(&A)";
            appearance85.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendJudgementExpression;
            buttonTool177.SharedPropsInternal.AppearancesSmall.Appearance = appearance85;
            buttonTool177.SharedPropsInternal.Caption = "Append Judgement Expression(&P)";
            appearance86.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeFunction;
            buttonTool178.SharedPropsInternal.AppearancesSmall.Appearance = appearance86;
            buttonTool178.SharedPropsInternal.Caption = "Insert Before Function(&B)";
            appearance87.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterFunction;
            buttonTool179.SharedPropsInternal.AppearancesSmall.Appearance = appearance87;
            buttonTool179.SharedPropsInternal.Caption = "Insert After Function(&A)";
            appearance88.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendFunction;
            buttonTool180.SharedPropsInternal.AppearancesSmall.Appearance = appearance88;
            buttonTool180.SharedPropsInternal.Caption = "Append Function(&P)";
            appearance89.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeJudgementCondition;
            buttonTool184.SharedPropsInternal.AppearancesSmall.Appearance = appearance89;
            buttonTool184.SharedPropsInternal.Caption = "Insert Before Judgement Condition(&B)";
            appearance90.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterJudgementCondition;
            buttonTool185.SharedPropsInternal.AppearancesSmall.Appearance = appearance90;
            buttonTool185.SharedPropsInternal.Caption = "Insert After Judgement Condition(&A)";
            appearance91.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendJudgementCondition;
            buttonTool186.SharedPropsInternal.AppearancesSmall.Appearance = appearance91;
            buttonTool186.SharedPropsInternal.Caption = "Append Judgement Condition(&P)";
            appearance92.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforePauser;
            buttonTool191.SharedPropsInternal.AppearancesSmall.Appearance = appearance92;
            buttonTool191.SharedPropsInternal.Caption = "Insert Before Pauser(&B)";
            appearance93.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterPauser;
            buttonTool196.SharedPropsInternal.AppearancesSmall.Appearance = appearance93;
            buttonTool196.SharedPropsInternal.Caption = "Insert After Pauser(&A)";
            appearance94.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendPauser;
            buttonTool205.SharedPropsInternal.AppearancesSmall.Appearance = appearance94;
            buttonTool205.SharedPropsInternal.Caption = "Append Pauser(&P)";
            popupMenuTool2.SharedPropsInternal.Caption = "Insert Before";
            popupMenuTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool213,
            buttonTool260,
            buttonTool261,
            buttonTool262,
            buttonTool263,
            buttonTool264,
            buttonTool265,
            buttonTool266,
            buttonTool267,
            buttonTool268,
            buttonTool269,
            buttonTool270,
            buttonTool199,
            buttonTool271,
            buttonTool272,
            buttonTool273,
            buttonTool274,
            buttonTool275,
            buttonTool276,
            buttonTool277,
            buttonTool278,
            buttonTool279,
            buttonTool280});
            popupMenuTool3.SharedPropsInternal.Caption = "Insert After";
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool281,
            buttonTool282,
            buttonTool283,
            buttonTool284,
            buttonTool285,
            buttonTool286,
            buttonTool287,
            buttonTool288,
            buttonTool289,
            buttonTool290,
            buttonTool291,
            buttonTool292,
            buttonTool198,
            buttonTool293,
            buttonTool294,
            buttonTool296,
            buttonTool297,
            buttonTool298,
            buttonTool299,
            buttonTool300,
            buttonTool301,
            buttonTool302});
            appearance95.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertBeforeEntryPoint;
            buttonTool192.SharedPropsInternal.AppearancesSmall.Appearance = appearance95;
            buttonTool192.SharedPropsInternal.Caption = "Insert Before Entry Point(&B)";
            appearance96.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.InsertAfterEntryPoint;
            buttonTool194.SharedPropsInternal.AppearancesSmall.Appearance = appearance96;
            buttonTool194.SharedPropsInternal.Caption = "Insert After Entry Point(&A)";
            appearance97.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.AppendEntryPoint;
            buttonTool195.SharedPropsInternal.AppearancesSmall.Appearance = appearance97;
            buttonTool195.SharedPropsInternal.Caption = "Append Entry Point(&P)";
            appearance98.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.SendHostMessage;
            buttonTool202.SharedPropsInternal.AppearancesSmall.Appearance = appearance98;
            buttonTool202.SharedPropsInternal.Caption = "Send Host Message(&S)";
            appearance99.Image = global::Nexplant.MC.TcpModeler.Properties.Resources.SendTcpMessage;
            buttonTool211.SharedPropsInternal.AppearancesSmall.Appearance = appearance99;
            buttonTool211.SharedPropsInternal.Caption = "Send TCP Message(&S)";
            buttonTool189.SharedPropsInternal.Caption = "Replace(&H)";
            buttonTool209.SharedPropsInternal.Caption = "Clone(&O)";
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
            buttonTool36,
            popupMenuTool1,
            buttonTool57,
            buttonTool58,
            buttonTool11,
            buttonTool25,
            buttonTool26,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool30,
            buttonTool12,
            buttonTool79,
            buttonTool80,
            buttonTool81,
            buttonTool82,
            buttonTool83,
            buttonTool84,
            buttonTool85,
            buttonTool86,
            buttonTool87,
            buttonTool88,
            buttonTool89,
            buttonTool90,
            buttonTool91,
            buttonTool92,
            buttonTool93,
            buttonTool94,
            buttonTool95,
            buttonTool96,
            buttonTool121,
            buttonTool122,
            buttonTool123,
            buttonTool124,
            buttonTool125,
            buttonTool126,
            buttonTool127,
            buttonTool128,
            buttonTool129,
            buttonTool130,
            buttonTool131,
            buttonTool132,
            buttonTool133,
            buttonTool134,
            buttonTool135,
            buttonTool136,
            buttonTool137,
            buttonTool138,
            buttonTool139,
            buttonTool140,
            buttonTool141,
            buttonTool142,
            buttonTool143,
            buttonTool144,
            buttonTool163,
            buttonTool164,
            buttonTool165,
            buttonTool166,
            buttonTool167,
            buttonTool168,
            buttonTool169,
            buttonTool170,
            buttonTool171,
            buttonTool172,
            buttonTool173,
            buttonTool174,
            buttonTool175,
            buttonTool176,
            buttonTool177,
            buttonTool178,
            buttonTool179,
            buttonTool180,
            buttonTool184,
            buttonTool185,
            buttonTool186,
            buttonTool191,
            buttonTool196,
            buttonTool205,
            popupMenuTool2,
            popupMenuTool3,
            buttonTool192,
            buttonTool194,
            buttonTool195,
            buttonTool202,
            buttonTool211,
            buttonTool189,
            buttonTool209});
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
            this.spcMain.Panel1.Controls.Add(this.spcScenario);
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
            // spcScenario
            // 
            this.spcScenario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcScenario.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spcScenario.Location = new System.Drawing.Point(0, 0);
            this.spcScenario.Name = "spcScenario";
            // 
            // spcScenario.Panel1
            // 
            this.spcScenario.Panel1.Controls.Add(this.rstSnrToolbar);
            this.spcScenario.Panel1.Controls.Add(this.tvwScenario);
            // 
            // spcScenario.Panel2
            // 
            this.spcScenario.Panel2.Controls.Add(this.spcFlow);
            this.spcScenario.Size = new System.Drawing.Size(722, 503);
            this.spcScenario.SplitterDistance = 250;
            this.spcScenario.TabIndex = 0;
            this.spcScenario.TabStop = false;
            // 
            // rstSnrToolbar
            // 
            this.rstSnrToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstSnrToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstSnrToolbar.Location = new System.Drawing.Point(0, 2);
            this.rstSnrToolbar.Name = "rstSnrToolbar";
            this.rstSnrToolbar.refreshEnabled = false;
            this.rstSnrToolbar.Size = new System.Drawing.Size(250, 21);
            this.rstSnrToolbar.TabIndex = 0;
            this.rstSnrToolbar.TabStop = false;
            this.rstSnrToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstSnrToolbar_SearchRequested);
            // 
            // spcFlow
            // 
            this.spcFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcFlow.Location = new System.Drawing.Point(0, 0);
            this.spcFlow.Name = "spcFlow";
            this.spcFlow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcFlow.Panel1
            // 
            this.spcFlow.Panel1.Controls.Add(this.flowContHost);
            this.spcFlow.Panel1.Controls.Add(this.rstFlowToolbar);
            // 
            // spcFlow.Panel2
            // 
            this.spcFlow.Panel2.Controls.Add(this.tvwFlow);
            this.spcFlow.Size = new System.Drawing.Size(468, 503);
            this.spcFlow.SplitterDistance = 381;
            this.spcFlow.TabIndex = 0;
            this.spcFlow.TabStop = false;
            // 
            // flowContHost
            // 
            this.flowContHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowContHost.BackColorTransparent = true;
            this.flowContHost.Location = new System.Drawing.Point(0, 25);
            this.flowContHost.Name = "flowContHost";
            this.flowContHost.Size = new System.Drawing.Size(468, 356);
            this.flowContHost.TabIndex = 0;
            this.flowContHost.Child = this.flcContainer;
            // 
            // rstFlowToolbar
            // 
            this.rstFlowToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rstFlowToolbar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rstFlowToolbar.Location = new System.Drawing.Point(0, 2);
            this.rstFlowToolbar.Margin = new System.Windows.Forms.Padding(5);
            this.rstFlowToolbar.Name = "rstFlowToolbar";
            this.rstFlowToolbar.refreshEnabled = false;
            this.rstFlowToolbar.Size = new System.Drawing.Size(468, 22);
            this.rstFlowToolbar.TabIndex = 10;
            this.rstFlowToolbar.TabStop = false;
            this.rstFlowToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstFlowToolbar_SearchRequested);
            // 
            // tvwFlow
            // 
            this.tvwFlow.AllowDrop = true;
            appearance5.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance5.BorderColor = System.Drawing.Color.Silver;
            this.tvwFlow.Appearance = appearance5;
            this.tvwFlow.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.tvwFlow.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.tvwFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwFlow.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.tvwFlow.Font = new System.Drawing.Font("Verdana", 9F);
            this.tvwFlow.HideSelection = false;
            this.tvwFlow.Location = new System.Drawing.Point(0, 0);
            this.tvwFlow.multiSelected = true;
            this.tvwFlow.Name = "tvwFlow";
            this.tvwFlow.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            appearance6.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance6.BackColor2 = System.Drawing.Color.LightSteelBlue;
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance6.ForeColor = System.Drawing.Color.Black;
            _override2.ActiveNodeAppearance = appearance6;
            _override2.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            _override2.ItemHeight = 18;
            _override2.Multiline = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance7.ForeColor = System.Drawing.Color.Black;
            _override2.NodeAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance8.BackColor2 = System.Drawing.Color.LightGray;
            appearance8.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance8.ForeColor = System.Drawing.Color.Black;
            _override2.SelectedNodeAppearance = appearance8;
            _override2.SelectionType = Infragistics.Win.UltraWinTree.SelectType.Extended;
            _override2.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            _override2.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            this.tvwFlow.Override = _override2;
            scrollBarLook2.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwFlow.ScrollBarLook = scrollBarLook2;
            this.tvwFlow.Size = new System.Drawing.Size(468, 118);
            this.tvwFlow.TabIndex = 0;
            this.tvwFlow.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.tvwFlow.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.tvwFlow.AfterActivate += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwFlow_AfterActivate);
            this.tvwFlow.AfterExpand += new Infragistics.Win.UltraWinTree.AfterNodeChangedEventHandler(this.tvwFlow_AfterExpand);
            this.tvwFlow.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvwFlow_DragDrop);
            this.tvwFlow.DragOver += new System.Windows.Forms.DragEventHandler(this.tvwFlow_DragOver);
            this.tvwFlow.Enter += new System.EventHandler(this.tvwFlow_Enter);
            this.tvwFlow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwFlow_KeyDown);
            this.tvwFlow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvwFlow_MouseMove);
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
            this.pgdProp.Leave += new System.EventHandler(this.pgdProp_Leave);
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
            // FEquipmentModeler
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.FControlFormBase_Fill_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FEquipmentModeler";
            this.Text = "Equipment Modeler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FEquipmentModeler_FormClosing);
            this.Load += new System.EventHandler(this.FEquipmentModeler_Load);
            this.Shown += new System.EventHandler(this.FEquipmentModeler_Shown);
            this.Controls.SetChildIndex(this.FControlFormBase_Fill_Panel, 0);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwScenario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcScenario.Panel1.ResumeLayout(false);
            this.spcScenario.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcScenario)).EndInit();
            this.spcScenario.ResumeLayout(false);
            this.spcFlow.Panel1.ResumeLayout(false);
            this.spcFlow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcFlow)).EndInit();
            this.spcFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwFlow)).EndInit();
            this.FControlFormBase_Fill_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FTreeView tvwScenario;
        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.Misc.UltraPanel FControlFormBase_Fill_Panel;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private Core.FaUIs.FRefreshAndSearchToolbar rstSnrToolbar;
        private System.Windows.Forms.SplitContainer spcScenario;
        private System.Windows.Forms.SplitContainer spcFlow;
        private System.Windows.Forms.Integration.ElementHost flowContHost;
        private Core.FaUIs.WPF.FFlowContainer flcContainer;
        private Core.FaUIs.FRefreshAndSearchToolbar rstFlowToolbar;
        private Core.FaUIs.FTreeView tvwFlow;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
    }
}
