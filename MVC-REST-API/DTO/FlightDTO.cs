using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.DTO
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string Origin_Country_Name { get; set; }
        public string Destination_Country_Name { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        public int Remaining_Tickets { get; set; }
        public AirlineDTO airlineCompany { get; set; }

    }
}
