using OM.Lib.Entity;
using OM.Lib.Framework.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Mantra.Chakra.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbxItem.SelectedIndex = 7;

            btnLoad.PerformClick();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            MantraHistory mantra = new MantraHistory();
            mantra.Item = cbxItem.SelectedItem.ToString();

            if (mantra.Item == "ALL") mantra.Item = "";

            Entities entities = (Entities)mantra.Collect();
            foreach (var m in entities.Cast<MantraHistory>())
            {
                var uc = new uc_MantraHistory();
                uc.BindItem(m);
                uc.Dock = DockStyle.Top;

                pnlContent.Controls.Add(uc);
            }

            if (entities.Count == 0)
            {
                var uc = new uc_MantraHistory();
                uc.BindItem(new MantraHistory());
                uc.Dock = DockStyle.Top;
                pnlContent.Controls.Add(uc);
            }
        }
    }
}
