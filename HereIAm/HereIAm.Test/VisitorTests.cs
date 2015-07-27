using System;
using NUnit.Framework;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class VisitorTests
	{
		[Test]
		public void VisitorCanHazNoHost ()
		{
			var visitor = new Visitor ();
			Assert.True (visitor.ForHost == null);

		}

		[Test]
		public void VisitorHazAHost ()
		{
			var visitor = new Visitor ("Bob", "6145551212", "9991231234");
			Assert.True (visitor.ForHost == "9991231234");
		}
	}
}

