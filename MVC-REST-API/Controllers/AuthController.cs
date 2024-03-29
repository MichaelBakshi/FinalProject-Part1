﻿
using FinalProject_Part1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVC_REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AuthController(IConfiguration configuration)
        {

            Configuration = configuration;
        }


        [HttpPost("token")]
        public async Task<ActionResult> GetToken([FromBody] UserDTO userDetails)
        {
            // 1) try login, with userDetails

            ILoginToken token;

            bool loginSuccess = new LoginService().TryLogin(userDetails.UserName, userDetails.Password, out token);
            int user_role = userDetails.User_Role;

            // 1 login failed

            if (!loginSuccess)
            {
                return Unauthorized("login failed");
            }

            string securityKey = "(*&gH7*T(*O&YT*O&GT*O&GT*&T";

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();

            LoginToken<Administrator> token1 = token as LoginToken<Administrator>;
            LoginToken<AirlineCompany> token2 = token as LoginToken<AirlineCompany>;
            LoginToken<Customer> token3 = token as LoginToken<Customer>;

            //string userRole = "";

            if (token1 != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                claims.Add(new Claim("admin_id", token1.User.Id.ToString()));
                claims.Add(new Claim("username", token1.User.user.Username));
                claims.Add(new Claim("level", token1.User.Level.ToString()));
            }
            else if (token2 != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "AirlineCompany"));
                claims.Add(new Claim("airline_id", token2.User.Id.ToString()));
                claims.Add(new Claim("username", token2.User.user.Username));
            }
            else if (token3 != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Customer"));
                claims.Add(new Claim("customer_id", token3.User.Id.ToString()));
                claims.Add(new Claim("username", token3.User.user.Username));
            }
            else
            {
                return Unauthorized("user not recognized");
            }

            // 4) create token
            var jwtToken = new JwtSecurityToken(
            issuer: "issuer_of_flight_project", 
            audience: "flight_project_users", 
            expires: DateTime.Now.AddDays(double.Parse(Configuration["JWTTTL"])), 
            signingCredentials: signingCredentials,
            claims: claims);

            // 5) return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(jwtToken));
            //return Ok (user_role);
        }

    }
}
