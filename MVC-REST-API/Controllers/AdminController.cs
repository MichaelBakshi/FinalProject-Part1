using AutoMapper;
using FinalProject_Part1;
using FinalProject_Part1.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_REST_API.DTO;
using Newtonsoft.Json;
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
    //[Authorize(Roles = "Administrator")]

    public class AdminController : ControllerBase
    {

        private void AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        {
            string jwtToken = Request.Headers["Authorization"];

            jwtToken = jwtToken.Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;

            string userName = decodedJwt.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "userid").Value);

            Administrator administrator = new AdminDAOPGSQL().GetAdminByUsername(userName);

            token_admin = new LoginToken<Administrator>()
            {
                User = administrator
            };

            facade = FlightsCenterSystem.Instance.GetFacade(token_admin) as LoggedInAdministratorFacade;
        }






        private ILoggedInAdministratorFacade m_facade;
        private readonly IMapper m_mapper;

        //the DI goes here

        // 1. i can choose to work with DI or not...
        // 2. we get here the admin facade
        //    it could be AdminFacade or AdminFacade Micro service

        public AdminController(ILoggedInAdministratorFacade adminFacade, IMapper mapper)
        {
            m_facade = new LoggedInAdministratorFacade(false);

            m_facade = adminFacade;
            m_mapper = mapper;
        }

        /// <summary>
        /// Get list of all the tickets belonging to the logged-in airline company
        /// add xml config in order for this responses to show in the swagger page
        /// </summary>
        /// <param name = "airlineCompanyCreationDTO" ></ param >
        /// < returns > List of all the tickets</returns>
        /// <response code = "200" > Returns the list of tickets</response>
        /// <response code = "204" > If the list of tickets is empty</response>
        //   / <response code = "401" > If the user is not authenticated as airline company</response> 

        //[HttpPost("createairline")]
        //public async Task<IActionResult> CreateAirline([FromBody]  AirlineCompany airline)
        //{

        //    AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
        //            token_admin, out LoggedInAdministratorFacade facade);

        //    try
        //    {
        //        await Task.Run(() => facade.CreateNewAirline(token_admin, airline));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
        //    }

        //    return Ok(new { airline});



        //    //m_facade.CreateNewAirline(token, company);
        //    //// ...
        //    ////  return CreatedAtRoute(nameof(GetTestByIdv1), new { id = id });
        //    //return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);
        //}



        // GET api/<AdminController>/5
        [HttpGet("getadminbyid/{adminid}")]
        public async Task<ActionResult<Flight>> GetAdminById(int adminid)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            Administrator result = null;
            try
            {
                result = await Task.Run(() => facade.GetAdminById(adminid));
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



        //public async Task<ActionResult> AddNewFlight([FromBody] Flight flight)
        //{
        //    AuthenticateAndGetTokenAndGetFacade(out LoginToken<AirlineCompany>
        //            token_airline, out LoggedInAirlineFacade facade);

        //    try
        //    {
        //        await Task.Run(() => facade.CreateFlight(token_airline, flight));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
        //    }

        //    return Ok();
        //}


        //[HttpGet("getairline")]
        //public async Task<ActionResult<AirlineDTO>> GetAirline()
        //{
        //     //access facade
        //     //request flight
        //     //let's pretend this flight was returned
        //    AirlineCompany company = new AirlineCompany()
        //    {
        //        Country_Id = 1,
        //        Id = 2,
        //        Name = "El-al",
        //        Password = "LikeHome12345678"
        //    };
        //    LoginToken<Administrator> token = GetLoginToken();

        //    AirlineDTO airlineDTO = m_mapper.Map<AirlineDTO>(company);

        //    return Ok(JsonConvert.SerializeObject(airlineDTO));

        //}





        //        private void AuthenticateAndGetTokenAndGetFacade(out
        //            LoginToken<Administrator> token_admin, out LoggedInAdministratorFacade facade)
        //        {
        //            GlobalConfig.GetConfiguration(false);

        //            ILoginToken token;
        ////            LoginService loginService = new LoginService();
        //            //loginService.TryLogin("John_Doe", "johndoe", out token);    // TODO fix this later
        //            token = GetLoginToken();
        //            token_admin = token as LoginToken<Administrator>;
        //            facade = FlightsCenterSystem.Instance.GetFacade(token_admin) as LoggedInAdministratorFacade;
        //        }





        // POST api/<AdminController>
        //[HttpPost("AddNewUser")]
        //public async Task<ActionResult> AddNewUser([FromBody] User user)
        //{
        //    AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
        //            token_admin, out LoggedInAdministratorFacade facade);

        //    try
        //    {
        //        await Task.Run(() => facade.CreateUser(token_admin, user));
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
        //    }

        //    return Ok();
        //}


        //   [HttpPost("createairline")]
        //public async Task<IActionResult> CreateAirline(AirlineCompanyCreationDTO airlineCompanyCreationDTO)
        //{
        //    AirlineCompany company = new AirlineCompany()
        //    {
        //        Id = 1,
        //        CountryId = 12,
        //        Name = "El-Al"
        //    };
        //    LoginToken<Administrator> token = GetLoginToken();

        //    m_facade.CreateAirline(token, company);
        //    ...
        //      return CreatedAtRoute(nameof(GetTestByIdv1), new { id = id });
        //    return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);
        //}











        // GET: api/<AdminController>
        [HttpGet("getallcustomers/")]
        public async Task<ActionResult<Administrator>> GetAllCustomers()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            IList<Customer> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllCustomers(token_admin));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
                //logger.Error("Couldn't get all customers");
            }
            if (result == null)
            {
                return StatusCode(204, "{ }");
            }
            return Ok(result);
        }

        // POST api/<AdminController>
        [HttpPost("AddNewAirline")]
        public async Task<ActionResult> AddNewAirline([FromBody] AirlineUser airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateUser(token_admin, airline.UserDetails));
                await Task.Run(() => facade.CreateNewAirline(token_admin, airline.AirlineCompanyDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }
            return Ok();
            //return Created("ur_for_get_method/new_airline_id", airline);
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
        public async Task<ActionResult<Administrator>> RemoveAirline([FromBody] AirlineUser airline)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveAirline(token_admin, airline.AirlineCompanyDetails));
                await Task.Run(() => facade.RemoveUser(token_admin, airline.UserDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }
            
            return Ok();
        }

        [HttpPost("createnewcustomer")]
        public async Task<ActionResult> CreateNewCustomer([FromBody] CustomerUser customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateUser(token_admin, customer.UserDetails));
                await Task.Run(() => facade.CreateNewCustomer(token_admin, customer.CustomerDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPut("UpdateCustomerDetails")]
        public async Task<ActionResult> UpdateCustomerDetails([FromBody] Customer customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateCustomerDetails(token_admin, customer));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpDelete("removecustomer/")]
        public async Task<ActionResult<Administrator>> RemoveCustomer([FromBody] CustomerUser customer)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveCustomer(token_admin, customer.CustomerDetails));
                await Task.Run(() => facade.RemoveUser(token_admin, customer.UserDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("createnewadministrator")]
        public async Task<ActionResult> CreateNewAdministrator([FromBody] AdminUser admin)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateUser(token_admin, admin.UserDetails));
                await Task.Run(() => facade.CreateAdmin(token_admin, admin.AdministratorDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPut("UpdateAdminDetails")]
        public async Task<ActionResult> UpdateAdminDetails([FromBody] Administrator administrator)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateAdmin(token_admin, administrator));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpDelete("removeadministrator/")]
        public async Task<ActionResult<Administrator>> RemoveAdministrator([FromBody] AdminUser admin)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveAdmin(token_admin, admin.AdministratorDetails));
                await Task.Run(() => facade.RemoveUser(token_admin, admin.UserDetails));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("createnewuser")]
        public async Task<ActionResult> CreateNewUser([FromBody] User user)
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

        [HttpDelete("removeuser/")]
        public async Task<ActionResult<Administrator>> RemoveUser([FromBody] User user)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.RemoveUser(token_admin, user));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }

        [HttpPost("createticket")]
        public async Task<ActionResult> CreateNewTicket([FromBody] Ticket ticket)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.CreateTicket(token_admin, ticket));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: \"{ex.Message}\" }}");
            }

            return Ok();
        }



    }
}
