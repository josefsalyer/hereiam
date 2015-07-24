using System;

namespace HereIAm
{
	public class Arrival
	{
		public bool ValidatePhoneNumber(string phoneNumber)
		{
			if (phoneNumber.Length == 10)
				return true;
			return false;
		}
	}
}

