using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public abstract class FacadeBase
    {
        AirlineDAOPGSQL _airlineDAO;
        CountryDAOPGSQL _countryDAO;
        CustomerDAOPGSQL _customerDAO;
        FlightDAOPGSQL _flightDAO;
        TicketDAOPGSQL _ticketDAO;
    }
}
