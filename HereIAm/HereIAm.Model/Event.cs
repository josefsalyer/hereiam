using System;
using System.Collections.Generic;

namespace HereIAm.Model
{
	public class Event : ModelBase
	{
		public List<Person> Hosts { get; set; }
		public List<Person> Visitors { get; set; }

		public Event ()
		{
			Hosts = new List<Person> ();
			Visitors = new List<Person> ();
		}

		public Event (Person host) : this()
		{
			Hosts.Add (host);
		}
	}
}

