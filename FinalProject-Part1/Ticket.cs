using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class Ticket : IPoco
    {
        public int Id { get; set; }
        public int Flight_Id { get; set; }
        public int Customer_Id { get; set; }
        public Flight flight { get; set; }
        public Customer customer { get; set; }

    public Ticket()
        {
                
        }

        public Ticket(int flight_Id, int customer_Id)
        {
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Ticket ticket &&
                   Id == ticket.Id &&
                   Flight_Id == ticket.Flight_Id &&
                   Customer_Id == ticket.Customer_Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Flight_Id, Customer_Id);
        }

        public static bool operator ==(Ticket left, Ticket right)
        {
            return EqualityComparer<Ticket>.Default.Equals(left, right);
        }

        public static bool operator !=(Ticket left, Ticket right)
        {
            return !(left == right);
        }

    }
}
