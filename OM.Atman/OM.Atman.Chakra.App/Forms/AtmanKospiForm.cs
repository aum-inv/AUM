using MetroFramework;
using MetroFramework.Controls;
using OM.Atman.Chakra.App.Config;
using OM.Atman.Chakra.App.Events;
using OM.Atman.Chakra.App.Uc;
using OM.Atman.Chakra.App.Uc.Plans;
using OM.Atman.Chakra.Ctx;
using OM.Lib.Framework.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OM.Atman.Chakra.App.Forms
{
    public partial class AtmanKospiForm : MetroFramework.Forms.MetroForm
    {

        int selectedIndex = -1;
        
        XmlNode selectedNode = null;
        XmlUtility xmlUtil = null;
        public AtmanKospiForm()
        {
            InitializeComponent();           
            InitializeControls();
            InitializeEvents();
        }
              
        private void InitializeControls()
        {
            uc_AccountFundPlan.Dock = DockStyle.Fill;
            uc_BuyPlan.Dock = DockStyle.Fill;
            uc_InvAvailability.Dock = DockStyle.Fill;
            uc_InvResult.Dock = DockStyle.Fill;
            uc_RevenuePlan.Dock = DockStyle.Fill;
            uc_TrendCheck.Dock = DockStyle.Fill;

            uc_InvAvailability.Visible = true;
        }
        private void InitializeEvents()
        {
            this.Load += AtmanForm_Load;
            
            tspMenu1.Click += tspMenu_Click;
            tspMenu2.Click += tspMenu_Click;
            tspMenu3.Click += tspMenu_Click;
            tspMenu4.Click += tspMenu_Click;
            tspMenu5.Click += tspMenu_Click;
            tspMenu7.Click += tspMenu_Click;

            InvestmentPlanSelectedEvents.Instance.InvestmentPlanSelectedChangedHandler += Instance_InvestmentPlanSelectedChangedHandler;
        }

        private void Instance_InvestmentPlanSelectedChangedHandler(int index)
        {
            selectedIndex = index;
            selectedNode = ShareData.Instance.PlanNodeLlist[index];

            tbTitle.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/Title");
            tbItem.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/Product");
            dtPStartDate.Value = Convert.ToDateTime(xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/StartDate"));
            dtPEndDate.Value = Convert.ToDateTime(xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/EndDate"));
            tbTendency.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/Tendency");
            tbFund.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/Fund");
            tbPRevenue.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/ExpectedRevenue");
            tbPLoss.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/ExpectedLoss");
            tbPPosition.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/Trend");
            tbProgressType.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/ProgressType");

            lblTitlePgr.Text = xmlUtil.GetElementValue(selectedIndex, "BasicInvestmentInfo/ProgressType");
            lblTitle.Text = $"[{dtPStartDate.Value.ToString("yy.MM.dd")} ~ {dtPEndDate.Value.ToString("yy.MM.dd")}] {tbTitle.Text}";
        }

        private void AtmanForm_Load(object sender, EventArgs e)
        {
            loadData();
        }
        #region LoadData
        private void loadData()
        {
            selectedIndex = -1;
            flpList.Controls.Clear();
            Task.Factory.StartNew(() => {
                string xmlPath = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Data", "AtmanKospiData.xml");

                xmlUtil = new XmlUtility(xmlPath);
                ShareData.Instance.XmlUtil = xmlUtil;
                ShareData.Instance.PlanNodeLlist = xmlUtil.GetElements("FinancialInvestmentPlan");
                int index = 0;
                foreach (XmlNode node in ShareData.Instance.PlanNodeLlist)
                {
                    this.Invoke(new Action(() =>
                    {
                        var item = new Uc.Uc_ListItem();
                        item.Index = index++;
                        item.SetData(node);
                        flpList.Controls.Add(item);
                    }));
                }
            });
        }
        #endregion
        private void tspMenu_Click(object sender, EventArgs e)
        {
            var btn = sender as ToolStripButton;

            bindContentUserControl(btn.Text);

            tspMenu1.ForeColor =
            tspMenu2.ForeColor =
            tspMenu3.ForeColor =
            tspMenu4.ForeColor =
            tspMenu5.ForeColor = 
            tspMenu7.ForeColor = System.Drawing.Color.DimGray;
            btn.ForeColor = System.Drawing.Color.OrangeRed;
        }

        private void bindContentUserControl(string menuTxt)
        {
            menuTxt = menuTxt.Trim();
            uc_AccountFundPlan.Visible = false;
            uc_BuyPlan.Visible = false;
            uc_InvAvailability.Visible = false;
            uc_InvResult.Visible = false;
            uc_RevenuePlan.Visible = false;
            uc_TrendCheck.Visible = false;

            switch (menuTxt)
            {
                case "투자가능시점여부": uc_InvAvailability.Visible = true; break;
                case "추세확인": uc_TrendCheck.Visible = true; break;
                case "계좌&&자금계획": uc_AccountFundPlan.Visible = true; break;
                case "진입&&로스컷계획": uc_BuyPlan.Visible = true; break;
                case "수익포지션계획": uc_RevenuePlan.Visible = true; break;
                case "투자결과": uc_InvResult.Visible = true; break;               
                default: break;
            }
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            MetroTextBox textBox = sender as MetroTextBox;            
            MetroMessageBox.Show(this, textBox.CustomButton.Text, "HELP");
        }

        #region Btn Event
        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedNode == null) return;

            string 계획명 = tbTitle.Text;
            string 투자상품 = tbItem.Text;
            string 예상투자시작일 = dtPStartDate.Value.ToString("yyyy-MM-dd");
            string 예상투자종료일 = dtPEndDate.Value.ToString("yyyy-MM-dd");
            string 투자성향 = tbTendency.Text;
            string 투자금액 = tbFund.Text;
            string 예상수익율 = tbPRevenue.Text;
            string 예상손실율 = tbPLoss.Text;
            string 현재지수흐름 = tbPPosition.Text;
            string 진행상태 = tbProgressType.Text;

            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/Title", 계획명);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/Product", 투자상품);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/StartDate", 예상투자시작일);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/EndDate", 예상투자종료일);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/Tendency", 투자성향);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/Fund", 투자금액);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/ExpectedRevenue", 예상수익율);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/ExpectedLoss", 예상손실율);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/Trend", 현재지수흐름);
            xmlUtil.SetElementValue(selectedIndex, "BasicInvestmentInfo/ProgressType", 진행상태);

            var uc = flpList.Controls[selectedIndex] as Uc_ListItem;
            
            uc.SetData(selectedNode);
            
            xmlUtil.Save();
            
            MessageBox.Show("저장되었습니다.");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (selectedNode == null) return;

            var copyNode = selectedNode.Clone();

            xmlUtil.InsertElement("Atman", copyNode);

            xmlUtil.Save();

            btnLoad.PerformClick();

            MessageBox.Show("복사되었습니다.");
        }
        #endregion

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbTitle.Text = string.Empty;
            tbItem.Text = string.Empty;
            dtPStartDate.Value = DateTime.Today;
            dtPEndDate.Value = DateTime.Today;
            tbTendency.Text = string.Empty;
            tbFund.Text = string.Empty;
            tbPRevenue.Text = string.Empty;
            tbPLoss.Text = string.Empty;
            tbPPosition.Text = string.Empty;
            tbProgressType.Text = string.Empty;
        }
    }
}
