using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC_REST_API.DTO;
using System;
using System.Collections.Generic;
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
        [HttpPost("token")]
        public async Task<ActionResult> GetToken([FromBody] UserDetailsDTO userDetails)
        {
            // 1) try login, with userDetails

            // await call FlightSystemCenter.Login(userDetails.Name, userDetails.Password);
            // 1 login failed
            //if (loginResult == false)
            //{
            //return Unauthorized("login failed");
            //}
            // 2 success 
            //   facade, LoginToken<T>, role 

            // 2) create key
            string securityKey = "this_is_our_supper_long_security_key_for_token_validation_project";

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            // 3) create claim for specific role
            // add claims
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "Administrator")); // --> here use the role from the login result
            claims.Add(new Claim("user_id", "1")); // --> here use the user_id from the result
            claims.Add(new Claim("username", "admin1")); // --> here use the name from the login result

            // 4) create token
            var token = new JwtSecurityToken(
            issuer: "issuer_of_flight_project", 
            audience: "flight_project_users", 
            expires: DateTime.Now.AddHours(1), // should be configurable
            signingCredentials: signingCredentials,
            claims: claims);

            // 5) return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

    }
}
