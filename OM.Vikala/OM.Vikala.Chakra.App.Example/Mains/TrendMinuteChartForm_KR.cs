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
    public partial class TrendMinuteChartForm_KR : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qMin1 = new QuantumLineChartHL();
        BaseChartControl qMin2 = new QuantumLineChartHL();
        BaseChartControl qMin3 = new QuantumLineChartHL();
        BaseChartControl qMin4 = new QuantumLineChartHL();
  
        public TrendMinuteChartForm_KR()
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
          

            qMin1.Title = "챠트 1시간";
            qMin2.Title = "챠트 3시간";
            qMin3.Title = "챠트 일";
            qMin4.Title = "챠트 주";
          

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
                , TimeIntervalEnum.Minute_180);
            var sourceDatas3 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Day);
            var sourceDatas4 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , TimeIntervalEnum.Week);
          

            if (sourceDatas1 != null && sourceDatas1.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas1, 9);
                qMin1.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_60, 3);
            }
            if (sourceDatas2 != null && sourceDatas2.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas2, 9);
                qMin2.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Minute_180, 3);
            }
            if (sourceDatas3 != null && sourceDatas3.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas3, 9);
                qMin3.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Day, 3);              
            }
            if (sourceDatas4 != null && sourceDatas4.Count > 0)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas4, 9);
                qMin4.LoadDataAndApply(itemCode, averageDatas, TimeIntervalEnum.Week, 3);
            }           
        }
    }
}
