namespace OM.Jiva.Chakra.App
{
    partial class JivaCreateThreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JivaCreateThreeForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.pattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpE = new System.Windows.Forms.DateTimePicker();
            this.dtpS = new System.Windows.Forms.DateTimePicker();
            this.btnAutoCreateKItem = new System.Windows.Forms.Button();
            this.btnAutoCreateWFuture = new System.Windows.Forms.Button();
            this.btnAutoCreateWIndex = new System.Windows.Forms.Button();
            this.btnAutoCreateKIndex = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbxItem2 = new System.Windows.Forms.ComboBox();
            this.cbxItem = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rdoTIntervalW = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalD = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalH = new System.Windows.Forms.RadioButton();
            this.rdoTIntervalM = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdoTypeKItem = new System.Windows.Forms.RadioButton();
            this.rdoTypeWFuture = new System.Windows.Forms.RadioButton();
            this.rdoTypeWIndex = new System.Windows.Forms.RadioButton();
            this.rdoTypeKIndex = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(801, 659);
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
            this.pattern});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle10;
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
            this.dgv.Size = new System.Drawing.Size(799, 563);
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
            this.sdt.Name = "sdt";
            this.sdt.ReadOnly = true;
            // 
            // edt
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.edt.DefaultCellStyle = dataGridViewCellStyle8;
            this.edt.Frozen = true;
            this.edt.HeaderText = "edt";
            this.edt.Name = "edt";
            this.edt.ReadOnly = true;
            // 
            // pattern
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.pattern.DefaultCellStyle = dataGridViewCellStyle9;
            this.pattern.Frozen = true;
            this.pattern.HeaderText = "pattern";
            this.pattern.MinimumWidth = 8;
            this.pattern.Name = "pattern";
            this.pattern.ReadOnly = true;
            this.pattern.Width = 140;
            // 
            // panel2
            // 
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
            this.panel2.Size = new System.Drawing.Size(799, 94);
            this.panel2.TabIndex = 0;
            // 
            // dtpE
            // 
            this.dtpE.Checked = false;
            this.dtpE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpE.Location = new System.Drawing.Point(135, 62);
            this.dtpE.Name = "dtpE";
            this.dtpE.ShowCheckBox = true;
            this.dtpE.Size = new System.Drawing.Size(115, 21);
            this.dtpE.TabIndex = 10;
            // 
            // dtpS
            // 
            this.dtpS.Checked = false;
            this.dtpS.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpS.Location = new System.Drawing.Point(7, 62);
            this.dtpS.Name = "dtpS";
            this.dtpS.ShowCheckBox = true;
            this.dtpS.Size = new System.Drawing.Size(115, 21);
            this.dtpS.TabIndex = 9;
            // 
            // btnAutoCreateKItem
            // 
            this.btnAutoCreateKItem.Location = new System.Drawing.Point(686, 57);
            this.btnAutoCreateKItem.Name = "btnAutoCreateKItem";
            this.btnAutoCreateKItem.Size = new System.Drawing.Size(110, 31);
            this.btnAutoCreateKItem.TabIndex = 8;
            this.btnAutoCreateKItem.Text = "자동(국내종목)";
            this.btnAutoCreateKItem.UseVisualStyleBackColor = true;
            this.btnAutoCreateKItem.Click += new System.EventHandler(this.btnAutoCreateKItem_Click);
            // 
            // btnAutoCreateWFuture
            // 
            this.btnAutoCreateWFuture.Location = new System.Drawing.Point(573, 57);
            this.btnAutoCreateWFuture.Name = "btnAutoCreateWFuture";
            this.btnAutoCreateWFuture.Size = new System.Drawing.Size(110, 31);
            this.btnAutoCreateWFuture.TabIndex = 7;
            this.btnAutoCreateWFuture.Text = "자동(해외선물)";
            this.btnAutoCreateWFuture.UseVisualStyleBackColor = true;
            this.btnAutoCreateWFuture.Click += new System.EventHandler(this.btnAutoCreateWFuture_Click);
            // 
            // btnAutoCreateWIndex
            // 
            this.btnAutoCreateWIndex.Enabled = false;
            this.btnAutoCreateWIndex.Location = new System.Drawing.Point(460, 57);
            this.btnAutoCreateWIndex.Name = "btnAutoCreateWIndex";
            this.btnAutoCreateWIndex.Size = new System.Drawing.Size(110, 31);
            this.btnAutoCreateWIndex.TabIndex = 6;
            this.btnAutoCreateWIndex.Text = "자동(해외지수)";
            this.btnAutoCreateWIndex.UseVisualStyleBackColor = true;
            this.btnAutoCreateWIndex.Click += new System.EventHandler(this.btnAutoCreateWIndex_Click);
            // 
            // btnAutoCreateKIndex
            // 
            this.btnAutoCreateKIndex.Enabled = false;
            this.btnAutoCreateKIndex.Location = new System.Drawing.Point(347, 57);
            this.btnAutoCreateKIndex.Name = "btnAutoCreateKIndex";
            this.btnAutoCreateKIndex.Size = new System.Drawing.Size(110, 31);
            this.btnAutoCreateKIndex.TabIndex = 5;
            this.btnAutoCreateKIndex.Text = "자동(국내지수)";
            this.btnAutoCreateKIndex.UseVisualStyleBackColor = true;
            this.btnAutoCreateKIndex.Click += new System.EventHandler(this.btnAutoCreateKIndex_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(736, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(60, 46);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cbxItem2);
            this.panel5.Controls.Add(this.cbxItem);
            this.panel5.Location = new System.Drawing.Point(501, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 46);
            this.panel5.TabIndex = 3;
            // 
            // cbxItem2
            // 
            this.cbxItem2.DropDownHeight = 600;
            this.cbxItem2.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbxItem2.FormattingEnabled = true;
            this.cbxItem2.IntegralHeight = false;
            this.cbxItem2.ItemHeight = 13;
            this.cbxItem2.Location = new System.Drawing.Point(13, 23);
            this.cbxItem2.Name = "cbxItem2";
            this.cbxItem2.Size = new System.Drawing.Size(156, 21);
            this.cbxItem2.TabIndex = 28;
            // 
            // cbxItem
            // 
            this.cbxItem.DropDownHeight = 120;
            this.cbxItem.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbxItem.FormattingEnabled = true;
            this.cbxItem.IntegralHeight = false;
            this.cbxItem.ItemHeight = 13;
            this.cbxItem.Location = new System.Drawing.Point(13, 0);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(156, 21);
            this.cbxItem.TabIndex = 27;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(691, 5);
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
            this.panel4.Controls.Add(this.rdoTIntervalW);
            this.panel4.Controls.Add(this.rdoTIntervalD);
            this.panel4.Controls.Add(this.rdoTIntervalH);
            this.panel4.Controls.Add(this.rdoTIntervalM);
            this.panel4.Location = new System.Drawing.Point(307, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(192, 46);
            this.panel4.TabIndex = 1;
            // 
            // rdoTIntervalW
            // 
            this.rdoTIntervalW.AutoSize = true;
            this.rdoTIntervalW.Location = new System.Drawing.Point(152, 15);
            this.rdoTIntervalW.Name = "rdoTIntervalW";
            this.rdoTIntervalW.Size = new System.Drawing.Size(35, 16);
            this.rdoTIntervalW.TabIndex = 7;
            this.rdoTIntervalW.TabStop = true;
            this.rdoTIntervalW.Text = "주";
            this.rdoTIntervalW.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalD
            // 
            this.rdoTIntervalD.AutoSize = true;
            this.rdoTIntervalD.Checked = true;
            this.rdoTIntervalD.Location = new System.Drawing.Point(115, 15);
            this.rdoTIntervalD.Name = "rdoTIntervalD";
            this.rdoTIntervalD.Size = new System.Drawing.Size(35, 16);
            this.rdoTIntervalD.TabIndex = 6;
            this.rdoTIntervalD.TabStop = true;
            this.rdoTIntervalD.Text = "일";
            this.rdoTIntervalD.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalH
            // 
            this.rdoTIntervalH.AutoSize = true;
            this.rdoTIntervalH.Location = new System.Drawing.Point(58, 15);
            this.rdoTIntervalH.Name = "rdoTIntervalH";
            this.rdoTIntervalH.Size = new System.Drawing.Size(53, 16);
            this.rdoTIntervalH.TabIndex = 5;
            this.rdoTIntervalH.TabStop = true;
            this.rdoTIntervalH.Text = "1시간";
            this.rdoTIntervalH.UseVisualStyleBackColor = true;
            // 
            // rdoTIntervalM
            // 
            this.rdoTIntervalM.AutoSize = true;
            this.rdoTIntervalM.Location = new System.Drawing.Point(10, 15);
            this.rdoTIntervalM.Name = "rdoTIntervalM";
            this.rdoTIntervalM.Size = new System.Drawing.Size(47, 16);
            this.rdoTIntervalM.TabIndex = 4;
            this.rdoTIntervalM.TabStop = true;
            this.rdoTIntervalM.Text = "30분";
            this.rdoTIntervalM.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdoTypeKItem);
            this.panel3.Controls.Add(this.rdoTypeWFuture);
            this.panel3.Controls.Add(this.rdoTypeWIndex);
            this.panel3.Controls.Add(this.rdoTypeKIndex);
            this.panel3.Location = new System.Drawing.Point(4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 46);
            this.panel3.TabIndex = 0;
            // 
            // rdoTypeKItem
            // 
            this.rdoTypeKItem.AutoSize = true;
            this.rdoTypeKItem.Location = new System.Drawing.Point(222, 15);
            this.rdoTypeKItem.Name = "rdoTypeKItem";
            this.rdoTypeKItem.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeKItem.TabIndex = 3;
            this.rdoTypeKItem.TabStop = true;
            this.rdoTypeKItem.Text = "국내종목";
            this.rdoTypeKItem.UseVisualStyleBackColor = true;
            // 
            // rdoTypeWFuture
            // 
            this.rdoTypeWFuture.AutoSize = true;
            this.rdoTypeWFuture.Location = new System.Drawing.Point(151, 15);
            this.rdoTypeWFuture.Name = "rdoTypeWFuture";
            this.rdoTypeWFuture.Size = new System.Drawing.Size(71, 16);
            this.rdoTypeWFuture.TabIndex = 2;
            this.rdoTypeWFuture.TabStop = true;
            this.rdoTypeWFuture.Text = "해외선물";
            this.rdoTypeWFuture.UseVisualStyleBackColor = true;
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
            // 
            // JivaCreateThhreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(841, 739);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "JivaCreateThhreeForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ATMAN INV. F PATTERN 3 DATA CREATION";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 고가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 저가;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종가;
        private System.Windows.Forms.DataGridViewTextBoxColumn sdt;
        private System.Windows.Forms.DataGridViewTextBoxColumn edt;
        private System.Windows.Forms.DataGridViewTextBoxColumn pattern;
        private System.Windows.Forms.ComboBox cbxItem2;
        private System.Windows.Forms.Button btnAutoCreateKIndex;
        private System.Windows.Forms.Button btnAutoCreateKItem;
        private System.Windows.Forms.Button btnAutoCreateWFuture;
        private System.Windows.Forms.Button btnAutoCreateWIndex;
        private System.Windows.Forms.DateTimePicker dtpS;
        private System.Windows.Forms.DateTimePicker dtpE;
    }
}