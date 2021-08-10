using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1.DAOPGSQL
{
    public class Airlines_Waiting_For_ConfirmationDAOPGSQL
    {
        private string m_conn_string;

        public Airlines_Waiting_For_ConfirmationDAOPGSQL()
        {
            m_conn_string = GlobalConfig.GetConnectionString();
        }


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

        public void Add(AirlineCompany a)
        {

            ExecuteNonQuery($"call sp_insert_airline_to_confirmation_list('{a.Name}', {a.Country_Id}, {a.User_Id});");
        }

            //UserDAOPGSQL userDAOPGSQL = new UserDAOPGSQL();
            //result.user = userDAOPGSQL.GetById(result.User_Id);

        public void Remove(AirlineCompany airline)
        {
            int result = ExecuteNonQuery($"call  sp_delete_airline_company_from_confirmation_list ({airline.Id})");
        }

    }
}
