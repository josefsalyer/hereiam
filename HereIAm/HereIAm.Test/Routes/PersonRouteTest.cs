using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonRouteTest
	{

		private Browser _client;

		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new Bootstrapper ());
		}


		[Test]
		public void TestGetPersonRoute ()
		{
			var results = _client.Get ("/person", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}

		[Test]
		public void TestAddPersonRouteFailsValidation ()
		{
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/person", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);

			
		}

		[Test]
		public void TestAnnounceRouteWorks ()
		{
			var results = _client.Put ("/person/arrived");

			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}


		[Test]
		public void UserArrivesWithInvalidPhoneNumberTooShortPostReturnsInvalid () {
			//Act
			var jsonName = "{'name':'james', 'number':'1231231'}";
			var results = _client.Put ("/person/arrived", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

	}
}

