using System;
using Nancy;
using Nancy.TinyIoc;
using Nancy.Validation;
using Nancy.Validation.FluentValidation;
using Nancy.Diagnostics;
using Nancy.Bootstrapper;

namespace HereIAm
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override DiagnosticsConfiguration DiagnosticsConfiguration
		{
			get { return new DiagnosticsConfiguration { Password = @"password"}; }
		}

	}
}
