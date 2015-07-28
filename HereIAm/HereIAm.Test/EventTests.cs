using System;
using NUnit.Framework;
using HereIAm.Dto;
using System.Collections.Generic;

namespace HereIAm.Test
{
	[TestFixture]
	public class EventTests
	{
		[Test]
		public void EventClassExists ()
		{
			Event actual = new Event ();
			Assert.IsInstanceOf<Event> (actual);
		}

		[Test]
		public void EventClassHasAListOfHosts ()
		{
			Event actual = new Event ();
			Assert.IsInstanceOf<List<Person>> (actual.Hosts);
		}

		[Test]
		public void EventClassHasAListOfVisitors ()
		{
			Event actual = new Event ();
			Assert.IsInstanceOf<List<Person>> (actual.Visitors);
		}

		[Test]
		public void EventClassHasOneHostOnInitialization()
		{
			Person expectedHost = new Person ();
			expectedHost.Name = "Joe";
			expectedHost.PhoneNumber = "1234567890";
			Event actual = new Event (expectedHost);
			Assert.AreEqual (expectedHost, actual.Hosts [0]);
		}
	}
}

