using System;
using NUnit.Framework;
using HereIAm.Dto;

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
	}
}

