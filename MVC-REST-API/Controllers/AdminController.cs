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
    public class AdminController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out
            LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        {
            GlobalConfig.GetConfiguration(false);

            ILoginToken token;
            LoginService loginService = new LoginService();
            loginService.TryLogin("John_Doe", "johndoe", out token);

            token_admin = token as LoginToken<Administrator>;
            facade = FlightsCenterSystem.Instance.GetFacade(token_admin) as LoggedInAdministratorFacade;
        }

        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        [HttpPost("AddNewUser")]
        public async Task<ActionResult> AddNewUser([FromBody] User user)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateUser(token_admin, user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        // POST api/<AdminController>
        [HttpPost("AddNewAirline")]
        public async Task<ActionResult> AddNewAirline([FromBody] AirlineCompany airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateNewAirline(token_admin, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        // PUT api/<AdminController>/5
        [HttpPut("UpdateAirline")]
        public async Task<ActionResult> UpdateAirline([FromBody] AirlineCompany airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateAirlineDetails(token_admin, airline));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("removeairline/")]
        public async Task<ActionResult<Administrator>> RemoveAirline([FromBody] AirlineCompany airlineCompany)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                 await Task.Run(() => facade.RemoveAirline(token_admin, airlineCompany));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            
            return Ok();
        }
    }
}
