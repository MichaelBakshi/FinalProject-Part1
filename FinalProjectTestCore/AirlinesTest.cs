using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AirlinesTest
    {
        LoggedInAirlineFacade airlineFacade;

        [TestInitialize]
        public void TryLogin()
        {
            ILoginToken loginToken;
            new LoginService().TryLogin("userName", "password", out loginToken);
            airlineFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<AirlineCompany>) as LoggedInAirlineFacade;
        }


        [TestMethod]
        //[ExpectedException()]
        public void CheckNullToken()
        {
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.CancelFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.GetAllTickets(null);
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.CreateFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.UpdateFlight(null, new Flight());
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.ChangeMyPassword(null, "old_password", "new_password");
            });
            Assert.ThrowsException<Exception>(() =>
            {
                airlineFacade.MofidyAirlineDetails(null, new AirlineCompany());
            });
        }

        [TestMethod]
        public void GetAllTickets()
        {
            Flight flight = airlineFacade.GetFlightById(1);
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            Assert.AreEqual(flight, expectedFlight);
        }

        [TestMethod]
        public void GetAllFlights()
        {
            Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)airlineFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Add(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        // cancel flight
        [TestMethod]
        public void CancelFlight()
        {
            //Flight expectedFlight = new Flight(1, 1, 1, DateTime.Now, DateTime.Now, 1);
            List<Flight> list_of_flights = (List<Flight>)airlineFacade.GetAllFlights();
            List<Flight> expected_list_of_flights = null;
            expected_list_of_flights.Remove(expectedFlight);
            Assert.AreEqual(list_of_flights, expected_list_of_flights);
        }

        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Remove(flight);
            }
            else
            {
                throw new Exception("There is a problem to get all flights. Please check your login details.");
            }
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
                            Airline_Company_Id = (int)reader["airline_company_id"],
                            Origin_Country_Id = (int)reader["origin_country_id"],
                            Destination_Country_Id = (int)reader["destination_country_id"],
                            Departure_Time = (DateTime)reader["departure_time"],
                            Landing_Time = (DateTime)reader["landing_time"],
                            Remaining_Tickets = (int)reader["remaining_tickets"]
                        };
                    }
                }
            }
            return result;
        }

        //change my password
        //create flight
        //modify airline details
        //update flight


    }
}
