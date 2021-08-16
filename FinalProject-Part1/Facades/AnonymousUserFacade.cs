using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject_Part1
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        public AnonymousUserFacade(bool testMode) : base(testMode)
        {
            GlobalConfig.GetConfiguration(testMode);
        }
        public IList<Flight> GetAllFlights()
        {
            return _flightDAO.GetAll();
        }

        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            return _airlineDAO.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            return _flightDAO.GetAllFlightsVacancy();
        }
        public Flight GetFlightById(int id)
        {
            return _flightDAO.GetById(id);
        }
        public AirlineCompany GetAirlineById(int id)
        { 
                return _airlineDAO.GetById(id);
        }
        public Customer GetCustomerById(int id)
        {
            return _customerDAO.GetById(id);
        }
        public Administrator GetAdminById(int id)
        {
            return _adminDAO.GetById(id);
        }
        public Ticket GetTicketById(int id)
        {
            return _ticketDAO.GetById(id);
        }

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }
        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }
        public IList<Flight> GetFlightsByDepartureDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightsByDepartureDate(departureDate);
        }
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }


        public void SignUp(Customer customer)
        {
            _userDAO.Add(customer.user);
            customer.User_Id = _userDAO.GetAll().OrderByDescending(x => x.Id).ToList()[0].Id;
            _customerDAO.Add(customer);
        }
      

    }
}
