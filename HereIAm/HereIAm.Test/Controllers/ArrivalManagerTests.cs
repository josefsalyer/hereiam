using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using Nancy;
using Nancy.Testing;
using HereIAm.Models;
using HereIAm.Data;

namespace HereIAm.Test
{
	

	[TestFixture]
	public class ArrivalManagerTests
	{
		private DBConnection _db;
		private Person _host;
		private Person _guest;
		private Event _event;

		[SetUp]
		public void SetUp()
		{
			_host = new Person {
				Id = Guid.NewGuid().ToString(),
				PhoneNumber = "1112223333",
				Name = "Hoster"
			};

			_guest = new Person {
				Id = Guid.NewGuid ().ToString (),
				PhoneNumber = "9990009999",
				Name = "Guest"
			};

			_db = DBConnection.Connection("hereiam-test");
			_db.People.Save (_host);
			_db.People.Save (_guest);

			var guests = new List<Person> {_guest};


			var hosts = new List<Person> {_host};

			_event = new Event {
				Id = Guid.NewGuid ().ToString (),
				Name = "Awesome Event",
				Guests = guests,
				Hosts = hosts
			};


			_db.Events.Save (_event);

		}


		[TearDown]
		public void TearDown()
		{
			_db.Events.Delete (_event);
			_db.People.Delete (_host);
			_db.People.Delete (_guest);
		}

		[Test]
		public void TestVisitorIsExpected ()
		{
			var arrivalManager = new ArrivalManager ();

			bool isExpected = arrivalManager.IsExpected (_guest);
			Assert.True (isExpected);
		
		}


		[Test]
		[Ignore]
		public void HostNotifiedWhenExpectedVisitorArrives()
		{


//			const string VISITOR_NAME = "John Doe";
//			const string PHONE_NUMBER = "5551235678";
//
//
//			// Mocking
//			var mockVisitorManager = Mock.Of<VisitorManager> (vm =>
//				vm.GetVisitor(PHONE_NUMBER) == new Models.Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber });
//			
//			// Arrange
//			var notifier = new HostNotifier (mockVisitorManager);
//			var results = new List<Person> ();
//			var expected = new List<Person> {
//				new Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber }
//			};
//
//
//			// Watch for event
//			notifier.VisitorArrived += delegate (object sender, VisitorEventArgs e)
//			{
//				results.Add(mockVisitorManager.GetVisitor(e.PhoneNumber));
//			};
//
//			// Act
//			var visitorArrivedArgs = new VisitorEventArgs (PHONE_NUMBER);
//			notifier.OnVisitorArrived (visitorArrivedArgs);
//
//			// Assert
//			CollectionAssert.AreEqual (expected, results);
		}

		[Test]
		[Ignore]
		public void HostNotifiedWhenValidVisitorArrivesPost()
		{
			
			// Arrange
//			const string VISITOR_NAME = "John Doe";
//			const string PHONE_NUMBER = "5551235678";
//			var phoneNumber = new PhoneNumber(PHONE_NUMBER);
//			var jsonName = "{'name':'"+VISITOR_NAME+"'}";
//
//			var bootstrapper = new Bootstrapper ();
//			var client = new Browser (bootstrapper);
//			var visitorManager = bootstrapper.Container.Resolve<VisitorManager> ();
//			var notifier = new HostNotifier (visitorManager);
//			var results = new List<Person> ();
//			var expected = new List<Person> {
//				new Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber }
//			};
//
//			//Watch for event
//			notifier.VisitorArrived += delegate (object sender, VisitorEventArgs e)
//			{
//				results.Add(visitorManager.GetVisitor(e.PhoneNumber));
//			};
//
//			// Act
//			client.Post (String.Format ("/person/{0}/arrive", PHONE_NUMBER), x => {
//				x.HttpRequest ();
//				x.Header ("Content-Type", "application/json");
//				x.Body (jsonName);
//			});
//		
//			// Assert
//			CollectionAssert.AreEqual (expected, results);
		}
	}
}

