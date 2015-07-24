using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture ()]
	public class VisitorArrivesTests
	{
		private Browser _client;
			
		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new DefaultNancyBootstrapper ());
		}

		[Test ()]
		public void UserArrivesWihValidPhoneNumberPostReturnsOK ()
		{
			// Act
			var results = _client.Post ("/arrival/5551234567", x => {
				x.HttpRequest ();
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}

		[Test ()]
		public void UserArrivesWithInvalidPhoneNumberTooShortPostReturnsInvalid () {
			//Act
			var results = _client.Post ("/arrival/1234567", x => {
				x.HttpRequest ();
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}

		[Test]
		public void UserArrivesWithInvalidPhoneNumberBadCharPostReturnsInvalid() {
			// Act
			var results = _client.Post ("/arrival/BADBEEF123", x => {
				x.HttpRequest ();
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}
	}
}

