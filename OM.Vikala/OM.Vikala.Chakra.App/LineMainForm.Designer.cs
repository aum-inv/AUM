﻿namespace OM.Vikala.Chakra.App
{
    partial class LineMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartLS2 = new OM.Vikala.Controls.Charts.BasicLineChart();
            this.chartLS1 = new OM.Vikala.Controls.Charts.BasicLineChart();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbDT_E = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.chartLS2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartLS1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1327, 702);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chartLS2
            // 
            this.chartLS2.ChartData = null;
            this.chartLS2.ChartEventInstance = null;
            this.chartLS2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chartLS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLS2.IsAutoScrollX = true;
            this.chartLS2.IsLoaded = false;
            this.chartLS2.ItemCode = "";
            this.chartLS2.Location = new System.Drawing.Point(8, 357);
            this.chartLS2.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartLS2.DisplayPointCount = 30;
            this.chartLS2.Name = "chartLS2";
            this.chartLS2.Size = new System.Drawing.Size(1311, 339);
             this.chartLS2.TabIndex = 3;
            this.chartLS2.Title = null;
            // 
            // chartLS1
            // 
            this.chartLS1.ChartData = null;
            this.chartLS1.ChartEventInstance = null;
            this.chartLS1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chartLS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLS1.IsAutoScrollX = true;
            this.chartLS1.IsLoaded = false;
            this.chartLS1.ItemCode = "";
            this.chartLS1.Location = new System.Drawing.Point(8, 6);
            this.chartLS1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartLS1.DisplayPointCount = 30;
            this.chartLS1.Name = "chartLS1";
            this.chartLS1.Size = new System.Drawing.Size(1311, 339);
            this.chartLS1.TabIndex = 2;
            this.chartLS1.Title = null;
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
            // LineMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "LineMainForm";
            this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Text = "라인챠트 테스트 폼";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.Charts.BasicLineChart chartLS1;
        private Controls.Charts.BasicLineChart chartLS2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox tbDT_E;
    }
}

