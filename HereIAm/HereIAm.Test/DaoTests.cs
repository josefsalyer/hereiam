using System;
using NUnit.Framework;
using HereIAm.Dal;
using HereIAm.Model;

namespace HereIAm.Test
{

	[TestFixture]
	public class DaoTests
	{
		private DaoFactory _factory;

		[SetUp]
		public void TestInit()
		{
			_factory = new DaoFactory ();
		}

		[Test]
		public void PeopleCollectionExists()
		{
			
			var dao = _factory.Create<Person> (Env.Dev) ; //this actually creates the collection

			Assert.NotNull (dao);
		}


		[Test]
		public void EventsCollectionExists()
		{
			var dao = _factory.Create<Event> (Env.Dev);

			Assert.NotNull(dao);
		}
		

//		[Test]
//		public void TestStoreSessionLifeCycle ()
//		{
//			
//
//
//
//			var client = new MongoClient ("mongodb://localhost:27017");
//
//			Assert.NotNull(client);
//
//
//			var database = client.GetDatabase ("hereiam");
//
//			Assert.NotNull (database );
//
//			database.CreateCollectionAsync ("People");
//
//			var collection = database.GetCollection<PersonRequest> ("People");
//
//			Assert.NotNull(collection);
//
//		
//			var id = Guid.NewGuid ().ToString ();
//			var person = new PersonRequest{ Name = "bob yunger", PhoneNumber = "1232341234", Id = id };
//
//			collection.InsertOneAsync (person);
//
//
//			var foundPerson = Get(person.Id, collection);
//
//			Assert.True (foundPerson.Result.Id == person.Id);
//
//		}

//		public async Task<PersonRequest> Get(String id, IMongoCollection<PersonRequest> collection)
//		{
//			return await collection.Find(x => x.Id == id).SingleAsync();
//		}
	}
}
