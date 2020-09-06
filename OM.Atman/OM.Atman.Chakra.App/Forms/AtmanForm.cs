using MetroFramework;
using MetroFramework.Controls;
using OM.Atman.Chakra.App.Config;
using OM.Atman.Chakra.App.Uc.Plans;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Atman.Chakra.App.Forms
{
    public partial class AtmanForm : MetroFramework.Forms.MetroForm
    {
     
        public AtmanForm()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {
             uc_AccountFundPlan.Dock = DockStyle.Fill;
            uc_BuyPlan.Dock = DockStyle.Fill;
            uc_InvAvailability.Dock = DockStyle.Fill;
            uc_InvResult.Dock = DockStyle.Fill;
            uc_RevenuePlan.Dock = DockStyle.Fill;
            uc_TrendCheck.Dock = DockStyle.Fill;
        }
        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
            
            tspMenu1.Click += tspMenu_Click;
            tspMenu2.Click += tspMenu_Click;
            tspMenu3.Click += tspMenu_Click;
            tspMenu4.Click += tspMenu_Click;
            tspMenu5.Click += tspMenu_Click;
            tspMenu7.Click += tspMenu_Click;
        }

        private void AtmanForm_Load(object sender, EventArgs e)
        {         
        }

        private void tspMenu_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            bindContentUserControl(btn.Text);

            tspMenu1.ForeColor =
            tspMenu2.ForeColor =
            tspMenu3.ForeColor =
            tspMenu4.ForeColor =
            tspMenu5.ForeColor = 
            tspMenu7.ForeColor = System.Drawing.Color.DimGray;
            btn.ForeColor = System.Drawing.Color.OrangeRed;
        }

        private void bindContentUserControl(string menuTxt)
        {
            menuTxt = menuTxt.Trim();
            uc_AccountFundPlan.Visible = false;
            uc_BuyPlan.Visible = false;
            uc_InvAvailability.Visible = false;
            uc_InvResult.Visible = false;
            uc_RevenuePlan.Visible = false;
            uc_TrendCheck.Visible = false;

            switch (menuTxt)
            {
                case "투자가능시점여부": uc_InvAvailability.Visible = true; break;
                case "추세확인": uc_TrendCheck.Visible = true; break;
                case "계좌&&자금계획": uc_AccountFundPlan.Visible = true; break;
                case "진입&&로스컷계획": uc_BuyPlan.Visible = true; break;
                case "수익포지션계획": uc_RevenuePlan.Visible = true; break;
                case "투자결과": uc_InvResult.Visible = true; break;
                default: break;
            }
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            MetroTextBox textBox = sender as MetroTextBox;            
            MetroMessageBox.Show(this, textBox.CustomButton.Text, "HELP");
        }
    }
}
