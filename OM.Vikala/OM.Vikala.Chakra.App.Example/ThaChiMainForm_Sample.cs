﻿using MetroFramework.Forms;
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
    public partial class ThaChiMainForm_Sample : Form
    {
        ChartEvents chartEvent = new ChartEvents();

        public ThaChiMainForm_Sample()
        {
            InitializeComponent();

            chartAT1.InitializeControl();
            chartAT1.InitializeEvent(chartEvent);
            chartAT1.DisplayPointCount = 30;

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
                , 300);

            int round = ItemCodeUtil.GetItemCodeRoundNum(itemCode);

            List<S_CandleItemData> sourceDatas = new List<S_CandleItemData>();

            List<T_ThaChiItemData> transformedDatas = new List<T_ThaChiItemData>();

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

            int itemsCnt = 7;

            for (int i = itemsCnt; i < sourceDatas.Count; i++)
            {
                T_ThaChiItemData transData = new T_ThaChiItemData(sourceDatas[i], sourceDatas.GetRange(i - itemsCnt, itemsCnt));
                transData.Transform();
                transformedDatas.Add(transData);
            }

            chartAT1.LoadData(itemCode, transformedDatas);
        }
    }
}
