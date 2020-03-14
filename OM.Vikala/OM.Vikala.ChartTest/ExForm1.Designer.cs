namespace OM.Vikala.ChartTest
{
    partial class ExForm1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisplay180Ex = new System.Windows.Forms.Button();
            this.btnDisplay180 = new System.Windows.Forms.Button();
            this.btnDisplay120 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDisplay60 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDisplay120Ex = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDisplay120Ex);
            this.panel1.Controls.Add(this.btnDisplay180Ex);
            this.panel1.Controls.Add(this.btnDisplay180);
            this.panel1.Controls.Add(this.btnDisplay120);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnDisplay60);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1346, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnDisplay180Ex
            // 
            this.btnDisplay180Ex.Location = new System.Drawing.Point(983, 4);
            this.btnDisplay180Ex.Name = "btnDisplay180Ex";
            this.btnDisplay180Ex.Size = new System.Drawing.Size(92, 23);
            this.btnDisplay180Ex.TabIndex = 4;
            this.btnDisplay180Ex.Text = "Display180Ex";
            this.btnDisplay180Ex.UseVisualStyleBackColor = true;
            this.btnDisplay180Ex.Click += new System.EventHandler(this.btnDisplay180Ex_Click);
            // 
            // btnDisplay180
            // 
            this.btnDisplay180.Location = new System.Drawing.Point(891, 4);
            this.btnDisplay180.Name = "btnDisplay180";
            this.btnDisplay180.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay180.TabIndex = 3;
            this.btnDisplay180.Text = "Display180";
            this.btnDisplay180.UseVisualStyleBackColor = true;
            this.btnDisplay180.Click += new System.EventHandler(this.btnDisplay180_Click);
            // 
            // btnDisplay120
            // 
            this.btnDisplay120.Location = new System.Drawing.Point(704, 4);
            this.btnDisplay120.Name = "btnDisplay120";
            this.btnDisplay120.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay120.TabIndex = 2;
            this.btnDisplay120.Text = "Display120";
            this.btnDisplay120.UseVisualStyleBackColor = true;
            this.btnDisplay120.Click += new System.EventHandler(this.btnDisplay120_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(12, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDisplay60
            // 
            this.btnDisplay60.Location = new System.Drawing.Point(613, 3);
            this.btnDisplay60.Name = "btnDisplay60";
            this.btnDisplay60.Size = new System.Drawing.Size(75, 23);
            this.btnDisplay60.TabIndex = 0;
            this.btnDisplay60.Text = "Display60";
            this.btnDisplay60.UseVisualStyleBackColor = true;
            this.btnDisplay60.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1346, 738);
            this.panel2.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart.BackSecondaryColor = System.Drawing.Color.White;
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderlineWidth = 0;
            chartArea4.Area3DStyle.Inclination = 15;
            chartArea4.Area3DStyle.IsClustered = true;
            chartArea4.Area3DStyle.IsRightAngleAxes = false;
            chartArea4.Area3DStyle.Perspective = 10;
            chartArea4.Area3DStyle.Rotation = 10;
            chartArea4.Area3DStyle.WallWidth = 0;
            chartArea4.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisX.LabelStyle.Interval = 0D;
            chartArea4.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea4.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX2.IsLabelAutoFit = false;
            chartArea4.AxisX2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea4.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY2.IsLabelAutoFit = false;
            chartArea4.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea4.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea4.BackColor = System.Drawing.Color.White;
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.BackSecondaryColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.CursorX.LineColor = System.Drawing.Color.Black;
            chartArea4.CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea4.CursorY.LineColor = System.Drawing.Color.Black;
            chartArea4.InnerPlotPosition.Auto = false;
            chartArea4.InnerPlotPosition.Height = 90F;
            chartArea4.InnerPlotPosition.Width = 93F;
            chartArea4.InnerPlotPosition.X = 2F;
            chartArea4.Name = "chartArea";
            chartArea4.Position.Auto = false;
            chartArea4.Position.Height = 95F;
            chartArea4.Position.Width = 98F;
            chartArea4.Position.Y = 5F;
            chartArea4.ShadowColor = System.Drawing.Color.Transparent;
            this.chart.ChartAreas.Add(chartArea4);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series4.BorderColor = System.Drawing.Color.Transparent;
            series4.ChartArea = "chartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series4.Color = System.Drawing.Color.Black;
            series4.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series4.IsXValueIndexed = true;
            series4.Name = "chartSerie";
            series4.ShadowColor = System.Drawing.Color.Transparent;
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.YValuesPerPoint = 4;
            this.chart.Series.Add(series4);
            this.chart.Size = new System.Drawing.Size(1346, 738);
            this.chart.TabIndex = 3;
            this.chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart_AxisViewChanged);
            // 
            // btnDisplay120Ex
            // 
            this.btnDisplay120Ex.Location = new System.Drawing.Point(785, 4);
            this.btnDisplay120Ex.Name = "btnDisplay120Ex";
            this.btnDisplay120Ex.Size = new System.Drawing.Size(100, 23);
            this.btnDisplay120Ex.TabIndex = 5;
            this.btnDisplay120Ex.Text = "Display120Ex";
            this.btnDisplay120Ex.UseVisualStyleBackColor = true;
            this.btnDisplay120Ex.Click += new System.EventHandler(this.btnDisplay120Ex_Click);
            // 
            // ExForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 768);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ExForm1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDisplay60;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDisplay180;
        private System.Windows.Forms.Button btnDisplay120;
        private System.Windows.Forms.Button btnDisplay180Ex;
        private System.Windows.Forms.Button btnDisplay120Ex;
    }
}

