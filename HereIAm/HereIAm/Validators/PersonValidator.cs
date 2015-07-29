using System;
using FluentValidation;
using HereIAm.Models;

namespace HereIAm
{
	public class PersonValidator : AbstractValidator<Person>
	{
		public PersonValidator ()
		{
			RuleFor (req => req.Name).Must (x => !String.IsNullOrWhiteSpace (x)).WithMessage ("Invalid name");
			RuleFor (req => req.PhoneNumber).Must (x => x != null).WithMessage ("Invalid phone number");
		}
	}
}

