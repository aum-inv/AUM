namespace OM.Vikala.Chakra.App.Mains.ToolbarChartForms
{
    partial class MovingAverageFlowChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovingAverageFlowChartForm));
            this.button1 = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowTable = new System.Windows.Forms.TableLayoutPanel();
            this.userToolStrip1 = new OM.Vikala.Chakra.App.Mains.UserToolStrip();
            this.chart1 = new OM.Vikala.Controls.Charts.QuantumLineChartHL();
            this.chart2 = new OM.Vikala.Controls.Charts.QuantumLineChartHL();
            this.pnlContent.SuspendLayout();
            this.flowTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.flowTable);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 23);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1283, 507);
            this.pnlContent.TabIndex = 4;
            // 
            // flowTable
            // 
            this.flowTable.ColumnCount = 1;
            this.flowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.flowTable.Controls.Add(this.chart2, 0, 1);
            this.flowTable.Controls.Add(this.chart1, 0, 0);
            this.flowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTable.Location = new System.Drawing.Point(0, 0);
            this.flowTable.Margin = new System.Windows.Forms.Padding(2);
            this.flowTable.Name = "flowTable";
            this.flowTable.RowCount = 2;
            this.flowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowTable.Size = new System.Drawing.Size(1283, 507);
            this.flowTable.TabIndex = 1;
            // 
            // userToolStrip1
            // 
            this.userToolStrip1.AutoSize = true;
            this.userToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToolStrip1.IsVisibleAlignmentButton = true;
            this.userToolStrip1.IsVisibleExpand = false;
            this.userToolStrip1.IsVisibleMdiButton = true;
            this.userToolStrip1.IsVisibleTimeIntervalButton = true;
            this.userToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip1.Margin = new System.Windows.Forms.Padding(1);
            this.userToolStrip1.Name = "userToolStrip1";
            this.userToolStrip1.Size = new System.Drawing.Size(1283, 23);
            this.userToolStrip1.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chart1.ChartData = null;
            this.chart1.ChartDataSub = null;
            this.chart1.ChartEventInstance = null;
            this.chart1.DisplayPointCount = 60;
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.IsAutoScrollX = true;
            this.chart1.IsLoaded = false;
            this.chart1.IsShowCandle = true;
            this.chart1.IsShowMassVolumn = true;
            this.chart1.IsShowXLine = true;
            this.chart1.IsShowYLine = true;
            this.chart1.ItemCode = "";
            this.chart1.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart1.Location = new System.Drawing.Point(4, 4);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.SelectedTrackBarValue = 1;
            this.chart1.Size = new System.Drawing.Size(1275, 245);
            this.chart1.TabIndex = 3;
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
            this.chart2.IsLoaded = false;
            this.chart2.IsShowCandle = true;
            this.chart2.IsShowMassVolumn = true;
            this.chart2.IsShowXLine = true;
            this.chart2.IsShowYLine = true;
            this.chart2.ItemCode = "";
            this.chart2.LineChartType = OM.Vikala.Controls.Charts.LineChartTypeEnum.기본;
            this.chart2.Location = new System.Drawing.Point(4, 257);
            this.chart2.Margin = new System.Windows.Forms.Padding(4);
            this.chart2.Name = "chart2";
            this.chart2.SelectedTrackBarValue = 1;
            this.chart2.Size = new System.Drawing.Size(1275, 246);
            this.chart2.TabIndex = 4;
            this.chart2.TimeInterval = OM.Lib.Base.Enums.TimeIntervalEnum.Day;
            this.chart2.Title = null;
            // 
            // MovingAverageFlowChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1283, 530);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MovingAverageFlowChartForm";
            this.Text = "단기추세챠트";
            this.pnlContent.ResumeLayout(false);
            this.flowTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserToolStrip userToolStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel flowTable;
        private Controls.Charts.QuantumLineChartHL chart2;
        private Controls.Charts.QuantumLineChartHL chart1;
    }
}