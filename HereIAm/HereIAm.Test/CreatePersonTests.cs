using NUnit.Framework;
using System;

namespace HereIAm.Test
{
	[TestFixture]
	public class CreatePersonTests
	{
		[Test]
		public void WithAnInvalidNameThrowsAnException ()
		{
			//Arrange
			var personMgr = new PersonManager();
			var name = "";
			var phoneNumber = "1234567890";
			var expectedExMessage = "Bad name";
			var expectedEx = typeof(ArgumentException);

			//Act / Assert
			Assert.Throws (
				expectedEx,
				delegate {
					personMgr.Create(name, phoneNumber);
				},
				expectedExMessage
			);
		}
	}
}

