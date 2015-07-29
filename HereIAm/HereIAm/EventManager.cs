using System;
using System.Collections.Generic;
using HereIAm.Dto;

namespace HereIAm
{
	public class EventManager
	{
		public EventManager ()
		{
			Events = new Dictionary<string, Event>();
		}

		private Dictionary<String, Event> Events;

		public void AddEvent (String name, Event meeting)
		{
			if (meeting == null)
			{
				throw new ArgumentNullException ("Event Should not be null!");
			}

			Events.Add(name, meeting);
		}

		public Event GetEvent(String name) {
			return Events[name];
		}

	}
}

