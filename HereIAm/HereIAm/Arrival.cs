using System;
using System.Text.RegularExpressions;

namespace HereIAm
{
	public class Arrival
	{
		private static readonly Regex _phonePattern = new Regex (@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

		public bool ValidatePhoneNumber(string phoneNumber)
		{
			return _phonePattern.IsMatch (phoneNumber);
		}
	}
}

