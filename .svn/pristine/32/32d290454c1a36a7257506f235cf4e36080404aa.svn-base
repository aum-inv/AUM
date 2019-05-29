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
    public partial class FiveColorChart : BaseChartControl
    {
        public List<T_FiveColorItemData> ChartData
        {
            get;
            set;
        }

        public void LoadData(string itemCode = ""
            , List <T_FiveColorItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            Reset();
            View();
        }
        
        public FiveColorChart()
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
            foreach (T_FiveColorItemData item in ChartData)
            {
                int idx =  chart.Series[0].Points.AddXY(item.DTime, 1, 0, 0, 1);
                chart.Series[1].Points.AddXY(item.DTime, 2, 1, 1, 2);
                chart.Series[2].Points.AddXY(item.DTime, 3, 2, 2, 3);
                chart.Series[3].Points.AddXY(item.DTime, 4, 3, 3, 4);
                chart.Series[4].Points.AddXY(item.DTime, 5, 4, 4, 5);
                //setLineAnnotation(1);
                //setLineAnnotation(2);
                //setLineAnnotation(3);
                //setLineAnnotation(4);
                var dataPoint1 = chart.Series[0].Points[idx];
                var dataPoint2 = chart.Series[1].Points[idx];
                var dataPoint3 = chart.Series[2].Points[idx];
                var dataPoint4 = chart.Series[3].Points[idx];
                var dataPoint5 = chart.Series[4].Points[idx];

                if (item.T1.PlusMinusType == PlusMinusTypeEnum.양
                    && item.T6.PlusMinusType == PlusMinusTypeEnum.음)
                    SetDataPointColor(dataPoint1, Color.Black, Color.Black, Color.Black);
                else
                    SetDataPointColor(dataPoint1, Color.White, Color.White, Color.White);

                if (item.T2.PlusMinusType == PlusMinusTypeEnum.음
                    && item.T7.PlusMinusType == PlusMinusTypeEnum.양)
                    SetDataPointColor(dataPoint2, Color.Red, Color.Red, Color.Red);
                else
                    SetDataPointColor(dataPoint2, Color.White, Color.White, Color.White);

                if (item.T3.PlusMinusType == PlusMinusTypeEnum.양
                   && item.T8.PlusMinusType == PlusMinusTypeEnum.음)
                    SetDataPointColor(dataPoint3, Color.Green, Color.Green, Color.Green);
                else
                    SetDataPointColor(dataPoint3, Color.White, Color.White, Color.White);

                if (item.T4.PlusMinusType == PlusMinusTypeEnum.음
                   && item.T9.PlusMinusType == PlusMinusTypeEnum.양)
                    SetDataPointColor(dataPoint4, Color.Gray, Color.Gray, Color.Gray);
                else
                    SetDataPointColor(dataPoint4, Color.White, Color.White, Color.White);

                if (item.T5.PlusMinusType == PlusMinusTypeEnum.양
                && item.T10.PlusMinusType == PlusMinusTypeEnum.음)
                    SetDataPointColor(dataPoint5, Color.Gold, Color.Gold, Color.Gold);
                else
                    SetDataPointColor(dataPoint5, Color.White, Color.White, Color.White);
            }
            chart.ChartAreas[0].AxisY2.Maximum = 5;
            chart.ChartAreas[0].AxisY2.Minimum = 0;

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

            List<T_FiveColorItemData> viewLists = null;
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
            SelectedTrackBarValue = (int)trackBar.Value;
            SetScrollBar();
            DisplayView();
            if (ChartEventInstance != null)
                ChartEventInstance.OnChangeChartTrackBarHandler(this.chart, trackBar.Value);
        }

        #region Chart Util
        private void SetDataPointColor(
                DataPoint dataPoint
            , Color? headlegColor = null
            , Color? bodyLineColor = null
            , Color? bodyColor = null
            , int? borderWidth = null)
        {
            if (headlegColor != null) dataPoint.Color = headlegColor.Value;

            if (bodyLineColor != null) dataPoint.BorderColor = bodyLineColor.Value;

            if (bodyColor != null) dataPoint.SetCustomProperty("PriceUpColor", bodyColor.Value.Name);
            if (bodyColor != null) dataPoint.SetCustomProperty("PriceDownColor", bodyColor.Value.Name);

            if (borderWidth != null) dataPoint.BorderWidth = borderWidth.Value;
        }

        private void setLineAnnotation(double value)
        {
            HorizontalLineAnnotation annH = new HorizontalLineAnnotation();
            annH.AxisX = chart.ChartAreas[0].AxisX;
            annH.AxisY = chart.ChartAreas[0].AxisY2;
            annH.IsSizeAlwaysRelative = false;
            annH.AnchorY = value;
            annH.IsInfinitive = true;
            annH.ClipToChartArea = chart.ChartAreas[0].Name;
            annH.LineColor = Color.DarkGray;
            annH.LineWidth = 1;
            chart.Annotations.Add(annH);
        }
        #endregion

        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
        }
    }
}
