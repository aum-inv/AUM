using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Xml;
using OM.Atman.Chakra.App.Events;
using OM.Lib.Framework.Utility;
using OM.Atman.Chakra.App.Config;

namespace OM.Atman.Chakra.App.Uc.Plans
{
    public partial class Uc_AccountFundPlan : Uc_PlanBase
    {
    
        int selectedIndex = -1;
        public Uc_AccountFundPlan()
        {
            InitializeComponent();

            InvestmentPlanSelectedEvents.Instance.InvestmentPlanSelectedChangedHandler += Instance_InvestmentPlanSelectedChangedHandler;
        }

        private void Instance_InvestmentPlanSelectedChangedHandler(int index)
        {           
            selectedIndex = index;
            bindData();
        }
        private void UrlLink_Click(object sender, EventArgs e)
        {
            MetroButton metroLink = sender as MetroButton;
            UrlLinkClick(metroLink.Tag.ToString());
        }
       
        private void bindData()
        {
            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            string securitiesCompany1 = xmlUtil.GetElementValue(0, "Account", "AccountFundPlan", "Accounts");
            string securitiesCompany2 = xmlUtil.GetElementValue(1, "Account", "AccountFundPlan", "Accounts");
            string securitiesCompany3 = xmlUtil.GetElementValue(2, "Account", "AccountFundPlan", "Accounts");

            string invFund1 = xmlUtil.GetElementAttributeValue(0, "Account", "InvFund", "AccountFundPlan", "Accounts");
            string invFund2 = xmlUtil.GetElementAttributeValue(1, "Account", "InvFund", "AccountFundPlan", "Accounts");
            string invFund3 = xmlUtil.GetElementAttributeValue(2, "Account", "InvFund", "AccountFundPlan", "Accounts");

            string summary = xmlUtil.GetElementValue("Summary", "AccountFundPlan");
            string fundMethod = xmlUtil.GetElementValue("FundMethod", "AccountFundPlan");

            tbsecuritiesCompany1.Text = securitiesCompany1;
            tbsecuritiesCompany2.Text = securitiesCompany2;
            tbsecuritiesCompany3.Text = securitiesCompany3;
            tbinvFund1.Text = invFund1;
            tbinvFund2.Text = invFund2;
            tbinvFund3.Text = invFund3;
            tbSummary.Text = summary;

            if (fundMethod.StartsWith("공격적")) rdoFundMethod1.Checked = true;
            else rdoFundMethod2.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string securitiesCompany1 = tbsecuritiesCompany1.Text;
            string securitiesCompany2 = tbsecuritiesCompany2.Text;
            string securitiesCompany3 = tbsecuritiesCompany3.Text;

            string invFund1 = tbinvFund1.Text;
            string invFund2 = tbinvFund2.Text;
            string invFund3 = tbinvFund3.Text;

            string summary = tbSummary.Text;
            string fundMethod = rdoFundMethod1.Checked ? rdoFundMethod1.Text : rdoFundMethod2.Text;

            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            xmlUtil.SetElementValue(0, "Account", securitiesCompany1, "AccountFundPlan", "Accounts");
            xmlUtil.SetElementValue(1, "Account", securitiesCompany2, "AccountFundPlan", "Accounts");
            xmlUtil.SetElementValue(2, "Account", securitiesCompany3, "AccountFundPlan", "Accounts");

            xmlUtil.SetElementAttributeValue(0, "Account", "InvFund", invFund1, "AccountFundPlan", "Accounts");
            xmlUtil.SetElementAttributeValue(1, "Account", "InvFund", invFund1, "AccountFundPlan", "Accounts");
            xmlUtil.SetElementAttributeValue(2, "Account", "InvFund", invFund1, "AccountFundPlan", "Accounts");

            xmlUtil.SetElementValue("Summary", summary, "AccountFundPlan");
            xmlUtil.SetElementValue("FundMethod", fundMethod, "AccountFundPlan");

            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }
    }
}
