using MaterialSkin;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.PP.Chakra.App
{
    public partial class AppMain : Form
    {
        public AppMain()
        {
            InitializeComponent();
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

        private void serverInfo()
        {
            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);          
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                serverInfo();

                PPContext.Instance.StartServer();

                LogWrite("*********서비스 실행되었습니다.*********");
             
                lblConnect.Visible = true;

                btnStart.Enabled = false;

                PPStorage.Instance.Init("CL");
                PPStorage.Instance.Init("NG");
                PPStorage.Instance.Init("GC");
                PPStorage.Instance.Init("SI");
                PPStorage.Instance.Init("HMH");
                PPStorage.Instance.Init("NQ"); 
                PPStorage.Instance.Init("URO"                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               );
                PPStorage.Instance.Init("ES");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }
    }
}
