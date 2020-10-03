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

namespace OM.Vikala.Chakra.App.Mains.ToolbarChartForms
{
    public partial class ComparedCandleChartForm : BaseForm
    {      
        public ComparedCandleChartForm()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
    
        private void InitializeControls()
        {           
            loadChartControls();
            //setTimer();
            userToolStrip.IsVisibleAlignmentButton = false;
            userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent; userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
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

            List<S_CandleItemData> sourceDatas = null;
            if (SharedData.SelectedType == "국내업종")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "3", "0", "500");
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
            else
                sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  itemCode
                , base.timeInterval);

            if (sourceDatas == null || sourceDatas.Count == 0) return;

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);

            //var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
            var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 4);
            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
            chart.LoadDataAndApply(itemCode, sourceDatas, averageDatas, base.timeInterval, 9);            
        }
    }
}
