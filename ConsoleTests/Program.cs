﻿using FinalProject_Part1;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleTests
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            //Console.WriteLine("Hello World!");

            log.Info("info test");
            log.Debug("debug test");
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

            //FlightDAOPGSQL flightDAOPGSQL = new FlightDAOPGSQL();
            //List<Flight> flights = flightDAOPGSQL.GetAll();
            //foreach (var item in flights)
            //{
            //    Console.WriteLine(item);
            //}

            //Dictionary<Flight, int> keyValues = flightDAOPGSQL.GetAllFlightsVacancy();
            //foreach (KeyValuePair<Flight, int> kvp in keyValues)
            //    Console.WriteLine("Flight: {0}, Available seats: {1}", kvp.Key, kvp.Value);

            //FlightsCenterSystem flightsCenter = FlightsCenterSystem.Instance;
            //FlightsCenterSystem flightsCenter1 = FlightsCenterSystem.Instance.GetFacade();
            //bool equal = flightsCenter == flightsCenter1;

            //for(int i=0;i<15;i++)
            //{
            //    ThreadPool.QueueUserWorkItem((x) =>
            //    {
            //        var a = flightsCenter.GetConnection();
            //        Console.WriteLine($"thread {Thread.CurrentThread}, got connection");
            //        Thread.Sleep(2000);
            //        flightsCenter.ReturnConnection(a);
            //        Console.WriteLine($"thread {Thread.CurrentThread}, returned connection");
            //    });
            //}
            //Console.ReadLine();

            //LoggedInAdministratorFacade loggedInAdministratorFacade = new LoggedInAdministratorFacade(false);
            //loggedInAdministratorFacade.GetAllCustomers(token, );

        }
    }
}
