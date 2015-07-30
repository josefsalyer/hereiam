using System;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Collections.Generic;
using HereIAm.Model;

namespace HereIAm
{
	public class Dao<T> where T : ModelBase
	{
		private IMongoCollection<T> _collection;

		public Dao (IMongoCollection<T> collection)
		{
			_collection = collection;	

		}

		public async Task<T> Get(string id)
		{
			return await _collection.Find(x => x.Id == id).SingleAsync();
		}

		public async Task Save(T obj)
		{
			await _collection.InsertOneAsync(obj);
		}

		public async Task Delete(T obj)
		{
			await _collection.DeleteOneAsync(x => x.Id == obj.Id);
		}

		public async Task Update(T obj)
		{
			await _collection.ReplaceOneAsync(x => x.Id == obj.Id, obj);
		}

		public async Task<IEnumerable<T>> FindAll()
		{
			var people = await _collection.Find("{}").ToListAsync();
			return people;
		}
	}
}

