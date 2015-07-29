using System;
using NUnit.Framework;

namespace HereIAm.Test
{
	[TestFixture]
	public class ValidPhoneNumberTests
	{
		[Test]
		public void Format1234567890IsNormalizedAs1234567890()
		{
			//Arrange
			var expected = "1234567890";
			var phoneNumber = new PhoneNumber ("1234567890");

			//Act
			var result = phoneNumber.ToString();

			//Assert
			Assert.AreEqual (expected, result);
		}
	}
}

