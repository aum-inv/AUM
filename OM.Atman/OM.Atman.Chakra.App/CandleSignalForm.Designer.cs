﻿namespace OM.Atman.Chakra.App
{
    partial class CandleSignalForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CandleSignalForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.nIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.종류 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.신호시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.시간 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.갯수 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.타입 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 25;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종류,
            this.신호시간,
            this.종목,
            this.시간,
            this.갯수,
            this.타입});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(678, 312);
            this.dgv.TabIndex = 2;
            // 
            // nIcon
            // 
            this.nIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nIcon.BalloonTipText = "CANDLE SIGNAL";
            this.nIcon.BalloonTipTitle = "CANDLE SIGNAL";
            this.nIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nIcon.Icon")));
            this.nIcon.Text = "ATMAN SIGNAL";
            this.nIcon.Visible = true;
            // 
            // 종류
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.종류.DefaultCellStyle = dataGridViewCellStyle2;
            this.종류.Frozen = true;
            this.종류.HeaderText = "종류";
            this.종류.Name = "종류";
            this.종류.ReadOnly = true;
            // 
            // 신호시간
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.신호시간.DefaultCellStyle = dataGridViewCellStyle3;
            this.신호시간.Frozen = true;
            this.신호시간.HeaderText = "신호시간";
            this.신호시간.Name = "신호시간";
            this.신호시간.ReadOnly = true;
            this.신호시간.Width = 150;
            // 
            // 종목
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.종목.DefaultCellStyle = dataGridViewCellStyle4;
            this.종목.Frozen = true;
            this.종목.HeaderText = "종목";
            this.종목.Name = "종목";
            this.종목.ReadOnly = true;
            this.종목.Width = 80;
            // 
            // 시간
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.시간.DefaultCellStyle = dataGridViewCellStyle5;
            this.시간.Frozen = true;
            this.시간.HeaderText = "시간";
            this.시간.Name = "시간";
            this.시간.ReadOnly = true;
            this.시간.Width = 80;
            // 
            // 갯수
            // 
            this.갯수.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.갯수.DefaultCellStyle = dataGridViewCellStyle6;
            this.갯수.HeaderText = "시그널";
            this.갯수.Name = "갯수";
            this.갯수.ReadOnly = true;
            // 
            // 타입
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.타입.DefaultCellStyle = dataGridViewCellStyle7;
            this.타입.HeaderText = "타입";
            this.타입.Name = "타입";
            this.타입.ReadOnly = true;
            this.타입.Width = 80;
            // 
            // CandleSignalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(678, 312);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CandleSignalForm";
            this.Text = "CandleSignalForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.NotifyIcon nIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종류;
        private System.Windows.Forms.DataGridViewTextBoxColumn 신호시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목;
        private System.Windows.Forms.DataGridViewTextBoxColumn 시간;
        private System.Windows.Forms.DataGridViewTextBoxColumn 갯수;
        private System.Windows.Forms.DataGridViewTextBoxColumn 타입;
    }
}