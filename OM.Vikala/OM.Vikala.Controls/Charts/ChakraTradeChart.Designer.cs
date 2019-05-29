﻿namespace OM.Vikala.Controls.Charts
{
    partial class ChakraTradeChart
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
            this.lblMH = new System.Windows.Forms.Label();
            this.lblML = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblLTick = new System.Windows.Forms.Label();
            this.lblHTick = new System.Windows.Forms.Label();
            this.lblMLTick = new System.Windows.Forms.Label();
            this.lblMHTick = new System.Windows.Forms.Label();
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
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisY2.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.BackColor = System.Drawing.Color.White;
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
            series2.IsVisibleInLegend = false;
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
            series3.IsVisibleInLegend = false;
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
            this.chart.Size = new System.Drawing.Size(431, 225);
            this.chart.TabIndex = 2;
            this.chart.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PostPaint);
            // 
            // pnlScroll
            // 
            this.pnlScroll.Controls.Add(this.hScrollBar);
            this.pnlScroll.Controls.Add(this.trackBar);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlScroll.Location = new System.Drawing.Point(0, 225);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(2);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(431, 14);
            this.pnlScroll.TabIndex = 4;
            // 
            // hScrollBar
            // 
            this.hScrollBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar.LargeChange = 2;
            this.hScrollBar.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar.Maximum = 1;
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(359, 14);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.Value = 1;
            this.hScrollBar.ValueChanged += new System.EventHandler(this.hScrollBar_ValueChanged);
            // 
            // trackBar
            // 
            this.trackBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.trackBar.LargeChange = 1;
            this.trackBar.Location = new System.Drawing.Point(359, 0);
            this.trackBar.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(72, 14);
            this.trackBar.TabIndex = 5;
            this.trackBar.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // lblMH
            // 
            this.lblMH.BackColor = System.Drawing.Color.Fuchsia;
            this.lblMH.ForeColor = System.Drawing.Color.White;
            this.lblMH.Location = new System.Drawing.Point(120, 0);
            this.lblMH.Name = "lblMH";
            this.lblMH.Size = new System.Drawing.Size(50, 15);
            this.lblMH.TabIndex = 6;
            this.lblMH.Text = "0";
            this.lblMH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblML
            // 
            this.lblML.BackColor = System.Drawing.Color.Green;
            this.lblML.ForeColor = System.Drawing.Color.White;
            this.lblML.Location = new System.Drawing.Point(230, 0);
            this.lblML.Name = "lblML";
            this.lblML.Size = new System.Drawing.Size(50, 15);
            this.lblML.TabIndex = 7;
            this.lblML.Text = "0";
            this.lblML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH
            // 
            this.lblH.BackColor = System.Drawing.Color.Red;
            this.lblH.ForeColor = System.Drawing.Color.White;
            this.lblH.Location = new System.Drawing.Point(3, 0);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(50, 15);
            this.lblH.TabIndex = 10;
            this.lblH.Text = "0";
            this.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblL
            // 
            this.lblL.BackColor = System.Drawing.Color.Blue;
            this.lblL.ForeColor = System.Drawing.Color.White;
            this.lblL.Location = new System.Drawing.Point(340, 0);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(50, 15);
            this.lblL.TabIndex = 11;
            this.lblL.Text = "0";
            this.lblL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLTick
            // 
            this.lblLTick.BackColor = System.Drawing.Color.Blue;
            this.lblLTick.ForeColor = System.Drawing.Color.White;
            this.lblLTick.Location = new System.Drawing.Point(396, 0);
            this.lblLTick.Name = "lblLTick";
            this.lblLTick.Size = new System.Drawing.Size(30, 15);
            this.lblLTick.TabIndex = 15;
            this.lblLTick.Text = "0";
            this.lblLTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHTick
            // 
            this.lblHTick.BackColor = System.Drawing.Color.Red;
            this.lblHTick.ForeColor = System.Drawing.Color.White;
            this.lblHTick.Location = new System.Drawing.Point(59, 0);
            this.lblHTick.Name = "lblHTick";
            this.lblHTick.Size = new System.Drawing.Size(30, 15);
            this.lblHTick.TabIndex = 14;
            this.lblHTick.Text = "0";
            this.lblHTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMLTick
            // 
            this.lblMLTick.BackColor = System.Drawing.Color.Green;
            this.lblMLTick.ForeColor = System.Drawing.Color.White;
            this.lblMLTick.Location = new System.Drawing.Point(286, 0);
            this.lblMLTick.Name = "lblMLTick";
            this.lblMLTick.Size = new System.Drawing.Size(30, 15);
            this.lblMLTick.TabIndex = 13;
            this.lblMLTick.Text = "0";
            this.lblMLTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMHTick
            // 
            this.lblMHTick.BackColor = System.Drawing.Color.Fuchsia;
            this.lblMHTick.ForeColor = System.Drawing.Color.White;
            this.lblMHTick.Location = new System.Drawing.Point(176, 0);
            this.lblMHTick.Name = "lblMHTick";
            this.lblMHTick.Size = new System.Drawing.Size(30, 15);
            this.lblMHTick.TabIndex = 12;
            this.lblMHTick.Text = "0";
            this.lblMHTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChakraTradeChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLTick);
            this.Controls.Add(this.lblHTick);
            this.Controls.Add(this.lblMLTick);
            this.Controls.Add(this.lblMHTick);
            this.Controls.Add(this.lblL);
            this.Controls.Add(this.lblH);
            this.Controls.Add(this.lblML);
            this.Controls.Add(this.lblMH);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.pnlScroll);
            this.Name = "ChakraTradeChart";
            this.Size = new System.Drawing.Size(431, 239);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.pnlScroll.ResumeLayout(false);
            this.pnlScroll.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label lblMH;
        private System.Windows.Forms.Label lblML;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblLTick;
        private System.Windows.Forms.Label lblHTick;
        private System.Windows.Forms.Label lblMLTick;
        private System.Windows.Forms.Label lblMHTick;
    }
}
