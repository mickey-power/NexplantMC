using Infragistics.Win.UltraWinGrid;
namespace Nexplant.MC.Core.FaUIs
{
    partial class FDetailViewGrid
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
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            // components = new System.ComponentModel.Container();
            this.SuspendLayout();
            //
            // DetailViewGrid
            //
            FGridCommon.designColumnGrid(this);

            // --

            this.DisplayLayout.Appearance.FontData.SizeInPoints = 9F;
            this.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            // --                

            this.DisplayLayout.ViewStyle = ViewStyle.SingleBand;
            this.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

            // --                

            this.DisplayLayout.Override.CellClickAction = CellClickAction.CellSelect;
            this.DisplayLayout.Override.CellMultiLine = Infragistics.Win.DefaultableBoolean.False;
            this.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;

            // --                

            this.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            this.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Default;

            // --

            // ***
            // Multi Select Option
            // ***
            this.DisplayLayout.Override.ActiveAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            this.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
            this.DisplayLayout.Override.SelectTypeRow = SelectType.None;
            this.DisplayLayout.Override.SelectTypeCell = SelectType.None;

            // --

            this.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            this.DisplayLayout.Override.RowSizing = RowSizing.Fixed;

            // --

            this.DisplayLayout.Override.TipStyleCell = TipStyle.Hide;
            this.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.False;

            // --

            this.DisplayLayout.Bands[0].ColHeadersVisible = false;
        }

        #endregion
    }
}
