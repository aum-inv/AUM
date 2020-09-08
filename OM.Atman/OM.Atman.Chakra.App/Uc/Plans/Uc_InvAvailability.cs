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
using static MetroFramework.Controls.MetroTextBox;

namespace OM.Atman.Chakra.App.Uc.Plans
{
    public partial class Uc_InvAvailability : Uc_PlanBase
    {
        int selectedIndex = -1;
        public Uc_InvAvailability()
        {
            InitializeComponent();
            InitializeControls();
            InitializeEvents();
        }
        private void InitializeControls()
        {           
        }
        private void InitializeEvents()
        {
            tbEpuKp.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbVixKr.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbEpuUs.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyEu.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyCn.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixUs.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixEu.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };
            tbUncertaintyVixCn.CustomButton.Click += (e, o) => { UrlLinkClick(((MetroTextButton)e).Tag.ToString()); };

            btnRef1.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef2.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef3.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef4.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef5.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef6.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
            btnRef7.Click += (e, o) => { UrlLinkClick(((MetroButton)e).Tag.ToString()); };
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

            string epuKr = xmlUtil.GetElementValue("KR", "InvestmentAvailability/Uncertainty/EPU");
            string vixKr = xmlUtil.GetElementValue("KR", "InvestmentAvailability/Uncertainty/VIX");
            string uncertaintySummary = xmlUtil.GetElementValue("Summary", "InvestmentAvailability/Uncertainty");

            string indicator1 = xmlUtil.GetElementValue("Indicator1", "InvestmentAvailability/Volatility");
            string indicator2 = xmlUtil.GetElementValue("Indicator2", "InvestmentAvailability/Volatility");
            string indicator3 = xmlUtil.GetElementValue("Indicator3", "InvestmentAvailability/Volatility");
            string indicator4 = xmlUtil.GetElementValue("Indicator4", "InvestmentAvailability/Volatility");
            string indicator5 = xmlUtil.GetElementValue("Indicator5", "InvestmentAvailability/Volatility");
            string indicatorSummary = xmlUtil.GetElementValue("Summary", "InvestmentAvailability/Volatility");

            tbEpuKp.Text = epuKr;
            tbVixKr.Text = vixKr;
            tbUncertaintySummary.Text = uncertaintySummary;

            tbVolatility1.Text = indicator1;
            tbVolatility2.Text = indicator2;
            tbVolatility3.Text = indicator3;
            tbVolatility4.Text = indicator4;
            tbVolatility5.Text = indicator5;
            tbVolatilitySummary.Text = indicatorSummary;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string epuKr = tbEpuKp.Text;
            string vixKr = tbVixKr.Text;
            string uncertaintySummary = tbUncertaintySummary.Text;

            string indicator1 = tbVolatility1.Text;
            string indicator2 = tbVolatility2.Text;
            string indicator3 = tbVolatility3.Text;
            string indicator4 = tbVolatility4.Text;
            string indicator5 = tbVolatility5.Text;
            string indicatorSummary = tbVolatilitySummary.Text;

            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            xmlUtil.SetElementValue("KR", epuKr, "InvestmentAvailability/Uncertainty/EPU");
            xmlUtil.SetElementValue("KR", vixKr, "InvestmentAvailability/Uncertainty/VIX");
            xmlUtil.SetElementValue("Summary", uncertaintySummary, "InvestmentAvailability/Uncertainty");

            xmlUtil.SetElementValue("Indicator1", indicator1, "InvestmentAvailability/Volatility");
            xmlUtil.SetElementValue("Indicator2", indicator2, "InvestmentAvailability/Volatility");
            xmlUtil.SetElementValue("Indicator3", indicator3, "InvestmentAvailability/Volatility");
            xmlUtil.SetElementValue("Indicator4", indicator4, "InvestmentAvailability/Volatility");
            xmlUtil.SetElementValue("Indicator5", indicator5, "InvestmentAvailability/Volatility");
            xmlUtil.SetElementValue("Summary", indicatorSummary, "InvestmentAvailability/Volatility");

            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbEpuKp.Text = 
            tbVixKr.Text = 
            tbUncertaintySummary.Text = string.Empty;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            tbVolatility1.Text = 
            tbVolatility2.Text = 
            tbVolatility3.Text = 
            tbVolatility4.Text = 
            tbVolatility5.Text = 
            tbVolatilitySummary.Text = string.Empty;
        }
    }
}
