using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{

    public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
        AirlineCompany GetAirlineByUsername(string _username);
        AirlineCompany GetAirlineByCountry(string _country_name);
    }
}
