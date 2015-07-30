using System;
using Nancy;
using HereIAm.Data;

namespace HereIAm
{
	public class EventRoute : NancyModule
	{
		DBConnection _db = new DBConnection();
		public EventRoute () : base("/event")
		{
			Get ["/", runAsync: true] = async (_, token) =>
			{
				var events = await _db.Events.FindAll();

				return Response.AsJson(events);

			};
		}
	}
}

