using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.Lib.Base.Utils;

namespace OM.Atman.Chakra.App.Uc.Calculators
{
    public partial class Uc_QuantityCalculator : UserControl
    {
        public Uc_QuantityCalculator()
        {
            InitializeComponent();
        }

        private void nudFund_ValueChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void nudRate_ValueChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void nudPrice_ValueChanged(object sender, EventArgs e)
        {
            calculator();
        }

        private void calculator()
        {
            double fund = Convert.ToDouble(nudFund.Value);
            double rate = Convert.ToDouble(nudRate.Value);
            double price = Convert.ToDouble(nudPrice.Value);

            if (fund == 0 || rate == 0 || price == 0) return;

            double realFund = Math.Ceiling(fund * rate / 100.0);
            double realQuantity = Math.Ceiling(realFund / price);

            tbQuantity.Text = Convert.ToInt32(realQuantity).ToString("N0");

            long fund2 = Convert.ToInt64(fund);
            lbMoney.Text = MoneyUtil.Number2Hangle(fund2) + "원";

            long quantity = Convert.ToInt64(tbQuantity.Text.Replace(",", ""));
            lbQuantity.Text = MoneyUtil.Number2Hangle(quantity) + "개";
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbQuantity.Text.Replace(",",""));
        }

        private void btnCopy2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbQuantity2.Text.Replace(",", ""));
        }

        private void nudQuantity2_ValueChanged(object sender, EventArgs e)
        {
            calculator2();
        }

        private void nudRate2_ValueChanged(object sender, EventArgs e)
        {
            calculator2();
        }
        private void calculator2()
        {
            double quantity = Convert.ToDouble(nudQuantity2.Value);
            double rate = Convert.ToDouble(nudRate2.Value);
          
            if (quantity == 0 || rate == 0) return;

            double realQuantity = Math.Ceiling(quantity * rate / 100.0);

            tbQuantity2.Text = Convert.ToInt32(realQuantity).ToString("N0");
            
            long quantity2 = Convert.ToInt64(tbQuantity2.Text.Replace(",", ""));
            lbQuantity2.Text = MoneyUtil.Number2Hangle(quantity2) + "개";
        }
    }
}
