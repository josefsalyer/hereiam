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
	}
}

