using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.Lib.Base.Enums;
using OM.Vikala.Chakra.App.Config;
using OM.Vikala.Chakra.App.Events;
using System.IO;

namespace OM.Vikala.Chakra.App.Mains
{
    public partial class UserToolStrip : UserControl
    {        
        TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;
        bool isAutoReload = false;

        public event EventHandler ItemCodeChangedEvent;
        public event EventHandler FlowDirectionChangedEvent;
        public event EventHandler TimerIntervalChangedEvent;
        public event EventHandler AutoReloadChangedEvent;
        public event EventHandler ReloadEvent;
        public event EventHandler ItemCountChangedEvent;
        public event EventHandler ScreenCaptureEvent;     
        public event EventHandler MdiChangedEvent;
        public event EventHandler VirtualCandleCreateEvent;
        public event EventHandler LineChartWidthChangedEvent;
        public event EventHandler SelectedDateTimePickerEvent;
        public event EventHandler TableViewChangedEvent;
        public bool IsVisibleAlignmentButton
        {
            get { return tsbSplit.Visible; }
            set
            {
                tsbSplit.Visible = value;
            }
        }
        public bool IsVisibleTimeIntervalButton
        {
            get { return tsbTime11.Visible; }
            set
            {
                tsbTime01.Visible = 
                tsbTime02.Visible = 
                tsbTime03.Visible =
                tsbTime05.Visible =
                tsbTime11.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible =
                tsbTime20.Visible =
                tsbTime30.Visible = value;
            }
        }
        public bool IsVisibleMdiButton
        {
            get { return tsbMdiOut.Visible; }
            set
            {
                tsbMdiIn.Visible = tsbMdiOut.Visible  = value;                
            }
        }
        public bool IsVisibleExpand
        {
            get { return tsl_0.Visible; }
            set
            {
                tsl_0.Visible = tsl_1.Visible = tsl_2.Visible = tsl_3.Visible = tsl_4.Visible = value;
            }
        }

        public UserToolStrip()
        {
            InitializeComponent();
            this.Load += UserToolStrip_Load;

            MainFormToolBarEvents.Instance.ManualReloadHandler += Instance_ManualReloadHandler;
            MainFormToolBarEvents.Instance.ItemSelectedChangedHandler += Instance_ItemSelectedChangedHandler;        
        }
        private void setTimeIntervalButton()
        {
            if (SharedData.SelectedType == "국내지수")
            {
                tsbTime01.Visible =
                tsbTime02.Visible =
                tsbTime03.Visible =
                tsbTime04.Visible =
                tsbTime05.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible = false;
            }
            else if (SharedData.SelectedType == "해외지수")
            {
                tsbTime01.Visible =
                tsbTime02.Visible =
                tsbTime03.Visible =
                tsbTime04.Visible =
                tsbTime05.Visible =
                tsbTime11.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible = false;
            }
            else if (SharedData.SelectedType == "해외선물")
            {
                tsbTime01.Visible =
                tsbTime03.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible = false;
            }
            else if (SharedData.SelectedType == "국내업종")
            {
                tsbTime01.Visible =
                tsbTime02.Visible =
                tsbTime03.Visible = 
                tsbTime04.Visible =
                tsbTime05.Visible =
                tsbTime11.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible = false;
            }
            else if (SharedData.SelectedType == "국내종목")
            {
                tsbTime01.Visible =
                tsbTime02.Visible =
                tsbTime03.Visible =
                tsbTime04.Visible =
                //tsbTime05.Visible =
                tsbTime12.Visible =
                tsbTime13.Visible =
                tsbTime14.Visible =
                tsbTime15.Visible =
                tsbTime16.Visible =
                tsbTime17.Visible =
                tsbTime18.Visible = false;
            }
        }
        private void clearTimeIntervalButton()
        {
            tsbTime01.Visible = 
            tsbTime02.Visible = 
            tsbTime03.Visible =
            tsbTime04.Visible =
            tsbTime05.Visible = 
            tsbTime11.Visible = 
            tsbTime12.Visible = 
            tsbTime13.Visible = 
            tsbTime14.Visible = 
            tsbTime15.Visible = 
            tsbTime16.Visible = 
            tsbTime17.Visible = 
            tsbTime18.Visible = 
            tsbTime20.Visible = 
            tsbTime30.Visible = true;
        }
        private void Instance_ItemSelectedChangedHandler(int selectedIndex)
        {
            if (selectedIndex == 0) return;

            if(tscbItem.Items.Count > 0 )
                tscbItem.SelectedIndex = selectedIndex;
        }

        private void Instance_ManualReloadHandler()
        {
            ReloadEvent(this, new EventArgs());
        }

