using System;
using NUnit.Framework;
using HereIAm.Models;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonFactoryTests
	{
		[Test]
		public void CreatesAndReturnsValidPerson()
		{
			//Assign
			var expected = new Person { Name = "John Doe", PhoneNumber = "1234567890" };

		

			//Assert
			Assert.NotNull (expected);
			Assert.Null (expected.Id);
		}
	}
}

