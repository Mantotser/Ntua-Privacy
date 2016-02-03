using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

[assembly:CLSCompliant(true)]

namespace WizardFormLib
{
	public partial class WizardFormBase : Form
	{
        #region Data members
        private WizardPageChain		m_pageChain;
		private WizardPage			m_startPage;
		private WizardPage			m_stopPage;
		private Color				m_graphicPanelBackgroundColor		= Color.White;
		private Color				m_graphicPanelGradientColor			= Color.White;
		private string				m_graphicPanelImageResource			= "";
		private WizardImagePosition	m_graphicPanelImagePosition			= WizardImagePosition.Right;
		private bool				m_graphicPanelImageIsTransparent	= false;
		private Font				m_graphicPanelTitleFont				= new Font("Arial", 9.25f, FontStyle.Bold);
		private Font				m_graphicPanelSubtitleFont			= new Font("Arial", 8.25f, FontStyle.Italic);
		private Color				m_graphicPanelTitleColor			= Color.White;
		private Color				m_graphicPanelSubtitleColor			= Color.White;
		private int					m_pageCount							= 0;
		private Size				m_desiredPagePanelSize				= new Size(0,0);
		private bool				m_buttonStartHide					= false;
		private bool				m_buttonBackHide					= false;
		private bool				m_buttonNextHide					= false;
		private bool				m_buttonCancelHide					= false;
		private bool				m_buttonHelpHide					= false;
		#endregion Data members

		#region Events
		public event WizardPageChangeHandler WizardPageChangeEvent;
        //public event WizardPageCreatedHandler WizardPageCreatedEvent;
        //public event WizardFormStartedHandler WizardFormStartedEvent;
        #endregion Events
        public static int i = 0;
		#region Properties

		public Color GraphicPanelBackgroundColor
		{
			get { return m_graphicPanelBackgroundColor; }
			set { m_graphicPanelBackgroundColor = value; }
		}

		public Color GraphicPanelGradientColor
		{
			get { return m_graphicPanelGradientColor; }
			set { m_graphicPanelGradientColor = value; }
		}

		public string GraphicPanelImageResource
		{
			get { return m_graphicPanelImageResource; }
			set { m_graphicPanelImageResource = value; }
		}

		public WizardImagePosition GraphicPanelImagePosition
		{
			get { return m_graphicPanelImagePosition; }
			set { m_graphicPanelImagePosition = value; }
		}

		public bool GraphicPanelImageIsTransparent
		{
			get { return m_graphicPanelImageIsTransparent; }
			set {m_graphicPanelImageIsTransparent = value; }
		}

		public Font GraphicPanelTitleFont
		{
			get { return m_graphicPanelTitleFont; }
			set { m_graphicPanelTitleFont = value; }
		}

		public Font GraphicPanelSubtitleFont
		{
			get { return m_graphicPanelSubtitleFont; }
			set { m_graphicPanelSubtitleFont = value; }
		}

		public Color GraphicPanelTitleColor
		{
			get { return m_graphicPanelTitleColor; }
			set { m_graphicPanelTitleColor = value; }
		}

		public Color GraphicPanelSubtitleColor
		{
			get { return m_graphicPanelSubtitleColor; }
			set { m_graphicPanelSubtitleColor = value; }
		}

		public WizardPage StartPage
		{
			get { return m_startPage; }
		}

		public WizardPage StopPage
		{
			get { return m_stopPage; }
		}

		public int PageCount
		{
			get { return m_pageCount; }
		}

		public bool ButtonStartHide
		{
			get { return m_buttonStartHide; }
			set { m_buttonStartHide = value; }
		}

		public bool ButtonBackHide
		{
			get { return m_buttonBackHide; }
			set { m_buttonBackHide = value; }
		}

		public bool ButtonNextHide
		{
			get { return m_buttonNextHide; }
			set { m_buttonNextHide = value; }
		}

		public bool ButtonCancelHide
		{
			get { return m_buttonCancelHide; }
			set { m_buttonCancelHide = value; }
		}

		public bool ButtonHelpHide
		{
			get { return m_buttonHelpHide; }
			set { m_buttonHelpHide = value; }
		}

