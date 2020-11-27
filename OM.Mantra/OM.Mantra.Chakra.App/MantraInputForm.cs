using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Mantra.Chakra.App
{
    public partial class MantraInputForm : MetroFramework.Forms.MetroForm
    {
        ucs.ucBasicInfo _ucBasicInfo = new ucs.ucBasicInfo();
        ucs.ucTechScore _ucTechScore = new ucs.ucTechScore();
        ucs.ucRisk _ucRisk = new ucs.ucRisk();
        ucs.ucTechView _ucTechView = new ucs.ucTechView();
        ucs.ucBaseLine _ucBaseLine = new ucs.ucBaseLine();
        ucs.ucBuy _ucBuy = new ucs.ucBuy();
        ucs.ucSell _ucSell = new ucs.ucSell();
        ucs.ucTradeSheet _ucTradeSheet = new ucs.ucTradeSheet();
        ucs.ucDiary _ucDiary = new ucs.ucDiary();

        public MantraInputForm()
        {
            InitializeComponent();
            InitializeControls();
            InitializeEvents();
        }

        private void InitializeControls()
        {
            tp_BasicInfo.Controls.Add(_ucBasicInfo);
            _ucBasicInfo.Dock = DockStyle.Fill;

            tp_Tech1.Controls.Add(_ucTechScore);
            _ucTechScore.Dock = DockStyle.Fill;

            tp_Risk.Controls.Add(_ucRisk);
            _ucRisk.Dock = DockStyle.Fill;

            tp_Tech2.Controls.Add(_ucTechView);
            _ucTechView.Dock = DockStyle.Fill;

            tp_BaseLine.Controls.Add(_ucBaseLine);
            _ucBaseLine.Dock = DockStyle.Fill;

            tp_Buy.Controls.Add(_ucBuy);
            _ucBuy.Dock = DockStyle.Fill;

            tp_Sell.Controls.Add(_ucSell);
            _ucSell.Dock = DockStyle.Fill;

            tp_TradeSheet.Controls.Add(_ucTradeSheet);
            _ucTradeSheet.Dock = DockStyle.Fill;

            tp_Diary.Controls.Add(_ucDiary);
            _ucDiary.Dock = DockStyle.Fill;
        }

        private void InitializeEvents()
        {
            //_ucBasicInfo.Dock = DockStyle.Fill;
            //_ucTechScore.Dock = DockStyle.Fill;
            //_ucRisk.Dock = DockStyle.Fill;
            //_ucTechView.Dock = DockStyle.Fill;
            //_ucBaseLine.Dock = DockStyle.Fill;
            //_ucBuy.Dock = DockStyle.Fill;
            //_ucSell.Dock = DockStyle.Fill;
            //_ucTradeSheet.Dock = DockStyle.Fill;
            //_ucDiary.Dock = DockStyle.Fill;
        }

    }
}
