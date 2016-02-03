using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WizardFormLib
{
	[Serializable()]
	public class WizardFormException : System.Exception
	{
		public WizardFormException() : base()
		{ }
	    
		public WizardFormException(string message) : base(message)
		{}

		public WizardFormException(string message, System.Exception inner) : base(message, inner)
		{ }

		protected WizardFormException(System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context) : base(info, context)
		{ }
	}
}
