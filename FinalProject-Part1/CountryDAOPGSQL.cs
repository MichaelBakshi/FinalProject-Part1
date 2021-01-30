using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class CountryDAOPGSQL : ICountryDAO
    {
        void IBasicDb<Country>.Add(Country newItem)
        {
            
        }

        Country IBasicDb<Country>.Get()
        {
            Country result = new Country();


            return result;
        }
    }
}
