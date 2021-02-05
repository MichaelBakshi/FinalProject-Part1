using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class AdminDAOPGSQL : IAdminDAO
    {
        private string m_conn_string;

        public AdminDAOPGSQL(string conn_string)
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


        public void Add_administrator(Administrator a)
        {

            ExecuteNonQuery($"call sp_insert_administrator('{a.First_Name}', '{a.Last_Name}', '{a.Level}', '{a.User_Id}');");
        }

        public Administrator GetAdministratorById(int id)
        {
            Administrator result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_administrator_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Administrator
                        {
                            Id = (int)reader["id"],
                            First_Name = reader["first_name"].ToString(),
                            Last_Name = reader["last_name"].ToString(),
                            Level = (int)reader["level"],
                            User_Id = (int)reader["user_id"]
                        };
                    }
                }
            }
            return result;
        }

        public List<Administrator> GetAllAdministrators()
        {
            List<Administrator> result = new List<Administrator>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_administrators()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Administrator c = new Administrator
                        {
                            Id = (int)reader["id"],
                            First_Name = reader["first_name"].ToString(),
                            Last_Name = reader["last_name"].ToString(),
                            Level = (int)reader["level"],
                            User_Id = (int)reader["user_id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void RemoveAdministrator(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_administrator ({id})");
        }

        public void UpdateAdministrator(int id, string first_name, string last_name, int level, int user_id)
        {
            int result = ExecuteNonQuery($"call sp_update_administrator( {id}, '{first_name}', '{last_name}', {level}, {user_id})");
        }
    }
}
