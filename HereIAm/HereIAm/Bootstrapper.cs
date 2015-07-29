using System;
using Nancy;
using Nancy.TinyIoc;
using Nancy.Validation;
using Nancy.Validation.FluentValidation;

namespace HereIAm
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		internal TinyIoCContainer Container { get; set; }

		protected override void ConfigureApplicationContainer (TinyIoCContainer container)
		{
			Container = container;
			Container.Register<IFluentAdapterFactory, DefaultFluentAdapterFactory> ().AsSingleton ();
			Container.Register<IModelValidatorFactory, FluentValidationValidatorFactory> ().AsSingleton ();
			Container.Register<VisitorManager> ().AsSingleton ();
		}

		protected override void ConfigureRequestContainer (TinyIoCContainer container, NancyContext context)
		{
			container.Register<Arrival>();
		}
	}
}
