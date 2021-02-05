using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class CountryDAOPGSQL : ICountryDAO
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
            //ExecuteNonQuery("INSERT INTO VISITS(first_name, last_name, visited_at, phone, store_id)" +
            //$"VALUES('{v.FirstName}', '{v.LastName}', '{v.VisitedAt}', '{v.Phone}', {v.StoreId});");

            ExecuteNonQuery($"call sp_insert_country('{v.Name}');");
            // בוא תנסה להריץ את השורה הזאת, נראה אם זה עובד
            // אני ממליץ לך ליצור בתוך הסולושן פרויקט קונסול כדי לעשות בדיקות וכו... רוצה נעשה את זה ביחד?
           

        }

        public  Country GetCountryById(int id)
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

        public List<Country> GetAllCountries()
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

        public void RemoveCountry(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_country ({id})");
        }

        public void UpdateCountry(int id, string country_name)
        {
            int result = ExecuteNonQuery( $"call sp_update_country( {id}, '{country_name}')");
        }



    }
}
