using System;
using Nancy.Hosting.Self;
using HereIAm;

namespace HereIAm.SelfHost
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			using (var host = new NancyHost (new Uri("http://localhost:8080/"))) {
				Console.Write ("Starting Nancy Host...");
				host.Start ();
				Console.WriteLine (" Done!");
				Console.Write ("Press any key to stop.");
				Console.ReadKey ();

			}
		}
	}
}
