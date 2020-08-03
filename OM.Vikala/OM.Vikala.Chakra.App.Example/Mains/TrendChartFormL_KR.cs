using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Config;
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
    public partial class TrendChartFormL_KR : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl qMin1 = new QuantumLineChart();
        BaseChartControl qMin2 = new QuantumLineChart();
        BaseChartControl qMin3 = new QuantumLineChart();
        BaseChartControl qMin4 = new QuantumLineChart();
        public TrendChartFormL_KR()
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
                flowTable.Controls.Add(charts[1], 0, 1);
                flowTable.Controls.Add(charts[2], 0, 2);
                flowTable.Controls.Add(charts[3], 0, 3);
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

            TimeIntervalEnum timeInterval = TimeIntervalEnum.Week;

            var sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                   base.SelectedItemData.Code
                 , timeInterval);

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);
            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 
            SetChangeOpenPrice(itemCode, sourceDatas);

            if (sourceDatas != null && sourceDatas.Count > 0)
            {
                var averageDatas1 = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
                var averageDatas2 = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 9);
                var averageDatas3 = PPUtils.GetAccumulatedAverageDatas(itemCode, sourceDatas, 9);

                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas1[0].DTime);

                qMin1.LoadDataAndApply(itemCode, sourceDatas, timeInterval, 3);
                qMin2.LoadDataAndApply(itemCode, averageDatas1, timeInterval, 3);
                qMin3.LoadDataAndApply(itemCode, averageDatas2, timeInterval, 3);
                qMin4.LoadDataAndApply(itemCode, averageDatas3, timeInterval, 3);
            }
        }
    }
}
