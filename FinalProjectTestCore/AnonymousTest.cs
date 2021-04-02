using FinalProject_Part1;
using FinalProject_Part1.DAOPGSQL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AnonymousTest
    {
        //FlightDAOPGSQL flightDAOPGSQL = new FlightDAOPGSQL();
        //TestingDAOPGSQL testingDAOPGSQL = new TestingDAOPGSQL();
        AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade();
        TestingFacade testingFacade = new TestingFacade();

        [TestInitialize]
        public void ClearDB ()
        {
            testingFacade.ClearDB();
        }

        

        [TestInitialize]
        public void InsertData()
        {
            Flight flight = new Flight();
            anonymousUserFacade.GetFlightById();
            
        }
    }
}
