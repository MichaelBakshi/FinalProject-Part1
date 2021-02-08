using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class Flight : IPoco
    {
        public int Id { get; set; }
        public int Airline_Company_Id { get; set; }
        public int Origin_Country_Id { get; set; }
        public int Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        public int Remaining_Tickets { get; set; }
        public AirlineCompany airlineCompany { get; set; }

        public Flight()
        {

        }

        public Flight(int airline_Company_Id, int origin_Country_Id, int destination_Country_Id, DateTime departure_Time, DateTime landing_Time, int remaining_Tickets)
        {
            Airline_Company_Id = airline_Company_Id;
            Origin_Country_Id = origin_Country_Id;
            Destination_Country_Id = destination_Country_Id;
            Departure_Time = departure_Time;
            Landing_Time = landing_Time;
            Remaining_Tickets = remaining_Tickets;
        }

        public override bool Equals(object obj)
        {
            return obj is Flight flight &&
                   Id == flight.Id &&
                   Airline_Company_Id == flight.Airline_Company_Id &&
                   Origin_Country_Id == flight.Origin_Country_Id &&
                   Destination_Country_Id == flight.Destination_Country_Id &&
                   Departure_Time == flight.Departure_Time &&
                   Landing_Time == flight.Landing_Time &&
                   Remaining_Tickets == flight.Remaining_Tickets;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Airline_Company_Id, Origin_Country_Id, Destination_Country_Id, Departure_Time, Landing_Time, Remaining_Tickets);
        }

        public static bool operator ==(Flight left, Flight right)
        {
            return EqualityComparer<Flight>.Default.Equals(left, right);
        }

        public static bool operator !=(Flight left, Flight right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Id: {Id}, Airline_Company_Id: {Airline_Company_Id}, Origin_Country_Id: {Origin_Country_Id}, Destination_Country_Id: {Destination_Country_Id}, " +
                $"Departure_Time: {Departure_Time}, Landing_Time: {Landing_Time}, Remaining_Tickets: {Remaining_Tickets}, AirlineCompany: { airlineCompany}  ";
        }
    }
}
