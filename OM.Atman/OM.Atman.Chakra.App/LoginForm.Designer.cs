namespace OM.Atman.Chakra.App
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.tbSecurity = new MetroFramework.Controls.MetroTextBox();
            this.chkPlanResult = new MetroFramework.Controls.MetroRadioButton();
            this.chkSignalMatching = new MetroFramework.Controls.MetroRadioButton();
            this.chkSignalComplication = new MetroFramework.Controls.MetroRadioButton();
            this.chkDiary = new MetroFramework.Controls.MetroRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRealBoard = new MetroFramework.Controls.MetroRadioButton();
            this.chkCalculator = new MetroFramework.Controls.MetroRadioButton();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(11, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "---------------------------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(11, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 12);
            this.label4.TabIndex = 27;
            this.label4.Text = "---------------------------------------";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(176, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "LOGIN";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSecurity
            // 
            // 
            // 
            // 
            this.tbSecurity.CustomButton.Image = null;
            this.tbSecurity.CustomButton.Location = new System.Drawing.Point(121, 1);
            this.tbSecurity.CustomButton.Name = "";
            this.tbSecurity.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.tbSecurity.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbSecurity.CustomButton.TabIndex = 1;
            this.tbSecurity.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbSecurity.CustomButton.UseSelectable = true;
            this.tbSecurity.CustomButton.Visible = false;
            this.tbSecurity.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbSecurity.Lines = new string[] {
        "atman999"};
            this.tbSecurity.Location = new System.Drawing.Point(13, 321);
            this.tbSecurity.MaxLength = 32767;
            this.tbSecurity.Name = "tbSecurity";
            this.tbSecurity.PasswordChar = '#';
            this.tbSecurity.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbSecurity.SelectedText = "";
            this.tbSecurity.SelectionLength = 0;
            this.tbSecurity.SelectionStart = 0;
            this.tbSecurity.ShortcutsEnabled = true;
            this.tbSecurity.Size = new System.Drawing.Size(141, 21);
            this.tbSecurity.TabIndex = 19;
            this.tbSecurity.Text = "atman999";
            this.tbSecurity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSecurity.UseSelectable = true;
            this.tbSecurity.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbSecurity.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chkPlanResult
            // 
            this.chkPlanResult.AutoSize = true;
            this.chkPlanResult.BackColor = System.Drawing.Color.Black;
            this.chkPlanResult.Checked = true;
            this.chkPlanResult.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkPlanResult.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkPlanResult.ForeColor = System.Drawing.Color.White;
            this.chkPlanResult.Location = new System.Drawing.Point(34, 75);
            this.chkPlanResult.Name = "chkPlanResult";
            this.chkPlanResult.Size = new System.Drawing.Size(177, 25);
            this.chkPlanResult.TabIndex = 30;
            this.chkPlanResult.TabStop = true;
            this.chkPlanResult.Text = "국내지수 투자전략";
            this.chkPlanResult.UseCustomBackColor = true;
            this.chkPlanResult.UseCustomForeColor = true;
            this.chkPlanResult.UseSelectable = true;
            // 
            // chkSignalMatching
            // 
            this.chkSignalMatching.AutoSize = true;
            this.chkSignalMatching.BackColor = System.Drawing.Color.Black;
            this.chkSignalMatching.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkSignalMatching.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkSignalMatching.ForeColor = System.Drawing.Color.White;
            this.chkSignalMatching.Location = new System.Drawing.Point(34, 106);
            this.chkSignalMatching.Name = "chkSignalMatching";
            this.chkSignalMatching.Size = new System.Drawing.Size(154, 25);
            this.chkSignalMatching.TabIndex = 31;
            this.chkSignalMatching.Text = "패턴매칭시그널";
            this.chkSignalMatching.UseCustomBackColor = true;
            this.chkSignalMatching.UseCustomForeColor = true;
            this.chkSignalMatching.UseSelectable = true;
            // 
            // chkSignalComplication
            // 
            this.chkSignalComplication.AutoSize = true;
            this.chkSignalComplication.BackColor = System.Drawing.Color.Black;
            this.chkSignalComplication.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkSignalComplication.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkSignalComplication.ForeColor = System.Drawing.Color.White;
            this.chkSignalComplication.Location = new System.Drawing.Point(34, 137);
            this.chkSignalComplication.Name = "chkSignalComplication";
            this.chkSignalComplication.Size = new System.Drawing.Size(154, 25);
            this.chkSignalComplication.TabIndex = 32;
            this.chkSignalComplication.Text = "삼오매매시그널";
            this.chkSignalComplication.UseCustomBackColor = true;
            this.chkSignalComplication.UseCustomForeColor = true;
            this.chkSignalComplication.UseSelectable = true;
            // 
            // chkDiary
            // 
            this.chkDiary.AutoSize = true;
            this.chkDiary.BackColor = System.Drawing.Color.Black;
            this.chkDiary.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkDiary.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkDiary.ForeColor = System.Drawing.Color.White;
            this.chkDiary.Location = new System.Drawing.Point(34, 179);
            this.chkDiary.Name = "chkDiary";
            this.chkDiary.Size = new System.Drawing.Size(136, 25);
            this.chkDiary.TabIndex = 33;
            this.chkDiary.Text = "투자다이어리";
            this.chkDiary.UseCustomBackColor = true;
            this.chkDiary.UseCustomForeColor = true;
            this.chkDiary.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(11, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "---------------------------------------";
            // 
            // chkRealBoard
            // 
            this.chkRealBoard.AutoSize = true;
            this.chkRealBoard.BackColor = System.Drawing.Color.Black;
            this.chkRealBoard.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkRealBoard.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkRealBoard.ForeColor = System.Drawing.Color.White;
            this.chkRealBoard.Location = new System.Drawing.Point(34, 224);
            this.chkRealBoard.Name = "chkRealBoard";
            this.chkRealBoard.Size = new System.Drawing.Size(182, 25);
            this.chkRealBoard.TabIndex = 35;
            this.chkRealBoard.Text = "실시간 시세 전광판";
            this.chkRealBoard.UseCustomBackColor = true;
            this.chkRealBoard.UseCustomForeColor = true;
            this.chkRealBoard.UseSelectable = true;
            // 
            // chkCalculator
            // 
            this.chkCalculator.AutoSize = true;
            this.chkCalculator.BackColor = System.Drawing.Color.Black;
            this.chkCalculator.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkCalculator.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkCalculator.ForeColor = System.Drawing.Color.White;
            this.chkCalculator.Location = new System.Drawing.Point(34, 255);
            this.chkCalculator.Name = "chkCalculator";
            this.chkCalculator.Size = new System.Drawing.Size(159, 25);
            this.chkCalculator.TabIndex = 36;
            this.chkCalculator.Text = "매수매도 계산기";
            this.chkCalculator.UseCustomBackColor = true;
            this.chkCalculator.UseCustomForeColor = true;
            this.chkCalculator.UseSelectable = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(269, 354);
            this.Controls.Add(this.chkCalculator);
            this.Controls.Add(this.chkRealBoard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkDiary);
            this.Controls.Add(this.chkSignalComplication);
            this.Controls.Add(this.chkSignalMatching);
            this.Controls.Add(this.chkPlanResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbSecurity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "ATMAN LOGIN";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Controls.MetroButton button1;
        private MetroFramework.Controls.MetroTextBox tbSecurity;
        private MetroFramework.Controls.MetroRadioButton chkPlanResult;
        private MetroFramework.Controls.MetroRadioButton chkSignalMatching;
        private MetroFramework.Controls.MetroRadioButton chkSignalComplication;
        private MetroFramework.Controls.MetroRadioButton chkDiary;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroRadioButton chkRealBoard;
        private MetroFramework.Controls.MetroRadioButton chkCalculator;
    }
}