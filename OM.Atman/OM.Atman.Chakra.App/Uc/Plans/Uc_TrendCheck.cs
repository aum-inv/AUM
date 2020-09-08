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
    public partial class Uc_TrendCheck : Uc_PlanBase
    {
        int selectedIndex = -1;
        public Uc_TrendCheck()
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

            string basicChart1 = xmlUtil.GetElementValue(0, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart2 = xmlUtil.GetElementValue(1, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart3 = xmlUtil.GetElementValue(2, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart4 = xmlUtil.GetElementValue(3, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart5 = xmlUtil.GetElementValue(4, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart6 = xmlUtil.GetElementValue(5, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart7 = xmlUtil.GetElementValue(6, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicChart8 = xmlUtil.GetElementValue(7, "BasicChart", "IndexTrendCheck/BasicCharts");
            string basicSummary = xmlUtil.GetElementValue("Summary", "IndexTrendCheck/BasicCharts");

            string indicator1 = xmlUtil.GetElementValue(0, "Indicator", "IndexTrendCheck/Indicators");
            string indicator2 = xmlUtil.GetElementValue(1, "Indicator", "IndexTrendCheck/Indicators");
            string indicator3 = xmlUtil.GetElementValue(2, "Indicator", "IndexTrendCheck/Indicators");
            string indicator4 = xmlUtil.GetElementValue(3, "Indicator", "IndexTrendCheck/Indicators");
            string indicator5 = xmlUtil.GetElementValue(4, "Indicator", "IndexTrendCheck/Indicators");
            string indicatorSummary = xmlUtil.GetElementValue("Summary", "IndexTrendCheck/Indicators");

            tbBasicChart1.Text = basicChart1;
            tbBasicChart2.Text = basicChart2;
            tbBasicChart3.Text = basicChart3;
            tbBasicChart4.Text = basicChart4;
            tbBasicChart5.Text = basicChart5;
            tbBasicChart6.Text = basicChart6;
            tbBasicChart7.Text = basicChart7;
            tbBasicChart8.Text = basicChart8;
            tbBasicSummary.Text = basicSummary;

            tbIndicator1.Text = indicator1;
            tbIndicator2.Text = indicator2;
            tbIndicator3.Text = indicator3;
            tbIndicator4.Text = indicator4;
            tbIndicator5.Text = indicator5;
            tbIndicatorSummary.Text = indicatorSummary;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string basicChart1 = tbBasicChart1.Text;
            string basicChart2 = tbBasicChart2.Text;
            string basicChart3 = tbBasicChart3.Text;
            string basicChart4 = tbBasicChart4.Text;
            string basicChart5 = tbBasicChart5.Text;
            string basicChart6 = tbBasicChart6.Text;
            string basicChart7 = tbBasicChart7.Text;
            string basicChart8 = tbBasicChart8.Text;
            string basicSummary = tbBasicSummary.Text;

            string indicator1 = tbIndicator1.Text;
            string indicator2 = tbIndicator2.Text;
            string indicator3 = tbIndicator3.Text;
            string indicator4 = tbIndicator4.Text;
            string indicator5 = tbIndicator5.Text;
            string indicatorSummary = tbIndicatorSummary.Text;

            XmlNode selectedNode = ShareData.Instance.XmlUtil.GetElement(selectedIndex, "FinancialInvestmentPlan");
            XmlNodeUtility xmlUtil = new XmlNodeUtility(selectedNode);

            xmlUtil.SetElementValue(0, "BasicChart", basicChart1, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(1, "BasicChart", basicChart2, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(2, "BasicChart", basicChart3, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(3, "BasicChart", basicChart4, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(4, "BasicChart", basicChart5, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(5, "BasicChart", basicChart6, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(6, "BasicChart", basicChart7, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue(7, "BasicChart", basicChart8, "IndexTrendCheck/BasicCharts");
            xmlUtil.SetElementValue("Summary", basicSummary, "IndexTrendCheck/BasicCharts");
                    
            xmlUtil.SetElementValue(0, "Indicator", indicator1, "IndexTrendCheck/Indicators");
            xmlUtil.SetElementValue(1, "Indicator", indicator2, "IndexTrendCheck/Indicators");
            xmlUtil.SetElementValue(2, "Indicator", indicator3, "IndexTrendCheck/Indicators");
            xmlUtil.SetElementValue(3, "Indicator", indicator4, "IndexTrendCheck/Indicators");
            xmlUtil.SetElementValue(4, "Indicator", indicator5, "IndexTrendCheck/Indicators");
            xmlUtil.SetElementValue("Summary", indicatorSummary, "IndexTrendCheck/Indicators");

            ShareData.Instance.XmlUtil.Save();
            ShareData.Instance.XmlUtil.Reload();
            MessageBox.Show("저장되었습니다.");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbBasicChart1.Text = 
            tbBasicChart2.Text = 
            tbBasicChart3.Text = 
            tbBasicChart4.Text = 
            tbBasicChart5.Text = 
            tbBasicChart6.Text = 
            tbBasicChart7.Text = 
            tbBasicChart8.Text = 
            tbBasicSummary.Text = string.Empty;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {          
            tbIndicator1.Text = 
            tbIndicator2.Text = 
            tbIndicator3.Text = 
            tbIndicator4.Text = 
            tbIndicator5.Text = 
            tbIndicatorSummary.Text = string.Empty;
        }
    }
}
