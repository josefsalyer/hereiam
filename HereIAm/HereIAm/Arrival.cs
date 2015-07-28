using System;
using System.Text.RegularExpressions;
using HereIAm.Dto;

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

		private VisitorManager _visitorManager;

		public Arrival(VisitorManager visitorManager)
		{
			if (visitorManager == null)
				throw new ArgumentNullException ("visitorManager");

			_visitorManager = visitorManager;
		}

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

		public void MarkAsArrived(Person visitor)
		{
			if (visitor == null)
				throw new ArgumentNullException ("visitor");

			_visitorManager.AddVisitor (visitor);
		}
	}
}

