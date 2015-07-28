﻿using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
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
				PersonReqest visitorParam;
				try
				{
					visitorParam = this.Bind<PersonReqest> ();
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
				return PostArrival (visitorParam);
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

