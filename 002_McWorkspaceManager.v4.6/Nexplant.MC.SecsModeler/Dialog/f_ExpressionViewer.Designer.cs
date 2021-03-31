namespace Nexplant.MC.SecsModeler
{
    partial class FExpressionViewer
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.txtValue = new Nexplant.MC.Core.FaUIs.FEditTextBox();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.txtValue);
            this.pnlClient.Size = new System.Drawing.Size(524, 315);
            // 
            // txtValue
            // 
            this.txtValue.AlwaysInEditMode = true;
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.BorderColor = System.Drawing.Color.Silver;
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.txtValue.Appearance = appearance1;
            this.txtValue.AutoSize = false;
            this.txtValue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtValue.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.txtValue.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.txtValue.HideSelection = false;
            this.txtValue.Location = new System.Drawing.Point(4, 4);
            this.txtValue.MaxLength = 2147483647;
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Scrollbars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtValue.Size = new System.Drawing.Size(516, 307);
            this.txtValue.TabIndex = 3;
            this.txtValue.UseOsThemes = Infragistics.Win.DefaultableBoolean.False;
            // 
            // FExpressionViewer2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 342);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FExpressionViewer2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Expression Viewer";
            this.Shown += new System.EventHandler(this.FExpressionViewer_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FExpressionViewer_KeyDown);
            this.pnlClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FEditTextBox txtValue;

    }
}