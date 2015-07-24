using System;
using Nancy;
using Nancy.Responses;

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

		private Response PostArrival(DynamicDictionary param) {
			var statusCode = HttpStatusCode.InternalServerError;

			var isValidPhoneNumber = _arrival.ValidatePhoneNumber (param ["phoneNumber"]);
			if (isValidPhoneNumber) {
				statusCode = HttpStatusCode.OK;
			} else {
				statusCode = HttpStatusCode.BadRequest;
			}

			var responseBody = _arrival.GenerateAcknowledgementResponse (isValidPhoneNumber);

			return new TextResponse (statusCode, responseBody);
		}
	}
}

