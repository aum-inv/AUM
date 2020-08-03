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
    public partial class TrendTickChartForm : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qTick180 = new QuantumLineChart();
        BaseChartControl qTick720 = new QuantumLineChart();

        BaseChartControl qTick360 = new QuantumLineChart();
        BaseChartControl qTick1080 = new QuantumLineChart();

        BaseChartControl qTick721= new QuantumLineChart();
        BaseChartControl qTick1440 = new QuantumLineChart();
     
        //BaseChartControl qTick1 = new QuantumLineChart();
        //BaseChartControl qTick2 = new QuantumLineChart();

        public TrendTickChartForm()
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
            charts.Add(qTick180);
            charts.Add(qTick720);

            charts.Add(qTick360);
            charts.Add(qTick1080);

            charts.Add(qTick721);
            charts.Add(qTick1440);

            qTick180.Title = "챠트 180틱";
            qTick360.Title = "챠트 360틱";
            qTick720.Title = qTick721.Title = "챠트 720틱";
            qTick1080.Title = "챠트 1080틱";
            qTick1440.Title = "챠트 1440틱";

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

            var sourceDatas180 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                   base.SelectedItemData.Code
                 , TimeIntervalEnum.Tick_180);
            var sourceDatas360 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Tick_360);
            var sourceDatas720 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Tick_720);
            var sourceDatas1080 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Tick_1080);
            var sourceDatas1440 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Tick_1440);
         
            if (sourceDatas180 != null && sourceDatas180.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas180, 7);
                qTick180.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_180, 3);
            }
            if (sourceDatas360 != null && sourceDatas360.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas360, 7);
                qTick360.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_360, 3);
            }
            if (sourceDatas720 != null && sourceDatas720.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas720, 7);
                qTick720.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_720, 3);
                qTick721.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_720, 3);
            }
            if (sourceDatas1080 != null && sourceDatas1080.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas1080, 7);
                qTick1080.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_1080, 3);
            }
            if (sourceDatas1440 != null && sourceDatas1440.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas1440, 7);
                qTick1440.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Tick_1440, 3);
            }
        }
    }
}