        private void UserToolStrip_Load(object sender, EventArgs e)
        {
            setTimeIntervalButton();
            setItems();
            setInterval();
            tscbCnt.SelectedIndex = 0;

            tscbType.SelectedItem = SharedData.SelectedType;

            if (SharedData.SelectedType == "해외선물")
            {
                var datePickerS = new DateTimePicker();
                var datePickerE = new DateTimePicker();
                var chS = new ToolStripControlHost(datePickerS);
                toolStrip1.Items.Add(chS);
                var chE = new ToolStripControlHost(datePickerE);
                toolStrip1.Items.Add(chE);

                var searchButton = new ToolStripButton("SEARCH");                
                searchButton.Click += (obj, evt) =>
                {
                    List<DateTime> dtList = new List<DateTime>();
                    dtList.Add(datePickerS.Value.Date);
                    dtList.Add(datePickerE.Value.Date);
                    SelectedDateTimePickerEvent(dtList, null); 
                };
                toolStrip1.Items.Add(searchButton);
            }
        }

        public void setProgressValue(int n)
        {
        }
        public void setTimeValue(int n)
        {
            try
            {
                this.Invoke(new MethodInvoker(() => {                   
                    tspb.Value = n;
                }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void setItems()
        {
            List<ItemData> itemDatas = new List<ItemData>();
            
            if (SharedData.SelectedType == "국내지수")
            {
                this.tscbItem.SelectedIndexChanged += new System.EventHandler(this.tscbItem_SelectedIndexChanged);
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("지수-국내") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                tscbItem.ComboBox.DataSource = itemDatas;
                tscbItem.ComboBox.DisplayMember = "Name";
                tscbItem.ComboBox.ValueMember = "Code";
            }
            else if (SharedData.SelectedType == "해외지수")
            {
                this.tscbItem.SelectedIndexChanged += new System.EventHandler(this.tscbItem_SelectedIndexChanged);
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("지수-해외") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                tscbItem.ComboBox.DataSource = itemDatas;
                tscbItem.ComboBox.DisplayMember = "Name";
                tscbItem.ComboBox.ValueMember = "Code";
            }
            else if (SharedData.SelectedType == "해외선물")
            {
                this.tscbItem.SelectedIndexChanged += new System.EventHandler(this.tscbItem_SelectedIndexChanged);
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("해선") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                tscbItem.ComboBox.DataSource = itemDatas;
                tscbItem.ComboBox.DisplayMember = "Name";
                tscbItem.ComboBox.ValueMember = "Code";
            }
            else if (SharedData.SelectedType == "국내업종")
            {
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "DB", "UPJONG.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                tscbItem.ComboBox.DataSource = lst;
                tscbItem.ComboBox.SelectedIndex = -1;
                this.tscbItem.TextChanged += new System.EventHandler(this.tscbItem_TextChanged);
            }
            else if (SharedData.SelectedType == "국내종목")
            {
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "DB", "JONGMOK.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                tscbItem.ComboBox.DataSource = lst;
                tscbItem.ComboBox.SelectedIndex = -1;
                this.tscbItem.TextChanged += new System.EventHandler(this.tscbItem_TextChanged);
            }               
        }
        private void clearItems()
        {
            this.tscbItem.SelectedIndexChanged -= new System.EventHandler(this.tscbItem_SelectedIndexChanged);
            this.tscbItem.TextChanged -= new System.EventHandler(this.tscbItem_TextChanged);
            this.tscbItem.ComboBox.DataSource = null;
        }
         
        private void setInterval()
        {
            tsbTime01.BackColor = Color.WhiteSmoke;
            tsbTime02.BackColor = Color.WhiteSmoke;
            tsbTime03.BackColor = Color.WhiteSmoke;
            tsbTime04.BackColor = Color.WhiteSmoke;
            tsbTime05.BackColor = Color.WhiteSmoke;
            tsbTime11.BackColor = Color.WhiteSmoke;
            tsbTime12.BackColor = Color.WhiteSmoke;
            tsbTime13.BackColor = Color.WhiteSmoke;
            tsbTime14.BackColor = Color.WhiteSmoke;
            tsbTime15.BackColor = Color.WhiteSmoke;
            tsbTime16.BackColor = Color.WhiteSmoke;
            tsbTime17.BackColor = Color.WhiteSmoke;
            tsbTime18.BackColor = Color.WhiteSmoke;
            tsbTime20.BackColor = Color.WhiteSmoke;
            tsbTime30.BackColor = Color.WhiteSmoke;

            switch (timeInterval)
            {
                case TimeIntervalEnum.Minute_01 : tsbTime01.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Minute_05: tsbTime02.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Minute_10: tsbTime03.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Minute_15: tsbTime04.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Minute_30: tsbTime05.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_01: tsbTime11.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_02: tsbTime12.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_03: tsbTime13.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_04: tsbTime14.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_05: tsbTime15.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_06: tsbTime16.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_08: tsbTime17.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Hour_12: tsbTime18.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Day: tsbTime20.BackColor = Color.Yellow; break;
                case TimeIntervalEnum.Week: tsbTime30.BackColor = Color.Yellow; break;
                default: tsbTime20.BackColor = Color.Yellow; break;
            }
        }

        private void tscbItem_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if ((tscbItem.SelectedItem as ItemData).Code == "")
            {
                if (SharedData.SelectedItem != null)
                {
                    tscbItem.SelectedItem = SharedData.SelectedItem;
                }                
            }
            
            if (ItemCodeChangedEvent != null)
            {
                ItemCodeChangedEvent((tscbItem.SelectedItem as ItemData), e);
                SharedData.SelectedItem = tscbItem.SelectedItem as ItemData;
            }
            tscbItem.Enabled = false;
            tscbItem.Enabled = true;
            tscbCnt.Enabled = false;
            tscbCnt.Enabled = true;
        }
        private void tscbItem_TextChanged(object sender, EventArgs e)
        {
            ItemData data = new ItemData();
            data.Code = tscbItem.Text;
            data.Name = SharedData.SelectedType;
            data.Length = 0;
            data.Tick = 1;

            if (SharedData.SelectedType == "국내업종")
            {
                if (tscbItem.Text.Length != 3) return;
            }
            if (SharedData.SelectedType == "국내종목")
            {
                if (tscbItem.Text.Length != 6) return;
            }

            if (ItemCodeChangedEvent != null)
            {
                ItemCodeChangedEvent(data, e);
                SharedData.SelectedItem = data;
            }

            if (SharedData.SelectedType == "국내업종")
            {
                string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Db", "업종.txt");
                var lines = File.ReadLines(filePath, Encoding.UTF8).ToList();
                foreach (var line in lines)
                {
                    string[] values = line.Split("\t".ToCharArray());
                    if (values[1] == data.Code)
                    {
                        lblName.Text = values[0];                      
                    }
                }

                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "DB", "UPJONG.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                if (lst.Count > 0 && lst[0] != data.Code)
                {
                    lst.Remove(data.Code);
                    lst.Insert(0, data.Code);                   
                }
                System.IO.File.WriteAllLines(path, lst);
            }
            else if (SharedData.SelectedType == "국내종목")
            {
                string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "Db", "종목.txt");
                var lines = File.ReadLines(filePath, Encoding.UTF8).ToList();
                foreach (var line in lines)
                {
                    string[] values = line.Split("\t".ToCharArray());
                    if (values[1] == data.Code)
                    {
                        lblName.Text = values[0];                        
                    }
                }

                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "DB", "JONGMOK.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                if (lst.Count > 0 && lst[0] != data.Code)
                {
                    lst.Remove(data.Code);
                    lst.Insert(0, data.Code);                    
                }
                System.IO.File.WriteAllLines(path, lst);
            }
        }

        private void IntervalButton_Click(object sender, EventArgs e)
        {
            var b = sender as ToolStripButton;
            string n = Convert.ToString(b.Tag);

            switch (n)
            {
                case "01m": timeInterval = TimeIntervalEnum.Minute_01; break;
                case "05m": timeInterval = TimeIntervalEnum.Minute_05; break;
                case "10m": timeInterval = TimeIntervalEnum.Minute_10; break;
                case "15m": timeInterval = TimeIntervalEnum.Minute_15; break;
                case "30m": timeInterval = TimeIntervalEnum.Minute_30; break;
                case "01h": timeInterval = TimeIntervalEnum.Hour_01; break;                
                case "02h": timeInterval = TimeIntervalEnum.Hour_02; break;
                case "03h": timeInterval = TimeIntervalEnum.Hour_03; break;
                case "04h": timeInterval = TimeIntervalEnum.Hour_04; break;
                case "05h": timeInterval = TimeIntervalEnum.Hour_05; break;
                case "06h": timeInterval = TimeIntervalEnum.Hour_06; break;
                case "08h": timeInterval = TimeIntervalEnum.Hour_08; break;
                case "12h": timeInterval = TimeIntervalEnum.Hour_12; break;
                case "D": timeInterval = TimeIntervalEnum.Day; break;
                case "W": timeInterval = TimeIntervalEnum.Week; break;
                default: timeInterval = TimeIntervalEnum.Day; break;
            }           

            if (TimerIntervalChangedEvent != null)
            {
                TimerIntervalChangedEvent(timeInterval, e);
                SharedData.SelectedInterval = timeInterval;
            }
            setInterval();
        }

        private void tsbAutoReload_Click(object sender, EventArgs e)
        {
            isAutoReload = !isAutoReload;

            AutoReloadChangedEvent(isAutoReload, e);

            if (isAutoReload)
                this.tsbAutoReload.Image = global::OM.Vikala.Chakra.App.Properties.Resources.refreshing_2;
            else
                this.tsbAutoReload.Image = global::OM.Vikala.Chakra.App.Properties.Resources.refreshing_0;
        }

        private void tsbReload_Click(object sender, EventArgs e)
        {            
            ReloadEvent(sender, e);
        }
        private void TsbReload2_Click(object sender, EventArgs e)
        {
            MainFormToolBarEvents.Instance.OnManualReloadHandler();
        }

        private void tsbAlignment_Click(object sender, EventArgs e)
        {
            ToolStripButton c = sender as ToolStripButton ;

            FlowDirectionTypeEnum type = FlowDirectionTypeEnum.TABLE;
            if (c.Text == "List") type = FlowDirectionTypeEnum.LIST;
            else if (c.Text == "Tab") type = FlowDirectionTypeEnum.TAB;

            if (FlowDirectionChangedEvent != null)
            {
                FlowDirectionChangedEvent(type, e);
            }

            //tsbTable.BackColor = Color.WhiteSmoke;
            //tsbList.BackColor = Color.WhiteSmoke;
            //tsbFTab.BackColor = Color.WhiteSmoke;

            ((ToolStripButton)sender).BackColor = Color.Yellow;
        }

        private void tscbCnt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemCountChangedEvent != null)
            {
                SharedData.SelectedItemCount = Convert.ToInt32(tscbCnt.SelectedItem);
                ItemCountChangedEvent(tscbCnt.SelectedItem, e);               
            }
            tscbCnt.Enabled = false;
            tscbCnt.Enabled = true;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (ScreenCaptureEvent != null)
                ScreenCaptureEvent("Save", e);
        }
        private void tsbDraw_Click(object sender, EventArgs e)
        {
            if (ScreenCaptureEvent != null)
                ScreenCaptureEvent("Draw", e);
        }

