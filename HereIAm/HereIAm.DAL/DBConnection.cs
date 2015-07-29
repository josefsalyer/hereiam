using System;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace HereIAm.DAL
{
	// FIXME: move to dto
	public class Person
	{
		public String Name  {
			get;
			set;
		}

		public String PhoneNumber {
			get;
			set;
		}

		public String Id {
			get;
			set;
		}
	}

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

		public PeopleCollection People {
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

			this.People = new PeopleCollection (this.Database.GetCollection<Person> ("People")); //;
				
		}
			
	}
		


}

