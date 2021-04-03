﻿using FinalProject_Part1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectTestCore
{
    [TestClass]
    public class AdministratorTest
    {
        LoggedInAdministratorFacade administratorFacade;

        [TestInitialize]
        public void TryLogin()
        {
            //login to users
            ILoginToken loginToken;
            new LoginService().TryLogin("userName", "password", out loginToken);
            administratorFacade = FlightsCenterSystem.Instance.GetFacade(loginToken as LoginToken<Administrator>) as LoggedInAdministratorFacade;
        }
    }
}