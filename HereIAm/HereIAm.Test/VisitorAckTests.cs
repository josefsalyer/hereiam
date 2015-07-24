using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;

namespace HereIAm.Test
{
	[TestFixture]
	public class VisitorAckTests
	{
		private Browser _client;

		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new DefaultNancyBootstrapper ());
		}

		[Test]
		public void AcceptedVisitorIsSentAnAcknowledgementMessage()
		{
			// Act
			var results = _client.Post ("/arrival/5551234567", x => {
				x.HttpRequest ();
			});

			// Arrange
			var expectedAck = @"Thank you, someone will be with you shortly.";

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
			Assert.AreEqual (expectedAck, results.Body.AsString ()); 
		}

		[Test]
		public void InvalidVisitorIsSentARejectionAcknowledgement()
		{
			//Act
			var results = _client.Post ("/arrival/55512345679877", x => {
				x.HttpRequest ();
			});

			//Arrange
			var expectedAck = @"Stranger Danger!";

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
			Assert.AreEqual (expectedAck, results.Body.AsString ());
		}
	}
}

