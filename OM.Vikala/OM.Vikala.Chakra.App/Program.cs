using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyTabs;
using OM.Vikala.Chakra.App.Config;
using OM.Vikala.Chakra.App.Mains;

namespace OM.Vikala.Chakra.App
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
                if(SharedData.StartWindowType == "1")
                    Application.Run(new Mains.MainForm());

                else if (SharedData.StartWindowType == "2")
                    Application.Run(new Mains.MainToolBar());

                else if (SharedData.StartWindowType == "3")
                    Application.Run(new Mains.MainToolBar());

                else if (SharedData.StartWindowType == "4")
                    Application.Run(new Mains.MainToolBar());
            }
        }
    }
}
