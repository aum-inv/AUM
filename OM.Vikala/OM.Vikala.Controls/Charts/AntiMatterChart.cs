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

        public bool IsShowVirtualDepth
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
        public override void InitializeControl()
        {
            //if (IsShowXLine) createXYLineAnnotation();
            //if (IsShowYLine) createYXLineAnnotation();        
            
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

            TotalPointCount = ChartDataSub.Count;

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

            int diffCnt = ChartData.Count - ChartDataSub.Count;
            for (int i = 0; i < diffCnt; i++)
                ChartData.RemoveAt(0);

            for (int i = 0; i < ChartData.Count; i++)
            {
                var item = ChartData[i];

                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);

                if (IsShowVirtualDepth)
                {
                    var dataPoint = chart.Series[0].Points[idx];
                    if (item.VirtualDepth == 0)
                    {
                        if (item.PlusMinusType == PlusMinusTypeEnum.양)
                            SetDataPointColor(dataPoint, Color.Red, Color.Red, Color.Red, 2);
                        else if (item.PlusMinusType == PlusMinusTypeEnum.음)
                            SetDataPointColor(dataPoint, Color.Blue, Color.Blue, Color.Blue, 2);
                        else
                            SetDataPointColor(dataPoint, Color.Black, Color.Black, Color.Black, 2);

                        if (IsShowVirtualDepth)
                            dataPoint.Label = "●";
                    }
                    else if (item.VirtualDepth == 1)
                    {
                        if (item.PlusMinusType == PlusMinusTypeEnum.양)
                            SetDataPointColor(dataPoint, Color.Red, Color.Red, Color.LightGray, 1);
                        else if (item.PlusMinusType == PlusMinusTypeEnum.음)
                            SetDataPointColor(dataPoint, Color.Blue, Color.Blue, Color.LightGray, 1);
                        else
                            SetDataPointColor(dataPoint, Color.Black, Color.Black, Color.LightGray, 1);
                    }
                    else if (item.VirtualDepth == 2)
                    {
                        if (item.PlusMinusType == PlusMinusTypeEnum.양)
                            SetDataPointColor(dataPoint, Color.Red, Color.Red, Color.White, 1);
                        else if (item.PlusMinusType == PlusMinusTypeEnum.음)
                            SetDataPointColor(dataPoint, Color.Blue, Color.Blue, Color.White, 1);
                        else
                            SetDataPointColor(dataPoint, Color.Black, Color.Black, Color.White, 1);
                    }
                }
                else 
                {
                    var dataPoint = chart.Series[0].Points[idx];

                    if (item.PlusMinusType == PlusMinusTypeEnum.양 && item.YinAndYang == PlusMinusTypeEnum.양)
                        SetDataPointColor(dataPoint, Color.Red, Color.Red, Color.Red, 2);
                    else if (item.PlusMinusType == PlusMinusTypeEnum.음 && item.YinAndYang == PlusMinusTypeEnum.양)
                        SetDataPointColor(dataPoint, Color.Blue, Color.Blue, Color.Blue, 2);

                    else if (item.PlusMinusType == PlusMinusTypeEnum.양)
                        SetDataPointColor(dataPoint, Color.Red, Color.Red, Color.White, 2);
                    else if (item.PlusMinusType == PlusMinusTypeEnum.음)
                        SetDataPointColor(dataPoint, Color.Blue, Color.Blue, Color.White, 2);

                    else
                        SetDataPointColor(dataPoint, Color.Black, Color.Black, Color.White, 2);
                }

                item = ChartDataSub[i];
                chart.Series[1].Points.AddXY(item.DTime, item.U_HighAvg);
                chart.Series[2].Points.AddXY(item.DTime, item.D_HighAvg);
                chart.Series[3].Points.AddXY(item.DTime, item.U_LowAvg);
                chart.Series[4].Points.AddXY(item.DTime, item.D_LowAvg);
                chart.Series[5].Points.AddXY(item.DTime, (item.D_HighAvg - item.D_LowAvg) / (item.D_HighAvg + item.D_LowAvg));
            }

            SetTrackBar();
            SetScrollBar();
            
            DisplayView();

            IsLoaded = true;

            base.View();

            //chart.ChartAreas["ca2"].AxisY2.LabelStyle.Format = "{N3}";
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
                int currentIndex = (scrollVal - 1);
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
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                maxPrice = viewLists.Max(m => (m.D_HighAvg - m.D_LowAvg) / (m.D_HighAvg + m.D_LowAvg));
                minPrice = viewLists.Min(m => (m.D_HighAvg - m.D_LowAvg) / (m.D_HighAvg + m.D_LowAvg));
                chart.ChartAreas[1].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[1].AxisY2.Minimum = minPrice;
                chart.ChartAreas[1].AxisX.Maximum = maxDisplayIndex + 1;
                chart.ChartAreas[1].AxisX.Minimum = minDisplayIndex - 1;
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
