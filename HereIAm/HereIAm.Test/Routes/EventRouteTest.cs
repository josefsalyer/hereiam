using NUnit.Framework;
using System;
using Nancy;
using Nancy.Testing;
using HereIAm.Models;
using HereIAm.Data;
using System.Collections.Generic;

namespace HereIAm.Test
{
	[TestFixture]
	public class EventRouteTest
	{

		private Browser _client;
		private Event _event;
		private DBConnection _db;


		[SetUp]
		public void InitializeTest()
		{
			// Arrange
			_client = new Browser (new Bootstrapper ());
			_event = new Event {
				Id = Guid.NewGuid ().ToString (),
				Name = "Awesome Event",
				Guests = new List<Person>(),
				Hosts = new List<Person>()
			};

			_db = new DBConnection ();

		}


		[TearDown]
		public void TearDown()
		{
			_db.Events.Delete (_event);
		}

		[Test]
		public void TestGetEventRoute ()
		{
			
			
			var results = _client.Get ("/event", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
			
			});

			// Assert
			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);
		}

		[Test]
		public void TestCreateAnEventRoute()
		{
			
			
			var results = _client.Post ("/event", x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body ("{'Name':'"+ _event.Name +"'}");
			});



			Assert.AreEqual (HttpStatusCode.OK, results.StatusCode);

			var returnedEventName = results.Body.DeserializeJson<Event>().Name;

			StringAssert.AreEqualIgnoringCase (returnedEventName, "Awesome Event" );


		}





	}
}

