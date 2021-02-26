using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public IList<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            return _customerDAO.GetAll();
        }
        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            _airlineDAO.Add(airline);
        }
        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            _airlineDAO.Update(airline);
        }
        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            _airlineDAO.Remove(airline);
        }
        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
           _customerDAO.Add(customer);
        }
        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAO.Update(customer);
        }
        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            _customerDAO.Remove(customer);
        }
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            _adminDAO.Add(admin);
        }
        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            _adminDAO.Update(admin);
        }
        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            _adminDAO.Remove(admin);
        }

    }
}
