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
    public partial class JivaHistoryCreateForm : MetroFramework.Forms.MetroForm
    {
        List<S_CandleItemData> sourceDatas = null;

        string selectedType = "국내지수";
        TimeIntervalEnum selectedTimeInterval = TimeIntervalEnum.Day;
        string selectedItem = "101";
        string selectedCandleType = "F";

        bool isAuto = false;
        bool isNoData = false;
        public JivaHistoryCreateForm()
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
            cbxItem.DataSource = null;

            List<ItemData> itemDatas = new List<ItemData>();
            if (selectedType == "국내지수")
            {
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("지수-국내") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                cbxItem.DataSource = itemDatas;
                cbxItem.DisplayMember = "Name";
                cbxItem.ValueMember = "Code";
            }
            else if (selectedType == "해외지수")
            {
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("지수-해외") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                cbxItem.DataSource = itemDatas;
                cbxItem.DisplayMember = "Name";
                cbxItem.ValueMember = "Code";
            }
            else if (selectedType == "해외선물")
            {
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("해선") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                cbxItem.DataSource = itemDatas;
                cbxItem.DisplayMember = "Name";
                cbxItem.ValueMember = "Code";
            }
            else if (selectedType == "암호화폐")
            {
                foreach (var m in ItemCodeSet.Items)
                {
                    if (m.Name.StartsWith("암호") || m.Code.Length == 0)
                        itemDatas.Add(m);
                }
                cbxItem.DataSource = itemDatas;
                cbxItem.DisplayMember = "Name";
                cbxItem.ValueMember = "Code";
            }
            else if (selectedType == "국내종목")
            {
                var lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\kritems.txt");
                cbxItem.DataSource = lines;
            }

            cbxItem.SelectedIndex = 0;
        }
      
        private void btnLoad_Click(object sender, EventArgs e)
        {           
            if (rdoTIntervalM.Checked) selectedTimeInterval = TimeIntervalEnum.Minute_30;
            else if (rdoTIntervalH.Checked) selectedTimeInterval = TimeIntervalEnum.Hour_01;
            else if (rdoTInterval2H.Checked) selectedTimeInterval = TimeIntervalEnum.Hour_02;
            else if (rdoTInterval5H.Checked) selectedTimeInterval = TimeIntervalEnum.Hour_05;
            else if (rdoTIntervalD.Checked) selectedTimeInterval = TimeIntervalEnum.Day;
            else if (rdoTIntervalW.Checked) selectedTimeInterval = TimeIntervalEnum.Week;
            
            if (selectedType == "국내종목")
                 selectedItem = cbxItem.SelectedItem.ToString().Substring(0, 6);            
            else 
                selectedItem = (cbxItem.SelectedItem as ItemData).Code;

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
                dgv.Rows.Add(selectedType
                    , selectedItem
                    , selectedTimeInterval
                    , item.DTime.ToString("yy.MM.dd HH:mm")
                    , item.OpenPrice.ToString()
                    , item.HighPrice.ToString()
                    , item.LowPrice.ToString()
                    , item.ClosePrice.ToString()
                    , item.Volume.ToString()
                    ); ;
            }            
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (isAuto == true && sourceDatas.Count == 0)
            {
                isNoData = true;
                return;
            }

            foreach (var item in sourceDatas)
            {

                try
                {
                    if (item.OpenPrice == 0 || item.HighPrice == 0 || item.LowPrice == 0 || item.ClosePrice == 0)
                        continue;
                    var data = new Entities.CandleHistoryData();
                    data.Item = selectedItem;
                    data.Product = selectedType;
                    data.TimeInterval = Convert.ToInt32(selectedTimeInterval);
                    data.DTime = item.DTime;
                    data.OpenPrice = item.OpenPrice.ToString();
                    data.HighPrice = item.HighPrice.ToString();
                    data.LowPrice = item.LowPrice.ToString();
                    data.ClosePrice = item.ClosePrice.ToString();
                    data.Volume = item.Volume.ToString();
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
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "5H", dtpS.Value, dtpE.Value);
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
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "5H");
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
            else if (selectedType == "암호화폐")
            {
                if (dtpS.Checked && dtpE.Checked)
                {
                    if (selectedTimeInterval == TimeIntervalEnum.Day)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "D", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Week)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "W", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "2H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "5H", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "5M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "15M", dtpS.Value, dtpE.Value);
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "30M", dtpS.Value, dtpE.Value);
                }
                else
                {
                    if (selectedTimeInterval == TimeIntervalEnum.Day)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "D");
                    else if (selectedTimeInterval == TimeIntervalEnum.Week)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "W");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "2H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "5H");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "5M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "15M");
                    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
                        sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "30M");
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
            rdoTypeKIndex.Checked = true;
            int itemCnt = cbxItem.Items.Count;
            int startIdx = cbxItem.SelectedIndex;
            if (startIdx == 0) startIdx = 1;

            Task.Factory.StartNew(() =>
            {
                isAuto = true;
               
                System.Threading.Thread.Sleep(1 * 1000);        
                
                for (int i = startIdx; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { cbxItem.SelectedIndex = i; }));

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
                
                isAuto = false;
            });
        }
        private void btnAutoCreateWIndex_Click(object sender, EventArgs e)
        {
            rdoTypeWIndex.Checked = true;
            int itemCnt = cbxItem.Items.Count;
            int startIdx = cbxItem.SelectedIndex;
            if (startIdx == 0) startIdx = 1;

            Task.Factory.StartNew(() =>
            {
                isAuto = true;

                System.Threading.Thread.Sleep(1 * 1000);

                for (int i = startIdx; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { cbxItem.SelectedIndex = i; }));

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

                isAuto = false;
            });
        }
        private void btnAutoCreateWFuture_Click(object sender, EventArgs e)
        {
            rdoTypeWFuture.Checked = true;
            Task.Factory.StartNew(() =>
            {
                isAuto = true;
                
                System.Threading.Thread.Sleep(1 * 1000);

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

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 10 * 12 * 2;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

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

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 10 * 12;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalH.Checked = true;
                        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                //itemCnt = 10 * 12;
                //for (int i = 0; i < itemCnt; i++)
                //{
                //    System.Threading.Thread.Sleep(1 * 1000);

                //    this.Invoke(new Action(() =>
                //    {
                //        rdoTInterval2H.Checked = true;
                //        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                //        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                //    }));

                //    System.Threading.Thread.Sleep(1 * 1000);

                //    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                //    System.Threading.Thread.Sleep(5 * 1000);

                //    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                //    System.Threading.Thread.Sleep(5 * 1000);

                //    if (isNoData)
                //    {
                //        isNoData = false;
                //        break;
                //    }
                //}

                    itemCnt = 10 * 12;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTInterval5H.Checked = true;
                        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 20;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalW.Checked = true;
                        dtpS.Value = DateTime.Today.AddYears((i + 1) * -2);
                        dtpE.Value = DateTime.Today.AddYears((i + 0) * -2);
                    }));

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }
                
                isAuto = false;
            });
        }
        private void btnAutoCreateCrypto_Click(object sender, EventArgs e)
        {
            rdoTypeCrypto.Checked = true;
            Task.Factory.StartNew(() =>
            {
                isAuto = true;

                System.Threading.Thread.Sleep(1 * 1000);

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

                   if (dtpS.Value < Convert.ToDateTime("2017-01-01")) break;

                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 10 * 12 * 2;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalM.Checked = true;
                        dtpS.Value = DateTime.Today.AddDays((i + 1) * -15);
                        dtpE.Value = DateTime.Today.AddDays((i + 0) * -15);
                    }));
                    if (dtpS.Value < Convert.ToDateTime("2017-01-01")) break;
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 10 * 12;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalH.Checked = true;
                        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                    }));
                    if (dtpS.Value < Convert.ToDateTime("2017-01-01")) break;
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                //itemCnt = 10 * 12;
                //for (int i = 0; i < itemCnt; i++)
                //{
                //    System.Threading.Thread.Sleep(1 * 1000);

                //    this.Invoke(new Action(() =>
                //    {
                //        rdoTInterval2H.Checked = true;
                //        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                //        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                //    }));

                //    System.Threading.Thread.Sleep(1 * 1000);

                //    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                //    System.Threading.Thread.Sleep(5 * 1000);

                //    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                //    System.Threading.Thread.Sleep(5 * 1000);

                //    if (isNoData)
                //    {
                //        isNoData = false;
                //        break;
                //    }
                //}

                itemCnt = 10 * 12;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTInterval5H.Checked = true;
                        dtpS.Value = DateTime.Today.AddMonths((i + 1) * -1);
                        dtpE.Value = DateTime.Today.AddMonths((i + 0) * -1);
                    }));
                    if (dtpS.Value < Convert.ToDateTime("2017-01-01")) break;
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                itemCnt = 20;
                for (int i = 0; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() =>
                    {
                        rdoTIntervalW.Checked = true;
                        dtpS.Value = DateTime.Today.AddYears((i + 1) * -2);
                        dtpE.Value = DateTime.Today.AddYears((i + 0) * -2);
                    }));
                    if (dtpS.Value < Convert.ToDateTime("2017-01-01")) break;
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { btnLoad.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    this.Invoke(new Action(() => { btnCreate.PerformClick(); }));
                    System.Threading.Thread.Sleep(5 * 1000);

                    if (isNoData)
                    {
                        isNoData = false;
                        break;
                    }
                }

                isAuto = false;
            });
        }
        private void btnAutoCreateKItem_Click(object sender, EventArgs e)
        {
            rdoTypeKItem.Checked = true;
            int itemCnt = cbxItem.Items.Count;
            int startIdx = cbxItem.SelectedIndex;
            Task.Factory.StartNew(() =>
            {
                isAuto = true;

                System.Threading.Thread.Sleep(1 * 1000);

                for (int i = startIdx; i < itemCnt; i++)
                {
                    System.Threading.Thread.Sleep(1 * 1000);

                    this.Invoke(new Action(() => { cbxItem.SelectedIndex = i; }));

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

                isAuto = false;
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.Kill();
        }

        private void rdoTypeKIndex_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "국내지수";
            setItems();
        }

        private void rdoTypeWIndex_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "해외지수";
            setItems();
        }

        private void rdoTypeWFuture_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "해외선물";
            setItems(); 
        }
        private void rdoTypeCrypto_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "암호화폐";
            setItems();
        }
        private void rdoTypeKItem_CheckedChanged(object sender, EventArgs e)
        {
            selectedType = "국내종목";
            setItems();
        }

        private void rdoCandle4_CheckedChanged(object sender, EventArgs e)
        {
            selectedCandleType = "234";
        }

        private void rdoCandleF_CheckedChanged(object sender, EventArgs e)
        {
            selectedCandleType = "F";
        }
    }
}
