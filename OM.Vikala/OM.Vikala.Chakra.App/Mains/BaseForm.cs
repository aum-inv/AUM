using OM.Lib.Base.Enums;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Config;
using OM.Vikala.Chakra.App.Events;
using OM.Vikala.Controls.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
    public class BaseForm : Form
    {
        protected bool autoReload = false;
        protected bool isLoading = false;

        protected int itemCnt = 60;
        protected int loadCnt = 120;

        protected TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;

        protected FlowDirectionTypeEnum flowDirection = FlowDirectionTypeEnum.TAB;

        protected ChartEvents chartEvent = new ChartEvents();
        protected ChartEvents chartEvent2 = new ChartEvents();
        protected ChartEvents chartEvent3 = new ChartEvents();

        protected UserToolStrip userToolStrip = null;

        protected double whimRate = 0.0;
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
        
        public string SelectedType
        {
            get;
            set;
        } = "";

        public AverageTypeEnum AverageType
        {
            get; set;
        } = AverageTypeEnum.Normal;
        
        public OriginSourceTypeEnum OriginSourceType
        {
            get; set;
        } = OriginSourceTypeEnum.Normal;

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
            Control pnlContent = this.Controls["pnlContent"] as Panel;
            if(pnlContent == null)
                pnlContent = this.Controls["sContainer"] as SplitContainer;

            Bitmap bmp = new Bitmap(pnlContent.Width, pnlContent.Height);
            pnlContent.DrawToBitmap(bmp, new Rectangle(0, 0, pnlContent.Width, pnlContent.Height));

            if (sender.ToString().Equals("Draw"))
            {
                var df = new MainDrawForm(bmp);
                df.Width = pnlContent.Width + 5;
                df.Height = pnlContent.Height + 30;
                df.Text = this.Text + "(EDIT IMAGE)";
                df.Show();
            }
            else
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Save an Image File";
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    //var filePath = saveFileDialog1.FileName;

                    //ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
                    //startInfo.Verb = "edit";
                    //Process.Start(startInfo);
                }
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


        protected List<S_CandleItemData> LoadData(string itemCode, string selectedType)
        {
            List<S_CandleItemData> sourceDatas = null;

            if (selectedType == "국내업종")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "3", "0", "500");
            }
            else if (selectedType == "국내지수")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "3", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "1", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "5", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "10", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "30", "500");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(itemCode, "1", "60", "500");
            }
            else if (selectedType == "국내종목")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "2", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "3", "0", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "1", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "5", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "10", "500");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "30", "500");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(itemCode, "1", "60", "500");
            }
            else if (selectedType == "해외지수")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(itemCode, "0");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(itemCode, "1");
            }
            else if (selectedType == "해외선물")
            {
                if (timeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "D");
                else if (timeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "W");
                else if (timeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "H");
                else if (timeInterval == TimeIntervalEnum.Hour_02)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "2H");
                else if (timeInterval == TimeIntervalEnum.Hour_04)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "4H");
                else if (timeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "M");
                else if (timeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "5M");
                else if (timeInterval == TimeIntervalEnum.Minute_15)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "15M");
                else if (timeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(itemCode, "30M");
            }
            else
                sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  itemCode
                , timeInterval);
            return sourceDatas;
        }

        //protected void SetWhim(string itemCode
        //    , TimeIntervalEnum timeInterval = TimeIntervalEnum.Day
        //    , double rate = 0.0)
        //{
        //    this.whimRate = rate;

        //    //if (timeInterval == TimeIntervalEnum.Week) rate = 2.5;
        //    //if (timeInterval == TimeIntervalEnum.Day) rate = 1.0;
        //    //if (timeInterval == TimeIntervalEnum.Hour_03) rate = 0.7;
        //    //if (timeInterval == TimeIntervalEnum.Hour_02) rate = 0.5;
        //    //if (timeInterval == TimeIntervalEnum.Hour_01) rate = 0.3;
        //}
    }
    public enum AverageTypeEnum
    { 
        Normal, Balanced, Accumulated
    }
    public enum OriginSourceTypeEnum
    {
        Normal, Whim, Second, SecondQutum
    }
}
