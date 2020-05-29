using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
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
    public partial class FiveColorChartForm : BaseForm
    {
        public FiveColorChartForm()
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
        }

        public override void loadChartControls()
        {
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;

            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;
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

            int totalCnt = sourceDatas.Count;
            if (totalCnt > Config.SharedData.SelectedItemCount)
                sourceDatas.RemoveRange(0, totalCnt - Config.SharedData.SelectedItemCount);

            chart.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 10);
            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 7);
            chart2.LoadDataAndApply(itemCode, averageDatas, base.timeInterval, 10);
        }
    }
}
