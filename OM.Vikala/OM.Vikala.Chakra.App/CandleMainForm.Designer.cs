namespace OM.Vikala.Chakra.App
{
    partial class CandleMainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CandleMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartCS2 = new OM.Vikala.Controls.Charts.BasicCandleChart();
            this.chartCS1 = new OM.Vikala.Controls.Charts.BasicCandleChart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 25);
            this.panel1.TabIndex = 0;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadData.Location = new System.Drawing.Point(0, 0);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(133, 25);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "LoadData";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1327, 707);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartCS2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartCS1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1327, 707);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // chartCS2
            // 
            this.chartCS2.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chartCS2.ChartData = null;
            this.chartCS2.ChartEventInstance = null;
            this.chartCS2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCS2.IsAutoScrollX = true;
            this.chartCS2.IsLoaded = false;
            this.chartCS2.ItemCode = "";
            this.chartCS2.Location = new System.Drawing.Point(8, 359);
            this.chartCS2.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartCS2.DisplayPointCount = 30;
            this.chartCS2.Name = "chartCS2";
            this.chartCS2.Size = new System.Drawing.Size(1311, 342);
            this.chartCS2.TabIndex = 3;
            // 
            // chartCS1
            // 
            this.chartCS1.CandleChartType = OM.Vikala.Controls.Charts.CandleChartTypeEnum.기본;
            this.chartCS1.ChartData = null;
            this.chartCS1.ChartEventInstance = null;
            this.chartCS1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCS1.IsAutoScrollX = true;
            this.chartCS1.IsLoaded = false;
            this.chartCS1.ItemCode = "";
            this.chartCS1.Location = new System.Drawing.Point(8, 6);
            this.chartCS1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.chartCS1.DisplayPointCount = 30;
            this.chartCS1.Name = "chartCS1";
            this.chartCS1.Size = new System.Drawing.Size(1311, 341);
            this.chartCS1.TabIndex = 2;
            // 
            // CandleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 744);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "CandleMainForm";
            this.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Text = "캔들챠트 테스트 폼";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Controls.Charts.BasicCandleChart chartCS1;
        private Controls.Charts.BasicCandleChart chartCS2;
    }
}

