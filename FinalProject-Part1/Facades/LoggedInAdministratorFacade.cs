using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoggedInAdministratorFacade(bool testMode) : base(testMode)
        {
            GlobalConfig.GetConfiguration(testMode);
        }

        public IList<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            if (token != null)
            {
                if (token.User.Level==1 || token.User.Level == 2 || token.User.Level == 3)
                {
                    return _customerDAO.GetAll();
                }
                logger.Debug("This administrator level is not authorized to get all customers.");
                throw new WrongLevelOfAccessException("This administrator level is not authorized to get all customers. Access is denied.");
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("Access is denied. You have no authorization to get all customers.");
            }
        }
        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                if (token.User.Level == 2 || token.User.Level == 3)
                {
                    _airlineDAO.Add(airline);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to create a new airline.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to create new airline.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to create new airline. Access is denied.");
            }
        }
        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                if (token.User.Level == 1 || token.User.Level == 2 || token.User.Level == 3)
                {
                    _airlineDAO.Update(airline);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to update airline details.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to update airline details.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to update airline details. Access is denied.");
            }
        }
        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                if (token.User.Level == 2 || token.User.Level == 3)
                {
                    _airlineDAO.Remove(airline);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to remove airline.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to remove airline.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to remove airline. Access is denied.");
            }
        }
        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                if (token.User.Level == 2 || token.User.Level == 3)
                {
                    _customerDAO.Add(customer);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to create a new customer.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to create new customer.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to create new customer. Access is denied.");
            }
        }
        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                if (token.User.Level == 1 || token.User.Level == 2 || token.User.Level == 3)
                {
                    _customerDAO.Update(customer);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to update customer details.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to update customer details.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to update customer details. Access is denied.");
            }
        }
        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                if (token.User.Level == 2 || token.User.Level == 3)
                {
                    _customerDAO.Remove(customer);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to remove customer.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to remove customer.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to remove customer. Access is denied.");
            }
        }
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            logger.Debug("starting CreateAdmin()");

            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _adminDAO.Add(admin);

                }
                else
                {
                    logger.Debug("This administrator level is not authorized to create a new admin.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to create a new admin.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to create a new admin. Access is denied.");
            }
        }
        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _adminDAO.Update(admin);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to update administrator details.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to update administrator details.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to update administrator details. Access is denied.");
            }
        }
        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _adminDAO.Remove(admin);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to remove administrator.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to remove administrator.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to remove administrator. Access is denied.");
            }
        }

        public void CreateUser(LoginToken<Administrator> token, User user)
        {
            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _userDAO.Add(user);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to create a new user.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to create new user.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to create new user. Access is denied.");
            }
        }

        public void CreateTicket(LoginToken<Administrator> token, Ticket ticket)
        {
            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _ticketDAO.Add(ticket);
                }
                else
                {
                    logger.Debug("This administrator level is not authorized to create a new ticket.");
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to create new ticket.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new Exception("There is a problem to create new ticket. Access is denied.");
            }
        }

    }
}
