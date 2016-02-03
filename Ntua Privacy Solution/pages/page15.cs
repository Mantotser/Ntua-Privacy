using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WizardFormLib;

namespace Ntua_Privacy_Solution
{
    public partial class page15 : WizardFormLib.WizardPage
    {
        public page15(WizardFormBase parent)
                    : base(parent)
        {
            InitPage();
        }

        public page15(WizardFormBase parent, WizardPageType pageType)
                    : base(parent, pageType)
        {
            InitPage();
        }

        public void InitPage()
        {
            ButtonStateNext &= ~WizardButtonState.Enabled;
            InitializeComponent();
            base.Size = this.Size;
            base.Title = "Εργαστήριο Συστημάτων Αποφάσεων και Διοίκησης";
            base.Subtitle = "Κατηγορία: Προστασία Αποκάλυψης Παρουσίας στον Πίνακα";
            this.ParentWizardForm.DiscoverPagePanelSize(this.Size);
            Size parentPanel = this.ParentWizardForm.PagePanelSize;
            int x = (int)((parentPanel.Width - this.groupBox1.Width) * 0.5);
            int y = (int)((parentPanel.Height - this.groupBox1.Height) * 0.5);
            this.groupBox1.Location = new Point(x, y);
        }

        public override bool SaveData()
        {
            return true;
        }

        public override WizardPage GetNextPage()
        {
            if (NextPages.Count != 2)
            {
                throw new WizardFormException("Page 15 expects two \"next\" pages to be specified.");
            }
            if (this.radioButton1.Checked)
            {
                return NextPages[0];
            }
            else
            {
                return NextPages[1];
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ButtonStateNext |= WizardButtonState.Enabled;
            ParentWizardForm.UpdateWizardForm(this);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ButtonStateNext |= WizardButtonState.Enabled;
            ParentWizardForm.UpdateWizardForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Για περισσότερες πληροφόρίες σας παραπέμπουμε στις οδηγίες σελίδα 4 στο κάτω μέρος", "Παραπομπή", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation );
        }
    }
}
