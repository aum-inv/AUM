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
using static MetroFramework.Controls.MetroTextBox;

namespace OM.Atman.Chakra.App.Uc.Plans
{
    public partial class Uc_InvAvailability : Uc_PlanBase
    {
        public Uc_InvAvailability()
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
            tbUncertaintyKp.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyFx.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyUs.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyEu.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyCn.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixUs.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixEu.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixCn.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };

            btnRef1.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef2.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef3.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef4.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef5.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef6.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef7.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };           
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
