using OM.Lib.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace OM.Atman.Chakra.App.TradingRule
{
    public partial class ThreeFiveRuleForm : Form
    {
        bool isStartTotal = false;
        bool isStart1 = false;
        bool isStart2 = false;
        bool isStart3 = false;

        string itemCode = "CL";
        int quantity = 0;

        ConcurrentQueue<CurrentPrice> currentPrices = new ConcurrentQueue<CurrentPrice>();

        ThreeFiveTradingRule rule1 = new ThreeFiveTradingRule();
        ThreeFiveTradingRule rule2 = new ThreeFiveTradingRule();
        ThreeFiveTradingRule rule3 = new ThreeFiveTradingRule();

        public ThreeFiveRuleForm()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeVariables();
            InitializeControls();
            InitializeThread();
        }

        private void InitializeEvents()
        {
            this.FormClosing += ThreeFiveRuleForm_FormClosing;
            SiseEvents.Instance.SiseHandler += Instance_SiseHandler;

            rule1.ThreeFiveTradingRuleMsgHandler += Rule1_ThreeFiveTradingRuleMsgHandler; 
            rule2.ThreeFiveTradingRuleMsgHandler += Rule2_ThreeFiveTradingRuleMsgHandler;
            rule3.ThreeFiveTradingRuleMsgHandler += Rule3_ThreeFiveTradingRuleMsgHandler;


        }

        
        private void InitializeThread()
        {
            System.Threading.Thread tCL = new System.Threading.Thread(new System.Threading.ThreadStart(Run));
            tCL.Start();
        }

        private void InitializeVariables()
        {
            isStartTotal = false;
            isStart1 = false;
            isStart2 = false;
            isStart3 = false;

            rule1.ItemCode = rule1.ItemCode = rule3.ItemCode = itemCode;
        }

        private void InitializeControls()
        {
            abtnStartStop.Text = "START";
            pcState.Spin = isStartTotal;
        }

        #region Custom Events
        private void ThreeFiveRuleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isStartTotal = false;
            isStart1 = false;
            isStart2 = false;
            isStart3 = false;
            SiseEvents.Instance.SiseHandler -= Instance_SiseHandler;

            rule1.Close();
            rule2.Close();
            rule3.Close();
        }
        private void Instance_SiseHandler(string itemCode, CurrentPrice price)
        {
            try
            {
                tbOrderPrice.Text = price.price;
                currentPrices.Enqueue(price);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void Rule1_ThreeFiveTradingRuleMsgHandler(string msg)
        {
            this.Invoke(new Action(() =>
            {
                aslblState1.Text = msg;
                tbLog1.AppendText($"{DateTime.Now.ToShortTimeString()} -> {msg}");
                tbLog1.AppendText(Environment.NewLine);
                ShowNotifyIcon("천인 메시지", msg);
            }));
        }
        private void Rule2_ThreeFiveTradingRuleMsgHandler(string msg)
        {
            this.Invoke(new Action(() =>
            {
                aslblState2.Text = msg;
                tbLog2.AppendText($"{DateTime.Now.ToShortTimeString()} -> {msg}");
                tbLog2.AppendText(Environment.NewLine);
                ShowNotifyIcon("지인 메시지", msg);
            }));
        }
        private void Rule3_ThreeFiveTradingRuleMsgHandler(string msg)
        {
            this.Invoke(new Action(() =>
            {
                aslblState3.Text = msg;
                tbLog3.AppendText($"{DateTime.Now.ToShortTimeString()} -> {msg}");
                tbLog3.AppendText(Environment.NewLine);

                ShowNotifyIcon("인인 메시지", msg);
            }));
        }
        private void ShowNotifyIcon(string title, string message)
        {
            
            try
            {
                PopupNotifier popup = new PopupNotifier();
                popup.ShowGrip = true;
                if (title.StartsWith("천인"))
                {
                    popup.HeaderColor = Color.DarkRed;
                    popup.BodyColor = Color.DarkBlue;
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.WhiteSmoke;
                }
                if (title.StartsWith("지인"))
                {
                    popup.HeaderColor = Color.DarkBlue;
                    popup.BodyColor = Color.DarkRed;
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.WhiteSmoke;
                }
                if (title.StartsWith("인인"))
                {
                    popup.HeaderColor = Color.DarkMagenta;
                    popup.BodyColor = Color.DarkGreen;
                    popup.TitleColor = Color.White;
                    popup.ContentColor = Color.WhiteSmoke;
                }

                popup.TitleFont = new Font("고딕", 24.0f);
                popup.ContentFont = new Font("굴림", 12.0f);
                popup.TitleText = title;
                popup.ContentText = message;
                popup.Image = global::OM.Atman.Chakra.App.Properties.Resources.signal;
                popup.ImageSize = new Size(50, 40);
                popup.Delay = 1000 * 60;
                popup.Popup();// show  

                var player = new System.Media.SoundPlayer();
                player.Stream = Properties.Resources.money;
                player.Play();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Thread Method
        private void Run()
        {
            
            while (isStartTotal)
            {
                try
                {
                    var priceQueue = currentPrices;
                    if (priceQueue.Count == 0)
                    {
                        System.Threading.Thread.Sleep(10);
                        continue;
                    }
                    CurrentPrice price;
                    var isDequeue = priceQueue.TryDequeue(out price);
                    if (isDequeue)
                    {
                        if (isStart1) analysis1(price);
                        if (isStart2) analysis2(price);
                        if (isStart3) analysis3(price);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region Controls Events
        private void abtnStartStop_Click(object sender, EventArgs e)
        {
            isStartTotal = !isStartTotal;

            if(isStartTotal) abtnStartStop.Text = "STOP";
            else abtnStartStop.Text = "START";

            pcState.Spin = isStartTotal;
        }
        private void tbItem_TextChanged(object sender, EventArgs e)
        {
            if (tbItem.Text.Length == 0) return;
            itemCode = tbItem.Text;
            rule1.ItemCode = rule1.ItemCode = rule3.ItemCode = itemCode;
        }

        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            if (tbQty.Text.Length == 0) return;
            quantity = Convert.ToInt32(tbQty.Text);
        }
        private void sbOnOff1_SliderValueChanged(object sender, EventArgs e)
        {
            isStart1 = sbOnOff1.IsOn;
        }
        private void sbOnOff2_SliderValueChanged(object sender, EventArgs e)
        {
            isStart2 = sbOnOff2.IsOn;
        }
        private void sbOnOff3_SliderValueChanged(object sender, EventArgs e)
        {
            isStart3 = sbOnOff3.IsOn;
        }
        private void abSet1_Click(object sender, EventArgs e)
        {
            rule1.PositionType = rdoPosition11.Checked ? "매도" : "매수";
            rule1.CharType = rdoChar11.Checked ? "안정형" : "공격형";
            rule1.BalancePrice = Convert.ToDouble(tbBalance1.Text);
            rule1.RangeValue = Convert.ToDouble(tbRange1.Text);
            rule1.InitRule();

            tbRangePrice11.Text = rule1.Direction1Value.ToString();
            tbRangePrice12.Text = rule1.Direction2Value.ToString();
            tbRangePrice13.Text = rule1.Direction3Value.ToString();
            tbRangePrice14.Text = rule1.Direction4Value.ToString();
            tbRangePrice15.Text = rule1.Direction5Value.ToString();
        }

        private void abSet2_Click(object sender, EventArgs e)
        {
            rule2.PositionType = rdoPosition21.Checked ? "매도" : "매수";
            rule2.CharType = rdoChar21.Checked ? "안정형" : "공격형";
            rule2.BalancePrice = Convert.ToDouble(tbBalance2.Text);
            rule2.RangeValue = Convert.ToDouble(tbRange2.Text);
            rule2.InitRule();

            tbRangePrice21.Text = rule2.Direction1Value.ToString();
            tbRangePrice22.Text = rule2.Direction2Value.ToString();
            tbRangePrice23.Text = rule2.Direction3Value.ToString();
            tbRangePrice24.Text = rule2.Direction4Value.ToString();
            tbRangePrice25.Text = rule2.Direction5Value.ToString();
        }

        private void abSet3_Click(object sender, EventArgs e)
        {
            rule3.PositionType = rdoPosition31.Checked ? "매도" : "매수";
            rule3.CharType = rdoChar31.Checked ? "안정형" : "공격형";
            rule3.BalancePrice = Convert.ToDouble(tbBalance3.Text);
            rule3.RangeValue = Convert.ToDouble(tbRange3.Text);
            rule3.InitRule();

            tbRangePrice31.Text = rule3.Direction1Value.ToString();
            tbRangePrice32.Text = rule3.Direction2Value.ToString();
            tbRangePrice33.Text = rule3.Direction3Value.ToString();
            tbRangePrice34.Text = rule3.Direction4Value.ToString();
            tbRangePrice35.Text = rule3.Direction5Value.ToString();
        }
        #endregion

        #region Analysis
        private void analysis1(CurrentPrice cprice)
        {
            try
            {
                rule1.Analysis(cprice);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void analysis2(CurrentPrice cprice)
        {
            try
            {
                rule2.Analysis(cprice);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void analysis3(CurrentPrice cprice)
        {
            try
            {
                rule3.Analysis(cprice);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        #endregion
    }
}
