using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class FlightDAOPGSQL : IFlightDAO
    {
        private string m_conn_string;

        public FlightDAOPGSQL(string conn_string)
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


        public void AddFlight(Flight f)
        {

            ExecuteNonQuery($"call sp_insert_flight({f.Airline_Company_Id}, {f.Origin_Country_Id}, {f.Destination_Country_Id}, {f.Departure_Time}, {f.Landing_Time}, {f.Remaining_Tickets} );");
        }

        public Flight GetFlightById(int id)
        {
            Flight result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flight_by_id({id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id =(int) reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int) reader["destination_country_id"],
                            Departure_Time = (DateTime) reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                    }
                }
            }
            return result;
        }

        public Flight GetFlightByCustomer(int _customer_id)
        {
            Flight result = null;

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flight_by_customer({_customer_id})";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        result = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            
                        };
                    }
                }
            }
            return result;
        }

        public List<Flight> GetAllFlights()
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_all_flights()";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight f = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public List<Flight> GetFlightsByDepartureDate(DateTime _departure_date)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_departure_date('{_departure_date}')";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight f = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public List<Flight> GetFlightsByLandingDate(DateTime _landing_date)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_departure_date('{_landing_date}')";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight f = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public List<Flight> GetFlightsByDestinationCountry(string _destination_country)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_destination_country('{_destination_country}')";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight f = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public List<Flight> GetFlightsByOriginCountry(string _origin_country)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_origin_country('{_origin_country}')";

                    NpgsqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Flight f = new Flight
                        {
                            Id = (int)reader["id"],
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public void RemoveFlight(int id)
        {
            int result = ExecuteNonQuery($"call  sp_delete_flight ({id})");
        }

        public void Updateflight(int id, int airline_company_id, int origin_country_id, int destination_country_id, DateTime departure_time, DateTime landing_time, int remaining_tickets)
        {
            int result = ExecuteNonQuery($"call sp_update_flight( {id}, {airline_company_id}, {origin_country_id}, {destination_country_id}, '{departure_time}', '{landing_time}',  {remaining_tickets})");
        }
    }
}
