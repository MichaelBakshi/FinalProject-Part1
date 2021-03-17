using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class WrongCredentialsException : ApplicationException
    {
        public WrongCredentialsException(string message)
        {
            //Console.WriteLine(message);
        }
    }
}
