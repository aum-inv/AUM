﻿namespace OM.Vikala.Chakra.App.Mains
{
    partial class TrendMinuteChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrendMinuteChartForm));
            this.button1 = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.flowTable = new System.Windows.Forms.TableLayoutPanel();
            this.userToolStrip1 = new OM.Vikala.Chakra.App.Mains.UserToolStrip();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.Controls.Add(this.flowTable);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 46);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(2566, 1014);
            this.pnlContent.TabIndex = 4;
            // 
            // flowTable
            // 
            this.flowTable.ColumnCount = 2;
            this.flowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.flowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowTable.Location = new System.Drawing.Point(0, 0);
            this.flowTable.Margin = new System.Windows.Forms.Padding(4);
            this.flowTable.Name = "flowTable";
            this.flowTable.RowCount = 3;
            this.flowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flowTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.flowTable.Size = new System.Drawing.Size(2566, 1014);
            this.flowTable.TabIndex = 3;
            // 
            // userToolStrip1
            // 
            this.userToolStrip1.AutoSize = true;
            this.userToolStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.userToolStrip1.IsVisibleAlignmentButton = true;
            this.userToolStrip1.IsVisibleMdiButton = true;
            this.userToolStrip1.IsVisibleTimeIntervalButton = true;
            this.userToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.userToolStrip1.Margin = new System.Windows.Forms.Padding(2);
            this.userToolStrip1.Name = "userToolStrip1";
            this.userToolStrip1.Size = new System.Drawing.Size(2566, 46);
            this.userToolStrip1.TabIndex = 0;
            // 
            // TrendMinuteChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(2566, 1060);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.userToolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrendMinuteChartForm";
            this.Text = "분_추세챠트";
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserToolStrip userToolStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.TableLayoutPanel flowTable;
    }
}