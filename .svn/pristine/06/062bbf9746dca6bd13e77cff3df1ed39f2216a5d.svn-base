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
    public partial class BasicMainForm : BaseForm
    {
        List<BaseChartControl> charts = new List<BaseChartControl>();
        BaseChartControl c_bcc = new BasicCandleChart();
        BaseChartControl c_bcc2 = new BasicCandleChart();
        BaseChartControl c_ac = new AtomChart();
        BaseChartControl c_ac2 = new AtomChart();
        BaseChartControl c_qlc = new QuantumLineChart();
        BaseChartControl c_qlc2 = new QuantumLineChart();
        
        public BasicMainForm()
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

            c_bcc.InitializeControl();
            c_bcc.InitializeEvent(chartEvent);
            c_bcc.CandleChartType = CandleChartTypeEnum.기본;
            c_bcc.DisplayPointCount = itemCnt;
            c_bcc.Title = "기본캔들챠트";
            charts.Add(c_bcc);
            c_bcc2.InitializeControl();
            c_bcc2.InitializeEvent(chartEvent);
            c_bcc2.CandleChartType = CandleChartTypeEnum.기본;
            c_bcc2.IsAutoScrollX = false;
            c_bcc2.DisplayPointCount = itemCnt;
            c_bcc2.Title = "기본캔들챠트";
            charts.Add(c_bcc2);

            c_ac.InitializeControl();
            c_ac.IsAutoScrollX = false;
            c_ac.InitializeEvent(chartEvent);
            c_ac.DisplayPointCount = itemCnt;
            charts.Add(c_ac);
            c_ac2.InitializeControl();
            c_ac2.IsAutoScrollX = false;
            c_ac2.InitializeEvent(chartEvent);
            c_ac2.DisplayPointCount = itemCnt;
            charts.Add(c_ac2);

            c_qlc.InitializeControl();
            c_qlc.IsAutoScrollX = false;
            c_qlc.InitializeEvent(chartEvent);
            c_qlc.DisplayPointCount = itemCnt;
            charts.Add(c_qlc);
            c_qlc2.InitializeControl();
            c_qlc2.IsAutoScrollX = false;
            c_qlc2.InitializeEvent(chartEvent);
            c_qlc2.DisplayPointCount = itemCnt;
            charts.Add(c_qlc2);

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

            foreach (var c in charts)
                c.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval);
        }
    }
}
