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
        public event EventHandler TableViewChangedEvent;
        public event EventHandler LineChartWidthChangedEvent;
        public bool IsVisibleAlignmentButton
        {
            get { return tsbSplit.Visible; }
            set
            {
                tsbSplit.Visible = tsbTable.Visible = tsbFTab.Visible = tsbList.Visible = value;
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
                tsbTime04.Visible =
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
            setItems();
            setInterval();
            tscbCnt.SelectedIndex = 3;
        }

        public void setProgressValue(int n)
        {
            //try
            //{
            //    if (n > 60) n = 60;

            //    this.Invoke(new MethodInvoker(() => { tspb.Value = n; }));
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public void setTimeValue(int n)
        {
            try
            {
                this.Invoke(new MethodInvoker(() => {
                    //tslTime.Text = n.ToString("N0");
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
            ItemData[] itemDatas = new ItemData[ItemCodeSet.Items.Length];
            ItemCodeSet.Items.CopyTo(itemDatas, 0);

            tscbItem.ComboBox.DataSource = itemDatas;
            tscbItem.ComboBox.DisplayMember = "Name";
            tscbItem.ComboBox.ValueMember = "Code";
            tscbItem.SelectedIndex = 0;
        }
        private void setInterval()
        {
            tsbTime01.BackColor = Color.WhiteSmoke;
            tsbTime02.BackColor = Color.WhiteSmoke;
            tsbTime03.BackColor = Color.WhiteSmoke;
            tsbTime04.BackColor = Color.WhiteSmoke;
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
                case TimeIntervalEnum.Minute_30: tsbTime04.BackColor = Color.Yellow; break;
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

        private void IntervalButton_Click(object sender, EventArgs e)
        {
            var b = sender as ToolStripButton;
            string n = Convert.ToString(b.Tag);

            switch (n)
            {
                case "01m": timeInterval = TimeIntervalEnum.Minute_01; break;
                case "05m": timeInterval = TimeIntervalEnum.Minute_05; break;
                case "10m": timeInterval = TimeIntervalEnum.Minute_10; break;
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

            tsbTable.BackColor = Color.WhiteSmoke;
            tsbList.BackColor = Color.WhiteSmoke;
            tsbFTab.BackColor = Color.WhiteSmoke;

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

            tsl_0.ForeColor = SystemColors.ControlText;
            tsl_1.ForeColor = SystemColors.ControlText;
            tsl_2.ForeColor = SystemColors.ControlText;
            tsl_3.ForeColor = SystemColors.ControlText;
            tsl_4.ForeColor = SystemColors.ControlText;

            switch (lbl.Text) {
                case "0": 
                    tsl_0.ForeColor = Color.Coral;
                    break;
                case "1":
                    tsl_1.ForeColor = Color.Coral;
                    break;
                case "2":
                    tsl_2.ForeColor = Color.Coral;
                    break;
                case "3":
                    tsl_3.ForeColor = Color.Coral;
                    break;
                case "4": 
                    tsl_4.ForeColor = Color.Coral;
                    break;
            }
            if (TableViewChangedEvent != null)
                TableViewChangedEvent(lbl.Text, e);            
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

        
    }

    public enum FlowDirectionTypeEnum
    {
        TABLE, LIST, TAB
    }
}
