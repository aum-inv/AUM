namespace OM.Atman.Chakra.App.PlanForms
{
    partial class AtmanStrategyPlanForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmanStrategyPlanForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.상품 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.예상기간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.예상수익 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.예상손실 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.등록일 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.상태 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Blank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.수정 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.삭제 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(464, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(47, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "새 항목 선택";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.miniToolStrip.Location = new System.Drawing.Point(1, 41);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.miniToolStrip.Size = new System.Drawing.Size(863, 42);
            this.miniToolStrip.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(974, 511);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.metroButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 61);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 66);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.panel3.Size = new System.Drawing.Size(962, 438);
            this.panel3.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("나눔고딕코딩", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv.ColumnHeadersHeight = 30;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.상품,
            this.종목,
            this.예상기간,
            this.예상수익,
            this.예상손실,
            this.등록일,
            this.상태,
            this._Blank,
            this.수정,
            this.삭제});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(2, 5);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(958, 431);
            this.dgv.TabIndex = 0;
            // 
            // 상품
            // 
            this.상품.Frozen = true;
            this.상품.HeaderText = "상품";
            this.상품.Name = "상품";
            this.상품.ReadOnly = true;
            // 
            // 종목
            // 
            this.종목.Frozen = true;
            this.종목.HeaderText = "종목";
            this.종목.Name = "종목";
            this.종목.ReadOnly = true;
            // 
            // 예상기간
            // 
            this.예상기간.Frozen = true;
            this.예상기간.HeaderText = "예상기간";
            this.예상기간.Name = "예상기간";
            this.예상기간.ReadOnly = true;
            // 
            // 예상수익
            // 
            this.예상수익.Frozen = true;
            this.예상수익.HeaderText = "예상수익";
            this.예상수익.Name = "예상수익";
            this.예상수익.ReadOnly = true;
            // 
            // 예상손실
            // 
            this.예상손실.Frozen = true;
            this.예상손실.HeaderText = "예상손실";
            this.예상손실.Name = "예상손실";
            this.예상손실.ReadOnly = true;
            // 
            // 등록일
            // 
            this.등록일.Frozen = true;
            this.등록일.HeaderText = "등록일";
            this.등록일.Name = "등록일";
            this.등록일.ReadOnly = true;
            this.등록일.Width = 120;
            // 
            // 상태
            // 
            this.상태.Frozen = true;
            this.상태.HeaderText = "상태";
            this.상태.Name = "상태";
            this.상태.ReadOnly = true;
            // 
            // _Blank
            // 
            this._Blank.Frozen = true;
            this._Blank.HeaderText = "";
            this._Blank.Name = "_Blank";
            this._Blank.ReadOnly = true;
            this._Blank.Width = 5;
            // 
            // 수정
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.수정.DefaultCellStyle = dataGridViewCellStyle14;
            this.수정.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.수정.Frozen = true;
            this.수정.HeaderText = "수정";
            this.수정.Name = "수정";
            this.수정.ReadOnly = true;
            // 
            // 삭제
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.삭제.DefaultCellStyle = dataGridViewCellStyle15;
            this.삭제.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.삭제.Frozen = true;
            this.삭제.HeaderText = "삭제";
            this.삭제.Name = "삭제";
            this.삭제.ReadOnly = true;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(826, 3);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(133, 52);
            this.metroButton1.TabIndex = 0;
            this.metroButton1.Text = "CREATE PLAN";
            this.metroButton1.UseSelectable = true;
            // 
            // AtmanStrategyPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 591);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AtmanStrategyPlanForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Black;
            this.Text = "ATMAN INV. F STRATEGY PLAN && RESULT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상품;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목;
        private System.Windows.Forms.DataGridViewTextBoxColumn 예상기간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 예상수익;
        private System.Windows.Forms.DataGridViewTextBoxColumn 예상손실;
        private System.Windows.Forms.DataGridViewTextBoxColumn 등록일;
        private System.Windows.Forms.DataGridViewTextBoxColumn 상태;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Blank;
        private System.Windows.Forms.DataGridViewButtonColumn 수정;
        private System.Windows.Forms.DataGridViewButtonColumn 삭제;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}