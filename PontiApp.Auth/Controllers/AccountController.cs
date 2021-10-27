using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IJwtProcessor _processor;

        private readonly IFbClient _client;


        public AccountController (IFbClient client,IJwtProcessor processor)
        {
            //_service = service;
            _client = client;
            _processor = processor;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult> Login (long id = 2008810342610546,[FromBody] string accessToken = "")
        {
            var userData = await _client.GetUser(id,accessToken);
            var newUser = new UserCreationDTO()
            {
                UserID = userData.UserID,
                UserName = userData.FullName,
                UserProfileURL = userData.PictureUrl
            };

            var data = _processor.GenerateJwt(newUser.UserID,newUser.UserName);
            return Ok(new { Bearer = data });
        }
        [Authorize]
        [HttpGet("get-data")]
        public ActionResult getdata ()
        {
            return Ok(new
            {
                success = "true",
                time = DateTime.UtcNow
            });
        }
    }
}
