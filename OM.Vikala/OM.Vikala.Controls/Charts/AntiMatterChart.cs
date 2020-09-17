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
    public partial class AntiMatterChart : BaseChartControl
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
        public List<T_AntiMatterItemData> ChartData
        {
            get;
            set;
        }
        public List<T_AntiMatterItemData> ChartDataSub
        {
            get;
            set;
        }
        public void LoadData(string itemCode = ""
            , List<T_AntiMatterItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            LoadData(itemCode, chartData, null, timeInterval);         
        }
        public void LoadData(string itemCode = ""
            , List<T_AntiMatterItemData> chartData = null
            , List<T_AntiMatterItemData> chartDataSub = null
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

        public AntiMatterChart() 
        {
            InitializeComponent();
            base.IsShowXLine = false;
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        
        public override void View()
        {
            if (ChartData == null) return;

            for (int i = 0; i < ChartData.Count; i++)
            {
                var item = ChartData[i];

                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);

                item = ChartDataSub[i];
                chart.Series[1].Points.AddXY(item.DTime, item.U_HighAvg);
                chart.Series[2].Points.AddXY(item.DTime, item.D_HighAvg);
                chart.Series[3].Points.AddXY(item.DTime, item.U_LowAvg);
                chart.Series[4].Points.AddXY(item.DTime, item.D_LowAvg);
            }

            //double maxPrice1 = ChartData.Max(m => m.HighPrice);
            //double minPrice1 = ChartData.Min(m => m.LowPrice);
            //double maxPrice2 = ChartData.Max(m => m.U_HighAvg);
            //double minPrice2 = ChartData.Min(m => m.U_LowAvg);
            //double maxPrice3 = ChartData.Max(m => m.D_HighAvg);
            //double minPrice3 = ChartData.Min(m => m.D_LowAvg);

            //double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
            //double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
            //maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
            //minPrice = minPrice < minPrice3 ? minPrice : minPrice3;

            //maxPrice = maxPrice + SpaceMaxMin;
            //minPrice = minPrice - SpaceMaxMin;
            //chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            //chart.ChartAreas[0].AxisY2.Minimum = minPrice; 
            
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

            List<T_AntiMatterItemData> viewLists = null;
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
                double maxPrice2 = viewLists.Max(m => m.U_HighAvg);
                double minPrice2 = viewLists.Min(m => m.U_LowAvg);
                double maxPrice3 = viewLists.Max(m => m.D_HighAvg);
                double minPrice3 = viewLists.Min(m => m.D_LowAvg);

                double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
                double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
                maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
                minPrice = minPrice < minPrice3 ? minPrice : minPrice3;

                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;

                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 5;
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
    }
}
