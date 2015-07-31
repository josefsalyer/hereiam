using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonArrivesTests
	{
		private Browser _client;
			
		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new Bootstrapper ());
		}

		[TearDown] 
		public void Dispose()
		{
			_client = null;
		}

		[Test]
		public void UserArrivesWihValidPhoneNumberAndNamePostReturnsOK ()
		{
			// Act
			var jsonName = "{'name':'james','PhoneNumber':'1119992112'}";
			var results = _client.Put ("/person/arrived", x => {
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
			var jsonName = "{'name':'james', 'PhoneNumber':'123456'}";
			var results = _client.Put ("/person/arrived", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithValidNameAndInvalidPhoneNumberBadCharPutReturnsInvalid() {
			// Act
			var jsonName = "{'name':'james','phonenumber':'BADBEEF123'}";
			var results = _client.Put ("/person/arrived", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithValidNameAndInvalidPhoneNumberTooLongPutReturnsInvalid() {
			// Act
			var jsonName = "{'name':'james','phonenumber':'012345678901'}";
			var results = _client.Put ("/person/arrived", x => {
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
			var jsonName = "{'name':'','phonenumber':'012345678901'}";
			var results = _client.Put ("/person/arrived", x => {
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
			var jsonName = "{'name':'', 'phonenumber':'5551234567'}";
			var results = _client.Put ("/person/arrived", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}


	}
}

