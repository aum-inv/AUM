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
    public partial class BuySellLineChartForm : BaseForm
    {      
        public BuySellLineChartForm()
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
        }
        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
        }
        public override void loadChartControls()
        {
            chart1.IsShowXLine = chart1.IsShowYLine = true;
            chart1.InitializeControl();
            chart1.InitializeEvent(chartEvent);
            chart1.DisplayPointCount = itemCnt;
        }

        public override void loadData()
        {
            if (isLoading) return;
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            List<S_CandleItemData> sourceDatas1 = null;
            List<S_CandleItemData> sourceDatas2 = null;
            List<S_CandleItemData> sourceDatas3 = null;
            List<S_CandleItemData> sourceDatas4 = null;

            isLoading = true;
            string selectedType = this.SelectedType;
            if (string.IsNullOrEmpty(selectedType))
                selectedType = SharedData.SelectedType;

            if (selectedType == "국내지수")
            {
                this.timeInterval = TimeIntervalEnum.Minute_05;
                sourceDatas1 = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "5", "500");
                sourceDatas2 = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "10", "300");
                sourceDatas3 = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "30", "100");
                sourceDatas4 = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "50");

            }
            else if (selectedType == "국내종목")
            {
                this.timeInterval = TimeIntervalEnum.Minute_05;
                sourceDatas1 = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "5", "500");
                sourceDatas2 = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "10", "300");
                sourceDatas3 = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "30", "100");
                sourceDatas4 = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "2", "0", "50");
            }

            else if (selectedType == "해외선물")
            {
                this.timeInterval = TimeIntervalEnum.Minute_05;
                sourceDatas1 = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "5M");
                sourceDatas2 = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "30M");
                sourceDatas3 = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "H");
                sourceDatas4 = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "D");
            }
            else
                return;

            isLoading = false;

            if (sourceDatas1 == null || sourceDatas1.Count == 0) return;

            int averageCount = 9;

            var averageDatas1 = PPUtils.GetAverageDatas(itemCode, sourceDatas1, averageCount, false);
            var averageDatas2 = PPUtils.GetAverageDatas(itemCode, sourceDatas2, averageCount, false);
            var averageDatas3 = PPUtils.GetAverageDatas(itemCode, sourceDatas3, averageCount, false);
            var averageDatas4 = PPUtils.GetAverageDatas(itemCode, sourceDatas4, averageCount, false);

            chart1.LoadDataAndApply(itemCode, averageDatas1, averageDatas2, averageDatas3, averageDatas4, base.timeInterval, averageCount);

        }
    }
}
