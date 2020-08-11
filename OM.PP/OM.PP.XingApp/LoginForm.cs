using MaterialSkin;
using MetroFramework;
using MetroFramework.Forms;
using OM.PP.XingApp.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.PP.XingApp
{
    public partial class LoginForm : MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();

            //MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            
            // Configure color schema
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Blue400, Primary.Blue500,
            //    Primary.Blue500, Accent.LightBlue200,
            //    TextShade.WHITE
            //);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbID.Text.Length == 0) 
            {
                MessageBox.Show("접속아이디 입력해주세요");
                return;
            }
            if (tbPassword.Text.Length == 0)
            {
                MessageBox.Show("접속패스워드 입력해주세요");
                return;
            }
            if (tbAuth.Text.Length == 0)
            {
                MessageBox.Show("인증서비밀번호 입력해주세요");
                return;
            }

            if (tbSecurity.Text == "atman999")
            {
                AccountInfoLEE.접속아이디 = tbID.Text;
                AccountInfoLEE.접속비밀번호 = tbPassword.Text;
                AccountInfoLEE.인증비밀번호 = tbAuth.Text;

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbSecurity.Text == "^__^")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
