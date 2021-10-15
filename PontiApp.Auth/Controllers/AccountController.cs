using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontiApp.Auth.Models.Request;
using PontiApp.Auth.Models.Response;

namespace PontiApp.Auth.Controllers
{
    [ApiController]
    public class AccountController: ControllerBase
    {
        private readonly IJwtProcessor _processor;
        private readonly IFbClient _client;
        

        public AccountController (IFbClient client,IJwtProcessor processor)
        {
            _client = client;
            _processor = processor;
        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginRequest)
        {
           
            var data = await _client.GetUser(loginRequest.UserId,loginRequest.FacebookAccessToken);
            var token = _processor.GenerateJwt(data.UserID,data.FullName);
            var current = User.Identity.Name;
            
            return Ok(new LoginResponse{ jwtToken = token});
        }
        
        
        [HttpGet]
        [Route("getData")]
        public async Task<ActionResult> GetData (string JwtToken)
        {
            
            var validatedUser = _processor.ValidateJwt(JwtToken);
            var userID = validatedUser.Claims.ToList().FirstOrDefault(x => x.Type == "UserID").Value;
            var userName = validatedUser.Claims.ToList().FirstOrDefault(x => x.Type == "UserName").Value;
            return Ok(new
            {
                ID = userID,
                Name = userName
            });
            
        }
        
        [HttpGet]
        [Route(nameof(Echo))]
        public IActionResult Echo(string text)
        {
            return Ok(new
            {
                Text = text
            });
        }
    }
}   
