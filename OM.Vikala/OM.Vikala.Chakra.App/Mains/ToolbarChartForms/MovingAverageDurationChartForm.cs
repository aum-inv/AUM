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
    public partial class MovingAverageDurationChartForm : BaseForm
    {
        bool isStrengthed = false;
        int inflectionPoint = 3;
        public MovingAverageDurationChartForm(bool isStrengthed = false, int inflectionPoint = 3)
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();

            this.isStrengthed = isStrengthed;
            this.inflectionPoint = inflectionPoint;
        }
      
        private void InitializeControls()
        {           
            loadChartControls();
            //setTimer();
            userToolStrip.IsVisibleAlignmentButton = false;
            userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent;
            userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
            userToolStrip.IsVisibleExpand = false;
            userToolStrip.IsVisibleMdiButton = false;

            App.Events.MainFormToolBarEvents.Instance.ManualReloadHandler += () =>
            {
                Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(new Random().Next(100, 5000));
                    loadData();
                });
            };
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            chart.BoldLine(sender.ToString());
            chart2.BoldLine(sender.ToString());
        }

        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
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
            if (isLoading) return;
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            List<S_CandleItemData> sourceDatas = null;
            isLoading = true;

            if (SharedData.SelectedType == "국내업종")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "3", "0", "500");
            }
            else if (SharedData.SelectedType == "국내지수")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "3", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "1", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "5", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "10", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "30", "500");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "60", "500");
            }
            else if(SharedData.SelectedType == "국내종목")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "3", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "10", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "30", "500");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "60", "500");
            }
            else if (SharedData.SelectedType == "해외지수")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(itemCode, "0");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(itemCode, "1");
            }
            else if (SharedData.SelectedType == "해외선물")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "D");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "W");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "H");
                else if (timeInterval == TimeIntervalEnum.Hour_02)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "2H");
                else if (timeInterval == TimeIntervalEnum.Hour_04)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "4H");
                else if (timeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "M");
                else if (timeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "5M");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "30M");
            }
            else
                sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  itemCode
                , base.timeInterval);

            isLoading = false;

            if (sourceDatas == null || sourceDatas.Count == 0) return;
                     
            var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 9);
            var averageDatas2 = PPUtils.GetMovingAverageDurationFlow(itemCode, averageDatas, isStrengthed, inflectionPoint);            
            var sourceDatas2 = PPUtils.GetDurationSum(itemCode, averageDatas2, sourceDatas);

            chart.LoadDataAndApply(itemCode, sourceDatas2, base.timeInterval, 9);
            chart2.LoadDataAndApply(itemCode, averageDatas2, base.timeInterval, 9);

            chart2.SetYFormat("N0");
        }        
    }
}
