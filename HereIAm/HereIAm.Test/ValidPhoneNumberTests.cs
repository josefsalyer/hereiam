using System;
using NUnit.Framework;

namespace HereIAm.Test
{
	[TestFixture]
	public class ValidPhoneNumberTests
	{
		[Test]
		public void NumericOnlyIsNormalizedAsNumericOnly()
		{
			//Arrange
			var expected = "1234567890";
			var phoneNumber = new PhoneNumber ("1234567890");

			//Act
			var result = phoneNumber.ToString();

			//Assert
			Assert.AreEqual (expected, result);
		}

		[Test]
		public void NumericDashDashIsNormalizedAsNumericOnly()
		{
			//Arrange
			var expected = "1234567890";
			var phoneNumber = new PhoneNumber ("123-456-7890");

			//Act
			var result = phoneNumber.ToString();

			//Assert
			Assert.AreEqual (expected, result);
		}
	}
}

