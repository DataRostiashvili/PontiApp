using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.User;
using PontiApp.GraphAPICalls;
using PontiApp.MessageSender;
using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontiApp.User.Services;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly MessagingService _service;
        private readonly IJwtProcessor _jwtProcessor;
        private readonly IFbClient _fbClient;

        public UserController(IUserService userService, MessagingService service, IJwtProcessor jwtProcessor, IFbClient fbClient)
        {
            _service = service;
            _userService = userService;
            _jwtProcessor = jwtProcessor;
            _fbClient = fbClient;
        }

        [HttpPut]
        [Route(nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser([FromBody] UserRequest userDTO)
        {

            await _userService.Update(userDTO);
            return Ok();

        }

        [HttpDelete]
        [Route(nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser([FromBody] int userId)
        {

            await _userService.Delete(userId);
            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetEvent(int id)
        {

            return Ok(await _userService.Get(id));

        }


        //}

        [HttpPost]
        [AllowAnonymous]
        [Route(nameof(CreateUser))]
        public async Task<ActionResult> CreateUser(long fbkey, string accessToken)
        {
            var result = await _userService.AddUser(fbkey, accessToken);
            return Ok(result);
        }



        [HttpPost]
        [Route("UploadImages")]
        public async Task<ActionResult> Upload(int id, IFormFileCollection files)
        {
            var user = await _userService.GetUser(id);
            await _service.SendUpdateMessage(user.MongoKey, files);
            return Ok();
        }
    }
}
