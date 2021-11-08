using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.AuthService;
using PontiApp.EventPlace.Services.UserServices;
using PontiApp.GraphAPICalls;
using PontiApp.MessageSender;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public UserController(IUserService userService, MessagingService service,IJwtProcessor jwtProcessor,IFbClient fbClient)
        {
            _service = service;
            _userService = userService;
            _jwtProcessor = jwtProcessor;
            _fbClient = fbClient;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(UserCreationDTO user)
        {
            try
            {
                await _userService.Add(user);
                await _service.SendAddMessage(user.MongoKey, user.PictureUrl);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateUser))]
        public async Task<ActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                await _userService.Update(userDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeleteUser))]
        public async Task<ActionResult> DeleteUser([FromBody] UserDTO userDTO)
        {
            try
            {
                await _userService.Delete(userDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetEvent(int id)
        {
            try
            {
                return Ok(await _userService.Get(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [Authorize]
        [HttpGet("GetAllUser")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUser()
        {
            try
            {
                return Ok(await _userService.GetAllUser());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Process-User")]
        public async Task<ActionResult> ProcessUser(long fbkey,string accessToken)
        {
            UserCreationDTO user = new UserCreationDTO();
            if (!_userService.UserExists(fbkey))
            {
                user = await _fbClient.GetUser(accessToken, fbkey);
                user.MongoKey = Guid.NewGuid().ToString();
                await _service.SendAddMessage(user.MongoKey, user.PictureUrl);
                await _userService.Add(user);
            }
            return Ok(new
            {
                Token = _jwtProcessor.GenerateJwt(fbkey, accessToken),
                Data = _userService.GetUser(fbkey)
            });
        }

        [HttpGet]
        [Route("Test")]
        public ActionResult Test(string guid)
        {
            _userService.DeleteImage(guid);
            return Ok();
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
