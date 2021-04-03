using FinalProject_Part1;
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
        LoginToken<AirlineCompany> token;

        [TestInitialize]
        public void TryLogin()
        {
            ILoginToken loginToken;
             token= new LoginService().TryLogin("userName", "password", out token);
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
            List<Ticket> list_of_tickets = (List<Ticket>)airlineFacade.GetAllTickets();
            List<Ticket> expected_list_of_tickets = null;
            expected_list_of_tickets.Add(expectedTicket);
            Assert.AreEqual(list_of_tickets, expected_list_of_tickets);
        }

        [TestMethod]
        public void GetAllFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)airlineFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        // cancel flight
        [TestMethod]
        public void CancelFlight()
        {
            //Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            //List<Flight> list_of_flights = (List<Flight>)airlineFacade.CancelFlight();
            //Flight expected_cancelled_flight = null;
            //expected_list_of_flights.Remove(expectedFlight);
            //Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }




        //create flight
        [TestMethod]
        public void CreateFlight()
        {
            
                _flightDAO.Add(flight);
            
        }

        //change my password
        //modify airline details
        //update flight


    }
}
