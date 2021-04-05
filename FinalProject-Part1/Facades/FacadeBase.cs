using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public abstract class FacadeBase
    {
        protected IAirlineDAO _airlineDAO = new AirlineDAOPGSQL();
        protected ICountryDAO _countryDAO = new CountryDAOPGSQL();
        protected ICustomerDAO _customerDAO = new CustomerDAOPGSQL();
        protected IAdminDAO _adminDAO = new AdminDAOPGSQL();
        protected IUserDAO _userDAO = new UserDAOPGSQL();
        protected IFlightDAO _flightDAO = new FlightDAOPGSQL();
        protected ITicketDAO _ticketDAO = new TicketDAOPGSQL();

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
