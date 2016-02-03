using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WizardFormLib
{
	public partial class WizardPage : UserControl
	{
		#region Data members
		private WizardFormBase		m_parentWizardForm;
		private List<WizardPage>	m_nextPages				= new List<WizardPage>();
		private WizardPageType		m_pageType				= WizardPageType.Intermediate;
		private WizardStepType		m_stepType				= WizardStepType.None;
		private string				m_title					= "";
		private string				m_subtitle				= "";

		// added the following line to support the "<< Start" button - jms - 2/19/2009
		private WizardButtonState	m_buttonStateStart		= WizardButtonState.Enabled | WizardButtonState.Visible;

		private WizardButtonState	m_buttonStateBack		= WizardButtonState.Enabled | WizardButtonState.Visible;
		private WizardButtonState	m_buttonStateNext		= WizardButtonState.Enabled | WizardButtonState.Visible;
		private WizardButtonState	m_buttonStateCancel		= WizardButtonState.Enabled | WizardButtonState.Visible;
		private WizardButtonState	m_buttonStateHelp		= WizardButtonState.Enabled | WizardButtonState.Visible;
		#endregion Data members

		public event WizardPageActivateHandler WizardPageActivated;

		public string Title
		{
			get { return m_title; }
			set { m_title = value;}
		}

		public string Subtitle
		{
			get { return m_subtitle; }
			set { m_subtitle = value;}
		}

		public WizardPageType WizardPageType
		{
			get { return m_pageType; }
			set { m_pageType = value; }
		}

		public WizardFormBase ParentWizardForm
		{
			get { return m_parentWizardForm; }
		}

		public WizardButtonState ButtonStateStart
		{
			get { return m_buttonStateStart; }
			set { m_buttonStateStart = value; }
		}

		public WizardButtonState ButtonStateBack
		{
			get { return m_buttonStateBack; }
			set { m_buttonStateBack = value; }
		}

		public WizardButtonState ButtonStateNext
		{
			get { return m_buttonStateNext; }
			set { m_buttonStateNext = value; }
		}

		public WizardButtonState ButtonStateCancel
		{
			get { return m_buttonStateCancel; }
			set { m_buttonStateCancel = value; }
		}

		public WizardButtonState ButtonStateHelp
		{
			get { return m_buttonStateHelp; }
			set { m_buttonStateHelp = value; }
		}

		public List<WizardPage> NextPages
		{
			get { return m_nextPages; }
		}

		public WizardPage()
		{
			InitializeComponent();
		}

		public WizardPage(WizardFormBase parent)
		{
			Init(parent, WizardPageType.Intermediate);
		}

		public WizardPage(WizardFormBase parent, WizardPageType pageType)
		{
			Init(parent, pageType);
		}

		private void Init(WizardFormBase parent, WizardPageType pageType)
		{
			InitializeComponent();
			m_parentWizardForm	= parent;
			this.Visible		= false;
			this.Dock			= DockStyle.Fill;
			m_pageType			= pageType;

			if (WizardPageType == WizardPageType.Start)
			{
				ButtonStateStart &= ~WizardButtonState.Enabled;

				ButtonStateBack &= ~WizardButtonState.Enabled;
			}

			m_parentWizardForm.PageCreated(this);
			m_parentWizardForm.WizardPageChangeEvent += new WizardPageChangeHandler(parentForm_WizardPageChange);
		}

		public void AddNextPage(WizardPage nextPage)
		{
			m_nextPages.Add(nextPage);
		}

		protected void Raise_WizardPageActivated(WizardPageActivateArgs e)
		{
			WizardPageActivated(this, e);
		}

		public virtual bool SaveData()
		{
			return true;
		}

		public virtual WizardPage GetNextPage()
		{
			if (m_nextPages.Count == 0)
			{
				throw new WizardFormException("No pages have been specified as a \"next\" page.");
			}
			return m_nextPages[0];
		}

		void parentForm_WizardPageChange(object sender, WizardPageChangeArgs e)
		{
		}

		private void WizardPage_VisibleChanged(object sender, EventArgs e)
		{
			if (!WizardUtility.IsDesignTime())
			{
				if (this.Visible)
				{
					WizardPageActivated(this, new WizardPageActivateArgs(this, m_stepType));
				}
			}
		}

        private void WizardPage_Load(object sender, EventArgs e)
        {

        }
    }
}



