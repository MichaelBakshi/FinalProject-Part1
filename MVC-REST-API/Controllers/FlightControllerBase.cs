using FinalProject_Part1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_REST_API.Controllers
{
    public abstract class FlightControllerBase<T> : ControllerBase where T : IUser, new()
    {
        protected LoginToken<T> GetLoginToken()
        {
            string userName = User.Claims.First(_ => _.Type == "username").Value;
            int id = Convert.ToInt32(User.Claims.First(_ => _.Type == "userid").Value);

            LoginToken<T> login_token = new LoginToken<T>()
            {
                User = new T()
                {
                    Id = id,
                    Username = userName,
                    Password = "no password. created from JWT"
                }
            };
            return login_token;
        }
    }

}