		public WizardPageChain PageChain
		{
			get { return m_pageChain; }
		}

		public Size PagePanelSize
		{
			get { return m_desiredPagePanelSize; }
		}
		#endregion Properties

		#region Constructors

		public WizardFormBase()
		{
			InitializeComponent();
			m_pageChain = new WizardPageChain(this);
			this.m_desiredPagePanelSize = this.pagePanel.Size;
		}
		#endregion Constructors

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				this.m_graphicPanelSubtitleFont.Dispose();
				this.m_graphicPanelTitleFont.Dispose();
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void Raise_WizardPageChangeEvent(WizardPageChangeArgs e)
		{
			UpdateWizardForm(e.ActivatedPage);
			WizardPageChangeEvent(this, e);
		}

		public void Raise_WizardFormStartedEvent(WizardFormStartedArgs e)
		{
			//WizardFormStartedEvent(this, e);
		}
	
		private void graphicPanelTop_Paint(object sender, PaintEventArgs e)
		{
			Graphics	g					= e.Graphics;
			Bitmap		image				= null;
			Rectangle	imageRect			= new Rectangle(0, 0, 0, 0);
			Rectangle	panelRect			= new Rectangle(0, 0, this.graphicPanelTop.Width, this.graphicPanelTop.Height);
			Rectangle	gradientRect		= new Rectangle(0, 0, panelRect.Width, panelRect.Height);
			Brush		gradientBrush		= null;
			int			gradientDirection	= 0;
			bool		needGradient		= (this.GraphicPanelGradientColor != this.GraphicPanelBackgroundColor);
			switch (this.GraphicPanelImagePosition)
			{
				case WizardImagePosition.Top :
					this.GraphicPanelImagePosition = WizardImagePosition.Right;
					break;
				case WizardImagePosition.Bottom :
					this.GraphicPanelImagePosition = WizardImagePosition.Center;
					break;
				case WizardImagePosition.Middle :
					this.GraphicPanelImagePosition = WizardImagePosition.Left;
					break;
			}

			try
			{
				if (this.GraphicPanelImageResource.Length > 0)
				{
					Assembly assembly = Assembly.GetEntryAssembly();
					Stream stream = assembly.GetManifestResourceStream(this.GraphicPanelImageResource);
					image = new Bitmap(Bitmap.FromStream(stream));
					imageRect.Size = new Size(image.Width, image.Height);
					if (imageRect.Size.Height != panelRect.Size.Height)
					{
						float resizePercent = (float)panelRect.Height / (float)imageRect.Height;
						imageRect.Size = new Size((int)((float)imageRect.Width * resizePercent), panelRect.Height);
					}
					switch (this.GraphicPanelImagePosition)
					{
						case WizardImagePosition.Right :
							imageRect.Location = new Point(panelRect.Width - imageRect.Width, 0);
							break;
						case WizardImagePosition.Left :
							imageRect.Location = new Point(0, 0);
							break;
						case WizardImagePosition.Center :
							imageRect.Location = new Point((int)(((float)panelRect.Width - (float)imageRect.Width) * 0.5), 0);
							break;
					}
				}
				bool needOppositeGradient = false;
				if (needGradient)
				{
					switch (this.GraphicPanelImagePosition)
					{
						case WizardImagePosition.Left :
							if (!m_graphicPanelImageIsTransparent)
							{
								gradientRect.Location = new Point(imageRect.Width-1, 0);
								gradientRect.Size = new Size(gradientRect.Width - imageRect.Width, gradientRect.Height);
								gradientDirection = 180;
							}
							break;
						case WizardImagePosition.Right :
							if (!m_graphicPanelImageIsTransparent)
							{
								gradientRect.Location = new Point(0, 0);
								gradientRect.Size = new Size(gradientRect.Width - imageRect.Width, gradientRect.Height);
								gradientDirection = 0;
							}
							break;
						case WizardImagePosition.Center :
							{
								needOppositeGradient = true;

								gradientRect.Location = new Point(0, 0);
								gradientRect.Size = new Size((int)(((float)gradientRect.Width - (float)imageRect.Width) * 0.5), gradientRect.Height);
								gradientDirection = 0;
							}
							break;
					}
					gradientBrush = new LinearGradientBrush(gradientRect, this.GraphicPanelGradientColor, this.GraphicPanelBackgroundColor, gradientDirection);
				}

				g.Clear(this.GraphicPanelBackgroundColor);

				if (needGradient && gradientBrush != null)
				{
					g.FillRectangle(gradientBrush, gradientRect);
					if (needOppositeGradient)
					{
						gradientBrush.Dispose();
						gradientDirection = (gradientDirection == 180) ? 0 : 180;
						gradientRect.Location = new Point(gradientRect.Width + imageRect.Width, 0);
						gradientBrush = new LinearGradientBrush(gradientRect, this.GraphicPanelGradientColor, this.GraphicPanelBackgroundColor, gradientDirection);
						g.FillRectangle(gradientBrush, gradientRect);
					}
					gradientBrush.Dispose();
				}

				if (image != null)
				{
					g.DrawImage(image, imageRect);
					image.Dispose();
				}

			}
			catch (Exception ex)
			{
				if (ex != null) { }
				throw;
			}
		}

