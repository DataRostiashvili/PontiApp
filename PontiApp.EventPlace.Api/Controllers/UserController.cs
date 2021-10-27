using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.UserServices;
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

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route(nameof(CreateUser))]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            try
            {
                await _userService.Add(userDTO);
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
    }
}
