namespace OM.Atman.Chakra.App.FinderForms
{
    partial class AtmanKRPickItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmanKRPickItemForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlResultView = new MetroFramework.Controls.MetroPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.종가 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시간 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReg = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tbPickDT = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.pnlLeft = new MetroFramework.Controls.MetroPanel();
            this.pnlLeftContent = new MetroFramework.Controls.MetroPanel();
            this.chart = new OM.Vikala.Controls.Charts.ComparedBasicCandleChart();
            this.pnlTitle = new MetroFramework.Controls.MetroPanel();
            this.btnGoAlpha = new System.Windows.Forms.Button();
            this.btnGoNaver = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbSelectedName2 = new MetroFramework.Controls.MetroTextBox();
            this.tbSelectedCode2 = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlResultView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftContent.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(352, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlResultView);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlLeft);
            this.splitContainer1.Size = new System.Drawing.Size(1169, 645);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 3;
            // 
            // pnlResultView
            // 
            this.pnlResultView.Controls.Add(this.dgv);
            this.pnlResultView.Controls.Add(this.panel1);
            this.pnlResultView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultView.HorizontalScrollbarBarColor = true;
            this.pnlResultView.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlResultView.HorizontalScrollbarSize = 10;
            this.pnlResultView.Location = new System.Drawing.Point(0, 0);
            this.pnlResultView.Name = "pnlResultView";
            this.pnlResultView.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlResultView.Size = new System.Drawing.Size(400, 645);
            this.pnlResultView.TabIndex = 11;
            this.pnlResultView.VerticalScrollbarBarColor = true;
            this.pnlResultView.VerticalScrollbarHighlightOnWheel = false;
            this.pnlResultView.VerticalScrollbarSize = 10;
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
            this.종가,
            this.시간,
            this.name,
            this.Sign});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.LightGray;
            this.dgv.Location = new System.Drawing.Point(5, 5);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.Size = new System.Drawing.Size(390, 503);
            this.dgv.TabIndex = 25;
            this.dgv.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentDoubleClick);
            // 
            // 종가
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "MM.dd";
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.종가.DefaultCellStyle = dataGridViewCellStyle2;
            this.종가.Frozen = true;
            this.종가.HeaderText = "date";
            this.종가.MinimumWidth = 8;
            this.종가.Name = "종가";
            this.종가.ReadOnly = true;
            this.종가.Width = 80;
            // 
            // 시간
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.시간.DefaultCellStyle = dataGridViewCellStyle3;
            this.시간.Frozen = true;
            this.시간.HeaderText = "code";
            this.시간.MinimumWidth = 8;
            this.시간.Name = "시간";
            this.시간.ReadOnly = true;
            this.시간.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.시간.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.시간.Width = 60;
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 110;
            // 
            // Sign
            // 
            this.Sign.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Sign.DefaultCellStyle = dataGridViewCellStyle4;
            this.Sign.HeaderText = "reason";
            this.Sign.MinimumWidth = 8;
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnReg);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 508);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(390, 132);
            this.panel1.TabIndex = 24;
            // 
            // btnReg
            // 
            this.btnReg.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Location = new System.Drawing.Point(295, 5);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(90, 122);
            this.btnReg.TabIndex = 32;
            this.btnReg.Text = "Registration";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.metroLabel2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel11, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.metroLabel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbPickDT, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbCode, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbReason, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 122);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // metroLabel2
            // 
            this.metroLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.ForeColor = System.Drawing.Color.Fuchsia;
            this.metroLabel2.Location = new System.Drawing.Point(4, 91);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(94, 30);
            this.metroLabel2.TabIndex = 27;
            this.metroLabel2.Text = "Reason";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroLabel2.UseCustomForeColor = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel11.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel11.Location = new System.Drawing.Point(4, 1);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(94, 29);
            this.metroLabel11.TabIndex = 21;
            this.metroLabel11.Text = "PickDT";
            this.metroLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel3
            // 
            this.metroLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.Location = new System.Drawing.Point(4, 31);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(94, 29);
            this.metroLabel3.TabIndex = 21;
            this.metroLabel3.Text = "Code";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel4
            // 
            this.metroLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.Location = new System.Drawing.Point(4, 61);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(94, 29);
            this.metroLabel4.TabIndex = 22;
            this.metroLabel4.Text = "Name";
            this.metroLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPickDT
            // 
            this.tbPickDT.BackColor = System.Drawing.Color.White;
            this.tbPickDT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPickDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPickDT.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPickDT.Location = new System.Drawing.Point(105, 4);
            this.tbPickDT.Name = "tbPickDT";
            this.tbPickDT.Size = new System.Drawing.Size(275, 22);
            this.tbPickDT.TabIndex = 28;
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.White;
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCode.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbCode.Location = new System.Drawing.Point(105, 34);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(275, 22);
            this.tbCode.TabIndex = 29;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbName.Location = new System.Drawing.Point(105, 64);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(275, 22);
            this.tbName.TabIndex = 30;
            // 
            // tbReason
            // 
            this.tbReason.BackColor = System.Drawing.Color.White;
            this.tbReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReason.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbReason.Location = new System.Drawing.Point(105, 94);
            this.tbReason.Name = "tbReason";
            this.tbReason.Size = new System.Drawing.Size(275, 22);
            this.tbReason.TabIndex = 31;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlLeftContent);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.HorizontalScrollbarBarColor = true;
            this.pnlLeft.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlLeft.HorizontalScrollbarSize = 10;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(765, 645);
            this.pnlLeft.TabIndex = 7;
            this.pnlLeft.VerticalScrollbarBarColor = true;
            this.pnlLeft.VerticalScrollbarHighlightOnWheel = false;
            this.pnlLeft.VerticalScrollbarSize = 10;
            // 
            // pnlLeftContent
            // 
            this.pnlLeftContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftContent.Controls.Add(this.chart);
            this.pnlLeftContent.Controls.Add(this.pnlTitle);
            this.pnlLeftContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftContent.HorizontalScrollbarBarColor = true;
            this.pnlLeftContent.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlLeftContent.HorizontalScrollbarSize = 10;
            this.pnlLeftContent.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftContent.Name = "pnlLeftContent";
            this.pnlLeftContent.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pnlLeftContent.Size = new System.Drawing.Size(765, 645);
            this.pnlLeftContent.TabIndex = 5;
            this.pnlLeftContent.VerticalScrollbarBarColor = true;
            this.pnlLeftContent.VerticalScrollbarHighlightOnWheel = false;
            this.pnlLeftContent.VerticalScrollbarSize = 10;
            // 
            // chart
            // 
            this.chart.BaseCandleChartType = OM.Vikala.Controls.Charts.BaseCandleChartTypeEnum.인;
            this.chart.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart.ChartData = null;
            this.chart.ChartDataSub = null;
            this.chart.ChartEventInstance = null;
            this.chart.DisplayPointCount = 120;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.IsAutoScrollX = true;
            this.chart.IsEnabledDrawLine = true;
            this.chart.IsLoaded = false;
            this.chart.IsShowEightRule = false;
            this.chart.IsShowXLine = true;
            this.chart.IsShowYLine = true;
            this.chart.ItemCode = "";
            this.chart.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart.Location = new System.Drawing.Point(5, 30);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart.Name = "chart";
            this.chart.SelectedTrackBarValue = 1;
            this.chart.Size = new System.Drawing.Size(753, 608);
            this.chart.TabIndex = 4;
            this.chart.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart.Title = null;
            // 
            // pnlTitle
            // 
            this.pnlTitle.Controls.Add(this.btnGoAlpha);
            this.pnlTitle.Controls.Add(this.btnGoNaver);
            this.pnlTitle.Controls.Add(this.btnDel);
            this.pnlTitle.Controls.Add(this.tbSelectedName2);
            this.pnlTitle.Controls.Add(this.tbSelectedCode2);
            this.pnlTitle.Controls.Add(this.metroLabel5);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.HorizontalScrollbarBarColor = true;
            this.pnlTitle.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlTitle.HorizontalScrollbarSize = 10;
            this.pnlTitle.Location = new System.Drawing.Point(5, 5);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(753, 25);
            this.pnlTitle.TabIndex = 3;
            this.pnlTitle.VerticalScrollbarBarColor = true;
            this.pnlTitle.VerticalScrollbarHighlightOnWheel = false;
            this.pnlTitle.VerticalScrollbarSize = 10;
            // 
            // btnGoAlpha
            // 
            this.btnGoAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnGoAlpha.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGoAlpha.FlatAppearance.BorderSize = 0;
            this.btnGoAlpha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoAlpha.Font = new System.Drawing.Font("굴림", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoAlpha.ForeColor = System.Drawing.Color.White;
            this.btnGoAlpha.Location = new System.Drawing.Point(470, 0);
            this.btnGoAlpha.Name = "btnGoAlpha";
            this.btnGoAlpha.Size = new System.Drawing.Size(75, 25);
            this.btnGoAlpha.TabIndex = 32;
            this.btnGoAlpha.Text = "Go Alpha";
            this.btnGoAlpha.UseVisualStyleBackColor = false;
            this.btnGoAlpha.Click += new System.EventHandler(this.btnGoAlpha_Click);
            // 
            // btnGoNaver
            // 
            this.btnGoNaver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGoNaver.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGoNaver.FlatAppearance.BorderSize = 0;
            this.btnGoNaver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoNaver.Font = new System.Drawing.Font("굴림", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoNaver.ForeColor = System.Drawing.Color.White;
            this.btnGoNaver.Location = new System.Drawing.Point(395, 0);
            this.btnGoNaver.Name = "btnGoNaver";
            this.btnGoNaver.Size = new System.Drawing.Size(75, 25);
            this.btnGoNaver.TabIndex = 30;
            this.btnGoNaver.Text = "Go Naver";
            this.btnGoNaver.UseVisualStyleBackColor = false;
            this.btnGoNaver.Click += new System.EventHandler(this.btnGoNaver_Click);
            // 
            // btnDel
            // 
            this.btnDel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(600, 0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(153, 25);
            this.btnDel.TabIndex = 28;
            this.btnDel.Text = "Delete SelectedItem";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // tbSelectedName2
            // 
            // 
            // 
            // 
            this.tbSelectedName2.CustomButton.Image = null;
            this.tbSelectedName2.CustomButton.Location = new System.Drawing.Point(128, 1);
            this.tbSelectedName2.CustomButton.Name = "";
            this.tbSelectedName2.CustomButton.Size = new System.Drawing.Size(16, 15);
            this.tbSelectedName2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSelectedName2.CustomButton.TabIndex = 1;
            this.tbSelectedName2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSelectedName2.CustomButton.UseSelectable = true;
            this.tbSelectedName2.CustomButton.Visible = false;
            this.tbSelectedName2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSelectedName2.Lines = new string[0];
            this.tbSelectedName2.Location = new System.Drawing.Point(188, 0);
            this.tbSelectedName2.MaxLength = 32767;
            this.tbSelectedName2.Name = "tbSelectedName2";
            this.tbSelectedName2.PasswordChar = '\0';
            this.tbSelectedName2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSelectedName2.SelectedText = "";
            this.tbSelectedName2.SelectionLength = 0;
            this.tbSelectedName2.SelectionStart = 0;
            this.tbSelectedName2.ShortcutsEnabled = true;
            this.tbSelectedName2.Size = new System.Drawing.Size(207, 25);
            this.tbSelectedName2.TabIndex = 27;
            this.tbSelectedName2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSelectedName2.UseSelectable = true;
            this.tbSelectedName2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSelectedName2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbSelectedCode2
            // 
            // 
            // 
            // 
            this.tbSelectedCode2.CustomButton.Image = null;
            this.tbSelectedCode2.CustomButton.Location = new System.Drawing.Point(41, 1);
            this.tbSelectedCode2.CustomButton.Name = "";
            this.tbSelectedCode2.CustomButton.Size = new System.Drawing.Size(16, 15);
            this.tbSelectedCode2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSelectedCode2.CustomButton.TabIndex = 1;
            this.tbSelectedCode2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSelectedCode2.CustomButton.UseSelectable = true;
            this.tbSelectedCode2.CustomButton.Visible = false;
            this.tbSelectedCode2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbSelectedCode2.Lines = new string[0];
            this.tbSelectedCode2.Location = new System.Drawing.Point(106, 0);
            this.tbSelectedCode2.MaxLength = 32767;
            this.tbSelectedCode2.Name = "tbSelectedCode2";
            this.tbSelectedCode2.PasswordChar = '\0';
            this.tbSelectedCode2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSelectedCode2.SelectedText = "";
            this.tbSelectedCode2.SelectionLength = 0;
            this.tbSelectedCode2.SelectionStart = 0;
            this.tbSelectedCode2.ShortcutsEnabled = true;
            this.tbSelectedCode2.Size = new System.Drawing.Size(82, 25);
            this.tbSelectedCode2.TabIndex = 26;
            this.tbSelectedCode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSelectedCode2.UseSelectable = true;
            this.tbSelectedCode2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSelectedCode2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.metroLabel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroLabel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.Location = new System.Drawing.Point(0, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(106, 25);
            this.metroLabel5.TabIndex = 25;
            this.metroLabel5.Text = "선택종목";
            this.metroLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // AtmanKRPickItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 725);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AtmanKRPickItemForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "ATMAN INV. F KR PICKED ITEM";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlResultView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftContent.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroPanel pnlLeft;
        private MetroFramework.Controls.MetroPanel pnlLeftContent;
        private MetroFramework.Controls.MetroPanel pnlTitle;
        private MetroFramework.Controls.MetroTextBox tbSelectedName2;
        private MetroFramework.Controls.MetroTextBox tbSelectedCode2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private Vikala.Controls.Charts.ComparedBasicCandleChart chart;
        private MetroFramework.Controls.MetroPanel pnlResultView;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.TextBox tbPickDT;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbReason;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnGoNaver;
        private System.Windows.Forms.Button btnGoAlpha;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종가;
        private System.Windows.Forms.DataGridViewLinkColumn 시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sign;
    }
}