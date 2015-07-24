using System;
using Nancy;

namespace HereIAm
{
	public class ArrivalModule : NancyModule
	{
		public ArrivalModule () : base("/arrival")
		{
			Post ["/{phoneNumber}"] = param => {
				return HttpStatusCode.OK;
			};
		}
	}
}

