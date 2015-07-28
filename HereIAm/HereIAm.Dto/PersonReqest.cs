using System;

namespace HereIAm.Dto
{
	public class PersonReqest : IEquatable<PersonReqest>
	{
		public string Name
		{
			get { return _name; }
			set {
				if (String.IsNullOrWhiteSpace (value))
					throw new ArgumentException ("Error: Blank Name");
				_name = value;
			}
		}
		public string PhoneNumber { get; set; } 

		private string _name;

		public PersonReqest()
		{
		}

		public PersonReqest (string name, string phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;
		}

		#region IEquatable implementation

		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hash = 0;
			hash ^= (Name != null) ? Name.GetHashCode() : 0;
			hash ^= (PhoneNumber != null) ? PhoneNumber.GetHashCode() : 0;
			return hash;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return Equals(obj as PersonReqest);
		}

		/// <inheritdoc />
		public bool Equals(PersonReqest other)
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
			return equals;
		}

		#endregion
	}
}

