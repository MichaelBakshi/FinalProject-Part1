using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
