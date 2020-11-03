using MetroFramework;
using MetroFramework.Controls;
using OM.Jiva.Chakra.Patterns;
using OM.Lib.Base.Enums;
using OM.Lib.Framework.Utility;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OM.Jiva.Chakra.App
{
    public partial class JivaCreateFourForm : MetroFramework.Forms.MetroForm
    {
        List<S_CandleItemData> sourceDatas = null;

        string selectedType = "";
        TimeIntervalEnum selectedTimeInterval = TimeIntervalEnum.Day;
        string selectedItem = "";
        public JivaCreateFourForm()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
        }

        private void AtmanForm_Load(object sender, EventArgs e)
        {
            serverInfo();
            setItems();
            setItems2();
        }

        private void serverInfo()
        {
            XingServerConfigData.IP = ConfigurationManager.AppSettings["XingService_IP"];
            XingServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["XingService_Port"]);
            XingContext.Instance.OnCreateClient();

            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);
            PPContext.Instance.OnCreateClient();
        }
      
        private void setItems()
        {
            ItemData[] itemDatas = new ItemData[ItemCodeSet.Items.Length];
            ItemCodeSet.Items.CopyTo(itemDatas, 0);

            cbxItem.DataSource = itemDatas;
            cbxItem.DisplayMember = "Name";
            cbxItem.ValueMember = "Code";
            cbxItem.SelectedIndex = 0;
        }
        private void setItems2()
        {
            var lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\kritems.txt");
            cbxItem2.DataSource = lines;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {           
            if (rdoTIntervalM.Checked) selectedTimeInterval = TimeIntervalEnum.Minute_30;
            else if (rdoTIntervalH.Checked) selectedTimeInterval = TimeIntervalEnum.Hour_01;
            else if (rdoTIntervalD.Checked) selectedTimeInterval = TimeIntervalEnum.Day;
            else if (rdoTIntervalW.Checked) selectedTimeInterval = TimeIntervalEnum.Week;

            if (rdoTypeKIndex.Checked) selectedType = "국내지수";
            else if (rdoTypeWIndex.Checked) selectedType = "해외지수";
            else if (rdoTypeWFuture.Checked) selectedType = "해외선물";
            else if (rdoTypeKItem.Checked) selectedType = "국내종목";

            if (selectedType == "국내종목")
            {
                selectedItem = cbxItem2.SelectedItem.ToString().Substring(0, 6);
            }
            else selectedItem = (cbxItem.SelectedItem as ItemData).Code;

            sourceDatas = loadData();

            for (int i = 0; i < sourceDatas.Count; i++)
            {
                int pIdx = i - 1 < 0 ? 0 : i - 1;
                int nIdx = i + 1 == sourceDatas.Count ? i : i + 1;

                sourceDatas[i].PreCandleItem = sourceDatas[pIdx];
                sourceDatas[i].NextCandleItem = sourceDatas[nIdx];
            }

            dgv.Rows.Clear();
            foreach (var item in sourceDatas)
            {
                dgv.Rows.Add(selectedItem
                    , item.OpenPrice.ToString()
                    , item.HighPrice.ToString()
                    , item.LowPrice.ToString()
                    , item.ClosePrice.ToString()
                    , item.PreCandleItem.PreCandleItem.DTime.ToString("yy.MM.dd HH:mm")
                    , item.DTime.ToString("yy.MM.dd HH:mm")
                    , ""); ;
            }            
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int idx = -1;
            foreach (var item in sourceDatas)
            {
                idx++;
                if (idx < 3) continue;
                if (item.PreCandleItem == null) continue;
                if (item.PreCandleItem.PreCandleItem == null) continue;
                if (item.PreCandleItem.PreCandleItem.PreCandleItem == null) continue;
                if (item.NextCandleItem == null) continue;
                if (item.NextCandleItem.NextCandleItem == null) continue;
                if (item.NextCandleItem.NextCandleItem.NextCandleItem == null) continue;

                var p3 = item.PreCandleItem.PreCandleItem.PreCandleItem;
                var p2 = item.PreCandleItem.PreCandleItem;
                var p1 = item.PreCandleItem;
                var p0 = item;
                var n1 = item.NextCandleItem;
                var n2 = item.NextCandleItem.NextCandleItem;
                var n3 = item.NextCandleItem.NextCandleItem.NextCandleItem;

                var pList = new List<S_CandleItemData>() { p3, p2, p1, p0};
                var nList = new List<S_CandleItemData>() { n1, n2, n3};

                var cpType = PatternUtil.GetCandlePatternType(p0, pList, nList);

                if (cpType == CandlePatternTypeEnum.Unknown)
                    continue;

                dgv.Rows[idx].Cells["pattern"].Value = Convert.ToString(cpType);

                try
                {
                    var data = new Entities.CandlePattern_Four();
                    data.CandlePatternType = Convert.ToInt32(cpType).ToString();
                    data.Item = selectedItem;
                    data.Product = selectedType;
                    data.TimeInterval = Convert.ToInt32(selectedTimeInterval);

                    data.PlusMinusType_P3 = Convert.ToInt32(p3.PlusMinusType).ToString();
                    data.PlusMinusType_P2 = Convert.ToInt32(p2.PlusMinusType).ToString();
                    data.PlusMinusType_P1 = Convert.ToInt32(p1.PlusMinusType).ToString();
                    data.PlusMinusType_P0 = Convert.ToInt32(p0.PlusMinusType).ToString();

                    data.CandleSpaceType_P3 = Convert.ToInt32(p3.SpaceType_C).ToString();
                    data.CandleSpaceType_P2 = Convert.ToInt32(p2.SpaceType_C).ToString();
                    data.CandleSpaceType_P1 = Convert.ToInt32(p1.SpaceType_C).ToString();
                    data.CandleSpaceType_P0 = Convert.ToInt32(p0.SpaceType_C).ToString();

                    var timeType = PatternUtil.GetCandleTimeType(p2, p1);
                    data.CandleTimeType_O_P21 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P21 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P21 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P21 = Convert.ToInt32(timeType.lowType).ToString();

                    timeType = PatternUtil.GetCandleTimeType(p1, p0);
                    data.CandleTimeType_O_P10 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P10 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P10 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P10 = Convert.ToInt32(timeType.lowType).ToString();

                    timeType = PatternUtil.GetCandleTimeType(p2, p0);
                    data.CandleTimeType_O_P20 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P20 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P20 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P20 = Convert.ToInt32(timeType.lowType).ToString();

                    timeType = PatternUtil.GetCandleTimeType(p3, p2);
                    data.CandleTimeType_O_P32 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P32 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P32 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P32 = Convert.ToInt32(timeType.lowType).ToString();
                    timeType = PatternUtil.GetCandleTimeType(p3, p1);
                    data.CandleTimeType_O_P31 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P31 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P31 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P31 = Convert.ToInt32(timeType.lowType).ToString();
                    timeType = PatternUtil.GetCandleTimeType(p3, p0);
                    data.CandleTimeType_O_P30 = Convert.ToInt32(timeType.openType).ToString();
                    data.CandleTimeType_C_P30 = Convert.ToInt32(timeType.closeType).ToString();
                    data.CandleTimeType_H_P30 = Convert.ToInt32(timeType.highType).ToString();
                    data.CandleTimeType_L_P30 = Convert.ToInt32(timeType.lowType).ToString();

                    var sizeType = PatternUtil.GetCandleBodySizeType(p2, p1);
                    data.CandleSizeType_B_P21 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleBodySizeType(p1, p0);
                    data.CandleSizeType_B_P10 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleBodySizeType(p2, p0);
                    data.CandleSizeType_B_P20 = Convert.ToInt32(sizeType).ToString();

                    sizeType = PatternUtil.GetCandleBodySizeType(p3, p2);
                    data.CandleSizeType_B_P32 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleBodySizeType(p3, p1);
                    data.CandleSizeType_B_P31 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleBodySizeType(p3, p0);
                    data.CandleSizeType_B_P30 = Convert.ToInt32(sizeType).ToString();

                    sizeType = PatternUtil.GetCandleTotalSizeType(p2, p1);
                    data.CandleSizeType_T_P21 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleTotalSizeType(p1, p0);
                    data.CandleSizeType_T_P10 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleTotalSizeType(p2, p0);
                    data.CandleSizeType_T_P20 = Convert.ToInt32(sizeType).ToString();

                    sizeType = PatternUtil.GetCandleTotalSizeType(p3, p2);
                    data.CandleSizeType_T_P32 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleTotalSizeType(p3, p1);
                    data.CandleSizeType_T_P31 = Convert.ToInt32(sizeType).ToString();
                    sizeType = PatternUtil.GetCandleTotalSizeType(p3, p0);
                    data.CandleSizeType_T_P30 = Convert.ToInt32(sizeType).ToString();

                    data.StartDT = p2.DTime;
                    data.EndDT = p0.DTime;

                    data.Create();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        protected List<S_CandleItemData> loadData()
        {
            List<S_CandleItemData> sourceDatas = null;

            if (selectedType == "국내업종")
            {
                if (selectedTimeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "2", "0", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "3", "0", "500");
            }
            else if (selectedType == "국내지수")
            {
                if (selectedTimeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "2", "0", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "3", "0", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "1", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "5", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "10", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "30", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "60", "500");
            }
            else if (selectedType == "국내종목")
            {
                if (selectedTimeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "2", "0", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "3", "0", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "1", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "5", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "10", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "30", "500");
                else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                    sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "60", "500");
            }
            else if (selectedType == "해외지수")
            {
                if (selectedTimeInterval == TimeIntervalEnum.Day)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(selectedItem, "0");
                else if (selectedTimeInterval == TimeIntervalEnum.Week)
                    sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(selectedItem, "1");
            }
            else if (selectedType == "해외선물")
            {
                if (dtpS.Checked && dtpE.Checked)
                {
                    if (selectedTimeInterval == TimeIntervalEnum.Day)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "D", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Week)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "W", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "2H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_04)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "4H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "5M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "15M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "30M", dtpS.Value, dtpE.Value);
                }
                else
                {
                    if (selectedTimeInterval == TimeIntervalEnum.Day)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "D");
                    else if (selectedTimeInterval == TimeIntervalEnum.Week)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "W");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "2H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_04)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "4H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "5M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "15M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "30M");
                }
            }
            else
                sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                  selectedItem
                , selectedTimeInterval);
            return sourceDatas;
        }

        private void btnAutoCreateKIndex_Click(object sender, EventArgs e)
        {

        }

        private void btnAutoCreateWIndex_Click(object sender, EventArgs e)
        {

        }

        private void btnAutoCreateWFuture_Click(object sender, EventArgs e)
        {
            rdoTypeWFuture.Checked = true;
            Task.Factory.StartNew(() =>
            {
                int itemCnt = 20;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalD.Checked = true;
                        dtpS.Value = DateTime.Today.AddYears((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddYears((i + 0) * -1);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);
                }

                itemCnt = 10 * 12 * 2;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    if (DateTime.Today.AddDays((i + 1) * -15) < Convert.ToDateTime("2016-01-01")) break;

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalM.Checked = true;
                        dtpS.Value = DateTime.Today.AddDays((i + 1) * -15);
                        dtpE.Value = DateTime.Today.AddDays((i + 0) * -15);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);
                }

                itemCnt = 10 * 12;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    if (DateTime.Today.AddDays((i + 1) * -15) < Convert.ToDateTime("2016-01-01")) break;

                    this.Invoke(new Action(() => {
                        rdoTIntervalH.Checked = true;
                        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);
                }

                itemCnt = 20;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => {
                        rdoTIntervalW.Checked = true;
                        dtpS.Value = DateTime.Today.AddYears((i + 1) * -2);
                        dtpE.Value = DateTime.Today.AddYears((i + 0) * -2);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);
                }
            });
        }

        private void btnAutoCreateKItem_Click(object sender, EventArgs e)
        {
            rdoTypeKItem.Checked = true;
            int itemCnt = cbxItem2.Items.Count;
            int startIdx = cbxItem2.SelectedIndex;
            Task.Factory.StartNew(() => 
            {
                for (int i = startIdx; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { cbxItem2.SelectedIndex = i; }));

                    this.Invoke(new Action(() => { rdoTIntervalD.Checked = true; }));
                    
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));

                    System.Threading.Thread.Sleep(3 * 1000);
                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));

                    System.Threading.Thread.Sleep(3 * 1000);

                    this.Invoke(new Action(() => { rdoTIntervalW.Checked = true; }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));

                    System.Threading.Thread.Sleep(3 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));

                    System.Threading.Thread.Sleep(3 * 1000);
                }
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }
    }
}
