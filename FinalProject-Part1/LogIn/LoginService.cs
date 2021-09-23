using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoginService:ILoginService
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAirlineDAO _airlineDAO = new AirlineDAOPGSQL();
        private ICustomerDAO _customerDAO = new CustomerDAOPGSQL();
        private IAdminDAO _adminDAO = new AdminDAOPGSQL();
        private IUserDAO _userDAO = new UserDAOPGSQL();

        public bool TryLogin(string userName, string password, out ILoginToken token )
        {
            token = null;

            if (userName== "admin" && password =="9999" )
            {
                logger.Info("Super administrator logged in.");
                token = new LoginToken<Administrator>(); 
                return true;
                
            }
            else
            {
                try
                {
                    User user;
                    try
                    {
                        user = _userDAO.GetUserByUsername(userName);
                    }
                    catch (Exception e)
                    {
                        logger.Fatal("Wrong username. Please try again.", e);
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
                        }
                        if (user.User_Role == 2)
                        {
                            AirlineCompany airline = _airlineDAO.GetAirlineByUsername(user.Username); //TODO check if null
                            airline.user = user;
                            token = new LoginToken<AirlineCompany>()
                            {
                                User = airline
                            };
                        }
                        if (user.User_Role == 3)
                        {
                            Customer customer = _customerDAO.GetCustomerByUsername(user.Username);
                            customer.user = _userDAO.GetUserByUsername(user.Username);
                            token = new LoginToken<Customer>()
                            {
                                User = customer
                            };
                        }
                        logger.Info("Login was completed. Username and password are correct.");
                        return true;
                    }
                    else
                    {
                        logger.Error("Login failed. Username or password are incorrect.");
                        throw new WrongCredentialsException("Username or password are incorrect. Please try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    logger.Error("Login failed.", e);
                    return false;
                }
                //log4net
              
            }

        }
    }
}
