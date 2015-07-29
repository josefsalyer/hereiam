using System;
using NUnit.Framework;
using HereIAm.Dto;

namespace HereIAm.Test
{
	[TestFixture]
	public class PersonTests
	{
		[Test]
		public void PersonClassExists ()
		{
			Person actual = new Person ();
			Assert.IsInstanceOf<Person> (actual);
		}
	}

}

