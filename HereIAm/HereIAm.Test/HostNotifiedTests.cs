using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using Nancy;
using Nancy.Testing;
using HereIAm.Dto;
using HereIAm.Models;

namespace HereIAm.Test
{
	[TestFixture]
	public class HostNotifiedTests
	{
		[Test]
		public void HostNotifiedWhenExpectedVisitorArrives()
		{
			const string VISITOR_NAME = "John Doe";
			const string PHONE_NUMBER = "5551235678";
			var phoneNumber = new PhoneNumber(PHONE_NUMBER);

			// Mocking
			var mockVisitorManager = Mock.Of<VisitorManager> (vm =>
				vm.GetVisitor(PHONE_NUMBER) == new Models.Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber });
			
			// Arrange
			var notifier = new HostNotifier (mockVisitorManager);
			var results = new List<Person> ();
			var expected = new List<Person> {
				new Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber }
			};


			// Watch for event
			notifier.VisitorArrived += delegate (object sender, VisitorEventArgs e)
			{
				results.Add(mockVisitorManager.GetVisitor(e.PhoneNumber));
			};

			// Act
			var visitorArrivedArgs = new VisitorEventArgs (PHONE_NUMBER);
			notifier.OnVisitorArrived (visitorArrivedArgs);

			// Assert
			CollectionAssert.AreEqual (expected, results);
		}

		[Test]
		public void HostNotifiedWhenValidVisitorArrivesPost()
		{
			
			// Arrange
			const string VISITOR_NAME = "John Doe";
			const string PHONE_NUMBER = "5551235678";
			var phoneNumber = new PhoneNumber(PHONE_NUMBER);
			var jsonName = "{'name':'"+VISITOR_NAME+"'}";

			var bootstrapper = new Bootstrapper ();
			var client = new Browser (bootstrapper);
			var visitorManager = bootstrapper.Container.Resolve<VisitorManager> ();
			var notifier = new HostNotifier (visitorManager);
			var results = new List<Person> ();
			var expected = new List<Person> {
				new Person { Name = VISITOR_NAME, PhoneNumber = phoneNumber }
			};

			// Watch for event
			notifier.VisitorArrived += delegate (object sender, VisitorEventArgs e)
			{
				results.Add(visitorManager.GetVisitor(e.PhoneNumber));
			};

			// Act
			client.Post (String.Format ("/person/{0}/arrive", PHONE_NUMBER), x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});
		
			// Assert
			CollectionAssert.AreEqual (expected, results);
		}
	}
}

