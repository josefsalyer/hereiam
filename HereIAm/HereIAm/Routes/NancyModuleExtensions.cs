/*
 * From https://gist.github.com/AnthonySteele/9290393 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses.Negotiation;
using Nancy.Validation;
using Nancy.Responses;


public static class ModuleExtensions
{
	public static object RespondWithValidationFailureMessage(this Negotiator negotiate, ModelValidationResult validationResult)
	{
		var model = new ValidationFailedResponse(validationResult);

		return new TextResponse(HttpStatusCode.BadRequest, model.Messages.FirstOrDefault ());
	}

	public static object RespondWithValidationFailureMessage(this Negotiator negotiate, string message)
	{
		var model = new ValidationFailedResponse(message);

		return new TextResponse(HttpStatusCode.BadRequest, model.Messages.FirstOrDefault ());
	}
}
	
internal class ValidationFailedResponse
{
	public List<string> Messages { get; set; }

	public ValidationFailedResponse()
	{}

	public ValidationFailedResponse(ModelValidationResult validationResult)
	{
		Messages = new List<string>();
		ErrorsToStrings(validationResult);
	}

	public ValidationFailedResponse(string message)
	{
		Messages = new List<string>
		{
			message
		};
	}

	private void ErrorsToStrings(ModelValidationResult validationResult)
	{
		foreach (var errorGroup in validationResult.Errors)
		{
			foreach (var error in errorGroup.Value)
			{
				Messages.Add(error.ErrorMessage);
			}
		}
	}
}