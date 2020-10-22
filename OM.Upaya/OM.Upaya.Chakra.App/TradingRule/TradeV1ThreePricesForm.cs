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

namespace OM.Upaya.Chakra.App.TradingRule
{
    public partial class TradeV1ThreePricesForm : Form
    {
        UpayaTradeThreePriceRule rule = new UpayaTradeThreePriceRule();

        public TradeV1ThreePricesForm()
        {
            InitializeComponent();

            this.Load += TradeRuleForm_Load;

            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;

            UpayaTradeEvents.Instance.TradeRuleHandler += Instance_TradeRuleHandler;
        }

        private void TradeRuleForm_Load(object sender, EventArgs e)
        {
            rule.Item = tbItem.Text;
            rule.ItemCode = tbItemCode.Text;
        }

        private void Instance_TradeRuleHandler(string message)
        {
            tbLog.Invoke(new MethodInvoker(() =>
            {
                tbLog.AppendText(message);
                tbLog.AppendText(Environment.NewLine);
            }));
        }
        private void Instance_SiseHandler(string item, CurrentPrice price)
        {
            try
            {
                if (!rule.IsUse) return;

                if (rule.Item != item) return;

                rule.Analysis(price);
            }
            catch (Exception ex)
            {
                tbLog.Invoke(new MethodInvoker(() =>
                {
                    tbLog.AppendText(ex.Message);
                    tbLog.AppendText(Environment.NewLine);
                }));
            }
        }
        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            rule.Item = tbItem.Text;
        }
        private void tbItemCode_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            rule.ItemCode = tbItemCode.Text;
        }
        private void chkIsUse_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUse = chkIsUse.Checked;
        }
        private void rdoTradeType1_CheckedChanged(object sender, EventArgs e)
        {
            rule.TradeType = "1";
        }
        private void rdoTradeType2_CheckedChanged(object sender, EventArgs e)
        {
            rule.TradeType = "2";
        }

        #region P2
        private void tbP2BuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice1.Text.Length == 0) return;
            rule.P2BuyPrice1 = Convert.ToDouble(tbP2BuyPrice1.Text);
        }
        private void tbP2BuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice2.Text.Length == 0) return;
            rule.P2BuyPrice2 = Convert.ToDouble(tbP2BuyPrice2.Text);
        }
        private void tbP2BuyPrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyPrice3.Text.Length == 0) return;
            rule.P2BuyPrice3 = Convert.ToDouble(tbP2BuyPrice3.Text);
        }
        private void tbP2RevenuePrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenuePrice1.Text.Length == 0) return;
            rule.P2RevenuePrice1 = Convert.ToDouble(tbP2RevenuePrice1.Text);
        }
        private void tbP2RevenuePrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenuePrice2.Text.Length == 0) return;
            rule.P2RevenuePrice2 = Convert.ToDouble(tbP2RevenuePrice2.Text);
        }
        private void tbP2RevenuePrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenuePrice3.Text.Length == 0) return;
            rule.P2RevenuePrice3 = Convert.ToDouble(tbP2RevenuePrice3.Text);
        }
        private void tbP2LosscutPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutPrice1.Text.Length == 0) return;
            rule.P2LosscutPrice1 = Convert.ToDouble(tbP2LosscutPrice1.Text);
        }
        private void tbP2LosscutPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutPrice2.Text.Length == 0) return;
            rule.P2LosscutPrice2 = Convert.ToDouble(tbP2LosscutPrice2.Text);
        }
        private void tbP2LosscutPrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutPrice3.Text.Length == 0) return;
            rule.P2LosscutPrice3 = Convert.ToDouble(tbP2LosscutPrice3.Text);
        }

        private void tbP2BuyQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyQty1.Text.Length == 0) return;
            rule.P2BuyQty1 = Convert.ToInt32(tbP2BuyQty1.Text);
        }

        private void tbP2BuyQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyQty2.Text.Length == 0) return;
            rule.P2BuyQty2 = Convert.ToInt32(tbP2BuyQty2.Text);
        }

        private void tbP2BuyQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2BuyQty3.Text.Length == 0) return;
            rule.P2BuyQty3 = Convert.ToInt32(tbP2BuyQty3.Text);
        }

        private void tbP2RevenueQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenueQty1.Text.Length == 0) return;
            rule.P2RevenueQty1 = Convert.ToInt32(tbP2RevenueQty1.Text);
        }

        private void tbP2RevenueQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenueQty2.Text.Length == 0) return;
            rule.P2RevenueQty2 = Convert.ToInt32(tbP2RevenueQty2.Text);
        }

        private void tbP2RevenueQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2RevenueQty3.Text.Length == 0) return;
            rule.P2RevenueQty3 = Convert.ToInt32(tbP2RevenueQty3.Text);
        }

        private void tbP2LosscutQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutQty1.Text.Length == 0) return;
            rule.P2LosscutQty1 = Convert.ToInt32(tbP2LosscutQty1.Text);
        }

        private void tbP2LosscutQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutQty2.Text.Length == 0) return;
            rule.P2LosscutQty2 = Convert.ToInt32(tbP2LosscutQty2.Text);
        }

        private void tbP2LosscutQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP2LosscutQty3.Text.Length == 0) return;
            rule.P2LosscutQty3 = Convert.ToInt32(tbP2LosscutQty3.Text);
        }

        private void chkIsUseP2Buy1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Buy1 = c.Checked;
        }

        private void chkIsUseP2Buy2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Buy2 = c.Checked;
        }

        private void chkIsUseP2Buy3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Buy3 = c.Checked;
        }

        private void chkIsUseP2Revenue1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Revenue1 = c.Checked;
        }

        private void chkIsUseP2Revenue2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Revenue2 = c.Checked;
        }

        private void chkIsUseP2Revenue3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Revenue3 = c.Checked;
        }

        private void chkIsUseP2Losscut1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Losscut1 = c.Checked;
        }

        private void chkIsUseP2Losscut2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Losscut2 = c.Checked;
        }

        private void chkIsUseP2Losscut3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP2Losscut3 = c.Checked;
        }
        #endregion

        #region P1
        
        private void tbP1BuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice1.Text.Length == 0) return;
            rule.P1BuyPrice1 = Convert.ToDouble(tbP1BuyPrice1.Text);
        }
        private void tbP1BuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice2.Text.Length == 0) return;
            rule.P1BuyPrice2 = Convert.ToDouble(tbP1BuyPrice2.Text);
        }
        private void tbP1BuyPrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyPrice3.Text.Length == 0) return;
            rule.P1BuyPrice3 = Convert.ToDouble(tbP1BuyPrice3.Text);
        }
        private void tbP1RevenuePrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenuePrice1.Text.Length == 0) return;
            rule.P1RevenuePrice1 = Convert.ToDouble(tbP1RevenuePrice1.Text);
        }
        private void tbP1RevenuePrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenuePrice2.Text.Length == 0) return;
            rule.P1RevenuePrice2 = Convert.ToDouble(tbP1RevenuePrice2.Text);
        }
        private void tbP1RevenuePrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenuePrice3.Text.Length == 0) return;
            rule.P1RevenuePrice3 = Convert.ToDouble(tbP1RevenuePrice3.Text);
        }
        private void tbP1LosscutPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutPrice1.Text.Length == 0) return;
            rule.P1LosscutPrice1 = Convert.ToDouble(tbP1LosscutPrice1.Text);
        }
        private void tbP1LosscutPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutPrice2.Text.Length == 0) return;
            rule.P1LosscutPrice2 = Convert.ToDouble(tbP1LosscutPrice2.Text);
        }
        private void tbP1LosscutPrice3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutPrice3.Text.Length == 0) return;
            rule.P1LosscutPrice3 = Convert.ToDouble(tbP1LosscutPrice3.Text);
        }

        private void tbP1BuyQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyQty1.Text.Length == 0) return;
            rule.P1BuyQty1 = Convert.ToInt32(tbP1BuyQty1.Text);
        }

        private void tbP1BuyQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyQty2.Text.Length == 0) return;
            rule.P1BuyQty2 = Convert.ToInt32(tbP1BuyQty2.Text);
        }

        private void tbP1BuyQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1BuyQty3.Text.Length == 0) return;
            rule.P1BuyQty3 = Convert.ToInt32(tbP1BuyQty3.Text);
        }

        private void tbP1RevenueQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenueQty1.Text.Length == 0) return;
            rule.P1RevenueQty1 = Convert.ToInt32(tbP1RevenueQty1.Text);
        }

        private void tbP1RevenueQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenueQty2.Text.Length == 0) return;
            rule.P1RevenueQty2 = Convert.ToInt32(tbP1RevenueQty2.Text);
        }

        private void tbP1RevenueQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1RevenueQty3.Text.Length == 0) return;
            rule.P1RevenueQty3 = Convert.ToInt32(tbP1RevenueQty3.Text);
        }

        private void tbP1LosscutQty1_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutQty1.Text.Length == 0) return;
            rule.P1LosscutQty1 = Convert.ToInt32(tbP1LosscutQty1.Text);
        }

        private void tbP1LosscutQty2_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutQty2.Text.Length == 0) return;
            rule.P1LosscutQty2 = Convert.ToInt32(tbP1LosscutQty2.Text);
        }

        private void tbP1LosscutQty3_TextChanged(object sender, EventArgs e)
        {
            if (tbP1LosscutQty3.Text.Length == 0) return;
            rule.P1LosscutQty3 = Convert.ToInt32(tbP1LosscutQty3.Text);
        }

        private void chkIsUseP1Buy1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Buy1 = c.Checked;
        }

        private void chkIsUseP1Buy2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Buy2 = c.Checked;
        }

        private void chkIsUseP1Buy3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Buy3 = c.Checked;
        }

        private void chkIsUseP1Revenue1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Revenue1 = c.Checked;
        }

        private void chkIsUseP1Revenue2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Revenue2 = c.Checked;
        }

        private void chkIsUseP1Revenue3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Revenue3 = c.Checked;
        }

        private void chkIsUseP1Losscut1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Losscut1 = c.Checked;
        }

        private void chkIsUseP1Losscut2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Losscut2 = c.Checked;
        }

        private void chkIsUseP1Losscut3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = sender as CheckBox;
            rule.IsUseP1Losscut3 = c.Checked;
        }
        #endregion

       
    }
}
