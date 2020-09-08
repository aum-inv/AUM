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
    public partial class Uc_BuyPlan : Uc_PlanBase
    {
        int selectedIndex = -1;
        public Uc_BuyPlan()
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

            string expectedBuyIndexPrice1_1 = xmlUtil.GetElementValue(0, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy1");
            string expectedBuyIndexPrice1_2 = xmlUtil.GetElementValue(1, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy1");
            string expectedBuyIndexPrice1_3 = xmlUtil.GetElementValue(2, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy1");           
            string expectedBuyIndexPrice2_1 = xmlUtil.GetElementValue(0, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy2");
            string expectedBuyIndexPrice2_2 = xmlUtil.GetElementValue(1, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy2");
            string expectedBuyIndexPrice2_3 = xmlUtil.GetElementValue(2, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy2");            
            string expectedBuyIndexPrice3_1 = xmlUtil.GetElementValue(0, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy3");
            string expectedBuyIndexPrice3_2 = xmlUtil.GetElementValue(1, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy3");
            string expectedBuyIndexPrice3_3 = xmlUtil.GetElementValue(2, "ExpectedBuyIndexPrice", "BuyAndLosscutPlan/Buy3");

            string expectedLosscutIndexPrice1 = xmlUtil.GetElementValue("ExpectedLosscutIndexPrice", "BuyAndLosscutPlan/Losscut1");
            string expectedLosscutIndexPrice2 = xmlUtil.GetElementValue("ExpectedLosscutIndexPrice", "BuyAndLosscutPlan/Losscut2");
            string expectedLosscutIndexPrice3 = xmlUtil.GetElementValue("ExpectedLosscutIndexPrice", "BuyAndLosscutPlan/Losscut3");

            string etc1 = xmlUtil.GetElementValue("Etc1", "BuyAndLosscutPlan");
            string etc2 = xmlUtil.GetElementValue("Etc2", "BuyAndLosscutPlan");
            string etc3 = xmlUtil.GetElementValue("Etc3", "BuyAndLosscutPlan");

            tbExpectedBuyIndexPrice1_1.Text = expectedBuyIndexPrice1_1;
            tbExpectedBuyIndexPrice1_2.Text = expectedBuyIndexPrice1_2;
            tbExpectedBuyIndexPrice1_3.Text = expectedBuyIndexPrice1_3;
            tbExpectedBuyIndexPrice2_1.Text = expectedBuyIndexPrice2_1;
            tbExpectedBuyIndexPrice2_2.Text = expectedBuyIndexPrice2_2;
            tbExpectedBuyIndexPrice2_3.Text = expectedBuyIndexPrice2_3;
            tbExpectedBuyIndexPrice3_1.Text = expectedBuyIndexPrice3_1;
            tbExpectedBuyIndexPrice3_2.Text = expectedBuyIndexPrice3_2;
            tbExpectedBuyIndexPrice3_3.Text = expectedBuyIndexPrice3_3;

            tbExpectedLosscutIndexPrice1.Text = expectedLosscutIndexPrice1;
            tbExpectedLosscutIndexPrice2.Text = expectedLosscutIndexPrice2;
            tbExpectedLosscutIndexPrice3.Text = expectedLosscutIndexPrice3;

            tbEtc1.Text = etc1;
            tbEtc2.Text = etc2;
            tbEtc3.Text = etc3;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string expectedBuyIndexPrice1_1 = tbExpectedBuyIndexPrice1_1.Text; 
            string expectedBuyIndexPrice1_2 = tbExpectedBuyIndexPrice1_2.Text; 
            string expectedBuyIndexPrice1_3 = tbExpectedBuyIndexPrice1_3.Text; 
            string expectedBuyIndexPrice2_1 = tbExpectedBuyIndexPrice2_1.Text; 
            string expectedBuyIndexPrice2_2 = tbExpectedBuyIndexPrice2_2.Text; 
            string expectedBuyIndexPrice2_3 = tbExpectedBuyIndexPrice2_3.Text; 
            string expectedBuyIndexPrice3_1 = tbExpectedBuyIndexPrice3_1.Text; 
            string expectedBuyIndexPrice3_2 = tbExpectedBuyIndexPrice3_2.Text;
            string expectedBuyIndexPrice3_3 = tbExpectedBuyIndexPrice3_3.Text;
            string expectedLosscutIndexPrice1 = tbExpectedLosscutIndexPrice1.Text;
            string expectedLosscutIndexPrice2 = tbExpectedLosscutIndexPrice2.Text;
            string expectedLosscutIndexPrice3 = tbExpectedLosscutIndexPrice3.Text;
            string etc1 = tbEtc1.Text;
            string etc2 = tbEtc2.Text;
            string etc3 = tbEtc3.Text; 


            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            xmlUtil.SetElementValue(0, "ExpectedBuyIndexPrice", expectedBuyIndexPrice1_1, "BuyAndLosscutPlan/Buy1");
            xmlUtil.SetElementValue(1, "ExpectedBuyIndexPrice", expectedBuyIndexPrice1_2, "BuyAndLosscutPlan/Buy1");
            xmlUtil.SetElementValue(2, "ExpectedBuyIndexPrice", expectedBuyIndexPrice1_3, "BuyAndLosscutPlan/Buy1");
            xmlUtil.SetElementValue(0, "ExpectedBuyIndexPrice", expectedBuyIndexPrice2_1, "BuyAndLosscutPlan/Buy2");
            xmlUtil.SetElementValue(1, "ExpectedBuyIndexPrice", expectedBuyIndexPrice2_2, "BuyAndLosscutPlan/Buy2");
            xmlUtil.SetElementValue(2, "ExpectedBuyIndexPrice", expectedBuyIndexPrice2_3, "BuyAndLosscutPlan/Buy2");
            xmlUtil.SetElementValue(0, "ExpectedBuyIndexPrice", expectedBuyIndexPrice3_1, "BuyAndLosscutPlan/Buy3");
            xmlUtil.SetElementValue(1, "ExpectedBuyIndexPrice", expectedBuyIndexPrice3_2, "BuyAndLosscutPlan/Buy3");
            xmlUtil.SetElementValue(2, "ExpectedBuyIndexPrice", expectedBuyIndexPrice3_3, "BuyAndLosscutPlan/Buy3");

            xmlUtil.SetElementValue("ExpectedLosscutIndexPrice", expectedLosscutIndexPrice1, "BuyAndLosscutPlan/Losscut1");
            xmlUtil.SetElementValue("ExpectedLosscutIndexPrice", expectedLosscutIndexPrice2, "BuyAndLosscutPlan/Losscut2");
            xmlUtil.SetElementValue("ExpectedLosscutIndexPrice", expectedLosscutIndexPrice3, "BuyAndLosscutPlan/Losscut3");

            xmlUtil.SetElementValue("Etc1", etc1, "BuyAndLosscutPlan");
            xmlUtil.SetElementValue("Etc2", etc2, "BuyAndLosscutPlan");
            xmlUtil.GetElementValue("Etc3", etc3, "BuyAndLosscutPlan");


            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbExpectedBuyIndexPrice1_1.Text = 
            tbExpectedBuyIndexPrice1_2.Text = 
            tbExpectedBuyIndexPrice1_3.Text =             
            tbExpectedLosscutIndexPrice1.Text = 
            tbEtc1.Text = string.Empty;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            tbExpectedBuyIndexPrice2_1.Text = 
            tbExpectedBuyIndexPrice2_2.Text = 
            tbExpectedBuyIndexPrice2_3.Text = 
            tbExpectedLosscutIndexPrice2.Text = 
            tbEtc2.Text = string.Empty;
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            tbExpectedBuyIndexPrice3_1.Text = 
            tbExpectedBuyIndexPrice3_2.Text = 
            tbExpectedBuyIndexPrice3_3.Text = 
            tbExpectedLosscutIndexPrice3.Text = 
            tbEtc3.Text = string.Empty;
        }
    }
}
