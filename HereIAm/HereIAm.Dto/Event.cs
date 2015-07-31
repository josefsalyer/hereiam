using System;
using System.Collections.Generic;

namespace HereIAm.Dto
{
	public class Event
	{
		public string Id {
			get;
			set;
		}

		public List<PersonRequest> Hosts {
			get;
			set;
		}

		public List<PersonRequest> Visitors {
			get;
			set;
		}

		public Event ()
		{
			Hosts =	new List<PersonRequest>();
			Visitors =	new List<PersonRequest>();
		}

		public Event (PersonRequest host) : this()
		{
			this.Hosts.Add (host);
		}
	}
}

