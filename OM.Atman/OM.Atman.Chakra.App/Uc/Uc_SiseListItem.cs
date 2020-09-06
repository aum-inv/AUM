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
using OM.PP.Chakra;
using OM.Atman.Chakra.App.Events;

namespace OM.Atman.Chakra.App.Uc
{
    public partial class Uc_SiseListItem : UserControl
    {
        public SmartCandleData CandleData { get; set; } = null;
        public int Index
        {
            get;
            set;
        } = -1;

        public Uc_SiseListItem()
        {
            InitializeComponent();
        }

        private void mouseEnterLeave(bool isEnter)
        { 
            if(isEnter) pnlBottom.BackColor = Color.DarkOrange;
            else pnlBottom.BackColor = Color.OldLace;
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

        public void SetData(SmartCandleData data)
        {
            this.CandleData = data;

            bindData();
        }

        private void bindData()
        {
            if (CandleData == null) return;

            string title = CandleData.BasicPrice_Close.ToString("N2");
            string date = Convert.ToDateTime(CandleData.DTime).ToString("yyyy-MM-dd HH:mm");
            string energy = CandleData.TotalEnergy.ToString("N7");
            lbTitle.Text = $"가격 : {title}";
            lbDuration.Text = $"날짜 : {date}";
            lblEnergy.Text = $"에너지 : {energy}";
        }

        private void itemType_Click(object sender, EventArgs e)
        {
            SiseListSelectedEvents.Instance.OnSiseListSelectedChangedHandler(Index, CandleData);
        }
    }
}
