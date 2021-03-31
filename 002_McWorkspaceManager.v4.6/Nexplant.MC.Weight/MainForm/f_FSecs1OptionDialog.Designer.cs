namespace Nexplant.MC.Counter
{
    partial class FSecs1OptionDialog
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
            this.cboSerialPort = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.chkRBit = new System.Windows.Forms.CheckBox();
            this.chkInterleave = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkDuplicateError = new System.Windows.Forms.CheckBox();
            this.lblDuplicateError = new System.Windows.Forms.Label();
            this.chkIgnoreSystemBytes = new System.Windows.Forms.CheckBox();
            this.lblIgnoreSystemBytes = new System.Windows.Forms.Label();
            this.txtRetryLimit = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtT1Timeout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtT2Timeout = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtT4Timeout = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtT3Timeout = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("새굴림", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "SECS1 Option";
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
            this.txtSessionId.Location = new System.Drawing.Point(177, 45);
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
            this.label2.Text = "Serial Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboSerialPort
            // 
            this.cboSerialPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSerialPort.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSerialPort.FormattingEnabled = true;
            this.cboSerialPort.ItemHeight = 16;
            this.cboSerialPort.Location = new System.Drawing.Point(0, 0);
            this.cboSerialPort.Name = "cboSerialPort";
            this.cboSerialPort.Size = new System.Drawing.Size(171, 24);
            this.cboSerialPort.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(372, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 26);
            this.label3.TabIndex = 38;
            this.label3.Text = "Baud";
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
            this.label4.Text = "R-Bit";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBaud
            // 
            this.cboBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboBaud.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.ItemHeight = 16;
            this.cboBaud.Location = new System.Drawing.Point(0, 0);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(171, 24);
            this.cboBaud.TabIndex = 2;
            // 
            // chkRBit
            // 
            this.chkRBit.AutoSize = true;
            this.chkRBit.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkRBit.Location = new System.Drawing.Point(177, 113);
            this.chkRBit.Name = "chkRBit";
            this.chkRBit.Size = new System.Drawing.Size(15, 14);
            this.chkRBit.TabIndex = 3;
            this.chkRBit.UseVisualStyleBackColor = true;
            // 
            // chkInterleave
            // 
            this.chkInterleave.AutoSize = true;
            this.chkInterleave.Location = new System.Drawing.Point(537, 114);
            this.chkInterleave.Name = "chkInterleave";
            this.chkInterleave.Size = new System.Drawing.Size(15, 14);
            this.chkInterleave.TabIndex = 4;
            this.chkInterleave.UseVisualStyleBackColor = true;
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
            this.label5.Text = "Interleave";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkDuplicateError
            // 
            this.chkDuplicateError.AutoSize = true;
            this.chkDuplicateError.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkDuplicateError.Location = new System.Drawing.Point(177, 144);
            this.chkDuplicateError.Name = "chkDuplicateError";
            this.chkDuplicateError.Size = new System.Drawing.Size(15, 14);
            this.chkDuplicateError.TabIndex = 5;
            this.chkDuplicateError.UseVisualStyleBackColor = true;
            // 
            // lblDuplicateError
            // 
            this.lblDuplicateError.BackColor = System.Drawing.Color.DimGray;
            this.lblDuplicateError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDuplicateError.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDuplicateError.ForeColor = System.Drawing.Color.White;
            this.lblDuplicateError.Location = new System.Drawing.Point(12, 138);
            this.lblDuplicateError.Name = "lblDuplicateError";
            this.lblDuplicateError.Size = new System.Drawing.Size(160, 26);
            this.lblDuplicateError.TabIndex = 45;
            this.lblDuplicateError.Text = "Duplicate Error";
            this.lblDuplicateError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkIgnoreSystemBytes
            // 
            this.chkIgnoreSystemBytes.AutoSize = true;
            this.chkIgnoreSystemBytes.Location = new System.Drawing.Point(537, 143);
            this.chkIgnoreSystemBytes.Name = "chkIgnoreSystemBytes";
            this.chkIgnoreSystemBytes.Size = new System.Drawing.Size(15, 14);
            this.chkIgnoreSystemBytes.TabIndex = 6;
            this.chkIgnoreSystemBytes.UseVisualStyleBackColor = true;
            // 
            // lblIgnoreSystemBytes
            // 
            this.lblIgnoreSystemBytes.BackColor = System.Drawing.Color.DimGray;
            this.lblIgnoreSystemBytes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgnoreSystemBytes.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIgnoreSystemBytes.ForeColor = System.Drawing.Color.White;
            this.lblIgnoreSystemBytes.Location = new System.Drawing.Point(372, 138);
            this.lblIgnoreSystemBytes.Name = "lblIgnoreSystemBytes";
            this.lblIgnoreSystemBytes.Size = new System.Drawing.Size(160, 26);
            this.lblIgnoreSystemBytes.TabIndex = 47;
            this.lblIgnoreSystemBytes.Text = "Ignore System Bytes";
            this.lblIgnoreSystemBytes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRetryLimit
            // 
            this.txtRetryLimit.BackColor = System.Drawing.Color.White;
            this.txtRetryLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetryLimit.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRetryLimit.Location = new System.Drawing.Point(177, 169);
            this.txtRetryLimit.Name = "txtRetryLimit";
            this.txtRetryLimit.Size = new System.Drawing.Size(173, 26);
            this.txtRetryLimit.TabIndex = 7;
            this.txtRetryLimit.Text = "0";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DimGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 26);
            this.label8.TabIndex = 49;
            this.label8.Text = "Retry Limit";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT1Timeout
            // 
            this.txtT1Timeout.BackColor = System.Drawing.Color.White;
            this.txtT1Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT1Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT1Timeout.Location = new System.Drawing.Point(177, 200);
            this.txtT1Timeout.Name = "txtT1Timeout";
            this.txtT1Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT1Timeout.TabIndex = 8;
            this.txtT1Timeout.Text = "0";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DimGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 200);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 26);
            this.label9.TabIndex = 51;
            this.label9.Text = "T1 Timeout";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT2Timeout
            // 
            this.txtT2Timeout.BackColor = System.Drawing.Color.White;
            this.txtT2Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT2Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT2Timeout.Location = new System.Drawing.Point(537, 200);
            this.txtT2Timeout.Name = "txtT2Timeout";
            this.txtT2Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT2Timeout.TabIndex = 9;
            this.txtT2Timeout.Text = "0";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DimGray;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(372, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 26);
            this.label10.TabIndex = 53;
            this.label10.Text = "T2 Timeout";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT4Timeout
            // 
            this.txtT4Timeout.BackColor = System.Drawing.Color.White;
            this.txtT4Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT4Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT4Timeout.Location = new System.Drawing.Point(537, 232);
            this.txtT4Timeout.Name = "txtT4Timeout";
            this.txtT4Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT4Timeout.TabIndex = 11;
            this.txtT4Timeout.Text = "0";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.DimGray;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(372, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(160, 26);
            this.label11.TabIndex = 57;
            this.label11.Text = "T4 Timeout";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtT3Timeout
            // 
            this.txtT3Timeout.BackColor = System.Drawing.Color.White;
            this.txtT3Timeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtT3Timeout.Font = new System.Drawing.Font("새굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtT3Timeout.Location = new System.Drawing.Point(177, 232);
            this.txtT3Timeout.Name = "txtT3Timeout";
            this.txtT3Timeout.Size = new System.Drawing.Size(173, 26);
            this.txtT3Timeout.TabIndex = 10;
            this.txtT3Timeout.Text = "0";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.DimGray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("새굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(160, 26);
            this.label12.TabIndex = 55;
            this.label12.Text = "T3 Timeout";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cboSerialPort);
            this.panel3.Location = new System.Drawing.Point(177, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(173, 26);
            this.panel3.TabIndex = 58;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.cboBaud);
            this.panel4.Location = new System.Drawing.Point(537, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(173, 26);
            this.panel4.TabIndex = 59;
            // 
            // FSecs1OptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(722, 455);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtT4Timeout);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtT3Timeout);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtT2Timeout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtT1Timeout);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRetryLimit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chkIgnoreSystemBytes);
            this.Controls.Add(this.lblIgnoreSystemBytes);
            this.Controls.Add(this.chkDuplicateError);
            this.Controls.Add(this.lblDuplicateError);
            this.Controls.Add(this.chkInterleave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkRBit);
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
            this.Name = "FSecs1OptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FErrorMessageBox";
            this.Load += new System.EventHandler(this.FSecs1OptionDialog_Load);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cboSerialPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.CheckBox chkRBit;
        private System.Windows.Forms.CheckBox chkInterleave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkDuplicateError;
        private System.Windows.Forms.Label lblDuplicateError;
        private System.Windows.Forms.CheckBox chkIgnoreSystemBytes;
        private System.Windows.Forms.Label lblIgnoreSystemBytes;
        private System.Windows.Forms.TextBox txtRetryLimit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtT1Timeout;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtT2Timeout;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtT4Timeout;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtT3Timeout;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}