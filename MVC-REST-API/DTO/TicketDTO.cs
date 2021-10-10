using FinalProject_Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.DTO
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public FlightDTO Flight { get; set; }
        public Customer Customer { get; set; }
    }
}
