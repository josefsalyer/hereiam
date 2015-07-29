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
					var visitorParam = this.BindAndValidate<Person> ();
					if (ModelValidationResult.IsValid)
						return PostArrival (visitorParam);
					return Negotiate.RespondWithValidationFailureMessage (ModelValidationResult);
				}
				catch (ModelBindingException)
				{
					return Negotiate.RespondWithValidationFailureMessage ("DTO binding failed");
				}
			};

			Post ["/{phoneNumber/greeting"] = _ => {
				throw new NotImplementedException (); 
			};
		}

		private Response PostArrival(Person visitor) 
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

