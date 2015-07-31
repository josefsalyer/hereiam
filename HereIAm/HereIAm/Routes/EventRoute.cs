using System;
using Nancy;
using Nancy.ModelBinding;
using HereIAm.Data;
using HereIAm.Models;

namespace HereIAm
{
	public class EventRoute : NancyModule
	{
		
		public EventRoute () : base("/event")
		{
			DBConnection _db = new DBConnection();

			Get ["/", runAsync: true] = async (_, token) =>
			{
				var events = await _db.Events.FindAll();

				return Response.AsJson(events);

			};

			Post ["/", runAsync: true] = async (_, token) => {

				var evt = this.Bind<Event>();

				evt.Id = Guid.NewGuid().ToString();

				await _db.Events.Save(evt);

				return Response.AsJson(evt, HttpStatusCode.OK);
			};
		}
	}
}

