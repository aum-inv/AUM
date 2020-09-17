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
    public partial class ComparedBasicCandleChart : BaseChartControl
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

        public BaseCandleChartTypeEnum BaseCandleChartType
        {
            get;
            set;
        } = BaseCandleChartTypeEnum.인;

        public void LoadData(string itemCode = ""
            , List <S_CandleItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            TimeInterval = timeInterval;
            ItemCode = itemCode;
            ChartData = chartData;

            this.Invoke(new MethodInvoker(() => {
                Reset();
                View();
                //if (IsShowEightRule)
                //    Annotation();
            }));
        }
        public void LoadData(string itemCode = ""
           , List<S_CandleItemData> chartData = null
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
        List<SmartCandleData> smartDataList = new List<SmartCandleData>();
        List<WisdomCandleData> wisdomDataList = new List<WisdomCandleData>();
        public ComparedBasicCandleChart() 
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }
        public override void InitializeControl()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = chart.ChartAreas[0];
            //chartArea.AxisX.IsLabelAutoFit = true;
            //chartArea.AxisX.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            //chartArea.AxisX.LineColor = System.Drawing.Color.WhiteSmoke;
            //chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));

            //chartArea.AxisY.IntervalType = DateTimeIntervalType.NotSet;
            //chartArea.AxisY.IsLabelAutoFit = true;
            //chartArea.AxisY.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //chartArea.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            //chartArea.AxisY.LineColor = System.Drawing.Color.WhiteSmoke;

            //chartArea.AxisY2.IntervalType = DateTimeIntervalType.NotSet;
            //chartArea.AxisY2.IsLabelAutoFit = true;
            //chartArea.AxisY2.LabelStyle.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //chartArea.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.DimGray;
            //chartArea.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke;

            //chartArea.BackColor = Color.White;
            //chartArea.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.None;
            //chartArea.BackSecondaryColor = System.Drawing.Color.White;
            //chartArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //chartArea.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;

            chartArea.InnerPlotPosition.Auto = false;
            chartArea.InnerPlotPosition.Height = 90F;
            chartArea.InnerPlotPosition.Width = 95F;
            chartArea.InnerPlotPosition.Y = 2F;
            chartArea.InnerPlotPosition.X = 2F;
            chartArea.Name = "chartArea";

            chartArea.Position.Auto = false;
            chartArea.Position.Height = 95F;
            chartArea.Position.Width = 98F;
            chartArea.Position.Y = 2F;
            chartArea.ShadowColor = System.Drawing.Color.Transparent;
        }
        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;

            smartDataList.Clear(); 
            wisdomDataList.Clear();
            SmartCandleData preSmartData = null; 
            WisdomCandleData preWisdomData = null;

            if (ChartDataSub == null)
            {
                for (int i = 0; i < ChartData.Count; i++)
                {
                    var cData = ChartData[i];

                    SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);

                    smartDataList.Add(smartData);

                    preSmartData = smartData;

                    WisdomCandleData wisdomData = new WisdomCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preWisdomData);

                    wisdomDataList.Add(wisdomData);

                    preWisdomData = wisdomData;
                }
            }
            else
            {
                for (int i = 0; i < ChartDataSub.Count; i++)
                {
                    var cData = ChartDataSub[i];

                    SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);

                    smartDataList.Add(smartData);

                    preSmartData = smartData;

                    WisdomCandleData wisdomData = new WisdomCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preWisdomData);

                    wisdomDataList.Add(wisdomData);

                    preWisdomData = wisdomData;
                }
            }

            double preVariancePrice = 0;
            double preVariancePrice2= 0;
            for (int i = 3; i < ChartData.Count; i++)
            {
                var item = ChartData[i];
                var smart = smartDataList[i];
                var wisdom = wisdomDataList[i];
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                //chart.Series[1].Points.AddXY(smart.DTime, smart.SpaceTotalChangeRate);
                chart.Series[1].Points.AddXY(smart.DTime, smart.Variance_ChartPrice);
                chart.Series[2].Points.AddXY(wisdom.DTime, wisdom.Variance_ChartPrice);

                if (preVariancePrice < smart.Variance_ChartPrice)
                {
                    chart.Series[1].Points[idx].Color = Color.Red;
                    chart.Series[1].Points[idx].MarkerColor = Color.Red;
                }
                else if (preVariancePrice > smart.Variance_ChartPrice)
                {
                    chart.Series[1].Points[idx].Color = Color.Red;
                    chart.Series[1].Points[idx].MarkerColor = Color.Red;
                }
                else
                {
                    chart.Series[1].Points[idx].Color = Color.Red;
                    chart.Series[1].Points[idx].MarkerColor = Color.Red;
                }
                preVariancePrice = smart.Variance_ChartPrice;


                if (preVariancePrice2 < wisdom.Variance_ChartPrice)
                {
                    chart.Series[2].Points[idx].Color = Color.Blue;
                    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                }
                else if (preVariancePrice2 > wisdom.Variance_ChartPrice)
                {
                    chart.Series[2].Points[idx].Color = Color.Blue;
                    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                }
                else
                {
                    chart.Series[2].Points[idx].Color = Color.Blue;
                    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                }
                preVariancePrice2 = wisdom.Variance_ChartPrice;

                var dataPoint = chart.Series[0].Points[idx];
                dataPoint.Tag = item;

            }
            //double maxPrice = ChartData.Max(m => m.HighPrice);
            //double minPrice = ChartData.Min(m => m.LowPrice);
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
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex + 5;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice = viewLists.Max(m => m.HighPrice);
                double minPrice = viewLists.Min(m => m.LowPrice);

                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
               
                double maxPrice2 = smartDataList.GetRange(2, smartDataList.Count - 2).Max(m => m.Variance_ChartPrice);
                double minPrice2 = smartDataList.GetRange(2, smartDataList.Count - 2).Min(m => m.Variance_ChartPrice);
                maxPrice2 = maxPrice2 + SpaceMaxMin;
                minPrice2 = minPrice2 - SpaceMaxMin;
                chart.ChartAreas[0].AxisY.Maximum = maxPrice2;
                chart.ChartAreas[0].AxisY.Minimum = minPrice2;
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
    }
}
