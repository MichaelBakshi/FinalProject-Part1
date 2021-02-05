using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class Administrator : IPoco, IUser
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Level { get; set; }
        public int User_Id { get; set; }
        public User user { get; set; }

        public Administrator()
        {

        }

        public Administrator( string first_Name, string last_Name, int level, int user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Level = level;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   Id == administrator.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public static bool operator ==(Administrator administrator1, Administrator administrator2)
        {
            if (object.ReferenceEquals(administrator1, null) && object.ReferenceEquals(administrator2, null))
                return true;
            if (object.ReferenceEquals(administrator1, null) || object.ReferenceEquals(administrator2, null))
                return false;
            return administrator1.Id == administrator2.Id;
        }

        public static bool operator !=(Administrator administrator1, Administrator administrator2)
        {
            return !(administrator1 == administrator2);
        }

        public override string ToString()
        {
            return $"Id: {Id}, First name: {First_Name}, Last name: {Last_Name}, Level: {Level}, User ID: {User_Id} ";
        }
    }
}
