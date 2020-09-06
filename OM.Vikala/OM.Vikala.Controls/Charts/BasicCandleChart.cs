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
using OM.Vikala.Controls.Properties;
using OM.Lib.Base.Enums;

namespace OM.Vikala.Controls.Charts
{
    public partial class BasicCandleChart : BaseChartControl
    {
        public override CandleChartTypeEnum CandleChartType
        {
            get;
            set;
        } = CandleChartTypeEnum.기본;
                       
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
        public bool IsShowEightRule
        {
            get;
            set;
        } = false;
        public void LoadData(string itemCode = ""
      , List<S_CandleItemData> chartData = null
      , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            LoadData(itemCode, chartData, null, timeInterval);
        }
        public void LoadData(string itemCode = ""
            , List <S_CandleItemData> chartData = null
             , List<S_CandleItemData> chartDataSub = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            ChartDataSub = chartDataSub;
            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                //if (IsShowEightRule)
                //    Annotation();
            }));
        }
        
        public BasicCandleChart() 
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }

        public override void View()
        {
            candlePriceInfo1.Visible = false;
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
            foreach (var item in ChartData)
            {
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                var dataPoint = chart.Series[0].Points[idx];
                dataPoint.Tag = item;

            }
            double maxPrice = ChartData.Max(m => m.HighPrice);
            double minPrice = ChartData.Min(m => m.LowPrice);
            if (CandleChartType == CandleChartTypeEnum.천지인)
            {
                double maxPrice2 = ChartData.Max(m => m.QuantumPrice);
                double minPrice2 = ChartData.Min(m => m.QuantumPrice);
                if (maxPrice < maxPrice2) maxPrice = maxPrice2;
                if (minPrice > minPrice2) minPrice = minPrice2;
            }
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
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice = viewLists.Max(m => m.HighPrice);
                double minPrice = viewLists.Min(m => m.LowPrice);

                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;              
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

        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
        }

        #region CandleChartType
       
        #endregion

        #region Chart Util

        #endregion

        private void chart_MouseClick(object sender, MouseEventArgs e)
        {
            candlePriceInfo1.Visible = false;
            HitTestResult result = chart.HitTest(e.X, e.Y);
           
            if (result.ChartElementType == ChartElementType.DataPoint && result.Series == chart.Series[0])
            {
                
                A_HLOC hloc = ChartData[result.PointIndex];
                candlePriceInfo1.Location = new Point(e.X - 230, candlePriceInfo1.Location.Y);
                candlePriceInfo1.Bind(hloc);

                candlePriceInfo1.Visible = true;
            }            
               }

        private void addImageAnnotation(DataPoint point)
        {
            //return;

          
            ImageAnnotation ia = new ImageAnnotation();
            ia.Image = System.Environment.CurrentDirectory + "\\Resources\\" + "" + ".png";
            ia.IsSizeAlwaysRelative = true;  
            ia.AnchorAlignment = ContentAlignment.TopCenter;
            ia.AnchorDataPoint = point;
            
            chart.Annotations.Add(ia);
        }
    }
}
