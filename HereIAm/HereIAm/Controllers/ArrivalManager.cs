using System;
using HereIAm.Models;
using HereIAm.Data;
using System.Collections.Generic;

namespace HereIAm
{
	public class ArrivalManager
	{
		private DBConnection _db;

		public ArrivalManager ()
		{
			_db = new DBConnection ();
		}

		public bool IsExpected (Person person)
		{
			var results = _db.Events.FindInvited (person);
			List <Event> eventsInvited = new List <Event>(results.Result);

			return (eventsInvited.Count > 0) ? true : false;
		}


	}
}