		protected void PaintTitle()
		{
			if (this.GraphicPanelImagePosition == WizardImagePosition.Center)
			{
				this.labelTitle.Visible = false;
				this.labelSubtitle.Visible = false;
				return;
			}
			else
			{
				this.labelTitle.Visible = true;
				this.labelSubtitle.Visible = true;
			}

			this.labelTitle.AutoSize	= true;
			this.labelTitle.Text		= m_pageChain.GetCurrentPage().Title;
			this.labelTitle.Font		= m_graphicPanelTitleFont;
			this.labelTitle.ForeColor	= m_graphicPanelTitleColor;
			this.labelSubtitle.AutoSize	= true;
			this.labelSubtitle.Text		= m_pageChain.GetCurrentPage().Subtitle;
			this.labelSubtitle.Font		= m_graphicPanelSubtitleFont;
			this.labelSubtitle.ForeColor= m_graphicPanelSubtitleColor;

			if (this.GraphicPanelImagePosition == WizardImagePosition.Left)
			{
				this.labelTitle.Location = new Point(this.graphicPanelTop.Width - 10 - this.labelTitle.Size.Width, this.labelTitle.Location.Y);
				this.labelSubtitle.Location = new Point(this.graphicPanelTop.Width - 10 - this.labelSubtitle.Size.Width, this.labelSubtitle.Location.Y);
			}

			Rectangle panelRect = new Rectangle(0, 0, this.graphicPanelTop.Width, this.graphicPanelTop.Height);

		    try
		    {
		        using (Graphics g = Graphics.FromHwndInternal(this.Handle))
		        {
		            int textHeight = (this.labelTitle.Height + this.labelSubtitle.Height);
					int y = (int)(((float)panelRect.Height - (float)textHeight) * 0.5f);
					this.labelTitle.Location = new Point(this.labelTitle.Location.X, y);
					y += this.labelTitle.Size.Height; 
					this.labelSubtitle.Location = new Point(this.labelSubtitle.Location.X, this.labelSubtitle.Location.Y);
					this.labelTitle.Invalidate();
					this.labelSubtitle.Invalidate();
				}
			}
			catch (Exception ex)
			{
				if (ex != null) { }
				throw;
			}

		}

