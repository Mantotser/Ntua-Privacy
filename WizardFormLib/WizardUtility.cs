using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WizardFormLib
{
	public static class WizardUtility
	{
		public static bool IsDesignTime()
		{
			return (Process.GetCurrentProcess().ProcessName.ToLower() == "devenv");
		}
	}
}
