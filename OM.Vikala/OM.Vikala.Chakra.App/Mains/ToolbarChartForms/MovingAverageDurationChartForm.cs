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
            if (base.SelectedItemData == null) return;
            if (string.IsNullOrEmpty(base.SelectedItemData.Code)) return;

            string itemCode = base.SelectedItemData.Code;

            var sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  itemCode
                , base.timeInterval);
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
