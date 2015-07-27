using System;

namespace HereIAm.Dto
{
	public class Visitor : IEquatable<Visitor>
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; } 

		public Visitor (string name, string phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;
		}

		#region IEquatable implementation

		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hash = 0;
			hash ^= Name.GetHashCode();
			hash ^= PhoneNumber.GetHashCode();
			return hash;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return Equals(obj as Visitor);
		}

		/// <inheritdoc />
		public bool Equals(Visitor other)
		{
			if (other == null)
				return false;

			var equals = true;
			equals &= Name.Equals(other.Name);
			equals &= PhoneNumber.Equals(other.PhoneNumber);
			return equals;
		}

		#endregion
	}
}

