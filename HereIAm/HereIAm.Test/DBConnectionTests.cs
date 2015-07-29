using System;
using NUnit.Framework;
using HereIAm.DAL;

using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Driver;
using MongoDB.Bson;


namespace HereIAm.Test
{

	public class Person
	{
		public String Name  {
			get;
			set;
		}

		public String PhoneNumber {
			get;
			set;
		}

		public String Id {
			get;
			set;
		}
	}

	[TestFixture]
	public class DBConnectionTests
	{
		[Test]
		public void TestDBConnectionNotNull ()
		{
			var db = new DBConnection ();
			Assert.NotNull (db);
		}

		[Test]
		public void TestConstructionsSetsDefaults()
		{
			var db = new DBConnection ();
			Assert.NotNull (db);
			var expectedHost = @"localhost";
			var actualHost = db.Client.Settings.Server.Host;
			StringAssert.AreEqualIgnoringCase (expectedHost, actualHost);

			var expectedPort = 27017;
			var actualPort = db.Client.Settings.Server.Port;
			Assert.AreEqual (expectedPort, actualPort);

		}



		[Test]
		public void TestDBConnectionHasHereIamDB()
		{
			var connection = new DBConnection ();
			var db = connection.Database;

			Assert.NotNull (db);
		}

		[Test]
		public void TestPeopleCollectionExists()
		{
			var connection = new DBConnection ();
			var db = connection.Database;
			var people = connection.People ; //this actually creates the collection

			Assert.NotNull (people);
		}
//
//		[Test]
//		public void TestStoreUrlIsConfigured ()
//		{
//			
//			var db = new DBConnection ();
//			var actual = db.Store.Url;
//			var expected = @"https://lrtconsulting-5noh.ravenhq.com/databases/lrtconsulting-hereiam";
//			Assert.AreEqual (expected, actual);
//
//		}
//
//		[Test]
//		public void TestStoreApiKeyIsConfigured ()
//		{
//
//			var db = new DBConnection ();
//			var actual = db.Store.ApiKey;
//			var expected = @"9db681e5-51c1-491a-b8ea-9dd8f12e09e0";
//			Assert.AreEqual (expected, actual);
//
//
//		}

		[Test]
		public void TestStoreSessionLifeCycle ()
		{
			



			var client = new MongoClient ("mongodb://localhost:27017");

			Assert.NotNull(client);


			var database = client.GetDatabase ("hereiam");

			Assert.NotNull (database );

			database.CreateCollectionAsync ("People");

			var collection = database.GetCollection<Person> ("People");

			Assert.NotNull(collection);

		
			var id = Guid.NewGuid ().ToString ();
			var person = new Person{ Name = "bob yunger", PhoneNumber = "1232341234", Id = id };

			collection.InsertOneAsync (person);


			var foundPerson = Get(person.Id, collection);

			Assert.True (foundPerson.Result.Id == person.Id);

		}

		public async Task<Person> Get(String id, IMongoCollection<Person> collection)
		{
			return await collection.Find(x => x.Id == id).SingleAsync();
		}



	}
}

