using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.GraphAPICalls;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Encodings;
using System.Text.Json;
using System.Text;

namespace PontiApp.Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IJwtProcessor _processor;

        private readonly IFbClient _client;

        private readonly IHttpClientFactory _factory;


        public AccountController(IFbClient client, IJwtProcessor processor, IHttpClientFactory factory)
        {
            //_service = service;
            _client = client;
            _processor = processor;
            _factory = factory;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("User/Token")]
        public async Task<ActionResult> Login(long id = 2008810342610546, [FromBody] string accessToken = "")
        {
            var userData = await _client.GetUser(id, accessToken);
            var apiClient = _factory.CreateClient("API");
            var json = JsonSerializer.Serialize(userData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var resp = await apiClient.PostAsync("http://pontiapp.eventplace.api/80/api/User/Process-User", content);
            var jwt = _processor.GenerateJwt(id, accessToken);
            return Ok(new
            {
                Bearer = jwt,
                User = json
            });
        }
        //[Authorize]
        [HttpPost]
        [Route("Test")]
        public async Task<ActionResult> getdata(long id = 2008810342610546, [FromBody] string access_token = "EAADm0S0jzhwBAM1srd2QTmAYI3Wd6syoYYFWEUDrQKjGT6sQH6tZCpBLJ9CucndzEkiyMKTtvOz6EPUZC2uj4mqR3jFE70DPcpmfMUAr3qZAdoSgFo11Tvcf2nzNw4q9IqSmZA4ZABjL8gIiVQeIfd35T9KgEjRu5gfhZAnhiIciYaF56TbmpvxwPvlXeOnYfQCaZCyd5eWoy7mUEGzYv6GPIcXvJfYYODVWpZC4GDoViBULdElv3138")
        {
            var user = await _client.GetUser(id, access_token);
            return Ok(user);
        }
    }
}
