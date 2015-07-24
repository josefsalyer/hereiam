using System;
using Nancy;
using Nancy.TinyIoc;

namespace HereIAm
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ConfigureApplicationContainer (TinyIoCContainer container)
		{
			base.ConfigureApplicationContainer (container);
		}

		protected override void ConfigureRequestContainer (TinyIoCContainer container, NancyContext context)
		{
			container.Register<Arrival>();
		}
	}
}

