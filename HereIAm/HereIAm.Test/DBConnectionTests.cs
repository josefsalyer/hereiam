using System;
using NUnit.Framework;
using HereIAm.DAL;
using Raven.Client.Document;

namespace HereIAm.Test
{
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
		public void TestReferenceToRavenDB()
		{
			var store = new DocumentStore ();
			Assert.NotNull (store);
		}

		[Test]
		public void TestDBConnectionHasDocumentStore()
		{
			var db = new DBConnection ();
			Assert.NotNull (db.Store);
		}

		[Test]
		public void TestStoreUrlIsConfigured ()
		{
			
			var db = new DBConnection ();
			var actual = db.Store.Url;
			var expected = @"https://lrtconsulting-5noh.ravenhq.com/databases/lrtconsulting-hereiam";
			Assert.AreEqual (expected, actual);

		}

		[Test]
		public void TestStoreApiKeyIsConfigured ()
		{

			var db = new DBConnection ();
			var actual = db.Store.ApiKey;
			var expected = @"9db681e5-51c1-491a-b8ea-9dd8f12e09e0";
			Assert.AreEqual (expected, actual);

		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void TestStoreIsInitialized()
		{	
			var db = new DBConnection ();
			Assert.Throws (typeof (System.InvalidOperationException), new TestDelegate (DelegateMethod(db)));

			db.Store.Initialize ();

			Assert.DoesNotThrow (new TestDelegate (DelegateMethod(db)));
		}

		dynamic DelegateMethod(DBConnection dbconn){
			
			return dbconn.Store.DatabaseCommands;

		}

	}
}

