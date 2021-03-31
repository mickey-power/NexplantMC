namespace Nexplant.MC.SecsModeler
{
    partial class FAllInOneModeler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAllInOneModeler));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.spLeft = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.pnlCenter);
            this.pnlClient.Controls.Add(this.splitter1);
            this.pnlClient.Controls.Add(this.spLeft);
            this.pnlClient.Controls.Add(this.pnlRight);
            this.pnlClient.Controls.Add(this.pnlLeft);
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(4, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 527);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(780, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(200, 527);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(209, 4);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(566, 527);
            this.pnlCenter.TabIndex = 2;
            // 
            // spLeft
            // 
            this.spLeft.Location = new System.Drawing.Point(204, 4);
            this.spLeft.Name = "spLeft";
            this.spLeft.Size = new System.Drawing.Size(5, 527);
            this.spLeft.TabIndex = 3;
            this.spLeft.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(775, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 527);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // FAllInOneModeler
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAllInOneModeler";
            this.ShowInTaskbar = false;
            this.Text = "All In One Modeler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FAllInOneModeler_FormClosing);
            this.Load += new System.EventHandler(this.FAllInOneModeler_Load);
            this.Shown += new System.EventHandler(this.FAllInOneModeler_Shown);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter spLeft;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;

    }
}
