using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

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
                Button btn = sender as Button;

                SharedData.SelectedType = btn.Text;              
                
                SharedData.SecurityType = "1";

                SharedData.StartWindowType = chkStartWindowType.Checked ? "2" : "1";
                    
                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

    }
}
