namespace Nexplant.MC.AdminManager
{
    partial class FNotification
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
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.ftxNotice = new Nexplant.MC.Core.FaUIs.FFormattedBox();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.ftxNotice);
            this.pnlDialogClient.Location = new System.Drawing.Point(2, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(618, 373);
            this.pnlDialogClient.TabIndex = 0;
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Size = new System.Drawing.Size(622, 426);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(517, 391);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(97, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ftxNotice
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            this.ftxNotice.Appearance = appearance1;
            this.ftxNotice.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ftxNotice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ftxNotice.Location = new System.Drawing.Point(0, 0);
            this.ftxNotice.Name = "ftxNotice";
            this.ftxNotice.ReadOnly = true;
            this.ftxNotice.Size = new System.Drawing.Size(618, 373);
            this.ftxNotice.TabIndex = 41;
            this.ftxNotice.UseFlatMode = Infragistics.Win.DefaultableBoolean.True;
            this.ftxNotice.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.ftxNotice.Value = "";
            // 
            // FNotification
            // 
            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnOk;
            this.ClientSize = new System.Drawing.Size(622, 453);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.Shown += new System.EventHandler(this.FNotification_Shown);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FFormattedBox ftxNotice;
    }
}
