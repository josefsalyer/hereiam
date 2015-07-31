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
			var actual = new PersonRequest ();
			Assert.IsInstanceOf<PersonRequest> (actual);
		}

		[Test]
		public void CanBeCreatedWithExistingAttributes()
		{
			var expectedName = "Mack the Knife";
			var expectedNumber = "1232341234";
			var expectedGuid = Guid.NewGuid ().ToString ();
			var actual = new PersonRequest (expectedName, expectedNumber, expectedGuid);
			Assert.AreEqual (expectedGuid, actual.Id);
			Assert.AreEqual (expectedNumber, actual.PhoneNumber);
			Assert.AreEqual (expectedName, actual.Name);	
		}

		[Test]
		public void GenerateGUIDWhenOneIsntThere () {
			var actual = new PersonRequest ("Kimmy the Hammer", "9075552727");
			Assert.IsNotNull (actual.Id);
		}
	}

}

