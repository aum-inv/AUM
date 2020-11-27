using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Mantra.Chakra.App
{
    public partial class LoginForm : MaterialForm
    {
        public string LoginType
        {
            get;
            set;
        } = "";
        public LoginForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {             
        }
        private void tbPwd_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   
            if (tbID.Text == "ID")
            {             
                LoginType = (sender as Button).Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Close();
            }
        }

    }
}
