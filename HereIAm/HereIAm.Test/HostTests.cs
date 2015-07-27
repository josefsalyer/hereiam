using System;
using NUnit.Framework;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class HostTests
	{
		[Test]
		public void HostClassExists ()
		{
			var actual = new Host ();
			Assert.IsInstanceOf<Host> (actual);
		}
			

		[Test]
		public void HostIsNotifiedOfAnArrival()
		{
			var actual = new Host ();
			var visitor = new Visitor ();
			Assert.True (actual.Notify(visitor));
		}

	
	}
}

