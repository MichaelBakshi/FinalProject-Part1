using AutoMapper;
using FinalProject_Part1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_REST_API.DTO;
using MVC_REST_API.Mapppers;
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
        //added
        private readonly IMapper m_mapper;
        
        public AirlineController(IMapper mapper)
        {
            m_mapper = mapper;
        }
        //added - END


        private void AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany> token_airline, out LoggedInAirlineFacade facade)
        {
            string jwtToken = Request.Headers["Authorization"];

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            //int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

            AirlineCompany airline = new AirlineDAOPGSQL().GetAirlineByUsername(userName);

            token_airline = new LoginToken<AirlineCompany>()
            {
                User = airline
            };

            if (airline == null)
            {
                throw new Exception("Token not correct");
            }

            

            facade = FlightsCenterSystem.Instance.GetFacade(token_airline) as LoggedInAirlineFacade;
        }


        [HttpGet("getallflights")]
        public async Task<ActionResult<List<FlightDTO>>> GetAllFlights()
        {
            AirlineCompanyProfile profile = new AirlineCompanyProfile();

            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            List<FlightDTO> result = null;
            try
            {
                
                List<Flight> list = await Task.Run(() => facade.GetAllFlights()) as List<Flight>;
                List<FlightDTO> flightDTOList = new List<FlightDTO>();

                foreach(Flight flight in list)
                {
                    //added our own m_mapper
                    FlightDTO flightDTO = m_mapper.Map<Flight, FlightDTO>(flight);
                    flightDTOList.Add(flightDTO);
                }
                result = flightDTOList;
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


        [HttpGet("getallflightsbyairline")]
        public async Task<ActionResult<List<FlightDTO>>> GetAllFlightsByAirline()
        {
            AirlineCompanyProfile profile = new AirlineCompanyProfile();

            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            List<FlightDTO> result = null;
            try
            {

                List<Flight> list = await Task.Run(() => facade.GetAllFlightsByAirline(token_airline)) as List<Flight>;
                List<FlightDTO> flightDTOList = new List<FlightDTO>();

                foreach (Flight flight in list)
                {
                    //added our own m_mapper
                    FlightDTO flightDTO = m_mapper.Map<Flight, FlightDTO>(flight);
                    flightDTOList.Add(flightDTO);
                }
                result = flightDTOList;
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




        [HttpGet("getalltickets")]
        public async Task<ActionResult<List<TicketDTO>>> GetAllTickets()
        {
            TicketProfile ticketProfile = new TicketProfile();

            AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
                    token_airline, out LoggedInAirlineFacade facade);

            List<TicketDTO> result = null;
            try
            {
                List<Ticket> list = await Task.Run(() => facade.GetAllTickets(token_airline)) as List<Ticket>;
                List<TicketDTO> ticketDTOList = new List<TicketDTO>();

                foreach (Ticket ticket in list)
                {
                    TicketDTO ticketDTO = m_mapper.Map<Ticket, TicketDTO>(ticket);
                    ticketDTOList.Add(ticketDTO);
                }
                result = ticketDTOList;
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

        //[HttpGet("getallairlinecompanies/")]
        //public async Task<ActionResult<AirlineCompany>> GetAllAirlineCompanies()
        //{
        //    AnonymousUserFacade facade = new AnonymousUserFacade(false);

        //    IList<AirlineCompany> result = null;
        //    try
        //    {
        //        result = await Task.Run(() => facade.GetAllAirlineCompanies());
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"{{ error: can't get all airline comapnies \"{ex.Message}\" }}");
        //    }
        //    if (result == null)
        //    {
        //        return StatusCode(204, "{The list is empty. No result to return }");
        //    }
        //    return Ok(result);
        //}

        // GET api/<AirlineController>/5
        [HttpGet("getairlinebyid/{airlineId}")]
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
        //  return CreatedAtRoute(nameof(GetTestByIdv1), new { id = id });
        //return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);

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
