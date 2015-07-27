using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture]
	public class VisitorArrivesTests
	{
		private Browser _client;
			
		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new DefaultNancyBootstrapper ());
		}

		[Test]
		public void UserArrivesWihValidPhoneNumberAndNamePostReturnsOK ()
		{
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/arrival/5551234567", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithInvalidPhoneNumberTooShortPostReturnsInvalid () {
			//Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/arrival/1234567", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithValidNameAndInvalidPhoneNumberBadCharPostReturnsInvalid() {
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/arrival/BADBEEF123", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithValidNameAndInvalidPhoneNumberTooLongPostReturnsInvalid() {
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/arrival/012345678901", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}
	}
}

