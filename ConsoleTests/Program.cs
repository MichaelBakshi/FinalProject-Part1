﻿using FinalProject_Part1;
using System;
using System.Collections.Generic;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountryDAOPGSQL dao = new CountryDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //dao.AddCountry(new Country("China"));
            //Country result_of_get = dao.GetCountryById(5);
            //Console.WriteLine(result_of_get.Name);
            List<Country> listofcountries = dao.GetAllCountries();
            //foreach (var item in listofcountries)
            //{
            //    Console.WriteLine(item);
            //}

            //dao.RemoveCountry(11);
            //dao.UpdateCountry(9, "Mongoly");



            // אוקיי אני יודע מה הבעיה
            // אוקיי עכשיו אתה צריך להכניס סיסמא ושם הדאטא בייס
            // היוזר ניים הוא postgres
            // סבבה אני רואה שקראת לזה postgres
            // אוקיי בוא תבדוק בטבלה של המדינות אם יש מונוליה
        }
    }
}
