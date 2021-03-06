using FinalProject_Part1;
using System;
using System.Collections.Generic;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //CountryDAOPGSQL dao = new CountryDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //dao.AddCountry(new Country("China"));
            //Country result_of_get = dao.GetCountryById(5);
            //Console.WriteLine(result_of_get.Name);
            //List<Country> listofcountries = dao.GetAllCountries();
            //foreach (var item in listofcountries)
            //{
            //    Console.WriteLine(item);
            //}

            //dao.RemoveCountry(11);
            //dao.UpdateCountry(9, "Mongoly");

            //AdminDAOPGSQL admindao = new AdminDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //admindao.UpdateAdministrator(1, "Billy", "Tuhes", 1, 1);

            //AirlineDAOPGSQL airline1 = new AirlineDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //airline1.UpdateAirline(14, "Aeroflot", 3, 11);

            //UserDAOPGSQL userdao1 = new UserDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //userdao1.UpdateUser(7, "EL-AL", "elal", "elal@gmail.com", 2);

            //CustomerDAOPGSQL customerDAO = new CustomerDAOPGSQL();
            //customerDAO.UpdateCustomer(1, "Asaf", "Cohen", "Lapid", "08-8976543", "4580523652145236", 3);
            //Customer customer = customerDAO.GetById(4);
            //Console.WriteLine(customer);

            FlightDAOPGSQL flightDAOPGSQL = new FlightDAOPGSQL();
            //List<Flight> flights = flightDAOPGSQL.GetAll();
            //foreach (var item in flights)
            //{
            //    Console.WriteLine(item);
            //}

            //Dictionary<Flight, int> keyValues = flightDAOPGSQL.GetAllFlightsVacancy();
            //foreach (KeyValuePair<Flight, int> kvp in keyValues)
            //    Console.WriteLine("Flight: {0}, Available seats: {1}", kvp.Key, kvp.Value);

            FlightsCenterSystem flightsCenter = FlightsCenterSystem.Instance;
            //FlightsCenterSystem flightsCenter1 = FlightsCenterSystem.Instance.GetFacade();
            //bool equal = flightsCenter == flightsCenter1;

            flightsCenter.DoSomething();

        }
    }
}
