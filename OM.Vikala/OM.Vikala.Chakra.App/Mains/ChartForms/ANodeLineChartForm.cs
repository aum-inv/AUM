using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Chakra;
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

namespace OM.Vikala.Chakra.App.Mains.ChartForm
{
    public partial class ANodeLineChartForm : BaseForm
    {
        public ANodeLineChartForm()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        public ANodeLineChartForm(AverageTypeEnum averageType = AverageTypeEnum.Normal)
        {
            InitializeComponent();
            this.AverageType = averageType;
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        public ANodeLineChartForm(OriginSourceTypeEnum originSourceType = OriginSourceTypeEnum.Normal)
        {
            InitializeComponent();
            this.OriginSourceType = originSourceType;
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        public ANodeLineChartForm(AverageTypeEnum averageType = AverageTypeEnum.Normal
            , OriginSourceTypeEnum originSourceType = OriginSourceTypeEnum.Normal)
        {
            InitializeComponent();
            this.AverageType = averageType;
            this.OriginSourceType = originSourceType;
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }

        private void InitializeControls()
        {           
            loadChartControls();
            setTimer();
            userToolStrip.IsVisibleAlignmentButton = false;
            userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent;
            userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            chart1.BoldLine(sender.ToString());
            chart2.BoldLine(sender.ToString());
            chart3.BoldLine(sender.ToString());
            chart4.BoldLine(sender.ToString());
        }

        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
            if (sender.ToString() == "0")
            {
                tableLayoutPanel1.RowStyles[0].Height = 25.0f;
                tableLayoutPanel1.RowStyles[1].Height = 25.0f;
                tableLayoutPanel1.RowStyles[2].Height = 25.0f;
                tableLayoutPanel1.RowStyles[3].Height = 25.0f;
            }
            if (sender.ToString() == "1")
            {
                tableLayoutPanel1.RowStyles[0].Height = 100.0f;
                tableLayoutPanel1.RowStyles[1].Height = 0f;
                tableLayoutPanel1.RowStyles[2].Height = 0f;
                tableLayoutPanel1.RowStyles[3].Height = 0f;
            }
            if (sender.ToString() == "2")
            {
                tableLayoutPanel1.RowStyles[0].Height = 0f;
                tableLayoutPanel1.RowStyles[1].Height = 100.0f;
                tableLayoutPanel1.RowStyles[2].Height = 0f;
                tableLayoutPanel1.RowStyles[3].Height = 0f;
            }
            if (sender.ToString() == "3")
            {
                tableLayoutPanel1.RowStyles[0].Height = 0f;
                tableLayoutPanel1.RowStyles[1].Height = 0f;
                tableLayoutPanel1.RowStyles[2].Height = 100.0f;
                tableLayoutPanel1.RowStyles[3].Height = 0f;
            }
            if (sender.ToString() == "4")
            {
                tableLayoutPanel1.RowStyles[0].Height = 0f;
                tableLayoutPanel1.RowStyles[1].Height = 0f;
                tableLayoutPanel1.RowStyles[2].Height = 0f;
                tableLayoutPanel1.RowStyles[3].Height = 100.0f;
            }
        }
        public override void loadChartControls()
        {
            chart1.InitializeControl();
            chart1.InitializeEvent(chartEvent);
            chart1.DisplayPointCount = itemCnt;

            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;

            chart3.InitializeControl();
            chart3.InitializeEvent(chartEvent);
            chart3.DisplayPointCount = itemCnt;

            chart4.InitializeControl();
            chart4.InitializeEvent(chartEvent);
            chart4.DisplayPointCount = itemCnt;
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
            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 

            var quantumDatas = PPUtils.GetANodeDatas(sourceDatas);
            var plusQuantumDatas = quantumDatas.plusList;
            var minusQuantumDatas = quantumDatas.minusList;

            //SetChangeOpenPrice(itemCode, plusQuantumDatas);
            //SetChangeOpenPrice(itemCode, minusQuantumDatas);

            string chartTitle = "ANode::";
            if (OriginSourceType == OriginSourceTypeEnum.Normal)
            {
                chartTitle += "Orgin::";
            }
            if (OriginSourceType == OriginSourceTypeEnum.Whim)
            {
                plusQuantumDatas = PPUtils.GetRecreateWhimDatas(itemCode, plusQuantumDatas, true);
                minusQuantumDatas = PPUtils.GetRecreateWhimDatas(itemCode, minusQuantumDatas, true);
                chartTitle += "Whim::";
            }
            if (OriginSourceType == OriginSourceTypeEnum.Second)
            {
                plusQuantumDatas = PPUtils.GetRecreateSecondDatas(itemCode, plusQuantumDatas, 5, false);
                minusQuantumDatas = PPUtils.GetRecreateSecondDatas(itemCode, minusQuantumDatas, 5, false);
                chartTitle += "Second::";
            }
            if (OriginSourceType == OriginSourceTypeEnum.SecondQutum)
            {
                plusQuantumDatas = PPUtils.GetRecreateSecondDatas(itemCode, plusQuantumDatas, 5, true);
                minusQuantumDatas = PPUtils.GetRecreateSecondDatas(itemCode, minusQuantumDatas, 5, true);
                chartTitle += "SQutum::";
            }

            if (true || AverageType == AverageTypeEnum.Normal)
            {
                var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 5);
                var pAverageDatas = PPUtils.GetAverageDatas(itemCode, plusQuantumDatas, 5);
                var mAverageDatas = PPUtils.GetAverageDatas(itemCode, minusQuantumDatas, 5);
               
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, pAverageDatas[0].DTime);
                chart1.LoadDataAndApply(itemCode, sourceDatas, pAverageDatas, mAverageDatas, base.timeInterval, 5);
                chart2.LoadDataAndApply(itemCode, averageDatas, pAverageDatas, mAverageDatas, base.timeInterval, 5);
                chart1.Title = chartTitle + "Normal";
                chart2.Title = chartTitle + "Normal";
            }
            if (true || AverageType == AverageTypeEnum.Balanced)
            {
                var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 4);
                var pAverageDatas = PPUtils.GetBalancedAverageDatas(itemCode, plusQuantumDatas, 4);
                var mAverageDatas = PPUtils.GetBalancedAverageDatas(itemCode, minusQuantumDatas, 4);

                sourceDatas = PPUtils.GetCutDatas(sourceDatas, pAverageDatas[0].DTime);
                chart3.LoadDataAndApply(itemCode, sourceDatas, pAverageDatas, mAverageDatas, base.timeInterval, 5);
                chart3.Title = chartTitle + "Balanced";
            }
            if (true || AverageType == AverageTypeEnum.Accumulated)
            {
                var averageDatas = PPUtils.GetAccumulatedAverageDatas(itemCode, sourceDatas, 9);
                var pAverageDatas = PPUtils.GetAccumulatedAverageDatas(itemCode, plusQuantumDatas, 9);
                var mAverageDatas = PPUtils.GetAccumulatedAverageDatas(itemCode, minusQuantumDatas, 9);

                sourceDatas = PPUtils.GetCutDatas(sourceDatas, pAverageDatas[0].DTime);
                chart4.LoadDataAndApply(itemCode, sourceDatas, pAverageDatas, mAverageDatas, base.timeInterval, 5);
                chart4.Title = chartTitle + "Accumulated";
            }
        }               
    }
}
