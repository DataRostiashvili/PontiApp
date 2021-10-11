using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.Auth.Controllers
{
    public class AccountController:Controller
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
        public async Task<ActionResult> Login(long id=2008810342610546,[FromBody]string accessToken= "EAADm0S0jzhwBAMTApKgwf2S1qSgDCKl7vNe4ChZBvD7i1KqyZBKkDv0ZAZBrEkJk8G1DIl353GfxJlKLsnsZCtxIfW8GH70fZAQAU7ZCE0kvVV2Ex5wMdR0Ta5FWeROQV3M6NMplEDALPGQmw9EIt6ZCwPnVbJF8qIXg3zVEomcHkZBn0kbhIlbSaNpAaHTepLj3JmUflvesElgZDZD")
        {
            var data = await _client.GetUser(id,accessToken);
            var token = _processor.GenerateJwt(data.UserID,data.FullName);
            var current = User.Identity.Name;
            return Ok(new
            {
                Token = token,
                Current = current
            });
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
    }
}
