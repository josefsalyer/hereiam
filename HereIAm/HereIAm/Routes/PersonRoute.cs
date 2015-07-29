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
					var visitorParam = this.BindAndValidate<PersonRequest> ();
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

		private Response PostArrival(PersonRequest visitor) 
		{
			var statusCode = HttpStatusCode.InternalServerError;
			var isValidPhoneNumber = false;

			try {
				_arrival.MarkAsArrived (visitor);
				statusCode = HttpStatusCode.OK;
				isValidPhoneNumber = true;
			} catch (Exception ex) {
				if (ex is ArgumentException || ex is ArgumentNullException)
					statusCode = HttpStatusCode.BadRequest;
				else
					throw;
			}

			var responseBody = _arrival.GenerateAcknowledgementResponse (isValidPhoneNumber);

			return new TextResponse (statusCode, responseBody);
		}
	}
}

