using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
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
    public partial class TrendMinuteChartForm : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qMin05 = new QuantumLineChart();
        BaseChartControl qMin30 = new QuantumLineChart();

        BaseChartControl qMin10 = new QuantumLineChart();
        BaseChartControl qMin60 = new QuantumLineChart();

        BaseChartControl qMin20= new QuantumLineChart();
        BaseChartControl qMin120 = new QuantumLineChart();
     
        //BaseChartControl qTick1 = new QuantumLineChart();
        //BaseChartControl qTick2 = new QuantumLineChart();

        public TrendMinuteChartForm()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }

        private void InitializeControls()
        {
            flowDirection = FlowDirectionTypeEnum.TABLE;
            loadChartControls();
            setTimer();
        }

        public override void loadChartControls()
        {
            charts.Clear();
            charts.Add(qMin05);
            charts.Add(qMin30);

            charts.Add(qMin10);
            charts.Add(qMin60);

            charts.Add(qMin20);
            charts.Add(qMin120);

            qMin05.Title = "챠트 05분";
            qMin10.Title = "챠트 10분";
            qMin20.Title = qMin30.Title = "챠트 30분";
            qMin60.Title = "챠트 60분";
            qMin120.Title = "챠트 120분";

            foreach (var c in charts)
            {
                if (c is QuantumLineChart)
                {
                    c.IsShowXLine = true;
                    c.InitializeControl();
                    c.InitializeEvent(null);                 
                    ((QuantumLineChart)c).IsShowCandle = true;
                }
                else if (c is AtomChart)
                {
                    c.IsAutoScrollX = true;
                    c.IsShowXLine = false;
                    c.InitializeControl();
                    c.InitializeEvent(null);                 
                    ((AtomChart)c).IsShowLine = false;
                    ((AtomChart)c).IsShowCandle = false;
                }
            }           
            this.flowTable.Dock = DockStyle.Fill;
            setFlow();
        }

        public override void setFlow()
        {
            flowTable.Visible = false;          
            flowTable.Controls.Clear();          
            if (flowDirection == FlowDirectionTypeEnum.TABLE)
            {
                flowTable.Controls.Add(charts[0], 0, 0);
                flowTable.Controls.Add(charts[1], 1, 0);
                flowTable.Controls.Add(charts[2], 0, 1);
                flowTable.Controls.Add(charts[3], 1, 1);
                flowTable.Controls.Add(charts[4], 0, 2);
                flowTable.Controls.Add(charts[5], 1, 2);
                flowTable.Visible = true;
            }
            foreach (var c in charts)
            {              
                c.Dock = DockStyle.Fill;
                c.BorderStyle = BorderStyle.None;
            }
        }

        public override void loadData()
        {
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            var sourceDatas05 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                   base.SelectedItemData.Code
                 , TimeIntervalEnum.Minute_05);
            var sourceDatas10 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_10);
            var sourceDatas30 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_30);
            var sourceDatas60 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_60);
            var sourceDatas120 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_120);
         
            if (sourceDatas05 != null && sourceDatas05.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas05, 7);
                qMin05.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_05, 3);
            }
            if (sourceDatas10 != null && sourceDatas10.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas10, 7);
                qMin10.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_10, 3);
            }
            if (sourceDatas30 != null && sourceDatas30.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas30, 7);
                qMin20.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_30, 3);
                qMin30.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_30, 3);
            }
            if (sourceDatas60 != null && sourceDatas60.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas60, 7);
                qMin60.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_60, 3);
            }
            if (sourceDatas120 != null && sourceDatas120.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas120, 7);
                qMin120.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_120, 3);
            }
        }
    }
}
