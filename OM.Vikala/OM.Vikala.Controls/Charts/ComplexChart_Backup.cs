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
    public partial class ComplexChart_Backup : BaseChartControl
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

        public ComplexChart_Backup() 
        {
            InitializeComponent();
            base.IsShowXLine = false;
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        
        public override void View()
        {
            if (ChartData == null) return;

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
                }
            }

            double maxPrice1 = ChartData.Max(m => m.HighPrice);
            double minPrice1 = ChartData.Min(m => m.LowPrice);
            double maxPrice2 = ChartData.Max(m => m.QuantumBaseHighPrice);
            double minPrice2 = ChartData.Min(m => m.QuantumBaseLowPrice);

            double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
            double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;          

            maxPrice = maxPrice + SpaceMaxMin;
            minPrice = minPrice - SpaceMaxMin;
            
            chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            chart.ChartAreas[0].AxisY2.Minimum = minPrice;            
           
            SetScrollBar();
            SetTrackBar();
            DisplayView();

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

        public void SetScrollBar()
        {
            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;

            int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartData.Count) / Convert.ToDouble(displayItemCount))) ;
            int minScrollValue = 1;

            hScrollBar.Minimum = minScrollValue;
            hScrollBar.Maximum = maxScrollValue;
            hScrollBar.Value = maxScrollValue;
            hScrollBar.LargeChange = 1;
            hScrollBar.SmallChange = 1;
        }

        public void SetTrackBar()
        {
            pnlScroll.Visible = IsAutoScrollX;
            int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartData.Count) / Convert.ToDouble(DisplayPointCount)));
            int minScrollValue = 1;

            trackBar.Minimum = minScrollValue;
            trackBar.Maximum = maxScrollValue;
            trackBar.Value = minScrollValue;
            trackBar.LargeChange = 1;
            trackBar.SmallChange = 1;
        }

        public void DisplayView()
        {
            chart.Update();

            int scrollVal = hScrollBar.Value;

            if (scrollVal < hScrollBar.Minimum) scrollVal = hScrollBar.Minimum;
            if (scrollVal > hScrollBar.Maximum) scrollVal = hScrollBar.Maximum;

            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView * DisplaySubItemCount;

            List<S_CandleItemData> viewLists = null;
            int maxDisplayIndex = 0;
            int minDisplayIndex = 0;
            if (scrollVal == hScrollBar.Minimum)
            {
                int maxIndex = ChartData.Count > displayItemCount ? displayItemCount - 1 : ChartData.Count;
                if (displayItemCount > ChartData.Count) displayItemCount = ChartData.Count;
                viewLists = ChartData.GetRange(0, maxIndex);
                maxDisplayIndex = displayItemCount;
                minDisplayIndex = 0;
            }
            else if (scrollVal == hScrollBar.Maximum)
            {
                int minIndex = ChartData.Count < displayItemCount ? 0 : ChartData.Count - displayItemCount;
                if (displayItemCount > ChartData.Count) displayItemCount = ChartData.Count;
                viewLists = ChartData.GetRange(minIndex, ChartData.Count < displayItemCount ? ChartData.Count : displayItemCount);
                maxDisplayIndex = ChartData.Count;
                minDisplayIndex = minIndex;
            }
            else
            {
                int currentIndex = (scrollVal - 1) * displayItemCount;
                if (ChartData.Count < currentIndex + displayItemCount)
                    displayItemCount = ChartData.Count - currentIndex;

                viewLists = ChartData.GetRange(currentIndex, displayItemCount);

                maxDisplayIndex = currentIndex + displayItemCount;
                minDisplayIndex = currentIndex;
            }

            if (viewLists != null)
            {                
                double maxPrice1 = viewLists.Max(m => m.HighPrice);
                double minPrice1 = viewLists.Min(m => m.LowPrice);
                double maxPrice2 = viewLists.Max(m => m.QuantumBaseHighPrice);
                double minPrice2 = viewLists.Min(m => m.QuantumBaseLowPrice);

                double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
                double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
               
                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;

                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;               
            }
        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            DisplayView();
            if (ChartEventInstance != null)
                ChartEventInstance.OnChangeChartScrollBarHandler(this.chart, hScrollBar.Value);
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            
            SetScrollBar();
            DisplayView();
            if (ChartEventInstance != null)
                ChartEventInstance.OnChangeChartTrackBarHandler(this.chart, trackBar.Value);

            SelectedTrackBarValue = (int)trackBar.Value;
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
