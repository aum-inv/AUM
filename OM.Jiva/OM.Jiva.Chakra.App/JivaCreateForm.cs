using MetroFramework;
using MetroFramework.Controls;
using OM.Jiva.Chakra.Entities;
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
    public partial class JivaCreateForm : MetroFramework.Forms.MetroForm
    {
        List<S_CandleItemData> sourceDatas = null;

        string selectedType = "국내지수";
        TimeIntervalEnum selectedTimeInterval = TimeIntervalEnum.Day;
        string selectedItem = "101";
        string selectedCandleType = "F";

        bool isAuto = false;
        bool isNoData = false;
        public JivaCreateForm()
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
                dgv.Rows.Add(selectedItem
                    , item.OpenPrice.ToString()
                    , item.HighPrice.ToString()
                    , item.LowPrice.ToString()
                    , item.ClosePrice.ToString()
                    , item.PreCandleItem.DTime.ToString("yy.MM.dd HH:mm")
                    , item.DTime.ToString("yy.MM.dd HH:mm")
                    , ""
                    , ""
                    , ""); ;
            }            
        }
        private void btnLoad2_Click(object sender, EventArgs e)
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

            sourceDatas = loadDBData();

            for (int i = 0; i < sourceDatas.Count; i++)
            {
                int pIdx = i - 1 < 0 ? 0 : i - 1;
                int nIdx = i + 1 == sourceDatas.Count ? i : i + 1;

                sourceDatas[i].PreCandleItem = sourceDatas[pIdx];
                sourceDatas[i].NextCandleItem = sourceDatas[nIdx];
            }

            dgv.Rows.Clear();
            var item = sourceDatas.First();
            dgv.Rows.Add(selectedItem
                    , item.OpenPrice.ToString()
                    , item.HighPrice.ToString()
                    , item.LowPrice.ToString()
                    , item.ClosePrice.ToString()
                    , item.PreCandleItem.DTime.ToString("yy.MM.dd HH:mm")
                    , item.DTime.ToString("yy.MM.dd HH:mm")
                    , ""
                    , ""
                    , "");

            item = sourceDatas.Last();
            dgv.Rows.Add(selectedItem
                   , item.OpenPrice.ToString()
                   , item.HighPrice.ToString()
                   , item.LowPrice.ToString()
                   , item.ClosePrice.ToString()
                   , item.PreCandleItem.DTime.ToString("yy.MM.dd HH:mm")
                   , item.DTime.ToString("yy.MM.dd HH:mm")
                   , ""
                   , ""
                   , "");
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            int idx = -1;

            if (isAuto == true && sourceDatas.Count == 0)
            {
                isNoData = true;
                return;
            }

           
            {
                foreach (var item in sourceDatas)
                {
                    idx++;
                    if (idx < 4) continue;
                    if (item.PreCandleItem == null) continue;
                    if (item.PreCandleItem.PreCandleItem == null) continue;
                    if (item.PreCandleItem.PreCandleItem.PreCandleItem == null) continue;
                    if (item.PreCandleItem.PreCandleItem.PreCandleItem.PreCandleItem == null) continue;
                 
                    var p3 = item.PreCandleItem.PreCandleItem.PreCandleItem;
                    var p2 = item.PreCandleItem.PreCandleItem;
                    var p1 = item.PreCandleItem;
                    var p0 = item;

                    var n1 = item.NextCandleItem;
                    var n2 = item.NextCandleItem.NextCandleItem;
                    var n3 = item.NextCandleItem.NextCandleItem.NextCandleItem;

                    var pList4 = new List<S_CandleItemData>() { p3, p2, p1, p0 };
                    var nList4 = new List<S_CandleItemData>() { n1, n2, n3 };
                    var cpType4 = PatternUtil.GetCandlePatternType(p0, pList4, nList4);

                    var pList3 = new List<S_CandleItemData>() { p2, p1, p0 };
                    var nList3 = new List<S_CandleItemData>() { n1, n2, n3 };
                    var cpType3 = PatternUtil.GetCandlePatternType(p0, pList3, nList3);

                    var pList2 = new List<S_CandleItemData>() { p1, p0 };
                    var nList2 = new List<S_CandleItemData>() { n1, n2, n3 };
                    var cpType2 = PatternUtil.GetCandlePatternType(p0, pList2, nList2);
                    if (idx < dgv.Rows.Count)
                    {
                        dgv.Rows[idx].Cells["pattern4"].Value = Convert.ToString(cpType4);
                        dgv.Rows[idx].Cells["pattern3"].Value = Convert.ToString(cpType3);
                        dgv.Rows[idx].Cells["pattern2"].Value = Convert.ToString(cpType2);
                    }
                    //dgv.Rows[idx].Cells["pattern"].Value = Convert.ToString(p0.GForceType);

                    if (item.OpenPrice == 0 || item.HighPrice == 0 || item.LowPrice == 0 || item.ClosePrice == 0)
                        continue;

                    try
                    {
                        var data = new Entities.CandleForcePatternData();                      
                        data.Item = selectedItem;
                        data.Product = selectedType;
                        data.TimeInterval = Convert.ToInt32(selectedTimeInterval);

                        data.CandlePatternType4 = Convert.ToInt32(cpType4).ToString();
                        data.CandlePatternType3 = Convert.ToInt32(cpType3).ToString();
                        data.CandlePatternType2 = Convert.ToInt32(cpType2).ToString();

                        data.GForceType_P3 = Convert.ToInt32(p3.GForceType).ToString();
                        data.GForceType_P2 = Convert.ToInt32(p2.GForceType).ToString();
                        data.GForceType_P1 = Convert.ToInt32(p1.GForceType).ToString();
                        data.GForceType_P0 = Convert.ToInt32(p0.GForceType).ToString();

                        data.EForceType_OC_P3 = Convert.ToInt32(p3.EForceType_OC).ToString();
                        data.EForceType_OC_P2 = Convert.ToInt32(p2.EForceType_OC).ToString();
                        data.EForceType_OC_P1 = Convert.ToInt32(p1.EForceType_OC).ToString();
                        data.EForceType_OC_P0 = Convert.ToInt32(p0.EForceType_OC).ToString();

                        data.EForceType_CC_P3 = Convert.ToInt32(p3.EForceType_CC).ToString();
                        data.EForceType_CC_P2 = Convert.ToInt32(p2.EForceType_CC).ToString();
                        data.EForceType_CC_P1 = Convert.ToInt32(p1.EForceType_CC).ToString();
                        data.EForceType_CC_P0 = Convert.ToInt32(p0.EForceType_CC).ToString();

                        data.SForceType_O_P3 = Convert.ToInt32(p3.SForceType_O).ToString();
                        data.SForceType_O_P2 = Convert.ToInt32(p2.SForceType_O).ToString();
                        data.SForceType_O_P1 = Convert.ToInt32(p1.SForceType_O).ToString();
                        data.SForceType_O_P0 = Convert.ToInt32(p0.SForceType_O).ToString();

                        data.SForceType_H_P3 = Convert.ToInt32(p3.SForceType_H).ToString();
                        data.SForceType_H_P2 = Convert.ToInt32(p2.SForceType_H).ToString();
                        data.SForceType_H_P1 = Convert.ToInt32(p1.SForceType_H).ToString();
                        data.SForceType_H_P0 = Convert.ToInt32(p0.SForceType_H).ToString();

                        data.SForceType_L_P3 = Convert.ToInt32(p3.SForceType_L).ToString();
                        data.SForceType_L_P2 = Convert.ToInt32(p2.SForceType_L).ToString();
                        data.SForceType_L_P1 = Convert.ToInt32(p1.SForceType_L).ToString();
                        data.SForceType_L_P0 = Convert.ToInt32(p0.SForceType_L).ToString();

                        data.SForceType_C_P3 = Convert.ToInt32(p3.SForceType_C).ToString();
                        data.SForceType_C_P2 = Convert.ToInt32(p2.SForceType_C).ToString();
                        data.SForceType_C_P1 = Convert.ToInt32(p1.SForceType_C).ToString();
                        data.SForceType_C_P0 = Convert.ToInt32(p0.SForceType_C).ToString();

                        data.WForceType_T_P3 = Convert.ToInt32(p3.WForceType_T).ToString();
                        data.WForceType_T_P2 = Convert.ToInt32(p2.WForceType_T).ToString();
                        data.WForceType_T_P1 = Convert.ToInt32(p1.WForceType_T).ToString();
                        data.WForceType_T_P0 = Convert.ToInt32(p0.WForceType_T).ToString();

                        data.WForceType_H_P3 = Convert.ToInt32(p3.WForceType_H).ToString();
                        data.WForceType_H_P2 = Convert.ToInt32(p2.WForceType_H).ToString();
                        data.WForceType_H_P1 = Convert.ToInt32(p1.WForceType_H).ToString();
                        data.WForceType_H_P0 = Convert.ToInt32(p0.WForceType_H).ToString();

                        data.WForceType_B_P3 = Convert.ToInt32(p3.WForceType_B).ToString();
                        data.WForceType_B_P2 = Convert.ToInt32(p2.WForceType_B).ToString();
                        data.WForceType_B_P1 = Convert.ToInt32(p1.WForceType_B).ToString();
                        data.WForceType_B_P0 = Convert.ToInt32(p0.WForceType_B).ToString();

                        data.WForceType_L_P3 = Convert.ToInt32(p3.WForceType_L).ToString();
                        data.WForceType_L_P2 = Convert.ToInt32(p2.WForceType_L).ToString();
                        data.WForceType_L_P1 = Convert.ToInt32(p1.WForceType_L).ToString();
                        data.WForceType_L_P0 = Convert.ToInt32(p0.WForceType_L).ToString();

                        data.StartDT = p0.DTime;
                        data.EndDT = p0.DTime;

                        data.Create();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            
            {
                idx = -1;
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

                    {
                        var pList4 = new List<S_CandleItemData>() { p3, p2, p1, p0 };
                        var nList4 = new List<S_CandleItemData>() { n1, n2, n3 };
                        var cpType4 = PatternUtil.GetCandlePatternType(p0, pList4, nList4);

                        var pList3 = new List<S_CandleItemData>() { p2, p1, p0 };
                        var nList3 = new List<S_CandleItemData>() { n1, n2, n3 };
                        var cpType3 = PatternUtil.GetCandlePatternType(p0, pList3, nList3);

                        var pList2 = new List<S_CandleItemData>() { p1, p0 };
                        var nList2 = new List<S_CandleItemData>() { n1, n2, n3 };
                        var cpType2 = PatternUtil.GetCandlePatternType(p0, pList2, nList2);
                        if (idx < dgv.Rows.Count)
                        {
                            dgv.Rows[idx].Cells["pattern4"].Value = Convert.ToString(cpType4);
                            dgv.Rows[idx].Cells["pattern3"].Value = Convert.ToString(cpType3);
                            dgv.Rows[idx].Cells["pattern2"].Value = Convert.ToString(cpType2);
                        }

                        if (item.OpenPrice == 0 || item.HighPrice == 0 || item.LowPrice == 0 || item.ClosePrice == 0)
                            continue;

                        try
                        {
                            var data = new Entities.CandlePatternData();                            
                            data.Item = selectedItem;
                            data.Product = selectedType;
                            data.TimeInterval = Convert.ToInt32(selectedTimeInterval);
                            data.CandlePatternType4 = Convert.ToInt32(cpType4).ToString();
                            data.CandlePatternType3 = Convert.ToInt32(cpType3).ToString();
                            data.CandlePatternType2 = Convert.ToInt32(cpType2).ToString();

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

                            data.StartDT = p0.DTime;
                            data.EndDT = p0.DTime;

                            data.Create();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        protected List<S_CandleItemData> loadData()
        {
            DateTime? dtS = null;
            if (dtpS.Checked) dtS = dtpS.Value;
            DateTime? dtE = null;
            if (dtpE.Checked) dtE = dtpE.Value;
            return PPUtils.LoadData(selectedType, selectedTimeInterval, selectedItem, dtS, dtE);

            //List<S_CandleItemData> sourceDatas = null;

            //if (selectedType == "국내업종")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "2", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "3", "0", "500");
            //}
            //else if (selectedType == "국내지수")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "2", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "3", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "1", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "5", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "10", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "30", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(selectedItem, "1", "60", "500");
            //}
            //else if (selectedType == "국내종목")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "2", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "3", "0", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "1", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "5", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_10)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "10", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "30", "500");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //        sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(selectedItem, "1", "60", "500");
            //}
            //else if (selectedType == "해외지수")
            //{
            //    if (selectedTimeInterval == TimeIntervalEnum.Day)
            //        sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(selectedItem, "0");
            //    else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //        sourceDatas = XingContext.Instance.ClientContext.GetWorldIndexSiseData(selectedItem, "1");
            //}
            //else if (selectedType == "해외선물")
            //{
            //    if (dtpS.Checked && dtpE.Checked)
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "D", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "W", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "2H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "5H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "5M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "15M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseDataByRange(selectedItem, "30M", dtpS.Value, dtpE.Value);
            //    }
            //    else
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "D");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "W");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "2H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "5H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "5M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "15M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetWorldFutureSiseData(selectedItem, "30M");
            //    }
            //}
            //else if (selectedType == "암호화폐")
            //{
            //    if (dtpS.Checked && dtpE.Checked)
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "D", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "W", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "2H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "5H", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "5M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "15M", dtpS.Value, dtpE.Value);
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseDataByRange(selectedItem, "30M", dtpS.Value, dtpE.Value);
            //    }
            //    else
            //    {
            //        if (selectedTimeInterval == TimeIntervalEnum.Day)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "D");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Week)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "W");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_02)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "2H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Hour_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "5H");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_01)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_05)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "5M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_15)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "15M");
            //        else if (selectedTimeInterval == TimeIntervalEnum.Minute_30)
            //            sourceDatas = XingContext.Instance.ClientContext.GetCryptoSiseData(selectedItem, "30M");
            //    }
            //}
            //else
            //    sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
            //      selectedItem
            //    , selectedTimeInterval);
            //return sourceDatas;
        }
        protected List<S_CandleItemData> loadDBData()
        {
            List<S_CandleItemData> sourceDatas = new List<S_CandleItemData>();
            CandleHistoryData history = new CandleHistoryData();
            history.Product = selectedType;
            history.Item = selectedItem;
            history.TimeInterval = Convert.ToInt32(selectedTimeInterval);

            var list = history.Collect().Cast<CandleHistoryData>().ToList();
            foreach (var m in list)
            {
                var item = new S_CandleItemData();                
                item.ItemCode = m.Item;
                item.DTime = m.DTime;
                item.OpenPrice = Convert.ToSingle( m.OpenPrice);
                item.HighPrice = Convert.ToSingle(m.HighPrice);
                item.LowPrice = Convert.ToSingle(m.LowPrice);
                item.ClosePrice = Convert.ToSingle(m.ClosePrice);              
                item.Volume = Convert.ToSingle(m.Volume);

                sourceDatas.Add(item);
            }           
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
