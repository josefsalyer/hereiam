using System;
using Nancy;
using Nancy.TinyIoc;

namespace HereIAm
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		public TinyIoCContainer Container { get; set; }

		protected override void ConfigureApplicationContainer (TinyIoCContainer container)
		{
			Container = container;
			container.Register<VisitorManager> ().AsSingleton ();
		}

		protected override void ConfigureRequestContainer (TinyIoCContainer container, NancyContext context)
		{
			container.Register<Arrival>();
		}
	}
}
