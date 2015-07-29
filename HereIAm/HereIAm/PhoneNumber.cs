using System;
using System.Text.RegularExpressions;

namespace HereIAm
{
	public class PhoneNumber
	{
		private static readonly Regex _phonePattern = 
			new Regex (@"^\(?\d{3}\)?-? ?\d{3}-? ?-?\d{4}$");

		private string _phoneNumber;

		public PhoneNumber (string phoneNumber)
		{
			if (phoneNumber == null)
				throw new ArgumentNullException ("phoneNumber");

			if (!_phonePattern.IsMatch (phoneNumber))
				throw new ArgumentException ("Bad phone number");
				
			_phoneNumber = phoneNumber;
		}
	}
}

