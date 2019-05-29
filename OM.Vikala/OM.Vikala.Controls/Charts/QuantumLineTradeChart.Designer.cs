namespace OM.Vikala.Controls.Charts
{
    partial class QuantumLineTradeChart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.lblLTick = new System.Windows.Forms.Label();
            this.lblHTick = new System.Windows.Forms.Label();
            this.lblMLTick = new System.Windows.Forms.Label();
            this.lblMHTick = new System.Windows.Forms.Label();
            this.lblL = new System.Windows.Forms.Label();
            this.lblH = new System.Windows.Forms.Label();
            this.lblML = new System.Windows.Forms.Label();
            this.lblMH = new System.Windows.Forms.Label();
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
            chartArea2.Area3DStyle.Inclination = 15;
            chartArea2.Area3DStyle.IsClustered = true;
            chartArea2.Area3DStyle.IsRightAngleAxes = false;
            chartArea2.Area3DStyle.Perspective = 10;
            chartArea2.Area3DStyle.Rotation = 10;
            chartArea2.Area3DStyle.WallWidth = 0;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.Interval = 0D;
            chartArea2.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea2.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisX2.IsLabelAutoFit = false;
            chartArea2.AxisX2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY2.IsLabelAutoFit = false;
            chartArea2.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea2.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(165)))), ((int)(((byte)(191)))), ((int)(((byte)(228)))));
            chartArea2.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 90F;
            chartArea2.InnerPlotPosition.Width = 93F;
            chartArea2.InnerPlotPosition.X = 2F;
            chartArea2.Name = "chartArea";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 95F;
            chartArea2.Position.Width = 98F;
            chartArea2.Position.Y = 5F;
            chartArea2.ShadowColor = System.Drawing.Color.Transparent;
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series7.BorderColor = System.Drawing.Color.Transparent;
            series7.ChartArea = "chartArea";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series7.Color = System.Drawing.Color.Black;
            series7.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series7.IsXValueIndexed = true;
            series7.Name = "candle1";
            series7.ShadowColor = System.Drawing.Color.Transparent;
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series7.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series7.YValuesPerPoint = 4;
            series8.BorderColor = System.Drawing.Color.Transparent;
            series8.ChartArea = "chartArea";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.Fuchsia;
            series8.IsXValueIndexed = true;
            series8.LabelForeColor = System.Drawing.Color.Lime;
            series8.Name = "line1";
            series8.ShadowColor = System.Drawing.Color.Transparent;
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series8.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series9.ChartArea = "chartArea";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            series9.IsXValueIndexed = true;
            series9.Name = "line2";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series9.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series10.ChartArea = "chartArea";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Color = System.Drawing.Color.Red;
            series10.IsXValueIndexed = true;
            series10.Name = "line3";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series10.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series11.ChartArea = "chartArea";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Color = System.Drawing.Color.Blue;
            series11.IsXValueIndexed = true;
            series11.Name = "line4";
            series11.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series11.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series12.ChartArea = "chartArea";
            series12.Color = System.Drawing.Color.Red;
            series12.IsValueShownAsLabel = true;
            series12.IsXValueIndexed = true;
            series12.Name = "column";
            series12.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series12.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart.Series.Add(series7);
            this.chart.Series.Add(series8);
            this.chart.Series.Add(series9);
            this.chart.Series.Add(series10);
            this.chart.Series.Add(series11);
            this.chart.Series.Add(series12);
            this.chart.Size = new System.Drawing.Size(723, 299);
            this.chart.TabIndex = 2;
            this.chart.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.chart_PostPaint);
            this.chart.Click += new System.EventHandler(this.Chart_Click);
            this.chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart_MouseClick);
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
            // lblLTick
            // 
            this.lblLTick.BackColor = System.Drawing.Color.Blue;
            this.lblLTick.ForeColor = System.Drawing.Color.White;
            this.lblLTick.Location = new System.Drawing.Point(394, -1);
            this.lblLTick.Name = "lblLTick";
            this.lblLTick.Size = new System.Drawing.Size(30, 15);
            this.lblLTick.TabIndex = 23;
            this.lblLTick.Text = "0";
            this.lblLTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHTick
            // 
            this.lblHTick.BackColor = System.Drawing.Color.Red;
            this.lblHTick.ForeColor = System.Drawing.Color.White;
            this.lblHTick.Location = new System.Drawing.Point(57, -1);
            this.lblHTick.Name = "lblHTick";
            this.lblHTick.Size = new System.Drawing.Size(30, 15);
            this.lblHTick.TabIndex = 22;
            this.lblHTick.Text = "0";
            this.lblHTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMLTick
            // 
            this.lblMLTick.BackColor = System.Drawing.Color.Green;
            this.lblMLTick.ForeColor = System.Drawing.Color.White;
            this.lblMLTick.Location = new System.Drawing.Point(284, -1);
            this.lblMLTick.Name = "lblMLTick";
            this.lblMLTick.Size = new System.Drawing.Size(30, 15);
            this.lblMLTick.TabIndex = 21;
            this.lblMLTick.Text = "0";
            this.lblMLTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMHTick
            // 
            this.lblMHTick.BackColor = System.Drawing.Color.Fuchsia;
            this.lblMHTick.ForeColor = System.Drawing.Color.White;
            this.lblMHTick.Location = new System.Drawing.Point(174, -1);
            this.lblMHTick.Name = "lblMHTick";
            this.lblMHTick.Size = new System.Drawing.Size(30, 15);
            this.lblMHTick.TabIndex = 20;
            this.lblMHTick.Text = "0";
            this.lblMHTick.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblL
            // 
            this.lblL.BackColor = System.Drawing.Color.Blue;
            this.lblL.ForeColor = System.Drawing.Color.White;
            this.lblL.Location = new System.Drawing.Point(338, -1);
            this.lblL.Name = "lblL";
            this.lblL.Size = new System.Drawing.Size(50, 15);
            this.lblL.TabIndex = 19;
            this.lblL.Text = "0";
            this.lblL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblH
            // 
            this.lblH.BackColor = System.Drawing.Color.Red;
            this.lblH.ForeColor = System.Drawing.Color.White;
            this.lblH.Location = new System.Drawing.Point(1, -1);
            this.lblH.Name = "lblH";
            this.lblH.Size = new System.Drawing.Size(50, 15);
            this.lblH.TabIndex = 18;
            this.lblH.Text = "0";
            this.lblH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblML
            // 
            this.lblML.BackColor = System.Drawing.Color.Green;
            this.lblML.ForeColor = System.Drawing.Color.White;
            this.lblML.Location = new System.Drawing.Point(228, -1);
            this.lblML.Name = "lblML";
            this.lblML.Size = new System.Drawing.Size(50, 15);
            this.lblML.TabIndex = 17;
            this.lblML.Text = "0";
            this.lblML.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMH
            // 
            this.lblMH.BackColor = System.Drawing.Color.Fuchsia;
            this.lblMH.ForeColor = System.Drawing.Color.White;
            this.lblMH.Location = new System.Drawing.Point(118, -1);
            this.lblMH.Name = "lblMH";
            this.lblMH.Size = new System.Drawing.Size(50, 15);
            this.lblMH.TabIndex = 16;
            this.lblMH.Text = "0";
            this.lblMH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuantumLineTradeChart
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
            this.DoubleBuffered = true;
            this.Name = "QuantumLineTradeChart";
            this.Size = new System.Drawing.Size(723, 313);
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
        private System.Windows.Forms.Label lblLTick;
        private System.Windows.Forms.Label lblHTick;
        private System.Windows.Forms.Label lblMLTick;
        private System.Windows.Forms.Label lblMHTick;
        private System.Windows.Forms.Label lblL;
        private System.Windows.Forms.Label lblH;
        private System.Windows.Forms.Label lblML;
        private System.Windows.Forms.Label lblMH;
    }
}
