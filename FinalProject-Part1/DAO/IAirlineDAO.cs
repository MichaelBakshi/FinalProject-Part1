using FinalProject_Part1.Members;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{

    public interface IAirlineDAO : IBasicDb<AirlineCompany>
    {
        AirlineCompany GetAirlineByUsername(string _username);
        void AddToAwaitingList(AirlineAwaitingConfirmation newItem);
        List<AirlineAwaitingConfirmation> GetAllAirlineCompaniesFromAwaitingList();
        IList<AirlineCompany> GetAllAirlinesByCountry(int country_id);
    }
}
