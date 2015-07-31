using System;
using System.Collections.Generic;

namespace HereIAm.Models
{
	public class Event
	{
		public string Id 
		{
			get;
			set;
		}

		public string Name 
		{
			get;
			set;
		}

		public List<Person> Hosts
		{
			get;
			set;
		}

		public List<Person> Guests
		{
			get;
			set;
		}

	}
}

