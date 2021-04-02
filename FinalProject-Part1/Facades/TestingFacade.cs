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

        //public int ExecuteNonQuery(string query)
        //{
        //    int result = 0;

        //    using (NpgsqlCommand cmd = new NpgsqlCommand())
        //    {
        //        using (cmd.Connection = new NpgsqlConnection(test_conn_string))
        //        {
        //            cmd.Connection.Open();
        //            cmd.CommandType = System.Data.CommandType.Text;  //StoredProcedure instead of text
        //            cmd.CommandText = query;

        //            result = cmd.ExecuteNonQuery();
        //        }
        //    }
        //    return result;
        //}
        public void ClearDB()
        {
            //call dao for sp which dletes all tables. exept caountries
            testingDAOPGSQL.ExecuteNonQuery($"call sp_delete_all_tables()");
        }
    }
}
