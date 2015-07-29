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
			_client = new Browser (new Bootstrapper ());
		}

		[Test]
		public void UserArrivesWihValidPhoneNumberAndNamePostReturnsOK ()
		{
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/person/5551234567/arrive", x => {
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
			var results = _client.Post ("/person/1234567/arrive", x => {
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
			var results = _client.Post ("/person/BADBEEF123/arrive", x => {
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
			var results = _client.Post ("/person/012345678901/arrive", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test] 
		public void UserArrivesWithBlankNameAndInvalidPhoneNumberTooShort(){
			//Act
			var jsonName = "{'name':''}";
			var results = _client.Post ("/person/012345678901/arrive", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithBlankNameAndValidPhoneNumber(){
			//Act
			var jsonName = "{'name':''}";
			var results = _client.Post ("/person/5551234567/arrive", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}
	}
}

