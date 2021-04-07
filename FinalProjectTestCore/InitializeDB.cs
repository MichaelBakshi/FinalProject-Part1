using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class InitializeDB
    {
        TestingFacade testingFacade = new TestingFacade();
        LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade(true);
        LoggedInAdministratorFacade administratorFacade = new LoggedInAdministratorFacade(true);
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade(true);

        [TestInitialize]
        public void InitDB()
        {
            GlobalConfig.GetConfiguration(true);
            testingFacade.ClearDB();
        }

        [TestMethod]
        public void InsertData()
        {
            LoginToken<Administrator> adminToken = new LoginToken<Administrator>()
            {
                User = new Administrator("admin", "monro", 3, 500)
            };
            
            administratorFacade.CreateUser(adminToken, new User("admin_username", "admin_password", "admin_email", 1));
            administratorFacade.CreateUser(adminToken, new User("airline_username", "airline_passsword", "airline_email", 2));
            administratorFacade.CreateUser(adminToken, new User("customer_username", "customer_password", "customer_email", 3));

            administratorFacade.CreateAdmin(adminToken, new Administrator("adminfirst_name", "admin_last_name", 1, 1));
            administratorFacade.CreateNewAirline(adminToken, new AirlineCompany("airline_name", 3, 2));
            administratorFacade.CreateNewCustomer(adminToken, new Customer("customer_first_name", "customer_last_name", "customer_address", "customer_phone_no", "customer_credit_card_no", 3));

            airlineFacade.CreateFlight(new LoginToken<AirlineCompany>(), new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1));
            administratorFacade.CreateTicket(adminToken, new Ticket(1, 1));

        }
    }
}
