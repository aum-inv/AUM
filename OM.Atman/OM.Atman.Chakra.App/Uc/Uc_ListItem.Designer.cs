namespace OM.Atman.Chakra.App.Uc
{
    partial class Uc_ListItem
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemType = new MetroFramework.Controls.MetroTile();
            this.itemTitle = new MetroFramework.Controls.MetroLabel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.itemIncoming = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // itemType
            // 
            this.itemType.ActiveControl = null;
            this.itemType.Dock = System.Windows.Forms.DockStyle.Left;
            this.itemType.Location = new System.Drawing.Point(2, 2);
            this.itemType.Name = "itemType";
            this.itemType.Size = new System.Drawing.Size(65, 39);
            this.itemType.TabIndex = 1;
            this.itemType.Text = "국내지수";
            this.itemType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.itemType.TileTextFontSize = MetroFramework.MetroTileTextSize.Small;
            this.itemType.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.itemType.UseSelectable = true;
            this.itemType.MouseClick += new System.Windows.Forms.MouseEventHandler(this.item_MouseClick);
            this.itemType.MouseEnter += new System.EventHandler(this.item_MouseEnter);
            this.itemType.MouseLeave += new System.EventHandler(this.item_MouseLeave);
            // 
            // itemTitle
            // 
            this.itemTitle.AutoSize = true;
            this.itemTitle.FontSize = MetroFramework.MetroLabelSize.Small;
            this.itemTitle.Location = new System.Drawing.Point(70, 4);
            this.itemTitle.Name = "itemTitle";
            this.itemTitle.Size = new System.Drawing.Size(143, 15);
            this.itemTitle.TabIndex = 2;
            this.itemTitle.Text = "2020/10/10 투자계획 (종료)";
            this.itemTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.item_MouseClick);
            this.itemTitle.MouseEnter += new System.EventHandler(this.item_MouseEnter);
            this.itemTitle.MouseLeave += new System.EventHandler(this.item_MouseLeave);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.OldLace;
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(67, 38);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(164, 3);
            this.pnlBottom.TabIndex = 5;
            // 
            // itemIncoming
            // 
            this.itemIncoming.AutoSize = true;
            this.itemIncoming.FontSize = MetroFramework.MetroLabelSize.Small;
            this.itemIncoming.Location = new System.Drawing.Point(71, 22);
            this.itemIncoming.Name = "itemIncoming";
            this.itemIncoming.Size = new System.Drawing.Size(88, 15);
            this.itemIncoming.TabIndex = 3;
            this.itemIncoming.Text = "수익율 : 200%   ";
            this.itemIncoming.MouseClick += new System.Windows.Forms.MouseEventHandler(this.item_MouseClick);
            this.itemIncoming.MouseEnter += new System.EventHandler(this.item_MouseEnter);
            this.itemIncoming.MouseLeave += new System.EventHandler(this.item_MouseLeave);
            // 
            // Uc_ListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.itemIncoming);
            this.Controls.Add(this.itemTitle);
            this.Controls.Add(this.itemType);
            this.Name = "Uc_ListItem";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(233, 43);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.item_MouseClick);
            this.MouseEnter += new System.EventHandler(this.item_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.item_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroTile itemType;
        private MetroFramework.Controls.MetroLabel itemTitle;
        private System.Windows.Forms.Panel pnlBottom;
        private MetroFramework.Controls.MetroLabel itemIncoming;
    }
}
