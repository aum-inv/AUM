using MetroFramework;
using MetroFramework.Controls;
using OM.Jiva.Chakra.Entities;
using OM.Jiva.Chakra.Patterns;
using OM.Lib.Base.Enums;
using OM.Lib.Framework.Utility;
using OM.PP.Chakra;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Controls.Charts;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Jiva.Chakra.App
{
    public partial class JivaAnalysisForm : MetroFramework.Forms.MetroForm
    {
        List<S_CandleItemData> sourceDatas = null;

        string selectedType = "국내지수";
        TimeIntervalEnum selectedTimeInterval = TimeIntervalEnum.Day;
        string selectedItem = "";

        S_CandleItemData selCandleData = null;

        Dictionary<string, BasicCandlePattern> basicPatterns = new Dictionary<string, BasicCandlePattern>();        
      
        int displayCnt = 60;
        public JivaAnalysisForm()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {
            chart1.InitializeControl();
            chart1.InitializeEvent(null);
            chart2.InitializeControl();
            chart2.InitializeEvent(null);
        }
        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
        }
                
        private void AtmanForm_Load(object sender, EventArgs e)
        {
            serverInfo();
            cbxProduct.SelectedIndex = 0;
            setItems();
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
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "krItems.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                cbxItem.DataSource = lst;                       
            }
            cbxItem.SelectedIndex = 0;
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
        #region LoadDSiseata
             
        void loadSiseDataFromDaemon()
        {
            BasicCandlePattern basicPattern = basicPatterns[selectedType];

            if (cbxProduct.SelectedIndex < 3)
                selectedItem = (cbxItem.SelectedItem as ItemData).Code;
            else
                selectedItem = cbxItem.SelectedItem.ToString().Substring(0, 6);

            sourceDatas = loadData(selectedType, selectedItem, selectedTimeInterval, null, null);
          
            if (sourceDatas == null || sourceDatas.Count == 0) return;

            for (int i = 0; i < sourceDatas.Count; i++)
            {
                int pIdx = i - 1 < 0 ? 0 : i - 1;
                int nIdx = i + 1 == sourceDatas.Count ? i : i + 1;

                sourceDatas[i].PreCandleItem = sourceDatas[pIdx];
                sourceDatas[i].NextCandleItem = sourceDatas[nIdx];
            }

            this.Invoke(new Action(() =>
            {
                dgvList.Rows.Clear();
                dgv.Rows.Clear();
                lbNoResult.Visible = false;

                for (int i = sourceDatas.Count - 1; i >= sourceDatas.Count - 50; i--)
                {
                    var data = sourceDatas[i];
                   
                    string date = Convert.ToDateTime(data.DTime).ToString("yy.MM.dd HH:mm");
                 
                    int index = dgvList.Rows.Add(date, "찾기2", "찾기3", "찾기4");

                    dgvList.Rows[index].Tag = data;

                    var pInfo = PatternUtil.GetCandlePatternInfo(data);
                    pInfo.TimeInterval = Convert.ToInt32(selectedTimeInterval);
                    pInfo.Product = selectedType;
                    pInfo.Item = selectedItem;

                    {
                        var pList = basicPattern.GetMatchPatterns2(pInfo);
                        if (pList.Count == 0)
                            ((DataGridViewButtonCell)dgvList.Rows[index].Cells[1]).Value = "";
                    }

                    {
                        var pList = basicPattern.GetMatchPatterns3(pInfo);
                        if (pList.Count == 0)
                            ((DataGridViewButtonCell)dgvList.Rows[index].Cells[2]).Value = "";
                    }

                    {
                        var pList = basicPattern.GetMatchPatterns4(pInfo);
                        if (pList.Count == 0)
                            ((DataGridViewButtonCell)dgvList.Rows[index].Cells[3]).Value = "";
                    }
                }

                dgvList.ClearSelection();

                Display();
            }));           
        }
        protected List<S_CandleItemData> loadData(string product = ""
            , string item = ""
            , TimeIntervalEnum timeInterval = TimeIntervalEnum.Day
            , DateTime? searchRangeDateS = null
            , DateTime? searchRangeDateE = null)
        {

            return PPUtils.LoadData(product, timeInterval, item, searchRangeDateS, searchRangeDateE);

            //List<S_CandleItemData> sourceDatas = null;

            //if (selectedType.Length == 0) return sourceDatas;
            //if (selectedType.Length == 0) return sourceDatas;

            //if (product == "국내업종")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "2", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "3", "0", "500");
            //}
            //else if (product == "국내지수")
            //{
            //    if (timeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "2", "0", "500");
            //    else if (timeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "3", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "1", "1", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "1", "5", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "1", "10", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "1", "30", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(item, "1", "60", "500");
            //}
            //else if (product == "국내종목")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "2", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "3", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "1", "1", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "1", "5", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "1", "10", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "1", "30", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(item, "1", "60", "500");
            //}
            //else if (product == "해외지수")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(item, "0");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(item, "1");
            //}
            //else if (product == "해외선물")
            //{
            //    if (searchRangeDateS != null && searchRangeDateE != null)
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "D", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "W", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "2H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "5H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "5M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "15M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(item, "30M", searchRangeDateS.Value, searchRangeDateE.Value);
            //    }
            //    else
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "D");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "W");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "2H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "5H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "5M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "15M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(item, "30M");
            //    }
            //}
            //else if (product == "암호화폐")
            //{
            //    if (searchRangeDateS != null && searchRangeDateE != null)
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "D", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "W", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "2H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "5H", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "5M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "15M", searchRangeDateS.Value, searchRangeDateE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(item, "30M", searchRangeDateS.Value, searchRangeDateE.Value);
            //    }
            //    else
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "D");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "W");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "2H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "5H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "5M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "15M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(item, "30M");
            //    }
            //}
            //else
            //    sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
            //      item
            //    , timeInterval);
            //return sourceDatas;
        }
        private void Display()
        {
            chart1.DisplayPointCount = displayCnt;
            chart1.LoadData(selectedItem, sourceDatas, selectedTimeInterval);            
        }
        #endregion


        #region Control Event
        private void dgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            BasicCandlePattern basicPattern = basicPatterns[selectedType];

            S_CandleItemData data = dgvList.Rows[e.RowIndex].Tag as S_CandleItemData;
            selCandleData = data;

            var pInfo = PatternUtil.GetCandlePatternInfo(selCandleData);
            pInfo.TimeInterval = Convert.ToInt32(selectedTimeInterval);
            pInfo.Product = selectedType;
            pInfo.Item = selectedItem;

            if (e.ColumnIndex == 1)
            {                
                var pList= basicPattern.GetMatchPatterns2(pInfo);

                dgv.Rows.Clear();
                if(pList.Count > 0) lbNoResult.Visible = false;
                else lbNoResult.Visible = true;

                foreach (var p in pList.OrderByDescending(t => t.CandlePatternType2))
                {
                    int idx = dgv.Rows.Add(p.Item
                        , getIntervalToString(p.TimeInterval)
                        , p.EndDT.ToString("yy.MM.dd HH:mm")
                        , Convert.ToString((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType2)));

                    var type = ((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType2));

                    if (type == CandlePatternTypeEnum.Up)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.Down)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.StrongUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.StrongDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.WeakUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.WeakDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;

                    dgv.Rows[idx].Tag = p;
                }
            }
            if (e.ColumnIndex == 2)
            {
                var pList = basicPattern.GetMatchPatterns3(pInfo);
                dgv.Rows.Clear();
                if (pList.Count > 0) lbNoResult.Visible = false;
                else lbNoResult.Visible = true;

                foreach (var p in pList.OrderByDescending(t => t.CandlePatternType3))
                {
                    int idx = dgv.Rows.Add(p.Item
                        , getIntervalToString(p.TimeInterval)
                        , p.EndDT.ToString("yy.MM.dd HH:mm")
                        , Convert.ToString((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType3)));

                    var type = ((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType3));

                    if (type == CandlePatternTypeEnum.Up)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.Down)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.StrongUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.StrongDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.WeakUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.WeakDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;

                    dgv.Rows[idx].Tag = p;
                }
            }
            if (e.ColumnIndex == 3)
            {
                var pList = basicPattern.GetMatchPatterns4(pInfo);

                dgv.Rows.Clear();
                if (pList.Count > 0) lbNoResult.Visible = false;
                else lbNoResult.Visible = true;

                foreach (var p in pList.OrderByDescending(t => t.CandlePatternType4))
                {
                    int idx = dgv.Rows.Add(p.Item
                        , getIntervalToString(p.TimeInterval)
                        , p.EndDT.ToString("yy.MM.dd HH:mm")
                        , Convert.ToString((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType4)));

                    var type = ((CandlePatternTypeEnum)Convert.ToInt32(p.CandlePatternType4));

                    if (type == CandlePatternTypeEnum.Up)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.Down)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.StrongUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.StrongDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;
                    else if (type == CandlePatternTypeEnum.WeakUp)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Red;
                    else if (type == CandlePatternTypeEnum.WeakDown)
                        dgv.Rows[idx].Cells[3].Style.ForeColor = Color.Blue;

                    dgv.Rows[idx].Tag = p;
                }
            }

            chart1.ClearChartLabel("1");
            chart1.ClearChartLabel("2");
            chart1.DisplayChartLabel(data, Color.Black, "1");
            chart1.DisplayView();
        }
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            string product = "";
            string item = "";

            TimeIntervalEnum interval = TimeIntervalEnum.Day;
            DateTime? searchRangeDateS = null;
            DateTime? searchRangeDateE = null;
            DateTime selectedDTime = DateTime.Now;
            
            var chooseData = dgv.Rows[e.RowIndex].Tag as CandlePatternData;
            product = chooseData.Product;
            item = chooseData.Item;
            interval = (TimeIntervalEnum)chooseData.TimeInterval;
            selectedDTime = chooseData.EndDT;

            if (product == "해외선물" || product == "암호화폐" || product == "국내지수" || product == "해외지수")
            {
                if (interval == TimeIntervalEnum.Minute_30)
                {
                    searchRangeDateS = chooseData.StartDT.AddDays(-1);
                    searchRangeDateE = chooseData.EndDT.AddDays(2);
                }
                if (interval == TimeIntervalEnum.Hour_01)
                {
                    searchRangeDateS = chooseData.StartDT.AddDays(-2);
                    searchRangeDateE = chooseData.EndDT.AddDays(5);
                }
                if (interval == TimeIntervalEnum.Hour_02)
                {
                    searchRangeDateS = chooseData.StartDT.AddDays(-3);
                    searchRangeDateE = chooseData.EndDT.AddDays(1);
                }
                if (interval == TimeIntervalEnum.Hour_05)
                {
                    searchRangeDateS = chooseData.StartDT.AddDays(-4);
                    searchRangeDateE = chooseData.EndDT.AddDays(1);
                }
                if (interval == TimeIntervalEnum.Day)
                {
                    searchRangeDateS = chooseData.StartDT.AddMonths(-1);
                    searchRangeDateE = chooseData.EndDT.AddMonths(2);
                }
                if (interval == TimeIntervalEnum.Week)
                {
                    searchRangeDateS = chooseData.StartDT.AddYears(-1);
                    searchRangeDateE = chooseData.EndDT.AddYears(2);
                }
            }

            var sourceDatas2 = loadData(product, item, interval, searchRangeDateS, searchRangeDateE);
            chart2.DisplayPointCount = displayCnt;
            chart2.LoadData(item, sourceDatas2, interval);
            chart2.DisplayChartLabel(selectedDTime, Color.Orange, "2");
            chart2.MoveView(selectedDTime);
        }

        private void btnLoadDaemon_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoadDaemonM.BackColor = 
                    btnLoadDaemonH.BackColor =
                    btnLoadDaemon2H.BackColor =
                    btnLoadDaemon5H.BackColor =
                    btnLoadDaemonD.BackColor = 
                    btnLoadDaemonW.BackColor = Color.White;
                Button btn = sender as Button;

                if (btn.Text == "M")
                {
                    selectedTimeInterval = TimeIntervalEnum.Minute_30;
                    btnLoadDaemonM.BackColor = Color.Red;
                }
                if (btn.Text == "H")
                { 
                    selectedTimeInterval = TimeIntervalEnum.Hour_01;
                    btnLoadDaemonH.BackColor = Color.Red;
                }
                if (btn.Text == "2H")
                {
                    selectedTimeInterval = TimeIntervalEnum.Hour_02;
                    btnLoadDaemon2H.BackColor = Color.Red;
                }
                if (btn.Text == "5H")
                {
                    selectedTimeInterval = TimeIntervalEnum.Hour_05;
                    btnLoadDaemon5H.BackColor = Color.Red;
                }
                if (btn.Text == "D")
                {
                    selectedTimeInterval = TimeIntervalEnum.Day;
                    btnLoadDaemonD.BackColor = Color.Red;
                }
                if (btn.Text == "W")
                {
                    selectedTimeInterval = TimeIntervalEnum.Week;
                    btnLoadDaemonW.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void nudDisplay_ValueChanged(object sender, EventArgs e)
        {
            displayCnt = Convert.ToInt32(nudDisplay.Value);
            Display();
        }

        private void cbxItem_SelectedIndexChanged(object sender, EventArgs e)
        {    
        }

        private void cbxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = cbxProduct.SelectedItem.ToString();
            setItems();           
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!basicPatterns.ContainsKey(selectedType))
            {
                MessageBox.Show("Load Data First!!!");
                return;
            }
            loadSiseDataFromDaemon();            
        }

        private string getIntervalToString(int interval)
        {
            if (interval == 5) return "M";
            else if (interval == 11) return "H";
            else if (interval == 12) return "2H";
            else if (interval == 15) return "5H";
            else if (interval == 20) return "D";
            else return "W";

        }

        private void cbxItem_KeyUp(object sender, KeyEventArgs e)
        {
            
          
        }

        private void cbxItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbxItem.Text.Length == 0)
            {
                string path = System.IO.Path.Combine(Environment.CurrentDirectory, "krItems.txt");
                List<string> lst = System.IO.File.ReadAllLines(path).ToList();
                cbxItem.DataSource = null;
                cbxItem.DataSource = lst;
            }

            if (cbxItem.Text.Length > 2)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string path = System.IO.Path.Combine(Environment.CurrentDirectory, "krItems.txt");
                    List<string> lst = System.IO.File.ReadAllLines(path).ToList();                  
                    int parseOut = 0;
                    bool isParse = Int32.TryParse(cbxItem.Text, out parseOut);
                    cbxItem.DataSource = null;
                    if(isParse)
                        cbxItem.DataSource = lst.Where(t => t.StartsWith(cbxItem.Text)).ToList();
                    else
                        cbxItem.DataSource = lst.Where(t => t.IndexOf(cbxItem.Text) > 1).ToList();
                }
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bmp = new Bitmap(tlpChart.Width, tlpChart.Height);
                tlpChart.DrawToBitmap(bmp, new Rectangle(0, 0, tlpChart.Width, tlpChart.Height));

                Clipboard.SetImage(bmp);

                MessageBox.Show("저장되었습니다.");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void btnLoadDB_Click(object sender, EventArgs e)
        {
            if (!basicPatterns.ContainsKey(selectedType))
                basicPatterns.Add(selectedType, new BasicCandlePattern());

            BasicCandlePattern basicPattern = basicPatterns[selectedType];

            Task.Factory.StartNew(() => {
                basicPattern.LoadPatternData(selectedType);               
                this.Invoke(new Action(() => { btnLoad.Enabled = true; }));
            });            
        }
    }
}
