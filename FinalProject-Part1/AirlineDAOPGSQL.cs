using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class AirlineDAOPGSQL :IAirlineDAO
    {
        private string m_conn_string;

        public TicketDAOPGSQL(string conn_string)
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


        public void AddTicket(Ticket t)
        {

            ExecuteNonQuery($"call sp_insert_ticket({t.Flight_Id}, {t.Customer_Id});");
        }

        public Ticket GetTicketById(int id)
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

        public List<Ticket> GetAllTickets()
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
                            Flight_Id = (int)reader["id"],
                            Customer_Id = (int)reader["id"]
                        };
                        result.Add(c);
                    }
                }
            }
            return result;
        }

        public void RemoveTicket(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_ticket ({id})");
        }

        public void UpdateTicket(int id, int flight_id, int customer_id)
        {
            int result = ExecuteNonQuery($"call sp_update_ticket( {id}, {flight_id}, {customer_id})");
        }
    }
}
