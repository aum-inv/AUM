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

namespace OM.Vikala.Controls.Charts
{
    public partial class ANodeLineChart : BaseChartControl
    {
        protected override string Description => "상하밴드";
        public bool IsShowCandle
        {
            get
            {
                return chart.Series[0].Enabled;
            }
            set
            {
                chart.Series[0].Enabled = value;
            }
        }

        public List<S_CandleItemData> ChartData
        {
            get;
            set;
        }
        public List<S_CandleItemData> ChartDataEx1
        {
            get;
            set;
        }
        public List<S_CandleItemData> ChartDataEx2
        {
            get;
            set;
        }

        public void LoadData(string itemCode = ""
            , List<S_CandleItemData> chartData = null
            , List<S_CandleItemData> chartDataEx1 = null
            , List<S_CandleItemData> chartDataEx2 = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            ChartDataEx1 = chartDataEx1;
            ChartDataEx2 = chartDataEx2;

            TotalPointCount = ChartData.Count;
            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                //Summary();
            }));
        }

        public ANodeLineChart()
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }

        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
            
            for(int i = 0; i < ChartData.Count; i++)           
            {
                var item = ChartData[i];

                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);

                var itemEx1 = ChartDataEx1[i];
                var itemEx2 = ChartDataEx2[i];
                chart.Series[1].Points.AddXY(item.DTime, itemEx1.HighPriceAvg + itemEx1.TotalLength); //red
                chart.Series[2].Points.AddXY(item.DTime, itemEx2.LowPriceAvg - itemEx2.TotalLength); //low              
                //chart.Series[3].Points.AddXY(item.DTime, itemEx2.HighPriceAvg); //black
                //chart.Series[3].Points.AddXY(item.DTime, itemEx2.LowPriceAvg); //black
            }
            chart.Series[3].Enabled = false;
            SetTrackBar(); 
            SetScrollBar();           
            DisplayView();

            IsLoaded = true;

            base.View();
        }

        //public void SetScrollBar()
        //{
        //    int trackView = trackBar.Value;
        //    int displayItemCount = DisplayPointCount * trackView;

        //    int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartData.Count) / Convert.ToDouble(displayItemCount)));
        //    int minScrollValue = 1;

        //    hScrollBar.Minimum = minScrollValue;
        //    hScrollBar.Maximum = maxScrollValue;
        //    hScrollBar.Value = maxScrollValue;
        //    hScrollBar.LargeChange = 1;
        //    hScrollBar.SmallChange = 1;
        //}

        //public void SetTrackBar()
        //{
        //    pnlScroll.Visible = IsAutoScrollX;
        //    int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartData.Count) / Convert.ToDouble(DisplayPointCount)));
        //    int minScrollValue = 1;

        //    trackBar.Minimum = minScrollValue;
        //    trackBar.Maximum = maxScrollValue;
        //    trackBar.Value = minScrollValue;
        //    trackBar.LargeChange = 1;
        //    trackBar.SmallChange = 1;
        //}

        public void DisplayView()
        {
            int scrollVal = hScrollBar.Value;
            if (scrollVal < hScrollBar.Minimum) scrollVal = hScrollBar.Minimum;
            if (scrollVal > hScrollBar.Maximum) scrollVal = hScrollBar.Maximum;

            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;            
            List<S_CandleItemData> viewLists = null;
            int maxDisplayIndex = 0;
            int minDisplayIndex = 0;
            if (scrollVal == hScrollBar.Minimum)
            {
                int maxIndex = ChartData.Count > displayItemCount ? displayItemCount - 1 : ChartData.Count;
                if (displayItemCount > ChartData.Count) displayItemCount = ChartData.Count; 
                viewLists = ChartData.GetRange(0, maxIndex);
                //viewListsEx1 = ChartDataEx1.GetRange(0, maxIndex);
                //viewListsEx2 = ChartDataEx2.GetRange(0, maxIndex);
                maxDisplayIndex = displayItemCount;
                minDisplayIndex = 0;
            }
            else if (scrollVal == hScrollBar.Maximum)
            {
                int minIndex = ChartData.Count < displayItemCount ? 0 : ChartData.Count - displayItemCount;
                if (displayItemCount > ChartData.Count) displayItemCount = ChartData.Count;
                viewLists = ChartData.GetRange(minIndex, ChartData.Count < displayItemCount ? ChartData.Count : displayItemCount);
                //viewListsEx1 = ChartDataEx1.GetRange(minIndex, ChartData.Count < displayItemCount ? ChartData.Count : displayItemCount);
                //viewListsEx2 = ChartDataEx2.GetRange(minIndex, ChartData.Count < displayItemCount ? ChartData.Count : displayItemCount);
                maxDisplayIndex = ChartData.Count;
                minDisplayIndex = minIndex;
            }
            else
            {
                int currentIndex = (scrollVal - 1);
                if (ChartData.Count < currentIndex + displayItemCount)
                    displayItemCount = ChartData.Count - currentIndex;
                viewLists = ChartData.GetRange(currentIndex, displayItemCount);
                //viewListsEx1 = ChartDataEx1.GetRange(currentIndex, displayItemCount);
                //viewListsEx2 = ChartDataEx2.GetRange(currentIndex, displayItemCount);

                maxDisplayIndex = currentIndex + displayItemCount;
                minDisplayIndex = currentIndex;
            }
            if (viewLists != null)
            {
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice1 = viewLists.Max(m => m.HighPrice);
                double minPrice1 = viewLists.Min(m => m.LowPrice);
                //double maxPrice2 = viewListsEx1.Max(m => m.CenterPriceAvg);
                //double minPrice2 = viewListsEx1.Min(m => m.CenterPriceAvg);
                //double maxPrice3 = viewListsEx2.Max(m => m.CenterPriceAvg);
                //double minPrice3 = viewListsEx2.Min(m => m.CenterPriceAvg);
                //double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
                //double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
                //maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
                //minPrice = minPrice < minPrice3 ? minPrice : minPrice3;
              
                double maxPrice = maxPrice1;
                double minPrice = minPrice1;
                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
                chart.ChartAreas[0].AxisY2.LabelStyle.Format = "{N2}";
            }

            chart.Update();
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
            SelectedTrackBarValue = (int)trackBar.Value;
            SetScrollBar();
            DisplayView();
            if (ChartEventInstance != null)
                ChartEventInstance.OnChangeChartTrackBarHandler(this.chart, trackBar.Value);
        }

        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
        }
    }
}