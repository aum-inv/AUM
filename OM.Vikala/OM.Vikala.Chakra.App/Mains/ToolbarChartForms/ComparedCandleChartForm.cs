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
            chart1.BoldLine(sender.ToString());
            chart2.BoldLine(sender.ToString());
        }
        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
        }
        public override void loadChartControls()
        {
            chart1.IsShowXLine = chart1.IsShowYLine = true;
            chart1.InitializeControl();
            chart1.InitializeEvent(chartEvent);
            chart1.DisplayPointCount = itemCnt / 2;

            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt / 2;
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
            isLoading = false;

            if (sourceDatas == null || sourceDatas.Count == 0) return;

            //표시할 갯수를 맞춘다.
            RemoveSourceData(sourceDatas);

            int averageCount = 9;

            if (timeInterval == TimeIntervalEnum.Minute_01
                || timeInterval == TimeIntervalEnum.Minute_05
                || timeInterval == TimeIntervalEnum.Minute_10
                || timeInterval == TimeIntervalEnum.Minute_30)
                averageCount = 18;

            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, averageCount, false);        
            //var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, averageCount);

            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
            chart1.LoadDataAndApply(itemCode, sourceDatas, averageDatas, base.timeInterval, averageCount);

            //var removeGapSourceDatas = PPUtils.RemoveGapPrice(sourceDatas);
            //var averageDatas2 = PPUtils.GetBalancedAverageDatas(itemCode, removeGapSourceDatas, 4);

            for(int i = 0; i < averageCount; i++)
                averageDatas.RemoveAt(0);

            averageDatas.RemoveAt(0);
            averageDatas.RemoveAt(0);
            averageDatas.RemoveAt(0);
            chart2.LoadDataAndApply(itemCode, averageDatas, averageDatas, timeInterval, averageCount);
        }
    }
}
