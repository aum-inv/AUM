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
    public partial class RemoveFirstPriceChartForm : BaseForm
    {
        public bool IsUseAverageData
        {
            get;
            set;
        } = false;
        public bool IsUseDetailCal
        {
            get;
            set;
        } = false;

        public RemoveFirstPriceChartForm()
        {
            InitializeComponent();
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        public RemoveFirstPriceChartForm(bool isUseAverage = false, bool isUseDetailCal = false)
        {
            InitializeComponent();

            this.IsUseAverageData = isUseAverage;
            this.IsUseDetailCal = isUseDetailCal;
            base.setToolStrip(userToolStrip1);
            InitializeControls();
        }
        private void InitializeControls()
        {           
            loadChartControls();
            setTimer();
            userToolStrip.IsVisibleAlignmentButton = false;
            userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent; userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            chart.BoldLine(sender.ToString());
            chart2.BoldLine(sender.ToString());
            chart3.BoldLine(sender.ToString());
        }
        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {
            if (sender.ToString() == "1")
            {
                tableLayoutPanel1.RowStyles[0].Height = 50f;
                tableLayoutPanel1.RowStyles[1].Height = 50f;
                tableLayoutPanel1.RowStyles[2].Height = 0f;
            }
            if (sender.ToString() == "2")
            {
                tableLayoutPanel1.RowStyles[0].Height = 50f;
                tableLayoutPanel1.RowStyles[1].Height = 0f;
                tableLayoutPanel1.RowStyles[2].Height = 50f;
            }
            if (sender.ToString() == "3")
            {
                tableLayoutPanel1.RowStyles[0].Height = 33.33333f;
                tableLayoutPanel1.RowStyles[1].Height = 33.33333f;
                tableLayoutPanel1.RowStyles[2].Height = 33.33333f;
            }
        }
        public override void loadChartControls()
        {
            chart.InitializeControl();
            chart.InitializeEvent(chartEvent);
            chart.DisplayPointCount = itemCnt;
            
            chart2.InitializeControl();
            chart2.InitializeEvent(chartEvent);
            chart2.DisplayPointCount = itemCnt;
          
            chart3.InitializeControl();
            chart3.InitializeEvent(chartEvent);
            chart3.DisplayPointCount = itemCnt;           
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
            RemoveSourceData(sourceDatas);
            //국내지수인 경우 시간갭이 크기 때문에.. 전일종가를 당일시가로 해야한다. 
            //SetChangeOpenPrice(itemCode, sourceDatas);                        
           
            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
            //var averageDatas = PPUtils.GetBalancedAverageDatas(itemCode, sourceDatas, 9);
            //var averageDatas = PPUtils.GetAccumulatedAverageDatas(itemCode, sourceDatas, 9);
            List<S_CandleItemData> rcSDatas1, rcSDatas2;

            if (IsUseDetailCal)
            {
                if (IsUseAverageData)
                {
                    rcSDatas1 = PPUtils.GetRecreateSecondDatas2(itemCode, averageDatas, 5, false);
                    rcSDatas2 = PPUtils.GetRecreateSecondDatas2(itemCode, averageDatas, 5, true);
                }
                else
                {
                    rcSDatas1 = PPUtils.GetRecreateSecondDatas2(itemCode, sourceDatas, 5, false);
                    rcSDatas2 = PPUtils.GetRecreateSecondDatas2(itemCode, sourceDatas, 5, true);
                }
            }
            else
            {
                if (IsUseAverageData)
                {
                    rcSDatas1 = PPUtils.GetRecreateSecondDatas(itemCode, averageDatas, 5, false);
                    rcSDatas2 = PPUtils.GetRecreateSecondDatas(itemCode, averageDatas, 5, true);
                }
                else
                {
                    rcSDatas1 = PPUtils.GetRecreateSecondDatas(itemCode, sourceDatas, 5, false);
                    rcSDatas2 = PPUtils.GetRecreateSecondDatas(itemCode, sourceDatas, 5, true);
                }
            }

            sourceDatas = PPUtils.GetCutDatas(sourceDatas, rcSDatas1[0].DTime);

            chart.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 9);
            chart2.LoadDataAndApply(itemCode, rcSDatas1, base.timeInterval, 9);
            chart3.LoadDataAndApply(itemCode, rcSDatas2, base.timeInterval, 9);

            //chart2.SetDataPointColor(Color.Black, Color.Black, Color.Black);
            //chart3.SetDataPointColor(Color.Black, Color.Black, Color.Black);
        }
    }
}
