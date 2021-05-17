using FinalProject_Part1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnonymousController : ControllerBase
    {
        AnonymousUserFacade facade = new AnonymousUserFacade(false);

        [HttpGet]
        [Route("[Controller]/get-all")]
        public IList<Flight> GetAllFlights()
        {
            try
            {
                IList<Flight> flights = facade.GetAllFlights();
                return flights;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }



        // Example Functions:

        
        // GET: api/<AnonymousController>
        [HttpGet]
        public IEnumerable<string> Get1()
        {
            return new string[] { "value1", "value2" };
        }
        
        // GET api/<AnonymousController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
