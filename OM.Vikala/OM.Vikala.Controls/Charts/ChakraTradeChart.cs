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
using OM.Lib.Base.Enums;

namespace OM.Vikala.Controls.Charts
{
    public partial class ChakraTradeChart : BaseChartControl
    {
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

        public void LoadData(string itemCode = ""
            , List <S_CandleItemData> chartData = null
            , Lib.Base.Enums.TimeIntervalEnum timeInterval = Lib.Base.Enums.TimeIntervalEnum.Day)
        {
            LoadData(itemCode, chartData, null, timeInterval);
        }
        public void LoadData(string itemCode = ""
          , List<S_CandleItemData> chartData = null
            , List<S_CandleItemData> chartDataSub = null
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
            Reset();
            View();
        }

        public ChakraTradeChart() 
        {
            InitializeComponent();
            base.SetChartControl(chart, hScrollBar, trackBar);
        }

        public override void View()
        {
            pnlScroll.Visible = IsAutoScrollX;
            if (ChartData == null) return;
            foreach (S_CandleItemData item in ChartData)
            {
                int idx = chart.Series[0].Points.AddXY(item.DTime, item.HighPrice, item.LowPrice, item.OpenPrice, item.ClosePrice);
                chart.Series[1].Points.AddXY(item.DTime, item.QuantumHighPrice, item.QuantumLowPrice, item.OpenPrice, item.QuantumPrice);
                chart.Series[2].Points.AddXY(item.DTime, item.VikalaHighPrice, item.VikalaLowPrice, item.ClosePrice, item.VikalaPrice);

                if (item.PlusMinusType == PlusMinusTypeEnum.양)
                {
                    chart.Series[3].Points.AddXY(item.DTime, item.HighPrice);
                    chart.Series[4].Points.AddXY(item.DTime, item.QuantumLowPrice);
                    chart.Series[3].Points[idx].Label = Math.Round(item.HighPrice, RoundLength).ToString();
                    chart.Series[4].Points[idx].Label = Math.Round(item.QuantumLowPrice, RoundLength).ToString();
                }
                else
                {
                    chart.Series[3].Points.AddXY(item.DTime, item.QuantumHighPrice);
                    chart.Series[4].Points.AddXY(item.DTime, item.LowPrice);
                    chart.Series[3].Points[idx].Label = Math.Round(item.QuantumHighPrice, RoundLength).ToString();
                    chart.Series[4].Points[idx].Label = Math.Round(item.LowPrice, RoundLength).ToString();
                }
                if (item.MassPrice > item.QuantumPrice)
                {
                    chart.Series[5].Points.AddXY(item.DTime, item.MassPrice);
                    chart.Series[6].Points.AddXY(item.DTime, item.QuantumPrice);
                }
                else
                {
                    chart.Series[5].Points.AddXY(item.DTime, item.QuantumPrice);
                    chart.Series[6].Points.AddXY(item.DTime, item.MassPrice);
                }

                var dataPoint = chart.Series[0].Points[idx];                
            }

            double maxPrice1 = ChartData.Max(m => m.HighPrice);
            double minPrice1 = ChartData.Min(m => m.LowPrice);
            double maxPrice2 = ChartData.Max(m => m.QuantumHighPrice);
            double minPrice2 = ChartData.Min(m => m.QuantumLowPrice);
            double maxPrice3 = ChartData.Max(m => m.VikalaHighPrice);
            double minPrice3 = ChartData.Min(m => m.VikalaLowPrice);
            double maxPrice = maxPrice1 > maxPrice2 ? maxPrice1 : maxPrice2;
            double minPrice = minPrice1 < minPrice2 ? minPrice1 : minPrice2;
            maxPrice = maxPrice > maxPrice3 ? maxPrice : maxPrice3;
            minPrice = minPrice < minPrice3 ? minPrice : minPrice3;
            maxPrice = maxPrice + SpaceMaxMin;
            minPrice = minPrice - SpaceMaxMin;
            chart.ChartAreas[0].AxisY2.Maximum = maxPrice;
            chart.ChartAreas[0].AxisY2.Minimum = minPrice;
           
            SetScrollBar();
            SetTrackBar();
            DisplayView();
            SummaryPrice();
            IsLoaded = true;

            base.View();
        }
        public void SummaryPrice()
        {
            if (ChartData != null && ChartData.Count == 1)
            {
                S_CandleItemData data = ChartData[0];
                double hPrice = data.PlusMinusType == PlusMinusTypeEnum.양 ? data.VikalaHighPrice : data.QuantumHighPrice;
                double lPrice = data.PlusMinusType == PlusMinusTypeEnum.양 ? data.QuantumLowPrice : data.VikalaLowPrice;
                double mPrice = data.MassPrice;
                double qPrice = data.TotalCenterPrice;
                double qhPrice = mPrice > qPrice ? mPrice : qPrice;
                double qlPrice = mPrice < qPrice ? mPrice : qPrice;

                lblH.Text = Math.Round(hPrice, RoundLength).ToString();
                lblH.Visible = true;
                lblL.Text = Math.Round(lPrice, RoundLength).ToString();
                lblL.Visible = true;

                lblMH.Text = Math.Round(qhPrice, RoundLength).ToString();
                lblMH.Visible = true;
                lblML.Text = Math.Round(qlPrice, RoundLength).ToString();
                lblML.Visible = true;

                lblHTick.Text = "0";
                lblH.Visible = true;
                lblLTick.Text = "0";
                lblL.Visible = true;
                lblMHTick.Text = "0";
                lblMH.Visible = true;
                lblMLTick.Text = "0";
                lblML.Visible = true;

                clearAnnotation();
                CreateBaseLineAnnotation(hPrice, Color.Red);
                CreateBaseLineAnnotation(qhPrice, Color.Fuchsia);
                CreateBaseLineAnnotation(qlPrice, Color.Green);
                CreateBaseLineAnnotation(lPrice, Color.Blue);
                CreatePriceLineAnnotation(0);
            }
        }

