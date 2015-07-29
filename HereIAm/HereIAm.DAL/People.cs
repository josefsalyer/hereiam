using System;
using MongoDB.Driver;
using HereIAm.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HereIAm.DAL
{
	public class People 
	{
		private IMongoCollection<PersonRequest> _collection;
		public People (IMongoCollection<PersonRequest> collection)
		{
			_collection = collection;	

		}

		public async Task<PersonRequest> Get(string id)
		{
			return await _collection.Find(x => x.Id == id).SingleAsync();
		}

		public async Task Save(PersonRequest person)
		{
			await _collection.InsertOneAsync(person);
		}

		public async Task Delete(PersonRequest person)
		{
			await _collection.DeleteOneAsync(x => x.Id == person.Id);
		}

		public async Task Update(PersonRequest person)
		{
			await _collection.ReplaceOneAsync(x => x.Id == person.Id, person);
		}

		public async Task<IEnumerable<PersonRequest>> FindAll()
		{
			var people = await _collection.Find("{}").ToListAsync();
			return people;
		}

	}
}

