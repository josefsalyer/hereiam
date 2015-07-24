using System;
using Nancy;

namespace HereIAm
{
	public class RootModule : NancyModule
	{
		public RootModule ()
		{
			Get ["/"] = parameter => {
				return "Beep Boop";
			};
		}
	}
}

