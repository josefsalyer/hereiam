using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Validation;
using HereIAm.Dto;

namespace HereIAm
{
	public class PersonRoute : NancyModule
	{
		private Arrival _arrival = null;

		public PersonRoute (Arrival arrival) : base("/person")
		{
			// Initialize class
			_arrival = arrival;

			// Setup routes
			Post ["/{phoneNumber}/arrive"] = _ => {
				try
				{
					var visitorParam = this.BindAndValidate<PersonReqest> ();
					if (ModelValidationResult.IsValid)
						return PostArrival (visitorParam);
					return HttpStatusCode.BadRequest;
				}
				catch (Exception ex)
				{
					// Check if Nancy exception.
					if ((ex as System.Reflection.TargetInvocationException) != null)
						return new TextResponse (HttpStatusCode.BadRequest);
					// Check if library exception.
					if ((ex as ArgumentException) != null)						
						return new TextResponse (HttpStatusCode.BadRequest, ex.Message);
					// Something we don't know about.
					throw;
				}
			};

			Post ["/{phoneNumber/greeting"] = _ => {
				throw new NotImplementedException (); 
			};
		}

		private Response PostArrival(PersonReqest visitor) 
		{
			var statusCode = HttpStatusCode.InternalServerError;

			var isValidPhoneNumber = _arrival.ValidatePhoneNumber (visitor.PhoneNumber);
			if (isValidPhoneNumber) {
				statusCode = HttpStatusCode.OK;
				_arrival.MarkAsArrived (visitor);
			} else {
				statusCode = HttpStatusCode.BadRequest;
			}

			var responseBody = _arrival.GenerateAcknowledgementResponse (isValidPhoneNumber);

			return new TextResponse (statusCode, responseBody);
		}
	}
}

