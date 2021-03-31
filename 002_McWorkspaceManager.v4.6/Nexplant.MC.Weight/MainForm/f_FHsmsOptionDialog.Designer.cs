namespace Nexplant.MC.Counter
{
    partial class FHsmsOptionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSessionId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboConnectMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLinkTestPeriod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtT3Timeout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtT5Timeout = new System.Windows.Forms.TextBox();
            this.lblT5Timeout = new System.Windows.Forms.Label();
            this.txtT7Timeout = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtT6Timeout = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLocalIp = new System.Windows.Forms.TextBox();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemotePort = new System.Windows.Forms.TextBox();
            this.txtRemoteIp = new System.Windows.Forms.TextBox();
            this.txtT8Timeout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("새굴림", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "HSMS Option";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 4);
            this.panel2.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnCancel.Font = new System.Drawing.Font("새굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(609, 364);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 79);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnOk.Font = new System.Drawing.Font("새굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOk.Location = new System.Drawing.Point(501, 364);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(101, 79);
            this.btnOk.TabIndex = 12;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 350);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 4);
            this.panel1.TabIndex = 21;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.DimGray;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label36.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label36.ForeColor = System.Drawing.Color.White;
            this.label36.Location = new System.Drawing.Point(12, 45);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(160, 26);
            this.label36.TabIndex = 34;
            this.label36.Text = "Session ID";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSessionId
            // 
            this.txtSessionId.BackColor = System.Drawing.Color.White;
            this.txtSessionId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSessionId.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSessionId.Location = new System.Drawing.Point(177, 44);
            this.txtSessionId.Name = "txtSessionId";
            this.txtSessionId.Size = new System.Drawing.Size(173, 26);
            this.txtSessionId.TabIndex = 0;
            this.txtSessionId.Text = "0";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 26);
            this.label2.TabIndex = 36;
            this.label2.Text = "Local IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 26);
            this.label3.TabIndex = 38;
            this.label3.Text = "Connect Mode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 26);
            this.label4.TabIndex = 40;
            this.label4.Text = "Remote IP";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboConnectMode
            // 
            this.cboConnectMode.BackColor = System.Drawing.Color.White;
            this.cboConnectMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboConnectMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboConnectMode.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboConnectMode.FormattingEnabled = true;
            this.cboConnectMode.ItemHeight = 16;
            this.cboConnectMode.Location = new System.Drawing.Point(0, 0);
            this.cboConnectMode.Name = "cboConnectMode";
            this.cboConnectMode.Size = new System.Drawing.Size(171, 24);
            this.cboConnectMode.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DimGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(372, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 26);
            this.label5.TabIndex = 43;
            this.label5.Text = "Remote Port";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLinkTestPeriod
            // 
            this.txtLinkTestPeriod.BackColor = System.Drawing.Color.White;
            this.txtLinkTestPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLinkTestPeriod.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLinkTestPeriod.Location = new System.Drawing.Point(177, 138);
            this.txtLinkTestPeriod.Name = "txtLinkTestPeriod";
            this.txtLinkTestPeriod.Size = new System.Drawing.Size(173, 26);
            this.txtLinkTestPeriod.TabIndex = 6;
            this.txtLinkTestPeriod.Text = "0";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DimGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 26);
            this.label8.TabIndex = 49;
            this.label8.Text = "Link Test Period";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT3Timeout
            // 
            this.txtT3Timeout.BackColor = System.Drawing.Color.White;
            this.txtT3Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT3Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT3Timeout.Location = new System.Drawing.Point(537, 138);
            this.txtT3Timeout.Name = "txtT3Timeout";
            this.txtT3Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT3Timeout.TabIndex = 7;
            this.txtT3Timeout.Text = "0";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(372, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 26);
            this.label9.TabIndex = 51;
            this.label9.Text = "T3 Timeout";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT5Timeout
            // 
            this.txtT5Timeout.BackColor = System.Drawing.Color.White;
            this.txtT5Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT5Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT5Timeout.Location = new System.Drawing.Point(177, 169);
            this.txtT5Timeout.Name = "txtT5Timeout";
            this.txtT5Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT5Timeout.TabIndex = 8;
            this.txtT5Timeout.Text = "0";
            // 
            // lblT5Timeout
            // 
            this.lblT5Timeout.BackColor = System.Drawing.Color.DimGray;
            this.lblT5Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblT5Timeout.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblT5Timeout.ForeColor = System.Drawing.Color.White;
            this.lblT5Timeout.Location = new System.Drawing.Point(12, 169);
            this.lblT5Timeout.Name = "lblT5Timeout";
            this.lblT5Timeout.Size = new System.Drawing.Size(160, 26);
            this.lblT5Timeout.TabIndex = 53;
            this.lblT5Timeout.Text = "T5 Timeout";
            this.lblT5Timeout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT7Timeout
            // 
            this.txtT7Timeout.BackColor = System.Drawing.Color.White;
            this.txtT7Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT7Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT7Timeout.Location = new System.Drawing.Point(177, 201);
            this.txtT7Timeout.Name = "txtT7Timeout";
            this.txtT7Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT7Timeout.TabIndex = 10;
            this.txtT7Timeout.Text = "0";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DimGray;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(12, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 26);
            this.label11.TabIndex = 57;
            this.label11.Text = "T7 Timeout";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT6Timeout
            // 
            this.txtT6Timeout.BackColor = System.Drawing.Color.White;
            this.txtT6Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT6Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT6Timeout.Location = new System.Drawing.Point(537, 169);
            this.txtT6Timeout.Name = "txtT6Timeout";
            this.txtT6Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT6Timeout.TabIndex = 9;
            this.txtT6Timeout.Text = "0";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DimGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(372, 169);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 26);
            this.label12.TabIndex = 55;
            this.label12.Text = "T6 Timeout";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLocalIp
            // 
            this.txtLocalIp.BackColor = System.Drawing.Color.White;
            this.txtLocalIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocalIp.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocalIp.Location = new System.Drawing.Point(177, 76);
            this.txtLocalIp.Name = "txtLocalIp";
            this.txtLocalIp.Size = new System.Drawing.Size(173, 26);
            this.txtLocalIp.TabIndex = 2;
            this.txtLocalIp.Text = "0";
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.BackColor = System.Drawing.Color.White;
            this.txtLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocalPort.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLocalPort.Location = new System.Drawing.Point(537, 76);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.Size = new System.Drawing.Size(173, 26);
            this.txtLocalPort.TabIndex = 3;
            this.txtLocalPort.Text = "0";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.DimGray;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(372, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 26);
            this.label13.TabIndex = 60;
            this.label13.Text = "Local Port";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemotePort
            // 
            this.txtRemotePort.BackColor = System.Drawing.Color.White;
            this.txtRemotePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemotePort.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemotePort.Location = new System.Drawing.Point(537, 107);
            this.txtRemotePort.Name = "txtRemotePort";
            this.txtRemotePort.Size = new System.Drawing.Size(173, 26);
            this.txtRemotePort.TabIndex = 5;
            this.txtRemotePort.Text = "0";
            // 
            // txtRemoteIp
            // 
            this.txtRemoteIp.BackColor = System.Drawing.Color.White;
            this.txtRemoteIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemoteIp.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemoteIp.Location = new System.Drawing.Point(177, 107);
            this.txtRemoteIp.Name = "txtRemoteIp";
            this.txtRemoteIp.Size = new System.Drawing.Size(173, 26);
            this.txtRemoteIp.TabIndex = 4;
            this.txtRemoteIp.Text = "0";
            // 
            // txtT8Timeout
            // 
            this.txtT8Timeout.BackColor = System.Drawing.Color.White;
            this.txtT8Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT8Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT8Timeout.Location = new System.Drawing.Point(537, 201);
            this.txtT8Timeout.Name = "txtT8Timeout";
            this.txtT8Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT8Timeout.TabIndex = 11;
            this.txtT8Timeout.Text = "0";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(372, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 26);
            this.label6.TabIndex = 64;
            this.label6.Text = "T8 Timeout";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboConnectMode);
            this.panel3.Location = new System.Drawing.Point(536, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 26);
            this.panel3.TabIndex = 65;
            // 
            // FHsmsOptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(722, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtT8Timeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRemotePort);
            this.Controls.Add(this.txtRemoteIp);
            this.Controls.Add(this.txtLocalPort);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtLocalIp);
            this.Controls.Add(this.txtT7Timeout);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtT6Timeout);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtT5Timeout);
            this.Controls.Add(this.lblT5Timeout);
            this.Controls.Add(this.txtT3Timeout);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLinkTestPeriod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSessionId);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FHsmsOptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FErrorMessageBox";
            this.Load += new System.EventHandler(this.FHsmsOptionDialog_Load);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtSessionId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboConnectMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLinkTestPeriod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtT3Timeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtT5Timeout;
        private System.Windows.Forms.Label lblT5Timeout;
        private System.Windows.Forms.TextBox txtT7Timeout;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtT6Timeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLocalIp;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemotePort;
        private System.Windows.Forms.TextBox txtRemoteIp;
        private System.Windows.Forms.TextBox txtT8Timeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
    }
}