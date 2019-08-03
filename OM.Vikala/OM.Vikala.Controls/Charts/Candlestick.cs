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
    public partial class Candlestick : BaseChartControl
    {      
        public List<S_CandleItemData> ChartData
        {
            get;
            set;
        }

        public void LoadData(List<S_CandleItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ChartData = chartData;
            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
            }));
        }
        
        public Candlestick()
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
                chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
            }

            chart.ChartAreas[0].AxisY2.Maximum = ChartData.Max(m => m.HighPrice);
            chart.ChartAreas[0].AxisY2.Minimum = ChartData.Min(m => m.LowPrice);
            
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
                viewLists = ChartData.GetRange(currentIndex, displayItemCount);

                maxDisplayIndex = currentIndex + displayItemCount;
                minDisplayIndex = currentIndex;
            }
            if (viewLists != null)
            {
                chart.ChartAreas[0].AxisY2.Maximum = viewLists.Max(m => m.HighPrice);
                chart.ChartAreas[0].AxisY2.Minimum = viewLists.Min(m => m.LowPrice);

                //chart.ChartAreas[0].AxisX.Maximum = viewLists[viewLists.Count - 1].DTime.ToOADate();
                //chart.ChartAreas[0].AxisX.Minimum = viewLists[0].DTime.ToOADate();
                
                
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;
            }
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (!IsLoaded) return;
            DisplayView();
        }
        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (!IsLoaded) return;
            SelectedTrackBarValue = (int)trackBar.Value;
            SetScrollBar();
            DisplayView();
        }
        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
            //머리와 다리 부분의 색깔을 변화시킬때.
            //ChartArea ca = chart.ChartAreas[0];
            //Series s = chart.Series[0];

            //Pen hiPen = new Pen(Color.Red, 1);
            //Pen loPen = new Pen(Color.Blue, 1);

            //s.BorderWidth = 0;

            //if (e.ChartElement == s)
            //{
            //    foreach (DataPoint dp in s.Points)
            //    {
            //        if (dp.XValue < chart.ChartAreas[0].AxisX.Minimum 
            //            || dp.XValue > chart.ChartAreas[0].AxisX.Maximum)
            //            continue;

            //        float x = (float)ca.AxisX.ValueToPixelPosition(dp.XValue);
            //        float y_hi = (float)ca.AxisY2.ValueToPixelPosition(dp.YValues[0]);
            //        float y_low = (float)ca.AxisY2.ValueToPixelPosition(dp.YValues[1]);
            //        float y_open = (float)ca.AxisY2.ValueToPixelPosition(dp.YValues[2]);
            //        float y_close = (float)ca.AxisY2.ValueToPixelPosition(dp.YValues[3]);

            //        e.ChartGraphics.Graphics.DrawLine(hiPen, x, y_hi, x, Math.Min(y_close, y_open));

            //        e.ChartGraphics.Graphics.DrawLine(loPen, x, y_low, x, Math.Max(y_close, y_open) - 1);
            //    }
            //}
        }  
    }
}
