using System;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using HereIAm.Dto;

namespace HereIAm.DAL
{

	public class DBConnection
	{
		public MongoClient Client {
			get;
			set;
		}

		public String Environment {
			get;
			set;
		}
			

		public  IMongoDatabase Database {
			get;
			set;
		}

		public People People {
			get;
			set;
		}

		public Events Events {
			get;
			set;
		}

		public DBConnection (string environment = null)
		{
			if (environment == null || environment == @"dev") {
				this.Environment = @"dev";
				this.Client = new MongoClient ("mongodb://localhost:27017");
			} else {
				this.Environment = @"prod";
				this.Client = new MongoClient ("mongodb://josef:HereIAm1@aws-us-east-1-portal.6.dblayer.com:27017");
			}

			this.Database = this.Client.GetDatabase ("hereiam");

			this.People = new People (this.Database.GetCollection<PersonRequest> ("People"));
			this.Events = new Events (this.Database.GetCollection<Event> ("Events"));
				
		}
			
	}
		


}

