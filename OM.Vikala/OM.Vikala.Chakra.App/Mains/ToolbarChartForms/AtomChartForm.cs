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
    public partial class AtomChartForm : BaseForm
    {
        public AtomChartForm()
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
        }

        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
          
        }
        public override void loadChartControls()
        {
            chart.IsShowLine = true;
            chart.IsShowXLine = chart.IsShowYLine = true;
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;
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
            else if (SharedData.SelectedType == "국내종목")
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

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);

            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 
            //var removeGapSourceDatas = PPUtils.RemoveGapPrice(sourceDatas);

            int averageCount = 9;
            if (timeInterval == TimeIntervalEnum.Minute_01
               || timeInterval == TimeIntervalEnum.Minute_05
               || timeInterval == TimeIntervalEnum.Minute_10
               || timeInterval == TimeIntervalEnum.Minute_30)
                averageCount = 9;

            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, averageCount);
            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
            chart.LoadDataAndApply(itemCode, sourceDatas, averageDatas, base.timeInterval, 5);
            chart.Title = "";

        }          
    }
}
