using MaterialSkin;
using MaterialSkin.Controls;
using MetroFramework.Forms;
using OM.PP.XingApp.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XA_SESSIONLib;

namespace OM.PP.XingApp
{
    public partial class XingAppFormTest : MetroForm
    {
        public XingAppFormTest()
        {
            InitializeComponent();            
            Control.CheckForIllegalCrossThreadCalls = false;
            this.Load += XingAppForm_Load;
        }

        private void XingAppForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        void LogWrite(string log)
        {
            if (tbLog.InvokeRequired)
            {
                tbLog.Invoke(new MethodInvoker(() =>
                {
                    tbLog.AppendText(log);
                    tbLog.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                tbLog.AppendText(log);
                tbLog.AppendText(Environment.NewLine);
            }
        }
    }
}
