using System;
using Nancy;

namespace HereIAm
{
	public class ArrivalModule : NancyModule
	{
		private Arrival _arrival = null;

		public ArrivalModule (Arrival arrival) : base("/arrival")
		{
			// Initialize class
			_arrival = arrival;

			// Setup routes
			Post ["/{phoneNumber}"] = param => PostArrival (param);
		}

		private HttpStatusCode PostArrival(DynamicDictionary param) {
			var statusCode = HttpStatusCode.InternalServerError;

			if (_arrival.ValidatePhoneNumber (param["phoneNumber"])) {
				statusCode = HttpStatusCode.OK;
			} else {
				statusCode = HttpStatusCode.BadRequest;
			}

			return statusCode;
		}
	}
}

