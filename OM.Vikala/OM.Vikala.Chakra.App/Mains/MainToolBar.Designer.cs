namespace OM.Vikala.Chakra.App.Mains
{
    partial class MainToolBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainToolBar));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbLeft = new System.Windows.Forms.ToolStripButton();
            this.tsbRight = new System.Windows.Forms.ToolStripButton();
            this.tsbTop = new System.Windows.Forms.ToolStripButton();
            this.tsbBottom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Atom = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Quantum = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Velocity = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_AntiMatter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_Dice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_ANode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_TimeSpace = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_MA1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_SY_3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLeft,
            this.tsbRight,
            this.tsbTop,
            this.tsbBottom,
            this.toolStripSeparator5,
            this.tsbExit,
            this.toolStripSeparator3,
            this.toolStripSeparator1,
            this.tsb_Atom,
            this.toolStripSeparator7,
            this.tsb_Quantum,
            this.toolStripSeparator8,
            this.tsb_Velocity,
            this.toolStripSeparator9,
            this.tsb_AntiMatter,
            this.toolStripSeparator10,
            this.tsb_Dice,
            this.toolStripSeparator11,
            this.tsb_ANode,
            this.toolStripSeparator12,
            this.tsb_TimeSpace,
            this.toolStripSeparator2,
            this.toolStripSeparator13,
            this.tsb_MA1,
            this.toolStripSeparator15,
            this.tsb_SY_3,
            this.toolStripSeparator17});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(35, 800);
            this.tsMain.TabIndex = 0;
            // 
            // tsbLeft
            // 
            this.tsbLeft.AutoSize = false;
            this.tsbLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsbLeft.Image")));
            this.tsbLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLeft.Name = "tsbLeft";
            this.tsbLeft.Size = new System.Drawing.Size(30, 28);
            this.tsbLeft.Text = "◀";
            this.tsbLeft.ToolTipText = "Left";
            this.tsbLeft.Click += new System.EventHandler(this.toolbarDock_Click);
            // 
            // tsbRight
            // 
            this.tsbRight.AutoSize = false;
            this.tsbRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRight.Image = ((System.Drawing.Image)(resources.GetObject("tsbRight.Image")));
            this.tsbRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRight.Name = "tsbRight";
            this.tsbRight.Size = new System.Drawing.Size(30, 28);
            this.tsbRight.Text = "▶";
            this.tsbRight.ToolTipText = "Right";
            this.tsbRight.Click += new System.EventHandler(this.toolbarDock_Click);
            // 
            // tsbTop
            // 
            this.tsbTop.AutoSize = false;
            this.tsbTop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTop.Image = ((System.Drawing.Image)(resources.GetObject("tsbTop.Image")));
            this.tsbTop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTop.Name = "tsbTop";
            this.tsbTop.Size = new System.Drawing.Size(30, 28);
            this.tsbTop.Text = "▲";
            this.tsbTop.ToolTipText = "Top";
            this.tsbTop.Click += new System.EventHandler(this.toolbarDock_Click);
            // 
            // tsbBottom
            // 
            this.tsbBottom.AutoSize = false;
            this.tsbBottom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBottom.Image = ((System.Drawing.Image)(resources.GetObject("tsbBottom.Image")));
            this.tsbBottom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBottom.Name = "tsbBottom";
            this.tsbBottom.Size = new System.Drawing.Size(30, 28);
            this.tsbBottom.Text = "▼";
            this.tsbBottom.ToolTipText = "Bottom";
            this.tsbBottom.Click += new System.EventHandler(this.toolbarDock_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(32, 6);
            // 
            // tsbExit
            // 
            this.tsbExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbExit.AutoSize = false;
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(34, 36);
            this.tsbExit.Text = "Ｘ";
            this.tsbExit.ToolTipText = "종료";
            this.tsbExit.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(32, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_Atom
            // 
            this.tsb_Atom.AutoSize = false;
            this.tsb_Atom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tsb_Atom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Atom.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_Atom.ForeColor = System.Drawing.Color.White;
            this.tsb_Atom.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_Atom.Name = "tsb_Atom";
            this.tsb_Atom.Size = new System.Drawing.Size(30, 30);
            this.tsb_Atom.Text = "원자";
            this.tsb_Atom.ToolTipText = "원자챠트";
            this.tsb_Atom.Click += new System.EventHandler(this.tsb_Atom_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_Quantum
            // 
            this.tsb_Quantum.AutoSize = false;
            this.tsb_Quantum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tsb_Quantum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Quantum.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_Quantum.ForeColor = System.Drawing.Color.White;
            this.tsb_Quantum.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_Quantum.Name = "tsb_Quantum";
            this.tsb_Quantum.Size = new System.Drawing.Size(30, 30);
            this.tsb_Quantum.Text = "양자";
            this.tsb_Quantum.ToolTipText = "양자챠트";
            this.tsb_Quantum.Click += new System.EventHandler(this.tsb_Quantum_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_Velocity
            // 
            this.tsb_Velocity.AutoSize = false;
            this.tsb_Velocity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tsb_Velocity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Velocity.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_Velocity.ForeColor = System.Drawing.Color.White;
            this.tsb_Velocity.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_Velocity.Name = "tsb_Velocity";
            this.tsb_Velocity.Size = new System.Drawing.Size(30, 30);
            this.tsb_Velocity.Text = "변화";
            this.tsb_Velocity.ToolTipText = "변화챠트";
            this.tsb_Velocity.Click += new System.EventHandler(this.tsb_Velocity_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_AntiMatter
            // 
            this.tsb_AntiMatter.AutoSize = false;
            this.tsb_AntiMatter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.tsb_AntiMatter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_AntiMatter.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_AntiMatter.ForeColor = System.Drawing.Color.White;
            this.tsb_AntiMatter.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_AntiMatter.Name = "tsb_AntiMatter";
            this.tsb_AntiMatter.Size = new System.Drawing.Size(30, 30);
            this.tsb_AntiMatter.Text = "반입";
            this.tsb_AntiMatter.ToolTipText = "반입자챠트";
            this.tsb_AntiMatter.Click += new System.EventHandler(this.tsb_AntiMatter_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_Dice
            // 
            this.tsb_Dice.AutoSize = false;
            this.tsb_Dice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tsb_Dice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_Dice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_Dice.ForeColor = System.Drawing.Color.White;
            this.tsb_Dice.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_Dice.Name = "tsb_Dice";
            this.tsb_Dice.Size = new System.Drawing.Size(30, 30);
            this.tsb_Dice.Text = "주사";
            this.tsb_Dice.ToolTipText = "주사위챠트";
            this.tsb_Dice.Click += new System.EventHandler(this.tsb_Dice_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_ANode
            // 
            this.tsb_ANode.AutoSize = false;
            this.tsb_ANode.BackColor = System.Drawing.Color.Navy;
            this.tsb_ANode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_ANode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_ANode.ForeColor = System.Drawing.Color.White;
            this.tsb_ANode.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_ANode.Name = "tsb_ANode";
            this.tsb_ANode.Size = new System.Drawing.Size(30, 30);
            this.tsb_ANode.Text = "양극";
            this.tsb_ANode.ToolTipText = "양극챠트";
            this.tsb_ANode.Click += new System.EventHandler(this.tsb_ANode_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_TimeSpace
            // 
            this.tsb_TimeSpace.AutoSize = false;
            this.tsb_TimeSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tsb_TimeSpace.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_TimeSpace.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_TimeSpace.ForeColor = System.Drawing.Color.White;
            this.tsb_TimeSpace.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_TimeSpace.Name = "tsb_TimeSpace";
            this.tsb_TimeSpace.Size = new System.Drawing.Size(30, 30);
            this.tsb_TimeSpace.Text = "시공";
            this.tsb_TimeSpace.ToolTipText = "비교챠트";
            this.tsb_TimeSpace.Click += new System.EventHandler(this.tsb_TimeSpace_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(32, 6);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_MA1
            // 
            this.tsb_MA1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tsb_MA1.AutoSize = false;
            this.tsb_MA1.BackColor = System.Drawing.Color.Black;
            this.tsb_MA1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_MA1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_MA1.ForeColor = System.Drawing.Color.White;
            this.tsb_MA1.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_MA1.Name = "tsb_MA1";
            this.tsb_MA1.Size = new System.Drawing.Size(30, 30);
            this.tsb_MA1.Text = "이평";
            this.tsb_MA1.ToolTipText = "이평캔들";
            this.tsb_MA1.Click += new System.EventHandler(this.tsb_MA_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(32, 6);
            // 
            // tsb_SY_3
            // 
            this.tsb_SY_3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tsb_SY_3.AutoSize = false;
            this.tsb_SY_3.BackColor = System.Drawing.Color.White;
            this.tsb_SY_3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb_SY_3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.tsb_SY_3.ForeColor = System.Drawing.Color.Black;
            this.tsb_SY_3.ImageTransparentColor = System.Drawing.Color.White;
            this.tsb_SY_3.Name = "tsb_SY_3";
            this.tsb_SY_3.Size = new System.Drawing.Size(30, 30);
            this.tsb_SY_3.Text = "누평";
            this.tsb_SY_3.ToolTipText = "이동평균기간(가중-3)";
            this.tsb_SY_3.Click += new System.EventHandler(this.tsb_SYN_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(32, 6);
            // 
            // MainToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(36, 800);
            this.Controls.Add(this.tsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainToolBar";
            this.Text = "ATMAN INV. F CHART";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLeft;
        private System.Windows.Forms.ToolStripButton tsbRight;
        private System.Windows.Forms.ToolStripButton tsbTop;
        private System.Windows.Forms.ToolStripButton tsbBottom;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsb_Atom;
        private System.Windows.Forms.ToolStripButton tsb_Quantum;
        private System.Windows.Forms.ToolStripButton tsb_Velocity;
        private System.Windows.Forms.ToolStripButton tsb_AntiMatter;
        private System.Windows.Forms.ToolStripButton tsb_Dice;
        private System.Windows.Forms.ToolStripButton tsb_ANode;
        private System.Windows.Forms.ToolStripButton tsb_TimeSpace;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsb_SY_3;
        private System.Windows.Forms.ToolStripButton tsb_MA1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
    }
}