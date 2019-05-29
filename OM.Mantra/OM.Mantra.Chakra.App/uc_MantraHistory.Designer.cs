namespace OM.Mantra.Chakra.App
{
    partial class uc_MantraHistory
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.cbBuySell = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbReason = new System.Windows.Forms.TextBox();
            this.gpIncomingType = new System.Windows.Forms.GroupBox();
            this.cbIncomingType = new System.Windows.Forms.ComboBox();
            this.gpIncoming = new System.Windows.Forms.GroupBox();
            this.tbIncoming = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gpIncomingType.SuspendLayout();
            this.gpIncoming.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbItem);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(84, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상품(종목)";
            // 
            // tbItem
            // 
            this.tbItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbItem.Location = new System.Drawing.Point(4, 16);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(76, 20);
            this.tbItem.TabIndex = 0;
            this.tbItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbTime);
            this.groupBox2.Location = new System.Drawing.Point(352, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(148, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "거래시간";
            // 
            // tbTime
            // 
            this.tbTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTime.Location = new System.Drawing.Point(4, 16);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(140, 20);
            this.tbTime.TabIndex = 3;
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbQuantity);
            this.groupBox3.Controls.Add(this.tbPrice);
            this.groupBox3.Location = new System.Drawing.Point(223, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(124, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "가격 & 수량";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbQuantity.Location = new System.Drawing.Point(78, 16);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(42, 20);
            this.tbQuantity.TabIndex = 2;
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPrice
            // 
            this.tbPrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPrice.Location = new System.Drawing.Point(4, 16);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(68, 20);
            this.tbPrice.TabIndex = 1;
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbPosition);
            this.groupBox4.Controls.Add(this.cbBuySell);
            this.groupBox4.Location = new System.Drawing.Point(94, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(125, 49);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "진입청산 & 포지션";
            // 
            // cbPosition
            // 
            this.cbPosition.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Items.AddRange(new object[] {
            "매수",
            "매도"});
            this.cbPosition.Location = new System.Drawing.Point(69, 16);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(52, 21);
            this.cbPosition.TabIndex = 1;
            // 
            // cbBuySell
            // 
            this.cbBuySell.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbBuySell.FormattingEnabled = true;
            this.cbBuySell.Items.AddRange(new object[] {
            "진입",
            "청산"});
            this.cbBuySell.Location = new System.Drawing.Point(4, 16);
            this.cbBuySell.Name = "cbBuySell";
            this.cbBuySell.Size = new System.Drawing.Size(59, 21);
            this.cbBuySell.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbReason);
            this.groupBox5.Location = new System.Drawing.Point(3, 59);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox5.Size = new System.Drawing.Size(497, 66);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "진입청산 이유";
            // 
            // tbReason
            // 
            this.tbReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbReason.Location = new System.Drawing.Point(4, 16);
            this.tbReason.Multiline = true;
            this.tbReason.Name = "tbReason";
            this.tbReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbReason.Size = new System.Drawing.Size(489, 47);
            this.tbReason.TabIndex = 4;
            // 
            // gpIncomingType
            // 
            this.gpIncomingType.Controls.Add(this.cbIncomingType);
            this.gpIncomingType.Location = new System.Drawing.Point(506, 3);
            this.gpIncomingType.Name = "gpIncomingType";
            this.gpIncomingType.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpIncomingType.Size = new System.Drawing.Size(71, 49);
            this.gpIncomingType.TabIndex = 5;
            this.gpIncomingType.TabStop = false;
            this.gpIncomingType.Text = "수익손실";
            // 
            // cbIncomingType
            // 
            this.cbIncomingType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbIncomingType.FormattingEnabled = true;
            this.cbIncomingType.Items.AddRange(new object[] {
            "수익",
            "손실",
            "본전"});
            this.cbIncomingType.Location = new System.Drawing.Point(4, 16);
            this.cbIncomingType.Name = "cbIncomingType";
            this.cbIncomingType.Size = new System.Drawing.Size(63, 21);
            this.cbIncomingType.TabIndex = 2;
            // 
            // gpIncoming
            // 
            this.gpIncoming.Controls.Add(this.tbIncoming);
            this.gpIncoming.Location = new System.Drawing.Point(579, 3);
            this.gpIncoming.Name = "gpIncoming";
            this.gpIncoming.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gpIncoming.Size = new System.Drawing.Size(94, 49);
            this.gpIncoming.TabIndex = 6;
            this.gpIncoming.TabStop = false;
            this.gpIncoming.Text = "수익손실금액";
            // 
            // tbIncoming
            // 
            this.tbIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIncoming.Location = new System.Drawing.Point(4, 16);
            this.tbIncoming.Name = "tbIncoming";
            this.tbIncoming.Size = new System.Drawing.Size(86, 20);
            this.tbIncoming.TabIndex = 4;
            this.tbIncoming.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReg
            // 
            this.btnReg.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Location = new System.Drawing.Point(506, 59);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(83, 31);
            this.btnReg.TabIndex = 7;
            this.btnReg.Text = "등 록";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Location = new System.Drawing.Point(590, 96);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(83, 29);
            this.btnDel.TabIndex = 8;
            this.btnDel.Text = "삭 제";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnUpd
            // 
            this.btnUpd.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnUpd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpd.Location = new System.Drawing.Point(590, 59);
            this.btnUpd.Name = "btnUpd";
            this.btnUpd.Size = new System.Drawing.Size(83, 31);
            this.btnUpd.TabIndex = 9;
            this.btnUpd.Text = "수 정";
            this.btnUpd.UseVisualStyleBackColor = true;
            this.btnUpd.Click += new System.EventHandler(this.btnUpd_Click);
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(506, 96);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 29);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "리 셋";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // uc_MantraHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnUpd);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.gpIncoming);
            this.Controls.Add(this.gpIncomingType);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "uc_MantraHistory";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.Size = new System.Drawing.Size(678, 129);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gpIncomingType.ResumeLayout(false);
            this.gpIncoming.ResumeLayout(false);
            this.gpIncoming.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox gpIncomingType;
        private System.Windows.Forms.GroupBox gpIncoming;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnUpd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.ComboBox cbBuySell;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbIncoming;
        private System.Windows.Forms.ComboBox cbIncomingType;
        private System.Windows.Forms.TextBox tbReason;
    }
}
