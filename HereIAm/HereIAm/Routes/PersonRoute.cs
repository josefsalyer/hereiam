using System;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.Validation;
using HereIAm.Models;
using HereIAm.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using FluentValidation.Results;

namespace HereIAm
{
	public class PersonRoute : NancyModule
	{
		DBConnection _db;
		ArrivalManager _arrivalManager;


		public ValidationResult ValidateRequestBody(Person person)
		{
			var validator = new PersonValidator();

			return validator.Validate(person);
		}


		public PersonRoute () : base("/person")
		{
			_db = DBConnection.Connection();
			_arrivalManager = new ArrivalManager ();

			Get ["/", runAsync: true] = async (_, token) =>
			{

				var people = await _db.People.FindAll();

				return Response.AsJson(people);
			};

			Post ["/", runAsync: true] = async (_, token) =>
			{
				var person = this.Bind<Person>();

				ValidationResult result = ValidateRequestBody(person);

				if(!result.IsValid){
					return Response.AsJson(result.Errors, HttpStatusCode.BadRequest);
				}


				person.Id = Guid.NewGuid().ToString();

				await _db.People.Save(person);

				return Response.AsJson(person);

			};

			Put ["/arrived", runAsync: true] = async (_, token) => {

				var person = this.Bind<Person>();

				ValidationResult result = ValidateRequestBody(person);

				if(!result.IsValid){
					return Response.AsJson(result.Errors, HttpStatusCode.BadRequest);
				}


				//check to see if person exists, if not return danger message
				var results = await _db.People.FindByPhoneNumber(person.PhoneNumber);
				List <Person> validPeople = new List<Person>(results);

				//if not valid return early
				if(validPeople.Count == 0)
				{
					return Response.AsJson("{'Warning':'Stranger Danger'}",HttpStatusCode.OK);
				}

				//look for events where they are expected guests
				var isExpected = _arrivalManager.IsExpected(person);

				//then we want to notify the hosts




				if(!isExpected)
				{
					return Response.AsJson(result.Errors, HttpStatusCode.BadRequest);
				}

				return HttpStatusCode.OK;
			};

			Delete  ["/", runAsync: true] = async (_, token) =>
			{
				var person = this.Bind<Person>();

				ValidationResult result = ValidateRequestBody(person);

				if(!result.IsValid){
					return Response.AsJson(result.Errors, HttpStatusCode.BadRequest);
				}

				await _db.People.Delete(person);

				return HttpStatusCode.OK;

			};

		}
	}
}