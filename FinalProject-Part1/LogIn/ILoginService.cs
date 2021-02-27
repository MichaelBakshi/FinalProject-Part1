using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    interface ILoginService
    {
        public bool TryLogin(string userName, string password, out ILoginToken token, out FacadeBase facade);
    }
}
