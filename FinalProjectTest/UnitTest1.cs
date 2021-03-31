using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Npgsql;

namespace FinalProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        //FlightDAOPGSQL
        [TestMethod]
        public void Test_DeleteAll()
        {
            int result = ($"call  sp_delete_administrator ({a.Id})");
        }
    }
}
