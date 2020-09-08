using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OM.Atman.Chakra.App.Events;
using OM.Lib.Framework.Utility;
using System.Xml;
using OM.Atman.Chakra.App.Config;

namespace OM.Atman.Chakra.App.Uc.Plans
{
    public partial class Uc_InvResult : Uc_PlanBase
    {
        int selectedIndex = -1;
        public Uc_InvResult()
        {
            InitializeComponent();

            InvestmentPlanSelectedEvents.Instance.InvestmentPlanSelectedChangedHandler += Instance_InvestmentPlanSelectedChangedHandler;
        }

        private void Instance_InvestmentPlanSelectedChangedHandler(int index)
        {
            selectedIndex = index;
            bindData();
        }

        private void bindData()
        {
            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            string trend = xmlUtil.GetElementValue("Trend", "InvestmentResult");
            string technicalAnalysis = xmlUtil.GetElementValue("TechnicalAnalysis", "InvestmentResult");
            string tendency = xmlUtil.GetElementValue("Tendency", "InvestmentResult");
            string accounts = xmlUtil.GetElementValue("Accounts", "InvestmentResult");
            string fund = xmlUtil.GetElementValue("Fund", "InvestmentResult");
            string duration = xmlUtil.GetElementValue("Duration", "InvestmentResult");
            string profitAndLoss1 = xmlUtil.GetElementValue("ProfitAndLoss1", "InvestmentResult");
            string profitAndLoss2 = xmlUtil.GetElementValue("ProfitAndLoss2", "InvestmentResult");
            string profitAndLoss3 = xmlUtil.GetElementValue("ProfitAndLoss3", "InvestmentResult");
            string summary = xmlUtil.GetElementValue("Summary", "InvestmentResult");

            tbTrend.Text = trend;
            tbTechnicalAnalysis.Text = technicalAnalysis;
            tbTendency.Text = tendency;
            tbAccounts.Text = accounts;
            tbFund.Text = fund;
            tbDuration.Text = duration;
            tbProfitAndLoss1.Text = profitAndLoss1;
            tbProfitAndLoss2.Text = profitAndLoss2;
            tbProfitAndLoss3.Text = profitAndLoss3;
            tbSummary.Text = summary;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string trend = tbTrend.Text;
            string technicalAnalysis = tbTechnicalAnalysis.Text;
            string tendency = tbTendency.Text;
            string accounts = tbAccounts.Text;
            string fund = tbFund.Text;
            string duration = tbDuration.Text;
            string profitAndLoss1 = tbProfitAndLoss1.Text;
            string profitAndLoss2 = tbProfitAndLoss2.Text;
            string profitAndLoss3 = tbProfitAndLoss3.Text;
            string summary = tbSummary.Text;


            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);
            xmlUtil.SetElementValue("Trend", trend, "InvestmentResult");
            xmlUtil.SetElementValue("TechnicalAnalysis", technicalAnalysis, "InvestmentResult");
            xmlUtil.SetElementValue("Tendency", tendency, "InvestmentResult");
            xmlUtil.SetElementValue("Accounts", accounts, "InvestmentResult");
            xmlUtil.SetElementValue("Fund", fund, "InvestmentResult");
            xmlUtil.SetElementValue("Duration", duration, "InvestmentResult");
            xmlUtil.SetElementValue("ProfitAndLoss1", profitAndLoss1, "InvestmentResult");
            xmlUtil.SetElementValue("ProfitAndLoss2", profitAndLoss2, "InvestmentResult");
            xmlUtil.SetElementValue("ProfitAndLoss3", profitAndLoss3, "InvestmentResult");
            xmlUtil.SetElementValue("Summary", summary, "InvestmentResult");

            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbTrend.Text = 
            tbTechnicalAnalysis.Text = 
            tbTendency.Text = 
            tbAccounts.Text = 
            tbFund.Text = 
            tbDuration.Text = 
            tbProfitAndLoss1.Text = 
            tbProfitAndLoss2.Text = 
            tbProfitAndLoss3.Text = 
            tbSummary.Text = string.Empty;
        }
    }
}
