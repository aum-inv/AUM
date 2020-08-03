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

        BaseChartControl qMin1 = new QuantumLineChartHL();
        BaseChartControl qMin2 = new QuantumLineChartHL();
        BaseChartControl qMin3 = new QuantumLineChartHL();
        BaseChartControl qMin4 = new QuantumLineChartHL();
        BaseChartControl qMin5= new QuantumLineChartHL();
        BaseChartControl qMin6 = new QuantumLineChartHL();

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
            charts.Add(qMin1);
            charts.Add(qMin2);
            charts.Add(qMin3);
            charts.Add(qMin4);
            charts.Add(qMin5);
            charts.Add(qMin6);

            qMin1.Title = "챠트 1시간";
            qMin2.Title = "챠트 2시간";
            qMin3.Title = "챠트 3시간";
            qMin4.Title = "챠트 6시간";
            qMin5.Title = "챠트 12시간";
            qMin6.Title = "챠트 24시간";

            foreach (var c in charts)
            {
                if (c is QuantumLineChart)
                {
                    c.IsShowXLine = true;
                    c.InitializeControl();
                    c.InitializeEvent(null);                 
                    ((QuantumLineChart)c).IsShowCandle = true;
                }
                else if (c is QuantumLineChartHL)
                {
                    c.IsAutoScrollX = true;
                    c.IsShowXLine = false;
                    c.InitializeControl();
                    c.InitializeEvent(null);
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

            var sourceDatas1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                   base.SelectedItemData.Code
                 , TimeIntervalEnum.Minute_60);
            var sourceDatas2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_120);
            var sourceDatas3 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_180);
            var sourceDatas4 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_360);
            var sourceDatas5 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Minute_720);
            var sourceDatas6 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Day);

            if (sourceDatas1 != null && sourceDatas1.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas1, 9);
                qMin1.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_60, 3);
            }
            if (sourceDatas2 != null && sourceDatas2.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas2, 9);
                qMin2.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_120, 3);
            }
            if (sourceDatas3 != null && sourceDatas3.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas3, 9);
                qMin3.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_180, 3);              
            }
            if (sourceDatas4 != null && sourceDatas4.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas4, 9);
                qMin4.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_360, 3);
            }
            if (sourceDatas5 != null && sourceDatas5.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas5, 9);
                qMin5.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_720, 3);
            }
            if (sourceDatas6 != null && sourceDatas6.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas6, 9);
                qMin6.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Day, 3);
            }
        }
    }
}
