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
            throw new NotImplementedException();
        }

        public IList<AirlineCompany> GetAllAirlineCompanies()
        {
            throw new NotImplementedException();
        }
        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            throw new NotImplementedException();
        }
        public Flight GetFlightById(int id)
        {
            throw new NotImplementedException();
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
