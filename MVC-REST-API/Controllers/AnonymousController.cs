using FinalProject_Part1;
using Microsoft.AspNetCore.Mvc;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {

        // GET: api/<AnonymousController>
        [HttpGet("getallairlinecompanies/")]
        public async Task<ActionResult<AirlineCompany>> GetAllAirlineCompanies()
        {
             AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<AirlineCompany> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllAirlineCompanies());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get all airline comapnies \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list is empty. No result to return }");
            }
            return Ok(result);
        }

        [HttpGet("getallflights/")]
        public async Task<ActionResult<Flight>> GetAllFlights()
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Flight> result = null;
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
                return StatusCode(204, "{The list of flight is empty. Nothing to return. }");
            }
            return Ok(result);
        }

        [HttpGet("getflightbyid")]
        public async Task<ActionResult<Flight>> GetFlightById(int flightid)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            Flight result = null;
            try
            {
                Flight flight = await Task.Run(() => facade.GetFlightById(flightid));
               
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flight by this id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{No flight by this id. }");
            }
            return Ok(result);
        }

        [HttpGet("getairlinebyid/{airlineid}")]
        public async Task<ActionResult<AirlineCompany>> GetAirlineById(int airlineid)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            Flight result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightById(airlineid));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get airline by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{No airline by this id }");
            }
            return Ok(result);
        }

        [HttpGet("getcustomerbyid/{customerid}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerid)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            Customer result = null;
            try
            {
                result = await Task.Run(() => facade.GetCustomerById(customerid));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get customer by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{No customer by this id. }");
            }
            return Ok(result);
        }

        [HttpGet("getadminbyid/{adminid}")]
        public async Task<ActionResult<Customer>> GetAdminById(int adminid)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            Administrator result = null;
            try
            {
                result = await Task.Run(() => facade.GetAdminById(adminid));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get administrator by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{No administrator by this id. }");
            }
            return Ok(result);
        }

        [HttpGet("getticketbyid/{ticketid}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int ticketid)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            Ticket result = null;
            try
            {
                result = await Task.Run(() => facade.GetTicketById(ticketid));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get ticket by id \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There is no ticket by this id }");
            }
            return Ok(result);
        }

        [HttpGet("getflightsbyorigincountry/{countrycode}")]
        public async Task<ActionResult<Flight>> GetFlightsByOriginCountry(int countrycode)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByOriginCountry(countrycode));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flights by origin country \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There are no flights by this origin country }");
            }
            return Ok(result);
        }


        [HttpGet("getflightsbydestinationcountry/{countrycode}")]
        public async Task<ActionResult<Flight>> GetFlightsByDestinationCountry(int countrycode)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByDestinationCountry(countrycode));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flights by destination country \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There are no flights by this destination country }");
            }
            return Ok(result);
        }


        [HttpGet("getflightsbydeparturedate/{datetime}")]
        public async Task<ActionResult<Flight>> GetFlightsByDepartureDate(DateTime dateTime)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByDepartureDate(dateTime));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flights by departure date \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There are no flights by this departure date }");
            }
            return Ok(result);
        }


        [HttpGet("getflightsbylandingdate/{datetime}")]
        public async Task<ActionResult<Flight>> GetFlightsByLandingDate(DateTime dateTime)
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Flight> result = null;
            try
            {
                result = await Task.Run(() => facade.GetFlightsByLandingDate(dateTime));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get flights by landing date \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{There are no flights by this departure date }");
            }
            return Ok(result);
        }


        [HttpPost("SignUpCustomer")]
        public async Task<ActionResult> SignUpCustomer([FromBody] Customer customer)
        {

            AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade(false);

            try
            {
                await Task.Run(() => anonymousUserFacade.SignUpCustomer(customer));
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"{{ error: can't sign up a new customer\"{ex.Message}\" }}");
            }
            return Ok(customer);
            //return Created("ur_for_get_method/new_airline_id", airline);
        }


        [HttpPost("SignUpAirline")]
        public async Task<ActionResult> SignUpAirline([FromBody] AirlineCompany airline)
        {

            AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade(false);

            try
            {
                await Task.Run(() => anonymousUserFacade.SignUpAirline(airline));
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"{{ error: can't sign up a new airline\"{ex.Message}\" }}");
            }
            return Ok(airline);
            //return Created("ur_for_get_method/new_airline_id", airline);
        }


        [HttpPost("SignUpAdmin")]
        public async Task<ActionResult> SignUpAdmin([FromBody] Administrator administrator)
        {

            AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade(false);

            try
            {
                await Task.Run(() => anonymousUserFacade.SignUpAdmin(administrator));
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"{{ error: can't sign up a new administrator\"{ex.Message}\" }}");
            }
            return Ok(administrator);
            //return Created("ur_for_get_method/new_airline_id", airline);
        }




        // POST api/<AnonymousController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnonymousController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnonymousController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
