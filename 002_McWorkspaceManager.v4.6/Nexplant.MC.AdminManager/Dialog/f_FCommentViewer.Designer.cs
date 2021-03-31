namespace Nexplant.MC.AdminManager
{
    partial class FCommentViewer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.txtComment = new Nexplant.MC.Core.FaUIs.FEditTextBox();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.txtComment);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
            // 
            // txtComment
            // 
            this.txtComment.AlwaysInEditMode = true;
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BackColor2 = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtComment.Appearance = appearance1;
            this.txtComment.AutoSize = false;
            this.txtComment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtComment.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtComment.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtComment.HideSelection = false;
            this.txtComment.Location = new System.Drawing.Point(4, 4);
            this.txtComment.MaxLength = 2147483647;
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.txtComment.Size = new System.Drawing.Size(516, 307);
            this.txtComment.TabIndex = 3;
            this.txtComment.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            this.txtComment.WordWrap = false;
            // 
            // FCommentViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FCommentViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comment Viewer";
            this.Shown += new System.EventHandler(this.FCommentViewer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FCommentViewer_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtComment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FEditTextBox txtComment;
    }
}