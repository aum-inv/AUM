using OM.Lib.Base.Enums;
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
    public partial class PatternTradeRuleForm4 : Form
    {
        BasicPatternTradeRule2 rule = new BasicPatternTradeRule2(false);

        public PatternTradeRuleForm4()
        {
            InitializeComponent();
            this.Load += TradeRuleForm_Load;
            this.FormClosing += PatternTradeRuleForm4_FormClosing;
            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;
            TradeEvents.Instance.TradeRuleHandler2 += Instance_TradeRuleHandler;
        }

        private void PatternTradeRuleForm4_FormClosing(object sender, FormClosingEventArgs e)
        {
            rule.Close();
            SiseEvents.Instance.SiseHandler -= Instance_SiseHandler;
            TradeEvents.Instance.TradeRuleHandler2 -= Instance_TradeRuleHandler;
        }

        private void TradeRuleForm_Load(object sender, EventArgs e)
        {
            rule.P2BuyPrice1 = new List<double>();
            rule.P2BuyPrice2 = new List<double>();
            rule.P1BuyPrice1 = new List<double>();
            rule.P1BuyPrice2 = new List<double>();
            rule.P2BuyPrice1.AddRange(new double[] { 0, 0, 0 });
            rule.P2BuyPrice2.AddRange(new double[] { 0, 0, 0 });
            rule.P1BuyPrice1.AddRange(new double[] { 0, 0, 0 });
            rule.P1BuyPrice2.AddRange(new double[] { 0, 0, 0 });

            rule.RuleID = tbRuleID.Text;
            rule.Item = tbItem.Text;

            cbP1Pattern.DataSource = Enum.GetValues(typeof(UpDownPatternEnum));
            cbP2Pattern.DataSource = Enum.GetValues(typeof(UpDownPatternEnum));
            cbP1Pattern.SelectedItem = UpDownPatternEnum.UpDownUpDownUpDown;
            cbP2Pattern.SelectedItem = UpDownPatternEnum.DownUpDownUpDownUp;

            cbP1LossPattern1.SelectedIndex = (int)rule.P1LosscutPattern1;
            cbP2LossPattern1.SelectedIndex = (int)rule.P2LosscutPattern1;

            cbPriceType.SelectedIndex = Convert.ToInt32(rule.PriceType);
        }

        private void Instance_TradeRuleHandler(string atmanName, string ruleID, string itemCode, string message)
        {
            if (atmanName != "TRADE") return;
            if (ruleID != tbRuleID.Text) return;
            if (itemCode != tbItem.Text) return;
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
                if (!rule.IsUse) return;

                if (rule.Item != itemCode) return;

                rule.Analysis(price);
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

        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            rule.Item = tbItem.Text;
        }

        private void cbTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.TimeType = cbTimeType.SelectedItem.ToString();
        }

        private void chkIsUse_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUse = chkIsUse.Checked;
        }

        private void tbP2BuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice1.Text.Length == 0) return;
            rule.P2BuyPrice1[0] = Convert.ToDouble(tbP2BuyPrice1.Text);           
        }
        private void tbP2BuyPrice1_2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice1_2.Text.Length == 0) return;
            rule.P2BuyPrice1[1] = Convert.ToDouble(tbP2BuyPrice1_2.Text);
        }
        private void tbP2BuyPrice1_3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice1_3.Text.Length == 0) return;
            rule.P2BuyPrice1[2] = Convert.ToDouble(tbP2BuyPrice1_3.Text);
        }

        private void tbP2BuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice2.Text.Length == 0) return;
            rule.P2BuyPrice2[0] = Convert.ToDouble(tbP2BuyPrice2.Text);
        }
        private void tbP2BuyPrice2_2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice2_2.Text.Length == 0) return;
            rule.P2BuyPrice2[1] = Convert.ToDouble(tbP2BuyPrice2_2.Text);
        }
        private void tbP2BuyPrice2_3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice2_3.Text.Length == 0) return;
            rule.P2BuyPrice2[2] = Convert.ToDouble(tbP2BuyPrice2_3.Text);
        }
        private void tbP2BuyPrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbP2BuyPrice1.Text.Length == 0) return;
            int buyTicks = 5;
            int lossTick1 = 10;
            int lossTick2 = 20;
            int revenueTick = 30;
            if (rdoSType1.Checked)
            {
                buyTicks = 5;
                lossTick1 = 20;
                lossTick2 = 30;
                revenueTick = 50;
            }
            else if (rdoSType2.Checked)
            {
                buyTicks = 3;
                lossTick1 = 5;
                lossTick2 = 10;
                revenueTick = 30;
            }
            else if (rdoSType3.Checked)
            {
                buyTicks = 10;
                lossTick1 = 20;
                lossTick2 = 40;
                revenueTick = 100;
            }          

            if (e.KeyCode == Keys.Enter)
            {
                if (tbP2BuyPrice1_2.Text == "0")
                {
                    tbP2BuyPrice1_2.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P2BuyPrice1[0], buyTicks + 5).ToString();
                }
                if (tbP2BuyPrice1_3.Text == "0")
                {
                    tbP2BuyPrice1_3.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P2BuyPrice1[0], buyTicks + 10).ToString();
                }

                if (tbP2BuyPrice2.Text == "0")
                {
                    tbP2BuyPrice2.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P2BuyPrice1[0], buyTicks).ToString();
                }
                if (tbP2BuyPrice2_2.Text == "0")
                {
                    tbP2BuyPrice2_2.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P2BuyPrice1[0], buyTicks - 5).ToString();
                }
                if (tbP2BuyPrice2_3.Text == "0")
                {
                    tbP2BuyPrice2_3.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P2BuyPrice1[0], buyTicks - 10).ToString();
                }

                if (tbP2LossPrice1.Text == "0")
                {
                    tbP2LossPrice1.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P2BuyPrice1[2], lossTick1).ToString();
                }
                if (tbP2LossPrice2.Text == "0")
                {
                    tbP2LossPrice2.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P2BuyPrice1[2], lossTick2).ToString();
                }
                if (tbMinimumRevenue2.Text == "0")
                {
                    tbMinimumRevenue2.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P2BuyPrice1[2],  revenueTick).ToString();
                }
            }
        }

        private void cbP2Pattern1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.P2BuyPattern = (UpDownPatternEnum)cbP2Pattern.SelectedItem;
        }               
        private void tbP2LossPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LossPrice1.Text.Length == 0) return;
            rule.P2LosscutPrice1 = Convert.ToDouble(tbP2LossPrice1.Text);
        }
        private void tbP2LossPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LossPrice2.Text.Length == 0) return;
            rule.P2LosscutPrice2 = Convert.ToDouble(tbP2LossPrice2.Text);
        }
        private void chkIsUseP2_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseP2 = chkIsUseP2.Checked;
        }      
        
        private void tbP1BuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice1.Text.Length == 0) return;
            rule.P1BuyPrice1[0] = Convert.ToDouble(tbP1BuyPrice1.Text);           
        }
        private void tbP1BuyPrice1_2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice1_2.Text.Length == 0) return;
            rule.P1BuyPrice1[1] = Convert.ToDouble(tbP1BuyPrice1_2.Text);
        }
        private void tbP1BuyPrice1_3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice1_3.Text.Length == 0) return;
            rule.P1BuyPrice1[2] = Convert.ToDouble(tbP1BuyPrice1_3.Text);
        }
        private void tbP1BuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice2.Text.Length == 0) return;
            rule.P1BuyPrice2[0] = Convert.ToDouble(tbP1BuyPrice2.Text);
        }
        private void tbP1BuyPrice2_2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice2_2.Text.Length == 0) return;
            rule.P1BuyPrice2[1] = Convert.ToDouble(tbP1BuyPrice2_2.Text);
        }
        private void tbP1BuyPrice2_3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice2_3.Text.Length == 0) return;
            rule.P1BuyPrice2[2] = Convert.ToDouble(tbP1BuyPrice2_3.Text);
        }
        private void tbP1BuyPrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbP1BuyPrice1.Text.Length == 0) return;
            int buyTicks = 5;
            int lossTick1 = 10;
            int lossTick2 = 20;
            int revenueTick = 30;
            if (rdoSType1.Checked)
            {
                buyTicks = 5;
                lossTick1 = 20;
                lossTick2 = 30;
                revenueTick = 50;
            }
            else if (rdoSType2.Checked)
            {
                buyTicks = 3;
                lossTick1 = 5;
                lossTick2 = 10;
                revenueTick = 30;
            }
            else if (rdoSType3.Checked)
            {
                buyTicks = 10;
                lossTick1 = 20;
                lossTick2 = 40;
                revenueTick = 100;
            }
            
            if (e.KeyCode == Keys.Enter)
            {
                if (tbP1BuyPrice1_2.Text == "0")
                {
                    tbP1BuyPrice1_2.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P1BuyPrice1[0], buyTicks + 5).ToString();
                }
                if (tbP1BuyPrice1_3.Text == "0")
                {
                    tbP1BuyPrice1_3.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P1BuyPrice1[0], buyTicks + 10).ToString();
                }

                if (tbP1BuyPrice2.Text == "0")
                {
                    tbP1BuyPrice2.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P1BuyPrice1[0], buyTicks).ToString();
                }
                if (tbP1BuyPrice2_2.Text == "0")
                {
                    tbP1BuyPrice2_2.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P1BuyPrice1[0], buyTicks - 5).ToString();
                }
                if (tbP1BuyPrice2_3.Text == "0")
                {
                    tbP1BuyPrice2_3.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P1BuyPrice1[0], buyTicks - 10).ToString();
                }

                if (tbP1LossPrice1.Text == "0")
                {
                    tbP1LossPrice1.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P1BuyPrice2[2], lossTick1).ToString();
                }
                if (tbP1LossPrice2.Text == "0")
                {
                    tbP1LossPrice2.Text = PriceTick.GetUpPriceOfTick(rule.Item, rule.P1BuyPrice2[2], lossTick2).ToString();
                }
                if (tbMinimumRevenue1.Text == "0")
                {
                    tbMinimumRevenue1.Text = PriceTick.GetDownPriceOfTick(rule.Item, rule.P1BuyPrice2[2], revenueTick).ToString();
                }
            }
        }
        private void cbP1Pattern1_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.P1BuyPattern = (UpDownPatternEnum)cbP1Pattern.SelectedItem;
        }

        private void tbP1LossPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LossPrice1.Text.Length == 0) return;
            rule.P1LosscutPrice1 = Convert.ToDouble(tbP1LossPrice1.Text);
        }        
        private void tbP1LossPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LossPrice2.Text.Length == 0) return;
            rule.P1LosscutPrice2 = Convert.ToDouble(tbP1LossPrice2.Text);
        }
                
        private void chkIsUseP1_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseP1 = chkIsUseP1.Checked;
        }

        private void tbRevenuePrice_TextChanged(object sender, EventArgs e)
        {
            if (tbRevenuePrice.Text.Length == 0) return;
            rule.RevenuePrice = Convert.ToDouble(tbRevenuePrice.Text);
        }

        private void tbRevenueRate_TextChanged(object sender, EventArgs e)
        {
            if (tbRevenueRate.Text.Length == 0) return;
            rule.RevenueRate = Convert.ToDouble(tbRevenueRate.Text);
        }

        private void chkIsUseRevenue_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseRevenue1 = chkIsUseRevenue1.Checked;
        }
        private void chkIsUseRevenue2_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseRevenue2 = chkIsUseRevenue2.Checked;
        }
      
        private void ChkMinimumRevenue2_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsMinimumRevenue2 = chkMinimumRevenue2.Checked;
        }

        private void TbMinimumRevenue2_TextChanged(object sender, EventArgs e)
        {
            if (tbMinimumRevenue2.Text.Length == 0) return;
            rule.MinimumRevenuePrice2 = Convert.ToDouble(tbMinimumRevenue2.Text);
        }

        private void TbMinimumRevenue1_TextChanged(object sender, EventArgs e)
        {
            if (tbMinimumRevenue1.Text.Length == 0) return;
            rule.MinimumRevenuePrice1 = Convert.ToDouble(tbMinimumRevenue1.Text);
        }

        private void ChkMinimumRevenue1_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsMinimumRevenue1 = chkMinimumRevenue1.Checked;
        }
        private void tbRuleInfo_TextChanged(object sender, EventArgs e)
        {
            if (tbRuleID.Text.Length == 0) return;
            rule.RuleID = tbRuleID.Text;
        }
                
        private void cbPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            rule.PriceType = cbPriceType.SelectedIndex.ToString();
        }
    }
}
