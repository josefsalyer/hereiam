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
			this.Store = new DocumentStore
				{
					Url = "https://lrtconsulting-5noh.ravenhq.com/databases/lrtconsulting-hereiam",
					ApiKey = "9db681e5-51c1-491a-b8ea-9dd8f12e09e0"
				};
			
		}
	}
}

