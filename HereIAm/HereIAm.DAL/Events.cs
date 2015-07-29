using System;
using MongoDB.Driver;
using HereIAm.Dto;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HereIAm.DAL
{
	public class Events
	{
		private IMongoCollection<Event> _collection;
		public Events (IMongoCollection<Event> collection)
		{
			_collection = collection;	

		}

		public async Task<Event> Get(string id)
		{
			return await _collection.Find(x => x.Id == id).SingleAsync();
		}

		public async Task Save(Event _event)
		{
			await _collection.InsertOneAsync(_event);
		}

		public async Task Delete(Event _event)
		{
			await _collection.DeleteOneAsync(x => x.Id == _event.Id);
		}

		public async Task Update(Event _event)
		{
			await _collection.ReplaceOneAsync(x => x.Id == _event.Id, _event);
		}

		public async Task<IEnumerable<Event>> FindAll()
		{
			var events = await _collection.Find("{}").ToListAsync();
			return events;
		}
			
	}
}

