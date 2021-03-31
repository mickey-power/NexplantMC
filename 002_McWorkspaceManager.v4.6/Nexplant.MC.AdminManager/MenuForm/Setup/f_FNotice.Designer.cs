namespace Nexplant.MC.AdminManager
{
    partial class FNotice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FNotice));
            this.btnReset = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnClear = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnUpdate = new Nexplant.MC.Core.FaUIs.FButton();
            this.ftxNotice = new Nexplant.MC.Core.FaUIs.FFormattedEditor();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.ftxNotice);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Padding = new System.Windows.Forms.Padding(2);
            this.pnlDialogClient.Size = new System.Drawing.Size(980, 482);
            // 
            // pnlClient
            // 
            this.pnlClient.Size = new System.Drawing.Size(984, 535);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnReset.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnReset.Location = new System.Drawing.Point(6, 528);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset(&R)";
            this.btnReset.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnClear.Location = new System.Drawing.Point(881, 528);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 28);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear(&R)";
            this.btnClear.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnUpdate.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(778, 528);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(97, 28);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update(&U)";
            this.btnUpdate.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ftxNotice
            // 
            this.ftxNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftxNotice.Location = new System.Drawing.Point(2, 2);
            this.ftxNotice.Name = "ftxNotice";
            this.ftxNotice.Size = new System.Drawing.Size(976, 478);
            this.ftxNotice.TabIndex = 0;
            this.ftxNotice.TabStop = false;
            this.ftxNotice.value = "";
            // 
            // FNotice
            // 
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FNotice";
            this.Text = "Notice";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FNotice_FormClosing);
            this.Load += new System.EventHandler(this.FNotice_Load);
            this.Shown += new System.EventHandler(this.FNotice_Shown);
            this.Controls.SetChildIndex(this.pnlClient, 0);
            this.Controls.SetChildIndex(this.btnUpdate, 0);
            this.Controls.SetChildIndex(this.btnClear, 0);
            this.Controls.SetChildIndex(this.btnReset, 0);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnReset;
        private Core.FaUIs.FButton btnClear;
        private Core.FaUIs.FButton btnUpdate;
        private Core.FaUIs.FFormattedEditor ftxNotice;
    }
}
