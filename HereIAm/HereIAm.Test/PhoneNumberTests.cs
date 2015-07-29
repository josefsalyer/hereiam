using System;
using NUnit.Framework;

namespace HereIAm.Test
{
	[TestFixture]
	public class PhoneNumberTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bad phone number")]
		public void ThrowsExceptionWhenInvalidNumberEntered()
		{
			//Act
			new PhoneNumber("BADBEEF123");
		}
	}
}