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
    public partial class page1 : WizardFormLib.WizardPage
    {
        //θεωρω πως η σελιδα ειναι intermediate
        public page1(WizardFormBase parent)
                    : base(parent)
        {
            InitPage();
        }

        //εδω δεχεται και τον τυπο της σελιδας
        public page1(WizardFormBase parent, WizardPageType pageType)
                    : base(parent, pageType)
        {
            InitPage();
        }

        //κουμπι επόμενο δεν ενεργοποιειται μεχρι πατημα checkbox, χτιζεται η σελιδα και το μέγεθος χτιζεται αυτοματα με βάση την μεγαλυτερη σελιδα,
        //ορισμος επικεφαλιδων,υπολογισμος πλαισιου και τοποθετηση groupbox ακριβως στην μεση
        public void InitPage()
        {
            ButtonStateNext &= ~WizardButtonState.Enabled;
            InitializeComponent();
            Size = this.Size;
            Title = "Εργαστήριο Συστημάτων Αποφάσεων και Διοίκησης";
            Subtitle = "Προσδιορισμός Κατηγορίας Μοντέλου";
            ParentWizardForm.DiscoverPagePanelSize(this.Size);
            Size parentPanel = this.ParentWizardForm.PagePanelSize;
            int x = (int)((parentPanel.Width - this.groupBox1.Width) * 0.5);
            int y = (int)((parentPanel.Height - this.groupBox1.Height) * 0.5);
            groupBox1.Location = new Point(x, y);
        }

        //αποθηκευω την σελιδα
        public override bool SaveData()
        {
            return true;
        }

        //επιλογη σελιδας πρωτης η δευτερης
        public override WizardPage GetNextPage()
        {
            // επιβεβαιωση πως εχω προσθεση δυο σελιδες για επιλογη
            if (NextPages.Count != 2)
            {
                throw new WizardFormException("Η σελίδα 1 αναμένει τις 2 επόμενες σελίδες για να οριστεί.");
            }
            // επιλογη
            if (this.radioButton1.Checked)
            {
                return NextPages[0];
            }
            else
            {
                return NextPages[1];
            }
        }

        //ενεργοποιειται το κουμπι επόμενο οταν πατιεται το radiobutton1
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ButtonStateNext |= WizardButtonState.Enabled;
            ParentWizardForm.UpdateWizardForm(this);
        }

        //ενεργοποιειται το κουμπι επόμενο οταν πατιεται το radiobutton1
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ButtonStateNext |= WizardButtonState.Enabled;
            ParentWizardForm.UpdateWizardForm(this);
        }

    }
}
