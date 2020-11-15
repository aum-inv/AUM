namespace OM.Atman.Chakra.App.PlanForms
{
    partial class StrategyPlanHtmlCreationForm
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
            BaiqiSoft.HtmlEditorControl.FormatHtmlOptions formatHtmlOptions1 = new BaiqiSoft.HtmlEditorControl.FormatHtmlOptions();
            this.htmlCtr = new BaiqiSoft.HtmlEditorControl.MstHtmlEditor();
            this.SuspendLayout();
            // 
            // htmlCtr
            // 
            this.htmlCtr.Dock = System.Windows.Forms.DockStyle.Fill;
            formatHtmlOptions1.BreakBeforeBR = true;
            formatHtmlOptions1.ClosingSingleTags = true;
            formatHtmlOptions1.IndentHtmlTags = true;
            formatHtmlOptions1.IndentScript = true;
            formatHtmlOptions1.IndentSpaces = 4;
            formatHtmlOptions1.IndentWithTabs = false;
            formatHtmlOptions1.LowercaseTags = true;
            formatHtmlOptions1.QuoteAttributeValues = true;
            this.htmlCtr.FormatHtmlOptions = formatHtmlOptions1;
            this.htmlCtr.LanguageConfig = null;
            this.htmlCtr.Location = new System.Drawing.Point(0, 0);
            this.htmlCtr.Name = "htmlCtr";
            this.htmlCtr.SelectionLength = 0;
            this.htmlCtr.SelectionStart = 0;
            this.htmlCtr.Size = new System.Drawing.Size(1179, 673);
            this.htmlCtr.TabIndex = 0;
            // 
            // StrategyPlanHtmlCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 673);
            this.Controls.Add(this.htmlCtr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StrategyPlanHtmlCreationForm";
            this.Text = "HTML";
            this.ResumeLayout(false);

        }

        #endregion

        private BaiqiSoft.HtmlEditorControl.MstHtmlEditor htmlCtr;
    }
}