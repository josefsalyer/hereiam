using System;
using NUnit.Framework;
using HereIAm.Model;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonFactoryTests
	{
		[Test]
		public void CreatesAndReturnsValidPerson()
		{
			//Assign
			var expected = new Person { Name = "John Doe", PhoneNumber = new PhoneNumber("1234567890") };
			var factory = new PersonFactory ();

			//Act
			var results = factory.Create("John Doe", "1234567890");

			//Assert
			Assert.AreEqual (expected, results);
		}
	}
}

