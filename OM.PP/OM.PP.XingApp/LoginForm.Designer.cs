using MetroFramework.Controls;

namespace OM.PP.XingApp
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
            this.tbPwd = new MetroFramework.Controls.MetroTextBox();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            // 
            // 
            // 
            this.tbPwd.CustomButton.Image = null;
            this.tbPwd.CustomButton.Location = new System.Drawing.Point(121, 1);
            this.tbPwd.CustomButton.Name = "";
            this.tbPwd.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.tbPwd.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbPwd.CustomButton.TabIndex = 1;
            this.tbPwd.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbPwd.CustomButton.UseSelectable = true;
            this.tbPwd.CustomButton.Visible = false;
            this.tbPwd.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.tbPwd.Lines = new string[] {
        "^__^"};
            this.tbPwd.Location = new System.Drawing.Point(12, 83);
            this.tbPwd.MaxLength = 32767;
            this.tbPwd.Multiline = true;
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '#';
            this.tbPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbPwd.SelectedText = "";
            this.tbPwd.SelectionLength = 0;
            this.tbPwd.SelectionStart = 0;
            this.tbPwd.ShortcutsEnabled = true;
            this.tbPwd.Size = new System.Drawing.Size(141, 21);
            this.tbPwd.TabIndex = 8;
            this.tbPwd.Text = "^__^";
            this.tbPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPwd.UseSelectable = true;
            this.tbPwd.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbPwd.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(175, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "로 그 인";
            this.button1.UseSelectable = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(267, 112);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbPwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "XING LOGIN";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroTextBox tbPwd;
        private MetroButton button1;
    }
}