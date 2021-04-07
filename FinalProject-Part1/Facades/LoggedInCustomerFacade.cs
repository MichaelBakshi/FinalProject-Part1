using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoggedInCustomerFacade: AnonymousUserFacade, ILoggedInCustomerFacade
    {
        public LoggedInCustomerFacade(bool testMode) : base(testMode)
        {
            GlobalConfig.GetConfiguration(testMode);
        }

        public IList<Flight> GetAllMyFlights(LoginToken<Customer> token)
        {
            if (token != null)
            {
                return _flightDAO.GetAll();
            }
            else
            {
                throw new Exception("There is a problem to get all flights. Please check your login details.");
            }
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            Ticket t = new Ticket(flight.Id, token.User.Id);
             _ticketDAO.Add(t);
            return t;
        }
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token != null)
            {
                _ticketDAO.Remove(ticket);
            }
        }

    }
}
