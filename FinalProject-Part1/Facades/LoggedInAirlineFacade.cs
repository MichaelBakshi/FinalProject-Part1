using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    public class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoggedInAirlineFacade(bool testMode) : base(testMode)
        {
            GlobalConfig.GetConfiguration(testMode);
        }
        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _ticketDAO.GetAll(); // get tickets by airline id
                // return _ticketDAO.GetTicketsByAirlineId(token.User.Id);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all tickets. Please check your login details.");
            }
        }
        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _flightDAO.GetAll();
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Remove(flight);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Add(flight);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            { 
                _flightDAO.Update(flight);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if (token != null)
            {
                if (oldPassword == token.User.user.Password)
                {
                    token.User.user.Password = newPassword;
                    _airlineDAO.Update(token.User);
                    //log4net
                }
                else
                {
                    throw new WrongCredentialsException("The old password is incorrect. Please try again.");
                    //log4net
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO.Update(airline);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.");
            }
        }

        
    }
}
