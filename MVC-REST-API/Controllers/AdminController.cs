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
            //int id = Convert.ToInt32(decodedJwt.Claims.First(_ => _.Type == "admin_id").Value);

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

        //    //return new CreatedResult("/api/admin/getcompanybyid/" + company.Id, company);


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
                return StatusCode(400, $"{{ Error: Couldn't get the list of customers \"{ex.Message}\" }}");
                //logger.Error("Couldn't get all customers");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list of customers is empty.}");
            }
            return Ok(result);
        }


        // GET: api/<AdminController>
        [HttpGet("getallairlines/")]
        public async Task<ActionResult<Administrator>> GetAllAirlines()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            IList<AirlineCompany> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllAirlineCompanies(token_admin));
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ Error: Couldn't get the list of all airlines \"{ex.Message}\" }}");
                //logger.Error("Couldn't get all customers");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list of airlines is empty.}");
            }
            return Ok(result);
        }



        // GET: api/<AdminController>
        [HttpGet("getallawaitingairlines/")]
        public async Task<ActionResult<Administrator>> GetAllAwaitingAirlines()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            IList<AirlineAwaitingConfirmation> result = null;
            try
            {
                result = await Task.Run(() => facade.GetAllAwaitingAirlineCompanies());
            }
            catch (Exception ex)
            {
                return StatusCode(400, $"{{ Error: Couldn't get the list of airlines awaiting for confirmation by administrator \"{ex.Message}\" }}");
                //logger.Error("Couldn't get all customers");
            }
            if (result == null)
            {
                return StatusCode(204, "{The list of airlines awaiting for confirmation is empty.}");
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
                return StatusCode(501, $"{{ error: can't create new airline \"{ex.Message}\" }}");
            }
            return Ok(airline);
            //return Created("ur_for_get_method/new_airline_id", airline);
        }

        // POST api/<AdminController>
        [HttpPost("AddConfirmedAirlineCompany")]
        public async Task<ActionResult> AddConfirmedAirlineCompany([FromBody] AirlineAwaitingConfirmation airlineAwaitingConfirmation)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.AddConfirmedAirlineCompany(token_admin, airlineAwaitingConfirmation));
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"{{ error: can't confirm airline and add it to final list\"{ex.Message}\" }}");
            }
            return Ok(airlineAwaitingConfirmation);
            //return Created("ur_for_get_method/new_airline_id", airline);
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
                return StatusCode(400, $"{{ error: can't remove airline from the list. \"{ex.Message}\" }}");
            }
            
            return Ok("Deleted");
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
                return StatusCode(500, $"{{ error: can't create new customer \"{ex.Message}\" }}");
            }

            return Ok(customer);
        }

        [HttpPut("UpdateCustomerDetails")]
        public async Task<ActionResult> UpdateCustomerDetails([FromBody] Customer [] customers)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            try
            {
                foreach (var customer in customers)
                {
                    await Task.Run(() => facade.UpdateCustomerDetails(token_admin, customer));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: can't update customer details \"{ex.Message}\" }}");
            }
            return Ok();
        }


        // PUT api/<AdminController>/5
        [HttpPut("UpdateAirline")]
        public async Task<ActionResult> UpdateAirline([FromBody] AirlineCompany [] airlines)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);
            try
            {
                foreach (var airline in airlines)
                {
                    await Task.Run(() => facade.UpdateAirlineDetails(token_admin, airline));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(501, $"{{ error: can't update airline details \"{ex.Message}\" }}");
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
                return StatusCode(400, $"{{ error: can't remove customer \"{ex.Message}\" }}");
            }

            return Ok("Deleted");
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
                return StatusCode(500, $"{{ error: can't create new administrator \"{ex.Message}\" }}");
            }

            return Ok(admin);
        }


        // GET api/<AdminController>/5
        [HttpGet("getadminbyid")]
        public async Task<ActionResult<Flight>> GetAdminById()
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            Administrator result = null;
            try
            {
                result = await Task.Run(() => facade.GetAdminById(token_admin.User.Id));
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




        [HttpPut("UpdateAdminDetails")]
        public async Task<ActionResult> UpdateAdminDetails([FromBody] Administrator administrator)
        {
            AuthenticateAndGetTokenAndGetFacade(out LoginToken<Administrator>
                    token_admin, out LoggedInAdministratorFacade facade);

            try
            {
                await Task.Run(() => facade.UpdateAdmin(token_admin, administrator));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{{ error: can't update administrator details \"{ex.Message}\" }}");
            }

            return Ok("Updated: " + administrator);
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
                return StatusCode(400, $"{{ error: can't remove administrator \"{ex.Message}\" }}");
            }

            return Ok("Deleted");
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
                return StatusCode(500, $"{{ error: can't create new user \"{ex.Message}\" }}");
            }

            return Ok(user);
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
                return StatusCode(400, $"{{ error: can't remove the user \"{ex.Message}\" }}");
            }

            return Ok("Deleted");
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
                return StatusCode(500, $"{{ error: can't create ticket \"{ex.Message}\" }}");
            }

            return Ok(ticket);
        }



    }
}
