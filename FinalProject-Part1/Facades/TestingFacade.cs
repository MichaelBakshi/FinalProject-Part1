using FinalProject_Part1.DAOPGSQL;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class TestingFacade
    {
        TestingDAOPGSQL testingDAOPGSQL = new TestingDAOPGSQL();

        public void ClearDB()
        {
            //call dao for sp which dletes all tables. exept caountries
            testingDAOPGSQL.ExecuteNonQuery($"call sp_delete_all_tables()");
        }
    }
}