        private void tsbMdiOut_Click(object sender, EventArgs e)
        {
            if (MdiChangedEvent != null)
            {
                MdiChangedEvent("OUT", e);
                tsbMdiOut.Visible = false;
            }
        }

        private void tsbMdiIn_Click(object sender, EventArgs e)
        {
            if (MdiChangedEvent != null)
                MdiChangedEvent("IN", e);
        }

        private void lblTableView_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            //↗  ↘ →
            tsl_0.ForeColor = SystemColors.ControlText;
            tsl_1.ForeColor = SystemColors.ControlText;
            tsl_2.ForeColor = SystemColors.ControlText;
            tsl_3.ForeColor = SystemColors.ControlText;
            tsl_4.ForeColor = SystemColors.ControlText;
            tsl_5.ForeColor = SystemColors.ControlText;

            switch (lbl.Text) {
                case "↗↗": 
                    tsl_0.ForeColor = Color.Coral;
                    break;
                case "↘↘":
                    tsl_1.ForeColor = Color.Coral;
                    break;
                case "↗↘":
                    tsl_2.ForeColor = Color.Coral;
                    break;
                case "↘↗":
                    tsl_3.ForeColor = Color.Coral;
                    break;
                case "→→": 
                    tsl_4.ForeColor = Color.Coral;
                    break;
                case "〓〓":
                    tsl_5.ForeColor = Color.Coral;
                    break;
            }
            if (VirtualCandleCreateEvent != null)
                VirtualCandleCreateEvent(lbl.Text, e);            
        }

