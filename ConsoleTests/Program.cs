using FinalProject_Part1;
using System;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CountryDAOPGSQL dao = new CountryDAOPGSQL("Host=localhost;Username=postgres;Password=admin;Database=postgres");
            dao.AddCountry(new Country("China"));
            // אוקיי אני יודע מה הבעיה
            // אוקיי עכשיו אתה צריך להכניס סיסמא ושם הדאטא בייס
                // היוזר ניים הוא postgres
                // סבבה אני רואה שקראת לזה postgres
                // אוקיי בוא תבדוק בטבלה של המדינות אם יש מונוליה
        }
    }
}
