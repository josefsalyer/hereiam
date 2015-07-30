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

		public List<string> Hosts
		{
			get;
			set;
		}

		public List<string> Guests
		{
			get;
			set;
		}

	}
}

