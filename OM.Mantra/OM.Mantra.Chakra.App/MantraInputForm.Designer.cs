
namespace OM.Mantra.Chakra.App
{
    partial class MantraInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantraInputForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tp_BasicInfo = new System.Windows.Forms.TabPage();
            this.tp_Tech1 = new System.Windows.Forms.TabPage();
            this.tp_Risk = new System.Windows.Forms.TabPage();
            this.tp_Tech2 = new System.Windows.Forms.TabPage();
            this.tp_BaseLine = new System.Windows.Forms.TabPage();
            this.tp_Buy = new System.Windows.Forms.TabPage();
            this.tp_Sell = new System.Windows.Forms.TabPage();
            this.tp_TradeSheet = new System.Windows.Forms.TabPage();
            this.tp_Diary = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.panel10 = new System.Windows.Forms.Panel();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(1326, 765);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tcMain);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(2, 44);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(2);
            this.panel6.Size = new System.Drawing.Size(1318, 698);
            this.panel6.TabIndex = 4;
            // 
            // tcMain
            // 
            this.tcMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcMain.Controls.Add(this.tp_BasicInfo);
            this.tcMain.Controls.Add(this.tp_Tech1);
            this.tcMain.Controls.Add(this.tp_Risk);
            this.tcMain.Controls.Add(this.tp_Tech2);
            this.tcMain.Controls.Add(this.tp_BaseLine);
            this.tcMain.Controls.Add(this.tp_Buy);
            this.tcMain.Controls.Add(this.tp_Sell);
            this.tcMain.Controls.Add(this.tp_TradeSheet);
            this.tcMain.Controls.Add(this.tp_Diary);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.ItemSize = new System.Drawing.Size(130, 30);
            this.tcMain.Location = new System.Drawing.Point(2, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1314, 694);
            this.tcMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcMain.TabIndex = 0;
            // 
            // tp_BasicInfo
            // 
            this.tp_BasicInfo.BackColor = System.Drawing.Color.White;
            this.tp_BasicInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_BasicInfo.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tp_BasicInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tp_BasicInfo.Location = new System.Drawing.Point(4, 34);
            this.tp_BasicInfo.Name = "tp_BasicInfo";
            this.tp_BasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tp_BasicInfo.Size = new System.Drawing.Size(1306, 656);
            this.tp_BasicInfo.TabIndex = 0;
            this.tp_BasicInfo.Text = "①단계 - 기본정보";
            this.tp_BasicInfo.UseVisualStyleBackColor = true;
            // 
            // tp_Tech1
            // 
            this.tp_Tech1.BackColor = System.Drawing.Color.White;
            this.tp_Tech1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_Tech1.Location = new System.Drawing.Point(4, 34);
            this.tp_Tech1.Name = "tp_Tech1";
            this.tp_Tech1.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Tech1.Size = new System.Drawing.Size(1306, 656);
            this.tp_Tech1.TabIndex = 1;
            this.tp_Tech1.Text = "②단계 - 기술분석표";
            this.tp_Tech1.UseVisualStyleBackColor = true;
            // 
            // tp_Risk
            // 
            this.tp_Risk.BackColor = System.Drawing.Color.White;
            this.tp_Risk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_Risk.Location = new System.Drawing.Point(4, 34);
            this.tp_Risk.Name = "tp_Risk";
            this.tp_Risk.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Risk.Size = new System.Drawing.Size(1306, 656);
            this.tp_Risk.TabIndex = 3;
            this.tp_Risk.Text = "③단계 - 리스크";
            this.tp_Risk.UseVisualStyleBackColor = true;
            // 
            // tp_Tech2
            // 
            this.tp_Tech2.BackColor = System.Drawing.Color.White;
            this.tp_Tech2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_Tech2.Location = new System.Drawing.Point(4, 34);
            this.tp_Tech2.Name = "tp_Tech2";
            this.tp_Tech2.Size = new System.Drawing.Size(1306, 656);
            this.tp_Tech2.TabIndex = 8;
            this.tp_Tech2.Text = "④단계 - 추세분석";
            this.tp_Tech2.UseVisualStyleBackColor = true;
            // 
            // tp_BaseLine
            // 
            this.tp_BaseLine.BackColor = System.Drawing.Color.White;
            this.tp_BaseLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_BaseLine.Location = new System.Drawing.Point(4, 34);
            this.tp_BaseLine.Name = "tp_BaseLine";
            this.tp_BaseLine.Padding = new System.Windows.Forms.Padding(3);
            this.tp_BaseLine.Size = new System.Drawing.Size(1306, 656);
            this.tp_BaseLine.TabIndex = 2;
            this.tp_BaseLine.Text = "⑤단계 - 베이스라인";
            this.tp_BaseLine.UseVisualStyleBackColor = true;
            // 
            // tp_Buy
            // 
            this.tp_Buy.BackColor = System.Drawing.Color.White;
            this.tp_Buy.Location = new System.Drawing.Point(4, 34);
            this.tp_Buy.Name = "tp_Buy";
            this.tp_Buy.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Buy.Size = new System.Drawing.Size(1306, 656);
            this.tp_Buy.TabIndex = 4;
            this.tp_Buy.Text = "⑥단계 - 진입계획";
            this.tp_Buy.UseVisualStyleBackColor = true;
            // 
            // tp_Sell
            // 
            this.tp_Sell.BackColor = System.Drawing.Color.White;
            this.tp_Sell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_Sell.Location = new System.Drawing.Point(4, 34);
            this.tp_Sell.Name = "tp_Sell";
            this.tp_Sell.Size = new System.Drawing.Size(1306, 656);
            this.tp_Sell.TabIndex = 5;
            this.tp_Sell.Text = "⑦단계 - 청산계획";
            this.tp_Sell.UseVisualStyleBackColor = true;
            // 
            // tp_TradeSheet
            // 
            this.tp_TradeSheet.BackColor = System.Drawing.Color.White;
            this.tp_TradeSheet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_TradeSheet.Location = new System.Drawing.Point(4, 34);
            this.tp_TradeSheet.Name = "tp_TradeSheet";
            this.tp_TradeSheet.Size = new System.Drawing.Size(1306, 656);
            this.tp_TradeSheet.TabIndex = 6;
            this.tp_TradeSheet.Text = "⑧단계 - 거래시트";
            this.tp_TradeSheet.UseVisualStyleBackColor = true;
            // 
            // tp_Diary
            // 
            this.tp_Diary.BackColor = System.Drawing.Color.White;
            this.tp_Diary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_Diary.Location = new System.Drawing.Point(4, 34);
            this.tp_Diary.Name = "tp_Diary";
            this.tp_Diary.Size = new System.Drawing.Size(1306, 656);
            this.tp_Diary.TabIndex = 7;
            this.tp_Diary.Text = "⑨단계 - 거래일지";
            this.tp_Diary.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(2, 742);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1318, 5);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(2, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1318, 5);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(2, 747);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(1318, 12);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.metroTile1);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.metroTile2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(1318, 37);
            this.panel2.TabIndex = 0;
            // 
            // metroTile2
            // 
            this.metroTile2.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroTile2.Location = new System.Drawing.Point(1122, 2);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(192, 31);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Black;
            this.metroTile2.TabIndex = 36;
            this.metroTile2.Text = "삭제하기";
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel10.Location = new System.Drawing.Point(1117, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(5, 31);
            this.panel10.TabIndex = 37;
            // 
            // metroTile1
            // 
            this.metroTile1.Dock = System.Windows.Forms.DockStyle.Right;
            this.metroTile1.Location = new System.Drawing.Point(925, 2);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(192, 31);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile1.TabIndex = 38;
            this.metroTile1.Text = "복제하기";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            // 
            // MantraInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 845);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MantraInputForm";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "ATMAN INV. F STRATEGY INSTRUMNENT OF MIND";
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tp_BasicInfo;
        private System.Windows.Forms.TabPage tp_Tech1;
        private System.Windows.Forms.TabPage tp_BaseLine;
        private System.Windows.Forms.TabPage tp_Risk;
        private System.Windows.Forms.TabPage tp_Buy;
        private System.Windows.Forms.TabPage tp_Tech2;
        private System.Windows.Forms.TabPage tp_Sell;
        private System.Windows.Forms.TabPage tp_TradeSheet;
        private System.Windows.Forms.TabPage tp_Diary;
        private MetroFramework.Controls.MetroTile metroTile2;
        private System.Windows.Forms.Panel panel10;
        private MetroFramework.Controls.MetroTile metroTile1;
    }
}