using System;
using NUnit.Framework;
using HereIAm.Data;

namespace HereIAm.Test
{

	[SetUpFixture]
	public class HereIAmFixtureSetup
	{
		private DBConnection _db;

		[SetUp]
		public void RunBeforelAllTestClasses()
		{
			_db = DBConnection.Connection("hereiam-test");
		}


		[TearDown]
		public void RunAfterAllTestClasses()
		{
			_db.Client.DropDatabaseAsync("hereiam-test");
			
		}
	}
}

