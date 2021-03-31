namespace Nexplant.MC.TcpModeler
{
    partial class FValueViewer
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtxValue = new Nexplant.MC.Core.FaUIs.FRichTextBox();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlClient.Controls.Add(this.rtxValue);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
            // 
            // rtxValue
            // 
            this.rtxValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rtxValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxValue.CausesValidation = false;
            this.rtxValue.DetectUrls = false;
            this.rtxValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxValue.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxValue.Location = new System.Drawing.Point(4, 4);
            this.rtxValue.Name = "rtxValue";
            this.rtxValue.ReadOnly = true;
            this.rtxValue.ShortcutsEnabled = false;
            this.rtxValue.Size = new System.Drawing.Size(514, 305);
            this.rtxValue.TabIndex = 0;
            this.rtxValue.Text = "";
            // 
            // FValueViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FValueViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Value Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FValueViewer_FormClosing);
            this.Shown += new System.EventHandler(this.FValueViewer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FValueViewer_KeyDown);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FRichTextBox rtxValue;


    }
}