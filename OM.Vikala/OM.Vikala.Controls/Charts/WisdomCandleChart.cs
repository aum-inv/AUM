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
    public partial class WisdomCandleChart : BaseChartControl
    {
          
        public List<WisdomCandleData> ChartData
        {
            get;
            set;
        }
       
        public void LoadData(string itemCode = ""
            , List <WisdomCandleData> chartData = null
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
        
        public WisdomCandleChart() 
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        public override void InitializeControl()
        {
            base.InitializeControl();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];

            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.Height = 95F;
            chartArea.InnerPlotPosition.Width = 92F;
            chartArea.InnerPlotPosition.Y = 2F;
            chartArea.InnerPlotPosition.X = 2F;
            chartArea.Name = "chartArea";

            chartArea.Position.Auto = false;
            chartArea.Position.Height = 96F;
            chartArea.Position.Width = 99F;
            chartArea.Position.Y = 2F;
            chartArea.ShadowColor = System.Drawing.Color.Transparent;
        }

        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
            foreach (var item in ChartData)
            {
                int idx = chart.Series[0].Points.AddXY(item.DTime
                    , item.high, item.low, item.open, item.close);
                var dataPoint = chart.Series[0].Points[idx];
                dataPoint.Tag = item;                
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

            List<WisdomCandleData> viewLists = null;
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
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 5;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice = viewLists.Max(m => m.high);
                double minPrice = viewLists.Min(m => m.low);
                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
            }
            chart.Update();
        }

        public void MoveView(WisdomCandleData data)
        {
            List<WisdomCandleData> viewLists = null;
            int maxDisplayIndex = 0;
            int minDisplayIndex = 0;

            foreach (var m in ChartData)
            {
                if (m == data)
                {
                    break;
                }
                maxDisplayIndex++;
            }
            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;
            minDisplayIndex = (maxDisplayIndex - displayItemCount);
            if (minDisplayIndex < 0) minDisplayIndex = 0;

            viewLists = ChartData.GetRange(minDisplayIndex, displayItemCount);

            chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 7;
            chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

            double maxPrice = viewLists.Max(m => m.high);
            double minPrice = viewLists.Min(m => m.low);

            maxPrice = maxPrice + SpaceMaxMin;
            minPrice = minPrice - SpaceMaxMin;

            chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            chart.ChartAreas[0].AxisY2.Minimum = minPrice;

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
        public void ClearChartLabel(string type)
        {
            for(int i = chart.Annotations.Count - 1; i >= 0; i--)
            {
                var a = chart.Annotations[i];

                if (a.Tag != null && a.Tag.ToString() == type)
                    chart.Annotations.Remove(a);
            }

            chart.Update();
        }
        public void DisplayChartLabel(WisdomCandleData data, Color color, string type, string title = "▼")
        {
            foreach (var p in chart.Series[0].Points)
            {               
                if (p.Tag as WisdomCandleData == data)
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

        private void chart_MouseClick(object sender, MouseEventArgs e)
        {
        }
    }
}
