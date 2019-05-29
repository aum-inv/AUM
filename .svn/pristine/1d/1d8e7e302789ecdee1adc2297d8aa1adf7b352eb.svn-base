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
    public partial class MultiChartForm3 : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();

        BaseChartControl q1 = new BasicCandleChart();
        BaseChartControl q2= new WuXingCandleChart();
        BaseChartControl q3= new PrimeNumCandleChart();
        BaseChartControl q4= new BasicCandleChart();
        BaseChartControl q5 = new BasicCandleChart();
        BaseChartControl q6 = new BasicCandleChart();

        public MultiChartForm3()
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

            charts.Add(q1);
            charts.Add(q2);
            charts.Add(q3);
            charts.Add(q4);
            charts.Add(q5);
            charts.Add(q6);

            q1.Title = "음양오행";
            q2.Title = "음양오행-누적";
            q3.Title = "음양오행-소수";
            q4.Title = "삼양삼음";
            q5.Title = "쿼크";
            q6.Title = "천지인";

            q1.CandleChartType = CandleChartTypeEnum.음양오행;            
            q4.CandleChartType = CandleChartTypeEnum.삼양삼음;    
            q5.CandleChartType = CandleChartTypeEnum.쿼크;    
            q6.CandleChartType = CandleChartTypeEnum.천지인;

            foreach (var c in charts)
            {
                c.IsShowXLine = true;
                c.InitializeControl();
                c.InitializeEvent(null);
                c.DisplayPointCount = 40;
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

            var sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  base.SelectedItemData.Code
                , base.timeInterval);
            if (sourceDatas == null || sourceDatas.Count == 0) return;
            
            foreach (var q in charts)
                q.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval);
        }
    }
}
