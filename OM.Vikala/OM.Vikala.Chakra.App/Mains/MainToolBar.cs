using MaterialSkin.Controls;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

            serverInfo();
        }
        private void serverInfo()
        {
            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);
            PPContext.Instance.OnCreateClient();
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

        private void tsb_Atom_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.AtomChartForm();
            f.Text = "ATMAN INV. F ATOM CHART";
            f.Show();
        }

        private void tsb_Quantum_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.QuantumChartHLForm();
            f.Text = "ATMAN INV. F QUANTUM CHART";
            f.Show();
        }

        private void tsb_Velocity_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.VelocityChartForm();
            f.Text = "ATMAN INV. F VELOCITY CHART";
            f.Show();
        }

        private void tsb_AntiMatter_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.AntiMatterChartForm();
            f.Text = "ATMAN INV. F ANTIMATTER CHART";
            f.Show();
        }

        private void tsb_Dice_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.DiceChartForm();
            f.Text = "ATMAN INV. F DICE CHART";
            f.Show();
        }

        private void tsb_ANode_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.ANodeLineChartForm();
            f.Text = "ATMAN INV. F ANODE CHART";
            f.Show();
        }

        private void tsb_TimeSpace_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.ComparedCandleChartForm();
            f.Text = "ATMAN INV. F TIMESPACE CHART";
            f.Show();
        }


        private void tsb_SY_3_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageDurationChartForm(true, 3);
            f.Text = "ATMAN INV. F MOVING AVERAGE DURATION CHART";
            f.Show();
        }

        private void tsb_SY_2_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageDurationChartForm(true, 2);
            f.Text = "ATMAN INV. F MOVING AVERAGE DURATION CHART";
            f.Show();
        }

        private void tsb_SN_3_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageDurationChartForm(false, 3);
            f.Text = "ATMAN INV. F MOVING AVERAGE DURATION CHART";
            f.Show();
        }

        private void tsb_SN_2_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageDurationChartForm(false, 2);
            f.Text = "ATMAN INV. F MOVING AVERAGE DURATION CHART";
            f.Show();
        }

        private void tsb_MA1_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageFlowChartForm(Lib.Base.Enums.TimeIntervalEnum.Minute_10);
            f.Text = "ATMAN INV. F MOVING AVERAGE FLOW(M) CHART";
            f.Show();
        }

        private void tsb_MA2_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageFlowChartForm(Lib.Base.Enums.TimeIntervalEnum.Hour_01);
            f.Text = "ATMAN INV. F MOVING AVERAGE FLOW(H) CHART";
            f.Show();
        }

        private void tsb_MA3_Click(object sender, EventArgs e)
        {
            var f = new ToolbarChartForms.MovingAverageFlowChartForm(Lib.Base.Enums.TimeIntervalEnum.Day);
            f.Text = "ATMAN INV. F MOVING AVERAGE FLOW(D) CHART";
            f.Show();
        }

        //List<Form> lstWindows = new List<Form>();
        //private void tsbArrange_Click(object sender, EventArgs e)
        //{
        //    if (lstWindows.Count == 0) return;

        //    int rows = 2;
        //    int cols = 2;
        //    // Get the form's location and dimensions.
        //    int screen_top = Screen.PrimaryScreen.WorkingArea.Top;
        //    int screen_left = Screen.PrimaryScreen.WorkingArea.Left;
        //    int screen_width = Screen.PrimaryScreen.WorkingArea.Width;
        //    int screen_height = Screen.PrimaryScreen.WorkingArea.Height;

        //    // See how big the windows should be.
        //    int window_width = (int)(screen_width / cols);
        //    int window_height = (int)(screen_height / rows);

        //    // Position the windows.
        //    int window_num = 0;
        //    int y = screen_top;
        //    for (int row = 0; row < rows; row++)
        //    {
        //        int x = screen_left;
        //        for (int col = 0; col < cols; col++, window_num++)
        //        {
        //            var form = lstWindows[window_num];

        //            if (window_num >= lstWindows.Count)
        //            {
        //                form.WindowState = FormWindowState.Minimized;
        //                continue;
        //            }
        //            form.Size = new Size(window_width, window_height);
        //            form.Location = new Point(x, y);
        //            x += window_width;
        //        }
        //        y += window_height;
        //    }
        //}

        //private void tsb_Minimize_Click(object sender, EventArgs e)
        //{
        //    foreach (var f in lstWindows)
        //        f.WindowState = FormWindowState.Minimized;
        //}

        //private void tsb_Maximize_Click(object sender, EventArgs e)
        //{
        //    foreach (var f in lstWindows)
        //        f.WindowState = FormWindowState.Maximized;
        //}

        //private void tsb_Normalize_Click(object sender, EventArgs e)
        //{
        //    foreach (var f in lstWindows)
        //        f.WindowState = FormWindowState.Normal;
        //}

        //private void tsb_CloseForm_Click(object sender, EventArgs e)
        //{
        //    foreach (var f in lstWindows)
        //        f.Close();

        //    lstWindows.Clear();
        //}

    }
}
