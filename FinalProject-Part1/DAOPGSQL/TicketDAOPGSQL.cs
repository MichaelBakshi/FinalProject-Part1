using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class TicketDAOPGSQL : ITicketDAO
    {
        private string m_conn_string;

        public TicketDAOPGSQL()
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


        public void Add(Ticket t)
        {

            ExecuteNonQuery($"call sp_insert_ticket({t.Flight_Id}, {t.Customer_Id});");
        }

        public Ticket GetById(int id)
        {
            Ticket result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_ticket_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Ticket
                        {
                            Id = (int)reader["id"],
                            Flight_Id = (int)reader["id"],
                            Customer_Id = (int)reader["id"]
                        };
                    }
                }
            }
            return result;
        }

        // get tickets by airline id
        //public List<Ticket> GetAllTicketsByAirlineId(int id)
        //{
        //    List<Ticket> result = new List<Ticket>();

        //    using (NpgsqlCommand cmd = new NpgsqlCommand())
        //    {
        //        using (cmd.Connection = new NpgsqlConnection(m_conn_string))
        //        {
        //            cmd.Connection.Open();
        //            cmd.CommandType = System.Data.CommandType.Text;
        //            cmd.CommandText = "select * from sp_get_all_tickets_by_airline_id()";

        //            NpgsqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                Ticket c = new Ticket
        //                {
        //                    Id = (int)reader["id"],
        //                    Flight_Id = (int)reader["id"],
        //                    Customer_Id = (int)reader["id"]
        //                };
        //                result.Add(c);
        //            }
        //        }
        //    }
        //    return result;
        //}


        public List<Ticket> GetAll()
        {
            List<Ticket> result = new List<Ticket>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from sp_get_all_tickets()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Ticket c = new Ticket
                        {
                            Id = (int)reader["id"],
                            Flight_Id = (int)reader["flight_id"],
                            Customer_Id = (int)reader["customer_id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void Remove(Ticket t)
        {
            int result = ExecuteNonQuery($"call  sp_delete_ticket ({t.Id})");
        }

        public void Update(Ticket t)
        {
            int result = ExecuteNonQuery($"call sp_update_ticket( {t.Id}, {t.Flight_Id}, {t.Customer_Id})");
        }
    }
}
