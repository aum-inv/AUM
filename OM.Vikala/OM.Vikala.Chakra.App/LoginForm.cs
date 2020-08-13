using OM.Vikala.Chakra.App.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {   
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
        private void tbPwd_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {           
            if (tbPwd.Text == "atman999")
            {
                SharedData.SelectedType = "KR";                
                SharedData.SecurityType = "1";

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnLogin2_Click(object sender, EventArgs e)
        {
            if (tbPwd.Text == "atman999")
            {
                SharedData.SelectedType = "US";               
                SharedData.SecurityType = "1";

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
