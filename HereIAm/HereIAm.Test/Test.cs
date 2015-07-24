using NUnit.Framework;
using System;

namespace HereIAm.Test
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
			var expected = 3;
			var actual = 1;


			Assert.AreEqual (expected, actual);
		}
	}
}

