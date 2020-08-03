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
    public partial class MovingAverageDurationChartForm : BaseForm
    {
        bool isStrengthed = false;
        int inflectionPoint = 3;
        string averageType = "단순";
        public MovingAverageDurationChartForm(string averageType = "단순", bool isStrengthed = false, int inflectionPoint = 3)
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();

            this.averageType = averageType;
            this.isStrengthed = isStrengthed;
            this.inflectionPoint = inflectionPoint;
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
            chart.DisplayPointCount = 500;

            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = 500;
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
            //RemoveSourceData(sourceDatas);
            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 
            SetChangeOpenPrice(itemCode, sourceDatas);

            bool isUseWhim = false;
            if (isUseWhim)
            {
                double rate = 0.0;
                if (timeInterval == TimeIntervalEnum.Week) rate = 2.5;
                if (timeInterval == TimeIntervalEnum.Day) rate = 1.0;
                if (timeInterval == TimeIntervalEnum.Minute_180) rate = 0.7;
                if (timeInterval == TimeIntervalEnum.Minute_120) rate = 0.5;
                if (timeInterval == TimeIntervalEnum.Minute_60) rate = 0.3;
                sourceDatas = PPUtils.GetRecreateWhimDatas(itemCode, sourceDatas, true, rate, null);
            }


            List<S_CandleItemData> averageDatas = null;
            if (averageType == "일반")
            {
                averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
            }
            else if (averageType == "밸런스")
            {
                averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 9);
            }
            else //if (averageType == "가중")
            {
                averageDatas = PPUtils.GetAccumulatedAverageDatas(itemCode, sourceDatas, 9);
            }           

            var averageDatas2 = PPUtils.GetMovingAverageDurationFlow(itemCode, averageDatas, isStrengthed, inflectionPoint);            
            var sourceDatas2 = PPUtils.GetDurationSum(itemCode, averageDatas2, sourceDatas);

            chart.LoadDataAndApply(itemCode, sourceDatas2, base.timeInterval, 9);
            chart2.LoadDataAndApply(itemCode, averageDatas2, base.timeInterval, 9);

            chart2.SetYFormat("N0");
           
            
        }        
    }
}
