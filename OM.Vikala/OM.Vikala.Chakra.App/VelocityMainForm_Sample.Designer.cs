﻿namespace OM.Vikala.Chakra.App
{
    partial class VelocityMainForm_Sample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VelocityMainForm_Sample));
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tbDT_E = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartVL1 = new OM.Vikala.Controls.Charts.VelocityLineChart();
            this.chartVL2 = new OM.Vikala.Controls.Charts.VelocityLineChart();
            this.chartVL3 = new OM.Vikala.Controls.Charts.VelocityLineChart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.tbDT_E);
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 22);
            this.panel1.TabIndex = 0;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Left;
            this.numericUpDown1.Location = new System.Drawing.Point(184, 0);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // tbDT_E
            // 
            this.tbDT_E.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbDT_E.Location = new System.Drawing.Point(80, 0);
            this.tbDT_E.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbDT_E.Name = "tbDT_E";
            this.tbDT_E.Size = new System.Drawing.Size(104, 20);
            this.tbDT_E.TabIndex = 1;
            this.tbDT_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadData.Location = new System.Drawing.Point(0, 0);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(80, 22);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "LoadData";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 26);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 405);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Controls.Add(this.chartVL1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartVL2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartVL3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 405);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chartVL1
            // 
            this.chartVL1.ChartData = null;
            this.chartVL1.ChartEventInstance = null;
            this.chartVL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVL1.IsAutoScrollX = true;
            this.chartVL1.IsLoaded = false;
            this.chartVL1.ItemCode = "";
            this.chartVL1.Location = new System.Drawing.Point(5, 4);
            this.chartVL1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chartVL1.DisplayPointCount = 30;
            this.chartVL1.Name = "chartVL1";
            this.chartVL1.Size = new System.Drawing.Size(714, 127);
            this.chartVL1.TabIndex = 2;
            this.chartVL1.Title = null;
            // 
            // chartVL2
            // 
            this.chartVL2.ChartData = null;
            this.chartVL2.ChartEventInstance = null;
            this.chartVL2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVL2.IsAutoScrollX = true;
            this.chartVL2.IsLoaded = false;
            this.chartVL2.ItemCode = "";
            this.chartVL2.Location = new System.Drawing.Point(5, 139);
            this.chartVL2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chartVL2.DisplayPointCount = 30;
            this.chartVL2.Name = "chartVL2";
            this.chartVL2.Size = new System.Drawing.Size(714, 127);
            this.chartVL2.TabIndex = 3;
            this.chartVL2.Title = null;
            // 
            // chartVL3
            // 
            this.chartVL3.ChartData = null;
            this.chartVL3.ChartEventInstance = null;
            this.chartVL3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartVL3.IsAutoScrollX = true;
            this.chartVL3.IsLoaded = false;
            this.chartVL3.ItemCode = "";
            this.chartVL3.Location = new System.Drawing.Point(5, 274);
            this.chartVL3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chartVL3.DisplayPointCount = 30;
            this.chartVL3.Name = "chartVL3";
            this.chartVL3.Size = new System.Drawing.Size(714, 127);
            this.chartVL3.TabIndex = 3;
            this.chartVL3.Title = null;
            // 
            // VelocityMainForm_Sample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 435);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "VelocityMainForm_Sample";
            this.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Text = "속도 테스트 폼";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.Charts.VelocityLineChart chartVL1;
        private Controls.Charts.VelocityLineChart chartVL2;
        private Controls.Charts.VelocityLineChart chartVL3;
        private System.Windows.Forms.TextBox tbDT_E;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

