using System;
using MongoDB.Driver;
using HereIAm.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HereIAm.Data
{
	public class People 
	{
		private IMongoCollection<Person> _collection;
		public People (IMongoCollection<Person> collection)
		{
			_collection = collection;	

		}

		public async Task<Person> Get(string id)
		{
			return await _collection.Find(x => x.Id == id).SingleAsync();
		}

		//find by phonenumber
		public async Task<IEnumerable<Person>> FindByPhoneNumber(string phoneNumber)
		{
			var people = await _collection.Find ("{ 'PhoneNumber': '" + phoneNumber + "' }").ToListAsync ();
			return people;
		}

		public async Task Save(Person person)
		{
			await _collection.InsertOneAsync(person);
		}

		public async Task Delete(Person person)
		{
			await _collection.DeleteOneAsync(x => x.Id == person.Id);
		}

		public async Task Update(Person person)
		{
			await _collection.ReplaceOneAsync(x => x.Id == person.Id, person);
		}

		public async Task<IEnumerable<Person>> FindAll()
		{
			var people = await _collection.Find("{}").ToListAsync();
			return people;
		}

	}
}

