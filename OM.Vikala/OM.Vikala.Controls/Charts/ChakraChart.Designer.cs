﻿namespace OM.Vikala.Controls.Charts
{
    partial class ChakraChart
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblQPriceH = new System.Windows.Forms.Label();
            this.lblQPriceL = new System.Windows.Forms.Label();
            this.candlePriceInfo1 = new OM.Vikala.Controls.Ucs.CandlePriceInfo();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.pnlScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart.BackSecondaryColor = System.Drawing.Color.White;
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderlineWidth = 0;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX2.IsLabelAutoFit = false;
            chartArea1.AxisX2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY2.IsLabelAutoFit = false;
            chartArea1.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea1.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 90F;
            chartArea1.InnerPlotPosition.Width = 93F;
            chartArea1.InnerPlotPosition.X = 2F;
            chartArea1.Name = "cArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 95F;
            chartArea1.Position.Width = 98F;
            chartArea1.Position.Y = 5F;
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.ChartArea = "cArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.Black;
            series1.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Name = "candle1";
            series1.ShadowColor = System.Drawing.Color.Transparent;
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series1.YValuesPerPoint = 4;
            series2.BorderColor = System.Drawing.Color.Transparent;
            series2.ChartArea = "cArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.Color = System.Drawing.Color.Black;
            series2.CustomProperties = "PriceDownColor=Navy, PriceUpColor=Maroon";
            series2.IsXValueIndexed = true;
            series2.Name = "candle2";
            series2.ShadowColor = System.Drawing.Color.Transparent;
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series2.YValuesPerPoint = 4;
            series3.BorderColor = System.Drawing.Color.Transparent;
            series3.ChartArea = "cArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.Black;
            series3.CustomProperties = "PriceDownColor=192\\, 255\\, 192, PriceUpColor=Green";
            series3.IsXValueIndexed = true;
            series3.Name = "candle3";
            series3.ShadowColor = System.Drawing.Color.Transparent;
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YValuesPerPoint = 4;
            series4.ChartArea = "cArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.IsValueShownAsLabel = true;
            series4.IsXValueIndexed = true;
            series4.Name = "line1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series5.ChartArea = "cArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.IsValueShownAsLabel = true;
            series5.IsXValueIndexed = true;
            series5.Name = "line2";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series5.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series6.ChartArea = "cArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Fuchsia;
            series6.IsXValueIndexed = true;
            series6.Name = "line3";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series6.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series7.ChartArea = "cArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            series7.IsXValueIndexed = true;
            series7.Name = "line4";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Series.Add(series6);
            this.chart.Series.Add(series7);
            this.chart.Size = new System.Drawing.Size(723, 299);
            this.chart.TabIndex = 2;
            this.chart.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PostPaint);
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart_MouseClick);
            this.chart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Chart_MouseDoubleClick);
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            // 
            // pnlScroll
            // 
            this.pnlScroll.Controls.Add(this.hScrollBar);
            this.pnlScroll.Controls.Add(this.trackBar);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlScroll.Location = new System.Drawing.Point(0, 299);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(2);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(723, 14);
            this.pnlScroll.TabIndex = 4;
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar.LargeChange = 2;
            this.hScrollBar.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar.Maximum = 1;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(651, 14);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.Value = 1;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(651, 0);
            this.trackBar.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(72, 14);
            this.trackBar.TabIndex = 5;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // lblQPriceH
            // 
            this.lblQPriceH.AutoSize = true;
            this.lblQPriceH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblQPriceH.ForeColor = System.Drawing.Color.White;
            this.lblQPriceH.Location = new System.Drawing.Point(610, 26);
            this.lblQPriceH.Name = "lblQPriceH";
            this.lblQPriceH.Size = new System.Drawing.Size(38, 12);
            this.lblQPriceH.TabIndex = 6;
            this.lblQPriceH.Text = "label1";
            this.lblQPriceH.Visible = false;
            // 
            // lblQPriceL
            // 
            this.lblQPriceL.AutoSize = true;
            this.lblQPriceL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblQPriceL.ForeColor = System.Drawing.Color.White;
            this.lblQPriceL.Location = new System.Drawing.Point(610, 50);
            this.lblQPriceL.Name = "lblQPriceL";
            this.lblQPriceL.Size = new System.Drawing.Size(38, 12);
            this.lblQPriceL.TabIndex = 7;
            this.lblQPriceL.Text = "label1";
            this.lblQPriceL.Visible = false;
            // 
            // candlePriceInfo1
            // 
            this.candlePriceInfo1.BackColor = System.Drawing.Color.White;
            this.candlePriceInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.candlePriceInfo1.Location = new System.Drawing.Point(16, 17);
            this.candlePriceInfo1.Margin = new System.Windows.Forms.Padding(1);
            this.candlePriceInfo1.Name = "candlePriceInfo1";
            this.candlePriceInfo1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.candlePriceInfo1.Size = new System.Drawing.Size(233, 212);
            this.candlePriceInfo1.TabIndex = 9;
            this.candlePriceInfo1.Visible = false;
            // 
            // ChakraChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.candlePriceInfo1);
            this.Controls.Add(this.lblQPriceL);
            this.Controls.Add(this.lblQPriceH);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.pnlScroll);
            this.Name = "ChakraChart";
            this.Size = new System.Drawing.Size(723, 313);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblQPriceH;
        private System.Windows.Forms.Label lblQPriceL;
        private Ucs.CandlePriceInfo candlePriceInfo1;
    }
}
