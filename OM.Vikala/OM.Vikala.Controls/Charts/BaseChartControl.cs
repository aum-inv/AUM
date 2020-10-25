using OM.Lib.Base.Enums;
using OM.PP.Chakra;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OM.Vikala.Controls.Charts
{
    public class BaseChartControl : UserControl
    {
        public BaseChartControl() {
            InitializeComponent();
        }

        protected virtual string Description
        {
            get;
        } = "";
        public string SelectedPType
        {
            get; set;
        } = "";

        private Chart chart;
        private HScrollBar hScrollBar;
        private TrackBar trackBar;

        public HorizontalLineAnnotation yLine = new HorizontalLineAnnotation();
        public List<VerticalLineAnnotation> xLines = new List<VerticalLineAnnotation>();

        Label yLineLabel = new Label();
        Label xLineLabel = new Label();
        public int SelectedTrackBarValue
        {
            get; set;
        } = 1;

        public virtual double SpaceMaxMin
        {
            get
            {
                int round = ItemCodeSet.GetItemRoundNum(ItemCode);

                if (ItemCode == "001" || ItemCode == "101" || ItemCode == "301")
                    round = 2;

                if (round == 0) return 1;
                else if (round == 1) return 0.5;
                else if (round == 2) return 0.05;
                else if (round == 3) return 0.005;
                else if (round == 4) return 0.0005;
                else if (round == 5) return 0.00005;

                return 1;
            }
        }

        public virtual string Title
        {
            get;
            set;
        }
        public ChartEvents ChartEventInstance
        {
            get;
            set;
        } = null;

        public int DisplayPointCount
        {
            get;
            set;
        } = 120;

        public string ItemCode
        {
            get;
            set;
        } = "";

        public int RoundLength
        {
            get
            {
                return ItemCodeSet.GetItemRoundNum(ItemCode);
            }
        }
        public bool IsLoaded
        {
            get;
            set;
        } = false;

        public virtual bool IsAutoScrollX
        {
            get;
            set;
        } = true;
        public virtual bool IsShowXLine
        {
            get;
            set;
        } = true;
        public virtual bool IsShowYLine
        {
            get;
            set;
        } = true;

        public virtual bool IsEnabledDrawLine
        {
            get;
            set;
        } = true;
        public virtual Lib.Base.Enums.TimeIntervalEnum TimeInterval
        {
            get;
            set;
        } = Lib.Base.Enums.TimeIntervalEnum.Day;

        public virtual CandleChartTypeEnum CandleChartType
        {
            get;
            set;
        } = CandleChartTypeEnum.기본;

        public virtual LineChartTypeEnum LineChartType
        {
            get;
            set;
        } = LineChartTypeEnum.기본;

        public System.Windows.Forms.DataVisualization.Charting.ChartArea CurrentChartArea
        {
            get
            {
                return chart.ChartAreas[0];
            }
        }

        public System.Windows.Forms.DataVisualization.Charting.Series CurrentSeries
        {
            get
            {
                return chart.Series[0];
            }
        }
        public System.Windows.Forms.DataVisualization.Charting.SeriesCollection Series
        {
            get
            {
                return chart.Series;
            }
        }

        public void SetChartControl(Chart chart, HScrollBar hScrollBar, TrackBar trackBar)
        {
            this.chart = chart;
            this.hScrollBar = hScrollBar;
            this.trackBar = trackBar;
        }

        public virtual void InitializeControl()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];

            chartArea.Area3DStyle.Inclination = 15;
            chartArea.Area3DStyle.IsClustered = true;
            chartArea.Area3DStyle.IsRightAngleAxes = false;
            chartArea.Area3DStyle.Perspective = 10;
            chartArea.Area3DStyle.Rotation = 10;
            chartArea.Area3DStyle.WallWidth = 0;
            chartArea.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea.AxisX.IsLabelAutoFit = false;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX.LabelStyle.Interval = 0D;
            chartArea.AxisX.LabelStyle.IntervalOffset = 0D;
            chartArea.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea.AxisX2.IsLabelAutoFit = false;
            chartArea.AxisX2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea.AxisY.IsLabelAutoFit = false;
            chartArea.AxisY.IsStartedFromZero = false;
            chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea.AxisY.LineColor = System.Drawing.Color.White;
            chartArea.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea.AxisY.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea.AxisY2.IsLabelAutoFit = false;
            chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea.AxisY2.MinorTickMark.LineColor = System.Drawing.Color.DimGray;
            chartArea.BackColor = System.Drawing.Color.White;
            chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea.BackSecondaryColor = System.Drawing.Color.White;
            chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea.CursorX.LineColor = System.Drawing.Color.Black;
            chartArea.CursorY.AxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            chartArea.CursorY.LineColor = System.Drawing.Color.Black;

            //chartArea.AxisX.IsLabelAutoFit = true;
            //chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            //chartArea.AxisX.LineColor = System.Drawing.Color.DimGray;
            //chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            //chartArea.AxisY2.IntervalType = DateTimeIntervalType.NotSet;           
            //chartArea.AxisY2.IsLabelAutoFit = true;
            //chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //chartArea.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            //chartArea.AxisY2.LineColor = System.Drawing.Color.DimGray;

            //chartArea.BackColor = Color.White;
            //chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.None;
            //chartArea.BackSecondaryColor = System.Drawing.Color.White;
            //chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;

            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.Height = 90F;
            chartArea.InnerPlotPosition.Width = 95F;
            chartArea.InnerPlotPosition.Y = 2F;
            chartArea.InnerPlotPosition.X = 2F;
            chartArea.Name = "chartArea";

            chartArea.Position.Auto = false;
            chartArea.Position.Height = 95F;
            chartArea.Position.Width = 98F;
            chartArea.Position.Y = 2F;
            chartArea.ShadowColor = System.Drawing.Color.Transparent;

            if (IsShowXLine) createXYLineAnnotation();
            if (IsShowYLine) createYXLineAnnotation();

            chart.MouseClick += Chart_MouseClick;
        }
        private void Chart_MouseClick(object sender, MouseEventArgs e)
        {
        }

        public virtual void InitializeEvent(ChartEvents chartEvents)
        {
            if (chartEvents != null)
            {
                ChartEventInstance = chartEvents;
                ChartEventInstance.ChangeChartScrollBarHandler += (e, v) =>
                {
                    if (!IsLoaded) return;
                    if (this.chart == e) return;
                    if (this.hScrollBar.Maximum < v) v = this.hScrollBar.Maximum;
                    this.hScrollBar.Value = v;
                };
                ChartEventInstance.ChangeChartTrackBarHandler += (e, v) =>
                {
                    if (!IsLoaded) return;
                    if (this.chart == e) return;
                    if (this.trackBar.Maximum < v) v = this.trackBar.Maximum;
                    this.trackBar.Value = v;
                };
            }
            if (IsShowXLine)
            {
                chart.MouseMove += Chart_MouseMove;
                chart.MouseLeave += Chart_MouseLeave;
                chart.MouseDown += Chart_MouseDown;
            }
        }

        public void Reset()
        {
            chart.Annotations.Clear();

            foreach (var s in chart.Series)
                s.Points.Clear();

            IsLoaded = false;
            hScrollBar.Minimum = hScrollBar.Maximum = hScrollBar.Value = 1;
            trackBar.Minimum = trackBar.Maximum = trackBar.Value = 1;
        }

        public virtual void Summary()
        {
        }

        public virtual void View() {
            if (SelectedTrackBarValue > 1)
            {
                if (trackBar.Maximum < SelectedTrackBarValue)
                    trackBar.Value = trackBar.Maximum;
                else
                {
                    if (this.trackBar.Maximum < SelectedTrackBarValue) SelectedTrackBarValue = this.trackBar.Maximum;
                    trackBar.Value = SelectedTrackBarValue;
                }
            }

            foreach (var ca in chart.ChartAreas)
            {
                if (TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Month
                    || TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Week
                    || TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Day)
                    ca.AxisX.LabelStyle.Format = "yy/MM/dd";
                else
                    ca.AxisX.LabelStyle.Format = "MM/dd HH:mm";

                ca.AxisY2.LabelStyle.Format = "{N" + RoundLength + "}";
                ca.AxisY.LabelStyle.Format = "{N" + RoundLength + "}";
            }
        }
        public virtual void SetYFormat(string format)
        {
            try
            {
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];
                chartArea.AxisY2.LabelStyle.Format = format;
            }
            catch (Exception ex) { string err = ex.Message; }
        }
        public virtual void SetXFormat(string format)
        {
            try
            {
                System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];
                chartArea.AxisX.LabelStyle.Format = format;
            }
            catch (Exception ex) { string err = ex.Message; }
        }
        public virtual void SetYInterval(Axis axis, double min, double max, double interval = 0)
        {
            if (interval > 0)
            {
                axis.IntervalType = DateTimeIntervalType.NotSet;
                axis.Interval = interval;
                return;
            }
            if (max > 0 && min > 0)
            {
                double dx = 15.0;

                axis.IntervalType = DateTimeIntervalType.NotSet;
                axis.Interval = Math.Round((max - min) / dx, RoundLength);
                return;
            }
        }
        public virtual void SetXInterval(Axis axis, double min, double max, double interval = 0)
        {
            if (interval > 0)
            {
                axis.Interval = interval;
                return;
            }
        }
        public void BoldLine(string type)
        {
            foreach (var s in chart.Series)
            {
                if (s.ChartType == SeriesChartType.Line || s.ChartType == SeriesChartType.Spline)
                {
                    if (type == "+")
                        s.BorderWidth += 1;
                    else if (type == "-")
                        s.BorderWidth -= 1;

                    if (s.BorderWidth <= 0)
                        s.BorderWidth = 1;
                }
            }
        }
        public void DrawChartTitle(ChartPaintEventArgs e)
        {
            if (string.IsNullOrEmpty(Title)) return;
            //if (string.IsNullOrEmpty(Description)) return;
            string drawString = $"{Title}";
            System.Drawing.Font drawFont = new System.Drawing.Font("돋움", 8);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
            float x = 1.0F;
            float y = 0.0F;
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.FormatFlags = System.Drawing.StringFormatFlags.NoWrap;
            e.ChartGraphics.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            drawFont.Dispose();
            drawBrush.Dispose();
        }
        public void SetCandleColor(int idx, string plusColor = "Red", string minusColor = "Blue")
        {
            this.Invoke(new Action(() =>
            {
                this.chart.Series[idx].CustomProperties = $"PriceDownColor={minusColor}, PriceUpColor={plusColor}";
            }));
        }

        public void SetDataPointColor(
               DataPoint dataPoint
           , Color? headlegColor = null
           , Color? bodyLineColor = null
           , Color? bodyColor = null
           , int borderWidth = 1)
        {
            if (headlegColor != null) dataPoint.Color = headlegColor.Value;
            if (bodyLineColor != null) dataPoint.BorderColor = bodyLineColor.Value;
            if (bodyColor != null) dataPoint.SetCustomProperty("PriceUpColor", bodyColor.Value.Name);
            if (bodyColor != null) dataPoint.SetCustomProperty("PriceDownColor", bodyColor.Value.Name);
            dataPoint.BorderWidth = borderWidth;
        }
        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (chart.Annotations.Count == 0)
            {
                createXYLineAnnotation();
                createYXLineAnnotation();
            }

            HitTestResult result = chart.HitTest(e.X, e.Y);
            if (result.ChartArea == null) return;

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = result.ChartArea;           
            int minX = 0, minY = 0, maxX = 0, maxY = 0;

            if (chartArea.Name == "ca1" || chart.ChartAreas.Count == 1)
            {
                minX = (int)chartArea.Position.X;
                maxX = (int)chartArea.Position.X + (int)(chartArea.Position.Width * chart.Width / 100);
                minY = (int)chartArea.Position.Y;
                maxY = (int)chartArea.Position.Y + (int)(chartArea.Position.Height * chart.Height / 100);

                if (e.Location.X < minX) return;
                if (e.Location.X > maxX - 50) return;
                if (e.Location.Y < minY) return;
                if (e.Location.Y > maxY - 20) return;

               
                var yv = chart.ChartAreas[0].AxisY2.PixelPositionToValue(e.Y);

                if (Double.IsInfinity(yv) || Double.IsNaN(yv))
                    return;

                yLine.AnchorY = yv;
                yLineLabel.Visible = true;
                yLineLabel.Location = new Point(minX, e.Location.Y);
                yLineLabel.Text = Math.Round(yv, ItemCodeSet.GetItemRoundNum(ItemCode)).ToString();
            }

            var xv = chart.ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            if (Double.IsInfinity(xv) || Double.IsNaN(xv))
                return;

            xLineLabel.Location = new Point(e.Location.X - 10, maxY - 20);
            if (result.PointIndex > -1)
            {
                var dtime = DateTime.FromOADate(result.Series.Points[result.PointIndex].XValue);
                xLineLabel.Text = dtime.ToString(chartArea.AxisX.LabelStyle.Format);
                xLineLabel.Visible = true;
            }
            else
            {
                xLineLabel.Visible = false;
            }

            foreach(var xLine in xLines)
                xLine.AnchorX = xv;
        }
        private void Chart_MouseLeave(object sender, EventArgs e)
        {
            yLine.AnchorY = 0;
            yLineLabel.Visible = false;

            foreach (var xLine in xLines)
            {
                xLine.AnchorX = 0;
                xLineLabel.Visible = false;
            }
        }
        public void Chart_MouseDown(object sender, MouseEventArgs e)
        {
            //chart.Annotations.Clear();
        }

        protected void createXYLineAnnotation()
        {
            yLine.AxisX = chart.ChartAreas[0].AxisX;
            yLine.AxisY = chart.ChartAreas[0].AxisY2;
            yLine.IsSizeAlwaysRelative = false;
            yLine.AnchorY = 0;
            yLine.IsInfinitive = true;
            yLine.ClipToChartArea = chart.ChartAreas[0].Name;
            yLine.LineColor = Color.Gray;
            yLine.LineWidth = 1;
            chart.Annotations.Add(yLine);

            yLineLabel.Text = "";
            yLineLabel.Visible = false;
            yLineLabel.AutoSize = true;
            yLineLabel.BackColor = Color.Gray;
            yLineLabel.ForeColor = Color.White;
            yLineLabel.BorderStyle = BorderStyle.None;
            yLineLabel.Height = 15;
            yLineLabel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            chart.Controls.Add(yLineLabel);
        }
        protected void createYXLineAnnotation()
        { 
            foreach(ChartArea c in chart.ChartAreas)
            {
                VerticalLineAnnotation xLine = new VerticalLineAnnotation();
                xLine.AxisX = c.AxisX;
                xLine.AxisY = c.AxisY2;
                xLine.IsSizeAlwaysRelative = false;
                xLine.AnchorX = 0;
                xLine.IsInfinitive = true;
                xLine.ClipToChartArea = c.Name;
                xLine.LineColor = Color.Gray;
                xLine.LineWidth = 1;
                chart.Annotations.Add(xLine);

                xLines.Add(xLine);
            }

            xLineLabel.Text = "";
            xLineLabel.Visible = false;
            xLineLabel.AutoSize = true;
            xLineLabel.BackColor = Color.Gray;
            xLineLabel.ForeColor = Color.White;
            xLineLabel.BorderStyle = BorderStyle.None;
            xLineLabel.Height = 15;
            xLineLabel.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            chart.Controls.Add(xLineLabel);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseChartControl
            // 
            this.Name = "BaseChartControl";
            this.Size = new System.Drawing.Size(1083, 749);
            this.ResumeLayout(false);

        }
    }
}
