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
    public partial class questionBase : WizardFormLib.WizardFormBase
    {
        page1 q1 = null;
        page2a q2a = null;
        page2b q2b = null;
        page3a q3a = null;
        page3b q3b = null;
        page4 q4 = null;
        page5 q5 = null;
        page6 q6 = null;
        page7 q7 = null;
        page8 q8 = null;
        page9 q9 = null;
        page10 q10 = null;
        page11 q11 = null;
        page12 q12 = null;
        page13 q13 = null;
        page14 q14 = null;
        page15 q15 = null;
        spage1 sq1 = null;
        spage2 sq2 = null;
        spage3 sq3 = null;
        spage4 sq4 = null;
        spage5 sq5 = null;
        spage6 sq6 = null;
        spage7 sq7 = null;
        spage8 sq8 = null;
        spage9 sq9 = null;
        spage10 sq10 = null;
        spage11 sq11 = null;
        spage12 sq12 = null;
        spage13 sq13 = null;
        spage14 sq14 = null;
        spage15 sq15 = null;
        spage16 sq16 = null;
        spage17 sq17 = null;
        spage18 sq18 = null;
        finalPage last = null;


        public questionBase()
        {
            InitializeComponent();
        }

        private void WizardExample_Load(object sender, EventArgs e)
        {
            //γραφικά στοιχεία
            this.GraphicPanelImagePosition = WizardImagePosition.Right;
            this.GraphicPanelImageResource = "Ntua_Privacy_Solution.NTUA.png";
            this.GraphicPanelGradientColor = Color.DarkSlateBlue;

            // αποκρυψη κουμπιου βοηθεια
            this.ButtonHelpHide = true;

            //προσθηκη handlers για τα κουμπια
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);

            // φτιάχνονται οι σελίδες
            q1 = new page1(this, WizardPageType.Start);
            q2a = new page2a(this);
            q2b = new page2b(this);
            q3a = new page3a(this);
            q3b = new page3b(this);
            q4 = new page4(this);
            q5 = new page5(this);
            q6 = new page6(this);
            q7 = new page7(this);
            q8 = new page8(this);
            q9 = new page9(this);
            q10 = new page10(this);
            q11 = new page11(this);
            q12 = new page12(this);
            q13 = new page13(this);
            q14 = new page14(this);
            q15 = new page15(this);
            sq1 = new spage1(this);
            sq2 = new spage2(this);
            sq3 = new spage3(this);
            sq4 = new spage4(this);
            sq5 = new spage5(this);
            sq6 = new spage6(this);
            sq7 = new spage7(this);
            sq8 = new spage8(this);
            sq9 = new spage9(this);
            sq10 = new spage10(this);
            sq11 = new spage11(this);
            sq12 = new spage12(this);
            sq13 = new spage13(this);
            sq14 = new spage14(this);
            sq15 = new spage15(this);
            sq16 = new spage16(this);
            sq17 = new spage17(this);
            sq18 = new spage18(this);
            last = new finalPage(this, WizardPageType.Stop);

            // προσθήκη handlers καθε φορα που δημιουργούνται σελίδες
            q1.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q2a.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q2b.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q3a.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q3b.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q4.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q5.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q6.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q7.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q8.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q9.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q10.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q11.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q12.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q13.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q14.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            q15.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq1.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq2.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq3.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq4.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq5.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq6.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq7.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq8.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq9.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq10.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq11.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq12.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq13.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq14.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq15.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq16.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq17.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            sq18.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);
            last.WizardPageActivated += new WizardPageActivateHandler(WizardPageActivated);


            // προσδιορισμός των επόμενων σελίδων
            q1.AddNextPage(q2b);
            q1.AddNextPage(q2a);
            q2a.AddNextPage(sq1);
            q2a.AddNextPage(q15);
            q15.AddNextPage(sq3);
            q15.AddNextPage(sq2);
            q2b.AddNextPage(q3a);
            q2b.AddNextPage(q3b);
            q3a.AddNextPage(q4);
            q3a.AddNextPage(sq5);
            q4.AddNextPage(sq6);
            q4.AddNextPage(q5);
            q5.AddNextPage(sq9);
            q5.AddNextPage(q6);
            q6.AddNextPage(sq10);
            q6.AddNextPage(q7);
            q7.AddNextPage(sq8);
            q7.AddNextPage(q8);
            q8.AddNextPage(sq4);
            q8.AddNextPage(q9);
            q9.AddNextPage(sq7);
            q9.AddNextPage(q10);
            q10.AddNextPage(sq11);
            q10.AddNextPage(sq12);
            q3b.AddNextPage(sq13);
            q3b.AddNextPage(q11);
            q11.AddNextPage(sq14);
            q11.AddNextPage(q12);
            q12.AddNextPage(sq15);
            q12.AddNextPage(q13);
            q13.AddNextPage(sq16);
            q13.AddNextPage(q14);
            q14.AddNextPage(sq17);
            q14.AddNextPage(sq18);
            sq1.AddNextPage(last);
            sq2.AddNextPage(last);
            sq3.AddNextPage(last);
            sq4.AddNextPage(last);
            sq5.AddNextPage(last);
            sq6.AddNextPage(last);
            sq7.AddNextPage(last);
            sq8.AddNextPage(last);
            sq9.AddNextPage(last);
            sq10.AddNextPage(last);
            sq11.AddNextPage(last);
            sq12.AddNextPage(last);
            sq13.AddNextPage(last);
            sq14.AddNextPage(last);
            sq15.AddNextPage(last);
            sq16.AddNextPage(last);
            sq17.AddNextPage(last);
            sq18.AddNextPage(last);

            // εναρξη wizard
            StartWizard();
        }

        //ενεργοποιείται όταν εμφανίζεται η σελίδα
        void WizardPageActivated(object sender, WizardPageActivateArgs e)
        {
            PaintTitle();
            this.buttonBack.Enabled = (e.ActivatedPage.WizardPageType != WizardPageType.Start);
            if (e.ActivatedPage.WizardPageType == WizardPageType.Stop)
            {
                this.buttonNext.Text = "Τέλος";
            }
            else
            {
                this.buttonNext.Text = "'Επόμενη >";
            }
        }

        //ενεργοποιείται οταν πατιεται το πισω
        private void buttonBack_Click(object sender, EventArgs e)
        {
            //λεει στην αλυσιδα των σελιδων να παει στην προηγουμενη
            WizardPage currentPage = PageChain.GoBack();
            //αλλαξε η σελιδα και ενημερωνει
            Raise_WizardPageChangeEvent(new WizardPageChangeArgs(currentPage, WizardStepType.Previous));
        }

        //ενεργοποιείται οταν πατιεται το επόμενο
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (PageChain.GetCurrentPage().WizardPageType == WizardPageType.Stop)
            {
                //κλεινει το προγραμμα εαν ειναι τελευταια σελιδα
                if (PageChain.SaveData() == null)
                {
                    this.Close();
                }
            }
            //αλλιώς πηγαινει στην επομενη
            else
            {
                WizardPage currentPage = PageChain.GoNext(PageChain.GetCurrentPage().GetNextPage());
                Raise_WizardPageChangeEvent(new WizardPageChangeArgs(currentPage, WizardStepType.Next));
            }
        }

        //ενεργοποιείται οταν πατιεται το ακυρο
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ενεργοποιείται οταν πατιεται η βοηθεια
        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yet.");
        }

        //ενεργοποιείται οταν πατιεται η επιστροφη στην πρωτη σελιδα
        private void buttonStart_Click(object sender, EventArgs e)
        {
            WizardPage currentPage = PageChain.GoFirst();
            //αλλαξε η σελιδα και ενημερωνει
            Raise_WizardPageChangeEvent(new WizardPageChangeArgs(currentPage, WizardStepType.Previous));
        }

    }
}

