using System;
<<<<<<< HEAD
using NUnit.Framework;
=======
using HereIAm.DAL;
using HereIAm.Dto;
using MongoDB.Driver;
using MongoDB.Bson;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HereIAm.Test
{
	[TestFixture]
	public class PeopleTests
	{
		private DBConnection connection;
		private IMongoDatabase db;
		private IMongoCollection<Person> collection;
		private People people;

		[SetUp]
		public void InitializeTest()
		{
			connection = new DBConnection ();
			db = connection.Database;
			collection = db.GetCollection<Person> ("People");
			people = new People (collection);
		}

		[Test]
		public void CreateAPerson()
		{
			var person = new Person { Name = "Kimmy Gibbler", PhoneNumber = "1112223344" };
			var expectedId = person.Id;
			people.Save(person);

			var actualPerson = Get(expectedId, collection);
			Assert.AreEqual (actualPerson.Result.Name, person.Name);
			Assert.AreEqual (actualPerson.Result.PhoneNumber, person.PhoneNumber);
		}

		public async Task<Person> Get(String id, IMongoCollection<Person> collection)
		{
			return await collection.Find(x => x.Id == id).SingleAsync();
		}
	}
}

