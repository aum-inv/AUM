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
    public partial class AtmanKRPickItemForm : MetroFramework.Forms.MetroForm
    {
        int displayCnt = 60;

        XmlUtility xmlUtil = null;
        XmlNode selectedNode = null;
        int selectedIndex = -1;
        public AtmanKRPickItemForm()
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

            tbPickDT.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
        }
                
        private void AtmanForm_Load(object sender, EventArgs e)
        {
            serverInfo();
            loadData();
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
        private void loadData()
        {
            Task.Factory.StartNew(() => {
                string xmlPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Data", "AtmanKospiPickItemData.xml");

                xmlUtil = new XmlUtility(xmlPath);
                
                ShareData.Instance.PickItemList = xmlUtil.GetElements("PickItem");
                
                foreach (XmlNode node in ShareData.Instance.PickItemList)
                {
                    string date = node.ChildNodes[0].InnerText;
                    string code = node.ChildNodes[1].InnerText;
                    string name = node.ChildNodes[2].InnerText;                   
                    string reason = node.ChildNodes[3].InnerText;
                    
                    this.Invoke(new Action(() =>
                    {
                        int idx = dgv.Rows.Add(date, code, name, reason);                        
                    }));
                }
            });
        }
       

        #region Control Event

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            string code = dgv.Rows[e.RowIndex].Cells[1].Value as string;
            string name = dgv.Rows[e.RowIndex].Cells[2].Value as string;
            DateTime dt = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells[0].Value);

            tbSelectedCode2.Text = code;
            tbSelectedName2.Text = name;
            selectedNode = dgv.Rows[e.RowIndex].Tag as XmlNode;
            selectedIndex = e.RowIndex;

            Task.Factory.StartNew(() => {
                var sourceDatas = XingContext.Instance.ClientContext.GetJongmokSiseData(code, "2", "0", "300");
                if (sourceDatas == null || sourceDatas.Count == 0) return;
                int totalCnt = sourceDatas.Count;
                if (totalCnt > 300)
                    sourceDatas.RemoveRange(0, totalCnt - 300);
                var averageDatas = PPUtils.GetBalancedAverageDatas(code, sourceDatas, 4);
                sourceDatas = PPUtils.GetCutDatas(sourceDatas, averageDatas[0].DTime);
               
                chart.LoadDataAndApply(code, sourceDatas, averageDatas, TimeIntervalEnum.Day, 9);
                chart.SetYFormat("N0");

                chart.ClearChartLabel("★");
                chart.DisplayChartLabel(dt, Color.DarkRed, "★", "★");
            });
        }

        #endregion

        private void btnReg_Click(object sender, EventArgs e)
        {
            string pickDT = tbPickDT.Text;
            string code = tbCode.Text;
            string name = tbName.Text;
            string reason = tbReason.Text;

            if (pickDT.Length == 0 || code.Length == 0 || name.Length == 0 || reason.Length == 0) return;

            string nodeXml = $"<PickDT>{pickDT}</PickDT><Code>{code}</Code><Name>{name}</Name><Reason>{reason}</Reason>";
            xmlUtil.InsertElement("Atman", "PickItem", nodeXml);
            xmlUtil.Save();
                     
            dgv.Rows.Insert(0, pickDT, code, name, reason);           
        }
               
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0) return;

            xmlUtil.DelElement(selectedIndex, "PickItem");
            xmlUtil.Save();

            dgv.Rows.RemoveAt(selectedIndex);

            selectedIndex = -1;
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
    }
}
