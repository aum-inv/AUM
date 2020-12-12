namespace OM.Jiva.Chakra.App
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
            this.btnAnalysis1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAnalysis2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPwd
            // 
            this.tbPwd.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbPwd.Location = new System.Drawing.Point(11, 78);
            this.tbPwd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '$';
            this.tbPwd.Size = new System.Drawing.Size(235, 38);
            this.tbPwd.TabIndex = 1;
            this.tbPwd.Text = "atman999";
            this.tbPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPwd.TextChanged += new System.EventHandler(this.tbPwd_TextChanged);
            this.tbPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoginForm_KeyDown);
            // 
            // btnAnalysis1
            // 
            this.btnAnalysis1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis1.ForeColor = System.Drawing.Color.Blue;
            this.btnAnalysis1.Location = new System.Drawing.Point(251, 78);
            this.btnAnalysis1.Name = "btnAnalysis1";
            this.btnAnalysis1.Size = new System.Drawing.Size(95, 38);
            this.btnAnalysis1.TabIndex = 9;
            this.btnAnalysis1.Text = "Analysis-1";
            this.btnAnalysis1.UseVisualStyleBackColor = true;
            this.btnAnalysis1.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(11, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 38);
            this.button2.TabIndex = 10;
            this.button2.Text = "Create History";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnAnalysis2
            // 
            this.btnAnalysis2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalysis2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAnalysis2.ForeColor = System.Drawing.Color.Blue;
            this.btnAnalysis2.Location = new System.Drawing.Point(251, 122);
            this.btnAnalysis2.Name = "btnAnalysis2";
            this.btnAnalysis2.Size = new System.Drawing.Size(95, 38);
            this.btnAnalysis2.TabIndex = 11;
            this.btnAnalysis2.Text = "Analysis-2";
            this.btnAnalysis2.UseVisualStyleBackColor = true;
            this.btnAnalysis2.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(131, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Create Pattern";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 172);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAnalysis2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnAnalysis1);
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
        private System.Windows.Forms.Button btnAnalysis1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAnalysis2;
        private System.Windows.Forms.Button button1;
    }
}