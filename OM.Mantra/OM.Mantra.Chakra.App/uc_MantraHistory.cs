using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.Lib.Entity;

namespace OM.Mantra.Chakra.App
{
    public partial class uc_MantraHistory : UserControl
    {
        MantraHistory mantraItem = null;
        public uc_MantraHistory()
        {
            InitializeComponent();
        }
        public void BindItem(MantraHistory item)
        {
            try
            {
                mantraItem = item;

                tbItem.Text = item.Item;

                if (item.BuySell == "진입")
                    cbBuySell.SelectedIndex = 0;
                else if (item.BuySell == "청산")
                    cbBuySell.SelectedIndex = 1;

                if (item.Position == "매수")
                    cbPosition.SelectedIndex = 0;
                else if (item.Position == "매도")
                    cbPosition.SelectedIndex = 1;

                tbPrice.Text = item.ContractPrice;
                tbTime.Text = item.ContractTime;
                tbQuantity.Text = item.Quantity.ToString();

                if (item.IncomingType == "수익")
                    cbIncomingType.SelectedIndex = 0;
                else if (item.IncomingType == "손실")
                    cbIncomingType.SelectedIndex = 1;
                else if (item.IncomingType == "본전")
                    cbIncomingType.SelectedIndex = 2;

                tbIncoming.Text = item.Incoming;
                if (item.BuySell == "진입")
                    tbReason.Text = item.BuyReason;
                else if (item.BuySell == "청산")
                    tbReason.Text = item.SellReason;

                if (item.BuySell == "진입")
                {
                    this.ForeColor = Color.Gold;
                }
                else if (item.BuySell == "청산")
                {
                    if (item.IncomingType == "수익")
                        this.ForeColor = Color.Red;
                    else if (item.IncomingType == "손실")
                        this.ForeColor = Color.Blue;                    
                }
            }
            catch (Exception ex)
            { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                MantraHistory item = new MantraHistory();
                item.No = 0;
                item.Item = tbItem.Text;
                if (item.Item.Length == 0) return;

                if (cbBuySell.SelectedIndex == 0)
                    item.BuySell = "진입";
                else if (cbBuySell.SelectedIndex == 1)
                    item.BuySell = "청산";

                if (cbPosition.SelectedIndex == 0)
                    item.Position = "매수";
                else if (cbPosition.SelectedIndex == 1)
                    item.Position = "매도";

                item.ContractPrice = tbPrice.Text;
                item.ContractTime = tbTime.Text;
                item.Quantity = Convert.ToInt16(tbQuantity.Text.Length == 0 ? "0" : tbQuantity.Text);

                if (cbIncomingType.SelectedIndex == 0)
                    item.IncomingType = "수익";
                else if (cbIncomingType.SelectedIndex == 1)
                    item.IncomingType = "손실";
                else if (cbIncomingType.SelectedIndex == 2)
                    item.IncomingType = "본전";

                item.Incoming = tbIncoming.Text;

                if (item.BuySell == "진입")
                    item.BuyReason = tbReason.Text;
                else if (item.BuySell == "청산")
                    item.SellReason = tbReason.Text;

                item.Create();

                MessageBox.Show("등록되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (mantraItem == null) return;

                MantraHistory item = new MantraHistory();
                item.No = mantraItem.No;
                item.Item = tbItem.Text;
                if (item.Item.Length == 0) return;

                if (cbBuySell.SelectedIndex == 0)
                    item.BuySell = "진입";
                else if (cbBuySell.SelectedIndex == 1)
                    item.BuySell = "청산";

                if (cbPosition.SelectedIndex == 0)
                    item.Position = "매수";
                else if (cbPosition.SelectedIndex == 1)
                    item.Position = "매도";

                item.ContractPrice = tbPrice.Text;
                item.ContractTime = tbTime.Text;
                item.Quantity = Convert.ToInt16(tbQuantity.Text.Length == 0 ? "0" : tbQuantity.Text);

                if (cbIncomingType.SelectedIndex == 0)
                    item.IncomingType = "수익";
                else if (cbIncomingType.SelectedIndex == 1)
                    item.IncomingType = "손실";
                else if (cbIncomingType.SelectedIndex == 2)
                    item.IncomingType = "본전";

                item.Incoming = tbIncoming.Text;

                if (item.BuySell == "진입")
                    item.BuyReason = tbReason.Text;
                else if (item.BuySell == "청산")
                    item.SellReason = tbReason.Text;

                item.Update();

                MessageBox.Show("수정되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tbItem.Text = "";
            cbBuySell.SelectedIndex = -1;      
            cbPosition.SelectedIndex = -1;
         
            tbPrice.Text = "";
            tbTime.Text = "";
            cbIncomingType.SelectedIndex = -1;
            tbIncoming.Text = "";
            tbReason.Text = "";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                MantraHistory item = new MantraHistory();
                item.No = mantraItem.No;
                item.Delete();

                Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
