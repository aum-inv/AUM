﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Atman.Chakra.App
{
    public partial class UC_Signal : UserControl
    {       
        public string Title
        {
            set { lblMin.Text = value; }
            get { return lblMin.Text; }
        }

        public bool IsShowSignalTypeColume
        {
            get
            {
                return tableLayoutPanel1.ColumnStyles[0].Width != 0;
            }
            set
            {
                if (value == false)
                {
                    tableLayoutPanel1.ColumnStyles[0].Width = 0;
                }
                else
                {
                    tableLayoutPanel1.ColumnStyles[0].Width = 90;
                }
            }
        }

        public Dictionary<string, Label> signalListControls = new Dictionary<string, Label>();
        public Dictionary<string, Label> signalResultListControls = new Dictionary<string, Label>();
        public Dictionary<string, Label> signalTimeListControls = new Dictionary<string, Label>();
        public UC_Signal()
        {
            InitializeComponent();

            label3.Text = "Line - 2";
            label6.Text = "Line - 3";
            label9.Text = "High Line";
            label12.Text = "Low Line";
            label15.Text = "H - L Line";
            label18.Text = "CCount";
            label21.Text = "Mass";
            label24.Text = "Candle - 6";
            label27.Text = "Candle - 5";
            label30.Text = "Candle - 4";
            label33.Text = "Candle - 3";

            signalListControls.Add(label3.Text, label4);
            signalListControls.Add(label6.Text, label7);
            signalListControls.Add(label9.Text, label10);
            signalListControls.Add(label12.Text, label13);
            signalListControls.Add(label15.Text, label16);
            signalListControls.Add(label18.Text, label19);
            signalListControls.Add(label21.Text, label22);
            signalListControls.Add(label24.Text, label25);
            signalListControls.Add(label27.Text, label28);
            signalListControls.Add(label30.Text, label31);
            signalListControls.Add(label33.Text, label34);

            signalResultListControls.Add(label3.Text, label5);
            signalResultListControls.Add(label6.Text, label8);
            signalResultListControls.Add(label9.Text, label11);
            signalResultListControls.Add(label12.Text, label14);
            signalResultListControls.Add(label15.Text, label17);
            signalResultListControls.Add(label18.Text, label20);
            signalResultListControls.Add(label21.Text, label23);
            signalResultListControls.Add(label24.Text, label26);
            signalResultListControls.Add(label27.Text, label29);
            signalResultListControls.Add(label30.Text, label32);
            signalResultListControls.Add(label33.Text, label35);

            signalTimeListControls.Add(label3.Text, label36);
            signalTimeListControls.Add(label6.Text, label37);
            signalTimeListControls.Add(label9.Text, label38);
            signalTimeListControls.Add(label12.Text, label39);
            signalTimeListControls.Add(label15.Text, label40);
            signalTimeListControls.Add(label18.Text, label41);
            signalTimeListControls.Add(label21.Text, label42);
            signalTimeListControls.Add(label24.Text, label43);
            signalTimeListControls.Add(label27.Text, label44);
            signalTimeListControls.Add(label30.Text, label45);
            signalTimeListControls.Add(label33.Text, label46);

            foreach (var kv in signalListControls)
                kv.Value.Text = "";

            foreach (var kv in signalResultListControls)
                kv.Value.Text = "";

            foreach (var kv in signalTimeListControls)
                kv.Value.Text = "";
        }

        public void SetTitle(string min)
        {
            lblMin.Text = min;
        }
        public void SetTitleColor(Color c)
        {
            lblMin.ForeColor = c;
        }
        public void SetLastTime(DateTime dt)
        {
            lblLastTime.Text = dt.ToString("yyyy-MM-dd HH:mm");
        }
        public void SetLine2(string signal, string result, DateTime dt)
        {
            string sType = "Line - 2";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetLine3(string signal, string result, DateTime dt)
        {
            string sType = "Line - 3";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetHighLine(string signal, string result, DateTime dt)
        {
            string sType = "High Line";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetLowLine(string signal, string result, DateTime dt)
        {
            string sType = "Low Line";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetHighLowLine(string signal, string result, DateTime dt)
        {
            string sType = "H - L Line";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetCCount(string signal, string result, DateTime dt)
        {
            string sType = "CCount";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetMass(string signal, string result, DateTime dt)
        {
            string sType = "Mass";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetCandle6(string signal, string result, DateTime dt)
        {
            string sType = "Candle - 6";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetCandle5(string signal, string result, DateTime dt)
        {
            string sType = "Candle - 5";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetCandle4(string signal, string result, DateTime dt)
        {
            string sType = "Candle - 4";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
        public void SetCandle3(string signal, string result, DateTime dt)
        {
            string sType = "Candle - 3";
            signalListControls[sType].Text = signal;
            signalResultListControls[sType].Text = result;
            signalTimeListControls[sType].Text = dt.ToString("MM-dd HH:mm");

            if (result == "▲") signalResultListControls[sType].ForeColor = Color.Red;
            else if (result == "▼") signalResultListControls[sType].ForeColor = Color.Blue;
            else if (result == "△") signalResultListControls[sType].ForeColor = Color.DarkRed;
            else if (result == "▽") signalResultListControls[sType].ForeColor = Color.DarkBlue;
        }
    }
}
