using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.Lib.Framework.Db;
using System;
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
    public partial class AtomRuleForm : Form
    {
        List<AtomTradeRule> ruleList = new List<AtomTradeRule>();

        public AtomRuleForm()
        {
            InitializeComponent();
            this.FormClosing += AtomRuleForm_FormClosing;
            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;
            TradeEvents.Instance.TradeRuleHandler += Instance_TradeRuleHandler;
        }

        private void AtomRuleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var rule in ruleList)
            {
                rule.Close();
            }
            SiseEvents.Instance.SiseHandler -= Instance_SiseHandler;
            TradeEvents.Instance.TradeRuleHandler -= Instance_TradeRuleHandler;
        }

        private void Instance_TradeRuleHandler(string atmanName, string itemCode, string message)
        {
            if (atmanName != "ATOM") return;
            tbLog.Invoke(new MethodInvoker(() =>
               {
                   tbLog.AppendText(itemCode + "=>" + message);
                   tbLog.AppendText(Environment.NewLine);
               }));
        }
        private void Instance_SiseHandler(string itemCode, CurrentPrice price)
        {
            try
            {
                foreach (var rule in ruleList)
                {
                    if (rule.RuleInfo.IsUse == "N") continue;
                    if (rule.RuleInfo.Item != itemCode) continue;

                    rule.Analysis(price);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AtmanRule rule = new AtmanRule();
                rule.RuleID = tbRuleID.Text;
                rule.Item = tbItem.Text;
                rule.TimeType = tbTimeType.Text;
                rule.PriceType = cbPriceType.SelectedIndex.ToString();
                rule.ForcastOfStrength = tbStrength.Text;
                rule.Position = tbPosition.Text;
                rule.BasePrice = tbBasePrice.Text;
                rule.BuyPrice = tbBuyPrice.Text;
                rule.BuyTick = tbBuyTick.Text;
                rule.BuyRate = tbBuyRate.Text;
                rule.BuyLimitTime = Convert.ToInt32(tbBuyLimitTime.Text);
                rule.LossPrice = tbLossPrice.Text;
                rule.LossTick = tbLossTick.Text;
                rule.LossRate = tbLossRate.Text;
                rule.RevenuePrice = tbRevenuePrice.Text;
                rule.RevenueTick = tbRevenueTick.Text;
                rule.RevenueRate = tbRevenueRate.Text;
                rule.RevenueLimitTime = Convert.ToInt32(tbRevenueLimitTime.Text);
                rule.IsUse = "N";

                rule.Update();
            }
            catch (Exception ex)
            { }
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            var rule = btnModify.Tag as AtmanRule;
            rule.TimeType = tbTimeType.Text;
            rule.PriceType = cbPriceType.SelectedIndex.ToString();
            rule.ForcastOfStrength = tbStrength.Text;
            rule.Position = tbTimeType.Text;
            rule.BasePrice = tbBasePrice.Text;
            rule.BuyPrice = tbBuyPrice.Text;
            rule.BuyTick = tbBuyTick.Text;
            rule.BuyRate = tbBuyRate.Text;
            rule.BuyLimitTime = Convert.ToInt32(tbBuyLimitTime.Text);
            rule.LossPrice = tbLossPrice.Text;
            rule.LossTick = tbLossTick.Text;
            rule.LossRate = tbLossRate.Text;
            rule.RevenuePrice = tbRevenuePrice.Text;
            rule.RevenueTick = tbRevenueTick.Text;
            rule.RevenueRate = tbRevenueRate.Text;
            rule.RevenueLimitTime = Convert.ToInt32(tbRevenueLimitTime.Text);
            
            AtmanRule ruleNew = new AtmanRule();
            ruleNew.RuleID = tbRuleID.Text;
            ruleNew.Item = tbItem.Text;
            ruleNew.PriceType = cbPriceType.SelectedIndex.ToString();
            ruleNew.TimeType = tbTimeType.Text;
            ruleNew.ForcastOfStrength = tbStrength.Text;
            ruleNew.Position = tbTimeType.Text;
            ruleNew.BasePrice = tbBasePrice.Text;
            ruleNew.BuyPrice = tbBuyPrice.Text;
            ruleNew.BuyTick = tbBuyTick.Text;
            ruleNew.BuyRate = tbBuyRate.Text;
            ruleNew.BuyLimitTime = Convert.ToInt32(tbBuyLimitTime.Text);
            ruleNew.LossPrice = tbLossPrice.Text;
            ruleNew.LossTick = tbLossTick.Text;
            ruleNew.LossRate = tbLossRate.Text;
            ruleNew.RevenuePrice = tbRevenuePrice.Text;
            ruleNew.RevenueTick = tbRevenueTick.Text;
            ruleNew.RevenueRate = tbRevenueRate.Text;
            ruleNew.RevenueLimitTime = Convert.ToInt32(tbRevenueLimitTime.Text);
            ruleNew.IsUse = "N";

            ruleNew.Update();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            AtmanRule rule = new AtmanRule();
            Entities entities = (Entities)rule.Collect();

            dgv.Rows.Clear();

            ruleList.Clear();

            foreach (var item in entities.Cast<AtmanRule>())
            {
                if (item.RuleID.StartsWith("Atom"))
                {
                    int idx = dgv.Rows.Add(item.RuleID, item.Item, item.TimeType, item.ForcastOfStrength, item.Position, item.BasePrice, item.IsUse == "Y", item.IsBuyDone);
                    dgv.Rows[idx].Tag = item;

                    ruleList.Add(new AtomTradeRule(item));
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            
            if (e.ColumnIndex == 0)
            {
                var rule = dgv.Rows[e.RowIndex].Tag as AtmanRule;
                tbRuleID.Text = rule.RuleID;
                tbItem.Text = rule.Item;
                cbPriceType.SelectedIndex = Convert.ToInt32(rule.PriceType);
                tbTimeType.Text = rule.TimeType ;
                tbStrength.Text = rule.ForcastOfStrength;
                tbPosition.Text = rule.Position;
                tbBasePrice.Text = rule.BasePrice;
                tbBuyPrice.Text = rule.BuyPrice;
                tbBuyTick.Text = rule.BuyTick;
                tbBuyRate.Text = rule.BuyRate;
                tbBuyLimitTime.Text = rule.BuyLimitTime.ToString();
                tbLossPrice.Text = rule.LossPrice;
                tbLossTick.Text = rule.LossTick;
                tbLossRate.Text = rule.LossRate;
                tbRevenuePrice.Text = rule.RevenuePrice;
                tbRevenueTick.Text = rule.RevenueTick;
                tbRevenueRate.Text = rule.RevenueRate;
                tbRevenueLimitTime.Text = rule.RevenueLimitTime.ToString();

                btnModify.Tag = rule;
                btnTest.Tag = rule;
            }
            else if (e.ColumnIndex == 6)
            {
                dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var rule = dgv.Rows[e.RowIndex].Tag as AtmanRule;
            if (e.ColumnIndex == 6)
            {
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    rule.IsUse = "Y";
                }
                else
                {
                    rule.IsUse = "N";
                }
            }
            if (e.ColumnIndex == 7)
            {
                if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "True")
                {
                    rule.IsBuyDone = true;
                }
                else
                {
                    rule.IsBuyDone = false;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            var rule = btnTest.Tag as AtmanRule;

            AtomTradeRule trade = new AtomTradeRule(rule);

            //터치
            trade.Analysis(new CurrentPrice() { price = "45" });
            //trade.Analysis("CL", new CurrentPrice() { price = "46" });
            //trade.Analysis("CL", new CurrentPrice() { price = "47" });

            //매입
            //trade.Analysis("CL", new CurrentPrice() { price = "46" });
            //trade.Analysis("CL", new CurrentPrice() { price = "45" });

            //로스컷
            //trade.Analysis("CL", new CurrentPrice() { high = "50", low = "40", price = "44" });
            //trade.Analysis("CL", new CurrentPrice() { high = "50", low = "40", price = "43" });
            //trade.Analysis("CL", new CurrentPrice() { high = "50", low = "40", price = "42" });

            //수익
            //trade.Analysis("CL", new CurrentPrice() { price = "58" });
            //trade.Analysis("CL", new CurrentPrice() { price = "59" });
            //trade.Analysis("CL", new CurrentPrice() { price = "60" });
            
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double buyRate = Convert.ToDouble(tbBuyRate.Text);
            double revenueRate = Convert.ToDouble(tbRevenueRate.Text);
            double lossRate = Convert.ToDouble(tbLossRate.Text);

            string itemCode = tbItem.Text;
            string position = tbTimeType.Text;
            double basePrice = Convert.ToDouble(tbBasePrice.Text);

            double baseRevenueRate = 1.0;
            
            if (position == "매수")
            {
                tbBuyPrice.Text = PriceTick.GetDownPriceOfRate(itemCode, basePrice, buyRate).ToString();
                tbBuyTick.Text = PriceTick.GetTickDiff(itemCode, basePrice, Convert.ToDouble(tbBuyPrice.Text)).ToString();

                double hPrice = PriceTick.GetUpPriceOfRate(itemCode, basePrice, baseRevenueRate);
                tbRevenuePrice.Text = PriceTick.GetDownPriceOfRate(itemCode, hPrice, revenueRate).ToString();
                tbRevenueTick.Text = PriceTick.GetTickDiff(itemCode, hPrice, Convert.ToDouble(tbRevenuePrice.Text)).ToString();

                tbLossPrice.Text = PriceTick.GetDownPriceOfRate(itemCode, basePrice, lossRate).ToString();
                tbLossTick.Text = PriceTick.GetTickDiff(itemCode, basePrice, Convert.ToDouble(tbLossPrice.Text)).ToString();
            }
            if (position == "매도")
            {
                tbBuyPrice.Text = PriceTick.GetUpPriceOfRate(itemCode, basePrice, buyRate).ToString();
                tbBuyTick.Text = PriceTick.GetTickDiff(itemCode, basePrice, Convert.ToDouble(tbBuyPrice.Text)).ToString();

                double lPrice = PriceTick.GetDownPriceOfRate(itemCode, basePrice, baseRevenueRate);
                tbRevenuePrice.Text = PriceTick.GetUpPriceOfRate(itemCode, lPrice, revenueRate).ToString();
                tbRevenueTick.Text = PriceTick.GetTickDiff(itemCode, lPrice, Convert.ToDouble(tbRevenuePrice.Text)).ToString();

                tbLossPrice.Text = PriceTick.GetUpPriceOfRate(itemCode, basePrice, lossRate).ToString();
                tbLossTick.Text = PriceTick.GetTickDiff(itemCode, basePrice, Convert.ToDouble(tbLossPrice.Text)).ToString();
            }
        }
    }
}
