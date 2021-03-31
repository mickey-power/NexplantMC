namespace Nexplant.MC.Core.FaUIs
{
    partial class FBaseStandardForm
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
            this.pnlClient = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.picTitleIcon = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMaximize = new System.Windows.Forms.PictureBox();
            this.picMinimize = new System.Windows.Forms.PictureBox();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.BackColor = System.Drawing.Color.Transparent;
            this.pnlClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlClient.Location = new System.Drawing.Point(0, 27);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Padding = new System.Windows.Forms.Padding(4);
            this.pnlClient.Size = new System.Drawing.Size(392, 309);
            this.pnlClient.TabIndex = 9;
            this.pnlClient.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClient_Paint);
            this.pnlClient.Resize += new System.EventHandler(this.pnlClient_Resize);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.Color.Silver;
            this.pnlTitle.Controls.Add(this.picTitleIcon);
            this.pnlTitle.Controls.Add(this.picClose);
            this.pnlTitle.Controls.Add(this.picMaximize);
            this.pnlTitle.Controls.Add(this.picMinimize);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(392, 27);
            this.pnlTitle.TabIndex = 8;
            this.pnlTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTitle_Paint);
            this.pnlTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDoubleClick);
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            this.pnlTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseMove);
            this.pnlTitle.Resize += new System.EventHandler(this.pnlTitle_Resize);
            // 
            // picTitleIcon
            // 
            this.picTitleIcon.BackColor = System.Drawing.Color.White;
            this.picTitleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picTitleIcon.Location = new System.Drawing.Point(5, 6);
            this.picTitleIcon.Name = "picTitleIcon";
            this.picTitleIcon.Size = new System.Drawing.Size(16, 16);
            this.picTitleIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTitleIcon.TabIndex = 3;
            this.picTitleIcon.TabStop = false;
            this.picTitleIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picTitleIcon_MouseDoubleClick);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackColor = System.Drawing.Color.Transparent;
            this.picClose.Image = global::Nexplant.MC.Core.Properties.Resources.UIForm_TitleClose;
            this.picClose.Location = new System.Drawing.Point(369, 7);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(15, 15);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseDown);
            this.picClose.MouseEnter += new System.EventHandler(this.picClose_MouseEnter);
            this.picClose.MouseLeave += new System.EventHandler(this.picClose_MouseLeave);
            this.picClose.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picClose_MouseUp);
            // 
            // picMaximize
            // 
            this.picMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMaximize.BackColor = System.Drawing.Color.Transparent;
            this.picMaximize.Image = global::Nexplant.MC.Core.Properties.Resources.UIForm_TitleMaximize;
            this.picMaximize.Location = new System.Drawing.Point(351, 7);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.Size = new System.Drawing.Size(15, 15);
            this.picMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMaximize.TabIndex = 1;
            this.picMaximize.TabStop = false;
            this.picMaximize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMaximize_MouseDown);
            this.picMaximize.MouseEnter += new System.EventHandler(this.picMaximize_MouseEnter);
            this.picMaximize.MouseLeave += new System.EventHandler(this.picMaximize_MouseLeave);
            this.picMaximize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMaximize_MouseUp);
            // 
            // picMinimize
            // 
            this.picMinimize.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.Image = global::Nexplant.MC.Core.Properties.Resources.UIForm_TitleMinimize;
            this.picMinimize.Location = new System.Drawing.Point(335, 7);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.Size = new System.Drawing.Size(15, 15);
            this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMinimize.TabIndex = 0;
            this.picMinimize.TabStop = false;
            this.picMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picMinimize_MouseDown);
            this.picMinimize.MouseEnter += new System.EventHandler(this.picMinimize_MouseEnter);
            this.picMinimize.MouseLeave += new System.EventHandler(this.picMinimize_MouseLeave);
            this.picMinimize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picMinimize_MouseUp);
            // 
            // FBaseStandardForm
            // 
            this.ClientSize = new System.Drawing.Size(392, 336);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlTitle);
            this.MinimumSize = new System.Drawing.Size(120, 120);
            this.Name = "FBaseStandardForm";
            this.Text = "Nexplant MC Standard Form Base";
            this.Activated += new System.EventHandler(this.FBaseStandardForm_Activated);
            this.Deactivate += new System.EventHandler(this.FBaseStandardForm_Deactivate);
            this.Load += new System.EventHandler(this.FBaseStandardForm_Load);
            this.TextChanged += new System.EventHandler(this.FBaseStandardForm_TextChanged);
            this.Enter += new System.EventHandler(this.FBaseStandardForm_Enter);
            this.Leave += new System.EventHandler(this.FBaseStandardForm_Leave);
            this.pnlTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitleIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.PictureBox picTitleIcon;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMaximize;
        private System.Windows.Forms.PictureBox picMinimize;
        private System.Windows.Forms.Panel pnlTitle;
    }
}
