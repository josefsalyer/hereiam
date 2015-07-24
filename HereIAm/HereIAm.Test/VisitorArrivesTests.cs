using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture ()]
	public class VisitorArrivesTests
	{
		// Name | Phone    | Results
		// josef|5551234567|accepted
		[Test ()]
		public void UserArrivesWihValidPhoneNumberPostReturnsOK ()
		{
			// Arrange
			var client = new Browser (new DefaultNancyBootstrapper ());

			// Act
			var results = client.Post ("/arrival/5551234567", x => {
				x.HttpRequest ();
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}

		[Test ()]
		public void UserArrivesWithInvalidPhoneNumberTooShortPostReturnsInvalid () {
			//Arrange
			var client = new Browser (new DefaultNancyBootstrapper ());

			//Act
			var results = client.Post ("/arrival/1234567", x => {
				x.HttpRequest ();
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
		}
	}
}

