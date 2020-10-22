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
    public partial class AtmanKRItemAIForm2 : MetroFramework.Forms.MetroForm
    {
        int displayCnt = 60;

        bool isRunningUpjong = false;
        bool isRunningJongmok = false;

        public AtmanKRItemAIForm2()
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
            setItems();
        }
        private void setItems()
        {
            string filePath = System.IO.Path.Combine(Environment.CurrentDirectory, "FinderForms", "업종.txt");
            var lines = File.ReadLines(filePath, Encoding.UTF8).ToList();
            dgvList.Rows.Clear();
            foreach (var line in lines) 
            {
                string[] values = line.Split("\t".ToCharArray());
                int rIdx = dgvList.Rows.Add(values[0]);
                dgvList.Rows[rIdx].Tag = values[1];
            }
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
        #region LoadDSiseata
   
       
        #endregion

        #region Control Event
        private void dgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string code = dgvList.Rows[e.RowIndex].Tag as string;
            string name = dgvList.Rows[e.RowIndex].Cells[0].Value as string;

            tbSelectedCode.Text = code;
            tbSelectedName.Text = name;

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(code, "2", "0", "100");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 100)
                    sourceDatas.RemoveRange(0, totalCnt - 100);
                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);                
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, TimeIntervalEnum.Day, 9);
                chart.SetYFormat("N0");
            });

            dgv.Rows.Clear();
            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetUpJongJongMokData(code);
                if (sourceDatas == null || sourceDatas.Count == 0) return;

                foreach (var item in sourceDatas)
                {
                    this.Invoke(new Action(() => {
                        
                        int rIdx = dgv.Rows.Add(item.종목코드
                                                , item.종목명
                                                , item.시가
                                                , item.고가
                                                , item.저가
                                                , item.현재가
                                                , item.전일대비구분
                                                , item.등락율 + "%"
                                                , item.전일대비
                                                , item.외인순매수
                                                , item.기관순매수                                                
                                                , item.거래대금
                                                , item.거래증가율
                                                , item.시가총액
                                                );

                        // 1:상한 2:상승 3:보합 4:하한 5:하락
                        if (item.전일대비구분 == "1")
                        {
                            dgv.Rows[rIdx].Cells[6].Value = "▲";
                            dgv.Rows[rIdx].Cells[6].Style.ForeColor = 
                            dgv.Rows[rIdx].Cells[7].Style.ForeColor = 
                            dgv.Rows[rIdx].Cells[8].Style.ForeColor = Color.Red;
                            
                        }
                        else if (item.전일대비구분 == "2")
                        {
                            dgv.Rows[rIdx].Cells[6].Value = "△";
                            dgv.Rows[rIdx].Cells[6].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[7].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[8].Style.ForeColor = Color.Red;
                        }
                        else if (item.전일대비구분 == "3")
                        {
                            dgv.Rows[rIdx].Cells[6].Value = "◇";
                        }
                        else if (item.전일대비구분 == "5")
                        {
                            dgv.Rows[rIdx].Cells[6].Value = "▽";
                            dgv.Rows[rIdx].Cells[6].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[7].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[8].Style.ForeColor = Color.Blue;
                        }
                        else if (item.전일대비구분 == "4")
                        {
                            dgv.Rows[rIdx].Cells[6].Value = "▼";
                            dgv.Rows[rIdx].Cells[6].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[7].Style.ForeColor =
                            dgv.Rows[rIdx].Cells[8].Style.ForeColor = Color.Blue;
                        }

                        if (item.거래증가율 > 0)
                        {
                            dgv.Rows[rIdx].Cells[11].Style.ForeColor
                            = dgv.Rows[rIdx].Cells[12].Style.ForeColor = Color.Red;
                        }
                        else if (item.거래증가율 < 0)
                        {
                            dgv.Rows[rIdx].Cells[11].Style.ForeColor
                             = dgv.Rows[rIdx].Cells[12].Style.ForeColor = Color.Blue;
                        }

                    }));
                }
            });
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string code = dgv.Rows[e.RowIndex].Cells[0].Value as string;
            string name = dgv.Rows[e.RowIndex].Cells[1].Value as string;

            tbSelectedCode2.Text = code;
            tbSelectedName2.Text = name;

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, "2", "0", "300");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 300)
                    sourceDatas.RemoveRange(0, totalCnt - 300);
                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);               
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, TimeIntervalEnum.Day, 9);
                chart.SetYFormat("N0");
            });
        }
        #endregion
               
        private void btnSearchUpjong_Click(object sender, EventArgs e)
        {
            if (!isRunningUpjong) isRunningUpjong = true;
            else
            {
                isRunningUpjong = false;
                return;
            }

            Task.Factory.StartNew(() =>
            {
                foreach (DataGridViewRow row in dgvList.Rows)
                {
                    if (!isRunningUpjong) return;

                    string code = row.Tag as string;
                
                    Task.Factory.StartNew(() => 
                    {
                        var sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(code, "2", "0", "50");
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

                        var swR4 = getSmartSmartLine(4, smartDataList);
                        var swR3 = getSmartSmartLine(3, smartDataList);
                        var swR2 = getSmartSmartLine(2, smartDataList);
                        var swR1 = getSmartSmartLine(1, smartDataList);
                        var swR0 = getSmartSmartLine(0, smartDataList);

                        //this.Invoke(new Action(() => {
                        row.Cells["S3"].Value = sR3.Item1;
                        row.Cells["S3"].Style.ForeColor = sR3.Item2;
                        row.Cells["S2"].Value = sR2.Item1;
                        row.Cells["S2"].Style.ForeColor = sR2.Item2;
                        row.Cells["S1"].Value = sR1.Item1;
                        row.Cells["S1"].Style.ForeColor = sR1.Item2;
                        row.Cells["S0"].Value = sR0.Item1;
                        row.Cells["S0"].Style.ForeColor = sR0.Item2;

                        row.Cells["SW4"].Value = swR4.Item1;
                        row.Cells["SW4"].Style.ForeColor = swR4.Item2;
                        row.Cells["SW3"].Value = swR3.Item1;
                        row.Cells["SW3"].Style.ForeColor = swR3.Item2;
                        row.Cells["SW2"].Value = swR2.Item1;
                        row.Cells["SW2"].Style.ForeColor = swR2.Item2;
                        row.Cells["SW1"].Value = swR1.Item1;
                        row.Cells["SW1"].Style.ForeColor = swR1.Item2;
                        row.Cells["SW0"].Value = swR0.Item1;
                        row.Cells["SW0"].Style.ForeColor = swR0.Item2;

                        //}));                                                 
                    });

                    System.Threading.Thread.Sleep(2000);                   
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

            Task.Factory.StartNew(() =>
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (!isRunningJongmok) return;
                    string code = row.Cells[0].Value as string;

                    Task.Factory.StartNew(() =>
                    {
                        var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, "2", "0", "50");
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

                        var swR4 = getSmartSmartLine(4, smartDataList);
                        var swR3 = getSmartSmartLine(3, smartDataList);
                        var swR2 = getSmartSmartLine(2, smartDataList);
                        var swR1 = getSmartSmartLine(1, smartDataList);
                        var swR0 = getSmartSmartLine(0, smartDataList);

                        //this.Invoke(new Action(() => {
                        row.Cells["IS3"].Value = sR3.Item1;
                        row.Cells["IS3"].Style.ForeColor = sR3.Item2;
                        row.Cells["IS2"].Value = sR2.Item1;
                        row.Cells["IS2"].Style.ForeColor = sR2.Item2;
                        row.Cells["IS1"].Value = sR1.Item1;
                        row.Cells["IS1"].Style.ForeColor = sR1.Item2;
                        row.Cells["IS0"].Value = sR0.Item1;
                        row.Cells["IS0"].Style.ForeColor = sR0.Item2;

                        row.Cells["ISW4"].Value = swR4.Item1;
                        row.Cells["ISW4"].Style.ForeColor = swR4.Item2;
                        row.Cells["ISW3"].Value = swR3.Item1;
                        row.Cells["ISW3"].Style.ForeColor = swR3.Item2;
                        row.Cells["ISW2"].Value = swR2.Item1;
                        row.Cells["ISW2"].Style.ForeColor = swR2.Item2;
                        row.Cells["ISW1"].Value = swR1.Item1;
                        row.Cells["ISW1"].Style.ForeColor = swR1.Item2;
                        row.Cells["ISW0"].Value = swR0.Item1;
                        row.Cells["ISW0"].Style.ForeColor = swR0.Item2;
                    });

                    System.Threading.Thread.Sleep(2000);
                }
            });
        }

        private (string, Color) getSmartLine(int preCount, List<SmartCandleData> list)
        {
            var m1 = list[list.Count - 2 - preCount];
            var m0 = list[list.Count - 1 - preCount];

            if (m1.Variance_ChartPrice2 < m0.Variance_ChartPrice2) return ("▲", Color.Red);
            else if (m1.Variance_ChartPrice2 > m0.Variance_ChartPrice2) return ("▼", Color.Blue);
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

        private void lblTitlePgr_Click(object sender, EventArgs e)
        {
            string code = tbSelectedCode.Text;

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetUpJongSiseData(code, "2", "0", "100");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 100)
                    sourceDatas.RemoveRange(0, totalCnt - 100);
                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, TimeIntervalEnum.Day, 9);
                chart.SetYFormat("N0");
            });
        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {
            string code = tbSelectedCode2.Text;

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, "2", "0", "300");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 300)
                    sourceDatas.RemoveRange(0, totalCnt - 300);
                var averageDatas = PPUtils.GetAverageDatas(code, sourceDatas, 9);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, averageDatas, TimeIntervalEnum.Day, 9);
                chart.SetYFormat("N0");
            });
        }
    }
}
