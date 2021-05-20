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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("getflight/{flightid}")]
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
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //new LoggedInCustomerFacade().PurchaseTicket(token,flight);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
