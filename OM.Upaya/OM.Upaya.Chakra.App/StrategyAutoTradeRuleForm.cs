using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.Lib.Framework.Db;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Controls.Charts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Upaya.Chakra.App
{
    public partial class StrategyAutoTradeRuleForm : Form
    {
        StrategyAutoTradeRule rule = new StrategyAutoTradeRule();
        ConcurrentQueue<CurrentPrice> currentPrices = new ConcurrentQueue<CurrentPrice>();
        bool isRun = true;
        bool isStart = false;

        public bool IsAutoLosscutCal = true;
        public bool IsAutoRevenueCal = true;

        public StrategyAutoTradeRuleForm()
        {
            InitializeComponent();
            this.Load += TradeRuleForm_Load;
            this.FormClosing += StrategyTradeRuleForm_FormClosing;
            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;
            rule.StrategyTradeRuleEventHandler += Rule_TradeRuleEventHandler;

            System.Threading.Thread tCL = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            tCL.Start();
        }

        private void Rule_TradeRuleEventHandler(string type, string desc)
        {
            tbLog.Invoke(new MethodInvoker(() =>
            {
                tbLog.AppendText(type + "=>" + desc);
                tbLog.AppendText(Environment.NewLine);

                if (type == "진입")
                {
                    btnForceOrder.Enabled = true;
                    lblBuyPosition.Text = desc.Substring(0, 2);
                    tbBuyPrice.Text = desc.Replace("매수", "").Replace("매도", "").Replace("진입::현재가", "");

                    if (lblBuyPosition.Text == "매수")
                    {
                        lblBuyPosition.ForeColor = tbBuyPrice.ForeColor = Color.Red;
                    }
                    if (lblBuyPosition.Text == "매도")
                    {
                        lblBuyPosition.ForeColor = tbBuyPrice.ForeColor = Color.Blue;
                    }
                }
            }));
        }

        private void Run()
        {
            while (isRun)
            {
                try
                {
                    var priceQueue = currentPrices;
                    if (priceQueue.Count == 0)
                    {
                        System.Threading.Thread.Sleep(10);
                        continue;
                    }
                    CurrentPrice price;
                    var isDequeue = priceQueue.TryDequeue(out price);
                    if (isDequeue && isStart)
                    {
                        rule.Analysis(price);

                        displayCurrentPrice(price);

                        chartChakra.SummaryPrice(Convert.ToDouble(price.price));

                        chartReal.SummaryPrice(Convert.ToDouble(price.price));

                        if (rule.BuyPrice > 0 && rule.IsBuyed)
                        {
                            calculateLosscutTick(price.price);
                            calculateRevenueTick(price.price);
                            calculateRevenueLosscutTick(price.price);
                        }
                    }
                }
                catch (Exception ex) { string err = ex.Message; }
            }
        }
        private void TradeRuleForm_Load(object sender, EventArgs e)
        {
            rule.ItemCode = tbItem.Text;
            rule.IsUse = true;
            rule.IsUseLosscut = true;
            cbPriceType.SelectedIndex = Convert.ToInt32(rule.PriceType);
            cbxTime.SelectedIndex = 1;
            cbBaseCandleType.SelectedIndex = 0;
            cbStrategy.SelectedIndex = 0;
            tbTime.Text = "60";

            chart1.CurrentChartArea.InnerPlotPosition.Width = 85F;
        }
        private void StrategyTradeRuleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = false;
            SiseEvents.Instance.SiseHandler -= Instance_SiseHandler;
            rule.Close();
        }

        private void Instance_SiseHandler(string itemCode, CurrentPrice price)
        {
            try
            {
                if (rule.ItemCode != itemCode) return;
                if (! isStart) return;

                currentPrices.Enqueue(price);

                //rule.Analysis(price);
            }
            catch (Exception ex)
            {
                tbLog.Invoke(new MethodInvoker(() =>
                {
                    tbLog.AppendText(itemCode + "=>" + ex.Message);
                    tbLog.AppendText(Environment.NewLine);
                }));
            }
        }
        private void displayCurrentPrice(CurrentPrice price)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                tbCPrice.Text = $"{price.price} | {price.price3} | {price.price5} | {price.price7}";
            }));
        }
        private void calculateLosscutTick(string price)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (IsAutoLosscutCal)                       
                            tbLosscutPrice.Text = Cals.LosscutCalculater.Calculator(rule);

                    if (rule.LosscutPrice > 0)
                    {
                        double p = Convert.ToDouble(price);
                        int tick = PriceTick.GetTickDiff(rule.ItemCode, rule.LosscutPrice, p);
                        tbLosscutPriceTick.Text = tick.ToString();
                    }
                }
                catch (Exception) { }
            }));
        }
        private void calculateRevenueLosscutTick(string price)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (rule.RevenuePrice > 0)
                    {
                        double p = Convert.ToDouble(price);
                        int tick = PriceTick.GetTickDiff(rule.ItemCode, rule.BuyPrice, p);
                        if (rule.Position == "1" && rule.BuyPrice > p)
                        {
                            lblRevenueTick.Text = "+" + tick.ToString();
                            lblRevenueTick.ForeColor = Color.Red;
                        }
                        else if (rule.Position == "2" && rule.BuyPrice < p)
                        {
                            lblRevenueTick.Text = "+" + tick.ToString();
                            lblRevenueTick.ForeColor = Color.Red;
                        }
                        else
                        {
                            lblRevenueTick.Text = "-" + tick.ToString();
                            lblRevenueTick.ForeColor = Color.Blue;
                        }
                    }
                }
                catch (Exception) { }
            }));
        }
        private void calculateRevenueTick(string price)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    if (IsAutoRevenueCal)
                        tbRevenuePrice.Text = Cals.RevenueCalculater.Calculator(rule);

                    if (rule.RevenuePrice > 0)
                    {
                        double p = Convert.ToDouble(price);
                        int tick = PriceTick.GetTickDiff(rule.ItemCode, rule.RevenuePrice, p);
                        tbRevenuePriceTick.Text = tick.ToString();
                    }
                }
                catch (Exception) { }
            }));
        }
        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            rule.ItemCode = tbItem.Text;
        }
        private void rdoSType1_CheckedChanged(object sender, EventArgs e)
        {
            //this.Text = "단기 전략투자 시나리오";
            rule.StrategyType = "1";
            tbTime.Text = "60";
        }
        private void rdoSType2_CheckedChanged(object sender, EventArgs e)
        {
            //this.Text = "중기 전략투자 시나리오";
            rule.StrategyType = "2";
            tbTime.Text = "120";
        }
        private void rdoSType3_CheckedChanged(object sender, EventArgs e)
        {
            //this.Text = "장기 전략투자 시나리오";
            rule.StrategyType = "3";
            tbTime.Text = "240";
        }

        private void cbPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.PriceType = cbPriceType.SelectedIndex.ToString();
        }

        private void TbTime_TextChanged(object sender, EventArgs e)
        {
            if (tbTime.Text.Length == 0) return;
            int ts = Convert.ToInt32(tbTime.Text);
            rule.ValidTimeSpan = TimeSpan.FromMinutes(ts);
        }
        private void chkIsUse_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUse = chkIsUse.Checked;
        }
        private void CbStrategy_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.StrategyDirection = (cbStrategy.SelectedIndex + 1).ToString();
        }
        private void CbBaseCandleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.BaseCandleItemType = (cbBaseCandleType.SelectedIndex + 1).ToString();
        }
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (tbQty.Text.Length == 0) return;
            rule.Quantity = Convert.ToInt32(tbQty.Text);
        }
        private void tbBuyPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice.Text.Length == 0) return;
            rule.BuyPrice = Convert.ToDouble(tbBuyPrice.Text);
        }

        private void tbLosscutPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbLosscutPrice.Text.Length == 0) return;
            rule.LosscutPrice = Convert.ToDouble(tbLosscutPrice.Text);
        }
        private void tbRevenuePrice_TextChanged(object sender, EventArgs e)
        {
            if (tbRevenuePrice.Text.Length == 0) return;
            rule.RevenuePrice = Convert.ToDouble(tbRevenuePrice.Text);
        }
        private void chkIsUseLosscut_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseLosscut = chkIsUseLosscut.Checked;
            if (rule.IsUseLosscut) rule.IsLosscuted = false;
        }
        private void chkIsUseRevenue_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseRevenue = chkIsUseRevenue.Checked;
            if (rule.IsUseRevenue) rule.IsRevenued = false;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            string txt = btnStartStop.Text;
            if (txt == "Start")
            {
                isStart = true;
                btnStartStop.Text = "Stop";
                timer1.Enabled = isStart;
                timer1.Start();
            }
            else if (txt == "Stop")
            {
                isStart = false;
                btnStartStop.Text = "Start";
                timer1.Enabled = isStart;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (isStart)
            {
                if (rule.ValidTimeSpan.TotalSeconds > 0)
                {
                    TimeSpan t2 = TimeSpan.FromSeconds(1);
                    rule.ValidTimeSpan = rule.ValidTimeSpan.Subtract(t2);
                    lbRemainTime.Text = $"{rule.ValidTimeSpan.Hours.ToString("00")}:{rule.ValidTimeSpan.Minutes.ToString("00")}:{rule.ValidTimeSpan.Seconds.ToString("00")}";

                    if (rule.ValidTimeSpan.TotalMinutes == 0)
                    {
                        if (!rule.IsBuyed)
                        {
                            isStart = false;
                            chkIsUse.Checked = false;
                            rule.IsUse = false;
                            timer1.Enabled = false;
                        }
                    }
                }
            }
        }
        private void BtnLoadCandle_Click(object sender, EventArgs e)
        {
            try
            {
                int loadCnt = 5;
                if (chkIsUseLastCandle.Checked) loadCnt = 6;

                TimeIntervalEnum timeInterval = TimeIntervalEnum.Minute_05;
                if (cbxTime.SelectedIndex == 1) timeInterval = TimeIntervalEnum.Minute_10;
                else if (cbxTime.SelectedIndex == 2) timeInterval = TimeIntervalEnum.Minute_30;
                else if (cbxTime.SelectedIndex == 3) timeInterval = TimeIntervalEnum.Hour_01;
                else if (cbxTime.SelectedIndex == 4) timeInterval = TimeIntervalEnum.Hour_02;

                var list = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(rule.ItemCode, timeInterval);
                var avglist = PPUtils.GetAverageDatas(rule.ItemCode, list, 5);
                var displayList = list.GetRange(list.Count - 10, 10);
                chart1.IsAutoScrollX = false;
                chart1.LoadDataAndApply(rule.ItemCode, displayList, timeInterval, 0);

                //챠크라
                if (rule.BaseCandleItemType == "1") 
                {
                    var newList = list.GetRange(list.Count - 6, loadCnt);
                    var newItem = PP.Chakra.PPUtils.GetMergeCandle(newList);
                    var newList2 = new List<PP.Chakra.S_CandleItemData>();
                    newList2.Add(newItem);
                    rule.BaseCandleItem = newItem;
                    chartChakra.IsAutoScrollX = false;
                    chartChakra.LoadDataAndApply(rule.ItemCode, newList2, timeInterval, 0);
                }
                //양자평균
                else if (rule.BaseCandleItemType == "2")
                {
                    var newList = avglist.GetRange(avglist.Count - 6, loadCnt);
                    var newItem = PP.Chakra.PPUtils.GetMergeCandle(newList);
                    var newList2 = new List<PP.Chakra.S_CandleItemData>();
                    newList2.Add(newItem);
                    rule.BaseCandleItem = newItem;
                    chartChakra.IsAutoScrollX = false;
                    chartChakra.loadDataAndApply(rule.ItemCode, newList2, timeInterval, 0);
                }
                //다이아몬드
                else if (rule.BaseCandleItemType == "3")
                {
                    var newList = list.GetRange(list.Count - 6, loadCnt);
                    var newItem = PP.Chakra.PPUtils.GetMergeDiamondCandle(newList);
                    var newList2 = new List<PP.Chakra.S_CandleItemData>();
                    var sCandle = newItem.GetCandleItem();
                    newList2.Add(sCandle);
                    rule.BaseCandleItem = sCandle;
                    chartChakra.IsAutoScrollX = false;
                    chartChakra.loadDataAndApply(rule.ItemCode, newList2, timeInterval, 0);
                }

                chartReal.LoadDataAndApply(rule.ItemCode, list, timeInterval, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RdoPositionType0_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPositionType0.Checked) rule.PositionType = "12";
        }

        private void RdoPositionType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPositionType2.Checked) rule.PositionType = "2";
        }

        private void RdoPositionType1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPositionType1.Checked) rule.PositionType = "1";
        }

        private void ChkIsAutoLosscutCal_CheckedChanged(object sender, EventArgs e)
        {
            IsAutoLosscutCal = chkIsAutoLosscutCal.Checked;
        }

        private void ChkIsAutoRevenueCal_CheckedChanged(object sender, EventArgs e)
        {
            IsAutoRevenueCal = chkIsAutoRevenueCal.Checked;
        }

        private void BtnForceOrder_Click(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show("강제청산 주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            rule.ForceSell();
            btnForceOrder.Enabled = false;
        }

        private void BtnOrder1_Click(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show("매도진입 주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            rule.SellBuy("진입", "1");

            rule.onStrategyTradeRuleHandler("진입", $"매도진입::현재가{rule.CPrice}");
        }

        private void BtnOrder2_Click(object sender, EventArgs e)
        {
            using (new CenterWinDialog(this))
            {
                if (MessageBox.Show("매수진입 주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            rule.SellBuy("진입", "2");
            
            rule.onStrategyTradeRuleHandler("진입", $"매수진입::현재가{rule.CPrice}");
        }
    }
}
