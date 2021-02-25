using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade
    {
        public IList<Customer> GetAllCustomers(LoginToken<Administrator> token)
        {
            throw new NotImplementedException();
        }
        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }
        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany customer)
        {
            throw new NotImplementedException();
        }
        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            throw new NotImplementedException();
        }
        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }
        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }
        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            throw new NotImplementedException();
        }
        public void CreateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }
        public void UpdateAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }
        public void RemoveAdmin(LoginToken<Administrator> token, Administrator admin)
        {
            throw new NotImplementedException();
        }

    }
}
