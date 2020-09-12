namespace OM.Atman.Chakra.App.Uc.Calculators
{
    partial class Uc_QuantityCalculator
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lbQuantity = new MetroFramework.Controls.MetroLabel();
            this.btnCopy = new System.Windows.Forms.Button();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbQuantity = new MetroFramework.Controls.MetroTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.nudRate = new System.Windows.Forms.NumericUpDown();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.lbMoney = new MetroFramework.Controls.MetroLabel();
            this.nudFund = new System.Windows.Forms.NumericUpDown();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.lbQuantity2 = new MetroFramework.Controls.MetroLabel();
            this.btnCopy2 = new System.Windows.Forms.Button();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.tbQuantity2 = new MetroFramework.Controls.MetroTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.nudRate2 = new System.Windows.Forms.NumericUpDown();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.nudQuantity2 = new System.Windows.Forms.NumericUpDown();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFund)).BeginInit();
            this.metroPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity2)).BeginInit();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.lbQuantity);
            this.metroPanel1.Controls.Add(this.btnCopy);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.tbQuantity);
            this.metroPanel1.Controls.Add(this.panel1);
            this.metroPanel1.Controls.Add(this.nudPrice);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.nudRate);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.lbMoney);
            this.metroPanel1.Controls.Add(this.nudFund);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(182, 301);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lbQuantity
            // 
            this.lbQuantity.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lbQuantity.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbQuantity.ForeColor = System.Drawing.Color.Magenta;
            this.lbQuantity.Location = new System.Drawing.Point(4, 276);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(171, 19);
            this.lbQuantity.TabIndex = 13;
            this.lbQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbQuantity.UseCustomBackColor = true;
            this.lbQuantity.UseCustomForeColor = true;
            this.lbQuantity.UseStyleColors = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(142, 226);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(33, 23);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "..";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(4, 230);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(55, 15);
            this.metroLabel5.TabIndex = 12;
            this.metroLabel5.Text = "매수수량";
            // 
            // tbQuantity
            // 
            // 
            // 
            // 
            this.tbQuantity.CustomButton.Image = null;
            this.tbQuantity.CustomButton.Location = new System.Drawing.Point(149, 1);
            this.tbQuantity.CustomButton.Name = "";
            this.tbQuantity.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbQuantity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbQuantity.CustomButton.TabIndex = 1;
            this.tbQuantity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbQuantity.CustomButton.UseSelectable = true;
            this.tbQuantity.CustomButton.Visible = false;
            this.tbQuantity.Lines = new string[] {
        "0"};
            this.tbQuantity.Location = new System.Drawing.Point(4, 250);
            this.tbQuantity.MaxLength = 32767;
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.PasswordChar = '\0';
            this.tbQuantity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbQuantity.SelectedText = "";
            this.tbQuantity.SelectionLength = 0;
            this.tbQuantity.SelectionStart = 0;
            this.tbQuantity.ShortcutsEnabled = true;
            this.tbQuantity.Size = new System.Drawing.Size(171, 23);
            this.tbQuantity.TabIndex = 4;
            this.tbQuantity.Text = "0";
            this.tbQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbQuantity.UseSelectable = true;
            this.tbQuantity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbQuantity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(4, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 3);
            this.panel1.TabIndex = 10;
            // 
            // nudPrice
            // 
            this.nudPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPrice.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudPrice.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPrice.Location = new System.Drawing.Point(4, 173);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(171, 26);
            this.nudPrice.TabIndex = 3;
            this.nudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrice.ValueChanged += new System.EventHandler(this.nudPrice_ValueChanged);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(4, 150);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(70, 15);
            this.metroLabel3.TabIndex = 8;
            this.metroLabel3.Text = "종목 현재가";
            // 
            // nudRate
            // 
            this.nudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudRate.DecimalPlaces = 2;
            this.nudRate.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRate.Location = new System.Drawing.Point(4, 109);
            this.nudRate.Name = "nudRate";
            this.nudRate.Size = new System.Drawing.Size(171, 26);
            this.nudRate.TabIndex = 2;
            this.nudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRate.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRate.ValueChanged += new System.EventHandler(this.nudRate_ValueChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(4, 86);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(88, 15);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "투자금 비율(%)";
            // 
            // lbMoney
            // 
            this.lbMoney.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lbMoney.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbMoney.ForeColor = System.Drawing.Color.Magenta;
            this.lbMoney.Location = new System.Drawing.Point(4, 56);
            this.lbMoney.Name = "lbMoney";
            this.lbMoney.Size = new System.Drawing.Size(171, 19);
            this.lbMoney.TabIndex = 5;
            this.lbMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbMoney.UseCustomBackColor = true;
            this.lbMoney.UseCustomForeColor = true;
            this.lbMoney.UseStyleColors = true;
            // 
            // nudFund
            // 
            this.nudFund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudFund.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudFund.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudFund.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudFund.Location = new System.Drawing.Point(4, 27);
            this.nudFund.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudFund.Name = "nudFund";
            this.nudFund.Size = new System.Drawing.Size(171, 26);
            this.nudFund.TabIndex = 1;
            this.nudFund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudFund.ValueChanged += new System.EventHandler(this.nudFund_ValueChanged);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(4, 4);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(55, 15);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "투자금액";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.lbQuantity2);
            this.metroPanel2.Controls.Add(this.btnCopy2);
            this.metroPanel2.Controls.Add(this.metroLabel6);
            this.metroPanel2.Controls.Add(this.tbQuantity2);
            this.metroPanel2.Controls.Add(this.panel2);
            this.metroPanel2.Controls.Add(this.nudRate2);
            this.metroPanel2.Controls.Add(this.metroLabel8);
            this.metroPanel2.Controls.Add(this.nudQuantity2);
            this.metroPanel2.Controls.Add(this.metroLabel10);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(201, 3);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(182, 301);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // lbQuantity2
            // 
            this.lbQuantity2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lbQuantity2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lbQuantity2.ForeColor = System.Drawing.Color.Magenta;
            this.lbQuantity2.Location = new System.Drawing.Point(4, 276);
            this.lbQuantity2.Name = "lbQuantity2";
            this.lbQuantity2.Size = new System.Drawing.Size(171, 19);
            this.lbQuantity2.TabIndex = 13;
            this.lbQuantity2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbQuantity2.UseCustomBackColor = true;
            this.lbQuantity2.UseCustomForeColor = true;
            this.lbQuantity2.UseStyleColors = true;
            // 
            // btnCopy2
            // 
            this.btnCopy2.Location = new System.Drawing.Point(142, 226);
            this.btnCopy2.Name = "btnCopy2";
            this.btnCopy2.Size = new System.Drawing.Size(33, 23);
            this.btnCopy2.TabIndex = 5;
            this.btnCopy2.Text = "..";
            this.btnCopy2.UseVisualStyleBackColor = true;
            this.btnCopy2.Click += new System.EventHandler(this.btnCopy2_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(4, 230);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(55, 15);
            this.metroLabel6.TabIndex = 12;
            this.metroLabel6.Text = "매도수량";
            // 
            // tbQuantity2
            // 
            // 
            // 
            // 
            this.tbQuantity2.CustomButton.Image = null;
            this.tbQuantity2.CustomButton.Location = new System.Drawing.Point(149, 1);
            this.tbQuantity2.CustomButton.Name = "";
            this.tbQuantity2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbQuantity2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbQuantity2.CustomButton.TabIndex = 1;
            this.tbQuantity2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbQuantity2.CustomButton.UseSelectable = true;
            this.tbQuantity2.CustomButton.Visible = false;
            this.tbQuantity2.Lines = new string[] {
        "0"};
            this.tbQuantity2.Location = new System.Drawing.Point(4, 250);
            this.tbQuantity2.MaxLength = 32767;
            this.tbQuantity2.Name = "tbQuantity2";
            this.tbQuantity2.PasswordChar = '\0';
            this.tbQuantity2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbQuantity2.SelectedText = "";
            this.tbQuantity2.SelectionLength = 0;
            this.tbQuantity2.SelectionStart = 0;
            this.tbQuantity2.ShortcutsEnabled = true;
            this.tbQuantity2.Size = new System.Drawing.Size(171, 23);
            this.tbQuantity2.TabIndex = 4;
            this.tbQuantity2.Text = "0";
            this.tbQuantity2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbQuantity2.UseSelectable = true;
            this.tbQuantity2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbQuantity2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(4, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 3);
            this.panel2.TabIndex = 10;
            // 
            // nudRate2
            // 
            this.nudRate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudRate2.DecimalPlaces = 2;
            this.nudRate2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudRate2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudRate2.Location = new System.Drawing.Point(4, 109);
            this.nudRate2.Name = "nudRate2";
            this.nudRate2.Size = new System.Drawing.Size(171, 26);
            this.nudRate2.TabIndex = 2;
            this.nudRate2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRate2.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudRate2.ValueChanged += new System.EventHandler(this.nudRate2_ValueChanged);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel8.Location = new System.Drawing.Point(4, 86);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(58, 15);
            this.metroLabel8.TabIndex = 6;
            this.metroLabel8.Text = "매도 비율";
            // 
            // nudQuantity2
            // 
            this.nudQuantity2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudQuantity2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nudQuantity2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.nudQuantity2.Increment = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantity2.Location = new System.Drawing.Point(4, 27);
            this.nudQuantity2.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudQuantity2.Name = "nudQuantity2";
            this.nudQuantity2.Size = new System.Drawing.Size(171, 26);
            this.nudQuantity2.TabIndex = 1;
            this.nudQuantity2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudQuantity2.ValueChanged += new System.EventHandler(this.nudQuantity2_ValueChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel10.Location = new System.Drawing.Point(4, 4);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(55, 15);
            this.metroLabel10.TabIndex = 3;
            this.metroLabel10.Text = "잔고수량";
            // 
            // Uc_QuantityCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "Uc_QuantityCalculator";
            this.Size = new System.Drawing.Size(387, 309);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFund)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.NumericUpDown nudFund;
        private MetroFramework.Controls.MetroLabel lbMoney;
        private System.Windows.Forms.NumericUpDown nudRate;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox tbQuantity;
        private System.Windows.Forms.Button btnCopy;
        private MetroFramework.Controls.MetroLabel lbQuantity;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel lbQuantity2;
        private System.Windows.Forms.Button btnCopy2;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox tbQuantity2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudRate2;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.NumericUpDown nudQuantity2;
        private MetroFramework.Controls.MetroLabel metroLabel10;
    }
}
