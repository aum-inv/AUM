﻿namespace OM.Vikala.Chakra.App.Mains.ChartForm
{
    partial class ReverseChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReverseChartForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart8 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart7 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart6 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart5 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart4 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart2 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart3 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.chart1 = new OM.Vikala.Controls.Charts.ReverseCandleChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userToolStrip1 = new OM.Vikala.Chakra.App.Mains.UserToolStrip();
            this.pnlContent.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.tableLayoutPanel1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 25);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1127, 689);
            this.pnlContent.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chart8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.chart7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chart6, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chart5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chart4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chart3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 689);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // chart8
            // 
            this.chart8.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart8.ChartData = null;
            this.chart8.ChartEventInstance = null;
            this.chart8.DisplayPointCount = 60;
            this.chart8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart8.IsAutoScrollX = true;
            this.chart8.IsLoaded = false;
            this.chart8.IsShowXLine = true;
            this.chart8.ItemCode = "";
            this.chart8.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart8.Location = new System.Drawing.Point(566, 520);
            this.chart8.Name = "chart8";
            this.chart8.ReverseChartData = null;
            this.chart8.SelectedTrackBarValue = 1;
            this.chart8.Size = new System.Drawing.Size(558, 166);
            this.chart8.TabIndex = 9;
            this.chart8.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart8.Title = null;
            // 
            // chart7
            // 
            this.chart7.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart7.ChartData = null;
            this.chart7.ChartEventInstance = null;
            this.chart7.DisplayPointCount = 60;
            this.chart7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart7.IsAutoScrollX = true;
            this.chart7.IsLoaded = false;
            this.chart7.IsShowXLine = true;
            this.chart7.ItemCode = "";
            this.chart7.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart7.Location = new System.Drawing.Point(3, 520);
            this.chart7.Name = "chart7";
            this.chart7.ReverseChartData = null;
            this.chart7.SelectedTrackBarValue = 1;
            this.chart7.Size = new System.Drawing.Size(557, 166);
            this.chart7.TabIndex = 8;
            this.chart7.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart7.Title = null;
            // 
            // chart6
            // 
            this.chart6.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart6.ChartData = null;
            this.chart6.ChartEventInstance = null;
            this.chart6.DisplayPointCount = 60;
            this.chart6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart6.IsAutoScrollX = true;
            this.chart6.IsLoaded = false;
            this.chart6.IsShowXLine = true;
            this.chart6.ItemCode = "";
            this.chart6.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart6.Location = new System.Drawing.Point(566, 351);
            this.chart6.Name = "chart6";
            this.chart6.ReverseChartData = null;
            this.chart6.SelectedTrackBarValue = 1;
            this.chart6.Size = new System.Drawing.Size(558, 163);
            this.chart6.TabIndex = 7;
            this.chart6.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart6.Title = null;
            // 
            // chart5
            // 
            this.chart5.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart5.ChartData = null;
            this.chart5.ChartEventInstance = null;
            this.chart5.DisplayPointCount = 60;
            this.chart5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart5.IsAutoScrollX = true;
            this.chart5.IsLoaded = false;
            this.chart5.IsShowXLine = true;
            this.chart5.ItemCode = "";
            this.chart5.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart5.Location = new System.Drawing.Point(3, 351);
            this.chart5.Name = "chart5";
            this.chart5.ReverseChartData = null;
            this.chart5.SelectedTrackBarValue = 1;
            this.chart5.Size = new System.Drawing.Size(557, 163);
            this.chart5.TabIndex = 6;
            this.chart5.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart5.Title = null;
            // 
            // chart4
            // 
            this.chart4.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart4.ChartData = null;
            this.chart4.ChartEventInstance = null;
            this.chart4.DisplayPointCount = 60;
            this.chart4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart4.IsAutoScrollX = true;
            this.chart4.IsLoaded = false;
            this.chart4.IsShowXLine = true;
            this.chart4.ItemCode = "";
            this.chart4.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart4.Location = new System.Drawing.Point(566, 172);
            this.chart4.Name = "chart4";
            this.chart4.ReverseChartData = null;
            this.chart4.SelectedTrackBarValue = 1;
            this.chart4.Size = new System.Drawing.Size(558, 163);
            this.chart4.TabIndex = 5;
            this.chart4.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart4.Title = null;
            // 
            // chart2
            // 
            this.chart2.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart2.ChartData = null;
            this.chart2.ChartEventInstance = null;
            this.chart2.DisplayPointCount = 60;
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.IsAutoScrollX = true;
            this.chart2.IsLoaded = false;
            this.chart2.IsShowXLine = true;
            this.chart2.ItemCode = "";
            this.chart2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart2.Location = new System.Drawing.Point(566, 3);
            this.chart2.Name = "chart2";
            this.chart2.ReverseChartData = null;
            this.chart2.SelectedTrackBarValue = 1;
            this.chart2.Size = new System.Drawing.Size(558, 163);
            this.chart2.TabIndex = 4;
            this.chart2.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart2.Title = null;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(566, 341);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(558, 4);
            this.panel2.TabIndex = 3;
            // 
            // chart3
            // 
            this.chart3.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart3.ChartData = null;
            this.chart3.ChartEventInstance = null;
            this.chart3.DisplayPointCount = 60;
            this.chart3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart3.IsAutoScrollX = true;
            this.chart3.IsLoaded = false;
            this.chart3.IsShowXLine = true;
            this.chart3.ItemCode = "";
            this.chart3.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart3.Location = new System.Drawing.Point(3, 172);
            this.chart3.Name = "chart3";
            this.chart3.ReverseChartData = null;
            this.chart3.SelectedTrackBarValue = 1;
            this.chart3.Size = new System.Drawing.Size(557, 163);
            this.chart3.TabIndex = 1;
            this.chart3.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart3.Title = null;
            // 
            // chart1
            // 
            this.chart1.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart1.ChartData = null;
            this.chart1.ChartEventInstance = null;
            this.chart1.DisplayPointCount = 60;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.IsAutoScrollX = true;
            this.chart1.IsLoaded = false;
            this.chart1.IsShowXLine = true;
            this.chart1.ItemCode = "";
            this.chart1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            this.chart1.ReverseChartData = null;
            this.chart1.SelectedTrackBarValue = 1;
            this.chart1.Size = new System.Drawing.Size(557, 163);
            this.chart1.TabIndex = 0;
            this.chart1.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart1.Title = null;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 4);
            this.panel1.TabIndex = 2;
            // 
            // userToolStrip1
            // 
            this.userToolStrip1.AutoSize = true;
            this.userToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToolStrip1.IsVisibleAlignmentButton = false;
            this.userToolStrip1.IsVisibleMdiButton = true;
            this.userToolStrip1.IsVisibleTimeIntervalButton = true;
            this.userToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.userToolStrip1.Name = "userToolStrip1";
            this.userToolStrip1.Size = new System.Drawing.Size(1127, 25);
            this.userToolStrip1.TabIndex = 0;
            // 
            // ReverseChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1127, 714);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReverseChartForm";
            this.Text = "VIKALA CHAKRA";
            this.pnlContent.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserToolStrip userToolStrip1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.Charts.ReverseCandleChart chart1;
        private Controls.Charts.ReverseCandleChart chart3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controls.Charts.ReverseCandleChart chart4;
        private Controls.Charts.ReverseCandleChart chart2;
        private Controls.Charts.ReverseCandleChart chart8;
        private Controls.Charts.ReverseCandleChart chart7;
        private Controls.Charts.ReverseCandleChart chart6;
        private Controls.Charts.ReverseCandleChart chart5;
    }
}