namespace OM.Jiva.Chakra.App
{
    partial class JivaCreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JivaCreateForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.고가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.저가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sdt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pattern2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pattern3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pattern4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAutoCreateCrypto = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdoCandleF = new System.Windows.Forms.RadioButton();
            this.rdoCandle4 = new System.Windows.Forms.RadioButton();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.btnAutoCreateKItem = new System.Windows.Forms.Button();
            this.btnAutoCreateWFuture = new System.Windows.Forms.Button();
            this.btnAutoCreateWIndex = new System.Windows.Forms.Button();
            this.btnAutoCreateKIndex = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbxItem = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoTInterval5H = new System.Windows.Forms.RadioButton();
            this.rdoTInterval2H = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalW = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalD = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalH = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalM = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoTypeCrypto = new System.Windows.Forms.RadioButton();
            this.rdoTypeKItem = new System.Windows.Forms.RadioButton();
            this.rdoTypeWFuture = new System.Windows.Forms.RadioButton();
            this.rdoTypeWIndex = new System.Windows.Forms.RadioButton();
            this.rdoTypeKIndex = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(459, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(985, 645);
            this.panel1.TabIndex = 3;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.시가,
            this.고가,
            this.저가,
            this.종가,
            this.sdt,
            this.edt,
            this.pattern2,
            this.pattern3,
            this.pattern4});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.LightGray;
            this.dgv.Location = new System.Drawing.Point(0, 94);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(983, 549);
            this.dgv.TabIndex = 6;
            // 
            // name
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle2;
            this.name.Frozen = true;
            this.name.HeaderText = "Item";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // 시가
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.시가.DefaultCellStyle = dataGridViewCellStyle3;
            this.시가.Frozen = true;
            this.시가.HeaderText = "open";
            this.시가.MinimumWidth = 8;
            this.시가.Name = "시가";
            this.시가.ReadOnly = true;
            this.시가.Width = 80;
            // 
            // 고가
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.고가.DefaultCellStyle = dataGridViewCellStyle4;
            this.고가.Frozen = true;
            this.고가.HeaderText = "high";
            this.고가.MinimumWidth = 8;
            this.고가.Name = "고가";
            this.고가.ReadOnly = true;
            this.고가.Width = 80;
            // 
            // 저가
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.저가.DefaultCellStyle = dataGridViewCellStyle5;
            this.저가.Frozen = true;
            this.저가.HeaderText = "low";
            this.저가.MinimumWidth = 8;
            this.저가.Name = "저가";
            this.저가.ReadOnly = true;
            this.저가.Width = 80;
            // 
            // 종가
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.종가.DefaultCellStyle = dataGridViewCellStyle6;
            this.종가.Frozen = true;
            this.종가.HeaderText = "close";
            this.종가.MinimumWidth = 8;
            this.종가.Name = "종가";
            this.종가.ReadOnly = true;
            this.종가.Width = 80;
            // 
            // sdt
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sdt.DefaultCellStyle = dataGridViewCellStyle7;
            this.sdt.Frozen = true;
            this.sdt.HeaderText = "sdt";
            this.sdt.MinimumWidth = 8;
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            this.sdt.Width = 150;
            // 
            // edt
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.edt.DefaultCellStyle = dataGridViewCellStyle8;
            this.edt.Frozen = true;
            this.edt.HeaderText = "edt";
            this.edt.MinimumWidth = 8;
            this.edt.Name = "edt";
            this.edt.ReadOnly = true;
            this.edt.Width = 150;
            // 
            // pattern2
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.pattern2.DefaultCellStyle = dataGridViewCellStyle9;
            this.pattern2.Frozen = true;
            this.pattern2.HeaderText = "pattern2";
            this.pattern2.MinimumWidth = 8;
            this.pattern2.Name = "pattern2";
            this.pattern2.ReadOnly = true;
            this.pattern2.Width = 60;
            // 
            // pattern3
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pattern3.DefaultCellStyle = dataGridViewCellStyle10;
            this.pattern3.Frozen = true;
            this.pattern3.HeaderText = "pattern3";
            this.pattern3.Name = "pattern3";
            this.pattern3.ReadOnly = true;
            this.pattern3.Width = 60;
            // 
            // pattern4
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pattern4.DefaultCellStyle = dataGridViewCellStyle11;
            this.pattern4.Frozen = true;
            this.pattern4.HeaderText = "pattern4";
            this.pattern4.Name = "pattern4";
            this.pattern4.ReadOnly = true;
            this.pattern4.Width = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAutoCreateCrypto);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.dtpE);
            this.panel2.Controls.Add(this.dtpS);
            this.panel2.Controls.Add(this.btnAutoCreateKItem);
            this.panel2.Controls.Add(this.btnAutoCreateWFuture);
            this.panel2.Controls.Add(this.btnAutoCreateWIndex);
            this.panel2.Controls.Add(this.btnAutoCreateKIndex);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(983, 94);
            this.panel2.TabIndex = 0;
            // 
            // btnAutoCreateCrypto
            // 
            this.btnAutoCreateCrypto.Location = new System.Drawing.Point(866, 57);
            this.btnAutoCreateCrypto.Name = "btnAutoCreateCrypto";
            this.btnAutoCreateCrypto.Size = new System.Drawing.Size(110, 30);
            this.btnAutoCreateCrypto.TabIndex = 11;
            this.btnAutoCreateCrypto.Text = "자동(암호화폐)";
            this.btnAutoCreateCrypto.UseVisualStyleBackColor = true;
            this.btnAutoCreateCrypto.Click += new System.EventHandler(this.btnAutoCreateCrypto_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.rdoCandleF);
            this.panel6.Controls.Add(this.rdoCandle4);
            this.panel6.Location = new System.Drawing.Point(4, 57);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(109, 31);
            this.panel6.TabIndex = 7;
            // 
            // rdoCandleF
            // 
            this.rdoCandleF.AutoSize = true;
            this.rdoCandleF.Checked = true;
            this.rdoCandleF.Location = new System.Drawing.Point(62, 7);
            this.rdoCandleF.Name = "rdoCandleF";
            this.rdoCandleF.Size = new System.Drawing.Size(30, 16);
            this.rdoCandleF.TabIndex = 7;
            this.rdoCandleF.TabStop = true;
            this.rdoCandleF.Text = "F";
            this.rdoCandleF.UseVisualStyleBackColor = true;
            this.rdoCandleF.CheckedChanged += new System.EventHandler(this.rdoCandleF_CheckedChanged);
            // 
            // rdoCandle4
            // 
            this.rdoCandle4.AutoSize = true;
            this.rdoCandle4.Location = new System.Drawing.Point(6, 7);
            this.rdoCandle4.Name = "rdoCandle4";
            this.rdoCandle4.Size = new System.Drawing.Size(41, 16);
            this.rdoCandle4.TabIndex = 6;
            this.rdoCandle4.Text = "234";
            this.rdoCandle4.UseVisualStyleBackColor = true;
            this.rdoCandle4.CheckedChanged += new System.EventHandler(this.rdoCandle4_CheckedChanged);
            // 
            // dtpE
            // 
            this.dtpE.Checked = false;
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpE.Location = new System.Drawing.Point(258, 62);
            this.dtpE.Name = "dtpE";
            this.dtpE.ShowCheckBox = true;
            this.dtpE.Size = new System.Drawing.Size(115, 21);
            this.dtpE.TabIndex = 10;
            // 
            // dtpS
            // 
            this.dtpS.Checked = false;
            this.dtpS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpS.Location = new System.Drawing.Point(130, 62);
            this.dtpS.Name = "dtpS";
            this.dtpS.ShowCheckBox = true;
            this.dtpS.Size = new System.Drawing.Size(115, 21);
            this.dtpS.TabIndex = 9;
            // 
            // btnAutoCreateKItem
            // 
            this.btnAutoCreateKItem.Location = new System.Drawing.Point(522, 57);
            this.btnAutoCreateKItem.Name = "btnAutoCreateKItem";
            this.btnAutoCreateKItem.Size = new System.Drawing.Size(110, 30);
            this.btnAutoCreateKItem.TabIndex = 8;
            this.btnAutoCreateKItem.Text = "자동(국내종목)";
            this.btnAutoCreateKItem.UseVisualStyleBackColor = true;
            this.btnAutoCreateKItem.Click += new System.EventHandler(this.btnAutoCreateKItem_Click);
            // 
            // btnAutoCreateWFuture
            // 
            this.btnAutoCreateWFuture.Location = new System.Drawing.Point(751, 57);
            this.btnAutoCreateWFuture.Name = "btnAutoCreateWFuture";
            this.btnAutoCreateWFuture.Size = new System.Drawing.Size(110, 30);
            this.btnAutoCreateWFuture.TabIndex = 7;
            this.btnAutoCreateWFuture.Text = "자동(해외선물)";
            this.btnAutoCreateWFuture.UseVisualStyleBackColor = true;
            this.btnAutoCreateWFuture.Click += new System.EventHandler(this.btnAutoCreateWFuture_Click);
            // 
            // btnAutoCreateWIndex
            // 
            this.btnAutoCreateWIndex.Location = new System.Drawing.Point(637, 57);
            this.btnAutoCreateWIndex.Name = "btnAutoCreateWIndex";
            this.btnAutoCreateWIndex.Size = new System.Drawing.Size(110, 30);
            this.btnAutoCreateWIndex.TabIndex = 6;
            this.btnAutoCreateWIndex.Text = "자동(해외지수)";
            this.btnAutoCreateWIndex.UseVisualStyleBackColor = true;
            this.btnAutoCreateWIndex.Click += new System.EventHandler(this.btnAutoCreateWIndex_Click);
            // 
            // btnAutoCreateKIndex
            // 
            this.btnAutoCreateKIndex.Location = new System.Drawing.Point(406, 57);
            this.btnAutoCreateKIndex.Name = "btnAutoCreateKIndex";
            this.btnAutoCreateKIndex.Size = new System.Drawing.Size(110, 30);
            this.btnAutoCreateKIndex.TabIndex = 5;
            this.btnAutoCreateKIndex.Text = "자동(국내지수)";
            this.btnAutoCreateKIndex.UseVisualStyleBackColor = true;
            this.btnAutoCreateKIndex.Click += new System.EventHandler(this.btnAutoCreateKIndex_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(913, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(62, 46);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cbxItem);
            this.panel5.Location = new System.Drawing.Point(681, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 46);
            this.panel5.TabIndex = 3;
            // 
            // cbxItem
            // 
            this.cbxItem.DropDownHeight = 120;
            this.cbxItem.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbxItem.FormattingEnabled = true;
            this.cbxItem.IntegralHeight = false;
            this.cbxItem.ItemHeight = 13;
            this.cbxItem.Location = new System.Drawing.Point(13, 12);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(156, 21);
            this.cbxItem.TabIndex = 27;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(869, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(44, 46);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rdoTInterval5H);
            this.panel4.Controls.Add(this.rdoTInterval2H);
            this.panel4.Controls.Add(this.rdoTIntervalW);
            this.panel4.Controls.Add(this.rdoTIntervalD);
            this.panel4.Controls.Add(this.rdoTIntervalH);
            this.panel4.Controls.Add(this.rdoTIntervalM);
            this.panel4.Location = new System.Drawing.Point(393, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(283, 46);
            this.panel4.TabIndex = 1;
            // 
            // rdoTInterval5H
            // 
            this.rdoTInterval5H.AutoSize = true;
            this.rdoTInterval5H.Location = new System.Drawing.Point(152, 15);
            this.rdoTInterval5H.Name = "rdoTInterval5H";
            this.rdoTInterval5H.Size = new System.Drawing.Size(37, 16);
            this.rdoTInterval5H.TabIndex = 9;
            this.rdoTInterval5H.TabStop = true;
            this.rdoTInterval5H.Text = "5H";
            this.rdoTInterval5H.UseVisualStyleBackColor = true;
            // 
            // rdoTInterval2H
            // 
            this.rdoTInterval2H.AutoSize = true;
            this.rdoTInterval2H.Location = new System.Drawing.Point(106, 15);
            this.rdoTInterval2H.Name = "rdoTInterval2H";
            this.rdoTInterval2H.Size = new System.Drawing.Size(37, 16);
            this.rdoTInterval2H.TabIndex = 8;
            this.rdoTInterval2H.TabStop = true;
            this.rdoTInterval2H.Text = "2H";
            this.rdoTInterval2H.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalW
            // 
            this.rdoTIntervalW.AutoSize = true;
            this.rdoTIntervalW.Location = new System.Drawing.Point(242, 15);
            this.rdoTIntervalW.Name = "rdoTIntervalW";
            this.rdoTIntervalW.Size = new System.Drawing.Size(33, 16);
            this.rdoTIntervalW.TabIndex = 7;
            this.rdoTIntervalW.TabStop = true;
            this.rdoTIntervalW.Text = "W";
            this.rdoTIntervalW.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalD
            // 
            this.rdoTIntervalD.AutoSize = true;
            this.rdoTIntervalD.Checked = true;
            this.rdoTIntervalD.Location = new System.Drawing.Point(205, 15);
            this.rdoTIntervalD.Name = "rdoTIntervalD";
            this.rdoTIntervalD.Size = new System.Drawing.Size(31, 16);
            this.rdoTIntervalD.TabIndex = 6;
            this.rdoTIntervalD.TabStop = true;
            this.rdoTIntervalD.Text = "D";
            this.rdoTIntervalD.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalH
            // 
            this.rdoTIntervalH.AutoSize = true;
            this.rdoTIntervalH.Location = new System.Drawing.Point(62, 15);
            this.rdoTIntervalH.Name = "rdoTIntervalH";
            this.rdoTIntervalH.Size = new System.Drawing.Size(37, 16);
            this.rdoTIntervalH.TabIndex = 5;
            this.rdoTIntervalH.TabStop = true;
            this.rdoTIntervalH.Text = "1H";
            this.rdoTIntervalH.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalM
            // 
            this.rdoTIntervalM.AutoSize = true;
            this.rdoTIntervalM.Location = new System.Drawing.Point(10, 15);
            this.rdoTIntervalM.Name = "rdoTIntervalM";
            this.rdoTIntervalM.Size = new System.Drawing.Size(46, 16);
            this.rdoTIntervalM.TabIndex = 4;
            this.rdoTIntervalM.TabStop = true;
            this.rdoTIntervalM.Text = "30M";
            this.rdoTIntervalM.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdoTypeCrypto);
            this.panel3.Controls.Add(this.rdoTypeKItem);
            this.panel3.Controls.Add(this.rdoTypeWFuture);
            this.panel3.Controls.Add(this.rdoTypeWIndex);
            this.panel3.Controls.Add(this.rdoTypeKIndex);
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 46);
            this.panel3.TabIndex = 0;
            // 
            // rdoTypeCrypto
            // 
            this.rdoTypeCrypto.AutoSize = true;
            this.rdoTypeCrypto.Location = new System.Drawing.Point(307, 15);
            this.rdoTypeCrypto.Name = "rdoTypeCrypto";
            this.rdoTypeCrypto.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeCrypto.TabIndex = 4;
            this.rdoTypeCrypto.TabStop = true;
            this.rdoTypeCrypto.Text = "암호화폐";
            this.rdoTypeCrypto.UseVisualStyleBackColor = true;
            this.rdoTypeCrypto.CheckedChanged += new System.EventHandler(this.rdoTypeCrypto_CheckedChanged);
            // 
            // rdoTypeKItem
            // 
            this.rdoTypeKItem.AutoSize = true;
            this.rdoTypeKItem.Location = new System.Drawing.Point(228, 15);
            this.rdoTypeKItem.Name = "rdoTypeKItem";
            this.rdoTypeKItem.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeKItem.TabIndex = 3;
            this.rdoTypeKItem.TabStop = true;
            this.rdoTypeKItem.Text = "국내종목";
            this.rdoTypeKItem.UseVisualStyleBackColor = true;
            this.rdoTypeKItem.CheckedChanged += new System.EventHandler(this.rdoTypeKItem_CheckedChanged);
            // 
            // rdoTypeWFuture
            // 
            this.rdoTypeWFuture.AutoSize = true;
            this.rdoTypeWFuture.Location = new System.Drawing.Point(153, 15);
            this.rdoTypeWFuture.Name = "rdoTypeWFuture";
            this.rdoTypeWFuture.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeWFuture.TabIndex = 2;
            this.rdoTypeWFuture.TabStop = true;
            this.rdoTypeWFuture.Text = "해외선물";
            this.rdoTypeWFuture.UseVisualStyleBackColor = true;
            this.rdoTypeWFuture.CheckedChanged += new System.EventHandler(this.rdoTypeWFuture_CheckedChanged);
            // 
            // rdoTypeWIndex
            // 
            this.rdoTypeWIndex.AutoSize = true;
            this.rdoTypeWIndex.Location = new System.Drawing.Point(79, 15);
            this.rdoTypeWIndex.Name = "rdoTypeWIndex";
            this.rdoTypeWIndex.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeWIndex.TabIndex = 1;
            this.rdoTypeWIndex.TabStop = true;
            this.rdoTypeWIndex.Text = "해외지수";
            this.rdoTypeWIndex.UseVisualStyleBackColor = true;
            this.rdoTypeWIndex.CheckedChanged += new System.EventHandler(this.rdoTypeWIndex_CheckedChanged);
            // 
            // rdoTypeKIndex
            // 
            this.rdoTypeKIndex.AutoSize = true;
            this.rdoTypeKIndex.Checked = true;
            this.rdoTypeKIndex.Location = new System.Drawing.Point(5, 15);
            this.rdoTypeKIndex.Name = "rdoTypeKIndex";
            this.rdoTypeKIndex.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeKIndex.TabIndex = 0;
            this.rdoTypeKIndex.TabStop = true;
            this.rdoTypeKIndex.Text = "국내지수";
            this.rdoTypeKIndex.UseVisualStyleBackColor = true;
            this.rdoTypeKIndex.CheckedChanged += new System.EventHandler(this.rdoTypeKIndex_CheckedChanged);
            // 
            // JivaCreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(1025, 725);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JivaCreateForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ATMAN INV. F PATTERN DATA CREATION";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.RadioButton rdoTypeKIndex;
        private System.Windows.Forms.RadioButton rdoTypeWIndex;
        private System.Windows.Forms.RadioButton rdoTypeKItem;
        private System.Windows.Forms.RadioButton rdoTypeWFuture;
        private System.Windows.Forms.ComboBox cbxItem;
        private System.Windows.Forms.RadioButton rdoTIntervalW;
        private System.Windows.Forms.RadioButton rdoTIntervalD;
        private System.Windows.Forms.RadioButton rdoTIntervalH;
        private System.Windows.Forms.RadioButton rdoTIntervalM;
        private System.Windows.Forms.Button btnAutoCreateKIndex;
        private System.Windows.Forms.Button btnAutoCreateKItem;
        private System.Windows.Forms.Button btnAutoCreateWFuture;
        private System.Windows.Forms.Button btnAutoCreateWIndex;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.DateTimePicker dtpE;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.RadioButton rdoCandle4;
        private System.Windows.Forms.Button btnAutoCreateCrypto;
        private System.Windows.Forms.RadioButton rdoTypeCrypto;
        private System.Windows.Forms.RadioButton rdoTInterval2H;
        private System.Windows.Forms.RadioButton rdoTInterval5H;
        private System.Windows.Forms.RadioButton rdoCandleF;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 고가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 저가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종가;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn edt;
        private System.Windows.Forms.DataGridViewTextBoxColumn pattern2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pattern3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pattern4;
    }
}