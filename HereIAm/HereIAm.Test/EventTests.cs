using System;
using NUnit.Framework;
using HereIAm.Model;
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
			var expectedHost = new Person {
				Name = "Joe",
				PhoneNumber = new PhoneNumber("1234567890")
			};
			var actual = new Event (expectedHost);
			Assert.AreEqual (expectedHost, actual.Hosts [0]);
		}
	}
}

