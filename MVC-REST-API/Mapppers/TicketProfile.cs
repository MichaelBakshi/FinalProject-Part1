using AutoMapper;
using FinalProject_Part1;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Mapppers
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketDTO>()
            .ForMember(dest => dest.Id,
                        opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Flight,
                        opt => opt.MapFrom(src => new FlightDAOPGSQL().GetById(src.Flight_Id)))
            .ForMember(dest => dest.Customer,
                        opt => opt.MapFrom(src => new CustomerDAOPGSQL().GetById(src.Customer_Id)));
        }
    }
}
