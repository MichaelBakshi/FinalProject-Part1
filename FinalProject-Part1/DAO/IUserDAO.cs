using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface IUserDAO : IBasicDb<User>
    {
        User GetUserByUsername(string username);
    }
}
