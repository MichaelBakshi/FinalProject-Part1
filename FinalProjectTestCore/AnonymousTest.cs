using FinalProject_Part1;
using FinalProject_Part1.DAOPGSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AnonymousTest
    {

        AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade();
        TestingFacade testingFacade = new TestingFacade();

        [TestInitialize]
        public void ClearDB ()
        {
            testingFacade.ClearDB();
        }


        [TestMethod]
        public void GetFlightById()
        {
            Flight flight = anonymousUserFacade.GetFlightById(1);
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            Assert.AreEqual(flight, expectedFlight);
        }

        [TestMethod]
        public void GetAllFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights  = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>
            {
                expectedFlight
            };
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetAllAirlineCompanies()
        {
            AirlineCompany expected_airline_company = new AirlineCompany("airline_name", 3, 2);
            List<AirlineCompany> list_of_airline_companies = (List < AirlineCompany >) anonymousUserFacade.GetAllAirlineCompanies();
            List<AirlineCompany> expected_list_of_airlines = null;
            expected_list_of_airlines.Add(expected_airline_company);
            Assert.AreEqual(list_of_airline_companies, expected_list_of_airlines);
        }

        [TestMethod]
        public void GetAllFlightsVacancy()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            Dictionary<Flight, int> flights_vacancy = anonymousUserFacade.GetAllFlightsVacancy();
            Dictionary<Flight, int> expected_flights_vacancy = null;
            expected_flights_vacancy.Add(expectedFlight, 1);
            Assert.AreEqual(flights_vacancy, expected_flights_vacancy);
        }

        [TestMethod]
        public void GetFlightsByDepartureDate()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByLandingDate()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByOriginCountry()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByDestinationCountry()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

    }
}
