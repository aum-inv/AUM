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
    public partial class BuySellLineChart : BaseChartControl
    {
        public override CandleChartTypeEnum CandleChartType
        {
            get;
            set;
        } = CandleChartTypeEnum.기본;
                       
        public List<T_QuantumItemData> ChartDataSub1
        {
            get;
            set;
        }
        public List<T_QuantumItemData> ChartDataSub2
        {
            get;
            set;
        }
        public List<T_QuantumItemData> ChartDataSub3
        {
            get;
            set;
        }
        public List<T_QuantumItemData> ChartDataSub4
        {
            get;
            set;
        }

        public void LoadData(string itemCode = ""
            , List<T_QuantumItemData> chartDataSub1 = null
            , List<T_QuantumItemData> chartDataSub2 = null
            , List<T_QuantumItemData> chartDataSub3 = null
            , List<T_QuantumItemData> chartDataSub4 = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Minute_01)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartDataSub1 = chartDataSub1;
            ChartDataSub2 = chartDataSub2;
            ChartDataSub3 = chartDataSub3;
            ChartDataSub4 = chartDataSub4;

            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
            }));
        }
        List<SmartCandleData> smartDataList1 = new List<SmartCandleData>();
        List<SmartCandleData> smartDataList2 = new List<SmartCandleData>();
        List<SmartCandleData> smartDataList3 = new List<SmartCandleData>();
        List<SmartCandleData> smartDataList4 = new List<SmartCandleData>();

        public BuySellLineChart() 
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
       
        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;

            smartDataList1.Clear();
            smartDataList2.Clear();
            smartDataList3.Clear();
            smartDataList4.Clear();

            SmartCandleData preSmartData = null; 
            for (int i = 0; i < ChartDataSub1.Count; i++)
            {
                var cData = ChartDataSub1[i];
                SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);
                smartDataList1.Add(smartData);
                preSmartData = smartData;
            }
            preSmartData = null;
            for (int i = 0; i < ChartDataSub2.Count; i++)
            {
                var cData = ChartDataSub2[i];
                SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);
                smartDataList2.Add(smartData);
                preSmartData = smartData;
            }
            preSmartData = null;
            for (int i = 0; i < ChartDataSub3.Count; i++)
            {
                var cData = ChartDataSub3[i];
                SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);
                smartDataList3.Add(smartData);
                preSmartData = smartData;
            }
            preSmartData = null;
            for (int i = 0; i < ChartDataSub4.Count; i++)
            {
                var cData = ChartDataSub4[i];
                SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);
                smartDataList4.Add(smartData);
                preSmartData = smartData;
            }

            for (int i = 0; i < smartDataList1.Count; i++)
            {
                var item1 = smartDataList1[i];             
                int idx = chart.Series[0].Points.AddXY(item1.DTime, item1.Variance_ChartPrice1);

                var item2 = smartDataList2.Where(t => (t.DTime < item1.DTime)).Last();
                chart.Series[1].Points.AddXY(item1.DTime, item2.Variance_ChartPrice1 / 6.0);

                var item3 = smartDataList3.Where(t => (t.DTime < item1.DTime)).Last();
                chart.Series[2].Points.AddXY(item1.DTime, item3.Variance_ChartPrice1 / 12.0);

                var item4 = smartDataList4.Where(t => (t.DTime < item1.DTime)).Last();
                chart.Series[3].Points.AddXY(item1.DTime, item4.Variance_ChartPrice1 / 288.0);
            }
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

            int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartDataSub1.Count) / Convert.ToDouble(displayItemCount)));
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
            int maxScrollValue = (int)Math.Ceiling((Convert.ToDouble(ChartDataSub1.Count) / Convert.ToDouble(DisplayPointCount)));
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

            List<SmartCandleData> viewLists = null;
            int maxDisplayIndex = 0;
            int minDisplayIndex = 0;
            if (scrollVal == hScrollBar.Minimum)
            {
                int maxIndex = ChartDataSub1.Count > displayItemCount ? displayItemCount - 1 : ChartDataSub1.Count;
                if (displayItemCount > ChartDataSub1.Count) displayItemCount = ChartDataSub1.Count;
                viewLists = smartDataList1.GetRange(0, maxIndex);
                maxDisplayIndex = displayItemCount;
                minDisplayIndex = 0;
            }
            else if (scrollVal == hScrollBar.Maximum)
            {
                int minIndex = ChartDataSub1.Count < displayItemCount ? 0 : ChartDataSub1.Count - displayItemCount;
                if (displayItemCount > ChartDataSub1.Count) displayItemCount = ChartDataSub1.Count;
                viewLists = smartDataList1.GetRange(minIndex, ChartDataSub1.Count < displayItemCount ? ChartDataSub1.Count : displayItemCount);
               
                maxDisplayIndex = ChartDataSub1.Count;
                minDisplayIndex = minIndex;
            }
            else
            {
                int currentIndex = (scrollVal - 1) * displayItemCount;
                if (ChartDataSub1.Count < currentIndex + displayItemCount)
                    displayItemCount = ChartDataSub1.Count - currentIndex;

                viewLists = smartDataList1.GetRange(currentIndex, displayItemCount);
        
                maxDisplayIndex = currentIndex + displayItemCount;
                minDisplayIndex = currentIndex;
            }
            if (viewLists != null)
            {
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex - 3;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice = viewLists.Max(m => m.Variance_ChartPrice2);
                double minPrice = viewLists.Min(m => m.Variance_ChartPrice2);

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
        }


        #region Chart Util
        public void ClearChartLabel(string type)
        {
            for (int i = chart.Annotations.Count - 1; i >= 0; i--)
            {
                var a = chart.Annotations[i];

                if (a.Tag != null && a.Tag.ToString() == type)
                    chart.Annotations.Remove(a);
            }

            chart.Update();
        }
        public void DisplayChartLabel(DateTime dt, Color color, string type, string title = "★")
        {
            foreach (var p in chart.Series[0].Points)
            {
                var d = p.Tag as T_QuantumItemData;

                if (d.DTime.Year == dt.Year 
                    && d.DTime.Month == dt.Month 
                    && d.DTime.Day == dt.Day 
                    && d.DTime.Hour == dt.Hour 
                    && d.DTime.Minute == dt.Minute)
                {
                    TextAnnotation a = new TextAnnotation();
                    a.Font = new Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                    a.Text = title;
                    a.ForeColor = color;
                    a.IsSizeAlwaysRelative = true;
                    a.AnchorAlignment = ContentAlignment.TopCenter;
                    a.AnchorDataPoint = p;
                    a.Tag = type;
                    a.AnchorOffsetY = -5;
                    chart.Annotations.Add(a);
                    break;
                }
            }

            chart.Update();
        }
        #endregion

    }
}
