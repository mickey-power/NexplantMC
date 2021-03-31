namespace Nexplant.MC.Core.FaUIs
{
    partial class FRefreshAndSearchToolbar
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.btnRefresh = new Nexplant.MC.Core.FaUIs.FToolButton();
            this.txtSearchWord = new Nexplant.MC.Core.FaUIs.FTextBox();
            this.btnSearch = new Nexplant.MC.Core.FaUIs.FToolButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchWord)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            appearance3.Image = global::Nexplant.MC.Core.Properties.Resources.ToolRefresh;
            appearance3.BorderColor = System.Drawing.Color.Silver;
            this.btnRefresh.Appearance = appearance3;
            this.btnRefresh.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnRefresh.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.ShowFocusRect = false;
            this.btnRefresh.ShowOutline = false;
            this.btnRefresh.Size = new System.Drawing.Size(21, 21);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.BorderColor = System.Drawing.Color.Silver;
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.txtSearchWord.Appearance = appearance2;
            this.txtSearchWord.AutoSize = false;
            this.txtSearchWord.BackColor = System.Drawing.Color.White;
            this.txtSearchWord.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtSearchWord.Font = new System.Drawing.Font("Verdana", 9F);
            this.txtSearchWord.Location = new System.Drawing.Point(23, 0);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(351, 21);
            this.txtSearchWord.TabIndex = 1;
            this.txtSearchWord.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtSearchWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchWord_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.Image = global::Nexplant.MC.Core.Properties.Resources.ToolFind;
            this.btnSearch.Appearance = appearance1;
            this.btnSearch.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnSearch.Location = new System.Drawing.Point(376, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ShowFocusRect = false;
            this.btnSearch.ShowOutline = false;
            this.btnSearch.Size = new System.Drawing.Size(21, 21);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FRefreshAndSearchToolbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchWord);
            this.Controls.Add(this.btnRefresh);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FRefreshAndSearchToolbar";
            this.Size = new System.Drawing.Size(397, 21);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchWord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FToolButton btnRefresh;
        private FTextBox txtSearchWord;
        private FToolButton btnSearch;

    }
}
