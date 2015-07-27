using System;

namespace HereIAm
{
	public class VisitorEventArgs : EventArgs
	{
		public string PhoneNumber {	get; }

		public VisitorEventArgs(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}

