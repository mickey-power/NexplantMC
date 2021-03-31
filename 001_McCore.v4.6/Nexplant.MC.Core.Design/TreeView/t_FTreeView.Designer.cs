namespace Nexplant.MC.Core.FaUIs
{
    partial class FTreeView
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // --

            this.Font = new System.Drawing.Font("Verdana", 9F);
            // --
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.BorderColor = System.Drawing.Color.Silver;
            // --
            this.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.DisplayStyle = Infragistics.Win.UltraWinTree.UltraTreeDisplayStyle.Standard;
            this.DrawsFocusRect = Infragistics.Win.DefaultableBoolean.False;
            this.HideSelection = false;
            this.NodeConnectorStyle = Infragistics.Win.UltraWinTree.NodeConnectorStyle.Solid;
            // --
            this.Override.NodeAppearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Override.NodeAppearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.Override.ActiveNodeAppearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Override.ActiveNodeAppearance.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.Override.ActiveNodeAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.Override.ActiveNodeAppearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.Override.SelectedNodeAppearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Override.SelectedNodeAppearance.BackColor2 = System.Drawing.Color.LightGray;
            this.Override.SelectedNodeAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.Override.SelectedNodeAppearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.Override.CellClickAction = Infragistics.Win.UltraWinTree.CellClickAction.ActivateCell;
            this.Override.ItemHeight = 18;
            this.Override.Multiline = Infragistics.Win.DefaultableBoolean.False;
            this.Override.TipStyleNode = Infragistics.Win.UltraWinTree.TipStyleNode.Hide;
            this.Override.UseEditor = Infragistics.Win.DefaultableBoolean.False;
            // --
            this.ScrollBarLook.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            // --
            this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;

            // --

            this.Override.SelectionType = m_multiSelected ? Infragistics.Win.UltraWinTree.SelectType.Extended : Infragistics.Win.UltraWinTree.SelectType.None;        
        }

        #endregion
    }
}
