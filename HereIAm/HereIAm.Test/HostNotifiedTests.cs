using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using Nancy;
using Nancy.Testing;
using HereIAm.Dto;

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

			// Mocking
			var mockVisitorManager = Mock.Of<VisitorManager> (vm =>
				vm.GetVisitor(PHONE_NUMBER) == new Visitor(VISITOR_NAME, PHONE_NUMBER));
			
			// Arrange
			var notifier = new HostNotifier (mockVisitorManager);
			var results = new List<Visitor> ();
			var expected = new List<Visitor> {
				new Visitor(VISITOR_NAME, PHONE_NUMBER)
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
			var jsonName = "{'name':'"+VISITOR_NAME+"'}";

			var bootstrapper = new Bootstrapper ();
			var client = new Browser (bootstrapper);
			var visitorManager = bootstrapper.Container.Resolve<VisitorManager> ();
			var notifier = new HostNotifier (visitorManager);
			var results = new List<Visitor> ();
			var expected = new List<Visitor> {
				new Visitor(VISITOR_NAME, PHONE_NUMBER)
			};

			// Watch for event
			notifier.VisitorArrived += delegate (object sender, VisitorEventArgs e)
			{
				results.Add(visitorManager.GetVisitor(e.PhoneNumber));
			};

			// Act
			client.Post (String.Format ("/arrival/{0}", PHONE_NUMBER), x => {
				x.HttpRequest ();
				x.Header ("Content-Type", "application/json");
				x.Body (jsonName);
			});
		
			// Assert
			CollectionAssert.AreEqual (expected, results);
		}
	}
}

