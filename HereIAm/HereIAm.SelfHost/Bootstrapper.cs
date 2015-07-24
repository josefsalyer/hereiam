using System;
using Nancy;
using Nancy.Conventions;

namespace HereIAm.SelfHost
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureConventions (NancyConventions nancyConventions)
		{
			nancyConventions.StaticContentsConventions.AddDirectory ("docs","swagger");
		}
	}
}

