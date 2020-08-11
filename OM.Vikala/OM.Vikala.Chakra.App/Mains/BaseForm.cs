using OM.Lib.Base.Enums;
using OM.PP.Chakra;
using OM.Vikala.Chakra.App.Config;
using OM.Vikala.Chakra.App.Events;
using OM.Vikala.Controls.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
    public class BaseForm : Form
    {
        protected bool autoReload = false;

        protected int itemCnt = 60;
        protected int loadCnt = 120;

        protected TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;

        protected FlowDirectionTypeEnum flowDirection = FlowDirectionTypeEnum.TAB;

        protected ChartEvents chartEvent = new ChartEvents();
        protected ChartEvents chartEvent2 = new ChartEvents();
        protected ChartEvents chartEvent3 = new ChartEvents();

        protected UserToolStrip userToolStrip = null;

        public MainForm MdiForm
        {
            get;
            set;
        } = null;

        protected ItemData SelectedItemData
        {
            get; set;
        }
        public int RoundLength
        {
            get
            {
                return ItemCodeSet.GetItemRoundNum(SelectedItemData.Code);
            }
        }
        public BaseForm()
        {
            this.FormClosing += BaseForm_FormClosing;
            this.Load += BaseForm_Load;

            MainFormToolBarEvents.Instance.AutoReloadHandler += Instance_AutoReloadHandler;

            //MainFormToolBarEvents.Instance.OnAutoReloadHandler(true);
        }

        private void Instance_AutoReloadHandler(bool isAutoReload)
        {
            autoReload = isAutoReload;
        }
   

        private void BaseForm_Load(object sender, EventArgs e)
        {
            bool isPermission = true;
            if (SharedData.SecurityType == "2")
               isPermission = true;           
            else if (SharedData.SecurityType == "1") 
                isPermission = true;

            if (SharedData.SelectedType == "KR")
            {

            }
            else if (SharedData.SelectedType == "US")
            {
                
            }

            if (!isPermission) this.Close();
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MdiForm != null)
                    MdiForm.RemoveTab(this);

                timer1.Stop();
                timer1.Dispose();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        protected Timer timer1 = new Timer();
        int timerCnt = (60 - DateTime.Now.Second);

        public virtual void loadChartControls() { }
        public virtual void setFlow() { }
        public virtual void setTimer() {
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 1000;
            timer1.Enabled = autoReload;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!autoReload) return;

                timerCnt--;
                if (autoReload && timerCnt == 0)
                {
                    timerCnt = 60;
                    loadData();
                }

                userToolStrip.setTimeValue(timerCnt);
            }
            catch (Exception ex)
            {
                timer1.Stop();
                timer1.Enabled = false;
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public virtual void loadData() { }

        public void OnMdiOut()
        {
            if (MdiForm == null) return;

            MdiForm.RemoveTab(this);
            this.MdiParent = null;
            this.WindowState = FormWindowState.Normal;
            userToolStrip.IsVisibleMdiButton = false;
        }
        internal void setToolStrip(UserToolStrip userToolStrip)
        {
            this.userToolStrip = userToolStrip;
            this.userToolStrip.ItemCodeChangedEvent += UserToolStrip1_ItemCodeChangedEvent;
            this.userToolStrip.TimerIntervalChangedEvent += UserToolStrip1_TimerIntervalChangedEvent;
            this.userToolStrip.FlowDirectionChangedEvent += UserToolStrip1_FlowDirectionChangedEvent;
            this.userToolStrip.AutoReloadChangedEvent += UserToolStrip1_AutoReloadChangedEvent;
            this.userToolStrip.ReloadEvent += UserToolStrip1_ReloadEvent;
            this.userToolStrip.ItemCountChangedEvent += UserToolStrip1_ItemCountChangedEvent;
            this.userToolStrip.ScreenCaptureEvent += UserToolStrip1_ScreenCaptureEvent;
            this.userToolStrip.MdiChangedEvent += UserToolStrip_MdiChangedEvent;
            this.userToolStrip.TableViewChangedEvent += UserToolStrip_TableViewChangedEvent;
            this.userToolStrip.LineChartWidthChangedEvent += UserToolStrip_LineChartWidthChangedEvent;
        }

        private void UserToolStrip_LineChartWidthChangedEvent(object sender, EventArgs e)
        {
            if (sender.ToString() == "+")
            {
                
            }
            else if (sender.ToString() == "-")
            {

            }
        }

        private void UserToolStrip_TableViewChangedEvent(object sender, EventArgs e)
        {            
        }

        private void UserToolStrip_MdiChangedEvent(object sender, EventArgs e)
        {
            //if (sender.ToString() == "IN")
            //{
            //    this.MdiParent = MdiForm;
            //    MdiForm.AddTab(this);
            //}    
            if (sender.ToString() == "OUT")
            {
                if (MdiForm == null) return;

                //MdiForm.RemoveForm(this);
                MdiForm.RemoveTab(this);
                this.MdiParent = null;
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void UserToolStrip1_ScreenCaptureEvent(object sender, EventArgs e)
        {
            Panel pnlContent = this.Controls["pnlContent"] as Panel;

            Bitmap bmp = new Bitmap(pnlContent.Width, pnlContent.Height);
            pnlContent.DrawToBitmap(bmp, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void UserToolStrip1_ItemCountChangedEvent(object sender, EventArgs e)
        {
            loadCnt = Convert.ToInt32(sender);
            loadData();
        }

        private void UserToolStrip1_ReloadEvent(object sender, EventArgs e)
        {
            loadData();
        }

        private void UserToolStrip1_AutoReloadChangedEvent(object sender, EventArgs e)
        {   
            autoReload = (bool)sender;
        
            timer1.Enabled = autoReload;
        }

        private void UserToolStrip1_FlowDirectionChangedEvent(object sender, EventArgs e)
        {
            flowDirection = (FlowDirectionTypeEnum)sender;
            setFlow();
        }

        private void UserToolStrip1_TimerIntervalChangedEvent(object sender, EventArgs e)
        {
            timeInterval = (TimeIntervalEnum)sender;
            loadData();
        }

        private void UserToolStrip1_ItemCodeChangedEvent(object sender, EventArgs e)
        {
            ItemData itemData = (ItemData)sender;
            if (itemData.Code == "") return;
            if (SelectedItemData != null && SelectedItemData.Code == itemData.Code) return;

            SelectedItemData = itemData;
            //this.Text = itemData.Name;
            Task.Factory.StartNew(() =>
            {
                loadData();
            });
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 0);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }


        protected void RemoveSourceData(List<S_CandleItemData> sourceDatas)
        {
            int totalCnt = sourceDatas.Count;
            if (totalCnt > SharedData.SelectedItemCount)
                sourceDatas.RemoveRange(0, totalCnt - SharedData.SelectedItemCount);
        }

        protected void SetChangeOpenPrice(string itemCode, List<S_CandleItemData> sourceDatas)
        {
            if (itemCode == "101" || itemCode == "301")
                PPUtils.SetModifyOpenPriceByClosePrice(sourceDatas);
        }
    }
}
