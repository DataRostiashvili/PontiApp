using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.MessageSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly MessagingService _service;
        public ImgController (MessagingService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult> Upload(string guid,IFormFileCollection files)
        {
            await _service.SendAddMessage(guid,files);
            return Ok(new { success = "true" });
        }
    }
}
