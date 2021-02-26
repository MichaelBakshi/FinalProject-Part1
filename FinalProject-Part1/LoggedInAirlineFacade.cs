using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Part1
{
    class LoggedInAirlineFacade : AnonymousUserFacade, ILoggedInAirlineFacade
    {
        public IList<Ticket> GetAllTickets(LoginToken<AirlineCompany> token)
        {
            return _ticketDAO.GetAll();
        }
        public IList<Flight> GetAllFlights(LoginToken<AirlineCompany> token)
        {
            return _flightDAO.GetAll();
        }
        public void CancelFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            _flightDAO.Remove(flight);
        }
        public void CreateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            _flightDAO.Add(flight);
        }
        public void UpdateFlight(LoginToken<AirlineCompany> token, Flight flight)
        {
            _flightDAO.Update(flight);
        }
        public void ChangeMyPassword(LoginToken<AirlineCompany> token, string oldPassword, string newPassword)
        {
            if (oldPassword==token.User.user.Password)
            {
                token.User.user.Password = newPassword;
                _airlineDAO.Update(token.User);
                //log4net
            }
            else
            {
                throw new WrongCredentialsException("The old password is incorrect. Please try agsin.");
                //log4net
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
