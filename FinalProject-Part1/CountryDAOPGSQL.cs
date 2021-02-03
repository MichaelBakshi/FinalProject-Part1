using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class CountryDAOPGSQL : ICountryDAO
    {
        //void IBasicDb<Country>.Add(Country newItem)
        //{

        //}

        //Country IBasicDb<Country>.Get()
        //{
        //    Country result = new Country();


        //    return result;
        //}
        private string m_conn_string;

        public CountryDAOPGSQL(string conn_string)
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


        public void AddCountry(Country v    )
        {
            ExecuteNonQuery("INSERT INTO VISITS(first_name, last_name, visited_at, phone, store_id)" +
            $"VALUES('{v.FirstName}', '{v.LastName}', '{v.VisitedAt}', '{v.Phone}', {v.StoreId});");

        }

        public Country GetCountryById(int id)
        {
            Country result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"SELECT * FROM VISITS WHERE visit_id={id}";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Country
                        {
                            Id = (int)reader["visit_id"],
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            VisitedAt = Convert.ToDateTime(reader["visited_at"]),
                            Phone = reader["phone"].ToString(),
                            StoreId = (int)reader["store_id"]
                        };
                    }

                }
            }

            return result;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> result = new List<Country>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();

                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "SELECT * FROM VISITS";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country v = new Country
                        {
                            Id = (int)reader["visit_id"],
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            VisitedAt = Convert.ToDateTime(reader["visited_at"]),
                            Phone = reader["phone"].ToString(),
                            StoreId = (int)reader["store_id"]
                        };
                        result.Add(v);
                    }

                }
            }

            return result;
        }

        public int RemoveCountry(int id)
        {
            int result = ExecuteNonQuery($"DELETE * FROM VISITS WHERE visit_id={id}");
            return result;
        }

        public void UpdateCountry(Country v, int id)
        {
            int result = ExecuteNonQuery(
                $"UPDATE FROM VISITS SET first_name={v.FirstName}, last_name={v.LastName}, visited_at={v.VisitedAt}," +
                $"phone={v.Phone}, store_id={v.StoreId} WHERE visit_id={id}");
        }



    }
}
