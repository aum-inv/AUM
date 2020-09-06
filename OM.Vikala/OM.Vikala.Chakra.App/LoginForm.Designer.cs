namespace OM.Vikala.Chakra.App
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
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnLogin2 = new System.Windows.Forms.Button();
            this.chkStartWindowType = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            this.tbPwd.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPwd.Location = new System.Drawing.Point(93, 93);
            this.tbPwd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '$';
            this.tbPwd.Size = new System.Drawing.Size(217, 38);
            this.tbPwd.TabIndex = 1;
            this.tbPwd.Text = "atman999";
            this.tbPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPwd.TextChanged += new System.EventHandler(this.tbPwd_TextChanged);
            this.tbPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.Color.Green;
            this.btnLogin.Location = new System.Drawing.Point(93, 169);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(102, 49);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "국내지수";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLogin2
            // 
            this.btnLogin2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin2.ForeColor = System.Drawing.Color.Fuchsia;
            this.btnLogin2.Location = new System.Drawing.Point(215, 169);
            this.btnLogin2.Name = "btnLogin2";
            this.btnLogin2.Size = new System.Drawing.Size(95, 49);
            this.btnLogin2.TabIndex = 5;
            this.btnLogin2.Text = "해외지수";
            this.btnLogin2.UseVisualStyleBackColor = true;
            this.btnLogin2.Click += new System.EventHandler(this.btnLogin2_Click);
            // 
            // chkStartWindowType
            // 
            this.chkStartWindowType.AutoSize = true;
            this.chkStartWindowType.BackColor = System.Drawing.Color.White;
            this.chkStartWindowType.Checked = true;
            this.chkStartWindowType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartWindowType.Depth = 0;
            this.chkStartWindowType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStartWindowType.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkStartWindowType.Location = new System.Drawing.Point(128, 135);
            this.chkStartWindowType.Margin = new System.Windows.Forms.Padding(0);
            this.chkStartWindowType.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkStartWindowType.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkStartWindowType.Name = "chkStartWindowType";
            this.chkStartWindowType.Ripple = true;
            this.chkStartWindowType.Size = new System.Drawing.Size(143, 30);
            this.chkStartWindowType.TabIndex = 6;
            this.chkStartWindowType.Text = "Start with ToolBox";
            this.chkStartWindowType.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 228);
            this.Controls.Add(this.chkStartWindowType);
            this.Controls.Add(this.btnLogin2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "ATMAN FINANCIAL INVESTMENT ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogin2;
        private MaterialSkin.Controls.MaterialCheckBox chkStartWindowType;
    }
}