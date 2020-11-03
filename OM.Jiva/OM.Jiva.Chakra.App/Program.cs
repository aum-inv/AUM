using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
namespace OM.Jiva.Chakra.App
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm login_form = new LoginForm();
            if (login_form.ShowDialog() == DialogResult.OK)
            {
                if (login_form.LoginType == "Create")
                    Application.Run(new JivaCreateForm());               
                else if (login_form.LoginType == "Analysis")
                    Application.Run(new JivaAnalysisForm());
            }
        }
    }
}
