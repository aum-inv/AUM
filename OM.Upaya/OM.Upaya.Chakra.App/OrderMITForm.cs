using OM.Lib.Base.Utils;
using OM.Lib.Entity;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Upaya.Chakra.App
{
    public partial class OrderMITForm : Form
    {
        OrderMITRule rule = new OrderMITRule();
        ConcurrentQueue<CurrentPrice> currentPrices = new ConcurrentQueue<CurrentPrice>();
        bool isRun = true;
        public OrderMITForm()
        {
            InitializeComponent();
            this.Load += TradeRuleForm_Load;
            this.FormClosing += OrderMITForm_FormClosing;
            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;

            System.Threading.Thread tCL = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            tCL.Start();
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
                    if (isDequeue)
                    {
                        rule.Analysis(price);
                    }
                }
                catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        private void OrderMITForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = false;
            SiseEvents.Instance.SiseHandler -= Instance_SiseHandler;
            rule.Close();
        }

        private void TradeRuleForm_Load(object sender, EventArgs e)
        {
            rule.ItemCode = tbItem.Text;
        }
        private void Instance_SiseHandler(string itemCode, CurrentPrice price)
        {
            try
            {
                if (rule.ItemCode != itemCode) return;
                tbOrderPrice.Text = price.price;
                currentPrices.Enqueue(price);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            rule.ItemCode = tbItem.Text;
        }

        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (tbQty.Text.Length == 0) return;
            rule.Quantity = Convert.ToInt32(tbQty.Text);
        }

        private void rdoTradeType1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTradeType1.Checked) rule.TradeType = "1";
        }

        private void rdoTradeType2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTradeType2.Checked) rule.TradeType = "2";
        }

        private void chkIsBuy_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseMITBuy = chkIsBuy.Checked;
        }

        private void tbBuyPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice2.Text.Length == 0) return;
            rule.BuyPrice2 = Convert.ToDouble(tbBuyPrice2.Text);
        }

        private void tbBuyPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbBuyPrice1.Text.Length == 0) return;
            rule.BuyPrice1 = Convert.ToDouble(tbBuyPrice1.Text);
        }

        private void chkIsSell_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseMITSell = chkIsSell.Checked;
        }

        private void tbSellPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbSellPrice1.Text.Length == 0) return;
            rule.SellPrice1 = Convert.ToDouble(tbSellPrice1.Text);
        }

        private void tbSellPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbSellPrice2.Text.Length == 0) return;
            rule.SellPrice2 = Convert.ToDouble(tbSellPrice2.Text);
        }

        private void btnIII_Click(object sender, EventArgs e)
        {
            rule.IsBuyed = false;
        }
    }
}
