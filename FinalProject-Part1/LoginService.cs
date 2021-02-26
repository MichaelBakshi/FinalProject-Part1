using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoginService:ILoginService
    {
        private IAirlineDAO _arilineDAO;
        private ICustomerDAO _customerDAO;
        private IAdminDAO adminDAO;

        public bool TryLogin(string userName, string password, out ILoginToken token, out FacadeBase facade)
        {

        }
    }
}
