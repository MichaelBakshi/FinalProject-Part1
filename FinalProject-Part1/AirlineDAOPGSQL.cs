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


        public void AddAirline(AirlineCompany a)
        {

            ExecuteNonQuery($"call sp_insert_airline('{a.Name}', {a.Country_Id}, {a.User_Id});");
        }

        public AirlineCompany GetAirlineById(int id)
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

        public AirlineCompany GetAirlineByUsername(string _name)
        {
            AirlineCompany result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_airline_by_username({_name})";

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

        public AirlineCompany GetAirlineByCountry(string _name)
        {
            AirlineCompany result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_airline_by_country({_name})";

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

        public List<AirlineCompany> GetAllAirlines()
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

        public void RemoveAirline(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_airline_company ({id})");
        }

        public void UpdateAirline(int id, string name, int country_id, int user_id)
        {
            int result = ExecuteNonQuery($"call sp_update_airline( {id}, '{name}', {country_id}, {user_id})");
        }
    }
}
