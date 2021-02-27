using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public IList<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            //if (token != null)
            //{
                if (token.User.Level==1 || token.User.Level == 2 || token.User.Level == 3)
                {
                    return _customerDAO.GetAll();
                }
            //}
            else
            {
                throw new Exception("There is a problem to get all customers. Access is denied.");

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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
            }
        }
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            if (token != null)
            {
                if (token.User.Level == 3)
                {
                    _adminDAO.Add(admin);
                }
                else
                {
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
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
                    throw new WrongLevelOfAccessException("Access is denied. You have no authorization to access this function");
                }
            }
        }

    }
}
