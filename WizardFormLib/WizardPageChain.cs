using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WizardFormLib
{
	public class WizardPageChain
	{
		private List<WizardPage> m_pageChain = new List<WizardPage>();
		private WizardFormBase m_parent;

		public int Count
		{
			get { return m_pageChain.Count; }
		}

		public List<WizardPage> PageChain
		{
			get { return m_pageChain; }
		}

		public WizardPageChain(WizardFormBase parent)
		{
			m_parent = parent;
			this.m_pageChain.Clear();
		}

		public WizardPage GetCurrentPage()
		{
			if (this.Count > 0)
			{
				return (WizardPage)this.m_pageChain[this.Count-1]; 
			}
			else
			{
				throw new WizardFormException("No pages in page chain list.");
			}
		}

		public WizardPage GoFirst()
		{
			if (this.Count > 1)
			{
				this.GetCurrentPage().Visible = false;
				this.m_pageChain.RemoveRange(1, this.Count - 1);
			}
			else
			{
				throw new WizardFormException("No pages in page chain list.");
			}
			WizardPage currentPage = this.GetCurrentPage();
			currentPage.Visible = true;
			return currentPage;
		}

		public WizardPage GoBack()
		{
			if (this.Count > 1)
			{
				this.GetCurrentPage().Visible = false;
				this.m_pageChain.RemoveAt(this.Count - 1);
			}
			else
			{
				throw new WizardFormException("No pages in page chain list.");
			}
			WizardPage currentPage = this.GetCurrentPage();
			currentPage.Visible = true;
			return currentPage;
		}

		public WizardPage GoNext(WizardPage nextPage)
		{
			m_pageChain.Add(nextPage);
			WizardPage currentPage = this.GetCurrentPage();
			if (this.Count > 1)
			{
				((WizardPage)(m_pageChain[this.Count-2])).Visible = false;
			}
			currentPage.Visible = true;
			return currentPage;
		}

		public WizardPage SaveData()
		{
			WizardPage invalidPage = null;
			foreach (WizardPage page in m_pageChain)
			{
				if (!page.SaveData())
				{
					invalidPage = page;
					break;
				}
			}
			return invalidPage;
		}
	}
}

