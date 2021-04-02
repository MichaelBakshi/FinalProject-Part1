using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    class InitializeDB
    {
        TestingFacade testingFacade = new TestingFacade();
        LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade();
        LoggedInAdministratorFacade administratorFacade = new LoggedInAdministratorFacade();

        [TestInitialize]
        public void ClearDB()
        {
            testingFacade.ClearDB();
        }

        [TestInitialize]
        public void InsertData()
        {
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("admin_username", "admin_password", "admin_email", 1));
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("airline_username", "airline_passsword", "airline_email", 2));
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("customer_username", "customer_password", "customer_email", 3));

            administratorFacade.CreateAdmin(new LoginToken<Administrator>(), new Administrator("adminfirst_name", "admin_last_name", 1, 1));
            administratorFacade.CreateNewAirline(new LoginToken<Administrator>(), new AirlineCompany("airline_name", 3, 2));
            administratorFacade.CreateNewCustomer(new LoginToken<Administrator>(), new Customer("customer_first_name", "customer_last_name", "customer_address", "customer_phone_no", "customer_credit_card_no", 3));


            airlineFacade.CreateFlight(new LoginToken<AirlineCompany>(), new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1));
            administratorFacade.CreateTicket(new LoginToken<Administrator>(), new Ticket(1, 1));

        }
    }
}
