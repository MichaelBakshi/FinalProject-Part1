using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalProjectTestCore
{
    [TestClass]
    public class FlightsTest
    {
        FlightDAOPGSQL flightDAOPGSQL = new FlightDAOPGSQL();

        [TestInitialize]
        public void ClearDB ()
        {
            //call dao for sp which dletes all tables. exept caountries
            TestingDAOPGSQL.ExecuteNonQuery($"call sp_delete_all_tables()");
        }

        [TestInitialize]
        public void TryLogin()
        {
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("user", "pass", out loginToken);
            LoggedInAirlineFacade facade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<AirlineCompany>) as LoggedInAirlineFacade;
        }

        [TestMethod]
        public void GetFlightById()
        {
            Flight flight = new Flight();
            flightDAOPGSQL.Add(flight); //change conn string to point to testdb
            
        }
    }
}
