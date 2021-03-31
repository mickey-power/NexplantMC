namespace Nexplant.MC.Core.FaUIs
{
    partial class FNumericBox
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
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // FNumericBox
            // 
            this.Size = new System.Drawing.Size(100, 21);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

            // --

            this.Font = new System.Drawing.Font("Verdana", 9F);
            // --
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BorderColor = System.Drawing.Color.Silver;
            // --
            foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase button in this.ButtonsLeft)
            {
                if (button is Infragistics.Win.UltraWinEditors.StateEditorButton)
                {
                    button.Appearance = FNumericBoxCommon.stateButtonAppearance;
                }
            }
            // --
            foreach (Infragistics.Win.UltraWinEditors.EditorButtonBase button in this.ButtonsRight)
            {
                if (button is Infragistics.Win.UltraWinEditors.SpinEditorButton)
                {
                    button.Appearance = FNumericBoxCommon.spinButtonAppearance;
                }
            }
            // --
            this.AutoSize = false;
            this.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            this.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
        }

        #endregion
    }
}
