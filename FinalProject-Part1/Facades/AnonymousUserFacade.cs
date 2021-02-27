using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        
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
            throw new NotImplementedException();
        }
        public Flight GetFlightById(int id)
        {
            return _flightDAO.GetById(id);
        }
        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }
        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }
        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            return _flightDAO.GetFlightsByDepartureDate(departureDate);
        }
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }
    }
}
