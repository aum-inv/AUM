using MetroFramework.Forms;
using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Controls.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App
{
    public partial class PrimeNumMainForm_Sample : Form
    {
        ChartEvents chartEvent = new ChartEvents();
        ChartEvents chartEvent2 = new ChartEvents();
        public PrimeNumMainForm_Sample()
        {
            InitializeComponent();

            chartCS1.InitializeControl();
            chartCS1.InitializeEvent(chartEvent);
            chartCS1.CandleChartType = CandleChartTypeEnum.기본;
            chartCS1.DisplayPointCount = 30;

            chartWX1.InitializeControl();
            chartWX1.InitializeEvent(chartEvent2);
            chartWX1.DisplayPointCount = 30;

            tbDT_E.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string itemCode = ItemCodeSet.GetItemCode(ItemCode.지수_국내_코스피200);

            var list = PPContext.Instance.ClientContext.GetSourceData(
                  itemCode
                , Lib.Base.Enums.TimeIntervalEnum.Day
                , null
                , tbDT_E.Text
                , 120);
            
            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            List<S_CandleItemData> sourceDatas = new List<S_CandleItemData>();
            List<T_PrimeNumItemData> transformedDatas = new List<T_PrimeNumItemData>();

            foreach (var m in list)
            {
                S_CandleItemData sourceData = new S_CandleItemData(
                      itemCode
                    , (Single)Math.Round(m.OpenVal, round)
                    , (Single)Math.Round(m.HighVal, round)
                    , (Single)Math.Round(m.LowVal, round)
                    , (Single)Math.Round(m.CloseVal, round)
                    , m.Volume
                    , m.DT
                    );

                sourceDatas.Add(sourceData);
            }
            chartCS1.LoadData(itemCode, sourceDatas);
            DateTime? dtime = null;
            foreach (var m in sourceDatas.OrderByDescending(t => t.DTime))
            {
                if (dtime != null && dtime.Value <= m.DTime) continue;

                T_PrimeNumItemData tData = new T_PrimeNumItemData(m, sourceDatas);
                tData.Transform();
                transformedDatas.Add(tData);

                dtime = tData.DTimeS;
            }
            chartWX1.LoadData(itemCode, transformedDatas.OrderBy(t => t.DTime).ToList());
        }
    }
}
