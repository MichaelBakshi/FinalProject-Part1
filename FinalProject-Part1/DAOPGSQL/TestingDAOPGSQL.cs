using Npgsql;
using FinalProject_Part1;
using System;
using System.Collections.Generic;
using System.Text;
using FinalProject_Part1.LogIn;

namespace FinalProject_Part1.DAOPGSQL
{
    public class TestingDAOPGSQL
    {
        private string test_conn_string;

        public TestingDAOPGSQL()
        {
            test_conn_string = TestingGlobalConfig.TestConnectionString;
        }


        public int ExecuteNonQuery(string query)
        {
            int result = 0;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(test_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;  //StoredProcedure instead of text
                    cmd.CommandText = query;

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
    }
}