        private void TsbLineBold_Click(object sender, EventArgs e)
        {
            if (LineChartWidthChangedEvent != null)
                LineChartWidthChangedEvent("+", e);            
        }

        private void TsbLineBold2_Click(object sender, EventArgs e)
        {
            if (LineChartWidthChangedEvent != null)
                LineChartWidthChangedEvent("-", e);
        }

        private void tsbWeb1_Click(object sender, EventArgs e)
        {
            if (tscbItem.Text.Length == 0) return;
            string url = "https://finance.naver.com/item/main.nhn?code=" + tscbItem.Text;
            System.Diagnostics.Process.Start("chrome", url);
        }

        private void tsbWeb2_Click(object sender, EventArgs e)
        {
            if (tscbItem.Text.Length == 0) return;
            string url = "https://www.alphasquare.co.kr/home/stock/stock-summary?code=" + tscbItem.Text;
            System.Diagnostics.Process.Start("chrome", url);
        }

        private void tscbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SharedData.SelectedType = tscbType.SelectedItem.ToString();

            (this.ParentForm as BaseForm).SelectedType = SharedData.SelectedType;

            clearItems();
            setItems();
            clearTimeIntervalButton();
            setTimeIntervalButton();
            setInterval();
        }
    }

    public enum FlowDirectionTypeEnum
    {
        TABLE, LIST, TAB
    }
}
