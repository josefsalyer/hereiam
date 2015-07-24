using System;
using Nancy;

namespace HereIAm
{
	public class NotificationModule : NancyModule
	{
		public NotificationModule ()
		{
			Get ["/notification"] = parameter => {
				return "Notified!!!";
			};
		}
	}
}

