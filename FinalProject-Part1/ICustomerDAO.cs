using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface ICustomerDAO : IBasicDb<Customer>
    {
        Customer GetCustomerByUsername(string _username);
        
    }
}
