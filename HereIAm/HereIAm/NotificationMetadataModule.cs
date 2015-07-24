using System;
using Nancy.Metadata.Modules;
using Nancy.Swagger;

namespace HereIAm
{
	public class NotificationMetadataModule : MetadataModule<SwaggerRouteData>
	{
		public NotificationMetadataModule ()
		{
			Describe["GetNotification"] = desc => desc.AsSwagger (x =>
				{
					x.ResourcePath ("/notification");
					x.Summary ("Notifies people");
					x.Notes ("Really cool!");
				});
		}
	}
}

