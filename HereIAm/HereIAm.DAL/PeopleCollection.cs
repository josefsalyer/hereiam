using System;
using MongoDB.Driver;

namespace HereIAm.DAL
{
	
	public class PeopleCollection
	{
		public IMongoCollection<Person> Collection {
			get;
			set;
		}
		public PeopleCollection (IMongoCollection<Person> collection)
		{
			this.Collection = collection;	
//			IMongoCollection<Person>
//			GetCollection<Person> ("People")
		}
	}
}

