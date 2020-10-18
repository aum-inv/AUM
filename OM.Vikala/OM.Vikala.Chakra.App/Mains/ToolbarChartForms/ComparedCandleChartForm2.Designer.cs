namespace OM.Vikala.Chakra.App.Mains.ToolbarChartForms
{
    partial class ComparedCandleChartForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparedCandleChartForm));
            this.userToolStrip1 = new OM.Vikala.Chakra.App.Mains.UserToolStrip();
            this.sContainer = new System.Windows.Forms.SplitContainer();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.chart1 = new OM.Vikala.Controls.Charts.ComparedBasicCandleChart();
            this.chart2 = new OM.Vikala.Controls.Charts.BasicCandleChart();
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).BeginInit();
            this.sContainer.Panel1.SuspendLayout();
            this.sContainer.Panel2.SuspendLayout();
            this.sContainer.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
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
            // sContainer
            // 
            this.sContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sContainer.Location = new System.Drawing.Point(0, 23);
            this.sContainer.Name = "sContainer";
            this.sContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sContainer.Panel1
            // 
            this.sContainer.Panel1.Controls.Add(this.pnlContent);
            this.sContainer.Panel1MinSize = 400;
            // 
            // sContainer.Panel2
            // 
            this.sContainer.Panel2.Controls.Add(this.chart2);
            this.sContainer.Panel2MinSize = 50;
            this.sContainer.Size = new System.Drawing.Size(1160, 721);
            this.sContainer.SplitterDistance = 667;
            this.sContainer.TabIndex = 5;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.chart1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1160, 667);
            this.pnlContent.TabIndex = 6;
            // 
            // chart1
            // 
            this.chart1.BaseCandleChartType = OM.Vikala.Controls.Charts.BaseCandleChartTypeEnum.인;
            this.chart1.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart1.ChartData = null;
            this.chart1.ChartDataSub = null;
            this.chart1.ChartEventInstance = null;
            this.chart1.DisplayPointCount = 30;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.IsAutoScrollX = true;
            this.chart1.IsEnabledDrawLine = true;
            this.chart1.IsLoaded = false;
            this.chart1.IsShowEightRule = true;
            this.chart1.IsShowXLine = true;
            this.chart1.IsShowYLine = true;
            this.chart1.ItemCode = "";
            this.chart1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.chart1.Name = "chart1";
            this.chart1.SelectedTrackBarValue = 1;
            this.chart1.Size = new System.Drawing.Size(1160, 667);
            this.chart1.TabIndex = 1;
            this.chart1.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart1.Title = null;
            // 
            // chart2
            // 
            this.chart2.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart2.ChartData = null;
            this.chart2.ChartDataSub = null;
            this.chart2.ChartEventInstance = null;
            this.chart2.DisplayPointCount = 60;
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.IsAutoScrollX = true;
            this.chart2.IsEnabledDrawLine = true;
            this.chart2.IsLoaded = false;
            this.chart2.IsShowCandlePriceInfo = false;
            this.chart2.IsShowXLine = true;
            this.chart2.IsShowYLine = true;
            this.chart2.ItemCode = "";
            this.chart2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Margin = new System.Windows.Forms.Padding(4);
            this.chart2.Name = "chart2";
            this.chart2.SelectedTrackBarValue = 1;
            this.chart2.Size = new System.Drawing.Size(1160, 50);
            this.chart2.TabIndex = 4;
            this.chart2.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart2.Title = null;
            // 
            // ComparedCandleChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1160, 744);
            this.Controls.Add(this.sContainer);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComparedCandleChartForm";
            this.Text = "VIKALA CHAKRA";
            this.sContainer.Panel1.ResumeLayout(false);
            this.sContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sContainer)).EndInit();
            this.sContainer.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserToolStrip userToolStrip1;
        private System.Windows.Forms.SplitContainer sContainer;
        private System.Windows.Forms.Panel pnlContent;
        private Controls.Charts.ComparedBasicCandleChart chart1;
        private Controls.Charts.BasicCandleChart chart2;
    }
}