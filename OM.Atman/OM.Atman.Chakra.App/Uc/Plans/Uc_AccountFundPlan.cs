using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace OM.Atman.Chakra.App.Uc.Plans
{
    public partial class Uc_AccountFundPlan : Uc_PlanBase
    {
        public Uc_AccountFundPlan()
        {
            InitializeComponent();
        }

        private void UrlLink_Click(object sender, EventArgs e)
        {
            MetroButton metroLink = sender as MetroButton;
            UrlLinkClick(metroLink.Tag.ToString());
        }
    }
}
