﻿using OM.Lib.Base.Enums;
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
    public partial class ChakraSingleChartForm : BaseForm
    {
        public ChakraSingleChartForm()
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
            
            var averageDatas = PPUtils.GetAverageDatas(itemCode, sourceDatas, 9);
            sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
            chart.LoadDataAndApply(itemCode, sourceDatas, base.timeInterval, 9);
        }
    }
}
