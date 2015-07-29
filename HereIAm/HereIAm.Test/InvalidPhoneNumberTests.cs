using System;
using NUnit.Framework;

namespace HereIAm.Test
{
	[TestFixture]
	public class InvalidPhoneNumberTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bad phone number")]
		public void ThrowsExceptionWhenNonNumericNumberEntered()
		{
			//Act
			new PhoneNumber("BADBEEF123");
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bad phone number")]
		public void ThrowsExceptionWhenNumberIsTooLong()
		{
			//Act
			new PhoneNumber("123456789123456789");
		}

		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bad phone number")]
		public void ThrowsExceptionWhenNumberIsTooShort()
		{
			//Act
			new PhoneNumber("12345");
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThrowsExceptionWhenNullEntered()
		{
			//Act
			new PhoneNumber (null);
		}
	}
}