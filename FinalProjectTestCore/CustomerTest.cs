using FinalProject_Part1;
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


        }

        //get all my flights
        [TestMethod]
        public void GetAllMyFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)customerFacade.GetAllFlights(); // why there is no need for token here?
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        //purchase ticket


    }
}
