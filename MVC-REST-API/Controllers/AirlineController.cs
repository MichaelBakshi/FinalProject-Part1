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
    public class AirlineController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out
            LoginToken<AirlineCompany> token_airline, out LoggedInAirlineFacade facade)
        {
            GlobalConfig.GetConfiguration(false);

            ILoginToken token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("EL-AL", "elal", out token);

            token_airline = token as LoginToken<AirlineCompany>;
            facade = FlightsCenterSystem.Instance.GetFacade(token_airline) as LoggedInAirlineFacade;
        }


        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flight>> GetAllFlights()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            IList <Flight> result = null;
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
                return StatusCode(204, "{ }");
            }
            return Ok(result);
        }

        // GET api/<AirlineController>/5
        [HttpGet("getairlinebyid/{airlineid}")]
        public async Task<ActionResult<AirlineCompany>> GetAirlineById(int airlineid)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            AirlineCompany result = null;
            try
            {
                result = await Task.Run(() => facade.GetAirlineById(airlineid));
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

        // POST api/<AirlineController>
        [HttpPost("AddNewFlight")]
        public async Task<ActionResult> AddNewFlight([FromBody] Flight flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.CreateFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        // PUT api/<AirlineController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
