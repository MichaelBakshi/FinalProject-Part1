using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AdministratorTest
    {
        LoggedInAdministratorFacade administratorFacade;
        LoggedInAirlineFacade airlineFacade;
        AnonymousUserFacade anonymousUserFacade;
        LoginToken<Administrator> admin_token;

        [TestInitialize]
        public void TryLogin()
        {
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("userName", "password", out loginToken);
            administratorFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<Administrator>) as LoggedInAdministratorFacade;
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



        //get all customers
        [TestMethod]
        public void GetAllTickets()
        {
            Ticket expectedTicket = new Ticket(1, 1);
            List<Ticket> list_of_tickets = (List<Ticket>)airlineFacade.GetAllTickets(airlineToken);
            List<Ticket> expected_list_of_tickets = null;
            expected_list_of_tickets.Add(expectedTicket);
            Assert.AreEqual(list_of_tickets, expected_list_of_tickets);
        }


        //create new airline
        //create new customer
        //remove airline
        //remove customer
        //update airline details
        //update customer details
        //create admin
        //update admin
        //remove admin
    }
}
