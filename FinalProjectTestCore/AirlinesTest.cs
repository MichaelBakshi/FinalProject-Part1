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

        [TestInitialize]
        public void TryLogin()
        {
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("userName", "password", out loginToken);
            airlineFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<AirlineCompany>) as LoggedInAirlineFacade;
        }

        [TestMethod]
        public void GetFlightById()
        {
            Flight flight = airlineFacade.GetFlightById(1);
            Flight expectedFlight = new Flight(1, 1, 2, DateTime.Now, DateTime.Now, 5);
            Assert.AreEqual(flight, expectedFlight);  
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
                airlineFacade.GetAllFlights(null);
            });
        }
    }
}
