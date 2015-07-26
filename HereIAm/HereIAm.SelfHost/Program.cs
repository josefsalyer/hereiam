using System;
using Nancy.Hosting.Self;

namespace HereIAm.SelfHost
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var host = new NancyHost (new Uri("http://localhost:80/"))) {
				Console.Write ("Starting Nancy Host...");
				host.Start ();
				Console.WriteLine (" Done!");
				Console.Write ("Press any key to stop.");
				Console.ReadKey ();
			}
		}
	}
}
