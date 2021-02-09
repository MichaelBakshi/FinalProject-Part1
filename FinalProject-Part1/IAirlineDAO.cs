using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{

    interface IAirlineDAO : IBasicDb<AirlineCompany>
    {

        //public AirlineCompany GetAirlineByCountry(string _name)
        //{
        //    AirlineCompany result = null;

        //    using (NpgsqlCommand cmd = new NpgsqlCommand())
        //    {
        //        using (cmd.Connection = new NpgsqlConnection(m_conn_string))
        //        {
        //            cmd.Connection.Open();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = $"select * from sp_get_airline_by_country({_name})";

        //            NpgsqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                result = new AirlineCompany
        //                {
        //                    Id = (int)reader["id"],
        //                    Name = reader["name"].ToString(),
        //                    Country_Id = (int)reader["country_id"],
        //                    User_Id = (int)reader["user_id"],

        //                };
        //            }
        //        }
        //    }
        //    return result;
        //}

        //public AirlineCompany GetAirlineByUsername(string _name)
        //{
        //    AirlineCompany result = null;

        //    using (NpgsqlCommand cmd = new NpgsqlCommand())
        //    {
        //        using (cmd.Connection = new NpgsqlConnection(m_conn_string))
        //        {
        //            cmd.Connection.Open();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = $"select * from sp_get_airline_by_username({_name})";

        //            NpgsqlDataReader reader = cmd.ExecuteReader();

        //            if (reader.Read())
        //            {
        //                result = new AirlineCompany
        //                {
        //                    Id = (int)reader["id"],
        //                    Name = reader["name"].ToString(),
        //                    Country_Id = (int)reader["country_id"],
        //                    User_Id = (int)reader["user_id"],

        //                };
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
