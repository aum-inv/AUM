using OM.Atman.Chakra.App.Config;
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
                if (chkPlanResult.Checked) ShareConfig.LaunchFormType = 1;
                else if (chkSignalMatching.Checked) ShareConfig.LaunchFormType = 2;
                else if (chkSignalComplication.Checked) ShareConfig.LaunchFormType = 3;
                else if (chkDiary.Checked) ShareConfig.LaunchFormType = 4;
                else if (chkRealBoard.Checked) ShareConfig.LaunchFormType = 9;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
