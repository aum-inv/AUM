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
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkSendRealtimeKr = new System.Windows.Forms.CheckBox();
            this.chkRealKosdaq = new System.Windows.Forms.CheckBox();
            this.chkRealKospi200 = new System.Windows.Forms.CheckBox();
            this.chkRealKospi = new System.Windows.Forms.CheckBox();
            this.btnRealKr = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkKospi = new System.Windows.Forms.CheckBox();
            this.chkKosdaq = new System.Windows.Forms.CheckBox();
            this.button20 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rdo500 = new System.Windows.Forms.RadioButton();
            this.rdo200 = new System.Windows.Forms.RadioButton();
            this.rdo100 = new System.Windows.Forms.RadioButton();
            this.button9 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(24, 48);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(114, 30);
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
            this.groupBox3.Location = new System.Drawing.Point(4, 8);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox3.Size = new System.Drawing.Size(397, 86);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "연결";
            // 
            // cbLogin
            // 
            this.cbLogin.FormattingEnabled = true;
            this.cbLogin.Items.AddRange(new object[] {
            "ATMAN"});
            this.cbLogin.Location = new System.Drawing.Point(24, 18);
            this.cbLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLogin.Name = "cbLogin";
            this.cbLogin.Size = new System.Drawing.Size(113, 26);
            this.cbLogin.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(286, 21);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 56);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.BackColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(163, 48);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(104, 30);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "           ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(163, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "로그인여부 :";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.groupBox8);
            this.pnlContent.Controls.Add(this.groupBox6);
            this.pnlContent.Controls.Add(this.groupBox2);
            this.pnlContent.Controls.Add(this.groupBox4);
            this.pnlContent.Controls.Add(this.groupBox5);
            this.pnlContent.Controls.Add(this.groupBox1);
            this.pnlContent.Controls.Add(this.groupBox7);
            this.pnlContent.Controls.Add(this.groupBox3);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(3, 3);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(910, 855);
            this.pnlContent.TabIndex = 12;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkSendRealtimeKr);
            this.groupBox6.Controls.Add(this.chkRealKosdaq);
            this.groupBox6.Controls.Add(this.chkRealKospi200);
            this.groupBox6.Controls.Add(this.chkRealKospi);
            this.groupBox6.Controls.Add(this.btnRealKr);
            this.groupBox6.Location = new System.Drawing.Point(4, 524);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox6.Size = new System.Drawing.Size(397, 112);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "국내지수 실시간 시세받기";
            // 
            // chkSendRealtimeKr
            // 
            this.chkSendRealtimeKr.AutoSize = true;
            this.chkSendRealtimeKr.Checked = true;
            this.chkSendRealtimeKr.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendRealtimeKr.Location = new System.Drawing.Point(287, 28);
            this.chkSendRealtimeKr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkSendRealtimeKr.Name = "chkSendRealtimeKr";
            this.chkSendRealtimeKr.Size = new System.Drawing.Size(70, 22);
            this.chkSendRealtimeKr.TabIndex = 42;
            this.chkSendRealtimeKr.Text = "전송";
            this.chkSendRealtimeKr.UseVisualStyleBackColor = true;
            this.chkSendRealtimeKr.CheckedChanged += new System.EventHandler(this.chkSendRealtimeKr_CheckedChanged);
            // 
            // chkRealKosdaq
            // 
            this.chkRealKosdaq.AutoSize = true;
            this.chkRealKosdaq.Location = new System.Drawing.Point(140, 69);
            this.chkRealKosdaq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealKosdaq.Name = "chkRealKosdaq";
            this.chkRealKosdaq.Size = new System.Drawing.Size(105, 22);
            this.chkRealKosdaq.TabIndex = 23;
            this.chkRealKosdaq.Text = "KOSDAQ";
            this.chkRealKosdaq.UseVisualStyleBackColor = true;
            // 
            // chkRealKospi200
            // 
            this.chkRealKospi200.AutoSize = true;
            this.chkRealKospi200.Location = new System.Drawing.Point(13, 69);
            this.chkRealKospi200.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealKospi200.Name = "chkRealKospi200";
            this.chkRealKospi200.Size = new System.Drawing.Size(113, 22);
            this.chkRealKospi200.TabIndex = 22;
            this.chkRealKospi200.Text = "KOSPI200";
            this.chkRealKospi200.UseVisualStyleBackColor = true;
            // 
            // chkRealKospi
            // 
            this.chkRealKospi.AutoSize = true;
            this.chkRealKospi.Location = new System.Drawing.Point(13, 32);
            this.chkRealKospi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealKospi.Name = "chkRealKospi";
            this.chkRealKospi.Size = new System.Drawing.Size(83, 22);
            this.chkRealKospi.TabIndex = 21;
            this.chkRealKospi.Text = "KOSPI";
            this.chkRealKospi.UseVisualStyleBackColor = true;
            // 
            // btnRealKr
            // 
            this.btnRealKr.Location = new System.Drawing.Point(283, 60);
            this.btnRealKr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRealKr.Name = "btnRealKr";
            this.btnRealKr.Size = new System.Drawing.Size(107, 40);
            this.btnRealKr.TabIndex = 20;
            this.btnRealKr.Text = "시작";
            this.btnRealKr.UseVisualStyleBackColor = true;
            this.btnRealKr.Click += new System.EventHandler(this.btnRealKr_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkKospi);
            this.groupBox2.Controls.Add(this.chkKosdaq);
            this.groupBox2.Controls.Add(this.button20);
            this.groupBox2.Controls.Add(this.button23);
            this.groupBox2.Location = new System.Drawing.Point(4, 648);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox2.Size = new System.Drawing.Size(397, 102);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "국내업종";
            // 
            // chkKospi
            // 
            this.chkKospi.AutoSize = true;
            this.chkKospi.Location = new System.Drawing.Point(19, 54);
            this.chkKospi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkKospi.Name = "chkKospi";
            this.chkKospi.Size = new System.Drawing.Size(22, 21);
            this.chkKospi.TabIndex = 25;
            this.chkKospi.Tag = "KOSPI";
            this.chkKospi.UseVisualStyleBackColor = true;
            this.chkKospi.CheckedChanged += new System.EventHandler(this.chkAutoKr_Changed);
            // 
            // chkKosdaq
            // 
            this.chkKosdaq.AutoSize = true;
            this.chkKosdaq.Location = new System.Drawing.Point(224, 54);
            this.chkKosdaq.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkKosdaq.Name = "chkKosdaq";
            this.chkKosdaq.Size = new System.Drawing.Size(22, 21);
            this.chkKosdaq.TabIndex = 24;
            this.chkKosdaq.Tag = "KOSDAQ";
            this.chkKosdaq.UseVisualStyleBackColor = true;
            this.chkKosdaq.CheckedChanged += new System.EventHandler(this.chkAutoKr_Changed);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(259, 45);
            this.button20.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(130, 40);
            this.button20.TabIndex = 4;
            this.button20.Tag = "301";
            this.button20.Text = "KOSDAQ";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.btnUpjong_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(49, 45);
            this.button23.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(131, 40);
            this.button23.TabIndex = 1;
            this.button23.Tag = "101";
            this.button23.Text = "KOSPI";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.btnUpjong_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button11);
            this.groupBox4.Controls.Add(this.button12);
            this.groupBox4.Controls.Add(this.button13);
            this.groupBox4.Controls.Add(this.button14);
            this.groupBox4.Controls.Add(this.button15);
            this.groupBox4.Location = new System.Drawing.Point(9, 352);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox4.Size = new System.Drawing.Size(393, 138);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CSV 파일로 시세 받기";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(254, 78);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(71, 40);
            this.button7.TabIndex = 48;
            this.button7.Text = "ES";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(254, 34);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(71, 40);
            this.button8.TabIndex = 47;
            this.button8.Text = "URO";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(177, 78);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(71, 40);
            this.button10.TabIndex = 46;
            this.button10.Text = "NQ";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(100, 78);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(71, 40);
            this.button11.TabIndex = 45;
            this.button11.Text = "HMH";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(21, 76);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(71, 40);
            this.button12.TabIndex = 44;
            this.button12.Text = "SI";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(177, 34);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(71, 40);
            this.button13.TabIndex = 43;
            this.button13.Text = "GC";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(100, 34);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(71, 40);
            this.button14.TabIndex = 42;
            this.button14.Text = "NG";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(21, 33);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(71, 40);
            this.button15.TabIndex = 41;
            this.button15.Text = "CL";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rdo500);
            this.groupBox5.Controls.Add(this.rdo200);
            this.groupBox5.Controls.Add(this.rdo100);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button25);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(4, 222);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox5.Size = new System.Drawing.Size(397, 129);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "해외선물";
            // 
            // rdo500
            // 
            this.rdo500.AutoSize = true;
            this.rdo500.Location = new System.Drawing.Point(330, 80);
            this.rdo500.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo500.Name = "rdo500";
            this.rdo500.Size = new System.Drawing.Size(63, 22);
            this.rdo500.TabIndex = 43;
            this.rdo500.Text = "500";
            this.rdo500.UseVisualStyleBackColor = true;
            // 
            // rdo200
            // 
            this.rdo200.AutoSize = true;
            this.rdo200.Location = new System.Drawing.Point(330, 52);
            this.rdo200.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo200.Name = "rdo200";
            this.rdo200.Size = new System.Drawing.Size(63, 22);
            this.rdo200.TabIndex = 42;
            this.rdo200.Text = "200";
            this.rdo200.UseVisualStyleBackColor = true;
            // 
            // rdo100
            // 
            this.rdo100.AutoSize = true;
            this.rdo100.Checked = true;
            this.rdo100.Location = new System.Drawing.Point(330, 26);
            this.rdo100.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdo100.Name = "rdo100";
            this.rdo100.Size = new System.Drawing.Size(63, 22);
            this.rdo100.TabIndex = 41;
            this.rdo100.TabStop = true;
            this.rdo100.Text = "100";
            this.rdo100.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(257, 69);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(71, 40);
            this.button9.TabIndex = 40;
            this.button9.Text = "ES";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(257, 26);
            this.button25.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(71, 40);
            this.button25.TabIndex = 39;
            this.button25.Text = "URO";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(180, 69);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 40);
            this.button4.TabIndex = 6;
            this.button4.Text = "NQ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(103, 69);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 40);
            this.button5.TabIndex = 5;
            this.button5.Text = "HMH";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(24, 68);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(71, 40);
            this.button6.TabIndex = 4;
            this.button6.Text = "SI";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "GC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(103, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "NG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(24, 24);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 40);
            this.button3.TabIndex = 1;
            this.button3.Text = "CL";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLog);
            this.groupBox1.Location = new System.Drawing.Point(410, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(13, 14, 13, 14);
            this.groupBox1.Size = new System.Drawing.Size(497, 750);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.ForeColor = System.Drawing.Color.White;
            this.tbLog.Location = new System.Drawing.Point(13, 35);
            this.tbLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(471, 701);
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
            this.groupBox7.Location = new System.Drawing.Point(4, 105);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox7.Size = new System.Drawing.Size(397, 112);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "실시간 시세받기";
            // 
            // chkRealES
            // 
            this.chkRealES.AutoSize = true;
            this.chkRealES.Location = new System.Drawing.Point(203, 69);
            this.chkRealES.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealES.Name = "chkRealES";
            this.chkRealES.Size = new System.Drawing.Size(56, 22);
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
            this.chkSendRealtime.Location = new System.Drawing.Point(287, 28);
            this.chkSendRealtime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkSendRealtime.Name = "chkSendRealtime";
            this.chkSendRealtime.Size = new System.Drawing.Size(70, 22);
            this.chkSendRealtime.TabIndex = 42;
            this.chkSendRealtime.Text = "전송";
            this.chkSendRealtime.UseVisualStyleBackColor = true;
            this.chkSendRealtime.CheckedChanged += new System.EventHandler(this.chkSendRealtime_CheckedChanged);
            // 
            // chkRealURO
            // 
            this.chkRealURO.AutoSize = true;
            this.chkRealURO.Location = new System.Drawing.Point(203, 30);
            this.chkRealURO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealURO.Name = "chkRealURO";
            this.chkRealURO.Size = new System.Drawing.Size(69, 22);
            this.chkRealURO.TabIndex = 41;
            this.chkRealURO.Text = "URO";
            this.chkRealURO.UseVisualStyleBackColor = true;
            this.chkRealURO.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealNQ
            // 
            this.chkRealNQ.AutoSize = true;
            this.chkRealNQ.Location = new System.Drawing.Point(140, 69);
            this.chkRealNQ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealNQ.Name = "chkRealNQ";
            this.chkRealNQ.Size = new System.Drawing.Size(59, 22);
            this.chkRealNQ.TabIndex = 26;
            this.chkRealNQ.Text = "NQ";
            this.chkRealNQ.UseVisualStyleBackColor = true;
            this.chkRealNQ.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealHSI
            // 
            this.chkRealHSI.AutoSize = true;
            this.chkRealHSI.Location = new System.Drawing.Point(69, 69);
            this.chkRealHSI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealHSI.Name = "chkRealHSI";
            this.chkRealHSI.Size = new System.Drawing.Size(71, 22);
            this.chkRealHSI.TabIndex = 25;
            this.chkRealHSI.Text = "HMH";
            this.chkRealHSI.UseVisualStyleBackColor = true;
            this.chkRealHSI.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealSI
            // 
            this.chkRealSI.AutoSize = true;
            this.chkRealSI.Location = new System.Drawing.Point(14, 69);
            this.chkRealSI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealSI.Name = "chkRealSI";
            this.chkRealSI.Size = new System.Drawing.Size(48, 22);
            this.chkRealSI.TabIndex = 24;
            this.chkRealSI.Text = "SI";
            this.chkRealSI.UseVisualStyleBackColor = true;
            this.chkRealSI.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealGC
            // 
            this.chkRealGC.AutoSize = true;
            this.chkRealGC.Location = new System.Drawing.Point(140, 30);
            this.chkRealGC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealGC.Name = "chkRealGC";
            this.chkRealGC.Size = new System.Drawing.Size(58, 22);
            this.chkRealGC.TabIndex = 23;
            this.chkRealGC.Text = "GC";
            this.chkRealGC.UseVisualStyleBackColor = true;
            this.chkRealGC.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealNG
            // 
            this.chkRealNG.AutoSize = true;
            this.chkRealNG.Location = new System.Drawing.Point(69, 30);
            this.chkRealNG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealNG.Name = "chkRealNG";
            this.chkRealNG.Size = new System.Drawing.Size(58, 22);
            this.chkRealNG.TabIndex = 22;
            this.chkRealNG.Text = "NG";
            this.chkRealNG.UseVisualStyleBackColor = true;
            this.chkRealNG.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // chkRealCL
            // 
            this.chkRealCL.AutoSize = true;
            this.chkRealCL.Location = new System.Drawing.Point(14, 30);
            this.chkRealCL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRealCL.Name = "chkRealCL";
            this.chkRealCL.Size = new System.Drawing.Size(55, 22);
            this.chkRealCL.TabIndex = 21;
            this.chkRealCL.Text = "CL";
            this.chkRealCL.UseVisualStyleBackColor = true;
            this.chkRealCL.CheckedChanged += new System.EventHandler(this.chkAuto_Changed);
            // 
            // btnReal
            // 
            this.btnReal.Location = new System.Drawing.Point(283, 60);
            this.btnReal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReal.Name = "btnReal";
            this.btnReal.Size = new System.Drawing.Size(107, 40);
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
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button21);
            this.groupBox8.Controls.Add(this.button22);
            this.groupBox8.Controls.Add(this.button18);
            this.groupBox8.Controls.Add(this.button19);
            this.groupBox8.Controls.Add(this.button16);
            this.groupBox8.Controls.Add(this.button17);
            this.groupBox8.Location = new System.Drawing.Point(5, 772);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBox8.Size = new System.Drawing.Size(905, 84);
            this.groupBox8.TabIndex = 20;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "해외지수";
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(167, 31);
            this.button16.Margin = new System.Windows.Forms.Padding(4);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(130, 40);
            this.button16.TabIndex = 4;
            this.button16.Tag = "SPI@SPX";
            this.button16.Text = "SnP500";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(12, 31);
            this.button17.Margin = new System.Windows.Forms.Padding(4);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(131, 40);
            this.button17.TabIndex = 1;
            this.button17.Tag = "DJI@DJI";
            this.button17.Text = "다우";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(469, 31);
            this.button18.Margin = new System.Windows.Forms.Padding(4);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(130, 40);
            this.button18.TabIndex = 6;
            this.button18.Tag = "SHS@000002";
            this.button18.Text = "중국상해";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(314, 31);
            this.button19.Margin = new System.Windows.Forms.Padding(4);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(131, 40);
            this.button19.TabIndex = 5;
            this.button19.Tag = "NAS@IXIC";
            this.button19.Text = "나스닥";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(762, 31);
            this.button21.Margin = new System.Windows.Forms.Padding(4);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(130, 40);
            this.button21.TabIndex = 8;
            this.button21.Tag = "NII@NI225";
            this.button21.Text = "니케이";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(607, 31);
            this.button22.Margin = new System.Windows.Forms.Padding(4);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(131, 40);
            this.button22.TabIndex = 7;
            this.button22.Tag = "HSI@HSI";
            this.button22.Text = "항셍";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.btnWorldIndex_Click);
            // 
            // XingAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(916, 861);
            this.Controls.Add(this.pnlContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "XingAppForm";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ATMAN INV..XING SISE DAEMON";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
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
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox chkRealES;
        private System.Windows.Forms.RadioButton rdo100;
        private System.Windows.Forms.RadioButton rdo500;
        private System.Windows.Forms.RadioButton rdo200;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkSendRealtimeKr;
        private System.Windows.Forms.CheckBox chkRealKosdaq;
        private System.Windows.Forms.CheckBox chkRealKospi200;
        private System.Windows.Forms.CheckBox chkRealKospi;
        private System.Windows.Forms.Button btnRealKr;
        private System.Windows.Forms.CheckBox chkKosdaq;
        private System.Windows.Forms.CheckBox chkKospi;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
    }
}

