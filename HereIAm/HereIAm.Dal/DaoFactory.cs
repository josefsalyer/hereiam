using System;
using MongoDB.Driver;
using HereIAm.Model;

namespace HereIAm.Dal
{
	public class DaoFactory
	{
		public Dao<T> Create<T>(Env environment) where T : ModelBase
		{
			MongoUrl url = null;
			var typeName = typeof(T).Name;

			switch (environment) 
			{
			case Env.Dev:
				url = new MongoUrl(@"mongodb://localhost:27017");
				break;
			case Env.Prod:
				url = new MongoUrl(@"mongodb://josef:HereIAm1@aws-us-east-1-portal.6.dblayer.com:27017");
				break;
			}

			var client = new MongoClient (url);
			var database = client.GetDatabase ("hereiam");

			return new Dao<T> (database.GetCollection<T> (typeName));
		}
	}
}

