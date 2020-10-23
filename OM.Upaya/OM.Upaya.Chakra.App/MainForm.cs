using OM.Lib.Base;
using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.Lib.Framework.Db;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Upaya.Chakra.Ctx;
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

namespace OM.Upaya.Chakra.App
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        Dictionary<string, Label> lblPrice = new Dictionary<string, Label>();
        Dictionary<string, Label> lblUpDown = new Dictionary<string, Label>();
        Dictionary<string, Label> lblDiff = new Dictionary<string, Label>();
        Dictionary<string, Label> lblRate = new Dictionary<string, Label>();

        bool isRun = true;
        bool isRunKr = true;
        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnStart.PerformClick();
        }

        private void InitializeControls()
        {
            lblPrice.Add("CL", lblPriceCL);
            lblPrice.Add("NG", lblPriceNG);
            lblPrice.Add("GC", lblPriceGC);
            lblPrice.Add("SI", lblPriceSI);
            lblPrice.Add("HMH", lblPriceHSI);
            lblPrice.Add("NQ", lblPriceNQ);
            lblPrice.Add("URO", lblPriceURO);
            lblPrice.Add("ES", lblPriceES);
            lblPrice.Add("001", lblPrice001);
            lblPrice.Add("101", lblPrice101);
            lblPrice.Add("301", lblPrice301);


            lblUpDown.Add("CL", lblUpDownCL);
            lblUpDown.Add("NG", lblUpDownNG);
            lblUpDown.Add("GC", lblUpDownGC);
            lblUpDown.Add("SI", lblUpDownSI);
            lblUpDown.Add("HMH", lblUpDownHSI);
            lblUpDown.Add("NQ", lblUpDownNQ);
            lblUpDown.Add("URO", lblUpDownURO);
            lblUpDown.Add("ES", lblUpDownES);
            lblUpDown.Add("001", lblUpDown001);
            lblUpDown.Add("101", lblUpDown101);
            lblUpDown.Add("301", lblUpDown301);

            lblDiff.Add("CL", lblDiffCL);
            lblDiff.Add("NG", lblDiffNG);
            lblDiff.Add("GC", lblDiffGC);
            lblDiff.Add("SI", lblDiffSI);
            lblDiff.Add("HMH", lblDiffHSI);
            lblDiff.Add("NQ", lblDiffNQ);
            lblDiff.Add("URO", lblDiffURO);
            lblDiff.Add("ES", lblDiffES); 
            lblDiff.Add("001", lblDiff001);
            lblDiff.Add("101", lblDiff101);
            lblDiff.Add("301", lblDiff301);

            lblRate.Add("CL", lblRateCL);
            lblRate.Add("NG", lblRateNG);
            lblRate.Add("GC", lblRateGC);
            lblRate.Add("SI", lblRateSI);
            lblRate.Add("HMH", lblRateHSI);
            lblRate.Add("NQ", lblRateNQ);
            lblRate.Add("URO", lblRateURO);
            lblRate.Add("ES", lblRateES);
            lblRate.Add("001", lblRate001);
            lblRate.Add("101", lblRate101);
            lblRate.Add("301", lblRate301);
        }
        private void serverInfo()
        {
            UpayaServerConfigData.IP = ConfigurationManager.AppSettings["UpayaService_IP"];
            UpayaServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["UpayaService_Port"]);

            XingServerConfigData.IP = ConfigurationManager.AppSettings["XingService_IP"];
            XingServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["XingService_Port"]);
            XingContext.Instance.OnCreateClient();

            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);
            PPContext.Instance.OnCreateClient();
        }

       
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = isRunKr = false;
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                serverInfo();

                UpayaContext.Instance.StartServer();

                btnStart.Enabled = false;

                InitThread();
                InitThreadKr();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void BindSise(string itemCode, CurrentPrice current)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                try
                {
                    lblPrice[itemCode].Text = current.price;
                    lblDiff[itemCode].Text = current.change;
                    lblRate[itemCode].Text = current.drate + "%";

                    if (current.sign == "1" || current.sign == "2")
                    {
                        lblUpDown[itemCode].Text = "▲";
                        lblPrice[itemCode].ForeColor = Color.Red;
                        lblUpDown[itemCode].ForeColor = Color.Red;
                        lblDiff[itemCode].ForeColor = Color.Red;
                        lblRate[itemCode].ForeColor = Color.Red;
                    }
                    else if (current.sign == "4" || current.sign == "5")
                    {
                        lblUpDown[itemCode].Text = "▼";
                        lblPrice[itemCode].ForeColor = Color.Blue;
                        lblUpDown[itemCode].ForeColor = Color.Blue;
                        lblDiff[itemCode].ForeColor = Color.Blue;
                        lblRate[itemCode].ForeColor = Color.Blue;
                    }
                    else
                    {
                        lblUpDown[itemCode].Text = "-";
                        lblPrice[itemCode].ForeColor = Color.White;
                        lblUpDown[itemCode].ForeColor = Color.White;
                        lblDiff[itemCode].ForeColor = Color.White;
                        lblRate[itemCode].ForeColor = Color.White;
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }));
        }
               
        private void InitThread()
        {
            System.Threading.Thread tCL =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tCL.Start("CL");
            
            System.Threading.Thread tNG =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tNG.Start("NG");

            System.Threading.Thread tGC =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tGC.Start("GC");

            System.Threading.Thread tSI =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tSI.Start("SI");

            System.Threading.Thread tHSI =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tHSI.Start("HMH");
            
            System.Threading.Thread tNQ =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tNQ.Start("NQ");

            System.Threading.Thread tURO =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tURO.Start("URO");

            System.Threading.Thread tES =
              new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Run));
            tES.Start("ES");
        }
        private void InitThreadKr()
        {
            System.Threading.Thread t001 =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(RunKr));
            t001.Start("001");

            System.Threading.Thread t101 =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(RunKr));
            t101.Start("101");

            System.Threading.Thread t301 =
                new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(RunKr));
            t301.Start("301");
        }
        bool isSiseBinding = true;
        private void Run(object o)
        {
            string itemCode = (string)o;

            string lastPrice = "";

            LimitedList<double> ll3 = new LimitedList<double>(3);
            LimitedList<double> ll5 = new LimitedList<double>(5);
            LimitedList<double> ll7 = new LimitedList<double>(7);

            int rnd = ItemCodeSet.GetItemRoundNum(itemCode);

            while (isRun)
            {
                try
                {
                    if (!SiseStorage.Instance.Prices.ContainsKey(itemCode))
                    {
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }

                    var priceQueue = SiseStorage.Instance.Prices[itemCode];

                    if (priceQueue.Count == 0)
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    CurrentPrice price;
                    var isDequeue = priceQueue.TryDequeue(out price);
                    if (isDequeue)
                    {
                        if (lastPrice == price.price) continue;
                        lastPrice = price.price;
                        double d = Math.Round(Convert.ToDouble(lastPrice), rnd);

                        if (!ll3.Contains(d)) ll3.Insert(d);
                        if (!ll5.Contains(d)) ll5.Insert(d);
                        if (!ll7.Contains(d)) ll7.Insert(d);

                        price.price3 = Math.Round(ll3.Average(), rnd);
                        price.price5 = Math.Round(ll5.Average(), rnd);
                        price.price7 = Math.Round(ll7.Average(), rnd);

                        SiseEvents.Instance.OnSiseHandler(itemCode, price);

                        if (isSiseBinding)
                        {
                            BindSise(itemCode, price);
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
        }

        private void RunKr(object o)
        {
            string itemCode = (string)o;

            string lastPrice = "";

            LimitedList<double> ll3 = new LimitedList<double>(3);
            LimitedList<double> ll5 = new LimitedList<double>(5);
            LimitedList<double> ll7 = new LimitedList<double>(7);

            int rnd = ItemCodeSet.GetItemRoundNum(itemCode);

            while (isRunKr)
            {
                try
                {
                    if (!SiseStorage.Instance.PricesKr.ContainsKey(itemCode))
                    {
                        System.Threading.Thread.Sleep(1000);
                        continue;
                    }

                    var priceQueue = SiseStorage.Instance.PricesKr[itemCode];

                    if (priceQueue.Count == 0)
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    CurrentPrice price;
                    var isDequeue = priceQueue.TryDequeue(out price);
                    if (isDequeue)
                    {
                        if (lastPrice == price.price) continue;
                        lastPrice = price.price;
                        double d = Math.Round(Convert.ToDouble(lastPrice), rnd);

                        if (!ll3.Contains(d)) ll3.Insert(d);
                        if (!ll5.Contains(d)) ll5.Insert(d);
                        if (!ll7.Contains(d)) ll7.Insert(d);

                        price.price3 = Math.Round(ll3.Average(), rnd);
                        price.price5 = Math.Round(ll5.Average(), rnd);
                        price.price7 = Math.Round(ll7.Average(), rnd);

                        SiseEvents.Instance.OnSiseHandler(itemCode, price);

                        if (isSiseBinding)
                        {
                            BindSise(itemCode, price);
                        }
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
            }
        }

        private void chkSise_CheckedChanged(object sender, EventArgs e)
        {
            isSiseBinding = chkSise.Checked;

            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }
    }
}