        public void SummaryPrice(double cPrice)
        {
            if (ChartData != null && ChartData.Count == 1)
            {
                this.Invoke(new Action(() =>
                {
                    double hPrice = Convert.ToDouble(lblH.Text);
                    double lPrice = Convert.ToDouble(lblL.Text);
                    double qhPrice = Convert.ToDouble(lblMH.Text);
                    double qlPrice = Convert.ToDouble(lblML.Text);

                    int hTick = PriceTick.GetTickDiff(ItemCode, hPrice, cPrice);
                    int lTick = PriceTick.GetTickDiff(ItemCode, lPrice, cPrice);
                    int qhTick = PriceTick.GetTickDiff(ItemCode, qhPrice, cPrice);
                    int qlTick = PriceTick.GetTickDiff(ItemCode, qlPrice, cPrice);

                    lblH.Text = $"{Math.Round(hPrice, RoundLength).ToString()}";
                    lblH.Visible = true;
                    lblL.Text = $"{Math.Round(lPrice, RoundLength).ToString()}";
                    lblL.Visible = true;
                    lblMH.Text = $"{Math.Round(qhPrice, RoundLength).ToString()}";
                    lblMH.Visible = true;
                    lblML.Text = $"{Math.Round(qlPrice, RoundLength).ToString()}";
                    lblML.Visible = true;
                    
                    lblHTick.Text = $"{(hPrice > cPrice ? "+" : "-")}{hTick}";
                    lblHTick.Visible = true;
                    lblLTick.Text = $"{(lPrice > cPrice ? "+" : "-")}{lTick}";
                    lblLTick.Visible = true;
                    lblMHTick.Text = $"{(qhPrice > cPrice ? "+" : "-")}{qhTick}";
                    lblMHTick.Visible = true;
                    lblMLTick.Text = $"{(qlPrice > cPrice ? "+" : "-")}{qlTick}";
                    lblMLTick.Visible = true;

                    SetPriceLineAnnotation(cPrice);
                }));
            }
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
                double maxPrice2 = viewLists.Max(m => m.QuantumHighPrice);
                double minPrice2 = viewLists.Min(m => m.QuantumLowPrice);
                double maxPrice3 = viewLists.Max(m => m.VikalaHighPrice);
                double minPrice3 = viewLists.Min(m => m.VikalaLowPrice);
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
        public override double SpaceMaxMin
        {
            get
            {
                int round = ItemCodeSet.GetItemRoundNum(ItemCode);

                if (round == 0) return 5;
                else if (round == 1) return 0.5;
                else if (round == 2) return 0.05;
                else if (round == 3) return 0.005;
                else if (round == 4) return 0.0005;
                else if (round == 5) return 0.000051;

                return 0.01;
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

        HorizontalLineAnnotation hPrice = null;
        private void CreatePriceLineAnnotation(double price)
        {
            hPrice = new HorizontalLineAnnotation();
            hPrice.AxisX = chart.ChartAreas[0].AxisX;
            hPrice.AxisY = chart.ChartAreas[0].AxisY2;
            hPrice.IsSizeAlwaysRelative = false;
            hPrice.IsInfinitive = true;
            hPrice.ClipToChartArea = chart.ChartAreas[0].Name;
            hPrice.LineColor = Color.Black;
            hPrice.LineWidth = 1;
            hPrice.Visible = true;
            hPrice.AnchorY = price;
            chart.Annotations.Add(hPrice);
        }
        private void SetPriceLineAnnotation(double price)
        {
            hPrice.AnchorY = price;
        }
        private void CreateBaseLineAnnotation(double price, Color color)
        {            
            HorizontalLineAnnotation hbase = new HorizontalLineAnnotation();
            hbase.AxisX = chart.ChartAreas[0].AxisX;
            hbase.AxisY = chart.ChartAreas[0].AxisY2;
            hbase.IsSizeAlwaysRelative = false;
            hbase.IsInfinitive = true;
            hbase.ClipToChartArea = chart.ChartAreas[0].Name;
            hbase.LineColor = color;
            hbase.LineWidth = 1;
            hbase.Visible = true;
            hbase.AnchorY = price;
            chart.Annotations.Add(hbase);
        }

        /*
        private void setLineAnnotation(int index, Point p, int type)
        {
            double highPoint = 0;
            double lowPoint = 0;
            double highPoint2 = 0;
            double lowPoint2 = 0;

            if (type == 1)
            {
                highPoint = ChartData[index].QuantumHighPrice;
                lowPoint = ChartData[index].QuantumLowPrice;
                highPoint2 = ChartData[index].HighPrice;
                lowPoint2 = ChartData[index].LowPrice;
            }
            else if (type == 2)
            {
                highPoint = ChartData[index].QuantumCenterPrice;
                lowPoint = ChartData[index].CenterPrice;
                highPoint2 = ChartData[index].CenterPrice;
                lowPoint2 = ChartData[index].QuantumCenterPrice;
            }

            if (highPoint < highPoint2) highPoint = highPoint2;
            if (lowPoint > lowPoint2) lowPoint = lowPoint2;

            highPoint = Math.Round(highPoint, RoundLength);
            lowPoint = Math.Round(lowPoint, RoundLength);

            HorizontalLineAnnotation annH = new HorizontalLineAnnotation();
            annH.AxisX = chart.ChartAreas[0].AxisX;
            annH.AxisY = chart.ChartAreas[0].AxisY2;
            annH.IsSizeAlwaysRelative = false;
            annH.AnchorY = highPoint;
            annH.IsInfinitive = true;
            annH.ClipToChartArea = chart.ChartAreas[0].Name;
            annH.LineColor = Color.Red;
            annH.LineWidth = 1;
            chart.Annotations.Add(annH);

            HorizontalLineAnnotation annL = new HorizontalLineAnnotation();
            annL.AxisX = chart.ChartAreas[0].AxisX;
            annL.AxisY = chart.ChartAreas[0].AxisY2;
            annL.IsSizeAlwaysRelative = false;
            annL.AnchorY = lowPoint;
            annL.IsInfinitive = true;
            annL.ClipToChartArea = chart.ChartAreas[0].Name;
            annL.LineColor = Color.Blue;
            annL.LineWidth = 1;
            chart.Annotations.Add(annL);
        }
        */
        private void chart_PostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawChartTitle(e);
        }
        private void clearAnnotation()
        {
            chart.Annotations.Clear();            
        }
    }
}
