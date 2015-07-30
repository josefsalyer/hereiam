using System;
using Nancy;

namespace HereIAm
{
	public class RootRoute : NancyModule
	{
		public RootRoute ()
		{
			Get ["/"] = parameter => {
				return "This should load the SPA";
			};
		}
	}
}

