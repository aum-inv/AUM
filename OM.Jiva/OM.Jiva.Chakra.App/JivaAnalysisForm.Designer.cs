namespace OM.Jiva.Chakra.App
{
    partial class JivaAnalysisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JivaAnalysisForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadDaemonM = new System.Windows.Forms.Button();
            this.btnLoadDaemonH = new System.Windows.Forms.Button();
            this.btnLoadDaemonD = new System.Windows.Forms.Button();
            this.btnLoadDaemonW = new System.Windows.Forms.Button();
            this.cbxItem = new System.Windows.Forms.ComboBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.nudDisplay = new System.Windows.Forms.NumericUpDown();
            this.pnlLeftContent = new MetroFramework.Controls.MetroPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.패턴4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlResultView = new MetroFramework.Controls.MetroPanel();
            this.lbNoResult = new MetroFramework.Controls.MetroLabel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.구분 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorEnergy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.고가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpChart = new System.Windows.Forms.TableLayoutPanel();
            this.chart2 = new OM.Vikala.Controls.Charts.PatternCandleChart();
            this.chart1 = new OM.Vikala.Controls.Charts.PatternCandleChart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplay)).BeginInit();
            this.pnlLeftContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.pnlResultView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.tlpChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(377, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadDaemonM
            // 
            this.btnLoadDaemonM.BackColor = System.Drawing.Color.White;
            this.btnLoadDaemonM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadDaemonM.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoadDaemonM.FlatAppearance.BorderSize = 0;
            this.btnLoadDaemonM.Location = new System.Drawing.Point(263, 4);
            this.btnLoadDaemonM.Name = "btnLoadDaemonM";
            this.btnLoadDaemonM.Size = new System.Drawing.Size(29, 23);
            this.btnLoadDaemonM.TabIndex = 10;
            this.btnLoadDaemonM.Text = "분";
            this.btnLoadDaemonM.UseVisualStyleBackColor = false;
            this.btnLoadDaemonM.Click += new System.EventHandler(this.btnLoadDaemon_Click);
            // 
            // btnLoadDaemonH
            // 
            this.btnLoadDaemonH.BackColor = System.Drawing.Color.White;
            this.btnLoadDaemonH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadDaemonH.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoadDaemonH.FlatAppearance.BorderSize = 0;
            this.btnLoadDaemonH.Location = new System.Drawing.Point(292, 4);
            this.btnLoadDaemonH.Name = "btnLoadDaemonH";
            this.btnLoadDaemonH.Size = new System.Drawing.Size(29, 23);
            this.btnLoadDaemonH.TabIndex = 9;
            this.btnLoadDaemonH.Text = "시";
            this.btnLoadDaemonH.UseVisualStyleBackColor = false;
            this.btnLoadDaemonH.Click += new System.EventHandler(this.btnLoadDaemon_Click);
            // 
            // btnLoadDaemonD
            // 
            this.btnLoadDaemonD.BackColor = System.Drawing.Color.White;
            this.btnLoadDaemonD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadDaemonD.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoadDaemonD.FlatAppearance.BorderSize = 0;
            this.btnLoadDaemonD.Location = new System.Drawing.Point(321, 4);
            this.btnLoadDaemonD.Name = "btnLoadDaemonD";
            this.btnLoadDaemonD.Size = new System.Drawing.Size(29, 23);
            this.btnLoadDaemonD.TabIndex = 7;
            this.btnLoadDaemonD.Text = "일";
            this.btnLoadDaemonD.UseVisualStyleBackColor = false;
            this.btnLoadDaemonD.Click += new System.EventHandler(this.btnLoadDaemon_Click);
            // 
            // btnLoadDaemonW
            // 
            this.btnLoadDaemonW.BackColor = System.Drawing.Color.White;
            this.btnLoadDaemonW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadDaemonW.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoadDaemonW.FlatAppearance.BorderSize = 0;
            this.btnLoadDaemonW.Location = new System.Drawing.Point(350, 4);
            this.btnLoadDaemonW.Name = "btnLoadDaemonW";
            this.btnLoadDaemonW.Size = new System.Drawing.Size(29, 23);
            this.btnLoadDaemonW.TabIndex = 8;
            this.btnLoadDaemonW.Text = "주";
            this.btnLoadDaemonW.UseVisualStyleBackColor = false;
            this.btnLoadDaemonW.Click += new System.EventHandler(this.btnLoadDaemon_Click);
            // 
            // cbxItem
            // 
            this.cbxItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxItem.DropDownHeight = 120;
            this.cbxItem.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbxItem.FormattingEnabled = true;
            this.cbxItem.IntegralHeight = false;
            this.cbxItem.ItemHeight = 12;
            this.cbxItem.Location = new System.Drawing.Point(99, 5);
            this.cbxItem.Name = "cbxItem";
            this.cbxItem.Size = new System.Drawing.Size(159, 20);
            this.cbxItem.TabIndex = 24;
            this.cbxItem.SelectedIndexChanged += new System.EventHandler(this.cbxItem_SelectedIndexChanged);
            this.cbxItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxItem_KeyDown);
            this.cbxItem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxItem_KeyUp);
            // 
            // openFile
            // 
            this.openFile.Filter = "텍스트파일|*.txt";
            // 
            // cbxProduct
            // 
            this.cbxProduct.DropDownHeight = 120;
            this.cbxProduct.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.IntegralHeight = false;
            this.cbxProduct.ItemHeight = 12;
            this.cbxProduct.Items.AddRange(new object[] {
            "국내지수",
            "해외지수",
            "해외선물",
            "국내종목"});
            this.cbxProduct.Location = new System.Drawing.Point(6, 5);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(87, 20);
            this.cbxProduct.TabIndex = 25;
            this.cbxProduct.SelectedIndexChanged += new System.EventHandler(this.cbxProduct_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnLoad);
            this.panel3.Controls.Add(this.nudDisplay);
            this.panel3.Controls.Add(this.cbxItem);
            this.panel3.Controls.Add(this.cbxProduct);
            this.panel3.Controls.Add(this.btnLoadDaemonM);
            this.panel3.Controls.Add(this.btnLoadDaemonH);
            this.panel3.Controls.Add(this.btnLoadDaemonW);
            this.panel3.Controls.Add(this.btnLoadDaemonD);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(20, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1267, 32);
            this.panel3.TabIndex = 4;
            // 
            // btnLoad
            // 
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoad.Enabled = false;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.Location = new System.Drawing.Point(414, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 23);
            this.btnLoad.TabIndex = 28;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // nudDisplay
            // 
            this.nudDisplay.AutoSize = true;
            this.nudDisplay.BackColor = System.Drawing.Color.White;
            this.nudDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudDisplay.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudDisplay.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisplay.Location = new System.Drawing.Point(739, 4);
            this.nudDisplay.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudDisplay.Name = "nudDisplay";
            this.nudDisplay.Size = new System.Drawing.Size(47, 23);
            this.nudDisplay.TabIndex = 27;
            this.nudDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudDisplay.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudDisplay.ValueChanged += new System.EventHandler(this.nudDisplay_ValueChanged);
            // 
            // pnlLeftContent
            // 
            this.pnlLeftContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftContent.Controls.Add(this.dgvList);
            this.pnlLeftContent.Controls.Add(this.pnlResultView);
            this.pnlLeftContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftContent.HorizontalScrollbarBarColor = true;
            this.pnlLeftContent.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlLeftContent.HorizontalScrollbarSize = 10;
            this.pnlLeftContent.Location = new System.Drawing.Point(20, 92);
            this.pnlLeftContent.Name = "pnlLeftContent";
            this.pnlLeftContent.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLeftContent.Size = new System.Drawing.Size(380, 549);
            this.pnlLeftContent.TabIndex = 12;
            this.pnlLeftContent.VerticalScrollbarBarColor = true;
            this.pnlLeftContent.VerticalScrollbarHighlightOnWheel = false;
            this.pnlLeftContent.VerticalScrollbarSize = 10;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            this.dgvList.BackgroundColor = System.Drawing.Color.White;
            this.dgvList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle78.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle78.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle78.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle78.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle78.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle78.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle78;
            this.dgvList.ColumnHeadersHeight = 25;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.Column1,
            this.패턴4});
            dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle83.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle83.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle83.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle83.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle83.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle83.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle83;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.GridColor = System.Drawing.Color.LightGray;
            this.dgvList.Location = new System.Drawing.Point(5, 5);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(368, 262);
            this.dgvList.TabIndex = 23;
            this.dgvList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellContentDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle79.Format = "d";
            dataGridViewCellStyle79.NullValue = "yy.MM.dd HH:mm";
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle79;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "시간";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle80.Padding = new System.Windows.Forms.Padding(1);
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle80;
            this.dataGridViewTextBoxColumn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewTextBoxColumn5.Frozen = true;
            this.dataGridViewTextBoxColumn5.HeaderText = "패턴 2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn5.Text = "분석";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // Column1
            // 
            dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle81.Padding = new System.Windows.Forms.Padding(1);
            this.Column1.DefaultCellStyle = dataGridViewCellStyle81;
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Column1.HeaderText = "패턴 3";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Text = "분석";
            this.Column1.Width = 70;
            // 
            // 패턴4
            // 
            dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle82.Padding = new System.Windows.Forms.Padding(1);
            this.패턴4.DefaultCellStyle = dataGridViewCellStyle82;
            this.패턴4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.패턴4.HeaderText = "패턴 4";
            this.패턴4.Name = "패턴4";
            this.패턴4.ReadOnly = true;
            this.패턴4.Width = 70;
            // 
            // pnlResultView
            // 
            this.pnlResultView.Controls.Add(this.lbNoResult);
            this.pnlResultView.Controls.Add(this.dgv);
            this.pnlResultView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResultView.HorizontalScrollbarBarColor = true;
            this.pnlResultView.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlResultView.HorizontalScrollbarSize = 10;
            this.pnlResultView.Location = new System.Drawing.Point(5, 267);
            this.pnlResultView.Name = "pnlResultView";
            this.pnlResultView.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlResultView.Size = new System.Drawing.Size(368, 275);
            this.pnlResultView.TabIndex = 22;
            this.pnlResultView.VerticalScrollbarBarColor = true;
            this.pnlResultView.VerticalScrollbarHighlightOnWheel = false;
            this.pnlResultView.VerticalScrollbarSize = 10;
            // 
            // lbNoResult
            // 
            this.lbNoResult.Location = new System.Drawing.Point(61, 119);
            this.lbNoResult.Name = "lbNoResult";
            this.lbNoResult.Size = new System.Drawing.Size(192, 23);
            this.lbNoResult.TabIndex = 4;
            this.lbNoResult.Text = "매칭된 데이터가 없습니다.";
            this.lbNoResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNoResult.Visible = false;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle84.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle84.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle84.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle84.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle84.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle84.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle84;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.시간,
            this.구분,
            this.ColorEnergy,
            this.고가});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.LightGray;
            this.dgv.Location = new System.Drawing.Point(0, 10);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(368, 265);
            this.dgv.TabIndex = 3;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            // 
            // 시간
            // 
            dataGridViewCellStyle85.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.시간.DefaultCellStyle = dataGridViewCellStyle85;
            this.시간.Frozen = true;
            this.시간.HeaderText = "종목";
            this.시간.Name = "시간";
            this.시간.ReadOnly = true;
            this.시간.Width = 80;
            // 
            // 구분
            // 
            dataGridViewCellStyle86.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.구분.DefaultCellStyle = dataGridViewCellStyle86;
            this.구분.Frozen = true;
            this.구분.HeaderText = "구분";
            this.구분.Name = "구분";
            this.구분.ReadOnly = true;
            this.구분.Width = 50;
            // 
            // ColorEnergy
            // 
            dataGridViewCellStyle87.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle87.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ColorEnergy.DefaultCellStyle = dataGridViewCellStyle87;
            this.ColorEnergy.Frozen = true;
            this.ColorEnergy.HeaderText = "시간";
            this.ColorEnergy.Name = "ColorEnergy";
            this.ColorEnergy.ReadOnly = true;
            // 
            // 고가
            // 
            dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle88.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.고가.DefaultCellStyle = dataGridViewCellStyle88;
            this.고가.Frozen = true;
            this.고가.HeaderText = "방향";
            this.고가.Name = "고가";
            this.고가.ReadOnly = true;
            // 
            // tlpChart
            // 
            this.tlpChart.ColumnCount = 1;
            this.tlpChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpChart.Controls.Add(this.chart2, 0, 1);
            this.tlpChart.Controls.Add(this.chart1, 0, 0);
            this.tlpChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChart.Location = new System.Drawing.Point(400, 92);
            this.tlpChart.Name = "tlpChart";
            this.tlpChart.RowCount = 2;
            this.tlpChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpChart.Size = new System.Drawing.Size(887, 549);
            this.tlpChart.TabIndex = 14;
            // 
            // chart2
            // 
            this.chart2.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart2.ChartData = null;
            this.chart2.ChartEventInstance = null;
            this.chart2.DisplayPointCount = 120;
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.IsAutoScrollX = true;
            this.chart2.IsEnabledDrawLine = true;
            this.chart2.IsLoaded = false;
            this.chart2.IsShowXLine = true;
            this.chart2.IsShowYLine = true;
            this.chart2.ItemCode = "";
            this.chart2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart2.Location = new System.Drawing.Point(3, 278);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart2.Name = "chart2";
            this.chart2.SelectedPType = "";
            this.chart2.SelectedTrackBarValue = 1;
            this.chart2.Size = new System.Drawing.Size(881, 267);
            this.chart2.TabIndex = 1;
            this.chart2.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart2.Title = null;
            // 
            // chart1
            // 
            this.chart1.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart1.ChartData = null;
            this.chart1.ChartEventInstance = null;
            this.chart1.DisplayPointCount = 120;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.IsAutoScrollX = true;
            this.chart1.IsEnabledDrawLine = true;
            this.chart1.IsLoaded = false;
            this.chart1.IsShowXLine = true;
            this.chart1.IsShowYLine = true;
            this.chart1.ItemCode = "";
            this.chart1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart1.Location = new System.Drawing.Point(3, 4);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart1.Name = "chart1";
            this.chart1.SelectedPType = "";
            this.chart1.SelectedTrackBarValue = 1;
            this.chart1.Size = new System.Drawing.Size(881, 266);
            this.chart1.TabIndex = 0;
            this.chart1.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart1.Title = null;
            // 
            // JivaAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 661);
            this.Controls.Add(this.tlpChart);
            this.Controls.Add(this.pnlLeftContent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JivaAnalysisForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Lime;
            this.Text = "ATMAN INV. F. JIVA ANALYSIS";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDisplay)).EndInit();
            this.pnlLeftContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.pnlResultView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.tlpChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.Button btnLoadDaemonD;
        private System.Windows.Forms.Button btnLoadDaemonW;
        private System.Windows.Forms.Button btnLoadDaemonH;
        private System.Windows.Forms.ComboBox cbxItem;
        private System.Windows.Forms.Button btnLoadDaemonM;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.Panel panel3;
        private MetroFramework.Controls.MetroPanel pnlLeftContent;
        private System.Windows.Forms.TableLayoutPanel tlpChart;
        private Vikala.Controls.Charts.PatternCandleChart chart1;
        private MetroFramework.Controls.MetroPanel pnlResultView;
        private MetroFramework.Controls.MetroLabel lbNoResult;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.NumericUpDown nudDisplay;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 구분;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorEnergy;
        private System.Windows.Forms.DataGridViewTextBoxColumn 고가;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn 패턴4;
        private Vikala.Controls.Charts.PatternCandleChart chart2;
    }
}