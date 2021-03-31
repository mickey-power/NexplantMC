namespace Nexplant.MC.Core.FaUIs
{
    partial class FTabChildIcon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FTabChildIcon
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(138, 111);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FTabChildIcon";
            this.Text = "FTabChildIcon";
            this.Load += new System.EventHandler(this.FTabChildIcon_Load);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FTabChildIcon_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FTabChildIcon_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FTabChildIcon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FTabChildIcon_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}