using FinalProject_Part1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out
            LoginToken<Customer> token_customer, out LoggedInCustomerFacade facade)
        {
            GlobalConfig.GetConfiguration(false);

            ILoginToken token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("AsafCohen", "asafcohen", out token);
            
            token_customer = token as LoginToken<Customer>;
            facade = FlightsCenterSystem.Instance.GetFacade(token_customer) as LoggedInCustomerFacade;
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
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
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
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(result);
        }

        // POST api/<CustomerController>
        [HttpPost("purchaseticket")]
        public async Task<ActionResult> PurchaseTicket([FromBody] Flight flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Customer>
                    token_customer, out LoggedInCustomerFacade facade);

            try
            {
                await Task.Run(() => facade.PurchaseTicket(token_customer, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
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
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }
    }
}
