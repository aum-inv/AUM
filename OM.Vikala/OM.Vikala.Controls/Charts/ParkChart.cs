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
using System.Security;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using OM.PP.Chakra.Indicators;
using System.Runtime.InteropServices;

namespace OM.Vikala.Controls.Charts
{
    public partial class ParkChart : BaseChartControl
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
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
        public List<T_ParkItemData> ChartData
        {
            get;
            set;
        }
        public void LoadData(string itemCode = ""
            , List<T_ParkItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            if (itemCode != ItemCode || TimeInterval != timeInterval)
            {
                clearAnnotation();
            }
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;

            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                Summary();
            }));           
        }        

        public ParkChart() 
        {
            InitializeComponent();
            base.IsShowXLine = false;
            base.SetChartControl(chart, hScrollBar, trackBar);

            chart.MouseDown -= chart_MouseDown;          
        }
        
        public override void View()
        {
            if (ChartData == null) return;
            int index = 0;
            foreach (T_ParkItemData item in ChartData)
            {
                item.Index = index++;
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                chart.Series[1].Points.AddXY(item.DTime, item.T_Psar);
                chart.Series[2].Points.AddXY(item.DTime, item.T_Psar2);
            }

            double maxPrice1 = ChartData.Max(m => m.HighPrice);
            double minPrice1 = ChartData.Min(m => m.LowPrice);
            double maxPrice2 = ChartData.Max(m => m.T_Psar);
            double minPrice2 = ChartData.Min(m => m.T_Psar);
            double maxPrice3 = ChartData.Max(m => m.T_Psar2);
            double minPrice3 = ChartData.Min(m => m.T_Psar2);

            double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
            double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
            maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
            minPrice = minPrice < minPrice3 ? minPrice : minPrice3;

            maxPrice = maxPrice + SpaceMaxMin;
            minPrice = minPrice - SpaceMaxMin;
            chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            chart.ChartAreas[0].AxisY2.Minimum = minPrice;
            chart.ChartAreas[0].AxisX.Maximum = ChartData.Count + 1;

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
            int scrollVal = hScrollBar.Value;

            if (scrollVal < hScrollBar.Minimum) scrollVal = hScrollBar.Minimum;
            if (scrollVal > hScrollBar.Maximum) scrollVal = hScrollBar.Maximum;

            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;

            List<T_ParkItemData> viewLists = null;
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
                double maxPrice2 = viewLists.Max(m => m.T_Psar);
                double minPrice2 = viewLists.Min(m => m.T_Psar);
                double maxPrice3 = viewLists.Max(m => m.T_Psar2);
                double minPrice3 = viewLists.Min(m => m.T_Psar2);
                double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
                double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;

                maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
                minPrice = minPrice < minPrice3 ? minPrice : minPrice3;
                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                DrawLines(viewLists);
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
            
            SetScrollBar();
            DisplayView();
           
            if (ChartEventInstance != null)
                ChartEventInstance.OnChangeChartTrackBarHandler(this.chart, trackBar.Value);

            SelectedTrackBarValue = (int)trackBar.Value;
        }

       
        #region DrawLine
        private void DrawLines(List<T_ParkItemData> viewLists)
        {
            try
            {
                chart.Annotations.Clear();
                T_ParkItemData bItem = null;
                int idx = 0;
                int cnt = 0;
                for (int i = 0; i < viewLists.Count; i++)
                {
                    if (bItem == null)
                    {
                        bItem = viewLists[0];
                        continue;
                    }

                    var cItem = viewLists[i];
                    cnt++;

                    if (TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Minute_01)
                    {
                        if (bItem.DTime.Minute / 10 != bItem.DTime.Minute / 10)
                        {
                            var subs = viewLists.GetRange(idx, cnt);
                            var hPrice = subs.Max(t => t.HighPrice);
                            var lPrice = subs.Min(t => t.LowPrice);
                            DrawLine(viewLists[idx].Index, viewLists[idx + cnt - 1].Index, hPrice, lPrice);
                            idx = i;
                            cnt = 0;
                            bItem = cItem;
                        }
                    }
                    if (TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Minute_10)
                    {
                        if (bItem.DTime.Hour != cItem.DTime.Hour)
                        {
                            var subs = viewLists.GetRange(idx, cnt);
                            var hPrice = subs.Max(t => t.HighPrice);
                            var lPrice = subs.Min(t => t.LowPrice);
                            DrawLine(viewLists[idx].Index, viewLists[idx + cnt - 1].Index, hPrice, lPrice);
                            idx = i;
                            cnt = 0;
                            bItem = cItem;
                        }
                    }
                    if (TimeInterval == Lib.Base.Enums.TimeIntervalEnum.Hour_01)
                    {
                        if (bItem.DTime.Day != cItem.DTime.Day)
                        {                         
                            var subs = viewLists.GetRange(idx, cnt);
                            var hPrice = subs.Max(t => t.HighPrice);
                            var lPrice = subs.Min(t => t.LowPrice);
                            DrawLine(viewLists[idx].Index, viewLists[idx + cnt - 1].Index, hPrice, lPrice);
                            idx = i;
                            cnt = 0;
                            bItem = cItem;
                        }
                    }
                }
                if (idx != 0 && idx != viewLists.Count - 1)
                {
                    var subs = viewLists.GetRange(idx, cnt+1);
                    var hPrice = subs.Max(t => t.HighPrice);
                    var lPrice = subs.Min(t => t.LowPrice);
                    DrawLine(viewLists[idx].Index, viewLists[idx + cnt].Index, hPrice, lPrice, true);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DrawLine(int startIdx, int endIdx, double hPrice, double lPrice, bool isLast = false)
        {
            try
            {
                int trackView = trackBar.Value;
                DataPoint left = chart.Series[0].Points[startIdx];
                DataPoint right = chart.Series[0].Points[endIdx];
                float zoom = getScalingFactor();

                LineAnnotation annH = new LineAnnotation();                
                annH.AxisX = chart.ChartAreas[0].AxisX;
                annH.AxisY = chart.ChartAreas[0].AxisY2;
                annH.IsSizeAlwaysRelative = true;
                annH.AnchorY = hPrice;
                annH.IsInfinitive = false;
                annH.LineColor = Color.DarkRed;
                annH.LineWidth = 2;
                annH.X = startIdx + 1;
                annH.Y = hPrice;                
                annH.Height = 0;
                annH.Width = Math.Ceiling((Convert.ToDouble(endIdx) - Convert.ToDouble(startIdx)) * zoom / trackView);
                //if (isLast) annH.Width += 1.5;
                annH.StartCap = LineAnchorCapStyle.None;
                annH.EndCap = LineAnchorCapStyle.None;
                chart.Annotations.Add(annH);

                LineAnnotation annL = new LineAnnotation();
                annL.AxisX = chart.ChartAreas[0].AxisX;
                annL.AxisY = chart.ChartAreas[0].AxisY2;
                annL.IsSizeAlwaysRelative = true;
                annL.AnchorY = lPrice;
                annL.IsInfinitive = false;
                annL.LineColor = Color.DarkBlue;
                annL.LineWidth = 2;
                annL.X = startIdx + 1;
                annL.Y = lPrice;
                annL.Height = 0;
                annL.Width = Math.Ceiling((Convert.ToDouble(endIdx) - Convert.ToDouble(startIdx)) * zoom / trackView);
                //if (isLast) annL.Width += 1.5;
                annL.StartCap = LineAnchorCapStyle.None;
                annL.EndCap = LineAnchorCapStyle.None;
                chart.Annotations.Add(annL);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Chart Util
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {  
            chart.Annotations.Clear();
            lblQPrice.Visible = false;

            HitTestResult result = chart.HitTest(e.X, e.Y);           
            if (result.ChartElementType == ChartElementType.DataPoint
                && (result.Series == chart.Series[0] || result.Series == chart.Series[1]))
            {
                setLineAnnotation(result.PointIndex, e.Location);
            }
        }

        private void setLineAnnotation(int index, Point p)
        {           
            double highPoint = 0;
            double lowPoint = 0;

            highPoint = Math.Round(ChartData[index].QuantumHighPrice, RoundLength);
            lowPoint = Math.Round(ChartData[index].QuantumLowPrice, RoundLength);

            if (ChartData[index].OpenPrice < ChartData[index].QuantumPrice)
            {
                HorizontalLineAnnotation annH = new HorizontalLineAnnotation();
                annH.AxisX = chart.ChartAreas[0].AxisX;
                annH.AxisY = chart.ChartAreas[0].AxisY2;
                annH.IsSizeAlwaysRelative = false;
                annH.AnchorY = highPoint;
                annH.IsInfinitive = true;
                annH.ClipToChartArea = chart.ChartAreas[0].Name;
                annH.LineColor = lblQPrice.ForeColor = Color.Red;
                annH.LineWidth = 1;
                chart.Annotations.Add(annH);
                lblQPrice.Text = highPoint.ToString("N"+ RoundLength);
                lblQPrice.Visible = true;
                lblQPrice.Location = p;
            }
            if (ChartData[index].OpenPrice > ChartData[index].QuantumPrice)
            {
                HorizontalLineAnnotation annL = new HorizontalLineAnnotation();
                annL.AxisX = chart.ChartAreas[0].AxisX;
                annL.AxisY = chart.ChartAreas[0].AxisY2;
                annL.IsSizeAlwaysRelative = false;
                annL.AnchorY = lowPoint;
                annL.IsInfinitive = true;
                annL.ClipToChartArea = chart.ChartAreas[0].Name;
                annL.LineColor = lblQPrice.ForeColor = Color.Blue;
                annL.LineWidth = 1;
                chart.Annotations.Add(annL);
                lblQPrice.Text = lowPoint.ToString("N" + RoundLength);
                lblQPrice.Visible = true;
                lblQPrice.Location = p;
            }
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
        #endregion

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,

            // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
        }

        private float getScalingFactor()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor; // 1.25 = 125%
        }
    }
}
