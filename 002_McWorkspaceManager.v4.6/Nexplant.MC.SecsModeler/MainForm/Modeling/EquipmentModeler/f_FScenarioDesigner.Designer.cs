namespace Nexplant.MC.SecsModeler
{
    partial class FScenarioDesigner
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
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool76 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool77 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool150 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool149 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool151 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool152 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool198 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool199 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool195 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool156 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool203 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool204 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool166 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool167 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool168 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool136 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool138 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool140 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool51 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool80 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool81 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool27 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool28 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool29 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool33 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool34 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool35 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool228 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool227 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool226 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool127 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool128 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool129 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool40 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool42 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool229 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Entry Point");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool58 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool59 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool60 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool67 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool68 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool69 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool82 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool83 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool84 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool88 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool89 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool90 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool94 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool96 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool97 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool100 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool101 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool102 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool205 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool206 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool207 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool175 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool179 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool180 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool176 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool178 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool186 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool44 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool112 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool117 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Trigger");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Trigger");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transmitter");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transmitter");
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transmitter");
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Trigger");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool24 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool25 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool26 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool30 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool31 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool32 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool36 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool37 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool38 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool154 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool155 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool237 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool158 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool157 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool159 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool160 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool202 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Remove");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool201 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool200 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool194 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert Before");
            Infragistics.Win.UltraWinToolbars.PopupGalleryTool popupGalleryTool1 = new Infragistics.Win.UltraWinToolbars.PopupGalleryTool("Insert After");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool52 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool53 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool54 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool55 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool216 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool174 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool143 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool165 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool56 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool57 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool135 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool66 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool75 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool108 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool111 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool115 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool118 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool219 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool185 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool192 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool126 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool225 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool61 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Condition");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool62 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Condition");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool63 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Condition");
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool70 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Expression");
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool71 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Expression");
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool72 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Expression");
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool78 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Expand");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool79 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Collapse");
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool85 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transfer");
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool86 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transfer");
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool87 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append SECS Transfer");
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool91 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool92 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool93 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Condition");
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool95 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool98 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool99 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Expression");
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool103 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool104 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool105 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Host Transfer");
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool119 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool121 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool122 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool123 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Function");
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool130 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool131 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool132 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Comment");
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool137 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool139 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool141 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Mapper");
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool145 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Copy");
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool146 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Cut");
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool147 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Sibling");
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool148 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Paste Child");
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool153 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool161 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool162 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Storage");
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool169 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool170 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool171 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement");
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool177 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool181 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool182 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Condition");
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool187 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool188 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool189 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Judgement Expression");
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool193 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Relation");
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool196 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Up");
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool197 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Move Down");
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool208 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool209 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool210 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Set Alterer");
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool211 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool212 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool213 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Equipment State Alterer");
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool220 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool221 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool222 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Pauser");
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.PopupGalleryTool popupGalleryTool2 = new Infragistics.Win.UltraWinToolbars.PopupGalleryTool("Insert After");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool134 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool142 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool144 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool163 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool164 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool172 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool173 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool183 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool184 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool190 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool191 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool214 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool215 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool217 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool218 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool223 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool224 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool231 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool232 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool233 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool234 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool235 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Function");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Insert Before");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool45 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool46 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool47 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Trigger");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool48 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transmitter");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool49 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Set Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool50 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool64 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Mapper");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool65 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Storage");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool73 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Callback");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool41 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Branch");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool74 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Pauser");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool106 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Comment");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool107 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool109 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool110 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before SECS Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool113 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool114 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool116 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Host Transfer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool120 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Equipment State Alterer");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool124 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Condition");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool125 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Judgement Expression");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool133 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Function");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool39 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert Before Entry Point");
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool43 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Insert After Entry Point");
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool230 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Append Entry Point");
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool236 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Replace");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FScenarioDesigner));
            this.FControlFormBase_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.spcFlow = new System.Windows.Forms.SplitContainer();
            this.flowContHost = new System.Windows.Forms.Integration.ElementHost();
            this.flcContainer = new Nexplant.MC.Core.FaUIs.WPF.FFlowContainer();
            this.rstFlowToolbar = new Nexplant.MC.Core.FaUIs.FRefreshAndSearchToolbar();
            this.tvwFlow = new Nexplant.MC.Core.FaUIs.FTreeView();
            this.pgdProp = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.mnuMenu = new Nexplant.MC.Core.FaUIs.FToolbarsManager(this.components);
            this.pnlMenu = new System.Windows.Forms.Panel();
            this._pnlMenu_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._pnlMenu_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.pnlClient.SuspendLayout();
            this.FControlFormBase_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcFlow)).BeginInit();
            this.spcFlow.Panel1.SuspendLayout();
            this.spcFlow.Panel2.SuspendLayout();
            this.spcFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tvwFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.spcMain);
            this.pnlClient.Controls.Add(this.pnlMenu);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // FControlFormBase_Fill_Panel
            // 
            this.FControlFormBase_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FControlFormBase_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FControlFormBase_Fill_Panel.Location = new System.Drawing.Point(0, 27);
            this.FControlFormBase_Fill_Panel.Name = "FControlFormBase_Fill_Panel";
            this.FControlFormBase_Fill_Panel.Size = new System.Drawing.Size(984, 535);
            this.FControlFormBase_Fill_Panel.TabIndex = 0;
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
            this.spcMain.Panel1.Controls.Add(this.spcFlow);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.pgdProp);
            this.spcMain.Panel2.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.spcMain.Panel2MinSize = 250;
            this.spcMain.Size = new System.Drawing.Size(976, 503);
            this.spcMain.SplitterDistance = 722;
            this.spcMain.TabIndex = 0;
            this.spcMain.TabStop = false;
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
            this.spcFlow.Size = new System.Drawing.Size(722, 503);
            this.spcFlow.SplitterDistance = 386;
            this.spcFlow.TabIndex = 0;
            this.spcFlow.TabStop = false;
            // 
            // flowContHost
            // 
            this.flowContHost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowContHost.Location = new System.Drawing.Point(0, 25);
            this.flowContHost.Name = "flowContHost";
            this.flowContHost.Size = new System.Drawing.Size(722, 360);
            this.flowContHost.TabIndex = 1;
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
            this.rstFlowToolbar.Size = new System.Drawing.Size(722, 22);
            this.rstFlowToolbar.TabIndex = 0;
            this.rstFlowToolbar.TabStop = false;
            this.rstFlowToolbar.SearchRequested += new Nexplant.MC.Core.FaUIs.FSearchRequestedEventHandler(this.rstFlowToolbar_SearchRequested);
            // 
            // tvwFlow
            // 
            this.tvwFlow.AllowDrop = true;
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.tvwFlow.Appearance = appearance1;
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
            this.tvwFlow.Override = _override1;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tvwFlow.ScrollBarLook = scrollBarLook1;
            this.tvwFlow.Size = new System.Drawing.Size(722, 113);
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
            ultraToolbar1.IsMainMenuBar = true;
            buttonTool150.InstanceProps.IsFirstInGroup = true;
            buttonTool1.InstanceProps.IsFirstInGroup = true;
            buttonTool198.InstanceProps.IsFirstInGroup = true;
            buttonTool195.InstanceProps.IsFirstInGroup = true;
            buttonTool3.InstanceProps.IsFirstInGroup = true;
            buttonTool13.InstanceProps.IsFirstInGroup = true;
            buttonTool7.InstanceProps.IsFirstInGroup = true;
            buttonTool9.InstanceProps.IsFirstInGroup = true;
            buttonTool15.InstanceProps.IsFirstInGroup = true;
            buttonTool17.InstanceProps.IsFirstInGroup = true;
            buttonTool21.InstanceProps.IsFirstInGroup = true;
            buttonTool23.InstanceProps.IsFirstInGroup = true;
            buttonTool156.InstanceProps.IsFirstInGroup = true;
            buttonTool204.InstanceProps.IsFirstInGroup = true;
            buttonTool166.InstanceProps.IsFirstInGroup = true;
            buttonTool168.InstanceProps.IsFirstInGroup = true;
            buttonTool136.InstanceProps.IsFirstInGroup = true;
            buttonTool140.InstanceProps.IsFirstInGroup = true;
            buttonTool51.InstanceProps.IsFirstInGroup = true;
            buttonTool81.InstanceProps.IsFirstInGroup = true;
            buttonTool27.InstanceProps.IsFirstInGroup = true;
            buttonTool29.InstanceProps.IsFirstInGroup = true;
            buttonTool33.InstanceProps.IsFirstInGroup = true;
            buttonTool35.InstanceProps.IsFirstInGroup = true;
            buttonTool228.InstanceProps.IsFirstInGroup = true;
            buttonTool226.InstanceProps.IsFirstInGroup = true;
            buttonTool127.InstanceProps.IsFirstInGroup = true;
            buttonTool129.InstanceProps.IsFirstInGroup = true;
            buttonTool40.InstanceProps.IsFirstInGroup = true;
            buttonTool229.InstanceProps.IsFirstInGroup = true;
            buttonTool58.InstanceProps.IsFirstInGroup = true;
            buttonTool60.InstanceProps.IsFirstInGroup = true;
            buttonTool67.InstanceProps.IsFirstInGroup = true;
            buttonTool69.InstanceProps.IsFirstInGroup = true;
            buttonTool82.InstanceProps.IsFirstInGroup = true;
            buttonTool84.InstanceProps.IsFirstInGroup = true;
            buttonTool88.InstanceProps.IsFirstInGroup = true;
            buttonTool90.InstanceProps.IsFirstInGroup = true;
            buttonTool94.InstanceProps.IsFirstInGroup = true;
            buttonTool97.InstanceProps.IsFirstInGroup = true;
            buttonTool100.InstanceProps.IsFirstInGroup = true;
            buttonTool102.InstanceProps.IsFirstInGroup = true;
            buttonTool205.InstanceProps.IsFirstInGroup = true;
            buttonTool207.InstanceProps.IsFirstInGroup = true;
            buttonTool175.InstanceProps.IsFirstInGroup = true;
            buttonTool180.InstanceProps.IsFirstInGroup = true;
            buttonTool176.InstanceProps.IsFirstInGroup = true;
            buttonTool186.InstanceProps.IsFirstInGroup = true;
            buttonTool44.InstanceProps.IsFirstInGroup = true;
            buttonTool117.InstanceProps.IsFirstInGroup = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool76,
            buttonTool77,
            buttonTool150,
            buttonTool149,
            buttonTool151,
            buttonTool152,
            buttonTool1,
            buttonTool198,
            buttonTool199,
            buttonTool195,
            buttonTool3,
            buttonTool4,
            buttonTool13,
            buttonTool7,
            buttonTool8,
            buttonTool9,
            buttonTool15,
            buttonTool16,
            buttonTool17,
            buttonTool21,
            buttonTool22,
            buttonTool23,
            buttonTool156,
            buttonTool203,
            buttonTool204,
            buttonTool166,
            buttonTool167,
            buttonTool168,
            buttonTool136,
            buttonTool138,
            buttonTool140,
            buttonTool51,
            buttonTool80,
            buttonTool81,
            buttonTool27,
            buttonTool28,
            buttonTool29,
            buttonTool33,
            buttonTool34,
            buttonTool35,
            buttonTool228,
            buttonTool227,
            buttonTool226,
            buttonTool127,
            buttonTool128,
            buttonTool129,
            buttonTool40,
            buttonTool42,
            buttonTool229,
            buttonTool58,
            buttonTool59,
            buttonTool60,
            buttonTool67,
            buttonTool68,
            buttonTool69,
            buttonTool82,
            buttonTool83,
            buttonTool84,
            buttonTool88,
            buttonTool89,
            buttonTool90,
            buttonTool94,
            buttonTool96,
            buttonTool97,
            buttonTool100,
            buttonTool101,
            buttonTool102,
            buttonTool205,
            buttonTool206,
            buttonTool207,
            buttonTool175,
            buttonTool179,
            buttonTool180,
            buttonTool176,
            buttonTool178,
            buttonTool186,
            buttonTool44,
            buttonTool112,
            buttonTool117});
            ultraToolbar1.Text = "Toolbar";
            this.mnuMenu.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.mnuMenu.ToolbarSettings.FillEntireRow = Infragistics.Win.DefaultableBoolean.True;
            appearance5.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolRemove;
            buttonTool2.SharedPropsInternal.AppearancesSmall.Appearance = appearance5;
            buttonTool2.SharedPropsInternal.Caption = "Remove(&R)";
            buttonTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyInMenus;
            appearance6.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeSecsTrigger;
            buttonTool5.SharedPropsInternal.AppearancesSmall.Appearance = appearance6;
            buttonTool5.SharedPropsInternal.Caption = "Insert Before SECS Trigger(&B)";
            appearance7.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterSecsTrigger;
            buttonTool6.SharedPropsInternal.AppearancesSmall.Appearance = appearance7;
            buttonTool6.SharedPropsInternal.Caption = "Insert After SECS Trigger(&A)";
            appearance8.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeSecsTransmitter;
            buttonTool10.SharedPropsInternal.AppearancesSmall.Appearance = appearance8;
            buttonTool10.SharedPropsInternal.Caption = "Insert Before SECS Transmitter(&B)";
            appearance9.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterSecsTransmitter;
            buttonTool11.SharedPropsInternal.AppearancesSmall.Appearance = appearance9;
            buttonTool11.SharedPropsInternal.Caption = "Insert After SECS Transmitter(&A)";
            appearance10.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendSecsTransmitter;
            buttonTool12.SharedPropsInternal.AppearancesSmall.Appearance = appearance10;
            buttonTool12.SharedPropsInternal.Caption = "Append SECS Transmitter(&P)";
            appearance11.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendSecsTrigger;
            buttonTool14.SharedPropsInternal.AppearancesSmall.Appearance = appearance11;
            buttonTool14.SharedPropsInternal.Caption = "Append SECS Trigger(&P)";
            appearance12.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeHostTrigger;
            buttonTool18.SharedPropsInternal.AppearancesSmall.Appearance = appearance12;
            buttonTool18.SharedPropsInternal.Caption = "Insert Before Host Trigger(&B)";
            appearance13.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendHostTrigger;
            buttonTool20.SharedPropsInternal.AppearancesSmall.Appearance = appearance13;
            buttonTool20.SharedPropsInternal.Caption = "Append Host Trigger(&P)";
            appearance14.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeHostTransmitter;
            buttonTool24.SharedPropsInternal.AppearancesSmall.Appearance = appearance14;
            buttonTool24.SharedPropsInternal.Caption = "Insert Before Host Transmitter(&B)";
            appearance15.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterHostTransmitter;
            buttonTool25.SharedPropsInternal.AppearancesSmall.Appearance = appearance15;
            buttonTool25.SharedPropsInternal.Caption = "Insert After Host Transmitter(&A)";
            appearance16.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendHostTransmitter;
            buttonTool26.SharedPropsInternal.AppearancesSmall.Appearance = appearance16;
            buttonTool26.SharedPropsInternal.Caption = "Append Host Transmitter(&P)";
            appearance17.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeCallback;
            buttonTool30.SharedPropsInternal.AppearancesSmall.Appearance = appearance17;
            buttonTool30.SharedPropsInternal.Caption = "Insert Before Callback(&B)";
            appearance18.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterCallback;
            buttonTool31.SharedPropsInternal.AppearancesSmall.Appearance = appearance18;
            buttonTool31.SharedPropsInternal.Caption = "Insert After Callback(&A)";
            appearance19.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendCallback;
            buttonTool32.SharedPropsInternal.AppearancesSmall.Appearance = appearance19;
            buttonTool32.SharedPropsInternal.Caption = "Append Callback(&P)";
            appearance20.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeBranch;
            buttonTool36.SharedPropsInternal.AppearancesSmall.Appearance = appearance20;
            buttonTool36.SharedPropsInternal.Caption = "Insert Before Branch(&B)";
            appearance21.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterBranch;
            buttonTool37.SharedPropsInternal.AppearancesSmall.Appearance = appearance21;
            buttonTool37.SharedPropsInternal.Caption = "Insert After Branch(&A)";
            appearance22.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendBranch;
            buttonTool38.SharedPropsInternal.AppearancesSmall.Appearance = appearance22;
            buttonTool38.SharedPropsInternal.Caption = "Append Branch(&P)";
            popupMenuTool1.SharedPropsInternal.Caption = "PopupMenu";
            buttonTool237.InstanceProps.IsFirstInGroup = true;
            buttonTool158.InstanceProps.IsFirstInGroup = true;
            buttonTool202.InstanceProps.IsFirstInGroup = true;
            buttonTool201.InstanceProps.IsFirstInGroup = true;
            buttonTool194.InstanceProps.IsFirstInGroup = true;
            popupMenuTool2.InstanceProps.IsFirstInGroup = true;
            buttonTool52.InstanceProps.IsFirstInGroup = true;
            buttonTool53.InstanceProps.IsFirstInGroup = true;
            buttonTool54.InstanceProps.IsFirstInGroup = true;
            buttonTool55.InstanceProps.IsFirstInGroup = true;
            buttonTool216.InstanceProps.IsFirstInGroup = true;
            buttonTool174.InstanceProps.IsFirstInGroup = true;
            buttonTool143.InstanceProps.IsFirstInGroup = true;
            buttonTool165.InstanceProps.IsFirstInGroup = true;
            buttonTool56.InstanceProps.IsFirstInGroup = true;
            buttonTool57.InstanceProps.IsFirstInGroup = true;
            buttonTool135.InstanceProps.IsFirstInGroup = true;
            buttonTool66.InstanceProps.IsFirstInGroup = true;
            buttonTool75.InstanceProps.IsFirstInGroup = true;
            buttonTool108.InstanceProps.IsFirstInGroup = true;
            buttonTool111.InstanceProps.IsFirstInGroup = true;
            buttonTool115.InstanceProps.IsFirstInGroup = true;
            buttonTool118.InstanceProps.IsFirstInGroup = true;
            buttonTool219.InstanceProps.IsFirstInGroup = true;
            buttonTool185.InstanceProps.IsFirstInGroup = true;
            buttonTool192.InstanceProps.IsFirstInGroup = true;
            buttonTool126.InstanceProps.IsFirstInGroup = true;
            buttonTool225.InstanceProps.IsFirstInGroup = true;
            popupMenuTool1.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool154,
            buttonTool155,
            buttonTool237,
            buttonTool158,
            buttonTool157,
            buttonTool159,
            buttonTool160,
            buttonTool202,
            buttonTool201,
            buttonTool200,
            buttonTool194,
            popupMenuTool2,
            popupGalleryTool1,
            buttonTool52,
            buttonTool53,
            buttonTool54,
            buttonTool55,
            buttonTool216,
            buttonTool174,
            buttonTool143,
            buttonTool165,
            buttonTool56,
            buttonTool57,
            buttonTool135,
            buttonTool66,
            buttonTool75,
            buttonTool108,
            buttonTool111,
            buttonTool115,
            buttonTool118,
            buttonTool219,
            buttonTool185,
            buttonTool192,
            buttonTool126,
            buttonTool225});
            appearance23.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeSecsCondition;
            buttonTool61.SharedPropsInternal.AppearancesSmall.Appearance = appearance23;
            buttonTool61.SharedPropsInternal.Caption = "Insert Before SECS Condition(&B)";
            appearance24.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterSecsCondition;
            buttonTool62.SharedPropsInternal.AppearancesSmall.Appearance = appearance24;
            buttonTool62.SharedPropsInternal.Caption = "Insert After SECS Condition(&A)";
            appearance25.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendSecsCondition;
            buttonTool63.SharedPropsInternal.AppearancesSmall.Appearance = appearance25;
            buttonTool63.SharedPropsInternal.Caption = "Append SECS Condition(&P)";
            appearance26.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeSecsExpression;
            buttonTool70.SharedPropsInternal.AppearancesSmall.Appearance = appearance26;
            buttonTool70.SharedPropsInternal.Caption = "Insert Before SECS Expression(&B)";
            appearance27.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterSecsExpression;
            buttonTool71.SharedPropsInternal.AppearancesSmall.Appearance = appearance27;
            buttonTool71.SharedPropsInternal.Caption = "Insert After SECS Expression(&A)";
            appearance28.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendSecsExpression;
            buttonTool72.SharedPropsInternal.AppearancesSmall.Appearance = appearance28;
            buttonTool72.SharedPropsInternal.Caption = "Append SECS Expression(&P)";
            appearance29.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolExpand;
            buttonTool78.SharedPropsInternal.AppearancesSmall.Appearance = appearance29;
            buttonTool78.SharedPropsInternal.Caption = "Expand(&L)";
            appearance30.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolCollapse;
            buttonTool79.SharedPropsInternal.AppearancesSmall.Appearance = appearance30;
            buttonTool79.SharedPropsInternal.Caption = "Collapse(&L)";
            appearance31.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeSecsTransfer;
            buttonTool85.SharedPropsInternal.AppearancesSmall.Appearance = appearance31;
            buttonTool85.SharedPropsInternal.Caption = "Insert Before SECS Transfer(&B)";
            appearance32.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterSecsTransfer;
            buttonTool86.SharedPropsInternal.AppearancesSmall.Appearance = appearance32;
            buttonTool86.SharedPropsInternal.Caption = "Insert After SECS Transfer(&A)";
            appearance33.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendSecsTransfer;
            buttonTool87.SharedPropsInternal.AppearancesSmall.Appearance = appearance33;
            buttonTool87.SharedPropsInternal.Caption = "Append SECS Transfer(&P)";
            appearance34.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeHostCondition;
            buttonTool91.SharedPropsInternal.AppearancesSmall.Appearance = appearance34;
            buttonTool91.SharedPropsInternal.Caption = "Insert Before Host Condition(&B)";
            appearance35.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterHostCondition;
            buttonTool92.SharedPropsInternal.AppearancesSmall.Appearance = appearance35;
            buttonTool92.SharedPropsInternal.Caption = "Insert After Host Condition(&A)";
            appearance36.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendHostCondition;
            buttonTool93.SharedPropsInternal.AppearancesSmall.Appearance = appearance36;
            buttonTool93.SharedPropsInternal.Caption = "Append Host Condition(&P)";
            appearance37.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeHostExpression;
            buttonTool95.SharedPropsInternal.AppearancesSmall.Appearance = appearance37;
            buttonTool95.SharedPropsInternal.Caption = "Insert Before Host Expression(&B)";
            appearance38.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterHostExpression;
            buttonTool98.SharedPropsInternal.AppearancesSmall.Appearance = appearance38;
            buttonTool98.SharedPropsInternal.Caption = "Insert After Host Expression(&A)";
            appearance39.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendHostExpression;
            buttonTool99.SharedPropsInternal.AppearancesSmall.Appearance = appearance39;
            buttonTool99.SharedPropsInternal.Caption = "Append Host Expression(&P)";
            appearance40.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeHostTransfer;
            buttonTool103.SharedPropsInternal.AppearancesSmall.Appearance = appearance40;
            buttonTool103.SharedPropsInternal.Caption = "Insert Before Host Transfer(&B)";
            appearance41.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterHostTransfer;
            buttonTool104.SharedPropsInternal.AppearancesSmall.Appearance = appearance41;
            buttonTool104.SharedPropsInternal.Caption = "Insert After Host Transfer(&A)";
            appearance42.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendHostTransfer;
            buttonTool105.SharedPropsInternal.AppearancesSmall.Appearance = appearance42;
            buttonTool105.SharedPropsInternal.Caption = "Append Host Transfer(&P)";
            appearance43.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterHostTrigger;
            buttonTool119.SharedPropsInternal.AppearancesSmall.Appearance = appearance43;
            buttonTool119.SharedPropsInternal.Caption = "Insert After Host Trigger(&A)";
            appearance44.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeFunction;
            buttonTool121.SharedPropsInternal.AppearancesSmall.Appearance = appearance44;
            buttonTool121.SharedPropsInternal.Caption = "Insert Before Function(&B)";
            appearance45.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterFunction;
            buttonTool122.SharedPropsInternal.AppearancesSmall.Appearance = appearance45;
            buttonTool122.SharedPropsInternal.Caption = "Insert After Function(&A)";
            appearance46.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendFunction;
            buttonTool123.SharedPropsInternal.AppearancesSmall.Appearance = appearance46;
            buttonTool123.SharedPropsInternal.Caption = "Append Function(&P)";
            appearance47.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeComment;
            buttonTool130.SharedPropsInternal.AppearancesSmall.Appearance = appearance47;
            buttonTool130.SharedPropsInternal.Caption = "Insert Before Comment(&B)";
            appearance48.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterComment;
            buttonTool131.SharedPropsInternal.AppearancesSmall.Appearance = appearance48;
            buttonTool131.SharedPropsInternal.Caption = "Insert After Comment(&A)";
            appearance49.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendComment;
            buttonTool132.SharedPropsInternal.AppearancesSmall.Appearance = appearance49;
            buttonTool132.SharedPropsInternal.Caption = "Append Comment(&P)";
            appearance50.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeMapper;
            buttonTool137.SharedPropsInternal.AppearancesSmall.Appearance = appearance50;
            buttonTool137.SharedPropsInternal.Caption = "Insert Before Mapper(&B)";
            appearance51.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterMapper;
            buttonTool139.SharedPropsInternal.AppearancesSmall.Appearance = appearance51;
            buttonTool139.SharedPropsInternal.Caption = "Insert After Mapper(&A)";
            appearance52.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendMapper;
            buttonTool141.SharedPropsInternal.AppearancesSmall.Appearance = appearance52;
            buttonTool141.SharedPropsInternal.Caption = "Append Mapper(&P)";
            appearance53.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolCopy;
            buttonTool145.SharedPropsInternal.AppearancesSmall.Appearance = appearance53;
            buttonTool145.SharedPropsInternal.Caption = "Copy(&C)";
            appearance54.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolCut;
            buttonTool146.SharedPropsInternal.AppearancesSmall.Appearance = appearance54;
            buttonTool146.SharedPropsInternal.Caption = "Cut(&T)";
            appearance55.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolPasteSibling;
            buttonTool147.SharedPropsInternal.AppearancesSmall.Appearance = appearance55;
            buttonTool147.SharedPropsInternal.Caption = "Paste Sibling(&S)";
            appearance56.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolPasteChild;
            buttonTool148.SharedPropsInternal.AppearancesSmall.Appearance = appearance56;
            buttonTool148.SharedPropsInternal.Caption = "Paste Child(&C)";
            appearance57.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeStorage;
            buttonTool153.SharedPropsInternal.AppearancesSmall.Appearance = appearance57;
            buttonTool153.SharedPropsInternal.Caption = "Insert Before Storage(&B)";
            appearance58.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterStorage;
            buttonTool161.SharedPropsInternal.AppearancesSmall.Appearance = appearance58;
            buttonTool161.SharedPropsInternal.Caption = "Insert After Storage(&A)";
            appearance59.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendStorage;
            buttonTool162.SharedPropsInternal.AppearancesSmall.Appearance = appearance59;
            buttonTool162.SharedPropsInternal.Caption = "Append Storage(&P)";
            appearance60.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeJudgement;
            buttonTool169.SharedPropsInternal.AppearancesSmall.Appearance = appearance60;
            buttonTool169.SharedPropsInternal.Caption = "Insert Before Judgement(&B)";
            appearance61.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterJudgement;
            buttonTool170.SharedPropsInternal.AppearancesSmall.Appearance = appearance61;
            buttonTool170.SharedPropsInternal.Caption = "Insert After Judgement(&A)";
            appearance62.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendJudgement;
            buttonTool171.SharedPropsInternal.AppearancesSmall.Appearance = appearance62;
            buttonTool171.SharedPropsInternal.Caption = "Append Judgement(&P)";
            appearance63.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeJudgementCondition;
            buttonTool177.SharedPropsInternal.AppearancesSmall.Appearance = appearance63;
            buttonTool177.SharedPropsInternal.Caption = "Insert Before Judgement Condition(&B)";
            appearance64.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterJudgementCondition;
            buttonTool181.SharedPropsInternal.AppearancesSmall.Appearance = appearance64;
            buttonTool181.SharedPropsInternal.Caption = "Insert After Judgement Condition(&A)";
            appearance65.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendJudgementCondition;
            buttonTool182.SharedPropsInternal.AppearancesSmall.Appearance = appearance65;
            buttonTool182.SharedPropsInternal.Caption = "Append Judgement Condition(&P)";
            appearance66.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeJudgementExpression;
            buttonTool187.SharedPropsInternal.AppearancesSmall.Appearance = appearance66;
            buttonTool187.SharedPropsInternal.Caption = "Insert Before Judgement Expression(&B)";
            appearance67.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterJudgementExpression;
            buttonTool188.SharedPropsInternal.AppearancesSmall.Appearance = appearance67;
            buttonTool188.SharedPropsInternal.Caption = "Insert After Judgement Expression(&A)";
            appearance68.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendJudgementExpression;
            buttonTool189.SharedPropsInternal.AppearancesSmall.Appearance = appearance68;
            buttonTool189.SharedPropsInternal.Caption = "Append Judgement Expression(&P)";
            appearance69.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ViewRelation;
            buttonTool193.SharedPropsInternal.AppearancesSmall.Appearance = appearance69;
            buttonTool193.SharedPropsInternal.Caption = "Relation(&R)";
            appearance70.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolMoveUp;
            buttonTool196.SharedPropsInternal.AppearancesSmall.Appearance = appearance70;
            buttonTool196.SharedPropsInternal.Caption = "Move UP(&U)";
            appearance71.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.ToolMoveDown;
            buttonTool197.SharedPropsInternal.AppearancesSmall.Appearance = appearance71;
            buttonTool197.SharedPropsInternal.Caption = "Move Down(&D)";
            appearance72.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeEquipmentStateSetAlterer;
            buttonTool208.SharedPropsInternal.AppearancesSmall.Appearance = appearance72;
            buttonTool208.SharedPropsInternal.Caption = "Insert Before Equipment State Set Alterer(&B)";
            appearance73.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterEquipmentStateSetAlterer;
            buttonTool209.SharedPropsInternal.AppearancesSmall.Appearance = appearance73;
            buttonTool209.SharedPropsInternal.Caption = "Insert After Equipment State Set Alterer(&A)";
            appearance74.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendEquipmentStateSetAlterer;
            buttonTool210.SharedPropsInternal.AppearancesSmall.Appearance = appearance74;
            buttonTool210.SharedPropsInternal.Caption = "Append Equipment State Set Alterer(&P)";
            appearance75.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeEquipmentStateAlterer;
            buttonTool211.SharedPropsInternal.AppearancesSmall.Appearance = appearance75;
            buttonTool211.SharedPropsInternal.Caption = "Insert Before Equipment State Alterer(&B)";
            appearance76.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterEquipmentStateAlterer;
            buttonTool212.SharedPropsInternal.AppearancesSmall.Appearance = appearance76;
            buttonTool212.SharedPropsInternal.Caption = "Insert After Equipment State Alterer(&A)";
            appearance77.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendEquipmentStateAlterer;
            buttonTool213.SharedPropsInternal.AppearancesSmall.Appearance = appearance77;
            buttonTool213.SharedPropsInternal.Caption = "Append Equipment State Alterer(&P)";
            appearance78.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforePauser;
            buttonTool220.SharedPropsInternal.AppearancesSmall.Appearance = appearance78;
            buttonTool220.SharedPropsInternal.Caption = "Insert Before Pauser(&B)";
            appearance79.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterPauser;
            buttonTool221.SharedPropsInternal.AppearancesSmall.Appearance = appearance79;
            buttonTool221.SharedPropsInternal.Caption = "Insert After Pauser(&A)";
            appearance80.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendPauser;
            buttonTool222.SharedPropsInternal.AppearancesSmall.Appearance = appearance80;
            buttonTool222.SharedPropsInternal.Caption = "Append Pauser(&P)";
            popupGalleryTool2.SharedPropsInternal.Caption = "Insert After";
            popupGalleryTool2.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool134,
            buttonTool142,
            buttonTool144,
            buttonTool163,
            buttonTool164,
            buttonTool172,
            buttonTool173,
            buttonTool183,
            buttonTool184,
            buttonTool190,
            buttonTool191,
            buttonTool214,
            buttonTool215,
            buttonTool217,
            buttonTool218,
            buttonTool223,
            buttonTool224,
            buttonTool231,
            buttonTool232,
            buttonTool233,
            buttonTool234,
            buttonTool235});
            popupMenuTool3.SharedPropsInternal.Caption = "Insert Before";
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool45,
            buttonTool46,
            buttonTool47,
            buttonTool48,
            buttonTool49,
            buttonTool50,
            buttonTool64,
            buttonTool65,
            buttonTool73,
            buttonTool41,
            buttonTool74,
            buttonTool106,
            buttonTool107,
            buttonTool109,
            buttonTool110,
            buttonTool113,
            buttonTool114,
            buttonTool116,
            buttonTool120,
            buttonTool124,
            buttonTool125,
            buttonTool133});
            appearance81.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertBeforeEntryPoint;
            buttonTool39.SharedPropsInternal.AppearancesSmall.Appearance = appearance81;
            buttonTool39.SharedPropsInternal.Caption = "Insert Before Entry Point(&B)";
            appearance82.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.InsertAfterEntryPoint;
            buttonTool43.SharedPropsInternal.AppearancesSmall.Appearance = appearance82;
            buttonTool43.SharedPropsInternal.Caption = "Insert After Entry Point(&A)";
            appearance83.Image = global::Nexplant.MC.SecsModeler.Properties.Resources.AppendEntryPoint;
            buttonTool230.SharedPropsInternal.AppearancesSmall.Appearance = appearance83;
            buttonTool230.SharedPropsInternal.Caption = "Append Entry Point(&P)";
            buttonTool236.SharedPropsInternal.Caption = "Replace(&H)";
            this.mnuMenu.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool2,
            buttonTool5,
            buttonTool6,
            buttonTool10,
            buttonTool11,
            buttonTool12,
            buttonTool14,
            buttonTool18,
            buttonTool20,
            buttonTool24,
            buttonTool25,
            buttonTool26,
            buttonTool30,
            buttonTool31,
            buttonTool32,
            buttonTool36,
            buttonTool37,
            buttonTool38,
            popupMenuTool1,
            buttonTool61,
            buttonTool62,
            buttonTool63,
            buttonTool70,
            buttonTool71,
            buttonTool72,
            buttonTool78,
            buttonTool79,
            buttonTool85,
            buttonTool86,
            buttonTool87,
            buttonTool91,
            buttonTool92,
            buttonTool93,
            buttonTool95,
            buttonTool98,
            buttonTool99,
            buttonTool103,
            buttonTool104,
            buttonTool105,
            buttonTool119,
            buttonTool121,
            buttonTool122,
            buttonTool123,
            buttonTool130,
            buttonTool131,
            buttonTool132,
            buttonTool137,
            buttonTool139,
            buttonTool141,
            buttonTool145,
            buttonTool146,
            buttonTool147,
            buttonTool148,
            buttonTool153,
            buttonTool161,
            buttonTool162,
            buttonTool169,
            buttonTool170,
            buttonTool171,
            buttonTool177,
            buttonTool181,
            buttonTool182,
            buttonTool187,
            buttonTool188,
            buttonTool189,
            buttonTool193,
            buttonTool196,
            buttonTool197,
            buttonTool208,
            buttonTool209,
            buttonTool210,
            buttonTool211,
            buttonTool212,
            buttonTool213,
            buttonTool220,
            buttonTool221,
            buttonTool222,
            popupGalleryTool2,
            popupMenuTool3,
            buttonTool39,
            buttonTool43,
            buttonTool230,
            buttonTool236});
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
            this._pnlMenu_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 67);
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
            this._pnlMenu_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(976, 67);
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
            this._pnlMenu_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(976, 67);
            this._pnlMenu_Toolbars_Dock_Area_Top.ToolbarsManager = this.mnuMenu;
            // 
            // FScenarioDesigner
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.FControlFormBase_Fill_Panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FScenarioDesigner";
            this.Text = "Scenario Modeler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FScenarioDesigner_FormClosing);
            this.Load += new System.EventHandler(this.FScenarioDesigner_Load);
            this.Shown += new System.EventHandler(this.FScenarioDesigner_Shown);
            this.Controls.SetChildIndex(this.FControlFormBase_Fill_Panel, 0);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.pnlClient.ResumeLayout(false);
            this.FControlFormBase_Fill_Panel.ResumeLayout(false);
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
            this.spcMain.ResumeLayout(false);
            this.spcFlow.Panel1.ResumeLayout(false);
            this.spcFlow.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcFlow)).EndInit();
            this.spcFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tvwFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FToolbarsManager mnuMenu;
        private Infragistics.Win.Misc.UltraPanel FControlFormBase_Fill_Panel;
        private System.Windows.Forms.SplitContainer spcMain;
        private Core.FaUIs.FDynPropGrid pgdProp;
        private System.Windows.Forms.SplitContainer spcFlow;
        private Core.FaUIs.FRefreshAndSearchToolbar rstFlowToolbar;
        private Core.FaUIs.FTreeView tvwFlow;
        private System.Windows.Forms.Integration.ElementHost flowContHost;
        private Core.FaUIs.WPF.FFlowContainer flcContainer;
        private System.Windows.Forms.Panel pnlMenu;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _pnlMenu_Toolbars_Dock_Area_Top;
    }
}
