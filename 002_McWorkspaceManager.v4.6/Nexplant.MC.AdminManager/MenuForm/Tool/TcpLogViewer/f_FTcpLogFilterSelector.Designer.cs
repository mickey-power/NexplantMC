namespace Nexplant.MC.AdminManager
{
    partial class FTcpLogFilterSelector
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
            this.btnOk = new Nexplant.MC.Core.FaUIs.FButton();
            this.btnCancel = new Nexplant.MC.Core.FaUIs.FButton();
            this.ultraTabPageControl1 = new Infragistics.Win.UltraWinTabControl.UltraTabPageControl();
            this.btnDefault = new Nexplant.MC.Core.FaUIs.FButton();
            this.pgdFilter = new Nexplant.MC.Core.FaUIs.FDynPropGrid();
            this.pnlDialogClient.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDialogClient
            // 
            this.pnlDialogClient.Controls.Add(this.pgdFilter);
            this.pnlDialogClient.Controls.Add(this.btnDefault);
            this.pnlDialogClient.Location = new System.Drawing.Point(3, 2);
            this.pnlDialogClient.Size = new System.Drawing.Size(652, 368);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.btnOk);
            this.pnlClient.Controls.Add(this.btnCancel);
            this.pnlClient.Size = new System.Drawing.Size(657, 421);
            this.pnlClient.Controls.SetChildIndex(this.pnlDialogClient, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlClient.Controls.SetChildIndex(this.btnOk, 0);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnOk.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnOk.Location = new System.Drawing.Point(467, 386);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 28);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK(&O)";
            this.btnOk.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnCancel.Location = new System.Drawing.Point(559, 386);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 28);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel(&C)";
            this.btnCancel.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            // 
            // ultraTabPageControl1
            // 
            this.ultraTabPageControl1.Location = new System.Drawing.Point(-10000, -10000);
            this.ultraTabPageControl1.Name = "ultraTabPageControl1";
            this.ultraTabPageControl1.Size = new System.Drawing.Size(409, 339);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDefault.ButtonStyle = Infragistics.Win.UIElementButtonStyle.WindowsVistaButton;
            this.btnDefault.Font = new System.Drawing.Font("Verdana", 9F);
            this.btnDefault.Location = new System.Drawing.Point(556, 335);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(86, 28);
            this.btnDefault.TabIndex = 1;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseOsThemes = Infragistics.Win.DefaultableBoolean.True;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // pgdFilter
            // 
            this.pgdFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgdFilter.BackColor = System.Drawing.Color.Gainsboro;
            this.pgdFilter.CategoryForeColor = System.Drawing.Color.DimGray;
            this.pgdFilter.CommandsBackColor = System.Drawing.Color.Gainsboro;
            this.pgdFilter.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.pgdFilter.HelpVisible = false;
            this.pgdFilter.LineColor = System.Drawing.Color.Silver;
            this.pgdFilter.Location = new System.Drawing.Point(4, 3);
            this.pgdFilter.Name = "pgdFilter";
            this.pgdFilter.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgdFilter.selectedObject = null;
            this.pgdFilter.Size = new System.Drawing.Size(644, 325);
            this.pgdFilter.TabIndex = 0;
            this.pgdFilter.ToolbarVisible = false;
            this.pgdFilter.ViewBackColor = System.Drawing.Color.WhiteSmoke;
            this.pgdFilter.ViewForeColor = System.Drawing.Color.Black;
            // 
            // FTcpLogFilterSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(657, 448);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTcpLogFilterSelector";
            this.resizable = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Filter";
            this.Load += new System.EventHandler(this.FLogFilter_Load);
            this.pnlDialogClient.ResumeLayout(false);
            this.pnlClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Core.FaUIs.FButton btnOk;
        private Core.FaUIs.FButton btnCancel;
        private Infragistics.Win.UltraWinTabControl.UltraTabPageControl ultraTabPageControl1;
        private Core.FaUIs.FButton btnDefault;
        private Core.FaUIs.FDynPropGrid pgdFilter;
    }
}