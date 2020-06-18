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
                if (tbPwd.Text == "qawsedrf")
                {
                    if (rdoType1.Checked) SharedData.SelectedType = "1";
                    if (rdoType2.Checked) SharedData.SelectedType = "2";

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void tbPwd_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
