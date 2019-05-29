using OM.Lib.Base.Enums;
using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.Lib.Framework.Db;
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

namespace OM.Atman.Chakra.App
{
    public partial class StrategyTradeRuleForm : Form
    {
        StrategyTradeRule rule = new StrategyTradeRule();
        ConcurrentQueue<CurrentPrice> currentPrices = new ConcurrentQueue<CurrentPrice>();
        bool isRun = true;
        bool isStart = false;
        public bool IsAutoLosscutCal = true;
        public bool IsAutoRevenueCal = true;
        public StrategyTradeRuleForm()
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

                        if (IsAutoLosscutCal) calculateLosscutTick(price.price);
                        if (IsAutoRevenueCal) calculateRevenueTick(price.price);
                    }
                }
                catch (Exception ex) { }
            }
        }
        private void TradeRuleForm_Load(object sender, EventArgs e)
        {
            rule.ItemCode = tbItem.Text;
            cbBasePattern.SelectedIndex = (int)rule.BasePattern;          
            cbPriceType.SelectedIndex = Convert.ToInt32(rule.PriceType);
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
                if (!rule.IsUse) return;

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
        private void calculateRevenueTick(string price)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
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
            this.Text = "단기 전략투자 시나리오";
            rule.StrategyType = "1";
        }
        private void rdoSType2_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "중기 전략투자 시나리오";
            rule.StrategyType = "2";
        }
        private void rdoSType3_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = "장기 전략투자 시나리오";
            rule.StrategyType = "3";
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
        private void tbBasePrice_TextChanged(object sender, EventArgs e)
        {
            if (tbBasePrice.Text.Length == 0) return;
            rule.BasePrice = Convert.ToDouble(tbBasePrice.Text);
        }
        private void cbBasePattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.BasePattern = (PricePatternEnum)cbBasePattern.SelectedIndex;
        }
        private void rdoPosition1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPosition1.Checked) rule.Position = "1";
        }
        private void rdoPosition2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPosition2.Checked) rule.Position = "2";
        }
        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (tbQty.Text.Length == 0) return;
            rule.Quantity = Convert.ToInt32(tbQty.Text);
        }
        private void tbBuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice1.Text.Length == 0) return;
            rule.BuyPrice1 = Convert.ToDouble(tbBuyPrice1.Text);           
        }
        private void tbBuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice2.Text.Length == 0) return;
            rule.BuyPrice2 = Convert.ToDouble(tbBuyPrice2.Text);            
        }
        private void tbBuyPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice.Text.Length == 0) return;
            rule.BuyPrice = Convert.ToDouble(tbBuyPrice.Text);            
        }
        private void calculateBuyPrice()
        {
            try
            {
                if (rule.BuyPrice1 > 0 && rule.BuyPrice2 > 0)
                {
                    tbBuyPrice.Text = Math.Round((rule.BuyPrice1 + rule.BuyPrice2) / 2.0, rule.RoundNum).ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        private void chkIsUseBuy_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseBuy = chkIsUseBuy.Checked;
        }
        private void ChkIsBuyed_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsBuyed = chkIsBuyed.Checked;
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
                            timer1.Enabled = false;
                        }
                    }
                }
            }
        }
    }
}
