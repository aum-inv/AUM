using MetroFramework.Controls;
using OM.Atman.Chakra.App.AIForms;
using OM.Atman.Chakra.App.Config;
using OM.Atman.Chakra.App.Forms;
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
                //if (chkPlanResultKR.Checked) ShareConfig.LaunchFormType = 1;
                //else if (chkPatternMatching1.Checked) ShareConfig.LaunchFormType = 2;
                //else if (chkSignalComplication.Checked) ShareConfig.LaunchFormType = 3;
                //else if (chkDiary.Checked) ShareConfig.LaunchFormType = 4;
                //else if (chkTechnicalCalculatorKR.Checked) ShareConfig.LaunchFormType = 5;
                //else if (chkRealBoard.Checked) ShareConfig.LaunchFormType = 8;
                //else if (chkQuantityCalculator.Checked) ShareConfig.LaunchFormType = 9;
                //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();
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
                case "국내지수투자전략작성":
                    form = new AtmanKospiForm();
                    break;
                case "해외선물투자전략작성":
                    form = new AtmanKospiForm();
                    break;
                case "국내지수기술분석계산기":
                    form = new AtmanInvTechnicalForm();
                    break;
                case "해외선물기술분석계산기":
                    form = new AtmanInvTechnicalForm();
                    break;
                case "매수매도수량계산기":
                    form = new AtmanInvCalculatorForm();
                    break;
                case "투자다이어리":
                    form = new AtmanInvDiaryForm();
                    break;
                case "실시간시세전광판":
                    form = new MainForm();
                    break;
                case "가격모니터링&&시그널":
                    form = new MainForm();
                    break;
                case "캔들패턴매칭AI-1":
                    form = new AtmanKospiAIForm();
                    break;
                case "캔들패턴매칭AI-2":
                    form = new AtmanKospiAI2Form();
                    break;
                case "캔들패턴매칭AI-3":
                    form = new AtmanKospiAIForm();
                    break;
                case "캔들패턴매칭AI-4":
                    form = new AtmanKospiAIForm();
                    break;
                default:
                    form = new MainForm();
                    break;
            }

            form.Show();            
        }
    }
}
