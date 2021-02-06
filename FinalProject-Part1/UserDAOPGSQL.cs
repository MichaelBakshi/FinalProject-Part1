using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class UserDAOPGSQL:IUserDAO
    {
        private string m_conn_string;

        public UserDAOPGSQL(string conn_string)
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


        public void AddUser(User u)
        {

            ExecuteNonQuery($"call sp_insert_user('{u.Username}', '{u.Password}', '{u.Email}', {u.User_Role});");
        }

        public User GetUserById(int id)
        {
            User result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_user_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new User
                        {
                            Id = (int)reader["id"],
                            Username = reader["name"].ToString(),
                            Password = reader["name"].ToString(),
                            Email = reader["name"].ToString(),
                            User_Role = (int)reader["id"]
                        };
                    }
                }
            }
            return result;
        }

        public List<User> GetAllAUsers()
        {
            List<User> result = new List<User>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_users()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        User u = new User
                        {
                            Id = (int)reader["id"],
                            Username = reader["name"].ToString(),
                            Password = reader["name"].ToString(),
                            Email = reader["name"].ToString(),
                            User_Role = (int)reader["id"]
                        };
                        result.Add(u);
                    }
                }
            }
            return result;
        }

        public void RemoveUser(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_user ({id})");
        }

        public void UpdateUser(int id, string username, string password, string email, int user_role)
        {
            int result = ExecuteNonQuery($"call sp_update_user( {id}, '{username}', '{password}', '{email}', {user_role}");
        }
    }
}
