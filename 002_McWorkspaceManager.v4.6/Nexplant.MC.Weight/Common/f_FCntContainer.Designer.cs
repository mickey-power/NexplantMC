namespace Nexplant.MC.Counter
{
    partial class FMainContainer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainContainer));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVer = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picPort1 = new System.Windows.Forms.PictureBox();
            this.picPort2 = new System.Windows.Forms.PictureBox();
            this.picPort3 = new System.Windows.Forms.PictureBox();
            this.picPort4 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblSecs1SentCount = new System.Windows.Forms.Label();
            this.lblSecs1RecvCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSecs1SentNak = new System.Windows.Forms.Label();
            this.lblSecs1RecvNak = new System.Windows.Forms.Label();
            this.lblSecs1SentAck = new System.Windows.Forms.Label();
            this.lblSecs1RecvAck = new System.Windows.Forms.Label();
            this.lblSecs1SentBlock = new System.Windows.Forms.Label();
            this.lblSecs1RecvBlock = new System.Windows.Forms.Label();
            this.lblSecs1SentEot = new System.Windows.Forms.Label();
            this.lblSecs1RecvEot = new System.Windows.Forms.Label();
            this.lblSecs1SentEnq = new System.Windows.Forms.Label();
            this.lblSecs1RecvEnq = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSecs1State = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblHsmsSentCount = new System.Windows.Forms.Label();
            this.lblHsmsRecvCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblHsmsSent = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblHsmsRecv = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblHsmsState = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblPort1 = new System.Windows.Forms.Label();
            this.lblLot1 = new System.Windows.Forms.Label();
            this.lblLot2 = new System.Windows.Forms.Label();
            this.lblPort2 = new System.Windows.Forms.Label();
            this.lblLot3 = new System.Windows.Forms.Label();
            this.lblPort3 = new System.Windows.Forms.Label();
            this.lblLot4 = new System.Windows.Forms.Label();
            this.lblPort4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblAsignLot1 = new System.Windows.Forms.Label();
            this.lblAsignLot2 = new System.Windows.Forms.Label();
            this.lblAsignLot3 = new System.Windows.Forms.Label();
            this.lblAsignLot4 = new System.Windows.Forms.Label();
            this.txtBcrRead = new System.Windows.Forms.TextBox();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblOffline = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblRemote = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTerminalMessage = new System.Windows.Forms.Button();
            this.btnPreviousMessage = new System.Windows.Forms.Button();
            this.btnNextMessage = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.picPort1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort4)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnExit.Font = new System.Drawing.Font("New Gulim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(574, 517);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 80);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.Enter += new System.EventHandler(this.btnExit_Enter);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMenu.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnMenu.Font = new System.Drawing.Font("New Gulim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMenu.Location = new System.Drawing.Point(1, 518);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(110, 80);
            this.btnMenu.TabIndex = 2;
            this.btnMenu.TabStop = false;
            this.btnMenu.Text = "Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.Enter += new System.EventHandler(this.btnMenu_Enter);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 513);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 4);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("New Gulim", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(27, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "MC Operator Interface";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 4);
            this.panel2.TabIndex = 5;
            // 
            // lblVer
            // 
            this.lblVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVer.BackColor = System.Drawing.Color.Transparent;
            this.lblVer.Font = new System.Drawing.Font("New Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVer.ForeColor = System.Drawing.Color.Black;
            this.lblVer.Location = new System.Drawing.Point(542, 3);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(257, 15);
            this.lblVer.TabIndex = 6;
            this.lblVer.Text = "Build Ver. 4.5.2.112";
            this.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(1, 172);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 4);
            this.panel3.TabIndex = 7;
            // 
            // picPort1
            // 
            this.picPort1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPort1.BackColor = System.Drawing.Color.Transparent;
            this.picPort1.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.LotUnload;
            this.picPort1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPort1.Location = new System.Drawing.Point(1, 28);
            this.picPort1.Name = "picPort1";
            this.picPort1.Size = new System.Drawing.Size(197, 150);
            this.picPort1.TabIndex = 8;
            this.picPort1.TabStop = false;
            // 
            // picPort2
            // 
            this.picPort2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPort2.BackColor = System.Drawing.Color.Transparent;
            this.picPort2.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.LotArrived;
            this.picPort2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPort2.Location = new System.Drawing.Point(1, 28);
            this.picPort2.Name = "picPort2";
            this.picPort2.Size = new System.Drawing.Size(194, 150);
            this.picPort2.TabIndex = 9;
            this.picPort2.TabStop = false;
            // 
            // picPort3
            // 
            this.picPort3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPort3.BackColor = System.Drawing.Color.Transparent;
            this.picPort3.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.LotMoveIn;
            this.picPort3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPort3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPort3.Location = new System.Drawing.Point(1, 27);
            this.picPort3.Name = "picPort3";
            this.picPort3.Size = new System.Drawing.Size(196, 150);
            this.picPort3.TabIndex = 10;
            this.picPort3.TabStop = false;
            // 
            // picPort4
            // 
            this.picPort4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPort4.BackColor = System.Drawing.Color.Transparent;
            this.picPort4.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.LotMoveOut;
            this.picPort4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPort4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPort4.Location = new System.Drawing.Point(1, 27);
            this.picPort4.Name = "picPort4";
            this.picPort4.Size = new System.Drawing.Size(191, 150);
            this.picPort4.TabIndex = 11;
            this.picPort4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblSecs1SentCount);
            this.groupBox1.Controls.Add(this.lblSecs1RecvCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSecs1SentNak);
            this.groupBox1.Controls.Add(this.lblSecs1RecvNak);
            this.groupBox1.Controls.Add(this.lblSecs1SentAck);
            this.groupBox1.Controls.Add(this.lblSecs1RecvAck);
            this.groupBox1.Controls.Add(this.lblSecs1SentBlock);
            this.groupBox1.Controls.Add(this.lblSecs1RecvBlock);
            this.groupBox1.Controls.Add(this.lblSecs1SentEot);
            this.groupBox1.Controls.Add(this.lblSecs1RecvEot);
            this.groupBox1.Controls.Add(this.lblSecs1SentEnq);
            this.groupBox1.Controls.Add(this.lblSecs1RecvEnq);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblSecs1State);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("New Gulim", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(5, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(794, 62);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SECS1 Status";
            // 
            // lblSecs1SentCount
            // 
            this.lblSecs1SentCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSecs1SentCount.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentCount.Font = new System.Drawing.Font("New Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentCount.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentCount.Location = new System.Drawing.Point(674, 38);
            this.lblSecs1SentCount.Name = "lblSecs1SentCount";
            this.lblSecs1SentCount.Size = new System.Drawing.Size(117, 17);
            this.lblSecs1SentCount.TabIndex = 43;
            this.lblSecs1SentCount.Text = "0";
            this.lblSecs1SentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSecs1RecvCount
            // 
            this.lblSecs1RecvCount.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvCount.Font = new System.Drawing.Font("New Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvCount.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvCount.Location = new System.Drawing.Point(557, 38);
            this.lblSecs1RecvCount.Name = "lblSecs1RecvCount";
            this.lblSecs1RecvCount.Size = new System.Drawing.Size(117, 17);
            this.lblSecs1RecvCount.TabIndex = 42;
            this.lblSecs1RecvCount.Text = "0";
            this.lblSecs1RecvCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.Navy;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(674, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 41;
            this.label6.Text = "Sent";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(557, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Received";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1SentNak
            // 
            this.lblSecs1SentNak.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentNak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentNak.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentNak.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentNak.Location = new System.Drawing.Point(514, 38);
            this.lblSecs1SentNak.Name = "lblSecs1SentNak";
            this.lblSecs1SentNak.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1SentNak.TabIndex = 25;
            this.lblSecs1SentNak.Text = "NAK";
            this.lblSecs1SentNak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1RecvNak
            // 
            this.lblSecs1RecvNak.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvNak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvNak.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvNak.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvNak.Location = new System.Drawing.Point(273, 38);
            this.lblSecs1RecvNak.Name = "lblSecs1RecvNak";
            this.lblSecs1RecvNak.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1RecvNak.TabIndex = 19;
            this.lblSecs1RecvNak.Text = "NAK";
            this.lblSecs1RecvNak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1SentAck
            // 
            this.lblSecs1SentAck.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentAck.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentAck.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentAck.Location = new System.Drawing.Point(471, 38);
            this.lblSecs1SentAck.Name = "lblSecs1SentAck";
            this.lblSecs1SentAck.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1SentAck.TabIndex = 23;
            this.lblSecs1SentAck.Text = "ACK";
            this.lblSecs1SentAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1RecvAck
            // 
            this.lblSecs1RecvAck.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvAck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvAck.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvAck.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvAck.Location = new System.Drawing.Point(230, 38);
            this.lblSecs1RecvAck.Name = "lblSecs1RecvAck";
            this.lblSecs1RecvAck.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1RecvAck.TabIndex = 18;
            this.lblSecs1RecvAck.Text = "ACK";
            this.lblSecs1RecvAck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1SentBlock
            // 
            this.lblSecs1SentBlock.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentBlock.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentBlock.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentBlock.Location = new System.Drawing.Point(404, 38);
            this.lblSecs1SentBlock.Name = "lblSecs1SentBlock";
            this.lblSecs1SentBlock.Size = new System.Drawing.Size(66, 17);
            this.lblSecs1SentBlock.TabIndex = 24;
            this.lblSecs1SentBlock.Text = "BLOCK";
            this.lblSecs1SentBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1RecvBlock
            // 
            this.lblSecs1RecvBlock.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvBlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvBlock.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvBlock.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvBlock.Location = new System.Drawing.Point(162, 38);
            this.lblSecs1RecvBlock.Name = "lblSecs1RecvBlock";
            this.lblSecs1RecvBlock.Size = new System.Drawing.Size(66, 17);
            this.lblSecs1RecvBlock.TabIndex = 18;
            this.lblSecs1RecvBlock.Text = "BLOCK";
            this.lblSecs1RecvBlock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1SentEot
            // 
            this.lblSecs1SentEot.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentEot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentEot.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentEot.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentEot.Location = new System.Drawing.Point(360, 38);
            this.lblSecs1SentEot.Name = "lblSecs1SentEot";
            this.lblSecs1SentEot.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1SentEot.TabIndex = 22;
            this.lblSecs1SentEot.Text = "EOT";
            this.lblSecs1SentEot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1RecvEot
            // 
            this.lblSecs1RecvEot.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvEot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvEot.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvEot.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvEot.Location = new System.Drawing.Point(119, 38);
            this.lblSecs1RecvEot.Name = "lblSecs1RecvEot";
            this.lblSecs1RecvEot.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1RecvEot.TabIndex = 17;
            this.lblSecs1RecvEot.Text = "EOT";
            this.lblSecs1RecvEot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1SentEnq
            // 
            this.lblSecs1SentEnq.BackColor = System.Drawing.Color.Black;
            this.lblSecs1SentEnq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1SentEnq.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1SentEnq.ForeColor = System.Drawing.Color.White;
            this.lblSecs1SentEnq.Location = new System.Drawing.Point(316, 38);
            this.lblSecs1SentEnq.Name = "lblSecs1SentEnq";
            this.lblSecs1SentEnq.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1SentEnq.TabIndex = 21;
            this.lblSecs1SentEnq.Text = "ENQ";
            this.lblSecs1SentEnq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1RecvEnq
            // 
            this.lblSecs1RecvEnq.BackColor = System.Drawing.Color.Black;
            this.lblSecs1RecvEnq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1RecvEnq.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1RecvEnq.ForeColor = System.Drawing.Color.White;
            this.lblSecs1RecvEnq.Location = new System.Drawing.Point(75, 38);
            this.lblSecs1RecvEnq.Name = "lblSecs1RecvEnq";
            this.lblSecs1RecvEnq.Size = new System.Drawing.Size(42, 17);
            this.lblSecs1RecvEnq.TabIndex = 16;
            this.lblSecs1RecvEnq.Text = "ENQ";
            this.lblSecs1RecvEnq.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Navy;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(316, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(240, 17);
            this.label16.TabIndex = 20;
            this.label16.Text = "Send State";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Navy;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(75, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(240, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Receive State";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecs1State
            // 
            this.lblSecs1State.BackColor = System.Drawing.Color.White;
            this.lblSecs1State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecs1State.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecs1State.ForeColor = System.Drawing.Color.Black;
            this.lblSecs1State.Location = new System.Drawing.Point(6, 38);
            this.lblSecs1State.Name = "lblSecs1State";
            this.lblSecs1State.Size = new System.Drawing.Size(68, 17);
            this.lblSecs1State.TabIndex = 15;
            this.lblSecs1State.Text = "Closed";
            this.lblSecs1State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Navy;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "COMM.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblHsmsSentCount);
            this.groupBox2.Controls.Add(this.lblHsmsRecvCount);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblHsmsSent);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lblHsmsRecv);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblHsmsState);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Font = new System.Drawing.Font("New Gulim", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(5, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 62);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "HSMS Status";
            // 
            // lblHsmsSentCount
            // 
            this.lblHsmsSentCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHsmsSentCount.BackColor = System.Drawing.Color.Black;
            this.lblHsmsSentCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHsmsSentCount.Font = new System.Drawing.Font("New Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHsmsSentCount.ForeColor = System.Drawing.Color.White;
            this.lblHsmsSentCount.Location = new System.Drawing.Point(306, 38);
            this.lblHsmsSentCount.Name = "lblHsmsSentCount";
            this.lblHsmsSentCount.Size = new System.Drawing.Size(75, 17);
            this.lblHsmsSentCount.TabIndex = 44;
            this.lblHsmsSentCount.Text = "0";
            this.lblHsmsSentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHsmsRecvCount
            // 
            this.lblHsmsRecvCount.BackColor = System.Drawing.Color.Black;
            this.lblHsmsRecvCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHsmsRecvCount.Font = new System.Drawing.Font("New Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHsmsRecvCount.ForeColor = System.Drawing.Color.White;
            this.lblHsmsRecvCount.Location = new System.Drawing.Point(229, 38);
            this.lblHsmsRecvCount.Name = "lblHsmsRecvCount";
            this.lblHsmsRecvCount.Size = new System.Drawing.Size(75, 17);
            this.lblHsmsRecvCount.TabIndex = 43;
            this.lblHsmsRecvCount.Text = "0";
            this.lblHsmsRecvCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.Navy;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(306, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 17);
            this.label14.TabIndex = 39;
            this.label14.Text = "Sent";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Navy;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(229, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "Received";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHsmsSent
            // 
            this.lblHsmsSent.BackColor = System.Drawing.Color.Black;
            this.lblHsmsSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHsmsSent.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHsmsSent.ForeColor = System.Drawing.Color.White;
            this.lblHsmsSent.Location = new System.Drawing.Point(152, 38);
            this.lblHsmsSent.Name = "lblHsmsSent";
            this.lblHsmsSent.Size = new System.Drawing.Size(75, 17);
            this.lblHsmsSent.TabIndex = 27;
            this.lblHsmsSent.Text = "Sent";
            this.lblHsmsSent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Navy;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(152, 19);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 17);
            this.label20.TabIndex = 18;
            this.label20.Text = "Send State";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHsmsRecv
            // 
            this.lblHsmsRecv.BackColor = System.Drawing.Color.Black;
            this.lblHsmsRecv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHsmsRecv.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHsmsRecv.ForeColor = System.Drawing.Color.White;
            this.lblHsmsRecv.Location = new System.Drawing.Point(75, 38);
            this.lblHsmsRecv.Name = "lblHsmsRecv";
            this.lblHsmsRecv.Size = new System.Drawing.Size(75, 17);
            this.lblHsmsRecv.TabIndex = 26;
            this.lblHsmsRecv.Text = "Received";
            this.lblHsmsRecv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Navy;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(75, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(75, 17);
            this.label19.TabIndex = 17;
            this.label19.Text = "Receive State";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHsmsState
            // 
            this.lblHsmsState.BackColor = System.Drawing.Color.White;
            this.lblHsmsState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHsmsState.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHsmsState.ForeColor = System.Drawing.Color.Black;
            this.lblHsmsState.Location = new System.Drawing.Point(6, 38);
            this.lblHsmsState.Name = "lblHsmsState";
            this.lblHsmsState.Size = new System.Drawing.Size(68, 17);
            this.lblHsmsState.TabIndex = 17;
            this.lblHsmsState.Text = "Closed";
            this.lblHsmsState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Navy;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(6, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 17);
            this.label18.TabIndex = 16;
            this.label18.Text = "COMM.";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort1
            // 
            this.lblPort1.BackColor = System.Drawing.Color.Black;
            this.lblPort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPort1.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort1.ForeColor = System.Drawing.Color.White;
            this.lblPort1.Location = new System.Drawing.Point(1, 0);
            this.lblPort1.Name = "lblPort1";
            this.lblPort1.Size = new System.Drawing.Size(30, 25);
            this.lblPort1.TabIndex = 17;
            this.lblPort1.Text = "1";
            this.lblPort1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot1
            // 
            this.lblLot1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot1.BackColor = System.Drawing.Color.Black;
            this.lblLot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot1.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLot1.ForeColor = System.Drawing.Color.White;
            this.lblLot1.Location = new System.Drawing.Point(33, 0);
            this.lblLot1.Name = "lblLot1";
            this.lblLot1.Size = new System.Drawing.Size(168, 25);
            this.lblLot1.TabIndex = 18;
            this.lblLot1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot2
            // 
            this.lblLot2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot2.BackColor = System.Drawing.Color.Black;
            this.lblLot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot2.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLot2.ForeColor = System.Drawing.Color.White;
            this.lblLot2.Location = new System.Drawing.Point(33, 0);
            this.lblLot2.Name = "lblLot2";
            this.lblLot2.Size = new System.Drawing.Size(161, 25);
            this.lblLot2.TabIndex = 20;
            this.lblLot2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort2
            // 
            this.lblPort2.BackColor = System.Drawing.Color.Black;
            this.lblPort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPort2.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort2.ForeColor = System.Drawing.Color.White;
            this.lblPort2.Location = new System.Drawing.Point(1, 0);
            this.lblPort2.Name = "lblPort2";
            this.lblPort2.Size = new System.Drawing.Size(30, 25);
            this.lblPort2.TabIndex = 19;
            this.lblPort2.Text = "2";
            this.lblPort2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot3
            // 
            this.lblLot3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot3.BackColor = System.Drawing.Color.Black;
            this.lblLot3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot3.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLot3.ForeColor = System.Drawing.Color.White;
            this.lblLot3.Location = new System.Drawing.Point(35, 0);
            this.lblLot3.Name = "lblLot3";
            this.lblLot3.Size = new System.Drawing.Size(162, 25);
            this.lblLot3.TabIndex = 22;
            this.lblLot3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort3
            // 
            this.lblPort3.BackColor = System.Drawing.Color.Black;
            this.lblPort3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPort3.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort3.ForeColor = System.Drawing.Color.White;
            this.lblPort3.Location = new System.Drawing.Point(3, 0);
            this.lblPort3.Name = "lblPort3";
            this.lblPort3.Size = new System.Drawing.Size(30, 25);
            this.lblPort3.TabIndex = 21;
            this.lblPort3.Text = "3";
            this.lblPort3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLot4
            // 
            this.lblLot4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot4.BackColor = System.Drawing.Color.Black;
            this.lblLot4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLot4.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLot4.ForeColor = System.Drawing.Color.White;
            this.lblLot4.Location = new System.Drawing.Point(29, 0);
            this.lblLot4.Name = "lblLot4";
            this.lblLot4.Size = new System.Drawing.Size(159, 25);
            this.lblLot4.TabIndex = 24;
            this.lblLot4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPort4
            // 
            this.lblPort4.BackColor = System.Drawing.Color.Black;
            this.lblPort4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPort4.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPort4.ForeColor = System.Drawing.Color.White;
            this.lblPort4.Location = new System.Drawing.Point(1, 0);
            this.lblPort4.Name = "lblPort4";
            this.lblPort4.Size = new System.Drawing.Size(30, 25);
            this.lblPort4.TabIndex = 23;
            this.lblPort4.Text = "4";
            this.lblPort4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(-1, 269);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(801, 4);
            this.panel4.TabIndex = 25;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Font = new System.Drawing.Font("New Gulim", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(146, 177);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(654, 88);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Information";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMessage.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.Location = new System.Drawing.Point(6, 20);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(541, 63);
            this.lblMessage.TabIndex = 17;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnClear.Font = new System.Drawing.Font("New Gulim", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClear.Location = new System.Drawing.Point(563, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 71);
            this.btnClear.TabIndex = 38;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.Enter += new System.EventHandler(this.btnClear_Enter);
            // 
            // lblAsignLot1
            // 
            this.lblAsignLot1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignLot1.BackColor = System.Drawing.Color.White;
            this.lblAsignLot1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignLot1.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAsignLot1.ForeColor = System.Drawing.Color.Black;
            this.lblAsignLot1.Location = new System.Drawing.Point(1, 181);
            this.lblAsignLot1.Name = "lblAsignLot1";
            this.lblAsignLot1.Size = new System.Drawing.Size(196, 25);
            this.lblAsignLot1.TabIndex = 29;
            this.lblAsignLot1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAsignLot2
            // 
            this.lblAsignLot2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignLot2.BackColor = System.Drawing.Color.White;
            this.lblAsignLot2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignLot2.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAsignLot2.ForeColor = System.Drawing.Color.Black;
            this.lblAsignLot2.Location = new System.Drawing.Point(4, 181);
            this.lblAsignLot2.Name = "lblAsignLot2";
            this.lblAsignLot2.Size = new System.Drawing.Size(190, 25);
            this.lblAsignLot2.TabIndex = 30;
            this.lblAsignLot2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAsignLot3
            // 
            this.lblAsignLot3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignLot3.BackColor = System.Drawing.Color.White;
            this.lblAsignLot3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignLot3.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAsignLot3.ForeColor = System.Drawing.Color.Black;
            this.lblAsignLot3.Location = new System.Drawing.Point(0, 181);
            this.lblAsignLot3.Name = "lblAsignLot3";
            this.lblAsignLot3.Size = new System.Drawing.Size(193, 25);
            this.lblAsignLot3.TabIndex = 31;
            this.lblAsignLot3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAsignLot4
            // 
            this.lblAsignLot4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAsignLot4.BackColor = System.Drawing.Color.White;
            this.lblAsignLot4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAsignLot4.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAsignLot4.ForeColor = System.Drawing.Color.Black;
            this.lblAsignLot4.Location = new System.Drawing.Point(1, 180);
            this.lblAsignLot4.Name = "lblAsignLot4";
            this.lblAsignLot4.Size = new System.Drawing.Size(188, 25);
            this.lblAsignLot4.TabIndex = 32;
            this.lblAsignLot4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBcrRead
            // 
            this.txtBcrRead.BackColor = System.Drawing.Color.Black;
            this.txtBcrRead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBcrRead.Font = new System.Drawing.Font("New Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBcrRead.ForeColor = System.Drawing.Color.White;
            this.txtBcrRead.Location = new System.Drawing.Point(121, 276);
            this.txtBcrRead.Multiline = true;
            this.txtBcrRead.Name = "txtBcrRead";
            this.txtBcrRead.Size = new System.Drawing.Size(353, 23);
            this.txtBcrRead.TabIndex = 0;
            this.txtBcrRead.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBcrRead_KeyDown);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 50;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Navy;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("New Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 34;
            this.label2.Text = "BCR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOffline
            // 
            this.lblOffline.BackColor = System.Drawing.Color.White;
            this.lblOffline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOffline.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOffline.ForeColor = System.Drawing.Color.Black;
            this.lblOffline.Location = new System.Drawing.Point(8, 19);
            this.lblOffline.Name = "lblOffline";
            this.lblOffline.Size = new System.Drawing.Size(113, 20);
            this.lblOffline.TabIndex = 35;
            this.lblOffline.Text = "OFFLINE";
            this.lblOffline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLocal
            // 
            this.lblLocal.BackColor = System.Drawing.Color.White;
            this.lblLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLocal.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLocal.ForeColor = System.Drawing.Color.Black;
            this.lblLocal.Location = new System.Drawing.Point(8, 41);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(113, 20);
            this.lblLocal.TabIndex = 36;
            this.lblLocal.Text = "LOCAL";
            this.lblLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRemote
            // 
            this.lblRemote.BackColor = System.Drawing.Color.White;
            this.lblRemote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemote.Font = new System.Drawing.Font("New Gulim", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemote.ForeColor = System.Drawing.Color.Black;
            this.lblRemote.Location = new System.Drawing.Point(8, 63);
            this.lblRemote.Name = "lblRemote";
            this.lblRemote.Size = new System.Drawing.Size(113, 20);
            this.lblRemote.TabIndex = 37;
            this.lblRemote.Text = "REMOTE";
            this.lblRemote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMin
            // 
            this.btnMin.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnMin.Font = new System.Drawing.Font("New Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMin.Location = new System.Drawing.Point(2, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(18, 18);
            this.btnMin.TabIndex = 39;
            this.btnMin.TabStop = false;
            this.btnMin.Text = "M";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            this.btnMin.Enter += new System.EventHandler(this.btnMin_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lblOffline);
            this.groupBox4.Controls.Add(this.lblLocal);
            this.groupBox4.Controls.Add(this.lblRemote);
            this.groupBox4.Font = new System.Drawing.Font("New Gulim", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox4.Location = new System.Drawing.Point(5, 177);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(135, 88);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Control Mode";
            // 
            // btnTerminalMessage
            // 
            this.btnTerminalMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTerminalMessage.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnTerminalMessage.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTerminalMessage.Location = new System.Drawing.Point(111, 518);
            this.btnTerminalMessage.Name = "btnTerminalMessage";
            this.btnTerminalMessage.Size = new System.Drawing.Size(110, 80);
            this.btnTerminalMessage.TabIndex = 42;
            this.btnTerminalMessage.TabStop = false;
            this.btnTerminalMessage.Text = "Terminal Message";
            this.btnTerminalMessage.UseVisualStyleBackColor = true;
            this.btnTerminalMessage.Click += new System.EventHandler(this.btnTerminalMessage_Click);
            this.btnTerminalMessage.Enter += new System.EventHandler(this.btnTerminalMessage_Enter);
            // 
            // btnPreviousMessage
            // 
            this.btnPreviousMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPreviousMessage.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnPreviousMessage.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPreviousMessage.Location = new System.Drawing.Point(221, 518);
            this.btnPreviousMessage.Name = "btnPreviousMessage";
            this.btnPreviousMessage.Size = new System.Drawing.Size(110, 80);
            this.btnPreviousMessage.TabIndex = 43;
            this.btnPreviousMessage.TabStop = false;
            this.btnPreviousMessage.Text = "Previous Message";
            this.btnPreviousMessage.UseVisualStyleBackColor = true;
            this.btnPreviousMessage.Visible = false;
            this.btnPreviousMessage.Click += new System.EventHandler(this.btnPreviousMessage_Click);
            this.btnPreviousMessage.Enter += new System.EventHandler(this.btnPreviousMessage_Enter);
            // 
            // btnNextMessage
            // 
            this.btnNextMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNextMessage.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Button;
            this.btnNextMessage.Font = new System.Drawing.Font("New Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNextMessage.Location = new System.Drawing.Point(331, 518);
            this.btnNextMessage.Name = "btnNextMessage";
            this.btnNextMessage.Size = new System.Drawing.Size(110, 80);
            this.btnNextMessage.TabIndex = 44;
            this.btnNextMessage.TabStop = false;
            this.btnNextMessage.Text = "Next Message";
            this.btnNextMessage.UseVisualStyleBackColor = true;
            this.btnNextMessage.Visible = false;
            this.btnNextMessage.Click += new System.EventHandler(this.btnNextMessage_Click);
            this.btnNextMessage.Enter += new System.EventHandler(this.btnNextMessage_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Location = new System.Drawing.Point(1, 302);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(796, 209);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 45;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblPort1);
            this.splitContainer2.Panel1.Controls.Add(this.picPort1);
            this.splitContainer2.Panel1.Controls.Add(this.lblLot1);
            this.splitContainer2.Panel1.Controls.Add(this.lblAsignLot1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblPort2);
            this.splitContainer2.Panel2.Controls.Add(this.picPort2);
            this.splitContainer2.Panel2.Controls.Add(this.lblLot2);
            this.splitContainer2.Panel2.Controls.Add(this.lblAsignLot2);
            this.splitContainer2.Size = new System.Drawing.Size(398, 209);
            this.splitContainer2.SplitterDistance = 199;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblPort3);
            this.splitContainer3.Panel1.Controls.Add(this.picPort3);
            this.splitContainer3.Panel1.Controls.Add(this.lblLot3);
            this.splitContainer3.Panel1.Controls.Add(this.lblAsignLot3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Panel2.Controls.Add(this.lblPort4);
            this.splitContainer3.Panel2.Controls.Add(this.picPort4);
            this.splitContainer3.Panel2.Controls.Add(this.lblLot4);
            this.splitContainer3.Panel2.Controls.Add(this.lblAsignLot4);
            this.splitContainer3.Size = new System.Drawing.Size(394, 209);
            this.splitContainer3.SplitterDistance = 198;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer4.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer4.Location = new System.Drawing.Point(0, 104);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer4.Size = new System.Drawing.Size(800, 66);
            this.splitContainer4.SplitterDistance = 396;
            this.splitContainer4.TabIndex = 46;
            // 
            // FMainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Nexplant.MC.Counter.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnNextMessage);
            this.Controls.Add(this.btnPreviousMessage);
            this.Controls.Add(this.btnTerminalMessage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBcrRead);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblVer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnExit);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FMainContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "V";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FMainContainer_FormClosing);
            this.Load += new System.EventHandler(this.FMainContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPort1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPort4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picPort1;
        private System.Windows.Forms.PictureBox picPort2;
        private System.Windows.Forms.PictureBox picPort3;
        private System.Windows.Forms.PictureBox picPort4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSecs1SentNak;
        private System.Windows.Forms.Label lblSecs1RecvNak;
        private System.Windows.Forms.Label lblSecs1SentAck;
        private System.Windows.Forms.Label lblSecs1RecvAck;
        private System.Windows.Forms.Label lblSecs1SentBlock;
        private System.Windows.Forms.Label lblSecs1RecvBlock;
        private System.Windows.Forms.Label lblSecs1SentEot;
        private System.Windows.Forms.Label lblSecs1RecvEot;
        private System.Windows.Forms.Label lblSecs1SentEnq;
        private System.Windows.Forms.Label lblSecs1RecvEnq;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSecs1State;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblHsmsSent;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblHsmsRecv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblHsmsState;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblPort1;
        private System.Windows.Forms.Label lblLot1;
        private System.Windows.Forms.Label lblLot2;
        private System.Windows.Forms.Label lblPort2;
        private System.Windows.Forms.Label lblLot3;
        private System.Windows.Forms.Label lblPort3;
        private System.Windows.Forms.Label lblLot4;
        private System.Windows.Forms.Label lblPort4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAsignLot1;
        private System.Windows.Forms.Label lblAsignLot2;
        private System.Windows.Forms.Label lblAsignLot3;
        private System.Windows.Forms.Label lblAsignLot4;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtBcrRead;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOffline;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblRemote;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblSecs1SentCount;
        private System.Windows.Forms.Label lblSecs1RecvCount;
        private System.Windows.Forms.Label lblHsmsSentCount;
        private System.Windows.Forms.Label lblHsmsRecvCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnTerminalMessage;
        private System.Windows.Forms.Button btnPreviousMessage;
        private System.Windows.Forms.Button btnNextMessage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}

