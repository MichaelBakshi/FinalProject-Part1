using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public interface ILoggedInCustomerFacade
    {
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token);
        Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight);
        void CancelTicket(LoginToken<Customer> token, Ticket ticket);

    }
}
