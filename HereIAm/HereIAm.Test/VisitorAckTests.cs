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
			_client = new Browser (new Bootstrapper ());
		}

		[Test]
		public void AcceptedVisitorIsSentAnAcknowledgementMessage()
		{
			// Act
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/person/5551234567/arrive", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
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
			var jsonName = "{'name':'james'}";
			var results = _client.Post ("/person/55512345679877/arrive", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body(jsonName);
			});

			//Arrange
			var expectedAck = @"Stranger Danger!";

			//Assert
			Assert.AreEqual (HttpStatusCode.BadRequest, results.StatusCode);
			Assert.AreEqual (expectedAck, results.Body.AsString ());
		}
	}
}

