namespace OM.Atman.Chakra.App.Forms
{
    partial class AtmanInvCalculatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmanInvCalculatorForm));
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.uc_QuantityCalculator1 = new OM.Atman.Chakra.App.Uc.Calculators.Uc_QuantityCalculator();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.White;
            this.metroPanel2.Controls.Add(this.uc_QuantityCalculator1);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(20, 30);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(386, 307);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.UseCustomForeColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // uc_QuantityCalculator1
            // 
            this.uc_QuantityCalculator1.BackColor = System.Drawing.Color.White;
            this.uc_QuantityCalculator1.Location = new System.Drawing.Point(3, 0);
            this.uc_QuantityCalculator1.Name = "uc_QuantityCalculator1";
            this.uc_QuantityCalculator1.Size = new System.Drawing.Size(387, 307);
            this.uc_QuantityCalculator1.TabIndex = 0;
            // 
            // AtmanInvCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 357);
            this.Controls.Add(this.metroPanel2);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AtmanInvCalculatorForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "ATMAN INV. F CALCULATOR";
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private Uc.Calculators.Uc_QuantityCalculator uc_QuantityCalculator1;
    }
}