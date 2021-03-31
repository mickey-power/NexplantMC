namespace Nexplant.MC.Core.FaUIs
{
    partial class FExplorerBar
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
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;//System.Drawing.Color.FromArgb(246, 250, 254);
            //this.Appearance.BackColor2 = System.Drawing.Color.FromArgb(214, 222, 234);
            this.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;//.Vertical;
            this.Appearance.BorderColor = System.Drawing.Color.Silver;
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            // --
            this.GroupSettings.HeaderVisible = Infragistics.Win.DefaultableBoolean.False;
            this.GroupSettings.AppearancesSmall.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.GroupSettings.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            // --
            this.ItemSettings.AppearancesSmall.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ItemSettings.AppearancesSmall.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.None;
            this.ItemSettings.AppearancesSmall.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.ItemSettings.AppearancesSmall.Appearance.Image = Properties.Resources.FExplorerbar_Item;
            this.ItemSettings.AppearancesSmall.ActiveAppearance = getActiveAppearance();
            // --
            this.AutoSize = false;
            this.ShowDefaultContextMenu = false;
            this.Style = Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarStyle.VisualStudio2005Toolbox;
            this.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;            
        }

        #endregion
    }
}
