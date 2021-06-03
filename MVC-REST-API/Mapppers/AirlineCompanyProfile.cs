using AutoMapper;
using FinalProject_Part1;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Mapppers
{
    public class AirlineCompanyProfile : Profile
    {
        public AirlineCompanyProfile()
        {
            // read from db or cache
            Dictionary<int, string> map_countryid_to_name = new Dictionary<int, string>()
            {
                { 1, "Israel" }
            };

            // 1. auto each with SAME NAME will be mapped from one object to another
            // 2. you can customize the mappings!
            CreateMap<AirlineCompany, AirlineDTO>()
                .ForMember(dest => dest.CountryName,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.Country_Id]))
                .ForMember(dest => dest.CompanyName,
                            opt => opt.MapFrom(src => src.Name));
        }

    }
}
