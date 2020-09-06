using OM.Atman.Chakra.App.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Atman.Chakra.App
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
                if(ShareConfig.LaunchFormType == 1)
                    Application.Run(new Forms.AtmanKospiForm());
                else if (ShareConfig.LaunchFormType == 2)
                    Application.Run(new AIForms.AtmanKospiAIForm());
                else if (ShareConfig.LaunchFormType == 3)
                    Application.Run(new TradingRule.ThreeFiveRuleForm());
                else if (ShareConfig.LaunchFormType == 4)
                    Application.Run(new Forms.AtmanInvDiaryForm());
            }

            //Application.Run(new LoginForm());
        }
    }
}
