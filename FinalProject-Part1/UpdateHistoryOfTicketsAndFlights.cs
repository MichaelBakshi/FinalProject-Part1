using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FinalProject_Part1
{
    public  class UpdateHistoryOfTicketsAndFlights
    {
        private static string conn_string = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        public static void UpdateTicketsHistory()
        {

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"call sp_update_tickets_history()";

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateFlightsHistory()
        {

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"call  sp_update_flights_history()";

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void UpdateHistory()
        {
            while (true)
            {
                if (DateTime.Now.ToString("HH:mm") == "00:00")
                {
                    UpdateTicketsHistory();
                    Thread.Sleep(5000);
                    UpdateFlightsHistory();
                    Thread.Yield();
                }
                Thread.Sleep(1000 * 60);
            }

        }
    }
}
