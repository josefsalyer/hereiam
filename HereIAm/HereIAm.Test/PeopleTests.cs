using System;
using NUnit.Framework;
using HereIAm.Dal;
using HereIAm.Dto;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HereIAm.Test
{
	[TestFixture]
	public class PeopleTests
	{
//		private DBConnection connection;
//		private IMongoDatabase db;
//		private IMongoCollection<PersonRequest> collection;
//		private People people;
//
//		[SetUp]
//		public void InitializeTest()
//		{
//			connection = new DBConnection ();
//			db = connection.Database;
//			collection = db.GetCollection<PersonRequest> ("People");
//			people = new People (collection);
//		}
//
//		[Test]
//		public void CreateAPerson()
//		{
//			var person = new PersonRequest { Name = "Kimmy Gibbler", PhoneNumber = "1112223344" };
//			var expectedId = person.Id;
//			people.Save(person);
//
//			var actualPerson = Get(expectedId, collection);
//			Assert.AreEqual (actualPerson.Result.Name, person.Name);
//			Assert.AreEqual (actualPerson.Result.PhoneNumber, person.PhoneNumber);
//		}
//
//		public async Task<PersonRequest> Get(String id, IMongoCollection<PersonRequest> collection)
//		{
//			return await collection.Find(x => x.Id == id).SingleAsync();
//		}
	}
}

