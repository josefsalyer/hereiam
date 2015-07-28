using System;

namespace HereIAm
{
	public class VisitorEventArgs : EventArgs
	{
		public string PhoneNumber {	get; private set; }

		public VisitorEventArgs(string phoneNumber)
		{
			PhoneNumber = phoneNumber;
		}
	}
}

