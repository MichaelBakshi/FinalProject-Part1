using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInCustomerFacade: AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            throw new NotImplementedException();
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            throw new NotImplementedException();
        }
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            throw new NotImplementedException();
        }

    }
}
