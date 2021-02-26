using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoginToken <T>: ILoginToken where T : IUser
    {
        public T User { get; set; }

        
    }
}
