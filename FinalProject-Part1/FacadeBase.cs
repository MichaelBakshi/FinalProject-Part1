using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public abstract class FacadeBase
    {

        protected IAirlineDAO _airlineDAO;
        protected CountryDAOPGSQL _countryDAO;
        protected CustomerDAOPGSQL _customerDAO;
        protected FlightDAOPGSQL _flightDAO;
        protected TicketDAOPGSQL _ticketDAO;
    }
}
