using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Npgsql;

namespace FinalProjectTest
{
    [TestClass]
    public class UnitTest1
    {
        private int ExecuteNonQuery(string query)
        {
            int result = 0;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;  //StoredProcedure instead of text
                    cmd.CommandText = query;

                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }
        [TestMethod]
        public void Test_DeleteAll()
        {
            int result = ExecuteNonQuery($"call  sp_delete_administrator ({a.Id})");
        }
    }
}
