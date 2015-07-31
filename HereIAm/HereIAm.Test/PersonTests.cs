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
		public void CanBeCreatedWithExistingAttributes()
		{
			var expectedName = "Mack the Knife";
			var expectedNumber = "1232341234";
			var expectedGuid = Guid.NewGuid ().ToString ();
			Person actual = new Person (expectedName, expectedNumber, expectedGuid);
			Assert.AreEqual (expectedGuid, actual.Id);
			Assert.AreEqual (expectedNumber, actual.PhoneNumber);
			Assert.AreEqual (expectedName, actual.Name);	
		}

		[Test]
		public void GenerateGUIDWhenOneIsntThere () {
			Person actual = new Person ("Kimmy the Hammer", "9075552727");
			Assert.IsNotNull (actual.Id);
		}
	}

}

