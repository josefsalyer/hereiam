﻿using System;
using Nancy.Validation.FluentValidation;
using FluentValidation;
using HereIAm.Dto;

namespace HereIAm
{
	public class PersonRequestValidator : AbstractValidator<PersonRequest>
	{
		public PersonRequestValidator ()
		{
			RuleFor (req => req.Name).Must (x => !String.IsNullOrWhiteSpace (x));
			RuleFor (req => req.PhoneNumber).Must (x => !String.IsNullOrWhiteSpace (x));
		}
	}
}

