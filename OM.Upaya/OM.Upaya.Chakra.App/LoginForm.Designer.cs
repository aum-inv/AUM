namespace OM.Upaya.Chakra.App
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
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.tbSecurity = new MetroFramework.Controls.MetroTextBox();
            this.chkPlanResultKR = new MetroFramework.Controls.MetroCheckBox();
            this.chkSignalComplication = new MetroFramework.Controls.MetroCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRealBoard = new MetroFramework.Controls.MetroCheckBox();
            this.chkPlanResultFF = new MetroFramework.Controls.MetroCheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(11, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(191, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "-------------------------------";
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(293, 249);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(71, 23);
            this.btnLogin.TabIndex = 20;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.button1_Click);
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
            this.tbSecurity.Location = new System.Drawing.Point(126, 249);
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
            // chkPlanResultKR
            // 
            this.chkPlanResultKR.AutoSize = true;
            this.chkPlanResultKR.BackColor = System.Drawing.Color.Black;
            this.chkPlanResultKR.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkPlanResultKR.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkPlanResultKR.ForeColor = System.Drawing.Color.White;
            this.chkPlanResultKR.Location = new System.Drawing.Point(26, 75);
            this.chkPlanResultKR.Name = "chkPlanResultKR";
            this.chkPlanResultKR.Size = new System.Drawing.Size(233, 25);
            this.chkPlanResultKR.TabIndex = 30;
            this.chkPlanResultKR.Text = "해외선물 기본 매매 3단계";
            this.chkPlanResultKR.UseCustomBackColor = true;
            this.chkPlanResultKR.UseCustomForeColor = true;
            this.chkPlanResultKR.UseSelectable = true;
            this.chkPlanResultKR.CheckedChanged += new System.EventHandler(this.RadioButton_Click);
            // 
            // chkSignalComplication
            // 
            this.chkSignalComplication.AutoSize = true;
            this.chkSignalComplication.BackColor = System.Drawing.Color.Black;
            this.chkSignalComplication.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkSignalComplication.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkSignalComplication.ForeColor = System.Drawing.Color.White;
            this.chkSignalComplication.Location = new System.Drawing.Point(276, 118);
            this.chkSignalComplication.Name = "chkSignalComplication";
            this.chkSignalComplication.Size = new System.Drawing.Size(233, 25);
            this.chkSignalComplication.TabIndex = 32;
            this.chkSignalComplication.Text = "국내종목 기본 매매 5단계";
            this.chkSignalComplication.UseCustomBackColor = true;
            this.chkSignalComplication.UseCustomForeColor = true;
            this.chkSignalComplication.UseSelectable = true;
            this.chkSignalComplication.CheckedChanged += new System.EventHandler(this.RadioButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(11, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "-------------------------------";
            // 
            // chkRealBoard
            // 
            this.chkRealBoard.AutoSize = true;
            this.chkRealBoard.BackColor = System.Drawing.Color.Black;
            this.chkRealBoard.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkRealBoard.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkRealBoard.ForeColor = System.Drawing.Color.White;
            this.chkRealBoard.Location = new System.Drawing.Point(276, 75);
            this.chkRealBoard.Name = "chkRealBoard";
            this.chkRealBoard.Size = new System.Drawing.Size(233, 25);
            this.chkRealBoard.TabIndex = 35;
            this.chkRealBoard.Text = "국내종목 기본 매매 3단계";
            this.chkRealBoard.UseCustomBackColor = true;
            this.chkRealBoard.UseCustomForeColor = true;
            this.chkRealBoard.UseSelectable = true;
            this.chkRealBoard.CheckedChanged += new System.EventHandler(this.RadioButton_Click);
            // 
            // chkPlanResultFF
            // 
            this.chkPlanResultFF.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPlanResultFF.AutoSize = true;
            this.chkPlanResultFF.BackColor = System.Drawing.Color.Black;
            this.chkPlanResultFF.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.chkPlanResultFF.FontWeight = MetroFramework.MetroCheckBoxWeight.Bold;
            this.chkPlanResultFF.ForeColor = System.Drawing.Color.White;
            this.chkPlanResultFF.Location = new System.Drawing.Point(26, 117);
            this.chkPlanResultFF.Name = "chkPlanResultFF";
            this.chkPlanResultFF.Size = new System.Drawing.Size(233, 25);
            this.chkPlanResultFF.TabIndex = 39;
            this.chkPlanResultFF.Text = "해외선물 기본 매매 5단계";
            this.chkPlanResultFF.UseCustomBackColor = true;
            this.chkPlanResultFF.UseCustomForeColor = true;
            this.chkPlanResultFF.UseSelectable = true;
            this.chkPlanResultFF.CheckedChanged += new System.EventHandler(this.RadioButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkRed;
            this.label6.Location = new System.Drawing.Point(264, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "-------------------------------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(261, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 12);
            this.label8.TabIndex = 47;
            this.label8.Text = "-------------------------------";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(519, 294);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkPlanResultFF);
            this.Controls.Add(this.chkRealBoard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSignalComplication);
            this.Controls.Add(this.chkPlanResultKR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbSecurity);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "UPAYA TRADING";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroButton btnLogin;
        private MetroFramework.Controls.MetroTextBox tbSecurity;
        private MetroFramework.Controls.MetroCheckBox chkPlanResultKR;
        private MetroFramework.Controls.MetroCheckBox chkSignalComplication;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroCheckBox chkRealBoard;
        private MetroFramework.Controls.MetroCheckBox chkPlanResultFF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}