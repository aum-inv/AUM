namespace OM.Vikala.Chakra.App.Mains.ToolbarChartForms
{
    partial class AtmanChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmanChartForm));
            this.pnlContent = new System.Windows.Forms.Panel();
            this.chart = new OM.Vikala.Controls.Charts.AtmanChart();
            this.userToolStrip1 = new OM.Vikala.Chakra.App.Mains.UserToolStrip();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.chart);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 23);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1160, 721);
            this.pnlContent.TabIndex = 4;
            // 
            // chart
            // 
            this.chart.BaseCandleChartType = OM.Vikala.Controls.Charts.BaseCandleChartTypeEnum.인;
            this.chart.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart.ChartData = null;
            this.chart.ChartDataSub = null;
            this.chart.ChartDataSub2 = null;
            this.chart.ChartEventInstance = null;
            this.chart.DisplayPointCount = 30;
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.IsAutoScrollX = true;
            this.chart.IsEnabledDrawLine = true;
            this.chart.IsLoaded = false;
            this.chart.IsShowXLine = true;
            this.chart.IsShowYLine = true;
            this.chart.ItemCode = "";
            this.chart.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart.Location = new System.Drawing.Point(0, 23);
            this.chart.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.chart.Name = "chart";
            this.chart.SelectedTrackBarValue = 1;
            this.chart.Size = new System.Drawing.Size(1160, 721);
            this.chart.TabIndex = 2;
            this.chart.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart.Title = null;
            // 
            // userToolStrip1
            // 
            this.userToolStrip1.AutoSize = true;
            this.userToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToolStrip1.IsVisibleAlignmentButton = false;
            this.userToolStrip1.IsVisibleExpand = false;
            this.userToolStrip1.IsVisibleMdiButton = false;
            this.userToolStrip1.IsVisibleTimeIntervalButton = true;
            this.userToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.userToolStrip1.Name = "userToolStrip1";
            this.userToolStrip1.Size = new System.Drawing.Size(1160, 23);
            this.userToolStrip1.TabIndex = 0;
            // 
            // AtmanChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 744);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AtmanChartForm";
            this.Text = "VIKALA CHAKRA";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlContent;
        private UserToolStrip userToolStrip1;
        private Controls.Charts.AtmanChart chart;
    }
}