using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public abstract class FacadeBase
    {
        protected IAirlineDAO _airlineDAO;
        protected ICountryDAO _countryDAO;
        protected ICustomerDAO _customerDAO;
        protected IAdminDAO _adminDAO;
        protected IUserDAO _userDAO;
        protected IFlightDAO _flightDAO;
        protected ITicketDAO _ticketDAO;

        //protected FacadeBase()
        //{
        //    _airlineDAO = new AirlineDAOPGSQL("" );
        //    _countryDAO = new CountryDAOPGSQL("");
        //    _customerDAO = new CustomerDAOPGSQL("");
        //    _flightDAO = new FlightDAOPGSQL("");
        //    _ticketDAO = new TicketDAOPGSQL("");
        //}
        //it's better to put connection string in configuration file. json, for example
    }
}
