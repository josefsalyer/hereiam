using System;
using System.Text.RegularExpressions;

namespace HereIAm
{
	public class Arrival
	{
		private const string VALID_ACK_MESSAGE = 
			@"Thank you, someone will be with you shortly.";
		private const string INVALID_ACK_MESSAGE =
			@"Stranger Danger!";
		private static readonly Regex _phonePattern = 
			new Regex (@"^\(?\d{3}\)?-? ?\d{3}-? ?-?\d{4}$");

		public bool ValidatePhoneNumber(string phoneNumber)
		{
			return _phonePattern.IsMatch (phoneNumber);
		}

		public string GenerateAcknowledgementResponse(bool isValidPhoneNumber)
		{
			if (isValidPhoneNumber)
				return VALID_ACK_MESSAGE;
			return INVALID_ACK_MESSAGE;
		}
	}
}

