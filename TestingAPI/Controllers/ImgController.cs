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
        /// <summary>
        /// Upload an image to a specific guid
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="files"></param>
        /// <returns>json string that says wether it was successfull or not</returns>
        
        [HttpPost]
        public async Task<ActionResult> Upload(string guid,IFormFileCollection files)
        {
            await _service.SendAddMessage(guid,files);
            return Ok(new { success = "true" });
        }
        /// <summary>
        /// Completelly delete the table object associated with this guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult Delete(string guid)
        {
            _service.SendDeleteMessage(guid);
            
            return Ok();
        }

    }
}
