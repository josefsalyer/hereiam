using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class HostNotifiedTests
	{
		[Test]
		public void HostNotifiedWhenExpectedVisitorArrives()
		{


			// Arrange
			const string VISITOR_NAME = "John Doe";
			const string PHONE_NUMBER = "5551235678";
			
			var notifier = new HostNotifier ();
			var results = new List<Visitor> ();
			var expected = new List<Visitor> {
				new Visitor(VISITOR_NAME, PHONE_NUMBER)
			};

			// Mocking
			var mockVisitorManager = Mock.Of<VisitorManager> (vm =>
				vm.GetVisitor(PHONE_NUMBER) == new Visitor(VISITOR_NAME, PHONE_NUMBER));

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
	}
}

