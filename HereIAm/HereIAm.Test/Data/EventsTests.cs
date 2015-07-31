using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using Nancy;
using Nancy.Testing;
using HereIAm.Models;
using HereIAm.Data;
using System.Reflection;


namespace HereIAm.Test
{
	[TestFixture]
	public class EventsTests
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

			_db = new DBConnection ();
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
		public void TestAnEventIsCreated ()
		{
			var results = _db.Events.Get (_event.Id);

			var fetchedEvent = results.Result;

			var properties = fetchedEvent.GetType().GetProperties(BindingFlags.Public);

			StringAssert.AreEqualIgnoringCase (fetchedEvent.Id, _event.Id);

			Assert.True (fetchedEvent.Guests.Count == 1);

			for (int i = 0; i < fetchedEvent.Guests.Count; i++) {
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Guests [i].Id, _event.Guests [i].Id);
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Guests [i].Name, _event.Guests [i].Name);
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Guests [i].PhoneNumber, _event.Guests [i].PhoneNumber);
			}

			for (int i = 0; i < fetchedEvent.Hosts.Count; i++) {
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Hosts [i].Id, _event.Hosts [i].Id);
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Hosts [i].Name, _event.Hosts [i].Name);
				StringAssert.AreEqualIgnoringCase (fetchedEvent.Hosts [i].PhoneNumber, _event.Hosts [i].PhoneNumber);
			}



		}
	}
}

