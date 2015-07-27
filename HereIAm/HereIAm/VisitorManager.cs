using System;
using System.Collections;
using System.Collections.Generic;
using HereIAm.Dto;

namespace HereIAm
{
	public class VisitorManager
	{
		public event EventHandler<VisitorEventArgs> VisitorAdded;

		private Dictionary<string, Visitor> _visitorState;

		public VisitorManager()
		{
			_visitorState = new Dictionary<string, Visitor> ();
		}

		public void OnVisitorAdded(VisitorEventArgs e)
		{
			var handler = VisitorAdded;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		public void AddVisitor(Visitor visitor)
		{
			if (visitor == null)
				throw new ArgumentNullException ("visitor");

			_visitorState.Add (visitor.PhoneNumber, visitor);
			OnVisitorAdded (new VisitorEventArgs(visitor.PhoneNumber));
		}

		public virtual Visitor GetVisitor(string phoneNumber) 
		{
			if (String.IsNullOrWhiteSpace (phoneNumber))
				throw new ArgumentException ("phoneNumber");

			return _visitorState [phoneNumber];
		}
	}
}

