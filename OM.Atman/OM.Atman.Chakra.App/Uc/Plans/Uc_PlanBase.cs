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
    public partial class Uc_PlanBase : UserControl
    {
        public string PlanID
        { 
            get;
            set;
        }
        public Uc_PlanBase()
        {
            InitializeComponent();
        }

        public void UrlLinkClick(string url)
        {
            if (string.IsNullOrEmpty(url)) return;
           
            // open in default browser
            //System.Diagnostics.Process.Start("http://www.stackoverflow.net");

            // open in Internet Explorer
            //System.Diagnostics.Process.Start("iexplore", @"http://www.stackoverflow.net/");

            // open in Firefox
            //System.Diagnostics.Process.Start("firefox", @"http://www.stackoverflow.net/");

            // open in Google Chrome
            System.Diagnostics.Process.Start("chrome", url);
            
        }
    }
}
