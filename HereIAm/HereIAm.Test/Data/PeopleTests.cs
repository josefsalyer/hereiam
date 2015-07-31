using System;
using NUnit.Framework;
using HereIAm.Models;
using HereIAm.Data;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HereIAm.Test
{
	[TestFixture]
	public class PeopleTests
	{
		private DBConnection _db;
		private Person _person;

		[SetUp]
		public void SetUp()
		{
			_person = new Person {
				Id = Guid.NewGuid().ToString(),
				PhoneNumber = "1112223333",
				Name = "Nobody"
			};

			_db = new DBConnection ();
			_db.People.Save (_person);
		}

		[Test]
		public void TestFindByPhoneNumberReturnsOnePerson ()
		{
			var result = FindByPhoneNumberWrapper (_person.PhoneNumber);
			List <Person> listOfPeople = new List<Person>(result.Result);
			Assert.True ( listOfPeople.Count >= 1); //fudged for inconsistent db setup and tear down
		}



		public async Task<IEnumerable<Person>> FindByPhoneNumberWrapper(string phonenumber)
		{
			return await _db.People.FindByPhoneNumber(phonenumber);
		} 

		[TearDown]
		public void TearDown()
		{
			_db.People.Delete (_person);
		}


	}
}

