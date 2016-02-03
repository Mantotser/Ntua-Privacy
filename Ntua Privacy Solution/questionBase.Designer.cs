namespace Ntua_Privacy_Solution
{
    partial class questionBase
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
            this.graphicPanelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagePanel
            // 
            this.pagePanel.Location = new System.Drawing.Point(0, 115);
            this.pagePanel.Size = new System.Drawing.Size(456, 63);
            // 
            // labelTopSeparatorLine
            // 
            this.labelTopSeparatorLine.Location = new System.Drawing.Point(0, 111);
            this.labelTopSeparatorLine.Size = new System.Drawing.Size(457, 2);
            // 
            // graphicPanelTop
            // 
            this.graphicPanelTop.Size = new System.Drawing.Size(457, 111);
            // 
            // labelBottomSeparatorLine
            // 
            this.labelBottomSeparatorLine.Size = new System.Drawing.Size(491, 2);
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(12, 186);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(391, 186);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(307, 186);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(210, 186);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(135, 186);
            // 
            // labelSubtitle
            // 
            this.labelSubtitle.Location = new System.Drawing.Point(9, 69);
            // 
            // questionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(457, 212);
            this.Name = "questionBase";
            this.Load += new System.EventHandler(this.WizardExample_Load);
            this.graphicPanelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
