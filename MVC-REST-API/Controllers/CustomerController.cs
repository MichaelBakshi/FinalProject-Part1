using FinalProject_Part1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer> token_customer, out LoggedInCustomerFacade facade)
        {
            string jwtToken = Request.Headers["Authorization"];

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

            Customer customer = new CustomerDAOPGSQL().GetCustomerByUsername(userName);

            token_customer = new LoginToken<Customer>()
            {
                User = customer
            };

            facade = FlightsCenterSystem.Instance.GetFacade(token_customer) as LoggedInCustomerFacade;
        }

        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flight>> GetAllFlights()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllFlights());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ The list is empty. Nothing to display. }");
            }
            return Ok(result);
        }

        // GET: api/<CustomerController>
        [HttpGet("getallflightsbycustomer/")]
        public async Task<ActionResult<Customer>> GetAllFlightsByCustomer([FromBody]Customer customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllFlightsByCustomer(token_customer, customer ));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flights by customer \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There are no flights by this customer. The list is empty. }");
            }
            return Ok(result);
        }


        [HttpGet("getflightbyid/{flightid}")]
        public async Task<ActionResult<Flight>> GetFlightById(int flightid)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            Flight result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightById(flightid));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flight by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There is no flight by this id }");
            }
            return Ok(result);
        }

        // POST api/<CustomerController>
        [HttpPost("purchaseticket")]
        public async Task<ActionResult> PurchaseTicket([FromBody] Flight flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            Ticket ticket = null;

            try
            {
                ticket = await Task.Run(() => facade.PurchaseTicket(token_customer, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: failed to purchase ticket \"{ex.Message}\" }}");
            }

            return Ok(new { ticket });
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("cancelticket/")]
        public async Task<ActionResult<Customer>> CancelTicket([FromBody] Ticket ticket)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            try
            {
                await Task.Run(() => facade.CancelTicket(token_customer, ticket));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: failed to cancel ticket \"{ex.Message}\" }}");
            }

            return Ok("Ticket has been canceled");
        }
    }
}
