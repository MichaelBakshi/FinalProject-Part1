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
            GlobalConfig.GetConfiguration(true);
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("admin_username", "admin_password", out loginToken);
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


        [TestMethod]
        public void GetAllCustomers()
        {
            Customer expectedCustomer = new Customer("customer_first_name", "customer_last_name", "customer_address", "customer_phone_no", "customer_credit_card_no", 3);
            List<Customer> list_of_customers = (List<Customer>)administratorFacade.GetAllCustomers(admin_token);
            List<Customer> expected_list_of_customers = new List<Customer>() ;
            expected_list_of_customers.Add(expectedCustomer);
            CollectionAssert.AreEqual(list_of_customers, expected_list_of_customers);
        }


        //create new airline
        [TestMethod]
        public void CreateAirline()
        {
            AirlineCompany additionalAirline = new AirlineCompany("second_airline_name", 1, 4);
            additionalAirline.Id = 2;
            administratorFacade.CreateNewAirline(admin_token, additionalAirline);
            AirlineCompany second_airline = administratorFacade.GetAirlineById(2);
            Assert.AreEqual(additionalAirline, second_airline);

        }


        //create new customer
        [TestMethod]
        public void CreateCustomer()
        {
            Customer additionalCustomer = new Customer("2customer_first_name", "2customer_last_name", "2customer_address", "2customer_phone_no", "2customer_credit_card_no", 4);
            additionalCustomer.Id = 2;
            administratorFacade.CreateNewCustomer(admin_token, additionalCustomer);
            Customer second_customer = administratorFacade.GetCustomerById(2);
            Assert.AreEqual(additionalCustomer, second_customer);
        }


        //remove airline
        [TestMethod]
        public void RemoveAirline()
        {
            AirlineCompany airline = administratorFacade.GetAirlineById(1);
            administratorFacade.RemoveAirline(admin_token, airline);
            AirlineCompany removed_airline = administratorFacade.GetAirlineById(1);
            Assert.IsNull(removed_airline);

        }
        //remove customer
        [TestMethod]
        public void RemoveCustomer()
        {
            Customer customer = administratorFacade.GetCustomerById(1);
            administratorFacade.RemoveCustomer(admin_token, customer);
            Customer removed_customer = administratorFacade.GetCustomerById(1);
            Assert.IsNull(removed_customer);            
        }

        //remove admin
        [TestMethod]
        public void RemoveAdmin()
        {
            Administrator admin = administratorFacade.GetAdminById(1);
            administratorFacade.RemoveAdmin(admin_token, admin);
            Administrator removed_administrator = administratorFacade.GetAdminById(1);
            Assert.IsNull(removed_administrator);

        }

        //update airline details
        [TestMethod]
        public void Modify_airline_details()
        {
            AirlineCompany airline = new AirlineCompany("Delta", 5, 2);
            airline.Id = 1;
            administratorFacade.UpdateAirlineDetails(admin_token, airline);
            AirlineCompany airline_before_modification = airlineFacade.GetAirlineById(1);
            Assert.AreNotEqual(airline, airline_before_modification);
        }

        //update customer details
        [TestMethod]
        public void Update_customer_details()
        {
            Customer customer = new Customer("2customer_first_name", "2customer_last_name", "2customer_address", "2customer_phone_no", "2customer_credit_card_no", 4);
            customer.Id = 1;
            administratorFacade.UpdateCustomerDetails(admin_token, customer);
            Customer customer_before_modification = administratorFacade.GetCustomerById(1);
            Assert.AreEqual(customer, customer_before_modification);
        }

        //create admin
        [TestMethod]
        public void CreateAdmin()
        {
            Administrator additionalAdmin = new Administrator("adminfirst_name", "admin_last_name", 1, 1);
            additionalAdmin.Id = 2;
            administratorFacade.CreateAdmin(admin_token, additionalAdmin);
            Administrator second_admin = administratorFacade.GetAdminById(2);
            Assert.AreEqual(additionalAdmin, second_admin);
        }

        //update admin
        [TestMethod]
        public void Update_admin_details()
        {
            Administrator admin = new Administrator("2adminfirst_name", "2admin_last_name", 1, 1);
            admin.Id = 1;
            administratorFacade.UpdateAdmin(admin_token, admin);
            Administrator admin_before_modification = administratorFacade.GetAdminById(1);
            Assert.AreEqual(admin, admin_before_modification);
        }

        
    }
}
