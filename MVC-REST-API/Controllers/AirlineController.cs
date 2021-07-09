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
    //[Authorize(Roles = "Airline")]

    public class AirlineController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany> token_airline, out LoggedInAirlineFacade facade)
        {
            string jwtToken = Request.Headers["Authorization"];

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

            AirlineCompany airline = new AirlineDAOPGSQL().GetAirlineByUsername(userName);

            token_airline = new LoginToken<AirlineCompany>()
            {
                User = airline
            };

            facade = FlightsCenterSystem.Instance.GetFacade(token_airline) as LoggedInAirlineFacade;
        }


        [HttpGet("getallflights/")]
        public async Task<ActionResult<AirlineCompany>> GetAllFlights()
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
                return StatusCode(400, $"{{ error: can't get all flights \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list is empty.}");
            }
            return Ok(result);
        }

        [HttpGet("getalltickets/")]
        public async Task<ActionResult<AirlineCompany>> GetAllTickets()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            IList<Ticket> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllTickets(token_airline));
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
        [HttpGet("getairlinebyid")]
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
                return StatusCode(400, $"{{ error: can't get airline by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There's no airline by this id. }");
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
                return StatusCode(500, $"{{ error: can't add new flight \"{ex.Message}\" }}");
            }

            return Ok(flight);
        }

        // PUT api/<AirlineController>/5
        [HttpPut("UpdateFlight")]
        public async Task<ActionResult> UpdateFlight([FromBody] Flight flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: can't update flight details \"{ex.Message}\" }}");
            }

            return Ok("Updated: " + flight);
        }

        // DELETE api/<AirlineController>/5
        [HttpDelete("cancelflight/")]
        public async Task<ActionResult<AirlineCompany>> CancelFlight([FromBody] Flight flight)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.CancelFlight(token_airline, flight));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't cancel the filght \"{ex.Message}\" }}");
            }

            return Ok("Flight is cancelled");
        }

        [HttpPut("changepassword")]
        public async Task<ActionResult> ChangePassword([FromBody] AirlineCompany airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.ChangeMyPassword(token_airline, airline.Password, airline.NewPassword));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: can't change the password\"{ex.Message}\" }}");
            }

            return Ok("New password has been created" );
        }

        [HttpPut("modifyairlinedetails")]
        public async Task<ActionResult> ModifyAirlineDetails([FromBody] AirlineCompany airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            try
            {
                await Task.Run(() => facade.MofidyAirlineDetails(token_airline, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: can't modify airline details \"{ex.Message}\" }}");
            }

            return Ok("Updated " + airline);
        }


    }
}
