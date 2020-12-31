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
    public partial class AntiMatterMixedChartForm : BaseForm
    {

        public AntiMatterMixedChartForm()
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
            userToolStrip.ItemCountChangedEvent += UserToolStrip_ItemCountChangedEvent;

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

        private void UserToolStrip_ItemCountChangedEvent(object sender, EventArgs e)
        {
            loadData();
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
            chart.IsShowVirtualDepth = true;
        }

        public override void loadData()
        {
            if (isLoading) return;
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            string selectedType = this.SelectedType;
            if (string.IsNullOrEmpty(selectedType))
                selectedType = SharedData.SelectedType;

            isLoading = true;

            List<S_CandleItemData> sourceDatas = LoadData(itemCode, selectedType);
            List<S_CandleItemData> sourceDatas2 = null;
            List<S_CandleItemData> sourceDatas3 = null;

            TimeIntervalEnum selectedInterval = this.timeInterval;

            if (selectedInterval == TimeIntervalEnum.Week) this.timeInterval = TimeIntervalEnum.Day;
            if (selectedInterval == TimeIntervalEnum.Day) this.timeInterval = TimeIntervalEnum.Hour_05;
            if (selectedInterval == TimeIntervalEnum.Hour_05) this.timeInterval = TimeIntervalEnum.Hour_01;
            if (selectedInterval == TimeIntervalEnum.Hour_02) this.timeInterval = TimeIntervalEnum.Minute_30;
            if (selectedInterval == TimeIntervalEnum.Hour_01) this.timeInterval = TimeIntervalEnum.Minute_15;
            sourceDatas2 = LoadData(itemCode, selectedType);

            if (selectedInterval == TimeIntervalEnum.Week) this.timeInterval = TimeIntervalEnum.Hour_05;
            if (selectedInterval == TimeIntervalEnum.Day) this.timeInterval = TimeIntervalEnum.Hour_01;
            if (selectedInterval == TimeIntervalEnum.Hour_05) this.timeInterval = TimeIntervalEnum.Minute_15;
            if (selectedInterval == TimeIntervalEnum.Hour_02) this.timeInterval = TimeIntervalEnum.Minute_05;
            if (selectedInterval == TimeIntervalEnum.Hour_01) this.timeInterval = TimeIntervalEnum.Minute_01;
            sourceDatas3 = LoadData(itemCode, selectedType);

            this.timeInterval = selectedInterval;

            isLoading = false;

            if (sourceDatas == null || sourceDatas.Count == 0) return;

            for (int i = 0; i < sourceDatas.Count; i++)
            {
                int pIdx = i - 1 < 0 ? 0 : i - 1;
                int nIdx = i + 1 > sourceDatas.Count - 1 ? sourceDatas.Count - 1 : i + 1;

                sourceDatas[i].PreCandleItem = sourceDatas[pIdx];
                sourceDatas[i].NextCandleItem = sourceDatas[nIdx];
            }

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);
            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 
            //var removeGapSourceDatas = PPUtils.RemoveGapPrice(sourceDatas);

            //sourceDatas = PPUtils.SetMergeByTime(sourceDatas, sourceDatas2, timeInterval);
            sourceDatas = PPUtils.SetMergeByTime(sourceDatas, sourceDatas2, sourceDatas3, timeInterval);

            int averageCount = 9;
            if (timeInterval == TimeIntervalEnum.Minute_01
               || timeInterval == TimeIntervalEnum.Minute_05
               || timeInterval == TimeIntervalEnum.Minute_10
               || timeInterval == TimeIntervalEnum.Minute_30)
                averageCount = 9;

            var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, averageCount);
            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);

            chart.LoadDataAndApply(itemCode, sourceDatas, averageDatas, base.timeInterval, 9);          
        }
    }
}
