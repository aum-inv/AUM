namespace OM.Upaya.Chakra.App
{
    partial class OrderMITForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderMITForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbOrderPrice = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdoTradeType2 = new System.Windows.Forms.RadioButton();
            this.rdoTradeType1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBuyPrice1 = new System.Windows.Forms.TextBox();
            this.chkIsBuy = new System.Windows.Forms.CheckBox();
            this.tbBuyPrice2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSellPrice2 = new System.Windows.Forms.TextBox();
            this.chkIsSell = new System.Windows.Forms.CheckBox();
            this.tbSellPrice1 = new System.Windows.Forms.TextBox();
            this.btnIII = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIII);
            this.groupBox2.Controls.Add(this.tbItem);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox2.Size = new System.Drawing.Size(120, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상품코드";
            // 
            // tbItem
            // 
            this.tbItem.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbItem.Location = new System.Drawing.Point(7, 24);
            this.tbItem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(62, 25);
            this.tbItem.TabIndex = 0;
            this.tbItem.Text = "CL";
            this.tbItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbItem.TextChanged += new System.EventHandler(this.tbItem_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbQty);
            this.groupBox3.Location = new System.Drawing.Point(139, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox3.Size = new System.Drawing.Size(104, 62);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수량";
            // 
            // tbQty
            // 
            this.tbQty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQty.Location = new System.Drawing.Point(7, 24);
            this.tbQty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(90, 25);
            this.tbQty.TabIndex = 0;
            this.tbQty.Text = "0";
            this.tbQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbQty.TextChanged += new System.EventHandler(this.tbQty_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbOrderPrice);
            this.groupBox5.Location = new System.Drawing.Point(16, 151);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox5.Size = new System.Drawing.Size(227, 60);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "현재가";
            // 
            // tbOrderPrice
            // 
            this.tbOrderPrice.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbOrderPrice.Location = new System.Drawing.Point(7, 24);
            this.tbOrderPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbOrderPrice.Name = "tbOrderPrice";
            this.tbOrderPrice.Size = new System.Drawing.Size(213, 25);
            this.tbOrderPrice.TabIndex = 0;
            this.tbOrderPrice.Text = "000.00";
            this.tbOrderPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdoTradeType2);
            this.groupBox6.Controls.Add(this.rdoTradeType1);
            this.groupBox6.Location = new System.Drawing.Point(16, 89);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox6.Size = new System.Drawing.Size(227, 58);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "주문타입";
            // 
            // rdoTradeType2
            // 
            this.rdoTradeType2.AutoSize = true;
            this.rdoTradeType2.Location = new System.Drawing.Point(129, 25);
            this.rdoTradeType2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoTradeType2.Name = "rdoTradeType2";
            this.rdoTradeType2.Size = new System.Drawing.Size(73, 19);
            this.rdoTradeType2.TabIndex = 1;
            this.rdoTradeType2.Text = "지정가";
            this.rdoTradeType2.UseVisualStyleBackColor = true;
            this.rdoTradeType2.CheckedChanged += new System.EventHandler(this.rdoTradeType2_CheckedChanged);
            // 
            // rdoTradeType1
            // 
            this.rdoTradeType1.AutoSize = true;
            this.rdoTradeType1.Checked = true;
            this.rdoTradeType1.Location = new System.Drawing.Point(11, 25);
            this.rdoTradeType1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoTradeType1.Name = "rdoTradeType1";
            this.rdoTradeType1.Size = new System.Drawing.Size(73, 19);
            this.rdoTradeType1.TabIndex = 0;
            this.rdoTradeType1.TabStop = true;
            this.rdoTradeType1.Text = "시장가";
            this.rdoTradeType1.UseVisualStyleBackColor = true;
            this.rdoTradeType1.CheckedChanged += new System.EventHandler(this.rdoTradeType1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBuyPrice1);
            this.groupBox1.Controls.Add(this.chkIsBuy);
            this.groupBox1.Controls.Add(this.tbBuyPrice2);
            this.groupBox1.Location = new System.Drawing.Point(16, 224);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox1.Size = new System.Drawing.Size(227, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "진입주문";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "매도";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "매수";
            // 
            // tbBuyPrice1
            // 
            this.tbBuyPrice1.Location = new System.Drawing.Point(129, 78);
            this.tbBuyPrice1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBuyPrice1.Name = "tbBuyPrice1";
            this.tbBuyPrice1.Size = new System.Drawing.Size(87, 25);
            this.tbBuyPrice1.TabIndex = 22;
            this.tbBuyPrice1.Text = "0";
            this.tbBuyPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBuyPrice1.TextChanged += new System.EventHandler(this.tbBuyPrice1_TextChanged);
            // 
            // chkIsBuy
            // 
            this.chkIsBuy.AutoSize = true;
            this.chkIsBuy.Location = new System.Drawing.Point(11, 26);
            this.chkIsBuy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsBuy.Name = "chkIsBuy";
            this.chkIsBuy.Size = new System.Drawing.Size(152, 19);
            this.chkIsBuy.TabIndex = 21;
            this.chkIsBuy.Text = "진입주문 MIT 사용";
            this.chkIsBuy.UseVisualStyleBackColor = true;
            this.chkIsBuy.CheckedChanged += new System.EventHandler(this.chkIsBuy_CheckedChanged);
            // 
            // tbBuyPrice2
            // 
            this.tbBuyPrice2.Location = new System.Drawing.Point(10, 78);
            this.tbBuyPrice2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbBuyPrice2.Name = "tbBuyPrice2";
            this.tbBuyPrice2.Size = new System.Drawing.Size(87, 25);
            this.tbBuyPrice2.TabIndex = 0;
            this.tbBuyPrice2.Text = "0";
            this.tbBuyPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBuyPrice2.TextChanged += new System.EventHandler(this.tbBuyPrice2_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbSellPrice2);
            this.groupBox4.Controls.Add(this.chkIsSell);
            this.groupBox4.Controls.Add(this.tbSellPrice1);
            this.groupBox4.Location = new System.Drawing.Point(16, 350);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.groupBox4.Size = new System.Drawing.Size(227, 120);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "청산주문";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "매도포지션";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "매수포지션";
            // 
            // tbSellPrice2
            // 
            this.tbSellPrice2.Location = new System.Drawing.Point(129, 85);
            this.tbSellPrice2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSellPrice2.Name = "tbSellPrice2";
            this.tbSellPrice2.Size = new System.Drawing.Size(87, 25);
            this.tbSellPrice2.TabIndex = 22;
            this.tbSellPrice2.Text = "0";
            this.tbSellPrice2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSellPrice2.TextChanged += new System.EventHandler(this.tbSellPrice2_TextChanged);
            // 
            // chkIsSell
            // 
            this.chkIsSell.AutoSize = true;
            this.chkIsSell.Location = new System.Drawing.Point(11, 26);
            this.chkIsSell.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chkIsSell.Name = "chkIsSell";
            this.chkIsSell.Size = new System.Drawing.Size(152, 19);
            this.chkIsSell.TabIndex = 21;
            this.chkIsSell.Text = "청산주문 MIT 사용";
            this.chkIsSell.UseVisualStyleBackColor = true;
            this.chkIsSell.CheckedChanged += new System.EventHandler(this.chkIsSell_CheckedChanged);
            // 
            // tbSellPrice1
            // 
            this.tbSellPrice1.Location = new System.Drawing.Point(10, 85);
            this.tbSellPrice1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSellPrice1.Name = "tbSellPrice1";
            this.tbSellPrice1.Size = new System.Drawing.Size(87, 25);
            this.tbSellPrice1.TabIndex = 0;
            this.tbSellPrice1.Text = "0";
            this.tbSellPrice1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSellPrice1.TextChanged += new System.EventHandler(this.tbSellPrice1_TextChanged);
            // 
            // btnIII
            // 
            this.btnIII.Location = new System.Drawing.Point(75, 26);
            this.btnIII.Name = "btnIII";
            this.btnIII.Size = new System.Drawing.Size(35, 23);
            this.btnIII.TabIndex = 1;
            this.btnIII.Text = "III";
            this.btnIII.UseVisualStyleBackColor = true;
            this.btnIII.Click += new System.EventHandler(this.btnIII_Click);
            // 
            // OrderMITForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 479);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "OrderMITForm";
            this.Text = "MIT 주문창";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbOrderPrice;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdoTradeType1;
        private System.Windows.Forms.RadioButton rdoTradeType2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsBuy;
        private System.Windows.Forms.TextBox tbBuyPrice2;
        private System.Windows.Forms.TextBox tbBuyPrice1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbSellPrice2;
        private System.Windows.Forms.CheckBox chkIsSell;
        private System.Windows.Forms.TextBox tbSellPrice1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIII;
    }
}