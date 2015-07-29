using System;
using NUnit.Framework;
using HereIAm;
using Nancy;


namespace HereIAm.Test
{
	
	public class MyBootStrapper:DefaultNancyBootstrapper
	{

	}

	[TestFixture]
	public class BootstrapperTests
	{


		[Test]
		public void TestBootstrapIsWorking ()
		{
			//this makes certain that the nuget package for Nancy.Validation.FluentValidation is installed in the test package	

			Assert.DoesNotThrow (delegate {
				new MyBootStrapper ();
			});
		}
	}
}

