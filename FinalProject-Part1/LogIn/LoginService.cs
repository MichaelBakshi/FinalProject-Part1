﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoginService:ILoginService
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAirlineDAO _airlineDAO = new AirlineDAOPGSQL();
        private ICustomerDAO _customerDAO = new CustomerDAOPGSQL();
        private IAdminDAO _adminDAO = new AdminDAOPGSQL();
        private IUserDAO _userDAO = new UserDAOPGSQL();

        public bool TryLogin(string userName, string password, out ILoginToken token, out FacadeBase facade)
        {
            token = null;
            facade = null;
            if (userName== "admin" && password =="9999" )
            {
                //log4net
                //logger.
                token = new LoginToken<Administrator>();
                facade = new LoggedInAdministratorFacade();   
                return true;
                
            }
            else
            {
                try
                {
                    User user;
                    try
                    {
                        user = _userDAO.GetByUsername(userName);
                    }
                    catch (Exception e)
                    {
                        logger.Fatal("my error message", e);
                        return false;
                    }
                   
                    if (user.Password == password)
                    {
                        if (user.User_Role == 1)
                        {
                            Administrator admin = _adminDAO.GetById(user.Id);
                            admin.user = user;
                            token = new LoginToken<Administrator>()
                            {
                                User = admin
                            };
                            facade = new LoggedInAdministratorFacade();
                        }
                        if (user.User_Role == 2)
                        {
                            AirlineCompany airline = _airlineDAO.GetById(user.Id);
                            airline.user = user;
                            token = new LoginToken<AirlineCompany>()
                            {
                                User = airline
                            };
                            facade = new LoggedInAirlineFacade();
                        }
                        if (user.User_Role == 3)
                        {
                            Customer customer = _customerDAO.GetById(user.Id);
                            customer.user = user;
                            token = new LoginToken<Customer>()
                            {
                                User = customer
                            };
                            facade = new LoggedInCustomerFacade();
                        }
                        return true;
                    }
                    else
                    {
                        throw new WrongCredentialsException("Username or password are incorrect. Please try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    logger.Error("my error message", e);
                    return false;
                }
                //log4net
              
            }

        }
    }
}
