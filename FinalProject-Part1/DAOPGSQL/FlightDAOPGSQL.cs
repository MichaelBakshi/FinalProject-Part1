using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class FlightDAOPGSQL : IFlightDAO
    {
        private string m_conn_string;

        public FlightDAOPGSQL()
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


        public void Add(Flight f)
        {

            ExecuteNonQuery($"call sp_insert_flight({f.Airline_Company_Id}, {f.Origin_Country_Id}, {f.Destination_Country_Id}, '{f.Departure_Time}', '{f.Landing_Time}', {f.Remaining_Tickets} );");   
        }

        public Flight GetById(int id)
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

        public IList <Flight> GetFlightsByCustomer(Customer c)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_all_flights_by_customer({c.Id})";

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
                            Remaining_Tickets = (int)reader["remaining_tickets"],
                            Ticket_Id = (int)reader["ticket_id"]
                        };
                        result.Add(f);
                    }
                }
            }
            return result;
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            Dictionary<Flight, int> keyValues = new Dictionary<Flight, int>();
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_remaining_seats_on_each_flight()";

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
                        int seats = (int)reader["remaining_tickets"];
                        
                        keyValues.Add(f, seats);
                    }
                }
            }
            return keyValues;
        }


        public List<Flight> GetAll()
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


        public IList<Flight> GetAllFlightsByAirline()
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_all_flights_by_airline()";

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



        public IList<Flight> GetFlightsByDepartureDate(DateTime _departure_date)
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

        public IList<Flight> GetFlightsByLandingDate(DateTime _landing_date)
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

        public IList<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_destination_country({countryCode})";

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

        public IList<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            List<Flight> result = new List<Flight>();

            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                using (cmd.Connection = new NpgsqlConnection(m_conn_string))
                {
                    cmd.Connection.Open();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"select * from sp_get_flights_by_origin_country({countryCode})";

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

        public void Remove(Flight f)
        {
            int result = ExecuteNonQuery($"call  sp_delete_flight ({f.Id})");
        }

        public void Update(Flight f)
        {
            int result = ExecuteNonQuery($"call sp_update_flight( {f.Id}, {f.Airline_Company_Id}, {f.Origin_Country_Id}, {f.Destination_Country_Id}, '{f.Departure_Time}', '{f.Landing_Time}',  {f.Remaining_Tickets})");
        }
    }
}
