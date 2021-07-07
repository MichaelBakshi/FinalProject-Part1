using AutoMapper;
using FinalProject_Part1;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Mapppers
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            Dictionary<int, string> map_airline_id_to_name = new Dictionary<int, string>();

            List<AirlineCompany> airlines = new AirlineDAOPGSQL().GetAll();

            foreach (AirlineCompany airline in airlines)
            {
                map_airline_id_to_name.Add(airline.Id, airline.Name);
            }

            CreateMap<AirlineCompany, FlightDTO>()
                .ForMember(dest => dest.Airline_Company_Name,
                            opt => opt.MapFrom(src => map_airline_id_to_name[src.Country_Id]));
                //.ForMember(dest => dest.Id,
                //            opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name,
                //            opt => opt.MapFrom(src => src.Name));


            Dictionary<int, string> map_countryid_to_name = new Dictionary<int, string>();

            List<Country> countries = new CountryDAOPGSQL().GetAll();

            foreach (Country country in countries)
            {
                map_countryid_to_name.Add(country.Id, country.Name);
            }

            CreateMap<Country, FlightDTO>()
                .ForMember(dest => dest.Origin_Country_Name,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.Id]))
                .ForMember(dest => dest.Destination_Country_Name,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.Id]));
                
        }

    }
}
