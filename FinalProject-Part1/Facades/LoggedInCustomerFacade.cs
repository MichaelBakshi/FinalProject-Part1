using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoggedInCustomerFacade: AnonymousUserFacade, ILoggedInCustomerFacade
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details. Token is null.");
            }
        }
        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            if (token != null)
            {
                Ticket t = new Ticket(flight.Id, token.User.Id);
                _ticketDAO.Add(t);
                return t;
            }

            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to purchase a ticket. Please check your login details. Token is null.");
            }
        }
        public void CancelTicket(LoginToken<Customer> token, Ticket ticket)
        {
            if (token != null)
            {
                _ticketDAO.Remove(ticket);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to cancel ticket. Please check your login details. Token is null.");
            }
        }

    }
}
