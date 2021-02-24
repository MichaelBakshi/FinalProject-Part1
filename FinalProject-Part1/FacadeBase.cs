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

        protected FacadeBase()
        {
            _airlineDAO = new AirlineDAOPGSQL("" );
            _countryDAO = new CountryDAOPGSQL("");
            _customerDAO = new CustomerDAOPGSQL("");
            _flightDAO = new FlightDAOPGSQL("");
            _ticketDAO = new TicketDAOPGSQL("");
        }

    }
}
