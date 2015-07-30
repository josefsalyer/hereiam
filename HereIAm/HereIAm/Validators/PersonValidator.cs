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
			RuleFor (req => req.PhoneNumber).Must (x => x != null).WithMessage ("PhoneNumber is required");
			RuleFor (req => req.PhoneNumber).Matches (@"^\(?\d{3}\)?-? ?\d{3}-? ?-?\d{4}$", new System.Text.RegularExpressions.RegexOptions()).WithMessage("Invalid PhoneNumber Format");

		}
	}
}

