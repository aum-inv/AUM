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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace OM.Atman.Chakra.App.AIForms
{
    public partial class AtmanKJongmokAIForm : MetroFramework.Forms.MetroForm
    {
        List<SmartCandleData> scList = new List<SmartCandleData>();

        SmartCandleData selCandleData = null;

        int displayCnt = 30;
        string itemCode = "";
        TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;
        public AtmanKJongmokAIForm()
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
             
        void loadSiseDataFromDaemon(TimeIntervalEnum timeInterval = TimeIntervalEnum.Day)
        {
            this.timeInterval = timeInterval;
            List<S_CandleItemData> sourceDatas = null;

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

            if (sourceDatas == null || sourceDatas.Count == 0) return;

            scList.Clear();
            this.Invoke(new Action(() =>
            {
                dgvList.Rows.Clear();

                dgv.Rows.Clear();
                lbNoResult.Visible = false;
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

                Display();
            }));           
        }

        private void Display()
        {
            chart1.DisplayPointCount = displayCnt;
            chart2.DisplayPointCount = displayCnt;
            chart1.LoadData(itemCode, scList, timeInterval);
            chart2.LoadData(itemCode, scList, timeInterval);
        }
        #endregion

        #region Result Grid
        private void dgv_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            SmartCandleData chooseData = dgv.Rows[e.RowIndex].Tag as SmartCandleData;

            chart1.ClearChartLabel("2");
            chart1.DisplayChartLabel(chooseData, Color.Orange, "2");

            chart2.ClearChartLabel("2");
            chart2.DisplayChartLabel(chooseData, Color.Orange, "2");
          
            chart1.MoveView(chooseData);
        }
        #endregion

        #region Search 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (selCandleData == null) return;
            lbNoResult.Visible = false;
            try
            {
                bool isUseTotalEnergy = chkMatchTotal.Checked;
                bool isUseTimeEnergy = chkMatchTime.Checked;
                bool isUseSpaceEnergy = chkMatchSpace.Checked;
                bool isUseMultiCandle = chkMultiCandle.Checked;

                Task.Factory.StartNew(() =>
                {
                    Searching(isUseTotalEnergy, isUseTimeEnergy, isUseSpaceEnergy, isUseMultiCandle);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Searching(bool isUseTotalEnergy = true, bool isUseTimeEnergy = true, bool isUseSpaceEnergy = true, bool isUseMulti = false)
        {  
            Dictionary<SmartCandleData, EnergyRank> totalEnergyRank = new Dictionary<SmartCandleData, EnergyRank>();
                       
            foreach (var data in scList)
            {
                if (data == selCandleData)
                    continue;

                EnergyRank energyRank = new EnergyRank();

                if (isUseMulti)
                {
                    double diffTime = Math.Abs(selCandleData.TimeEnergy3 - data.TimeEnergy3)
                                    + Math.Abs(selCandleData.PreviousCandleData.TimeEnergy3 - data.PreviousCandleData.TimeEnergy3)
                                    + Math.Abs(selCandleData.PreviousCandleData.PreviousCandleData.TimeEnergy3 - data.PreviousCandleData.PreviousCandleData.TimeEnergy3);
                    energyRank.TimeEnergy = isUseTimeEnergy ? diffTime : 0;

                    double diffSpace = Math.Abs(selCandleData.SpaceEnergy - data.SpaceEnergy)
                                    + Math.Abs(selCandleData.PreviousCandleData.SpaceEnergy - data.PreviousCandleData.SpaceEnergy)
                                    + Math.Abs(selCandleData.PreviousCandleData.PreviousCandleData.SpaceEnergy - data.PreviousCandleData.PreviousCandleData.SpaceEnergy);
                    energyRank.SpaceEnergy = isUseSpaceEnergy ? diffSpace : 0;

                    energyRank.SumEnergy = isUseTotalEnergy ? (diffTime + diffSpace) : 0;

                    if (energyRank.TimeEnergy != double.NaN && energyRank.SpaceEnergy != double.NaN && energyRank.SumEnergy != double.NaN)
                        totalEnergyRank.Add(data, energyRank);
                }
                else 
                {
                    double diffTime = Math.Abs(selCandleData.TimeEnergy - data.TimeEnergy);
                    energyRank.TimeEnergy = isUseTimeEnergy ? diffTime : 0;

                    double diffSpace = Math.Abs(selCandleData.SpaceEnergy - data.SpaceEnergy);
                    energyRank.SpaceEnergy = isUseSpaceEnergy ? diffSpace : 0;

                    energyRank.SumEnergy = isUseTotalEnergy ? (diffTime + diffSpace) : 0;

                    if (energyRank.TimeEnergy != double.NaN && energyRank.SpaceEnergy != double.NaN && energyRank.SumEnergy != double.NaN)
                        totalEnergyRank.Add(data, energyRank);
                }
            }

            int rank = 0;
            double currentValue = 0;
            foreach (var item in totalEnergyRank.OrderBy(t => t.Value.TimeEnergy).ToList())
            {
                if(currentValue < item.Value.TimeEnergy)
                {
                    rank++;
                    currentValue = item.Value.TimeEnergy;
                }
                totalEnergyRank[item.Key].TimeRank = rank;
            }
            rank = 0;
            currentValue = 0;
            foreach (var item in totalEnergyRank.OrderBy(t => t.Value.SpaceEnergy).ToList())
            {
                if (currentValue < item.Value.SpaceEnergy)
                {
                    rank++;
                    currentValue = item.Value.SpaceEnergy;
                }
                totalEnergyRank[item.Key].SpaceRank = rank;
            }
            rank = 0;
            currentValue = 0;
            foreach (var item in totalEnergyRank.OrderBy(t => t.Value.SumEnergy).ToList())
            {
                if (currentValue < item.Value.SumEnergy)
                {
                    rank++;
                    currentValue = item.Value.SumEnergy;
                }
                totalEnergyRank[item.Key].SumRank = rank;
            }
            rank = 0;
            currentValue = 0;
            foreach (var item in totalEnergyRank.OrderBy(t => (t.Value.TimeRank + t.Value.SpaceRank)).ToList())
            {
                if (currentValue < (item.Value.TimeRank + item.Value.SpaceRank))
                {
                    rank++;
                    currentValue = (item.Value.TimeRank + item.Value.SpaceRank);
                }
                totalEnergyRank[item.Key].TotalRank = rank;
            }
            this.Invoke(new Action(() =>
            {
                dgv.Rows.Clear();
                chart1.ClearChartLabel("2");
                chart2.ClearChartLabel("2");
            }));

            int resultCount = 0;
                        
            foreach (var item in totalEnergyRank.OrderBy(t => t.Value.TotalRank))
            {
                var data = item.Key;
                var totalRank = item.Value.TotalRank;
                int timeRank = item.Value.TimeRank;
                int spaceRank = item.Value.SpaceRank;

                if (isUseTimeEnergy && timeRank == 0) continue;
                if (isUseSpaceEnergy && spaceRank == 0) continue;

                int filter = 10;
                if (!isUseTimeEnergy || !isUseSpaceEnergy) filter = 3;

                if (timeRank > filter || spaceRank > filter) continue;

                resultCount++;
                double totalValue = item.Value.SumEnergy;
                double timeValue = item.Value.TimeEnergy;
                double spaceValue = item.Value.SpaceEnergy;

                this.Invoke(new Action(() =>
                {
                    int idx = dgv.Rows.Add(
                            Convert.ToDateTime(data.DTime).ToString("yy.MM.dd HH:mm")
                        , data.BasicPrice_Open
                        , data.BasicPrice_High
                        , data.BasicPrice_Low
                        , data.BasicPrice_Close
                        , data.BasicPriceColorType
                        , data.ComparedPreviousDayPriceColorType
                        , totalValue
                        , spaceValue
                        , timeValue
                        , ""
                        , totalRank
                        , spaceRank
                        , timeRank
                        , ""
                        , ""
                        , ""                        
                        );

                    if (data.PreviousCandleData != null)
                    {
                        if (data.PreviousCandleData.BasicPrice_Close > data.BasicPrice_Close)
                        {
                            dgv.Rows[idx].Cells["yday1"].Value = "▲";
                            dgv.Rows[idx].Cells["yday1"].Style.ForeColor = Color.Red;
                        }
                        else if (data.PreviousCandleData.BasicPrice_Close < data.BasicPrice_Close)
                        {
                            dgv.Rows[idx].Cells["yday1"].Value = "▼";
                            dgv.Rows[idx].Cells["yday1"].Style.ForeColor = Color.Blue;
                        }
                    }
                    if (data.PreviousCandleData != null && data.PreviousCandleData.PreviousCandleData != null)
                    {
                        if (data.PreviousCandleData.PreviousCandleData.BasicPrice_Close > data.BasicPrice_Close)
                        {
                            dgv.Rows[idx].Cells["yday2"].Value = "▲";
                            dgv.Rows[idx].Cells["yday2"].Style.ForeColor = Color.Red;
                        }
                        else if (data.PreviousCandleData.PreviousCandleData.BasicPrice_Close < data.BasicPrice_Close)
                        {
                            dgv.Rows[idx].Cells["yday2"].Value = "▼";
                            dgv.Rows[idx].Cells["yday2"].Style.ForeColor = Color.Blue;
                        }
                    }

                    setTDay(idx, data);

                    dgv.Rows[idx].Tag = data;

                    chart1.DisplayChartLabel(data, Color.Orange, "2", resultCount + Environment.NewLine + "▼");
                }));
            }
            
            this.Invoke(new Action(() =>
            {
                dgv.ClearSelection();

                lbNoResult.Visible = resultCount == 0;
            }));
        }

        private void setTDay(int rIdx, SmartCandleData cData)
        {
            Task.Factory.StartNew(() => 
            {
                for (int i = 0; i < scList.Count; i++)
                {
                    var data = scList[i];

                    if (data.DTime == cData.DTime)
                    {
                        int j = i + 1;
                        if (j < scList.Count)
                        {
                            data = scList[j];
                            this.Invoke(new Action(() => { 
                                if (data.BasicPrice_Close > cData.BasicPrice_Close)
                                {
                                    dgv.Rows[rIdx].Cells["tday1"].Value = "▲";
                                    dgv.Rows[rIdx].Cells["tday1"].Style.ForeColor = Color.Red;
                                }
                                else if (data.BasicPrice_Close < cData.BasicPrice_Close)
                                {
                                    dgv.Rows[rIdx].Cells["tday1"].Value = "▼";
                                    dgv.Rows[rIdx].Cells["tday1"].Style.ForeColor = Color.Blue;
                                }
                            }));
                        }
                        j = i + 2;
                        if (j < scList.Count)
                        {
                            data = scList[j];

                            this.Invoke(new Action(() => {
                                if (data.BasicPrice_Close > cData.BasicPrice_Close)
                                {
                                    dgv.Rows[rIdx].Cells["tday2"].Value = "▲";
                                    dgv.Rows[rIdx].Cells["tday2"].Style.ForeColor = Color.Red;
                                }
                                else if (data.BasicPrice_Close < cData.BasicPrice_Close)
                                {
                                    dgv.Rows[rIdx].Cells["tday2"].Value = "▼";
                                    dgv.Rows[rIdx].Cells["tday2"].Style.ForeColor = Color.Blue;
                                }
                            }));
                        }
                        break;
                    }
                }
            });
        }

        #endregion

        #region Control Event
        private void dgvList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            SmartCandleData data = dgvList.Rows[e.RowIndex].Tag as SmartCandleData;
            selCandleData = data;

            tbSelectedInfo.Text =
                $"{data.ItemCode} [{Convert.ToDateTime(data.DTime).ToString("yyyy-MM-dd HH:mm")}] 시가 : {data.BasicPrice_Open} 고가 : {data.BasicPrice_High} 저가 : {data.BasicPrice_Low} 종가 : {data.BasicPrice_Close} 음양 : {data.BasicPriceColorType} Space : {data.SpaceEnergy.ToString("N7")} Time : {data.TimeEnergy.ToString("N7")} Energy : {data.TotalEnergy.ToString("N7")}";

            chart1.ClearChartLabel("1");
            chart1.ClearChartLabel("2");
            chart1.DisplayChartLabel(data, Color.Black, "1");

            chart2.ClearChartLabel("1");
            chart2.ClearChartLabel("2");
            chart2.DisplayChartLabel(data, Color.Black, "1");

            dgv.Rows.Clear();
            lbNoResult.Visible = false;

            btnSearch.PerformClick();

            chart1.DisplayView();
        }
        private void btnLoadDaemon_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;

                TimeIntervalEnum timeInterval = TimeIntervalEnum.Day;

                if (btn.Text == "분") timeInterval = TimeIntervalEnum.Minute_30;
                if (btn.Text == "시") timeInterval = TimeIntervalEnum.Hour_01;
                if (btn.Text == "일") timeInterval = TimeIntervalEnum.Day;
                if (btn.Text == "주") timeInterval = TimeIntervalEnum.Week;

                Task.Factory.StartNew(() =>
                {
                    loadSiseDataFromDaemon(timeInterval);
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        #endregion

        private void ai_Click(object sender, EventArgs e)
        {
            MetroTile metroTile = sender as MetroTile;

            if (metroTile.Text == "1") return;

            if (metroTile.Text == "2")
            {
                new AtmanKospiAI2Form().Show();
            }
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(tlpChart.Width, tlpChart.Height);
            tlpChart.DrawToBitmap(bmp, new Rectangle(0, 0, tlpChart.Width, tlpChart.Height));

            var df = new Forms.MainDrawForm(bmp);
            df.Width = tlpChart.Width + 5;
            df.Height = tlpChart.Height + 30;
            df.Text = this.Text + "(EDIT IMAGE)";
            df.Show();
        }

        private void metroLabel11_Click(object sender, EventArgs e)
        {

        }

        private void nudDisplay_ValueChanged(object sender, EventArgs e)
        {
            displayCnt = Convert.ToInt32(nudDisplay.Value);
            Display();
        }


        private void tbSelectedCode_TextChanged(object sender, EventArgs e)
        {
            itemCode = tbSelectedCode.Text;
        }

        private void tbSelectedCode_Click(object sender, EventArgs e)
        {

        }
    }
}
