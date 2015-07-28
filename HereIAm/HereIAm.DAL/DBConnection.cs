using System;
using Raven.Client.Document;

namespace HereIAm.DAL
{
	public class DBConnection
	{
		public DocumentStore Store {
			get;
			set;
		}

		public DBConnection ()
		{
			this.Store = new DocumentStore ();
		}
	}
}

