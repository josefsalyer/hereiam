using System;
using NUnit.Framework;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonTests
	{
		[Test]
		public void PersonClassExists ()
		{
			Person actual = new Person ();
			Assert.IsInstanceOf<Person> (actual);
		}

		[Test]
		public void PersonHasANameAndAPhoneNumber ()
		{
			var expectedName = "Maisam";
			var expectedPhoneNumber = "1234567890";
			Person actual = new Person (expectedName, expectedPhoneNumber);

			Assert.AreEqual (actual.Name, expectedName);
			Assert.AreEqual(actual.PhoneNumber, expectedPhoneNumber);
		}
			
	}

}

