using OM.Lib.Base.Enums;
using OM.Lib.Entity;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Chakra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains.Strategy
{
    public partial class CandleSummaryForm : Form
    {
        //PPContext.Instance

        System.Threading.Timer timer = null;

        bool isRunning = false;
        bool isStart = false;
        public CandleSummaryForm()
        {
            InitializeComponent();
            this.Load += CandleSummaryForm_Load;
        }

        private void CandleSummaryForm_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(timer_Tick, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(1));
        }

        private void StrategyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            isStart = false;
        }
        private void timer_Tick(object state)
        {
            if (isRunning) return;
            if (!isStart) return;

            isRunning = true;

            var list = CandleSummary.Instance.ForecastInfos;

            this.Invoke(new MethodInvoker(delegate () {
                dgv.Rows.Clear();

                foreach (var m in list)
                {
                    if (tbItem.Text.Length > 0 && m.Item != tbItem.Text) continue;

                    int idx = dgv.Rows.Add(m.Item, m.TimeInterval, m.Position, m.Trend, m.Volatility, m.BaseLine, m.TrendOfStrength, m.ForcastOfStrength);

                    dgv.Rows[idx].Cells[3].Style.ForeColor = GetColor(m.Trend);
                    dgv.Rows[idx].Cells[4].Style.ForeColor = GetColor(m.Volatility);
                    dgv.Rows[idx].Cells[5].Style.ForeColor = GetColor(m.BaseLine);
                }
            }));
            
            isRunning = false;
        }            

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            var m = dgv.Rows[e.RowIndex].Tag as PriceMonitoring;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            isStart = true;
            lblMonitorState.Text = "모니터링중......";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStart = false;
            lblMonitorState.Text = "모니터링중지.";
        }

        private Color GetColor(UpDownEnum upDown)
        {
            if (upDown == UpDownEnum.Down) return Color.Blue;
            if (upDown == UpDownEnum.Up) return Color.Red;

            if (upDown == UpDownEnum.StrongUp) return Color.DarkRed;
            if (upDown == UpDownEnum.WeakUp) return Color.MediumVioletRed;

            if (upDown == UpDownEnum.StrongDown) return Color.DarkBlue;
            if (upDown == UpDownEnum.WeakDown) return Color.MediumBlue;

            return Color.Black;
        }
    }
}
