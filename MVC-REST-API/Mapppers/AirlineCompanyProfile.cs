using AutoMapper;
using FinalProject_Part1;
using FinalProject_Part1.Members;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Mapppers
{
    public class AirlineCompanyProfile : Profile
    {
        Dictionary<int, string> map_countryid_to_name = new Dictionary<int, string>();

        public AirlineCompanyProfile()
        {

            List<Country> countries = new CountryDAOPGSQL().GetAll();

            foreach (Country country in countries)
            {
                map_countryid_to_name.Add(country.Id, country.Name);
            }

            CreateMap<AirlineCompany, AirlineDTO>()
                .ForMember(dest => dest.CountryName,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.Country_Id]))
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.user,
                            opt => opt.MapFrom(src => src.user));

            CreateMap<AirlineDTO, AirlineCompany>()
                .ForMember(dest => dest.Country_Id,
                            opt => opt.MapFrom(src => countries.Where(c=>c.Name == src.CountryName).ToList()[0].Id))
                                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.user,
                            opt => opt.MapFrom(src => src.user));

            CreateMap<AirlineAwaitingConfirmation, AirlineDTO>()
                .ForMember(dest => dest.CountryName,
                            opt => opt.MapFrom(src => map_countryid_to_name[src.Country_Id]));
                //.ForMember(dest => dest.Id,
                //            opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.Name,
                //            opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.user,
                //            opt => opt.MapFrom(src => src.user));
        }

    }
}
