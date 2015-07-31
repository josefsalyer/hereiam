using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;
using HereIAm.Data;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonArrivesTests
	{
		private Browser _client;
		private DBConnection _db;	
		[SetUp]
		public void SetUp()
		{
			// Arrange
			_client = new Browser (new Bootstrapper ());
		}

		[TearDown] 
		public void TearDown()
		{
			_client = null;
		}

		[Test]
		public void PersonArrivesWihValidPhoneNumberAndNamePostReturnsOK ()
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
		public void PersonArrivesWithInvalidPhoneNumberTooShortPostReturnsInvalid () {
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
		public void PersonArrivesWithValidNameAndInvalidPhoneNumberBadCharPutReturnsInvalid() {
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
		public void PersonArrivesWithValidNameAndInvalidPhoneNumberTooLongPutReturnsInvalid() {
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
		public void PersonArrivesWithBlankNameAndInvalidPhoneNumberTooShort(){
			//Act
			var jsonName = "{'name':'','phonenumber':'012345'}";
			var results = _client.Put ("/person/arrived", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void PersonArrivesWithBlankNameAndValidPhoneNumber(){
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

		[Test]
		public void PersonArrivesAndIsUnexpected()
		{
				
			
		}


	}
}

