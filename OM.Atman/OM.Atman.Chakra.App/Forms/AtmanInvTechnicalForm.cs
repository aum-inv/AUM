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
    public partial class AtmanInvTechnicalForm : MetroFramework.Forms.MetroForm
    {
     
        public AtmanInvTechnicalForm()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {       
        }
        private void InitializeEvents()
        {
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            int checkCnt = 0;
            int totalPoint = 0;
            techincalCalculator("1", out checkCnt, out totalPoint);
            tbS1.Text = checkCnt.ToString();
            tbT1.Text = totalPoint.ToString();

            techincalCalculator("2", out checkCnt, out totalPoint);
            tbS2.Text = checkCnt.ToString();
            tbT2.Text = totalPoint.ToString();

            techincalCalculator("3", out checkCnt, out totalPoint);
            tbS3.Text = checkCnt.ToString();
            tbT3.Text = totalPoint.ToString();

            techincalCalculator("4", out checkCnt, out totalPoint);
            tbS4.Text = checkCnt.ToString();
            tbT4.Text = totalPoint.ToString();

            techincalCalculator("5", out checkCnt, out totalPoint);
            tbS5.Text = checkCnt.ToString();
            tbT5.Text = totalPoint.ToString();

            techincalCalculator("6", out checkCnt, out totalPoint);
            tbS6.Text = checkCnt.ToString();
            tbT6.Text = totalPoint.ToString();
        }

        private void techincalCalculator(string pointIndex, out int checkCnt, out int totalPoint)
        {
            checkCnt = 0;
            totalPoint = 0;
            foreach (var c in metroPanel2.Controls)
            { 
                if(c is MetroCheckBox) 
                {
                    var chk = c as MetroCheckBox;

                    if (chk.Name.EndsWith(pointIndex))
                    {
                        if (chk.Checked)
                        {
                            checkCnt++;
                            totalPoint += Convert.ToInt32(chk.Tag);
                        }
                    }
                }
            }
        }
    }
}
