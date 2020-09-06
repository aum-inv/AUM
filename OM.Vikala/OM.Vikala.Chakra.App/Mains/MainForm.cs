using MaterialSkin;
using OM.Lib.Base.Enums;
using OM.PP.Chakra.Ctx;
using OM.Vikala.Chakra.App.Config;
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
    public partial class MainForm : MaterialSkin.Controls.MaterialForm
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


            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


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
            tscbItem.SelectedIndex = 1;

            SharedData.SelectedItem = tscbItem.SelectedItem as ItemData;
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

                    if (bmf.Text.Length < 6)
                        bmf.Text += "     ";

                    TabPage tp = new TabPage(bmf.Text);                   
                    tabPage.TabPages.Add(tp);
                    tp.Controls.Add(bmf);                   

                    bmf.Show();
                    formList.Add(bmf);

                    tabPage.SelectedTab = tp;                   
                    tabPage.Update();
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
                r.Offset(4, 4);
                Brush TitleBrush = new SolidBrush(Color.Black);
                Font f = this.Font;
                
                string title = tabPage.TabPages[e.Index].Text.Replace("챠트",  "");
                if (e.Index == tabPage.SelectedIndex)
                {
                    e.Graphics.DrawString(title, new Font(tabPage.Font, FontStyle.Bold), Brushes.DarkRed, new PointF(r.X, r.Y + 2));
                    e.Graphics.DrawString("X", new Font(tabPage.Font, FontStyle.Bold), Brushes.DarkRed, new Point(r.X + (tabPage.GetTabRect(e.Index).Width - 20), 9));
                }
                else
                {
                    e.Graphics.DrawString(title, f, TitleBrush, new PointF(r.X, r.Y + 2));
                    e.Graphics.DrawString("X", f, TitleBrush, new Point(r.X + (tabPage.GetTabRect(e.Index).Width - 20), 9));
                }
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
                        case "추세기간":
                            createMovingAverageDurationChart(menuText);
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
                                       
                        case "캔들라인형:변화챠트":
                            createCandleLineTypeChart_Velocity(menuText);
                            break;

                        case "캔들라인형:반입자챠트":
                            createCandleLineTypeChart_Anti(menuText);
                            break;
                        case "캔들라인형:반캔들흐름챠트":
                            createCandleLineTypeChart_Cac(menuText);
                            break;

                        case "캔들라인형:세컨드흐름챠트":
                            createCandleLineTypeChart_SecondCandle(menuText);
                            break;
                        #endregion

                        #region 캔들형
                        //기본 음양오행 음양오행(누적) 진동주파수 삼태극 미러
                        case "캔들형:기본챠트":
                            createCandleTypeChart_Basic(menuText);
                            break;
                        case "캔들형:비교기본챠트":
                            createCandleTypeChart_ComparedBasic(menuText);
                            break;

                        case "추세기간챠트:단순평균-가중-3":
                        case "추세기간챠트:단순평균-가중-2":
                        case "추세기간챠트:단순평균-일반-3":
                        case "추세기간챠트:단순평균-일반-2":
                        case "추세기간챠트:밸런스평균-가중-3":
                        case "추세기간챠트:밸런스평균-가중-2":
                        case "추세기간챠트:밸런스평균-일반-3":
                        case "추세기간챠트:밸런스평균-일반-2":
                        case "추세기간챠트:가중평균-가중-3":
                        case "추세기간챠트:가중평균-가중-2":
                        case "추세기간챠트:가중평균-일반-3":
                        case "추세기간챠트:가중평균-일반-2":
                            createCandleTypeChart_AverageDuration(menuText);
                            break;                       
                        case "캔들형:미러챠트":
                            createCandleTypeChart_Mirror(menuText);
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
                        case "라인형:길이변화챠트":
                            createLineTypeChart_LengthRate(menuText);
                            break;
                        case "라인형:암흑질량챠트":
                            createCandleLineTypeChart_Dm(menuText);
                            break;
                        case "라인형:양극챠트":
                            createCandleLineTypeChart_ANode(menuText);
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
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.Message); }
        }
        private void createRequiredCharts()
        {
            //국내지수
            if (SharedData.SelectedType == "KR")
            {
                createTrendMultiChart("분챠트추세");
                createCandleLineTypeChart_Atom("원자챠트");
                createCandleLineTypeChart_Quantum("양자챠트");
                createCandleLineTypeChart_QuantumHL("양자고저챠트");
                createCandleLineTypeChart_Dice("주사위챠트");
                createCandleLineTypeChart_Velocity("변화챠트");
                createTimeComplexChart("멀티타임챠트");
            }
            //해외선물
            if (SharedData.SelectedType == "US")
            {
                createTrendMultiChart("분챠트추세");
                createCandleLineTypeChart_Atom("원자챠트");
                createCandleLineTypeChart_Quantum("양자챠트");
                createCandleLineTypeChart_QuantumHL("양자고저챠트");
                createCandleLineTypeChart_Dice("주사위챠트");
                createCandleLineTypeChart_Velocity("변화챠트");
                createTimeComplexChart("멀티타임챠트");
            }
        }

        #region 멀티챠트
        private void createTrendMultiChart(string title)
        {
            //국내지수
            if (SharedData.SelectedType == "KR")
            {
                if (title == "단중장추세")
                {
                    var bmf1 = new TrendChartFormS_KR();
                    bmf1.Text = "단기추세";
                    AddTab(bmf1);
                    var bmf2 = new TrendChartFormM_KR();
                    bmf2.Text = "중기추세";
                    AddTab(bmf2);
                    var bmf3 = new TrendChartFormL_KR();
                    bmf3.Text = "장기추세";
                    AddTab(bmf3);
                }

                if (title == "분챠트추세")
                {
                    var bmf = new TrendMinuteChartForm_KR();
                    bmf.Text = title;
                    AddTab(bmf);
                }
            }
            //해외선물
            if (SharedData.SelectedType == "US")
            {
                if (title == "단중장추세")
                {
                    var bmf1 = new TrendChartFormS();
                    bmf1.Text = "단기추세";
                    AddTab(bmf1);
                    var bmf2 = new TrendChartFormM();
                    bmf2.Text = "중기추세";
                    AddTab(bmf2);
                    var bmf3 = new TrendChartFormL();
                    bmf3.Text = "장기추세";
                    AddTab(bmf3);
                }

                if (title == "분챠트추세")
                {
                    var bmf = new TrendMinuteChartForm();
                    bmf.Text = title;
                    AddTab(bmf);
                }
            }
        }
        private void createTimeComplexChart(string title)
        {
            var bmf = new ChartForm.ComplexChartForm();
            bmf.Text = title;
            AddTab(bmf);
        }

        private void createMovingAverageDurationChart(string title)
        {
            BaseForm bmf = new ChartForm.MovingAverageDurationChartForm();
            bmf.Text = title;
            AddTab(bmf);
        }
        
        #endregion

        #region 캔들라인형챠트
        private void createCandleLineTypeChart_Atom(string title) {
            var form = new Mains.ChartForm.AtomChartForm();
            form.Text = title;
            AddTab(form);

            form = new Mains.ChartForm.AtomChartForm(OriginSourceTypeEnum.Whim);
            form.Text = title + "(Whim)";
            AddTab(form);

            form = new Mains.ChartForm.AtomChartForm(OriginSourceTypeEnum.Second);
            form.Text = title + "(SOrigin)";
            AddTab(form);
            form = new Mains.ChartForm.AtomChartForm(OriginSourceTypeEnum.SecondQutum);
            form.Text = title + "(SQutum)";
            AddTab(form);
        }
        private void createCandleLineTypeChart_Quantum(string title) {            
            var form = new Mains.ChartForm.QuantumChartForm();
            form.Text = title;
            AddTab(form);

            form = new Mains.ChartForm.QuantumChartForm(OriginSourceTypeEnum.Whim);
            form.Text = title + "(Whim)";
            AddTab(form);

            form = new Mains.ChartForm.QuantumChartForm(OriginSourceTypeEnum.Second);
            form.Text = title + "(SOrigin)";
            AddTab(form);
            form = new Mains.ChartForm.QuantumChartForm(OriginSourceTypeEnum.SecondQutum);
            form.Text = title + "(SQutum)";
            AddTab(form);
        }
        private void createCandleLineTypeChart_QuantumHL(string title)
        {
            var form = new Mains.ChartForm.QuantumChartHLForm();
            form.Text = title;
            AddTab(form);

            form = new Mains.ChartForm.QuantumChartHLForm(OriginSourceTypeEnum.Whim);
            form.Text = title + "(Whim)";
            AddTab(form);

            form = new Mains.ChartForm.QuantumChartHLForm(OriginSourceTypeEnum.Second);
            form.Text = title + "(SOrigin)";
            AddTab(form);
            form = new Mains.ChartForm.QuantumChartHLForm(OriginSourceTypeEnum.SecondQutum);
            form.Text = title + "(SQutum)";
            AddTab(form);
        }
        private void createCandleLineTypeChart_Dice(string title)
        {
            var form = new Mains.ChartForm.DiceChartForm();
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

        private void createCandleLineTypeChart_Cac(string title)
        {
            var form = new Mains.ChartForm.CandleAntiCandleChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_SecondCandle(string title)
        {
            var form = new Mains.ChartForm.RemoveFirstPriceChartForm(false, false);
            form.Text = "세컨드:원본:일반";
            AddTab(form);

            var form2 = new Mains.ChartForm.RemoveFirstPriceChartForm(true, false);           
            form2.Text = "세컨드:평균:일반"; 
            AddTab(form2);

            var form3 = new Mains.ChartForm.RemoveFirstPriceChartForm(false, true);
            form3.Text = "세컨드:원본:상세";
            AddTab(form3);

            var form4 = new Mains.ChartForm.RemoveFirstPriceChartForm(true, true);
            form4.Text = "세컨드:평균:상세";
            AddTab(form4);
        }
       
        #endregion

        #region 캔들형챠트
        private void createCandleTypeChart_Basic(string title) {
            var form = new Mains.ChartForm.CandleChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_ComparedBasic(string title)
        {
            var form = new Mains.ChartForm.ComparedCandleChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleTypeChart_AverageDuration(string title)
        {
            string averageType = "단순";
            bool isStrengthed = true;
            int inflectionPoint = 3;

            if (title.StartsWith("밸런스")) averageType = "밸런스";
            else if (title.StartsWith("가중")) averageType = "가중";

            isStrengthed = (title.IndexOf("-일반-") > 0);

            if (title.EndsWith("2")) inflectionPoint = 2;
          
            var form = new Mains.ChartForm.MovingAverageDurationChartForm(averageType, isStrengthed, inflectionPoint);
            form.Text = title;
            AddTab(form);
        }      
            
        private void createCandleTypeChart_Mirror(string title) {
            var form = new Mains.ChartForm.MirrorChartForm();
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
            form.IsShowCandle = true;
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_Dm(string title)
        {
            var form = new Mains.ChartForm.DarkMassChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createCandleLineTypeChart_ANode(string title)
        {
            var form = new Mains.ChartForm.ANodeLineChartForm();
            form.Text = title;
            AddTab(form);
        }
        private void createLineTypeChart_LengthRate(string title)
        {
            var form = new Mains.ChartForm.LengthRateChartForm();
            form.IsShowCandle = true;
            form.Text = title;
            AddTab(form);
        }
        private void createLineTypeChart_Quantum(string title)
        {
            var form = new Mains.ChartForm.QuantumChartForm();
            form.IsShowCandle = true;
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
