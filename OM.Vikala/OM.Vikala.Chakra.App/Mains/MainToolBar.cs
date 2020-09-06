using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
   
    public partial class MainToolBar : Form
    {
        public MainToolBar()
        {
            InitializeComponent();
            this.Load += MainToolBar_Load;
        }

        private void MainToolBar_Load(object sender, EventArgs e)
        {
            dockWindow("Left");
        }

        private void toolbarDock_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = sender as ToolStripButton;
            dockWindow(btn.ToolTipText);
        }

        private void dockWindow(string direction)
        {           
            var workingArea = Screen.FromHandle(Handle).WorkingArea;
            int minHW = 35;
            if (direction == "Left")
            {
                this.Location = new Point(0, 0);
                this.Width = minHW;
                this.Height = workingArea.Height;
                this.tsMain.Dock = DockStyle.Left;
            }
            else if (direction == "Right")
            {
                this.Location = new Point(workingArea.Width - minHW, 0);
                this.Width = minHW;
                this.Height = workingArea.Height;
                this.tsMain.Dock = DockStyle.Left;
            }
            else if (direction == "Top")
            {
                minHW += 5;
                this.Location = new Point(0, 0);
                this.Height = minHW;
                this.Width = workingArea.Width;
                this.tsMain.Dock = DockStyle.Top;
            }
            else if (direction == "Bottom")
            {
                minHW += 5;
                this.Location = new Point(0, workingArea.Height - minHW);
                this.Height = minHW;
                this.Width = workingArea.Width;
                this.tsMain.Dock = DockStyle.Top;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
