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

            CustomerDAOPGSQL customerDAO = new CustomerDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            //customerDAO.UpdateCustomer(1, "Asaf", "Cohen", "Lapid", "08-8976543", "4580523652145236", 3);
            Customer customer = customerDAO.GetCustomerById(4);
            Console.WriteLine(customer);

            // אוקיי אני יודע מה הבעיה
            // אוקיי עכשיו אתה צריך להכניס סיסמא ושם הדאטא בייס
            // היוזר ניים הוא postgres
            // סבבה אני רואה שקראת לזה postgres
            // אוקיי בוא תבדוק בטבלה של המדינות אם יש מונוליה
        }
    }
}
