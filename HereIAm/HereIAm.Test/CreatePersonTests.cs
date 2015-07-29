using NUnit.Framework;
using System;

namespace HereIAm.Test
{
	[TestFixture]
	public class CreatePersonTests
	{
		[Test]
		[ExpectedException(typeof(ArgumentException), ExpectedMessage = "Bad name")]
		public void WithAnInvalidNameThrowsAnException ()
		{
			//Arrange
			var personMgr = new PersonManager();
			var name = "";
			var phoneNumber = new PhoneNumber ("1234567890");

			//Act
			personMgr.Create (name, phoneNumber);
		}
	}
}

