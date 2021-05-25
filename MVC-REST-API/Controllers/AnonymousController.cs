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
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
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
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(result);
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
