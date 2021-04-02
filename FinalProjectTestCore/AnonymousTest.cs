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
        //FlightDAOPGSQL flightDAOPGSQL = new FlightDAOPGSQL();
        //TestingDAOPGSQL testingDAOPGSQL = new TestingDAOPGSQL();
        AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade();
        TestingFacade testingFacade = new TestingFacade();

        [TestInitialize]
        public void ClearDB ()
        {
            testingFacade.ClearDB();
        }

        

        //[TestInitialize]
        //public void InsertData()
        //{
        //    Flight flight = new Flight();
        //    anonymousUserFacade.GetFlightById();
            
        //}

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
            List<Flight> expected_list_of_flights=null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        [TestMethod]
        public void GetAllAirlineCompanies()
        {
            
        }

        [TestMethod]
        public void GetAllFlightsVacancy()
        {

        }
    }
}
