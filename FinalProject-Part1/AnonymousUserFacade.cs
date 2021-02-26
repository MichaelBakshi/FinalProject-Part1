using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade
    {
        
        //public List<AirlineCompany> GetAllAirlines()
        //{
            
        //    throw new NotImplementedException();
        //    //_airlineDAO 

        //}
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
            throw new NotImplementedException();
        }
        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            throw new NotImplementedException();
        }
        public IList<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            throw new NotImplementedException();
        }
        public IList<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            throw new NotImplementedException();
        }
    }
}
