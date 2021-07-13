using AutoMapper;
using FinalProject_Part1;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Mapppers
{
    public class TicketProfile: Profile
    {
        //public TicketProfile()
        //{

        //    Dictionary<int, string> map_customerid_to_name = new Dictionary<int, string>();

        //    List<Customer> customers = new CustomerDAOPGSQL().GetAll();

        //    foreach (Customer customer in customers)
        //    {
        //        map_customerid_to_name.Add(customer.Id, customer.First_Name);
        //    }

        //    CreateMap<Ticket, TicketDTO>()
        //        .ForMember(dest => dest.Id,
        //                    opt => opt.MapFrom(src => src.Id))

        //        .ForMember(dest => dest.Customer_Name,
        //                    opt => opt.MapFrom(src => map_customerid_to_name[src.Customer_Id]));

        //}
    }
}
