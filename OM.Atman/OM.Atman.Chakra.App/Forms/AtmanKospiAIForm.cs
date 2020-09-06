using MetroFramework;
using MetroFramework.Controls;
using OM.Atman.Chakra.App.Config;
using OM.Atman.Chakra.App.Events;
using OM.Atman.Chakra.App.Uc.Plans;
using OM.Atman.Chakra.Ctx;
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
using System.Xml;

namespace OM.Atman.Chakra.App.Forms
{
    public partial class AtmanKospiAIForm : MetroFramework.Forms.MetroForm
    {
        List<SmartCandleData> scList = new List<SmartCandleData>();

        SmartCandleData selCandleData = null;

       
        public AtmanKospiAIForm()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {
            chart.InitializeControl();
            chart.InitializeEvent(null);
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
        #region LoadDSiseata
        private void openFile_FileOk(object sender, EventArgs e)
        {
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFile.FileName;
                    Task.Factory.StartNew(() =>
                    {
                        loadSiseDataFromFile(fileName);
                    });
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }
        private void btnLoadDaemon_Click(object sender, EventArgs e)
        {
            try
            {

                Task.Factory.StartNew(() =>
                {
                    loadSiseDataFromDaemon();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void loadSiseDataFromFile(string fileName)
        {
            try
            {
                string itemType = string.Empty;
                string siseInterval = string.Empty;
                var lines = File.ReadLines(fileName, Encoding.Default).ToList();

                if(lines.Count == 0) return;

                scList.Clear();
                {
                    string[] values = lines[0].Split("\t".ToCharArray());
                    if (values[0].StartsWith("["))
                    {
                        itemType = values[0].Replace("[일시]", "");
                        siseInterval = values[1].Trim() == "시간" ? "분" : "일";
                    }
                }
                SmartCandleData preData = null;

                for (int i = lines.Count - 1; i > 0; i--)
                {                    
                    var line = lines[i];
                    string[] values = lines[i].Split("\t".ToCharArray());
                    if (siseInterval == "일")
                    {
                        SmartCandleData data = new SmartCandleData(
                            itemType,
                            Convert.ToDouble(values[1].Trim()),
                            Convert.ToDouble(values[2].Trim()),
                            Convert.ToDouble(values[3].Trim()),
                            Convert.ToDouble(values[4].Trim()),
                            Convert.ToDouble(values[7].Trim().Replace(",", "")),
                            Convert.ToDateTime(values[0].Trim()),
                            preData);
                        preData = data;
                        scList.Add(data);
                    }
                    else
                    {
                        SmartCandleData data = new SmartCandleData(
                            itemType,
                            Convert.ToDouble(values[2].Trim()),
                            Convert.ToDouble(values[3].Trim()),
                            Convert.ToDouble(values[4].Trim()),
                            Convert.ToDouble(values[5].Trim()),
                            Convert.ToDouble(values[8].Trim().Replace(",", "")),
                            Convert.ToDateTime(values[0].Trim() + " " + values[1].Trim()),
                            preData);
                        preData = data;
                        scList.Add(data);
                    }
                }

                if (scList.Count > 3)
                {
                    scList.RemoveAt(0);
                    scList.RemoveAt(0);
                    scList.RemoveAt(0);

                    
                    this.Invoke(new Action(() =>
                    {
                        dgvList.Rows.Clear();
                    }));
                    
                    for (int i = scList.Count - 1; i >= 0 ; i--)
                    {
                        this.Invoke(new Action(() =>
                        {
                            var data = scList[i];
                            //var item = new Uc.Uc_SiseListItem();
                            //item.Index = index++;
                            //item.SetData(data);
                            //flpList.Controls.Add(item);

                            string title = data.BasicPrice_Close.ToString("N2");
                            string date = Convert.ToDateTime(data.DTime).ToString("yy.MM.dd HH:mm");
                            string tenergy = data.TimeEnergy.ToString("N7");
                            string senergy = data.SpaceEnergy.ToString("N7");

                            int index = dgvList.Rows.Add(date, title, senergy, tenergy);
                            dgvList.Rows[index].Tag = data;
                        }));
                    }

                    this.Invoke(new Action(() =>
                    {
                        dgvList.ClearSelection();
                        lblCnt.Text = scList.Count.ToString("N0");
                    }));

                    chart.LoadData("101", scList, Lib.Base.Enums.TimeIntervalEnum.Day);                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        void loadSiseDataFromDaemon()
        {
            var sourceDatas = PPContext.Instance.ClientContext.GetCandleSourceDataOrderByAsc(
                      "101"
                    , Lib.Base.Enums.TimeIntervalEnum.Day);
            if (sourceDatas == null || sourceDatas.Count == 0) return;

            scList.Clear();
            this.Invoke(new Action(() =>
            {
                dgvList.Rows.Clear();
            }));

            SmartCandleData preData = null;

            for (int i = 0; i < sourceDatas.Count; i++)
            {
                var value = sourceDatas[i];

                SmartCandleData data = new SmartCandleData(
                        value.ItemCode,
                        Convert.ToDouble(value.OpenPrice),
                        Convert.ToDouble(value.HighPrice),
                        Convert.ToDouble(value.LowPrice),
                        Convert.ToDouble(value.ClosePrice),
                        Convert.ToDouble(value.Volume),
                        Convert.ToDateTime(value.DTime),
                        preData);
                preData = data;
                scList.Add(data);
            }
            if (scList.Count < 3) return;

            scList.RemoveAt(0);
            scList.RemoveAt(0);
            scList.RemoveAt(0);

            this.Invoke(new Action(() =>
            {
                for (int i = scList.Count - 1; i >= 0; i--)
                {
                    var data = scList[i];
                    string title = data.BasicPrice_Close.ToString("N2");
                    string date = Convert.ToDateTime(data.DTime).ToString("yy.MM.dd HH:mm");
                    string tenergy = data.TimeEnergy.ToString("N7");
                    string senergy = data.SpaceEnergy.ToString("N7");

                    int index = dgvList.Rows.Add(date, title, senergy, tenergy);
                    dgvList.Rows[index].Tag = data;
                }

                dgvList.ClearSelection();
                lblCnt.Text = scList.Count.ToString("N0");

                chart.LoadData("101", scList, Lib.Base.Enums.TimeIntervalEnum.Day);
            }));           
        }
        #endregion

        #region Result Grid
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            SmartCandleData chooseData = dgv.Rows[e.RowIndex].Tag as SmartCandleData;

            chart.ClearChartLabel("2");
            chart.DisplayChartLabel(chooseData, Color.Orange, "2");
        }
        #endregion

        #region Search 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (selCandleData == null) return;
            lbNoResult.Visible = false;
            try
            {               
                Task.Factory.StartNew(() =>
                {
                    Searching();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Searching()
        {
            Dictionary<SmartCandleData, double> allEnergySearch = new Dictionary<SmartCandleData, double>();
            Dictionary<SmartCandleData, double> totalEnergySearch = new Dictionary<SmartCandleData, double>();
            Dictionary<SmartCandleData, double> timeEnergySearch = new Dictionary<SmartCandleData, double>();
            Dictionary<SmartCandleData, double> spaceEnergySearch = new Dictionary<SmartCandleData, double>();

            foreach (var data in scList)
            {
                if (data == selCandleData)
                    break;

                double diffTotal = Math.Abs(selCandleData.TotalEnergy - data.TotalEnergy);
                totalEnergySearch.Add(data, diffTotal);            
             
                double diffTime = Math.Abs(selCandleData.TimeEnergy - data.TimeEnergy);
                timeEnergySearch.Add(data, diffTime);
               
                double diffSpace = Math.Abs(selCandleData.SpaceEnergy - data.SpaceEnergy);
                spaceEnergySearch.Add(data, diffSpace);

                double diffColor = 0;
                if (data.BasicPriceColorType != selCandleData.BasicPriceColorType)
                    diffColor += 0.1;
                if (data.ComparedPreviousDayPriceColorType != selCandleData.ComparedPreviousDayPriceColorType)
                    diffColor += 0.1;

                double diffAll = Math.Abs(diffTotal + diffTime + diffSpace + diffColor);

                allEnergySearch.Add(data, diffAll);
            }


            List<KeyValuePair<SmartCandleData, double>> allEnergyRank = new List<KeyValuePair<SmartCandleData, double>>();
            List<KeyValuePair<SmartCandleData, double>> totalEnergyRank = new List<KeyValuePair<SmartCandleData, double>>();
            List<KeyValuePair<SmartCandleData, double>> timeEnergyRank = new List<KeyValuePair<SmartCandleData, double>>();
            List<KeyValuePair<SmartCandleData, double>> spaceEnergyRank = new List<KeyValuePair<SmartCandleData, double>>();

            foreach (KeyValuePair<SmartCandleData, double> item in allEnergySearch.OrderBy(t => t.Value).ToList())
            {
                allEnergyRank.Add(item);
            }
            foreach (KeyValuePair<SmartCandleData, double> item in totalEnergySearch.OrderBy(t => t.Value).ToList())
            {
                totalEnergyRank.Add(item);
            }
            foreach (KeyValuePair<SmartCandleData, double> item in timeEnergySearch.OrderBy(t => t.Value).ToList())
            {
                timeEnergyRank.Add(item);
            }
            foreach (KeyValuePair<SmartCandleData, double> item in spaceEnergySearch.OrderBy(t => t.Value).ToList())
            {
                spaceEnergyRank.Add(item);
            }

         
            this.Invoke(new Action(() =>
            {
                dgv.Rows.Clear();
                chart.ClearChartLabel("2");               
            }));

            int resultCount = 0;
            
            foreach (var item in totalEnergyRank)
            {              
                var data = item.Key;
                 
                int allRank = getRank(allEnergyRank, data);
                int totalRank = getRank(totalEnergyRank, data);
                int timeRank = getRank(timeEnergyRank, data);
                int spaceRank = getRank(spaceEnergyRank, data);

                if (timeRank > 10 || spaceRank > 10 || totalRank > 10) continue;

                resultCount++;
                double allValue = getValue(allEnergyRank, data);
                double totalValue = getValue(totalEnergyRank, data);
                double timeValue = getValue(timeEnergyRank, data);
                double spaceValue = getValue(spaceEnergyRank, data);

                this.Invoke(new Action(() =>
                {
                    int idx = dgv.Rows.Add(
                            Convert.ToDateTime(data.DTime).ToString("yy.MM.dd HH:mm")
                        , data.BasicPrice_Open
                        , data.BasicPrice_High
                        , data.BasicPrice_Low
                        , data.BasicPrice_Close
                        , data.PreviousCandleData.BasicPrice_Close
                        , data.BasicPriceColorType
                        , data.ComparedPreviousDayPriceColorType
                        , allValue
                        , totalValue
                        , spaceValue
                        , timeValue
                        , ""
                        , allRank
                        , totalRank
                        , spaceRank
                        , timeRank
                        );

                    dgv.Rows[idx].Tag = data;

                    chart.DisplayChartLabel(data, Color.Orange, "2", resultCount + Environment.NewLine + "▼");
                }));
            }

            this.Invoke(new Action(() =>
            {
                dgv.ClearSelection();

                lbNoResult.Visible = resultCount == 0;
            }));
        }

        private int getRank(List<KeyValuePair<SmartCandleData, double>> rankList, SmartCandleData data)
        {
            int rank = -1;
            for (int idx = 0; idx < rankList.Count; idx++)
            {
                if (rankList[idx].Key == data)
                {
                    rank = ++idx;
                    break;
                }
            }

            return rank;
        }
        private double getValue(List<KeyValuePair<SmartCandleData, double>> rankList, SmartCandleData data)
        {
            double val = -1;
            for (int idx = 0; idx < rankList.Count; idx++)
            {
                if (rankList[idx].Key == data)
                {
                    val =  rankList[idx].Value;
                    break;
                }
            }

            return val;
        }
        #endregion

        private void dgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            SmartCandleData data = dgvList.Rows[e.RowIndex].Tag as SmartCandleData;
            selCandleData = data;

            tbSelectedInfo.Text =
                $"{data.ItemCode} [{Convert.ToDateTime(data.DTime).ToString("yyyy-MM-dd HH:mm")}] 시가 : {data.BasicPrice_Open} 고가 : {data.BasicPrice_High} 저가 : {data.BasicPrice_Low} 종가 : {data.BasicPrice_Close} 음양 : {data.BasicPriceColorType} Space : {data.SpaceEnergy.ToString("N7")} Time : {data.TimeEnergy.ToString("N7")} Energy : {data.TotalEnergy.ToString("N7")}";

            chart.ClearChartLabel("1");
            chart.ClearChartLabel("2");
            chart.DisplayChartLabel(data, Color.Black, "1");

            dgv.Rows.Clear();
            lbNoResult.Visible = false;

            btnSearch.PerformClick();
        }

       
    }
}
