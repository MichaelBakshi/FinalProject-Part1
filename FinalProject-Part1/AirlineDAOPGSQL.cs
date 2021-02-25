using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class AirlineDAOPGSQL :IAirlineDAO
    {
        private string m_conn_string;

        public AirlineDAOPGSQL(string conn_string)
        {
            m_conn_string = conn_string;
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

            ExecuteNonQuery($"call sp_insert_airline('{a.Name}', {a.Country_Id}, {a.User_Id});");
        }

        public AirlineCompany GetById(int id)
        {
            AirlineCompany result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_airline_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new AirlineCompany
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Country_Id = (int)reader["country_id"],
                            User_Id = (int)reader["user_id"]
                        };
                    }
                }
            }
            return result;
        }

        public AirlineCompany GetAirlineByUsername(string _username)
        {
            AirlineCompany result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_airline_by_username({_username})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new AirlineCompany
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Country_Id = (int)reader["country_id"],
                            User_Id = (int)reader["user_id"],
                           
                        };
                    }
                }
            }
            return result;
        }

        public IList<AirlineCompany> GetAllAirlinesByCountry(int country_id)
        {
            List<AirlineCompany> result = new List<AirlineCompany>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_all_airlines_by_country({country_id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AirlineCompany c = new AirlineCompany
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Country_Id = (int)reader["country_id"],
                            User_Id = (int)reader["user_id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public List<AirlineCompany> GetAll()
        {
            List<AirlineCompany> result = new List<AirlineCompany>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_airline_companies()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AirlineCompany c = new AirlineCompany
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString(),
                            Country_Id = (int)reader["country_id"],
                            User_Id = (int)reader["user_id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void Remove(AirlineCompany airline)
        {
            int result = ExecuteNonQuery($"call  sp_delete_airline_company ({airline.Id})");
        }

        public void Update(AirlineCompany airline)
        {
            int result = ExecuteNonQuery($"call sp_update_airline( {airline.Id}, '{airline.Name}', {airline.Country_Id}, {airline.User_Id})");
        }
    }
}
