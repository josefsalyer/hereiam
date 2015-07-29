using System;
using NUnit.Framework;
using HereIAm.Models;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonValidationTest
	{
		[Test]
		public void IsNotValidWithNullName()
		{
			//Assign
			var validator = new PersonValidator();
			var person = new Person {
				Name = null,
				PhoneNumber = null
			};

			//Act
			var results = validator.Validate (person);

			//Assert
			Assert.IsFalse (results.IsValid);
		}

		[Test]
		public void IsNotValidWithNullNumber()
		{
			//Assign
			var validator = new PersonValidator();
			var person = new Person {
				Name = "John Doe",
				PhoneNumber = null
			};

			//Act
			var results = validator.Validate (person);

			//Assert
			Assert.IsFalse (results.IsValid);
		}

		[Test]
		public void IsValidWithNameAndPhoneNumber ()
		{
			//Assign
			var validator = new PersonValidator();
			var person = new Person {
				Name = "John Doe",
				PhoneNumber = new PhoneNumber ("1234567890")
			};

			//Act
			var results = validator.Validate (person);

			//Assert
			Assert.IsTrue (results.IsValid);
		}
	}
}