		public void PageCreated(WizardPage page)
		{
			pagePanel.Controls.Add(page);

			if (ButtonStartHide)
			{
				page.ButtonStateStart &= ~WizardButtonState.Visible;
			}
			if (ButtonBackHide)
			{
				page.ButtonStateBack &= ~WizardButtonState.Visible;
			}
			if (ButtonNextHide)
			{
				page.ButtonStateNext &= ~WizardButtonState.Visible;
			}
			if (ButtonCancelHide)
			{
				page.ButtonStateCancel &= ~WizardButtonState.Visible;
			}
			if (ButtonHelpHide)
			{
				page.ButtonStateHelp &= ~WizardButtonState.Visible;
			}

			switch (page.WizardPageType)
			{
				case WizardPageType.Start :
					{
						if (m_startPage != null)
						{
							throw new WizardFormException("Αρχική σελίδα έχει ήδη οριστεί.");
						}
						if (m_stopPage != null)
						{
							throw new WizardFormException("Δεν μπορεί να οριστεί αρχική σελίδα έπειτα από ορισμό τελευταίας.");
						}
						if (this.PageCount > 0)
						{
							throw new WizardFormException("Δεν μπορεί να οριστεί αρχική σελίδα έπειτα από ορισμό άλλων.");
						}
						m_startPage = page;
					}
					break;
				case WizardPageType.Stop :
					{
						if (m_stopPage != null)
						{
							throw new WizardFormException("Τελευταία σελίδα έχει ήδη οριστεί.");
						}
						if (m_startPage == null)
						{
							throw new WizardFormException("Τελευταία σελίδα δεν μπορεί να οριστεί αν αρχική δεν έχει ήδη οριστεί.");
						}
						m_stopPage = page;
					}
					break;
				case WizardPageType.Intermediate :
					{
						if (m_startPage == null)
						{
							throw new WizardFormException("Ενδιάμεση σελίδα δεν μπορεί να οριστεί αν αρχική δεν έχει ήδη οριστεί.");
						}
						if (m_stopPage != null)
						{
							throw new WizardFormException("Ενδιάμεση σελίδα δεν μπορεί να οριστεί αν τελευταία δεν έχει ήδη οριστεί.");
						}
					}
					break;
			}
			m_pageCount++;
		}

		public void DiscoverPagePanelSize(Size pageSize)
		{
			if (pageSize.Width > m_desiredPagePanelSize.Width)
			{
				m_desiredPagePanelSize.Width = pageSize.Width;
			}
			if (pageSize.Height > m_desiredPagePanelSize.Height)
			{
				m_desiredPagePanelSize.Height = pageSize.Height;
			}
		}

		public void StartWizard()
		{
			if (m_pageCount == 0)
			{
				throw new WizardFormException("Δεν υπάρχουν σελίδες στο πρόγραμμα.");
			}
			if (m_startPage == null)
			{
				throw new WizardFormException("Δεν έχει οριστεί αρχική σελίδα.");
			}
			if (m_stopPage == null)
			{
				throw new WizardFormException("Δεν έχει οριστεί τελευταία σελίδα.");
			}

			this.Width += (m_desiredPagePanelSize.Width  - this.pagePanel.Size.Width);
			this.Height += (m_desiredPagePanelSize.Height - this.pagePanel.Size.Height);
			m_pageChain.GoNext(m_startPage);
			UpdateWizardForm(m_startPage);

			Raise_WizardFormStartedEvent(new WizardFormStartedArgs());
		}

		public bool PageIsVisible(WizardButtonState state)
		{
			return (state & WizardButtonState.Visible) == WizardButtonState.Visible;
		}

		public bool PageIsEnabled(WizardButtonState state)
		{
			return (state & WizardButtonState.Enabled) == WizardButtonState.Enabled;
		}

		public void UpdateWizardForm(WizardPage page)
		{
		    PaintTitle();
			this.buttonStart.Visible	= PageIsVisible(page.ButtonStateStart);
			this.buttonStart.Enabled	= PageIsEnabled(page.ButtonStateStart);
			this.buttonBack.Visible		= PageIsVisible(page.ButtonStateBack);
			this.buttonBack.Enabled		= PageIsEnabled(page.ButtonStateBack);
			this.buttonNext.Visible		= PageIsVisible(page.ButtonStateNext);
			this.buttonNext.Enabled		= PageIsEnabled(page.ButtonStateNext);
			this.buttonCancel.Visible	= PageIsVisible(page.ButtonStateCancel);
			this.buttonCancel.Enabled	= PageIsEnabled(page.ButtonStateCancel);
			this.buttonHelp.Visible		= PageIsVisible(page.ButtonStateHelp);
			this.buttonHelp.Enabled		= PageIsEnabled(page.ButtonStateHelp);

			if (page.WizardPageType == WizardPageType.Stop)
			{
				this.buttonNext.Text = "Τέλος";
			}
			else
			{
				this.buttonNext.Text = "Επόμενη >";
			}
		}
	}
}


