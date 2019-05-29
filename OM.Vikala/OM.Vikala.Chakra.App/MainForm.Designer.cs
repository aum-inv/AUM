﻿namespace OM.Vikala.Chakra.App
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCandle1 = new System.Windows.Forms.Button();
            this.btnLine1 = new System.Windows.Forms.Button();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button14 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnThaChi = new System.Windows.Forms.Button();
            this.btnFiveColor = new System.Windows.Forms.Button();
            this.btnSampleAtom = new System.Windows.Forms.Button();
            this.btnSampleCandle = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnVelocity = new System.Windows.Forms.Button();
            this.btnQuantum = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCandle1);
            this.panel1.Controls.Add(this.btnLine1);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 43);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(187, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // btnCandle1
            // 
            this.btnCandle1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCandle1.Location = new System.Drawing.Point(380, 0);
            this.btnCandle1.Margin = new System.Windows.Forms.Padding(2);
            this.btnCandle1.Name = "btnCandle1";
            this.btnCandle1.Size = new System.Drawing.Size(111, 43);
            this.btnCandle1.TabIndex = 2;
            this.btnCandle1.Text = "ShowCandleChart";
            this.btnCandle1.UseVisualStyleBackColor = true;
            this.btnCandle1.Click += new System.EventHandler(this.btnCandle1_Click);
            // 
            // btnLine1
            // 
            this.btnLine1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnLine1.Location = new System.Drawing.Point(491, 0);
            this.btnLine1.Margin = new System.Windows.Forms.Padding(2);
            this.btnLine1.Name = "btnLine1";
            this.btnLine1.Size = new System.Drawing.Size(91, 43);
            this.btnLine1.TabIndex = 1;
            this.btnLine1.Text = "ShowLineChart";
            this.btnLine1.UseVisualStyleBackColor = true;
            this.btnLine1.Click += new System.EventHandler(this.btnLine1_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadData.Location = new System.Drawing.Point(0, 0);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(80, 43);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "LoadData";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button14);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.btnReverse);
            this.panel2.Controls.Add(this.btnThaChi);
            this.panel2.Controls.Add(this.btnFiveColor);
            this.panel2.Controls.Add(this.btnSampleAtom);
            this.panel2.Controls.Add(this.btnSampleCandle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 47);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 43);
            this.panel2.TabIndex = 1;
            // 
            // button14
            // 
            this.button14.Dock = System.Windows.Forms.DockStyle.Right;
            this.button14.Location = new System.Drawing.Point(64, 0);
            this.button14.Margin = new System.Windows.Forms.Padding(2);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(53, 43);
            this.button14.TabIndex = 12;
            this.button14.Text = "Sample Shakra";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click_1);
            // 
            // button12
            // 
            this.button12.Dock = System.Windows.Forms.DockStyle.Right;
            this.button12.Location = new System.Drawing.Point(117, 0);
            this.button12.Margin = new System.Windows.Forms.Padding(2);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(53, 43);
            this.button12.TabIndex = 11;
            this.button12.Text = "Sample Prime";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Right;
            this.button8.Location = new System.Drawing.Point(170, 0);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(53, 43);
            this.button8.TabIndex = 10;
            this.button8.Text = "Sample Mirror";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Right;
            this.button7.Location = new System.Drawing.Point(223, 0);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(53, 43);
            this.button7.TabIndex = 9;
            this.button7.Text = "Sample WuXing";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReverse.Location = new System.Drawing.Point(276, 0);
            this.btnReverse.Margin = new System.Windows.Forms.Padding(2);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(57, 43);
            this.btnReverse.TabIndex = 8;
            this.btnReverse.Text = "Sample Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnThaChi
            // 
            this.btnThaChi.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnThaChi.Location = new System.Drawing.Point(333, 0);
            this.btnThaChi.Margin = new System.Windows.Forms.Padding(2);
            this.btnThaChi.Name = "btnThaChi";
            this.btnThaChi.Size = new System.Drawing.Size(53, 43);
            this.btnThaChi.TabIndex = 7;
            this.btnThaChi.Text = "Sample ThaChi";
            this.btnThaChi.UseVisualStyleBackColor = true;
            this.btnThaChi.Click += new System.EventHandler(this.btnThaChi_Click);
            // 
            // btnFiveColor
            // 
            this.btnFiveColor.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFiveColor.Location = new System.Drawing.Point(386, 0);
            this.btnFiveColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiveColor.Name = "btnFiveColor";
            this.btnFiveColor.Size = new System.Drawing.Size(66, 43);
            this.btnFiveColor.TabIndex = 6;
            this.btnFiveColor.Text = "Sample FiveColor";
            this.btnFiveColor.UseVisualStyleBackColor = true;
            this.btnFiveColor.Click += new System.EventHandler(this.btnFiveColor_Click);
            // 
            // btnSampleAtom
            // 
            this.btnSampleAtom.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSampleAtom.Location = new System.Drawing.Point(452, 0);
            this.btnSampleAtom.Margin = new System.Windows.Forms.Padding(2);
            this.btnSampleAtom.Name = "btnSampleAtom";
            this.btnSampleAtom.Size = new System.Drawing.Size(68, 43);
            this.btnSampleAtom.TabIndex = 4;
            this.btnSampleAtom.Text = "Sample Atom";
            this.btnSampleAtom.UseVisualStyleBackColor = true;
            this.btnSampleAtom.Click += new System.EventHandler(this.btnSampleAtom_Click);
            // 
            // btnSampleCandle
            // 
            this.btnSampleCandle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSampleCandle.Location = new System.Drawing.Point(520, 0);
            this.btnSampleCandle.Margin = new System.Windows.Forms.Padding(2);
            this.btnSampleCandle.Name = "btnSampleCandle";
            this.btnSampleCandle.Size = new System.Drawing.Size(62, 43);
            this.btnSampleCandle.TabIndex = 3;
            this.btnSampleCandle.Text = "Sample Candle";
            this.btnSampleCandle.UseVisualStyleBackColor = true;
            this.btnSampleCandle.Click += new System.EventHandler(this.btnSampleCandle_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 176);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(582, 43);
            this.panel3.TabIndex = 2;
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Right;
            this.button9.Location = new System.Drawing.Point(299, 0);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 43);
            this.button9.TabIndex = 5;
            this.button9.Text = "MainForm";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Location = new System.Drawing.Point(394, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "SingleChartForm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Right;
            this.button6.Location = new System.Drawing.Point(491, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(91, 43);
            this.button6.TabIndex = 3;
            this.button6.Text = "BasicMainForm";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnVelocity);
            this.panel4.Controls.Add(this.btnQuantum);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 133);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(582, 43);
            this.panel4.TabIndex = 3;
            // 
            // btnVelocity
            // 
            this.btnVelocity.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnVelocity.Location = new System.Drawing.Point(368, 0);
            this.btnVelocity.Margin = new System.Windows.Forms.Padding(2);
            this.btnVelocity.Name = "btnVelocity";
            this.btnVelocity.Size = new System.Drawing.Size(107, 43);
            this.btnVelocity.TabIndex = 9;
            this.btnVelocity.Text = "Sample Velociy";
            this.btnVelocity.UseVisualStyleBackColor = true;
            this.btnVelocity.Click += new System.EventHandler(this.btnVelocity_Click);
            // 
            // btnQuantum
            // 
            this.btnQuantum.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuantum.Location = new System.Drawing.Point(475, 0);
            this.btnQuantum.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuantum.Name = "btnQuantum";
            this.btnQuantum.Size = new System.Drawing.Size(107, 43);
            this.btnQuantum.TabIndex = 8;
            this.btnQuantum.Text = "Sample Quantum";
            this.btnQuantum.UseVisualStyleBackColor = true;
            this.btnQuantum.Click += new System.EventHandler(this.btnQuantum_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button13);
            this.panel5.Controls.Add(this.button11);
            this.panel5.Controls.Add(this.button5);
            this.panel5.Controls.Add(this.button4);
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 90);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(582, 43);
            this.panel5.TabIndex = 4;
            // 
            // button13
            // 
            this.button13.Dock = System.Windows.Forms.DockStyle.Right;
            this.button13.Location = new System.Drawing.Point(166, 0);
            this.button13.Margin = new System.Windows.Forms.Padding(2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(66, 43);
            this.button13.TabIndex = 13;
            this.button13.Text = "쿼크";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button11
            // 
            this.button11.Dock = System.Windows.Forms.DockStyle.Right;
            this.button11.Location = new System.Drawing.Point(232, 0);
            this.button11.Margin = new System.Windows.Forms.Padding(2);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(66, 43);
            this.button11.TabIndex = 12;
            this.button11.Text = "천지인";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Right;
            this.button5.Location = new System.Drawing.Point(298, 0);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 43);
            this.button5.TabIndex = 11;
            this.button5.Text = "음양오행";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Right;
            this.button4.Location = new System.Drawing.Point(364, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 43);
            this.button4.TabIndex = 10;
            this.button4.Text = "삼양삼음";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.button2.Location = new System.Drawing.Point(430, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "진동주파수";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(516, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 43);
            this.button3.TabIndex = 8;
            this.button3.Text = "삼태극";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 218);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Text = "메인폼";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnLine1;
        private System.Windows.Forms.Button btnCandle1;
        private System.Windows.Forms.Button btnSampleCandle;
        private System.Windows.Forms.Button btnSampleAtom;
        private System.Windows.Forms.Button btnFiveColor;
        private System.Windows.Forms.Button btnThaChi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnVelocity;
        private System.Windows.Forms.Button btnQuantum;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label1;
    }
}

