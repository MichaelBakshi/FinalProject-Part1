﻿using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class CustomerTest
    {
        LoggedInCustomerFacade customerFacade;
        LoggedInAdministratorFacade administratorFacade;
        LoggedInAirlineFacade airlineFacade;
        AnonymousUserFacade anonymousUserFacade;
        LoginToken<Customer> customer_token;

        [TestInitialize]
        public void TryLogin()
        {
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("userName", "password", out loginToken);
            customerFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<Customer>) as LoggedInCustomerFacade;
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

        //cancel ticket
        [TestMethod]
        public void CancelTicket()
        {
            Ticket ticket = customerFacade.GetTicketById(1);
            customerFacade.CancelTicket(customer_token, ticket);
            Ticket cancelled_ticket = customerFacade.GetTicketById(1);
            Assert.IsNull(cancelled_ticket);
        }

        //get all my flights
        [TestMethod]
        public void GetAllMyFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            List<Flight> list_of_flights = (List<Flight>)customerFacade.GetAllFlights(); // why there is no need for token here?
            List<Flight> expected_list_of_flights = new List<Flight>();
            expected_list_of_flights.Add(expectedFlight);
            CollectionAssert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        //purchase ticket
        [TestMethod]
        public void PurchasTicket()
        {
            Flight additionalFlight = new Flight(1, 1, 1, new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 1);
            additionalFlight.Id = 2;
            customerFacade.PurchaseTicket(customer_token, additionalFlight); 
            Flight new_flight = airlineFacade.GetFlightById(2);
            Assert.AreEqual(additionalFlight, new_flight);
        }

    }
}
