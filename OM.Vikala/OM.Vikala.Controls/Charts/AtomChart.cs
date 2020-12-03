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
    public partial class AtomChart : BaseChartControl
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
        public List<T_AtomItemData> ChartData
        {
            get;
            set;
        }
        public List<T_AtomItemData> ChartDataSub
        {
            get;
            set;
        }

        public void LoadData(string itemCode = ""
            , List<T_AtomItemData> chartData = null 
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            LoadData(itemCode, chartData, null, timeInterval);
        }

        public void LoadData(string itemCode = ""
            , List<T_AtomItemData> chartData = null
            , List<T_AtomItemData> chartAvgData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            if (itemCode != ItemCode || TimeInterval != timeInterval)
            {
                clearAnnotation();
            }
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;
            ChartDataSub = chartAvgData;

            TotalPointCount = ChartData.Count;

            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                Summary();
            }));           
        }        

        public AtomChart() 
        {
            InitializeComponent();
            base.IsShowXLine = false;
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        
        public override void View()
        {
            if (ChartData == null) return;
            if (ChartDataSub == null) return;
            //foreach (T_AtomItemData item in ChartData)

            int diffCnt = ChartData.Count - ChartDataSub.Count;
            for (int i = 0; i < diffCnt; i++)
                ChartData.RemoveAt(0); 
            
            diffCnt = ChartDataSub.Count - ChartData.Count;
            for (int i = 0; i < diffCnt; i++)
                ChartDataSub.RemoveAt(0);

            for (int i = 0; i < ChartData.Count; i++)
            {
                var item = ChartData[i];
             
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                                
                if (item.VirtualDepth == 2)
                {
                    chart.Series[1].Points.AddXY(item.DTime, double.NaN, double.NaN, double.NaN, double.NaN);
                    chart.Series[2].Points.AddXY(item.DTime, double.NaN, double.NaN, double.NaN, double.NaN);
                }
                else if (item.VirtualDepth == 1)
                {
                    chart.Series[1].Points.AddXY(item.DTime, item.VikalaPrice, item.VikalaPrice, item.ClosePrice, item.VikalaPrice);
                    chart.Series[2].Points.AddXY(item.DTime, item.QuantumPrice, item.QuantumPrice, item.OpenPrice, item.QuantumPrice);
                }
                else if (item.VirtualDepth == 0)
                {
                    chart.Series[1].Points.AddXY(item.DTime, item.VikalaPrice, item.VikalaPrice, item.ClosePrice, item.VikalaPrice);
                    chart.Series[2].Points.AddXY(item.DTime, item.QuantumPrice, item.QuantumPrice, item.OpenPrice, item.QuantumPrice);
                }

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

                var itemAvg = ChartDataSub[i];
                //빨강
                chart.Series[3].Points.AddXY(item.DTime, itemAvg.T_QuantumAvg);
                //주황
                chart.Series[4].Points.AddXY(item.DTime, itemAvg.T_MassAvg);
                //파랑
                chart.Series[5].Points.AddXY(item.DTime, itemAvg.T_VikalaAvg);
                //검정
                chart.Series[6].Points.AddXY(item.DTime, itemAvg.T_Avg);
                               
                bool isSignal = false;
                bool isUpPosition = false;
                bool isDownPosition = false;
               
                if (itemAvg.HighPrice < itemAvg.T_MassAvg
                    && itemAvg.HighPrice < itemAvg.T_QuantumAvg
                    && itemAvg.HighPrice < itemAvg.T_VikalaAvg
                    && itemAvg.HighPrice < itemAvg.T_TotalCenterAvg)
                {
                    isSignal = true;
                    isDownPosition = true;
                }
                if (itemAvg.LowPrice > itemAvg.T_MassAvg
                   && itemAvg.LowPrice > itemAvg.T_QuantumAvg
                   && itemAvg.LowPrice > itemAvg.T_VikalaAvg
                   && itemAvg.LowPrice > itemAvg.T_TotalCenterAvg)
                {
                    isSignal = true;
                    isUpPosition = true;
                }

                if (idx > 0 && isSignal)
                {
                    T_AtomItemData bitem = ChartDataSub[idx - 1];
                    bool isUpPosition2 = false;
                    bool isDownPosition2 = false;
                    if (bitem.HighPrice < bitem.T_MassAvg
                       && bitem.HighPrice < bitem.T_QuantumAvg
                       && bitem.HighPrice < bitem.T_VikalaAvg
                       && bitem.HighPrice < bitem.T_TotalCenterAvg)
                    {
                        isDownPosition2 = true;
                    }
                    if (bitem.LowPrice > bitem.T_MassAvg
                       && bitem.LowPrice > bitem.T_QuantumAvg
                       && bitem.LowPrice > bitem.T_VikalaAvg
                       && bitem.LowPrice > bitem.T_TotalCenterAvg)
                    {
                        isUpPosition2 = true;
                    }

                    if (bitem.PlusMinusType == PlusMinusTypeEnum.양 && isUpPosition && isUpPosition2)
                    {                       
                        bool isFirst = false;
                        bool isSecond = false;
                        if (bitem.QuantumPrice > itemAvg.ClosePrice)
                        {
                            chart.Series[1].Points[idx - 1].Label = "▼";
                            isFirst = true;
                        }
                        if (bitem.VikalaPrice > itemAvg.ClosePrice)
                        {
                            chart.Series[2].Points[idx - 1].Label = "▼";
                            isSecond = true;
                        }

                        if (isFirst && isSecond)
                        {
                            chart.Series[1].Points[idx - 1].LabelForeColor =
                                 chart.Series[2].Points[idx - 1].LabelForeColor = Color.Blue;
                        }
                    }

                    if (bitem.PlusMinusType == PlusMinusTypeEnum.음 && isDownPosition && isDownPosition2)
                    {
                        bool isFirst = false;
                        bool isSecond = false;
                        if (bitem.QuantumPrice < itemAvg.ClosePrice)
                        {
                            chart.Series[1].Points[idx - 1].Label = "▲";
                            isFirst = true;
                        }
                        if (bitem.VikalaPrice < itemAvg.ClosePrice)
                        {
                            chart.Series[2].Points[idx - 1].Label = "▲";
                            isSecond = true;
                        }

                        if (isFirst && isSecond)
                        {
                            chart.Series[1].Points[idx - 1].LabelForeColor =
                                 chart.Series[2].Points[idx - 1].LabelForeColor = Color.Red;
                        }
                    }
                }
            }

            SetTrackBar();
            SetScrollBar();
            
            DisplayView();

            IsLoaded = true;

            base.View();
        }        

        public void DisplayView()
        {
            chart.Update();

            int scrollVal = hScrollBar.Value;

            if (scrollVal < hScrollBar.Minimum) scrollVal = hScrollBar.Minimum;
            if (scrollVal > hScrollBar.Maximum) scrollVal = hScrollBar.Maximum;

            int trackView = trackBar.Value;
            int displayItemCount = DisplayPointCount * trackView;

            List<T_AtomItemData> viewLists = null;
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
                double maxPrice2 = viewLists.Max(m => m.HighPrice);
                double minPrice2 = viewLists.Min(m => m.LowPrice);
                double maxPrice3 = viewLists.Max(m => m.HighPrice);
                double minPrice3 = viewLists.Min(m => m.LowPrice);

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
            //chart.Annotations.Clear();
            //lblQPrice.Visible = false;
            //HitTestResult result = chart.HitTest(e.X, e.Y);           
            //if (result.ChartElementType == ChartElementType.DataPoint
            //    && result.Series == chart.Series[0])
            //{
            //    setLineAnnotation(result.PointIndex, e.Location);
            //}
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
