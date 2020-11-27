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
    public partial class MantraForm : MetroFramework.Forms.MetroForm
    {
        public MantraForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new MantraInputForm().Show();
        }
    }
}
