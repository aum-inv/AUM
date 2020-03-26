namespace OM.PP.XingApp
{
    partial class XingAppForm
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
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XingAppForm));
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbLogin = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdo500 = new System.Windows.Forms.RadioButton();
            this.rdo200 = new System.Windows.Forms.RadioButton();
            this.rdo100 = new System.Windows.Forms.RadioButton();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkRealES = new System.Windows.Forms.CheckBox();
            this.chkSendRealtime = new System.Windows.Forms.CheckBox();
            this.chkRealURO = new System.Windows.Forms.CheckBox();
            this.chkRealNQ = new System.Windows.Forms.CheckBox();
            this.chkRealHSI = new System.Windows.Forms.CheckBox();
            this.chkRealSI = new System.Windows.Forms.CheckBox();
            this.chkRealGC = new System.Windows.Forms.CheckBox();
            this.chkRealNG = new System.Windows.Forms.CheckBox();
            this.chkRealCL = new System.Windows.Forms.CheckBox();
            this.btnReal = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button32 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(17, 32);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 20);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbLogin);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.lblLogin);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnLogin);
            this.groupBox3.Location = new System.Drawing.Point(3, 5);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(278, 57);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "연결";
            // 
            // cbLogin
            // 
            this.cbLogin.FormattingEnabled = true;
            this.cbLogin.Items.AddRange(new object[] {
            "LEE",
            "SON",
            "JIN",
            "JUNG"});
            this.cbLogin.Location = new System.Drawing.Point(17, 12);
            this.cbLogin.Name = "cbLogin";
            this.cbLogin.Size = new System.Drawing.Size(80, 20);
            this.cbLogin.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(200, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 37);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(114, 32);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(73, 20);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "           ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "로그인여부 :";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.groupBox4);
            this.pnlContent.Controls.Add(this.groupBox5);
            this.pnlContent.Controls.Add(this.groupBox1);
            this.pnlContent.Controls.Add(this.groupBox7);
            this.pnlContent.Controls.Add(this.groupBox3);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(2, 2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(464, 385);
            this.pnlContent.TabIndex = 12;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdo500);
            this.groupBox5.Controls.Add(this.rdo200);
            this.groupBox5.Controls.Add(this.rdo100);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Controls.Add(this.button25);
            this.groupBox5.Controls.Add(this.panel2);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(3, 66);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(278, 164);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "해외선물";
            // 
            // rdo500
            // 
            this.rdo500.AutoSize = true;
            this.rdo500.Location = new System.Drawing.Point(231, 53);
            this.rdo500.Name = "rdo500";
            this.rdo500.Size = new System.Drawing.Size(41, 16);
            this.rdo500.TabIndex = 43;
            this.rdo500.Text = "500";
            this.rdo500.UseVisualStyleBackColor = true;
            // 
            // rdo200
            // 
            this.rdo200.AutoSize = true;
            this.rdo200.Location = new System.Drawing.Point(231, 35);
            this.rdo200.Name = "rdo200";
            this.rdo200.Size = new System.Drawing.Size(41, 16);
            this.rdo200.TabIndex = 42;
            this.rdo200.Text = "200";
            this.rdo200.UseVisualStyleBackColor = true;
            // 
            // rdo100
            // 
            this.rdo100.AutoSize = true;
            this.rdo100.Checked = true;
            this.rdo100.Location = new System.Drawing.Point(231, 17);
            this.rdo100.Name = "rdo100";
            this.rdo100.Size = new System.Drawing.Size(41, 16);
            this.rdo100.TabIndex = 41;
            this.rdo100.TabStop = true;
            this.rdo100.Text = "100";
            this.rdo100.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(180, 46);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 27);
            this.button9.TabIndex = 40;
            this.button9.Text = "ES";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button15);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.button11);
            this.groupBox2.Controls.Add(this.button12);
            this.groupBox2.Controls.Add(this.button13);
            this.groupBox2.Controls.Add(this.button14);
            this.groupBox2.Location = new System.Drawing.Point(0, 85);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(278, 85);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "해외선물 틱시세";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(180, 50);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(50, 27);
            this.button15.TabIndex = 40;
            this.button15.Text = "ES";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(181, 17);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 27);
            this.button7.TabIndex = 39;
            this.button7.Text = "URO";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(126, 50);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 27);
            this.button8.TabIndex = 6;
            this.button8.Text = "NQ";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(72, 50);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 27);
            this.button10.TabIndex = 5;
            this.button10.Text = "HMH";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(17, 50);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 27);
            this.button11.TabIndex = 4;
            this.button11.Text = "SI";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(126, 17);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(50, 27);
            this.button12.TabIndex = 3;
            this.button12.Text = "GC";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(72, 17);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(50, 27);
            this.button13.TabIndex = 2;
            this.button13.Text = "NG";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(17, 16);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(50, 27);
            this.button14.TabIndex = 1;
            this.button14.Text = "CL";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.btnFFTick_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(180, 17);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(50, 27);
            this.button25.TabIndex = 39;
            this.button25.Text = "URO";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(8, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 2);
            this.panel2.TabIndex = 22;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 46);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(50, 27);
            this.button4.TabIndex = 6;
            this.button4.Text = "NQ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(72, 46);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 27);
            this.button5.TabIndex = 5;
            this.button5.Text = "HMH";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(17, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 27);
            this.button6.TabIndex = 4;
            this.button6.Text = "SI";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "GC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(72, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 27);
            this.button2.TabIndex = 2;
            this.button2.Text = "NG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 27);
            this.button3.TabIndex = 1;
            this.button3.Text = "CL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLog);
            this.groupBox1.Location = new System.Drawing.Point(287, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(9);
            this.groupBox1.Size = new System.Drawing.Size(174, 318);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.ForeColor = System.Drawing.Color.White;
            this.tbLog.Location = new System.Drawing.Point(9, 23);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(156, 286);
            this.tbLog.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkRealES);
            this.groupBox7.Controls.Add(this.chkSendRealtime);
            this.groupBox7.Controls.Add(this.chkRealURO);
            this.groupBox7.Controls.Add(this.chkRealNQ);
            this.groupBox7.Controls.Add(this.chkRealHSI);
            this.groupBox7.Controls.Add(this.chkRealSI);
            this.groupBox7.Controls.Add(this.chkRealGC);
            this.groupBox7.Controls.Add(this.chkRealNG);
            this.groupBox7.Controls.Add(this.chkRealCL);
            this.groupBox7.Controls.Add(this.btnReal);
            this.groupBox7.Location = new System.Drawing.Point(3, 249);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(278, 74);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "실시간 시세받기";
            // 
            // chkRealES
            // 
            this.chkRealES.AutoSize = true;
            this.chkRealES.Location = new System.Drawing.Point(137, 42);
            this.chkRealES.Name = "chkRealES";
            this.chkRealES.Size = new System.Drawing.Size(40, 16);
            this.chkRealES.TabIndex = 43;
            this.chkRealES.Text = "ES";
            this.chkRealES.UseVisualStyleBackColor = true;
            this.chkRealES.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkSendRealtime
            // 
            this.chkSendRealtime.AutoSize = true;
            this.chkSendRealtime.Checked = true;
            this.chkSendRealtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendRealtime.Location = new System.Drawing.Point(196, 15);
            this.chkSendRealtime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkSendRealtime.Name = "chkSendRealtime";
            this.chkSendRealtime.Size = new System.Drawing.Size(48, 16);
            this.chkSendRealtime.TabIndex = 42;
            this.chkSendRealtime.Text = "전송";
            this.chkSendRealtime.UseVisualStyleBackColor = true;
            this.chkSendRealtime.CheckedChanged += new System.EventHandler(this.chkSendRealtime_CheckedChanged);
            // 
            // chkRealURO
            // 
            this.chkRealURO.AutoSize = true;
            this.chkRealURO.Location = new System.Drawing.Point(137, 16);
            this.chkRealURO.Name = "chkRealURO";
            this.chkRealURO.Size = new System.Drawing.Size(49, 16);
            this.chkRealURO.TabIndex = 41;
            this.chkRealURO.Text = "URO";
            this.chkRealURO.UseVisualStyleBackColor = true;
            this.chkRealURO.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealNQ
            // 
            this.chkRealNQ.AutoSize = true;
            this.chkRealNQ.Location = new System.Drawing.Point(93, 42);
            this.chkRealNQ.Name = "chkRealNQ";
            this.chkRealNQ.Size = new System.Drawing.Size(42, 16);
            this.chkRealNQ.TabIndex = 26;
            this.chkRealNQ.Text = "NQ";
            this.chkRealNQ.UseVisualStyleBackColor = true;
            this.chkRealNQ.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealHSI
            // 
            this.chkRealHSI.AutoSize = true;
            this.chkRealHSI.Location = new System.Drawing.Point(43, 42);
            this.chkRealHSI.Name = "chkRealHSI";
            this.chkRealHSI.Size = new System.Drawing.Size(51, 16);
            this.chkRealHSI.TabIndex = 25;
            this.chkRealHSI.Text = "HMH";
            this.chkRealHSI.UseVisualStyleBackColor = true;
            this.chkRealHSI.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealSI
            // 
            this.chkRealSI.AutoSize = true;
            this.chkRealSI.Location = new System.Drawing.Point(5, 42);
            this.chkRealSI.Name = "chkRealSI";
            this.chkRealSI.Size = new System.Drawing.Size(35, 16);
            this.chkRealSI.TabIndex = 24;
            this.chkRealSI.Text = "SI";
            this.chkRealSI.UseVisualStyleBackColor = true;
            this.chkRealSI.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealGC
            // 
            this.chkRealGC.AutoSize = true;
            this.chkRealGC.Location = new System.Drawing.Point(93, 16);
            this.chkRealGC.Name = "chkRealGC";
            this.chkRealGC.Size = new System.Drawing.Size(42, 16);
            this.chkRealGC.TabIndex = 23;
            this.chkRealGC.Text = "GC";
            this.chkRealGC.UseVisualStyleBackColor = true;
            this.chkRealGC.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealNG
            // 
            this.chkRealNG.AutoSize = true;
            this.chkRealNG.Location = new System.Drawing.Point(43, 16);
            this.chkRealNG.Name = "chkRealNG";
            this.chkRealNG.Size = new System.Drawing.Size(42, 16);
            this.chkRealNG.TabIndex = 22;
            this.chkRealNG.Text = "NG";
            this.chkRealNG.UseVisualStyleBackColor = true;
            this.chkRealNG.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealCL
            // 
            this.chkRealCL.AutoSize = true;
            this.chkRealCL.Location = new System.Drawing.Point(5, 16);
            this.chkRealCL.Name = "chkRealCL";
            this.chkRealCL.Size = new System.Drawing.Size(40, 16);
            this.chkRealCL.TabIndex = 21;
            this.chkRealCL.Text = "CL";
            this.chkRealCL.UseVisualStyleBackColor = true;
            this.chkRealCL.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // btnReal
            // 
            this.btnReal.Location = new System.Drawing.Point(193, 36);
            this.btnReal.Name = "btnReal";
            this.btnReal.Size = new System.Drawing.Size(75, 27);
            this.btnReal.TabIndex = 20;
            this.btnReal.Text = "시작";
            this.btnReal.UseVisualStyleBackColor = true;
            this.btnReal.Click += new System.EventHandler(this.btnReal_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // noti
            // 
            this.noti.Visible = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button32);
            this.groupBox4.Location = new System.Drawing.Point(6, 331);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(455, 50);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CSV 파일로 시세 받기";
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(17, 16);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(88, 27);
            this.button32.TabIndex = 1;
            this.button32.Tag = "cl";
            this.button32.Text = "CL 시세";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // XingAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(468, 389);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XingAppForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "OM.PP ::: Xing 시세";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnReal;
        private System.Windows.Forms.CheckBox chkRealCL;
        private System.Windows.Forms.CheckBox chkRealGC;
        private System.Windows.Forms.CheckBox chkRealNG;
        private System.Windows.Forms.CheckBox chkRealNQ;
        private System.Windows.Forms.CheckBox chkRealHSI;
        private System.Windows.Forms.CheckBox chkRealSI;
        private System.Windows.Forms.ComboBox cbLogin;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.CheckBox chkRealURO;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon noti;
        private System.Windows.Forms.CheckBox chkSendRealtime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.CheckBox chkRealES;
        private System.Windows.Forms.RadioButton rdo100;
        private System.Windows.Forms.RadioButton rdo500;
        private System.Windows.Forms.RadioButton rdo200;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button32;
    }
}

