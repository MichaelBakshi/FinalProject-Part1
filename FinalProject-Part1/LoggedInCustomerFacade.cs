using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInCustomerFacade: AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            return _flightDAO.GetAll();
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            throw new NotImplementedException();
        }
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            _ticketDAO.Remove(ticket);
        }

    }
}
