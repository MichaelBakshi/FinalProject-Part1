﻿using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AirlinesTest
    {
        LoggedInAirlineFacade airlineFacade;
        AnonymousUserFacade anonymousUserFacade;
        LoginToken<AirlineCompany> airlineToken;
        

        [TestInitialize]
        public void TryLogin()
        {
            GlobalConfig.GetConfiguration(true);
            ILoginToken loginToken;
            new LoginService().TryLogin("airline_username", "airline_passsword", out loginToken);
            airlineToken = (LoginToken<AirlineCompany>)loginToken;
            airlineFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<AirlineCompany>) as LoggedInAirlineFacade;
        }



        [TestMethod]
        //[ExpectedException()]
        public void CheckNullToken()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.CancelFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.GetAllTickets(null);
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.CreateFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.UpdateFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.ChangeMyPassword(null, "old_password", "new_password");
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.MofidyAirlineDetails(null, new AirlineCompany());
            });
        }

        [TestMethod]
        public void GetAllTickets()
        {
            Ticket expectedTicket = new Ticket(1, 1);
            expectedTicket.Id = 1;
            List<Ticket> list_of_tickets = (List<Ticket>)airlineFacade.GetAllTickets(airlineToken);
            List<Ticket> expected_list_of_tickets = new List<Ticket>();
            expected_list_of_tickets.Add(expectedTicket);
            CollectionAssert.AreEqual(list_of_tickets, expected_list_of_tickets);
        }

        [TestMethod]
        public void GetAllFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime (2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            List<Flight> list_of_flights = (List<Flight>)airlineFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        // cancel flight
        [TestMethod]
        public void CancelFlight()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            expectedFlight.Id = 1;
            airlineFacade.CancelFlight(airlineToken, expectedFlight);
            Flight expected_cancelled_flight = airlineFacade.GetFlightById(1);
            Assert.AreNotEqual(expectedFlight, expected_cancelled_flight);

        }


        //create flight
        [TestMethod]
        public void CreateFlight()
        {
            Flight additionalFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            additionalFlight.Id = 2;
            // insert and assume ai resets
            airlineFacade.CreateFlight(airlineToken, additionalFlight); // assume new id is 2
            Flight new_flight = airlineFacade.GetFlightById(2);
            Assert.AreEqual(additionalFlight, new_flight);
        }

        //change my password
        [TestMethod]
        public void ChangeMyPassword()
        {
            AirlineCompany airline_before_modification = airlineFacade.GetAirlineById(1);
            string old_password = airline_before_modification.user.Password;
            airlineFacade.ChangeMyPassword(airlineToken, "airline_passsword", "new_airline_passsword");
            string new_password = "new_airline_passsword";
            Assert.AreNotEqual(old_password, new_password);
        }

        //modify airline details
        [TestMethod]
        public void Modify_airline_details()
        {
            AirlineCompany airline = new AirlineCompany("Delta", 5, 2);
            airline.Id = 1;
            airlineFacade.MofidyAirlineDetails(airlineToken,airline);
            AirlineCompany airline_before_modification = airlineFacade.GetAirlineById(1);
            Assert.AreEqual(airline, airline_before_modification);
        }

        //update flight
        [TestMethod]
        public void Modify_flight_details()
        {
            Flight additionalFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 20);
            additionalFlight.Id = 1;
            airlineFacade.UpdateFlight(airlineToken,additionalFlight);
            Flight flight_before_modification = airlineFacade.GetFlightById(1);
            Assert.AreEqual(additionalFlight, flight_before_modification);
        }

    }
}
