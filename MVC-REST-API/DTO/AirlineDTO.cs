﻿using FinalProject_Part1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.DTO
{
    public class AirlineDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public int User_Id { get; set; }
        public User user { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
