using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class CountryDAOPGSQL : ICountryDAO
    {
       
        private string m_conn_string;

        public CountryDAOPGSQL()
        {
            m_conn_string = GlobalConfig.ConnectionString;
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


        public void Add(Country c    )
        {
            ExecuteNonQuery($"call sp_insert_country('{c.Name}');");           

        }

        public  Country GetById(int id)
        {
            Country result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_country_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Country
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString()

                        };
                    }
                }
            }
            return result;
        }

        public List<Country> GetAll()
        {
            List<Country> result = new List<Country>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_countries()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country c = new Country
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString()
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void Remove(Country c)
        {
            int result = ExecuteNonQuery($"call  sp_delete_country ({c.Id})");
        }

        public void Update(Country c)
        {
            int result = ExecuteNonQuery( $"call sp_update_country( {c.Id}, '{c.Name}')");
        }



    }
}
