using System;

namespace HereIAm
{
	public class PersonManager
	{
		public void Create(string name, string phoneNumber)
		{
			if (String.IsNullOrWhiteSpace (name))
				throw new ArgumentException ("Bad name", "name");
		}
	}
}

