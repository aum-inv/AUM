using MetroFramework;
using MetroFramework.Controls;
using OM.Atman.Chakra.App.Config;
using OM.Atman.Chakra.App.Events;
using OM.Atman.Chakra.App.Uc.Plans;
using OM.Atman.Chakra.Ctx;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace OM.Atman.Chakra.App.FinderForms
{
    public partial class AtmanKRItemFinderByVolRankForm2 : MetroFramework.Forms.MetroForm
    {
        int displayCnt = 60;   
        bool isRunningJongmok = false;

        public AtmanKRItemFinderByVolRankForm2()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {
            chart.IsShowXLine = chart.IsShowYLine = true;
            chart.InitializeControl();
            chart.InitializeEvent(null);
            chart.DisplayPointCount = displayCnt;
        }
        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
        }
                
        private void AtmanForm_Load(object sender, EventArgs e)
        {
            serverInfo();          
        }
       
        private void serverInfo()
        {
            AtmanServerConfigData.IP = ConfigurationManager.AppSettings["AtmanService_IP"];
            AtmanServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["AtmanService_Port"]);

            XingServerConfigData.IP = ConfigurationManager.AppSettings["XingService_IP"];
            XingServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["XingService_Port"]);
            XingContext.Instance.OnCreateClient();

            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);
            PPContext.Instance.OnCreateClient();
        }

        #region Control Event
       
        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string code = dgv.Rows[e.RowIndex].Cells[0].Value as string;
            string name = dgv.Rows[e.RowIndex].Cells[1].Value as string;

            tbSelectedCode2.Text = code;
            tbSelectedName2.Text = name;

            TimeIntervalEnum timeInterval = chkTD.Checked ? TimeIntervalEnum.Day : TimeIntervalEnum.Week;
            string timeIntervalStr = chkTD.Checked ? "2" : "3";

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, timeIntervalStr, "0", "300");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 300)
                    sourceDatas.RemoveRange(0, totalCnt - 300);

                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);               
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, timeInterval, 9);
                chart.SetYFormat("N0");
            });
        }
        #endregion

        private void btnSearchRank_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            string gubun = "0";
            if (chkKospi.Checked && chkKosdaq.Checked) gubun = "0";
            else if (chkKospi.Checked) gubun = "1";
            else if (chkKosdaq.Checked) gubun = "2";

            string sdiff = nudSdiff.Value.ToString();
            string ediff = nudEdiff.Value.ToString();

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongMokRankData(gubun, sdiff, ediff);
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                foreach (var item in sourceDatas)
                {
                    this.Invoke(new Action(() => {

                        int rIdx = dgv.Rows.Add(item.종목코드
                                                , item.종목명                                              
                                                , item.현재가
                                                , item.전일대비구분
                                                , item.등락율 + "%"
                                                , item.전일대비                                                   
                                                );

                        // 1:상한 2:상승 3:보합 4:하한 5:하락
                        if (item.전일대비구분 == "1")
                        {
                            dgv.Rows[rIdx].Cells[3].Value = "▲";
                            dgv.Rows[rIdx].Cells[3].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[4].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[5].Style.ForeColor = Color.Red;

                        }
                        else if (item.전일대비구분 == "2")
                        {
                            dgv.Rows[rIdx].Cells[3].Value = "△";
                            dgv.Rows[rIdx].Cells[3].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[4].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[5].Style.ForeColor = Color.Red;
                        }
                        else if (item.전일대비구분 == "3")
                        {
                            dgv.Rows[rIdx].Cells[3].Value = "◇";
                        }
                        else if (item.전일대비구분 == "5")
                        {
                            dgv.Rows[rIdx].Cells[3].Value = "▽";
                            dgv.Rows[rIdx].Cells[3].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[4].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[5].Style.ForeColor = Color.Blue;
                        }
                        else if (item.전일대비구분 == "4")
                        {
                            dgv.Rows[rIdx].Cells[3].Value = "▼";
                            dgv.Rows[rIdx].Cells[3].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[4].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[5].Style.ForeColor = Color.Blue;
                        }
                    }));
                }
            });
        }
              
        private void btnSearchJongmok_Click(object sender, EventArgs e)
        {
            if (!isRunningJongmok) isRunningJongmok = true;
            else
            {
                isRunningJongmok = false;
                return;
            }

            TimeIntervalEnum timeInterval = chkTD.Checked ? TimeIntervalEnum.Day : TimeIntervalEnum.Week;
            string timeIntervalStr = chkTD.Checked ? "2" : "3";

            Task.Factory.StartNew(() =>
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!isRunningJongmok) return;
                    string code = row.Cells[0].Value as string;

                    Task.Factory.StartNew(() =>
                    {
                        var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, timeIntervalStr, "0", "20");
                        if (sourceDatas == null || sourceDatas.Count == 0) return;
                        var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);

                        List<SmartCandleData> smartDataList = new List<SmartCandleData>();
                        SmartCandleData preSmartData = null;
                        for (int i = 0; i < averageDatas.Count; i++)
                        {
                            var cData = averageDatas[i];
                            SmartCandleData smartData = new SmartCandleData(cData.ItemCode, cData.OpenPrice, cData.HighPrice, cData.LowPrice, cData.ClosePrice, cData.Volume, cData.DTime, preSmartData);
                            smartDataList.Add(smartData);
                            preSmartData = smartData;                           
                        }

                        var sR0 = getSmartLine(0, smartDataList);
                        var sR1 = getSmartLine(1, smartDataList);
                        var sR2 = getSmartLine(2, smartDataList);
                        var sR3 = getSmartLine(3, smartDataList);
                        var sR4 = getSmartLine(4, smartDataList);
                        var sR5 = getSmartLine(5, smartDataList);
                        var sR6 = getSmartLine(6, smartDataList);
                        var sR7 = getSmartLine(7, smartDataList);
                        var sR8 = getSmartLine(8, smartDataList);

                        //this.Invoke(new Action(() => {

                        row.Cells["S8"].Value = sR8.Item1;
                        row.Cells["S8"].Style.ForeColor = sR8.Item2;
                        row.Cells["S7"].Value = sR7.Item1;
                        row.Cells["S7"].Style.ForeColor = sR7.Item2;
                        row.Cells["S6"].Value = sR6.Item1;
                        row.Cells["S6"].Style.ForeColor = sR6.Item2;
                        row.Cells["S5"].Value = sR5.Item1;
                        row.Cells["S5"].Style.ForeColor = sR5.Item2;
                        row.Cells["S4"].Value = sR4.Item1;
                        row.Cells["S4"].Style.ForeColor = sR4.Item2;
                        row.Cells["S3"].Value = sR3.Item1;
                        row.Cells["S3"].Style.ForeColor = sR3.Item2;
                        row.Cells["S2"].Value = sR2.Item1;
                        row.Cells["S2"].Style.ForeColor = sR2.Item2;
                        row.Cells["S1"].Value = sR1.Item1;
                        row.Cells["S1"].Style.ForeColor = sR1.Item2;
                        row.Cells["S0"].Value = sR0.Item1;
                        row.Cells["S0"].Style.ForeColor = sR0.Item2;

                        //}));                                                            
                    });

                    System.Threading.Thread.Sleep(2000);
                }
            });
        }

        private (string, Color) getSmartLine(int preCount, List<SmartCandleData> list)
        {
            var m1 = list[list.Count - 2 - preCount];
            var m0 = list[list.Count - 1 - preCount];

            if (m0.Variance_ChartPrice3 < 0 && m1.Variance_ChartPrice3 < m0.Variance_ChartPrice3) return ("▲", Color.Red);
            else if (m0.Variance_ChartPrice3 > 0 && m1.Variance_ChartPrice3 > m0.Variance_ChartPrice3) return ("▼", Color.Blue);
            else if (m0.Variance_ChartPrice3 > 0 && m1.Variance_ChartPrice3 < m0.Variance_ChartPrice3) return ("△", Color.Red);
            else if (m0.Variance_ChartPrice3 < 0 && m1.Variance_ChartPrice3 > m0.Variance_ChartPrice3) return ("▽", Color.Blue);

            else return ("◇", Color.Black);
        }
        private (string, Color) getSmartSmartLine(int preCount, List<SmartCandleData> list)
        {
            var m1 = list[list.Count - 2 - preCount];
            var m0 = list[list.Count - 1 - preCount];

            if (m1.Variance_ChartPrice1 < m0.Variance_ChartPrice2) return ("▲", Color.Red);
            else if (m1.Variance_ChartPrice1 > m0.Variance_ChartPrice2) return ("▼", Color.Blue);
            else return ("◇", Color.Black);
        }

        private void btnGoNaver_Click(object sender, EventArgs e)
        {
            if (tbSelectedCode2.Text.Length == 0) return;
            string url = "https://finance.naver.com/item/main.nhn?code=" + tbSelectedCode2.Text;
            System.Diagnostics.Process.Start("chrome", url);
        }

        private void btnGoAlpha_Click(object sender, EventArgs e)
        {
            if (tbSelectedCode2.Text.Length == 0) return;
            string url = "https://www.alphasquare.co.kr/home/stock/stock-summary?code=" + tbSelectedCode2.Text;
            System.Diagnostics.Process.Start("chrome", url);
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {
            string code = tbSelectedCode2.Text;

            TimeIntervalEnum timeInterval = chkTD.Checked ? TimeIntervalEnum.Day : TimeIntervalEnum.Week;
            string timeIntervalStr = chkTD.Checked ? "2" : "3";

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, timeIntervalStr, "0", "300");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 300)
                    sourceDatas.RemoveRange(0, totalCnt - 300);

                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, timeInterval, 9);
                chart.SetYFormat("N0");
            });
        }
    }
}
