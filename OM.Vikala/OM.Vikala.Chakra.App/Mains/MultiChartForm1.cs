using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Chakra;
using OM.Vikala.Chakra.App.Events;
using OM.Vikala.Controls.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
    public partial class MultiChartForm1 : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qMin5 = new QuantumLineChart();
        BaseChartControl qMin10 = new QuantumLineChart();
        BaseChartControl qMin30 = new QuantumLineChart();
        BaseChartControl qMin60 = new QuantumLineChart();
        BaseChartControl qMin120 = new QuantumLineChart();
        BaseChartControl qDay = new QuantumLineChart();

        public MultiChartForm1()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }

        private void InitializeControls()
        {            
            loadChartControls();
            setTimer();
        }

        public override void loadChartControls()
        {
            charts.Clear();
            charts.Add(qDay);
            charts.Add(qMin120);
            charts.Add(qMin60);
            charts.Add(qMin30);            
            charts.Add(qMin10);
            charts.Add(qMin5);

            qMin5.Title = "양자챠트 5분";
            qMin10.Title = "양자챠트 10분";
            qMin30.Title = "양자챠트 30분";
            qMin60.Title = "양자챠트 60분";
            qMin120.Title = "양자챠트 120분";
            qDay.Title = "양자챠트 일";

            qMin5.TimeInterval = TimeIntervalEnum.Minute_05;
            qMin10.TimeInterval = TimeIntervalEnum.Minute_10;
            qMin30.TimeInterval = TimeIntervalEnum.Minute_30;
            qMin60.TimeInterval = TimeIntervalEnum.Minute_60;
            qMin120.TimeInterval = TimeIntervalEnum.Minute_120;
            qDay.TimeInterval = TimeIntervalEnum.Day;

            foreach (var c in charts)
            {
                c.IsShowXLine = true;
                c.InitializeControl();
                c.InitializeEvent(null);
                c.DisplayPointCount = itemCnt;

                ((QuantumLineChart)c).IsShowCandle = true;                
            }

            this.flowTable.Dock = DockStyle.Top;
            this.flowList.Dock = DockStyle.Top;
            this.flowTab.Dock = DockStyle.Fill;

            setFlow();
        }

        public override void setFlow()
        {
            flowTable.Visible = false;
            flowList.Visible = false;
            flowTab.Visible = false;

            flowTable.Controls.Clear();
            flowList.Controls.Clear();
            for (int i = 0; i < flowTab.TabPages.Count; i++)
                flowTab.TabPages[i].Controls.Clear();

            if (flowDirection == FlowDirectionTypeEnum.TABLE)
            {
                flowTable.Controls.Add(charts[0], 0, 0);
                flowTable.Controls.Add(charts[1], 1, 0);
                flowTable.Controls.Add(charts[2], 0, 1);
                flowTable.Controls.Add(charts[3], 1, 1);
                flowTable.Controls.Add(charts[4], 0, 2);
                flowTable.Controls.Add(charts[5], 1, 2);
                flowTable.Height = 300 * 3;
                flowTable.Visible = true;
            }
            else if (flowDirection == FlowDirectionTypeEnum.LIST)
            {
                flowList.Controls.Add(charts[0], 0, 0);
                flowList.Controls.Add(charts[1], 0, 1);
                flowList.Controls.Add(charts[2], 0, 2);
                flowList.Controls.Add(charts[3], 0, 3);
                flowList.Controls.Add(charts[4], 0, 4);
                flowList.Controls.Add(charts[5], 0, 5);
                flowList.Height = 300 * 6;
                flowList.Visible = true;
            }
            else if (flowDirection == FlowDirectionTypeEnum.TAB)
            {
                flowTab.TabPages[0].Controls.Add(charts[0]);
                flowTab.TabPages[0].Text = charts[0].Title;
                flowTab.TabPages[1].Controls.Add(charts[1]);
                flowTab.TabPages[1].Text = charts[1].Title;
                flowTab.TabPages[2].Controls.Add(charts[2]);
                flowTab.TabPages[2].Text = charts[2].Title;
                flowTab.TabPages[3].Controls.Add(charts[3]);
                flowTab.TabPages[3].Text = charts[3].Title;
                flowTab.TabPages[4].Controls.Add(charts[4]);
                flowTab.TabPages[4].Text = charts[4].Title;
                flowTab.TabPages[5].Controls.Add(charts[5]);
                flowTab.TabPages[5].Text = charts[5].Title;
                flowTab.Visible = true;
            }

            foreach (var c in charts)
            {
                c.Height = 290;
                c.Dock = DockStyle.Fill;
                c.BorderStyle = BorderStyle.None;
            }
        }

        public override void loadData()
        {
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;
         
            string itemCode = base.SelectedItemData.Code;
            
            var sourceDatas1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_05);

            var sourceDatas2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_10);

            var sourceDatas3 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_30);

            var sourceDatas4 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_60);

            var sourceDatas5 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_120);

            var sourceDatas6 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Day);
            if (sourceDatas1 == null || sourceDatas1.Count == 0) return;
            if (sourceDatas2 == null || sourceDatas2.Count == 0) return;
            if (sourceDatas3 == null || sourceDatas3.Count == 0) return;
            if (sourceDatas4 == null || sourceDatas4.Count == 0) return;
            if (sourceDatas5 == null || sourceDatas5.Count == 0) return;
            if (sourceDatas6 == null || sourceDatas6.Count == 0) return;

            qMin5.LoadDataAndApply(itemCode, sourceDatas1, TimeIntervalEnum.Minute_05, 3);
            qMin10.LoadDataAndApply(itemCode, sourceDatas2, TimeIntervalEnum.Minute_10, 3);
            qMin30.LoadDataAndApply(itemCode, sourceDatas3, TimeIntervalEnum.Minute_30, 3);
            qMin60.LoadDataAndApply(itemCode, sourceDatas4, TimeIntervalEnum.Minute_60, 3);
            qMin120.LoadDataAndApply(itemCode, sourceDatas5, TimeIntervalEnum.Minute_120, 3);
            qDay.LoadDataAndApply(itemCode, sourceDatas6, TimeIntervalEnum.Day, 3);

            Summary(itemCode, (QuantumLineChart)qMin5);
            Summary(itemCode, (QuantumLineChart)qMin10);
            Summary(itemCode, (QuantumLineChart)qMin30);
            Summary(itemCode, (QuantumLineChart)qMin60);
            Summary(itemCode, (QuantumLineChart)qMin120);
            Summary(itemCode, (QuantumLineChart)qDay);
        }

        public void Summary(string itemCode, QuantumLineChart c)
        {
            var data2 = c.ChartData[c.ChartData.Count - 2];
            var data1 = c.ChartData[c.ChartData.Count - 1];
            
            Lib.Base.Enums.UpDownEnum upDown1 = Lib.Base.Enums.UpDownEnum.None;
            if (data2.T_QuantumAvg < data2.T_MassAvg && data1.T_QuantumAvg < data1.T_MassAvg) upDown1 = UpDownEnum.StrongUp;
            else if (data2.T_QuantumAvg < data2.T_MassAvg && data1.T_QuantumAvg >= data1.T_MassAvg) upDown1 = UpDownEnum.WeakUp;
            CandleSummary.Instance.UpdateSummaryTrend(itemCode, c.TimeInterval, "매수", upDown1);

            Lib.Base.Enums.UpDownEnum upDown2 = Lib.Base.Enums.UpDownEnum.None;
            if (data2.T_QuantumAvg > data2.T_MassAvg && data1.T_QuantumAvg > data1.T_MassAvg) upDown1 = UpDownEnum.StrongDown;
            else if (data2.T_QuantumAvg < data2.T_MassAvg && data1.T_QuantumAvg <= data1.T_MassAvg) upDown1 = UpDownEnum.WeakDown;
            CandleSummary.Instance.UpdateSummaryTrend(itemCode, c.TimeInterval, "매도", upDown2);


            int tick2 = PriceTick.GetTickDiff(itemCode, data2.MassPrice, data2.QuantumPrice);
            int tick1 = PriceTick.GetTickDiff(itemCode, data1.MassPrice, data1.QuantumPrice);

            CandleSummary.Instance.UpdateSummaryTrendOfStrength(itemCode, c.TimeInterval, "매수", tick2);
            CandleSummary.Instance.UpdateSummaryTrendOfStrength(itemCode, c.TimeInterval, "매도", tick2);
        }
    }
}
