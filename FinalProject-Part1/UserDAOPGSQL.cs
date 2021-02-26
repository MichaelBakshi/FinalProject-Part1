using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class UserDAOPGSQL:IUserDAO
    {
        private string m_conn_string;

        public UserDAOPGSQL()
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


        public void Add(User u)
        {

            ExecuteNonQuery($"call sp_insert_user('{u.Username}', '{u.Password}', '{u.Email}', {u.User_Role});");
        }

        public User GetById(int id)
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

        public List<User> GetAll()
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
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Email = reader["email"].ToString(),
                            User_Role = (int)reader["id"]
                        };
                        result.Add(u);
                    }
                }
            }
            return result;
        }

        public void Remove(User u)
        {
            int result = ExecuteNonQuery($"call  sp_delete_user ({u.Id})");
        }

        public void Update(User u)
        {
            int result = ExecuteNonQuery($"call sp_update_user( {u.Id}, '{u.Username}', '{u.Password}', '{u.Email}', {u.User_Role})");
        }

        public User GetByUsername(string username)
        {
            // To implement
            return null;
        }
    }
}
