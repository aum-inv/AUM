using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Atman.Chakra.App.Uc
{
    public partial class Uc_ListItem : UserControl
    {
        public Uc_ListItem()
        {
            InitializeComponent();
        }

        private void mouseEnterLeave(bool isEnter)
        { 
            if(isEnter) pnlBottom.BackColor = Color.DarkOrange;
            else pnlBottom.BackColor = Color.OldLace;
        }

        private void item_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterLeave(true);
        }

        private void item_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterLeave(false);
        }

        private void item_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
