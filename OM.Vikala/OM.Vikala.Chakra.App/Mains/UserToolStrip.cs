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
                    tsbTime11.Visible =
                    tsbTime12.Visible =
                    tsbTime13.Visible =
                    tsbTime14.Visible =
                    tsbTime15.Visible =
                    tsbTime16.Visible =
                    tsbTime20.Visible =
                    //tsbTime11.Visible =
                    //tsbTime12.Visible =
                    //tsbTime13.Visible =
                    //tsbTime14.Visible =
                    //tsbTime15.Visible =
                    value;
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

        public UserToolStrip()
        {
            InitializeComponent();
            this.Load += UserToolStrip_Load;

            MainFormToolBarEvents.Instance.ManualReloadHandler += Instance_ManualReloadHandler;
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
            tsbTime11.BackColor = Color.WhiteSmoke;
            tsbTime12.BackColor = Color.WhiteSmoke;
            tsbTime13.BackColor = Color.WhiteSmoke;
            tsbTime14.BackColor = Color.WhiteSmoke;
            tsbTime15.BackColor = Color.WhiteSmoke;
            tsbTime16.BackColor = Color.WhiteSmoke;           
            tsbTime20.BackColor = Color.WhiteSmoke;          

            if (timeInterval == TimeIntervalEnum.Minute_60) tsbTime11.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Minute_120) tsbTime12.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Minute_180) tsbTime13.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Minute_300) tsbTime14.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Minute_420) tsbTime15.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Minute_540) tsbTime16.BackColor = Color.Yellow;
            else if (timeInterval == TimeIntervalEnum.Day) tsbTime20.BackColor = Color.Yellow;
        }

        private void tscbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (SharedData.SelectedItem != null &&
            //    SharedData.SelectedItem == (tscbItem.SelectedItem as ItemData))
            //{
            //    return;
            //}
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
            int n = Convert.ToInt32(b.Tag);

            if (n == 1) timeInterval = TimeIntervalEnum.Minute_60;
            else if (n == 2) timeInterval = TimeIntervalEnum.Minute_120;
            else if (n == 3) timeInterval = TimeIntervalEnum.Minute_180;
            else if (n == 4) timeInterval = TimeIntervalEnum.Minute_300;
            else if (n == 5) timeInterval = TimeIntervalEnum.Minute_420;
            else if (n == 6) timeInterval = TimeIntervalEnum.Minute_540;
            else if (n == 7) timeInterval = TimeIntervalEnum.Day;
            
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
                ItemCountChangedEvent(tscbCnt.SelectedItem, e);
                SharedData.SelectedItemCount = Convert.ToInt32(tscbCnt.SelectedItem);
            }
            tscbCnt.Enabled = false;
            tscbCnt.Enabled = true;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (ScreenCaptureEvent != null)
                ScreenCaptureEvent(sender, e);
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
