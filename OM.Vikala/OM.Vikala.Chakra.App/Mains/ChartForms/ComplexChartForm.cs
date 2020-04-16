using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Chakra;
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
    public partial class ComplexChartForm : BaseForm
    {
        public ComplexChartForm()
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
            //chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;

            chart2.InitializeControl();
            //chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;

            chart.IsShowLine = true;
            chart2.IsShowLine = true;
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

            //chart.DisplayPointCount = 120;
            //chart2.DisplayPointCount = 120;
            if (base.timeInterval == TimeIntervalEnum.Day)
            {
                var sourceDatasSub1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_720);
                var sourceDatasSub2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_480);
                chart.DisplaySubItemCount = 2;
                chart.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, base.timeInterval);
                chart2.DisplaySubItemCount = 4;
                chart2.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub2, base.timeInterval);
            }
            else if (base.timeInterval == TimeIntervalEnum.Minute_720)
            {
                var sourceDatasSub1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_360);
                var sourceDatasSub2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_180);
                chart.DisplaySubItemCount = 2;
                chart.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, base.timeInterval);
                chart2.DisplaySubItemCount = 4;
                chart2.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub2, base.timeInterval);
            }
            else if (base.timeInterval == TimeIntervalEnum.Minute_480)
            {
                var sourceDatasSub1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_240);
                var sourceDatasSub2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_120);
                chart.DisplaySubItemCount = 2;
                chart.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, base.timeInterval);
                chart2.DisplaySubItemCount = 4;
                chart2.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub2, base.timeInterval);
            }
            else if (base.timeInterval == TimeIntervalEnum.Minute_240)
            {
                var sourceDatasSub1 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_120);
                var sourceDatasSub2 = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(itemCode, TimeIntervalEnum.Minute_60);
                chart.DisplaySubItemCount = 2;
                chart.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub1, base.timeInterval);
                chart2.DisplaySubItemCount = 4;
                chart2.LoadDataAndApply(itemCode, sourceDatas, sourceDatasSub2, base.timeInterval);
            }
        }
    }
}
