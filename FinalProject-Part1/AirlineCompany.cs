using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class AirlineCompany : IPoco, IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
        public int User_Id { get; set; }
        public User user { get; set; }


        public AirlineCompany()
        {

        }
        public AirlineCompany(string name, int country_Id, int user_Id)
        {
            Name = name;
            Country_Id = country_Id;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is AirlineCompany company &&
                   Id == company.Id &&
                   Name == company.Name &&
                   Country_Id == company.Country_Id &&
                   User_Id == company.User_Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Country_Id, User_Id);
        }

        public static bool operator ==(AirlineCompany left, AirlineCompany right)
        {
            return EqualityComparer<AirlineCompany>.Default.Equals(left, right);
        }

        public static bool operator !=(AirlineCompany left, AirlineCompany right)
        {
            return !(left == right);
        }
    }
}
