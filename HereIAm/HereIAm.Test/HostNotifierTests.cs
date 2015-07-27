using System;
using NUnit.Framework;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class HostNotifierTests
	{
		[Test]
		public void HostIsNotifiedOfVisitor()
		{
			var visitorManager = new VisitorManager ();
			var notifier = new HostNotifier (visitorManager);
			var host = new Host ();
			host.Id = "9991231234";

			var visitor = new Visitor ("Bob", "6145551212", "9991231234");

			visitorManager.AddVisitor (visitor);

			
		}
	}
}

