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

        AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade(true);
        TestingFacade testingFacade = new TestingFacade();

        [TestInitialize]
        public void Init ()
        {
            GlobalConfig.GetConfiguration(true);
        }


        [TestMethod]
        public void GetFlightById()
        {
            Flight flight = anonymousUserFacade.GetFlightById(1);
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            Assert.AreEqual(flight, expectedFlight);
        }

        [TestMethod]
        public void GetAllFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights  = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>
            {
                expectedFlight
            };
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetAllAirlineCompanies()
        {
            AirlineCompany expected_airline_company = new AirlineCompany("airline_name", 3, 2);
            expected_airline_company.Id = 1;
            List<AirlineCompany> list_of_airline_companies = (List < AirlineCompany >) anonymousUserFacade.GetAllAirlineCompanies();
            List<AirlineCompany> expected_list_of_airlines = new List<AirlineCompany>();
            expected_list_of_airlines.Add(expected_airline_company);
            CollectionAssert.AreEqual(list_of_airline_companies, expected_list_of_airlines);
        }

        [TestMethod]
        public void GetAllFlightsVacancy()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            Dictionary<Flight, int> flights_vacancy = anonymousUserFacade.GetAllFlightsVacancy();
            Dictionary<Flight, int> expected_flights_vacancy = new Dictionary<Flight, int>();
            expected_flights_vacancy.Add(expectedFlight, 1);
            CollectionAssert .AreEqual(flights_vacancy, expected_flights_vacancy);
        }

        [TestMethod]
        public void GetFlightsByDepartureDate()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByLandingDate()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByOriginCountry()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetFlightsByDestinationCountry()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights = (List<Flight>)anonymousUserFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

    }
}
