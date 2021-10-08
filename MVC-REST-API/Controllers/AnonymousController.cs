using FinalProject_Part1;
using FinalProject_Part1.Members;
using Microsoft.AspNetCore.Mvc;
using MVC_REST_API.DTO;
using MVC_REST_API.Mapppers;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {
        private readonly IMapper m_mapper;
        public AnonymousController (IMapper mapper)
        {
            m_mapper = mapper;
        }

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
        public async Task<ActionResult<List<Flight>>> GetAllFlights()
        {
            //AnonymousProfile profile = new AnonymousProfile();
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            List<Flight> result = null;
            try
            {
                List<Flight> list = await Task.Run(() => facade.GetAllFlights()) as List<Flight>;
                //List<FlightDTO> flightDTOList = new List<FlightDTO>();
                //foreach (Flight flight in list)
                //{
                //    //added our own m_mapper
                //    FlightDTO flightDTO = m_mapper.Map<Flight, FlightDTO>(flight);
                //    flightDTOList.Add(flightDTO);
                //}
                result = list;
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

        //[HttpGet("getflightsbyairline")]
        //public async Task<ActionResult<List<FlightDTO>>> GetFlightsByAirline()
        //{
        //    AirlineCompanyProfile profile = new AirlineCompanyProfile();

        //    AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
        //            token_airline, out LoggedInAirlineFacade facade);

        //    List<FlightDTO> result = null;
        //    try
        //    {
        //        List<Flight> list = await Task.Run(() => facade.GetFlightsByAirline(token_airline)) as List<Flight>;
        //        List<FlightDTO> flightDTOList = new List<FlightDTO>();

        //        foreach (Flight flight in list)
        //        {
        //            //added our own m_mapper
        //            FlightDTO flightDTO = m_mapper.Map<Flight, FlightDTO>(flight);

        //            if (flight.Departure_Time.CompareTo(DateTime.Now) >= 0)   // 
        //            {
        //                flightDTO.IsCancellable = true;
        //            }

        //            flightDTOList.Add(flightDTO);
        //        }
        //        result = flightDTOList;
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(400, $"{{ error: can't get all flights \"{ex.Message}\" }}");
        //    }
        //    if (result == null)
        //    {
        //        return StatusCode(204, "{The list is empty.}");
        //    }
        //    return Ok(result);
        //}



        [HttpGet("getallcountries/")]
        public async Task<ActionResult<Country>> GetAllCountries()
        {
            AnonymousUserFacade facade = new AnonymousUserFacade(false);

            IList<Country> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllCountries());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: can't get all countries \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list of countries is empty. Nothing to return. }");
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

        //// POST api/<AdminController>
        //[HttpPost("AddAirlineToWaitingList")]
        //public async Task<ActionResult> AddAirlineToWaitingList([FromBody] AirlineCompany airline)
        //{
        //    AnonymousUserFacade anonymousUserFacade = new AnonymousUserFacade(false);

        //    try
        //    {
        //        await Task.Run(() => anonymousUserFacade.AddAirlineToWaitingList(airline));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(501, $"{{ error: can't add new airline to awaiting list\"{ex.Message}\" }}");
        //    }
        //    return Ok();
        //}

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
