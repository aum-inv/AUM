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

namespace OM.Vikala.Chakra.App.Mains.ChartForm
{
    public partial class CandleChartForm2 : BaseForm
    {       
        public CandleChartForm2()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }        

        private void InitializeControls()
        {           
            loadChartControls();
            setTimer();
            userToolStrip.IsVisibleAlignmentButton = false;
            userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent; userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            chart.BoldLine(sender.ToString());
            chart2.BoldLine(sender.ToString());
            chart3.BoldLine(sender.ToString());
        }
        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {            
        }
        public override void loadChartControls()
        {
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;
            chart.CandleChartType = CandleChartTypeEnum.기본;
            chart.BaseCandleChartType = BaseCandleChartTypeEnum.천;
            
            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;
            chart2.CandleChartType = CandleChartTypeEnum.기본;
            chart2.BaseCandleChartType = BaseCandleChartTypeEnum.인;

            chart3.InitializeControl();
            chart3.InitializeEvent(chartEvent);
            chart3.DisplayPointCount = itemCnt;
            chart3.CandleChartType = CandleChartTypeEnum.기본;
            chart3.BaseCandleChartType = BaseCandleChartTypeEnum.지;
        }

        public override void loadData()
        {
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            var sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(                 
                  itemCode
                , base.timeInterval);
            if (sourceDatas == null || sourceDatas.Count == 0) return;

            chart.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 11);
            chart2.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 11);
            chart3.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 11);
        }
    }
}
