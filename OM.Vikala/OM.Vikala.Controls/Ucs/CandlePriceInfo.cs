using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.PP.Chakra;
using OM.Lib.Base.Utils;

namespace OM.Vikala.Controls.Ucs
{
    public partial class CandlePriceInfo : UserControl
    {
        List<Label> labels = new List<Label>();
        List<TextBox> textBoxes = new List<TextBox>();

        public CandlePriceInfo()
        {
            InitializeComponent();
            InitControls();
        }

        private void InitControls()
        {
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);

            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);
            textBoxes.Add(textBox5);
            textBoxes.Add(textBox6);
            textBoxes.Add(textBox7);
            textBoxes.Add(textBox8);
            textBoxes.Add(textBox9);
            textBoxes.Add(textBox10);
            textBoxes.Add(textBox11);
            textBoxes.Add(textBox12);
        }

        public void Bind(A_HLOC hloc,  int type = 0)
        {
            lblTime.Text = hloc.DTime.ToString("yyyy-MM-dd HH:mm");

            Dictionary<string, float> abc = new Dictionary<string, float>();

            abc.Add("시가", hloc.OpenPrice);
            abc.Add("고가", hloc.HighPrice);
            abc.Add("저가", hloc.LowPrice);
            abc.Add("종가", hloc.ClosePrice);

            abc.Add("중앙가", hloc.CenterPrice);
            abc.Add("중심가", hloc.MiddlePrice);
            abc.Add("양중앙가", hloc.QuantumCenterPrice);
            abc.Add("양중심가", hloc.QuantumMiddlePrice);

            abc.Add("양고가", hloc.QuantumHighPrice);
            abc.Add("양저가", hloc.QuantumLowPrice);
            abc.Add("양종가", hloc.QuantumPrice);

            abc.Add("질량가", hloc.MassPrice);

            double h1 = abc["양고가"] > abc["고가"] ? abc["양고가"] : abc["고가"];
            double l1 = abc["양저가"] < abc["저가"] ? abc["양저가"] : abc["저가"];
            lblMaxMin.Text = Math.Round(Math.Abs(h1 - l1), hloc.RoundLength).ToString() 
                + " / " 
                + PriceTick.GetTickDiff(hloc.ItemCode, h1, l1).ToString();

            double h2 = abc["고가"];
            double l2 = abc["저가"];
            lblHighLow.Text = Math.Round(Math.Abs(h2 - l2), hloc.RoundLength).ToString()
                + " / "
                + PriceTick.GetTickDiff(hloc.ItemCode, h2, l2).ToString();

            lblMiddle.Text = Math.Round(Math.Abs(abc["양중심가"] - abc["중심가"]), hloc.RoundLength).ToString()
                + " / "
                + PriceTick.GetTickDiff(hloc.ItemCode, abc["양중심가"], abc["중심가"]).ToString();

            lblCenter.Text = Math.Round(Math.Abs(abc["양중앙가"] - abc["중앙가"]), hloc.RoundLength).ToString()
                + " / "
                + PriceTick.GetTickDiff(hloc.ItemCode, abc["양중앙가"], abc["중앙가"]).ToString();

            lblMassClose.Text = Math.Round(Math.Abs(abc["질량가"] - abc["종가"]), hloc.RoundLength).ToString()
                + " / "
                + PriceTick.GetTickDiff(hloc.ItemCode, abc["질량가"], abc["종가"]).ToString();

            lblMassQClose.Text = Math.Round(Math.Abs(abc["질량가"] - abc["양종가"]), hloc.RoundLength).ToString()
                + " / "
                + PriceTick.GetTickDiff(hloc.ItemCode, abc["질량가"], abc["양종가"]).ToString();
            
            int idx = 0;
            foreach (var m in abc.OrderByDescending(t => t.Value))
            {
                textBoxes[idx].ForeColor = labels[idx].ForeColor = SystemColors.ControlText;
                
                labels[idx].Text = m.Key;

                if (type == 0)
                {
                    if (m.Key == "양종가" || m.Key == "양중앙가" || m.Key == "양중심가")
                    {
                        if (hloc.ClosePrice < hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Red;
                        }

                        else if (hloc.ClosePrice > hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Blue;
                        }
                    }
                }
                else if (type == 1)
                {
                    string h = abc["양고가"] > abc["고가"] ? "양고가" : "고가";
                    string l = abc["양저가"] < abc["저가"] ? "양저가" : "저가";
                    if (m.Key == h || m.Key == l)
                    {
                        if (hloc.ClosePrice < hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Red;
                        }

                        else if (hloc.ClosePrice > hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Blue;
                        }
                    }
                }
                else if (type == 2)
                {
                    if (m.Key == "양중앙가" || m.Key == "중앙가")
                    {
                        if (hloc.ClosePrice < hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Red;
                        }

                        else if (hloc.ClosePrice > hloc.QuantumPrice)
                        {
                            textBoxes[idx].ForeColor = labels[idx].ForeColor = Color.Blue;
                        }
                    }
                }

                textBoxes[idx].Text = m.Value.ToString();
                idx++;
            }
        }

        public void Init()
        {
            //lblTime.Text = "";
            //foreach (var c in labels)
            //    c.Text = "";

            //foreach (var c in textBoxes)
            //    c.Text = "";
        }
    }
}
