using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace OM.Vikala.ChartTest
{
    public partial class ExForm1 : Form
    {
        List<CandleDate> listCandles60 = new List<CandleDate>();
        List<CandleDate> listCandles120 = new List<CandleDate>();
        List<CandleDate> listCandles180 = new List<CandleDate>();
        public ExForm1()
        {
            InitializeComponent();
            InitializeControl();
        }
        public virtual void InitializeControl()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];

            chartArea.AxisX.IsLabelAutoFit = true;
            chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            chartArea.AxisY2.IsLabelAutoFit = true;
            chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            chartArea.AxisY2.LineColor = System.Drawing.Color.DimGray;

            chartArea.BackColor = Color.White;
            chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.None;
            chartArea.BackSecondaryColor = System.Drawing.Color.White;
            chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;

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
        }
       
        private void FillChart(List<CandleDate> listCandles)
        {
            if (listCandles == null)
                return;
            
           
            int blockSize = 100;

            chart.Series[0].Points.Clear();

            foreach(var dc in listCandles)
                chart.Series[0].Points.AddXY(dc.dt, dc.high, dc.low, dc.open, dc.close);
            var chartArea = chart.ChartAreas[chart.Series[0].ChartArea];

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = listCandles.Count;

            chartArea.CursorX.AutoScroll = true;

            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position = listCandles.Count - blockSize;
            int size = listCandles.Count;
            chartArea.AxisX.ScaleView.Zoom(position, size + 1);

            // disable zoom-reset button (only scrollbar's arrows are available)
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            chartArea.AxisX.ScaleView.SmallScrollSize = 10;

            chart_AxisViewChanged(chart, new ViewEventArgs(chartArea.AxisX, size + 1));

        }

        private void chart_AxisViewChanged(object sender, ViewEventArgs e)
        {          
            if (e.Axis.AxisName == AxisName.X)
            {
                int start = (int)e.Axis.ScaleView.ViewMinimum;
                int end = (int)e.Axis.ScaleView.ViewMaximum;
               
                double[] tempHighs = chart.Series[0].Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[0]).ToArray();
                double[] tempLows = chart.Series[0].Points.Where((x, i) => i >= start && i <= end).Select(x => x.YValues[1]).ToArray();
                double ymin = tempLows.Min();
                double ymax = tempHighs.Max();

                chart.ChartAreas[0].AxisX.ScaleView.Position = start + 5;
                            
                chart.ChartAreas[0].AxisY2.ScaleView.Position = ymin;
                chart.ChartAreas[0].AxisY2.ScaleView.Size = ymax - ymin;
                chart.ChartAreas[0].AxisY2.ScrollBar.Enabled = false;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            listCandles60.Clear();
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\wti_60.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    CandleDate cd = new CandleDate();
                    cd.dt = Convert.ToDateTime(values[0].Trim() + " " + values[1].Trim());
                    cd.open = Convert.ToDouble(values[2].Trim());
                    cd.high = Convert.ToDouble(values[3].Trim());
                    cd.low = Convert.ToDouble(values[4].Trim());
                    cd.close = Convert.ToDouble(values[5].Trim());
                    cd.volume = Convert.ToDouble(values[6].Trim());

                    listCandles60.Add(cd);
                }
            }
            listCandles120.Clear();
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\wti_120.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    CandleDate cd = new CandleDate();
                    cd.dt = Convert.ToDateTime(values[0].Trim() + " " + values[1].Trim());
                    cd.open = Convert.ToDouble(values[2].Trim());
                    cd.high = Convert.ToDouble(values[3].Trim());
                    cd.low = Convert.ToDouble(values[4].Trim());
                    cd.close = Convert.ToDouble(values[5].Trim());
                    cd.volume = Convert.ToDouble(values[6].Trim());

                    listCandles120.Add(cd);
                }
            }
            listCandles180.Clear();
            using (var reader = new StreamReader(Environment.CurrentDirectory + "\\wti_180.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    CandleDate cd = new CandleDate();
                    cd.dt = Convert.ToDateTime(values[0].Trim() + " " + values[1].Trim());
                    cd.open = Convert.ToDouble(values[2].Trim());
                    cd.high = Convert.ToDouble(values[3].Trim());
                    cd.low = Convert.ToDouble(values[4].Trim());
                    cd.close = Convert.ToDouble(values[5].Trim());
                    cd.volume = Convert.ToDouble(values[6].Trim());

                    listCandles180.Add(cd);
                }
            }           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FillChart(listCandles60);
        }
        private void btnDisplay120_Click(object sender, EventArgs e)
        {
            FillChart(listCandles120);
        }

        private void btnDisplay180_Click(object sender, EventArgs e)
        {
            FillChart(listCandles180);
        }
    }

    //class CandleDate
    //{
    //    public DateTime dt;
    //    public double open;
    //    public double high;
    //    public double low;
    //    public double close;
    //    public double volume;
    //}
}
