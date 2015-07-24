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


	}
}

