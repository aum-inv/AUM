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
    public partial class Uc_RevenuePlan : Uc_PlanBase
    {
        int selectedIndex = -1;
        public Uc_RevenuePlan()
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

            string expectedSellIndexPrice1_1 = xmlUtil.GetElementValue(0, "ExpectedSellIndexPrice", "RevenuePlan/Sell1");
            string expectedSellIndexPrice1_2 = xmlUtil.GetElementValue(1, "ExpectedSellIndexPrice", "RevenuePlan/Sell1");
            string expectedSellIndexPrice1_3 = xmlUtil.GetElementValue(2, "ExpectedSellIndexPrice", "RevenuePlan/Sell1");
           
            string expectedSellIndexPrice2_1 = xmlUtil.GetElementValue(0, "ExpectedSellIndexPrice", "RevenuePlan/Sell2");
            string expectedSellIndexPrice2_2 = xmlUtil.GetElementValue(1, "ExpectedSellIndexPrice", "RevenuePlan/Sell2");
            string expectedSellIndexPrice2_3 = xmlUtil.GetElementValue(2, "ExpectedSellIndexPrice", "RevenuePlan/Sell2");
            
            string expectedSellIndexPrice3_1 = xmlUtil.GetElementValue(0, "ExpectedSellIndexPrice", "RevenuePlan/Sell3");
            string expectedSellIndexPrice3_2 = xmlUtil.GetElementValue(1, "ExpectedSellIndexPrice", "RevenuePlan/Sell3");
            string expectedSellIndexPrice3_3 = xmlUtil.GetElementValue(2, "ExpectedSellIndexPrice", "RevenuePlan/Sell3");

            string expectedAllSellIndexPrice1 = xmlUtil.GetElementValue("ExpectedAllSellIndexPrice", "RevenuePlan/Sell1");
            string expectedAllSellIndexPrice2 = xmlUtil.GetElementValue("ExpectedAllSellIndexPrice", "RevenuePlan/Sell2");
            string expectedAllSellIndexPrice3 = xmlUtil.GetElementValue("ExpectedAllSellIndexPrice", "RevenuePlan/Sell3");

            string etc1 = xmlUtil.GetElementValue("Etc", "RevenuePlan/Sell1");
            string etc2 = xmlUtil.GetElementValue("Etc", "RevenuePlan/Sell2");
            string etc3 = xmlUtil.GetElementValue("Etc", "RevenuePlan/Sell3");

            string reBuyMethod = xmlUtil.GetElementValue("ReBuyMethod", "RevenuePlan");

            tbExpectedSellIndexPrice1_1.Text = expectedSellIndexPrice1_1;
            tbExpectedSellIndexPrice1_2.Text = expectedSellIndexPrice1_2;
            tbExpectedSellIndexPrice1_3.Text = expectedSellIndexPrice1_3;
            tbExpectedSellIndexPrice2_1.Text = expectedSellIndexPrice2_1;
            tbExpectedSellIndexPrice2_2.Text = expectedSellIndexPrice2_2;
            tbExpectedSellIndexPrice2_3.Text = expectedSellIndexPrice2_3;
            tbExpectedSellIndexPrice3_1.Text = expectedSellIndexPrice3_1;
            tbExpectedSellIndexPrice3_2.Text = expectedSellIndexPrice3_2;
            tbExpectedSellIndexPrice3_3.Text = expectedSellIndexPrice3_3;

            tbExpectedAllSellIndexPrice1.Text = expectedAllSellIndexPrice1;
            tbExpectedAllSellIndexPrice2.Text = expectedAllSellIndexPrice2;
            tbExpectedAllSellIndexPrice3.Text = expectedAllSellIndexPrice3;

            tbEtc1.Text = etc1;
            tbEtc2.Text = etc2;
            tbEtc3.Text = etc3;

            if (reBuyMethod.StartsWith("수익포함")) rdoReBuyMethod1.Checked = true;
            else rdoReBuyMethod2.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string expectedSellIndexPrice1_1 = tbExpectedSellIndexPrice1_1.Text;
            string expectedSellIndexPrice1_2 = tbExpectedSellIndexPrice1_2.Text;
            string expectedSellIndexPrice1_3 = tbExpectedSellIndexPrice1_3.Text;
            string expectedSellIndexPrice2_1 = tbExpectedSellIndexPrice2_1.Text;
            string expectedSellIndexPrice2_2 = tbExpectedSellIndexPrice2_2.Text;
            string expectedSellIndexPrice2_3 = tbExpectedSellIndexPrice2_3.Text;
            string expectedSellIndexPrice3_1 = tbExpectedSellIndexPrice3_1.Text;
            string expectedSellIndexPrice3_2 = tbExpectedSellIndexPrice3_2.Text;
            string expectedSellIndexPrice3_3 = tbExpectedSellIndexPrice3_3.Text;

            string expectedAllSellIndexPrice1 = tbExpectedAllSellIndexPrice1.Text;
            string expectedAllSellIndexPrice2 = tbExpectedAllSellIndexPrice2.Text;
            string expectedAllSellIndexPrice3 = tbExpectedAllSellIndexPrice3.Text;

            string etc1 = tbEtc1.Text;
            string etc2 = tbEtc2.Text;
            string etc3 = tbEtc3.Text;

            string reBuyMethod = rdoReBuyMethod1.Checked ? rdoReBuyMethod1.Text : rdoReBuyMethod2.Text;


            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            xmlUtil.SetElementValue(0, "ExpectedSellIndexPrice", expectedSellIndexPrice1_1, "RevenuePlan/Sell1");
            xmlUtil.SetElementValue(1, "ExpectedSellIndexPrice", expectedSellIndexPrice1_2, "RevenuePlan/Sell1");
            xmlUtil.SetElementValue(2, "ExpectedSellIndexPrice", expectedSellIndexPrice1_3, "RevenuePlan/Sell1");
            xmlUtil.SetElementValue(0, "ExpectedSellIndexPrice", expectedSellIndexPrice2_1, "RevenuePlan/Sell2");
            xmlUtil.SetElementValue(1, "ExpectedSellIndexPrice", expectedSellIndexPrice2_2, "RevenuePlan/Sell2");
            xmlUtil.SetElementValue(2, "ExpectedSellIndexPrice", expectedSellIndexPrice2_3, "RevenuePlan/Sell2");
            xmlUtil.SetElementValue(0, "ExpectedSellIndexPrice", expectedSellIndexPrice3_1, "RevenuePlan/Sell3");
            xmlUtil.SetElementValue(1, "ExpectedSellIndexPrice", expectedSellIndexPrice3_2, "RevenuePlan/Sell3");
            xmlUtil.SetElementValue(2, "ExpectedSellIndexPrice", expectedSellIndexPrice3_3, "RevenuePlan/Sell3");

            xmlUtil.SetElementValue("ExpectedAllSellIndexPrice", expectedAllSellIndexPrice1, "RevenuePlan/Sell1");
            xmlUtil.SetElementValue("ExpectedAllSellIndexPrice", expectedAllSellIndexPrice2, "RevenuePlan/Sell2");
            xmlUtil.SetElementValue("ExpectedAllSellIndexPrice", expectedAllSellIndexPrice3, "RevenuePlan/Sell3");

            xmlUtil.SetElementValue("Etc", etc1, "RevenuePlan/Sell1");
            xmlUtil.SetElementValue("Etc", etc2, "RevenuePlan/Sell2");
            xmlUtil.SetElementValue("Etc", etc3, "RevenuePlan/Sell3");

            xmlUtil.SetElementValue("ReBuyMethod", reBuyMethod, "RevenuePlan");

            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbExpectedSellIndexPrice1_1.Text = 
            tbExpectedSellIndexPrice1_2.Text = 
            tbExpectedSellIndexPrice1_3.Text = 
            tbExpectedAllSellIndexPrice1.Text =   
            tbEtc1.Text = string.Empty;         
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            tbExpectedSellIndexPrice2_1.Text = 
            tbExpectedSellIndexPrice2_2.Text = 
            tbExpectedSellIndexPrice2_3.Text =     
            tbExpectedAllSellIndexPrice2.Text =
            tbEtc2.Text = string.Empty;
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            tbExpectedSellIndexPrice3_1.Text = 
            tbExpectedSellIndexPrice3_2.Text = 
            tbExpectedSellIndexPrice3_3.Text = 
            tbExpectedAllSellIndexPrice3.Text =
            tbEtc3.Text = string.Empty;
        }
    }
}
