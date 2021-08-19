using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface IAnonymousUserFacade
    {
        IList<Flight> GetAllFlights();
        //IList<Country> GetAllCountries();
        IList<AirlineCompany> GetAllAirlineCompanies();
        Dictionary<Flight, int> GetAllFlightsVacancy();
        Flight GetFlightById(int id);
        IList<Flight> GetFlightsByOriginCountry(int countryCode);
        IList<Flight> GetFlightsByDestinationCountry(int countryCode);
        IList<Flight> GetFlightsByDepartureDate(DateTime departureDate);
        IList<Flight> GetFlightsByLandingDate(DateTime landingDate);
    }
}
