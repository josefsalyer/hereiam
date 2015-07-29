using System;
using Nancy.Validation.FluentValidation;
using FluentValidation;
using HereIAm.Dto;

namespace HereIAm
{
	public class PersonRequestValidator : AbstractValidator<Person>
	{
		public PersonRequestValidator ()
		{
			RuleFor (req => req.Name).Must (x => !String.IsNullOrWhiteSpace (x)).WithMessage ("Error: Bad name");
			RuleFor (req => req.PhoneNumber).Must (x => !String.IsNullOrWhiteSpace (x)).WithMessage ("Error: Bad phone number");
		}
	}
}

