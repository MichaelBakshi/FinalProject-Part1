using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class CustomerDAOPGSQL : ICustomerDAO
    {
        private string m_conn_string;

        public CustomerDAOPGSQL()
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


        public void Add(Customer c)
        {

            ExecuteNonQuery($"call sp_insert_customer('{c.First_Name}', '{c.Last_Name}', '{c.Address}', '{c.Phone_No}', '{c.Credit_Card_No}', {c.User_Id});");
        }

        public Customer GetById(int id)
        {
            Customer result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_customer_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Customer
                        {
                            Id = (int)reader["id"],
                            First_Name = reader["first_name"].ToString(),
                            Last_Name = reader["last_name"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone_No = reader["phone_no"].ToString(),
                            Credit_Card_No = reader["credit_card_no"].ToString(),
                            User_Id = (int)reader["user_id"],
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public Customer GetCustomerByUsername(string _username)
        {
            Customer result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_customer_by_username('{_username}')";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Customer
                        {
                            Id = (int)reader["id"],
                            First_Name = reader["first_name"].ToString(),
                            Last_Name = reader["last_name"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone_No = reader["phone_no"].ToString(),
                            Credit_Card_No = reader["credit_card_no"].ToString(),
                            User_Id = (int)reader["user_id"],
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };
                    }
                }
            }
            return result;
        }

        public List<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_customers()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer c = new Customer
                        {
                            Id = (int)reader["id"],
                            First_Name = reader["first_name"].ToString(),
                            Last_Name = reader["last_name"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone_No = reader["phone_no"].ToString(),
                            Credit_Card_No = reader["credit_card_no"].ToString(),
                            User_Id = (int)reader["user_id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void Remove(Customer c)
        {
            int result = ExecuteNonQuery($"call  sp_delete_customer ({c.Id})");
        }

        public void Update(Customer c)
        {
            int result = ExecuteNonQuery($"call sp_update_customer( {c.Id}, '{c.First_Name}', '{c.Last_Name}', '{c.Address}'," +
                $" '{c.Phone_No}', '{c.Credit_Card_No}',  {c.User_Id}, '{c.Username}','{c.Password}')");
        }
    }
}
