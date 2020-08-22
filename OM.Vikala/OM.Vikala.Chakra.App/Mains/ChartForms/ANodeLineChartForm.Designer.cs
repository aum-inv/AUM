namespace OM.Vikala.Chakra.App.Mains.ChartForm
{
    partial class ANodeLineChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtomChartForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chart1 = new OM.Vikala.Controls.Charts.ANodeLineChart();
            this.chart2 = new OM.Vikala.Controls.Charts.ANodeLineChart();
            this.chart3 = new OM.Vikala.Controls.Charts.ANodeLineChart();
            this.chart4 = new OM.Vikala.Controls.Charts.ANodeLineChart();
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
            this.pnlContent.Location = new System.Drawing.Point(0, 34);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1690, 1037);
            this.pnlContent.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.chart1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chart4, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1690, 1037);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.chart1.IsShowXLine = false;
            this.chart1.ItemCode = "";
            this.chart1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart1.Location = new System.Drawing.Point(6, 6);
            this.chart1.Margin = new System.Windows.Forms.Padding(6);
            this.chart1.Name = "chart1";
            this.chart1.SelectedTrackBarValue = 1;
            this.chart1.Size = new System.Drawing.Size(1678, 247);
            this.chart1.TabIndex = 0;
            this.chart1.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart1.Title = null;
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
            this.chart2.IsShowXLine = false;
            this.chart2.ItemCode = "";
            this.chart2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart2.Location = new System.Drawing.Point(6, 265);
            this.chart2.Margin = new System.Windows.Forms.Padding(6);
            this.chart2.Name = "chart2";
            this.chart2.SelectedTrackBarValue = 1;
            this.chart2.Size = new System.Drawing.Size(1678, 247);
            this.chart2.TabIndex = 1;
            this.chart2.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart2.Title = null;
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
            this.chart3.IsShowXLine = false;
            this.chart3.ItemCode = "";
            this.chart3.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart3.Location = new System.Drawing.Point(6, 524);
            this.chart3.Margin = new System.Windows.Forms.Padding(6);
            this.chart3.Name = "chart3";
            this.chart3.SelectedTrackBarValue = 1;
            this.chart3.Size = new System.Drawing.Size(1678, 247);
            this.chart3.TabIndex = 1;
            this.chart3.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart3.Title = null;
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
            this.chart4.IsShowXLine = false;
            this.chart4.ItemCode = "";
            this.chart4.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart4.Location = new System.Drawing.Point(6, 783);
            this.chart4.Margin = new System.Windows.Forms.Padding(6);
            this.chart4.Name = "chart4";
            this.chart4.SelectedTrackBarValue = 1;
            this.chart4.Size = new System.Drawing.Size(1678, 248);
            this.chart4.TabIndex = 1;
            this.chart4.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart4.Title = null;
            // 
            // userToolStrip1
            // 
            this.userToolStrip1.AutoSize = true;
            this.userToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToolStrip1.IsVisibleAlignmentButton = false;
            this.userToolStrip1.IsVisibleMdiButton = true;
            this.userToolStrip1.IsVisibleTimeIntervalButton = true;
            this.userToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip1.Margin = new System.Windows.Forms.Padding(2);
            this.userToolStrip1.Name = "userToolStrip1";
            this.userToolStrip1.Size = new System.Drawing.Size(1690, 34);
            this.userToolStrip1.TabIndex = 0;
            // 
            // AtomChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1690, 1071);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AtomChartForm";
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
        private Controls.Charts.ANodeLineChart chart1;
        private Controls.Charts.ANodeLineChart chart2;
        private Controls.Charts.ANodeLineChart chart3;
        private Controls.Charts.ANodeLineChart chart4;
    }
}