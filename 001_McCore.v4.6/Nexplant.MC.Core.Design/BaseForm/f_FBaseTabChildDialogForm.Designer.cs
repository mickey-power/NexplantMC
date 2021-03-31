namespace Nexplant.MC.Core.FaUIs
{
    partial class FBaseTabChildDialogForm
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDialogClient = new System.Windows.Forms.Panel();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlDialogClient);
            this.pnlClient.Size = new System.Drawing.Size(439, 315);
            this.pnlClient.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClient_Paint);
            this.pnlClient.Resize += new System.EventHandler(this.pnlClient_Resize);
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDialogClient.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDialogClient.Location = new System.Drawing.Point(7, 7);
            this.pnlDialogClient.Name = "pnlDialogClient";
            this.pnlDialogClient.Size = new System.Drawing.Size(167, 134);
            this.pnlDialogClient.TabIndex = 2;
            // 
            // FTabChildDialogFormBase
            // 
            this.ClientSize = new System.Drawing.Size(439, 342);
            this.Name = "FTabChildDialogFormBase";
            this.Shown += new System.EventHandler(this.FBaseTabChildDialogForm_Shown);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlDialogClient;
    }
}
