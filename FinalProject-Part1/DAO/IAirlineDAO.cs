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
        IList<AirlineAwaitingConfirmation> GetAllAirlineCompaniesFromAwaitingList();
        void Remove_from_awaiting_for_confirmation_list(AirlineAwaitingConfirmation airline);
        IList<AirlineCompany> GetAllAirlinesByCountry(int country_id);
    }
}
