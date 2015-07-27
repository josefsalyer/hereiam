using System;
using System.Collections;
using System.Collections.Generic;
using HereIAm.Dto;

namespace HereIAm
{
	public class VisitorManager
	{
		private Dictionary<string, Visitor> _visitorState;

		public VisitorManager()
		{
			_visitorState = new Dictionary<string, Visitor> ();
		}

		public virtual Visitor GetVisitor(string phoneNumber) 
		{
			throw new NotImplementedException ();
		}
	}
}

