﻿using System;

namespace HereIAm.Dto
{
	public class Person : IEquatable<Person>
	{
		public string Id { get; set; }

		public string Name{ get; set; }

		public string PhoneNumber { get; set; } 

		public Person()
		{
		}

		public Person(String name, String phoneNumber, String id)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			Id = id;
		}

		public Person(String name, String phoneNumber)
		{
			Name = name;
			PhoneNumber = phoneNumber;
			Id = Guid.NewGuid ().ToString ();
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
			return Equals(obj as Person);
		}

		/// <inheritdoc />
		public bool Equals(Person other)
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

