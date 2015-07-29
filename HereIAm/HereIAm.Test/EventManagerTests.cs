using System;
using NUnit.Framework;
using HereIAm.Dto;
using System.Collections.Generic;

namespace HereIAm.Test
{
	[TestFixture]
	public class EventManagerTests
	{
		[Test]
		public void EventManagersExist ()
		{
			EventManager actual = new EventManager ();
			Assert.IsInstanceOf<EventManager> (actual);
		}

		[Test]
		public void WeCanAddMultipleEventsToTheManager ()
		{
			EventManager manager = new EventManager ();
			Event expected = new Event ();
			Event secondExpected = new Event ();
			manager.AddEvent ("myEvent", expected);
			manager.AddEvent ("anotherEvent", secondExpected);
			Assert.AreEqual (expected, manager.GetEvent("myEvent"));
			Assert.AreEqual(secondExpected, manager.GetEvent("anotherEvent"));
		}

		[Test]
		public void WeCantAddNullEvents ()
		{
			EventManager manager = new EventManager ();
			Assert.Throws<ArgumentNullException> ( delegate { manager.AddEvent ("nullEvent", null); });
		}
	}
}

