using System;

namespace HereIAm.Dto
{
	public class Visitor : IEquatable<Visitor>
	{
		public string Name { get; set; }
		public string PhoneNumber { get; set; } 
		public string ForHost { get; set; } 

		public Visitor()
		{
		}

		public Visitor (string name, string phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			ForHost = null;
		}

		public Visitor (string name, string phoneNumber, string forHost)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			ForHost = forHost;
		}

		#region IEquatable implementation

		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hash = 0;
			hash ^= (Name != null) ? Name.GetHashCode() : 0;
			hash ^= (PhoneNumber != null) ? PhoneNumber.GetHashCode() : 0;
			hash ^= (ForHost != null) ? ForHost.GetHashCode () : 0;
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
			equals &= (Name != null) ? 
				Name.Equals(other.Name) : 
				Name == other.Name;
			equals &= (PhoneNumber != null) ? 
				PhoneNumber.Equals(other.PhoneNumber) : 
				PhoneNumber == other.PhoneNumber;
			equals &= (ForHost != null) ? 
				ForHost.Equals(other.ForHost) : 
				ForHost == other.ForHost;
			return equals;
		}

		#endregion
	}
}

