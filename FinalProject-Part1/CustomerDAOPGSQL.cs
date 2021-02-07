using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class CustomerDAOPGSQL : ICustomerDAO
    {
        private string m_conn_string;

        public CustomerDAOPGSQL(string conn_string)
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


        public void AddCustomer(Customer c)
        {

            ExecuteNonQuery($"call sp_insert_customer('{c.First_Name}', '{c.Last_Name}', '{c.Address}', '{c.Phone_No}', '{c.Credit_Card_No}', {c.User_Id});");
        }

        public Customer GetCustomerById(int id)
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
                            User_Id = (int)reader["user_id"]
                        };
                    }
                }
            }
            return result;
        }

        public List<Customer> GetAllCustomers()
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

        public void RemoveCustomer(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_customer ({id})");
        }

        public void UpdateCustomer(int id, string first_name, string last_name, string address, string phone_no, string credit_card_no, int user_id)
        {
            int result = ExecuteNonQuery($"call sp_update_customer( {id}, '{first_name}', '{last_name}', '{address}', '{phone_no}', '{credit_card_no}',  {user_id})");
        }
    }
}
