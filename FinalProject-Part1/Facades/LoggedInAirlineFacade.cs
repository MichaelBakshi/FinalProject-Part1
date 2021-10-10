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
                return _ticketDAO.GetAll();
                // get tickets by airline id
                //return _ticketDAO.GetTicketsByAirlineId(token.User.Id);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all tickets. Please check your login details. Token is null.");
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
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.Token is null.");
            }
        }

        public IList<Flight> GetFlightsByAirline(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _flightDAO.GetFlightsByAirline(token.User);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all flights. Please check your login details.Token is null.");
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
                throw new NullTokenException("There is a problem to cancel the flight. Please check your login details.Token is null.");
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
                throw new NullTokenException("There is a problem to create a flight. Please check your login details.Token is null.");
            }
        }
        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            { 
                if (flight.Id == 0)
                {
                    _flightDAO.Add(flight);
                }
                else
                {
                    _flightDAO.Update(flight);
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to update a flight. Please check your login details.Token is null.");
            }
        }
        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if (token != null)
            {
                if (oldPassword == token.User.user.Password)
                {
                    token.User.user.Password = newPassword;
                    _userDAO.Update(token.User.user);
                    //log4net
                }
                else
                {
                    logger.Debug($"Attempt to change Password for airline {token.User.Name} has failed. ");
                    throw new WrongCredentialsException("The old password is incorrect. Please try again.");
                }
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException($"There is a problem to to change Password for airline {token.User.Name}. Please check your login details.Token is null.");
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
                throw new NullTokenException("There is a problem to mofidy airline details. Please check your login details.Token is null.");
            }
        }

        
    }
}
