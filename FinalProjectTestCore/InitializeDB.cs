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
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("us", "123", "a@a.com", 1));
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("us", "123", "a@a.com", 2));
            administratorFacade.CreateUser(new LoginToken<Administrator>(), new User("us", "123", "a@a.com", 3));

            administratorFacade.CreateNewAirline(new LoginToken<Administrator>(), new AirlineCompany(
                "El-Al",1,1
                ));


            airlineFacade.CreateFlight(new LoginToken<AirlineCompany>(), new Flight(1, 1, 2, DateTime.Now, DateTime.Now, 5));

            // add flights

            // add customers

            // add tickets
        }
    }
}
