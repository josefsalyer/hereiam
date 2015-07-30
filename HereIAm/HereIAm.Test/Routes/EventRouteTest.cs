using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture]
	public class EventRouteTest
	{

		private Browser _client;

		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new Bootstrapper ());
		}

		[Test]
		public void TestGetEventRoute ()
		{
			var results = _client.Get ("/person", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
			
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}
	}
}

