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
    public partial class MultiChartForm4 : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qMin10 = new QuantumLineChart();
        BaseChartControl qMin30 = new QuantumLineChart();
        BaseChartControl qMin60 = new QuantumLineChart();
        BaseChartControl qMin120 = new QuantumLineChart();
        BaseChartControl qTick720 = new QuantumLineChart();
        BaseChartControl qTick1440 = new QuantumLineChart();

        public MultiChartForm4()
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

            charts.Add(qMin10);
            charts.Add(qMin30);

            charts.Add(qTick720);
            charts.Add(qTick1440);

            charts.Add(qMin60);
            charts.Add(qMin120);
           

            qMin10.Title = "추세10분";
            qMin30.Title = "추세30분";
            qMin60.Title = "추세60분";
            qMin120.Title = "추세120분";
            qTick720.Title = "추세720틱";
            qTick1440.Title = "추세1440틱";

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

            this.flowTable.Dock = DockStyle.Top;
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
                flowTable.Height = 300 * 3;
                flowTable.Visible = true;
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

            var sourceDatas720 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
               base.SelectedItemData.Code
             , TimeIntervalEnum.Tick_720);

            var sourceDatas1440 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
               base.SelectedItemData.Code
             , TimeIntervalEnum.Tick_1440);

            if (sourceDatas10 != null && sourceDatas10.Count > 0) {
                var averageDatas10 = PPUtils.GetAverageDatas(itemCode, sourceDatas10, 7);
                qMin10.LoadDataAndApply(itemCode, averageDatas10, TimeIntervalEnum.Minute_10, 3);
            }
            if (sourceDatas30 != null && sourceDatas30.Count > 0) {
                var averageDatas30 = PPUtils.GetAverageDatas(itemCode, sourceDatas30, 7);
                qMin30.LoadDataAndApply(itemCode, averageDatas30, TimeIntervalEnum.Minute_30, 3);
            }
            if (sourceDatas60 != null && sourceDatas60.Count > 0) {
                var averageDatas60 = PPUtils.GetAverageDatas(itemCode, sourceDatas60, 7);
                qMin60.LoadDataAndApply(itemCode, averageDatas60, TimeIntervalEnum.Minute_60, 3);
            }
            if (sourceDatas120 != null && sourceDatas120.Count > 0) {
                var averageDatas120 = PPUtils.GetAverageDatas(itemCode, sourceDatas120, 7);
                qMin120.LoadDataAndApply(itemCode, averageDatas120, TimeIntervalEnum.Minute_120, 3);
            }
            if (sourceDatas720 != null && sourceDatas720.Count > 0) {
                var averageDatas720 = PPUtils.GetAverageDatas(itemCode, sourceDatas720, 7);
                qTick720.LoadDataAndApply(itemCode, averageDatas720, TimeIntervalEnum.Tick_720, 3);
            }
            if (sourceDatas1440 != null && sourceDatas1440.Count > 0) {
                var averageDatas1440 = PPUtils.GetAverageDatas(itemCode, sourceDatas1440, 7);
                qTick1440.LoadDataAndApply(itemCode, averageDatas1440, TimeIntervalEnum.Tick_1440, 3);
            }
        }
    }
}
