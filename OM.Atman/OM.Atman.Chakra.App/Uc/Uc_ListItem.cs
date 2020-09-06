using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using OM.Lib.Framework.Utility;
using OM.Atman.Chakra.App.Events;

namespace OM.Atman.Chakra.App.Uc
{
    public partial class Uc_ListItem : UserControl
    {
        public XmlNode XNode { get; set; } = null;
        public bool IsSelected { get; set; } = false;
        public int Index
        {
            get;
            set;
        } = -1;

        public Uc_ListItem()
        {
            InitializeComponent();
            InvestmentPlanSelectedEvents.Instance.InvestmentPlanSelectedChangedHandler += Instance_InvestmentPlanSelectedChangedHandler;
        }

        private void Instance_InvestmentPlanSelectedChangedHandler(int index)
        {
            if (index == Index)
            {
                IsSelected = true;
                pnlBottom.BackColor = Color.DarkRed;
            }
            else
            {
                IsSelected = false;
                pnlBottom.BackColor = Color.OldLace;
            }
        }

        public void mouseEnterLeave(bool isEnter)
        {
            if (!IsSelected)
            {
                if (isEnter) pnlBottom.BackColor = Color.DarkOrange;
                else pnlBottom.BackColor = Color.OldLace;
            }
        }

        private void item_MouseEnter(object sender, EventArgs e)
        {
            mouseEnterLeave(true);
        }

        private void item_MouseLeave(object sender, EventArgs e)
        {
            mouseEnterLeave(false);
        }

        private void item_MouseClick(object sender, MouseEventArgs e)
        {
        }

        public void SetData(XmlNode node)
        {
            this.XNode = node;

            bindData();
        }

        private void bindData()
        {
            XmlUtility xmlUtility = new XmlUtility(XNode);

            string title = xmlUtility.GetElementValue("Title", "FinancialInvestmentPlan", "BasicInvestmentInfo");
            string state = xmlUtility.GetElementValue("ProgressType", "FinancialInvestmentPlan", "BasicInvestmentInfo");
            string sdt = xmlUtility.GetElementValue("StartDate", "FinancialInvestmentPlan", "BasicInvestmentInfo");
            string edt = xmlUtility.GetElementValue("EndDate", "FinancialInvestmentPlan", "BasicInvestmentInfo");
           
            lbTitle.Text = $"{title} ({state})";
            lbDuration.Text = $"기간: {sdt} ~ {edt}";
        }

        private void itemType_Click(object sender, EventArgs e)
        {          
            InvestmentPlanSelectedEvents.Instance.OnInvestmentPlanSelectedChangedHandler(Index);            
        }
    }
}
