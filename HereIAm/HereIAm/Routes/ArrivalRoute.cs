﻿using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using HereIAm.Dto;

namespace HereIAm
{
	public class ArrivalRoute : NancyModule
	{
		private Arrival _arrival = null;

		public ArrivalRoute (Arrival arrival) : base("/arrival")
		{
			// Initialize class
			_arrival = arrival;

			// Setup routes
			Post ["/{phoneNumber}"] = param => {
				Person visitorParam;
				try
				{
					visitorParam = this.Bind<Person> ();
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

