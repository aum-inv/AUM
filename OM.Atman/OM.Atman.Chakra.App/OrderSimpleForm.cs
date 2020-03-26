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

namespace OM.Atman.Chakra.App
{
    public partial class OrderSimpleForm : Form
    {
        OrderSimpleRule rule = new OrderSimpleRule();
        ConcurrentQueue<CurrentPrice> currentPrices = new ConcurrentQueue<CurrentPrice>();
        bool isRun = true;
        public OrderSimpleForm()
        {
            InitializeComponent();
            this.Load += TradeRuleForm_Load;
            this.FormClosing += OrderSimpleForm_FormClosing;
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
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
        }
        private void OrderSimpleForm_FormClosing(object sender, FormClosingEventArgs e)
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

                tbCurPrice.Text = price.price;

                if (chkCurPrice.Checked) tbOrderPrice.Text = price.price;

                rule.Analysis(price);
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
        
        private void tbOrderPrice_TextChanged(object sender, EventArgs e)
        {
            if (tbOrderPrice.Text.Length == 0) return;
            rule.OrderPrice = Convert.ToDouble(tbOrderPrice.Text);
        }

        private void rdoPosition1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPosition1.Checked) rule.Position = "1";
        }

        private void rdoPosition2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPosition2.Checked) rule.Position = "2";
        }

        private void tbAvgPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbAvgPrice2.Text.Length == 0) return;
            rule.AvgPrice2 = Convert.ToDouble(tbAvgPrice2.Text);
        }

        private void tbAvgPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbAvgPrice1.Text.Length == 0) return;
            rule.AvgPrice1 = Convert.ToDouble(tbAvgPrice1.Text);
        }

        private void tbLossPrice1_TextChanged(object sender, EventArgs e)
        {
            if (tbLossPrice1.Text.Length == 0) return;
            rule.LossPrice1 = Convert.ToDouble(tbLossPrice1.Text);
        }

        private void tbLossPrice2_TextChanged(object sender, EventArgs e)
        {
            if (tbLossPrice2.Text.Length == 0) return;
            rule.LossPrice2 = Convert.ToDouble(tbLossPrice2.Text);
        }

        private void chkIsUseLoss_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseLossPrice = chkIsUseLoss.Checked;
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

        private void tbMinimumRevenue2_TextChanged(object sender, EventArgs e)
        {
            if (tbMinimumRevenue2.Text.Length == 0) return;
            rule.MinimumRevenuePrice2 = Convert.ToDouble(tbMinimumRevenue2.Text);
        }

        private void tbMinimumRevenue1_TextChanged(object sender, EventArgs e)
        {
            if (tbMinimumRevenue1.Text.Length == 0) return;
            rule.MinimumRevenuePrice1 = Convert.ToDouble(tbMinimumRevenue1.Text);
        }

        private void chkIsUseRevenue1_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseRevenue1 = chkIsUseRevenue1.Checked;
        }

        private void chkIsUseRevenue2_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsUseRevenue2 = chkIsUseRevenue2.Checked;
        }

        private void chkMinimumRevenue2_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsMinimumRevenue2 = chkMinimumRevenue2.Checked;
        }

        private void chkMinimumRevenue1_CheckedChanged(object sender, EventArgs e)
        {
            rule.IsMinimumRevenue1 = chkMinimumRevenue1.Checked;
        }

        private void chkIsUseRevenue_CheckedChanged(object sender, EventArgs e)
        {            
            rule.IsUseRevenue = chkIsUseRevenue.Checked;
        }

        private void btnBuy2_Click(object sender, EventArgs e)
        {
            if (chkOrderConfirm.Checked)
            {
                using (new CenterWinDialog(this))
                {
                    if (MessageBox.Show("주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }
            XingContext.Instance.ClientContext.OrderBuySell(rule.ItemCode, "2", rule.TradeType, rule.OrderPrice.ToString(), rule.Quantity.ToString());
        }

        private void btnBuy1_Click(object sender, EventArgs e)
        {
            if (chkOrderConfirm.Checked)
            {
                using (new CenterWinDialog(this))
                {
                    if (MessageBox.Show("주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }
            XingContext.Instance.ClientContext.OrderBuySell(rule.ItemCode, "1", rule.TradeType, rule.OrderPrice.ToString(), rule.Quantity.ToString());
        }

        private void btnSell1_Click(object sender, EventArgs e)
        {
            if (chkOrderConfirm.Checked)
            {
                using (new CenterWinDialog(this))
                {
                    if (MessageBox.Show("주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }
            XingContext.Instance.ClientContext.OrderBuySell(rule.ItemCode, "1", rule.TradeType, rule.OrderPrice.ToString(), rule.Quantity.ToString());
        }

        private void btnSell2_Click(object sender, EventArgs e)
        {
            if (chkOrderConfirm.Checked)
            {
                using (new CenterWinDialog(this))
                {
                    if (MessageBox.Show("주문하시겠습니까?", "주문확인", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                }
            }
            XingContext.Instance.ClientContext.OrderBuySell(rule.ItemCode, "2", rule.TradeType, rule.OrderPrice.ToString(), rule.Quantity.ToString());
        }

        private void tbAvgPrice2_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbAvgPrice2.Text.Length == 0) return;
            int lossTick1 = 15;
            int lossTick2 = 30;
            int revenueTick = 60;
            if (e.KeyCode == Keys.Enter)
            {
                if (tbLossPrice1.Text == "0")
                {
                    tbLossPrice1.Text = PriceTick.GetDownPriceOfTick(rule.ItemCode, rule.AvgPrice2, lossTick1).ToString();
                }
                if (tbLossPrice2.Text == "0")
                {
                    tbLossPrice2.Text = PriceTick.GetDownPriceOfTick(rule.ItemCode, rule.AvgPrice2, lossTick2).ToString();
                }
                if (tbMinimumRevenue2.Text == "0")
                {
                    tbMinimumRevenue2.Text = PriceTick.GetUpPriceOfTick(rule.ItemCode, rule.AvgPrice2, revenueTick).ToString();
                }
            }
        }

        private void tbAvgPrice1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbAvgPrice1.Text.Length == 0) return;
            int lossTick1 = 15;
            int lossTick2 = 30;
            int revenueTick = 60;
            if (e.KeyCode == Keys.Enter)
            {
                if (tbLossPrice1.Text == "0")
                {
                    tbLossPrice1.Text = PriceTick.GetUpPriceOfTick(rule.ItemCode, rule.AvgPrice1, lossTick1).ToString();
                }
                if (tbLossPrice2.Text == "0")
                {
                    tbLossPrice2.Text = PriceTick.GetUpPriceOfTick(rule.ItemCode, rule.AvgPrice1, lossTick2).ToString();
                }
                if (tbMinimumRevenue1.Text == "0")
                {
                    tbMinimumRevenue1.Text = PriceTick.GetDownPriceOfTick(rule.ItemCode, rule.AvgPrice1, revenueTick).ToString();
                }
            }
        }

        private void btnIII_Click(object sender, EventArgs e)
        {
            rule.IsBuyed = false;
        }
    }

    class CenterWinDialog : IDisposable
    {
        private int mTries = 0;
        private Form mOwner;               
        public CenterWinDialog(Form owner)
        {
            mOwner = owner;
            owner.BeginInvoke(new MethodInvoker(findDialog));
        }
        
        private void findDialog()
        {
            // Enumerate windows to find the message box
            if (mTries < 0) return;
            EnumThreadWndProc callback = new EnumThreadWndProc(checkWindow);
            if (EnumThreadWindows(GetCurrentThreadId(), callback, IntPtr.Zero))
            {
                if (++mTries < 10) mOwner.BeginInvoke(new MethodInvoker(findDialog));
            }
        }

        private bool checkWindow(IntPtr hWnd, IntPtr lp)
        {
            // Checks if <hWnd> is a dialog
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            if (sb.ToString() != "#32770") return true;
            // Got it

            Rectangle frmRect = new Rectangle(mOwner.Location, mOwner.Size);
            RECT dlgRect;
            GetWindowRect(hWnd, out dlgRect);
            MoveWindow(hWnd,
                frmRect.Left + (frmRect.Width - dlgRect.Right + dlgRect.Left) / 2,
                frmRect.Top + (frmRect.Height - dlgRect.Bottom + dlgRect.Top) / 2,
                dlgRect.Right - dlgRect.Left,
                dlgRect.Bottom - dlgRect.Top, true);
            return false;
        }

        public void Dispose()
        {
            mTries = -1;
        }

        // P/Invoke declarations

        private delegate bool EnumThreadWndProc(IntPtr hWnd, IntPtr lp);
        [DllImport("user32.dll")]
        private static extern bool EnumThreadWindows(int tid, EnumThreadWndProc callback, IntPtr lp);
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();
        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder buffer, int buflen);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);
        [DllImport("user32.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);
        private struct RECT { public int Left; public int Top; public int Right; public int Bottom; }

    }
}
