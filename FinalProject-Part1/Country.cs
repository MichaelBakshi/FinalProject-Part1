using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class Country : IPoco
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Country()
        {
                
        }

        public Country(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Country country &&
                   Id == country.Id &&
                   Name == country.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }

        public static bool operator ==(Country left, Country right)
        {
            return EqualityComparer<Country>.Default.Equals(left, right);
        }

        public static bool operator !=(Country left, Country right)
        {
            return !(left == right);
        }
    }
}
