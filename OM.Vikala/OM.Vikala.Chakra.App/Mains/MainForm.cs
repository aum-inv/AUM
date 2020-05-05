using OM.Lib.Base.Enums;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OM.Vikala.Chakra.App.Mains
{
    public partial class MainForm : Form
    {
        List<BaseForm> formList = new List<BaseForm>();

        public bool isUseMdiForm = true;
        public TabControl MdiTabControl
        {
            get
            {
                return this.tabPage;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            serverInfo();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setItems();
        }

        private void serverInfo()
        {
            PPServerConfigData.IP = ConfigurationManager.AppSettings["PPService_IP"];
            PPServerConfigData.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PPService_Port"]);
            PPContext.Instance.OnCreateClient();
        }
        private void setItems()
        {
            ItemData[] itemDatas = new ItemData[ItemCodeSet.Items.Length];
            ItemCodeSet.Items.CopyTo(itemDatas, 0);

            tscbItem.ComboBox.DataSource = itemDatas;
            tscbItem.ComboBox.DisplayMember = "Name";
            tscbItem.ComboBox.ValueMember = "Code";
            tscbItem.SelectedIndex = -1;
        }

        public void AddTab(BaseForm bmf)
        {
            try
            {
                if (isUseMdiForm)
                {
                    bmf.WindowState = FormWindowState.Maximized;
                    bmf.MdiParent = this;
                    bmf.MdiForm = this;

                    TabPage tp = new TabPage(bmf.Text);
                    tp.Controls.Add(bmf);
                    tabPage.TabPages.Add(tp);
                    bmf.Show();
                    formList.Add(bmf);

                    tabPage.SelectedTab = tp;
                }
                else
                {
                    bmf.Show();
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        public void RemoveTab(BaseForm bmf)
        {
            try
            {
                TabPage sP = null;
                foreach (TabPage p in tabPage.TabPages)
                {
                    if (p.Controls.Count > 0)
                    {
                        if (p.Controls[0] == bmf)
                        {
                            sP = p;
                            break;
                        }
                    }
                }
                if (sP != null)
                    tabPage.TabPages.Remove(sP);

                formList.Remove(bmf);
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
      
        private void tabPage_DrawItem(object sender, DrawItemEventArgs e)
        {            
            try
            {
                Rectangle r = e.Bounds;
                r = tabPage.GetTabRect(e.Index);
                r.Offset(2, 2);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                string title = tabPage.TabPages[e.Index].Text.Replace("챠트",  "");

                e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y + 2));

                e.Graphics.DrawString("X", f, TitleBrush, new Point(r.X + (tabPage.GetTabRect(e.Index).Width - 16), 7));                
            }
            catch (Exception) { }
        }

        private void tabPage_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                TabControl tc = (TabControl)sender;
                Point p = e.Location;
                int _tabWidth = 0;
                _tabWidth = tabPage.GetTabRect(tc.SelectedIndex).Width - 16;
                Rectangle r = tabPage.GetTabRect(tc.SelectedIndex);
                r.Offset(_tabWidth, 7);
                r.Width = 16;
                r.Height = 16;
                if (r.Contains(p))
                {
                    TabPage TabP = (TabPage)tc.TabPages[tc.SelectedIndex];
                    tc.TabPages.Remove(TabP);

                    if (TabP.Controls.Count > 0)
                        RemoveTab((BaseForm)TabP.Controls[0]);
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var f in formList)
                {
                    f.WindowState = FormWindowState.Normal;
                    f.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void tabPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPage.SelectedIndex < 0) return;
                if (tabPage.SelectedTab == null) return;

                if (tabPage.SelectedTab.Controls.Count > 0)
                {
                    Form f = (Form)tabPage.SelectedTab.Controls[0];

                    f.WindowState = FormWindowState.Normal;
                    f.WindowState = FormWindowState.Maximized;
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void tsb_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ToolStripSplitButton tsb = sender as ToolStripSplitButton;
                tsb.ShowDropDown();
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }

        private void tsb_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is ToolStripButton)
                {
                    ToolStripButton menu = sender as ToolStripButton;
                    string menuText = menu.Text;
                    switch (menuText)
                    {
                        case "필수챠트":
                            createRequiredCharts();
                            break;
                        case "단중장추세":
                            createTrendMultiChart(menuText);
                            break;
                        case "분챠트추세":
                            createTrendMultiChart(menuText);
                            break;
                        case "틱챠트추세":
                            createTrendMultiChart(menuText);
                            break;
                        case "멀티타임캔들":
                            createTimeComplexChart(menuText);
                            break;
                    }
                }
                else if (sender is ToolStripMenuItem)
                {
                    ToolStripMenuItem menu = sender as ToolStripMenuItem;
                    string pMenuText = menu.OwnerItem.Text;
                    string menuText = pMenuText + ":" + menu.Text;
                    switch (menuText)
                    {
                        #region 캔들라인형
                        //원자 양자 질량 삼태극 리버스
                        case "캔들라인형:원자챠트":
                            createCandleLineTypeChart_Atom(menuText);
                            break;
                        case "캔들라인형:양자챠트":
                            createCandleLineTypeChart_Quantum(menuText);
                            break;
                        case "캔들라인형:양자고저챠트":
                            createCandleLineTypeChart_QuantumHL(menuText);
                            break;
                        case "캔들라인형:주사위챠트":
                            createCandleLineTypeChart_Dice(menuText);
                            break;
                        case "캔들라인형:삼태극챠트":
                            createCandleLineTypeChart_Wuxing(menuText);
                            break;
                        case "캔들라인형:리버스챠트":
                            createCandleLineTypeChart_Reverse(menuText);
                            break;
                        case "캔들라인형:챠크라챠트":
                            createCandleLineTypeChart_Chakra(menuText);
                            break;
                        case "캔들라인형:변화챠트":
                            createCandleLineTypeChart_Velocity(menuText);
                            break;

                        case "캔들라인형:반입자챠트":
                            createCandleLineTypeChart_Anti(menuText);
                            break;

                        case "캔들라인형:천부경챠트":
                            createCandleLineTypeChart_Cbk(menuText);
                            break;
                        #endregion

                        #region 캔들형
                        //기본 음양오행 음양오행(누적) 진동주파수 삼태극 미러
                        case "캔들형:기본챠트":
                            createCandleTypeChart_Basic(menuText);
                            break;

                        case "기본챠트:인-캔들챠트":
                            createCandleTypeChart_Basic_인(menuText);
                            break;
                        case "기본챠트:지-캔들챠트":
                            createCandleTypeChart_Basic_지(menuText);
                            break;
                        case "기본챠트:천-캔들챠트":
                            createCandleTypeChart_Basic_천(menuText);
                            break;
                        case "기본챠트:천지인-캔들챠트":
                            createCandleTypeChart_Basic_천지인(menuText);
                            break;

                        case "캔들형:천지인챠트":
                            createCandleTypeChart_Slh(menuText);
                            break;
                        case "캔들형:쿼크챠트":
                            createCandleTypeChart_Quark(menuText);
                            break;
                        case "캔들형:음양오행챠트":
                            createCandleTypeChart_Five(menuText);
                            break;
                        case "캔들형:음양오행(누적)챠트":
                            createCandleTypeChart_FiveAccur(menuText);
                            break;
                        case "캔들형:음양오행(소수)챠트":
                            createCandleTypeChart_FivePrimeNum(menuText);
                            break;
                        case "캔들형:진동주파수챠트":
                            createCandleTypeChart_Frequency(menuText);
                            break;
                        case "캔들형:삼태극챠트":
                            createCandleTypeChart_Wuxing(menuText);
                            break;
                        case "캔들형:미러챠트":
                            createCandleTypeChart_Mirror(menuText);
                            break;
                        case "캔들형:삼양삼음챠트":
                            createCandleTypeChart_TT(menuText);
                            break;

                        #endregion

                        #region 라인형
                        //기본 변화
                        case "라인형:기본챠트":
                            createLineTypeChart_Basic(menuText);
                            break;
                        case "라인형:변화챠트":
                            createLineTypeChart_Velocity(menuText);
                            break;
                        case "라인형:양자챠트":
                            createLineTypeChart_Quantum(menuText);
                            break;                    
                        #endregion

                        #region 기타형
                        //오색
                        case "기타형:오색챠트":
                            createEtcTypeChart_FiveColor(menuText);
                            break;
                        #endregion


                        #region 챠크라
                        case "챠크라:엘리어트오행":
                            createChakra(menuText);
                            break;
                        case "챠크라:오행마운틴":
                            createChakra(menuText);
                            break;
                            #endregion
                    }
                }
            }
            catch(Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        private void createRequiredCharts()
        {
            createTrendMultiChart("분챠트추세");
            createCandleLineTypeChart_Atom("원자챠트");
            createCandleLineTypeChart_Quantum("양자챠트");
            createCandleLineTypeChart_QuantumHL("양자고저챠트"); 
            createCandleLineTypeChart_Dice("주사위챠트");
            createCandleLineTypeChart_Velocity("변화챠트");
            createTimeComplexChart("멀티타임챠트");
        }

        #region 멀티챠트
        private void createTrendMultiChart(string title)
        {
            if (title == "단중장추세")
            {
                BaseForm bmf1 = new TrendChartFormS();
                bmf1.Text = "단기추세";
                AddTab(bmf1);
                BaseForm bmf2 = new TrendChartFormM();
                bmf2.Text = "중기추세";
                AddTab(bmf2);
                BaseForm bmf3 = new TrendChartFormL();
                bmf3.Text = "장기추세";
                AddTab(bmf3);
            }
          
            if (title == "분챠트추세")
            {
                BaseForm bmf = new TrendMinuteChartForm();
                bmf.Text = title;
                AddTab(bmf);
            }
        }
        private void createTimeComplexChart(string title)
        {
            BaseForm bmf = new ChartForm.ComplexChartForm();
            bmf.Text = title;
            AddTab(bmf);
        }
        #endregion

        #region 캔들라인형챠트
        private void createCandleLineTypeChart_Atom(string title) {
            var form = new Mains.ChartForm.AtomChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Quantum(string title) {            
            var form = new Mains.ChartForm.QuantumChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_QuantumHL(string title)
        {
            var form = new Mains.ChartForm.QuantumChartHLForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Dice(string title)
        {
            var form = new Mains.ChartForm.DiceChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Wuxing(string title) {            
            var form = new Mains.ChartForm.XuWingChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Reverse(string title) {
            var form = new Mains.ChartForm.ReverseChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Chakra(string title)
        {
            var form = new Mains.ChartForm.ChakraChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Velocity(string title)
        {
            var form = new Mains.ChartForm.VelocityChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Anti(string title)
        {
            var form = new Mains.ChartForm.AntiMatterChartForm();           
            form.Text = title;
            AddTab(form);
        }

        private void createCandleLineTypeChart_Cbk(string title)
        {
            var form = new Mains.ChartForm.CheonbugyeongChartForm();
            form.Text = title;
            AddTab(form);
        }
        #endregion

        #region 캔들형챠트
        private void createCandleTypeChart_Basic(string title) {
            var form = new Mains.ChartForm.CandleChartForm();
            form.Text = title;
            AddTab(form);
        }

        private void createCandleTypeChart_Basic_인(string title)
        {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.기본
                , Vikala.Controls.Charts.BaseCandleChartTypeEnum.인);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Basic_지(string title)
        {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.기본
                , Vikala.Controls.Charts.BaseCandleChartTypeEnum.지);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Basic_천(string title)
        {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.기본
                , Vikala.Controls.Charts.BaseCandleChartTypeEnum.천);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Basic_천지인(string title)
        {
            var form = new Mains.ChartForm.CandleChartForm2();
            form.Text = title;
            AddTab(form);
        }

        private void createCandleTypeChart_Slh(string title) {            
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.천지인);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Quark(string title) {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.쿼크);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Five(string title) {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.음양오행);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_FiveAccur(string title)
        {
            var form = new Mains.ChartForm.XuWingChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_FivePrimeNum(string title)
        {
            var form = new Mains.ChartForm.PrimeNumChartForm();
            form.Text = title;
            AddTab(form);
        }        
        private void createCandleTypeChart_Frequency(string title) {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.진동주파수);
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Wuxing(string title) {
            var form = new Mains.ChartForm.ThaChiChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_Mirror(string title) {
            var form = new Mains.ChartForm.MirrorChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_TT(string title) {
            var form = new Mains.ChartForm.CandleChartForm(Vikala.Controls.Charts.CandleChartTypeEnum.삼양삼음);
            form.Text = title;
            AddTab(form);
        }
        #endregion

        #region 라인형챠트
        private void createLineTypeChart_Basic(string title) {
            var form = new Mains.ChartForm.LineChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createLineTypeChart_Velocity(string title) {
            var form = new Mains.ChartForm.VelocityChartForm();
            form.IsShowCandle = false;
            form.Text = title;
            AddTab(form);
        }
        private void createLineTypeChart_Quantum(string title)
        {
            var form = new Mains.ChartForm.QuantumChartForm();
            form.IsShowCandle = false;
            form.Text = title;
            AddTab(form);
        }      
        #endregion

        #region 기타형챠트
        private void createEtcTypeChart_FiveColor(string title) {
            var form = new Mains.ChartForm.FiveColorChartForm();
            form.Text = title;
            AddTab(form);
        }

        #endregion

        #region 챠크라
        private void createChakra(string title)
        {

        }
        private void tsbUrl_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = sender as ToolStripMenuItem;
            string url = menu.Tag.ToString();

            Process.Start("chrome.exe", url);
        }
        #endregion

        private void tsbAutoReloadStart_Click(object sender, EventArgs e)
        {
            try
            {
                MainFormToolBarEvents.Instance.OnAutoReloadHandler(false);
                tsbAutoReloadStart.Visible = false;
                tsbAutoReloadStop.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        private void tsbAutoReloadStop_Click(object sender, EventArgs e)
        {
            try
            {
                MainFormToolBarEvents.Instance.OnAutoReloadHandler(true);
                tsbAutoReloadStart.Visible = true;
                tsbAutoReloadStop.Visible = false;
            }
            catch (Exception)
            {
            }
        }

        private void tsbIsMdiY_Click(object sender, EventArgs e)
        {
            try
            {
                isUseMdiForm = false;
                tsbIsMdiY.Visible = isUseMdiForm;
                tsbIsMdiN.Visible = !isUseMdiForm;
            }
            catch (Exception)
            {
            }
        }

        private void tsbIsMdiN_Click(object sender, EventArgs e)
        {
            //isUseMdiForm = true;
            //tsbIsMdiY.Visible = isUseMdiForm;
            //tsbIsMdiN.Visible = !isUseMdiForm;

            MainFormToolBarEvents.Instance.OnManualReloadHandler();
        }

        private void tsbNoMdiAll_Click(object sender, EventArgs e)
        {
            for(int i = formList.Count - 1; i >= 0; i--)
            {
                formList[i].OnMdiOut();
            }
        }

        private void tsbAtman_Click(object sender, EventArgs e)
        {
            //new Strategy.CandleSummaryForm().Show();
        }

        private void TscbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tscbItem.SelectedIndex > 0 )
                MainFormToolBarEvents.Instance.OnItemSelectedChangedHandler(tscbItem.SelectedIndex);
        }
    }
}
