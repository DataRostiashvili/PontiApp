using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using PontiApp.Models.DTOs;
using PontiApp.User.Service;
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

        private readonly IUserService _service;

        public AccountController (IFbClient client,IJwtProcessor processor,IUserService service)
        {
            _service = service;
            _client = client;
            _processor = processor;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login (long id = 2008810342610546,[FromBody] string accessToken = "EAADm0S0jzhwBAGQATTHjqZBwhoUiFFx1CKRNAve2rdff8b5ppzNVH3GBVqxqJiOTLn5JivJOO7m4pLfgrZBNead9YqlEPNEGMIydrZBipvZBZCsZBtYuLEG7UChmcCqiv2PPSf54MK9HIkOR8c1PHa1hqYDG8DuXvv8h249wejqoZBJ9tXZB35gTVl3TnEfYPqHvwblECfiZCSQZDZD")
        {
            var data = await _client.GetUser(id,accessToken);
            var newUser = new UserCreationDTO()
            {
                UserID = data.UserID,
                UserName = data.FullName,
                UserProfileURL = data.PictureUrl
            };
            if (!await _service.CheckIfUserExists(newUser.UserID))
            {
               await _service.AddUser(newUser);
            }
            var token = _processor.GenerateJwt(newUser.UserID,newUser.UserName);
            return Ok(token);
        }
    }
}
