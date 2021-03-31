namespace Nexplant.MC.Core.FaUIs
{
    partial class FBaseTabChildGroupForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinScrollBar.ScrollBarLook scrollBarLook1 = new Infragistics.Win.UltraWinScrollBar.ScrollBarLook();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.tpnClient = new Nexplant.MC.Core.FaUIs.FTilePanel();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpnClient)).BeginInit();
            this.tpnClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.tpnClient);
            // 
            // tpnClient
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpnClient.Appearance = appearance1;
            this.tpnClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnClient.Font = new System.Drawing.Font("Verdana", 9F);
            this.tpnClient.Location = new System.Drawing.Point(4, 4);
            this.tpnClient.Name = "tpnClient";
            this.tpnClient.NormalModeDimensions = new System.Drawing.Size(0, 0);
            scrollBarLook1.ShowMinMaxButtons = Infragistics.Win.DefaultableBoolean.True;
            scrollBarLook1.ViewStyle = Infragistics.Win.UltraWinScrollBar.ScrollBarViewStyle.Office2010;
            this.tpnClient.ScrollBarLook = scrollBarLook1;
            this.tpnClient.Size = new System.Drawing.Size(431, 283);
            this.tpnClient.TabIndex = 1;
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.BorderColor = System.Drawing.Color.DarkGray;
            this.tpnClient.TileSettings.Appearance = appearance2;
            this.tpnClient.TileSettings.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance3.BackColor = System.Drawing.Color.LightSteelBlue;
            appearance3.BackColor2 = System.Drawing.Color.Lavender;
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.tpnClient.TileSettings.HeaderAppearance = appearance3;
            this.tpnClient.TileSettings.ShowCloseButton = Infragistics.Win.DefaultableBoolean.True;
            this.tpnClient.TileSettings.ShowStateChangeButton = Infragistics.Win.DefaultableBoolean.True;
            this.tpnClient.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FBaseTabChildGroupForm
            // 
            this.ClientSize = new System.Drawing.Size(439, 318);
            this.Name = "FBaseTabChildGroupForm";
            this.Text = "Nexplant MC TAB Child Group Form Base";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FBaseTabChildGroupForm_FormClosing);
            this.Load += new System.EventHandler(this.FBaseTabChildGroupForm_Load);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tpnClient)).EndInit();
            this.tpnClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected FTilePanel tpnClient;
    }
}
