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
                       
        public List<T_QuantumItemData> ChartData
        {
            get;
            set;
        }
        public List<T_QuantumItemData> ChartDataSub
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

        public bool IsBalanceAverage { get; set; } = false;
        public void LoadData(string itemCode = ""
            , List <T_QuantumItemData> chartData = null
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
           , List<T_QuantumItemData> chartData = null
           , List<T_QuantumItemData> chartDataSub = null
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
            double preVariancePrice3 = 0;
            for (int i = 4; i < ChartData.Count; i++)
            {
                var item = ChartData[i];
                var item2 = ChartDataSub[i];
                var smart = smartDataList[i];
                var wisdom = wisdomDataList[i];
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                string diceChar = getDiceChar(item);
                chart.Series[0].Points[idx].Label = diceChar;
                if (diceChar == "◆")
                    chart.Series[0].Points[idx].LabelForeColor = Color.Red;

                //chart.Series[1].Points.AddXY(smart.DTime, smart.SpaceTotalChangeRate);
                chart.Series[1].Points.AddXY(smart.DTime, smart.Variance_ChartPrice2);
                chart.Series[2].Points.AddXY(wisdom.DTime, wisdom.Variance_ChartPrice);
                chart.Series[3].Points.AddXY(wisdom.DTime, smart.Variance_ChartPrice1);

                chart.Series[4].Points.AddXY(item2.DTime, item2.HighPrice, item2.LowPrice, item2.OpenPrice, item2.ClosePrice);
               
                chart.Series[5].Points.AddXY(item2.DTime, item2.T_MassAvg);
                chart.Series[6].Points.AddXY(item2.DTime, item2.T_QuantumAvg);

                chart.Series[1].Points[idx].Color = Color.Red;
                chart.Series[2].Points[idx].Color = Color.Blue;

                if (preVariancePrice < preVariancePrice2 && wisdom.Variance_ChartPrice < smart.Variance_ChartPrice2)
                {
                    chart.Series[1].Points[idx].LabelForeColor = Color.Red;
                    chart.Series[1].Points[idx].Label = "◎";
                }
                else if (preVariancePrice > preVariancePrice2 && wisdom.Variance_ChartPrice > smart.Variance_ChartPrice2)
                {
                    chart.Series[1].Points[idx].LabelForeColor = Color.Blue;
                    chart.Series[1].Points[idx].Label = "◎";
                }
              

                if (preVariancePrice3 < preVariancePrice2 && wisdom.Variance_ChartPrice < smart.Variance_ChartPrice1)
                {
                    chart.Series[3].Points[idx].LabelForeColor = Color.Coral;
                    chart.Series[3].Points[idx].Label = "▲";
                }
                else if (preVariancePrice3 > preVariancePrice2 && wisdom.Variance_ChartPrice > smart.Variance_ChartPrice1)
                {
                    chart.Series[3].Points[idx].LabelForeColor = Color.Lime;
                    chart.Series[3].Points[idx].Label = "▼";
                }

                preVariancePrice = smart.Variance_ChartPrice2;
                preVariancePrice2 = wisdom.Variance_ChartPrice;
                preVariancePrice3 = smart.Variance_ChartPrice1;

                //if (preVariancePrice2 < wisdom.Variance_ChartPrice)
                //{
                //    chart.Series[2].Points[idx].Color = Color.Blue;
                //    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                //}
                //else if (preVariancePrice2 > wisdom.Variance_ChartPrice)
                //{
                //    chart.Series[2].Points[idx].Color = Color.Blue;
                //    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                //}
                //else
                //{
                //    chart.Series[2].Points[idx].Color = Color.Blue;
                //    chart.Series[2].Points[idx].MarkerColor = Color.Blue;
                //}


                var dataPoint = chart.Series[0].Points[idx];
                dataPoint.Tag = item;

            }
            //chart.Series[1].Enabled = false;
            chart.Series[4].Enabled = false;
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

            List<T_QuantumItemData> viewLists = null;
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
                chart.ChartAreas[0].AxisX.Maximum = maxDisplayIndex - 3;
                chart.ChartAreas[0].AxisX.Minimum = minDisplayIndex - 1;

                double maxPrice = viewLists.Max(m => m.HighPrice);
                double minPrice = viewLists.Min(m => m.LowPrice);

                maxPrice = maxPrice + SpaceMaxMin;
                minPrice = minPrice - SpaceMaxMin;
                chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
                chart.ChartAreas[0].AxisY2.Minimum = minPrice;
               
                double maxPrice2 = smartDataList.GetRange(2, smartDataList.Count - 3).Max(m => m.Variance_ChartPrice2);
                double minPrice2 = smartDataList.GetRange(2, smartDataList.Count - 3).Min(m => m.Variance_ChartPrice2);
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

        private string getDiceChar(A_HLOC item)
        {
            //if (n == 1) return "⚀";
            //if (n == 2) return "⚁";
            //if (n == 3) return "⚂";
            //if (n == 4) return "⚃";
            //if (n == 5) return "⚄";
            //if (n == 6) return "⚅";
            //❶❷❸❹❺❻❼❽❾❿
            //➀➁➂➃➄➅➆➇➈➉

            if (item.DiceNum == 1 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➀";
            if (item.DiceNum == 2 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➁";
            if (item.DiceNum == 3 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➂";
            if (item.DiceNum == 4 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➃";
            if (item.DiceNum == 5 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➄";
            if (item.DiceNum == 6 && item.PlusMinusType == PlusMinusTypeEnum.양) return "➅";

            if (item.DiceNum == 1 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❶";
            if (item.DiceNum == 2 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❷";
            if (item.DiceNum == 3 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❸";
            if (item.DiceNum == 4 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❹";
            if (item.DiceNum == 5 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❺";
            if (item.DiceNum == 6 && item.PlusMinusType == PlusMinusTypeEnum.음) return "❻";

            if (item.DiceNum == 1 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";
            if (item.DiceNum == 2 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";
            if (item.DiceNum == 3 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";
            if (item.DiceNum == 4 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";
            if (item.DiceNum == 5 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";
            if (item.DiceNum == 6 && item.PlusMinusType == PlusMinusTypeEnum.무) return "◆";

            return "";
        }
    }
}
