using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class Customer : IPoco, IUser
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Credit_Card_No { get; set; }
        public int User_Id { get; set; }
        public User user { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Customer()
        {
                
        }

        public Customer( string first_Name, string last_Name, string address, string phone_No, string credit_Card_No, int user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Address = address;
            Phone_No = phone_No;
            Credit_Card_No = credit_Card_No;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id;
        }

        public override int GetHashCode()
        {
            return this.Id;
        }

        public static bool operator ==(Customer left, Customer right)
        {
            return EqualityComparer<Customer>.Default.Equals(left, right);
        }

        public static bool operator !=(Customer left, Customer right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Id: {Id}, First_Name: {First_Name}, Last_Name: {Last_Name}, Address: {Address}, Phone_No: {Phone_No}, Credit_Card_No: {Credit_Card_No}, User_Id: {User_Id}, " +
                $"User: {user} ";
        }
    }
}
