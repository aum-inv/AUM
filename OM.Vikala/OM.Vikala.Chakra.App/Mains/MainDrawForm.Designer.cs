﻿namespace OM.Vikala.Chakra.App.Mains
{
    partial class MainDrawForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDrawForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_L_Red = new System.Windows.Forms.ToolStripButton();
            this.tsb_L_Blue = new System.Windows.Forms.ToolStripButton();
            this.tsb_L_Black = new System.Windows.Forms.ToolStripButton();
            this.tsb_L_Magenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_R_Red = new System.Windows.Forms.ToolStripButton();
            this.tsb_R_Blue = new System.Windows.Forms.ToolStripButton();
            this.tsb_R_Black = new System.Windows.Forms.ToolStripButton();
            this.tsb_R_Magenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCopy,
            this.toolStripSeparator2,
            this.tsb_L_Red,
            this.tsb_L_Blue,
            this.tsb_L_Black,
            this.tsb_L_Magenta,
            this.toolStripSeparator1,
            this.tsb_R_Red,
            this.tsb_R_Blue,
            this.tsb_R_Black,
            this.tsb_R_Magenta,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripButton7,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1182, 33);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.AutoSize = false;
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(50, 30);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.AutoSize = false;
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(50, 30);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // tsb_L_Red
            // 
            this.tsb_L_Red.AutoSize = false;
            this.tsb_L_Red.Checked = true;
            this.tsb_L_Red.CheckOnClick = true;
            this.tsb_L_Red.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsb_L_Red.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_L_Red.ForeColor = System.Drawing.Color.Red;
            this.tsb_L_Red.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_L_Red.Name = "tsb_L_Red";
            this.tsb_L_Red.Size = new System.Drawing.Size(30, 30);
            this.tsb_L_Red.Text = "/";
            this.tsb_L_Red.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_L_Blue
            // 
            this.tsb_L_Blue.AutoSize = false;
            this.tsb_L_Blue.CheckOnClick = true;
            this.tsb_L_Blue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_L_Blue.ForeColor = System.Drawing.Color.Blue;
            this.tsb_L_Blue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_L_Blue.Name = "tsb_L_Blue";
            this.tsb_L_Blue.Size = new System.Drawing.Size(30, 30);
            this.tsb_L_Blue.Text = "/";
            this.tsb_L_Blue.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_L_Black
            // 
            this.tsb_L_Black.AutoSize = false;
            this.tsb_L_Black.CheckOnClick = true;
            this.tsb_L_Black.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_L_Black.ForeColor = System.Drawing.Color.Black;
            this.tsb_L_Black.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_L_Black.Name = "tsb_L_Black";
            this.tsb_L_Black.Size = new System.Drawing.Size(30, 30);
            this.tsb_L_Black.Text = "/";
            this.tsb_L_Black.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_L_Magenta
            // 
            this.tsb_L_Magenta.AutoSize = false;
            this.tsb_L_Magenta.CheckOnClick = true;
            this.tsb_L_Magenta.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_L_Magenta.ForeColor = System.Drawing.Color.Magenta;
            this.tsb_L_Magenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_L_Magenta.Name = "tsb_L_Magenta";
            this.tsb_L_Magenta.Size = new System.Drawing.Size(30, 30);
            this.tsb_L_Magenta.Text = "/";
            this.tsb_L_Magenta.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // tsb_R_Red
            // 
            this.tsb_R_Red.AutoSize = false;
            this.tsb_R_Red.CheckOnClick = true;
            this.tsb_R_Red.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_R_Red.ForeColor = System.Drawing.Color.Red;
            this.tsb_R_Red.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_R_Red.Name = "tsb_R_Red";
            this.tsb_R_Red.Size = new System.Drawing.Size(30, 30);
            this.tsb_R_Red.Text = "▣";
            this.tsb_R_Red.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_R_Blue
            // 
            this.tsb_R_Blue.AutoSize = false;
            this.tsb_R_Blue.CheckOnClick = true;
            this.tsb_R_Blue.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_R_Blue.ForeColor = System.Drawing.Color.Blue;
            this.tsb_R_Blue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_R_Blue.Name = "tsb_R_Blue";
            this.tsb_R_Blue.Size = new System.Drawing.Size(30, 30);
            this.tsb_R_Blue.Text = "▣";
            this.tsb_R_Blue.ToolTipText = "▣";
            this.tsb_R_Blue.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_R_Black
            // 
            this.tsb_R_Black.AutoSize = false;
            this.tsb_R_Black.CheckOnClick = true;
            this.tsb_R_Black.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_R_Black.ForeColor = System.Drawing.Color.Black;
            this.tsb_R_Black.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_R_Black.Name = "tsb_R_Black";
            this.tsb_R_Black.Size = new System.Drawing.Size(30, 30);
            this.tsb_R_Black.Text = "▣";
            this.tsb_R_Black.ToolTipText = "▣";
            this.tsb_R_Black.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // tsb_R_Magenta
            // 
            this.tsb_R_Magenta.AutoSize = false;
            this.tsb_R_Magenta.CheckOnClick = true;
            this.tsb_R_Magenta.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.tsb_R_Magenta.ForeColor = System.Drawing.Color.Magenta;
            this.tsb_R_Magenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_R_Magenta.Name = "tsb_R_Magenta";
            this.tsb_R_Magenta.Size = new System.Drawing.Size(30, 30);
            this.tsb_R_Magenta.Text = "▣";
            this.tsb_R_Magenta.Click += new System.EventHandler(this.tsb_Pen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 30);
            this.toolStripButton1.Tag = "L";
            this.toolStripButton1.Text = "Remove Lines";
            this.toolStripButton1.Click += new System.EventHandler(this.tsb_Remove_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(115, 30);
            this.toolStripButton7.Tag = "R";
            this.toolStripButton7.Text = "Remove Rectangles";
            this.toolStripButton7.Click += new System.EventHandler(this.tsb_Remove_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(78, 30);
            this.toolStripButton3.Tag = "A";
            this.toolStripButton3.Text = "Remove ALL";
            this.toolStripButton3.Click += new System.EventHandler(this.tsb_Remove_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.picCanvas);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 33);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1182, 724);
            this.pnlContent.TabIndex = 1;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1182, 724);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove_NotDown);
            // 
            // MainDrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 757);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainDrawForm";
            this.Text = "EDIT IMAGE";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainDrawForm_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainDrawForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainDrawForm_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.ToolStripButton tsb_L_Red;
        private System.Windows.Forms.ToolStripButton tsb_L_Blue;
        private System.Windows.Forms.ToolStripButton tsb_L_Black;
        private System.Windows.Forms.ToolStripButton tsb_L_Magenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsb_R_Red;
        private System.Windows.Forms.ToolStripButton tsb_R_Blue;
        private System.Windows.Forms.ToolStripButton tsb_R_Black;
        private System.Windows.Forms.ToolStripButton tsb_R_Magenta;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
    }
}