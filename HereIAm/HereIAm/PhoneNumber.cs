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

		public override string ToString ()
		{
			var normalized = _phoneNumber;

			switch (normalized.Length) 
			{
			case 12:
				normalized = normalized.Replace ("-", String.Empty);
				normalized = normalized.Replace (" ", String.Empty);
				break;
			case 13:
				normalized = normalized.Replace ("(", String.Empty);
				normalized = normalized.Replace (")", String.Empty);
				normalized = normalized.Replace ("-", String.Empty);
				break;
			case 14:
				normalized = normalized.Replace ("(", String.Empty);
				normalized = normalized.Replace (")", String.Empty);
				normalized = normalized.Replace (" ", String.Empty);
				normalized = normalized.Replace ("-", String.Empty);
				break;
			}
				
			return normalized;
		}

		#region IEquatable implementation

		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hash = 0;
			hash ^= ToString().GetHashCode ();
			return hash;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return Equals(obj as PhoneNumber);
		}

		/// <inheritdoc />
		public bool Equals(PhoneNumber other)
		{
			if (other == null)
				return false;

			var equals = true;
			equals &= ToString().Equals (other.ToString());
			return equals;
		}

		#endregion


	}
}

