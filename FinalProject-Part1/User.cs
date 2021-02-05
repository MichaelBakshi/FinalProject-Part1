using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class User :IPoco
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int User_Role { get; set; }
        public User()
        {

        }

        public User(string username, string password, string email, int user_Role)
        {
            Username = username;
            Password = password;
            Email = email;
            User_Role = user_Role;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Username == user.Username &&
                   Password == user.Password &&
                   Email == user.Email &&
                   User_Role == user.User_Role;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Password, Email, User_Role);
        }

        public static bool operator ==(User left, User right)
        {
            return EqualityComparer<User>.Default.Equals(left, right);
        }

        public static bool operator !=(User left, User right)
        {
            return !(left == right);
        }
    }
}
