using MetroFramework.Controls;
using System;
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
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tbSecurity.Text == "atman999")
            {
                tbSecurity.Visible = btnLogin.Visible = false;

                foreach (var c in this.Controls)
                {
                    if (c is MetroCheckBox)
                    {
                        ((MetroCheckBox)c).Enabled = true;
                    }
                }
                new MainForm().Show();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                if (c is MetroCheckBox)
                {
                    ((MetroCheckBox)c).Enabled = false;
                }
            }
        }

        private void RadioButton_Click(object sender, EventArgs e)
        {
            var c = sender as MetroCheckBox;
            if (!c.Checked) return;
            
            string cText = c.Text.Replace(" " , "");
            Form form = null;
            switch (cText) 
            {
                case "해외선물기본매매3단계":
                    form = new TradingRule.TradeV1ThreePricesForm();
                    break;
                case "해외선물기본매매5단계":
                    form = new TradingRule.TradeV1ThreePricesForm();
                    break;
                case "국내종목기본매매3단계":
                    form = new TradingRule.TradeV1ThreePricesForm();
                    break;
                case "국내종목기본매매5단계":
                    form = new TradingRule.TradeV1ThreePricesForm();
                    break;
                default:
                    form = new MainForm();
                    break;
            }

            form.Show();            
        }
    }
}
