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
        public void GetAllCustomers()
        {
            Customer expectedCustomer = new Customer("customer_first_name", "customer_last_name", "customer_address", "customer_phone_no", "customer_credit_card_no", 3);
            List<Customer> list_of_customers = (List<Customer>)administratorFacade.GetAllCustomers(admin_token);
            List<Customer> expected_list_of_customers = null;
            expected_list_of_customers.Add(expectedCustomer);
            Assert.AreEqual(list_of_customers, expected_list_of_customers);
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
