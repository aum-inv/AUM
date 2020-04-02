using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.PP.Chakra;
using System.Windows.Forms.DataVisualization.Charting;
using OM.Lib.Base.Utils;

namespace OM.Vikala.Controls.Charts
{
    public partial class ComplexChart : BaseChartControl
    {
        protected override string Description => "";

        public bool IsShowCandle
        {
            get;
            set;
        } = false;
        public bool IsShowLine
        {
            get;
            set;
        } = false;
        public bool IsQuantum
        {
            get;
            set;
        } = false;
        public bool IsQuantum2
        {
            get;
            set;
        } = false; 
        
        public int DisplaySubItemCount
        {
            get;
            set;
        } = 2;

        public List<S_CandleItemData> ChartData
        {
            get;
            set;
        }
        public List<S_CandleItemData> ChartDataSub
        {
            get;
            set;
        }
        public void LoadData(string itemCode = ""
            , List<S_CandleItemData> chartData = null
            , List<S_CandleItemData> chartDataSub = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            if (itemCode != ItemCode || TimeInterval != timeInterval)
            {
                clearAnnotation();
            }

            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            ChartDataSub = chartDataSub;

            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                Summary();
            }));           
        }        

        public ComplexChart() 
        {
            InitializeComponent();
            base.IsShowXLine = false;
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        
        public override void View()
        {
            if (ChartData == null) return;

            int candleCount = 0;
           
            foreach (S_CandleItemData item in ChartData)
            {
                int idx = -1;
                if (!IsQuantum)
                {
                    idx = chart.Series[0].Points.AddXY(
                        item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                }
                else
                {
                    idx = chart.Series[0].Points.AddXY(
                            item.DTime, item.QuantumBaseHighPrice, item.QuantumBaseLowPrice, item.OpenPrice, item.QuantumBasePrice);
                }        
                SetDataPointColor(chart.Series[0].Points[idx], Color.Black, Color.Black, Color.Black, 1);
                candleCount++;

                var list = FindCandles(item);

                foreach (var subItem in list)
                {
                    int idx2 = -1;
                    if (!IsQuantum2)
                        idx2 = chart.Series[0].Points.AddXY(
                            subItem.DTime, subItem.HighPrice, subItem.LowPrice, subItem.OpenPrice, subItem.ClosePrice);
                    else
                        idx2 = chart.Series[0].Points.AddXY(
                            subItem.DTime, subItem.QuantumBaseHighPrice, subItem.QuantumBaseLowPrice, subItem.OpenPrice, subItem.QuantumBasePrice);
                    
                    candleCount++;
                }
            }

            DisplayView(candleCount);

            IsLoaded = true;

            base.View();

            chart.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd:HH";
        }
        private List<S_CandleItemData> FindCandles(S_CandleItemData candle)
        {
            List<S_CandleItemData> sourcesList = ChartDataSub;
            List<S_CandleItemData> findLists = new List<S_CandleItemData>();

            int idx = sourcesList.FindIndex(t => t.DTime >= candle.DTime);

            if (idx > DisplaySubItemCount)
            {
                int findIndex = idx;
                int findLength = idx + DisplaySubItemCount;

                for (int i = findIndex; i < findLength; i++)
                {
                    if (sourcesList.Count > i)
                        findLists.Add(sourcesList[i]);
                }
            }

            return findLists;
        }

        
        public void DisplayView(int candleCount)
        {
            var chartArea = chart.ChartAreas[chart.Series[0].ChartArea];
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = candleCount;
            chartArea.CursorX.AutoScroll = true;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chartArea.AxisX.ScaleView.SizeType = DateTimeIntervalType.Number;
            int position = candleCount - DisplayPointCount;
            int size = candleCount;
            chartArea.AxisX.ScaleView.Zoom(position, size + 1);
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
        #region Chart Util

        #endregion

        private void chart_MouseDown(object sender, MouseEventArgs e)
        {  
            chart.Annotations.Clear();          
        }
      
       
        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
        }
        private void clearAnnotation()
        {
            chart.Annotations.Clear();
            lblQPrice.Visible = false;
        }
    }
}
