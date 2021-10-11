using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
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
            _client = client;
            _processor = processor;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login (long id = 2008810342610546,[FromBody] string accessToken = "EAADm0S0jzhwBAJZCGZBvu3WZBAIX5RU61NGnZCrxZAvkv8Slp5Vq6uDq4OHYtYb6iMwPzlHmRpe9MCZBVI48XfyZCKsH5GFpZCdZBlHfI72ZAun3fUDHud2fuDIpQorc0ZBAY46tsD5QEJCGunlzwka3P60cbpIXWFXPtyHPNp5pulopV3QvL9mwGpnZANjKEKBtVt6zqxdiq3vICgZDZD")
        {
            var data = await _client.GetUser(id,accessToken);
            //Check if exists
            var token = _processor.GenerateJwt(data.UserID,data.FullName);
            var current = User.Identity.Name;
            HttpContext.Items.Add("UserToken",token);
            return Ok(token);
        }

        [HttpGet]
        [Route("getData")]
        public ActionResult GetData (string token)
        {
            var validUser = _processor.ValidateJwt(token);
            var userId = validUser.Claims.First(x => x.Type == "UserID").Value;
            var userName = validUser.Claims.First(x => x.Type == "UserName").Value;
            return Ok(new
            {
                userId,
                userName
            });
        }
    }
}
