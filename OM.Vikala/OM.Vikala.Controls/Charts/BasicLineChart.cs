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
    public partial class BasicLineChart : BaseChartControl
    {
        public override LineChartTypeEnum LineChartType
        {
            get;
            set;
        } = LineChartTypeEnum.기본;

        
        public bool IsUseLine1
        {
            get { return chart.Series[0].Enabled; }
            set { chart.Series[0].Enabled = value; }
        }
        public bool IsUseLine2
        {
            get { return chart.Series[1].Enabled; }
            set { chart.Series[1].Enabled = value; }
        }
        public bool IsUseLine3
        {
            get { return chart.Series[2].Enabled; }
            set { chart.Series[2].Enabled = value; }
        }
        public bool IsUseLine4
        {
            get { return chart.Series[3].Enabled; }
            set { chart.Series[3].Enabled = value; }
        }

        public List<S_LineItemData> ChartData
        {
            get;
            set;
        }

        public void LoadData(string itemCode = ""
            , List<S_LineItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
            }));
        }

        public BasicLineChart()
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        
        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
           
            foreach (var item in ChartData)
            {
                if (chart.Series[0].Enabled) chart.Series[0].Points.AddXY(item.DTime, item.ClosePrice1);
                if (chart.Series[1].Enabled) chart.Series[1].Points.AddXY(item.DTime, item.ClosePrice2);
                if (chart.Series[2].Enabled) chart.Series[2].Points.AddXY(item.DTime, item.ClosePrice3);
                if (chart.Series[3].Enabled) chart.Series[3].Points.AddXY(item.DTime, item.ClosePrice4);                        
            }
            double maxPrice = IsUseLine1 ? ChartData.Max(m => m.ClosePrice1) : ChartData.Max(m => m.ClosePrice1);
            double minPrice = IsUseLine1 ? ChartData.Min(m => m.ClosePrice1) : ChartData.Min(m => m.ClosePrice1);
            double maxPrice2 = IsUseLine2 ? ChartData.Max(m => m.ClosePrice2) : ChartData.Max(m => m.ClosePrice1);
            double minPrice2 = IsUseLine2 ? ChartData.Min(m => m.ClosePrice2) : ChartData.Min(m => m.ClosePrice1);
            double maxPrice3 = IsUseLine3 ? ChartData.Max(m => m.ClosePrice3) : ChartData.Max(m => m.ClosePrice1);
            double minPrice3 = IsUseLine3 ? ChartData.Min(m => m.ClosePrice3) : ChartData.Min(m => m.ClosePrice1);
            double maxPrice4 = IsUseLine4 ? ChartData.Max(m => m.ClosePrice4) : ChartData.Max(m => m.ClosePrice1);
            double minPrice4 = IsUseLine4 ? ChartData.Min(m => m.ClosePrice4) : ChartData.Min(m => m.ClosePrice1);

            if (maxPrice < maxPrice2) maxPrice = maxPrice2;
            if (minPrice > minPrice2) minPrice = minPrice2;
            if (maxPrice < maxPrice3) maxPrice = maxPrice3;
            if (minPrice > minPrice3) minPrice = minPrice3;
            if (maxPrice < maxPrice4) maxPrice = maxPrice4;
            if (minPrice > minPrice4) minPrice = minPrice4;

            maxPrice = maxPrice + SpaceMaxMin;
            minPrice = minPrice - SpaceMaxMin;
            chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            chart.ChartAreas[0].AxisY2.Minimum = minPrice;

            SetScrollBar();
            SetTrackBar();
            DisplayView();

            IsLoaded = true;

            base.View();
        }

        public void SetScrollBar()
        {
            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;

            int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartData.Count) / Convert.ToDouble(displayItemCount)));
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
            int displayItemCount = DisplayPointCount * trackView;

            List<S_LineItemData> viewLists = null;
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
                double maxPrice = IsUseLine1 ? viewLists.Max(m => m.ClosePrice1) : viewLists.Max(m => m.ClosePrice1);
                double minPrice = IsUseLine1 ? viewLists.Min(m => m.ClosePrice1) : viewLists.Min(m => m.ClosePrice1);
                double maxPrice2 = IsUseLine2 ? viewLists.Max(m => m.ClosePrice2) : viewLists.Max(m => m.ClosePrice1);
                double minPrice2 = IsUseLine2 ? viewLists.Min(m => m.ClosePrice2) : viewLists.Min(m => m.ClosePrice1);
                double maxPrice3 = IsUseLine3 ? viewLists.Max(m => m.ClosePrice3) : viewLists.Max(m => m.ClosePrice1);
                double minPrice3 = IsUseLine3 ? viewLists.Min(m => m.ClosePrice3) : viewLists.Min(m => m.ClosePrice1);
                double maxPrice4 = IsUseLine4 ? viewLists.Max(m => m.ClosePrice4) : viewLists.Max(m => m.ClosePrice1);
                double minPrice4 = IsUseLine4 ? viewLists.Min(m => m.ClosePrice4) : viewLists.Min(m => m.ClosePrice1);

                if (maxPrice < maxPrice2) maxPrice = maxPrice2;
                if (minPrice > minPrice2) minPrice = minPrice2;
                if (maxPrice < maxPrice3) maxPrice = maxPrice3;
                if (minPrice > minPrice3) minPrice = minPrice3;
                if (maxPrice < maxPrice4) maxPrice = maxPrice4;
                if (minPrice > minPrice4) minPrice = minPrice4;

                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;
            }
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            //if (!IsLoaded) return;
            //DisplayView();
            //if (ChartEventInstance != null)
            //    ChartEventInstance.OnChangeChartScrollBarHandler(this.chart, hScrollBar.Value);
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            //if (!IsLoaded) return;
            //SetScrollBar();
            //DisplayView();
            //if(ChartEventInstance != null)
            //    ChartEventInstance.OnChangeChartTrackBarHandler(this.chart, trackBar.Value);
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