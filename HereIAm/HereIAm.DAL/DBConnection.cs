using System;
using Raven.Client.Document;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HereIAm.DAL
{
	public class DBConnection
	{
		public DocumentStore Store {
			get;
			set;
		}

		public DBConnection ()
		{
			this.Store = new DocumentStore
				{
					Url = "https://lrtconsulting-5noh.ravenhq.com/databases/lrtconsulting-hereiam",
					ApiKey = "9db681e5-51c1-491a-b8ea-9dd8f12e09e0",
					DefaultDatabase = "lrtconsulting-hereiam"//,
//					HttpMessageHandlerFactory = new CustomHttpMessageHandler()
				};
			this.Store.Initialize ();
		}
	}



//
//
//	public class CustomHttpMessageHandler : HttpClientHandler
//	{
//		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//		{
//			request.Headers.TransferEncodingChunked = null;
//			return base.SendAsync(request, cancellationToken);
//		}
//	}
}

