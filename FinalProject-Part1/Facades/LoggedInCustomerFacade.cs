﻿using System;
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


        public IList<Flight> GetAllFlightsByCustomer(LoginToken<Customer> token)
        {
            if (token != null)
            {
                return _flightDAO.GetFlightsByCustomer(token.User);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to get all customer flights. Please check your login details. Token is null.");
            }
        }


        public void UpdateCustomerDetails(LoginToken<Customer> token, Customer customer)
        {
            if (token != null)
            {
                //_userDAO.Update(customer.user);
                    _customerDAO.Update(customer);
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to update your details. Access is denied.");
            }
        }



        public Ticket PurchaseTicket(LoginToken<Customer> token, Flight flight)
        {
            //TODO get all user tickets and check if already purchased


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
            //DateTime ticketDepartureTime = ticket.flight.Departure_Time;
            //DateTime currentDateTime = DateTime.Now;

            if (token != null) 
            {
                //if (ticketDepartureTime < DateTime.Now)
                //{
                    _ticketDAO.Remove(ticket);
                //}
                //else
                //{
                //    logger.Error("Trying to cancel ticket for the flight that already departed.");
                //    throw new NullTokenException("It's impossible to cancel ticket for the flight that already departed.");
                //}
            }
            else
            {
                logger.Error("Error - token is null");
                throw new NullTokenException("There is a problem to cancel ticket. Please check your login details. Token is null.");
            }
        }

    }
}
