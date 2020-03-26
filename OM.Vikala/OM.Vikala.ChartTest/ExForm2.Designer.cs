namespace OM.Vikala.ChartTest
{
    partial class ExForm2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisplayDayEx = new System.Windows.Forms.Button();
            this.chkDisplay180 = new System.Windows.Forms.CheckBox();
            this.btnDisplay120Ex = new System.Windows.Forms.Button();
            this.btnDisplay180Ex = new System.Windows.Forms.Button();
            this.btnDisplay180 = new System.Windows.Forms.Button();
            this.btnDisplay120 = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDisplay60 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnDisplay720Ex = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDisplay720Ex);
            this.panel1.Controls.Add(this.btnDisplayDayEx);
            this.panel1.Controls.Add(this.chkDisplay180);
            this.panel1.Controls.Add(this.btnDisplay120Ex);
            this.panel1.Controls.Add(this.btnDisplay180Ex);
            this.panel1.Controls.Add(this.btnDisplay180);
            this.panel1.Controls.Add(this.btnDisplay120);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnDisplay60);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1538, 38);
            this.panel1.TabIndex = 0;
            // 
            // btnDisplayDayEx
            // 
            this.btnDisplayDayEx.Location = new System.Drawing.Point(185, 5);
            this.btnDisplayDayEx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplayDayEx.Name = "btnDisplayDayEx";
            this.btnDisplayDayEx.Size = new System.Drawing.Size(132, 29);
            this.btnDisplayDayEx.TabIndex = 6;
            this.btnDisplayDayEx.Text = "DisplayDayEx";
            this.btnDisplayDayEx.UseVisualStyleBackColor = true;
            this.btnDisplayDayEx.Click += new System.EventHandler(this.btnDisplayDayEx_Click);
            // 
            // chkDisplay180
            // 
            this.chkDisplay180.AutoSize = true;
            this.chkDisplay180.Location = new System.Drawing.Point(1235, 12);
            this.chkDisplay180.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkDisplay180.Name = "chkDisplay180";
            this.chkDisplay180.Size = new System.Drawing.Size(71, 19);
            this.chkDisplay180.TabIndex = 4;
            this.chkDisplay180.Text = "180Ex";
            this.chkDisplay180.UseVisualStyleBackColor = true;
            this.chkDisplay180.CheckedChanged += new System.EventHandler(this.chkDisplay180_CheckedChanged);
            // 
            // btnDisplay120Ex
            // 
            this.btnDisplay120Ex.Location = new System.Drawing.Point(897, 5);
            this.btnDisplay120Ex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay120Ex.Name = "btnDisplay120Ex";
            this.btnDisplay120Ex.Size = new System.Drawing.Size(114, 29);
            this.btnDisplay120Ex.TabIndex = 5;
            this.btnDisplay120Ex.Text = "Display120Ex";
            this.btnDisplay120Ex.UseVisualStyleBackColor = true;
            this.btnDisplay120Ex.Click += new System.EventHandler(this.btnDisplay120Ex_Click);
            // 
            // btnDisplay180Ex
            // 
            this.btnDisplay180Ex.Location = new System.Drawing.Point(1123, 5);
            this.btnDisplay180Ex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay180Ex.Name = "btnDisplay180Ex";
            this.btnDisplay180Ex.Size = new System.Drawing.Size(105, 29);
            this.btnDisplay180Ex.TabIndex = 4;
            this.btnDisplay180Ex.Text = "Display180Ex";
            this.btnDisplay180Ex.UseVisualStyleBackColor = true;
            this.btnDisplay180Ex.Click += new System.EventHandler(this.btnDisplay180Ex_Click);
            // 
            // btnDisplay180
            // 
            this.btnDisplay180.Location = new System.Drawing.Point(1018, 5);
            this.btnDisplay180.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay180.Name = "btnDisplay180";
            this.btnDisplay180.Size = new System.Drawing.Size(86, 29);
            this.btnDisplay180.TabIndex = 3;
            this.btnDisplay180.Text = "Display180";
            this.btnDisplay180.UseVisualStyleBackColor = true;
            this.btnDisplay180.Click += new System.EventHandler(this.btnDisplay180_Click);
            // 
            // btnDisplay120
            // 
            this.btnDisplay120.Location = new System.Drawing.Point(805, 5);
            this.btnDisplay120.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay120.Name = "btnDisplay120";
            this.btnDisplay120.Size = new System.Drawing.Size(86, 29);
            this.btnDisplay120.TabIndex = 2;
            this.btnDisplay120.Text = "Display120";
            this.btnDisplay120.UseVisualStyleBackColor = true;
            this.btnDisplay120.Click += new System.EventHandler(this.btnDisplay120_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(14, 5);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(86, 29);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDisplay60
            // 
            this.btnDisplay60.Location = new System.Drawing.Point(701, 4);
            this.btnDisplay60.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay60.Name = "btnDisplay60";
            this.btnDisplay60.Size = new System.Drawing.Size(86, 29);
            this.btnDisplay60.TabIndex = 0;
            this.btnDisplay60.Text = "Display60";
            this.btnDisplay60.UseVisualStyleBackColor = true;
            this.btnDisplay60.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1538, 771);
            this.panel2.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart.BackSecondaryColor = System.Drawing.Color.White;
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderlineWidth = 0;
            chartArea3.Area3DStyle.Inclination = 15;
            chartArea3.Area3DStyle.IsClustered = true;
            chartArea3.Area3DStyle.IsRightAngleAxes = false;
            chartArea3.Area3DStyle.Perspective = 10;
            chartArea3.Area3DStyle.Rotation = 10;
            chartArea3.Area3DStyle.WallWidth = 0;
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LabelStyle.Interval = 0D;
            chartArea3.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea3.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.AxisX2.IsLabelAutoFit = false;
            chartArea3.AxisX2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea3.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.AxisY2.IsLabelAutoFit = false;
            chartArea3.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea3.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea3.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea3.BackSecondaryColor = System.Drawing.Color.White;
            chartArea3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.CursorX.LineColor = System.Drawing.Color.Black;
            chartArea3.CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea3.CursorY.LineColor = System.Drawing.Color.Black;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 90F;
            chartArea3.InnerPlotPosition.Width = 93F;
            chartArea3.InnerPlotPosition.X = 2F;
            chartArea3.Name = "chartArea";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 95F;
            chartArea3.Position.Width = 98F;
            chartArea3.Position.Y = 5F;
            chartArea3.ShadowColor = System.Drawing.Color.Transparent;
            this.chart.ChartAreas.Add(chartArea3);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.BorderColor = System.Drawing.Color.Transparent;
            series3.ChartArea = "chartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Color = System.Drawing.Color.Black;
            series3.CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";
            series3.IsXValueIndexed = true;
            series3.Name = "chartSerie";
            series3.ShadowColor = System.Drawing.Color.Transparent;
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.YValuesPerPoint = 4;
            this.chart.Series.Add(series3);
            this.chart.Size = new System.Drawing.Size(1538, 771);
            this.chart.TabIndex = 3;
            this.chart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.chart_AxisViewChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chart2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 809);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1538, 151);
            this.panel3.TabIndex = 2;
            // 
            // chart2
            // 
            this.chart2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart2.BackSecondaryColor = System.Drawing.Color.White;
            this.chart2.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart2.BorderlineWidth = 0;
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
            chartArea4.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
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
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
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
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(1538, 151);
            this.chart2.TabIndex = 4;
            // 
            // btnDisplay720Ex
            // 
            this.btnDisplay720Ex.Location = new System.Drawing.Point(450, 4);
            this.btnDisplay720Ex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDisplay720Ex.Name = "btnDisplay720Ex";
            this.btnDisplay720Ex.Size = new System.Drawing.Size(132, 29);
            this.btnDisplay720Ex.TabIndex = 7;
            this.btnDisplay720Ex.Text = "Display720Ex";
            this.btnDisplay720Ex.UseVisualStyleBackColor = true;
            this.btnDisplay720Ex.Click += new System.EventHandler(this.btnDisplay720Ex_Click);
            // 
            // ExForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 960);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExForm2";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
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
        private System.Windows.Forms.CheckBox chkDisplay180;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btnDisplayDayEx;
        private System.Windows.Forms.Button btnDisplay720Ex;
    }
}

