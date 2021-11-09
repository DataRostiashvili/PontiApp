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
using PontiApp.EventPlace.Services.UserServices;

namespace PontiApp.Auth.Controllers
{
    public class AccountController : Controller
    {
        private readonly IJwtProcessor _processor;

        private readonly IFbClient _client;

        private readonly IHttpClientFactory _factory;

        private readonly IUserService _userService;


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
        public async Task<ActionResult> Login(long id = 2008810342610546, [FromBody] string accessToken = "EAADm0S0jzhwBAMYmENXA986FfypjUg4bytPN6EbflX6uSSSi6x5WHvDYCrTPpU2G1dfSjO2LWQQ6Xy4LcvY2VLZCdUNCTbT94lNMBlT0PNvlyLW0C9Vfcj9TZAdJilZCJvzMZBgo7NbZAAXegsEqhR1wQcZBQkrZCvB4zZCUhG2nDsrquSdJsumHM0gaJJ7ftytWfxZBVORKpvwZDZD")
        {
            var jwt = _processor.GenerateJwt(id, accessToken);
            return Ok(new
            {
                Bearer = jwt,
            });
        }
    }
}
