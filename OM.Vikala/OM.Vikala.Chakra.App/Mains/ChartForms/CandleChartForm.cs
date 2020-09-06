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
    public partial class CandleChartForm : BaseForm
    {
        CandleChartTypeEnum candleChartType = CandleChartTypeEnum.기본;
        BaseCandleChartTypeEnum baseCandleChartType = BaseCandleChartTypeEnum.인;

        public CandleChartForm()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        //public CandleChartForm(CandleChartTypeEnum candleChartType)
        //{
        //    InitializeComponent();
        //    base.setToolStrip(userToolStrip1);
        //    this.candleChartType = candleChartType;
        //    InitializeControls();
        //}
        //public CandleChartForm(CandleChartTypeEnum candleChartType, BaseCandleChartTypeEnum baseCandleChartType)
        //{
        //    InitializeComponent();
        //    base.setToolStrip(userToolStrip1);
        //    this.candleChartType = candleChartType;
        //    this.baseCandleChartType = baseCandleChartType;
        //    InitializeControls();
        //}

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
        }
        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
            if (sender.ToString() == "1")
            {
                tableLayoutPanel1.RowStyles[0].Height = 100.0f;
                tableLayoutPanel1.RowStyles[1].Height = 0f;
            }
            if (sender.ToString() == "2")
            {
                tableLayoutPanel1.RowStyles[1].Height = 100.0f;
                tableLayoutPanel1.RowStyles[0].Height = 0f;
            }
            if (sender.ToString() == "3")
            {
                tableLayoutPanel1.RowStyles[0].Height = 50.0f;
                tableLayoutPanel1.RowStyles[1].Height = 50.0f;
            }
        }
        public override void loadChartControls()
        {
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;
            chart.CandleChartType = candleChartType;
            
            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;
            chart2.CandleChartType = candleChartType;
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

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);
            
            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
           
            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
            chart.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 9);
            chart2.LoadDataAndApply(itemCode, averageDatas, base.timeInterval, 9);
        }
    }
}
