using System;
using HereIAm.Model;
using HereIAm.Model.Validator;

namespace HereIAm
{
	public class PersonFactory
	{
		public Person Create(string name, string phoneNumber)
		{
			var person = new Person {
				Name = name,
				PhoneNumber = new PhoneNumber(phoneNumber)
			};

			var personValidator = new PersonValidator ();
			var result = personValidator.Validate (person);

			if (result.IsValid)
				return person;
			return null;
		}
	}
}

