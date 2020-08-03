﻿namespace OM.Vikala.Chakra.App
{
    partial class ReverseCandleMainForm_Sample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReverseCandleMainForm_Sample));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chartRS3 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chartRS2 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chartRS4 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chartRS1 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbDT_E = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.tbDT_E);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadData.Location = new System.Drawing.Point(0, 0);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(133, 30);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "LoadData";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1327, 702);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1327, 702);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.chartRS3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chartRS2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chartRS4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chartRS1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1321, 696);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chartRS3
            // 
            this.chartRS3.ChartData = null;
            this.chartRS3.ChartEventInstance = null;
            this.chartRS3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRS3.IsAutoScrollX = false;
            this.chartRS3.IsLoaded = false;
            this.chartRS3.ItemCode = "";
            this.chartRS3.Location = new System.Drawing.Point(8, 354);
            this.chartRS3.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartRS3.DisplayPointCount = 30;
            this.chartRS3.Name = "chartRS3";
            this.chartRS3.ReverseChartData = null;
            this.chartRS3.Size = new System.Drawing.Size(644, 336);
            this.chartRS3.TabIndex = 6;
            this.chartRS3.Title = null;
            // 
            // chartRS2
            // 
            this.chartRS2.ChartData = null;
            this.chartRS2.ChartEventInstance = null;
            this.chartRS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRS2.IsAutoScrollX = false;
            this.chartRS2.IsLoaded = false;
            this.chartRS2.ItemCode = "";
            this.chartRS2.Location = new System.Drawing.Point(668, 6);
            this.chartRS2.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartRS2.DisplayPointCount = 30;
            this.chartRS2.Name = "chartRS2";
            this.chartRS2.ReverseChartData = null;
            this.chartRS2.Size = new System.Drawing.Size(645, 336);
            this.chartRS2.TabIndex = 5;
            this.chartRS2.Title = null;
            // 
            // chartRS4
            // 
            this.chartRS4.ChartData = null;
            this.chartRS4.ChartEventInstance = null;
            this.chartRS4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRS4.IsAutoScrollX = false;
            this.chartRS4.IsLoaded = false;
            this.chartRS4.ItemCode = "";
            this.chartRS4.Location = new System.Drawing.Point(668, 354);
            this.chartRS4.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartRS4.DisplayPointCount = 30;
            this.chartRS4.Name = "chartRS4";
            this.chartRS4.ReverseChartData = null;
            this.chartRS4.Size = new System.Drawing.Size(645, 336);
            this.chartRS4.TabIndex = 4;
            this.chartRS4.Title = null;
            // 
            // chartRS1
            // 
            this.chartRS1.ChartData = null;
            this.chartRS1.ChartEventInstance = null;
            this.chartRS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRS1.IsAutoScrollX = false;
            this.chartRS1.IsLoaded = false;
            this.chartRS1.ItemCode = "";
            this.chartRS1.Location = new System.Drawing.Point(8, 6);
            this.chartRS1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartRS1.DisplayPointCount = 30;
            this.chartRS1.Name = "chartRS1";
            this.chartRS1.ReverseChartData = null;
            this.chartRS1.Size = new System.Drawing.Size(644, 336);
            this.chartRS1.TabIndex = 3;
            this.chartRS1.Title = null;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDown1.Location = new System.Drawing.Point(304, 0);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(171, 28);
            this.numericUpDown1.TabIndex = 4;
            // 
            // tbDT_E
            // 
            this.tbDT_E.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDT_E.Location = new System.Drawing.Point(133, 0);
            this.tbDT_E.Name = "tbDT_E";
            this.tbDT_E.Size = new System.Drawing.Size(171, 28);
            this.tbDT_E.TabIndex = 3;
            this.tbDT_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReverseCandleMainForm_Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ReverseCandleMainForm_Sample";
            this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Text = "리버스챠트 테스트 폼";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.Charts.ReverseCandleChart chartRS1;
        private Controls.Charts.ReverseCandleChart chartRS2;
        private Controls.Charts.ReverseCandleChart chartRS4;
        private Controls.Charts.ReverseCandleChart chartRS3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbDT_E;
    }
}

