using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            if (token != null)
            {
                return _ticketDAO.GetAll();
            }
            else
            {
                throw new Exception("There is a problem to get all tickets. Please check your login details.");
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
                throw new Exception("There is a problem to get all flights. Please check your login details.");
            }
        }
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            {
                _flightDAO.Remove(flight);
            }
        }
        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token!=null)
            {
                _flightDAO.Add(flight);
            }
        }
        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            if (token != null)
            { 
                _flightDAO.Update(flight);
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
        }
        public void MofidyAirlineDetails(LoginToken<AirlineCompany> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO.Update(airline);
            }
        }

    }
}
