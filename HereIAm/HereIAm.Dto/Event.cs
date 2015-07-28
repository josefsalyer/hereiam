using System;
using System.Collections.Generic;

namespace HereIAm.Dto
{
	public class Event
	{

		public List<Person> Hosts {
			get;
			set;
		}

		public List<Person> Visitors {
			get;
			set;
		}

		public Event ()
		{
			Hosts =	new List<Person>();
			Visitors =	new List<Person>();
		}

		public Event (Person host) : this()
		{
			this.Hosts.Add (host);
		}
	}
}

