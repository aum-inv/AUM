
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Atman.Chakra.App.PlanForms
{
    public partial class StrategyPlanHtmlCreationForm : Form
    {
        public StrategyPlanHtmlCreationForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Load += StrategyPlanHtmlCreationForm_Load;
        }

        private void StrategyPlanHtmlCreationForm_Load(object sender, EventArgs e)
        {
            var filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "HtmlTemplate", "plan_01.html");

            htmlCtr.OpenFile(filePath);
        }
    }
}
