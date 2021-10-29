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
        [Route("User/Token")]
        public async Task<ActionResult> Login (long id = 2008810342610546,[FromBody] string accessToken = "")
        {
            //var userData = await _client.GetUser(id,accessToken);
            //var newUser = new UserCreationDTO()
            //{
            //    UserID = userData.UserID,
            //    UserName = userData.FullName,
            //    UserProfileURL = userData.PictureUrl
            //};

            //var data = _processor.GenerateJwt(newUser.UserID,newUser.UserName);
            //return Ok(new { Bearer = data });
            //add rabbit

            await Task.Delay(5000);
            return Ok();
        }
        //[Authorize]
        [HttpPost]
        [Route("Test")]
        public async Task<ActionResult> getdata (long id= 2008810342610546,[FromBody] string access_token= "EAADm0S0jzhwBAM1srd2QTmAYI3Wd6syoYYFWEUDrQKjGT6sQH6tZCpBLJ9CucndzEkiyMKTtvOz6EPUZC2uj4mqR3jFE70DPcpmfMUAr3qZAdoSgFo11Tvcf2nzNw4q9IqSmZA4ZABjL8gIiVQeIfd35T9KgEjRu5gfhZAnhiIciYaF56TbmpvxwPvlXeOnYfQCaZCyd5eWoy7mUEGzYv6GPIcXvJfYYODVWpZC4GDoViBULdElv3138")
        {
            var user = await _client.GetUser(id, access_token);
            return Ok(user);
        }
    }
}
