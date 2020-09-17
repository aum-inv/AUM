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

namespace OM.Vikala.Chakra.App.Mains.ToolbarChartForms
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
            userToolStrip.IsVisibleExpand = false;
            userToolStrip.IsVisibleMdiButton = false;
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            chart.BoldLine(sender.ToString());           
        }

        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
        }
        public override void loadChartControls()
        {
            chart.IsShowXLine = chart.IsShowYLine = true;
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;           
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

            var removeGapSourceDatas = PPUtils.RemoveGapPrice(sourceDatas);
            var quantumDatas = PPUtils.GetANodeDatas(removeGapSourceDatas);
            var plusQuantumDatas = quantumDatas.plusList;
            var minusQuantumDatas = quantumDatas.minusList;
                      
            var pAverageDatas = PPUtils.GetBalancedAverageDatas(itemCode, plusQuantumDatas, 4);
            var mAverageDatas = PPUtils.GetBalancedAverageDatas(itemCode, minusQuantumDatas, 4);

            sourceDatas = PPUtils.GetCutDatas(sourceDatas, pAverageDatas[0].DTime);
            chart.LoadDataAndApply(itemCode, sourceDatas, pAverageDatas, mAverageDatas, base.timeInterval, 5);
        }
    }
}
